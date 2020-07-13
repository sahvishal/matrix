using System;
using Falcon.App.Core.Deprecated;
using Falcon.App.Core.Interfaces;
using Falcon.App.Core.ValidationRules;
using HealthYes.Web.UnitTests.Fakes;
using NUnit.Framework;

namespace HealthYes.Web.UnitTests.Core.ValidationRules
{
    [TestFixture]
    public class NumberMustBeInRangeRuleTester
    {
        [Test]
        public void IsValidReturnsFalseWhenGivenNullObject()
        {
            IValidationRule<FakeObjectToValidate> rule = new NumberMustBeInRangeRule<FakeObjectToValidate, int>
                (f => f.Integer, "Int", 0, 5);

            bool isValid = rule.IsValid(null);

            Assert.IsFalse(isValid, "IsValid returned true for null object.");
        }

        [Test]
        public void IsValidReturnsTrueWhenGivenNumberMatchesMinimumNumber()
        {
            const int minimumNumber = 0;
            IValidationRule<FakeObjectToValidate> rule = new NumberMustBeInRangeRule<FakeObjectToValidate, long>
                (f => f.Long, "Long", minimumNumber, 5);

            bool isValid = rule.IsValid(new FakeObjectToValidate {Integer = minimumNumber});

            Assert.IsTrue(isValid, "IsValid returned false for number matching minimum number.");
        }

        [Test]
        public void IsValidReturnsFalseWhenGivenNumberIsLessThanMinimumNumber()
        {
            const int minimumNumber = 1;
            IValidationRule<FakeObjectToValidate> rule = new NumberMustBeInRangeRule<FakeObjectToValidate, decimal>
                (f => f.Decimal, "Decimal", minimumNumber, 5m);

            bool isValid = rule.IsValid(new FakeObjectToValidate { Decimal = minimumNumber - 1 });

            Assert.IsFalse(isValid, "IsValid returned true for number less than minimum number.");
        }

        [Test]
        public void IsValidReturnsTrueWhenGivenNumberMatchesMaximumNumber()
        {
            const int maximumNumber = 5;
            IValidationRule<FakeObjectToValidate> rule = new NumberMustBeInRangeRule<FakeObjectToValidate, int>
                (f => f.Integer, "Int", 0, maximumNumber);

            bool isValid = rule.IsValid(new FakeObjectToValidate { Integer = maximumNumber });

            Assert.IsTrue(isValid, "IsValid returned false for number matching maximum number.");
        }

        [Test]
        public void IsValidReturnsFalseWhenGivenNumberGreaterThanMaximumNumber()
        {
            const int maximumNumber = 5;
            IValidationRule<FakeObjectToValidate> rule = new NumberMustBeInRangeRule<FakeObjectToValidate, int>
                (f => f.Integer, "Int", 0, maximumNumber);

            bool isValid = rule.IsValid(new FakeObjectToValidate { Integer = maximumNumber + 1 });

            Assert.IsFalse(isValid, "IsValid returned true for number greater than maximum number.");
        }

        [Test]
        public void IsValidReturnsTrueWhenGivenNumberMatchesMinimumAndMaximumNumber()
        {
            const int minimumNumber = 0;
            const int maximumNumber = minimumNumber;
            IValidationRule<FakeObjectToValidate> rule = new NumberMustBeInRangeRule<FakeObjectToValidate, long>
                (f => f.Long, "Long", minimumNumber, maximumNumber);

            bool isValid = rule.IsValid(new FakeObjectToValidate { Long = minimumNumber });

            Assert.IsTrue(isValid, "IsValid returned false for number matching both minimum and maximum number.");
        }

        [Test]
        [ExpectedException(typeof(ArgumentNullException))]
        public void ConstructorThrowsExceptionWhenGivenNullFunction()
        {
            new NumberMustBeInRangeRule<FakeObjectToValidate, int>(null, string.Empty, 0, 0);
        }

        [Test]
        [ExpectedException(typeof(ArgumentNullException))]
        public void ConstructorThrowsExceptionWhenGivenNullPropertyName()
        {
            new NumberMustBeInRangeRule<FakeObjectToValidate, int>(f => f.Integer, null, 0, 0);
        }

        [Test]
        [ExpectedException(typeof(ArgumentException))]
        public void ConstructorThrowsExceptionWhenMinimumNumberExceedsMaximumNumber()
        {
            const int minimumNumber = 2;
            new NumberMustBeInRangeRule<FakeObjectToValidate, int>(f => f.Integer, string.Empty, 
                minimumNumber, minimumNumber - 1);
        }

        [Test]
        public void GetErrorMessageReturnsMessageForNullObject()
        {
            IValidationRule<FakeObjectToValidate> rule = new NumberMustBeInRangeRule<FakeObjectToValidate, int>
                (f => f.Integer, "Int", 0, 0);

            string errorMessage = rule.GetErrorMessage(null);

            Assert.IsNotNull(errorMessage);
            Assert.IsNotEmpty(errorMessage);
        }

        [Test]
        public void GetErrorMessageReturnsMessageForNonNullObject()
        {
            IValidationRule<FakeObjectToValidate> rule = new NumberMustBeInRangeRule<FakeObjectToValidate, int>
                (f => f.Integer, "Int", 0, 0);

            string errorMessage = rule.GetErrorMessage(new FakeObjectToValidate());

            Assert.IsNotNull(errorMessage);
            Assert.IsNotEmpty(errorMessage);
        }
    }
}