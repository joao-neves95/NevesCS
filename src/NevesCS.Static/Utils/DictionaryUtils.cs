namespace NevesCS.Static.Utils
{
    public static class DictionaryUtils
    {
        public static IDictionary<TKey, TValue> Clone<TKey, TValue>(IDictionary<TKey, TValue> target)
            where TKey : notnull
        {
            return new Dictionary<TKey, TValue>(target);
        }

        public static TValue GetOrCreate<TKey, TValue>(IDictionary<TKey, TValue> target, TKey key, Func<TValue>? valueFactory = null)
            where TValue : new()
        {
            if (!target.TryGetValue(key, out TValue? existingValue))
            {
                if (valueFactory == null)
                {
                    existingValue = new TValue();
                }
                else
                {
                    existingValue = valueFactory();
                }

                target.Add(key, existingValue);
            }

            return existingValue;
        }
    }
}
