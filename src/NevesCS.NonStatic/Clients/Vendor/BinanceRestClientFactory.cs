using Binance.Net.Clients;
using CryptoExchange.Net.Authentication;

using NevesCS.Abstractions.Interfaces;
using NevesCS.NonStatic.Clients.Models;
using NevesCS.Static.Utils;

namespace NevesCS.NonStatic.Clients;

public class BinanceRestClientFactory : IServiceFactory<BinanceRestClient>
{
    private readonly BinanceRestClientFactoryOptions Options;

    public BinanceRestClientFactory(BinanceRestClientFactoryOptions options)
    {
        Options = ObjectUtils.AssertNotNull(options, nameof(options));
    }

    public BinanceRestClient Create()
    {
        return new BinanceRestClient(
            o => o.ApiCredentials = new ApiCredentials(Options.ApiKey, Options.ApiSecret));
    }
}
