using NevesCS.Abstractions.Interfaces;
using NevesCS.Static.Utils;

using Solnet.Rpc;

using System.Diagnostics.CodeAnalysis;

namespace NevesCS.NonStatic.Clients.Web3.Solana
{
    public sealed class SolnetRpcCientCachedFactory : ICachedServiceFactory<IRpcClient>
    {
        private readonly RpcClientCachedFactoryOptions Options;

        private readonly Cluster RpcClusterType;

        private readonly IHttpClientFactory HttpClientFactory;

        private readonly Dictionary<string, CacheItem> CachedRpcClients = [];

        public SolnetRpcCientCachedFactory(
            RpcClientCachedFactoryOptions options,
            Cluster rpcClusterType,
            IHttpClientFactory httpClientFactory)
        {
            Options = ObjectUtils.ThrowIfNull(options, nameof(options));
            RpcClusterType = ObjectUtils.ThrowIfNull(rpcClusterType, nameof(rpcClusterType));
            HttpClientFactory = ObjectUtils.ThrowIfNull(httpClientFactory, nameof(httpClientFactory));
        }

        public IRpcClient Create(string key)
        {
            CheckAndDeleteExpiredCacheItems();

            return DictionaryUtils
                .GetOrCreate(
                    CachedRpcClients,
                    key,
                    () => new CacheItem(ClientFactory.GetClient(
                        cluster: RpcClusterType,
                        httpClient: HttpClientFactory.CreateClient($"{nameof(IRpcClient)}_{key}"))))
                .RpcClient;
        }

        private void CheckAndDeleteExpiredCacheItems()
        {
            foreach (var item in CachedRpcClients)
            {
                if ((DateTimeOffset.UtcNow - item.Value.CreatedAt) > Options.MaxLifetime)
                {
                    CachedRpcClients.Remove(item.Key, out _);
                }
            }
        }

        private readonly struct CacheItem
        {
            [SetsRequiredMembers]
            public CacheItem(IRpcClient rpcClient)
            {
                RpcClient = rpcClient;
            }

            public required readonly IRpcClient RpcClient { get; init; }

            public readonly DateTimeOffset CreatedAt { get; } = DateTimeOffset.UtcNow;
        }
    }
}
