using System;
using Falcon.App.Core.Deprecated;
using Falcon.App.Core.Interfaces;
using Falcon.App.Core.ValidationRules;
using HealthYes.Web.UnitTests.Fakes;
using NUnit.Framework;

namespace HealthYes.Web.UnitTests.Core.ValidationRules
{
    [TestFixture]
    public class StringCannotBeNullOrEmptyRuleTester
    {
        [Test]
        public void IsValidReturnsFalseWhenGivenNullObject()
        {
            IValidationRule<FakeObjectToValidate> rule = 
                new StringCannotBeNullOrEmptyRule<FakeObjectToValidate>(f => f.ToString(), "Property");

            bool isValid = rule.IsValid(null);

            Assert.IsFalse(isValid, "IsValid returned true for null object.");
        }

        [Test]
        public void IsValidReturnsTrueForStringOfLengthOne()
        {
            IValidationRule<string> rule = new StringCannotBeNullOrEmptyRule<string>(s => s, "Property");

            bool isValid = rule.IsValid("1");

            Assert.IsTrue(isValid, "IsValid returned false for string of length 1.");
        }

        [Test]
        public void IsValidReturnsTrueForStringOfLengthGreaterThanOne()
        {
            string stringToCheck = "1";
            IValidationRule<string> rule = new StringCannotBeNullOrEmptyRule<string>(s => s, "Property");

            for (int i = 2; i < 10; i++)
            {
                stringToCheck += i;
                Assert.IsTrue(rule.IsValid(stringToCheck), "IsValid returned false for string of length {0}.", i);
            }
        }

        [Test]
        public void IsValidReturnsFalseForEmptyString()
        {
            IValidationRule<string> rule = new StringCannotBeNullOrEmptyRule<string>(s => s, "Property");

            bool isValid = rule.IsValid(string.Empty);

            Assert.IsFalse(isValid, "IsValid returned true for empty string.");
        }

        [Test]
        public void IsValidReturnsFalseForNullString()
        {
            IValidationRule<string> rule = new StringCannotBeNullOrEmptyRule<string>(s => null, "Property");

            bool isValid = rule.IsValid("1");

            Assert.IsFalse(isValid, "IsValid returned true for null string.");
        }

        [Test]
        public void GetErrorMessageReturnsMessageWhenGivenNullObject()
        {
            IValidationRule<string> rule = new StringCannotBeNullOrEmptyRule<string>(s => s, "Property");

            string errorMessage = rule.GetErrorMessage(null);

            Assert.IsNotNull(errorMessage);
            Assert.IsNotEmpty(errorMessage);
        }

        [Test]
        public void GetErrorMessageReturnsMessageWhenGivenNonNullObject()
        {
            IValidationRule<string> rule = new StringCannotBeNullOrEmptyRule<string>(s => s, "Property");

            string errorMessage = rule.GetErrorMessage(string.Empty);

            Assert.IsNotNull(errorMessage);
            Assert.IsNotEmpty(errorMessage);
        }

        [Test]
        [ExpectedException(typeof(ArgumentNullException))]
        public void ConstructorThrowsExceptionWhenGivenNullStringToValidateFunction()
        {
            new StringCannotBeNullOrEmptyRule<string>(null, string.Empty);
        }

        [Test]
        [ExpectedException(typeof(ArgumentNullException))]
        public void ConstructorThrowsExceptionWhenGivenNullPropertyName()
        {
            new StringCannotBeNullOrEmptyRule<string>(s => s, null);
        }
    }
}