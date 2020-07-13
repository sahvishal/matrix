using System;
using System.Collections.Generic;
using Falcon.App.Core.Finance.Domain;
using Falcon.App.Core.Finance.Interfaces;
using Falcon.App.Infrastructure.Service;
using NUnit.Framework;

namespace Falcon.Web.IntegrationTests.Infrastructure.Finance
{
    [TestFixture]
    [Ignore("The database needs to be in a steady state in order to run this test fixture.")]
    public class MedicalVendorPaymentServiceTester
    {
        // TODO: Retrieve epoch date from common location.
        readonly DateTime _payPeriodStartDate = new DateTime(2001, 1, 1);
        private const int VALID_MEDICAL_VENDOR_ID = 1;
        private const int VALID_ORGANIZATION_ROLE_USER_ID = 609;

        private readonly IMedicalVendorPaymentService _medicalVendorPaymentService = new MedicalVendorPaymentService();

        [Test]
        public void GenerateInvoiceReturnsInvoiceWhenGivenValidParameters()
        {

            PhysicianInvoice medicalVendorInvoice = _medicalVendorPaymentService.GenerateInvoice
                (VALID_MEDICAL_VENDOR_ID, VALID_ORGANIZATION_ROLE_USER_ID,
                _payPeriodStartDate, DateTime.Now);

            Assert.IsNotNull(medicalVendorInvoice);
        }

        [Test]
        public void GenerateInvoicesForMedicalVendorReturnsInvoicesWhenGivenValidVendorId()
        {
            List<PhysicianInvoice> medicalVendorInvoices = _medicalVendorPaymentService.
                GenerateInvoicesForMedicalVendor(VALID_MEDICAL_VENDOR_ID, _payPeriodStartDate, DateTime.Now);

            Assert.IsNotNull(medicalVendorInvoices);
            Assert.IsNotEmpty(medicalVendorInvoices);
        }
    }
}