namespace NevesCS.Abstractions.Clients
{
    public interface IPriceDataRequestProvider<TRequest, TResponse>
    {
        public Task<TResponse?> GetPriceAsync(
            TRequest request,
            CancellationToken cancellationToken = default);
    }
}
