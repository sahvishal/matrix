using System;
using System.Security.Cryptography;
using System.Text;

namespace Falcon.App.UI.TwoFactor
{
    public static class TimeBasedOneTimePassword
    {
        public static readonly DateTime UNIX_EPOCH = new DateTime(1970, 1, 1, 0, 0, 0, DateTimeKind.Utc);

         
        static TimeBasedOneTimePassword()
        {
             
        }

        public static string GetPassword(string secret)
        {
            return GetPassword(secret, GetCurrentCounter());
        }

        public static string GetPassword(string secret, DateTime epoch, int timeStep)
        {
            long counter = GetCurrentCounter(DateTime.UtcNow, epoch, timeStep);

            return GetPassword(secret, counter);
        }

        public static string GetPassword(string secret, DateTime now, DateTime epoch, int timeStep, int digits)
        {
            long counter = GetCurrentCounter(now, epoch, timeStep);

            return GetPassword(secret, counter, digits);
        }

        private static string GetPassword(string secret, long counter, int digits = 6)
        {
            return GeneratePassword(secret, counter, digits);
        }

        private static long GetCurrentCounter()
        {
            return GetCurrentCounter(DateTime.UtcNow, UNIX_EPOCH, 30);
        }

        private static long GetCurrentCounter(DateTime now, DateTime epoch, int timeStep)
        {
            return (long)(now - epoch).TotalSeconds / timeStep;
        }

        public static bool IsValid(string secret, string password, int checkAdjacentIntervals = 1)
        {
            // Keeping a cache of the secret/password combinations that have been requested allows us to
            // make this a real one time use system. Once a secret/password combination has been tested,
            // it cannot be tested again until after it is no longer valid.
            // See http://tools.ietf.org/html/rfc6238#section-5.2 for more info.
            
            var ss = GetPassword(secret);
            if (password == ss)
                return true;

            for (int i = 1; i <= checkAdjacentIntervals; i++)
            {
                if (password == GetPassword(secret, GetCurrentCounter() - i))
                    return true;

                if (password == GetPassword(secret, GetCurrentCounter() + i))
                    return true;
            }

            return false;
        }

        public static string GeneratePassword(string secret, long iterationNumber, int digits = 6)
        {
            byte[] counter = BitConverter.GetBytes(iterationNumber);

            if (BitConverter.IsLittleEndian)
                Array.Reverse(counter);

            byte[] key = Encoding.ASCII.GetBytes(secret);

            HMACSHA1 hmac = new HMACSHA1(key, true);

            byte[] hash = hmac.ComputeHash(counter);

            int offset = hash[hash.Length - 1] & 0xf;

            // Convert the 4 bytes into an integer, ignoring the sign.
            int binary =
                ((hash[offset] & 0x7f) << 24)
                | (hash[offset + 1] << 16)
                | (hash[offset + 2] << 8)
                | (hash[offset + 3]);

            // Limit the number of digits
            int password = binary % (int)Math.Pow(10, digits);

            // Pad to required digits
            return password.ToString(new string('0', digits));
        }

        public static string GenerateSecret(out string encodedSecret)
        {
            byte[] buffer = new byte[9];
            using (RandomNumberGenerator rng = RNGCryptoServiceProvider.Create())
            {
                rng.GetBytes(buffer);
            }
            var secret = Convert.ToBase64String(buffer).Substring(0, 10).Replace('/', '0').Replace('+', '1');
            encodedSecret = new Base32Encoder().Encode(Encoding.ASCII.GetBytes(secret));
            return secret;
        }

        public static string EncodeSecret(string secret)
        {
            return  new Base32Encoder().Encode(Encoding.ASCII.GetBytes(secret));
        }
    }
}