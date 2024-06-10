namespace NevesCS.Abstractions.Services
{
    /// <summary>
    /// A wrapper to perform JSON operations.
    ///
    /// </summary>
    public interface IJsonParser
    {
        public TResult? DeserializeObject<TResult>(string jsonString);

        public TResult? DeserializeStream<TResult>(Stream jsonStream);

        public string? SerializeObject(object source);
    }
}
