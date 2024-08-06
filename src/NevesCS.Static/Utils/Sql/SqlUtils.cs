using NevesCS.Static.Constants;

namespace NevesCS.Static.Utils.Sql
{
    public static class SqlUtils
    {
        public static bool IsSqlStringLikeType<T>()
        {
            return IsSqlStringLikeType(typeof(T));
        }

        public static bool IsSqlStringLikeType<T>(T value)
        {
            return IsSqlStringLikeType(value?.GetType() ?? typeof(T));
        }

        public static bool IsSqlStringLikeType(Type type)
        {
            return type == TypeOf.String
                || type == TypeOf.DateOnly
                || type == TypeOf.DateTime
                || type == TypeOf.DateTimeOffset;
        }
    }
}
