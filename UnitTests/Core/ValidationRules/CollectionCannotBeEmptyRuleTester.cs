using System;
using System.Collections.Generic;
using Falcon.App.Core.Deprecated;
using Falcon.App.Core.Interfaces;
using Falcon.App.Core.ValidationRules;
using HealthYes.Web.UnitTests.Fakes;
using NUnit.Framework;

namespace HealthYes.Web.UnitTests.Core.ValidationRules
{
    [TestFixture]
    public class CollectionCannotBeEmptyRuleTester
    {
        [Test]
        public void IsValidReturnsFalseWhenGivenNullObject()
        {
            IValidationRule<FakeObjectToValidate> rule = new CollectionCannotBeEmptyRule<FakeObjectToValidate, string>
                (f => f.ListOfStrings, "list");

            bool isValid = rule.IsValid(null);

            Assert.IsFalse(isValid, "IsValid returned true for null object.");
        }

        [Test]
        public void IsValidReturnsFalseWhenGivenCollectionIsNull()
        {
            IValidationRule<FakeObjectToValidate> rule = new CollectionCannotBeEmptyRule<FakeObjectToValidate, string>
                (f => f.ListOfStrings, "list");

            bool isValid = rule.IsValid(new FakeObjectToValidate());

            Assert.IsFalse(isValid, "IsValid returned true for null collection.");
        }

        [Test]
        public void IsValidReturnsTrueForCollectionThatIsNotEmpty()
        {
            IValidationRule<FakeObjectToValidate> rule = new CollectionCannotBeEmptyRule<FakeObjectToValidate, string>
                (f => f.ListOfStrings, "list");

            bool isValid = rule.IsValid(new FakeObjectToValidate {ListOfStrings = new List<string> {"3"}});

            Assert.IsTrue(isValid, "IsValid returned false for non-empty collection.");
        }

        [Test]
        public void IsValidReturnsFalseForEmptyCollection()
        {
            IValidationRule<FakeObjectToValidate> rule = new CollectionCannotBeEmptyRule<FakeObjectToValidate, string>
                (f => f.ListOfStrings, "list");

            bool isValid = rule.IsValid(new FakeObjectToValidate { ListOfStrings = new List<string>() });

            Assert.IsFalse(isValid, "IsValid returned false for empty collection.");
        }

        [Test]
        public void GetErrorMessageReturnsMessageWhenNullObjectGiven()
        {
            IValidationRule<FakeObjectToValidate> rule = new CollectionCannotBeEmptyRule<FakeObjectToValidate, string>
                (f => f.ListOfStrings, "list");

            string errorMessage = rule.GetErrorMessage(null);

            Assert.IsNotNull(errorMessage);
            Assert.IsNotEmpty(errorMessage);
        }

        [Test]
        public void GetErrorMessageReturnsMessageWhenNonNullObjectGiven()
        {
            IValidationRule<FakeObjectToValidate> rule = new CollectionCannotBeEmptyRule<FakeObjectToValidate, string>
                (f => f.ListOfStrings, "list");

            string errorMessage = rule.GetErrorMessage(new FakeObjectToValidate());

            Assert.IsNotNull(errorMessage);
            Assert.IsNotEmpty(errorMessage);
        }

        [Test]
        [ExpectedException(typeof(ArgumentNullException))]
        public void ConstructorThrowsExceptionWhenNullFunctionGiven()
        {
            new CollectionCannotBeEmptyRule<FakeObjectToValidate, string>(null, string.Empty);
        }

        [Test]
        [ExpectedException(typeof(ArgumentNullException))]
        public void ConstructorThrowsExceptionWhenNullPropertyNameGiven()
        {
            new CollectionCannotBeEmptyRule<FakeObjectToValidate, string>(f => f.ListOfStrings, null);
        }
    }
}