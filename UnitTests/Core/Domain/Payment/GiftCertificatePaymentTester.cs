using Falcon.App.Core.Finance.Domain;
using Falcon.App.Core.Finance.Enum;
using NUnit.Framework;

namespace HealthYes.Web.UnitTests.Core.Domain.Payment
{
    [TestFixture]
    public class GiftCertificatePaymentTester
    {
        [Test]
        public void GiftCertificatePaymentTypeIsGiftCertificate()
        {
            PaymentType expectedPaymentType = PaymentType.GiftCertificate;

            var giftCertificatePayment = new GiftCertificatePayment();

            Assert.AreEqual(expectedPaymentType, giftCertificatePayment.PaymentType, "Incorrect PaymentType returned.");
        }
    }
}