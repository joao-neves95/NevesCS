using NevesCS.Abstractions.Clients.Web3.SolanaJupiterHttpApi.Models;

using Solnet.Rpc;

namespace NevesCS.NonStatic.Clients.Web3.SolanaJupiterHttpApi.Abstractions
{
    internal interface ISolanaJupiterV6PrivateRpcClient
    {
        public Task<SolanaJupiterV6QuoteApiResponse?> GetQuoteAsync(
            SolanaJupiterV6SwapRequest request,
            HttpClient httpClient,
            IRpcClient rpcClient,
            CancellationToken cancellationToken = default);

        public Task<byte[]> GetSwapTransactionAsync(
            SolanaJupiterV6QuoteApiResponse quoteResponse,
            HttpClient httpClient,
            CancellationToken cancellationToken = default);
    }
}
