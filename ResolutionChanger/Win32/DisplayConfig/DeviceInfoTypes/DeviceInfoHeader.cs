using System.Runtime.InteropServices;
using ResolutionChanger.Win32.DisplayConfig.Data;

namespace ResolutionChanger.Win32.DisplayConfig.DeviceInfoTypes
{
    /// <summary>
    ///     The DISPLAYCONFIG_DEVICE_INFO_HEADER structure contains display information about the device.
    ///     DISPLAYCONFIG_DEVICE_INFO_HEADER structure (wingdi.h)
    /// </summary>
    [StructLayout(LayoutKind.Sequential)]
    public struct DeviceInfoHeader
    {
        /// <summary>
        ///     A DISPLAYCONFIG_DEVICE_INFO_TYPE enumerated value that determines the type of device information to retrieve or
        ///     set. The remainder of the packet for the retrieve or set operation follows immediately after the
        ///     DISPLAYCONFIG_DEVICE_INFO_HEADER structure.
        /// </summary>
        public DeviceInfoType type;

        /// <summary>
        ///     The size, in bytes, of the device information that is retrieved or set. This size includes the size of the header
        ///     and the size of the additional data that follows the header. This device information depends on the request type.
        /// </summary>
        public uint size;

        /// <summary>
        ///     A locally unique identifier (LUID) that identifies the adapter that the device information packet refers to.
        /// </summary>
        public LuId adapterId;

        /// <summary>
        ///     The source or target identifier to get or set the device information for. The meaning of this identifier is related
        ///     to the type of information being requested. For example, in the case of <see cref="DeviceInfoType.GetSourceName" />
        ///     , this is the source identifier.
        /// </summary>
        public uint id;

        public override string ToString()
        {
            return $"{GetType().Name}: {{{type}, {adapterId}, {id}}}";
        }
    }
}