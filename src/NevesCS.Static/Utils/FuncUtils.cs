namespace NevesCS.Static.Utils
{
    public static class FuncUtils
    {
        /// <summary>
        /// Enumerates the result of <paramref name="sourceFactory"/> times the number defined by <paramref name="repeatTimes"/>.
        ///
        /// </summary>
        public static IEnumerable<T> Enumerate<T>(Func<T> sourceFactory, int repeatTimes = 0)
        {
            for (int i = 1; i <= repeatTimes; ++i)
            {
                yield return sourceFactory();
            }
        }

        public static TResult TryCatch<TResult>(Func<TResult> tryFunc, Func<Exception, TResult> unsafeCatchFunc)
        {
            try
            {
                return tryFunc();
            }
            catch (Exception ex)
            {
                return unsafeCatchFunc(ex);
            }
        }

        public static async Task<TResult> TryCatchAsync<TResult>(Func<Task<TResult>> asyncTryFunc, Func<Exception, Task<TResult>> unsafeAsyncCatchFunc)
        {
            try
            {
                return await asyncTryFunc();
            }
            catch (Exception ex)
            {
                return await unsafeAsyncCatchFunc(ex);
            }
        }
    }
}
