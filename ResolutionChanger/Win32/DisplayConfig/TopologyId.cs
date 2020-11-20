namespace ResolutionChanger.Win32.DisplayConfig
{
    /// <summary>
    ///     The DISPLAYCONFIG_TOPOLOGY_ID enumeration specifies the type of display topology.
    ///     DISPLAYCONFIG_TOPOLOGY_ID enumeration (wingdi.h)
    /// </summary>
    public enum TopologyId
    {
        None = 0,

        /// <summary>
        ///     Indicates that the display topology is an internal configuration.
        ///     DISPLAYCONFIG_TOPOLOGY_INTERNAL
        /// </summary>
        Internal = 0x00000001,

        /// <summary>
        ///     Indicates that the display topology is clone-view configuration.
        ///     DISPLAYCONFIG_TOPOLOGY_CLONE
        /// </summary>
        Clone = 0x00000002,

        /// <summary>
        ///     Indicates that the display topology is an extended configuration.
        ///     DISPLAYCONFIG_TOPOLOGY_EXTEND
        /// </summary>
        Extend = 0x00000004,

        /// <summary>
        ///     Indicates that the display topology is an external configuration.
        ///     DISPLAYCONFIG_TOPOLOGY_EXTERNAL
        /// </summary>
        External = 0x00000008
    }
}