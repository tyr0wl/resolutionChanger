using System.Runtime.InteropServices;

namespace ResolutionChanger.Win32
{
    [StructLayout(LayoutKind.Sequential)]
    public struct PointL
    {
        public int x;
        public int y;
    }
}