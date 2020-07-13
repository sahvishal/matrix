using Falcon.App.Core.Geo;
using Falcon.App.Core.Geo.Domain;
using Falcon.App.DependencyResolution;
using NUnit.Framework;
using Falcon.App.Core.Geo.Enum;

namespace Falcon.Web.IntegrationTests.Infrastructure.Geo
{
    [TestFixture]
    public class AddressServiceTester
    {

        private IAddressService _addressService;

        [SetUp]
        public void Setup()
        {
            DependencyRegistrar.RegisterDependencies();
            _addressService = IoC.Resolve<IAddressService>();
        }

        [Test]
        public void SaveValidatableAddressTest()
        {
            var address = new Address()
                              {
                                  StreetAddressLine1 = "Fake Address1",
                                  City = "Austin",
                                  State = "Texas",
                                  CountryId = (long)AddressValidatableCountries.USA,
                                  ZipCode = new ZipCode() { Zip = "78705" }
                              };
            address = _addressService.SaveAfterSanitizing(address);

            Assert.Greater(address.Id, 0);
        }

        [Test]
        public void SaveUnvalidatableAddressTest()
        {
            var address = new Address()
            {
                StreetAddressLine1 = "Fake Address1",
                City = "Fake City",
                State = "British Columbia",
                Country = "Canada",
                ZipCode = new ZipCode() { Zip = "AB445" }
            };
            address = _addressService.SaveAfterSanitizing(address);

            Assert.Greater(address.Id, 0);
        }


    }
}