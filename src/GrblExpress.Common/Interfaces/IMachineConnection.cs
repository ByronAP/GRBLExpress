using GrblExpress.Common.Objects;
using GrblExpress.Common.Types;

namespace GrblExpress.Common.Interfaces
{
    public interface IMachineConnection : IDisposable
    {
        // Events
        public event DataReceivedEventHandler? DataReceived;
        public event ErrorReceivedEventHandler? ErrorReceived;
        public event ConnectionStateChangedEventHandler? ConnectionStateChanged;

        // Properties
        public ConnectionType ConnectionType { get; }
        public bool IsOpen { get; }

        // Functions
        public void Open();
        public void Close();
        public Task<GrblCommandAck> SendCommandAsync(string command, bool awaitAck, int timeoutMs);
        public void SendData(string data);
        public void SendData(char data);
        public void SendData(byte[] data);
    }
}
