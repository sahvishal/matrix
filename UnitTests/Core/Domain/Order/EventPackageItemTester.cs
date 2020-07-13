using Falcon.App.Core.Enum;
using Falcon.App.Core.Finance.Domain;
using NUnit.Framework;

namespace HealthYes.Web.UnitTests.Core.Domain.Order
{
    [TestFixture]
    public class EventPackageItemTester
    {
        [Test]
        public void EventPackageItemOrderItemTypeReturnsProductItemOrderItemType()
        {
            const OrderItemType expectedOrderItemType = OrderItemType.EventPackageItem;
            var packageItem = new EventPackageItem();

            OrderItemType orderItemType = packageItem.OrderItemType;

            Assert.AreEqual(expectedOrderItemType, orderItemType, "EventPackageItem returned incorrect OrderItemType.");
        }

        [Test]
        public void EventPackageItemOrderItemIdGetsSetViaConstructorParameter()
        {
            const long expectedOrderItemId = 83;
            var packageItem = new EventPackageItem(expectedOrderItemId);

            long orderItemId = packageItem.Id;

            Assert.AreEqual(expectedOrderItemId, orderItemId, "EventPackageItem's OrderItemId was not set correctly.");
        }
    }
}