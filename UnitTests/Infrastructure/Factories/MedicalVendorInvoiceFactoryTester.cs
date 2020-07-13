using System;
using System.Collections.Generic;
using System.Linq;
using Falcon.App.Core.Finance.Domain;
using Falcon.App.Core.Geo.Domain;
using Falcon.App.Core.Users.Domain;
using Falcon.App.Infrastructure.Finance.Interfaces;
using Falcon.Data.EntityClasses;
using Falcon.Data.HelperClasses;
using Falcon.App.Core.Domain;
using Falcon.App.Core.Enum;
using Falcon.App.Core.ValueTypes;
using Falcon.App.Infrastructure.Factories;
using NUnit.Framework;
using Rhino.Mocks;

namespace HealthYes.Web.UnitTests.Infrastructure.Factories
{
    [TestFixture]
    public class MedicalVendorInvoiceFactoryTester
    {
        private MockRepository _mocks;
        private IMedicalVendorInvoiceBaseFactory _medicalVendorInvoiceBaseFactory;
        private IMedicalVendorInvoiceItemFactory _medicalVendorInvoiceItemFactory;

        private IMedicalVendorInvoiceFactory _medicalVendorInvoiceFactory;

        [SetUp]
        public void SetUp()
        {
            _mocks = new MockRepository();
            _medicalVendorInvoiceBaseFactory = _mocks.StrictMock<IMedicalVendorInvoiceBaseFactory>();
            _medicalVendorInvoiceItemFactory = _mocks.StrictMock<IMedicalVendorInvoiceItemFactory>();

            _medicalVendorInvoiceFactory = new MedicalVendorInvoiceFactory(_medicalVendorInvoiceBaseFactory, 
                _medicalVendorInvoiceItemFactory);
        }

        [TearDown]
        public void TearDown()
        {
            _mocks = null;
            _medicalVendorInvoiceFactory = null;
        }

        [Test]
        [ExpectedException(typeof(ArgumentNullException))]
        public void CreateMedicalVendorInvoiceThrowsExceptionWhenGivenNullEntityAndValidItemList()
        {
            _mocks.ReplayAll();
            _medicalVendorInvoiceFactory.CreateMedicalVendorInvoice(null, new List<MedicalVendorInvoiceItem>());
            _mocks.VerifyAll();
        }

        [Test]
        [ExpectedException(typeof(ArgumentNullException))]
        public void CreateMedicalVendorInvoiceThrowsExceptionWhenGivenNullList()
        {
            _mocks.ReplayAll();
            _medicalVendorInvoiceFactory.CreateMedicalVendorInvoice(new PhysicianInvoiceEntity(), (List<MedicalVendorInvoiceItem>) null);
            _mocks.VerifyAll();
        }

        [Test]
        [ExpectedException(typeof(ArgumentNullException))]
        public void CreateMedicalVendorInvoiceThrowsExceptionWhenGivenNullEntityAndValidItemCollection()
        {
            var medicalVendorInvoiceItemEntities = new EntityCollection<PhysicianInvoiceItemEntity>();
            Expect.Call(_medicalVendorInvoiceItemFactory.CreateMedicalVendorInvoiceItems(medicalVendorInvoiceItemEntities)).
                Return(new List<MedicalVendorInvoiceItem>());

            _mocks.ReplayAll();
            _medicalVendorInvoiceFactory.CreateMedicalVendorInvoice(null, medicalVendorInvoiceItemEntities);
            _mocks.VerifyAll();
        }

        [Test]
        public void CreateMedicalVendorInvoiceReturnsMedicalVendorInvoice()
        {
            var medicalVendorInvoiceItemEntities = new EntityCollection<PhysicianInvoiceItemEntity>();
            Expect.Call(_medicalVendorInvoiceItemFactory.CreateMedicalVendorInvoiceItems(medicalVendorInvoiceItemEntities))
                .Return(new List<MedicalVendorInvoiceItem>());
            Expect.Call(() => _medicalVendorInvoiceBaseFactory.SetMedicalVendorInvoiceBaseFields(null, null)).IgnoreArguments();

            _mocks.ReplayAll();
            PhysicianInvoice medicalVendorInvoice = _medicalVendorInvoiceFactory.CreateMedicalVendorInvoice
                (new PhysicianInvoiceEntity(), medicalVendorInvoiceItemEntities);
            _mocks.VerifyAll();

            Assert.IsNotNull(medicalVendorInvoice);
        }

        [Test]
        public void CreateMedicalVendorInvoiceReturnsMedicalVendorInvoiceWhenEntityAndListGiven()
        {
            Expect.Call(() => _medicalVendorInvoiceBaseFactory.SetMedicalVendorInvoiceBaseFields(null, null)).IgnoreArguments();

            _mocks.ReplayAll();
            PhysicianInvoice medicalVendorInvoice = _medicalVendorInvoiceFactory.
                CreateMedicalVendorInvoice(new PhysicianInvoiceEntity(), new List<MedicalVendorInvoiceItem>());
            _mocks.VerifyAll();
            
            Assert.IsNotNull(medicalVendorInvoice);
        }

        [Test]
        public void CreateMedicalVendorInvoiceMapsGivenListToMedicalVendorInvoiceItemCollection()
        {
            var medicalVendorInvoiceItems = new List<MedicalVendorInvoiceItem> { new MedicalVendorInvoiceItem(1), new MedicalVendorInvoiceItem(2) };
            Expect.Call(() => _medicalVendorInvoiceBaseFactory.SetMedicalVendorInvoiceBaseFields(null, null)).IgnoreArguments();
            
            _mocks.ReplayAll();
            PhysicianInvoice medicalVendorInvoice = _medicalVendorInvoiceFactory.
                CreateMedicalVendorInvoice(new PhysicianInvoiceEntity(), medicalVendorInvoiceItems);
            _mocks.VerifyAll();

            Assert.AreEqual(medicalVendorInvoiceItems, medicalVendorInvoice.MedicalVendorInvoiceItems);
        }

        [Test]
        [ExpectedException(typeof(ArgumentNullException))]
        public void CreateMedicalVendorInvoiceEntityThrowsExceptionWhenGivenNullInvoice()
        {
            _mocks.ReplayAll();
            _medicalVendorInvoiceFactory.CreateMedicalVendorInvoiceEntity(null);
            _mocks.VerifyAll();
        }

        [Test]
        [Ignore]
        public void CreateMedicalVendorInvoiceEntityMapsDomainPropertiesToEntityPropertiesCorrectly()
        {
            var medicalVendorInvoice = new PhysicianInvoice
            {
                ApprovalGuid = Guid.NewGuid(),
                PhysicianId = 3,
                PayPeriodEndDate = new DateTime(2001, 3, 3),
                MedicalVendorName = "Name"
            };

            _mocks.ReplayAll();
            PhysicianInvoiceEntity medicalVendorInvoiceEntity = _medicalVendorInvoiceFactory.
                CreateMedicalVendorInvoiceEntity(medicalVendorInvoice);
            _mocks.VerifyAll();

            Assert.AreEqual(medicalVendorInvoice.ApprovalGuid, medicalVendorInvoiceEntity.ApprovalGuid);
            Assert.AreEqual(medicalVendorInvoice.PhysicianId, medicalVendorInvoiceEntity.PhysicianProfile.PhysicianId);
            Assert.AreEqual(medicalVendorInvoice.PayPeriodEndDate, medicalVendorInvoiceEntity.PayPeriodEndDate);
            Assert.AreEqual(medicalVendorInvoice.MedicalVendorName, medicalVendorInvoiceEntity.MedicalVendorName);
        }

        [Test]
        public void CreateMedicalVendorInvoiceEntitySetsOrganizationRoleUserNameToPhysicianName()
        {
            var medicalVendorInvoice = new PhysicianInvoice { PhysicianName = "Bobby" };

            _mocks.ReplayAll();
            PhysicianInvoiceEntity medicalVendorInvoiceEntity = _medicalVendorInvoiceFactory.
                CreateMedicalVendorInvoiceEntity(medicalVendorInvoice);
            _mocks.VerifyAll();

            Assert.AreEqual(medicalVendorInvoice.PhysicianName, medicalVendorInvoiceEntity.PhysicianName);
        }

        [Test]
        public void CreateMedicalVendorInvoiceEntitySetsApprovalStatusToApprovalStatusByteValue()
        {
            var approvedMedicalVendorInvoice = new PhysicianInvoice { ApprovalStatus = ApprovalStatus.Approved };
            var unapprovedMedicalVendorInvoice = new PhysicianInvoice { ApprovalStatus = ApprovalStatus.Unapproved };

            _mocks.ReplayAll();
            PhysicianInvoiceEntity approvedMedicalVendorInvoiceEntity = _medicalVendorInvoiceFactory.
                CreateMedicalVendorInvoiceEntity(approvedMedicalVendorInvoice);
            PhysicianInvoiceEntity unapprovedMedicalVendorInvoiceEntity = _medicalVendorInvoiceFactory.
                CreateMedicalVendorInvoiceEntity(unapprovedMedicalVendorInvoice);
            _mocks.VerifyAll();

            Assert.AreEqual((byte)approvedMedicalVendorInvoice.ApprovalStatus, approvedMedicalVendorInvoiceEntity.ApprovalStatus);
            Assert.AreEqual((byte)unapprovedMedicalVendorInvoice.ApprovalStatus, unapprovedMedicalVendorInvoiceEntity.ApprovalStatus);
        }

        [Test]
        public void CreateMedicalVendorInvoiceEntitySetsPaymentStatusToPaymentStatusByteValue()
        {
            var paidMedicalVendorInvoice = new PhysicianInvoice { PaymentStatus = PaymentStatus.Paid };
            var unpaidMedicalVendorInvoice = new PhysicianInvoice { PaymentStatus = PaymentStatus.Unpaid };

            _mocks.ReplayAll();
            PhysicianInvoiceEntity paidMedicalVendorInvoiceEntity = _medicalVendorInvoiceFactory.
                CreateMedicalVendorInvoiceEntity(paidMedicalVendorInvoice);
            PhysicianInvoiceEntity unpaidMedicalVendorInvoiceEntity = _medicalVendorInvoiceFactory.
                CreateMedicalVendorInvoiceEntity(unpaidMedicalVendorInvoice);
            _mocks.VerifyAll();

            Assert.AreEqual((byte)paidMedicalVendorInvoice.PaymentStatus, paidMedicalVendorInvoiceEntity.PaymentStatus);
            Assert.AreEqual((byte)unpaidMedicalVendorInvoice.PaymentStatus, unpaidMedicalVendorInvoiceEntity.PaymentStatus);
        }

        [Test]
        public void CreateMedicalVendorInvoiceEntitySetsDatePaidToDomainDatePaidProperty()
        {
            var expectedDatePaid = new DateTime(2004, 2, 1);
            
            _mocks.ReplayAll();
            PhysicianInvoiceEntity medicalVendorInvoiceEntity = _medicalVendorInvoiceFactory.
                CreateMedicalVendorInvoiceEntity(new PhysicianInvoice {DatePaid = expectedDatePaid});
            _mocks.VerifyAll();

            Assert.AreEqual(expectedDatePaid, medicalVendorInvoiceEntity.DatePaid);
        }

        [Test]
        [ExpectedException(typeof(ArgumentNullException))]
        public void CreateMedicalVendorInvoicesThrowsExceptionWhenNullInvoiceEntityCollectionGiven()
        {
            _mocks.ReplayAll();
            _medicalVendorInvoiceFactory.CreateMedicalVendorInvoices(null, new EntityCollection<PhysicianInvoiceItemEntity>());
            _mocks.VerifyAll();
        }

        [Test]
        [ExpectedException(typeof(ArgumentNullException))]
        public void CreateMedicalVendorInvoicesThrowsExceptionWhenNullInvoiceEntityItemCollectionGiven()
        {
            _mocks.ReplayAll();
            _medicalVendorInvoiceFactory.CreateMedicalVendorInvoices(new EntityCollection<PhysicianInvoiceEntity>(), null);
            _mocks.VerifyAll();
        }

        [Test]
        public void CreateMedicalVendorInvoicesReturnsOneInvoiceWhenOneInvoiceEntityGiven()
        {
            var medicalVendorInvoiceEntity = new PhysicianInvoiceEntity();
            var medicalVendorInvoiceItemEntities = new EntityCollection<PhysicianInvoiceItemEntity>();
            Expect.Call(_medicalVendorInvoiceItemFactory.CreateMedicalVendorInvoiceItems(medicalVendorInvoiceItemEntities))
                .Return(new List<MedicalVendorInvoiceItem>());
            Expect.Call(() => _medicalVendorInvoiceBaseFactory.SetMedicalVendorInvoiceBaseFields(null, null)).IgnoreArguments();
            
            _mocks.ReplayAll();
            List<PhysicianInvoice> medicalVendorInvoices = _medicalVendorInvoiceFactory.
                CreateMedicalVendorInvoices(new EntityCollection<PhysicianInvoiceEntity> { medicalVendorInvoiceEntity },
                medicalVendorInvoiceItemEntities);
            _mocks.VerifyAll();

            Assert.IsNotNull(medicalVendorInvoices);
            Assert.AreEqual(1, medicalVendorInvoices.Count);
        }

        [Test]
        public void CreateMedicalVendorInvoicesReturnsNoInvoiceWhenEmptyCollectionOfInvoiceEntitiesGiven()
        {
            _mocks.ReplayAll();
            List<PhysicianInvoice> medicalVendorInvoices = _medicalVendorInvoiceFactory.
                CreateMedicalVendorInvoices(new EntityCollection<PhysicianInvoiceEntity>(),
                new EntityCollection<PhysicianInvoiceItemEntity>());
            _mocks.VerifyAll();

            Assert.IsNotNull(medicalVendorInvoices);
            Assert.IsEmpty(medicalVendorInvoices);
        }

        [Test]
        public void CreateMedicalVendorInvoicesReturnsThreeInvoicesWhenThreeInvoiceEntitiesGiven()
        {
            var medicalVendorInvoiceEntities = new EntityCollection<PhysicianInvoiceEntity> { new PhysicianInvoiceEntity(), new PhysicianInvoiceEntity(), new PhysicianInvoiceEntity() };
            var medicalVendorInvoiceItemEntities = new EntityCollection<PhysicianInvoiceItemEntity>();
            Expect.Call(_medicalVendorInvoiceItemFactory.CreateMedicalVendorInvoiceItems(medicalVendorInvoiceItemEntities))
                .Return(new List<MedicalVendorInvoiceItem>()).Repeat.Times(medicalVendorInvoiceEntities.Count);
            Expect.Call(() => _medicalVendorInvoiceBaseFactory.SetMedicalVendorInvoiceBaseFields(null, null)).IgnoreArguments().
                Repeat.Times(medicalVendorInvoiceEntities.Count);

            _mocks.ReplayAll();
            List<PhysicianInvoice> medicalVendorInvoices = _medicalVendorInvoiceFactory.
                CreateMedicalVendorInvoices(medicalVendorInvoiceEntities, medicalVendorInvoiceItemEntities);
            _mocks.VerifyAll();

            Assert.AreEqual(medicalVendorInvoiceEntities.Count, medicalVendorInvoices.Count);
        }

        [Test]
        public void CreateMedicalVendorInvoicesGivesAllItemEntitiesToSingleInvoice()
        {
            var medicalVendorInvoiceEntities = new EntityCollection<PhysicianInvoiceEntity> {new PhysicianInvoiceEntity()};
            var medicalVendorInvoiceItemEntities = new EntityCollection<PhysicianInvoiceItemEntity>();
            var medicalVendorInvoiceItems = new List<MedicalVendorInvoiceItem> 
                { new MedicalVendorInvoiceItem(), new MedicalVendorInvoiceItem() };
            Expect.Call(_medicalVendorInvoiceItemFactory.CreateMedicalVendorInvoiceItems(medicalVendorInvoiceItemEntities))
                .Return(medicalVendorInvoiceItems);
            Expect.Call(() => _medicalVendorInvoiceBaseFactory.SetMedicalVendorInvoiceBaseFields(null, null)).IgnoreArguments();

            _mocks.ReplayAll();
            List<PhysicianInvoice> medicalVendorInvoices = _medicalVendorInvoiceFactory.
                CreateMedicalVendorInvoices(medicalVendorInvoiceEntities, medicalVendorInvoiceItemEntities);
            _mocks.VerifyAll();

            PhysicianInvoice medicalVendorInvoice = medicalVendorInvoices.Single();
            Assert.IsNotNull(medicalVendorInvoice.MedicalVendorInvoiceItems);
            Assert.AreEqual(medicalVendorInvoiceItems.Count, medicalVendorInvoice.MedicalVendorInvoiceItems.Count);
        }

        [Test]
        [Ignore]
        public void CreateMedicalVenderInvoicesDoesNotAddItemEntitiesFromOtherInvoicesToSingleInvoice()
        {
            const int medicalVendorInvoiceId = 5;
            var medicalVendorInvoiceEntities = new EntityCollection<PhysicianInvoiceEntity> { new PhysicianInvoiceEntity(medicalVendorInvoiceId) };
            var medicalVendorInvoiceItemEntites = new EntityCollection<PhysicianInvoiceItemEntity>
            {
                new PhysicianInvoiceItemEntity { PhysicianInvoiceId = medicalVendorInvoiceId},
                new PhysicianInvoiceItemEntity { PhysicianInvoiceId = medicalVendorInvoiceId + 1},
            };
            var expectedEntities = new EntityCollection<PhysicianInvoiceItemEntity>(medicalVendorInvoiceItemEntites.Where
                (mviie => mviie.PhysicianInvoiceId == medicalVendorInvoiceId).ToList());
            Expect.Call(_medicalVendorInvoiceItemFactory.CreateMedicalVendorInvoiceItems(expectedEntities))
                .Return(new List<MedicalVendorInvoiceItem>());
            Expect.Call(() => _medicalVendorInvoiceBaseFactory.SetMedicalVendorInvoiceBaseFields(null, null)).IgnoreArguments();

            _mocks.ReplayAll();
            _medicalVendorInvoiceFactory.CreateMedicalVendorInvoices(medicalVendorInvoiceEntities, medicalVendorInvoiceItemEntites);
            _mocks.VerifyAll();
        }

        [Test]
        [Ignore]
        public void CreateMedicalVendorInvoicesSetsItemsToTheirAssociatedInvoices()
        {
            const int medicalVendorInvoiceId1 = 5;
            const int medicalVendorInvoiceId2 = 6;
            var medicalVendorInvoiceEntities = new EntityCollection<PhysicianInvoiceEntity> 
                { new PhysicianInvoiceEntity(medicalVendorInvoiceId1), new PhysicianInvoiceEntity(medicalVendorInvoiceId2) };

            var medicalVendorInvoiceItemEntites = new EntityCollection<PhysicianInvoiceItemEntity>
            {
                new PhysicianInvoiceItemEntity { PhysicianInvoiceId = medicalVendorInvoiceId1 },
                new PhysicianInvoiceItemEntity { PhysicianInvoiceId = medicalVendorInvoiceId2 },
                new PhysicianInvoiceItemEntity { PhysicianInvoiceId = medicalVendorInvoiceId1 },
                new PhysicianInvoiceItemEntity { PhysicianInvoiceId = medicalVendorInvoiceId2 },
                new PhysicianInvoiceItemEntity { PhysicianInvoiceId = medicalVendorInvoiceId1 + medicalVendorInvoiceId2 },
            };

            var expectedEntities1 = new EntityCollection<PhysicianInvoiceItemEntity>(medicalVendorInvoiceItemEntites.Where
                (mviie => mviie.PhysicianInvoiceId == medicalVendorInvoiceId1).ToList());
            var expectedEntities2 = new EntityCollection<PhysicianInvoiceItemEntity>(medicalVendorInvoiceItemEntites.Where
                (mviie => mviie.PhysicianInvoiceId == medicalVendorInvoiceId2).ToList());
            Expect.Call(_medicalVendorInvoiceItemFactory.CreateMedicalVendorInvoiceItems(expectedEntities1))
                .Return(new List<MedicalVendorInvoiceItem>());
            Expect.Call(_medicalVendorInvoiceItemFactory.CreateMedicalVendorInvoiceItems(expectedEntities2))
                .Return(new List<MedicalVendorInvoiceItem>());
            Expect.Call(() => _medicalVendorInvoiceBaseFactory.SetMedicalVendorInvoiceBaseFields(null, null)).IgnoreArguments()
                .Repeat.Times(medicalVendorInvoiceEntities.Count);

            _mocks.ReplayAll();
            _medicalVendorInvoiceFactory.CreateMedicalVendorInvoices(medicalVendorInvoiceEntities, medicalVendorInvoiceItemEntites);
            _mocks.VerifyAll();
        }

        //[Test]
        //public void CreateNewMedicalVendorInvoiceSetsApprovalGuidToNonEmptyValue()
        //{
        //    var medicalVendor = new MedicalVendor { BusinessAddressId = new Address() };
        //    var medicalVendorMedicalVendorUser = new MedicalVendorMedicalVendorUser {Name = new Name()};
            
        //    MedicalVendorInvoice medicalVendorInvoice = _medicalVendorInvoiceFactory.CreateNewMedicalVendorInvoice
        //        (medicalVendor, medicalVendorMedicalVendorUser, new List<MedicalVendorInvoiceItem>(), 
        //        new DateTime(), new DateTime());

        //    Assert.AreNotEqual(Guid.Empty, medicalVendorInvoice.ApprovalGuid);
        //}

        //[Test]
        //public void CreateNewMedicalVendorInvoiceSetsApprovalStatusToUnapproved()
        //{
        //    var medicalVendor = new MedicalVendor { BusinessAddressId = new Address() };
        //    var medicalVendorMedicalVendorUser = new MedicalVendorMedicalVendorUser { Name = new Name() };

        //    MedicalVendorInvoice medicalVendorInvoice = _medicalVendorInvoiceFactory.CreateNewMedicalVendorInvoice
        //        (medicalVendor, medicalVendorMedicalVendorUser, new List<MedicalVendorInvoiceItem>(),
        //        new DateTime(), new DateTime());

        //    Assert.AreEqual(ApprovalStatus.Unapproved, medicalVendorInvoice.ApprovalStatus);
        //}

        //[Test]
        //public void CreateNewMedicalVendorInvoiceSetsDateGeneratedToNow()
        //{
            
        //    var medicalVendor = new MedicalVendor { BusinessAddressId = new Address() };
        //    var medicalVendorMedicalVendorUser = new MedicalVendorMedicalVendorUser { Name = new Name() };

        //    MedicalVendorInvoice medicalVendorInvoice = _medicalVendorInvoiceFactory.CreateNewMedicalVendorInvoice
        //        (medicalVendor, medicalVendorMedicalVendorUser, new List<MedicalVendorInvoiceItem>(),
        //        new DateTime(), new DateTime());

        //    Assert.IsTrue(DateTime.Now.AddSeconds(-1) < medicalVendorInvoice.DateGenerated);
        //}

        //[Test]
        //public void CreateNewMedicalVendorInvoiceSetsInvoiceItemsToGivenCollection()
        //{
        //    var expectedInvoiceItems = new List<MedicalVendorInvoiceItem> {new MedicalVendorInvoiceItem()};
        //    var medicalVendor = new MedicalVendor { BusinessAddressId = new Address() };
        //    var medicalVendorMedicalVendorUser = new MedicalVendorMedicalVendorUser { Name = new Name() };
            
        //    MedicalVendorInvoice medicalVendorInvoice = _medicalVendorInvoiceFactory.CreateNewMedicalVendorInvoice
        //        (medicalVendor, medicalVendorMedicalVendorUser, expectedInvoiceItems,
        //        new DateTime(), new DateTime());

        //    Assert.AreEqual(expectedInvoiceItems, medicalVendorInvoice.MedicalVendorInvoiceItems);
        //}

        //[Test]
        //public void CreateNewMedicalVendorInvoiceSetsPaymentStatusToUnpaid()
        //{
        //    var medicalVendor = new MedicalVendor { BusinessAddressId = new Address() };
        //    var medicalVendorMedicalVendorUser = new MedicalVendorMedicalVendorUser { Name = new Name() };

        //    MedicalVendorInvoice medicalVendorInvoice = _medicalVendorInvoiceFactory.CreateNewMedicalVendorInvoice
        //        (medicalVendor, medicalVendorMedicalVendorUser, new List<MedicalVendorInvoiceItem>(),
        //        new DateTime(), new DateTime());

        //    Assert.AreEqual(PaymentStatus.Unpaid, medicalVendorInvoice.PaymentStatus);
        //}

        //[Test]
        //public void CreateNewMedicalVendorInvoiceSetsDateApprovedAndDatePaidToNull()
        //{
        //    var medicalVendor = new MedicalVendor { BusinessAddressId = new Address() };
        //    var medicalVendorMedicalVendorUser = new MedicalVendorMedicalVendorUser { Name = new Name() };

        //    MedicalVendorInvoice medicalVendorInvoice = _medicalVendorInvoiceFactory.CreateNewMedicalVendorInvoice
        //        (medicalVendor, medicalVendorMedicalVendorUser, new List<MedicalVendorInvoiceItem>(),
        //        new DateTime(), new DateTime());

        //    Assert.IsNull(medicalVendorInvoice.DateApproved, "DateApproved was not set to null.");
        //    Assert.IsNull(medicalVendorInvoice.DatePaid, "DatePaid was not set to null.");
        //}

        //[Test]
        //public void CreateNewMedicalVendorInvoiceSetsPayPeriodDatesToGivenDates()
        //{
        //    var expectedStartDate = new DateTime(2001, 1, 1);
        //    var expectedEndDate = new DateTime(2002, 1, 1);
        //    var medicalVendor = new MedicalVendor { BusinessAddressId = new Address() };
        //    var medicalVendorMedicalVendorUser = new MedicalVendorMedicalVendorUser { Name = new Name() };
            
        //    MedicalVendorInvoice medicalVendorInvoice = _medicalVendorInvoiceFactory.CreateNewMedicalVendorInvoice
        //        (medicalVendor, medicalVendorMedicalVendorUser, new List<MedicalVendorInvoiceItem>(),
        //        expectedStartDate, expectedEndDate);

        //    Assert.AreEqual(expectedStartDate, medicalVendorInvoice.PayPeriodStartDate);
        //    Assert.AreEqual(expectedEndDate, medicalVendorInvoice.PayPeriodEndDate);
        //}

        //[Test]
        //public void CreateNewMedicalVendorInvoiceSetsVendorPropertiesToGivenVendorProperties()
        //{
        //    var expectedMedicalVendor = new MedicalVendor(1) { BusinessAddressId = new Address(3), Name = "Business"};
        //    var medicalVendorMedicalVendorUser = new MedicalVendorMedicalVendorUser { Name = new Name() };

        //    MedicalVendorInvoice medicalVendorInvoice = _medicalVendorInvoiceFactory.CreateNewMedicalVendorInvoice
        //        (expectedMedicalVendor, medicalVendorMedicalVendorUser, new List<MedicalVendorInvoiceItem>(),
        //        new DateTime(), new DateTime());

        //    Assert.AreEqual(expectedMedicalVendor.BusinessAddressId.ToString(), medicalVendorInvoice.MedicalVendorAddress);
        //    Assert.AreEqual(expectedMedicalVendor.Id, medicalVendorInvoice.MedicalVendorId);
        //    Assert.AreEqual(expectedMedicalVendor.Name, medicalVendorInvoice.MedicalVendorName);
        //}

        //[Test]
        //public void CreateNewMedicalVendorInvoiceSetsVendorUserPropertiesToGivenVendorUserProperties()
        //{
        //    var medicalVendor = new MedicalVendor { BusinessAddressId = new Address() };
        //    var expectedMedicalVendorMedicalVendorUser = new MedicalVendorMedicalVendorUser(5) { Name = new Name("b", "a", "c") };

        //    MedicalVendorInvoice medicalVendorInvoice = _medicalVendorInvoiceFactory.CreateNewMedicalVendorInvoice
        //        (medicalVendor, expectedMedicalVendorMedicalVendorUser, new List<MedicalVendorInvoiceItem>(),
        //        new DateTime(), new DateTime());

        //    Assert.AreEqual(expectedMedicalVendorMedicalVendorUser.Id, medicalVendorInvoice.OrganizationRoleUserId);
        //    Assert.AreEqual(expectedMedicalVendorMedicalVendorUser.Name.FullName, medicalVendorInvoice.PhysicianName);
        //}

    }
}