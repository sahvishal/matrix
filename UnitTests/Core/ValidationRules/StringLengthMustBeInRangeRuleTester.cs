using System;
using Falcon.App.Core.Deprecated;
using Falcon.App.Core.Interfaces;
using Falcon.App.Core.ValidationRules;
using HealthYes.Web.UnitTests.Fakes;
using NUnit.Framework;

namespace HealthYes.Web.UnitTests.Core.ValidationRules
{
    [TestFixture]
    public class StringLengthMustBeInRangeRuleTester
    {
        [Test]
        public void IsValidReturnsFalseWhenGivenNullObjectToValidate()
        {
            IValidationRule<string> rule = new StringLengthMustBeInRangeRule<string>(s => s, "Name", 0);

            bool isValid = rule.IsValid(null);

            Assert.IsFalse(isValid, "Null object evaluated to true when validated.");
        }

        [Test]
        public void IsValidReturnsFalseWhenPropertyToCheckOfGivenObjectIsNull()
        {
            var medicalVendorInvoice = new FakeMedicalVendorInvoiceBase {MedicalVendorName = null};
            IValidationRule<FakeMedicalVendorInvoiceBase> rule = new StringLengthMustBeInRangeRule
                <FakeMedicalVendorInvoiceBase>(s => s.MedicalVendorName, "MedicalVendorName", 0);

            bool isValid = rule.IsValid(medicalVendorInvoice);

            Assert.IsFalse(isValid, "Null object evaluated to true when validated.");
        }

        [Test]
        public void IsValidReturnsTrueForEmptyStringWhenMinimumLengthIs0()
        {
            const int minimumLength = 0;
            IValidationRule<string> rule = new StringLengthMustBeInRangeRule<string>(s => s, "Name", 
                minimumLength);

            bool isValid = rule.IsValid(string.Empty);

            Assert.IsTrue(isValid, "Empty string evaluated to false when minimum length was 0.");
        }

        [Test]
        public void IsValidReturnsFalseForEmptyStringWhenMinimumLengthIs1()
        {
            const int minimumLength = 1;
            IValidationRule<string> rule = new StringLengthMustBeInRangeRule<string>(s => s, "Name", 
                minimumLength);

            bool isValid = rule.IsValid(string.Empty);

            Assert.IsFalse(isValid, "Empty string evaluated to true when minimum length was 1.");
        }

        [Test]
        public void IsValidReturnsTrueForStringWhoseLengthEqualsMinimumLength()
        {
            const string stringToValidate = "1";
            const int minimumLength = 1;
            IValidationRule<string> rule = new StringLengthMustBeInRangeRule<string>(s => s, "Name", 
                minimumLength);

            bool isValid = rule.IsValid(stringToValidate);

            Assert.IsTrue(isValid, "'{0}' returned false even though it matched minimum length {1}.",
                stringToValidate, minimumLength);
        }

        [Test]
        public void IsValidReturnsTrueForStringWhoseLengthExceedsMinimumLength()
        {
            string stringToValidate = "123";
            const int minimumLength = 3;
            IValidationRule<string> rule = new StringLengthMustBeInRangeRule<string>(s => s, "Name", 
                minimumLength);

            for (int i = 4; i < 10; i++)
            {
                stringToValidate += i;
                bool isValid = rule.IsValid(stringToValidate);
                Assert.IsTrue(isValid, "'{0}' returned false even though it matched minimum length {1}.",
                    stringToValidate, minimumLength);
            }
        }

        [Test]
        public void IsValidReturnsTrueForStringWhoseLengthMatchesMaximumLength()
        {
            const string stringToValidate = "1";
            const int maximumLength = 1;
            IValidationRule<string> rule = new StringLengthMustBeInRangeRule<string>(s => s, "Name", 
                0, maximumLength);

            bool isValid = rule.IsValid(stringToValidate);

            Assert.IsTrue(isValid, "'{0}' returned false even though it matched maximum length {1}.",
                stringToValidate, maximumLength);
        }

        [Test]
        public void IsValidReturnsTrueForStringWhoseLengthIsOneLessThanMax()
        {
            const string stringToValidate = "12";
            const int maximumLength = 3;
            IValidationRule<string> rule = new StringLengthMustBeInRangeRule<string>(s => s, "Name", 
                0, maximumLength);

            bool isValid = rule.IsValid(stringToValidate);

            Assert.IsTrue(isValid, "'{0}' returned false even though it was one less than maximum length {1}.",
                stringToValidate, maximumLength);
        }

        [Test]
        public void IsValidReturnsTrueForStringWhoseLengthIsLessThanMax()
        {
            string stringToValidate = "12";
            const int maximumLength = 10;
            IValidationRule<string> rule = new StringLengthMustBeInRangeRule<string>(s => s, "Name", 
                0, maximumLength);

            for (int i = 3; i < maximumLength; i++)
            {
                stringToValidate += i;
                bool isValid = rule.IsValid(stringToValidate);
                Assert.IsTrue(isValid, "'{0}' returned false even though it was less than maximum length {1}.",
                    stringToValidate, maximumLength);
            }
        }

        [Test]
        public void IsValidReturnsFalseForStringWhoseLengthIsOneGreaterThanMaximumLength()
        {
            const string stringToValidate = "12";
            const int maximumLength = 1;
            IValidationRule<string> rule = new StringLengthMustBeInRangeRule<string>(s => s, "Name", 
                0, maximumLength);

            bool isValid = rule.IsValid(stringToValidate);

            Assert.IsFalse(isValid, "'{0}' returned true even though it exceeded maximum length {1}.",
                stringToValidate, maximumLength);
        }

        [Test]
        public void IsValidReturnsFalseForStringWhoseLengthExceedsMaximumLength()
        {
            string stringToValidate = "12";
            const int maximumLength = 1;
            IValidationRule<string> rule = new StringLengthMustBeInRangeRule<string>(s => s, "Name", 
                0, maximumLength);

            for (int i = 3; i < 10; i++)
            {
                stringToValidate += i;
                bool isValid = rule.IsValid(stringToValidate);
                Assert.IsFalse(isValid, "'{0}' returned true even though it exceeded maximum length {1}.",
                    stringToValidate, maximumLength);
            }
        }

        [Test]
        public void IsValidReturnsTrueForStringWhoseLengthEqualsMinAndMax()
        {
            const string stringToValidate = "12345";
            const int length = 5;
            IValidationRule<string> rule = new StringLengthMustBeInRangeRule<string>(s => s, "Name", length, length);

            bool isValid = rule.IsValid(stringToValidate);

            Assert.IsTrue(isValid, "'{0}' returned false even though it matched min/max length {1}.",
                stringToValidate, length);
        }

        [Test]
        public void IsValidReturnsFalseForStringWhoseLengthDoesNotEqualMinAndMax()
        {
            const string stringLessThanMin = "1234";
            const string stringMoreThanMax = "123456";
            const int length = 5;
            IValidationRule<string> rule = new StringLengthMustBeInRangeRule<string>(s => s, "Name", 
                length, length);

            bool isMinStringValid = rule.IsValid(stringLessThanMin);
            bool isMaxStringValid = rule.IsValid(stringMoreThanMax);

            Assert.IsFalse(isMinStringValid, "'{0}' returned true even though it was less than min/max length {1}.",
                stringLessThanMin, length);
            Assert.IsFalse(isMaxStringValid, "'{0}' returned true even though it was more than min/max length {1}.",
                stringMoreThanMax, length);
        }

        [Test]
        public void GetErrorMessageReturnsMessageContainingErrornousStringLength()
        {
            const string stringToValidate = "123";
            int expectedLength = stringToValidate.Length;
            IValidationRule<string> rule = new StringLengthMustBeInRangeRule<string>(s => s, "Name", 0, 0);

            string errorMessage = rule.GetErrorMessage(stringToValidate);

            Assert.IsTrue(errorMessage.Contains(expectedLength.ToString()), 
                "Message did not contain string's length.");
        }

        [Test]
        public void GetErrorMessageReturnsMessageContainingMinimumStringLength()
        {
            const int expectedMinimumLength = 4;
            IValidationRule<string> rule = new StringLengthMustBeInRangeRule<string>(s => s, "Name", 
                expectedMinimumLength);

            string errorMessage = rule.GetErrorMessage(string.Empty);

            Assert.IsTrue(errorMessage.Contains(expectedMinimumLength.ToString()),
                "Message did not contain minimum string length.");
        }

        [Test]
        public void GetErrorMessageReturnsMessageContainingMaximumStringLength()
        {
            const int expectedMaximumLength = 4;
            IValidationRule<string> rule = new StringLengthMustBeInRangeRule<string>(s => s, "Name", 
                0, expectedMaximumLength);

            string errorMessage = rule.GetErrorMessage(string.Empty);

            Assert.IsTrue(errorMessage.Contains(expectedMaximumLength.ToString()),
                "Message did not contain maximum string length.");
        }

        [Test]
        public void GetErrorMessageReturnsMessageContainingStringLengthMinLengthAndMaxLengthWhenAllGiven()
        {
            const string stringToValidate = "123";
            int expectedLength = stringToValidate.Length;
            const int expectedMinimumLength = 64156;
            const int expectedMaximumLength = 99591;
            IValidationRule<string> rule = new StringLengthMustBeInRangeRule<string>(s => s, "Name",
                expectedMinimumLength, expectedMaximumLength);

            string errorMessage = rule.GetErrorMessage(stringToValidate);

            Assert.IsTrue(errorMessage.Contains(expectedMinimumLength.ToString()),
                "Message did not contain minimum string length.");
            Assert.IsTrue(errorMessage.Contains(expectedMaximumLength.ToString()),
                "Message did not contain maximum string length.");
            Assert.IsTrue(errorMessage.Contains(expectedLength.ToString()),
                "Message did not contain string's length.");
        }

        [Test]
        public void GetErrorMessageReturnsStringWhenGivenNullObject()
        {
            IValidationRule<string> rule = new StringLengthMustBeInRangeRule<string>(s => s, "Name", 0, 0);

            string errorMessage = rule.GetErrorMessage(null);

            Assert.IsNotNull(errorMessage);
            Assert.IsNotEmpty(errorMessage);
        }

        [Test]
        public void GetErrorMessageReturnsStringWhenGivenObjectWithNullProperty()
        {
            var medicalVendorInvoice = new FakeMedicalVendorInvoiceBase { MedicalVendorName = null };
            IValidationRule<FakeMedicalVendorInvoiceBase> rule = new StringLengthMustBeInRangeRule
                <FakeMedicalVendorInvoiceBase>(s => s.MedicalVendorName, "MedicalVendorName", 0, 0);

            string errorMessage = rule.GetErrorMessage(medicalVendorInvoice);

            Assert.IsNotNull(errorMessage);
            Assert.IsNotEmpty(errorMessage);
        }

        [Test]
        [ExpectedException(typeof(ArgumentException))]
        public void ConstructorThrowsExceptionWhenGivenMinimumLengthExceedsGivenMaximumLength()
        {
            const int minimumLength = 3;
            new StringLengthMustBeInRangeRule<string>(s => s, "Name", minimumLength, minimumLength - 1);
        }

        [Test]
        [ExpectedException(typeof(ArgumentOutOfRangeException))]
        public void ConstructorThrowsExceptionWhenGivenMinimumLengthIsNegative()
        {
            const int minimumLength = -1;
            new StringLengthMustBeInRangeRule<string>(s => s, "Name", minimumLength);
        }

        [Test]
        [ExpectedException(typeof(ArgumentOutOfRangeException))]
        public void ConstructorThrowsExceptionWhenGivenMaximumLengthIsNegative()
        {
            const int maximumLength = -1;
            new StringLengthMustBeInRangeRule<string>(s => s, "Name", maximumLength, maximumLength);
        }
    }
}