namespace GrblExpress.Common.Interfaces
{
    public interface IWebsocketOptions
    {
        public int ReceiveBufferSize { get; set; }
        public string Uri { get; set; }
    }
}
