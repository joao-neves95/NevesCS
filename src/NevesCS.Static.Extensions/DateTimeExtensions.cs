using NevesCS.Abstractions.Options;
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

        public static DateTime SetTime(
            this DateTime sourceDateTime,
            double? hours = null,
            double? minutes = null,
            double? seconds = null,
            double? milliseconds = null,
            double? microseconds = null)
        {
            return DateTimeUtils.SetTime(sourceDateTime, hours, minutes, seconds, milliseconds, microseconds);
        }

        public static DateTimeOffset SetTime(
            this DateTimeOffset sourceDateTime,
            double? hours = null,
            double? minutes = null,
            double? seconds = null,
            double? milliseconds = null,
            double? microseconds = null)
        {
            return DateTimeUtils.SetTime(sourceDateTime.DateTime, hours, minutes, seconds, milliseconds, microseconds);
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

        public static DateTimeOffset ToNext(
            this DateTimeOffset source,
            TimeComponent timeComponent,
            double componentQuantity = Ints.One)
        {
            return DateTimeUtils.ToNext(source, timeComponent, componentQuantity);
        }
    }
}
