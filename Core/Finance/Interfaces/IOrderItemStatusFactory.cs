using Falcon.App.Core.Enum;
using Falcon.App.Core.Finance.Enum;

namespace Falcon.App.Core.Finance.Interfaces
{
    public interface IOrderItemStatusFactory
    {
        OrderItemStatus CreateOrderItemStatus(OrderItemType orderItemType, int orderItemStatus);
        OrderItemType GetOrderItemType(OrderItemStatus orderItemStatus);
    }
}