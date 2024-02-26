namespace NevesCS.Static.Utils
{
    public static class DateTimeUtils
    {
        public static DateTime From(DateTime sourceDate)
        {
            return new DateTime(
                sourceDate.Year,
                sourceDate.Month,
                sourceDate.Day,
                sourceDate.Hour,
                sourceDate.Minute,
                sourceDate.Second,
                sourceDate.Millisecond,
                sourceDate.Microsecond,
                sourceDate.Kind);
        }

        public static DateTimeOffset From(DateTimeOffset sourceDate)
        {
            return new DateTimeOffset(
                sourceDate.Year,
                sourceDate.Month,
                sourceDate.Day,
                sourceDate.Hour,
                sourceDate.Minute,
                sourceDate.Second,
                sourceDate.Millisecond,
                sourceDate.Microsecond,
                sourceDate.Offset);
        }

        public static DateTime SetHours(
            DateTime sourceDateTime,
            double? hours = null,
            double? minutes = null,
            double? seconds = null,
            double? milliseconds = null,
            double? microseconds = null)
        {
            var newDate = ToStartOfDay(sourceDateTime);

            if (hours != null)
            {
                newDate = newDate.AddHours(hours.Value);
            }

            if (minutes != null)
            {
                newDate = newDate.AddMinutes(minutes.Value);
            }

            if (seconds != null)
            {
                newDate = newDate.AddSeconds(seconds.Value);
            }

            if (milliseconds != null)
            {
                newDate = newDate.AddMilliseconds(milliseconds.Value);
            }

            if (microseconds != null)
            {
                newDate = newDate.AddMicroseconds(microseconds.Value);
            }

            return newDate;
        }

        public static DateTimeOffset SetHours(
            DateTimeOffset sourceDateTime,
            double? hours = null,
            double? minutes = null,
            double? seconds = null,
            double? milliseconds = null,
            double? microseconds = null)
        {
            return new DateTimeOffset(
                SetHours(sourceDateTime.DateTime, hours, minutes, seconds, milliseconds, microseconds),
                sourceDateTime.Offset);
        }

        public static DateTime SetTicks(DateTime sourceDateTime, long ticks)
        {
            return ToStartOfDay(sourceDateTime).AddTicks(ticks);
        }

        public static DateTimeOffset SetTicks(DateTimeOffset sourceDateTime, long ticks)
        {
            return new DateTimeOffset(SetTicks(sourceDateTime.DateTime, ticks), sourceDateTime.Offset);
        }

        public static DateTime ToNextDayOfWeek(DateTime sourceDateTime, DayOfWeek targetDayOfWeek)
        {
            return sourceDateTime.AddDays(targetDayOfWeek - sourceDateTime.DayOfWeek);
        }

        public static DateTimeOffset ToNextDayOfWeek(DateTimeOffset sourceDateTime, DayOfWeek targetDayOfWeek)
        {
            return sourceDateTime.AddDays(targetDayOfWeek - sourceDateTime.DayOfWeek);
        }

        public static DateTime ToStartOfDay(DateTime date)
        {
            return date.AddTicks(-date.TimeOfDay.Ticks);
        }

        public static DateTimeOffset ToStartOfDay(DateTimeOffset date)
        {
            return date.AddTicks(-date.TimeOfDay.Ticks);
        }

        public static DateTime ToEndOfDay(DateTime date)
        {
            return ToStartOfDay(date).AddDays(1).AddTicks(-1);
        }

        public static DateTimeOffset ToEndOfDay(DateTimeOffset date)
        {
            return ToStartOfDay(date).AddDays(1).AddTicks(-1);
        }

        public static DateTime ToStartOfWeek(DateTime date)
        {
            var newDate = ToStartOfDay(From(date));

            switch (newDate.DayOfWeek)
            {
                case DayOfWeek.Monday:
                    break;
                case DayOfWeek.Tuesday:
                    newDate = newDate.AddDays(-1);
                    break;
                case DayOfWeek.Wednesday:
                    newDate = newDate.AddDays(-2);
                    break;
                case DayOfWeek.Thursday:
                    newDate = newDate.AddDays(-3);
                    break;
                case DayOfWeek.Friday:
                    newDate = newDate.AddDays(-4);
                    break;
                case DayOfWeek.Saturday:
                    newDate = newDate.AddDays(-5);
                    break;
                case DayOfWeek.Sunday:
                    newDate = newDate.AddDays(-6);
                    break;
            }

            return newDate;
        }

        public static DateTimeOffset ToStartOfWeek(DateTimeOffset date)
        {
            return new DateTimeOffset(ToStartOfWeek(date.DateTime), date.Offset);
        }
    }
}
