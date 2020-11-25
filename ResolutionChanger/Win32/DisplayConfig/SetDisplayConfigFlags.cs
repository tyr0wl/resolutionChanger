using System;

namespace ResolutionChanger.Win32.DisplayConfig
{
    /// <summary>
    ///     Corresponds to UINT32 parameter flags of the <see cref="DisplayConfigApi.SetDisplayConfig"/> function (winuser.h)
    /// </summary>
    [Flags]
    public enum SetDisplayConfigFlags : uint
    {
        Invalid = 0,

        /// <summary>
        ///     The caller requests the last internal configuration from the persistence database.
        ///     SDC_TOPOLOGY_INTERNAL
        /// </summary>
        TopologyInternal = 0x00000001,

        /// <summary>
        ///     The caller requests the last clone configuration from the persistence database.
        ///     SDC_TOPOLOGY_CLONE
        /// </summary>
        TopologyClone = 0x00000002,

        /// <summary>
        ///     The caller requests the last extended configuration from the persistence database.
        ///     SDC_TOPOLOGY_EXTEND
        /// </summary>
        TopologyExtend = 0x00000004,

        /// <summary>
        ///     The caller requests the last external configuration from the persistence database.
        ///     SDC_TOPOLOGY_EXTERNAL
        /// </summary>
        TopologyExternal = 0x00000008,

        /// <summary>
        ///     The caller requests a combination of all four SDC_TOPOLOGY_XXX configurations. This value informs the API to set the last known display configuration for the current connected monitors.
        ///     SDC_USE_DATABASE_CURRENT
        /// </summary>
        UseDatabaseCurrent = TopologyInternal | TopologyClone | TopologyExtend | TopologyExternal,

        /// <summary>
        ///     The caller provides the path data so the function only queries the persistence database to find and use the source and target mode.
        ///     SDC_TOPOLOGY_SUPPLIED
        /// </summary>
        TopologySupplied = 0x00000010,

        /// <summary>
        ///     The topology, source, and target mode information that are supplied in the pathArray and the modeInfoArray parameters are used, rather than looking up the configuration in the database.
        ///     SDC_USE_SUPPLIED_DISPLAY_CONFIG
        /// </summary>
        UseSuppliedDisplayConfig = 0x00000020,

        /// <summary>
        ///     The system tests for the requested topology, source, and target mode information to determine whether it can be set.
        ///     SDC_VALIDATE
        /// </summary>
        Validate = 0x00000040,

        /// <summary>
        ///     The resulting topology, source, and target mode is set.
        ///     SDC_APPLY
        /// </summary>
        Apply = 0x00000080,

        /// <summary>
        ///     A modifier to the <see cref="Apply"/> flag. This causes the change mode to be forced all the way down to the driver for each active display.
        ///     SDC_NO_OPTIMIZATION
        /// </summary>
        NoOptimization = 0x00000100,

        /// <summary>
        ///     The resulting topology, source, and target mode are saved to the database.
        ///     SDC_SAVE_TO_DATABASE
        /// </summary>
        SaveToDatabase = 0x00000200,

        /// <summary>
        ///     If required, the function can modify the specified source and target mode information in order to create a functional display path set.
        ///     SDC_ALLOW_CHANGES
        /// </summary>
        AllowChanges = 0x00000400,

        /// <summary>
        ///     When the function processes a SDC_TOPOLOGY_XXX request, it can force path persistence on a target to satisfy the request if necessary. For information about the other flags that this flag can be combined with, see the following list.
        ///     SDC_PATH_PERSIST_IF_REQUIRED
        /// </summary>
        PathPersistIfRequired = 0x00000800,

        /// <summary>
        ///     The caller requests that the driver is given an opportunity to update the GDI mode list while SetDisplayConfig sets the new display configuration.
        ///     This flag value is only valid when the <see cref="UseSuppliedDisplayConfig"/> and <see cref="Apply"/> flag values are also specified.
        ///     SDC_FORCE_MODE_ENUMERATION
        /// </summary>
        ForceModeEnumeration = 0x00001000,

        /// <summary>
        ///     A modifier to the <see cref="TopologySupplied"/> flag that indicates that <see cref="DisplayConfigApi.SetDisplayConfig"/> should ignore the path order of the supplied topology when searching the database. When this flag is set, the topology set is the most recent topology that contains all the paths regardless of the path order.
        ///     SDC_ALLOW_PATH_ORDER_CHANGES
        /// </summary>
        AllowPathOrderChanges = 0x00002000,
    }
}