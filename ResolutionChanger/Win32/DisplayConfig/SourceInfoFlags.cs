using System;

namespace ResolutionChanger.Win32.DisplayConfig
{
    /// <summary>
    ///     Corresponds to UINT32 field statusFlags of the <see cref="PathSourceInfo"/> structure.
    /// </summary>
    [Flags]
    public enum SourceInfoFlags : uint
    {
        None = 0,

        /// <summary>
        ///     DISPLAYCONFIG_SOURCE_IN_USE
        ///     This source is in use by at least one active path.
        /// </summary>
        InUse = 1
    }
}