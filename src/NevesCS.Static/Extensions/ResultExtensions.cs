using CSharpFunctionalExtensions;

namespace NevesCS.Static.Extensions
{
    public static class ResultExtensions
    {
        public static Result<TOut> TryCatchToResult<TOut>(Func<TOut> tryAction)
        {
            try
            {
                return tryAction();
            }
            catch (Exception ex)
            {
                return Result.Failure<TOut>(ex.Serialize());
            }
        }
    }
}
