using System;
using System.Collections.Generic;
using System.Linq;
using Falcon.App.Core.Domain;
using Falcon.App.Core.Finance.Domain;
using Falcon.App.Core.Finance.Interfaces;
using Falcon.App.Core.Impl;
using Falcon.App.Core.Interfaces;
using Falcon.App.Infrastructure.Repositories.Payment;
using NUnit.Framework;

namespace Falcon.Web.IntegrationTests.Infrastructure.Finance
{
    [TestFixture]
    [Ignore("The database must be in a stable state for this test to run.")]
    public class CheckPaymentRepositoryTester
    {
        private readonly ICheckPaymentRepository _checkPaymentRepository;
        private const long PAYMENT_ID_WITH_ONLY_CHECKS = 4;

        public CheckPaymentRepositoryTester()
        {
            _checkPaymentRepository = new CheckPaymentRepository();
        }

        [Test]
        public void CheckPaymentHasCheckAfterGetByPaymentId()
        {
            IEnumerable<PaymentInstrument> paymentInstruments = _checkPaymentRepository.GetByPaymentId(PAYMENT_ID_WITH_ONLY_CHECKS);
            Assert.IsNotNull(paymentInstruments);
            Assert.IsNotEmpty(paymentInstruments.ToList());
            foreach (var paymentInstrument in paymentInstruments)
            {
                var checkPayment = (CheckPayment)paymentInstrument;
                Check check = checkPayment.Check;

                Assert.AreEqual(check.Id, checkPayment.CheckId);
                Assert.IsInstanceOf<CheckPayment>(paymentInstrument);
                Assert.IsNotNull(check);
            }
        }

        [Test]
        public void CanSaveCheckPayment()
        {
            IDataRecorderMetaDataFactory metaDataFactory = new DataRecorderMetaDataFactory();
            DataRecorderMetaData metaData = metaDataFactory.CreateDataRecorderMetaData(2);

            var check = new Check {
                Amount = 200,
                Memo = "Happy Birthday!",
                CheckDate = new DateTime(1903, 6, 6),
                AccountNumber = "testtest",
                BankName = "Bank of Sans Serif",
                CheckNumber = "blue",
                DataRecorderMetaData = metaData,
                PayableTo = "Falcon",
                PaymentId = PAYMENT_ID_WITH_ONLY_CHECKS,
                RoutingNumber = "twelve"
            };

            var checkPayment = new CheckPayment {
                PaymentId = PAYMENT_ID_WITH_ONLY_CHECKS,
                Amount = check.Amount,
                DataRecorderMetaData = metaData,
                Check = check
            };

            checkPayment = (CheckPayment)_checkPaymentRepository.SavePaymentInstrument(checkPayment);

            Assert.IsNotNull(checkPayment, "Check Payment is null but should not be.");
            Assert.IsNotNull(checkPayment.Check, "Check is null but should not be.");
            Assert.AreNotEqual(0, checkPayment.Check.Id);
        }
    }
}