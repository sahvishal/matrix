using Falcon.App.Core.Enum;
using Falcon.App.Core.Finance.Domain;
using NUnit.Framework;

namespace HealthYes.Web.UnitTests.Core.Domain.Order
{
    [TestFixture]
    public class ProductItemTester
    {
        [Test]
        public void ProductItemOrderItemTypeReturnsProductItemOrderItemType()
        {
            const OrderItemType expectedOrderItemType = OrderItemType.ProductItem;
            var productItem = new ProductItem();

            OrderItemType orderItemType = productItem.OrderItemType;

            Assert.AreEqual(expectedOrderItemType, orderItemType, "ProductItem returned incorrect OrderItemType.");
        }

        [Test]
        public void ProductItemOrderItemIdGetsSetViaConstructorParameter()
        {
            const long expectedOrderItemId = 83;
            var productItem = new ProductItem(expectedOrderItemId);

            long orderItemId = productItem.Id;

            Assert.AreEqual(expectedOrderItemId, orderItemId, "ProductItem's OrderItemId was not set correctly.");
        }
    }
}