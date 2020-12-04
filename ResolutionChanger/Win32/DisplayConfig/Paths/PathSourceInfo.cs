using System.Runtime.InteropServices;
using ResolutionChanger.Data;
using ResolutionChanger.Data.Paths;
using ResolutionChanger.Win32.DisplayConfig.Data;

namespace ResolutionChanger.Win32.DisplayConfig.Paths
{
    /// <summary>
    ///     The DISPLAYCONFIG_PATH_SOURCE_INFO structure contains source information for a single path.
    ///     DISPLAYCONFIG_PATH_SOURCE_INFO structure (wingdi.h)
    /// </summary>
    [StructLayout(LayoutKind.Sequential)]
    public struct PathSourceInfo
    {
        public const uint ModeIdxInvalid = 0xffffffff;

        /// <summary>
        ///     The identifier of the adapter that this source information relates to.
        /// </summary>
        [MarshalAs(UnmanagedType.Struct)] public LuId adapterId;

        /// <summary>
        ///     The source identifier on the specified adapter that this path relates to.
        /// </summary>
        [MarshalAs(UnmanagedType.U4)] public uint id;

        /// <summary>
        ///     A valid index into the mode information table that contains the source mode information for this path only when
        ///     DISPLAYCONFIG_PATH_SUPPORT_VIRTUAL_MODE is not set. If source mode information is not available, the value of
        ///     modeInfoIdx is DISPLAYCONFIG_PATH_MODE_IDX_INVALID.
        /// </summary>
        [MarshalAs(UnmanagedType.U4)] public uint modeInfoIdx;

        /// <summary>
        ///     A bitwise OR of flag values that indicates the state of the path.
        /// </summary>
        [MarshalAs(UnmanagedType.U4)] public SourceInfoFlags statusFlags;

        public bool InvalidModeIdx => modeInfoIdx == ModeIdxInvalid;

        public override string ToString()
        {
            var modeIdxString = InvalidModeIdx ? "-" : modeInfoIdx.ToString();
            return $@"{{source {id},{statusFlags},[{modeIdxString}]}}";
        }

        public static explicit operator Source(PathSourceInfo sourceInfo)
        {
            return new()
            {
                DeviceId = new DeviceId
                {
                    AdapterId = sourceInfo.adapterId.LowPart,
                    Id = sourceInfo.id
                },
                InUse = sourceInfo.statusFlags.HasFlag(SourceInfoFlags.InUse),
                ModeIndex = sourceInfo.InvalidModeIdx ? -1 : (int) sourceInfo.modeInfoIdx,
            };
        }

        public static explicit operator PathSourceInfo(Source source)
        {
            return new()
            {
                adapterId = new LuId { LowPart = source.DeviceId.AdapterId },
                id = source.DeviceId.Id,
                modeInfoIdx = source.InvalidModeIndex ? ModeIdxInvalid : (uint) source.ModeIndex,
                statusFlags = source.InUse ? SourceInfoFlags.InUse : SourceInfoFlags.None,
            };
        }
    }
}