using System.Collections.Generic;
using System.Linq;
using Falcon.App.Core.Deprecated;
using Falcon.App.Core.Extensions;
using Falcon.App.Core.Impl;
using Falcon.App.Core.Interfaces;
using NUnit.Framework;
using Rhino.Mocks;

namespace HealthYes.Web.UnitTests.Core.Impl
{
    [TestFixture]
    public class ValidatorTester
    {
        private MockRepository _mocks;
        private IValidationRuleFactory<string> _mockedValidationRuleFactory;
        private IValidationRule<string> _mockedValidationRule;
        private IValidator<string> _validator;

        [SetUp]
        public void SetUp()
        {
            _mocks = new MockRepository();
            _mockedValidationRuleFactory = _mocks.StrictMock<IValidationRuleFactory<string>>();
            _mockedValidationRule = _mocks.StrictMock<IValidationRule<string>>();
        }

        [TearDown]
        public void TearDown()
        {
            _mocks = null;
        }

        private void InitializeValidator()
        {
            _validator = new Validator<string>(_mockedValidationRuleFactory);
        }

        [Test]
        public void IsValidReturnsTrueWhenNoRulesExist()
        {
            Expect.Call(_mockedValidationRuleFactory.CreateValidationRules()).Return(new List<IValidationRule<string>>());

            _mocks.ReplayAll();
            InitializeValidator();
            bool isValid = _validator.IsValid(string.Empty);
            _mocks.VerifyAll();

            Assert.IsTrue(isValid);
        }

        [Test]
        public void IsValidReturnsTrueWhenOneRuleExistsAndIsValid()
        {
            string stringToValidate = string.Empty;

            Expect.Call(_mockedValidationRuleFactory.CreateValidationRules()).Return(new List<IValidationRule<string>> { _mockedValidationRule });
            Expect.Call(_mockedValidationRule.IsValid(stringToValidate)).Return(true);

            _mocks.ReplayAll();
            InitializeValidator();
            bool isValid = _validator.IsValid(stringToValidate);
            _mocks.VerifyAll();

            Assert.IsTrue(isValid);
        }

        [Test]
        public void IsValidReturnsTrueWhenThreeRulesExistsAndAreValid()
        {
            string stringToValidate = string.Empty;

            var validationRules = new List<IValidationRule<string>> { _mockedValidationRule, _mockedValidationRule, _mockedValidationRule };
            Expect.Call(_mockedValidationRuleFactory.CreateValidationRules()).Return(validationRules);
            Expect.Call(_mockedValidationRule.IsValid(stringToValidate)).Return(true).Repeat.Times(3);

            _mocks.ReplayAll();
            InitializeValidator();
            bool isValid = _validator.IsValid(string.Empty);
            _mocks.VerifyAll();

            Assert.IsTrue(isValid);
        }

        [Test]
        public void IsValidReturnsFalseWhenOneRuleExistsAndIsInvalid()
        {
            string stringToValidate = string.Empty;

            Expect.Call(_mockedValidationRuleFactory.CreateValidationRules()).Return(new List<IValidationRule<string>> { _mockedValidationRule });
            Expect.Call(_mockedValidationRule.IsValid(stringToValidate)).Return(false);
            Expect.Call(_mockedValidationRule.GetErrorMessage(stringToValidate)).Return(string.Empty);

            _mocks.ReplayAll();
            InitializeValidator();
            bool isValid = _validator.IsValid(stringToValidate);
            _mocks.VerifyAll();

            Assert.IsFalse(isValid);
        }

        [Test]
        public void IsValidReturnsFalseWhenThreeRulesExistAndOneIsInvalid()
        {
            string stringToValidate = string.Empty;

            var validationRules = new List<IValidationRule<string>> { _mockedValidationRule, _mockedValidationRule, _mockedValidationRule };
            Expect.Call(_mockedValidationRuleFactory.CreateValidationRules()).Return(validationRules);
            Expect.Call(_mockedValidationRule.IsValid(stringToValidate)).Return(true).Repeat.Twice();
            Expect.Call(_mockedValidationRule.IsValid(stringToValidate)).Return(false);
            Expect.Call(_mockedValidationRule.GetErrorMessage(stringToValidate)).Return(string.Empty);

            _mocks.ReplayAll();
            InitializeValidator();
            bool isValid = _validator.IsValid(string.Empty);
            _mocks.VerifyAll();

            Assert.IsFalse(isValid);
        }

        [Test]
        public void IsValidClearsBrokenRulesListBeforeValidatingGivenRules()
        {
            const int expectedNumberOfErrorMessages = 1;
            string stringToValidate = string.Empty;
            const string expectedErrorMessage = "ErrorMessage";

            Expect.Call(_mockedValidationRuleFactory.CreateValidationRules()).Return(new List<IValidationRule<string>> { _mockedValidationRule });
            Expect.Call(_mockedValidationRule.IsValid(stringToValidate)).Return(false).Repeat.Twice();
            Expect.Call(_mockedValidationRule.GetErrorMessage(stringToValidate)).Return(expectedErrorMessage).Repeat.Twice();

            _mocks.ReplayAll();
            InitializeValidator();
            _validator.IsValid(stringToValidate);
            _validator.IsValid(stringToValidate);
            _mocks.VerifyAll();

            int numberOfErrorMessages = _validator.GetBrokenRuleErrorMessages().Count;
            Assert.AreEqual(expectedNumberOfErrorMessages, numberOfErrorMessages, "{0} error message(s) expected, {1} returned.",
                expectedNumberOfErrorMessages, numberOfErrorMessages);
        }

        [Test]
        public void IsValidReturnsFalseWhenNullObjectProvided()
        {
            Expect.Call(_mockedValidationRuleFactory.CreateValidationRules()).Return(new List<IValidationRule<string>>());

            _mocks.ReplayAll();
            InitializeValidator();
            bool isValid = _validator.IsValid(null);
            _mocks.VerifyAll();

            Assert.IsFalse(isValid, "IsValid returned true for null object.");
        }

        [Test]
        public void GetBrokenRuleErrorMessagesReturnsEmptyListWhenOneRuleExistsAndIsValid()
        {
            string stringToValidate = string.Empty;
            Expect.Call(_mockedValidationRuleFactory.CreateValidationRules()).Return(new List<IValidationRule<string>> { _mockedValidationRule });
            Expect.Call(_mockedValidationRule.IsValid(stringToValidate)).Return(true);

            _mocks.ReplayAll();
            InitializeValidator();
            _validator.IsValid(stringToValidate);
            List<string> errorMessages = _validator.GetBrokenRuleErrorMessages();
            _mocks.VerifyAll();

            Assert.IsEmpty(errorMessages, "{0} message(s) returned.", errorMessages.Count);
        }

        [Test]
        public void GetBrokenRuleErrorMessagesReturnsOneErrorWithCorrectMessageWhenOneRuleExistsAndIsInvalid()
        {
            const string expectedErrorMessage = "ErrorMessage";
            const string stringToValidate = "asdf";

            Expect.Call(_mockedValidationRuleFactory.CreateValidationRules()).Return(new List<IValidationRule<string>> { _mockedValidationRule });
            Expect.Call(_mockedValidationRule.IsValid(stringToValidate)).Return(false);
            Expect.Call(_mockedValidationRule.GetErrorMessage(stringToValidate)).Return(expectedErrorMessage);

            _mocks.ReplayAll();
            InitializeValidator();
            _validator.IsValid(stringToValidate);
            List<string> errorMessages = _validator.GetBrokenRuleErrorMessages();
            _mocks.VerifyAll();

            Assert.IsTrue(errorMessages.HasSingleItem(), "{0} messages returned when 1 expected.", errorMessages.Count);
            Assert.AreEqual(expectedErrorMessage, errorMessages.Single());
        }

        [Test]
        public void GetBrokenRuleErrorMessagesReturnsTwoErrorsWhenThreeRulesExistAndTwoAreInvalid()
        {
            const string stringToValidate = "String to validate";
            const string expectedErrorMessage1 = "ErrorMessage1";
            const string expectedErrorMessage2 = "ErrorMessage2";

            var validationRules = new List<IValidationRule<string>> { _mockedValidationRule, _mockedValidationRule, _mockedValidationRule };
            Expect.Call(_mockedValidationRuleFactory.CreateValidationRules()).Return(validationRules);
            Expect.Call(_mockedValidationRule.IsValid(stringToValidate)).Return(true);
            Expect.Call(_mockedValidationRule.IsValid(stringToValidate)).Return(false).Repeat.Twice();
            Expect.Call(_mockedValidationRule.GetErrorMessage(stringToValidate)).Return(expectedErrorMessage1);
            Expect.Call(_mockedValidationRule.GetErrorMessage(stringToValidate)).Return(expectedErrorMessage2);

            _mocks.ReplayAll();
            InitializeValidator();
            _validator.IsValid(stringToValidate);
            List<string> errorMessages = _validator.GetBrokenRuleErrorMessages();
            _mocks.VerifyAll();

            Assert.Contains(expectedErrorMessage1, errorMessages);
            Assert.Contains(expectedErrorMessage2, errorMessages);
        }
    }
}