namespace NevesCS.Static.Utils
{
    public static class IEnumerableUtils
    {
        public static void ForEach<T>(IEnumerable<T> enumeration, Action<T> action)
        {
            Array.ForEach(enumeration.ToArray(), action);
        }

        public static T? TryGetElementAtOr<T>(IEnumerable<T> enumeration, Index index, T? defaultValue = default)
        {
            try
            {
                return enumeration.ElementAt(index);
            }
            catch (IndexOutOfRangeException)
            {
                return defaultValue;
            }
        }
    }
}
