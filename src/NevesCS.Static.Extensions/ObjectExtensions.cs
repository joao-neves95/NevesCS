using NevesCS.Static.Utils;

namespace NevesCS.Static.Extensions
{
    public static class ObjectExtensions
    {
        public static T ThrowIfNull<T>(this T? @object)
        {
            return ObjectUtils.ThrowIfNull(@object);
        }

        public static bool In<TIn>(this TIn? @object, IEnumerable<TIn> target)
        {
            return target.Contains(@object);
        }

        /// <summary>
        /// Return true if the <paramref name="target"/> has the requested property.
        ///
        /// </summary>
        public static bool HasProperty(this object target, string propertyName)
        {
            return ObjectUtils.HasProperty(target, propertyName);
        }

        /// <summary>
        /// <code>
        /// myClassInstance.SetPropertyDynamically(
        ///     nameof(MyClass.WithThisProperty),
        ///     someValueToAdd);
        /// </code>
        /// <code>
        /// myClassInstance.SetPropertyDynamically(
        ///     "ThisProperty.WithThisSubProperty"
        ///     someValueToAdd);
        /// </code>
        /// </summary>
        public static object SetPropertyDynamically(this object target, string propertyPath, object value)
        {
            return ObjectUtils.SetPropertyDynamically(target, propertyPath, value);
        }

        /// <summary>
        /// E.g.:
        /// <code>
        /// myClassInstance.CallMethodOfPropertyDynamically(
        ///     nameof(MyClass.WithThisListProperty),
        ///     nameof(MyClass.WithThisListProperty.AddRange),
        ///     someListOfValuesToAdd);
        /// </code>
        /// </summary>
        public static void CallMethodOfPropertyDynamically(
            this object target,
            string propertyName,
            string methodName,
            object value)
        {
            ObjectUtils.CallMethodOfPropertyDynamically(target, propertyName, methodName, value);
        }
    }
}
