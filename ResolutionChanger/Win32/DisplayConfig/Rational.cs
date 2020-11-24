using System.Runtime.InteropServices;

namespace ResolutionChanger.Win32.DisplayConfig
{
    /// <summary>
    ///     The DISPLAYCONFIG_RATIONAL structure describes a fractional value that represents vertical and horizontal
    ///     frequencies of a video mode (that is, vertical sync and horizontal sync).
    ///     DISPLAYCONFIG_RATIONAL structure (wingdi.h)
    /// </summary>
    [StructLayout(LayoutKind.Sequential)]
    public struct Rational
    {
        /// <summary>
        ///     The numerator of the frequency fraction.
        /// </summary>
        public uint Numerator;

        /// <summary>
        ///     The denominator of the frequency fraction.
        /// </summary>
        public uint Denominator;
    }
}