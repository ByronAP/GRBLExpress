using GrblExpress.Common.Interfaces;

namespace GrblExpress.Common.Objects
{
    public class TelnetOptions : ITelnetOptions
    {
        private string _host = string.Empty;
        private int _port = TelnetConstants.DefaultPort;                    // Default value
        private int _readTimeoutMs = TelnetConstants.DefaultReadTimeoutMs;  // Default value
        private int _writeTimeoutMs = TelnetConstants.DefaultWriteTimeoutMs;// Default value
        private int _txBufferSize = TelnetConstants.DefaultTXBufferSize;    // Default value
        private int _rxBufferSize = TelnetConstants.DefaultRXBufferSize;    // Default value
        private bool _noDelay = TelnetConstants.DefaultNoDelay;             // Default value
        private bool _lingerEnabled = TelnetConstants.DefaultLingerEnabled; // Default value
        private int _lingerTime = TelnetConstants.DefaultLingerTime;        // Default value

        public string Host
        {
            get => _host;
            set
            {
                if (string.IsNullOrWhiteSpace(value))
                    throw new ArgumentException("Host cannot be null or whitespace.", nameof(value));
                _host = value;
            }
        }

        public int Port
        {
            get => _port;
            set
            {
                if (value < 0 || value > 65535)
                    throw new ArgumentOutOfRangeException(nameof(value), "Port must be between 0 and 65535.");
                _port = value;
            }
        }

        public int ReadTimeoutMs
        {
            get => _readTimeoutMs;
            set
            {
                if (value < 0)
                    throw new ArgumentOutOfRangeException(nameof(value), "Read timeout must be greater than or equal to 0.");
                _readTimeoutMs = value;
            }
        }

        public int WriteTimeoutMs
        {
            get => _writeTimeoutMs;
            set
            {
                if (value < 0)
                    throw new ArgumentOutOfRangeException(nameof(value), "Write timeout must be greater than or equal to 0.");
                _writeTimeoutMs = value;
            }
        }

        public int TXBufferSize
        {
            get => _txBufferSize;
            set
            {
                if (value < 0)
                    throw new ArgumentOutOfRangeException(nameof(value), "TX buffer size must be greater than or equal to 0.");
                _txBufferSize = value;
            }
        }

        public int RXBufferSize
        {
            get => _rxBufferSize;
            set
            {
                if (value < 0)
                    throw new ArgumentOutOfRangeException(nameof(value), "RX buffer size must be greater than or equal to 0.");
                _rxBufferSize = value;
            }
        }

        public bool NoDelay
        {
            get => _noDelay;
            set => _noDelay = value;
        }

        public bool LingerEnabled
        {
            get => _lingerEnabled;
            set => _lingerEnabled = value;
        }

        public int LingerTime
        {
            get => _lingerTime;
            set
            {
                if (value < 0)
                    throw new ArgumentOutOfRangeException(nameof(value), "Linger time must be greater than or equal to 0.");
                _lingerTime = value;
            }
        }
    }
}
