namespace NevesCS.Abstractions.Types
{
    public interface IFiniteDateRange
        : IDateRange,
          IEqualityComparer<IFiniteDateRange>,
          IEquatable<IFiniteDateRange>
    {
        public DateTimeOffset End { get; }
    }
}
