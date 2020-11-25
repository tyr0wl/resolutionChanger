namespace ResolutionChanger
{
    public struct Point
    {
        public Point(int x, int y)
        {
            X = x;
            Y = y;
        }

        public static Point Empty => default;

        public bool IsEmpty => Equals(this, Empty);

        public int X { get; set; }
        public int Y { get; set; }

        public void Deconstruct(out int x, out int y)
        {
            x = X;
            y = Y;
        }

        public override string ToString()
        {
            return $"{{{nameof(X)}: {X}, {nameof(Y)}: {Y}}}";
        }
    }
}