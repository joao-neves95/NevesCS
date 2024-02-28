namespace NevesCS.Static.Utils
{
    public static class FuncUtils
    {
        /// <summary>
        /// Enumerates the result of <paramref name="sourceFactory"/> times the number defined by <paramref name="repeatTimes"/>.
        ///
        /// </summary>
        public static IEnumerable<T> Enumerate<T>(Func<T> sourceFactory, int repeatTimes = 0)
        {
            for (int i = 1; i <= repeatTimes; ++i)
            {
                yield return sourceFactory();
            }
        }
    }
}
