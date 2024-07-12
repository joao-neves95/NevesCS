using NevesCS.Abstractions.Interfaces;
using NevesCS.Static.Utils;

using System.Collections.Concurrent;
using System.Diagnostics.CodeAnalysis;

namespace NevesCS.NonStatic.Clients
{
    public abstract class BaseHttpClientCachedFactory<TService> : ICachedServiceFactory<TService>
    {
        private readonly HttpClientCachedFactoryOptions Options;

        private readonly IHttpClientFactory HttpClientFactory;

        private readonly ConcurrentDictionary<string, CacheItem> CachedHttpClients = [];

        protected BaseHttpClientCachedFactory(HttpClientCachedFactoryOptions options, IHttpClientFactory httpClientFactory)
        {
            Options = ObjectUtils.ThrowIfNull(options, nameof(options));
            HttpClientFactory = ObjectUtils.ThrowIfNull(httpClientFactory, nameof(httpClientFactory));
        }

        protected abstract TService CreateNewInstance(string key, HttpClient httpClient);

        public TService Create(string key)
        {
            CheckAndDeleteExpiredCacheItems();

            return CreateNewInstance(
                key,
                DictionaryUtils.GetOrCreate(
                    CachedHttpClients,
                    key,
                    () => new CacheItem(HttpClientFactory.CreateClient(key)))
                .HttpClient);
        }

        private void CheckAndDeleteExpiredCacheItems()
        {
            foreach (var item in CachedHttpClients)
            {
                if ((DateTimeOffset.UtcNow - item.Value.CreatedAt) > Options.MaxLifetime)
                {
                    item.Value.HttpClient.Dispose();
                    CachedHttpClients.Remove(item.Key, out _);
                }
            }
        }

        private readonly struct CacheItem
        {
            [SetsRequiredMembers]
            public CacheItem(HttpClient httpClient)
            {
                HttpClient = httpClient;
            }

            public required readonly HttpClient HttpClient { get; init; }

            public readonly DateTimeOffset CreatedAt { get; } = DateTimeOffset.UtcNow;
        }
    }
}
