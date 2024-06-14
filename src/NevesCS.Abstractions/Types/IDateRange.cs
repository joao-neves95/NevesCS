using System.Collections;

namespace NevesCS.Abstractions.Types
{
    public interface IDateRange
        : IEqualityComparer,
          IEqualityComparer<IDateRange>,
          IEquatable<IDateRange>
    {
        public DateTimeOffset Start { get; }
    }
}
