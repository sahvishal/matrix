using System;
using System.Collections.Generic;
using System.Linq;
using Falcon.App.Core.Finance.Domain;
using Falcon.App.Core.Finance.Interfaces;
using Falcon.App.Infrastructure.Repositories.Payment;
using NUnit.Framework;

namespace Falcon.Web.IntegrationTests.Infrastructure.Finance
{
    [TestFixture]
    [Ignore("The database must be in a stable state to run these tests.")]
    public class CombinedPaymentInstrumentRepositoryTester
    {
        private const long PAYMENT_ID = 5;
        private readonly ICombinedPaymentInstrumentRepository _repository = new CombinedPaymentInstrumentRepository();

        private Dictionary<Type, int> _expectedCounts = new Dictionary<Type, int>()
        {
            {typeof(GiftCertificatePayment), 1},
            {typeof(CashPayment), 2}
        };

        [Test]
        public void GetForPaymentReturnsExpectNumbersOfPaymentInstrumentsForPayment()
        {
            IEnumerable<PaymentInstrument> instruments = _repository.GetByPaymentId(PAYMENT_ID);

            int totalCount = _expectedCounts.Select(eC => eC.Value).Sum();

            Assert.AreEqual(totalCount, instruments.Count());

            foreach (Type type in _expectedCounts.Keys)
            {
                if (_expectedCounts[type] != instruments.Count(instrument => instrument.GetType() == type))
                {
                    Assert.Fail("Count mismatch!");
                }
            }
        }

        [Test]
        public void GetForOrderReturnsExpectedNumberOfPaymentInstrumentsForOrder()
        {
            const int expectedPaymentInstrumentCount = 2;

            IEnumerable<PaymentInstrument> paymentInstruments = _repository.GetByOrderId(3);

            Assert.AreEqual(expectedPaymentInstrumentCount, paymentInstruments.Count());
        }
    }
}