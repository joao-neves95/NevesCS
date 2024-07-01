namespace NevesCS.Abstractions.Types
{
    public interface IFiniteDateRange
        : IEqualityComparer<IFiniteDateRange>,
          IEquatable<IFiniteDateRange>
    {
        public DateTimeOffset Start { get; }

        public DateTimeOffset End { get; }
    }
}
