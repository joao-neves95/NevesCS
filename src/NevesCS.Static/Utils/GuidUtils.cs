using System.Security.Cryptography;
using System.Text;

namespace NevesCS.Static.Utils
{
    public static class GuidUtils
    {
        /// <summary>
        /// Creates a new <see cref="Guid"/> by computing the <see cref="MD5"/> hash of a <see cref="string"/>.
        ///
        /// </summary>
        public static Guid StringHashIntoGuid(string name)
        {
            using var hasher = MD5.Create();
            var hashBytes = hasher.ComputeHash(Encoding.UTF8.GetBytes(name));

            return new Guid(hashBytes);
        }
    }
}
