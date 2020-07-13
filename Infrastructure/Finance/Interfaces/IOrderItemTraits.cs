using Falcon.App.Core.Finance.Domain;
using SD.LLBLGen.Pro.ORMSupportClasses;

namespace Falcon.App.Infrastructure.Finance.Interfaces
{
    public interface IOrderItemTraits
    {
        IPredicate ItemIdPredicate(long itemId);
        IPredicate OrderItemIdPredicate(long orderItemId);

        IEntity2 CreateItemEntity(long orderItemId, long itemId);

        OrderItem CreateOrderItem(long orderItemId, long itemId);
        IEntityCollection2 CreateItemEntityCollection();

        long GetItemId(IEntity2 itemEntity);
        long GetOrderItemId(IEntity2 itemEntity);
    }
}