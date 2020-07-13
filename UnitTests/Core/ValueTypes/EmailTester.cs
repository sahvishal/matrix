using NUnit.Framework;
using Falcon.App.Core.ValueTypes;

namespace HealthYes.Web.UnitTests.Core.ValueTypes
{
    [TestFixture]
    public class EmailTester
    {
        [Test]
        public void ToStringReturnsAddressAtDomain()
        {
            const string address = "Address";
            const string domainName = "Domain";
            const string expectedString = address + "@" + domainName;
            
            var email = new Email(address, domainName);

            Assert.AreEqual(expectedString, email.ToString());
        }

        [Test]
        public void ToStringReturnsEmptyStringWhenAddressIsEmpty()
        {
            string address = string.Empty;
            const string domainName = "bob";

            var email = new Email(address, domainName);

            Assert.IsEmpty(email.ToString());
        }

        [Test]
        public void ToStringReturnsEmptyStringWhenDomainNameIsEmpty()
        {
            const string address = "bob";
            string domainName = string.Empty;

            var email = new Email(address, domainName);

            Assert.IsEmpty(email.ToString());
        }
    }
}