using System;
using System.Runtime.InteropServices;

namespace ResolutionChanger.Win32.DisplayConfig
{
    /// <summary>
    ///     Describes a local identifier for an adapter.
    ///     LUID structure (winnt.h)
    /// </summary>
    [StructLayout(LayoutKind.Sequential)]
    public readonly struct LuId : IEquatable<LuId>
    {
        /// <summary>
        ///     Specifies a DWORD that contains the unsigned lower numbers of the id.
        /// </summary>
        public readonly uint LowPart;

        /// <summary>
        ///     Specifies a LONG that contains the signed high numbers of the id.
        /// </summary>
        public readonly int HighPart;

        public bool Equals(LuId other)
        {
            return LowPart == other.LowPart && HighPart == other.HighPart;
        }

        public override bool Equals(object obj)
        {
            return obj is LuId other && Equals(other);
        }

        public override int GetHashCode()
        {
            return HashCode.Combine(LowPart, HighPart);
        }

        public static bool operator ==(LuId left, LuId right)
        {
            return left.Equals(right);
        }

        public static bool operator !=(LuId left, LuId right)
        {
            return !left.Equals(right);
        }
    }
}