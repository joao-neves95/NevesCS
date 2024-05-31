using NevesCS.Abstractions.Services;

namespace NevesCS.NonStatic.Services
{
    public sealed class UtcClock : IClock
    {
        public DateTimeOffset GetTime()
        {
            return DateTimeOffset.UtcNow;
        }
    }
}
