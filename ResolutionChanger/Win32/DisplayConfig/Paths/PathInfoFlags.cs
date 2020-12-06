using System;

namespace ResolutionChanger.Win32.DisplayConfig.Paths
{
    /// <summary>
    ///     Corresponds to UINT32 field flags of the <see cref="PathInfo"/> structure.
    /// </summary>
    [Flags]
    internal enum PathInfoFlags : uint
    {
        None = 0,

        /// <summary>
        ///     Set by <see cref="DisplayConfigApi.QueryDisplayConfig"/> to indicate that the path is active and part of the desktop. If this flag value is set, <see cref="DisplayConfigApi.SetDisplayConfig"/> attempts to enable this path.
        /// </summary>
        Active = 1,

        /// <summary>
        ///     Set by <see cref="DisplayConfigApi.QueryDisplayConfig"/> to indicate that the path supports the virtual mode. Supported starting in Windows 10.
        /// </summary>
        SupportVirtualMode = 8
    }
}