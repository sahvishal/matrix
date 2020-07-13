using System.Collections.Generic;
using Falcon.App.Core.Operations.Enum;
using Falcon.App.Core.Operations.ViewModels;

namespace Falcon.App.Core.Operations
{
    public interface IShippingDetailService
    {
        IEnumerable<EventCustomerShippingDetailViewData> GetEventCustomerShippingDetailViewData(int pageNumber, int pageSize, EventCustomerShippingDetailViewDataFilter filter);
        IEnumerable<ShippingDetailEditModel> GetShippingDetailEditModels(long eventId, long customerId);
        bool UpdateShippingStatus(long shippingDetailId, ShipmentStatus status, long modifiedByOrgRoleUserId);
        bool CheckShippingIsExclusivelyRequested(long eventId, long customerId);
        void SendPurchaseShippingNotification(long eventId, long customerId, long createdByOrgRoleUserId);
        IEnumerable<ShippingDetailViewModel> GetShippingDetailsForPopup(long orderDetailId);
    }
}
