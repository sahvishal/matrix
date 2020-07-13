namespace Falcon.App.Core.Application.Impl
{
    public abstract class CryptographyService
    {
        protected abstract string SecurityKey { get; }
        
        public string Encrypt(string stringToEncrypt)
        {
            return Rijndael.Encrypt(stringToEncrypt);
            //byte[] toEncryptArray = Encoding.UTF8.GetBytes(stringToEncrypt);
            //var cryptoServiceProvider = new MD5CryptoServiceProvider();
            //byte[] keyArray = cryptoServiceProvider.ComputeHash(Encoding.UTF8.GetBytes(SecurityKey));
            //cryptoServiceProvider.Clear();
            //var tripleDesCryptoServiceProvider = new TripleDESCryptoServiceProvider
            //                                          {
            //                                              Key = keyArray,
            //                                              Mode = CipherMode.ECB,
            //                                              Padding = PaddingMode.PKCS7
            //                                          };

            //ICryptoTransform cryptoTransform = tripleDesCryptoServiceProvider.CreateEncryptor();
            //byte[] resultArray = cryptoTransform.TransformFinalBlock(toEncryptArray, 0, toEncryptArray.Length);
            //tripleDesCryptoServiceProvider.Clear();
            //return Convert.ToBase64String(resultArray, 0, resultArray.Length);
        }


        public string Decrypt(string stringToDecrypt)
        {
            try
            {
                return stringToDecrypt.Decrypt();
                //byte[] toEncryptArray = Convert.FromBase64String(stringToDecrypt);

                //var cryptoServiceProvider = new MD5CryptoServiceProvider();
                //byte[] keyArray = cryptoServiceProvider.ComputeHash(Encoding.UTF8.GetBytes(SecurityKey));
                //cryptoServiceProvider.Clear();

                //var tripleDesCryptoServiceProvider = new TripleDESCryptoServiceProvider
                //               {
                //                   Key = keyArray,
                //                   Mode = CipherMode.ECB,
                //                   Padding = PaddingMode.PKCS7
                //               };

                //ICryptoTransform cTransform = tripleDesCryptoServiceProvider.CreateDecryptor();
                //byte[] resultArray = cTransform.TransformFinalBlock(toEncryptArray, 0, toEncryptArray.Length);

                //tripleDesCryptoServiceProvider.Clear();
                //return Encoding.UTF8.GetString(resultArray);
            }
            catch 
            {
                return "Invalid key";
            }
        }
        
    }
}
