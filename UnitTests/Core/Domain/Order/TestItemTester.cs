using Falcon.App.Core.Enum;
using Falcon.App.Core.Finance.Domain;
using NUnit.Framework;

namespace HealthYes.Web.UnitTests.Core.Domain.Order
{
    [TestFixture]
    public class TestItemTester
    {
        [Test]
        public void ProductItemOrderItemTypeReturnsProductItemOrderItemType()
        {
            const OrderItemType expectedOrderItemType = OrderItemType.EventTestItem;
            var testItem = new EventTestItem();

            OrderItemType orderItemType = testItem.OrderItemType;

            Assert.AreEqual(expectedOrderItemType, orderItemType, "TestItem returned incorrect OrderItemType.");
        }

        [Test]
        public void ProductItemOrderItemIdGetsSetViaConstructorParameter()
        {
            const long expectedOrderItemId = 83;
            var testItem = new EventTestItem(expectedOrderItemId);

            long orderItemId = testItem.Id;

            Assert.AreEqual(expectedOrderItemId, orderItemId, "TestItem's OrderItemId was not set correctly.");
        }
    }
}