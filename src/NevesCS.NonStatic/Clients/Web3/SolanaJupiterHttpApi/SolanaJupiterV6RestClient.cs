using NevesCS.Abstractions.Clients.Web3;
using NevesCS.NonStatic.Clients.Web3.SolanaJupiterHttpApi.Models;

using RestSharp;

namespace NevesCS.NonStatic.Clients.Web3.SolanaJupiterHttpApi
{
    public sealed class SolanaJupiterV6RestClient
        : ISolanaJupiterRequestClient<SolanaJupiterV6GetPriceRequest, SolanaJupiterV6GetPriceResponse>,
          IDisposable
    {
        private const string BaseUrl = "https://price.jup.ag/v6/";

        private readonly RestClient RestClient = new(BaseUrl);

        public void Dispose()
        {
            RestClient?.Dispose();
            GC.SuppressFinalize(this);
        }

        /// <summary>
        /// https://price.jup.ag/v6/price?ids=token1,token2&vsToken=quote-token
        /// </summary>
        public async Task<SolanaJupiterV6GetPriceResponse?> GetPrice(
            SolanaJupiterV6GetPriceRequest request,
            CancellationToken cancellationToken = default)
        {
            return await RestClient.GetJsonAsync<SolanaJupiterV6GetPriceResponse>(
                $"price?ids={string.Join(',', request.Ids)}&vsToken={request.VsToken}",
                cancellationToken);
        }
    }
}
