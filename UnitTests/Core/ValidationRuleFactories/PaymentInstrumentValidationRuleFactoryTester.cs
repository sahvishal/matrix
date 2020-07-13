using Falcon.App.Core.Deprecated;
using Falcon.App.Core.Domain;
using Falcon.App.Core.Finance.Domain;
using Falcon.App.Core.Finance.Impl;
using Falcon.App.Core.Impl;
using Falcon.App.Core.Interfaces;
using HealthYes.Web.UnitTests.Fakes;
using NUnit.Framework;

namespace HealthYes.Web.UnitTests.Core.ValidationRuleFactories
{
    [TestFixture]
    public class PaymentInstrumentValidationRuleFactoryTester
    {
        private readonly IValidator<PaymentInstrument> _validator =
            new Validator<PaymentInstrument>(new PaymentInstrumentValidationRuleFactory());
        private PaymentInstrument _paymentInstrument;

        [SetUp]
        public void SetUp()
        {
            _paymentInstrument = GetValidPaymentInstrument();
        }

        [TearDown]
        public void TearDown()
        {
            _paymentInstrument = null;
        }

        private static FakePaymentInstrument GetValidPaymentInstrument()
        {
            return new FakePaymentInstrument { Amount = 1m, DataRecorderMetaData = new DataRecorderMetaData() };
        }

        [Test]
        [Ignore]
        public void IsValidReturnsTrueWhenAmountIsGreaterThan0()
        {
            for (decimal i = .01m; i <= 5m; i++)
            {
                _paymentInstrument.Amount = i;
                Assert.IsTrue(_validator.IsValid(_paymentInstrument), "Amount {0:c} returned false", i);
            }
        }

        [Test]
        [Ignore]
        public void IsValidReturnsFalseWhenAmountIs0()
        {
            _paymentInstrument.Amount = 0m;

            bool isValid = _validator.IsValid(_paymentInstrument);

            Assert.IsFalse(isValid, "PaymentInstrument valid even though payment amount is 0.");
        }

        [Test]
        [Ignore]
        public void IsValidReturnsFalseWhenAmountIsLessThan0()
        {
            for (decimal i = -.01m; i > -5m; i--)
            {
                _paymentInstrument.Amount = i;
                Assert.IsFalse(_validator.IsValid(_paymentInstrument), string.Format("{0} returned true.", i));
            }
        }

        [Test]
        public void IsValidReturnsFalseWhenDataRecorderMetaDataIsNull()
        {
            _paymentInstrument.DataRecorderMetaData = null;

            bool isValid = _validator.IsValid(_paymentInstrument);

            Assert.IsFalse(isValid, "PaymentInstrument valid even though DataRecorderMetaData is null.");
        }

        [Test]
        public void IsValidReturnsTrueWhenDataRecorderMetaDataIsNotNull()
        {
            _paymentInstrument.DataRecorderMetaData = new DataRecorderMetaData();

            bool isValid = _validator.IsValid(_paymentInstrument);

            Assert.IsTrue(isValid, "PaymentInstrument invalid even though DataRecorderMetaData is not null.");
        }
    }
}