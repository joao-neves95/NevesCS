using NevesCS.Abstractions.Traits;

namespace NevesCS.NonStatic.Models.ReferenceTypes
{
    public class Duration : IDuration
    {
        public Duration(DateTimeOffset start, DateTimeOffset? end)
        {
            Start = start;
            End = end;
        }

        public DateTimeOffset Start { get; set; }

        public DateTimeOffset? End { get; set; }
    }
}
