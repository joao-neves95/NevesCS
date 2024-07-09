using NevesCS.Static.Utils;

using System.Diagnostics.CodeAnalysis;

namespace NevesCS.Static.Constants
{
    [ExcludeFromCodeCoverage]
    public static class TimeZones
    {
        public static readonly TimeZoneInfo London = TimeZoneUtils.GetTimeZone(TimeZoneIds.LONDON);

        public static readonly TimeZoneInfo Berlin = TimeZoneUtils.GetTimeZone(TimeZoneIds.BERLIN);
    }
}
