namespace NevesCS.Static.Constants
{
    public static class TimeZoneIds
    {
        public const string EUROPE_LONDON_UNIX = "Europe/London";
        public const string EUROPE_LONDON_WINDOWS = "GMT Standard Time";
        public static readonly TimeZoneSystemIdsRecord EUROPE_LONDON = new(EUROPE_LONDON_UNIX, EUROPE_LONDON_WINDOWS);
    }

    public readonly record struct TimeZoneSystemIdsRecord(string UnixTimeZoneId, string WindowsTimeZoneId);
}
