namespace NevesCS.NonStatic.Models.ReferenceTypes
{
    public class DateRange
    {
        public DateRange(DateTimeOffset start, DateTimeOffset? end)
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
            return obj is DateRange dr && dr.Start == Start;
        }

        public static bool operator ==(DateRange left, DateRange right)
        {
            return left.Equals(right);
        }

        public static bool operator !=(DateRange left, DateRange right)
        {
            return !left.Equals(right);
        }
    }
}
