using System.Collections.Generic;
using System.Linq;
using Falcon.App.Core.Enum;
using Falcon.App.Core.Finance.Domain;
using Falcon.App.Core.Finance.Interfaces;
using Falcon.App.Infrastructure.Factories.Order;
using Falcon.App.Core.Extensions;

namespace Falcon.App.Infrastructure.Service
{
    public class OrderSynchronizationService : IOrderSynchronizationService
    {
        private readonly IOrderDetailFactory _orderDetailFactory;

        public OrderSynchronizationService()
            : this(new OrderDetailFactory())
        { }

        public OrderSynchronizationService(IOrderDetailFactory orderDetailFactory)
        {
            _orderDetailFactory = orderDetailFactory;
        }

        // TODO: Once order system is refactored this method will have to be rewritten.
        public Order SynchronizeOrder(Order oldOrder, Order newOrder, SourceCodeOrderDetail newSourceCodeOrderDetail)
        {
            if (oldOrder.OrderDetails.IsNullOrEmpty()) return newOrder;

            var newOrderDetails = new List<OrderDetail>();

            newOrder.OrderDetails.ForEach(newOrderDetails.Add);
            var newOrderItemIds = newOrderDetails.Select(od => od.OrderItemId);
            var newOrderDetailCreator = newOrderDetails.First().DataRecorderMetaData.DataRecorderCreator.Id;
            var oldOrderDetails = oldOrder.OrderDetails;
            var oldOrderItemIds = oldOrderDetails.Select(od => od.OrderItemId);

            newOrder.OrderDetails.Clear();

            var alreadyCancelledOrderDetails =
                oldOrderDetails.Where(
                    ood =>
                    !ood.IsCompleted ||
                    (ood.DetailType != OrderItemType.EventPackageItem && ood.DetailType != OrderItemType.EventTestItem && ood.DetailType != OrderItemType.ProductItem))
                    .ToList();

            var alreadyCancelledOrderItemIds = alreadyCancelledOrderDetails.Select(od => od.OrderItemId);

            newOrder.OrderDetails.AddRange(alreadyCancelledOrderDetails);

            // It will give the line items which still exists for the order.
            var existingOrderDetails = newOrderDetails.Join(oldOrderDetails, nod => nod.OrderItemId,
                                                            ood => ood.OrderItemId, (nod, ood) => ood);

            newOrder.OrderDetails.AddRange(existingOrderDetails);

            // It will give the line items which does not exist for the order.
            var nonExistingOrderDetails =
                oldOrderDetails.Where(
                    eod =>
                    !newOrderItemIds.Contains(eod.OrderItemId) && eod.IsCompleted &&
                    (eod.DetailType == OrderItemType.EventPackageItem || eod.DetailType == OrderItemType.EventTestItem));

            EventCustomerOrderDetail eventCustomerOrderDetail = null;
            List<ShippingDetailOrderDetail> shippingDetailOrderDetails = null;

            foreach (var nonExistingOrderDetail in nonExistingOrderDetails)
            {
                if (nonExistingOrderDetail.EventCustomerOrderDetail != null)
                {
                    eventCustomerOrderDetail = new EventCustomerOrderDetail
                                                   {
                                                       EventCustomerId =
                                                           nonExistingOrderDetail.EventCustomerOrderDetail.
                                                           EventCustomerId,
                                                       IsActive = true,
                                                       OrderDetailId = 0
                                                   };
                    if (!nonExistingOrderDetail.ShippingDetailOrderDetails.IsNullOrEmpty())
                    {
                        if (shippingDetailOrderDetails.IsNullOrEmpty())
                            shippingDetailOrderDetails = new List<ShippingDetailOrderDetail>();

                        foreach (var shippingDetailOrderDetail in nonExistingOrderDetail.ShippingDetailOrderDetails)
                        {
                            if (shippingDetailOrderDetails != null)
                                shippingDetailOrderDetails.Add(new ShippingDetailOrderDetail
                                                                   {
                                                                       ShippingDetailId =
                                                                           shippingDetailOrderDetail.ShippingDetailId,
                                                                       IsActive = true
                                                                   });
                        }
                    }

                    shippingDetailOrderDetails = nonExistingOrderDetail.ShippingDetailOrderDetails;
                    shippingDetailOrderDetails.ForEach(sdod => sdod.OrderDetailId = 0);
                }

                var cancelledOrderDetail = _orderDetailFactory.CreateNewOrderDetail(nonExistingOrderDetail,
                                                                                    nonExistingOrderDetail.
                                                                                        ForOrganizationRoleUserId,
                                                                                    newOrderDetailCreator);

                newOrder.OrderDetails.Add(nonExistingOrderDetail);
                newOrder.OrderDetails.Add(cancelledOrderDetail);
            }

            // It will give the line items which are new for this order.
            var freshOrderDetails = newOrderDetails.Where(nod => !oldOrderItemIds.Contains(nod.OrderItemId)).ToList();

            var alreadyAddedOrderItems = newOrder.OrderDetails.Where(od => od.IsCompleted).Select(nod => nod.OrderItemId);

            // Items which were cancelled earlier and are made active again.
            var cancelledOrderDetailsToBeRevived =
                newOrderDetails.Where(
                    nod =>
                    alreadyCancelledOrderItemIds.Contains(nod.OrderItemId) && nod.IsCompleted &&
                    !alreadyAddedOrderItems.Contains(nod.OrderItemId));

            newOrder.OrderDetails.AddRange(cancelledOrderDetailsToBeRevived);

            newOrder.OrderDetails.AddRange(freshOrderDetails);

            if (eventCustomerOrderDetail != null)
            {
                var currentActiveOrderDetail =
                    newOrder.OrderDetails.SingleOrDefault(
                        od =>
                        od.SourceCodeOrderDetail != null &&
                        od.OrderItemStatus.OrderStatusState == OrderStatusState.FinalSuccess) ??
                    newOrder.OrderDetails.First(
                        od =>
                        od.OrderItemStatus.OrderStatusState == OrderStatusState.FinalSuccess &&
                        (od.DetailType == OrderItemType.EventPackageItem || od.DetailType == OrderItemType.EventTestItem));

                newOrder.OrderDetails.Remove(currentActiveOrderDetail);

                currentActiveOrderDetail.EventCustomerOrderDetail = eventCustomerOrderDetail;
                currentActiveOrderDetail.ShippingDetailOrderDetails = shippingDetailOrderDetails;
                currentActiveOrderDetail.SourceCodeOrderDetail = newSourceCodeOrderDetail;

                newOrder.OrderDetails.Add(currentActiveOrderDetail);
            }
            else
            {
                var currentActiveOrderDetail =
                    newOrder.OrderDetails.SingleOrDefault(
                        od =>
                        od.EventCustomerOrderDetail != null &&
                        od.OrderItemStatus.OrderStatusState == OrderStatusState.FinalSuccess);

                newOrder.OrderDetails.Remove(currentActiveOrderDetail);
                if (newSourceCodeOrderDetail != null)
                {
                    currentActiveOrderDetail.SourceCodeOrderDetail = newSourceCodeOrderDetail;
                    newSourceCodeOrderDetail.OrderDetailId = currentActiveOrderDetail.Id;
                }
                newOrder.OrderDetails.Add(currentActiveOrderDetail);
            }

            foreach (var orderDetail in newOrder.OrderDetails)
            {
                if (orderDetail.IsCompleted)
                {
                    var newOrderDetail = newOrderDetails.SingleOrDefault(od => od.OrderItemId == orderDetail.OrderItemId);
                    if (newOrderDetail != null)
                        orderDetail.Price = newOrderDetail.Price;
                }
            }

            return newOrder;
        }
    }
}