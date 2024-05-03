namespace NevesCS.NonStatic.Patterns
{
    // Source: https://csharpindepth.com/articles/Singleton
    public abstract class Singleton<T>
        where T : new()
    {
        public static T Instance { get; } = new T();

        // Explicit static constructor to tell C# compiler not to mark type as beforefieldinit.
        // Executes only once per AppDomain, I.e.: thread-safe.
        static Singleton()
        {
        }

        private Singleton()
        {
        }
    }
}
