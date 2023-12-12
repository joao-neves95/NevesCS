using NevesCS.Static.Utils;

namespace NevesCS.Static.Extensions
{
    public static class BinaryExtensions
    {
        /// <summary>
        /// Serializes primitive type properties of an object.
        ///
        /// </summary>
        public static byte[] SerializeObjectIntoRawBytes<T>(this T target)
        {
            return BinaryUtils.SerializeObject(target);
        }

        /// <summary>
        /// Deserializes primitive type properties of a previously serialized object.
        ///
        /// </summary>
        public static T? DeserializeRawByteObject<T>(this byte[] serializedData)
            where T : class, new()
        {
            return BinaryUtils.DeserializeByteObject<T>(serializedData);
        }
    }
}
