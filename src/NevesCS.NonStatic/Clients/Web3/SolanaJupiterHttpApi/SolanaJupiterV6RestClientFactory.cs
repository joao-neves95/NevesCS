using NevesCS.Abstractions.Clients;
using NevesCS.NonStatic.Clients.Web3.SolanaJupiterHttpApi.Models;

namespace NevesCS.NonStatic.Clients.Web3.SolanaJupiterHttpApi
{
    public sealed class SolanaJupiterV6RestClientFactory
        : IPriceDataRequestProviderFactory<SolanaJupiterV6GetPriceRequest, SolanaJupiterV6GetPriceResponse>
    {
        public IPriceDataRequestProvider<SolanaJupiterV6GetPriceRequest, SolanaJupiterV6GetPriceResponse> Create()
        {
            return CreateNew();
        }

        public static IPriceDataRequestProvider<SolanaJupiterV6GetPriceRequest, SolanaJupiterV6GetPriceResponse>
            CreateNew()
        {
            return new SolanaJupiterV6RestClient();
        }
    }
}
