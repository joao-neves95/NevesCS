
namespace NevesCS.AspNetCore.Interfaces
{
    /// <summary>
    /// A wrapper to perform Json operations.
    ///
    /// </summary>
    public interface IJsonClientAdapter
    {
        public TResult? DeserializeStream<TResult>(Stream jsonStream);
    }
}
