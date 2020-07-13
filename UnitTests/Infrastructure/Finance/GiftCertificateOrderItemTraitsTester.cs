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
    public class GiftCertificateOrderItemTraitsTester
    {
        private readonly IOrderItemTraits _giftCertificateOrderItemTraits = new GiftCertificateOrderItemTraits();

        [Test]
        [Ignore("Need to find a way to compare predicates.")]
        public void ItemIdPredicateReturnsPredicateComparingGiftCertificateIdToGivenId()
        {
            const int giftCertificateOrderItemId = 234;
            IPredicate expectedPredicate = GiftCertificateOrderItemFields.GiftCertificateId == giftCertificateOrderItemId;

            IPredicate predicate = _giftCertificateOrderItemTraits.ItemIdPredicate(giftCertificateOrderItemId);

            Assert.AreEqual(expectedPredicate, predicate, "ItemIdPredicate returned incorrect predicate.");
        }

        [Test]
        [Ignore("Need to find a way to compare predicates.")]
        public void OrderItemIdPredicateReturnsPredicateComparingOrderItemIdToGivenId()
        {
            const int orderItemId = 38;
            IPredicate expectedPredicate = GiftCertificateOrderItemFields.OrderItemId == orderItemId;

            IPredicate predicate = _giftCertificateOrderItemTraits.ItemIdPredicate(orderItemId);

            Assert.AreEqual(expectedPredicate, predicate, "OrderItemIdPredicate returned incorrect predicate.");
        }

        [Test]
        public void CreateItemEntityReturnsGiftCertificateOrderItemEntity()
        {
            IEntity2 entity = _giftCertificateOrderItemTraits.CreateItemEntity(0, 0);

            Assert.IsInstanceOf<GiftCertificateOrderItemEntity>(entity, "CreateItemEntity returned incorrect type of entity.");
        }

        [Test]
        public void CreateItemEntitySetsEntityOrderItemIdToGivenOrderItemId()
        {
            const int expectedOrderItemId = 283;

            var giftCertificateOrderItemEntity = (GiftCertificateOrderItemEntity)_giftCertificateOrderItemTraits.
                CreateItemEntity(expectedOrderItemId, 0);

            Assert.AreEqual(expectedOrderItemId, giftCertificateOrderItemEntity.OrderItemId,
                "CreateItemEntity set GiftCertificateId incorrectly.");
        }

        [Test]
        public void CreateItemEntitySetsEntityGiftCertificateIdToGivenGiftCertificateId()
        {
            const int expectedGiftCertificateId = 898;

            var giftCertificateOrderItemEntity = (GiftCertificateOrderItemEntity)_giftCertificateOrderItemTraits.
                CreateItemEntity(0, expectedGiftCertificateId);

            Assert.AreEqual(expectedGiftCertificateId, giftCertificateOrderItemEntity.GiftCertificateId,
                "CreateItemEntity set GiftCertificateId incorrectly.");
        }

        [Test]
        public void CreateOrderItemReturnsGiftCertificateItem()
        {
            OrderItem orderItem = _giftCertificateOrderItemTraits.CreateOrderItem(0, 0);

            Assert.IsInstanceOf<GiftCertificateItem>(orderItem, "CreateOrderItem returned OrderItem of incorrect derived type.");
        }

        [Test]
        public void CreateOrderItemSetsIdToGivenOrderItemId()
        {
            const int expectedOrderItemId = 2388;

            OrderItem orderItem = _giftCertificateOrderItemTraits.CreateOrderItem(expectedOrderItemId, 0);

            Assert.AreEqual(expectedOrderItemId, orderItem.Id, "CreateOrderItem set OrderItemID incorrectly.");
        }

        [Test]
        public void CreateOrderItemSetsItemIdToGivenGiftCertificateId()
        {
            const long expectedItemId = 9999999999;

            OrderItem orderItem = _giftCertificateOrderItemTraits.CreateOrderItem(0, expectedItemId);

            Assert.AreEqual(expectedItemId, orderItem.ItemId, "CreateOrderItem set ItemID incorrectly.");
        }

        [Test]
        public void CreateItemEntityCollectionReturnsEntityCollectionOfGiftCertificateOrderItemEntities()
        {
            IEntityCollection2 entityCollection = _giftCertificateOrderItemTraits.CreateItemEntityCollection();

            Assert.IsInstanceOf<EntityCollection<GiftCertificateOrderItemEntity>>(entityCollection, "CreateItemEntityCollection returned collection of wrong type.");
        }

        [Test]
        public void CreateItemEntityCollectionReturnsEmptyEntityCollection()
        {
            const int expectedNumberOfEntities = 0;

            IEntityCollection2 entityCollection = _giftCertificateOrderItemTraits.CreateItemEntityCollection();

            Assert.AreEqual(expectedNumberOfEntities, entityCollection.Count, "CreateItemEntityCollection returned nonempty collection of entities.");
        }

        [Test]
        public void GetItemIdReturnsGivenEntityGiftCertificateId()
        {
            const int expectedItemId = 29;
            var giftCertificateOrderItemEntity = new GiftCertificateOrderItemEntity(0, expectedItemId);

            long itemId = _giftCertificateOrderItemTraits.GetItemId(giftCertificateOrderItemEntity);

            Assert.AreEqual(expectedItemId, itemId, "GetItemId returned incorrect ID.");
        }

        [Test]
        [ExpectedException(typeof(ArgumentException))]
        public void GetItemIdThrowsExceptionIfEntityTypeIsNotGiftCertificateOrderItemEntity()
        {
            _giftCertificateOrderItemTraits.GetItemId(new FakeEntity());
        }

        [Test]
        [ExpectedException(typeof(ArgumentNullException))]
        public void GetItemIdThrowsExceptionWhenGivenNullEntity()
        {
            _giftCertificateOrderItemTraits.GetItemId(null);
        }
    }
}