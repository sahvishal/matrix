using Falcon.App.Core.Deprecated;
using Falcon.App.Core.Finance.Domain;
using Falcon.App.Core.Finance.Impl;
using Falcon.App.Core.Impl;
using HealthYes.Web.UnitTests.Fakes;
using NUnit.Framework;

namespace HealthYes.Web.UnitTests.Core.ValidationRuleFactories
{
    [TestFixture]
    public class CheckPaymentValidationRuleFactoryTester
    {
        private IValidator<CheckPayment> _checkPaymentValidator;
        private IValidator<PaymentInstrument> _paymentInstrumentValidator;
        private IValidator<Check> _checkValidator;

        private CheckPayment _checkPayment;

        [SetUp]
        public void SetUp()
        {
            _paymentInstrumentValidator = new FakeValidator<PaymentInstrument>();
            _checkValidator = new FakeValidator<Check>();
            _checkPaymentValidator = new Validator<CheckPayment>(new CheckPaymentValidationRuleFactory(_checkValidator, _paymentInstrumentValidator));
            _checkPayment = GetValidCheckPayment();
        }

        [TearDown]
        public void TearDown()
        {
            _checkPayment = null;
        }

        private static CheckPayment GetValidCheckPayment()
        {
            return new CheckPayment
            {
                Amount = 5.04m,
            };
        }

        [Test]
        public void IsValidReturnsTrueWhenCheckValidatorReturnsTrue()
        {
            ((FakeValidator<Check>)_checkValidator).IsValidReturnValue = true;

            bool isValid = _checkPaymentValidator.IsValid(_checkPayment);

            Assert.IsTrue(isValid, "IsValid returned false even though the check validator returned true.");
        }

        [Test]
        public void IsValidReturnsFalseWhenCheckValidatorReturnsFalse()
        {
            ((FakeValidator<Check>)_checkValidator).IsValidReturnValue = false;

            bool isValid = _checkPaymentValidator.IsValid(_checkPayment);

            Assert.IsFalse(isValid, "IsValid returned true even though the check validator returned false.");
        }

        [Test]
        public void IsValidReturnsTrueWhenPaymentInstrumentValidatorReturnsTrue()
        {
            ((FakeValidator<PaymentInstrument>)_paymentInstrumentValidator).IsValidReturnValue = true;

            bool isValid = _checkPaymentValidator.IsValid(_checkPayment);

            Assert.IsTrue(isValid, "IsValid returned false even though payment instrument validator returned true.");
        }

        [Test]
        public void IsValidReturnsFalseWhenPaymentInstrumentValidatorReturnsFalse()
        {
            ((FakeValidator<PaymentInstrument>)_paymentInstrumentValidator).IsValidReturnValue = false;

            bool isValid = _checkPaymentValidator.IsValid(_checkPayment);

            Assert.IsFalse(isValid, "IsValid returned true even though payment instrument validator returned false.");
        }
    }
}