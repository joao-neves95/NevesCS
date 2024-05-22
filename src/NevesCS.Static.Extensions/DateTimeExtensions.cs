using NevesCS.Static.Constants;
using NevesCS.Static.Utils;

namespace NevesCS.Static.Extensions
{
    public static class DateTimeExtensions
    {
        /// <summary>
        ///  Gets a <see cref="System.DateTime"/> value that represents the date component of the current System.DateTimeOffset object.
        ///
        /// </summary>
        public static DateTimeOffset GetDateWithOffset(this DateTimeOffset source)
        {
            return DateTimeUtils.GetDateWithOffset(source);
        }

        public static DateTime SetHours(
            this DateTime sourceDateTime,
            double? hours = null,
            double? minutes = null,
            double? seconds = null,
            double? milliseconds = null,
            double? microseconds = null)
        {
            return DateTimeUtils.SetHours(sourceDateTime, hours, minutes, seconds, milliseconds, microseconds);
        }

        public static DateTimeOffset SetHours(
            this DateTimeOffset sourceDateTime,
            double? hours = null,
            double? minutes = null,
            double? seconds = null,
            double? milliseconds = null,
            double? microseconds = null)
        {
            return DateTimeUtils.SetHours(sourceDateTime.DateTime, hours, minutes, seconds, milliseconds, microseconds);
        }

        public static DateTime SetTicks(this DateTime sourceDateTime, long ticks)
        {
            return DateTimeUtils.SetTicks(sourceDateTime, ticks);
        }

        public static DateTimeOffset SetTicks(this DateTimeOffset sourceDateTime, long ticks)
        {
            return DateTimeUtils.SetTicks(sourceDateTime, ticks);
        }

        public static DateTime ToNextDayOfWeek(this DateTime sourceDateTime, DayOfWeek targetDayOfWeek)
        {
            return DateTimeUtils.ToNextDayOfWeek(sourceDateTime, targetDayOfWeek);
        }

        public static DateTimeOffset ToNextDayOfWeek(this DateTimeOffset sourceDateTime, DayOfWeek targetDayOfWeek)
        {
            return DateTimeUtils.ToNextDayOfWeek(sourceDateTime, targetDayOfWeek);
        }

        public static DateTime ToStartOfDay(this DateTime date)
        {
            return DateTimeUtils.ToStartOfDay(date);
        }

        public static DateTimeOffset ToStartOfDay(this DateTimeOffset date)
        {
            return DateTimeUtils.ToStartOfDay(date);
        }

        public static DateTime ToEndOfDay(this DateTime date)
        {
            return DateTimeUtils.ToEndOfDay(date);
        }

        public static DateTimeOffset ToEndOfDay(this DateTimeOffset date)
        {
            return DateTimeUtils.ToEndOfDay(date);
        }

        public static DateTime ToStartOfWeek(this DateTime date)
        {
            return DateTimeUtils.ToStartOfWeek(date);
        }

        public static DateTimeOffset ToStartOfWeek(this DateTimeOffset date)
        {
            return DateTimeUtils.ToStartOfWeek(date);
        }

        public static string ToIso8601FormatString(this DateTimeOffset date)
        {
            return DateTimeUtils.ToIso8601FormatString(date);
        }

        public static string ToSqlQueryFormatString(this DateTimeOffset date)
        {
            return DateTimeUtils.ToSqlQueryFormatString(date);
        }
    }
}
