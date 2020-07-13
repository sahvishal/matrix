using System;
using System.Collections.Generic;
using Falcon.App.Core.Deprecated;
using Falcon.App.Core.Interfaces;
using Falcon.App.Core.ValidationRules;
using HealthYes.Web.UnitTests.Fakes;
using NUnit.Framework;
using Rhino.Mocks;

namespace HealthYes.Web.UnitTests.Core.ValidationRules
{
    [TestFixture]
    public class CollectionMustBeValidRuleTester
    {
        private MockRepository _mocks;
        private IValidationRule<string> _mockedValidationRule;
        private IValidationRule<FakeObjectToValidate> _collectionRule;
        private IValidationErrorMessageFormatter<string> _mockedFormatter;

        [SetUp]
        public void SetUp()
        {
            _mocks = new MockRepository();
            _mockedValidationRule = _mocks.StrictMock<IValidationRule<string>>();
            _mockedFormatter = _mocks.StrictMock<IValidationErrorMessageFormatter<string>>();
            _collectionRule = new CollectionMustBeValidRule<FakeObjectToValidate, string>(i => i.ListOfStrings,
                _mockedValidationRule, _mockedFormatter);
        }

        [TearDown]
        public void TearDown()
        {
            _mocks = null;
        }

        [Test]
        [ExpectedException(typeof(ArgumentNullException))]
        public void ConstructorThrowsExceptionWhenNullCollectionToValidateFunctionGiven()
        {
            new CollectionMustBeValidRule<string, string>(null, _mockedValidationRule);
        }

        [Test]
        [ExpectedException(typeof(ArgumentNullException))]
        public void ConstructorThrowsExceptionWhenNullValidationRuleGiven()
        {
            new CollectionMustBeValidRule<string, string>(i => new List<string>(), null);
        }

        [Test]
        [ExpectedException(typeof(ArgumentNullException))]
        public void ConstructorThrowsExceptionWhenNullFormatterGiven()
        {
            new CollectionMustBeValidRule<string, string>(i => new List<string>(), _mockedValidationRule, null);
        }

        [Test]
        public void IsValidReturnsFalseWhenNullObjectProvided()
        {
            bool isValid = _collectionRule.IsValid(null);

            Assert.IsFalse(isValid, "True returned for null object.");
        }

        [Test]
        public void IsValidReturnsTrueWhenObjectGivenHasEmptyCollectionOfObjectsToValidate()
        {
            bool isValid = _collectionRule.IsValid(new FakeObjectToValidate());

            Assert.IsTrue(isValid, "False returned for object containing empty collection.");
        }

        [Test]
        public void IsValidReturnsTrueWhenSingleObjectValidatesToTrue()
        {
            const string stringToValidate = "Foo";

            var fake = new FakeObjectToValidate { ListOfStrings = new List<string> {stringToValidate} };

            Expect.Call(_mockedValidationRule.IsValid(stringToValidate)).Return(true);

            _mocks.ReplayAll();
            bool isValid = _collectionRule.IsValid(fake);
            _mocks.VerifyAll();

            Assert.IsTrue(isValid, "False returned for object single valid object.");
        }

        [Test]
        public void IsValidReturnsFalseWhenSingleObjectValidatesToFalse()
        {
            const string stringToValidate = "Bar";
            var fake = new FakeObjectToValidate { ListOfStrings = new List<string> { stringToValidate } };

            Expect.Call(_mockedValidationRule.IsValid(stringToValidate)).Return(false);
            Expect.Call(_mockedValidationRule.GetErrorMessage(stringToValidate)).Return(string.Empty);

            _mocks.ReplayAll();
            bool isValid = _collectionRule.IsValid(fake);
            _mocks.VerifyAll();

            Assert.IsFalse(isValid, "True returned for object single invalid object.");
        }

        [Test]
        public void IsValidReturnsTrueWhenAllItemsInCollectionAreValid()
        {
            var fake = new FakeObjectToValidate { ListOfStrings = new List<string> { "1", "2", "3" } };

            Expect.Call(_mockedValidationRule.IsValid(fake.ListOfStrings[0])).Return(true);
            Expect.Call(_mockedValidationRule.IsValid(fake.ListOfStrings[1])).Return(true);
            Expect.Call(_mockedValidationRule.IsValid(fake.ListOfStrings[2])).Return(true);

            _mocks.ReplayAll();
            bool isValid = _collectionRule.IsValid(fake);
            _mocks.VerifyAll();

            Assert.IsTrue(isValid, "False returned for object containing all valid objects.");
        }

        [Test]
        public void IsValidReturnsFalseWhenAllItemsInCollectionAreInvalid()
        {
            var fake = new FakeObjectToValidate { ListOfStrings = new List<string> { "1", "2", "3" } };

            Expect.Call(_mockedValidationRule.IsValid(fake.ListOfStrings[0])).Return(false);
            Expect.Call(_mockedValidationRule.GetErrorMessage(fake.ListOfStrings[0])).Return(string.Empty);
            Expect.Call(_mockedValidationRule.IsValid(fake.ListOfStrings[1])).Return(false);
            Expect.Call(_mockedValidationRule.GetErrorMessage(fake.ListOfStrings[1])).Return(string.Empty);
            Expect.Call(_mockedValidationRule.IsValid(fake.ListOfStrings[2])).Return(false);
            Expect.Call(_mockedValidationRule.GetErrorMessage(fake.ListOfStrings[2])).Return(string.Empty);

            _mocks.ReplayAll();
            bool isValid = _collectionRule.IsValid(fake);
            _mocks.VerifyAll();

            Assert.IsFalse(isValid, "True returned for object containing all invalid objects.");
        }

        [Test]
        public void IsValidReturnsFalseWhenAllButOneItemAreValid()
        {
            var fake = new FakeObjectToValidate { ListOfStrings = new List<string> { "1", "2", "3" } };

            Expect.Call(_mockedValidationRule.IsValid(fake.ListOfStrings[0])).Return(true);
            Expect.Call(_mockedValidationRule.IsValid(fake.ListOfStrings[1])).Return(true);
            Expect.Call(_mockedValidationRule.IsValid(fake.ListOfStrings[2])).Return(false);
            Expect.Call(_mockedValidationRule.GetErrorMessage(fake.ListOfStrings[2])).Return(string.Empty);

            _mocks.ReplayAll();
            bool isValid = _collectionRule.IsValid(fake);
            _mocks.VerifyAll();

            Assert.IsFalse(isValid, "True returned for object containing an invalid object.");
        }

        [Test]
        public void GetErrorMessageReturnsMessageWhenNullObjectGiven()
        {
            string errorMessage = _collectionRule.GetErrorMessage(null);

            Assert.IsNotNull(errorMessage);
            Assert.IsNotEmpty(errorMessage);
        }
    }
}