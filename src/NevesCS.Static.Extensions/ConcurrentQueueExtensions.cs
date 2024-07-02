using NevesCS.Static.Utils;

using System.Collections.Concurrent;

namespace NevesCS.Static.Extensions
{
    public static class ConcurrentQueueExtensions
    {
        public static IEnumerable<T> DequeueAllNonBlocking<T>(this ConcurrentQueue<T> target)
        {
            return ConcurrentQueueUtils.DequeueAllNonBlocking(target);
        }
    }
}
