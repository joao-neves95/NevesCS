
namespace NevesCS.Static.Extensions
{
    public static class IEnumerableExtensions
    {
        public static void ForEach<T>(this IEnumerable<T> enumeration, Action<T> action)
        {
            foreach (T item in enumeration)
            {
                action(item);
            }
        }

        // TODO: (optimized)
        public static bool In<T>(this IEnumerable<T>? enumerable, IEnumerable<T> target)
        {
            throw new NotImplementedException("TODO");
        }
    }
}
