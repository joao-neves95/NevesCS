namespace NevesCS.Abstractions.Interfaces
{
    public interface ICachedServiceFactory<out TService>
    {
        public TService Create(string key);
    }
}
