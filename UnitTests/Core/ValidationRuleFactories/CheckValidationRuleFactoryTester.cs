using Falcon.App.Core.Deprecated;
using Falcon.App.Core.Finance.Domain;
using Falcon.App.Core.Finance.Impl;
using Falcon.App.Core.Impl;
using HealthYes.Web.UnitTests.Fakes;
using NUnit.Framework;

namespace Falcon.Web.UnitTests.Core.ValidationRuleFactories
{
    [TestFixture]
    public class CheckValidationRuleFactoryTester
    {
        private IValidator<PaymentInstrument> _paymentInstrumentValidator = new FakeValidator<PaymentInstrument>();
        private IValidator<Check> _checkValidator;

        private Check _check;

        [SetUp]
        public void SetUp()
        {
            _paymentInstrumentValidator = new FakeValidator<PaymentInstrument>();
            _checkValidator = new Validator<Check>(new CheckValidationRuleFactory(_paymentInstrumentValidator));
            _check = GetValidCheck();
        }

        [TearDown]
        public void TearDown()
        {
            _check = null;
        }

        private static Check GetValidCheck()
        {
            return new Check
            {
                Amount = 5.04m,
                PayableTo = "PayableTo",
            };
        }

        [Test]
        public void IsValidReturnsFalseWhenPayableToIsNull()
        {
            _check.PayableTo = null;
            
            bool isValid = _checkValidator.IsValid(_check);
            
            Assert.IsFalse(isValid);
        }

        [Test]
        public void IsValidReturnsFalseWhenPayableToIsEmpty()
        {
            _check.PayableTo = string.Empty;

            bool isValid = _checkValidator.IsValid(_check);

            Assert.IsFalse(isValid);
        }

        [Test]
        public void IsValidReturnsTrueWhenPayableToHasValue()
        {
            _check.PayableTo = "PayableTo";

            bool isValid = _checkValidator.IsValid(_check);

            Assert.IsTrue(isValid);
        }

        [Test]
        public void IsValidReturnsTrueWhenPaymentInstrumentValidatorReturnsTrue()
        {
            ((FakeValidator<PaymentInstrument>)_paymentInstrumentValidator).IsValidReturnValue = true;
            bool isValid = _checkValidator.IsValid(_check);

            Assert.IsTrue(isValid, "IsValid returned false even though payment instrument validator returned true.");
        }

        [Test]
        public void IsValidReturnsFalseWhenPaymentInstrumentValidatorReturnsFalse()
        {
            ((FakeValidator<PaymentInstrument>)_paymentInstrumentValidator).IsValidReturnValue = false;
            bool isValid = _checkValidator.IsValid(_check);

            Assert.IsFalse(isValid, "IsValid returned true even though payment instrument validator returned false.");
        }
    }
}