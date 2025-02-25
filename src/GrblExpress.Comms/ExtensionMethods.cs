﻿using GrblExpress.Common.Types;

namespace GrblExpress.Comms
{
    public static class ExtensionMethods
    {
        public static GrblCommandAckStatus GetAckType(this ReadOnlyMemory<byte> data)
        {
            var span = data.Span;

#pragma warning disable IDE0230 // Use UTF-8 string literal, GRBL uses ascii
            if (span.IndexOf(new byte[] { 111, 107 }) >= 0) return GrblCommandAckStatus.Ok;
            if (span.IndexOf(new byte[] { 79, 75 }) >= 0) return GrblCommandAckStatus.Ok;
            if (span.IndexOf(new byte[] { 101, 114, 114, 111, 114 }) >= 0) return GrblCommandAckStatus.Error;
            if (span.IndexOf(new byte[] { 69, 82, 82, 79, 82 }) >= 0) return GrblCommandAckStatus.Error;
#pragma warning restore IDE0230 // Use UTF-8 string literal

            return GrblCommandAckStatus.Unknown;
        }
    }
}
