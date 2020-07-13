using System;
using System.Collections.Generic;
using System.Linq;
using Falcon.App.Core.Domain;
using Falcon.App.Core.Enum;
using Falcon.App.Core.Finance.Interfaces;
using Falcon.App.Core.Users.Domain;
using Falcon.App.Infrastructure.Repositories.Order;
using NUnit.Framework;
using SD.LLBLGen.Pro.ORMSupportClasses;
using Falcon.App.Core.Scheduling.ViewModels;

namespace Falcon.Web.IntegrationTests.Infrastructure.Finance
{
    [TestFixture]
    [Ignore("The database needs to be in a steady state in order to run this test fixture.")]
    public class OrderRepositoryTester
    {
        private readonly IOrderRepository _orderRepository = new OrderRepository();
        private const int EXISTING_ORDER_ID = 1;
        private const int EXISTING_CUSTOMER_ID = 28623;
        private const int EXISTING_EVENT_ID = 1800;

        [Test]
        public void GetAllOrdersReturnsOrders()
        {
            IEnumerable<Falcon.App.Core.Finance.Domain.Order> orders = _orderRepository.GetAllOrders(1, 2000);

            Assert.IsNotNull(orders);
        }

        [Test]
        public void GetOrderReturnsOrderForExistingOrderId()
        {
            Falcon.App.Core.Finance.Domain.Order order = _orderRepository.GetOrder(EXISTING_ORDER_ID);

            Assert.IsNotNull(order, "Null Order returned.");
        }

        [Test]
        public void SaveOrderSavesNewOrder()
        {
            var orderToSave = new Falcon.App.Core.Finance.Domain.Order
            {
                DataRecorderMetaData = new DataRecorderMetaData { DataRecorderCreator = new OrganizationRoleUser(1), 
                    DateCreated = DateTime.Now},
                OrderType = OrderType.Corporate,
            };

            _orderRepository.SaveOrder(orderToSave);
        }

        [Test]
        public void SaveOrderUpdatesExistingOrder()
        {
            Falcon.App.Core.Finance.Domain.Order existingOrder = _orderRepository.GetOrder(EXISTING_ORDER_ID);
            OrderType expectedOrderType = (existingOrder.OrderType == OrderType.Retail ? OrderType.Corporate : OrderType.Retail);
            existingOrder.OrderType = expectedOrderType;

            _orderRepository.SaveOrder(existingOrder);

            Falcon.App.Core.Finance.Domain.Order updatedOrder = _orderRepository.GetOrder(EXISTING_ORDER_ID);

            Assert.AreEqual(expectedOrderType, updatedOrder.OrderType, "The Order was not updated.");
        }

        [Test]
        [Ignore("Doesn't increment these numbers.")]
        public void ApplyPaymentToOrderPersists()
        {
            const long orderId = 1;
            const long paymentId = 3;

            _orderRepository.ApplyPaymentToOrder(orderId, paymentId);
        }

        [Test]
        [ExpectedException(typeof(ORMQueryExecutionException))]
        public void ApplyPaymentToOrderThrowsExceptionWhenOrderIdIsZero()
        {
            const long orderId = 0;
            const long paymentId = 0;

            _orderRepository.ApplyPaymentToOrder(orderId, paymentId);
        }

        [Test]
        public void CountAllOrdersReturnsNumberGreaterThanZero()
        {
            Assert.Less(0, _orderRepository.CountAllOrders());
        }
        
        [Test]
        public void FooBar()
        {
            Falcon.App.Core.Finance.Domain.Order order = _orderRepository.GetOrder(2770, 1958);
            Assert.IsNotNull(order);
        }

        [Test]
        public void GetAllUpgradedDowngradedOrdersTest()
        {
            int totalRecords = 0;
            var orders = _orderRepository.GetAllUpgradedDowngradedOrders(1, 20, null, out totalRecords);
            Assert.IsNotNull(orders);
            Assert.IsNotEmpty(orders.ToList());
        }

        [Test]
        public void GetAllUpgradedDowngradedOrderswithFilterTest()
        {
            int totalRecords = 0;
            var filter = new CustomerUpsellListModelFilter
                             {FromDate = DateTime.Now.AddDays(-30), ToDate = DateTime.Now.AddDays(30),UpSellRole = 10};
            var orders = _orderRepository.GetAllUpgradedDowngradedOrders(1, 20, filter, out totalRecords);
            Assert.IsNotNull(orders);
            Assert.IsNotEmpty(orders.ToList());
        }

        [Test]
        public void GetOrderSumforEventIdsTest()
        {
            var eventIds = new long[] {1, 2, 4};
            var eventOrdersAmountPair = _orderRepository.GetOrderSumforEventIds(eventIds);
            Assert.IsNotNull(eventOrdersAmountPair);
            Assert.IsNotEmpty(eventOrdersAmountPair.ToList());
        }

        [Test]
        public void GetOrdersbyEventCustomerIdsIncludingCancelledOnes()
        {
            var ids = new long[] { 13, 15 };
            var orders = _orderRepository.GetAllOrdersByEventCustomerIds(ids, true);

            Assert.IsNotNull(orders);
            Assert.IsNotEmpty(orders);

            foreach (var order in orders)
            {
                Assert.IsNotNull(order.OrderDetails);
                Assert.IsNotEmpty(order.OrderDetails);
                Assert.GreaterOrEqual(order.OrderValue, 0);
                Assert.GreaterOrEqual(order.DiscountedTotal, 0);
            }
        }


        [Test]
        public void GetOrdersbyEventCustomerIds()
        {
            var ids = new long[] { 5, 7, 11 };
            var orders = _orderRepository.GetAllOrdersByEventCustomerIds(ids);

            Assert.IsNotNull(orders);
            Assert.IsNotEmpty(orders);

            foreach (var order in orders)
            {
                Assert.IsNotNull(order.OrderDetails);
                Assert.IsNotEmpty(order.OrderDetails);
                Assert.GreaterOrEqual(order.OrderValue, 0);
                Assert.GreaterOrEqual(order.DiscountedTotal, 0);
            }
        }


        [Test]
        public void GetOrdersbyEventCustomerId()
        {
            var ids = new long[] { 5, 7, 11 };
            var orders = _orderRepository.GetOrder(1301686, 47191);

            //Assert.IsNotNull(orders);
            //Assert.IsNotEmpty(orders);

            //foreach (var order in orders)
            //{
            //    Assert.IsNotNull(order.OrderDetails);
            //    Assert.IsNotEmpty(order.OrderDetails);
            //    Assert.GreaterOrEqual(order.OrderValue, 0);
            //    Assert.GreaterOrEqual(order.DiscountedTotal, 0);
            //}
        }

    }
}