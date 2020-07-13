using System;
using Falcon.App.Core.Application.Exceptions;
using Falcon.App.Core.Deprecated;
using Falcon.App.Core.Extensions;
using Falcon.App.Core.Interfaces;
using Falcon.App.Core.ValidationRules;
using HealthYes.Web.UnitTests.Fakes;
using NUnit.Framework;

namespace HealthYes.Web.UnitTests.Core.ValidationRules
{
    [TestFixture]
    public class DateMustBeInRangeRuleTester
    {
        [Test]
        public void IsValidReturnsTrueWhenNullDateGiven()
        {
            IValidationRule<FakeObjectToValidate> rule = new DateMustBeInRangeRule<FakeObjectToValidate>
                (f => f.NullableDateTime, "Null Date");

            bool isValid = rule.IsValid(new FakeObjectToValidate());

            Assert.IsTrue(isValid, "IsValid returned false for null datetime object.");
        }

        [Test]
        public void IsValidReturnsFalseWhenNullDateGivenAndIsNullDateValidIsFalse()
        {
            IValidationRule<FakeObjectToValidate> rule = new DateMustBeInRangeRule<FakeObjectToValidate>
                (f => f.NullableDateTime, "Null Date", false);

            bool isValid = rule.IsValid(new FakeObjectToValidate());

            Assert.IsFalse(isValid, "IsValid returned true for null datetime object.");
        }

        [Test]
        public void IsValidReturnsFalseWhenGivenNullObject()
        {
            IValidationRule<FakeObjectToValidate> rule = new DateMustBeInRangeRule<FakeObjectToValidate>
                (f => f.NullableDateTime, "Null Date");

            bool isValid = rule.IsValid(null);

            Assert.IsFalse(isValid, "Null object returned true.");
        }

        [Test]
        public void IsValidReturnsTrueForDateThatMatchesMinimumDate()
        {
            var minimumDate = new DateTime(2001, 1, 1);
            IValidationRule<FakeObjectToValidate> rule = new DateMustBeInRangeRule<FakeObjectToValidate>
                (f => f.NullableDateTime, "Null Date", minimumDate, new DateTime(2002, 1, 1));

            bool isValid = rule.IsValid(new FakeObjectToValidate {NullableDateTime = minimumDate});

            Assert.IsTrue(isValid, "IsValid returned false for date that matched minimum date.");
        }

        [Test]
        public void IsValidReturnsTrueForDateThatComesOneDayAfterMinimumDate()
        {
            var minimumDate = new DateTime(2001, 1, 1);
            IValidationRule<FakeObjectToValidate> rule = new DateMustBeInRangeRule<FakeObjectToValidate>
                (f => f.NullableDateTime, "Null Date", minimumDate, new DateTime(2002, 1, 1));

            bool isValid = rule.IsValid(new FakeObjectToValidate { NullableDateTime = minimumDate.AddDays(1) });

            Assert.IsTrue(isValid, "IsValid returned false for date that came one day after minimum date.");
        }

        [Test]
        public void IsValidReturnsFalseForDateThatComesBeforeMinimumDate()
        {
            var minimumDate = new DateTime(2001, 1, 1);
            IValidationRule<FakeObjectToValidate> rule = new DateMustBeInRangeRule<FakeObjectToValidate>
                (f => f.NullableDateTime, "Null Date", minimumDate, new DateTime(2002, 1, 1));

            bool isValid = rule.IsValid(new FakeObjectToValidate { NullableDateTime = minimumDate.AddDays(-1) });

            Assert.IsFalse(isValid, "IsValid returned true for date that came one day before minimum date.");
        }

        [Test]
        public void IsValidReturnsTrueForDateThatMatchesMaximumDate()
        {
            var maximumDate = new DateTime(2002, 1, 1);
            IValidationRule<FakeObjectToValidate> rule = new DateMustBeInRangeRule<FakeObjectToValidate>
                (f => f.NullableDateTime, "Null Date", new DateTime(2001, 1, 1), maximumDate);

            bool isValid = rule.IsValid(new FakeObjectToValidate { NullableDateTime = maximumDate });

            Assert.IsTrue(isValid, "IsValid returned false for date that matched maximum date.");
        }

        [Test]
        public void IsValidReturnsTrueForDateThatComesOneDayBeforeMaximumDate()
        {
            var maximumDate = new DateTime(2002, 1, 1);
            IValidationRule<FakeObjectToValidate> rule = new DateMustBeInRangeRule<FakeObjectToValidate>
                (f => f.NullableDateTime, "Null Date", new DateTime(2001, 1, 1), maximumDate);

            bool isValid = rule.IsValid(new FakeObjectToValidate { NullableDateTime = maximumDate.AddDays(-1) });

            Assert.IsTrue(isValid, "IsValid returned false for date that came one day before maximum date.");
        }

        [Test]
        public void IsValidReturnsFalseForDateThatComesOneDayAfterMaximumDate()
        {
            var maximumDate = new DateTime(2002, 1, 1);
            IValidationRule<FakeObjectToValidate> rule = new DateMustBeInRangeRule<FakeObjectToValidate>
                (f => f.NullableDateTime, "Null Date", new DateTime(2001, 1, 1), maximumDate);

            bool isValid = rule.IsValid(new FakeObjectToValidate { NullableDateTime = maximumDate.AddDays(1) });

            Assert.IsFalse(isValid, "IsValid returned true for date that came one day after maximum date.");
        }

        [Test]
        public void IsValidReturnsTrueForDateMatchingMinimumAndMaximumDate()
        {
            var date = new DateTime(2001, 1, 1);

            IValidationRule<FakeObjectToValidate> rule = new DateMustBeInRangeRule<FakeObjectToValidate>
                (f => f.NullableDateTime, "Null Date", date, date);

            bool isValid = rule.IsValid(new FakeObjectToValidate { NullableDateTime = date });

            Assert.IsTrue(isValid, "IsValid returned false for date that match both minimum and maximum dates.");
        }

        [Test]
        public void GetErrorMessageReturnsMessageWhenNullObjectGiven()
        {
            IValidationRule<FakeObjectToValidate> rule = new DateMustBeInRangeRule<FakeObjectToValidate>
                (f => f.NullableDateTime, "Null Date");

            string message = rule.GetErrorMessage(null);

            Assert.IsNotNull(message);
            Assert.IsNotEmpty(message);
        }

        [Test]
        public void DefaultEndDateSetToTheEndOfTheCurrentDay()
        {
            DateTime validDate = DateTime.Today.GetEndOfDay();
            DateTime invalidDate = validDate.AddSeconds(1);
            var fakeObjectToValidate = new FakeObjectToValidate { NullableDateTime = invalidDate };

            IValidationRule<FakeObjectToValidate> rule = new DateMustBeInRangeRule<FakeObjectToValidate>(
                f => f.NullableDateTime, "Nullable DateTime");

            Assert.IsFalse(rule.IsValid(fakeObjectToValidate));
            fakeObjectToValidate.NullableDateTime = validDate;
            Assert.IsTrue(rule.IsValid(fakeObjectToValidate), "The DateTime {0} {1} was supposed to validate to true.", 
                validDate.ToShortDateString(), validDate.ToShortTimeString());
        }

        [Test]
        [ExpectedException(typeof(ArgumentNullException))]
        public void ConstructorThrowsExceptionWhenGivenNullDateToValidate()
        {
            new DateMustBeInRangeRule<string>(null, string.Empty);
        }

        [Test]
        [ExpectedException(typeof(ArgumentNullException))]
        public void ConstructorThrowsExceptionWhenGivenNullPropertyName()
        {
            new DateMustBeInRangeRule<string>(s => null, null);
        }

        [Test]
        [ExpectedException(typeof(DateCannotExceedOtherDateException))]
        public void ConstructorThrowsExceptionWhenMinimumDateExceedsMaximumDate()
        {
            var maximumDate = new DateTime(2001, 1, 1);
            new DateMustBeInRangeRule<string>(s => null, string.Empty, maximumDate.AddDays(1), maximumDate);
        }
    }
}