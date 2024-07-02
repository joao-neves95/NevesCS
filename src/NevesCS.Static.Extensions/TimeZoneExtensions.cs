using NevesCS.Static.Utils;

namespace NevesCS.Static.Extensions
{
    public static class TimeZoneExtensions
    {
        public static DateTimeOffset ConvertToLondonTimeZone(this DateTimeOffset source)
        {
            return TimeZoneUtils.ConvertToLondonTimeZone(source);
        }

        public static DateTimeOffset ConvertToTimeZone(this DateTimeOffset source, TimeZoneInfo timeZoneInfo)
        {
            return TimeZoneUtils.ConvertToTimeZone(source, timeZoneInfo);
        }
    }
}
