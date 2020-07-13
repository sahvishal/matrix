using System;
using Falcon.App.Core.Enum;
using Falcon.App.Core.Finance.Enum;
using Falcon.App.Core.Finance.Impl;
using Falcon.App.Core.Finance.Interfaces;
using NUnit.Framework;

namespace HealthYes.Web.UnitTests.Core.Domain.Order.Impl
{
    [TestFixture]
    public class OrderItemStatusFactoryTester
    {
        private readonly IOrderItemStatusFactory _orderItemStatusFactory = new OrderItemStatusFactory();

        [Test]
        public void CreateOrderItemStatusSetsStatusToCorrectTypeBasedOnOrderItemType()
        {
            
            OrderItemStatus orderItemStatus = _orderItemStatusFactory.CreateOrderItemStatus(OrderItemType.EventPackageItem, 0);

            Assert.IsInstanceOf<EventPackageItemStatus>(orderItemStatus, "The OrderItemStatus is of the incorrect type.");
        }

        [Test]
        public void CreateOrderItemStatusSetsStatusToCorrectRefundItemStatus()
        {
            OrderItemStatus expectedRefundItemStatus = RefundItemStatus.NotApplied;

            OrderItemStatus orderItemStatus = _orderItemStatusFactory.CreateOrderItemStatus
                (OrderItemType.RefundItem, RefundItemStatus.NotApplied.StatusCode);

            Assert.AreEqual(expectedRefundItemStatus, orderItemStatus, "OrderItemStatus was set incorrectly.");
        }

        [Test]
        [ExpectedException(typeof(NotSupportedException))]
        public void CreateOrderItemStatusThrowsExceptionWhenGivenUnsupportedOrderItemType()
        {
            _orderItemStatusFactory.CreateOrderItemStatus((OrderItemType)(-1), 0);
        }
    }
}