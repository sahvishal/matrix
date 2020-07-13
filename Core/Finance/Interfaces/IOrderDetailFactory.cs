using Falcon.App.Core.Finance.Domain;
using Falcon.App.Core.Marketing.Domain;
using Falcon.App.Core.Operations.Domain;
using Falcon.App.Core.Scheduling.Domain;

namespace Falcon.App.Core.Finance.Interfaces
{
    public interface IOrderDetailFactory
    {
        OrderDetail CreateNewOrderDetail(IOrderable orderable, int quantity,
            long forOrganizationRoleUserId, long dataRecorderCreatorId, SourceCode sourceCode,
            EventCustomer eventCustomer, ShippingDetail shippingDetail, long? sourceId = null);

        OrderDetail CreateNewOrderDetail(OrderDetail existingOrderDetail, long forOrganizationRoleUserId,
                                         long dataRecorderCreatorId);

        OrderDetail CreateNewOrderDetailforCanellationItem(decimal cancellationFee, long orderId,
                                                           long forOrganizationRoleUserId,
                                                           long dataRecorderCreatorId);
    }
}