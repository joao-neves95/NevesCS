using NevesCS.Abstractions.Clients.Web3.SolanaJupiterHttpApi.Models;

namespace NevesCS.Abstractions.Clients.Web3.SolanaJupiterHttpApi
{
    public interface ISolanaJupiterV6PublicClient
    {
        public Task<SolanaJupiterV6GetPriceApiResponse?> GetCurrentPriceAsync(
            SolanaJupiterV6GetPriceRequest request,
            CancellationToken cancellationToken = default);
    }
}
