using System;

namespace ResolutionChanger.Win32.DisplaySettings
{
    /// <summary>
    ///     Corresponds to DWORD field StateFlags of the <see cref="DisplayDevice.StateFlags"/> structure.
    /// </summary>
    [Flags]
    internal enum DisplayDeviceStateFlags
    {
        None = 0,

        /// <summary>
        ///     The device is part of the desktop.
        ///     DISPLAY_DEVICE_ATTACHED_TO_DESKTOP
        /// </summary>
        AttachedToDesktop = 0x1,

        /// <summary>
        ///     undocumented
        ///     DISPLAY_DEVICE_MULTI_DRIVER
        /// </summary>
        MultiDriver = 0x2,

        /// <summary>
        ///     The primary desktop is on the device. For a system with a single display card, this is always set. For a system with multiple display cards, only one device can have this set.
        ///     DISPLAY_DEVICE_PRIMARY_DEVICE
        /// </summary>
        PrimaryDevice = 0x4,

        /// <summary>
        ///     Represents a pseudo device used to mirror application drawing for remoting or other purposes.
        ///     An invisible pseudo monitor is associated with this device.
        ///     For example, NetMeeting uses it.
        ///     Note that GetSystemMetrics (SM_MONITORS) only accounts for visible display monitors.
        ///     DISPLAY_DEVICE_MIRRORING_DRIVER
        /// </summary>
        MirroringDriver = 0x8,

        /// <summary>
        ///     The device is VGA compatible.
        ///     DISPLAY_DEVICE_VGA_COMPATIBLE
        /// </summary>
        VgaCompatible = 0x10,

        /// <summary>
        ///     The device is removable; it cannot be the primary display.
        ///     DISPLAY_DEVICE_REMOVABLE
        /// </summary>
        Removable = 0x20,

        /// <summary>
        ///     The device has more display modes than its output devices support.
        ///     DISPLAY_DEVICE_MODESPRUNED
        /// </summary>
        ModesPruned = 0x8000000,
        /// <summary>
        ///     undocumented
        ///     DISPLAY_DEVICE_REMOTE
        /// </summary>
        Remote = 0x4000000,
        /// <summary>
        ///     undocumented
        ///     DISPLAY_DEVICE_DISCONNECT
        /// </summary>
        Disconnect = 0x2000000
    }
}