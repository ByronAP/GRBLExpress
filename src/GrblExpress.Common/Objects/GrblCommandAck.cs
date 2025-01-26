using GrblExpress.Common.Types;

namespace GrblExpress.Common.Objects
{
    public class GrblCommandAck
    {
        public GrblCommandAckStatus Status { get; set; } = GrblCommandAckStatus.Unknown;
        public string Message { get; set; } = string.Empty;

        public new string ToString()
        {
            return $"Status: {Status}, Message: {Message}";
        }
    }
}
