
namespace NevesCS.Static.Utils
{
    public static class TypeUtils
    {
        /// <summary>
        /// Gets a specific Type by name, supporting external assemblies.
        ///
        /// </summary>
        /// <typeparam name="KnownType">A known type inside to the Assembly where the <paramref name="typeName"/> belongs to.</typeparam>
        public static Type GetTypeByNameFromKnownType<KnownType>(string typeName)
        {
            return typeof(KnownType).Assembly.DefinedTypes
                .First(type => type.Name == typeName)
                .AsType();
        }
    }
}
