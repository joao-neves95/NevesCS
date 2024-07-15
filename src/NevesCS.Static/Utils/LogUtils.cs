using System.Reflection;

namespace NevesCS.Static.Utils
{
    public static class LogUtils
    {
        /// <summary>
        /// "[Class.ctor()]"
        ///
        /// </summary>
        public static string BuildConstructorNameLogHeader(string className)
        {
            return $"[{className}.ctor()]";
        }

        /// <summary>
        /// "[Class.Method()]"
        ///
        /// </summary>
        public static string BuildMethodNameLogHeader(MethodInfo methodInfo)
        {
            return BuildMethodNameLogHeader(methodInfo.DeclaringType?.Name ?? string.Empty, methodInfo.Name);
        }

        /// <summary>
        /// "[Class.Method()]"
        ///
        /// </summary>
        public static string BuildMethodNameLogHeader(string className, string methodName)
        {
            return $"[{className}.{methodName}()]";
        }
    }
}
