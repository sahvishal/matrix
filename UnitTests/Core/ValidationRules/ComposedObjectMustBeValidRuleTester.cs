using System;
using Falcon.App.Core.Deprecated;
using Falcon.App.Core.Interfaces;
using Falcon.App.Core.ValidationRules;
using NUnit.Framework;
using Rhino.Mocks;

namespace HealthYes.Web.UnitTests.Core.ValidationRules
{
    [TestFixture]
    public class ComposedObjectMustBeValidRuleTester
    {
        private MockRepository _mocks;
        private IValidator<int> _mockedValidator;
        private IValidationRule<string> _composedObjectRule;
        private IValidationErrorMessageFormatter<int> _mockedFormatter;

        [SetUp]
        public void SetUp()
        {
            _mocks = new MockRepository();
            _mockedValidator = _mocks.StrictMock<IValidator<int>>();
            _mockedFormatter = _mocks.StrictMock<IValidationErrorMessageFormatter<int>>();
            _composedObjectRule = new ComposedObjectMustBeValidRule<string, int>(s => s.Length, _mockedValidator, _mockedFormatter);
        }

        [TearDown]
        public void TearDown()
        {
            _mocks = null;
        }

        [Test]
        public void IsValidReturnsTrueWhenGivenValidatorReturnsTrue()
        {
            const string stringToValidate = "Foo";

            Expect.Call(_mockedValidator.IsValid(stringToValidate.Length)).Return(true);

            _mocks.ReplayAll();
            Assert.IsTrue(_composedObjectRule.IsValid(stringToValidate));
            _mocks.VerifyAll();
        }

        [Test]
        public void IsValidReturnsFalseWhenGivenValidatorReturnsFalse()
        {
            const string stringToValidate = "Test";

            Expect.Call(_mockedValidator.IsValid(stringToValidate.Length)).Return(false);

            _mocks.ReplayAll();
            Assert.IsFalse(_composedObjectRule.IsValid(stringToValidate));
            _mocks.VerifyAll();
        }

        [Test]
        public void IsValidReturnsFalseWhenGivenNullObject()
        {
            bool isValid = _composedObjectRule.IsValid(null);

            Assert.IsFalse(isValid, "Null object returned true.");
        }

        [Test]
        public void GetErrorMessageReturnsResultOfMessageFormatterWithGivenValidatorProvided()
        {
            const string expectedMessage = "Expected error message.";

            Expect.Call(_mockedFormatter.FormatErrorMessages(_mockedValidator, "\t")).Return(expectedMessage);

            _mocks.ReplayAll();
            string errorMessage = _composedObjectRule.GetErrorMessage(string.Empty);
            _mocks.VerifyAll();

            Assert.Contains(expectedMessage, errorMessage.Split(Environment.NewLine.ToCharArray()));
        }

        [Test]
        [ExpectedException(typeof(ArgumentNullException))]
        public void ConstructorThrowsExceptionWhenGivenNullPropertyFunction()
        {
            new ComposedObjectMustBeValidRule<string, int>(null, _mockedValidator);
        }

        [Test]
        [ExpectedException(typeof(ArgumentNullException))]
        public void ConstructorThrowsExceptionWhenGivenNullValidator()
        {
            new ComposedObjectMustBeValidRule<string, int>(s => s.Length, null);
        }

        [Test]
        [ExpectedException(typeof(ArgumentNullException))]
        public void ConstructorThrowsExceptionWhenGivenNullFormatter()
        {
            new ComposedObjectMustBeValidRule<string, int>(s => s.Length, _mockedValidator, null);
        }
    }
}