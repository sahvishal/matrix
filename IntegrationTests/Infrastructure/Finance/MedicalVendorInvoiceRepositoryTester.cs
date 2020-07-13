using System;
using System.Collections.Generic;
using Falcon.App.Core;
using Falcon.App.Core.Enum;
using Falcon.App.Core.Finance.Domain;
using Falcon.App.Core.Finance.Interfaces;
using Falcon.App.Infrastructure.Repositories;
using NUnit.Framework;

namespace Falcon.Web.IntegrationTests.Infrastructure.Finance
{
    [TestFixture]
    [Ignore("The database needs to be in a steady state in order to run this test fixture.")]
    public class MedicalVendorInvoiceRepositoryTester
    {
        private readonly IMedicalVendorInvoiceRepository _repository = new MedicalVendorInvoiceRepository();

        private const long VALID_MEDICAL_VENDOR_INVOICE_ID = 2;
        private const long VALID_MEDICAL_VENDOR_ID = 1;
        private const int VALID_ORGANIZATION_ROLE_USER_ID = 588;
        private readonly Guid _validGuid = new Guid("53186473-A853-4255-A3E2-8BED61B346E2");

        [Test]
        public void GetMedicalVendorInvoiceReturnsInvoiceWhenValidIdGiven()
        {
            PhysicianInvoice medicalVendorInvoice = _repository.
                GetMedicalVendorInvoice(VALID_MEDICAL_VENDOR_INVOICE_ID);

            Assert.IsNotNull(medicalVendorInvoice);
            Assert.AreEqual(VALID_MEDICAL_VENDOR_INVOICE_ID, medicalVendorInvoice.Id);
        }

        [Test]
        public void GetMedicalVendorInvoiceReturnsInvoiceWhenValidGuidGiven()
        {
            PhysicianInvoice medicalVendorInvoice = _repository.
                GetMedicalVendorInvoice(_validGuid);

            Assert.IsNotNull(medicalVendorInvoice);
            Assert.AreEqual(_validGuid, medicalVendorInvoice.ApprovalGuid);
        }

        [Test]
        public void ChangeMedicalVendorInvoiceApprovalStatusChangesStatusOfValidId()
        {
            PhysicianInvoice medicalVendorInvoice = _repository.
                GetMedicalVendorInvoice(VALID_MEDICAL_VENDOR_INVOICE_ID);
            ApprovalStatus newStatus = medicalVendorInvoice.ApprovalStatus == ApprovalStatus.Approved ? 
                ApprovalStatus.Unapproved : ApprovalStatus.Approved;

            _repository.ChangeMedicalVendorInvoiceApprovalStatus(VALID_MEDICAL_VENDOR_INVOICE_ID, newStatus);
            medicalVendorInvoice = _repository.GetMedicalVendorInvoice(VALID_MEDICAL_VENDOR_INVOICE_ID);

            Assert.AreEqual(newStatus, medicalVendorInvoice.ApprovalStatus);
        }

        [Test]
        public void ChangeMedicalVendorInvoicePaymentStatusChangesStatusOfValidId()
        {
            PhysicianInvoice medicalVendorInvoice = _repository.
                GetMedicalVendorInvoice(VALID_MEDICAL_VENDOR_INVOICE_ID);
            PaymentStatus newStatus = medicalVendorInvoice.PaymentStatus == PaymentStatus.Paid ?
                PaymentStatus.Unpaid : PaymentStatus.Paid;
            _repository.ChangeMedicalVendorInvoicePaymentStatus(VALID_MEDICAL_VENDOR_INVOICE_ID, newStatus, DateTime.Now);
            medicalVendorInvoice = _repository.GetMedicalVendorInvoice(VALID_MEDICAL_VENDOR_INVOICE_ID);

            Assert.AreEqual(newStatus, medicalVendorInvoice.PaymentStatus);
        }

        //[Test]
        //public void GetInvoicesForMedicalVendorUserReturnsInvoiceListForValidId()
        //{
        //    MedicalVendorInvoice medicalVendorInvoice = _repository.
        //        GetMedicalVendorInvoice(VALID_MEDICAL_VENDOR_INVOICE_ID);
        //    ApprovalStatus statusToRetrieve = medicalVendorInvoice.ApprovalStatus;

        //    List<MedicalVendorInvoice> medicalVendorInvoices = _repository.
        //        GetInvoicesForMedicalVendorUser(VALID_MEDICAL_VENDOR_ID, statusToRetrieve);

        //    Assert.IsNotNull(medicalVendorInvoices);
        //    Assert.AreEqual(VALID_MEDICAL_VENDOR_ID, medicalVendorInvoices[0].MedicalVendorId);
        //}

        [Test]
        public void SaveMedicalVendorInvoicePersistsValidInvoiceToDatabase()
        {
            Guid approvalGuid = Guid.NewGuid();

            var medicalVendorInvoiceItems = new List<MedicalVendorInvoiceItem>
            {
                new MedicalVendorInvoiceItem
                {
                    MedicalVendorInvoiceId = 1,
                    MedicalVendorAmountEarned = 3.23m,
                    OrganizationRoleUserAmountEarned = 5.33m,
                    CustomerId = 6,
                    CustomerName = "CustomerName",
                    EventDate = new DateTime(2009, 3, 1),
                    EventId = 34,
                    EventName = "EventName",
                    PackageName = "PackageName",
                    PodName = "PodName",
                    ReviewDate = new DateTime(2009, 6, 1),
                    EvaluationStartTime = new DateTime(2009, 6, 1),
                    EvaluationEndTime = new DateTime(2009, 6, 2)
                }
            };
            
            var medicalVendorInvoice = new PhysicianInvoice
            {
                ApprovalGuid = approvalGuid,
                ApprovalStatus = ApprovalStatus.Unapproved,
                DateGenerated = new DateTime(2009, 6, 1),
                MedicalVendorAddress = "MedicalVendorAddress",
                MedicalVendorId = VALID_MEDICAL_VENDOR_ID,
                MedicalVendorInvoiceItems = medicalVendorInvoiceItems,
                MedicalVendorName = "MedicalVendorName",
                PhysicianId = 1,
                PhysicianName = "Bob",
                PaymentStatus = PaymentStatus.Paid,
                PayPeriodEndDate = new DateTime(2009, 6, 12),
                PayPeriodStartDate = new DateTime(2009, 6, 1)
            };
            
            _repository.SaveMedicalVendorInvoice(medicalVendorInvoice);

            PhysicianInvoice retrievedInvoice = _repository.GetMedicalVendorInvoice(approvalGuid);

            Assert.AreEqual(medicalVendorInvoice.ApprovalGuid, retrievedInvoice.ApprovalGuid);
            Assert.AreEqual(medicalVendorInvoice.PayPeriodEndDate, retrievedInvoice.PayPeriodEndDate);
            Assert.AreEqual(medicalVendorInvoice.PaymentStatus, retrievedInvoice.PaymentStatus);
        }

        [Test]
        public void HasInvoicePendingApprovalReturnsTrueWhenValidMedicalVendorInvoiceforUserExists()
        {
            bool hasPendingInvoicesToBeApproved = _repository.HasInvoicePendingApproval(VALID_ORGANIZATION_ROLE_USER_ID);
            Assert.IsTrue(hasPendingInvoicesToBeApproved);
        }

        [Test]
        public void GetMedicalVendorInvoicePayPeriodsReturnsListOfPayPeriods()
        {
            List<OrderedPair<DateTime, DateTime>> payPeriods = _repository.
                GetMedicalVendorInvoicePayPeriods(609, PaymentStatus.Paid);

            Assert.IsNotNull(payPeriods);
            Assert.IsNotEmpty(payPeriods);
        }

        [Test]
        public void GetInvoicesByPaymentStatusReturnsInvoices()
        {
            List<PhysicianInvoice> medicalVendorInvoices = _repository.
                GetInvoicesByPaymentStatus(PaymentStatus.Paid);

            Assert.IsNotNull(medicalVendorInvoices, "Null invoice collection returned.");
            Assert.IsNotEmpty(medicalVendorInvoices, "Empty invoice collection returned.");
        }

        [Test]
        public void GetInvoicesForDateRangeReturnsInvoices()
        {
            List<PhysicianInvoice> medicalVendorInvoices = _repository.
                GetInvoicesForDateRange(new DateTime(1900, 1, 1), DateTime.Today);

            Assert.IsNotNull(medicalVendorInvoices, "Null invoice collection returned.");
            Assert.IsNotEmpty(medicalVendorInvoices, "Empty invoice collection returned.");
        }

        //[Test]
        //public void GetInvoicesForMedicalVendorUserReturnsInvoices()
        //{
        //    List<MedicalVendorInvoice> medicalVendorInvoices = _repository.
        //        GetInvoicesForMedicalVendorUser(VALID_MEDICAL_VENDOR_ID, ApprovalStatus.Unapproved);

        //    Assert.IsNotNull(medicalVendorInvoices, "Null invoice collection returned.");
        //    Assert.IsNotEmpty(medicalVendorInvoices, "Empty invoice collection returned.");
        //}

        [Test]
        public void GetOldestUnapprovedInvoiceForMedicalVendorUserReturnsInvoice()
        {
            const long organizationRoleUserWithUnapprovedInvoice = 610;
            PhysicianInvoice medicalVendorInvoice = _repository.
                GetOldestUnapprovedInvoiceForMedicalVendorUser(organizationRoleUserWithUnapprovedInvoice);

            Assert.IsNotNull(medicalVendorInvoice, "Null Medical Vendor Invoice returned.");
        }
    }
}