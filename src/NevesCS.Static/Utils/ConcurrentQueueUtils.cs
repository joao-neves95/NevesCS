using System.Collections.Concurrent;

namespace NevesCS.Static.Utils
{
    public static class ConcurrentQueueUtils
    {
        public static IEnumerable<T> DequeueAllNonBlocking<T>(ConcurrentQueue<T> target)
        {
            while (target.TryDequeue(out T? item))
            {
                if (item == null)
                {
                    yield break;
                }

                yield return item;
            }
        }
    }
}
