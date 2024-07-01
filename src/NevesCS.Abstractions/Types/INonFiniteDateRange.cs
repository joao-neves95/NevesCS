namespace NevesCS.Abstractions.Types
{
    public interface INonFiniteDateRange
        : IEqualityComparer<INonFiniteDateRange>,
          IEquatable<INonFiniteDateRange>
    {
        public DateTimeOffset Start { get; }

        public DateTimeOffset? End { get; }
    }
}
