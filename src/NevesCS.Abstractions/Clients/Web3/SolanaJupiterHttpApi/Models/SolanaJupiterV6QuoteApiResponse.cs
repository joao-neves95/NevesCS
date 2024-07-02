using System.Diagnostics.CodeAnalysis;
using System.Text.Json.Serialization;

namespace NevesCS.Abstractions.Clients.Web3.SolanaJupiterHttpApi.Models
{
    [ExcludeFromCodeCoverage]
    public readonly record struct SolanaJupiterV6QuoteApiResponse
    {
        [JsonPropertyName("inputMint")]
        public string InputMint { get; init; }

        [JsonPropertyName("inAmount")]
        public string InAmount { get; init; }

        [JsonPropertyName("outputMint")]
        public string OutputMint { get; init; }

        [JsonPropertyName("outAmount")]
        public string OutAmount { get; init; }

        [JsonPropertyName("otherAmountThreshold")]
        public string OtherAmountThreshold { get; init; }

        [JsonPropertyName("swapMode")]
        public string SwapMode { get; init; }

        [JsonPropertyName("slippageBps")]
        public int SlippageBps { get; init; }

        [JsonPropertyName("computedAutoSlippage")]
        public double? ComputedAutoSlippage { get; init; }

        [JsonPropertyName("platformFee")]
        public PlatformFee? PlatformFee { get; init; }

        [JsonPropertyName("priceImpactPct")]
        public string PriceImpactPct { get; init; }

        [JsonPropertyName("contextSlot")]
        public int? ContextSlot { get; init; }

        [JsonPropertyName("timeTaken")]
        public decimal TimeTaken { get; init; }

        [JsonPropertyName("routePlan")]
        public List<RoutePlanStep> RoutePlan { get; init; }
    }

    public readonly record struct PlatformFee
    {
        [JsonPropertyName("amount")]
        public string? Amount { get; init; }

        [JsonPropertyName("feeBps")]
        public int FeeBps { get; init; }
    }

    public readonly record struct RoutePlanStep
    {
        [JsonPropertyName("swapInfo")]
        public SwapInfo SwapInfo { get; init; }

        [JsonPropertyName("percent")]
        public int Percent { get; init; }
    }

    public readonly record struct SwapInfo
    {
        [JsonPropertyName("ammKey")]
        public string AmmKey { get; init; }

        [JsonPropertyName("label")]
        public string? Label { get; init; }

        [JsonPropertyName("inputMint")]
        public string InputMint { get; init; }

        [JsonPropertyName("outputMint")]
        public string OutputMint { get; init; }

        [JsonPropertyName("inAmount")]
        public string InAmount { get; init; }

        [JsonPropertyName("outAmount")]
        public string OutAmount { get; init; }

        [JsonPropertyName("feeAmount")]
        public string FeeAmount { get; init; }

        [JsonPropertyName("feeMint")]
        public string FeeMint { get; init; }
    }
}
