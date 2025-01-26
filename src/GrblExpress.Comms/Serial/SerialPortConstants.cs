using GrblExpress.Common.Types;
using System.IO.Ports;

namespace GrblExpress.Comms.Serial
{
    public static class SerialPortConstants
    {
        public const BaudRate DefaultBaudRate = BaudRate.Baud115200;
        public const DataBits DefaultDataBits = DataBits.Eight;
        public const Parity DefaultParity = Parity.None;
        public const StopBits DefaultStopBits = StopBits.One;
        public const Handshake DefaultHandshake = Handshake.None;
        public const DeviceResetMode DefaultResetMode = DeviceResetMode.None;
        public const int DefaultReadTimeoutMs = 100;
        public const int DefaultWriteTimeoutMs = 100;
        public const int DefaultTXBufferSize = 4096;
        public const int DefaultRXBufferSize = 1024;
        public const int DefaultResetDelayMs = 0;
        public const int DefaultCommandAckTimeoutMs = 1000;
    }
}
