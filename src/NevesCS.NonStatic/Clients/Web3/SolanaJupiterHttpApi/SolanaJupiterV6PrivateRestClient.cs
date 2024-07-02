using NevesCS.Abstractions.Clients.Web3.Solana.Exceptions;
using NevesCS.Abstractions.Clients.Web3.Solana.Models;
using NevesCS.Abstractions.Clients.Web3.SolanaJupiterHttpApi;
using NevesCS.Abstractions.Clients.Web3.SolanaJupiterHttpApi.Exceptions;
using NevesCS.Abstractions.Clients.Web3.SolanaJupiterHttpApi.Models;
using NevesCS.Abstractions.Services;
using NevesCS.NonStatic.Clients.Web3.SolanaJupiterHttpApi.Abstractions;
using NevesCS.Static.Utils.Web3.Solana;

using Solnet.Rpc;
using Solnet.Wallet;

using System.Net.Http.Json;

namespace NevesCS.NonStatic.Clients.Web3.SolanaJupiterHttpApi
{
    /// <summary>
    /// Docs: <see href="https://station.jup.ag/docs/apis/swap-api"/>
    ///
    /// </summary>
    public sealed class SolanaJupiterV6PrivateRestClient : ISolanaJupiterV6PrivateClient, ISolanaJupiterV6PrivateRpcClient
    {
        private readonly Wallet Wallet;

        private readonly IJsonParser JsonParser;

        private readonly IHttpClientFactory HttpClientFactory;

        private readonly Cluster RpcClusterType;

        public SolanaJupiterV6PrivateRestClient(
            Wallet wallet,
            IHttpClientFactory httpClientFactory,
            Cluster rpcClusterType,
            IJsonParser jsonParser)
        {
            Wallet = wallet;
            JsonParser = jsonParser;
            HttpClientFactory = httpClientFactory;
            RpcClusterType = rpcClusterType;
        }

        /// <summary>
        /// Performs a trade swap through the Jupiter aggregator. <br/>
        /// <see href="https://station.jup.ag/docs/apis/swap-api"/> <br/>
        /// <see href="https://jup.ag/swap"/>
        ///
        /// </summary>
        /// <exception cref="ArgumentOutOfRangeException"></exception>
        /// <exception cref="SolanaJupiterApiHttpException"></exception>
        /// <exception cref="SolanaRpcException"></exception>
        public async Task<SolanaJupiterV6SwapTransactionResponse?> SwapAsync(
            SolanaJupiterV6SwapRequest request,
            CancellationToken cancellationToken = default)
        {
            if (request.Amount <= 0)
            {
                throw new ArgumentOutOfRangeException(nameof(request));
            }

            // TODO: Stop receiving a factory and let the client handle their own concurrency issues.
            using var httpClient = HttpClientFactory.CreateClient();

            // - https://learn.microsoft.com/en-us/aspnet/core/performance/objectpool
            // - https://stackoverflow.com/questions/75605876/how-to-create-an-objectpool-in-net-6-for-a-custom-parameterless-class
            var rpcClient = CreateNewRpcClient(httpClient);

            var quoteResponse = await GetQuoteAsync(request, httpClient, rpcClient, cancellationToken);

            var tx = await GetSwapTransactionAsync(quoteResponse.Value, httpClient, cancellationToken);

            var simulation = await rpcClient.SimulateTransactionAsync(
               transaction: tx,
               replaceRecentBlockhash: true);

            if (!simulation.WasSuccessful || simulation.ErrorData != null || simulation.Result.Value.Error != null)
            {
                throw new SolanaRpcException(JsonParser.SerializeObject(simulation));
            }

            var txResponse = (await rpcClient.SendTransactionAsync(tx));

            if (!txResponse.WasSuccessful || txResponse.ErrorData != null)
            {
                throw new SolanaRpcException(JsonParser.SerializeObject(simulation));
            }

            return new SolanaJupiterV6SwapTransactionResponse()
            {
                TxId = txResponse.Result,
            };
        }

        public async Task<SolanaJupiterV6QuoteApiResponse?> GetQuoteAsync(SolanaJupiterV6SwapRequest request, CancellationToken cancellationToken = default)
        {
            var httpClient = HttpClientFactory.CreateClient();

            return await GetQuoteAsync(request, httpClient, CreateNewRpcClient(httpClient), cancellationToken);
        }

        /// <summary>
        /// Gets the Jupiter aggragator quote and route needed to perform the trade swap.
        ///
        /// </summary>
        /// <exception cref="SolanaRpcException"></exception>
        public async Task<SolanaJupiterV6QuoteApiResponse?> GetQuoteAsync(
            SolanaJupiterV6SwapRequest request,
            HttpClient httpClient,
            IRpcClient rpcClient,
            CancellationToken cancellationToken = default)
        {
            var tokenIn = request.OrderType == JupiterOrderType.Buy
                ? request.QuoteAssetAddress
                : request.BaseAssetAddress;

            var tokenOut = request.OrderType == JupiterOrderType.Buy
                ? request.BaseAssetAddress
                : request.QuoteAssetAddress;

            var tokenInDecimalCountRes = await rpcClient.GetTokenAccountInfoAsync(tokenIn);

            if (!tokenInDecimalCountRes.WasSuccessful || tokenInDecimalCountRes.ErrorData != null)
            {
                throw new SolanaRpcException(JsonParser.SerializeObject(tokenInDecimalCountRes));
            }

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

            return await SolanaJupiterHttpApiUtils.TryGetOrThrowAsync<SolanaJupiterV6QuoteApiResponse>(
                httpClient,
                $"{SolanaJupiterConstants.BaseUrlApiQuote}/quote"
                + $"?inputMint={tokenIn}&outputMint={tokenOut}"
                + $"&amount={amountIn}"
                + $"&slippageBps={splippageBps}",
                cancellationToken);
        }

        public async Task<byte[]> GetSwapTransactionAsync(SolanaJupiterV6QuoteApiResponse quoteResponse, CancellationToken cancellationToken = default)
        {
            return await GetSwapTransactionAsync(quoteResponse, HttpClientFactory.CreateClient(), cancellationToken);
        }

        /// <summary>
        /// Gets the raw swap transaction to send to the Solana RPC client.
        ///
        /// </summary>
        /// <exception cref="SolanaJupiterApiHttpException"></exception>
        public async Task<byte[]> GetSwapTransactionAsync(
            SolanaJupiterV6QuoteApiResponse quoteResponse,
            HttpClient httpClient,
            CancellationToken cancellationToken = default)
        {
            var swapTxResponse = await httpClient.PostAsJsonAsync(
                $"{SolanaJupiterConstants.BaseUrlApiQuote}/swap",
                new SolanaJupiterV6SwapApiRequest()
                {
                    QuoteResponse = quoteResponse,
                    UserPublicKey = Wallet.Account.PublicKey.ToString(),
                },
                cancellationToken);

            if (!swapTxResponse.IsSuccessStatusCode)
            {
                throw new SolanaJupiterApiHttpException(
                    swapTxResponse,
                    await swapTxResponse?.RequestMessage?.Content?.ReadAsStringAsync());
            }

            var swapTransactionStr = JsonParser
                .DeserializeStream<SolanaJupiterV6SwapApiResponse>(
                    await swapTxResponse.Content.ReadAsStreamAsync(cancellationToken))
                .SwapTransaction;

            return SolanaTransactionUtils.SignRawTransaction(swapTransactionStr, Wallet);
        }

        private IRpcClient CreateNewRpcClient(HttpClient httpClient)
        {
            return ClientFactory.GetClient(cluster: RpcClusterType, httpClient: httpClient);
        }
    }
}
