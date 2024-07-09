using System.Diagnostics.CodeAnalysis;

namespace NevesCS.Static.Constants
{
    /// <summary>
    /// Windows: <see href="https://learn.microsoft.com/en-us/windows-hardware/manufacture/desktop/default-time-zones"/> <br/>
    /// Unix: <see href="https://en.wikipedia.org/wiki/List_of_tz_database_time_zones"/>
    ///
    /// </summary>
    [ExcludeFromCodeCoverage]
    public static class TimeZoneIds
    {
        public const string LONDON_UNIX = "Europe/London";
        public const string LONDON_WINDOWS = "GMT Standard Time";
        public static readonly SystemTimeZoneIdsRecord LONDON = new(LONDON_UNIX, LONDON_WINDOWS);

        public const string BERLIN_UNIX = "Europe/Berlin";
        public const string BERLIN_WINDOWS = "W. Europe Standard Time";
        public static readonly SystemTimeZoneIdsRecord BERLIN = new(BERLIN_UNIX, BERLIN_WINDOWS);
    }

    [ExcludeFromCodeCoverage]
    public readonly record struct SystemTimeZoneIdsRecord
    {
        [SetsRequiredMembers]
        public SystemTimeZoneIdsRecord(string unixTimeZoneId, string windowsTimeZoneId)
        {
            Unix = unixTimeZoneId;
            Windows = windowsTimeZoneId;
        }

        public required readonly string Unix { get; init; }

        public required readonly string Windows { get; init; }
    }
}
