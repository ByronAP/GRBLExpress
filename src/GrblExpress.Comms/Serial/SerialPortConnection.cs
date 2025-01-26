using GrblExpress.Common;
using GrblExpress.Common.Interfaces;
using GrblExpress.Common.Objects;
using GrblExpress.Common.Types;
using System.Buffers;
using System.IO.Ports;
using System.Text;

namespace GrblExpress.Comms.Serial
{
    public class SerialPortConnection : IMachineConnection
    {
        public event DataReceivedEventHandler? DataReceived;
        public event ErrorReceivedEventHandler? ErrorReceived;
        public event ConnectionStateChangedEventHandler? ConnectionStateChanged;

        public ConnectionType ConnectionType => ConnectionType.Serial;
        public bool IsOpen => _serialPort.IsOpen;

        private readonly SerialPortOptions _options;
        private readonly SerialPort _serialPort;
        private readonly SemaphoreSlim _commandSemaphore;
        private readonly Lock _readLock;
        private readonly Timer _stateCheckTimer;
        private bool _lastState;
        private byte[] _buffer;
        private int _bufferLength = 0;
        private bool _awaitingAck;
        private GrblCommandAck _ack;

        public SerialPortConnection(SerialPortOptions options)
        {
            _options = options;
            _commandSemaphore = new SemaphoreSlim(1, 1);
            _readLock = new Lock();
            _stateCheckTimer = new Timer(CheckState, null, 100, 100);
            _awaitingAck = false;
            _ack = new();

            _serialPort = new SerialPort
            {
                PortName = _options.PortName,
                BaudRate = (int)_options.BaudRate,
                Parity = _options.Parity,
                DataBits = (int)_options.DataBits,
                StopBits = _options.StopBits,
                Handshake = _options.Handshake,
                ReadBufferSize = _options.RXBufferSize,
                WriteBufferSize = _options.TXBufferSize,
                DtrEnable = _options.ResetMode == DeviceResetMode.DTR,
                RtsEnable = _options.ResetMode == DeviceResetMode.RTS,
                WriteTimeout = _options.WriteTimeoutMs,
                ReadTimeout = _options.ReadTimeoutMs
            };

            _serialPort.DataReceived += _serialPort_DataReceived;
            _serialPort.ErrorReceived += _serialPort_ErrorReceived;
            _serialPort.PinChanged += _serialPort_PinChanged;

            // Rent the initial buffer
            _buffer = ArrayPool<byte>.Shared.Rent(_options.RXBufferSize);
        }

        private void CheckState(object? state)
        {
            if (_lastState != IsOpen)
            {
                _lastState = IsOpen;
                ConnectionStateChanged?.Invoke(this, _lastState);
            }
        }

        private void _serialPort_PinChanged(object sender, SerialPinChangedEventArgs e)
        {
            Console.WriteLine($"Serial pin changed: {e.EventType}");
        }

        private void _serialPort_ErrorReceived(object sender, SerialErrorReceivedEventArgs e)
        {
            ErrorReceived?.Invoke(this, e.EventType.ToString());
        }

        private void _serialPort_DataReceived(object sender, SerialDataReceivedEventArgs e)
        {
            lock (_readLock)
            {
                if (e.EventType == SerialData.Chars)
                {
                    int bytesToRead = _serialPort.BytesToRead;

                    while (bytesToRead > 0)
                    {
                        int spaceAvailable = _buffer.Length - _bufferLength;

                        if (spaceAvailable == 0)
                        {
                            // Rent a larger buffer and copy existing data
                            int newSize = _buffer.Length * 2;
                            byte[] newBuffer = ArrayPool<byte>.Shared.Rent(newSize);
                            Buffer.BlockCopy(_buffer, 0, newBuffer, 0, _bufferLength);
                            ArrayPool<byte>.Shared.Return(_buffer);
                            _buffer = newBuffer;
                            spaceAvailable = _buffer.Length - _bufferLength;
                        }

                        int bytesRead = _serialPort.Read(_buffer, _bufferLength, Math.Min(bytesToRead, spaceAvailable));
                        _bufferLength += bytesRead;
                        bytesToRead -= bytesRead;
                    }

                    ProcessBuffer();
                }
            }
        }

        private void ProcessBuffer()
        {
            int messageEndIndex;
            int startIndex = 0;

            while (startIndex < _bufferLength)
            {
                messageEndIndex = Array.FindIndex(_buffer, startIndex, _bufferLength - startIndex, b => b == '\r' || b == '\n');

                if (messageEndIndex >= 0)
                {
                    int messageLength = messageEndIndex - startIndex;
                    if (messageLength > 0)
                    {
                        var messageData = new ReadOnlyMemory<byte>(_buffer, startIndex, messageLength);
                        if (_awaitingAck)
                        {
                            _ack.Status = messageData.GetAckType();

                            if (_ack.Status == GrblCommandAckStatus.Unknown)
                            {
                                _ack.Message += Encoding.ASCII.GetString(messageData.ToArray());
                            }
                            else
                            {
                                if (_ack.Status == GrblCommandAckStatus.Error)
                                {
                                    var msg = Encoding.ASCII.GetString(messageData.ToArray());
                                    msg = msg.Remove(0, msg.IndexOf(':') + 1);
                                    _ack.Message += msg;
                                }

                                _awaitingAck = false;
                            }
                        }
                        else
                        {
                            DataReceived?.Invoke(this, messageData);
                        }
                    }

                    // Move to the byte after the newline character
                    startIndex = messageEndIndex + 1;
                }
                else
                {
                    // No complete message found
                    break;
                }
            }

            if (startIndex == _bufferLength)
            {
                // All data processed; reset buffer
                _bufferLength = 0;
            }
            else if (startIndex > 0)
            {
                // Shift unprocessed data to the start of the buffer
                int remainingBytes = _bufferLength - startIndex;
                Buffer.BlockCopy(_buffer, startIndex, _buffer, 0, remainingBytes);
                _bufferLength = remainingBytes;
            }
        }

        public void Open()
        {
            _serialPort.Open();
        }

        public void Close()
        {
            _serialPort.Close();
        }

        public async Task<GrblCommandAck> SendCommandAsync(string command, bool awaitAck = true, int timeoutMs = SerialPortConstants.DefaultCommandAckTimeoutMs)
        {
            await _commandSemaphore.WaitAsync();
            try
            {
                if (_serialPort.IsOpen)
                {
                    _serialPort.DiscardOutBuffer();
                    _ack.Message = string.Empty;
                    _ack.Status = GrblCommandAckStatus.Unknown;
                    _awaitingAck = awaitAck;
                    _serialPort.Write(command + GrblConstants.CommandTerminationChar);

                    using (var cts = new CancellationTokenSource(timeoutMs))
                    {
                        try
                        {
                            while (_awaitingAck)
                            {
                                if (cts.Token.IsCancellationRequested)
                                {
                                    throw new TimeoutException("Command acknowledgment timed out.");
                                }
                                await Task.Delay(10, cts.Token); // Await asynchronously for just a bit to keep things moving
                            }
                        }
                        catch (OperationCanceledException)
                        {
                            throw new TimeoutException("Command acknowledgment timed out.");
                        }
                    }

                    return _ack;
                }
                else
                {
                    throw new InvalidOperationException("Serial port is not open.");
                }
            }
            finally
            {
                _commandSemaphore.Release();
            }
        }

        public void SendData(string data)
        {
            if (_serialPort.IsOpen)
            {
                _serialPort.DiscardOutBuffer();
                _serialPort.Write(data);
                Console.WriteLine($"Sent: {data}");
            }
            else
            {
                throw new InvalidOperationException("Serial port is not open.");
            }
        }

        public void SendData(char data)
        {
            if (_serialPort.IsOpen)
            {
                _serialPort.DiscardOutBuffer();
                _serialPort.Write(new[] { data }, 0, 1);
                Console.WriteLine($"Sent: {data}");
            }
            else
            {
                throw new InvalidOperationException("Serial port is not open.");
            }
        }

        public void SendData(byte[] data)
        {
            if (_serialPort.IsOpen)
            {
                _serialPort.DiscardOutBuffer();
                _serialPort.Write(data, 0, data.Length);
                Console.WriteLine($"Sent: {BitConverter.ToString(data)}");
            }
            else
            {
                throw new InvalidOperationException("Serial port is not open.");
            }
        }

        public void Dispose()
        {
            _stateCheckTimer.Dispose();
            _serialPort.Dispose();
            if (_buffer != null)
            {
                ArrayPool<byte>.Shared.Return(_buffer);
#pragma warning disable CS8625 // Cannot convert null literal to non-nullable reference type.
                _buffer = null;
#pragma warning restore CS8625 // Cannot convert null literal to non-nullable reference type.
            }
            Console.WriteLine("Serial port disposed.");
        }
    }
}
