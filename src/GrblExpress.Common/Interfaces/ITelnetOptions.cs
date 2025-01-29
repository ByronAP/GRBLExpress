namespace GrblExpress.Common.Interfaces
{
    public interface ITelnetOptions
    {
        public string Host { get; set; }
        public int Port { get; set; }
        public int ReadTimeoutMs { get; set; }
        public int WriteTimeoutMs { get; set; }
        public int TXBufferSize { get; set; }
        public int RXBufferSize { get; set; }
        public bool NoDelay { get; set; }
        public bool LingerEnabled { get; set; }
        public int LingerTime { get; set; }
    }
}
