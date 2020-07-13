using System;
using System.Diagnostics;
using System.Security.Cryptography;
using System.Text;

namespace Falcon.App.Core.Application.Impl
{
    public static class Rijndael
    {
        //todo: drive secret key from config or some file [discussion]
        private const string Secret = "ˠˠˤ̡ʤʥʨʧʯʭʬͶͷζЉЊϹϸϸ³ÂÖÙîæíÊó¶djD̆ЊЋЌЖẂệՃև₧₯₡₹₱┐ ﬕﬗỮбб";

        private static RijndaelManaged GetRijndaelManaged(string secretKey)
        {
            var keyBytes = new byte[16];
            var secretKeyBytes = Encoding.UTF8.GetBytes(secretKey);
            Array.Copy(secretKeyBytes, keyBytes, Math.Min(keyBytes.Length, secretKeyBytes.Length));
            return new RijndaelManaged
            {
                Mode = CipherMode.CBC,
                Padding = PaddingMode.PKCS7,
                KeySize = 128,
                BlockSize = 128,
                Key = keyBytes,
                IV = keyBytes
            };
        }

        static byte[] Encrypt(byte[] plainBytes, RijndaelManaged rijndaelManaged)
        {
            return rijndaelManaged.CreateEncryptor()
                .TransformFinalBlock(plainBytes, 0, plainBytes.Length);
        }
        static byte[] Decrypt(byte[] encryptedData, RijndaelManaged rijndaelManaged)
        {
            return rijndaelManaged.CreateDecryptor()
                .TransformFinalBlock(encryptedData, 0, encryptedData.Length);
        }

        public static String Encrypt(this String plainText)
        {
            var plainBytes = Encoding.UTF8.GetBytes(plainText);
            return Convert.ToBase64String(Encrypt(plainBytes, GetRijndaelManaged(Secret)));
        }

        [DebuggerStepThrough]
        public static String Decrypt(this String encryptedText)
        {
            var encryptedBytes = Convert.FromBase64String(encryptedText);
            var decrypt = Decrypt(encryptedBytes, GetRijndaelManaged(Secret));
            return Encoding.UTF8.GetString(decrypt);
        }
    }
}