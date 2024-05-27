namespace NevesCS.Abstractions.Clients
{
    public interface IPriceDataRequestProvider<TRequest, TResponse>
    {
        public Task<TResponse?> GetPrice(
            TRequest request,
            CancellationToken cancellationToken = default);
    }
}
