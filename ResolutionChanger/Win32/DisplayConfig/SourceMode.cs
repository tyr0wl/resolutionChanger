using System.Runtime.InteropServices;

namespace ResolutionChanger.Win32.DisplayConfig
{
    [StructLayout(LayoutKind.Sequential)]
    public struct SourceMode
    {
        public uint width;
        public uint height;
        public DisplayConfigPixelFormat pixelFormat;
        public PointL position;
    }
}