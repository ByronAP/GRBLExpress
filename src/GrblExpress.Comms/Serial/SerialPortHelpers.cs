using GrblExpress.Common.Types;
using System.IO.Ports;

namespace GrblExpress.Comms.Serial
{
    public static class SerialPortHelpers
    {
        public static string[] ListAvailablePorts() => SerialPort.GetPortNames();

        public static string[] ListHandshakes() => Enum.GetNames<Handshake>();

        public static string[] ListParities() => Enum.GetNames<Parity>();

        public static string[] ListStopBits() => Enum.GetNames<StopBits>();

        public static string[] ListDataBits() => Enum.GetNames<DataBits>();

        public static string[] ListBaudRates() => Enum.GetNames<BaudRate>();

        public static string[] ListResetModes() => Enum.GetNames<DeviceResetMode>();
    }
}
