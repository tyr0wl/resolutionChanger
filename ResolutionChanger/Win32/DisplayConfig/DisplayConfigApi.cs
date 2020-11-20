using System;
using System.Runtime.InteropServices;

namespace ResolutionChanger.Win32.DisplayConfig
{
    public class DisplayConfigApi
    {
        /// <summary>
        ///     The <see cref="DisplayConfigGetDeviceInfo(ref TargetDeviceName)" /> function retrieves display configuration information about the
        ///     device.
        /// </summary>
        /// <param name="requestPacket">
        ///     A pointer to a <see cref="TargetDeviceName" /> structure. The <see cref="TargetBaseType.header" /> member contains
        ///     information about the request, which includes the packet type in the <see cref="DeviceInfoHeader.type" /> member.
        ///     The type and size of additional data that
        ///     <see cref="DisplayConfigGetDeviceInfo(ref TargetDeviceName)" /> returns after
        ///     the <see cref="TargetDeviceName.header" /> structure depend on the packet type.
        /// </param>
        [DllImport("user32.dll")]
        public static extern int DisplayConfigGetDeviceInfo(ref TargetDeviceName requestPacket);

        /// <summary>
        ///     The <see cref="DisplayConfigGetDeviceInfo(ref SourceDeviceName)" /> function retrieves display configuration information about the
        ///     device.
        /// </summary>
        /// <param name="requestPacket">
        ///     A pointer to a <see cref="SourceDeviceName" /> structure. The <see cref="TargetBaseType.header" /> member contains
        ///     information about the request, which includes the packet type in the <see cref="DeviceInfoHeader.type" /> member.
        ///     The type and size of additional data that
        ///     <see cref="DisplayConfigGetDeviceInfo(ref SourceDeviceName)" /> returns after
        ///     the <see cref="SourceDeviceName.header" /> structure depend on the packet type.
        /// </param>
        [DllImport("user32.dll")]
        public static extern int DisplayConfigGetDeviceInfo(ref SourceDeviceName requestPacket);

        /// <summary>
        ///     The <see cref="DisplayConfigGetDeviceInfo(ref TargetPreferredMode)" /> function retrieves display configuration information about the
        ///     device.
        /// </summary>
        /// <param name="requestPacket">
        ///     A pointer to a <see cref="TargetPreferredMode" /> structure. The <see cref="TargetBaseType.header" /> member contains
        ///     information about the request, which includes the packet type in the <see cref="DeviceInfoHeader.type" /> member.
        ///     The type and size of additional data that
        ///     <see cref="DisplayConfigGetDeviceInfo(ref TargetPreferredMode)" /> returns after
        ///     the <see cref="TargetPreferredMode.header" /> structure depend on the packet type.
        /// </param>
        [DllImport("user32.dll")]
        public static extern int DisplayConfigGetDeviceInfo(ref TargetPreferredMode requestPacket);

        /// <summary>
        ///     The <see cref="DisplayConfigGetDeviceInfo(ref AdapterName)" /> function retrieves display configuration information about the
        ///     device.
        /// </summary>
        /// <param name="requestPacket">
        ///     A pointer to a <see cref="AdapterName" /> structure. The <see cref="TargetBaseType.header" /> member contains
        ///     information about the request, which includes the packet type in the <see cref="DeviceInfoHeader.type" /> member.
        ///     The type and size of additional data that
        ///     <see cref="DisplayConfigGetDeviceInfo(ref AdapterName)" /> returns after
        ///     the <see cref="AdapterName.header" /> structure depend on the packet type.
        /// </param>
        [DllImport("user32.dll")]
        public static extern int DisplayConfigGetDeviceInfo(ref AdapterName requestPacket);

        /// <summary>
        ///     The <see cref="DisplayConfigGetDeviceInfo(ref TargetBaseType)" /> function retrieves display configuration information about the
        ///     device.
        /// </summary>
        /// <param name="requestPacket">
        ///     A pointer to a <see cref="TargetBaseType" /> structure. The <see cref="TargetBaseType.header" /> member contains
        ///     information about the request, which includes the packet type in the <see cref="DeviceInfoHeader.type" /> member.
        ///     The type and size of additional data that
        ///     <see cref="DisplayConfigGetDeviceInfo(ref TargetBaseType)" /> returns after
        ///     the <see cref="TargetBaseType.header" /> structure depend on the packet type.
        /// </param>
        [DllImport("user32.dll")]
        public static extern int DisplayConfigGetDeviceInfo(ref TargetBaseType requestPacket);

        /// <summary>
        ///     The <see cref="GetDisplayConfigBufferSizes" /> function retrieves the size of the buffers that are required to call
        ///     the <see cref="QueryDisplayConfig" /> function.
        /// </summary>
        /// <param name="flags">
        ///     The type of information to retrieve. The value for the Flags parameter must be one of the values of
        ///     <see cref="QueryDeviceConfigFlags" />.
        /// </param>
        /// <param name="numPathArrayElements">
        ///     Pointer to a variable that receives the number of elements in the path information
        ///     table. The <paramref name="numPathArrayElements" /> parameter value is then used by a subsequent call to the
        ///     <see cref="QueryDisplayConfig" /> function. This parameter cannot be <c>null</c>.
        /// </param>
        /// <param name="numModeInfoArrayElements">
        ///     Pointer to a variable that receives the number of elements in the mode
        ///     information table. The <paramref name="numModeInfoArrayElements" /> parameter value is then used by a subsequent
        ///     call to the  <see cref="QueryDisplayConfig" /> function. This parameter cannot be <c>null</c>.
        /// </param>
        /// <returns></returns>
        [DllImport("user32.dll")]
        public static extern int GetDisplayConfigBufferSizes(QueryDeviceConfigFlags flags, out uint numPathArrayElements, out uint numModeInfoArrayElements);

        /// <summary>
        ///     The <see cref="QueryDisplayConfig" /> function retrieves information about all possible display paths for all
        ///     display devices, or views, in the current setting.
        /// </summary>
        /// <param name="flags">
        ///     The type of information to retrieve. The value for the Flags parameter must be one of the values of
        ///     <see cref="QueryDeviceConfigFlags" />.
        /// </param>
        /// <param name="numPathArrayElements">
        ///     Pointer to a variable that contains the number of elements in
        ///     <paramref name="pathArray" />. This parameter cannot be <c>null</c>. If <see cref="QueryDisplayConfig" /> returns
        ///     <see cref="Win32Status.ErrorSuccess" />, <paramref name="numPathArrayElements" /> is updated with the number of
        ///     valid entries in <paramref name="pathArray" />.
        /// </param>
        /// <param name="pathArray">
        ///     Pointer to a variable that contains an array of <see cref="PathInfo" /> elements. Each element
        ///     in <paramref name="pathArray" /> describes a single path from a source to a target. The source and target mode
        ///     information indexes are only valid in combination with the <paramref name="modeInfoArray" /> tables that are
        ///     returned for the API at the same time. This parameter cannot be <c>null</c>. The <paramref name="pathArray" /> is
        ///     always returned in path priority order. For more information about path priority order, see Path Priority Order.
        /// </param>
        /// <param name="numModeInfoArrayElements">
        ///     Pointer to a variable that specifies the number in element of the mode
        ///     information table. This parameter cannot be <c>null</c>. If <see cref="QueryDisplayConfig" /> returns
        ///     <see cref="Win32Status.ErrorSuccess" />, <paramref name="numModeInfoArrayElements" /> is updated with the number of
        ///     valid entries in <paramref name="modeInfoArray" />.
        /// </param>
        /// <param name="modeInfoArray">
        ///     Pointer to a variable that contains an array of <see cref="ModeInfo" /> elements. This
        ///     parameter cannot be <c>null</c>.
        /// </param>
        /// <param name="currentTopologyId">
        ///     Pointer to a variable that receives the identifier of the currently active topology in the CCD database. For a list
        ///     of possible values, see the <see cref="TopologyId" /> enumerated type.
        ///     <br />
        ///     The <paramref name="currentTopologyId" /> parameter is only set when the <paramref name="flags" /> parameter value
        ///     is <see cref="QueryDeviceConfigFlags.DatabaseCurrent" />.
        ///     <br />
        ///     If the <paramref name="flags" /> parameter value is set to <see cref="QueryDeviceConfigFlags.DatabaseCurrent" />,
        ///     the <paramref name="currentTopologyId" /> parameter must not be <c>null</c>. If the <paramref name="flags" />
        ///     parameter value is not set to <see cref="QueryDeviceConfigFlags.DatabaseCurrent" />, the
        ///     <paramref name="currentTopologyId" /> parameter value must be <c>null</c>.
        /// </param>
        [DllImport("user32.dll")]
        public static extern int QueryDisplayConfig(
            QueryDeviceConfigFlags flags,
            ref uint numPathArrayElements, [Out] PathInfo[] pathArray,
            ref uint numModeInfoArrayElements, [Out] ModeInfo[] modeInfoArray,
            IntPtr currentTopologyId
        );

        /// <summary>
        ///     The <see cref="QueryDisplayConfig" /> function retrieves information about all possible display paths for all
        ///     display devices, or views, in the current setting.
        /// </summary>
        /// <param name="flags">
        ///     The type of information to retrieve. The value for the Flags parameter must be one of the values of
        ///     <see cref="QueryDeviceConfigFlags" />.
        /// </param>
        /// <param name="numPathArrayElements">
        ///     Pointer to a variable that contains the number of elements in
        ///     <paramref name="pathArray" />. This parameter cannot be <c>null</c>. If <see cref="QueryDisplayConfig" /> returns
        ///     <see cref="Win32Status.ErrorSuccess" />, <paramref name="numPathArrayElements" /> is updated with the number of
        ///     valid entries in <paramref name="pathArray" />.
        /// </param>
        /// <param name="pathArray">
        ///     Pointer to a variable that contains an array of <see cref="PathInfo" /> elements. Each element
        ///     in <paramref name="pathArray" /> describes a single path from a source to a target. The source and target mode
        ///     information indexes are only valid in combination with the <paramref name="modeInfoArray" /> tables that are
        ///     returned for the API at the same time. This parameter cannot be <c>null</c>. The <paramref name="pathArray" /> is
        ///     always returned in path priority order. For more information about path priority order, see Path Priority Order.
        /// </param>
        /// <param name="numModeInfoArrayElements">
        ///     Pointer to a variable that specifies the number in element of the mode
        ///     information table. This parameter cannot be <c>null</c>. If <see cref="QueryDisplayConfig" /> returns
        ///     <see cref="Win32Status.ErrorSuccess" />, <paramref name="numModeInfoArrayElements" /> is updated with the number of
        ///     valid entries in <paramref name="modeInfoArray" />.
        /// </param>
        /// <param name="modeInfoArray">
        ///     Pointer to a variable that contains an array of <see cref="ModeInfo" /> elements. This
        ///     parameter cannot be <c>null</c>.
        /// </param>
        /// <param name="currentTopologyId">
        ///     Pointer to a variable that receives the identifier of the currently active topology in the CCD database. For a list
        ///     of possible values, see the <see cref="TopologyId" /> enumerated type.
        ///     <br />
        ///     The <paramref name="currentTopologyId" /> parameter is only set when the <paramref name="flags" /> parameter value
        ///     is <see cref="QueryDeviceConfigFlags.DatabaseCurrent" />.
        ///     <br />
        ///     If the <paramref name="flags" /> parameter value is set to <see cref="QueryDeviceConfigFlags.DatabaseCurrent" />,
        ///     the <paramref name="currentTopologyId" /> parameter must not be <c>null</c>. If the <paramref name="flags" />
        ///     parameter value is not set to <see cref="QueryDeviceConfigFlags.DatabaseCurrent" />, the
        ///     <paramref name="currentTopologyId" /> parameter value must be <c>null</c>.
        /// </param>
        [DllImport("user32.dll")]
        public static extern int QueryDisplayConfig(
            QueryDeviceConfigFlags flags,
            ref uint numPathArrayElements, [Out] PathInfo[] pathArray,
            ref uint numModeInfoArrayElements, [Out] ModeInfo[] modeInfoArray,
            [Out] out TopologyId currentTopologyId
        );
    }
}