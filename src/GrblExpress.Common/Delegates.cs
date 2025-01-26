namespace GrblExpress.Common
{
    public delegate void DataReceivedEventHandler(object sender, ReadOnlyMemory<byte> data);
    public delegate void ErrorReceivedEventHandler(object sender, string error);
    public delegate void ConnectionStateChangedEventHandler(object sender, bool isConnected);
}
