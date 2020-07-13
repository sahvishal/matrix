using Falcon.App.Core.Enum;
using Falcon.App.Infrastructure.Factories.Order;
using Falcon.App.Infrastructure.Finance.Impl;
using Falcon.App.Infrastructure.Finance.Interfaces;
using NUnit.Framework;
using System;

namespace Falcon.UnitTests.Infrastructure.Factories.Order
{
    [TestFixture]
    public class OrderItemTraitsFactoryTester
    {
        private readonly IOrderItemTraitsFactory _orderItemTraitsFactory = new OrderItemTraitsFactory();

        [Test]
        public void CreateTraitsReturnsGiftCertificateOrderItemTraitsObjectWhenGivenGiftCertificateItemType()
        {
    
            IOrderItemTraits orderItemTraits = _orderItemTraitsFactory.CreateTraits(OrderItemType.GiftCertificateItem);

            Assert.IsInstanceOf<GiftCertificateOrderItemTraits>(orderItemTraits,"CreateTraits returned incorrect type of Traits object.");
        }

        [Test]
        public void CreateTraitsReturnsEventPackageOrderItemTraitsObjectWhenGivenEventPackageItemType()
        {
            

            IOrderItemTraits orderItemTraits = _orderItemTraitsFactory.CreateTraits(OrderItemType.EventPackageItem);

            Assert.IsInstanceOf<EventPackageOrderItemTraits>(orderItemTraits, "CreateTraits returned incorrect type of Traits object.");
        }

        [Test]
        public void CreateTraitsReturnsProductOrderItemTraitsObjectWhenGivenProductItemType()
        {
            IOrderItemTraits orderItemTraits = _orderItemTraitsFactory.CreateTraits(OrderItemType.ProductItem);

            Assert.IsInstanceOf<ProductOrderItemTraits>(orderItemTraits, "CreateTraits returned incorrect type of Traits object.");
        }

        [Test]
        public void CreateTraitsReturnsRefundOrderItemTraitsObjectWhenGivenRefundItemType()
        {
            IOrderItemTraits orderItemTraits = _orderItemTraitsFactory.CreateTraits(OrderItemType.RefundItem);

            Assert.IsInstanceOf<RefundOrderItemTraits>(orderItemTraits, "CreateTraits returned incorrect type of Traits object.");
        }

        [Test]
        public void CreateTraitsReturnsTestOrderItemTraitsObjectWhenGivenTestItemType()
        {
            IOrderItemTraits orderItemTraits = _orderItemTraitsFactory.CreateTraits(OrderItemType.EventTestItem);

            Assert.IsInstanceOf<EventTestOrderItemTraits>(orderItemTraits, "CreateTraits returned incorrect type of Traits object.");
        }

        [Test]
        [ExpectedException(typeof(NotSupportedException))]
        public void CreateTraitsThrowsExceptionWhenGivenUnsupportedOrderItemType()
        {
            _orderItemTraitsFactory.CreateTraits((OrderItemType)(-1));
        }
    }
}