using System;
using System.Linq;
using Falcon.App.Core.Users.ViewModels;
using Falcon.App.Core.ValueTypes;
using Falcon.App.DependencyResolution;
using FluentValidation;
using FluentValidation.Results;
using NUnit.Framework;

namespace Falcon.Web.IntegrationTests.Infrastructure.Users
{
    [TestFixture]
    public class UserCreateModelValidatorTester
    {
        private IValidator<UserEditModel> _validator;

        public UserCreateModelValidatorTester()
        {
            DependencyRegistrar.RegisterDependencies();
            _validator = IoC.Resolve<IValidator<UserEditModel>>();
        }


        [Test]
        public void ValidatorReturnFalseForEmptyObject()
        {
            var userCreateModel = new UserEditModel();

            ValidationResult validationResult = _validator.Validate(userCreateModel);

            foreach (var error in validationResult.Errors)
            {
                    Console.WriteLine("Property Name : {0}, Error Message: {1}",error.PropertyName, error.ErrorMessage);
            }

            Assert.AreEqual(false, validationResult.IsValid);
            Assert.AreEqual(7 , validationResult.Errors.Count);
        }


        [Test]
        public void ValidatorReturnFalseWhenNameIsInvalid()
        {
            var userCreateModel = new UserEditModel{FullName = new Name("$#$##","","LastName")};

            ValidationResult validationResult = _validator.Validate(userCreateModel);

            foreach (var error in validationResult.Errors)
            {
                Console.WriteLine("Property Name : {0}, Error Message: {1}", error.PropertyName, error.ErrorMessage);
            }

            Assert.AreEqual(false, validationResult.IsValid);
            Assert.Contains("FullName.FirstName", validationResult.Errors.Select(x => x.PropertyName).ToList());
        }
    }
}