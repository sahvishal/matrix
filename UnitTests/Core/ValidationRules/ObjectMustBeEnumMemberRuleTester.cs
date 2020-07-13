using System;
using Falcon.App.Core.Deprecated;
using Falcon.App.Core.Interfaces;
using Falcon.App.Core.ValidationRules;
using HealthYes.Web.UnitTests.Fakes;
using NUnit.Framework;

namespace HealthYes.Web.UnitTests.Core.ValidationRules
{
    [TestFixture]
    public class ObjectMustBeEnumMemberRuleTester
    {
        [Test]
        [ExpectedException(typeof(ArgumentNullException))]
        public void ConstructorThrowsExceptionWhenGivenNullEnumToCheckFunction()
        {
            new ObjectMustBeEnumMemberRule<string>(null);
        }

        [Test]
        public void IsValidReturnsFalseWhenGivenNullObjectToCheck()
        {
            IValidationRule<FakeObjectToValidate> rule = new ObjectMustBeEnumMemberRule<FakeObjectToValidate>(f => f.FakeEnum);

            bool isValid = rule.IsValid(null);

            Assert.IsFalse(isValid, "Null object returned true.");
        }

        [Test]
        public void IsValidReturnsTrueWhenEnumOfGivenObjectIsSetToMemberOfThatEnum()
        {
            IValidationRule<FakeObjectToValidate> rule = new ObjectMustBeEnumMemberRule<FakeObjectToValidate>(f => f.FakeEnum);

            bool isValid = rule.IsValid(new FakeObjectToValidate {FakeEnum = FakeEnum.EnumOne});

            Assert.IsTrue(isValid, "IsValid returned false when enum property was set to member of that enum.");
        }

        [Test]
        public void IsValidReturnsTrueWhenEnumOfGivenObjectIsNotSetToMemberOfThatEnum()
        {
            IValidationRule<FakeObjectToValidate> rule = new ObjectMustBeEnumMemberRule<FakeObjectToValidate>(f => f.FakeEnum);

            bool isValid = rule.IsValid(new FakeObjectToValidate { FakeEnum = (FakeEnum)55 });

            Assert.IsFalse(isValid, "IsValid returned true when enum property was not set to member of that enum.");
        }

        [Test]
        public void IsValidReturnsFalseWhenEnumOfGivenObjectIsNotSet()
        {
            IValidationRule<FakeObjectToValidate> rule = new ObjectMustBeEnumMemberRule<FakeObjectToValidate>(f => f.FakeEnum);

            bool isValid = rule.IsValid(new FakeObjectToValidate());

            Assert.IsFalse(isValid, "IsValid returned true when enum property was not set.");
        }

        [Test]
        public void GetErrorMessageReturnsMessageIfGivenObjectIsNull()
        {
            IValidationRule<FakeObjectToValidate> rule = new ObjectMustBeEnumMemberRule<FakeObjectToValidate>(f => f.FakeEnum);

            string message = rule.GetErrorMessage(null);

            Assert.IsNotNull(message);
            Assert.IsNotEmpty(message);
        }

        [Test]
        public void GetErrorMessageReturnsMessageForInvalidEnum()
        {
            IValidationRule<FakeObjectToValidate> rule = new ObjectMustBeEnumMemberRule<FakeObjectToValidate>(f => f.FakeEnum);

            string message = rule.GetErrorMessage(new FakeObjectToValidate());

            Assert.IsNotNull(message);
            Assert.IsNotEmpty(message);
        }
    }
}