using NevesCS.Abstractions.Services;
using NevesCS.Static.Utils;

namespace NevesCS.NonStatic.Clients.Web3.DexToolsClient
{
    public sealed class DexToolsV1HttpClientCachedFactory : BaseHttpClientCachedFactory<DexToolsV1HttpClient>
    {
        private readonly IThreadRateLimiter? ThreadRateLimiter;

        public DexToolsV1HttpClientCachedFactory(HttpClientCachedFactoryOptions options, IHttpClientFactory httpClientFactory)
            : base(options, httpClientFactory)
        {
        }

        public DexToolsV1HttpClientCachedFactory(
            HttpClientCachedFactoryOptions options,
            IHttpClientFactory httpClientFactory,
            IThreadRateLimiter rateLimiter)
            : base(options, httpClientFactory)
        {
            ThreadRateLimiter = ObjectUtils.ThrowIfNull(rateLimiter, nameof(rateLimiter));
        }

        protected override DexToolsV1HttpClient CreateNewInstance(string key, HttpClient httpClient)
        {
            return ThreadRateLimiter == null
                ? new DexToolsV1HttpClient(httpClient)
                : new DexToolsV1HttpClient(httpClient, ThreadRateLimiter);
        }
    }
}
