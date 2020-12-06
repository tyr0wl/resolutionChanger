using System.Runtime.InteropServices;
using ResolutionChanger.Data;
using ResolutionChanger.Data.Paths;
using ResolutionChanger.Win32.DisplayConfig.Data;
using ResolutionChanger.Win32.DisplayConfig.Modes;

namespace ResolutionChanger.Win32.DisplayConfig.Paths
{
    /// <summary>
    ///     The DISPLAYCONFIG_PATH_TARGET_INFO structure contains target information for a single path.
    ///     DISPLAYCONFIG_PATH_TARGET_INFO structure (wingdi.h)
    /// </summary>
    [StructLayout(LayoutKind.Sequential)]
    internal struct PathTargetInfo
    {
        public const uint ModeIdxInvalid = 0xffffffff;

        /// <summary>
        ///     The identifier of the adapter that the path is on.
        /// </summary>
        [MarshalAs(UnmanagedType.Struct)] public LuId adapterId;

        /// <summary>
        ///     The target identifier on the specified adapter that this path relates to.
        /// </summary>
        [MarshalAs(UnmanagedType.U4)] public uint id;

        /// <summary>
        ///     A valid index into the mode information table that contains the target mode information for this path only when
        ///     DISPLAYCONFIG_PATH_SUPPORT_VIRTUAL_MODE is not set. If target mode information is not available, the value of
        ///     modeInfoIdx is DISPLAYCONFIG_PATH_MODE_IDX_INVALID.
        /// </summary>
        [MarshalAs(UnmanagedType.U4)] public uint modeInfoIdx;

        /// <summary>
        ///     The target's connector type. For a list of possible values, see the <see cref="VideoOutputTechnology" /> enumerated
        ///     type.
        /// </summary>
        [MarshalAs(UnmanagedType.U4)] public VideoOutputTechnology outputTechnology;

        /// <summary>
        ///     A value that specifies the rotation of the target. For a list of possible values, see the <see cref="Rotation" />
        ///     enumerated type.
        /// </summary>
        [MarshalAs(UnmanagedType.U4)] public Rotation rotation;

        /// <summary>
        ///     A value that specifies how the source image is scaled to the target. For a list of possible values, see the
        ///     <see cref="Scaling" /> enumerated type. For more information about scaling, see Scaling the Desktop Image.
        /// </summary>
        [MarshalAs(UnmanagedType.U4)] public Scaling scaling;

        /// <summary>
        ///     A DISPLAYCONFIG_RATIONAL structure that specifies the refresh rate of the target. If the caller specifies target
        ///     mode information, the operating system will instead use the refresh rate that is stored in the
        ///     <see cref="VideoSignalInfo.vSyncFreq" /> member of the <see cref="VideoSignalInfo" /> structure. In this case, the
        ///     caller specifies this value in the <see cref="TargetMode.targetVideoSignalInfo" /> member of the
        ///     <see cref="TargetMode" /> structure. A refresh rate with both the <see cref="Rational.Numerator" /> and
        ///     <see cref="Rational.Denominator" /> set to zero indicates that the caller does not specify a refresh rate and the
        ///     operating system should use the most optimal refresh rate available. For this case, in a call to the
        ///     <see cref="DisplayConfigApi.SetDisplayConfig" /> function, the caller must set the <see cref="scanLineOrdering" />
        ///     member to the <see cref="ScanLineOrdering.Unspecified" /> value; otherwise,
        ///     <see cref="DisplayConfigApi.SetDisplayConfig" /> fails.
        /// </summary>
        [MarshalAs(UnmanagedType.Struct)] public Rational refreshRate;

        /// <summary>
        ///     A value that specifies the scan-line ordering of the output on the target. For a list of possible values, see the
        ///     <see cref="ScanLineOrdering" /> enumerated type. If the caller specifies target mode information, the operating
        ///     system will instead use the scan-line ordering that is stored in the
        ///     <see cref="VideoSignalInfo.scanLineOrdering" /> member of the <see cref="VideoSignalInfo" /> structure. In this
        ///     case, the caller specifies this value in the <see cref="TargetMode.targetVideoSignalInfo" /> member of the
        ///     <see cref="TargetMode" /> structure.
        /// </summary>
        [MarshalAs(UnmanagedType.U4)] public ScanLineOrdering scanLineOrdering;

        /// <summary>
        ///     A Boolean value that specifies whether the target is available. <c>true</c> indicates that the target is available.
        ///     <br />
        ///     Because the asynchronous nature of display topology changes when a monitor is removed, a path might still be marked
        ///     as active even though the monitor has been removed. In such a case, <see cref="targetAvailable" /> could be
        ///     <c>false</c> for an active path. This is typically a transient situation that will change after the operating
        ///     system takes action on the monitor removal.
        /// </summary>
        [MarshalAs(UnmanagedType.Bool)] public bool targetAvailable;

        /// <summary>
        ///     A bitwise OR of flag values that indicates the status of the target.
        /// </summary>
        [MarshalAs(UnmanagedType.U4)] public PathTargetInfoFlags statusFlags;

        public bool InvalidModeIdx => modeInfoIdx == ModeIdxInvalid;

        public override string ToString()
        {
            var modeIdxString = InvalidModeIdx ? "-" : modeInfoIdx.ToString();
            return $@"{{target {id},{statusFlags},[{modeIdxString}]->{outputTechnology}}}";
        }

        public static explicit operator PathTargetInfo(TargetPath targetPath)
        {
            return new()
            {
                adapterId = new LuId { LowPart = targetPath.DeviceId.AdapterId },
                id = targetPath.DeviceId.Id,
                modeInfoIdx = targetPath.InvalidModeIndex ? ModeIdxInvalid : (uint)targetPath.ModeIndex,
                outputTechnology = targetPath.VideoOutput,
                refreshRate = targetPath.RefreshRate,
                rotation = targetPath.Rotation,
                scaling = targetPath.Scaling,
                scanLineOrdering = targetPath.ScanLineOrdering,
                targetAvailable = targetPath.Available,
                statusFlags = targetPath.Status,
            };
        }
    }
}