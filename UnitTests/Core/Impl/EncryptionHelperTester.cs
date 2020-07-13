using System.Diagnostics;
using Falcon.App.Core.Application.Impl;
using NUnit.Framework;

namespace HealthYes.Web.UnitTests.Core.Impl
{
    [TestFixture]
    public class EncryptionHelperTester
    {
        [Test]
        public void DecryptingAndEncryptingStringReturnsSameString()
        {
            const string toEncrypt = "four score and twenty years ago";
            var encryptionHelper = new EncryptionHelper();            

            string encrypted = encryptionHelper.Encrypt(toEncrypt);
            string decrypted = encryptionHelper.Decrypt(encrypted);

            Assert.AreEqual(toEncrypt, decrypted);
        }
        
        [Test]
        public void DecryptTest()
        {
            var encryptionHelper = new EncryptionHelper();
            Debug.Print(encryptionHelper.Decrypt("GrzntE8BM9PrR7OSgyMiUdqW49ZAcZPJPhoNJCJvEI8="));
        }
    }
}
