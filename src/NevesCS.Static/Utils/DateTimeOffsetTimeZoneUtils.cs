using NevesCS.Static.Constants;

namespace NevesCS.Static.Utils
{
    public static class DateTimeOffsetTimeZoneUtils
    {
        public static DateTimeOffset ToUtcOffset(DateTimeOffset localDateTime, TimeZoneInfo sourceTimeZone)
        {
            return ToUtcOffset(localDateTime.DateTime, sourceTimeZone);
        }

        public static DateTimeOffset ToUtcOffset(DateTime localDateTime, TimeZoneInfo sourceTimeZone)
        {
            return new DateTimeOffset(ToUtc(localDateTime, sourceTimeZone), TimeSpan.Zero);
        }

        public static DateTime ToUtc(DateTime localDateTime, TimeZoneInfo sourceTimeZone)
        {
            if (localDateTime.Kind == DateTimeKind.Utc)
            {
                return localDateTime;
            }

            return TimeZoneInfo.ConvertTimeToUtc(localDateTime, sourceTimeZone);
        }

        /// <summary>
        /// Returns the UTC date for date plus the specified days in accordance with local timezone. <br/>
        /// This is a DST aware method.
        ///
        /// </summary>
        public static DateTimeOffset AddDays(DateTimeOffset date, double days, TimeZoneInfo timeZone)
        {
            var localDate = TimeZoneInfo.ConvertTimeFromUtc(date.UtcDateTime, timeZone)
                .AddDays(days);

            return ToUtcOffset(localDate, timeZone);
        }

        /// <summary>
        /// Returns the UTC date for date plus the specified months in accordance with local timezone. <br/>
        /// This is a DST aware method.
        ///
        /// </summary>
        public static DateTimeOffset AddMonths(DateTimeOffset date, int months, TimeZoneInfo timeZone)
        {
            var localDate = TimeZoneInfo.ConvertTimeFromUtc(date.UtcDateTime, timeZone)
                .AddMonths(months);

            return ToUtcOffset(localDate, timeZone);
        }

        /// <summary>
        /// Returns the UTC date for date plus the specified years in accordance with local timezone. <br/>
        /// This is a DST aware method.
        ///
        /// </summary>
        public static DateTimeOffset AddYears(DateTimeOffset date, int years, TimeZoneInfo timeZone)
        {
            var localDate = TimeZoneInfo.ConvertTimeFromUtc(date.UtcDateTime, timeZone)
                .AddYears(years);

            return ToUtcOffset(localDate, timeZone);
        }

        /// <summary>
        /// Returns the UTC date corresponding to the start of day for the UTC date in accordance with local timezone. <br/>
        /// This is a DST aware method.
        ///
        /// </summary>
        public static DateTimeOffset ToStartOfDay(DateTimeOffset dateTime, TimeZoneInfo timeZone)
        {
            var localDate = TimeZoneInfo.ConvertTimeFromUtc(dateTime.UtcDateTime, timeZone);

            return ToUtcOffset(
                localDate
                    .AddHours(-localDate.Hour)
                    .AddMinutes(-localDate.Minute)
                    .AddSeconds(-localDate.Second)
                    .AddMilliseconds(-localDate.Millisecond),
                timeZone);
        }

        public static DateTimeOffset ToStartOfWeek(DateTimeOffset date, TimeZoneInfo timeZone)
        {
            var localDate = TimeZoneInfo.ConvertTimeFromUtc(date.UtcDateTime, timeZone);
            var newDate = ToStartOfDay(localDate, timeZone);

            switch (newDate.DayOfWeek)
            {
                case DayOfWeek.Monday:
                    break;
                case DayOfWeek.Tuesday:
                    newDate = newDate.AddDays(-Ints.One);
                    break;
                case DayOfWeek.Wednesday:
                    newDate = newDate.AddDays(-Ints.Two);
                    break;
                case DayOfWeek.Thursday:
                    newDate = newDate.AddDays(-Ints.Three);
                    break;
                case DayOfWeek.Friday:
                    newDate = newDate.AddDays(-Ints.Four);
                    break;
                case DayOfWeek.Saturday:
                    newDate = newDate.AddDays(-Ints.Five);
                    break;
                case DayOfWeek.Sunday:
                    newDate = newDate.AddDays(-Ints.Six);
                    break;
            }

            return newDate.ToUniversalTime();
        }

        public static DateTimeOffset ToStartOfMonth(DateTimeOffset date, TimeZoneInfo timeZone)
        {
            var localDate = TimeZoneInfo.ConvertTimeFromUtc(date.UtcDateTime, timeZone);

            return ToStartOfDay(date, timeZone)
                .AddDays(-(localDate.Day - 1));
        }

        public static DateTimeOffset ToNextDayOfWeek(DateTimeOffset dateTime, DayOfWeek targetDayOfWeek, TimeZoneInfo timeZone)
        {
            var localDate = TimeZoneInfo.ConvertTimeFromUtc(dateTime.UtcDateTime, timeZone);
            var currentDayOfWeek = localDate.DayOfWeek;

            return ToUtcOffset(localDate
                .AddDays(targetDayOfWeek - currentDayOfWeek),
                timeZone);
        }
    }
}
