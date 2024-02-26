using NevesCS.Static.Utils;

namespace NevesCS.Static.Extensions
{
    public static class DayOfWeekExtensions
    {
        public static DayOfWeek AddDays(this DayOfWeek dayOfWeek, int daysToAdd)
        {
            return DayOfWeekUtils.AddDays(dayOfWeek, daysToAdd);
        }
    }
}
