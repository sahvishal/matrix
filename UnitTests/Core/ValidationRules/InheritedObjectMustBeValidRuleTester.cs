using System;
using Falcon.App.Core.Deprecated;
using Falcon.App.Core.Interfaces;
using Falcon.App.Core.ValidationRules;
using HealthYes.Web.UnitTests.Fakes;
using NUnit.Framework;
using Rhino.Mocks;

namespace HealthYes.Web.UnitTests.Core.ValidationRules
{
    [TestFixture]
    public class InheritedObjectMustBeValidRuleTester
    {
        private MockRepository _mocks;
        private IValidator<string> _mockedValidator;
        private IValidationRule<string> _inheritedObjectRule;
        private IValidationErrorMessageFormatter<string> _mockedFormatter;

        [SetUp]
        public void SetUp()
        {
            _mocks = new MockRepository();
            _mockedValidator = _mocks.StrictMock<IValidator<string>>();
            _mockedFormatter = _mocks.StrictMock<IValidationErrorMessageFormatter<string>>();
            _inheritedObjectRule = new InheritedObjectMustBeValidRule<string, string>(_mockedValidator, _mockedFormatter);
        }

        [Test]
        public void IsValidReturnsTrueWhenGivenValidatorReturnsTrue()
        {
            string stringToValidate = string.Empty;

            Expect.Call(_mockedValidator.IsValid(stringToValidate)).Return(true);

            _mocks.ReplayAll();
            Assert.IsTrue(_inheritedObjectRule.IsValid(stringToValidate));
            _mocks.VerifyAll();
        }

        [Test]
        public void IsValidReturnsFalseWhenGivenValidatorReturnsFalse()
        {
            string stringToValidate = string.Empty;

            Expect.Call(_mockedValidator.IsValid(stringToValidate)).Return(false);

            _mocks.ReplayAll();
            Assert.IsFalse(_inheritedObjectRule.IsValid(stringToValidate));
            _mocks.VerifyAll();
        }

        [Test]
        public void IsValidReturnsFalseWhenGivenNullObjectToValidate()
        {
            bool isValid = _inheritedObjectRule.IsValid(null);

            Assert.IsFalse(isValid, "Null object returned true.");
        }

        [Test]
        public void GetErrorMessageReturnsResultOfMessageFormatterWithGivenValidatorProvided()
        {
            const string expectedMessage = "Expected error message.";

            Expect.Call(_mockedFormatter.FormatErrorMessages(_mockedValidator)).Return(expectedMessage);

            _mocks.ReplayAll();
            string errorMessage = _inheritedObjectRule.GetErrorMessage(string.Empty);
            _mocks.VerifyAll();

            Assert.Contains(expectedMessage, errorMessage.Split(Environment.NewLine.ToCharArray()));
        }

        [Test]
        [ExpectedException(typeof(ArgumentNullException))]
        public void ConstructorThrowsExceptionWhenGivenNullValidator()
        {
            new InheritedObjectMustBeValidRule<string, string>(null);
        }

        [Test]
        [ExpectedException(typeof(ArgumentNullException))]
        public void ConstructorThrowsExceptionWhenGivenNullFormatter()
        {
            new InheritedObjectMustBeValidRule<string, string>(_mockedValidator, null);
        }
    }
}