using NevesCS.Static.Utils;

namespace NevesCS.Static.Extensions
{
    public static class IEnumerableExtensions
    {
        public static void ForEach<T>(this IEnumerable<T> enumeration, Action<T> action)
        {
            IEnumerableUtils.ForEach(enumeration, action);
        }

        public static T? TryGetElementAtOr<T>(this IEnumerable<T> enumeration, Index index, T? defaultValue = default)
        {
            return IEnumerableUtils.TryGetElementAtOr(enumeration, index, defaultValue);
        }
    }
}
