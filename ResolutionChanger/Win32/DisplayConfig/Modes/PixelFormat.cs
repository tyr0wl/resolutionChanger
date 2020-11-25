namespace ResolutionChanger.Win32.DisplayConfig.Modes
{
    /// <summary>
    ///     The DISPLAYCONFIG_PIXELFORMAT enumeration specifies pixel format in various bits per pixel (BPP) values.
    ///     DISPLAYCONFIG_PIXELFORMAT enumeration (wingdi.h)
    /// </summary>
    public enum PixelFormat : uint
    {
        None = 0,

        /// <summary>
        ///     Indicates 8 BPP format.
        ///     DISPLAYCONFIG_PIXELFORMAT_8BPP
        /// </summary>
        PixelFormat8Bpp = 1,

        /// <summary>
        ///     Indicates 16 BPP format.
        ///     DISPLAYCONFIG_PIXELFORMAT_16BPP
        /// </summary>
        PixelFormat16Bpp = 2,

        /// <summary>
        ///     Indicates 24 BPP format.
        ///     DISPLAYCONFIG_PIXELFORMAT_24BPP
        /// </summary>
        PixelFormat24Bpp = 3,

        /// <summary>
        ///     Indicates 32 BPP format.
        ///     DISPLAYCONFIG_PIXELFORMAT_32BPP
        /// </summary>
        PixelFormat32Bpp = 4,

        /// <summary>
        ///     Indicates that the current display is not an 8, 16, 24, or 32 BPP GDI desktop mode. For example, a call to the
        ///     <see cref="DisplayConfigApi.QueryDisplayConfig" /> function returns <see cref="PixelFormatNonGdi" /> if a DirectX
        ///     application previously set the desktop to A2R10G10B10 format. A call to the
        ///     <see cref="DisplayConfigApi.SetDisplayConfig" /> function fails if any pixel formats for active paths are set to
        ///     <see cref="PixelFormatNonGdi" />.
        ///     DISPLAYCONFIG_PIXELFORMAT_NONGDI
        /// </summary>
        PixelFormatNonGdi = 5
    }
}