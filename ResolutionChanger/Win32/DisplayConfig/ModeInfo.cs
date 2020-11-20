using System.Runtime.InteropServices;

namespace ResolutionChanger.Win32.DisplayConfig
{
    /// <summary>
    ///     The DISPLAYCONFIG_MODE_INFO structure contains either source mode or target mode information.
    ///     DISPLAYCONFIG_MODE_INFO structure (wingdi.h)
    /// </summary>
    [StructLayout(LayoutKind.Explicit)]
    public readonly struct ModeInfo
    {
        /// <summary>
        ///     A value that indicates whether the <see cref="ModeInfo" /> structure represents source or target mode information.
        ///     If <see cref="infoType" /> is <see cref="ModeInfoType.Target" />, the <see cref="targetMode" /> parameter value
        ///     contains a valid <see cref="TargetMode" /> structure describing the specified target. If <see cref="infoType" /> is
        ///     <see cref="ModeInfoType.Source" />, the <see cref="sourceMode" /> parameter value contains a valid
        ///     <see cref="SourceMode" /> structure describing the specified source.
        /// </summary>
        [MarshalAs(UnmanagedType.U4)] [FieldOffset(0)]
        public readonly ModeInfoType infoType;

        /// <summary>
        ///     The source or target identifier on the specified adapter that this path relates to.
        /// </summary>
        [MarshalAs(UnmanagedType.U4)] [FieldOffset(4)]
        public readonly uint id;

        /// <summary>
        ///     The identifier of the adapter that this source or target mode information relates to.
        /// </summary>
        [MarshalAs(UnmanagedType.Struct)] [FieldOffset(8)]
        public readonly LuId adapterId;

        /// <summary>
        ///     A valid DISPLAYCONFIG_TARGET_MODE structure that describes the specified target only when <see cref="infoType" />
        ///     is <see cref="ModeInfoType.Target" />.
        /// </summary>
        [MarshalAs(UnmanagedType.Struct)] [FieldOffset(16)]
        public readonly TargetMode targetMode;

        /// <summary>
        ///     A valid DISPLAYCONFIG_SOURCE_MODE structure that describes the specified source only when <see cref="infoType" />
        ///     is <see cref="ModeInfoType.Source" />.
        /// </summary>
        [MarshalAs(UnmanagedType.Struct)] [FieldOffset(16)]
        public readonly SourceMode sourceMode;

        /// <summary>
        ///     A DISPLAYCONFIG_DESKTOP_IMAGE_INFO structure that describes information about the desktop image only when
        ///     <see cref="infoType" /> is <see cref="ModeInfoType.DesktopImage" />.
        ///     Supported starting in Windows 10.
        /// </summary>
        [MarshalAs(UnmanagedType.Struct)] [FieldOffset(16)]
        public readonly DesktopImageInfo desktopImageInfo;
    }
}