using Falcon.App.Core.Application.Impl;
using NUnit.Framework;

namespace Falcon.Web.IntegrationTests.Infrastructure.Application
{
    public class PasswordGenerator
    {
        private PasswordCryptographyService _passwordCryptographyService;

        private const string Password = "^qECf+DLCaNC3C-U";
        private const string CustomerKey = "r97ej48zb25n";

        private const string EncryptedPassword = "3DAN71+ViNqv+lUlOojaGMlgjBuv0qc9v58+1E0sM1M=";
        private const string EncryptedCustomerKey = "GCd9CcBEx+Nv9zo5vPypDQ==";

        [SetUp]
        public void SetUp()
        {
            _passwordCryptographyService = new PasswordCryptographyService();
        }

        [Test]
        public void Encrypt()
        {
            var password = _passwordCryptographyService.Encrypt(Password);

            var customerKey = _passwordCryptographyService.Encrypt(CustomerKey);
        }

        [Test]
        public void Decrypt()
        {
            var password = _passwordCryptographyService.Decrypt(EncryptedPassword);

            var customerKey = _passwordCryptographyService.Decrypt(EncryptedCustomerKey);
        }
    }
}
