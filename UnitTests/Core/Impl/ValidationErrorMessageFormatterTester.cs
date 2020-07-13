using System;
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
    public class ValidationErrorMessageFormatterTester
    {
        private MockRepository _mocks;
        private IValidator<string> _mockedValidator;

        private readonly IValidationErrorMessageFormatter<string> _formatter = new ValidationErrorMessageFormatter<string>();

        [SetUp]
        public void SetUp()
        {
            _mocks = new MockRepository();
            _mockedValidator = _mocks.StrictMock<IValidator<string>>();
        }

        [TearDown]
        public void TearDown()
        {
            _mocks = null;
        }

        [Test]
        public void FormatErrorMessagesReturnsStringWithOneLineWhenNoErrorsExist()
        {
            const int expectedNumberOfLines = 1;

            Expect.Call(_mockedValidator.GetBrokenRuleErrorMessages()).Return(new List<string>());

            _mocks.ReplayAll();
            string formattedMessage = _formatter.FormatErrorMessages(_mockedValidator);
            _mocks.VerifyAll();

            Assert.AreEqual(expectedNumberOfLines, formattedMessage.LineCount(), "Expected {0} lines but got {1}.",
                expectedNumberOfLines, formattedMessage.LineCount());
        }

        [Test]
        [ExpectedException(typeof(ArgumentNullException))]
        public void FormatErrorMessagesThrowsExceptionWhenGivenValidatorIsNull()
        {
            _formatter.FormatErrorMessages((IValidator<string>)null);
        }

        [Test]
        [ExpectedException(typeof(ArgumentNullException))]
        public void FormatErrorMessagesThrowsExceptionWhenGivenPrependStringIsNull()
        {
            _formatter.FormatErrorMessages(new List<string>(), null);
        }

        [Test]
        [ExpectedException(typeof(ArgumentNullException))]
        public void FormatErrorMessagesThrowsExceptionWhenGivenListOfMessagesIsNull()
        {
            _formatter.FormatErrorMessages((List<string>)null, string.Empty);
        }

        [Test]
        public void FormatErrorMessagesReturnsStringWithTwoLinesWhenOneErrorExists()
        {
            const int expectedNumberOfLines = 2;
            var errorMessages = new List<string> {string.Empty};

            string formattedMessage = _formatter.FormatErrorMessages(errorMessages);

            Assert.AreEqual(expectedNumberOfLines, formattedMessage.LineCount(), "Expected {0} lines but got {1}.",
                expectedNumberOfLines, formattedMessage.LineCount());
        }

        [Test]
        public void FormatErrorMessagesReturnsStringWithFourLinesWhenThreeErrorsExist()
        {
            const int expectedNumberOfLines = 4;
            var errorMessages = new List<string> { "foo", "foo", "foo" };

            string formattedMessage = _formatter.FormatErrorMessages(errorMessages);

            Assert.AreEqual(expectedNumberOfLines, formattedMessage.LineCount(), "Expected {0} lines but got {1}.",
                expectedNumberOfLines, formattedMessage.LineCount());
        }

        [Test]
        public void FormatErrorMessagesReturnsStringContainingAllErrorMessagesInGivenValidator()
        {
            var errorMessages = new List<string> { "foo", "bar", "bip" };

            string formattedMessage = _formatter.FormatErrorMessages(errorMessages);
            var messages = formattedMessage.Split(Environment.NewLine.ToCharArray());

            foreach (var errorMessage in errorMessages)
            {
                Assert.Contains(errorMessage, messages, "Returned message did not contain error '{0}'.", errorMessage);
            }
        }

        [Test]
        public void FormatErrorMessagesPrependsEachLineWithGivenPrependedString()
        {
            var errorMessages = new List<string> { "foo", "bar", "bip" };
            const string prependString = "\t";
            string formattedMessage = _formatter.FormatErrorMessages(errorMessages, prependString);
            var messages = formattedMessage.Split(Environment.NewLine.ToCharArray());
            foreach (var errorMessage in messages.Where(m => !m.IsEmpty()))
            {
                Assert.IsTrue(errorMessage.Contains(prependString),
                    "Returned message '{0}' did not contain prepend string.", errorMessage);
            }
        }

        [Test]
        public void FormatErrorMessagesReturnsFourLinesWhenThreeErrorsExistAndArePrepended()
        {
            const int expectedNumberOfLines = 4;
            var errorMessages = new List<string> { "foo", "foo", "foo" };

            string formattedMessage = _formatter.FormatErrorMessages(errorMessages, "(pre)");
            Assert.AreEqual(expectedNumberOfLines, formattedMessage.LineCount(), "Expected {0} lines but got {1}.",
                expectedNumberOfLines, formattedMessage.LineCount());
        }
    }
}