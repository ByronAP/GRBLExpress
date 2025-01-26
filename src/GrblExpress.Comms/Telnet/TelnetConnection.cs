using GrblExpress.Common;
using GrblExpress.Common.Interfaces;
using GrblExpress.Common.Objects;
using GrblExpress.Common.Types;
using System.Net.Sockets;
using System.Text;

namespace GrblExpress.Comms.Telnet
{
    public class TelnetConnection : IMachineConnection
    {
        public event DataReceivedEventHandler? DataReceived;
        public event ErrorReceivedEventHandler? ErrorReceived;
        public event ConnectionStateChangedEventHandler? ConnectionStateChanged;

        public ConnectionType ConnectionType => ConnectionType.Telnet;
        public bool IsOpen => _tcpClient.Connected;

        private readonly TelnetOptions _options;
        private readonly TcpClient _tcpClient;
        private NetworkStream? _networkStream;
        private readonly SemaphoreSlim _commandSemaphore;
        private readonly Timer _stateCheckTimer;
        private bool _lastState;
        private bool _awaitingAck;
        private GrblCommandAck _ack;

        public TelnetConnection(TelnetOptions options)
        {
            _options = options;
            _commandSemaphore = new SemaphoreSlim(1, 1);
            _stateCheckTimer = new Timer(CheckState, null, 100, 100);
            _awaitingAck = false;
            _ack = new();

            _tcpClient = new TcpClient
            {
                ReceiveTimeout = _options.ReadTimeoutMs,
                SendTimeout = _options.WriteTimeoutMs,
                ReceiveBufferSize = _options.RXBufferSize,
                SendBufferSize = _options.TXBufferSize,
                NoDelay = _options.NoDelay,
                LingerState = new LingerOption(_options.LingerEnabled, _options.LingerTime)
            };
        }

        private void CheckState(object? state)
        {
            if (_lastState != IsOpen)
            {
                _lastState = IsOpen;
                ConnectionStateChanged?.Invoke(this, _lastState);
            }
        }

        public void Open()
        {
            if (IsOpen) return;

            _tcpClient.Connect(_options.Host, _options.Port);
            _networkStream = _tcpClient.GetStream();
            StartReading();
        }

        public void Close()
        {
            if (!IsOpen) return;

            _networkStream?.Close();
            _tcpClient.Close();
        }

        private async void StartReading()
        {
            var buffer = new byte[_options.RXBufferSize];
            while (IsOpen)
            {
                int bytesRead = await _networkStream!.ReadAsync(buffer, 0, buffer.Length);
                if (bytesRead > 0)
                {
                    var messageData = new ReadOnlyMemory<byte>(buffer, 0, bytesRead);
                    if (_awaitingAck)
                    {
                        _ack.Status = messageData.GetAckType();

                        if (_ack.Status == GrblCommandAckStatus.Unknown)
                        {
                            _ack.Message += Encoding.ASCII.GetString(messageData.ToArray());
                        }
                        else
                        {
                            if (_ack.Status == GrblCommandAckStatus.Ok)
                            {
                                var msg = Encoding.ASCII.GetString(messageData.ToArray());
                                msg = msg.Remove(msg.LastIndexOf("ok"));
                                _ack.Message += msg;
                            }
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
            }
        }

        public async Task<GrblCommandAck> SendCommandAsync(string command, bool awaitAck = true, int timeoutMs = TelnetConstants.DefaultCommandAckTimeoutMs)
        {
            await _commandSemaphore.WaitAsync();
            try
            {
                if (IsOpen)
                {
                    _ack.Message = string.Empty;
                    _ack.Status = GrblCommandAckStatus.Unknown;
                    _awaitingAck = awaitAck;
                    var commandBytes = Encoding.ASCII.GetBytes(command + '\r' + GrblConstants.CommandTerminationChar);
                    await _networkStream!.WriteAsync(commandBytes, 0, commandBytes.Length);

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
                    throw new InvalidOperationException("Telnet connection is not open.");
                }
            }
            finally
            {
                _commandSemaphore.Release();
            }
        }

        public void SendData(string data)
        {
            if (IsOpen)
            {
                var dataBytes = Encoding.ASCII.GetBytes(data);
                _networkStream!.Write(dataBytes, 0, dataBytes.Length);
                Console.WriteLine($"Sent: {data}");
            }
            else
            {
                throw new InvalidOperationException("Telnet connection is not open.");
            }
        }

        public void SendData(char data)
        {
            if (IsOpen)
            {
                var dataBytes = new[] { (byte)data };
                _networkStream!.Write(dataBytes, 0, dataBytes.Length);
                Console.WriteLine($"Sent: {data}");
            }
            else
            {
                throw new InvalidOperationException("Telnet connection is not open.");
            }
        }

        public void SendData(byte[] data)
        {
            if (IsOpen)
            {
                _networkStream!.Write(data, 0, data.Length);
                Console.WriteLine($"Sent: {BitConverter.ToString(data)}");
            }
            else
            {
                throw new InvalidOperationException("Telnet connection is not open.");
            }
        }

        public void Dispose()
        {
            _stateCheckTimer.Dispose();
            if (IsOpen) Close();
            _commandSemaphore.Dispose();
            _networkStream?.Dispose();
            _tcpClient?.Dispose();
            Console.WriteLine("Telnet connection disposed.");
        }
    }
}
