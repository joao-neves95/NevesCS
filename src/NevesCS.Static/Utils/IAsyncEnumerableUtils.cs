namespace NevesCS.Static.Utils
{
    public static class IAsyncEnumerableUtils
    {
        public static async ValueTask<List<T>> ConsumeIntoListAsync<T>(
            this IAsyncEnumerable<T> source,
            CancellationToken cancellationToken = default)
        {
            return await source.ToListAsync(cancellationToken).ConfigureAwait(false);
        }
    }
}
