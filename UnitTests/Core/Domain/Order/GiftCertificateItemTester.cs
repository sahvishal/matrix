using Falcon.App.Core.Enum;
using Falcon.App.Core.Finance.Domain;
using NUnit.Framework;

namespace HealthYes.Web.UnitTests.Core.Domain.Order
{
    [TestFixture]
    public class GiftCertificateItemTester
    {
        [Test]
        public void GiftCertificateOrderItemTypeReturnsGiftCertificateItemOrderItemType()
        {
            const OrderItemType expectedOrderItemType = OrderItemType.GiftCertificateItem;
            var refundItem = new GiftCertificateItem();

            OrderItemType orderItemType = refundItem.OrderItemType;

            Assert.AreEqual(expectedOrderItemType, orderItemType, "RefundItem returned incorrect OrderItemType.");
        }

        [Test]
        public void RefundItemOrderItemIdGetsSetViaConstructorParameter()
        {
            const long expectedOrderItemId = 83;
            var refundItem = new GiftCertificateItem(expectedOrderItemId);

            long orderItemId = refundItem.Id;

            Assert.AreEqual(expectedOrderItemId, orderItemId, "RefundItem's OrderItemId was not set correctly.");
        }
    }
}