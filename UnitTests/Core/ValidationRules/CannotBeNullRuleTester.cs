using Falcon.App.Core.Deprecated;
using Falcon.App.Core.Interfaces;
using Falcon.App.Core.ValidationRules;
using NUnit.Framework;

namespace HealthYes.Web.UnitTests.Core.ValidationRules
{
    [TestFixture]
    public class CannotBeNullRuleTester
    {
        [Test]
        public void IsValidReturnsWhetherOrNotTheGivenPropertyIsNull()
        {
            IValidationRule<string> rule = new CannotBeNullRule<string, string>(s => s, string.Empty);
            
            bool isValid = rule.IsValid(string.Empty);
            bool isNullValid = rule.IsValid(null);
            
            Assert.IsTrue(isValid);
            Assert.IsFalse(isNullValid);
        }

        [Test]
        public void IsValidReturnsFalseWhenGivenObjectToValidateIsNull()
        {
            IValidationRule<string> rule = new CannotBeNullRule<string, string>(s => "Bob", string.Empty);

            bool isValid = rule.IsValid(null);

            Assert.IsFalse(isValid, "Null object returned true.");
        }

        [Test]
        public void GetErrorMessageReturnsStringWithTypeAndPropertyName()
        {
            const string expectedPropertyName = "String";
            string expectedString = string.Format("{0} must be provided.", expectedPropertyName);

            var rule = new CannotBeNullRule<string, string>(s => s, expectedPropertyName);

            Assert.AreEqual(expectedString, rule.GetErrorMessage(string.Empty));
        }
    }
}