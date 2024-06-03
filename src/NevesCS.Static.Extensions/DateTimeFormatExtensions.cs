using NevesCS.Static.Utils;

namespace NevesCS.Static.Extensions
{
    public static class DateTimeFormatExtensions
    {
        public static string ToIso8601FormatString(this DateTimeOffset date)
        {
            return DateTimeFormatUtils.ToIso8601FormatString(date);
        }

        public static string ToDetailedFormatString(this DateTimeOffset date)
        {
            return DateTimeFormatUtils.ToDetailedFormatString(date);
        }

        public static string ToSqlQueryFormatString(this DateTimeOffset date)
        {
            return DateTimeFormatUtils.ToSqlQueryFormatString(date);
        }
    }
}
