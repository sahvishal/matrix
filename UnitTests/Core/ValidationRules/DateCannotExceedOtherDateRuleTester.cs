using System;
using Falcon.App.Core.ValidationRules;
using HealthYes.Web.UnitTests.Fakes;
using NUnit.Framework;

namespace HealthYes.Web.UnitTests.Core.ValidationRules
{
    [TestFixture]
    public class DateCannotExceedOtherDateRuleTester
    {
        [Test]
        public void IsValidReturnsFalseWhenGivenNullObject()
        {
            var rule = new DateCannotExceedOtherDateRule<string>(s => null, string.Empty, s => null, string.Empty);

            bool isValid = rule.IsValid(null);

            Assert.IsFalse(isValid, "Null object returned true.");
        }

        [Test]
        public void IsValidReturnsTrueIfFirstDateIsNull()
        {
            var rule = new DateCannotExceedOtherDateRule<FakeObjectToValidate>(f => null, string.Empty, f => f.NullableDateTime, string.Empty);

            bool isValid = rule.IsValid(new FakeObjectToValidate {NullableDateTime = new DateTime(2001, 1, 1)});

            Assert.IsTrue(isValid, "IsValid returned false even though the first date was null.");
        }

        [Test]
        public void IsValidReturnsTrueIfSecondDateIsNull()
        {
            var rule = new DateCannotExceedOtherDateRule<FakeObjectToValidate>(f => f.NullableDateTime, string.Empty, f => null, string.Empty);

            bool isValid = rule.IsValid(new FakeObjectToValidate { NullableDateTime = new DateTime(2001, 1, 1) });

            Assert.IsTrue(isValid, "IsValid returned false even though the second date was null.");
        }

        [Test]
        public void IsValidReturnsTrueIfFirstDateIsEarlierThanSecondDate()
        {
            var date = new DateTime(2001, 1, 1);
            var rule = new DateCannotExceedOtherDateRule<FakeObjectToValidate>(f => date, string.Empty, f => date.AddDays(1), string.Empty);

            bool isValid = rule.IsValid(new FakeObjectToValidate());

            Assert.IsTrue(isValid, "IsValid returned false even though the first date was earlier than the second.");
        }

        [Test]
        public void IsValidReturnsTrueIfFirstDateMatchesSecondDate()
        {
            var date = new DateTime(2001, 1, 1);
            var rule = new DateCannotExceedOtherDateRule<FakeObjectToValidate>(f => date, string.Empty, f => date, string.Empty);

            bool isValid = rule.IsValid(new FakeObjectToValidate());

            Assert.IsTrue(isValid, "IsValid returned false even though the first date matches the second.");
        }

        [Test]
        public void IsValidReturnsFalsIfFirstDateExceedsTheSecondDate()
        {
            var date = new DateTime(2001, 1, 1);
            var rule = new DateCannotExceedOtherDateRule<FakeObjectToValidate>(f => date.AddDays(1), string.Empty, f => date, string.Empty);

            bool isValid = rule.IsValid(new FakeObjectToValidate());

            Assert.IsFalse(isValid, "IsValid returned true even though the first date was later than the second.");
        }

        [Test]
        public void GetErrorMessageReturnsMessageWhenGivenNullObject()
        {
            var rule = new DateCannotExceedOtherDateRule<FakeObjectToValidate>(f => null, string.Empty, f => null, string.Empty);

            string message = rule.GetErrorMessage(null);

            Assert.IsNotNull(message);
            Assert.IsNotEmpty(message);
        }

        [Test]
        public void GetErrorMessageReturnsMessageWhenGivenNonNullObjectWithNullDate()
        {
            var rule = new DateCannotExceedOtherDateRule<FakeObjectToValidate>(f => null, string.Empty, f => null, string.Empty);

            string message = rule.GetErrorMessage(new FakeObjectToValidate());

            Assert.IsNotNull(message);
            Assert.IsNotEmpty(message);
        }

        [Test]
        public void GetErrorMessageReturnsMessageWhenGivenNonNullObjectWithNonNullDates()
        {
            var date = new DateTime(2001, 1, 1);
            var rule = new DateCannotExceedOtherDateRule<FakeObjectToValidate>(f => date, string.Empty, f => date, string.Empty);

            string message = rule.GetErrorMessage(new FakeObjectToValidate());

            Assert.IsNotNull(message);
            Assert.IsNotEmpty(message);
        }

        [Test]
        [ExpectedException(typeof(ArgumentNullException))]
        public void ConstructorThrowsExceptionWhenNullFirstDateFunctionGiven()
        {
            new DateCannotExceedOtherDateRule<string>(null, string.Empty, s => null, string.Empty);
        }

        [Test]
        [ExpectedException(typeof(ArgumentNullException))]
        public void ConstructorThrowsExceptionWhenNullSecondDateFunctionGiven()
        {
            new DateCannotExceedOtherDateRule<string>(s => null, null, s => null, string.Empty);
        }

        [Test]
        [ExpectedException(typeof(ArgumentNullException))]
        public void ConstructorThrowsExceptionWhenNullFirstDatePropertyStringGiven()
        {
            new DateCannotExceedOtherDateRule<string>(s => null, string.Empty, null, string.Empty);
        }

        [Test]
        [ExpectedException(typeof(ArgumentNullException))]
        public void ConstructorThrowsExceptionWhenNullSecondDatePropertyStringGiven()
        {
            new DateCannotExceedOtherDateRule<string>(s => null, string.Empty, s => null, null);
        }
    }
}