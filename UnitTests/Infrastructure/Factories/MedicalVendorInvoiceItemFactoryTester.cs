using System;
using System.Collections.Generic;
using System.Linq;
using Falcon.App.Core.Finance.Domain;
using Falcon.App.Infrastructure.Finance.Interfaces;
using Falcon.App.Infrastructure.Users.Interfaces;
using Falcon.Data.EntityClasses;
using Falcon.Data.HelperClasses;
using Falcon.Data.TypedViewClasses;
using Falcon.App.Core.Domain;
using Falcon.App.Core.Domain.MedicalVendors;
using Falcon.App.Core.Extensions;
using Falcon.App.Core.ValueTypes;
using Falcon.App.Infrastructure.Factories;
using Falcon.App.Infrastructure.Interfaces;
using NUnit.Framework;
using Rhino.Mocks;

namespace HealthYes.Web.UnitTests.Infrastructure.Factories
{
    [TestFixture]
    [Ignore]
    public class MedicalVendorInvoiceItemFactoryTester
    {
        private MockRepository _mocks;
        private IMedicalVendorMedicalVendorUserFactory _medicalVendorMedicalVendorUserFactory;
        private IMedicalVendorInvoiceItemFactory _medicalVendorInvoiceItemFactory;

        private MedicalVendorInvoiceItemTypedView _medicalVendorInvoiceItemTypedView;

        [SetUp]
        public void SetUp()
        {
            _mocks = new MockRepository();
            _medicalVendorMedicalVendorUserFactory = _mocks.StrictMock<IMedicalVendorMedicalVendorUserFactory>();
            _medicalVendorInvoiceItemTypedView = new MedicalVendorInvoiceItemTypedView();

            _medicalVendorInvoiceItemFactory = new MedicalVendorInvoiceItemFactory(_medicalVendorMedicalVendorUserFactory);
        }

        [TearDown]
        public void TearDown()
        {
            _mocks = null;
            _medicalVendorInvoiceItemTypedView = null;
        }

        private void ExpectCreateMedicalVendorMedicalVendorUser(MedicalVendorInvoiceItemRow medicalVendorInvoiceItemRow)
        {
            Expect.Call(_medicalVendorMedicalVendorUserFactory.CreateMedicalVendorMedicalVendorUser(medicalVendorInvoiceItemRow))
                .Return(new MedicalVendorMedicalVendorUser { Name = new Name()});
        }

        #region AddRowToMedicalVendorInvoiceItemTypedView()

        private MedicalVendorInvoiceItemRow AddRowToMedicalVendorInvoiceItemTypedView()
        {
            return AddRowToMedicalVendorInvoiceItemTypedView(0, 0, new DateTime(), new DateTime(), 0m, 0);
        }

        private void AddRowToMedicalVendorInvoiceItemTypedView(long podId)
        {
            AddRowToMedicalVendorInvoiceItemTypedView(0, 0, new DateTime(), new DateTime(), 0m, podId);
        }

        private MedicalVendorInvoiceItemRow AddRowToMedicalVendorInvoiceItemTypedView(long customerId, long eventId)
        {
            return AddRowToMedicalVendorInvoiceItemTypedView(customerId, eventId, new DateTime(), new DateTime(), 0m, 0);
        }

        private void AddRowToMedicalVendorInvoiceItemTypedView(DateTime evaluationStartTime,
            DateTime evaluationEndTime)
        {
            AddRowToMedicalVendorInvoiceItemTypedView(0, 0, evaluationStartTime, evaluationEndTime, 0m, 0);
        }

        private void AddRowToMedicalVendorInvoiceItemTypedView(long customerId, DateTime evaluationStartTime,
            decimal medicalVendorAmountEarned)
        {
            AddRowToMedicalVendorInvoiceItemTypedView(customerId, 0, evaluationStartTime, new DateTime(), medicalVendorAmountEarned, 0);
        }

        private void AddRowToMedicalVendorInvoiceItemTypedView(MedicalVendorInvoiceItemRow medicalVendorInvoiceItemRow)
        {
            AddRowToMedicalVendorInvoiceItemTypedView(medicalVendorInvoiceItemRow.CustomerId, medicalVendorInvoiceItemRow.EventId,
                new DateTime(), new DateTime(), 0m, 0);
        }

        private MedicalVendorInvoiceItemRow AddRowToMedicalVendorInvoiceItemTypedView
            (long customerId, long eventId, DateTime evaluationStartTime, DateTime evaluationEndTime, 
            decimal medicalVendorAmountEarned, long PodId)
        {
            _medicalVendorInvoiceItemTypedView.Rows.Add(1, customerId, "FirstName", "MiddleName", "LastName", new DateTime(), eventId, 
                "EventName", new DateTime(), PodId, "PodName", medicalVendorAmountEarned, 13, evaluationStartTime, evaluationEndTime);
            return _medicalVendorInvoiceItemTypedView.Last();
        }

        #endregion

        [Test]
        [ExpectedException(typeof(ArgumentNullException))]
        public void CreateMedicalVendorInvoiceItemsThrowsExceptionWhenGivenNullDataRows()
        {
            _mocks.ReplayAll();
            _medicalVendorInvoiceItemFactory.CreateMedicalVendorInvoiceItems((MedicalVendorInvoiceItemTypedView)null);
            _mocks.VerifyAll();
        }

        [Test]
        public void CreateMedicalVendorInvoiceReturnsEmptyListWhenEmptyRowCollectionGiven()
        {
            _mocks.ReplayAll();
            List<MedicalVendorInvoiceItem> medicalVendorInvoiceItems = _medicalVendorInvoiceItemFactory.
                CreateMedicalVendorInvoiceItems(_medicalVendorInvoiceItemTypedView);
            _mocks.VerifyAll();

            Assert.IsNotNull(medicalVendorInvoiceItems);
            Assert.IsEmpty(medicalVendorInvoiceItems);
        }

        [Test]
        public void CreateMedicalVendorInvoiceReturnsOneItemWhenOneRowGiven()
        {
            MedicalVendorInvoiceItemRow medicalVendorInvoiceItemRow = AddRowToMedicalVendorInvoiceItemTypedView();
            ExpectCreateMedicalVendorMedicalVendorUser(medicalVendorInvoiceItemRow);

            _mocks.ReplayAll();
            List<MedicalVendorInvoiceItem> medicalVendorInvoiceItems = _medicalVendorInvoiceItemFactory.
                CreateMedicalVendorInvoiceItems(_medicalVendorInvoiceItemTypedView);
            _mocks.VerifyAll();

            Assert.IsTrue(medicalVendorInvoiceItems.HasSingleItem());
        }

        [Test]
        public void CreateMedicalVendorInvoiceReturnsTwoItemsWhenGivenTwoUniqueRows()
        {
            const long eventId = 7;
            const long customerId = 5;
            MedicalVendorInvoiceItemRow medicalVendorInvoiceItemRow1 = AddRowToMedicalVendorInvoiceItemTypedView(customerId, eventId);
            AddRowToMedicalVendorInvoiceItemTypedView(medicalVendorInvoiceItemRow1);
            MedicalVendorInvoiceItemRow medicalVendorInvoiceItemRow2 = AddRowToMedicalVendorInvoiceItemTypedView(customerId + 1, eventId);
            ExpectCreateMedicalVendorMedicalVendorUser(medicalVendorInvoiceItemRow1);
            ExpectCreateMedicalVendorMedicalVendorUser(medicalVendorInvoiceItemRow2);

            _mocks.ReplayAll();
            List<MedicalVendorInvoiceItem> medicalVendorInvoiceItems = _medicalVendorInvoiceItemFactory.
                CreateMedicalVendorInvoiceItems(_medicalVendorInvoiceItemTypedView);
            _mocks.VerifyAll();

            const int expectedNumberOfInvoiceItems = 2;
            Assert.AreEqual(expectedNumberOfInvoiceItems, medicalVendorInvoiceItems.Count);

        }

        [Test]
        public void CreateMedicalVendorInvoiceReturnsThreeItemsWhenThreeUniqueRowsGiven()
        {
            const long eventId = 7;
            const long customerId = 5;
            ExpectCreateMedicalVendorMedicalVendorUser(AddRowToMedicalVendorInvoiceItemTypedView(customerId, eventId));
            ExpectCreateMedicalVendorMedicalVendorUser(AddRowToMedicalVendorInvoiceItemTypedView(customerId + 1, eventId));
            ExpectCreateMedicalVendorMedicalVendorUser(AddRowToMedicalVendorInvoiceItemTypedView(customerId, eventId + 1));
            
            _mocks.ReplayAll();
            List<MedicalVendorInvoiceItem> medicalVendorInvoiceItems = _medicalVendorInvoiceItemFactory.
                CreateMedicalVendorInvoiceItems(_medicalVendorInvoiceItemTypedView);
            _mocks.VerifyAll();

            const int expectedNumberOfInvoiceItems = 3;
            Assert.AreEqual(expectedNumberOfInvoiceItems, medicalVendorInvoiceItems.Count);
        }

        [Test]
        public void CreateMedicalVendorInvoiceReturnsOneItemWhenGivenTwoRowsWithSameCustomerIdAndEventId()
        {
            const long eventId = 7;
            const long customerId = 8;
            MedicalVendorInvoiceItemRow medicalVendorInvoiceItemRow = AddRowToMedicalVendorInvoiceItemTypedView
                (customerId, eventId);
            AddRowToMedicalVendorInvoiceItemTypedView(medicalVendorInvoiceItemRow);
            
            ExpectCreateMedicalVendorMedicalVendorUser(medicalVendorInvoiceItemRow);

            _mocks.ReplayAll();
            List<MedicalVendorInvoiceItem> medicalVendorInvoiceItems = _medicalVendorInvoiceItemFactory.
                CreateMedicalVendorInvoiceItems(_medicalVendorInvoiceItemTypedView);
            _mocks.VerifyAll();

            Assert.IsTrue(medicalVendorInvoiceItems.HasSingleItem());
        }

        [Test]
        [ExpectedException(typeof(ArgumentNullException))]
        public void CreateMedicalVendorInvoiceItemThrowsExceptionWhenNullRowGiven()
        {
            _mocks.ReplayAll();
            _medicalVendorInvoiceItemFactory.CreateMedicalVendorInvoiceItem((MedicalVendorInvoiceItemRow)null);
            _mocks.VerifyAll();
        }

        [Test]
        public void CreateMedicalVendorInvoiceItemSetsCustomerNameToMVMVUserFullName()
        {
            AddRowToMedicalVendorInvoiceItemTypedView();
            MedicalVendorInvoiceItemRow medicalVendorInvoiceItemRow = _medicalVendorInvoiceItemTypedView[0];
            var medicalVendorMedicalVendorUser = new MedicalVendorMedicalVendorUser { Name = new Name("F", "M", "L") };
            Expect.Call(_medicalVendorMedicalVendorUserFactory.CreateMedicalVendorMedicalVendorUser(medicalVendorInvoiceItemRow))
                .Return(medicalVendorMedicalVendorUser);

            _mocks.ReplayAll();
            MedicalVendorInvoiceItem medicalVendorInvoiceItem = _medicalVendorInvoiceItemFactory.
                CreateMedicalVendorInvoiceItem(medicalVendorInvoiceItemRow);
            _mocks.VerifyAll();

            Assert.AreEqual(medicalVendorMedicalVendorUser.Name.FullName, medicalVendorInvoiceItem.CustomerName);
        }

        [Test]
        public void CreateMedicalVendorInvoiceItemSetsPodIdToPodIdFromView()
        {
            const long expectedPodId = 234;
            AddRowToMedicalVendorInvoiceItemTypedView(expectedPodId);
            Expect.Call(_medicalVendorMedicalVendorUserFactory.CreateMedicalVendorMedicalVendorUser((MedicalVendorInvoiceItemRow)null)).
                IgnoreArguments().Return(new MedicalVendorMedicalVendorUser { Name = new Name() });

            _mocks.ReplayAll();
            MedicalVendorInvoiceItem medicalVendorInvoiceItem = _medicalVendorInvoiceItemFactory.
                CreateMedicalVendorInvoiceItem(_medicalVendorInvoiceItemTypedView[0]);
            _mocks.VerifyAll();

            Assert.AreEqual(expectedPodId, medicalVendorInvoiceItem.PodId);
        }

        [Test]
        public void CreateMedicalVendorInvoiceItemSetsDomainPropertiesToRowPropertiesCorrectly()
        {
            const long customerId = 1;
            var evaluationStartTime = new DateTime(2003, 5, 4);
            const decimal medicalVendorAmountEarned = 23.55m;
            AddRowToMedicalVendorInvoiceItemTypedView(customerId, evaluationStartTime, medicalVendorAmountEarned);
            Expect.Call(_medicalVendorMedicalVendorUserFactory.CreateMedicalVendorMedicalVendorUser((MedicalVendorInvoiceItemRow)null)).
                IgnoreArguments().Return(new MedicalVendorMedicalVendorUser {Name = new Name()});

            _mocks.ReplayAll();
            MedicalVendorInvoiceItem medicalVendorInvoiceItem = _medicalVendorInvoiceItemFactory.
                CreateMedicalVendorInvoiceItem(_medicalVendorInvoiceItemTypedView[0]);
            _mocks.VerifyAll();

            Assert.AreEqual(customerId, medicalVendorInvoiceItem.CustomerId);
            Assert.AreEqual(evaluationStartTime, medicalVendorInvoiceItem.EvaluationStartTime);
            Assert.AreEqual(medicalVendorAmountEarned, medicalVendorInvoiceItem.MedicalVendorAmountEarned);
        }

        [Test]
        public void CreateMedicalVendorInvoiceItemSetsEvaluationTimesToNullWhenMinDateGiven()
        {
            var evaluationStartTime = DateTime.MinValue;
            var evaluationEndTime = DateTime.MinValue;
            AddRowToMedicalVendorInvoiceItemTypedView(evaluationStartTime, evaluationEndTime);
            
            Expect.Call(_medicalVendorMedicalVendorUserFactory.CreateMedicalVendorMedicalVendorUser((MedicalVendorInvoiceItemRow)null)).
                IgnoreArguments().Return(new MedicalVendorMedicalVendorUser { Name = new Name() });

            _mocks.ReplayAll();
            MedicalVendorInvoiceItem medicalVendorInvoiceItem = _medicalVendorInvoiceItemFactory.
                CreateMedicalVendorInvoiceItem(_medicalVendorInvoiceItemTypedView[0]);
            _mocks.VerifyAll();

            Assert.IsNull(medicalVendorInvoiceItem.EvaluationStartTime, "EvaluationStartTime not set to null.");
            Assert.IsNull(medicalVendorInvoiceItem.EvaluationEndTime, "EvaluationEndTime not set to null.");
        }

        [Test]
        [ExpectedException(typeof(ArgumentNullException))]
        public void GetMedicalVendorInvoiceItemThrowsExceptionWhenNullGiven()
        {
            _medicalVendorInvoiceItemFactory.CreateMedicalVendorInvoiceItem((PhysicianInvoiceItemEntity)null);
        }

        [Test]
        public void GetMedicalVendorInvoiceItemReturnsMedicalVendorInvoiceItemWhenGivenEntity()
        {
            MedicalVendorInvoiceItem medicalVendorInvoiceItem = _medicalVendorInvoiceItemFactory.
                CreateMedicalVendorInvoiceItem(new PhysicianInvoiceItemEntity());
            Assert.IsNotNull(medicalVendorInvoiceItem);
        }

        [Test]
        public void GetMedicalVendorInvoiceItemMapsEntityPropertiesToDomainPropertiesCorrectly()
        {
            var medicalVendorInvoiceItemEntity = new PhysicianInvoiceItemEntity(33)
            {
                AmountEarned = 5.44m,
                CustomerName = "CustomerName",
            };

            MedicalVendorInvoiceItem medicalVendorInvoiceItem = _medicalVendorInvoiceItemFactory.
                CreateMedicalVendorInvoiceItem(medicalVendorInvoiceItemEntity);

            Assert.AreEqual(medicalVendorInvoiceItemEntity.PhysicianInvoiceItemId, medicalVendorInvoiceItem.Id);
            Assert.AreEqual(medicalVendorInvoiceItemEntity.AmountEarned,
                            medicalVendorInvoiceItem.OrganizationRoleUserAmountEarned);
            Assert.AreEqual(medicalVendorInvoiceItemEntity.CustomerName, medicalVendorInvoiceItem.CustomerName);
        }

        [Test]
        [ExpectedException(typeof(ArgumentNullException))]
        public void GetMedicalVendorInvoiceItemsThrowsExceptionWhenNullEntityCollectionGiven()
        {
            _medicalVendorInvoiceItemFactory.CreateMedicalVendorInvoiceItems((EntityCollection<PhysicianInvoiceItemEntity>)null);
        }

        [Test]
        public void GetMedicalVendorInvoiceItemsReturnsEmptyListWhenEmptyCollectionGiven()
        {
            List<MedicalVendorInvoiceItem> medicalVendorInvoiceItems = _medicalVendorInvoiceItemFactory.
                CreateMedicalVendorInvoiceItems(new EntityCollection<PhysicianInvoiceItemEntity>());

            Assert.IsNotNull(medicalVendorInvoiceItems);
            Assert.IsEmpty(medicalVendorInvoiceItems);
        }

        [Test]
        public void GetMedicalVendorInvoiceItemsReturnsNumberOfItemsEqualToNumberInCollection()
        {
            var medicalVendorInvoiceItemEntities = new EntityCollection<PhysicianInvoiceItemEntity>();
            for (int i = 0; i < 5; i++)
            {
                medicalVendorInvoiceItemEntities.Add(new PhysicianInvoiceItemEntity());
                List<MedicalVendorInvoiceItem> medicalVendorInvoiceItems = _medicalVendorInvoiceItemFactory.
                    CreateMedicalVendorInvoiceItems(medicalVendorInvoiceItemEntities);
                Assert.AreEqual(medicalVendorInvoiceItemEntities.Count, medicalVendorInvoiceItems.Count,
                    string.Format("{0} entities given but {1} returned.", medicalVendorInvoiceItemEntities.Count,
                    medicalVendorInvoiceItems.Count));
            }
        }

        [Test]
        [ExpectedException(typeof(ArgumentNullException))]
        public void CreateMedicalVendorInvoiceItemEntityThrowsExceptionWhenNullInvoiceItemGiven()
        {
            _medicalVendorInvoiceItemFactory.CreateMedicalVendorInvoiceItemEntity(0, null);
        }

        [Test]
        public void CreateMedicalVendorInvoiceItemEntitySetsGivenIdToMedicalVendorInvoiceId()
        {
            const long medicalVendorInvoiceId = 5;

            PhysicianInvoiceItemEntity medicalVendorInvoiceItemEntity = _medicalVendorInvoiceItemFactory.CreateMedicalVendorInvoiceItemEntity
                (medicalVendorInvoiceId, new MedicalVendorInvoiceItem());

            Assert.AreEqual(medicalVendorInvoiceId, medicalVendorInvoiceItemEntity.PhysicianInvoiceId);
        }

        [Test]
        public void CreateMedicalVendorInvoiceItemEntitySetsPodIdToEntityPodId()
        {
            const long expectedPodId = 533;

            PhysicianInvoiceItemEntity medicalVendorInvoiceItemEntity = _medicalVendorInvoiceItemFactory.
                CreateMedicalVendorInvoiceItemEntity(0, new MedicalVendorInvoiceItem { PodId = expectedPodId });

            Assert.AreEqual(expectedPodId, medicalVendorInvoiceItemEntity.PodId);
        }

        [Test]
        public void CreateMedicalVendorInvoiceItemEntitySetsEntityPropertiesToItemPropertiesCorrectly()
        {
            var medicalVendorInvoiceItem = new MedicalVendorInvoiceItem
            {
                CustomerId = 5,
                MedicalVendorAmountEarned = 23m, 
                EventDate = new DateTime(2006, 3, 2),
                EventName = "Name"
            };

            PhysicianInvoiceItemEntity medicalVendorInvoiceItemEntity = _medicalVendorInvoiceItemFactory.CreateMedicalVendorInvoiceItemEntity
                (0, medicalVendorInvoiceItem);

            Assert.AreEqual(medicalVendorInvoiceItem.CustomerId, medicalVendorInvoiceItemEntity.CustomerId);
            Assert.AreEqual(medicalVendorInvoiceItem.MedicalVendorAmountEarned, medicalVendorInvoiceItemEntity.AmountEarned);
            Assert.AreEqual(medicalVendorInvoiceItem.EventDate, medicalVendorInvoiceItemEntity.EventDate);
            Assert.AreEqual(medicalVendorInvoiceItem.EventName, medicalVendorInvoiceItemEntity.EventName);
        }

        [Test]
        [ExpectedException(typeof(ArgumentNullException))]
        public void CreateMedicalVendorInvoiceItemEntitiesThrowsExceptionWhenNullListGiven()
        {
            _medicalVendorInvoiceItemFactory.CreateMedicalVendorInvoiceItemEntities(0, null);
        }

        [Test]
        public void CreateMedicalVendorInvoiceItemEntitiesReturnsEmptyCollectionWhenEmptyListGiven()
        {
            var medicalVendorInvoiceItems = new List<MedicalVendorInvoiceItem>();
            
            EntityCollection<PhysicianInvoiceItemEntity> medicalVendorInvoiceItemEntities = _medicalVendorInvoiceItemFactory.
                CreateMedicalVendorInvoiceItemEntities(0, medicalVendorInvoiceItems);
            
            Assert.IsEmpty(medicalVendorInvoiceItemEntities);
        }

        [Test]
        public void CreateMedicalVendorInvoiceItemEntitiesReturnsOneEntityWhenOneItemGiven()
        {
            var medicalVendorInvoiceItems = new List<MedicalVendorInvoiceItem> {new MedicalVendorInvoiceItem()};

            EntityCollection<PhysicianInvoiceItemEntity> medicalVendorInvoiceItemEntities = _medicalVendorInvoiceItemFactory.
                CreateMedicalVendorInvoiceItemEntities(0, medicalVendorInvoiceItems);

            Assert.IsTrue(medicalVendorInvoiceItemEntities.HasSingleItem(), 
                string.Format("Single item expected but {0} returned.", medicalVendorInvoiceItemEntities.Count));
        }

        [Test]
        public void CreateMedicalVendorInvoiceItemEntitesReturnsOneEntityPerListItem()
        {
            var medicalVendorInvoiceItems = new List<MedicalVendorInvoiceItem> {new MedicalVendorInvoiceItem()};

            for (int i = 2; i < 10; i++)
            {
                medicalVendorInvoiceItems.Add(new MedicalVendorInvoiceItem());
                EntityCollection<PhysicianInvoiceItemEntity> medicalVendorInvoiceItemEntities = _medicalVendorInvoiceItemFactory.
                    CreateMedicalVendorInvoiceItemEntities(0, medicalVendorInvoiceItems);
                Assert.AreEqual(medicalVendorInvoiceItems.Count, medicalVendorInvoiceItemEntities.Count,
                    string.Format("{0} items given but {1} entities returned.", medicalVendorInvoiceItems.Count,
                    medicalVendorInvoiceItemEntities.Count));
            }
        }

        [Test]
        public void CreateMedicalVendorInvoiceItemEntitiesSetsAllMedicalVendorInvoiceIdsToGivenId()
        {
            const long expectedMedicalVendorInvoiceId = 23;
            var medicalVendorInvoiceItems = new List<MedicalVendorInvoiceItem> 
                { new MedicalVendorInvoiceItem(), new MedicalVendorInvoiceItem(), new MedicalVendorInvoiceItem() };

            EntityCollection<PhysicianInvoiceItemEntity> medicalVendorInvoiceItemEntities = _medicalVendorInvoiceItemFactory.
                CreateMedicalVendorInvoiceItemEntities(expectedMedicalVendorInvoiceId, medicalVendorInvoiceItems);

            foreach (PhysicianInvoiceItemEntity medicalVendorInvoiceItemEntity in medicalVendorInvoiceItemEntities)
            {
                Assert.AreEqual(expectedMedicalVendorInvoiceId, medicalVendorInvoiceItemEntity.PhysicianInvoiceId,
                    string.Format("PhysicianInvoiceItemEntity {0} returned incorrect ID.",
                    medicalVendorInvoiceItemEntity.PhysicianInvoiceId));
            }
        }
    }
}