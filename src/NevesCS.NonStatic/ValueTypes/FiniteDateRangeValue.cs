namespace NevesCS.NonStatic.ValueTypes
{
    public readonly struct FiniteDateRange
    {
        public FiniteDateRange(DateTimeOffset start, DateTimeOffset end)
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
            return obj is FiniteDateRange dr
                && dr.Start == Start
                && dr.End == End;
        }

        public static bool operator ==(FiniteDateRange left, FiniteDateRange right)
        {
            return left.Equals(right);
        }

        public static bool operator !=(FiniteDateRange left, FiniteDateRange right)
        {
            return !left.Equals(right);
        }
    }
}
