using System.Diagnostics.CodeAnalysis;

namespace NevesCS.Abstractions.Clients.Web3.SolanaJupiterHttpApi.Models
{
    [ExcludeFromCodeCoverage]
    public record SolanaJupiterV6SwapTransactionResponse
    {
        public required string TxId { get; init; }
    }
}
