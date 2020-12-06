using System;
using ResolutionChanger.Win32.DisplayConfig.Modes;

namespace ResolutionChanger.Data.Modes
{
    public class SourceScreenMode : ScreenMode, IEquatable<SourceScreenMode>
    {
        public uint Height { get; init; }
        public PixelFormat PixelFormat { get; init; }
        public Point Position { get; init; }
        public uint Width { get; init; }

        public bool Equals(SourceScreenMode other)
        {
            if (other is null)
            {
                return false;
            }

            if (ReferenceEquals(this, other))
            {
                return true;
            }

            return Width == other.Width && Height == other.Height && PixelFormat == other.PixelFormat && Position.Equals(other.Position);
        }

        public void Deconstruct(out uint width, out uint height, out PixelFormat pixelFormat, out Point position)
        {
            width = Width;
            height = Height;
            pixelFormat = PixelFormat;
            position = Position;
        }

        public override bool Equals(object obj)
        {
            if (obj is null)
            {
                return false;
            }

            if (ReferenceEquals(this, obj))
            {
                return true;
            }

            if (obj.GetType() != GetType())
            {
                return false;
            }

            return Equals((SourceScreenMode) obj);
        }

        public override int GetHashCode()
        {
            return HashCode.Combine(Width, Height, (int) PixelFormat, Position);
        }

        public static bool operator ==(SourceScreenMode left, SourceScreenMode right)
        {
            return Equals(left, right);
        }

        public static bool operator !=(SourceScreenMode left, SourceScreenMode right)
        {
            return !Equals(left, right);
        }

        public override string ToString()
        {
            var pixelFormatString = PixelFormat.ToString().Replace(nameof(PixelFormat), string.Empty);
            return $"{{ {GetType().Name} {Width}x{Height}, {pixelFormatString}, {Position} }}";
        }
    }
}