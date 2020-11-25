using System.Runtime.InteropServices;

namespace ResolutionChanger.Win32.DisplayConfig
{
    /// <summary>
    ///     The DISPLAYCONFIG_VIDEO_SIGNAL_INFO structure contains information about the video signal for a display.
    ///     DISPLAYCONFIG_VIDEO_SIGNAL_INFO structure (wingdi.h)
    /// </summary>
    [StructLayout(LayoutKind.Sequential)]
    public struct VideoSignalInfo
    {
        /// <summary>
        ///     The pixel clock rate.
        /// </summary>
        [MarshalAs(UnmanagedType.U8)] public readonly ulong pixelRate;

        /// <summary>
        ///     A DISPLAYCONFIG_RATIONAL structure that represents horizontal sync.
        /// </summary>
        [MarshalAs(UnmanagedType.Struct)] public readonly Rational hSyncFreq;

        /// <summary>
        ///     A DISPLAYCONFIG_RATIONAL structure that represents vertical sync.
        /// </summary>
        [MarshalAs(UnmanagedType.Struct)] public Rational vSyncFreq;

        /// <summary>
        ///     A DISPLAYCONFIG_2DREGION structure that specifies the width and height (in pixels) of the active portion of the
        ///     video signal.
        /// </summary>
        [MarshalAs(UnmanagedType.Struct)] public readonly DisplayConfig2dRegion activeSize;

        /// <summary>
        ///     A DISPLAYCONFIG_2DREGION structure that specifies the width and height (in pixels) of the entire video signal.
        /// </summary>
        [MarshalAs(UnmanagedType.Struct)] public readonly DisplayConfig2dRegion totalSize;

        /// <summary>
        ///     The video standard (if any) that defines the video signal. For a list of possible values, see the
        ///     <see cref="VideoSignalStandard" /> enumerated type.
        ///     Supported starting with Windows 8.1.
        /// </summary>
        [MarshalAs(UnmanagedType.U2)] public readonly VideoSignalStandard videoStandard;

        /// <summary>
        ///     The ratio of the VSync rate of a monitor that displays through a Miracast connected session to the VSync rate of
        ///     the Miracast sink.
        ///     <br />
        ///     To avoid visual artifacts, the VSync rate of the display monitor that's connected to the Miracast sink must be an
        ///     integer multiple of the VSync rate of the Miracast sink. The display miniport driver reports the latter rate to the
        ///     operating system as the refresh rate of the desktop present path.
        ///     <br />
        ///     For a non-Miracast target, the driver should set <see cref="vSyncFreqDivider" /> to zero.
        /// </summary>
        [MarshalAs(UnmanagedType.U2)] public readonly ushort vSyncFreqDivider;

        /// <summary>
        ///     The scan-line ordering (for example, progressive or interlaced) of the video signal. For a list of possible values,
        ///     see the <see cref="ScanLineOrdering" /> enumerated type.
        /// </summary>
        [MarshalAs(UnmanagedType.U4)] public readonly ScanLineOrdering scanLineOrdering;

        public override string ToString()
        {
            return $"{{video {videoStandard},hSync:{hSyncFreq},vSync:{vSyncFreq},{scanLineOrdering}}}";
        }
    }
}