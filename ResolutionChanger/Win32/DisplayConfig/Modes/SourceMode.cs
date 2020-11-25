using System.Runtime.InteropServices;

namespace ResolutionChanger.Win32.DisplayConfig.Modes
{
    /// <summary>
    ///     The DISPLAYCONFIG_SOURCE_MODE structure represents a point or an offset in a two-dimensional space.
    ///     DISPLAYCONFIG_SOURCE_MODE structure (wingdi.h)
    /// </summary>
    [StructLayout(LayoutKind.Sequential)]
    public struct SourceMode
    {
        /// <summary>
        ///     The width in pixels of the source mode.
        /// </summary>
        [MarshalAs(UnmanagedType.U4)] public uint width;

        /// <summary>
        ///     The height in pixels of the source mode.
        /// </summary>
        [MarshalAs(UnmanagedType.U4)] public uint height;

        /// <summary>
        ///     A value from the DISPLAYCONFIG_PIXELFORMAT enumeration that specifies the pixel format of the source mode.
        /// </summary>
        [MarshalAs(UnmanagedType.U4)] public PixelFormat pixelFormat;

        /// <summary>
        ///     A POINTL structure that specifies the position in the desktop coordinate space of the upper-left corner of this
        ///     source surface. The source surface that is located at (0, 0) is always the primary source surface.
        /// </summary>
        [MarshalAs(UnmanagedType.Struct)] public PointL position;

        public bool IsEmpty => Equals(this, Empty);

        public static SourceMode Empty => default;

        public override string ToString()
        {
            var pixelFormatString = pixelFormat.ToString().Replace(nameof(PixelFormat), string.Empty);
            return $"{{{GetType().Name} {width}x{height},{pixelFormatString},{position}}}";
        }
    }
}