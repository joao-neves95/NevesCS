using NevesCS.Static.Utils;

namespace NevesCS.Static.Extensions
{
    public static class DictionaryExtensions
    {
        public static IDictionary<TKey, TValue> CloneIntoNew<TKey, TValue>(this IDictionary<TKey, TValue> target)
            where TKey : notnull
        {
            return DictionaryUtils.CloneIntoNew(target);
        }

        public static TValue? GetValueOr<TKey, TValue>(
            this IDictionary<TKey, TValue> target,
            TKey key,
            TValue? defaultValue = default)
        {
            return DictionaryUtils.GetValueOr(target, key, defaultValue);
        }

        public static TValue GetOrCreate<TKey, TValue>(
            this IDictionary<TKey, TValue> target,
            TKey key,
            Func<TValue>? valueFactory = null)

            where TValue : new()
        {
            return DictionaryUtils.GetOrCreate(target, key, valueFactory);
        }

        public static async Task<TValue> GetOrCreateAsync<TKey, TValue>(
            this IDictionary<TKey, TValue> target,
            TKey key,
            Func<Task<TValue>>? valueFactory = null)

            where TValue : new()
        {
            return await DictionaryUtils.GetOrCreateAsync(target, key, valueFactory);
        }

        public static IDictionary<TKey, TValue> Upsert<TKey, TValue>(
            this IDictionary<TKey, TValue> target,
            TKey key,
            TValue value)

            where TValue : new()
        {
            return DictionaryUtils.Upsert(target, key, value);
        }
    }
}
