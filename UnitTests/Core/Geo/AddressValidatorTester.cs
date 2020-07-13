using Falcon.App.Core.Geo.Domain;
using Falcon.App.DependencyResolution;
using FluentValidation;
using NUnit.Framework;

namespace Falcon.Web.UnitTests.Core.Geo
{
    [TestFixture]
    public class AddressValidatorTester
    {
        private IValidator<Address> _addressValidator;

        [SetUp]
        public void Setup()
        {
            DependencyRegistrar.RegisterDependencies();
            _addressValidator = IoC.Resolve<IValidator<Address>>();
        }

        [Test]
        public void AddressValidation_StreetLine1CannotBeEmpty()
        {
            var address = new Address{StreetAddressLine1 = ""};

            bool isValid = _addressValidator.Validate(address).IsValid;

            Assert.AreEqual(false,isValid);
        }


        [Test]
        public void AddressValidation_AddressIsValidIfAtleastIdOrNameIsSet()
        {
            var address = new Address("line 1","","Austin","","78701","USA");
            address.StateId = 60;


            bool isValid = _addressValidator.Validate(address).IsValid;

            Assert.AreEqual(true, isValid);
        }
    }
}