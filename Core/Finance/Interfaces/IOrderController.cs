using System.Collections.Generic;
using Falcon.App.Core.Enum;
using Falcon.App.Core.Finance.Domain;
using Falcon.App.Core.Finance.ViewModels;
using Falcon.App.Core.Marketing.Domain;
using Falcon.App.Core.Operations.Domain;
using Falcon.App.Core.Scheduling.Domain;

namespace Falcon.App.Core.Finance.Interfaces
{
    public interface IOrderController
    {
        void AddItem(IOrderable itemToOrder, int quantity, long forOrganizationRoleUserId, 
            long dataRecorderCreatorId);

        void AddItem(IOrderable itemToOrder, int quantity, long forOrganizationRoleUserId,
            long dataRecorderCreatorId, OrderStatusState orderStatusState, long? sourceId = null);

        void AddItem(IOrderable itemToOrder, int quantity, long forOrganizationRoleUserId,
                     long dataRecorderCreatorId, SourceCode sourceCode, EventCustomer eventCustomer,
                     ShippingDetail shippingDetail, OrderStatusState orderStatusState, long? sourceId = null);

        Order PlaceOrder(OrderType typeOfOrderToPlace, long dataRecorderCreatorId);
        Order PlaceOrder(Order order);
        Order ActivateOrder(Order order);
        Order CancelOrder(Order order, long forOrganizationRoleUserId, long dataRecorderCreatorId, bool chargeCancellation = true);
        Order UpdateOrder(Order order, SourceCode sourceCode, long dataRecorderCreatorId);
        Order RefundOrder(Order order);

        OrderDetail GetActiveOrderDetail(long orderId);
        OrderDetail GetActiveOrderDetail(Order order);
        OrderDetail GetActiveOrderDetail(IEnumerable<OrderDetail> orderDetails);
        Order PlaceProductOrder(Order order);

        void ManageOrderforRefundRequestwithFreeDiscountandProduct(RefundRequestResultEditModel model, long orderId, long customerId, long processedbyOrgRoleUserId);

        Order NegateAppointmentOrderagainstGiftCertificate(Order order, long forOrganizationRoleUserId, long dataRecorderCreatorId);
        Order AdjustOrderagainstGiftCertificate(Order order, long forOrganizationRoleUserId, long dataRecorderCreatorId);
        void NegateOrderLineItems(IEnumerable<long> orderDetailIds, Order order, long dataRecorderCreatorId);
    }
}