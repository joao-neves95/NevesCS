using System.Reflection;

namespace NevesCS.Static.Utils
{
    public static class ObjectUtils
    {
        public static T ThrowIfNull<T>(T? @object)
        {
            if (@object == null)
            {
                throw new ArgumentNullException(typeof(T).Name);
            }

            return @object;
        }

        /// <summary>
        /// Return true if the <paramref name="target"/> has the requested property.
        ///
        /// </summary>
        public static bool HasProperty(object target, string propertyName)
        {
            return target
                .GetType()
                .GetProperty(propertyName, BindingFlags.Public | BindingFlags.Instance)
                != null;
        }

        /// <summary>
        /// <code>
        /// ObjectUtils.SetPropertyDynamically(
        ///     myClassInstance,
        ///     nameof(MyClass.WithThisProperty),
        ///     someValueToAdd);
        /// </code>
        /// <code>
        /// ObjectUtils.SetPropertyDynamically(
        ///     myClassInstance,
        ///     "ThisProperty.WithThisSubProperty"
        ///     someValueToAdd);
        /// </code>
        /// </summary>
        public static object SetPropertyDynamically(object target, string propertyPath, object value)
        {
            var subPropertyNames = propertyPath.Split('.');

            for (int i = 0; i < subPropertyNames.Length - 1; i++)
            {
                var property = target.GetType().GetProperty(subPropertyNames[i]);
                target = property.GetValue(target) ?? throw new NullReferenceException(subPropertyNames[i]);
            }

            var finalProperty = target
                .GetType()
                .GetProperty(subPropertyNames.Last())
                ?? throw new MissingFieldException(subPropertyNames.Last());

            finalProperty.SetValue(target, value);

            return target;
        }

        /// <summary>
        /// E.g.:
        /// <code>
        /// ObjectUtils.CallMethodOfPropertyDynamically(
        ///     myClassInstance,
        ///     nameof(MyClass.WithThisListProperty),
        ///     nameof(MyClass.WithThisListProperty.AddRange),
        ///     someListOfValuesToAdd);
        /// </code>
        /// </summary>
        public static void CallMethodOfPropertyDynamically(
            object target,
            string propertyName,
            string methodName,
            object value)
        {
            var propertyInfo = target
                .GetType()
                .GetProperty(propertyName, BindingFlags.Public | BindingFlags.Instance)
                ?? throw new MissingFieldException(propertyName);

            var methodInfo = propertyInfo
                .PropertyType
                .GetMethod(methodName, BindingFlags.Public | BindingFlags.Instance)
                ?? throw new MissingMethodException(methodName);

            var targetProperty = propertyInfo.GetValue(target);

            if (!methodInfo.IsStatic && targetProperty == null)
            {
                throw new NullReferenceException(propertyName);
            }

            methodInfo.Invoke(targetProperty, new[] { value });
        }
    }
}
