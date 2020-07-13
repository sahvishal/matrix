using System;
using Falcon.App.Core.Geo.ViewModels;
using Falcon.App.DependencyResolution;
using FluentValidation;
using NUnit.Framework;

namespace Falcon.UnitTests.Core.Geo
{
    [TestFixture]
    public class AddressCreateModelValidatorTester
    {
        private readonly IValidator<AddressEditModel> _validator;

        public AddressCreateModelValidatorTester()
        {
            DependencyRegistrar.RegisterDependencies();
            _validator = IoC.Resolve<IValidator<AddressEditModel>>();
        }

        [Test]
        public void ValidatorValidatesCorrectlyWhenAddressIsEmpty()
        {
            AddressEditModel addressEditModel = new AddressEditModel();

            var validationResult = _validator.Validate(addressEditModel);

            //foreach (var error in validationResult.Errors)
            //{
            //    Console.WriteLine("Property Name : {0}, Error Message: {1}", error.PropertyName, error.ErrorMessage);
            //}

            Assert.AreEqual(false, validationResult.IsValid);
            var expectedErrors = 10;
            Assert.AreEqual(expectedErrors, validationResult.Errors.Count);            
        }

    }
}