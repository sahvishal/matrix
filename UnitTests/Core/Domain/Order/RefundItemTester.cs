using Falcon.App.Core.Enum;
using Falcon.App.Core.Finance.Domain;
using NUnit.Framework;

namespace HealthYes.Web.UnitTests.Core.Domain.Order
{
    [TestFixture]
    public class RefundItemTester
    {
        [Test]
        public void RefundItemOrderItemTypeReturnsRefundItemOrderItemType()
        {
            const OrderItemType expectedOrderItemType = OrderItemType.RefundItem;
            var refundItem = new RefundItem();

            OrderItemType orderItemType = refundItem.OrderItemType;

            Assert.AreEqual(expectedOrderItemType, orderItemType, "RefundItem returned incorrect OrderItemType.");
        }

        [Test]
        public void RefundItemOrderItemIdGetsSetViaConstructorParameter()
        {
            const long expectedOrderItemId = 83;
            var refundItem = new RefundItem(expectedOrderItemId);

            long orderItemId = refundItem.Id;

            Assert.AreEqual(expectedOrderItemId, orderItemId, "RefundItem's OrderItemId was not set correctly.");
        }
    }
}