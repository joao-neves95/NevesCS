using NevesCS.Abstractions.Clients.Web3.SolanaJupiterHttpApi;
using NevesCS.Abstractions.Clients.Web3.SolanaJupiterHttpApi.Models;
using NevesCS.Static.Utils;

using System.Net.Http.Json;

namespace NevesCS.NonStatic.Clients.Web3.SolanaJupiterHttpApi
{
    public sealed class SolanaJupiterV6PublicRestClient : ISolanaJupiterV6PublicClient
    {
        private readonly HttpClient? HttpClient;

        private readonly IHttpClientFactory? HttpClientFactory;

        private readonly bool HasFactory;

        public SolanaJupiterV6PublicRestClient(HttpClient httpClient)
        {
            HttpClient = ObjectUtils.ThrowIfNull(httpClient, nameof(httpClient));
        }

        public SolanaJupiterV6PublicRestClient(IHttpClientFactory httpClientFactory)
        {
            HttpClientFactory = ObjectUtils.ThrowIfNull(httpClientFactory, typeof(IHttpClientFactory));

            HasFactory = true;
        }

        /// <summary>
        /// https://price.jup.ag/v6/price?ids=token1,token2&vsToken=quote-token
        /// </summary>
        public async Task<SolanaJupiterV6GetPriceApiResponse?> GetCurrentPriceAsync(
            SolanaJupiterV6GetPriceRequest request,
            CancellationToken cancellationToken = default)
        {
            var httpClient = HasFactory ? HttpClientFactory.CreateClient() : HttpClient;

            var response = await httpClient
                .GetFromJsonAsync<SolanaJupiterV6GetPriceApiResponse>(
                    $"{SolanaJupiterConstants.BaseUrlApiPrice}/price?ids={string.Join(',', request.Ids)}&vsToken={request.VsToken}",
                    cancellationToken);

            if (HasFactory)
            {
                httpClient.Dispose();
            }

            return response;
        }
    }
}
