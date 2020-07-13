using System;
using Falcon.App.Core.Application;
using Falcon.App.Core.Domain;
using Falcon.App.Core.Enum;
using Falcon.App.Core.Finance.Domain;
using Falcon.App.Core.Finance.Enum;
using Falcon.App.Core.Finance.Interfaces;
using Falcon.App.Core.Finance.ViewModels;
using Falcon.App.Core.Operations.ViewModels;
using Falcon.App.Core.Users;
using Falcon.App.Core.Users.Domain;
using Falcon.App.Infrastructure.Factories.Order;
using Falcon.App.Infrastructure.Factories.Payment;
using Falcon.App.Infrastructure.Finance.Impl;
using Falcon.App.Infrastructure.Finance.Interfaces;
using Falcon.App.Infrastructure.Repositories.Order;
using Falcon.App.Infrastructure.Repositories.Payment;
using Falcon.App.Infrastructure.Repositories.Users;
using System.Collections.Generic;
using Falcon.App.Core.Extensions;
using System.Linq;
using Falcon.App.Core.Application.Attributes;

namespace Falcon.App.Infrastructure.Service
{
    [DefaultImplementation]
    public class OrderService : IOrderService
    {
        private readonly IOrderDetailRepository _orderDetailRepository;
        private readonly ICombinedPaymentInstrumentRepository _combinedPaymentInstrumentRepository;
        private IPaymentController _paymentController;


        public OrderService(IOrderDetailRepository orderDetailRepository,
            ICombinedPaymentInstrumentRepository combinedPaymentInstrumentRepository, IPaymentController paymentController)
        {
            _orderDetailRepository = orderDetailRepository;
            _combinedPaymentInstrumentRepository = combinedPaymentInstrumentRepository;
            _paymentController = paymentController;
        }


        public IEnumerable<OrderViewData> GetOrderDetailViewData(long orderId)
        {
            var orderDetails = _orderDetailRepository.GetOrderDetailsForOrder(orderId);

            IOrderViewDataFactory orderViewDataFactory = new OrderViewDataFactory();
            var orderViewDataList = new List<OrderViewData>();
            foreach (var orderDetail in orderDetails)
            {
                orderViewDataList.Add(orderViewDataFactory.Create(orderDetail));
            }
            var orderViewData = orderViewDataList;
            return SortOrderViewData(orderViewData);
        }

        public IEnumerable<PaymentViewData> GetPaymentDetailViewData(long orderId)
        {
            var paymentInstruments = _combinedPaymentInstrumentRepository.GetByOrderId(orderId).ToList();

            // TODO: This has to be moved to each payment instrument repository.
            // HACK: This is done to fetch datarecorder metadata.
            IPaymentRepository paymentRepository = new PaymentRepository();
            var payments = paymentRepository.GetByOrderId(orderId);

            if (payments != null && paymentInstruments != null && !payments.IsEmpty() && !paymentInstruments.IsEmpty())
                paymentInstruments.ForEach(
                    pi => pi.DataRecorderMetaData = payments.Single(p => p.Id == pi.PaymentId).DataRecorderMetaData);

            IPaymentViewDataFactory paymentViewDataFactory = new PaymentViewDataFactory();
            var paymentDetailViewDataList = new List<PaymentViewData>();
            foreach (var paymentInstrument in paymentInstruments)
            {
                paymentDetailViewDataList.Add(paymentViewDataFactory.Create(paymentInstrument));
            }
            return paymentDetailViewDataList;
        }

        public bool RefundOrder(long orderId, decimal amount, int refundMode, string notes, string checkNumber,
            long customerId, long organizationRoleUserId)
        {
            IOrderRepository orderRepository = new OrderRepository();

            var order = orderRepository.GetOrder(orderId);

            ICustomerRepository customerRepository = new CustomerRepository();
            var customer = customerRepository.GetCustomer(customerId);

            if (customer == null) return false;

            OrganizationRoleUser forOrganizationRoleUser;
            OrganizationRoleUser creatorOrganizationRoleUser = GetOrganizationRoleUsers(customer, organizationRoleUserId, out forOrganizationRoleUser);


            Refund refundOrderItem = SaveRefundOrderItem(creatorOrganizationRoleUser, notes, amount);

            if (refundOrderItem.Id == 0) return false;

            var creditCardPayment =
                order.PaymentsApplied.FirstOrDefault(pa => pa.PaymentType == PaymentType.CreditCard) as
                ChargeCardPayment;

            var paymentInstrument = GetPaymentInstrumentForRefund(amount, refundMode, checkNumber, customer.NameAsString, creditCardPayment, creatorOrganizationRoleUser);

            order = RefundOrder(refundOrderItem, order, creatorOrganizationRoleUser, forOrganizationRoleUser);

            ApplyPaymentToRefund(orderRepository, creatorOrganizationRoleUser, order, paymentInstrument);

            return true;
        }


        // TODO: These private methods have to be removed from the service, probably pull out a seperate type for these actions.
        private void ApplyPaymentToRefund(IOrderRepository orderRepository, DomainObjectBase creatorOrganizationRoleUser,
            DomainObjectBase order, PaymentInstrument paymentInstrument)
        {
            long paymentId = _paymentController.SavePayment(paymentInstrument, "Payment", creatorOrganizationRoleUser.Id);
            orderRepository.ApplyPaymentToOrder(order.Id, paymentId);
        }

        public Order RefundOrder(IOrderable refundOrderItem, Order order,
            DomainObjectBase creatorOrganizationRoleUser, DomainObjectBase forOrganizationRoleUser)
        {
            IOrderController orderController = new OrderController();

            orderController.AddItem(refundOrderItem, 1, forOrganizationRoleUser.Id, creatorOrganizationRoleUser.Id, null,
                                    null, null, RefundItemStatus.Applied.OrderStatusState);

            order = orderController.RefundOrder(order);
            return order;
        }

        public Refund SaveRefundOrderItem(OrganizationRoleUser creatorOrganizationRoleUser, string notes,
            decimal amount)
        {
            var refundOrderItem = new Refund
            {
                DataRecorderMetaData =
                    new DataRecorderMetaData
                        {
                            DataRecorderCreator = creatorOrganizationRoleUser,
                            DateCreated = DateTime.Now,
                            DataRecorderModifier = creatorOrganizationRoleUser,
                            DateModified = DateTime.Now
                        },
                Notes = notes,
                Price = amount,
                RefundReason = RefundReason.Other
            };
            IUniqueItemRepository<Refund> refundItemRepository = new RefundRepository();
            refundOrderItem = refundItemRepository.Save(refundOrderItem);
            return refundOrderItem;
        }

        private OrganizationRoleUser GetOrganizationRoleUsers(DomainObjectBase customer, long organizationRoleUserId, out OrganizationRoleUser forOrganizationRoleUser)
        {
            var organizationRoleUserRepository = new OrganizationRoleUserRepository();
            var creatorOrganizationRoleUser = organizationRoleUserRepository.GetOrganizationRoleUser(organizationRoleUserId);

            forOrganizationRoleUser = null;
            var orgRoleUsers = organizationRoleUserRepository.GetOrganizationRoleUserCollectionforaUser(customer.Id);
            if (!orgRoleUsers.IsNullOrEmpty())
            {
                forOrganizationRoleUser = orgRoleUsers.Where(org => org.RoleId == (long)Roles.Customer).FirstOrDefault();
            }

            return creatorOrganizationRoleUser;
        }

        private PaymentInstrument GetPaymentInstrumentForRefund(decimal amount, int refundMode,
            string checkNumber, string customerName,
           ChargeCardPayment chargeCardPayment, OrganizationRoleUser creatorOrganizationRoleUser)
        {
            if (refundMode == PaymentType.Cash.PersistenceLayerId)
            {
                return new CashPayment
                           {
                               Amount = (-1) * amount,
                               DataRecorderMetaData =
                                   new DataRecorderMetaData
                                       {
                                           DataRecorderCreator = creatorOrganizationRoleUser,
                                           DateCreated = DateTime.Now,
                                           DataRecorderModifier = creatorOrganizationRoleUser,
                                           DateModified = DateTime.Now
                                       }
                           };
            }

            else if (refundMode == PaymentType.Check.PersistenceLayerId)
            {
                var check = new Check
                                {
                                    AccountNumber = string.Empty,
                                    Amount = (-1) * amount,
                                    BankName = string.Empty,
                                    CheckNumber = checkNumber,
                                    DataRecorderMetaData =
                                        new DataRecorderMetaData
                                            {
                                                DataRecorderCreator = creatorOrganizationRoleUser,
                                                DateCreated = DateTime.Now,
                                                DataRecorderModifier = creatorOrganizationRoleUser,
                                                DateModified = DateTime.Now
                                            },
                                    CheckDate = DateTime.Today,
                                    RoutingNumber = string.Empty,
                                    PayableTo = customerName,
                                    AcountHolderName = string.Empty
                                };

                return new CheckPayment
                           {
                               Check = check,
                               Amount = check.Amount,
                               CheckStatus = CheckPaymentStatus.Recieved,
                               DataRecorderMetaData = check.DataRecorderMetaData,
                               CheckId = check.Id
                           };
            }

            return new ChargeCardPayment
                       {
                           Amount = (-1) * amount,
                           ChargeCardId = chargeCardPayment.ChargeCardId,
                           ChargeCardPaymentStatus = ChargeCardPaymentStatus.Approve,
                           DataRecorderMetaData =
                               new DataRecorderMetaData { DataRecorderCreator = creatorOrganizationRoleUser, DateCreated = DateTime.Now },
                           ProcessorResponse = chargeCardPayment.ProcessorResponse
                       };
        }

        private IEnumerable<OrderViewData> SortOrderViewData(IEnumerable<OrderViewData> orderViewData)
        {
            const string eventPackageItem = "Event Package";
            const string eventTestItem = "Event Test";
            const string refundItem = "Refund";
            const string productItem = "Product";
            const string cancelFeeItem = "Cancellation Fee";
            const string giftCertificateItem = "Gift Certificate";
            var sortedOrderViewData = new List<OrderViewData>();

            // Get all the event Package order Items.
            var eventPackageOrderDetails = orderViewData.Where(odv => odv.OrderDetailType == eventPackageItem);

            var orderedEventPackageOrderDetails =
                eventPackageOrderDetails.Where(epod => epod.OrderDetailStatus == EventPackageItemStatus.Ordered.Name).
                    OrderBy(epod => epod.OrderDetailDateCreated);

            foreach (var orderedEventPackageOrderDetail in orderedEventPackageOrderDetails)
            {
                // Get the cancelled EventPackageOrderDetails for this ordered order detail.
                OrderViewData detail = orderedEventPackageOrderDetail;

                var cancelledEventPackageOrderDetail =
                    eventPackageOrderDetails.FirstOrDefault(
                        epod =>
                        (epod.OrderDetailStatus == EventPackageItemStatus.Cancelled.Name) &&
                        ((epod.TotalCost * (-1)) == detail.TotalCost) && (epod.Description == detail.Description));

                // It can never be null, but there can be data problem.
                if (cancelledEventPackageOrderDetail != null)
                {
                    // Add to the sorted list.
                    sortedOrderViewData.Add(detail);
                    sortedOrderViewData.Add(cancelledEventPackageOrderDetail);
                }
            }

            // Get all the event test order Items.
            var eventTestOrderDetails = orderViewData.Where(odv => odv.OrderDetailType == eventTestItem);

            var orderedEventTestOrderDetails =
                eventTestOrderDetails.Where(etod => etod.OrderDetailStatus == EventTestItemStatus.Ordered.Name).
                    OrderBy(etod => etod.OrderDetailDateCreated);

            foreach (var orderedEventTestOrderDetail in orderedEventTestOrderDetails)
            {
                // Get the cancelled EventPackageOrderDetails for this ordered order detail.
                OrderViewData detail = orderedEventTestOrderDetail;

                var cancelledEventTestOrderDetail =
                    eventTestOrderDetails.FirstOrDefault(
                        etod =>
                        (etod.OrderDetailStatus == EventTestItemStatus.Cancelled.Name) &&
                        ((etod.TotalCost * (-1)) == detail.TotalCost) && (etod.Description == detail.Description));

                // It can never be null, but there can be data problem.
                if (cancelledEventTestOrderDetail != null)
                {
                    // Add to the sorted list.
                    sortedOrderViewData.Add(detail);
                    sortedOrderViewData.Add(cancelledEventTestOrderDetail);
                }
            }

            // Get all the product order Items.
            var productOrderDetails = orderViewData.Where(odv => odv.OrderDetailType == productItem);

            var orderedProductOrderDetails =
                productOrderDetails.Where(pod => pod.OrderDetailStatus == ProductItemStatus.Ordered.Name).
                    OrderBy(pod => pod.OrderDetailDateCreated);

            foreach (var orderedProductOrderDetail in orderedProductOrderDetails)
            {
                // Get the cancelled product for this ordered order detail.
                OrderViewData detail = orderedProductOrderDetail;

                var cancelledProductOrderDetail =
                    productOrderDetails.FirstOrDefault(
                        pod =>
                        (pod.OrderDetailStatus == ProductItemStatus.Cancelled.Name) &&
                        ((pod.TotalCost * (-1)) == detail.TotalCost) && (pod.Description == detail.Description));

                // It can never be null, but there can be data problem.
                if (cancelledProductOrderDetail != null)
                {
                    // Add to the sorted list.
                    sortedOrderViewData.Add(detail);
                    sortedOrderViewData.Add(cancelledProductOrderDetail);
                }
            }

            // Get all the cancelled fee order Items.
            var cancelFeeOrderDetails = orderViewData.Where(odv => odv.OrderDetailType == cancelFeeItem);
            sortedOrderViewData.AddRange(cancelFeeOrderDetails);


            // Add the availed packages to the sorted list.
            sortedOrderViewData.AddRange(
                orderViewData.Where(
                    odv =>
                    odv.OrderDetailType == eventPackageItem &&
                    odv.OrderDetailStatus == EventPackageItemStatus.Availed.Name).OrderBy(
                    odv => odv.OrderDetailDateCreated));

            // Add the availed tests to the sorted list.
            sortedOrderViewData.AddRange(
                orderViewData.Where(
                    odv =>
                    odv.OrderDetailType == eventTestItem &&
                    odv.OrderDetailStatus == EventTestItemStatus.Availed.Name).OrderBy(
                    odv => odv.OrderDetailDateCreated));

            // Add the availed products to the sorted list.
            sortedOrderViewData.AddRange(
                orderViewData.Where(
                    odv =>
                    odv.OrderDetailType == productItem &&
                    odv.OrderDetailStatus == ProductItemStatus.Availed.Name).OrderBy(
                    odv => odv.OrderDetailDateCreated));

            // Add the availed gift certificate to the sorted list.
            sortedOrderViewData.AddRange(
                orderViewData.Where(
                    odv =>
                    odv.OrderDetailType == giftCertificateItem &&
                    odv.OrderDetailStatus == GiftCertificateItemStatus.PaidFor.Name).OrderBy(
                    odv => odv.OrderDetailDateCreated));

            // Get the last order detail to which we will attach the source code and shipping detail.
            var lastOrderDetail = sortedOrderViewData.LastOrDefault();

            // Finally we have to bind source code and shipping to the last order detail.
            var sourceCodeOrderDetail = sortedOrderViewData.SingleOrDefault(sovd => sovd.SourceCode != null);

            if (sourceCodeOrderDetail != null && lastOrderDetail != null && lastOrderDetail.SourceCode == null)
            {
                lastOrderDetail.SourceCode = sourceCodeOrderDetail.SourceCode;
                sourceCodeOrderDetail.SourceCode = null;
            }

            var shippingDetailOrderDetails =
                sortedOrderViewData.Where(sovd => !sovd.ShippingDetails.IsNullOrEmpty()).ToList();
            foreach (var shippingDetailOrderDetail in shippingDetailOrderDetails)
            {
                if (shippingDetailOrderDetail != null && !shippingDetailOrderDetail.ShippingDetails.IsNullOrEmpty() && lastOrderDetail != null && lastOrderDetail != shippingDetailOrderDetail)// && lastOrderDetail.ShippingDetails.IsNullOrEmpty()
                {
                    if (lastOrderDetail.ShippingDetails == null)
                        lastOrderDetail.ShippingDetails = new List<ShippingDetailViewData>();

                    lastOrderDetail.ShippingDetails.AddRange(shippingDetailOrderDetail.ShippingDetails);
                }
                if (lastOrderDetail != shippingDetailOrderDetail)
                    shippingDetailOrderDetail.ShippingDetails = null;
            }

            sortedOrderViewData.AddRange(orderViewData.Where(
                                             odv =>
                                             odv.OrderDetailType == refundItem).OrderBy(odv=>odv.OrderDetailDateCreated));

            //&& odv.OrderDetailStatus == RefundItemStatus.Applied.Name
            return sortedOrderViewData;
        }

        public Order CancelRefundOrder(IEnumerable<IOrderable> refundOrderItem, Order order, DomainObjectBase creatorOrganizationRoleUser, DomainObjectBase forOrganizationRoleUser)
        {
            IOrderController orderController = new OrderController();
            foreach (var orderable in refundOrderItem)
            {
                orderController.AddItem(orderable, 1, forOrganizationRoleUser.Id, creatorOrganizationRoleUser.Id, null,
                                    null, null, RefundItemStatus.NotApplied.OrderStatusState);
            }

            order = orderController.RefundOrder(order);
            return order;
        }
    }
}