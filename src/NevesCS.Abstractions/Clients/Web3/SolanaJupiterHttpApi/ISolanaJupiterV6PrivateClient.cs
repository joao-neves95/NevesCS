using NevesCS.Abstractions.Clients.Web3.SolanaJupiterHttpApi.Models;

namespace NevesCS.Abstractions.Clients.Web3.SolanaJupiterHttpApi
{
    public interface ISolanaJupiterV6PrivateClient
    {
        public Task<SolanaJupiterV6SwapTransactionResponse?> SwapAsync(
            SolanaJupiterV6SwapRequest request,
            CancellationToken cancellationToken = default);

        public Task<SolanaJupiterV6QuoteApiResponse?> GetQuoteAsync(
            SolanaJupiterV6SwapRequest request,
            CancellationToken cancellationToken = default);

        public Task<byte[]> GetSwapTransactionAsync(
            SolanaJupiterV6QuoteApiResponse quoteResponse,
            CancellationToken cancellationToken = default);
    }
}
