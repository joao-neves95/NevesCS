using System.Diagnostics.CodeAnalysis;

namespace NevesCS.NonStatic.Clients.Models;

public readonly record struct BinanceRestClientFactoryOptions
{
    [SetsRequiredMembers]
    public BinanceRestClientFactoryOptions(string apiKey, string apiSecret)
    {
        ApiKey = apiKey;
        ApiSecret = apiSecret;
    }

    public required readonly string ApiKey { get; init; }

    public required readonly string ApiSecret { get; init; }
}
