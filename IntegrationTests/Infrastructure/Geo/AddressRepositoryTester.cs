using System.Collections.Generic;
using Falcon.App.Core.Application.Exceptions;
using Falcon.App.Core.Geo;
using Falcon.App.Core.Geo.Domain;
using Falcon.App.DependencyResolution;
using NUnit.Framework;

namespace Falcon.Web.IntegrationTests.Infrastructure.Geo
{
    [TestFixture]
    [Ignore("The database needs to be in a steady state in order to run this test fixture.")]
    public class AddressRepositoryTester
    {
        private const long VALID_ADDRESS_ID_1 = 1;
        private const long VALID_ADDRESS_ID_2 = 2300;

        private IAddressRepository _addressRepository;

        [SetUp]
        public void Setup()
        {
            DependencyRegistrar.RegisterDependencies();
            _addressRepository = IoC.Resolve<IAddressRepository>();
        }


        [Test]
        public void GetAddressReturnsAddressWhenGivenValidId()
        {
            Address address = _addressRepository.GetAddress(VALID_ADDRESS_ID_1);

            Assert.IsNotNull(address);
        }

        [Test]
        public void GetAddressesReturnsAddressesWhenGivenValidIds()
        {
            var validAddressIds = new List<long> { VALID_ADDRESS_ID_1, VALID_ADDRESS_ID_2 };

            List<Address> addresses = _addressRepository.GetAddresses(validAddressIds);

            Assert.AreEqual(validAddressIds.Count, addresses.Count);
        }

        [Test]
        public void ValidateAddressTester()
        {
            var address = new Address();
            address.StreetAddressLine1 = "ABCD";
            address.State = "Texas";
            address.ZipCode = new ZipCode();
            address.ZipCode.Zip = "78705";
            address.City = "Austin";
            
            Assert.IsTrue(_addressRepository.ValidateAddress(address));
        }

        [Test]
        [ExpectedException(typeof(InvalidAddressException))]
        public void SaveAddressFailsWhenOnlyCountrySet()
        {
            var address = new Address {Country = "USA"};
            address = _addressRepository.Save(address);

            Assert.Greater(0,address.Id);

        }

    }
}