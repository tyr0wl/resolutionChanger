using System.Runtime.InteropServices;

namespace ResolutionChanger.Win32.DisplayConfig.ModeInfo
{
    /// <summary>
    ///     The DISPLAYCONFIG_DESKTOP_IMAGE_INFO structure contains information about the image displayed on the desktop.
    ///     DISPLAYCONFIG_DESKTOP_IMAGE_INFO structure (wingdi.h)
    /// </summary>
    [StructLayout(LayoutKind.Sequential)]
    internal struct DesktopImageInfo
    {
        /// <summary>
        ///     A POINTL structure that specifies the size of the VidPn source surface that is being displayed on the monitor.
        /// </summary>
        [MarshalAs(UnmanagedType.Struct)] public PointL PathSourceSize;

        /// <summary>
        ///     A RECTL structure that defines where the desktop image will be positioned within path source. Region must be completely inside the bounds of the path source size.
        /// </summary>
        [MarshalAs(UnmanagedType.Struct)] public RectangleL DesktopImageRegion;

        /// <summary>
        ///     A RECTL structure that defines which part of the desktop image for this clone group will be displayed on this path. This currently must be set to the desktop size.
        /// </summary>
        [MarshalAs(UnmanagedType.Struct)] public RectangleL DesktopImageClip;
    }
}