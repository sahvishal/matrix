using System.Collections.Generic;
using Falcon.App.Core.Finance.Domain;
using Falcon.App.Core.Operations.Enum;

namespace Falcon.App.Core.Finance.Interfaces
{
    public interface IOrderDetailRepository
    {
        List<OrderDetail> GetOrderDetailsForOrder(long orderId);
        OrderDetail SaveOrderDetail(OrderDetail orderDetailToSave);
        List<OrderDetail> SaveOrderDetails(IEnumerable<OrderDetail> orderDetails);

        IEnumerable<OrderedPair<long, ShipmentStatus>> GetCdImageShippingStatusfortheEventCustomers(
            long[] eventCustomerIds);

        bool UpdateOrderDetail(long cancelledOrderId, long activeOrderId);
    }
}