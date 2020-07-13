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
    public class RefundOrderItemTraitsTester
    {
        private readonly IOrderItemTraits _refundOrderItemTraits = new RefundOrderItemTraits();

        [Test]
        [Ignore("Need to find a way to compare predicates.")]
        public void ItemIdPredicateReturnsPredicateComparingRefundIdToGivenId()
        {
            const int refundOrderItemId = 234;
            IPredicate expectedPredicate = RefundOrderItemFields.RefundId == refundOrderItemId;

            IPredicate predicate = _refundOrderItemTraits.ItemIdPredicate(refundOrderItemId);

            Assert.AreEqual(expectedPredicate, predicate, "ItemIdPredicate returned incorrect predicate.");
        }

        [Test]
        [Ignore("Need to find a way to compare predicates.")]
        public void OrderItemIdPredicateReturnsPredicateComparingOrderItemIdToGivenId()
        {
            const int orderItemId = 38;
            IPredicate expectedPredicate = RefundOrderItemFields.OrderItemId == orderItemId;

            IPredicate predicate = _refundOrderItemTraits.ItemIdPredicate(orderItemId);

            Assert.AreEqual(expectedPredicate, predicate, "OrderItemIdPredicate returned incorrect predicate.");
        }

        [Test]
        public void CreateItemEntityReturnsRefundOrderItemEntity()
        {
            IEntity2 entity = _refundOrderItemTraits.CreateItemEntity(0, 0);

            Assert.IsInstanceOf<RefundOrderItemEntity>(entity, "CreateItemEntity returned incorrect type of entity.");
        }

        [Test]
        public void CreateItemEntitySetsEntityOrderItemIdToGivenOrderItemId()
        {
            const int expectedOrderItemId = 283;

            var refundOrderItemEntity = (RefundOrderItemEntity)_refundOrderItemTraits.
                CreateItemEntity(expectedOrderItemId, 0);

            Assert.AreEqual(expectedOrderItemId, refundOrderItemEntity.OrderItemId,
                "CreateItemEntity set RefundId incorrectly.");
        }

        [Test]
        public void CreateItemEntitySetsEntityRefundIdToGivenRefundId()
        {
            const int expectedRefundId = 898;

            var refundOrderItemEntity = (RefundOrderItemEntity)_refundOrderItemTraits.
                CreateItemEntity(0, expectedRefundId);

            Assert.AreEqual(expectedRefundId, refundOrderItemEntity.RefundId,
                "CreateItemEntity set RefundId incorrectly.");
        }

        [Test]
        public void CreateOrderItemReturnsRefundItem()
        {
            OrderItem orderItem = _refundOrderItemTraits.CreateOrderItem(0, 0);

            Assert.IsInstanceOf<RefundItem>(orderItem, "CreateOrderItem returned OrderItem of incorrect derived type.");
        }

        [Test]
        public void CreateOrderItemSetsIdToGivenOrderItemId()
        {
            const int expectedOrderItemId = 2388;

            OrderItem orderItem = _refundOrderItemTraits.CreateOrderItem(expectedOrderItemId, 0);

            Assert.AreEqual(expectedOrderItemId, orderItem.Id, "CreateOrderItem set OrderItemID incorrectly.");
        }

        [Test]
        public void CreateOrderItemSetsItemIdToGivenRefundId()
        {
            const long expectedItemId = 9999999999;

            OrderItem orderItem = _refundOrderItemTraits.CreateOrderItem(0, expectedItemId);

            Assert.AreEqual(expectedItemId, orderItem.ItemId, "CreateOrderItem set ItemID incorrectly.");
        }

        [Test]
        public void CreateItemEntityCollectionReturnsEntityCollectionOfRefundOrderItemEntities()
        {
            IEntityCollection2 entityCollection = _refundOrderItemTraits.CreateItemEntityCollection();

            Assert.IsInstanceOf<EntityCollection<RefundOrderItemEntity>>(entityCollection, "CreateItemEntityCollection returned collection of wrong type.");
        }

        [Test]
        public void CreateItemEntityCollectionReturnsEmptyEntityCollection()
        {
            const int expectedNumberOfEntities = 0;

            IEntityCollection2 entityCollection = _refundOrderItemTraits.CreateItemEntityCollection();

            Assert.AreEqual(expectedNumberOfEntities, entityCollection.Count, "CreateItemEntityCollection returned nonempty collection of entities.");
        }

        [Test]
        public void GetItemIdReturnsGivenEntityRefundId()
        {
            const int expectedItemId = 29;
            var refundOrderItemEntity = new RefundOrderItemEntity(0, expectedItemId);

            long itemId = _refundOrderItemTraits.GetItemId(refundOrderItemEntity);

            Assert.AreEqual(expectedItemId, itemId, "GetItemId returned incorrect ID.");
        }

        [Test]
        [ExpectedException(typeof(ArgumentException))]
        public void GetItemIdThrowsExceptionIfEntityTypeIsNotProductOrderItemEntity()
        {
            _refundOrderItemTraits.GetItemId(new TerritoryEntity());
        }

        [Test]
        [ExpectedException(typeof(ArgumentNullException))]
        public void GetItemIdThrowsExceptionWhenGivenNullEntity()
        {
            _refundOrderItemTraits.GetItemId(null);
        }
    }
}