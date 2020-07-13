using Falcon.App.Core.Finance.Domain;
using Falcon.App.Core.Finance.Enum;
using NUnit.Framework;

namespace HealthYes.Web.UnitTests.Core.Domain.Payment
{
    [TestFixture]
    public class ChargeCardPaymentTester
    {
        [Test]
        public void PaymentTypeIsCreditCard()
        {
            PaymentType expectedPaymentType = PaymentType.CreditCard;

            var chargeCardPayment = new ChargeCardPayment();

            Assert.AreEqual(expectedPaymentType, chargeCardPayment.PaymentType,
                "Incorrect PaymentType returned.");
        }
    }
}