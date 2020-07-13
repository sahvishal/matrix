using System;
using Falcon.App.Core.Deprecated;
using Falcon.App.Core.Interfaces;
using Falcon.App.Core.ValidationRules;
using HealthYes.Web.UnitTests.Fakes;
using NUnit.Framework;

namespace HealthYes.Web.UnitTests.Core.ValidationRules
{
    [TestFixture]
    public class GuidMustBeValidRuleTester
    {
        [Test]
        public void IsValidReturnsFalseWhenGivenNullObjectToCheck()
        {
            IValidationRule<FakeObjectToValidate> rule = 
                new GuidMustBeValidRule<FakeObjectToValidate>(f => f.Guid, "FakeGuid");

            bool isValid = rule.IsValid(null);

            Assert.IsFalse(isValid, "IsValid returned true for null object.");
        }

        [Test]
        public void IsValidReturnsTrueForGuidThatIsNotEqualToEmptyGuid()
        {
            IValidationRule<FakeObjectToValidate> rule =
                new GuidMustBeValidRule<FakeObjectToValidate>(f => f.Guid, "FakeGuid");

            bool isValid = rule.IsValid(new FakeObjectToValidate {Guid = Guid.NewGuid()});

            Assert.IsTrue(isValid, "IsValid returned false for guid that did not equal empty guid.");
        }

        [Test]
        public void IsValidReturnsFalseForEmptyGuid()
        {
            IValidationRule<FakeObjectToValidate> rule =
                new GuidMustBeValidRule<FakeObjectToValidate>(f => f.Guid, "FakeGuid");

            bool isValid = rule.IsValid(new FakeObjectToValidate());

            Assert.IsFalse(isValid, "IsValid returned true for empty guid.");
        }

        [Test]
        public void GetErrorMessageReturnsMessageForNullObject()
        {
            IValidationRule<FakeObjectToValidate> rule =
                new GuidMustBeValidRule<FakeObjectToValidate>(f => f.Guid, "FakeGuid");

            string errorMessage = rule.GetErrorMessage(null);

            Assert.IsNotNull(errorMessage);
            Assert.IsNotEmpty(errorMessage);
        }

        [Test]
        public void GetErrorMessageReturnsMessageForNonNullObject()
        {
            IValidationRule<FakeObjectToValidate> rule =
                new GuidMustBeValidRule<FakeObjectToValidate>(f => f.Guid, "FakeGuid");

            string errorMessage = rule.GetErrorMessage(new FakeObjectToValidate());

            Assert.IsNotNull(errorMessage);
            Assert.IsNotEmpty(errorMessage);
        }

        [Test]
        [ExpectedException(typeof(ArgumentNullException))]
        public void ConstructorThrowsExceptionWhenGivenNullGuidToCheckFunction()
        {
            new GuidMustBeValidRule<FakeObjectToValidate>(null, string.Empty);
        }

        [Test]
        [ExpectedException(typeof(ArgumentNullException))]
        public void ConstructorThrowsExceptionWhenGivenNullPropertyName()
        {
            new GuidMustBeValidRule<FakeObjectToValidate>(f => f.Guid, null);
        }
    }
}