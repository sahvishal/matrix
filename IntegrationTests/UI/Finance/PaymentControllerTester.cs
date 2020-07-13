using System;
using System.Collections.Generic;
using Falcon.App.Core.Domain;
using Falcon.App.Core.Finance.Domain;
using Falcon.App.Core.Finance.Interfaces;
using Falcon.App.Core.Users.Domain;
using Falcon.App.DependencyResolution;
using Falcon.App.Infrastructure.Finance.Impl;
using NUnit.Framework;

namespace Falcon.Web.IntegrationTests.UI.Finance
{
    [TestFixture]
    [Ignore("Temporarily ignoring test")]
    public class PaymentControllerTester
    {
        [Test]
        [ExpectedException(typeof(InvalidOperationException))]
        public void SavePaymentThrowsExceptionWhenNullListProvided()
        {
            IPaymentController paymentController = IoC.Resolve<PaymentController>(); 
            const List<PaymentInstrument> paymentInstruments = null;
            paymentController.SavePayment(paymentInstruments, "shouldn't save", 1);
        }

        [Test]
        [ExpectedException(typeof(InvalidOperationException))]
        public void SavePaymentThrowsExceptionWhenEmptyListProvided()
        {
            IPaymentController paymentController = IoC.Resolve<PaymentController>();
            var paymentInstruments = new List<PaymentInstrument>();
            paymentController.SavePayment(paymentInstruments, "shouldn't save", 1);
        }

        [Test]
        public void SavePaymentSavesPaymentWithOnePaymentInstrument()
        {
            IPaymentController paymentController = IoC.Resolve<PaymentController>();

            var check = new Check
            {
                AccountNumber = "asdfsadf",
                Amount = 12.00m,
                BankName = "Bank Yes",
                CheckDate = DateTime.Now,
                CheckNumber = "123",
                Memo = "Payment in full",
                PayableTo = "ABC Company",
                DataRecorderMetaData =
                    new DataRecorderMetaData {DataRecorderCreator = new OrganizationRoleUser(1), DateCreated = DateTime.Now}
            };

            var checkPayment = new CheckPayment()
            {
                Amount = check.Amount,
                Check = check
            };            

            var paymentInstruments = new List<PaymentInstrument>{checkPayment};

            long paymentId = paymentController.SavePayment(paymentInstruments, "should save", 1);

            Assert.Greater(paymentId, 0, "PaymentId must be >= 0");
        }
    }
}