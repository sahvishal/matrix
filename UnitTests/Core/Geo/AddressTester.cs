using Falcon.App.Core.Geo.Domain;
using NUnit.Framework;

namespace Falcon.UnitTests.Core.Geo
{
    [TestFixture]
    public class AddressTester
    {
     
        [Test]
        public void IsEmptyReturnsTrueForEmptyAddress()
        {
            var address = new Address();

            Assert.IsTrue(address.IsEmpty());

        }

        [Test]
        public void IsEmptyReturnsTrueForEmptyAddressWithNotNullZipCode()
        {
            var address = new Address();
            address.ZipCode = new ZipCode{Zip = ""};

            Assert.IsTrue(address.IsEmpty());

        }
    }
}