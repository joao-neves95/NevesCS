namespace NevesCS.Static.Utils
{
    public static class DayOfWeekUtils
    {
        public static IEnumerable<object[]> GetAllDaysOfWeek()
        {
            yield return new object[] { DayOfWeek.Monday };
            yield return new object[] { DayOfWeek.Tuesday };
            yield return new object[] { DayOfWeek.Wednesday };
            yield return new object[] { DayOfWeek.Thursday };
            yield return new object[] { DayOfWeek.Friday };
            yield return new object[] { DayOfWeek.Saturday };
            yield return new object[] { DayOfWeek.Sunday };
        }

        public static DayOfWeek AddDays(DayOfWeek dayOfWeek, int daysToAdd)
        {
            var newDayOfWeek = dayOfWeek;

            for (int i = 0; i < daysToAdd; ++i)
            {
                if (newDayOfWeek == DayOfWeek.Saturday)
                {
                    newDayOfWeek = 0;
                }
                else
                {
                    ++newDayOfWeek;
                }
            }

            return newDayOfWeek;
        }
    }
}
