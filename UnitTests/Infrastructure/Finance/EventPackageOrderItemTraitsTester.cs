using System;
using Falcon.App.Core.Finance.Domain;
using Falcon.App.Infrastructure.Finance.Impl;
using Falcon.App.Infrastructure.Finance.Interfaces;
using Falcon.Data.EntityClasses;
using Falcon.Data.HelperClasses;
using HealthYes.Web.UnitTests.Fakes;
using NUnit.Framework;
using SD.LLBLGen.Pro.ORMSupportClasses;

namespace Falcon.UnitTests.Infrastructure.Finance
{
    [TestFixture]
    public class EventPackageOrderItemTraitsTester
    {
        private readonly IOrderItemTraits _eventPackageOrderItemTraits = new EventPackageOrderItemTraits();

        [Test]
        [Ignore("Need to find a way to compare predicates.")]
        public void ItemIdPredicateReturnsPredicateComparingEventPackageIdToGivenId()
        {
            const int eventPackageOrderItemId = 234;
            IPredicate expectedPredicate = EventPackageOrderItemFields.EventPackageId == eventPackageOrderItemId;

            IPredicate predicate = _eventPackageOrderItemTraits.ItemIdPredicate(eventPackageOrderItemId);

            Assert.AreEqual(expectedPredicate, predicate, "ItemIdPredicate returned incorrect predicate.");
        }

        [Test]
        [Ignore("Need to find a way to compare predicates.")]
        public void OrderItemIdPredicateReturnsPredicateComparingOrderItemIdToGivenId()
        {
            const int orderItemId = 38;
            IPredicate expectedPredicate = EventPackageOrderItemFields.OrderItemId == orderItemId;

            IPredicate predicate = _eventPackageOrderItemTraits.ItemIdPredicate(orderItemId);

            Assert.AreEqual(expectedPredicate, predicate, "OrderItemIdPredicate returned incorrect predicate.");
        }

        [Test]
        public void CreateItemEntityReturnsEventPackageOrderItemEntity()
        {
          
            IEntity2 entity = _eventPackageOrderItemTraits.CreateItemEntity(0, 0);

            Assert.IsInstanceOf<EventPackageOrderItemEntity>(entity, "CreateItemEntity returned incorrect type of entity.");
        }

        [Test]
        public void CreateItemEntitySetsEntityOrderItemIdToGivenOrderItemId()
        {
            const int expectedOrderItemId = 283;

            var eventPackageOrderItemEntity = (EventPackageOrderItemEntity)_eventPackageOrderItemTraits.
                CreateItemEntity(expectedOrderItemId, 0);

            Assert.AreEqual(expectedOrderItemId, eventPackageOrderItemEntity.OrderItemId,
                "CreateItemEntity set EventPackageId incorrectly.");
        }

        [Test]
        public void CreateItemEntitySetsEntityEventPackageIdToGivenEventPackageId()
        {
            const int expectedEventPackageId = 898;

            var eventPackageOrderItemEntity = (EventPackageOrderItemEntity)_eventPackageOrderItemTraits.
                CreateItemEntity(0, expectedEventPackageId);

            Assert.AreEqual(expectedEventPackageId, eventPackageOrderItemEntity.EventPackageId,
                "CreateItemEntity set EventPackageId incorrectly.");
        }

        [Test]
        public void CreateOrderItemReturnsEventPackageItem()
        {
            OrderItem orderItem = _eventPackageOrderItemTraits.CreateOrderItem(0, 0);

            Assert.IsInstanceOf<EventPackageItem>(orderItem, "CreateOrderItem returned OrderItem of incorrect derived type.");
        }

        [Test]
        public void CreateOrderItemSetsIdToGivenOrderItemId()
        {
            const int expectedOrderItemId = 2388;

            OrderItem orderItem = _eventPackageOrderItemTraits.CreateOrderItem(expectedOrderItemId, 0);

            Assert.AreEqual(expectedOrderItemId, orderItem.Id, "CreateOrderItem set OrderItemID incorrectly.");
        }

        [Test]
        public void CreateOrderItemSetsItemIdToGivenEventPackageId()
        {
            const long expectedItemId = 9999999999;

            OrderItem orderItem = _eventPackageOrderItemTraits.CreateOrderItem(0, expectedItemId);

            Assert.AreEqual(expectedItemId, orderItem.ItemId, "CreateOrderItem set ItemID incorrectly.");
        }

        [Test]
        public void CreateItemEntityCollectionReturnsEntityCollectionOfEventPackageOrderItemEntities()
        {
            IEntityCollection2 entityCollection = _eventPackageOrderItemTraits.CreateItemEntityCollection();

            Assert.IsInstanceOf<EntityCollection<EventPackageOrderItemEntity>>(entityCollection, "CreateItemEntityCollection returned collection of wrong type.");
        }

        [Test]
        public void CreateItemEntityCollectionReturnsEmptyEntityCollection()
        {
            const int expectedNumberOfEntities = 0;

            IEntityCollection2 entityCollection = _eventPackageOrderItemTraits.CreateItemEntityCollection();

            Assert.AreEqual(expectedNumberOfEntities, entityCollection.Count, "CreateItemEntityCollection returned nonempty collection of entities.");
        }

        [Test]
        public void GetItemIdReturnsGivenEntityEventPackageId()
        {
            const int expectedItemId = 29;
            var eventPackageOrderItemEntity = new EventPackageOrderItemEntity(0, expectedItemId);

            long itemId = _eventPackageOrderItemTraits.GetItemId(eventPackageOrderItemEntity);

            Assert.AreEqual(expectedItemId, itemId, "GetItemId returned incorrect ID.");
        }

        [Test]
        [ExpectedException(typeof(ArgumentException))]
        public void GetItemIdThrowsExceptionIfEntityTypeIsNotEventPackageOrderItemEntity()
        {
            _eventPackageOrderItemTraits.GetItemId(new FakeEntity());
        }

        [Test]
        [ExpectedException(typeof(ArgumentNullException))]
        public void GetItemIdThrowsExceptionWhenGivenNullEntity()
        {
            _eventPackageOrderItemTraits.GetItemId(null);
        }

        [Test]
        public void GetOrderItemIdReturnsGivenEntityOrderItemId()
        {
            const int expectedOrderItemId = 55;
            var eventPackageOrderItemEntity = new EventPackageOrderItemEntity(expectedOrderItemId, 0);

            long orderItemId = _eventPackageOrderItemTraits.GetOrderItemId(eventPackageOrderItemEntity);

            Assert.AreEqual(expectedOrderItemId, orderItemId, "GetOrderItemId returned incorrect ID.");
        }

        [Test]
        [ExpectedException(typeof(ArgumentException))]
        public void GetOrderItemIdThrowsExceptionIfEntityTypeIsNotEventPackageOrderItemEntity()
        {
            _eventPackageOrderItemTraits.GetOrderItemId(new FakeEntity());
        }

        [Test]
        [ExpectedException(typeof(ArgumentNullException))]
        public void GetOrderItemIdThrowsExceptionWhenGivenNullEntity()
        {
            _eventPackageOrderItemTraits.GetOrderItemId(null);
        }
    }
}