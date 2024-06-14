namespace NevesCS.Abstractions.Clients
{
    public interface IRequestProvider<TRequest, TResponse>
    {
        public Task<TResponse?> RequestAsync(
            TRequest request,
            CancellationToken cancellationToken = default);
    }
}
