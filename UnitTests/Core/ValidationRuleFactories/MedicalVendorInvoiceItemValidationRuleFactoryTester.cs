using System;
using Falcon.App.Core.Deprecated;
using Falcon.App.Core.Domain.MedicalVendors;
using Falcon.App.Core.Finance.Domain;
using Falcon.App.Core.Finance.Impl;
using Falcon.App.Core.Impl;
using Falcon.App.Core.Interfaces;
using NUnit.Framework;

namespace HealthYes.Web.UnitTests.Core.ValidationRuleFactories
{
    [TestFixture]
    public class MedicalVendorInvoiceItemValidationRuleFactoryTester
    {
        // TODO: Retrieve epoch date from common location.
        private readonly DateTime _minimumDate = new DateTime(1900, 1, 1);
        private readonly IValidator<MedicalVendorInvoiceItem> _validator =
            new Validator<MedicalVendorInvoiceItem>(new MedicalVendorInvoiceItemValidationRuleFactory());

        private MedicalVendorInvoiceItem _medicalVendorInvoiceItem;

        [SetUp]
        public void SetUp()
        {
            _medicalVendorInvoiceItem = GetValidMedicalVendorInvoiceItem();
        }

        [TearDown]
        public void TearDown()
        {
            _medicalVendorInvoiceItem = null;
        }

        private MedicalVendorInvoiceItem GetValidMedicalVendorInvoiceItem()
        {
            return new MedicalVendorInvoiceItem(1)
            {
                MedicalVendorInvoiceId = 1,
                ReviewDate = _minimumDate.AddDays(1),
                MedicalVendorAmountEarned = 100m,
                OrganizationRoleUserAmountEarned = 100m,
                CustomerId = 1,
                CustomerName = "CustomerName",
                EventId = 1,
                EventName = "EventName",
                EventDate = _minimumDate.AddDays(1),
                PodName = "PodName",
                PackageName = "PackageName",
                EvaluationStartTime = _minimumDate.AddDays(1),
                EvaluationEndTime = _minimumDate.AddDays(2)
            };
        }

        [Test]
        public void IsValidReturnsFalseWhenMedicalVendorInvoiceIdIsLessThanOrEqualTo0()
        {
            _medicalVendorInvoiceItem.MedicalVendorInvoiceId = 0;
            Assert.IsFalse(_validator.IsValid(_medicalVendorInvoiceItem));

            _medicalVendorInvoiceItem.MedicalVendorInvoiceId--;
            Assert.IsFalse(_validator.IsValid(_medicalVendorInvoiceItem));
        }

        [Test]
        public void IsValidReturnsTrueWhenMedicalVendorInvoiceIdIsGreaterThan0()
        {
            _medicalVendorInvoiceItem.MedicalVendorInvoiceId = 1;
            Assert.IsTrue(_validator.IsValid(_medicalVendorInvoiceItem));
        }

        [Test]
        public void IsValidReturnsFalseWhenReviewDateIsBeforeEventDate()
        {
            _medicalVendorInvoiceItem.ReviewDate = _medicalVendorInvoiceItem.EventDate.AddDays(-1);
            Assert.IsFalse(_validator.IsValid(_medicalVendorInvoiceItem));
        }

        [Test]
        public void IsValidReturnsTrueWhenReviewDateIsOnOrAfterEventDate()
        {
            _medicalVendorInvoiceItem.ReviewDate = _medicalVendorInvoiceItem.EventDate;
            Assert.IsTrue(_validator.IsValid(_medicalVendorInvoiceItem));

            _medicalVendorInvoiceItem.ReviewDate = _medicalVendorInvoiceItem.EventDate.AddDays(1);
            Assert.IsTrue(_validator.IsValid(_medicalVendorInvoiceItem));
        }

        [Test]
        public void IsValidReturnsFalseWhenMedicalVendorAmountEarnedIsLessThan0()
        {
            _medicalVendorInvoiceItem.MedicalVendorAmountEarned = -.01m;
            Assert.IsFalse(_validator.IsValid(_medicalVendorInvoiceItem));
        }

        [Test]
        public void IsValidReturnsTrueWhenMedicalVendorAmountEarnedIsZero()
        {
            _medicalVendorInvoiceItem.MedicalVendorAmountEarned = 0m;
            Assert.IsTrue(_validator.IsValid(_medicalVendorInvoiceItem));
        }

        [Test]
        public void IsValidReturnsTrueWhenMedicalVendorAmountEarnedIsLessThan100()
        {
            for (decimal i = .01m; i < 99.99m; i += .01m)
            {
                _medicalVendorInvoiceItem.MedicalVendorAmountEarned = i;
                Assert.IsTrue(_validator.IsValid(_medicalVendorInvoiceItem), string.Format("{0:c} did not return true.", i));
            }
        }

        [Test]
        public void IsValidReturnsTrueWhenMedicalVendorAmountEarnedIs100()
        {
            _medicalVendorInvoiceItem.MedicalVendorAmountEarned = 100m;
            Assert.IsTrue(_validator.IsValid(_medicalVendorInvoiceItem));
        }

        [Test]
        public void IsValidReturnsTrueWhenMedicalVendorAmountEarnedIsGreaterThan100()
        {
            for (decimal i = 100.01m; i < 110m; i += .01m)
            {
                _medicalVendorInvoiceItem.MedicalVendorAmountEarned = i;
                Assert.IsFalse(_validator.IsValid(_medicalVendorInvoiceItem), string.Format("{0:c} did not return false.", i));
            }
        }

        [Test]
        public void IsValidReturnsFalseWhenOrganizationRoleUserAmountEarnedIsLessThan0()
        {
            _medicalVendorInvoiceItem.OrganizationRoleUserAmountEarned = -.01m;
            Assert.IsFalse(_validator.IsValid(_medicalVendorInvoiceItem));
        }

        [Test]
        public void IsValidReturnsTrueWhenOrganizationRoleUserAmountEarnedIsZero()
        {
            _medicalVendorInvoiceItem.OrganizationRoleUserAmountEarned = 0m;
            Assert.IsTrue(_validator.IsValid(_medicalVendorInvoiceItem));
        }

        [Test]
        public void IsValidReturnsTrueWhenOrganizationRoleUserAmountEarnedIsLessThan100()
        {
            for (decimal i = .01m; i < 99.99m; i += .01m)
            {
                _medicalVendorInvoiceItem.OrganizationRoleUserAmountEarned = i;
                Assert.IsTrue(_validator.IsValid(_medicalVendorInvoiceItem), string.Format("{0:c} did not return true.", i));
            }
        }

        [Test]
        public void IsValidReturnsTrueWhenOrganizationRuleUserAmountEarnedIs100()
        {
            _medicalVendorInvoiceItem.OrganizationRoleUserAmountEarned = 100m;
            Assert.IsTrue(_validator.IsValid(_medicalVendorInvoiceItem));
        }

        [Test]
        public void IsValidReturnsTrueWhenOrganizationRoleUserAmountEarnedIsGreaterThan100()
        {
            for (decimal i = 100.01m; i < 110m; i += .01m)
            {
                _medicalVendorInvoiceItem.OrganizationRoleUserAmountEarned = i;
                Assert.IsFalse(_validator.IsValid(_medicalVendorInvoiceItem), string.Format("{0:c} did not return false.", i));
            }
        }

        [Test]
        public void IsValidReturnsFalseWhenCustomerIdIsLessThanOrEqualTo0()
        {
            _medicalVendorInvoiceItem.CustomerId = 0;
            Assert.IsFalse(_validator.IsValid(_medicalVendorInvoiceItem));

            _medicalVendorInvoiceItem.CustomerId--;
            Assert.IsFalse(_validator.IsValid(_medicalVendorInvoiceItem));
        }

        [Test]
        public void IsValidReturnsTrueWhenCustomerIdIsGreaterThan0()
        {
            _medicalVendorInvoiceItem.CustomerId = 1;
            Assert.IsTrue(_validator.IsValid(_medicalVendorInvoiceItem));
        }

        [Test]
        public void IsValidReturnsFalseWhenCustomerNameIsNullOrEmpty()
        {
            _medicalVendorInvoiceItem.CustomerName = null;
            Assert.IsFalse(_validator.IsValid(_medicalVendorInvoiceItem));

            _medicalVendorInvoiceItem.CustomerName = string.Empty;
            Assert.IsFalse(_validator.IsValid(_medicalVendorInvoiceItem));
        }

        [Test]
        public void IsValidReturnsTrueWhenCustomerNameIsNotNullOrEmpty()
        {
            _medicalVendorInvoiceItem.CustomerName = "CustomerName";
            Assert.IsTrue(_validator.IsValid(_medicalVendorInvoiceItem));
        }

        [Test]
        public void IsValidReturnsFalseWhenEventIdIsLessThanOrEqualTo0()
        {
            _medicalVendorInvoiceItem.EventId = 0;
            Assert.IsFalse(_validator.IsValid(_medicalVendorInvoiceItem));

            _medicalVendorInvoiceItem.EventId--;
            Assert.IsFalse(_validator.IsValid(_medicalVendorInvoiceItem));
        }

        [Test]
        public void IsValidReturnsTrueWhenEventIdIsGreaterThan0()
        {
            _medicalVendorInvoiceItem.EventId = 1;
            Assert.IsTrue(_validator.IsValid(_medicalVendorInvoiceItem));
        }

        [Test]
        public void IsValidReturnsFalseWhenEventNameIsNullOrEmpty()
        {
            _medicalVendorInvoiceItem.EventName = null;
            Assert.IsFalse(_validator.IsValid(_medicalVendorInvoiceItem));

            _medicalVendorInvoiceItem.EventName = string.Empty;
            Assert.IsFalse(_validator.IsValid(_medicalVendorInvoiceItem));
        }

        [Test]
        public void IsValidReturnsTrueWhenEventNameIsNotNullOrEmpty()
        {
            _medicalVendorInvoiceItem.EventName = "EventName";
            Assert.IsTrue(_validator.IsValid(_medicalVendorInvoiceItem));
        }

        [Test]
        public void IsValidReturnsFalseWhenEventDateIsEarlierThanEpochDate()
        {
            _medicalVendorInvoiceItem.EventDate = _minimumDate.AddDays(-1);
            Assert.IsFalse(_validator.IsValid(_medicalVendorInvoiceItem));
        }

        [Test]
        public void IsValidReturnsTrueWhenEventDateIsAfterEpochDate()
        {
            _medicalVendorInvoiceItem.EventDate = _minimumDate.AddDays(1);
            Assert.IsTrue(_validator.IsValid(_medicalVendorInvoiceItem));
        }

        [Test]
        public void IsValidReturnsFalseWhenPackageNameIsNullOrEmpty()
        {
            _medicalVendorInvoiceItem.PackageName = null;
            Assert.IsFalse(_validator.IsValid(_medicalVendorInvoiceItem));

            _medicalVendorInvoiceItem.PackageName = string.Empty;
            Assert.IsFalse(_validator.IsValid(_medicalVendorInvoiceItem));
        }

        [Test]
        public void IsValidReturnsTrueWhenPackageNameIsNotNullOrEmpty()
        {
            _medicalVendorInvoiceItem.PackageName = "PackageName";
            Assert.IsTrue(_validator.IsValid(_medicalVendorInvoiceItem));
        }

        [Test]
        public void IsValidReturnsFalseWhenPodNameIsNullOrEmpty()
        {
            _medicalVendorInvoiceItem.PodName = null;
            Assert.IsFalse(_validator.IsValid(_medicalVendorInvoiceItem));

            _medicalVendorInvoiceItem.PodName = string.Empty;
            Assert.IsFalse(_validator.IsValid(_medicalVendorInvoiceItem));
        }

        [Test]
        public void IsValidReturnsTrueWhenPodNameIsNotNullOrEmpty()
        {
            _medicalVendorInvoiceItem.PodName = "PodName";
            Assert.IsTrue(_validator.IsValid(_medicalVendorInvoiceItem));
        }

        //[Test]
        //public void IsValidReturnsFalseWhenEvaluationStartTimeIsOnOrEarlierThanEpochDate()
        //{
        //    _medicalVendorInvoiceItem.EvaluationStartTime = _minimumDate;
        //    Assert.IsFalse(_validator.IsValid(_medicalVendorInvoiceItem));

        //    _medicalVendorInvoiceItem.EvaluationStartTime = _minimumDate.AddDays(-1);
        //    Assert.IsFalse(_validator.IsValid(_medicalVendorInvoiceItem));
        //}

        [Test]
        public void IsValidReturnsTrueWhenEvaluationStartTimeIsAfterEpochDate()
        {
            _medicalVendorInvoiceItem.EvaluationStartTime = _minimumDate.AddDays(1);
            Assert.IsTrue(_validator.IsValid(_medicalVendorInvoiceItem));
        }

        //[Test]
        //public void IsValidReturnsFalseWhenEvaluationEndTimeIsOnOrEarlierThanEpochDate()
        //{
        //    _medicalVendorInvoiceItem.EvaluationEndTime = _minimumDate;
        //    Assert.IsFalse(_validator.IsValid(_medicalVendorInvoiceItem));

        //    _medicalVendorInvoiceItem.EvaluationEndTime = _minimumDate.AddDays(-1);
        //    Assert.IsFalse(_validator.IsValid(_medicalVendorInvoiceItem));
        //}

        //[Test]
        //public void IsValidReturnsTrueWhenEvaluationEndTimeIsAfterEpochDate()
        //{
        //    _medicalVendorInvoiceItem.EvaluationEndTime = _medicalVendorInvoiceItem.EvaluationStartTime.AddDays(1);
        //    Assert.IsTrue(_validator.IsValid(_medicalVendorInvoiceItem));
        //}

        //[Test]
        //public void IsValidReturnsFalseWhenEvaluationStartTimeComesAfterEvaluationEndTime()
        //{
        //    _medicalVendorInvoiceItem.EvaluationStartTime = _minimumDate.AddDays(1);
        //    _medicalVendorInvoiceItem.EvaluationEndTime = _medicalVendorInvoiceItem.EvaluationStartTime.AddHours(-1);

        //    Assert.IsFalse(_validator.IsValid(_medicalVendorInvoiceItem));
        //}

        //[Test]
        //public void IsValidReturnsFalseWhenEvaluationStartTimeEqualsEvaluationEndTime()
        //{
        //    _medicalVendorInvoiceItem.EvaluationStartTime = _minimumDate.AddDays(1);
        //    _medicalVendorInvoiceItem.EvaluationEndTime = _medicalVendorInvoiceItem.EvaluationStartTime;

        //    Assert.IsFalse(_validator.IsValid(_medicalVendorInvoiceItem));
        //}

        //[Test]
        //public void IsValidReturnsTrueWhenEvaluationStartTimeComesBeforeEvaluationEndTime()
        //{
        //    _medicalVendorInvoiceItem.EvaluationStartTime = _minimumDate.AddDays(1);
        //    _medicalVendorInvoiceItem.EvaluationEndTime = _medicalVendorInvoiceItem.EvaluationStartTime.AddMinutes(2);

        //    Assert.IsTrue(_validator.IsValid(_medicalVendorInvoiceItem));
        //}
    }
}