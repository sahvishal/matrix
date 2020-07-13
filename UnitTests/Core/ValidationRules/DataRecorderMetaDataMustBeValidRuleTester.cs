using Falcon.App.Core.Deprecated;
using Falcon.App.Core.Interfaces;
using Falcon.App.Core.ValidationRules;
using HealthYes.Web.UnitTests.Fakes;
using NUnit.Framework;

namespace HealthYes.Web.UnitTests.Core.ValidationRules
{
    [TestFixture]
    public class DataRecorderMetaDataMustBeValidRuleTester
    {
        [Test]
        public void IsValidReturnsFalseWhenGivenNullObjectToValidate()
        {
            IValidationRule<FakeDomainObject> validationRule = new DataRecorderMetaDataMustBeValidRule<FakeDomainObject>(fake => fake.DataRecorderMetaData);

            bool isValid = validationRule.IsValid(null);

            Assert.IsFalse(isValid, "IsValid should be false if object is null.");
        }
    }
}