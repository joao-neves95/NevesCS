using NevesCS.Abstractions.Clients;
using NevesCS.NonStatic.Clients.Web3.SolanaJupiterHttpApi.Models;

namespace NevesCS.NonStatic.Clients.Web3.SolanaJupiterHttpApi
{
    public sealed class SolanaJupiterV6PublicRestClientFactory
        : IRequestProviderFactory<SolanaJupiterV6GetPriceRequest, SolanaJupiterV6GetPriceApiResponse>
    {
        public IRequestProvider<SolanaJupiterV6GetPriceRequest, SolanaJupiterV6GetPriceApiResponse> Create()
        {
            return CreateNew();
        }

        public static IRequestProvider<SolanaJupiterV6GetPriceRequest, SolanaJupiterV6GetPriceApiResponse>
            CreateNew()
        {
            return new SolanaJupiterV6PublicRestClient();
        }
    }
}
