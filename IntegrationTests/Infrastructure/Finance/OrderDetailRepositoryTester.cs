using System;
using System.Collections.Generic;
using Falcon.App.Core.Domain;
using Falcon.App.Core.Finance.Domain;
using Falcon.App.Core.Finance.Enum;
using Falcon.App.Core.Finance.Interfaces;
using Falcon.App.Core.Users.Domain;
using Falcon.App.Infrastructure.Repositories.Order;
using NUnit.Framework;

namespace Falcon.Web.IntegrationTests.Infrastructure.Finance
{
    [TestFixture]
    [Ignore("The database needs to be in a steady state in order to run this test fixture.")]
    public class OrderDetailRepositoryTester
    {
        private readonly IOrderDetailRepository _orderDetailRepository = new OrderDetailRepository();

        private const int NONEXISTING_ORDER_ID = -1;
        private const int ORDER_ID_WITH_ORDER_DETAIL_WITH_SOURCE_CODE = 1;
        private const int ORDER_ID_WITH_ORDER_DETAIL = 2;
        private const int EXISTING_ORDER_ITEM_ID = 1;

        [Test]
        public void GetOrderDetailsForOrderReturnsEmptyListOfOrderDetailsForNonexistingOrderId()
        {
            List<OrderDetail> orderDetails = _orderDetailRepository.GetOrderDetailsForOrder(NONEXISTING_ORDER_ID);

            Assert.IsNotNull(orderDetails, "Null list of OrderDetails returned.");
            Assert.IsEmpty(orderDetails, "Nonempty list of OrderDetails returned for nonexisting ID.");
        }

        [Test]
        public void GetOrderDetailsForOrderReturnsNonemptyListForOrderIdWithOrderDetail()
        {
            List<OrderDetail> orderDetails = _orderDetailRepository.GetOrderDetailsForOrder(ORDER_ID_WITH_ORDER_DETAIL);

            Assert.IsNotEmpty(orderDetails, "Empty list of OrderDetails returned for OrderID with an OrderDetail.");
        }

        [Test]
        public void GetOrderDetailsForOrderReturnsCollectionOfDetailsWhenOneHasAssociatedSourceCodeOrderDetail()
        {
            _orderDetailRepository.GetOrderDetailsForOrder(ORDER_ID_WITH_ORDER_DETAIL_WITH_SOURCE_CODE);
        }

        [Test]
        public void SaveOrderDetailSavesNewOrderDetailWithoutSourceCode()
        {
            var orderDetailToSave = new OrderDetail
            {
                DataRecorderMetaData = new DataRecorderMetaData {DataRecorderCreator = new OrganizationRoleUser(1),
                    DateCreated = DateTime.Now},
                Description = "Integration Test for saving new OrderDetail",
                ForOrganizationRoleUserId = 1,
                OrderItemStatus = EventPackageItemStatus.Availed,
                OrderItemId = EXISTING_ORDER_ITEM_ID,
                OrderId = ORDER_ID_WITH_ORDER_DETAIL_WITH_SOURCE_CODE
            };

            _orderDetailRepository.SaveOrderDetail(orderDetailToSave);
        }

        [Test]
        public void SaveOrderDetailUpdatesExistingOrderDetailWithoutSourceCode()
        {
            var orderDetailToSave = new OrderDetail
            {
                DataRecorderMetaData = new DataRecorderMetaData { DataRecorderCreator = new OrganizationRoleUser(1),
                    DateCreated = DateTime.Now },
                Description = "Integration Test for saving new OrderDetail",
                ForOrganizationRoleUserId = 1,
                OrderItemStatus = EventPackageItemStatus.Availed,
                OrderItemId = EXISTING_ORDER_ITEM_ID,
                OrderId = ORDER_ID_WITH_ORDER_DETAIL_WITH_SOURCE_CODE
            };
            _orderDetailRepository.SaveOrderDetail(orderDetailToSave);
        }
    }
}