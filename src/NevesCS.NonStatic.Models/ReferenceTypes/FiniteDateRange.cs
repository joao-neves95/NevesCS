using NevesCS.Abstractions.Types;

using System.Diagnostics.CodeAnalysis;

namespace NevesCS.NonStatic.Models.ReferenceTypes
{
    public class FiniteDateRange : IFiniteDateRange
    {
        public FiniteDateRange([NotNull, DisallowNull] DateTimeOffset start, DateTimeOffset end)
        {
            if (start == default)
            {
                throw new ArgumentNullException(nameof(start));
            }

            if (end == default)
            {
                throw new ArgumentNullException(nameof(end));
            }

            Start = start;
            End = end;
        }

        public DateTimeOffset Start { get; }

        public DateTimeOffset End { get; }

        public static bool operator ==(FiniteDateRange left, FiniteDateRange right)
        {
            return left.Equals(right);
        }

        public static bool operator !=(FiniteDateRange left, FiniteDateRange right)
        {
            return !left.Equals(right);
        }

        public override bool Equals([NotNullWhen(true)] object? obj)
        {
            return obj is IFiniteDateRange dr && this.Equals(dr);
        }

        public bool Equals(IFiniteDateRange? other)
        {
            return Start == other?.Start && End == other.End;
        }

        public bool Equals(IFiniteDateRange? x, IFiniteDateRange? y)
        {
            return x?.Equals(y) ?? false;
        }

        public override int GetHashCode()
        {
            return HashCode.Combine(Start, End);
        }

        public int GetHashCode([DisallowNull] IFiniteDateRange obj)
        {
            return HashCode.Combine(Start, End, obj.Start, obj.End);
        }
    }
}
