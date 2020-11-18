namespace ResolutionChanger
{
    public struct Resolution
    {
        public static Resolution Empty { get; set; } = new Resolution();

        public int Width { get; set; }
        public int Height { get; set; }
        public int Frequency { get; set; }

        public override string ToString()
        {
            return $"{Width}x{Height}@{Frequency}";
        }
    }
}