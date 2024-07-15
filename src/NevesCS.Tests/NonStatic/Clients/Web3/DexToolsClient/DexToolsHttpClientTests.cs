using FluentAssertions;

using NevesCS.Abstractions.Clients.Web3.DexTools.Models;
using NevesCS.NonStatic.Clients.Web3.DexToolsClient;
using NevesCS.NonStatic.Services.ThreadRateLimiters;

namespace NevesCS.Tests.NonStatic.Clients.Web3.DexToolsClient
{
    public class DexToolsHttpClientTests
    {
        private const string SOL_USDC_ORCA_POOL = "EGZ7tiLeH62TPV1gL8WwbXGzEPa9zmcpVnnkPKKnrE2U";

        private readonly DexToolsV1HttpClient sut = new(
            new(),
            new SyncTimeIntervalThreadRateLimiter(TimeSpan.FromMilliseconds(10)));

        //[Fact]
        public async Task GetPoolUsdCandlesAsync_Passes()
        {
            var response = await sut.GetPoolUsdCandlesAsync(
                new DexToolsV1GetPoolCandlesRequest()
                {
                    Chain = DexToolsV1ChainType.SOLANA,
                    DexPoolAddress = SOL_USDC_ORCA_POOL,
                    CandleSize = DexToolsV1CandleType.h1,
                    FromUtcDate = DateTime.UtcNow.AddDays(-60),
                });

            response.Count.Should().BePositive();
        }
    }
}
