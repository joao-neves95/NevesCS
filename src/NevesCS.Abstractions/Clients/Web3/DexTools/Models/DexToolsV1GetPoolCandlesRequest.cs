using System.Diagnostics.CodeAnalysis;

namespace NevesCS.Abstractions.Clients.Web3.DexTools.Models
{
    [ExcludeFromCodeCoverage]
    public sealed record DexToolsV1GetPoolCandlesRequest
    {
        public required DexToolsV1ChainType Chain { get; init; }

        /// <summary>
        /// Note that this is for a specific exchange.
        ///
        /// </summary>
        public required string DexPoolAddress { get; init; }

        public required DexToolsV1CandleType CandleSize { get; init; }

        public required DateTimeOffset FromUtcDate { get; init; }

        public bool UseRandomUserAgent { get; init; }
    }
}
