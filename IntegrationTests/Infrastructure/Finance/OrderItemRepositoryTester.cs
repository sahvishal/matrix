using Falcon.App.Core.Enum;
using Falcon.App.Core.Finance.Domain;
using Falcon.App.Core.Finance.Interfaces;
using Falcon.App.Infrastructure.Repositories.Order;
using NUnit.Framework;

namespace Falcon.Web.IntegrationTests.Infrastructure.Finance
{
    [TestFixture]
    [Ignore("The database needs to be in a steady state in order to run this test fixture.")]
    public class OrderItemRepositoryTester
    {
        private readonly IOrderItemRepository _orderItemRepository = new OrderItemRepository();
        private const int EXISTING_ORDER_ITEM_ID = 3;

        [Test]
        public void GetOrderItemReturnsOrderItemWhenGivenExistingId()
        {
            OrderItem orderItem = _orderItemRepository.GetOrderItem(EXISTING_ORDER_ITEM_ID);

            Assert.IsNotNull(orderItem, "Null OrderItem returned.");
        }

        [Test]
        public void SaveOrderItemSavesUnmappedPackageItem()
        {
            const int validUnmappedEventPackageId = 244;

            _orderItemRepository.SaveOrderItem(validUnmappedEventPackageId, OrderItemType.EventPackageItem);
        }
    }
}