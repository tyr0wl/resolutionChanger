using System.Runtime.InteropServices;

namespace ResolutionChanger.Win32.DisplayConfig
{
    /// <summary>
    ///     The DISPLAYCONFIG_TARGET_MODE structure describes a display path target mode.
    ///     DISPLAYCONFIG_TARGET_MODE structure (wingdi.h)
    /// </summary>
    [StructLayout(LayoutKind.Sequential)]
    public struct TargetMode
    {
        /// <summary>
        ///     A DISPLAYCONFIG_VIDEO_SIGNAL_INFO structure that contains a detailed description of the current target mode.
        /// </summary>
        [MarshalAs(UnmanagedType.Struct)] public VideoSignalInfo targetVideoSignalInfo;

        public override string ToString()
        {
            return $"{GetType().Name} {{{targetVideoSignalInfo}}}";
        }
    }
}