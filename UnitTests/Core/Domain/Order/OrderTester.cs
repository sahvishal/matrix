using System.Collections.Generic;
using System.Linq;
using Falcon.App.Core.Domain;
using Falcon.App.Core.Enum;
using Falcon.App.Core.Finance.Domain;
using Falcon.App.Core.Finance.Enum;
using HealthYes.Web.UnitTests.Fakes;
using NUnit.Framework;

namespace HealthYes.Web.UnitTests.Core.Domain.Order
{
    [TestFixture]
    public class OrderTester
    {
        [Test]
        public void OrderDetailsIsInitializedOnObjectInstantiation()
        {
            var order = new Falcon.App.Core.Finance.Domain.Order();

            Assert.IsNotNull(order.OrderDetails, "OrderDetail collection not initialized upon Order instantiation.");
        }

        [Test]
        public void OrderDetailsIsNotNullEvenWhenExplicitlyNullified()
        {
            var order = new Falcon.App.Core.Finance.Domain.Order { OrderDetails = null };

            Assert.IsNotNull(order.OrderDetails, "OrderDetail collection remained null after nullification.");
        }

        [Test]
        public void PaymentsAppliedIsInitializedOnObjectInstantiation()
        {
            var order = new Falcon.App.Core.Finance.Domain.Order();

            Assert.IsNotNull(order.PaymentsApplied, "PaymentsApplied not initialized upon Order instantiation.");
        }

        [Test]
        public void PaymentsAppliedIsNotNullEvenWhenExplicitlyNullified()
        {
            var order = new Falcon.App.Core.Finance.Domain.Order { PaymentsApplied = null };

            Assert.IsNotNull(order.OrderDetails, "PaymentsApplied remained null after nullification.");
        }

        [Test]
        public void OrderStatusIsEmptyWhenOrderDetailCollectionIsEmpty()
        {
            const OrderStatus expectedOrderStatus = OrderStatus.Empty;
            var orderDetails = new List<OrderDetail>();

            var order = new Falcon.App.Core.Finance.Domain.Order { OrderDetails = orderDetails };

            Assert.AreEqual(expectedOrderStatus, order.OrderStatus, "Order's OrderStatus not Empty when empty OrderDetail collection given.");
        }

        [Test]
        public void OrderStatusIsClosedWhenOrderDetailCollectionContainsOneCompleteOrder()
        {
            const OrderStatus expectedOrderStatus = OrderStatus.Closed;
            var orderDetails = new List<OrderDetail> { new OrderDetail { OrderItemStatus = FakeOrderItemStatus.CompleteFakeStatus } };

            var order = new Falcon.App.Core.Finance.Domain.Order { OrderDetails = orderDetails };

            Assert.AreEqual(expectedOrderStatus, order.OrderStatus, "Order's OrderStatus not Closed when single completed OrderDetail given.");
        }

        [Test]
        public void OrderStatusIsOpenWhenOrderDetailCollectionContainsOneIncompleteOrder()
        {
            const OrderStatus expectedOrderStatus = OrderStatus.Open;
            var orderDetails = new List<OrderDetail> { new OrderDetail { OrderItemStatus = FakeOrderItemStatus.IncompleteFakeStatus } };

            var order = new Falcon.App.Core.Finance.Domain.Order { OrderDetails = orderDetails };

            Assert.AreEqual(expectedOrderStatus, order.OrderStatus, "Order's OrderStatus not Open when single incomplete OrderDetail given.");
        }

        [Test]
        public void OrderStatusIsOpenWhenOrderDetailCollectionHasOneIncompleteOrder()
        {
            const OrderStatus expectedOrderStatus = OrderStatus.Open;
            var orderDetails = new List<OrderDetail>
            {
                new OrderDetail { OrderItemStatus = FakeOrderItemStatus.IncompleteFakeStatus },
                new OrderDetail { OrderItemStatus = FakeOrderItemStatus.CompleteFakeStatus },
                new OrderDetail { OrderItemStatus = FakeOrderItemStatus.CompleteFakeStatus },
            };

            var order = new Falcon.App.Core.Finance.Domain.Order { OrderDetails = orderDetails };

            Assert.AreEqual(expectedOrderStatus, order.OrderStatus, "Order's OrderStatus not Open when OrderDetail collection with an incomplete detail given.");
        }

        [Test]
        public void OrderStatusIsOpenWhenOrderDetailCollectionHasAllCompleteOrders()
        {
            const OrderStatus expectedOrderStatus = OrderStatus.Closed;
            var orderDetails = new List<OrderDetail>
            {
                new OrderDetail { OrderItemStatus = FakeOrderItemStatus.CompleteFakeStatus },
                new OrderDetail { OrderItemStatus = FakeOrderItemStatus.CompleteFakeStatus },
                new OrderDetail { OrderItemStatus = FakeOrderItemStatus.CompleteFakeStatus },
            };

            var order = new Falcon.App.Core.Finance.Domain.Order { OrderDetails = orderDetails };

            Assert.AreEqual(expectedOrderStatus, order.OrderStatus, "Order's OrderStatus not Closed when collection of completed OrderDetails given.");
        }

        [Test]
        public void UndiscountedTotalReturnsPriceOfSingleOrderDetailWithNoDiscount()
        {
            const decimal expectedPrice = 15.00m;

            var orderDetails = new List<OrderDetail>
                                   {
                                       new OrderDetail
                                           {Price = expectedPrice, OrderItemStatus = EventPackageItemStatus.Ordered}
                                   };

            var order = new Falcon.App.Core.Finance.Domain.Order { OrderDetails = orderDetails };
            decimal undiscountedTotal = order.UndiscountedTotal;

            Assert.AreEqual(expectedPrice, undiscountedTotal);
        }

        [Test]
        public void UndiscountedTotalReturnsPriceOfSingleOrderDetailWithADiscount()
        {
            const decimal expectedPrice = 15.00m;

            var orderDetails = new List<OrderDetail>
                                   {
                                       new OrderDetail
                                           {
                                               Price = expectedPrice,
                                               SourceCodeOrderDetail = new SourceCodeOrderDetail {Amount = 5m},
                                               OrderItemStatus = EventPackageItemStatus.Ordered
                                           }
                                   };

            var order = new Falcon.App.Core.Finance.Domain.Order { OrderDetails = orderDetails };
            decimal undiscountedTotal = order.UndiscountedTotal;

            Assert.AreEqual(expectedPrice, undiscountedTotal);
        }

        [Test]
        public void UndiscountedTotalReturnsPriceOfOnePluralOrderDetailWithNoDiscount()
        {
            const decimal expectedPrice = 15.00m;

            var orderDetails = new List<OrderDetail>
                                   {
                                       new OrderDetail
                                           {
                                               Price = expectedPrice/3,
                                               Quantity = 3,
                                               OrderItemStatus = EventPackageItemStatus.Ordered
                                           }
                                   };

            var order = new Falcon.App.Core.Finance.Domain.Order { OrderDetails = orderDetails };
            decimal undiscountedTotal = order.UndiscountedTotal;

            Assert.AreEqual(expectedPrice, undiscountedTotal);
        }

        [Test]
        public void DiscountedTotalReturnsPriceOfOneOrderDetailWithNoDiscount()
        {
            const decimal expectedPrice = 15.00m;

            var orderDetails = new List<OrderDetail>
                                   {
                                       new OrderDetail
                                           {Price = expectedPrice, OrderItemStatus = EventPackageItemStatus.Ordered}
                                   };

            var order = new Falcon.App.Core.Finance.Domain.Order { OrderDetails = orderDetails };
            decimal discountedTotal = order.DiscountedTotal;

            Assert.AreEqual(expectedPrice, discountedTotal);
        }

        [Test]
        public void DiscountedTotalReturnsPriceOfOneSingleOrderDetailWithADiscount()
        {
            const decimal couponAmount = 5m;
            const decimal expectedPrice = 15.00m;

            var orderDetails = new List<OrderDetail>
                                   {
                                       new OrderDetail
                                           {
                                               Price = expectedPrice + couponAmount,
                                               SourceCodeOrderDetail = new SourceCodeOrderDetail {Amount = couponAmount},
                                               OrderItemStatus = EventPackageItemStatus.Ordered
                                           }
                                   };

            var order = new Falcon.App.Core.Finance.Domain.Order { OrderDetails = orderDetails };
            decimal discountedTotal = order.DiscountedTotal;

            Assert.AreEqual(expectedPrice, discountedTotal);
        }

        [Test]
        public void TotalAmountPaidReturns0WhenPaymentsAppliedIsEmpty()
        {
            const decimal expectedTotalAmountPaid = 0m;

            var order = new Falcon.App.Core.Finance.Domain.Order { PaymentsApplied = new List<PaymentInstrument>() };

            Assert.AreEqual(expectedTotalAmountPaid, order.TotalAmountPaid);
        }

        [Test]
        public void TotalAmountPaidReturns5DollarsWhenPaymentsAppliedHasOne5DollarPayment()
        {
            const decimal expectedTotalAmountPaid = 5m;
            var paymentsApplied = new List<PaymentInstrument> { new FakePaymentInstrument { Amount = expectedTotalAmountPaid } };

            var order = new Falcon.App.Core.Finance.Domain.Order { PaymentsApplied = paymentsApplied };

            Assert.AreEqual(expectedTotalAmountPaid, order.TotalAmountPaid);
        }

        [Test]
        public void TotalAmountPaidReturnsTotalOfThreeAppliedPayments()
        {
            var paymentsApplied = new List<PaymentInstrument>
            {
                new FakePaymentInstrument {Amount = 3.44m},
                new FakePaymentInstrument {Amount = 8.33m},
                new FakePaymentInstrument {Amount = 99.10m}
            };
            decimal expectedTotalAmountPaid = paymentsApplied.Sum(pa => pa.Amount);

            var order = new Falcon.App.Core.Finance.Domain.Order { PaymentsApplied = paymentsApplied };

            Assert.AreEqual(expectedTotalAmountPaid, order.TotalAmountPaid);
        }
    }
}