using System;
using Falcon.App.Core.Deprecated;
using Falcon.App.Core.Domain.MedicalVendors;
using Falcon.App.Core.Enum;
using Falcon.App.Core.Finance.Domain;
using Falcon.App.Core.Finance.Impl;
using Falcon.App.Core.Impl;
using Falcon.App.Core.Interfaces;
using HealthYes.Web.UnitTests.Fakes;
using NUnit.Framework;

namespace HealthYes.Web.UnitTests.Core.ValidationRuleFactories
{
    [TestFixture]
    public class MedicalVendorInvoiceBaseValidationRuleFactoryTester
    {
        // TODO: Retrieve epoch date from common location.
        private readonly DateTime _minimumValidDate = new DateTime(1900, 1, 1);
        private readonly IValidator<PhysicianInvoiceBase> _validator =
            new Validator<PhysicianInvoiceBase>(new MedicalVendorInvoiceBaseValidationRuleFactory());
        private PhysicianInvoiceBase _medicalVendorInvoiceBase;

        [SetUp]
        public void SetUp()
        {
            _medicalVendorInvoiceBase = GetValidMedicalVendorInvoice();
        }

        [TearDown]
        public void TearDown()
        {
            _medicalVendorInvoiceBase = null;
        }

        private FakeMedicalVendorInvoiceBase GetValidMedicalVendorInvoice()
        {
            return new FakeMedicalVendorInvoiceBase(1)
            {
                PaymentStatus = PaymentStatus.Paid,
                PayPeriodStartDate = _minimumValidDate.AddDays(1),
                PayPeriodEndDate = _minimumValidDate.AddDays(1),
                DateGenerated = _minimumValidDate.AddDays(1),
                MedicalVendorId = 1,
                MedicalVendorName = "MedicalVendorName",
                MedicalVendorAddress = "MedicalVendorAddress",
                ApprovalGuid = Guid.NewGuid(),
                ApprovalStatus = ApprovalStatus.Unapproved,
                PhysicianId = 1,
                PhysicianName = "PhysicianName",
                DateApproved = null,
                DatePaid = null,
            };
        }

        [Test]
        public void IsValidReturnsFalseWhenPaymentStatusIsNotPaidOrUnpaid()
        {
            _medicalVendorInvoiceBase.PaymentStatus = 0;
            Assert.IsFalse(_validator.IsValid(_medicalVendorInvoiceBase));

            _medicalVendorInvoiceBase.PaymentStatus = (PaymentStatus)3;
            Assert.IsFalse(_validator.IsValid(_medicalVendorInvoiceBase));
        }

        [Test]
        public void IsValidReturnsTrueWhenPaymentStatusIsPaidOrUnpaid()
        {
            _medicalVendorInvoiceBase.PaymentStatus = PaymentStatus.Paid;
            Assert.IsTrue(_validator.IsValid(_medicalVendorInvoiceBase));

            _medicalVendorInvoiceBase.PaymentStatus = PaymentStatus.Unpaid;
            Assert.IsTrue(_validator.IsValid(_medicalVendorInvoiceBase));
        }

        [Test]
        public void IsValidReturnsFalseWhenPayPeriodStartDateIsBeforeValidDate()
        {
            _medicalVendorInvoiceBase.PayPeriodStartDate = _minimumValidDate.AddDays(-1);
            Assert.IsFalse(_validator.IsValid(_medicalVendorInvoiceBase));
        }

        [Test]
        public void IsValidReturnsTrueWhePayPeriodStartDateIsAfterValidDate()
        {
            _medicalVendorInvoiceBase.PayPeriodStartDate = _minimumValidDate.AddDays(1);
            Assert.IsTrue(_validator.IsValid(_medicalVendorInvoiceBase));
        }

        [Test]
        public void IsValidReturnsFalseWhenPayPeriodEndDateIsOnOrBeforeValidDate()
        {
            _medicalVendorInvoiceBase.PayPeriodEndDate = _minimumValidDate;
            Assert.IsFalse(_validator.IsValid(_medicalVendorInvoiceBase));

            _medicalVendorInvoiceBase.PayPeriodEndDate = _minimumValidDate.AddDays(-1);
            Assert.IsFalse(_validator.IsValid(_medicalVendorInvoiceBase));
        }

        [Test]
        public void IsValidReturnsTrueWhenPayPeriodEndDateIsAfterValidDate()
        {
            _medicalVendorInvoiceBase.PayPeriodEndDate = _minimumValidDate.AddDays(1);
            Assert.IsTrue(_validator.IsValid(_medicalVendorInvoiceBase));
        }

        [Test]
        public void IsValidReturnsFalseWhenPayPeriodStartDateExceedsPayPeriodEndDate()
        {
            _medicalVendorInvoiceBase.PayPeriodEndDate = _minimumValidDate.AddDays(1);
            _medicalVendorInvoiceBase.PayPeriodStartDate = _medicalVendorInvoiceBase.PayPeriodEndDate.AddDays(1);

            Assert.IsFalse(_validator.IsValid(_medicalVendorInvoiceBase));
        }

        [Test]
        public void IsValidReturnsTrueWhenPayPeriodStartDateIsOnOrBeforePayPeriodEndDate()
        {
            _medicalVendorInvoiceBase.PayPeriodEndDate = _minimumValidDate.AddDays(7);
            _medicalVendorInvoiceBase.PayPeriodStartDate = _medicalVendorInvoiceBase.PayPeriodEndDate;
            Assert.IsTrue(_validator.IsValid(_medicalVendorInvoiceBase));

            _medicalVendorInvoiceBase.PayPeriodStartDate = _medicalVendorInvoiceBase.PayPeriodEndDate.AddDays(-1);
            Assert.IsTrue(_validator.IsValid(_medicalVendorInvoiceBase));
        }

        [Test]
        public void IsValidReturnsFalseWhenDateGeneratedIsBeforeValidDate()
        {
            _medicalVendorInvoiceBase.DateGenerated = _minimumValidDate.AddDays(-1);
            Assert.IsFalse(_validator.IsValid(_medicalVendorInvoiceBase));
        }

        [Test]
        public void IsValidReturnsTrueWheDateGeneratedIsAfterValidDate()
        {
            _medicalVendorInvoiceBase.DateGenerated = _minimumValidDate.AddDays(1);
            Assert.IsTrue(_validator.IsValid(_medicalVendorInvoiceBase));
        }

        [Test]
        public void IsValidReturnsFalseWhenMedicalVendorIdIsLessThanOrEqualTo0()
        {
            _medicalVendorInvoiceBase.MedicalVendorId = 0;
            Assert.IsFalse(_validator.IsValid(_medicalVendorInvoiceBase));

            _medicalVendorInvoiceBase.MedicalVendorId = -1;
            Assert.IsFalse(_validator.IsValid(_medicalVendorInvoiceBase));
        }

        [Test]
        public void IsValidReturnsTrueWhenMedicalVendorIdIsGreaterThan0()
        {
            _medicalVendorInvoiceBase.MedicalVendorId = 1;
            Assert.IsTrue(_validator.IsValid(_medicalVendorInvoiceBase));
        }

        [Test]
        public void IsValidReturnsFalseWhenMedicalVendorNameIsNullOrEmpty()
        {
            _medicalVendorInvoiceBase.MedicalVendorName = null;
            Assert.IsFalse(_validator.IsValid(_medicalVendorInvoiceBase));

            _medicalVendorInvoiceBase.MedicalVendorName = string.Empty;
            Assert.IsFalse(_validator.IsValid(_medicalVendorInvoiceBase));
        }

        [Test]
        public void IsValidReturnsTrueWhenMedicalVendorNameHasValue()
        {
            _medicalVendorInvoiceBase.MedicalVendorName = "MedicalVendorName";
            Assert.IsTrue(_validator.IsValid(_medicalVendorInvoiceBase));
        }

        [Test]
        public void IsValidReturnsFalseWhenMedicalVendorAddressIsNullOrEmpty()
        {
            _medicalVendorInvoiceBase.MedicalVendorAddress = null;
            Assert.IsFalse(_validator.IsValid(_medicalVendorInvoiceBase));

            _medicalVendorInvoiceBase.MedicalVendorAddress = string.Empty;
            Assert.IsFalse(_validator.IsValid(_medicalVendorInvoiceBase));
        }

        [Test]
        public void IsValidReturnsTrueWhenMedicalVendorAddressHasValue()
        {
            _medicalVendorInvoiceBase.MedicalVendorAddress = "MedicalVendorAddress";
            Assert.IsTrue(_validator.IsValid(_medicalVendorInvoiceBase));
        }

        [Test]
        public void IsValidReturnsFalseWhenApprovalGuidIsEmpty()
        {
            _medicalVendorInvoiceBase.ApprovalGuid = Guid.Empty;
            Assert.IsFalse(_validator.IsValid(_medicalVendorInvoiceBase));
        }

        [Test]
        public void IsValidReturnsTrueWhenApprovalGuidIsNotEmpty()
        {
            for (int i = 0; i < 3; i++)
            {
                _medicalVendorInvoiceBase.ApprovalGuid = Guid.NewGuid();
                Assert.IsTrue(_validator.IsValid(_medicalVendorInvoiceBase));
            }
        }

        [Test]
        public void IsValidReturnsFalseWhenApprovalStatusIsNotApprovedOrUnapproved()
        {
            _medicalVendorInvoiceBase.ApprovalStatus = 0;
            Assert.IsFalse(_validator.IsValid(_medicalVendorInvoiceBase));

            _medicalVendorInvoiceBase.ApprovalStatus = (ApprovalStatus)3;
            Assert.IsFalse(_validator.IsValid(_medicalVendorInvoiceBase));
        }

        [Test]
        public void IsValidReturnsTrueWhenApprovalStatusIsApprovedOrUnapproved()
        {
            _medicalVendorInvoiceBase.ApprovalStatus = ApprovalStatus.Approved;
            Assert.IsTrue(_validator.IsValid(_medicalVendorInvoiceBase));

            _medicalVendorInvoiceBase.ApprovalStatus = ApprovalStatus.Unapproved;
            Assert.IsTrue(_validator.IsValid(_medicalVendorInvoiceBase));
        }

        [Test]
        public void IsValidReturnsFalseWhenOrganizationRoleUserIdIsLessThanOrEqualTo0()
        {
            _medicalVendorInvoiceBase.PhysicianId = 0;
            Assert.IsFalse(_validator.IsValid(_medicalVendorInvoiceBase));

            _medicalVendorInvoiceBase.PhysicianId--;
            Assert.IsFalse(_validator.IsValid(_medicalVendorInvoiceBase));
        }

        [Test]
        public void IsValidReturnsTrueWhenOrganizationRoleUserIdIsGreaterThan0()
        {
            _medicalVendorInvoiceBase.PhysicianId = 1;
            Assert.IsTrue(_validator.IsValid(_medicalVendorInvoiceBase));
        }

        [Test]
        public void IsValidReturnsFalseWhenOrganizationRoleUserNameIsNullOrEmpty()
        {
            _medicalVendorInvoiceBase.PhysicianName = null;
            Assert.IsFalse(_validator.IsValid(_medicalVendorInvoiceBase));

            _medicalVendorInvoiceBase.PhysicianName = string.Empty;
            Assert.IsFalse(_validator.IsValid(_medicalVendorInvoiceBase));
        }

        [Test]
        public void IsValidReturnsTrueWhenOrganizationRoleUserNameHasNonEmptyValue()
        {
            _medicalVendorInvoiceBase.PhysicianName = "PhysicianName";
            Assert.IsTrue(_validator.IsValid(_medicalVendorInvoiceBase));
        }

        [Test]
        public void IsValidReturnsFalseWhenDateApprovedIsBeforeValidDate()
        {
            _medicalVendorInvoiceBase.DateApproved = _minimumValidDate.AddDays(-1);
            Assert.IsFalse(_validator.IsValid(_medicalVendorInvoiceBase));
        }

        [Test]
        public void IsValidReturnsTrueWhenDateApprovedNullOrAfterValidDate()
        {
            _medicalVendorInvoiceBase.DateApproved = _minimumValidDate.AddDays(1);
            Assert.IsTrue(_validator.IsValid(_medicalVendorInvoiceBase));

            _medicalVendorInvoiceBase.DateApproved = null;
            Assert.IsTrue(_validator.IsValid(_medicalVendorInvoiceBase));
        }

        [Test]
        public void IsValidReturnsFalseWhenPayPeriodEndDateIsInTheFuture()
        {
            _medicalVendorInvoiceBase.PayPeriodEndDate = DateTime.Today.AddDays(1);
            Assert.IsFalse(_validator.IsValid(_medicalVendorInvoiceBase));
        }

        [Test]
        public void IsValidReturnsTrueWhenPayPeriodEndDateIsOnOrBeforeToday()
        {
            _medicalVendorInvoiceBase.PayPeriodEndDate = DateTime.Today;
            Assert.IsTrue(_validator.IsValid(_medicalVendorInvoiceBase));

            _medicalVendorInvoiceBase.PayPeriodEndDate = DateTime.Today.AddDays(-1);
            Assert.IsTrue(_validator.IsValid(_medicalVendorInvoiceBase));
        }

        [Test]
        public void IsValidReturnsFalseWhenDatePaidIsBeforeValidDate()
        {
            _medicalVendorInvoiceBase.DatePaid = _minimumValidDate.AddDays(-1);
            Assert.IsFalse(_validator.IsValid(_medicalVendorInvoiceBase));
        }

        [Test]
        public void IsValidReturnsTrueWhenDatePaidIsNull()
        {
            _medicalVendorInvoiceBase.DatePaid = null;

            bool isValid = _validator.IsValid(_medicalVendorInvoiceBase);

            Assert.IsTrue(isValid);
        }

        [Test]
        public void IsValidReturnsTrueWhenDatePaidIsAfterValidDate()
        {
            _medicalVendorInvoiceBase.DatePaid = _minimumValidDate.AddDays(1);

            bool isValid = _validator.IsValid(_medicalVendorInvoiceBase);

            Assert.IsTrue(isValid);
        }

        [Test]
        public void IsValidReturnsFalseWhenDatePaidPreceedsDateApproved()
        {
            _medicalVendorInvoiceBase.DateApproved = _minimumValidDate.AddDays(1);
            _medicalVendorInvoiceBase.DatePaid = _medicalVendorInvoiceBase.DateApproved.Value.AddMinutes(-1);

            bool isValid = _validator.IsValid(_medicalVendorInvoiceBase);

            Assert.IsFalse(isValid);
        }

        [Test]
        public void IsValidReturnsTrueWhenDatePaidIsOnOrAfterDateApproved()
        {
            _medicalVendorInvoiceBase.DateApproved = _minimumValidDate.AddDays(1);
            _medicalVendorInvoiceBase.DatePaid = _medicalVendorInvoiceBase.DateApproved.Value;
            Assert.IsTrue(_validator.IsValid(_medicalVendorInvoiceBase));

            _medicalVendorInvoiceBase.DatePaid = _medicalVendorInvoiceBase.DateApproved.Value.AddDays(1);
            Assert.IsTrue(_validator.IsValid(_medicalVendorInvoiceBase));
        }
    }
}