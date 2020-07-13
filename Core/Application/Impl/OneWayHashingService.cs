using System;
using System.Security.Cryptography;
using Falcon.App.Core.Application.Attributes;
using Falcon.App.Core.Application.ViewModels;

namespace Falcon.App.Core.Application.Impl
{
    [DefaultImplementation]
    public class OneWayHashingService : IOneWayHashingService 
    {
         
        public const int SALT_BYTES = 24;
        public const int HASH_BYTES = 24;
        public const int PBKDF2_ITERATIONS = 1000;

        /// <summary>
        /// Creates a salted PBKDF2 hash of the text.
        /// </summary>
        /// <param name="text">The text to hash.</param>
        /// <returns>The hash of the text.</returns>
        public SecureHash CreateHash(string text)
        {
            // Generate a random salt
            var csprng = new RNGCryptoServiceProvider();
            var salt = new byte[SALT_BYTES];
            csprng.GetBytes(salt);

            // Hash the password and encode the parameters
            byte[] hash = PBKDF2(text, salt, PBKDF2_ITERATIONS, HASH_BYTES);

            return new SecureHash(Convert.ToBase64String(hash), Convert.ToBase64String(salt));
        }

        /// <summary>
        /// Validates a text given a hash of the correct one.
        /// </summary>
        /// <param name="text">The text to check.</param>
        /// <param name="goodHash">A hash to compare with.</param>
        /// <returns>True if it matches. False otherwise.</returns>
        public bool Validate(string text, SecureHash goodHash)
        {
            // Extract the parameters from the hash

            byte[] salt = Convert.FromBase64String(goodHash.Salt);
            byte[] hash = Convert.FromBase64String(goodHash.HashedText);

            byte[] testHash = PBKDF2(text, salt, PBKDF2_ITERATIONS, hash.Length);
            return SlowEquals(hash, testHash);
        }

        /// <summary>
        /// Compares two byte arrays in length-constant time. This comparison
        /// method is used so that text hashes cannot be extracted from
        /// on-line systems using a timing attack and then attacked off-line.
        /// </summary>
        /// <param name="a">The first byte array.</param>
        /// <param name="b">The second byte array.</param>
        /// <returns>True if both byte arrays are equal. False otherwise.</returns>
        private bool SlowEquals(byte[] a, byte[] b)
        {
            uint diff = (uint)a.Length ^ (uint)b.Length;
            for (int i = 0; i < a.Length && i < b.Length; i++)
                diff |= (uint)(a[i] ^ b[i]);
            return diff == 0;
        }

        /// <summary>
        /// Computes the PBKDF2-SHA1 hash of a text.
        /// </summary>
        /// <param name="text">The text to hash.</param>
        /// <param name="salt">The salt.</param>
        /// <param name="iterations">The PBKDF2 iteration count.</param>
        /// <param name="outputBytes">The length of the hash to generate, in bytes.</param>
        /// <returns>A hash of the text.</returns>
        private byte[] PBKDF2(string text, byte[] salt, int iterations, int outputBytes)
        {
            var pbkdf2 = new Rfc2898DeriveBytes(text, salt) { IterationCount = iterations };
            return pbkdf2.GetBytes(outputBytes);
        }
    }
}
