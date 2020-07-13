using System;
using Falcon.App.Infrastructure.Finance.Interfaces;
using Falcon.Data.EntityClasses;
using Falcon.App.Core.Enum;
using Falcon.App.Infrastructure.Factories;
using Falcon.App.Infrastructure.Interfaces;
using HealthYes.Web.UnitTests.Fakes;
using NUnit.Framework;

namespace HealthYes.Web.UnitTests.Infrastructure.Factories
{
    [TestFixture]
    public class MedicalVendorInvoiceBaseFactoryTester
    {
        private readonly IMedicalVendorInvoiceBaseFactory _medicalVendorInvoiceBaseFactory = new MedicalVendorInvoiceBaseFactory();
        private FakeMedicalVendorInvoiceBase _fakeMedicalVendorInvoiceBase;

        [SetUp]
        public void SetUp()
        {
            _fakeMedicalVendorInvoiceBase = new FakeMedicalVendorInvoiceBase();
        }

        [TearDown]
        public void TearDown()
        {
            _fakeMedicalVendorInvoiceBase = null;
        }

        [Test]
        [ExpectedException(typeof(ArgumentNullException))]
        public void SetMedicalVendorInvoiceBaseFieldsThrowsExceptionWhenNullBaseObjectGiven()
        {
            _medicalVendorInvoiceBaseFactory.SetMedicalVendorInvoiceBaseFields(null, new PhysicianInvoiceEntity());
        }

        [Test]
        [ExpectedException(typeof(ArgumentNullException))]
        public void SetMedicalVendorInvoiceBaseFieldsThrowsExceptionWhenNullEntityGiven()
        {
            _medicalVendorInvoiceBaseFactory.SetMedicalVendorInvoiceBaseFields(_fakeMedicalVendorInvoiceBase, null);
        }

        [Test]
        public void SetMedicalVendorInvoiceBaseFieldsMapsEntityPropertiesToDomainPropertiesCorrectly()
        {
            var medicalVendorInvoiceEntity = new PhysicianInvoiceEntity
                { ApprovalGuid = Guid.NewGuid(), DateApproved = new DateTime(2003, 2, 1) ,MedicalVendorAddress = "MedicalVendorAddress" };
            _medicalVendorInvoiceBaseFactory.SetMedicalVendorInvoiceBaseFields(_fakeMedicalVendorInvoiceBase,
                medicalVendorInvoiceEntity);

            Assert.AreEqual(medicalVendorInvoiceEntity.ApprovalGuid, _fakeMedicalVendorInvoiceBase.ApprovalGuid);
            Assert.AreEqual(medicalVendorInvoiceEntity.DateApproved, _fakeMedicalVendorInvoiceBase.DateApproved);
            Assert.AreEqual(medicalVendorInvoiceEntity.MedicalVendorAddress, _fakeMedicalVendorInvoiceBase.MedicalVendorAddress);
        }

        [Test]
        public void SetMedicalVendorInvoiceBaseFieldsSetsApprovalStatusToUnnaprovedWhenEntityApprovalStatusIsOne()
        {
            var medicalVendorInvoiceEntity = new PhysicianInvoiceEntity { ApprovalStatus = 1 };

            _medicalVendorInvoiceBaseFactory.SetMedicalVendorInvoiceBaseFields(_fakeMedicalVendorInvoiceBase, 
                medicalVendorInvoiceEntity);

            Assert.AreEqual(ApprovalStatus.Unapproved, _fakeMedicalVendorInvoiceBase.ApprovalStatus);
        }

        [Test]
        public void SetMedicalVendorInvoiceBaseFieldsSetsPaymentStatusToPaidWhenEntityPaymentStatusIsTwo()
        {
            var medicalVendorInvoiceEntity = new PhysicianInvoiceEntity { PaymentStatus = 2 };

            _medicalVendorInvoiceBaseFactory.SetMedicalVendorInvoiceBaseFields(_fakeMedicalVendorInvoiceBase, 
                medicalVendorInvoiceEntity);

            Assert.AreEqual(PaymentStatus.Paid, _fakeMedicalVendorInvoiceBase.PaymentStatus);
        }

        [Test]
        public void SetMedicalVendorInvoiceBaseFieldsMapsDatePaidEntityPropertyToDomainProperty()
        {
            var expectedDatePaid = new DateTime(2003, 2, 1);

            _medicalVendorInvoiceBaseFactory.SetMedicalVendorInvoiceBaseFields(_fakeMedicalVendorInvoiceBase, 
                new PhysicianInvoiceEntity { DatePaid = expectedDatePaid });

            Assert.AreEqual(expectedDatePaid, _fakeMedicalVendorInvoiceBase.DatePaid);
        }
    }
}