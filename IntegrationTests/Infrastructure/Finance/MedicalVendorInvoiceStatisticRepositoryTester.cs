using System;
using System.Collections.Generic;
using System.Linq;
using Falcon.App.Core.Enum;
using Falcon.App.Core.Finance.Domain;
using Falcon.App.Infrastructure.Repositories;
using NUnit.Framework;
using EnumerableExtensions = Falcon.App.Core.Extensions.EnumerableExtensions;

namespace Falcon.Web.IntegrationTests.Infrastructure.Finance
{
    [TestFixture]
    [Ignore("The database needs to be in a steady state in order to run this test fixture.")]
    public class MedicalVendorInvoiceStatisticRepositoryTester
    {
        private readonly MedicalVendorInvoiceStatisticRepository _repository =
            new MedicalVendorInvoiceStatisticRepository();
        private const long VALID_MEDICAL_VENDOR_ID = 1;
        private const long VALID_MEDICAL_VENDOR_INVOICE_ID = 69;
        private const long VALID_ORGANIZATION_ROLE_USER_ID = 609;

        [Test]
        public void GetInvoiceStatisticsForMedicalVendorUserReturnsStatisticsWhenGivenValidId()
        {
            List<MedicalVendorInvoiceStatistic> medicalVendorInvoiceStatistics = _repository.
                GetInvoiceStatisticsForMedicalVendorUser(VALID_MEDICAL_VENDOR_ID, PaymentStatus.Paid);

            Assert.IsNotNull(medicalVendorInvoiceStatistics);
        }

        [Test]
        public void GetInvoiceStatisticsForMedicalVendorUserSetsNumberOfEvaluationsToNumberGreaterThanZero()
        {
            List<MedicalVendorInvoiceStatistic> medicalVendorInvoiceStatistics = _repository.
                GetInvoiceStatisticsForMedicalVendorUser(VALID_MEDICAL_VENDOR_ID, PaymentStatus.Unpaid);

            Assert.IsNotEmpty(medicalVendorInvoiceStatistics, "No invoice statistics exist for MVUser {0}.", 
                VALID_MEDICAL_VENDOR_ID);
            foreach (MedicalVendorInvoiceStatistic medicalVendorInvoiceStatistic in medicalVendorInvoiceStatistics)
            {
                Assert.IsTrue(medicalVendorInvoiceStatistic.NumberOfEvaluations > 0);
            }
        }

        [Test]
        public void GetInvoiceStatisticsForMedicalVendorUserReturnsStatistics()
        {
            
            List<MedicalVendorInvoiceStatistic> medicalVendorInvoiceStatistics = _repository.
                GetInvoiceStatisticsForMedicalVendorUser(VALID_ORGANIZATION_ROLE_USER_ID, new DateTime(1900, 1, 1), DateTime.Today, 1, 900);

            Assert.IsNotNull(medicalVendorInvoiceStatistics, "Invalid collection of Medical Vendor Invoice Statistics returned.");
            Assert.IsNotEmpty(medicalVendorInvoiceStatistics, "Empty collection fo Medical Vendor Invoice Statistics returned.");
        }

        [Test]
        public void GetInvoiceStatisticsByPaymentStatusOnlyReturnsStatisticsWithGivenPaymentStatus()
        {
            PaymentStatus paymentStatus = PaymentStatus.Unpaid;
            for (int i = 0; i < 2; i++)
            {
                List<MedicalVendorInvoiceStatistic> medicalVendorInvoiceStatistics = _repository.
                    GetInvoiceStatisticsByPaymentStatus(paymentStatus);
                Assert.IsNotEmpty(medicalVendorInvoiceStatistics, "No records were returned.");
                Assert.IsTrue(EnumerableExtensions.IsEmpty(medicalVendorInvoiceStatistics.Where(mvis => mvis.PaymentStatus != paymentStatus)),
                    "Invoice statistics that were not marked as {0} were returned.", paymentStatus);
                paymentStatus = PaymentStatus.Paid;
            }
        }

        [Test]
        public void GetInvoiceStatisticReturnsInvoiceStatisticWhenGivenValidInvoiceId()
        {
            MedicalVendorInvoiceStatistic medicalVendorInvoiceStatistic = 
                _repository.GetInvoiceStatistic(VALID_MEDICAL_VENDOR_INVOICE_ID);

            Assert.IsNotNull(medicalVendorInvoiceStatistic);
            Assert.AreEqual(VALID_MEDICAL_VENDOR_INVOICE_ID, medicalVendorInvoiceStatistic.Id);
        }

        [Test]
        public void GetAllInvoiceStatisticsReturnsStatisticsWhenStatisticsExistInTheDatabase()
        {
            List<MedicalVendorInvoiceStatistic> medicalVendorInvoiceStatistics = 
                _repository.GetAllInvoiceStatistics();

            Assert.IsNotNull(medicalVendorInvoiceStatistics);
            Assert.IsNotEmpty(medicalVendorInvoiceStatistics, "No medical vendor invoice statistics were returned.");
        }

        [Test]
        public void GetInvoiceStatisticsForMedicalVendorReturnsStatistics()
        {
            List<MedicalVendorInvoiceStatistic> medicalVendorInvoiceStatistics = _repository.
                GetInvoiceStatisticsForMedicalVendor(VALID_MEDICAL_VENDOR_ID, new DateTime(1900, 1, 1), DateTime.Today, 1, 900);

            Assert.IsNotNull(medicalVendorInvoiceStatistics, "Null collection of Medical Vendor Invoice Statstics returned.");
            Assert.IsNotEmpty(medicalVendorInvoiceStatistics, "Empty collection of Medical Vendor Invoice Statstics returned.");
        }

        [Test]
        public void GetNumberOfInvoiceStatisticsForMedicalVendorUserReturnsNumberGreaterThan0()
        {
            int numberOfInvoiceStatistics = _repository.
                GetNumberOfInvoiceStatisticsForMedicalVendorUser(VALID_ORGANIZATION_ROLE_USER_ID, new DateTime(1900, 1, 1), DateTime.Today);

            Assert.IsTrue(numberOfInvoiceStatistics > 0, "Number of Medical Vendor Invoice Statistics found was 0.");
        }

        [Test]
        public void GetNumberOfInvoiceStatisticsForMedicalVendorReturnsNumberGreaterThan0()
        {
            int numberOfInvoiceStatistics = _repository.
                GetNumberOfInvoiceStatisticsForMedicalVendor(VALID_MEDICAL_VENDOR_ID, new DateTime(1900, 1, 1), DateTime.Today);

            Assert.IsTrue(numberOfInvoiceStatistics > 0, "Number of Medical Vendor Invoice Statistics found was 0.");
        }
    }
}