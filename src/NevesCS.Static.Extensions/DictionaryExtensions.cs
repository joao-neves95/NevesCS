namespace NevesCS.Static.Utils
{
    public static class DictionaryExtensions
    {
        public static IDictionary<TKey, TValue> CloneIntoNew<TKey, TValue>(this IDictionary<TKey, TValue> target)
            where TKey : notnull
        {
            return DictionaryUtils.CloneIntoNew(target);
        }

        public static TValue GetOrCreate<TKey, TValue>(this IDictionary<TKey, TValue> target, TKey key, Func<TValue>? valueFactory = null)
            where TValue : new()
        {
            return DictionaryUtils.GetOrCreate(target, key, valueFactory);
        }
    }
}
