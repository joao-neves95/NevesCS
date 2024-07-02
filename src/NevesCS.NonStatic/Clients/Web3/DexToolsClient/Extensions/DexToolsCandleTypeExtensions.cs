using NevesCS.Abstractions.Clients.Web3.DexTools.Models;
using NevesCS.Static.Utils;

namespace NevesCS.NonStatic.Clients.Web3.DexToolsClient.Extensions
{
    internal static class DexToolsCandleTypeExtensions
    {
        public static string GetTimeSpanSize(this DexToolsV1CandleType candleSize)
        {
            return EnumUtils.GetDescription(candleSize switch
            {
                (<= DexToolsV1CandleType.m5)
                    => DexToolsV1TimeSpanSize.DAY,
                (> DexToolsV1CandleType.m5 and < DexToolsV1CandleType.h1)
                    => DexToolsV1TimeSpanSize.WEEK,
                (>= DexToolsV1CandleType.h1)
                    => DexToolsV1TimeSpanSize.MONTH
            });
        }

        public static uint GetTotalNumberOfCandles(this DexToolsV1CandleType candleSize)
        {
            return candleSize switch
            {
                DexToolsV1CandleType.m1 => 1000,
                DexToolsV1CandleType.m3 => 900,
                DexToolsV1CandleType.m5 => 800,
                DexToolsV1CandleType.m15 => 650,
                DexToolsV1CandleType.m30 => 450,
                DexToolsV1CandleType.h1 => 350,
                DexToolsV1CandleType.h2 => 325,
                DexToolsV1CandleType.h4 => 300,
                DexToolsV1CandleType.h12 => 250,
                DexToolsV1CandleType.d1 => 100,

                _ => throw new NotImplementedException()
            };
        }
    }
}
