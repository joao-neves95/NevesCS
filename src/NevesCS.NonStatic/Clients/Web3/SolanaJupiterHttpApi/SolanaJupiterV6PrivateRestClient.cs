using NevesCS.Abstractions.Clients;
using NevesCS.Abstractions.Services;
using NevesCS.NonStatic.Clients.Web3.Solana.Models;
using NevesCS.NonStatic.Clients.Web3.SolanaJupiterHttpApi.Models;

using Solnet.Rpc;
using Solnet.Wallet;

using System.Net.Http.Json;

namespace NevesCS.NonStatic.Clients.Web3.SolanaJupiterHttpApi
{
    public sealed class SolanaJupiterV6PrivateRestClient
        : IRequestProvider<SolanaJupiterV6SwapRequest, SolanaJupiterV6SwapTransactionResponse>
    {
        private readonly HttpClient HttpClient;

        private readonly Wallet Wallet;

        private readonly IRpcClient RpcClient;

        private readonly IJsonParser JsonParser;

        public SolanaJupiterV6PrivateRestClient(Wallet wallet, IRpcClient rpcClient, IJsonParser jsonParser)
        {
            Wallet = wallet;
            RpcClient = rpcClient;
            HttpClient = new HttpClient();
            JsonParser = jsonParser;
        }

        public void Dispose()
        {
            HttpClient?.Dispose();
            GC.SuppressFinalize(this);
        }

        public async Task<SolanaJupiterV6SwapTransactionResponse?> RequestAsync(
            SolanaJupiterV6SwapRequest request,
            CancellationToken cancellationToken = default)
        {
            // https://station.jup.ag/docs/apis/swap-api

            var quoteResponse = await GetQuoteAsync(request, cancellationToken);

            var tx = await GetSwapTransactionAsync(quoteResponse.Value, cancellationToken);

            var simulation = await RpcClient.SimulateTransactionAsync(
               transaction: tx
               //, replaceRecentBlockhash: true
               );

            //var result = await RpcClient.SendTransactionAsync(tx);

            // TODO: Wait until completion or error.

            return new SolanaJupiterV6SwapTransactionResponse()
            {
                Id = "",
            };
        }

        public async Task<SolanaJupiterV6QuoteApiResponse?> GetQuoteAsync(
            SolanaJupiterV6SwapRequest request,
            CancellationToken cancellationToken = default)
        {
            // TODO: Error handling.

            var tokenIn = request.OrderType == JupiterOrderType.Buy
                ? request.QuoteAssetAddress
                : request.BaseAssetAddress;

            var tokenOut = request.OrderType == JupiterOrderType.Buy
                ? request.BaseAssetAddress
                : request.QuoteAssetAddress;

            var tokenInDecimalCountRes = (await RpcClient.GetTokenAccountInfoAsync(tokenIn));
            var tokenInDecimalCount = JsonParser
                .DeserializeObject<RawRpcResponse<TokenAccountInfoResponse>>(tokenInDecimalCountRes.RawRpcResponse)
                .Result.Value.Data.Parsed.Info.Decimals;

            /*
             * "The API takes in amount in integer and you have to factor in the decimals for
             * each token by looking up the decimals for that token".
             * E.g. USDC has 6 decimals, so 1 = 1000000
             */
            var amountIn = (int)(request.Amount * (decimal)(Math.Pow(10, tokenInDecimalCount)));

            /*
             * The slippage % in BPS.
             * If the output token amount exceeds the slippage, then the swap transaction will fail.
             * E.g. Percentage(0.5%) = SlippageBps(50)
             */
            var splippageBps = request.SlippagePercentage * 100;

            var quoteResponse = (await HttpClient.GetFromJsonAsync<SolanaJupiterV6QuoteApiResponse>(
                $"{SolanaJupiterConstants.BaseUrlApiQuote}/quote"
                + $"?inputMint={tokenIn}&outputMint={tokenOut}"
                + $"&amount={amountIn}"
                + $"&slippageBps={splippageBps}",
                cancellationToken));

            return quoteResponse;
        }

        public async Task<byte[]?> GetSwapTransactionAsync(
            SolanaJupiterV6QuoteApiResponse quoteResponse,
            CancellationToken cancellationToken = default)
        {
            // TODO: Error handling.

            var swapTxResponse = await HttpClient.PostAsJsonAsync(
                $"{SolanaJupiterConstants.BaseUrlApiQuote}/swap",
                new SolanaJupiterV6SwapApiRequest()
                {
                    QuoteResponse = quoteResponse,
                    UserPublicKey = Wallet.Account.PublicKey.ToString(),
                },
                cancellationToken);

            var swapTransactionStr = JsonParser
                .DeserializeStream<SolanaJupiterV6SwapApiResponse>(
                    await swapTxResponse.Content.ReadAsStreamAsync(cancellationToken))
                .SwapTransaction;

            var txData = Convert.FromBase64String(swapTransactionStr);
            var txMessage = txData[(1 + 64 * 2)..]; // Advance sig count byte + signature bytes.
            var signature = Wallet.Account.PrivateKey.Sign(txMessage);
            Array.Copy(signature, 0, txData, 1, signature.Length);

            return txData;
        }
    }
}
