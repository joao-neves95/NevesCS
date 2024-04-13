using NevesCS.Abstractions.Traits;

namespace NevesCS.NonStatic.ValueTypes
{
    public struct DurationValue : IDuration
    {
        public DurationValue(DateTimeOffset start, DateTimeOffset? end)
        {
            Start = start;
            End = end;
        }

        public DateTimeOffset Start { get; set; }

        public DateTimeOffset? End { get; set; }
    }
}
