using Falcon.App.Core.Finance.Domain;
using Falcon.App.Core.Finance.Enum;
using NUnit.Framework;

namespace HealthYes.Web.UnitTests.Core.Domain.Payment
{
    [TestFixture]
    public class CashPaymentTester
    {
        [Test]
        public void PaymentTypeIsCash()
        {
            PaymentType expectedPaymentType = PaymentType.Cash;

            var cashPayment = new CashPayment();

            Assert.AreEqual(expectedPaymentType, cashPayment.PaymentType, 
                "Incorrect PaymentType returned.");
        }
    }
}