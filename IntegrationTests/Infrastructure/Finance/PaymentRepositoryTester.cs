using System.Collections.Generic;
using System.Linq;
using Falcon.App.Infrastructure.Repositories.Payment;
using NUnit.Framework;

namespace Falcon.Web.IntegrationTests.Infrastructure.Finance
{
    [TestFixture]
    [Ignore("The database must be in a stable state to run these tests.")]
    public class PaymentRepositoryTester
    {
        private PaymentRepository _paymentRepository;

        private const long ORDER_ID = 3;
        private readonly List<long> _expectedPaymentIds = new List<long> {5, 7};

        [SetUp]
        public void SetUp()
        {
            _paymentRepository = new PaymentRepository();
        }

        [Test]
        public void PaymentRepositoryCanFetchPaymentById()
        {
            var payment = _paymentRepository.GetById(_expectedPaymentIds[0]);

            Assert.IsNotNull(payment);
            Assert.AreEqual(_expectedPaymentIds[0], payment.Id);
        }

        [Test]
        public void PaymentRepositoryCanFetchPaymentsByOrderId()
        {
            var payments = _paymentRepository.GetByOrderId(ORDER_ID);
            var paymentIds = payments.Select(payment => payment.Id).ToList();

            Assert.AreEqual(_expectedPaymentIds, paymentIds);
        }
    }
}