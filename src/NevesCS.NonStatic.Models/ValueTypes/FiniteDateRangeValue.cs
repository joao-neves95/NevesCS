using NevesCS.Abstractions.Traits;

namespace NevesCS.NonStatic.Models.ValueTypes
{
    public readonly struct FiniteDateRangeValue : IConvertible<(DateTimeOffset start, DateTimeOffset end)>
    {
        public FiniteDateRangeValue(DateTimeOffset start, DateTimeOffset end)
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

        public override readonly int GetHashCode()
        {
            return HashCode.Combine(Start, End);
        }

        public override readonly bool Equals(object obj)
        {
            return obj is FiniteDateRangeValue dr
                && dr.Start == Start
                && dr.End == End;
        }

        public static bool operator ==(FiniteDateRangeValue left, FiniteDateRangeValue right)
        {
            return left.Equals(right);
        }

        public static bool operator !=(FiniteDateRangeValue left, FiniteDateRangeValue right)
        {
            return !left.Equals(right);
        }

        public (DateTimeOffset start, DateTimeOffset end) To<Out>()
        {
            return (Start, End);
        }
    }
}
