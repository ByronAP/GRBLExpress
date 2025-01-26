namespace GrblExpress.Comms.Websocket
{
    public class WebsocketOptions
    {
        private int _receiveBufferSize = WebsocketConstants.DefaultReceiveBufferSize;
        private string _uri = string.Empty;

        public int ReceiveBufferSize
        {
            get => _receiveBufferSize;
            set
            {
                if (value < 1)
                {
                    throw new ArgumentOutOfRangeException(nameof(ReceiveBufferSize), "Receive buffer size must be greater than 0");
                }
                _receiveBufferSize = value;
            }
        }

        public string Uri
        {
            get => _uri;
            set
            {
                if (!value.StartsWith("ws://") && !value.StartsWith("wss://"))
                {
                    throw new ArgumentException("Uri must start with ws:// or wss://");
                }
                _uri = value;
            }
        }
    }
}
