using NevesCS.Abstractions.Interfaces;

namespace NevesCS.Abstractions.Clients
{
    public interface IPriceDataRequestProviderFactory<TRequest, TResponse>
        : IServiceFactory<IPriceDataRequestProvider<TRequest, TResponse>>;
}
