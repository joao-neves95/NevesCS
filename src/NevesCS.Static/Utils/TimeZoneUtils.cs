using NevesCS.Static.Constants;

using System.Runtime.InteropServices;

namespace NevesCS.Static.Utils
{
    public static class TimeZoneUtils
    {
        public static readonly TimeZoneInfo London = GetTimeZone(TimeZoneIds.EUROPE_LONDON_UNIX, TimeZoneIds.EUROPE_LONDON_WINDOWS);

        public static TimeZoneInfo GetTimeZone(string unixTimezoneName, string windowsTimezoneName)
        {
            return GetTimeZone(RuntimeInformation.IsOSPlatform(OSPlatform.Windows) ? windowsTimezoneName : unixTimezoneName);
        }

        public static TimeZoneInfo GetTimeZone(string timezoneId)
        {
            TimeZoneInfo tz;

            try
            {
                tz = TimeZoneInfo.FindSystemTimeZoneById(timezoneId);
            }
            catch (TimeZoneNotFoundException)
            {
                throw new TimeZoneNotFoundException(
                    "Could not find timezone for " +
                    $"{(RuntimeInformation.IsOSPlatform(OSPlatform.Windows) ? nameof(OSPlatform.Windows) : "Unix")} " +
                    $"system. `{timezoneId}`");
            }

            return tz;
        }

        public static DateTimeOffset ConvertToLondonTimeZone(DateTimeOffset source)
        {
            return ConvertToTimeZone(source, London);
        }

        public static DateTimeOffset ConvertToTimeZone(DateTimeOffset source, TimeZoneInfo timeZoneInfo)
        {
            return TimeZoneInfo.ConvertTime(source, timeZoneInfo);
        }
    }
}
