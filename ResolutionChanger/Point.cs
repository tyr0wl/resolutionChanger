﻿namespace ResolutionChanger
{   
    public struct Point
    {
        public int X { get; set; }
        public int Y { get; set; }

        public override string ToString()
        {
            return $"P{ X },{ Y }";
        }
    }
}
