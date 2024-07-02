using System.Diagnostics.CodeAnalysis;

namespace NevesCS.Abstractions.Clients.Web3.SolanaJupiterHttpApi.Models
{
    [ExcludeFromCodeCoverage]
    public readonly record struct SolanaJupiterV6GetPriceRequest
    {
        public required IEnumerable<string> Ids { get; init; }

        public required string VsToken { get; init; }
    }
}
