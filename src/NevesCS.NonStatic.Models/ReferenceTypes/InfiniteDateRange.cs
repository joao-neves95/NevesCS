namespace NevesCS.NonStatic.Models.ReferenceTypes
{
    public class InfiniteDateRange
    {
        public InfiniteDateRange(DateTimeOffset start)
        {
            if (start == default)
            {
                throw new ArgumentNullException(nameof(start));
            }

            Start = start;
        }

        public DateTimeOffset Start { get; }

        public DateTimeOffset? End { get; }

        public override int GetHashCode()
        {
            return HashCode.Combine(Start, End);
        }

        public override bool Equals(object obj)
        {
            return obj is FiniteDateRange dr
                && dr.Start == Start;
        }

        public static bool operator ==(InfiniteDateRange left, InfiniteDateRange right)
        {
            return left.Equals(right);
        }

        public static bool operator !=(InfiniteDateRange left, InfiniteDateRange right)
        {
            return !left.Equals(right);
        }
    }
}
