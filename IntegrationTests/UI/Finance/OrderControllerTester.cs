using Falcon.App.Core.Enum;
using Falcon.App.Core.Finance.Interfaces;
using Falcon.App.Core.Scheduling.Domain;
using Falcon.App.Infrastructure.Finance.Impl;
using NUnit.Framework;

namespace Falcon.Web.IntegrationTests.UI.Finance
{
    [TestFixture]
    [Ignore("The database must be in a stable state to run these tests.")]
    public class OrderControllerTester
    {
        [Test]
        public void PlaceOrderPersistsOrderWithOneItemSpecified()
        {
            IOrderController orderController = new OrderController();

            var eventPackage = new EventPackage(3730) {Price = 139.95m, PackageId = 57, EventId = 940};

            orderController.AddItem(eventPackage, 1, 0, 0);

            orderController.PlaceOrder(OrderType.Retail, 0);

            // TODO: Test that this actually occurred.
        }
    }
}