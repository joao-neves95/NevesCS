namespace NevesCS.Abstractions.Types
{
    public interface INonFiniteDateRange
        : IDateRange,
          IEqualityComparer<INonFiniteDateRange>,
          IEquatable<INonFiniteDateRange>
    {
        public DateTimeOffset? End { get; }
    }
}
