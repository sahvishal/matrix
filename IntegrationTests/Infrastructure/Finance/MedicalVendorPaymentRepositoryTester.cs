using System.Collections.Generic;
using Falcon.App.Core.Domain;
using Falcon.App.Core.Enum;
using Falcon.App.Core.Finance.Domain;
using Falcon.App.Core.Finance.Interfaces;
using Falcon.App.Core.Impl;
using Falcon.App.Infrastructure.Repositories;
using NUnit.Framework;

namespace Falcon.Web.IntegrationTests.Infrastructure.Finance
{
    [TestFixture]
    [Ignore("The database needs to be in a steady state in order to run this test fixture.")]
    public class MedicalVendorPaymentRepositoryTester
    {
        private readonly IMedicalVendorPaymentRepository _medicalVendorPaymentRepository = new MedicalVendorPaymentRepository();
        private readonly DataRecorderMetaDataFactory _dataRecorderMetaDataFactory = new DataRecorderMetaDataFactory();

        private const long VALID_ORGANIZATION_ROLE_USER = 1;
        private const long VALID_MEDICAL_VENDOR_INVOICE_ID = 856;

        [Test]
        public void MakePaymentPersistsPaymentToStorageWhenEverythingIsValid()
        {
            DataRecorderMetaData dataRecorderMetaData = _dataRecorderMetaDataFactory.
                CreateDataRecorderMetaData(VALID_ORGANIZATION_ROLE_USER);

            var check = new Check
            {
                DataRecorderMetaData = dataRecorderMetaData,
                Amount = 5.01m,
                PayableTo = "PayableTo"
            };

            var medicalVendorPayment = new MedicalVendorPayment
            {
                DataRecorderMetaData = dataRecorderMetaData,
                PaymentStatus = PaymentStatus.Unpaid,
            };
            medicalVendorPayment.PaymentInstruments.Add(check);
            var medicalVendorInvoiceIdsToApplyPaymentTo = new List<long> {VALID_MEDICAL_VENDOR_INVOICE_ID};

            _medicalVendorPaymentRepository.MakePayment(medicalVendorPayment, medicalVendorInvoiceIdsToApplyPaymentTo);
        }
    }
}