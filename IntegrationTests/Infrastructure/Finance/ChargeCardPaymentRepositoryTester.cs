using System.Collections.Generic;
using Falcon.App.Core.Extensions;
using Falcon.App.Core.Finance.Domain;
using Falcon.App.Infrastructure.Repositories.Payment;
using NUnit.Framework;

namespace Falcon.Web.IntegrationTests.Infrastructure.Finance
{
    [TestFixture]
    [Ignore("The database must be in a steady state to run these tests.")]
    public class ChargeCardPaymentRepositoryTester
    {
        private const long CHARGE_CARD_PAYMENT_ID = 1;
        private const long CHARGE_CARD_PAYMENT_PAYMENT_ID = 3;

        private ChargeCardPaymentRepository _repository;
            
        [SetUp]        
        public void SetUp()
        {
            _repository = new ChargeCardPaymentRepository();
        }        

        [Test]
        public void GetByIdReturnsExpectedChargeCardPayment()
        {
            ChargeCardPayment chargeCardPayment = _repository.GetById(CHARGE_CARD_PAYMENT_ID);

            Assert.AreEqual(CHARGE_CARD_PAYMENT_ID, chargeCardPayment.Id);
        }

        [Test]
        public void GetByPaymentIdReturnsListOfOneChargeCard()
        {
            IEnumerable<PaymentInstrument> payments = _repository.GetByPaymentId(CHARGE_CARD_PAYMENT_PAYMENT_ID);
            const int expectedCount = 1;

            Assert.AreEqual(expectedCount, payments.Count());
        }
    }
}