using System;

namespace ResolutionChanger.Data.Paths
{
    public class ScreenPath : IEquatable<ScreenPath>
    {
        public bool Active { get; init; }
        public SourcePath SourcePath { get; init; }
        public bool SupportsVirtualMode { get; init; }
        public TargetPath TargetPath { get; init; }

        public bool Equals(ScreenPath other)
        {
            if (other is null)
            {
                return false;
            }

            if (ReferenceEquals(this, other))
            {
                return true;
            }

            return Equals(SourcePath, other.SourcePath) && Equals(TargetPath, other.TargetPath) && Active == other.Active && SupportsVirtualMode == other.SupportsVirtualMode;
        }

        public ScreenPath Copy
        (
            SourcePath sourcePath = null,
            TargetPath targetPath = null,
            bool? active = null,
            bool? supportsVirtualMode = null
        )
        {
            return new()
            {
                SourcePath = sourcePath ?? SourcePath,
                TargetPath = targetPath ?? TargetPath,
                Active = active ?? Active,
                SupportsVirtualMode = supportsVirtualMode ?? SupportsVirtualMode
            };
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

            return Equals((ScreenPath) obj);
        }

        public override int GetHashCode()
        {
            return HashCode.Combine(SourcePath, TargetPath, Active, SupportsVirtualMode);
        }

        public static bool operator ==(ScreenPath left, ScreenPath right)
        {
            return Equals(left, right);
        }

        public static bool operator !=(ScreenPath left, ScreenPath right)
        {
            return !Equals(left, right);
        }

        public override string ToString()
        {
            return $"{{path {SourcePath},{TargetPath},{(Active ? "active" : "")}}}";
        }
    }
}