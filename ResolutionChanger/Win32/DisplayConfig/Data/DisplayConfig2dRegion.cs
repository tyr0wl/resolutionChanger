using System.Runtime.InteropServices;

namespace ResolutionChanger.Win32.DisplayConfig.Data
{
    /// <summary>
    ///     The DISPLAYCONFIG_2DREGION structure represents a point or an offset in a two-dimensional space.
    ///     DISPLAYCONFIG_2DREGION structure (wingdi.h)
    /// </summary>
    [StructLayout(LayoutKind.Sequential)]
    public struct DisplayConfig2dRegion
    {
        /// <summary>
        ///     The horizontal component of the point or offset.
        /// </summary>
        public uint cx;

        /// <summary>
        ///     The vertical component of the point or offset.
        /// </summary>
        public uint cy;

        public override string ToString()
        {
            return $"{{{nameof(cx)}: {cx}, {nameof(cy)}: {cy}}}";
        }
    }
}