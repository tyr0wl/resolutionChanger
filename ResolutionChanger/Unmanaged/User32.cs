using System;
using System.Runtime.InteropServices;

namespace ResolutionChanger.Unmanaged
{
    public class User32
    {
        [DllImport("user32.dll")]
        public static extern bool EnumDisplayDevices(string lpDevice, uint iDevNum, ref DisplayDevice lpDisplayDevice, uint dwFlags);
    }
}