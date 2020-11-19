using System;
using System.Runtime.InteropServices;

namespace ResolutionChanger.Unmanaged.DisplaySettings
{
    public class DisplaySettingsApi
    {
        /// <summary>
        ///     Retrieve the current settings for the display device.
        ///     ENUM_CURRENT_SETTINGS
        /// </summary>
        public const int CurrentSettings = -1;

        /// <summary>
        ///     Retrieve the settings for the display device that are currently stored in the registry.
        ///     ENUM_REGISTRY_SETTINGS
        /// </summary>
        public const int RegistrySettings = -2;

        /// <summary>
        ///     The <see cref="EnumDisplaySettings" /> function retrieves information about one of the graphics modes for a display
        ///     device. To retrieve information for all the graphics modes of a display device, make a series of calls to this
        ///     function.
        /// </summary>
        /// <param name="lpszDeviceName">
        ///     A pointer to a <c>null</c>-terminated string that specifies the display device about whose
        ///     graphics mode the function will obtain information.
        ///     <br />
        ///     This parameter is either <c>null</c> or a <see cref="DisplayDevice.DeviceName" /> returned from
        ///     <see cref="EnumDisplayDevices" />. A <c>null</c> value specifies the current display device on the computer on
        ///     which the calling thread is running.
        /// </param>
        /// <param name="iModeNum">
        ///     The type of information to be retrieved. This value can be a graphics mode index or one of the
        ///     values of <see cref="CurrentSettings" /> and <see cref="RegistrySettings"/>.
        ///     <br />
        ///     Graphics mode indexes start at zero. To obtain information for all of a display device's graphics modes, make a
        ///     series of calls to <see cref="EnumDisplaySettings" />, as follows: Set <paramref name="iModeNum" /> to zero for the
        ///     first call, and increment <paramref name="iModeNum" /> by one for each subsequent call. Continue calling the
        ///     function until the return value is zero.
        ///     <br />
        ///     When you call <see cref="EnumDisplaySettings" /> with <paramref name="iModeNum" /> set to zero, the operating
        ///     system initializes and caches information about the display device. When you call
        ///     <see cref="EnumDisplaySettings" /> with <paramref name="iModeNum" /> set to a nonzero value, the function returns
        ///     the information that was cached the last time the function was called with <paramref name="iModeNum" /> set to
        ///     zero.
        /// </param>
        /// <param name="lpDevMode">
        ///     A pointer to a <see cref="DevMode" /> structure into which the function stores information
        ///     about the specified graphics mode. Before calling <see cref="EnumDisplaySettings" />, set the
        ///     <see cref="DevMode.dmSize" /> member to sizeof(<see cref="DevMode" />), and set the
        ///     <see cref="DevMode.dmDriverExtra" /> member to indicate the size, in bytes, of the additional space available to
        ///     receive private driver data.
        /// </param>
        [DllImport("user32.dll")]
        public static extern bool EnumDisplaySettings(string lpszDeviceName, int iModeNum, ref DevMode lpDevMode);

        /// <summary>
        ///     The <see cref="EnumDisplayDevices" /> function (winuser.h) lets you obtain information about the display devices in
        ///     the current session.
        /// </summary>
        /// <param name="lpDevice">
        ///     A pointer to the device name. If <c>null</c>, function returns information for the display
        ///     adapter(s) on the machine, based on <paramref name="iDevNum" />.
        /// </param>
        /// <param name="iDevNum">
        ///     An index value that specifies the display device of interest.
        ///     <br />
        ///     The operating system identifies  each display device in the current session with an index value. The index values
        ///     are consecutive integers, starting  at 0. If the current session has three display devices, for example, they are
        ///     specified by the index values 0, 1,  and 2.H
        /// </param>
        /// <param name="lpDisplayDevice">
        ///     A pointer to a <see cref="DisplayDevice" /> structure that receives information about the display device specified
        ///     by <paramref name="iDevNum" />.
        ///     <br />
        ///     Before calling <see cref="EnumDisplayDevices" />, you must initialize the <see cref="DisplayDevice.cb" /> member of
        ///     <see cref="DisplayDevice" /> to the size, in bytes, of see cref="DisplayDevice" />.
        /// </param>
        /// <param name="dwFlags">
        ///     Set this flag to EDD_GET_DEVICE_INTERFACE_NAME (0x00000001) to retrieve the device interface name
        ///     for GUID_DEVINTERFACE_MONITOR, which is registered by the operating system on a per monitor basis. The value is
        ///     placed in the <see cref="DisplayDevice.DeviceID" /> member of the <see cref="DisplayDevice" /> structure returned
        ///     in <paramref name="lpDisplayDevice" />. The resulting device interface name can be used with SetupAPI functions and
        ///     serves as a link between GDI monitor devices and SetupAPI monitor devices.
        /// </param>
        [DllImport("user32.dll")]
        public static extern bool EnumDisplayDevices(string lpDevice, uint iDevNum, ref DisplayDevice lpDisplayDevice, uint dwFlags);

        /// <summary>
        ///     The <see cref="ChangeDisplaySettingsEx" /> function (winuser.h) changes the settings of the specified display
        ///     device to the
        ///     specified graphics mode.
        /// </summary>
        /// <param name="lpszDeviceName">
        ///     A pointer to a <c>null</c>-terminated string that specifies the display device whose graphics mode will change.
        ///     Only display device names as returned by <see cref="EnumDisplayDevices" /> are valid. See
        ///     <see cref="EnumDisplayDevices" /> for further information on the names associated with these display devices.
        ///     <br />
        ///     The <paramref name="lpszDeviceName" /> parameter can be <c>null</c>. A <c>null</c> value specifies the default
        ///     display device. The default device can be determined by calling <see cref="EnumDisplayDevices" /> and checking for
        ///     the <see cref="DisplayDeviceStateFlags.PrimaryDevice" /> flag.
        /// </param>
        /// <param name="lpDevMode">
        ///     A pointer to a <see cref="DevMode" /> structure that describes the new graphics mode. If
        ///     <paramref name="lpDevMode" /> is <c>null</c>, all the values currently in the registry will be used for the display
        ///     setting. Passing <c>null</c> for the <paramref name="lpDevMode" /> parameter and 0 for the
        ///     <paramref name="dwflags" /> parameter is the easiest way to return to the default mode after a dynamic mode change.
        ///     <br />
        ///     The <see cref="DevMode.dmSize" /> member must be initialized to the size, in bytes, of the <see cref="DevMode" />
        ///     structure. The <see cref="DevMode.dmDriverExtra" /> member must be initialized to indicate the number of bytes of
        ///     private driver data following the <see cref="DevMode" /> structure.
        /// </param>
        /// <param name="hwnd">Reserved; must be <c>null</c>.</param>
        /// <param name="dwflags">
        ///     Indicates how the graphics mode should be changed.
        ///     <br />
        ///     Specifying <see cref="ChangeDisplaySettingsFlags.CDS_TEST" /> allows an application to determine which graphics
        ///     modes are actually valid, without causing the system to change to them.
        ///     <br />
        ///     If <see cref="ChangeDisplaySettingsFlags.CDS_UPDATEREGISTRY" /> is specified and it is possible to change the
        ///     graphics mode dynamically, the information is stored in the registry and <see cref="DisplayChange.Successful" /> is
        ///     returned. If it is not possible to change the graphics mode dynamically, the information is stored in the registry
        ///     and <see cref="DisplayChange.Restart" /> is returned.
        ///     <br />
        ///     If <see cref="ChangeDisplaySettingsFlags.CDS_UPDATEREGISTRY" /> is specified and the information could not be
        ///     stored in the registry, the graphics mode is not changed and <see cref="DisplayChange.NotUpdated" /> is returned.
        /// </param>
        /// <param name="lParam">
        ///     If dwFlags is <see cref="ChangeDisplaySettingsFlags.CDS_VIDEOPARAMETERS" />, <paramref name="lParam" /> is a
        ///     pointer to a VIDEOPARAMETERS structure. Otherwise <paramref name="lParam" /> must be <c>null</c>.
        /// </param>
        [DllImport("user32.dll")]
        public static extern DisplayChange ChangeDisplaySettingsEx(string lpszDeviceName, ref DevMode lpDevMode, IntPtr hwnd, ChangeDisplaySettingsFlags dwflags, IntPtr lParam);

        [DllImport("user32.dll")]
        // A signature for ChangeDisplaySettingsEx with a DevMode struct as the second parameter won't allow you to pass in IntPtr.Zero, so create an overload
        public static extern DisplayChange ChangeDisplaySettingsEx(string lpszDeviceName, IntPtr lpDevMode, IntPtr hwnd, ChangeDisplaySettingsFlags dwflags, IntPtr lParam);
    }
}