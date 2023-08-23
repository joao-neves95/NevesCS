using System.Reflection;

namespace NevesCS.Static.Extensions
{
    public static class ObjectExtensions
    {
        public static T ThrowIfNull<T>(this T? @object)
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
        public static bool HasProperty(
            this object target,
            string propertyName)
        {
            return target
                .GetType()
                .GetProperty(propertyName, BindingFlags.Public | BindingFlags.Instance)
                != null;
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
        public static void SetPropertyDynamically(this object target, string propertyPath, object value)
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
