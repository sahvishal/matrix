using System;
using System.Collections.Generic;
using System.Linq;
using System.Transactions;
using Falcon.App.Core;
using Falcon.App.Core.Application;
using Falcon.App.Core.Domain;
using Falcon.App.Core.Enum;
using Falcon.App.Core.Extensions;
using Falcon.App.Core.Finance.Domain;
using Falcon.App.Core.Finance.Enum;
using Falcon.App.Core.Finance.Impl;
using Falcon.App.Core.Finance.Interfaces;
using Falcon.App.Core.Finance.ViewModels;
using Falcon.App.Core.Marketing.Domain;
using Falcon.App.Core.Operations;
using Falcon.App.Core.Operations.Domain;
using Falcon.App.Core.Operations.Enum;
using Falcon.App.Core.Scheduling;
using Falcon.App.Core.Scheduling.Domain;
using Falcon.App.Core.Scheduling.Enum;
using Falcon.App.Core.Users;
using Falcon.App.Infrastructure.Factories.Order;
using Falcon.App.Infrastructure.Repositories;
using Falcon.App.Infrastructure.Repositories.Order;
using Falcon.App.Infrastructure.Repositories.Shipping;
using Falcon.App.Infrastructure.Repositories.Users;
using Falcon.App.Infrastructure.Scheduling.Repositories;
using Falcon.App.Infrastructure.Service;

namespace Falcon.App.Infrastructure.Finance.Impl
{
    public class OrderController : IOrderController
    {
        private readonly IOrderRepository _orderRepository;
        private readonly IOrderItemRepository _orderItemRepository;
        private readonly IOrderSynchronizationService _orderSynchronizationService;

        private readonly IOrderFactory _orderFactory;
        private readonly IOrderDetailFactory _orderDetailFactory;
        private readonly List<OrderedPair<OrderDetail, IOrderable>> _lineItems = new List<OrderedPair<OrderDetail, IOrderable>>();

        private readonly IOrderItemStatusFactory _orderItemStatusFactory;
        private readonly IUniqueItemRepository<Refund> _refundRepository;
        private readonly IElectronicProductRepository _electronicProductRepository;
        private readonly IShippingDetailRepository _shippingDetailRepository;
        private readonly IPreApprovedTestRepository _preApprovedTestRepository;
        private readonly IPreApprovedPackageRepository _preApprovedPackageRepository;
        private readonly IOrganizationRoleUserRepository _organizationRoleUserRepository;

        public OrderController()
            : this(new OrderRepository(), new OrderItemRepository(), new OrderFactory(),
            new OrderDetailFactory(), new ElectronicProductRepository(), new OrderItemStatusFactory(), new OrderSynchronizationService(), new RefundRepository(), new ShippingDetailRepository(),
            new PreApprovedTestRepository(), new PreApprovedPackageRepository(), new OrganizationRoleUserRepository())
        { }

        public OrderController(IOrderRepository orderRepository, IOrderItemRepository orderItemRepository,
            IOrderFactory orderFactory, IOrderDetailFactory orderDetailFactory, IElectronicProductRepository electronicProductRepository,
        IOrderItemStatusFactory orderItemStatusFactory, IOrderSynchronizationService orderSynchronizationService, IUniqueItemRepository<Refund> refundRepository,
            IShippingDetailRepository shippingDetailRepository, IPreApprovedTestRepository preApprovedTestRepository, IPreApprovedPackageRepository preApprovedPackageRepository,
            IOrganizationRoleUserRepository organizationRoleUserRepository)
        {
            _orderRepository = orderRepository;
            _orderItemStatusFactory = orderItemStatusFactory;
            _orderItemRepository = orderItemRepository;
            _orderFactory = orderFactory;
            _orderDetailFactory = orderDetailFactory;
            _orderSynchronizationService = orderSynchronizationService;
            _refundRepository = refundRepository;
            _electronicProductRepository = electronicProductRepository;
            _shippingDetailRepository = shippingDetailRepository;
            _preApprovedTestRepository = preApprovedTestRepository;
            _preApprovedPackageRepository = preApprovedPackageRepository;
            _organizationRoleUserRepository = organizationRoleUserRepository;
        }

        public void AddItem(IOrderable itemToOrder, int quantity, long forOrganizationRoleUserId,
            long dataRecorderCreatorId)
        {
            AddItem(itemToOrder, quantity, forOrganizationRoleUserId, dataRecorderCreatorId, null, null, null, OrderStatusState.Initial);
        }

        public void AddItem(IOrderable itemToOrder, int quantity, long forOrganizationRoleUserId,
            long dataRecorderCreatorId, OrderStatusState orderStatusState, long? sourceId = null)
        {
            AddItem(itemToOrder, quantity, forOrganizationRoleUserId, dataRecorderCreatorId, null, null, null, orderStatusState, sourceId);
        }

        public void AddItem(IOrderable itemToOrder, int quantity, long forOrganizationRoleUserId,
            long dataRecorderCreatorId, SourceCode sourceCode, EventCustomer eventCustomer,
            ShippingDetail shippingDetail, OrderStatusState orderStatusState, long? sourceId = null)
        {

            if (sourceId == null && (itemToOrder is EventPackage || itemToOrder is EventTest))
            {
                var customerId = forOrganizationRoleUserId;
                if (itemToOrder is EventTest)
                {
                    var preApprovedTestList = _preApprovedTestRepository.GetByCustomerId(customerId).Select(x => x.TestId);
                    if (preApprovedTestList.Contains(((EventTest)itemToOrder).TestId))
                    {
                        sourceId = (long)OrderSource.PreApproved;
                    }
                }
                else if (itemToOrder is EventPackage)
                {
                    var preApprovedPackageList = _preApprovedPackageRepository.GetByCustomerId(customerId).Select(x => x.PackageId);
                    if (preApprovedPackageList.Contains(((EventPackage)itemToOrder).PackageId))
                    {
                        sourceId = (long)OrderSource.PreApproved;
                    }
                }
                if (sourceId == null)
                {
                    var oru = _organizationRoleUserRepository.GetOrganizationRoleUser(dataRecorderCreatorId);
                    if (oru.RoleId == (long) Roles.FranchiseeAdmin)
                    {
                        sourceId = (long)OrderSource.Admin;
                    }
                    else if (oru.RoleId == (long)Roles.CallCenterRep)
                    {
                        sourceId = (long)OrderSource.CallCenter;
                    }
                    else if (oru.RoleId == (long)Roles.Technician)
                    {
                        sourceId = (long)OrderSource.Technician;
                    }
                    else if (oru.RoleId == (long)Roles.NursePractitioner)
                    {
                        sourceId = (long)OrderSource.NursePractioner;
                    }
                }
            }


            OrderDetail orderDetail = _orderDetailFactory.CreateNewOrderDetail(itemToOrder, quantity,
                                                                               forOrganizationRoleUserId,
                                                                               dataRecorderCreatorId,
                                                                               sourceCode, eventCustomer, shippingDetail, sourceId);
            orderDetail.OrderItemStatus = _orderItemStatusFactory.CreateOrderItemStatus(itemToOrder.OrderItemType,
                                                                                        (int)orderStatusState);

            var pair = new OrderedPair<OrderDetail, IOrderable>(orderDetail, itemToOrder);
            _lineItems.Add(pair);
        }

        public Core.Finance.Domain.Order PlaceOrder(OrderType typeOfOrderToPlace, long dataRecorderCreatorId)
        {
            if (!_lineItems.Any())
            {
                throw new InvalidOperationException("The order must contain at least one line item.");
            }

            Core.Finance.Domain.Order order;
            using (var transaction = new TransactionScope())
            {
                order = _orderFactory.CreateNewOrder(typeOfOrderToPlace, dataRecorderCreatorId);
                foreach (var lineItem in _lineItems)
                {
                    OrderItem orderItem = _orderItemRepository.SaveOrderItem(lineItem.SecondValue.Id, lineItem.SecondValue.OrderItemType);
                    lineItem.FirstValue.OrderItemId = orderItem.Id;
                    lineItem.FirstValue.OrderId = order.Id;
                    order.OrderDetails.Add(lineItem.FirstValue);
                }
                order = _orderRepository.SaveOrder(order);
                transaction.Complete();
            }
            _lineItems.Clear();
            return order;
        }

        public Core.Finance.Domain.Order PlaceOrder(Core.Finance.Domain.Order order)
        {
            var newOrder = _orderFactory.CreateDuplicateOrder(order);

            if (!_lineItems.Any())
            {
                throw new InvalidOperationException("The order must contain at least one line item.");
            }

            if (order == null) throw new InvalidOperationException("The order can not be null.");

            using (var transaction = new TransactionScope())
            {
                foreach (var lineItem in _lineItems)
                {
                    OrderItem orderItem = _orderItemRepository.SaveOrderItem(lineItem.SecondValue.Id, lineItem.SecondValue.OrderItemType);
                    lineItem.FirstValue.OrderItemId = orderItem.Id;
                    lineItem.FirstValue.OrderId = order.Id;
                    newOrder.OrderDetails.Add(lineItem.FirstValue);
                }

                // Get the new sourceCode applied...
                var orderDetailWithSourceCode = newOrder.OrderDetails.SingleOrDefault(od => od.SourceCodeOrderDetail != null);
                var sourceCodeOrderDetail = orderDetailWithSourceCode != null
                                                ? orderDetailWithSourceCode.SourceCodeOrderDetail
                                                : null;
                if (orderDetailWithSourceCode != null)
                    orderDetailWithSourceCode.SourceCodeOrderDetail = null;

                newOrder = _orderSynchronizationService.SynchronizeOrder(order, newOrder, sourceCodeOrderDetail);
                newOrder = _orderRepository.SaveOrder(newOrder);
                transaction.Complete();
            }
            _lineItems.Clear();
            return newOrder;

        }

        public Core.Finance.Domain.Order PlaceProductOrder(Core.Finance.Domain.Order order)
        {
            var newOrder = _orderFactory.CreateDuplicateOrder(order);

            if (!_lineItems.Any())
            {
                throw new InvalidOperationException("The order must contain at least one line item.");
            }

            if (order == null) throw new InvalidOperationException("The order can not be null.");

            using (var transaction = new TransactionScope())
            {
                foreach (var lineItem in _lineItems)
                {
                    OrderItem orderItem = _orderItemRepository.SaveOrderItem(lineItem.SecondValue.Id, lineItem.SecondValue.OrderItemType);
                    lineItem.FirstValue.OrderItemId = orderItem.Id;
                    lineItem.FirstValue.OrderId = order.Id;
                    newOrder.OrderDetails.Add(lineItem.FirstValue);
                }

                newOrder = _orderRepository.SaveOrder(newOrder);
                transaction.Complete();
            }
            _lineItems.Clear();
            return newOrder;
        }

        public Core.Finance.Domain.Order ActivateOrder(Core.Finance.Domain.Order order)
        {
            if (!_lineItems.Any())
            {
                throw new InvalidOperationException("The order must contain at least one line item.");
            }

            if (order == null) throw new InvalidOperationException("The order can not be null.");

            using (var transaction = new TransactionScope())
            {
                foreach (var lineItem in _lineItems)
                {
                    OrderItem orderItem = _orderItemRepository.SaveOrderItem(lineItem.SecondValue.Id, lineItem.SecondValue.OrderItemType);
                    lineItem.FirstValue.OrderItemId = orderItem.Id;
                    lineItem.FirstValue.OrderId = order.Id;
                    order.OrderDetails.Add(lineItem.FirstValue);
                }
                order = _orderRepository.SaveOrder(order);
                transaction.Complete();
            }
            _lineItems.Clear();
            return order;
        }

        public Order CancelOrder(long eventId, long customerId, long dataRecorderOrgRoleUserId, bool chargeCancellation = true)
        {
            var order = _orderRepository.GetOrder(customerId, eventId);

            if (order != null && !order.OrderDetails.IsEmpty())
            {
                OrderDetail orderDetail = GetActiveOrderDetail(order);
                if (orderDetail == null) return null;
                if (orderDetail.EventCustomerOrderDetail == null) return null;

                return CancelOrder(order, customerId, dataRecorderOrgRoleUserId, chargeCancellation);
            }
            return null;
        }

        public Order CancelOrder(Order order, long forOrganizationRoleUserId, long dataRecorderCreatorId, bool chargeCancellation = true)
        {
            if (order == null) throw new InvalidOperationException("The order can not be null.");

            using (var transaction = new TransactionScope())
            {
                var orderDetailsToBeCancelled = new List<OrderDetail>();
                orderDetailsToBeCancelled.AddRange(order.OrderDetails.Where(CancelOrderPredicate));
                order.OrderDetails.RemoveAll(CancelOrderPredicate);

                foreach (var detailsToBeCancelled in orderDetailsToBeCancelled)
                {
                    var cancelledOrderDetail = _orderDetailFactory.CreateNewOrderDetail(detailsToBeCancelled,
                                                                                        forOrganizationRoleUserId,
                                                                                        dataRecorderCreatorId);
                    order.OrderDetails.Add(detailsToBeCancelled);
                    order.OrderDetails.Add(cancelledOrderDetail);
                }

                if (chargeCancellation)
                {
                    IConfigurationSettingRepository _configRepository = new ConfigurationSettingRepository();
                    var cancellationFeeString =
                        _configRepository.GetConfigurationValue(ConfigurationSettingName.CancellationFee);
                    decimal cancellationFee = 0;
                    if (!string.IsNullOrEmpty(cancellationFeeString))
                        decimal.TryParse(cancellationFeeString, out cancellationFee);

                    if (order.TotalAmountPaid >= cancellationFee) // May be greater than Cancellation fee
                    {
                        var cancelledFeeOrderItemTypeOrderDetail =
                            _orderDetailFactory.CreateNewOrderDetailforCanellationItem(cancellationFee, order.Id,
                                                                                       forOrganizationRoleUserId,
                                                                                       dataRecorderCreatorId);
                        var orderItemId = _orderItemRepository.SaveCancellationFeeOrderItem();
                        cancelledFeeOrderItemTypeOrderDetail.OrderItemId = orderItemId;
                        order.OrderDetails.Add(cancelledFeeOrderItemTypeOrderDetail);
                    }
                }

                order = _orderRepository.SaveOrder(order);
                transaction.Complete();
            }
            _lineItems.Clear();
            return order;

        }

        public Order NegateAppointmentOrderagainstGiftCertificate(Order order, long forOrganizationRoleUserId, long dataRecorderCreatorId)
        {
            if (order == null) throw new InvalidOperationException("The order can not be null.");

            using (var transaction = new TransactionScope())
            {
                var orderDetailsToBeCancelled = new List<OrderDetail>();
                orderDetailsToBeCancelled.AddRange(order.OrderDetails.Where(CancelOrderPredicate));
                order.OrderDetails.RemoveAll(CancelOrderPredicate);

                foreach (var detailsToBeCancelled in orderDetailsToBeCancelled)
                {
                    var cancelledOrderDetail = _orderDetailFactory.CreateNewOrderDetail(detailsToBeCancelled,
                                                                                        forOrganizationRoleUserId,
                                                                                        dataRecorderCreatorId);
                    order.OrderDetails.Add(detailsToBeCancelled);
                    order.OrderDetails.Add(cancelledOrderDetail);
                }
                var lineItem = _lineItems.FirstOrDefault();
                OrderItem orderItem = _orderItemRepository.SaveOrderItem(lineItem.SecondValue.Id, lineItem.SecondValue.OrderItemType);
                lineItem.FirstValue.OrderItemId = orderItem.Id;
                lineItem.FirstValue.OrderId = order.Id;

                order.OrderDetails.Add(lineItem.FirstValue);

                order = _orderRepository.SaveOrder(order);
                transaction.Complete();
            }
            _lineItems.Clear();
            return order;
        }

        public Order AdjustOrderagainstGiftCertificate(Order order, long forOrganizationRoleUserId, long dataRecorderCreatorId)
        {
            if (order == null) throw new InvalidOperationException("The order can not be null.");

            using (var transaction = new TransactionScope())
            {
                var lineItem = _lineItems.FirstOrDefault();
                OrderItem orderItem = _orderItemRepository.SaveOrderItem(lineItem.SecondValue.Id, lineItem.SecondValue.OrderItemType);
                lineItem.FirstValue.OrderItemId = orderItem.Id;
                lineItem.FirstValue.OrderId = order.Id;

                order.OrderDetails.Add(lineItem.FirstValue);

                order = _orderRepository.SaveOrder(order);
                transaction.Complete();
            }
            _lineItems.Clear();
            return order;
        }

        private bool CancelOrderPredicate(OrderDetail od)
        {
            return od.OrderItemStatus.OrderStatusState == OrderStatusState.FinalSuccess &&
                   (od.DetailType == OrderItemType.EventPackageItem || od.DetailType == OrderItemType.EventTestItem || od.DetailType == OrderItemType.ProductItem || od.DetailType == OrderItemType.RefundItem);
        }

        public Core.Finance.Domain.Order UpdateOrder(Core.Finance.Domain.Order order, SourceCode sourceCode, long dataRecorderCreatorId)
        {
            if (order == null) throw new InvalidOperationException("The order can not be null.");

            var existingActiveOrderDetail = GetActiveOrderDetail(order);

            if (existingActiveOrderDetail == null) throw new InvalidOperationException("The order must contain at least one active line item.");

            if (existingActiveOrderDetail.EventCustomerOrderDetail == null) throw new InvalidOperationException("The order must contain at least one active line item.");

            existingActiveOrderDetail.SourceCodeOrderDetail = new SourceCodeOrderDetail
                                                                  {
                                                                      Amount = sourceCode.CouponValue,
                                                                      OrderDetailId = existingActiveOrderDetail.Id,
                                                                      IsActive = true,
                                                                      OrganizationRoleUserCreatorId =
                                                                          dataRecorderCreatorId,
                                                                      SourceCodeId = sourceCode.Id
                                                                  };

            using (var transaction = new TransactionScope())
            {
                order = _orderRepository.SaveOrder(order);
                transaction.Complete();
            }
            return order;
        }

        public Core.Finance.Domain.Order RefundOrder(Core.Finance.Domain.Order order)
        {
            if (!_lineItems.Any())
            {
                throw new InvalidOperationException("The order must contain at least one line item.");
            }

            if (order == null) throw new InvalidOperationException("The order can not be null.");

            using (var transaction = new TransactionScope())
            {
                foreach (var lineItem in _lineItems)
                {
                    OrderItem orderItem = _orderItemRepository.SaveOrderItem(lineItem.SecondValue.Id,
                                                                             lineItem.SecondValue.OrderItemType);
                    lineItem.FirstValue.OrderItemId = orderItem.Id;
                    lineItem.FirstValue.OrderId = order.Id;
                    order.OrderDetails.Add(lineItem.FirstValue);
                }
                order = _orderRepository.SaveOrder(order);
                transaction.Complete();
            }
            _lineItems.Clear();
            return order;
        }

        public OrderDetail GetActiveOrderDetail(long orderId)
        {
            try
            {
                var order = _orderRepository.GetOrder(orderId);
                return GetActiveOrderDetail(order.OrderDetails);
            }
            // Throw the incoming exception.
            catch { throw; }
        }

        public OrderDetail GetActiveOrderDetail(Core.Finance.Domain.Order order)
        {
            return GetActiveOrderDetail(order.OrderDetails);
        }

        public OrderDetail GetActiveOrderDetail(IEnumerable<OrderDetail> orderDetails)
        {
            return
                orderDetails.SingleOrDefault(
                    od =>
                    (od.DetailType == OrderItemType.EventPackageItem || od.DetailType == OrderItemType.EventTestItem) &&
                    od.EventCustomerOrderDetail != null && od.EventCustomerOrderDetail.IsActive && od.IsCompleted);
        }

        public void ManageOrderforRefundRequestwithFreeDiscountandProduct(RefundRequestResultEditModel model, long orderId, long customerId, long processedbyOrgRoleUserId)
        {
            var order = _orderRepository.GetOrder(orderId);
            if (order == null) return;
            var dataRecorder = new DataRecorderMetaData(processedbyOrgRoleUserId, DateTime.Now, null);

            var productsAvailed = model.OfferFreeProduct.Where(fp => fp.ProductAvailed);

            foreach (var product in productsAvailed)
            {
                long orderItemId = product.OrderItemId;
                if (orderItemId < 1)
                {
                    orderItemId = _orderItemRepository.SaveOrderItem(product.ProductId, OrderItemType.ProductItem).Id;
                    var orderDetail = new OrderDetail()
                                    {
                                        DataRecorderMetaData = dataRecorder,
                                        Description = "Offered free product while Resolving Request",
                                        DetailType = OrderItemType.ProductItem,
                                        ForOrganizationRoleUserId = customerId,
                                        OrderId = orderId,
                                        OrderItemId = orderItemId,
                                        OrderItemStatus =
                                            (new OrderItemStatusFactory()).CreateOrderItemStatus(
                                                OrderItemType.ProductItem, ProductItemStatus.Availed.StatusCode),
                                        Price = 0.00m,
                                        Quantity = 1
                                    };
                    order.OrderDetails.Add(orderDetail);
                }
                else
                {
                    var eproduct = _electronicProductRepository.GetById(product.ProductId);
                    order.OrderDetails.Add(GetRefunTypeOrderLineItem(product.ProductPriceinOrder.Value, "Issuing Refund for Product " + eproduct.Name + " in Order [Id:" + orderId + "]", orderId, customerId, processedbyOrgRoleUserId));
                }
            }

            if (model.OfferDiscount)
            {
                order.OrderDetails.Add(GetRefunTypeOrderLineItem(model.DiscountAmount, "Offered Discount while Resolving Request", orderId, customerId, processedbyOrgRoleUserId));
            }

            order = _orderRepository.SaveOrder(order);
        }

        private OrderDetail GetRefunTypeOrderLineItem(decimal amount, string reasonForRefund, long orderId, long customerId, long processedbyOrgRoleUserId)
        {
            var dataRecorder = new DataRecorderMetaData(processedbyOrgRoleUserId, DateTime.Now, null);
            var refund = new Refund()
            {
                DataRecorderMetaData = dataRecorder,
                Notes = reasonForRefund,
                RefundReason = RefundReason.ProcessedRefundRequest,
                Price = amount
            };

            refund = _refundRepository.Save(refund);
            OrderItem orderItem = _orderItemRepository.SaveOrderItem(refund.Id, OrderItemType.RefundItem);

            var orderDetail = new OrderDetail()
            {
                DataRecorderMetaData = dataRecorder,
                Description = reasonForRefund,
                DetailType = OrderItemType.RefundItem,
                ForOrganizationRoleUserId = customerId,
                OrderId = orderId,
                OrderItemId = orderItem.Id,
                OrderItemStatus =
                    (new OrderItemStatusFactory()).CreateOrderItemStatus(
                        OrderItemType.RefundItem, RefundItemStatus.Applied.StatusCode),
                Price = amount,
                Quantity = 1
            };

            return orderDetail;
        }

        /// <summary>
        /// Negating a provided certain order item ids
        /// </summary>
        /// <param name="orderDetailIds"></param>
        /// <param name="order"></param>
        /// <param name="dataRecorderCreatorId"></param>
        public void NegateOrderLineItems(IEnumerable<long> orderDetailIds, Order order, long dataRecorderCreatorId)
        {
            if (order == null) throw new InvalidOperationException("The order can not be null.");

            var orderDetailsToBeCancelled = new List<OrderDetail>();
            orderDetailsToBeCancelled.AddRange(order.OrderDetails.Where(od => orderDetailIds.Contains(od.Id)));
            order.OrderDetails.RemoveAll(od => orderDetailIds.Contains(od.Id));
            var shippingDetailsToCancelled = new List<ShippingDetail>();
            long orderDetailId = 0;
            foreach (var detailsToBeCancelled in orderDetailsToBeCancelled)
            {
                var cancelledOrderDetail = _orderDetailFactory.CreateNewOrderDetail(detailsToBeCancelled,
                                                                                    detailsToBeCancelled.ForOrganizationRoleUserId,
                                                                                    dataRecorderCreatorId);
                order.OrderDetails.Add(detailsToBeCancelled);
                order.OrderDetails.Add(cancelledOrderDetail);

                if (detailsToBeCancelled.DetailType == OrderItemType.ProductItem)
                {
                    OrderDetail orderDetail = GetActiveOrderDetail(order);
                    orderDetailId = orderDetail.Id;
                    var shippingDetails = _shippingDetailRepository.GetProductShippingDetailsForCancellation(orderDetail.Id).ToList();
                    shippingDetails = shippingDetails.Where(sd => sd.Status == ShipmentStatus.Processing).Select(sd => sd).ToList();
                    var shippingDetail = shippingDetails.FirstOrDefault();

                    if (shippingDetail != null)
                    {
                        shippingDetailsToCancelled.Add(shippingDetail);
                        shippingDetails.Remove(shippingDetail);
                    }
                }
            }

            //var lineItem = _lineItems.FirstOrDefault();
            //OrderItem orderItem = _orderItemRepository.SaveOrderItem(lineItem.SecondValue.Id, lineItem.SecondValue.OrderItemType);
            //lineItem.FirstValue.OrderItemId = orderItem.Id;
            //lineItem.FirstValue.OrderId = order.Id;

            //order.OrderDetails.Add(lineItem.FirstValue);

            order = _orderRepository.SaveOrder(order);

            if (shippingDetailsToCancelled.Count > 0)
            {
                IShippingDetailOrderDetailRepository shippingDetailOrderDetailRepository =
                            new ShippingDetailOrderDetailRepository();
                foreach (var shippingDetail in shippingDetailsToCancelled)
                {
                    shippingDetailOrderDetailRepository.UpdateStatus(shippingDetail.Id, orderDetailId, false);
                    var shipping = _shippingDetailRepository.GetById(shippingDetail.Id);
                    shipping.Status = ShipmentStatus.Cancelled;
                    _shippingDetailRepository.Save(shipping);
                }
            }
        }

    }
}