using System.Collections.Generic;
using Falcon.App.Core.Finance;
using Falcon.App.Core.Finance.Domain;
using Falcon.App.Infrastructure.Repositories;
using NUnit.Framework;

namespace Falcon.Web.IntegrationTests.Infrastructure.Finance
{
    [TestFixture]
    [Ignore("The database needs to be in a steady state in order to run this test fixture.")]
    public class PaymentInstrumentRepositoryTester
    {
        const long VALID_MEDICAL_VENDOR_PAYMENT_ID = 24;
        const long VALID_MEDICAL_VENDOR_INVOICE_ID = 46;
        const int ORDER_ID_WITH_PAYMENTS = 3;

        private readonly IPaymentInstrumentRepository _paymentInstrumentRepository = new CombinedPaymentInstrumentRepository();

        [Test]
        public void GetPaymentInstrumentsForPaymentReturnsInstrumentsForValidPayment()
        {
            List<PaymentInstrument> paymentInstruments = _paymentInstrumentRepository.
                GetPaymentInstrumentsForPayment(VALID_MEDICAL_VENDOR_PAYMENT_ID);

            Assert.IsNotNull(paymentInstruments);
            Assert.IsNotEmpty(paymentInstruments);
        }

        [Test]
        public void GetPaymentInstrumentsForInvoiceReturnsInstrumentsForValidInvoice()
        {
            List<PaymentInstrument> paymentInstruments = _paymentInstrumentRepository.
                GetPaymentInstrumentsForInvoice(VALID_MEDICAL_VENDOR_INVOICE_ID);

            Assert.IsNotNull(paymentInstruments);
            Assert.IsNotEmpty(paymentInstruments);
        }

        [Test]
        public void GetPaymentInstrumentsForOrderReturnsInstrumentsForValidOrder()
        {
            List<PaymentInstrument> paymentInstruments = _paymentInstrumentRepository.
                GetPaymentInstrumentsForOrder(ORDER_ID_WITH_PAYMENTS);

            Assert.IsNotNull(paymentInstruments);
            Assert.IsNotEmpty(paymentInstruments);
            Assert.AreEqual(2, paymentInstruments.Count);
        }
    }
}