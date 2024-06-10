using NevesCS.Abstractions.Interfaces;

namespace NevesCS.Abstractions.Clients
{
    public interface IRequestProviderFactory<TRequest, TResponse>
        : IServiceFactory<IRequestProvider<TRequest, TResponse>>;
}
