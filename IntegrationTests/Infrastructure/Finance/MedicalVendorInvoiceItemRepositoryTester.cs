using System;
using System.Collections.Generic;
using Falcon.App.Core.Finance.Domain;
using Falcon.App.Core.Finance.Interfaces;
using Falcon.App.Infrastructure.Repositories;
using NUnit.Framework;

namespace Falcon.Web.IntegrationTests.Infrastructure.Finance
{
    [TestFixture]
    [Ignore("The database needs to be in a steady state in order to run this test fixture.")]
    public class MedicalVendorInvoiceItemRepositoryTester
    {
        const long INVALID_MEDICAL_VENDOR_MEDICAL_VENDOR_USER_ID = 0;
        const long VALID_MEDICAL_VENDOR_MEDICAL_VENDOR_USER_ID = 607;
        private readonly IMedicalVendorInvoiceItemRepository _medicalVendorInvoiceItemRepository
            = new MedicalVendorInvoiceItemRepository();

        [Test]
        public void GetMedicalVendorInvoiceItemsReturnsEmptyListWhenInvalidIdGiven()
        {
            List<MedicalVendorInvoiceItem> medicalVendorInvoiceItems =  _medicalVendorInvoiceItemRepository.
                GetMedicalVendorInvoiceItems(INVALID_MEDICAL_VENDOR_MEDICAL_VENDOR_USER_ID, new DateTime(2000, 1, 1), 
                DateTime.Today);

            Assert.IsNotNull(medicalVendorInvoiceItems);
            Assert.IsEmpty(medicalVendorInvoiceItems);
        }

        [Test]
        public void GetMedicalVendorInvoiceItemsReturnsItemsWhenGivenValidIdWithItems()
        {
            List<MedicalVendorInvoiceItem> medicalVendorInvoiceItems = _medicalVendorInvoiceItemRepository.
                GetMedicalVendorInvoiceItems(VALID_MEDICAL_VENDOR_MEDICAL_VENDOR_USER_ID, new DateTime(2000, 1, 1), 
                DateTime.Today);

            Assert.IsNotEmpty(medicalVendorInvoiceItems);
        }
    }
}