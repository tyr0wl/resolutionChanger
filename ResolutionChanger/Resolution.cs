namespace ResolutionChanger
{
    public struct Resolution
    {
        public Resolution(uint width, uint height, uint frequency)
        {
            Width = width;
            Height = height;
            Frequency = frequency;
        }

        public static Resolution Empty { get; set; } = new();
        public uint Frequency { get; set; }
        public uint Height { get; set; }

        public uint Width { get; set; }

        public void Deconstruct(out uint width, out uint height, out uint frequency)
        {
            width = Width;
            height = Height;
            frequency = Frequency;
        }

        public override string ToString()
        {
            return $"{Width}x{Height}@{Frequency}";
        }
    }
}