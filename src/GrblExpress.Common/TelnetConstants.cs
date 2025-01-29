namespace GrblExpress.Common
{
    public static class TelnetConstants
    {
        public const int DefaultPort = 23;
        public const int DefaultReadTimeoutMs = 500;
        public const int DefaultWriteTimeoutMs = 500;
        public const int DefaultTXBufferSize = 2048;
        public const int DefaultRXBufferSize = 1024;
        public const int DefaultCommandAckTimeoutMs = 1000;
        public const bool DefaultNoDelay = false;
        public const bool DefaultLingerEnabled = false;
        public const int DefaultLingerTime = 0;
    }
}
