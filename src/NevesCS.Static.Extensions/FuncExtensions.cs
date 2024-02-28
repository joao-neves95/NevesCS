using NevesCS.Static.Utils;

namespace NevesCS.Static.Extensions
{
    public static class FuncExtensions
    {
        /// <summary>
        /// Enumerates the result of <paramref name="sourceFactory"/> times the number defined by <paramref name="repeatTimes"/>.
        ///
        /// </summary>
        public static IEnumerable<T> Enumerate<T>(this Func<T> sourceFactory, int repeatTimes = 0)
        {
            return FuncUtils.Enumerate(sourceFactory, repeatTimes);
        }
    }
}
