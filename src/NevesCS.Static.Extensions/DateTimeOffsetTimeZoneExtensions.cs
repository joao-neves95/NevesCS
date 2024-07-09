using NevesCS.Static.Utils;

namespace NevesCS.Static.Extensions
{
    public static class DateTimeOffsetTimeZoneExtensions
    {
        public static DateTimeOffset ToUtcOffset(this DateTimeOffset localDateTime, TimeZoneInfo sourceTimeZone)
        {
            return DateTimeOffsetTimeZoneUtils.ToUtcOffset(localDateTime, sourceTimeZone);
        }

        public static DateTimeOffset ToUtcOffset(this DateTime localDateTime, TimeZoneInfo sourceTimeZone)
        {
            return DateTimeOffsetTimeZoneUtils.ToUtcOffset(localDateTime, sourceTimeZone);
        }

        public static DateTime ToUtc(this DateTime localDateTime, TimeZoneInfo sourceTimeZone)
        {
            return DateTimeOffsetTimeZoneUtils.ToUtc(localDateTime, sourceTimeZone);
        }

        /// <summary>
        /// Returns the UTC date for date plus the specified days in accordance with local timezone. <br/>
        /// This is a DST aware method.
        ///
        /// </summary>
        public static DateTimeOffset AddDays(this DateTimeOffset date, double days, TimeZoneInfo timeZone)
        {
            return DateTimeOffsetTimeZoneUtils.AddDays(date, days, timeZone);
        }

        /// <summary>
        /// Returns the UTC date for date plus the specified months in accordance with local timezone. <br/>
        /// This is a DST aware method.
        ///
        /// </summary>
        public static DateTimeOffset AddMonths(this DateTimeOffset date, int months, TimeZoneInfo timeZone)
        {
            return DateTimeOffsetTimeZoneUtils.AddMonths(date, months, timeZone);
        }

        /// <summary>
        /// Returns the UTC date for date plus the specified years in accordance with local timezone. <br/>
        /// This is a DST aware method.
        ///
        /// </summary>
        public static DateTimeOffset AddYears(this DateTimeOffset date, int years, TimeZoneInfo timeZone)
        {
            return DateTimeOffsetTimeZoneUtils.AddYears(date, years, timeZone);
        }

        public static DateTimeOffset ToStartOfDay(this DateTimeOffset date, TimeZoneInfo timeZone)
        {
            return DateTimeOffsetTimeZoneUtils.ToStartOfDay(date, timeZone);
        }

        public static DateTimeOffset ToStartOfWeek(this DateTimeOffset date, TimeZoneInfo timeZone)
        {
            return DateTimeOffsetTimeZoneUtils.ToStartOfWeek(date, timeZone);
        }

        public static DateTimeOffset ToStartOfMonth(this DateTimeOffset date, TimeZoneInfo timeZone)
        {
            return DateTimeOffsetTimeZoneUtils.ToStartOfMonth(date, timeZone);
        }

        public static DateTimeOffset ToNextDayOfWeek(this DateTimeOffset dateTime, DayOfWeek targetDayOfWeek, TimeZoneInfo timeZone)
        {
            return DateTimeOffsetTimeZoneUtils.ToNextDayOfWeek(dateTime, targetDayOfWeek, timeZone);
        }
    }
}
