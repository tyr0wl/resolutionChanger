using System;

namespace ResolutionChanger.Win32.DisplayConfig
{
    /// <summary>
    ///     Corresponds to UINT32 field statusFlags of the <see cref="PathTargetInfo"/> structure.
    /// </summary>
    [Flags]
    public enum PathTargetInfoFlags : uint
    {
        None = 0,

        /// <summary>
        ///     Target is in use on an active path.
        ///     DISPLAYCONFIG_TARGET_IN_USE
        /// </summary>
        InUse = 1,

        /// <summary>
        ///     The output can be forced on this target even if a monitor is not detected.
        ///     DISPLAYCONFIG_TARGET_FORCIBLE
        /// </summary>
        Forcible = 2,

        /// <summary>
        ///     Output is currently being forced in a boot-persistent manner.
        ///     DISPLAYCONFIG_TARGET_FORCED_AVAILABILITY_BOOT
        /// </summary>
        ForcedAvailabilityBoot = 3,

        /// <summary>
        ///     Output is currently being forced in a path-persistent manner.
        ///     DISPLAYCONFIG_TARGET_FORCED_AVAILABILITY_PATH
        /// </summary>
        ForcedAvailabilityPath = 4,

        /// <summary>
        ///     Output is currently being forced in a non-persistent manner.
        ///     DISPLAYCONFIG_TARGET_FORCED_AVAILABILITY_SYSTEM
        /// </summary>
        ForcedAvailabilitySystem = 5
    }
}