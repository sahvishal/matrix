using System;
using Falcon.App.Core.Finance.Domain;
using Falcon.App.Infrastructure.Finance.Impl;
using Falcon.App.Infrastructure.Finance.Interfaces;
using Falcon.Data.EntityClasses;
using Falcon.Data.HelperClasses;
using NUnit.Framework;
using SD.LLBLGen.Pro.ORMSupportClasses;

namespace Falcon.UnitTests.Infrastructure.Finance
{
    [TestFixture]
    public class TestOrderItemTraitsTester
    {
        private readonly IOrderItemTraits _testOrderItemTraits = new EventTestOrderItemTraits();

        [Test]
        [Ignore("Need to find a way to compare predicates.")]
        public void ItemIdPredicateReturnsPredicateComparingTestIdToGivenId()
        {
            const int testOrderItemId = 234;
            IPredicate expectedPredicate = TestOrderItemFields.TestId == testOrderItemId;

            IPredicate predicate = _testOrderItemTraits.ItemIdPredicate(testOrderItemId);

            Assert.AreEqual(expectedPredicate, predicate, "ItemIdPredicate returned incorrect predicate.");
        }

        [Test]
        [Ignore("Need to find a way to compare predicates.")]
        public void OrderItemIdPredicateReturnsPredicateComparingOrderItemIdToGivenId()
        {
            const int orderItemId = 38;
            IPredicate expectedPredicate = TestOrderItemFields.OrderItemId == orderItemId;

            IPredicate predicate = _testOrderItemTraits.ItemIdPredicate(orderItemId);

            Assert.AreEqual(expectedPredicate, predicate, "OrderItemIdPredicate returned incorrect predicate.");
        }

        [Test]
        public void CreateItemEntityReturnsTestOrderItemEntity()
        {
            IEntity2 entity = _testOrderItemTraits.CreateItemEntity(0, 0);

            Assert.IsInstanceOf<EventTestOrderItemEntity>(entity, "CreateItemEntity returned incorrect type of entity.");
        }

        [Test]
        public void CreateItemEntitySetsEntityOrderItemIdToGivenOrderItemId()
        {
            const int expectedOrderItemId = 283;

            var testOrderItemEntity = (EventTestOrderItemEntity)_testOrderItemTraits.
                CreateItemEntity(expectedOrderItemId, 0);

            Assert.AreEqual(expectedOrderItemId, testOrderItemEntity.OrderItemId,
                "CreateItemEntity set TestId incorrectly.");
        }

        [Test]
        public void CreateItemEntitySetsEntityTestIdToGivenTestId()
        {
            const int expectedTestId = 898;

            var testOrderItemEntity = (EventTestOrderItemEntity)_testOrderItemTraits.
                CreateItemEntity(0, expectedTestId);

            Assert.AreEqual(expectedTestId, testOrderItemEntity.EventTestId,
                "CreateItemEntity set TestId incorrectly.");
        }

        [Test]
        public void CreateOrderItemReturnsTestItem()
        {
            OrderItem orderItem = _testOrderItemTraits.CreateOrderItem(0, 0);

            Assert.IsInstanceOf<EventTestItem>(orderItem, "CreateOrderItem returned OrderItem of incorrect derived type.");
        }

        [Test]
        public void CreateOrderItemSetsIdToGivenOrderItemId()
        {
            const int expectedOrderItemId = 2388;

            OrderItem orderItem = _testOrderItemTraits.CreateOrderItem(expectedOrderItemId, 0);

            Assert.AreEqual(expectedOrderItemId, orderItem.Id, "CreateOrderItem set OrderItemID incorrectly.");
        }

        [Test]
        public void CreateOrderItemSetsItemIdToGivenTestId()
        {
            const long expectedItemId = 9999999999;

            OrderItem orderItem = _testOrderItemTraits.CreateOrderItem(0, expectedItemId);

            Assert.AreEqual(expectedItemId, orderItem.ItemId, "CreateOrderItem set ItemID incorrectly.");
        }

        [Test]
        public void CreateItemEntityCollectionReturnsEntityCollectionOfTestOrderItemEntities()
        {
            IEntityCollection2 entityCollection = _testOrderItemTraits.CreateItemEntityCollection();

            Assert.IsInstanceOf<EntityCollection<EventTestOrderItemEntity>>(entityCollection, "CreateItemEntityCollection returned collection of wrong type.");
        }

        [Test]
        public void CreateItemEntityCollectionReturnsEmptyEntityCollection()
        {
            const int expectedNumberOfEntities = 0;

            IEntityCollection2 entityCollection = _testOrderItemTraits.CreateItemEntityCollection();

            Assert.AreEqual(expectedNumberOfEntities, entityCollection.Count, "CreateItemEntityCollection returned nonempty collection of entities.");
        }

        [Test]
        public void GetItemIdReturnsGivenEntityTestId()
        {
            const int expectedItemId = 29;
            var testOrderItemEntity = new EventTestOrderItemEntity(0, expectedItemId);

            long itemId = _testOrderItemTraits.GetItemId(testOrderItemEntity);

            Assert.AreEqual(expectedItemId, itemId, "GetItemId returned incorrect ID.");
        }

        [Test]
        [ExpectedException(typeof(ArgumentException))]
        public void GetItemIdThrowsExceptionIfEntityTypeIsNotProductOrderItemEntity()
        {
            _testOrderItemTraits.GetItemId(new TerritoryEntity());
        }

        [Test]
        [ExpectedException(typeof(ArgumentNullException))]
        public void GetItemIdThrowsExceptionWhenGivenNullEntity()
        {
            _testOrderItemTraits.GetItemId(null);
        }
    }
}