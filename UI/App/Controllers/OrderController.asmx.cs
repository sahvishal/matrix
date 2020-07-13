using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Web.Script.Services;
using System.Web.Services;
using Falcon.App.Core.Finance.Domain;
using Falcon.App.Core.Finance.Enum;
using Falcon.App.Core.Finance.Interfaces;
using Falcon.App.Core.Finance.ViewModels;
using Falcon.App.Core.Marketing.ViewModels;
using Falcon.App.Core.Scheduling;
using Falcon.App.Core.Scheduling.Enum;
using Falcon.App.DependencyResolution;
using Falcon.App.Infrastructure.Repositories.Order;
using Falcon.App.Core.Extensions;
using Falcon.App.Infrastructure.Repositories.Payment;

namespace Falcon.App.UI.Controllers
{
    [WebService(Namespace = "http://tempuri.org/")]
    [WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
    [ToolboxItem(false)]
    [ScriptService]
    public class OrderController : WebService
    {
        protected const int CUSTOMER_SHELL_ID = 100;

        private readonly IOrderRepository _orderRepository;
        private readonly IOrderDetailRepository _orderDetailRepository;
        private readonly ICombinedPaymentInstrumentRepository _combinedPaymentInstrumentRepository;
        private readonly IOrderService _orderService;

        public OrderController()
            : this(new OrderRepository(), new OrderDetailRepository(), new CombinedPaymentInstrumentRepository(),
            IoC.Resolve<IOrderService>())
        { }

        public OrderController(IOrderRepository orderRepository, IOrderDetailRepository orderDetailRepository,
            ICombinedPaymentInstrumentRepository combinedPaymentInstrumentRepository, IOrderService orderService)
        {
            _orderRepository = orderRepository;
            _orderDetailRepository = orderDetailRepository;
            _combinedPaymentInstrumentRepository = combinedPaymentInstrumentRepository;
            _orderService = orderService;

        }

        [WebMethod (EnableSession = true)]
        public IEnumerable<Order> GetAllOrders(int pageNumber, int pageSize)
        {
            // TODO: Implement access controls.
            // TODO: Implement sorting choice.
            return _orderRepository.GetAllOrders(pageNumber, pageSize).OrderByDescending(o => o.DataRecorderMetaData.DateCreated);
        }

        [WebMethod (EnableSession = true)]
        public int CountAllOrders()
        {
            return _orderRepository.CountAllOrders();
        }

        [WebMethod (EnableSession = true)]
        public IEnumerable<OrderDetail> GetOrderDetailsForOrder(long orderId)
        {
            return _orderDetailRepository.GetOrderDetailsForOrder(orderId);
        }

        [WebMethod (EnableSession = true)]
        public IEnumerable<PaymentInstrument> GetPaymentInstrumentsForOrder(long orderId)
        {
            return _combinedPaymentInstrumentRepository.GetByOrderId(orderId);
        }

        [WebMethod (EnableSession = true)]
        public IEnumerable<OrderViewData> GetOrderDetails(long orderId)
        {
            return _orderService.GetOrderDetailViewData(orderId);
        }

        [WebMethod (EnableSession = true)]
        public IEnumerable<PaymentViewData> GetPaymentDetails(long orderId)
        {
            return _orderService.GetPaymentDetailViewData(orderId);
        }

        [WebMethod (EnableSession = true)]
        public bool RefundOrder(long orderId, decimal amount, int refundMode, string notes, string checkNumber,
            long customerId, long organizationRoleUserId)
        {
            return _orderService.RefundOrder(orderId, amount, refundMode, notes, checkNumber, customerId, organizationRoleUserId);
        }

        [WebMethod (EnableSession = true)]
        public bool IsPaymentUsingChargeCard(long orderId)
        {
            var order = _orderRepository.GetOrder(orderId);
            return !order.PaymentsApplied.IsEmpty() &&
                   order.PaymentsApplied.Any(pa => pa.PaymentType == PaymentType.CreditCard);
        }

        [WebMethod (EnableSession = true)]
        public SourceCodeApplyEditModel GetCoupon(string couponCode, long packageId, string addOnTestIds, long eventId, long customerId, int signUpMode, decimal packageTestCost)
        {
            IOrderRepository orderRepository = new OrderRepository();
            var order = orderRepository.GetOrder(customerId, eventId);
            if (order != null)
            {
                var testIds = new List<long>();
                if (!String.IsNullOrEmpty(addOnTestIds))
                    addOnTestIds.Split(',').ToList().ForEach(t => testIds.Add(Convert.ToInt64(t)));

                var shippingAmount =
                    order.OrderDetails.Sum(
                        od =>
                        (od.ShippingDetailOrderDetails != null && !od.ShippingDetailOrderDetails.IsEmpty()
                             ? od.ShippingDetailOrderDetails.Sum(sdod => sdod.Amount)
                             : 0));
                var orderTotal = packageTestCost + (order.ProductCost.HasValue ? order.ProductCost.Value : 0) + shippingAmount;

                var eventSchedulerService = IoC.Resolve<IEventSchedulerService>();
                var model = eventSchedulerService.ApplySourceCode(packageId, testIds, orderTotal, couponCode, eventId, customerId, (SignUpMode)signUpMode, shippingAmount, (order.ProductCost.HasValue ? order.ProductCost.Value : 0));

                return model;
            }
            return null;
        }

        [WebMethod(EnableSession = true)]
        public SourceCodeApplyEditModel GetCouponForReschedule(string couponCode, long packageId, string addOnTestIds, long newEventId, long customerId, int signUpMode, long oldEventId, decimal packageTestCost)
        {
            var testIds = new List<long>();
            if (!String.IsNullOrEmpty(addOnTestIds))
                addOnTestIds.Split(',').ToList().ForEach(t => testIds.Add(Convert.ToInt64(t)));

            IOrderRepository orderRepository = new OrderRepository();
            var order = orderRepository.GetOrder(customerId, oldEventId);
            var orderTotal = packageTestCost;
            decimal shippingAmount = 0;
            decimal productCostValue = 0;

            if (order != null)
            {
                productCostValue = order.ProductCost.HasValue ? order.ProductCost.Value : 0;
                shippingAmount =
                    order.OrderDetails.Sum(od => (od.ShippingDetailOrderDetails != null && !od.ShippingDetailOrderDetails.IsEmpty() ? od.ShippingDetailOrderDetails.Sum(sdod => sdod.Amount) : 0));

                orderTotal = packageTestCost + (productCostValue) + shippingAmount;
            }

            var eventSchedulerService = IoC.Resolve<IEventSchedulerService>();
            var model = eventSchedulerService.ApplySourceCode(packageId, testIds, orderTotal, couponCode, newEventId, customerId, (SignUpMode)signUpMode, shippingAmount, productCostValue);

            return model;
        }
    }
}
