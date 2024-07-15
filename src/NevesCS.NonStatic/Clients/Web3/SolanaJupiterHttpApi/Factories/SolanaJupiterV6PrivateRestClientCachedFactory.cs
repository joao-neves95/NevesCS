using NevesCS.Abstractions.Interfaces;
using NevesCS.Abstractions.Services;
using NevesCS.Static.Utils;

using Solnet.Rpc;
using Solnet.Wallet;

namespace NevesCS.NonStatic.Clients.Web3.SolanaJupiterHttpApi.Factories
{
    public sealed class SolanaJupiterV6PrivateRestClientCachedFactory : BaseHttpClientCachedFactory<SolanaJupiterV6PrivateRestClient>
    {
        private readonly Wallet Wallet;

        private readonly ICachedServiceFactory<IRpcClient> CachedRpcClientFactory;

        private readonly IJsonParser JsonParser;

        public SolanaJupiterV6PrivateRestClientCachedFactory(
            HttpClientCachedFactoryOptions options,
            Wallet wallet,
            ICachedServiceFactory<IRpcClient> cachedRpcClientFactory,
            IHttpClientFactory httpClientFactory,
            IJsonParser jsonParser)

            :base(options, httpClientFactory)
        {
            Wallet = ObjectUtils.ThrowIfNull(wallet, nameof(wallet));
            CachedRpcClientFactory = ObjectUtils.ThrowIfNull(cachedRpcClientFactory, nameof(cachedRpcClientFactory));
            JsonParser = ObjectUtils.ThrowIfNull(jsonParser, nameof(jsonParser));
        }

        protected override SolanaJupiterV6PrivateRestClient CreateNewInstance(string key, HttpClient httpClient)
        {
            return new SolanaJupiterV6PrivateRestClient(
                Wallet,
                CachedRpcClientFactory.Create(key),
                httpClient,
                JsonParser);
        }
    }
}
