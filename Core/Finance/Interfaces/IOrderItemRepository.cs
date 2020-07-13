using System.Collections.Generic;
using Falcon.App.Core.Enum;
using Falcon.App.Core.Finance.Domain;

namespace Falcon.App.Core.Finance.Interfaces
{
    public interface IOrderItemRepository
    {
        IEnumerable<OrderItem> GetOrderItems(long[] orderItemId);
        OrderItem GetOrderItem(long orderItemId);
        OrderItem SaveOrderItem(long itemId, OrderItemType orderItemType);
        long SaveCancellationFeeOrderItem(); // Need to refactor this.
    }
}