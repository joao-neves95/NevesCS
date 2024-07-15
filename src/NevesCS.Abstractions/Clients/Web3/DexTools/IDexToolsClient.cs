using NevesCS.Abstractions.Clients.Web3.DexTools.Models;

namespace NevesCS.Abstractions.Clients.Web3.DexTools
{
    public interface IDexToolsClient
    {
        public Task<DexToolsV1GetPoolCandlesResponse> GetLatestPoolUsdCandlesAsync(
            DexToolsV1GetLatestPoolCandlesRequest request,
            CancellationToken cancellationToken = default);

        public Task<IList<DexToolsV1GetPoolCandlesResponseDataCandles>> GetPoolUsdCandlesAsync(
            DexToolsV1GetPoolCandlesRequest request,
            CancellationToken cancellationToken = default);
    }
}
