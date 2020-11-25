using System;
using System.Runtime.InteropServices;

namespace ResolutionChanger.Win32.DisplayConfig
{
    /// <summary>
    ///     Describes a local identifier for an adapter.
    ///     LUID structure (winnt.h)
    /// </summary>
    [StructLayout(LayoutKind.Sequential)]
    public struct LuId : IEquatable<LuId>
    {
        /// <summary>
        ///     Specifies a DWORD that contains the unsigned lower numbers of the id.
        /// </summary>
        public uint LowPart;

        /// <summary>
        ///     Specifies a LONG that contains the signed high numbers of the id.
        /// </summary>
        public int HighPart;

        public LuId(uint lowPart, int highPart)
        {
            LowPart = lowPart;
            HighPart = highPart;
        }

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

        public override string ToString()
        {
            return $"{GetType().Name} {{{LowPart},{HighPart}}}";
        }

        public static explicit operator LuId(uint lowPart)
        {
            return new (lowPart, 0);
        }
    }
}