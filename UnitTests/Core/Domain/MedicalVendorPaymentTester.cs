using System.Linq;
using Falcon.App.Core.Domain;
using Falcon.App.Core.Domain.MedicalVendors;
using Falcon.App.Core.Finance.Domain;
using NUnit.Framework;

namespace HealthYes.Web.UnitTests.Core.Domain
{
    [TestFixture]
    public class MedicalVendorPaymentTester
    {
        [Test]
        public void PaymentInstrumentsIsNotNullAndEmptyOnCreationOfNewMedicalVendorPayment()
        {
            var payment = new MedicalVendorPayment();
            Assert.IsNotNull(payment.PaymentInstruments);
            Assert.IsEmpty(payment.PaymentInstruments);
        }

        [Test]
        public void PaymentAmountReturns0WhenPaymentInstrumentsCollectionIsEmpty()
        {
            var payment = new MedicalVendorPayment();
            Assert.AreEqual(0m, payment.PaymentAmount);
        }

        [Test]
        public void PaymentAmountReturnsAmountOfSinglePaymentInstrument()
        {
            var payment = new MedicalVendorPayment();
            payment.PaymentInstruments.Add(new Check {Amount = 25m});
            decimal expectedPaymentAmount = payment.PaymentInstruments[0].Amount;

            Assert.AreEqual(expectedPaymentAmount, payment.PaymentAmount);
        }

        [Test]
        public void PaymentAmountReturnsSumOfThreePaymentInstrumentAmounts()
        {
            var payment = new MedicalVendorPayment();
            payment.PaymentInstruments.Add(new Check { Amount = 25m });
            payment.PaymentInstruments.Add(new Check { Amount = 55m });
            payment.PaymentInstruments.Add(new Check { Amount = 33m });
            decimal expectedPaymentAmount = payment.PaymentInstruments.Sum(p => p.Amount);

            Assert.AreEqual(expectedPaymentAmount, payment.PaymentAmount);
        }

        
    }
}