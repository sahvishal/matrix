using Falcon.App.Core.Application.Attributes;
using Falcon.App.Core.Finance;
using Falcon.App.Core.Finance.Interfaces;
using Falcon.App.Core.Finance.ViewModels;
using Falcon.App.Core.Users;

namespace Falcon.App.Infrastructure.Finance.Impl
{
    [DefaultImplementation]
    public class OrderSummaryService : IOrderSummaryService
    {
        private readonly IOrderService _orderService;
        private readonly IOrderRepository _orderRepository;
        private readonly ICustomerRepository _customerRepository;

        public OrderSummaryService(IOrderService orderService, IOrderRepository orderRepository,ICustomerRepository customerRepository)
        {
            _orderService = orderService;
            _orderRepository = orderRepository;
            _customerRepository = customerRepository;
        }

        public CustomerOrderViewModel GetOrderSummary(long customerId, long eventId)
        {
            var order = _orderRepository.GetOrder(customerId,eventId);
            var amountDue = (order.DiscountedTotal - order.TotalAmountPaid);
            var vmModel = new CustomerOrderViewModel
            {
                CustomerId = customerId,
                OrderTotal = order.DiscountedTotal,
                PaymentTotal = order.TotalAmountPaid,
                AmountOwed = amountDue,
                CustomerName = _customerRepository.GetCustomer(customerId).Name.FullName,
                OrderDetails = _orderService.GetOrderDetailViewData(order.Id),
                Paymentdetails = _orderService.GetPaymentDetailViewData(order.Id),
            };

            return vmModel;
        }
    }
}
