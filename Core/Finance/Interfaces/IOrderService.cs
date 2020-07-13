using System.Collections.Generic;
using Falcon.App.Core.Domain;
using Falcon.App.Core.Finance.Domain;
using Falcon.App.Core.Finance.ViewModels;
using Falcon.App.Core.Users.Domain;

namespace Falcon.App.Core.Finance.Interfaces
{
    public interface IOrderService
    {
        IEnumerable<OrderViewData> GetOrderDetailViewData(long orderId);
        IEnumerable<PaymentViewData> GetPaymentDetailViewData(long orderId);

        bool RefundOrder(long orderId, decimal amount, int refundMode, string notes, string checkNumber,
                         long customerId, long organizationRoleUserId);

        Refund SaveRefundOrderItem(OrganizationRoleUser creatorOrganizationRoleUser, string notes,
                                   decimal amount);

        Order RefundOrder(IOrderable refundOrderItem, Order order,
                          DomainObjectBase creatorOrganizationRoleUser, DomainObjectBase forOrganizationRoleUser);

        Order CancelRefundOrder(IEnumerable<IOrderable> refundOrderItem, Order order, DomainObjectBase creatorOrganizationRoleUser, DomainObjectBase forOrganizationRoleUser);
    }
}