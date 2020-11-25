namespace ResolutionChanger.Win32.DisplayConfig.Data
{
    /// <summary>
    ///     The DISPLAYCONFIG_VIDEO_OUTPUT_TECHNOLOGY enumeration specifies the target's connector type.
    ///     DISPLAYCONFIG_VIDEO_OUTPUT_TECHNOLOGY enumeration (wingdi.h)
    /// </summary>
    public enum VideoOutputTechnology : uint
    {
        /// <summary>
        ///     Indicates a connector that is not one of the types that is indicated by the following enumerators in this
        ///     enumeration.
        ///     DISPLAYCONFIG_OUTPUT_TECHNOLOGY_OTHER
        /// </summary>
        Other = 0xFFFFFFFF,

        /// <summary>
        ///     Indicates an HD15 (VGA) connector.
        ///     DISPLAYCONFIG_OUTPUT_TECHNOLOGY_HD15
        /// </summary>
        Hd15 = 0,

        /// <summary>
        ///     Indicates an S-video connector.
        ///     DISPLAYCONFIG_OUTPUT_TECHNOLOGY_SVIDEO
        /// </summary>
        SVideo = 1,

        /// <summary>
        ///     Indicates a composite video connector group.
        ///     DISPLAYCONFIG_OUTPUT_TECHNOLOGY_COMPOSITE_VIDEO
        /// </summary>
        CompositeVideo = 2,

        /// <summary>
        ///     Indicates a component video connector group.
        ///     DISPLAYCONFIG_OUTPUT_TECHNOLOGY_COMPONENT_VIDEO
        /// </summary>
        ComponentVideo = 3,

        /// <summary>
        ///     Indicates a Digital Video Interface (DVI) connector.
        ///     DISPLAYCONFIG_OUTPUT_TECHNOLOGY_DVI
        /// </summary>
        Dvi = 4,

        /// <summary>
        ///     Indicates a High-Definition Multimedia Interface (HDMI) connector.
        ///     DISPLAYCONFIG_OUTPUT_TECHNOLOGY_HDMI
        /// </summary>
        Hdmi = 5,

        /// <summary>
        ///     Indicates a Low Voltage Differential Swing (LVDS) connector.
        ///     DISPLAYCONFIG_OUTPUT_TECHNOLOGY_LVDS
        /// </summary>
        Lvds = 6,

        /// <summary>
        ///     Indicates a Japanese D connector.
        ///     DISPLAYCONFIG_OUTPUT_TECHNOLOGY_D_JPN
        /// </summary>
        DJpn = 8,

        /// <summary>
        ///     Indicates an SDI connector.
        ///     DISPLAYCONFIG_OUTPUT_TECHNOLOGY_SDI
        /// </summary>
        Sdi = 9,

        /// <summary>
        ///     Indicates an external display port, which is a display port that connects externally to a display device.
        ///     DISPLAYCONFIG_OUTPUT_TECHNOLOGY_DISPLAYPORT_EXTERNAL
        /// </summary>
        DisplayPortExternal = 10,

        /// <summary>
        ///     Indicates an embedded display port that connects internally to a display device.
        ///     DISPLAYCONFIG_OUTPUT_TECHNOLOGY_DISPLAYPORT_EMBEDDED
        /// </summary>
        DisplayPortEmbedded = 11,

        /// <summary>
        ///     Indicates an external Unified Display Interface (UDI), which is a UDI that connects externally to a display device.
        ///     DISPLAYCONFIG_OUTPUT_TECHNOLOGY_UDI_EXTERNAL
        /// </summary>
        UdiExternal = 12,

        /// <summary>
        ///     Indicates an embedded UDI that connects internally to a display device.
        ///     DISPLAYCONFIG_OUTPUT_TECHNOLOGY_UDI_EMBEDDED
        /// </summary>
        UdiEmbedded = 13,

        /// <summary>
        ///     Indicates a dongle cable that supports standard definition television (SDTV).
        ///     DISPLAYCONFIG_OUTPUT_TECHNOLOGY_SDTVDONGLE
        /// </summary>
        SDtvDongle = 14,

        /// <summary>
        ///     Indicates that the VidPN target is a Miracast wireless display device.
        ///     Supported starting in Windows 8.1.
        ///     DISPLAYCONFIG_OUTPUT_TECHNOLOGY_MIRACAST
        /// </summary>
        Miracast = 15,

        /// <summary>
        ///     Indicates that the video output device connects internally to a display device (for example, the internal
        ///     connection in a laptop computer).
        ///     DISPLAYCONFIG_OUTPUT_TECHNOLOGY_INTERNAL
        /// </summary>
        Internal = 0x80000000,
    }
}