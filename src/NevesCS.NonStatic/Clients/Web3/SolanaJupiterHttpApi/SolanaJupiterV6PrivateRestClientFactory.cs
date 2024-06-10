using Microsoft.Extensions.Logging;

using NevesCS.Abstractions.Clients;
using NevesCS.Abstractions.Services;
using NevesCS.NonStatic.Clients.Web3.SolanaJupiterHttpApi.Models;

using Solnet.Rpc;
using Solnet.Wallet;

namespace NevesCS.NonStatic.Clients.Web3.SolanaJupiterHttpApi
{
    public sealed class SolanaJupiterV6PrivateRestClientFactory
        : IRequestProviderFactory<SolanaJupiterV6SwapRequest, SolanaJupiterV6SwapTransactionResponse>
    {
        private readonly Wallet Wallet;

        private readonly IJsonParser JsonParser;

        private readonly ILogger Logger;

        public SolanaJupiterV6PrivateRestClientFactory(Wallet wallet, IJsonParser jsonParser, ILogger logger)
        {
            Wallet = wallet;
            JsonParser = jsonParser;
            Logger = logger;
        }

        public IRequestProvider<SolanaJupiterV6SwapRequest, SolanaJupiterV6SwapTransactionResponse> Create()
        {
            return new SolanaJupiterV6PrivateRestClient(Wallet, ClientFactory.GetClient(Cluster.MainNet, Logger), JsonParser);
        }
    }
}
