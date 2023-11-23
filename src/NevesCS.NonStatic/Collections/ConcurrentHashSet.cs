using NevesCS.Abstractions.Traits;

namespace NevesCS.NonStatic.Collections
{
    public sealed class ConcurrentHashSet<T> : ICountable, IDisposable
    {
        private readonly HashSet<T> InternalHashSet = new();

        private readonly ReaderWriterLockSlim Lock = new(LockRecursionPolicy.SupportsRecursion);

        ~ConcurrentHashSet()
        {
            Dispose(false);
        }

        public int Count()
        {
            return InternalHashSet.Count;
        }

        public bool Contains(T item)
        {
            Lock.EnterReadLock();

            try
            {
                return InternalHashSet.Contains(item);
            }
            catch
            {
                return false;
            }
            finally
            {
                if (Lock.IsReadLockHeld)
                {
                    Lock.ExitReadLock();
                }
            }
        }

        public bool Add(T item)
        {
            Lock.EnterWriteLock();

            try
            {
                return InternalHashSet.Add(item);
            }
            catch
            {
                return false;
            }
            finally
            {
                if (Lock.IsWriteLockHeld)
                {
                    Lock.ExitWriteLock();
                }
            }
        }

        public bool Remove(T item)
        {
            Lock.EnterWriteLock();

            try
            {
                return InternalHashSet.Remove(item);
            }
            catch
            {
                return false;
            }
            finally
            {
                if (Lock.IsWriteLockHeld)
                {
                    Lock.ExitWriteLock();
                }
            }
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        private void Dispose(bool disposing)
        {
            if (disposing)
            {
                Lock?.Dispose();
            }
        }
    }
}
