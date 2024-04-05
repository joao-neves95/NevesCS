using NevesCS.Static.Utils;

namespace NevesCS.Static.Extensions
{
    public static class IEnumerableExtensions
    {
        public static void ForEach<T>(this IEnumerable<T> enumeration, Action<T> action)
        {
            IEnumerableUtils.ForEach(enumeration, action);
        }

        public static bool None<T>(this IEnumerable<T> enumeration)
        {
            return IEnumerableUtils.None(enumeration);
        }

        public static bool None<T>(this IEnumerable<T> enumeration, Func<T, bool> predicate)
        {
            return IEnumerableUtils.None(enumeration, predicate);
        }

        public static T? TryGetElementAtOr<T>(this IEnumerable<T> enumeration, Index index, T? defaultValue = default)
        {
            return IEnumerableUtils.TryGetElementAtOr(enumeration, index, defaultValue);
        }

        public static bool ContainsObjectValue<TObject, TValue>(this IEnumerable<TValue> enumeration, TObject testObject, Func<TObject, TValue> selector)
        {
            return IEnumerableUtils.ContainsObjectValue(enumeration, testObject, selector);
        }
    }
}
