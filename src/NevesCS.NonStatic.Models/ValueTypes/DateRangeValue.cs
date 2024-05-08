namespace NevesCS.NonStatic.Models.ReferenceTypes
{
    public struct DateRangeValue
    {
        public DateRangeValue(DateTimeOffset start, DateTimeOffset? end)
        {
            if (start == default)
            {
                throw new ArgumentNullException(nameof(start));
            }

            Start = start;
            End = end;
        }

        public DateTimeOffset Start { get; }

        public DateTimeOffset? End { get; }

        public override int GetHashCode()
        {
            return HashCode.Combine(Start, End);
        }

        public override bool Equals(object obj)
        {
            return obj is DateRangeValue dr && dr.Start == Start;
        }

        public static bool operator ==(DateRangeValue left, DateRangeValue right)
        {
            return left.Equals(right);
        }

        public static bool operator !=(DateRangeValue left, DateRangeValue right)
        {
            return !left.Equals(right);
        }
    }
}
