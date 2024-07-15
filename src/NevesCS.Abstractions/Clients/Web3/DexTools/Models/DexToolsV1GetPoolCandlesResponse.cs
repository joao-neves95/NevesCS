using System.Diagnostics.CodeAnalysis;
using System.Text.Json.Serialization;

namespace NevesCS.Abstractions.Clients.Web3.DexTools.Models
{
    [ExcludeFromCodeCoverage]
    public sealed record DexToolsV1GetPoolCandlesResponse
    {
        [JsonPropertyName("statusCode")]
        public int StatusCode { get; set; }
        [JsonPropertyName("data")]
        public DexToolsV1GetPoolCandlesResponseData Data { get; set; }
    }

    [ExcludeFromCodeCoverage]
    public sealed record DexToolsV1GetPoolCandlesResponseData
    {
        [JsonPropertyName("next")]
        public DexToolsV1GetPoolCandlesResponseDataNext Next { get; set; }
        [JsonPropertyName("interval")]
        public DexToolsV1GetPoolCandlesResponseDatainterval interval { get; set; }
        [JsonPropertyName("first")]
        public long First { get; set; }
        [JsonPropertyName("last")]
        public int Last { get; set; }
        [JsonPropertyName("total")]
        public int Total { get; set; }
        [JsonPropertyName("res")]
        public string Res { get; set; }
        [JsonPropertyName("span")]
        public string Span { get; set; }
        [JsonPropertyName("candles")]
        public IList<DexToolsV1GetPoolCandlesResponseDataCandles> Candles { get; set; }
    }

    [ExcludeFromCodeCoverage]
    public sealed record DexToolsV1GetPoolCandlesResponseDataNext
    {
        [JsonPropertyName("ts")]
        public long Ts { get; set; }
        [JsonPropertyName("res")]
        public string Res { get; set; }
    }

    [ExcludeFromCodeCoverage]
    public sealed record DexToolsV1GetPoolCandlesResponseDatainterval
    {
        [JsonPropertyName("from")]
        public long From { get; set; }
        [JsonPropertyName("to")]
        public long To { get; set; }
    }

    // The commented properties is because they cannot be trusted as the dextools API is sending negative values here (some kind of overflow??).
    [ExcludeFromCodeCoverage]
    public sealed record DexToolsV1GetPoolCandlesResponseDataCandles
    {
        [JsonPropertyName("_id")]
        public int Id { get; set; }
        [JsonPropertyName("ts")]
        public long Ts { get; set; }
        //[JsonPropertyName("firstBlock")]
        //public long FirstBlock { get; set; }
        //[JsonPropertyName("firstIndex")]
        //public long FirstIndex { get; set; }
        //[JsonPropertyName("firstTimestamp")]
        public long FirstTimestamp { get; set; }
        //[JsonPropertyName("lastBlock")]
        //public long LastBlock { get; set; }
        //[JsonPropertyName("lastIndex")]
        //public long LastIndex { get; set; }
        [JsonPropertyName("lastTimestamp")]
        public long LastTimestamp { get; set; }
        //[JsonPropertyName("sellsNumber")]
        //public long SellsNumber { get; set; }
        //[JsonPropertyName("sellsVolume")]
        //public decimal SellsVolume { get; set; }
        //[JsonPropertyName("buysNumber")]
        //public int BuysNumber { get; set; }
        //[JsonPropertyName("buysVolume")]
        //public decimal BuysVolume { get; set; }
        [JsonPropertyName("time")]
        public long Time { get; set; }
        [JsonPropertyName("open")]
        public decimal Open { get; set; }
        [JsonPropertyName("close")]
        public decimal Close { get; set; }
        [JsonPropertyName("high")]
        public decimal High { get; set; }
        [JsonPropertyName("low")]
        public decimal Low { get; set; }
        [JsonPropertyName("volume")]
        public decimal Volume { get; set; }
    }
}
