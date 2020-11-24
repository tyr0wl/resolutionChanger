using System.Runtime.InteropServices;

namespace ResolutionChanger.Win32
{
    [StructLayout(LayoutKind.Sequential)]
    public struct PointL
    {
        public int x;
        public int y;

        public override string ToString()
        {
            return $"{{{GetType().Name} {nameof(x)}: {x}, {nameof(y)}: {y}}}";
        }
    }
}