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
    public class ProductOrderItemTraitsTester
    {
        private readonly IOrderItemTraits _productOrderItemTraits = new ProductOrderItemTraits();

        [Test]
        [Ignore("Need to find a way to compare predicates.")]
        public void ItemIdPredicateReturnsPredicateComparingProductIdToGivenId()
        {
            const int productOrderItemId = 234;
            IPredicate expectedPredicate = ProductOrderItemFields.ProductId == productOrderItemId;

            IPredicate predicate = _productOrderItemTraits.ItemIdPredicate(productOrderItemId);

            Assert.AreEqual(expectedPredicate, predicate, "ItemIdPredicate returned incorrect predicate.");
        }

        [Test]
        [Ignore("Need to find a way to compare predicates.")]
        public void OrderItemIdPredicateReturnsPredicateComparingOrderItemIdToGivenId()
        {
            const int orderItemId = 38;
            IPredicate expectedPredicate = ProductOrderItemFields.OrderItemId == orderItemId;

            IPredicate predicate = _productOrderItemTraits.ItemIdPredicate(orderItemId);

            Assert.AreEqual(expectedPredicate, predicate, "OrderItemIdPredicate returned incorrect predicate.");
        }

        [Test]
        public void CreateItemEntityReturnsProductOrderItemEntity()
        {
            IEntity2 entity = _productOrderItemTraits.CreateItemEntity(0, 0);

            Assert.IsInstanceOf<ProductOrderItemEntity>(entity, "CreateItemEntity returned incorrect type of entity.");
        }

        [Test]
        public void CreateItemEntitySetsEntityOrderItemIdToGivenOrderItemId()
        {
            const int expectedOrderItemId = 283;

            var productOrderItemEntity = (ProductOrderItemEntity)_productOrderItemTraits.
                CreateItemEntity(expectedOrderItemId, 0);

            Assert.AreEqual(expectedOrderItemId, productOrderItemEntity.OrderItemId,
                "CreateItemEntity set ProductId incorrectly.");
        }

        [Test]
        public void CreateItemEntitySetsEntityProductIdToGivenProductId()
        {
            const int expectedProductId = 898;

            var productOrderItemEntity = (ProductOrderItemEntity)_productOrderItemTraits.
                CreateItemEntity(0, expectedProductId);

            Assert.AreEqual(expectedProductId, productOrderItemEntity.ProductId,
                "CreateItemEntity set ProductId incorrectly.");
        }

        [Test]
        public void CreateOrderItemReturnsProductItem()
        {
            OrderItem orderItem = _productOrderItemTraits.CreateOrderItem(0, 0);

            Assert.IsInstanceOf<ProductItem>(orderItem, "CreateOrderItem returned OrderItem of incorrect derived type.");
        }

        [Test]
        public void CreateOrderItemSetsIdToGivenOrderItemId()
        {
            const int expectedOrderItemId = 2388;

            OrderItem orderItem = _productOrderItemTraits.CreateOrderItem(expectedOrderItemId, 0);

            Assert.AreEqual(expectedOrderItemId, orderItem.Id, "CreateOrderItem set OrderItemID incorrectly.");
        }

        [Test]
        public void CreateOrderItemSetsItemIdToGivenProductId()
        {
            const long expectedItemId = 9999999999;

            OrderItem orderItem = _productOrderItemTraits.CreateOrderItem(0, expectedItemId);

            Assert.AreEqual(expectedItemId, orderItem.ItemId, "CreateOrderItem set ItemID incorrectly.");
        }

        [Test]
        public void CreateItemEntityCollectionReturnsEntityCollectionOfProductOrderItemEntities()
        {
            IEntityCollection2 entityCollection = _productOrderItemTraits.CreateItemEntityCollection();

            Assert.IsInstanceOf<EntityCollection<ProductOrderItemEntity>>(entityCollection, "CreateItemEntityCollection returned collection of wrong type.");
        }

        [Test]
        public void CreateItemEntityCollectionReturnsEmptyEntityCollection()
        {
            const int expectedNumberOfEntities = 0;

            IEntityCollection2 entityCollection = _productOrderItemTraits.CreateItemEntityCollection();

            Assert.AreEqual(expectedNumberOfEntities, entityCollection.Count, "CreateItemEntityCollection returned nonempty collection of entities.");
        }

        [Test]
        public void GetItemIdReturnsGivenEntityProductId()
        {
            const int expectedItemId = 29;
            var productOrderItemEntity = new ProductOrderItemEntity(0, expectedItemId);

            long itemId = _productOrderItemTraits.GetItemId(productOrderItemEntity);

            Assert.AreEqual(expectedItemId, itemId, "GetItemId returned incorrect ID.");
        }

        [Test]
        [ExpectedException(typeof(ArgumentException))]
        public void GetItemIdThrowsExceptionIfEntityTypeIsNotProductOrderItemEntity()
        {
            _productOrderItemTraits.GetItemId(new TerritoryEntity());
        }

        [Test]
        [ExpectedException(typeof(ArgumentNullException))]
        public void GetItemIdThrowsExceptionWhenGivenNullEntity()
        {
            _productOrderItemTraits.GetItemId(null);
        }
    }
}