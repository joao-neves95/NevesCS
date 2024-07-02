using System.Diagnostics.CodeAnalysis;

namespace NevesCS.Abstractions.Clients.Web3.SolanaJupiterHttpApi.Models
{
    [ExcludeFromCodeCoverage]
    public readonly record struct SolanaJupiterV6SwapRequest
    {
        public required readonly string BaseAssetAddress { get; init; }

        public required readonly string QuoteAssetAddress { get; init; }

        public required readonly JupiterOrderType OrderType { get; init; }

        /// <summary>
        /// Amount of input token.
        ///
        /// </summary>
        public required readonly decimal Amount { get; init; }

        /// <summary>
        /// E.g. 0.5%, 1%, etc.
        ///
        /// </summary>
        public required readonly float SlippagePercentage { get; init; }
    }

    public enum JupiterOrderType
    {
        Buy,
        Sell
    }
}
