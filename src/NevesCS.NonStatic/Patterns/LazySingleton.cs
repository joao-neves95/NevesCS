namespace NevesCS.NonStatic.Patterns
{
    // Source: https://csharpindepth.com/articles/Singleton
    public abstract class LazySingleton<T>
        where T : new()
    {
        private static readonly Lazy<T> lazy = new(() => new T());

        public static T Instance { get { return lazy.Value; } }

        protected LazySingleton()
        {
        }
    }
}
