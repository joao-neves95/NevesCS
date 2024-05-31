namespace NevesCS.Abstractions.Interfaces
{
    public interface IServiceFactory<out TService>
    {
        public TService Create();
    }
}
