using GrblExpress.Common;
using GrblExpress.Common.Interfaces;
using GrblExpress.Common.Objects;
using GrblExpress.Common.Types;
using System.Buffers;
using System.Net.WebSockets;
using System.Text;

namespace GrblExpress.Comms.Websocket
{
    public class WebsocketConnection : IMachineConnection
    {
        public event DataReceivedEventHandler? DataReceived;
        public event ErrorReceivedEventHandler? ErrorReceived;
        public event ConnectionStateChangedEventHandler? ConnectionStateChanged;

        public ConnectionType ConnectionType => ConnectionType.Websocket;
        public bool IsOpen => _webSocket?.State == WebSocketState.Open;

        private readonly WebsocketOptions _options;
        private readonly ClientWebSocket _webSocket;
        private readonly SemaphoreSlim _commandSemaphore;
        private readonly Timer _stateCheckTimer;
        private bool _lastState;
        private byte[] _buffer;
        private int _bufferLength = 0;
        private bool _awaitingAck;
        private GrblCommandAck _ack;
        private readonly CancellationTokenSource _cancellationTokenSource;

        public WebsocketConnection(WebsocketOptions options)
        {
            _options = options;
            _commandSemaphore = new SemaphoreSlim(1, 1);
            _stateCheckTimer = new Timer(CheckState, null, 100, 100);
            _awaitingAck = false;
            _ack = new();
            _cancellationTokenSource = new CancellationTokenSource();

            _webSocket = new ClientWebSocket();
            //_webSocket.Options.SetRequestHeader("User-Agent", "GrblExpress");

            // Initialize the buffer
            _buffer = ArrayPool<byte>.Shared.Rent(_options.ReceiveBufferSize);
        }

        private void CheckState(object? state)
        {
            if (_lastState != IsOpen)
            {
                _lastState = IsOpen;
                ConnectionStateChanged?.Invoke(this, _lastState);
            }
        }

        public async void Open()
        {
            await _webSocket.ConnectAsync(new Uri(_options.Uri), _cancellationTokenSource.Token);
            StartReading();
        }

        public async void Close()
        {
            if (IsOpen)
            {
                await _webSocket.CloseAsync(WebSocketCloseStatus.NormalClosure, "Closing", CancellationToken.None);
                _cancellationTokenSource.Cancel();
            }
        }

        private async void StartReading()
        {
            var receiveBuffer = new byte[_options.ReceiveBufferSize];
            var buffer = new ArraySegment<byte>(receiveBuffer);

            try
            {
                while (IsOpen && !_cancellationTokenSource.IsCancellationRequested)
                {
                    var result = await _webSocket.ReceiveAsync(buffer, _cancellationTokenSource.Token);

                    if (result.MessageType == WebSocketMessageType.Close)
                    {
                        await _webSocket.CloseAsync(WebSocketCloseStatus.NormalClosure, "Closing", _cancellationTokenSource.Token);
                        ConnectionStateChanged?.Invoke(this, false);
                        break;
                    }

                    if (result.Count > 0)
                    {
                        ProcessReceivedData(buffer.Array!, result.Count, result.EndOfMessage);
                    }
                }
            }
            catch (Exception ex)
            {
                ErrorReceived?.Invoke(this, ex.Message);
            }
        }

        private void ProcessReceivedData(byte[] data, int count, bool endOfMessage)
        {
            Buffer.BlockCopy(data, 0, _buffer, _bufferLength, count);
            _bufferLength += count;

            if (endOfMessage)
            {
                int startIndex = 0;
                int messageEndIndex;

                while (startIndex < _bufferLength)
                {
                    messageEndIndex = Array.FindIndex(_buffer, startIndex, _bufferLength - startIndex, b => b == '\r' || b == '\n');

                    if (messageEndIndex >= 0)
                    {
                        int messageLength = messageEndIndex - startIndex;
                        if (messageLength > 0)
                        {
                            var messageData = new ReadOnlyMemory<byte>(_buffer, startIndex, messageLength);
                            HandleReceivedMessage(messageData);
                        }

                        // Move to the byte after the newline character
                        startIndex = messageEndIndex + 1;
                    }
                    else
                    {
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
        }

        private void HandleReceivedMessage(ReadOnlyMemory<byte> messageData)
        {
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
                        msg = msg.Substring(msg.IndexOf(':') + 1);
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

        public async Task<GrblCommandAck> SendCommandAsync(string command, bool awaitAck = true, int timeoutMs = WebsocketConstants.DefaultCommandAckTimeoutMs)
        {
            await _commandSemaphore.WaitAsync();
            try
            {
                if (IsOpen)
                {
                    _ack.Message = string.Empty;
                    _ack.Status = GrblCommandAckStatus.Unknown;
                    _awaitingAck = awaitAck;

                    var commandBytes = Encoding.ASCII.GetBytes(command + GrblConstants.CommandTerminationChar);
                    await _webSocket.SendAsync(new ArraySegment<byte>(commandBytes), WebSocketMessageType.Text, true, CancellationToken.None);

                    using (var cts = new CancellationTokenSource(timeoutMs))
                    {
                        try
                        {
                            while (_awaitingAck)
                            {
                                cts.Token.ThrowIfCancellationRequested();
                                await Task.Delay(10, cts.Token);
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
                    throw new InvalidOperationException("WebSocket connection is not open.");
                }
            }
            finally
            {
                _commandSemaphore.Release();
            }
        }

        public async void SendData(string data)
        {
            if (IsOpen)
            {
                var dataBytes = Encoding.ASCII.GetBytes(data);
                await _webSocket.SendAsync(new ArraySegment<byte>(dataBytes), WebSocketMessageType.Text, true, CancellationToken.None);
                Console.WriteLine($"Sent: {data}");
            }
            else
            {
                throw new InvalidOperationException("WebSocket connection is not open.");
            }
        }

        public void SendData(char data)
        {
            SendData(data.ToString());
        }

        public async void SendData(byte[] data)
        {
            if (IsOpen)
            {
                await _webSocket.SendAsync(new ArraySegment<byte>(data), WebSocketMessageType.Binary, true, CancellationToken.None);
                Console.WriteLine($"Sent: {BitConverter.ToString(data)}");
            }
            else
            {
                throw new InvalidOperationException("WebSocket connection is not open.");
            }
        }

        public void Dispose()
        {
            _stateCheckTimer.Dispose();
            if (IsOpen)
            {
                Close();
            }
            _commandSemaphore.Dispose();
            _cancellationTokenSource.Cancel();
            _webSocket.Dispose();
            if (_buffer != null)
            {
                ArrayPool<byte>.Shared.Return(_buffer);
                _buffer = null!;
            }
            Console.WriteLine("WebSocket connection disposed.");
        }
    }
}
