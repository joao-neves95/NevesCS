namespace NevesCS.NonStatic.Clients.Web3.SolanaJupiterHttpApi.Factories
{
    public sealed class SolanaJupiterV6PublicRestClientCachedFactory : BaseHttpClientCachedFactory<SolanaJupiterV6PublicRestClient>
    {
        public SolanaJupiterV6PublicRestClientCachedFactory(
            HttpClientCachedFactoryOptions options,
            IHttpClientFactory httpClientFactory)
            : base(options, httpClientFactory)
        {
        }

        protected override SolanaJupiterV6PublicRestClient CreateNewInstance(string key, HttpClient httpClient)
        {
            return new SolanaJupiterV6PublicRestClient(httpClient);
        }
    }
}
