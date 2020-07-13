using System;
using System.IO;
using System.Security.Cryptography;
using System.Text;
using Falcon.App.Core.Application.Attributes;

namespace Falcon.App.Core.Application.Impl
{
    [DefaultImplementation(Interface = typeof(IEncrypter))]
    public class EncryptionHelper : IEncrypter
    {
        private const string CODED_PHRASE = "Pas5pr@se";
        private const string SALT_VALUE = "s@1tValue";
        private const string HASH_ALGORITHM = "SHA1";
        private const int    PASSWORD_ITERATIONS = 2;
        private const string INIT_VECTOR = "@1B2c3D4e5F6g7H8";
        private const int    KEY_SIZE = 256;

        public string GetCypherText(string mmId, string campaignId, string affiliateId)
        {
            return Encrypt("mid=" + mmId + "//CId=" + campaignId + "//aId=" + affiliateId);
        }

        public string Encrypt(string plainText)
        {
            byte[] initVectorBytes = Encoding.ASCII.GetBytes(INIT_VECTOR);
            byte[] saltValueBytes = Encoding.ASCII.GetBytes(SALT_VALUE);

            byte[] plainTextBytes = Encoding.UTF8.GetBytes(plainText);

            var password = new PasswordDeriveBytes(CODED_PHRASE, saltValueBytes, HASH_ALGORITHM, PASSWORD_ITERATIONS);
            byte[] keyBytes = password.GetBytes(KEY_SIZE / 8);

            var symmetricKey = new RijndaelManaged { Mode = CipherMode.CBC };

            ICryptoTransform encryptor = symmetricKey.CreateEncryptor(keyBytes, initVectorBytes);

            var memoryStream = new MemoryStream();

            var cryptoStream = new CryptoStream(memoryStream, encryptor, CryptoStreamMode.Write);
            cryptoStream.Write(plainTextBytes, 0, plainTextBytes.Length);

            cryptoStream.FlushFinalBlock();

            byte[] cipherTextBytes = memoryStream.ToArray();

            memoryStream.Close();
            cryptoStream.Close();

            string cipherText = Convert.ToBase64String(cipherTextBytes);

            return cipherText;
        }


        public string Decrypt(string cipherText)
        {
            try
            {
                byte[] initVectorBytes = Encoding.ASCII.GetBytes(INIT_VECTOR);
                byte[] saltValueBytes = Encoding.ASCII.GetBytes(SALT_VALUE);

                byte[] cipherTextBytes = Convert.FromBase64String(cipherText);

                var password = new PasswordDeriveBytes(CODED_PHRASE, saltValueBytes, HASH_ALGORITHM, PASSWORD_ITERATIONS);

                byte[] keyBytes = password.GetBytes(KEY_SIZE / 8);

                var symmetricKey = new RijndaelManaged { Mode = CipherMode.CBC };

                ICryptoTransform decryptor = symmetricKey.CreateDecryptor(keyBytes, initVectorBytes);

                var memoryStream = new MemoryStream(cipherTextBytes);

                var cryptoStream = new CryptoStream(memoryStream, decryptor, CryptoStreamMode.Read);

                var plainTextBytes = new byte[cipherTextBytes.Length];

                int decryptedByteCount = cryptoStream.Read(plainTextBytes, 0, plainTextBytes.Length);

                memoryStream.Close();
                cryptoStream.Close();

                string plainText = Encoding.UTF8.GetString(plainTextBytes, 0, decryptedByteCount);

                return plainText;
            }
            catch
            {
                return string.Empty;
            }
        }

    }
}
