using System.Runtime.InteropServices;

namespace ResolutionChanger.Win32
{
    [StructLayout(LayoutKind.Sequential)]
    internal struct PointL
    {
        public int x;
        public int y;

        public PointL(int x, int y)
        {
            this.x = x;
            this.y = y;
        }

        public void Deconstruct(out int x, out int y)
        {
            x = this.x;
            y = this.y;
        }

        public static PointL FromPoint(Point point)
        {
            return new(point.X, point.Y);
        }

        public static explicit operator Point(PointL point)
        {
            var (x, y) = point;
            return new Point(x, y);
        }

        public static explicit operator PointL(Point point)
        {
            var (x, y) = point;
            return new PointL(x, y);
        }

        public override string ToString()
        {
            return $"{{{GetType().Name} {nameof(x)}: {x}, {nameof(y)}: {y}}}";
        }
    }
}