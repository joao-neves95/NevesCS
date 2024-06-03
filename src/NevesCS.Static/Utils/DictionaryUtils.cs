namespace NevesCS.Static.Utils
{
    public static class DictionaryUtils
    {
        public static IDictionary<TKey, TValue> CloneIntoNew<TKey, TValue>(IDictionary<TKey, TValue> target)
            where TKey : notnull
        {
            return new Dictionary<TKey, TValue>(target);
        }

        public static IDictionary<TKey, TValue> Upsert<TKey, TValue>(IDictionary<TKey, TValue> target, TKey key, TValue value)
            where TValue : new()
        {
            target[key] = value;

            return target;
        }

        public static TValue? GetValueOr<TKey, TValue>(
            IDictionary<TKey, TValue> target,
            TKey key,
            TValue? defaultValue = default)
        {
            if (!target.TryGetValue(key, out TValue? existingValue))
            {
                return defaultValue;
            }

            return existingValue;
        }

        /// <summary>
        /// Get an item by key, or adds a new return value from the <paramref name="valueFactory"/>.
        ///
        /// </summary>
        public static TValue GetOrCreate<TKey, TValue>(
            IDictionary<TKey, TValue> target,
            TKey key,
            Func<TValue>? valueFactory = null)
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

        /// <summary>
        /// Get an item by key, or adds a new return value from the <paramref name="valueFactory"/>.
        ///
        /// </summary>
        public static async Task<TValue> GetOrCreateAsync<TKey, TValue>(
            IDictionary<TKey, TValue> target,
            TKey key,
            Func<Task<TValue>>? valueFactory = null)

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
                    existingValue = await valueFactory();
                }

                target.Add(key, existingValue);
            }

            return existingValue;
        }
    }
}
