using GrblExpress.Common.Types;
using System.IO.Ports;

namespace GrblExpress.Comms.Serial
{
    public class SerialPortOptions
    {
        private string _portName = string.Empty;
        private BaudRate _baudRate = SerialPortConstants.DefaultBaudRate;           // Default value
        private DataBits _dataBits = SerialPortConstants.DefaultDataBits;           // Default value
        private Parity _parity = SerialPortConstants.DefaultParity;                 // Default value
        private StopBits _stopBits = SerialPortConstants.DefaultStopBits;           // Default value
        private Handshake _handshake = SerialPortConstants.DefaultHandshake;        // Default value
        private DeviceResetMode _resetMode = SerialPortConstants.DefaultResetMode;  // Default value
        private int _readTimeoutMs = SerialPortConstants.DefaultReadTimeoutMs;      // Default value
        private int _writeTimeoutMs = SerialPortConstants.DefaultWriteTimeoutMs;    // Default value
        private int _txBufferSize = SerialPortConstants.DefaultTXBufferSize;        // Default value
        private int _rxBufferSize = SerialPortConstants.DefaultRXBufferSize;        // Default value
        private int _resetDelayMs = SerialPortConstants.DefaultResetDelayMs;        // Default value

        public string PortName
        {
            get => _portName;
            set
            {
                if (string.IsNullOrWhiteSpace(value))
                    throw new ArgumentException("Port name cannot be null or whitespace.", nameof(value));
                if (!SerialPortHelpers.ListAvailablePorts().Contains(value))
                    throw new ArgumentException("Port name is not available.", nameof(value));
                _portName = value;
            }
        }

        public BaudRate BaudRate
        {
            get => _baudRate;
            set
            {
                if (!Enum.IsDefined(typeof(BaudRate), value))
                    throw new ArgumentOutOfRangeException(nameof(value), "Invalid baud rate.");
                _baudRate = value;
            }
        }

        public DataBits DataBits
        {
            get => _dataBits;
            set
            {
                if (!Enum.IsDefined(typeof(DataBits), value))
                    throw new ArgumentOutOfRangeException(nameof(value), "Invalid data bits.");
                _dataBits = value;
            }
        }

        public Parity Parity
        {
            get => _parity;
            set
            {
                if (!Enum.IsDefined(typeof(Parity), value))
                    throw new ArgumentOutOfRangeException(nameof(value), "Invalid parity.");
                _parity = value;
            }
        }

        public StopBits StopBits
        {
            get => _stopBits;
            set
            {
                if (!Enum.IsDefined(typeof(StopBits), value))
                    throw new ArgumentOutOfRangeException(nameof(value), "Invalid stop bits.");
                _stopBits = value;
            }
        }

        public Handshake Handshake
        {
            get => _handshake;
            set
            {
                if (!Enum.IsDefined(typeof(Handshake), value))
                    throw new ArgumentOutOfRangeException(nameof(value), "Invalid handshake.");
                _handshake = value;
            }
        }

        public DeviceResetMode ResetMode
        {
            get => _resetMode;
            set
            {
                if (!Enum.IsDefined(typeof(DeviceResetMode), value))
                    throw new ArgumentOutOfRangeException(nameof(value), "Invalid reset mode.");
                _resetMode = value;
            }
        }

        public int ReadTimeoutMs
        {
            get => _readTimeoutMs;
            set
            {
                if (value < 0)
                    throw new ArgumentOutOfRangeException(nameof(value), "Read timeout must be greater than or equal to zero.");
                _readTimeoutMs = value;
            }
        }

        public int WriteTimeoutMs
        {
            get => _writeTimeoutMs;
            set
            {
                if (value < 0)
                    throw new ArgumentOutOfRangeException(nameof(value), "Write timeout must be greater than or equal to zero.");
                _writeTimeoutMs = value;
            }
        }

        public int TXBufferSize
        {
            get => _txBufferSize;
            set
            {
                if (value < 0)
                    throw new ArgumentOutOfRangeException(nameof(value), "TX buffer size must be greater than or equal to zero.");
                _txBufferSize = value;
            }
        }

        public int RXBufferSize
        {
            get => _rxBufferSize;
            set
            {
                if (value < 0)
                    throw new ArgumentOutOfRangeException(nameof(value), "RX buffer size must be greater than or equal to zero.");
                _rxBufferSize = value;
            }
        }

        public int ResetDelayMs
        {
            get => _resetDelayMs;
            set
            {
                if (value < 0)
                    throw new ArgumentOutOfRangeException(nameof(value), "Reset delay must be greater than or equal to zero.");
                _resetDelayMs = value;
            }
        }

        public override string ToString()
        {
            return $"PortName: {PortName}, BaudRate: {BaudRate}, DataBits: {DataBits}, Parity: {Parity}, StopBits: {StopBits}, Handshake: {Handshake}, ResetMode: {ResetMode}, ReadTimeout: {ReadTimeoutMs}, WriteTimeout: {WriteTimeoutMs}, TXBufferSz: {TXBufferSize}, RXBufferSz: {RXBufferSize}, ResetDelay: {ResetDelayMs}";
        }

        public override bool Equals(object? obj)
        {
            if (obj is SerialPortOptions other)
            {
                return PortName == other.PortName &&
                       BaudRate == other.BaudRate &&
                       DataBits == other.DataBits &&
                       Parity == other.Parity &&
                       StopBits == other.StopBits &&
                       Handshake == other.Handshake &&
                       ResetMode == other.ResetMode &&
                       ReadTimeoutMs == other.ReadTimeoutMs &&
                       WriteTimeoutMs == other.WriteTimeoutMs &&
                       TXBufferSize == other.TXBufferSize &&
                       RXBufferSize == other.RXBufferSize &&
                       ResetDelayMs == other.ResetDelayMs;
            }
            return false;
        }

        public override int GetHashCode()
        {
            return HashCode.Combine(PortName, BaudRate, DataBits, Parity, StopBits, Handshake, ResetMode) ^
                   HashCode.Combine(ReadTimeoutMs, WriteTimeoutMs, TXBufferSize, RXBufferSize, ResetDelayMs);
        }
    }
}
