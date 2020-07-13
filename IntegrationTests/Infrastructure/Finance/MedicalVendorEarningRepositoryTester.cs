using System;
using System.Collections.Generic;
using System.Linq;
using Falcon.App.Core;
using Falcon.App.Core.Finance.Domain;
using Falcon.App.Core.Finance.Interfaces;
using Falcon.App.Core.Impl;
using Falcon.App.Infrastructure.Repositories;
using NUnit.Framework;

namespace Falcon.Web.IntegrationTests.Infrastructure.Finance
{
    [TestFixture]
    [Ignore("The database needs to be in a steady state in order to run this test fixture.")]
    public class MedicalVendorEarningRepositoryTester
    {
        private readonly IMedicalVendorEarningRepository _medicalVendorEarningRepository = new MedicalVendorEarningRepository();
        private readonly DataRecorderMetaDataFactory _dataRecorderMetaDataFactory = new DataRecorderMetaDataFactory();

        private const long INVALID_ORGANIZATION_ROLE_USER_ID = 0;
        private const long VALID_MEDICAL_VENDOR_USER_EVENT_TEST_LOCK_ID = 1;
        private const long VALID_DATA_RECORDER_CREATOR_ID = 1;
        private const long VALID_ORGANIZATION_ROLE_USER_ID = 609;
        private readonly DateTime _defaultStartDate = new DateTime(1995, 1, 1);
        private readonly DateTime _defaultEndDate = new DateTime(2100, 1, 1);

        [Test]
        public void GetEarningsForMedicalVendorUserReturnsEarningsForValidIdWithEarnings()
        {
            List<MedicalVendorEarning> medicalVendorEarnings = _medicalVendorEarningRepository.
                GetEarningsForMedicalVendorUser(VALID_ORGANIZATION_ROLE_USER_ID, _defaultStartDate, _defaultEndDate);

            Assert.IsNotEmpty(medicalVendorEarnings);
        }

        [Test]
        public void GetEarningsForMedicalVendorUserOnlyReturnsRecordsForGivenId()
        {
            List<MedicalVendorEarning> medicalVendorEarnings = _medicalVendorEarningRepository.
                GetEarningsForMedicalVendorUser(VALID_ORGANIZATION_ROLE_USER_ID, _defaultStartDate, _defaultEndDate);

            var earningsNotForGivenUser = medicalVendorEarnings.
                Where(e => e.OrganizationRoleUserId != VALID_ORGANIZATION_ROLE_USER_ID).ToList();
            Assert.IsEmpty(earningsNotForGivenUser);
        }

        [Test]
        public void GetEarningsForMedicalVendorUserReturnsNoEarningsBeforeGivenStartDate()
        {
            var startDate = new DateTime(2009, 6, 1);
            var unfilteredEarnings = _medicalVendorEarningRepository.
                GetEarningsForMedicalVendorUser(VALID_ORGANIZATION_ROLE_USER_ID, _defaultStartDate, _defaultEndDate);
            Assert.IsTrue(unfilteredEarnings.Where(e => e.DataRecorderMetaData.DateCreated < startDate).Count() > 0,
                          string.Format("Earnings for {0} did not contain records before {1} prior to filtering.",
                                        VALID_ORGANIZATION_ROLE_USER_ID, startDate.ToShortDateString()));

            var filteredEarnings = _medicalVendorEarningRepository.
                GetEarningsForMedicalVendorUser(VALID_ORGANIZATION_ROLE_USER_ID, startDate, _defaultEndDate);
            Assert.IsEmpty(filteredEarnings.Where(e => e.DataRecorderMetaData.DateCreated < startDate).ToList(),
                           string.Format("Earnings before {0} were not filtered out.", startDate.ToShortDateString()));
        }

        [Test]
        public void GetEarningsForMedicalVendorUserReturnsNoEarningsAfterGivenEndDate()
        {
            var endDate = new DateTime(2009, 6, 1);
            var unfilteredEarnings = _medicalVendorEarningRepository.
                GetEarningsForMedicalVendorUser(VALID_ORGANIZATION_ROLE_USER_ID, _defaultStartDate, _defaultEndDate);
            Assert.IsTrue(unfilteredEarnings.Where(e => e.DataRecorderMetaData.DateCreated > endDate).Count() > 0,
                          string.Format("Earnings for {0} did not contain records after {1} prior to filtering.",
                                        VALID_ORGANIZATION_ROLE_USER_ID, endDate.ToShortDateString()));

            var filteredEarnings = _medicalVendorEarningRepository.
                GetEarningsForMedicalVendorUser(VALID_ORGANIZATION_ROLE_USER_ID, _defaultStartDate, endDate);
            Assert.IsEmpty(filteredEarnings.Where(e => e.DataRecorderMetaData.DateCreated > endDate).ToList(),
                           string.Format("Earnings after {0} were not filtered out.", endDate.ToShortDateString()));
        }

        [Test]
        public void SaveMedicalVendorEarningSavesValidEarning()
        {
            var medicalVendorEarning = new MedicalVendorEarning
            {
                OrganizationRoleUserId = VALID_ORGANIZATION_ROLE_USER_ID,
                MedicalVendorUserEventTestLockId = VALID_MEDICAL_VENDOR_USER_EVENT_TEST_LOCK_ID,
                MedicalVendorUserAmountEarned = 58.33m,
                DataRecorderMetaData = _dataRecorderMetaDataFactory.CreateDataRecorderMetaData
                (VALID_DATA_RECORDER_CREATOR_ID)
            };
            _medicalVendorEarningRepository.SaveMedicalVendorEarning(medicalVendorEarning);
        }

        [Test]
        public void GetLifetimeNumberOfEarningsAndTotalAmountEarnedForUserReturnsValuesWhenGivenValidId()
        {
            OrderedPair<int, decimal> numberOfEarningsAndAmountEarned = _medicalVendorEarningRepository.
                GetNumberOfEarningsAndTotalAmountEarnedForUser(VALID_ORGANIZATION_ROLE_USER_ID);

            Assert.AreNotEqual(0, numberOfEarningsAndAmountEarned.FirstValue);
            Assert.AreNotEqual(0m, numberOfEarningsAndAmountEarned.SecondValue);
        }

        [Test]
        public void GetLifetimeNumberOfEarningsAndTotalAmountEarnedForUserReturnsZerosWhenInvalidIdGiven()
        {
            OrderedPair<int, decimal> numberOfEarningsAndAmountEarned = _medicalVendorEarningRepository.
                GetNumberOfEarningsAndTotalAmountEarnedForUser(INVALID_ORGANIZATION_ROLE_USER_ID);

            Assert.AreEqual(0, numberOfEarningsAndAmountEarned.FirstValue);
            Assert.AreEqual(0m, numberOfEarningsAndAmountEarned.SecondValue);
        }

        [Test]
        public void GetEarningsNotInDateRangesReturnsCountGreaterThanZero()
        {
            var dateRanges = new List<OrderedPair<DateTime, DateTime>>
            {
                new OrderedPair<DateTime, DateTime>(new DateTime(2009, 6, 3), new DateTime(2009, 6, 5)),
                new OrderedPair<DateTime, DateTime>(new DateTime(2009, 7, 7), new DateTime(2009, 7, 13)),
            };

            int count = _medicalVendorEarningRepository.GetEarningsNotInDateRanges(VALID_ORGANIZATION_ROLE_USER_ID, dateRanges);

            Assert.IsTrue(count > 0);
        }

        [Test]
        public void GetNumberOfEarningsByCustomerEventTestIdReturnsTrueWhenGivenIdWithEarning()
        {
            const int idWithEarning = 680;

            bool hasEarnings = _medicalVendorEarningRepository.CustomerEventTestIdHasEarnings(idWithEarning);

            Assert.IsTrue(hasEarnings, "False returned when given ID associated with earnings.");
        }
    }
}