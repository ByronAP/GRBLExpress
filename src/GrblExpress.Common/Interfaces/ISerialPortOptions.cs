using GrblExpress.Common.Types;
using System.IO.Ports;

namespace GrblExpress.Common.Interfaces
{
    public interface ISerialPortOptions
    {
        public string PortName { get; set; }
        public BaudRate BaudRate { get; set; }
        public DataBits DataBits { get; set; }
        public Parity Parity { get; set; }
        public StopBits StopBits { get; set; }
        public Handshake Handshake { get; set; }
        public DeviceResetMode ResetMode { get; set; }
        public int ReadTimeoutMs { get; set; }
        public int WriteTimeoutMs { get; set; }
        public int TXBufferSize { get; set; }
        public int RXBufferSize { get; set; }
        public int ResetDelayMs { get; set; }
    }
}
