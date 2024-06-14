using NevesCS.Abstractions.Clients;
using NevesCS.NonStatic.Clients.Web3.SolanaJupiterHttpApi.Models;
using NevesCS.Static.Utils;

using System.Net.Http.Json;

namespace NevesCS.NonStatic.Clients.Web3.SolanaJupiterHttpApi
{
    public sealed class SolanaJupiterV6PublicRestClient
        : IRequestProvider<SolanaJupiterV6GetPriceRequest, SolanaJupiterV6GetPriceApiResponse>
    {
        private readonly IHttpClientFactory HttpClientFactory;

        public SolanaJupiterV6PublicRestClient(IHttpClientFactory httpClientFactory)
        {
            HttpClientFactory = ObjectUtils.ThrowIfNull(httpClientFactory);
        }

        /// <summary>
        /// https://price.jup.ag/v6/price?ids=token1,token2&vsToken=quote-token
        /// </summary>
        public async Task<SolanaJupiterV6GetPriceApiResponse?> RequestAsync(
            SolanaJupiterV6GetPriceRequest request,
            CancellationToken cancellationToken = default)
        {
            using var httpClient = HttpClientFactory.CreateClient();

            return await httpClient.GetFromJsonAsync<SolanaJupiterV6GetPriceApiResponse>(
                $"{SolanaJupiterConstants.BaseUrlApiPrice}/price?ids={string.Join(',', request.Ids)}&vsToken={request.VsToken}",
                cancellationToken);
        }
    }
}
