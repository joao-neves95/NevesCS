using System.Security.Cryptography;
using System.Text;

namespace NevesCS.Static.Utils
{
    public static class GuidUtils
    {
        public static bool IsNullOrEmpty(Guid? guid)
        {
            return guid == null || guid == Guid.Empty;
        }

        /// <summary>
        /// Creates a new <see cref="Guid"/> by computing the <see cref="MD5"/> hash of a <see cref="string"/>.
        ///
        /// </summary>
        public static Guid HashStringIntoGuid(string name)
        {
            var hashBytes = MD5.HashData(Encoding.UTF8.GetBytes(name));

            return new Guid(hashBytes);
        }

#if NET7_0_OR_GREATER

        /// <summary>
        /// Creates a new <see cref="Guid"/> by computing the <see cref="MD5"/> hash of a <see cref="string"/>.
        ///
        /// </summary>
        public static async Task<Guid> HashStringIntoGuidAsync(string name, CancellationToken cancellationToken = default)
        {
            using var byteStream = new MemoryStream(Encoding.UTF8.GetBytes(name));
            var hashBytes = await MD5.HashDataAsync(byteStream, cancellationToken);

            return new Guid(hashBytes);
        }

#endif
    }
}
