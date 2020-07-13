using System;
using Falcon.App.Core.Finance.Domain;
using Falcon.App.Infrastructure.Finance.Interfaces;
using SD.LLBLGen.Pro.ORMSupportClasses;

namespace Falcon.App.Infrastructure.Finance.Impl
{
    public class CancellationFeeOrderItemTraits : IOrderItemTraits
    {
        public IPredicate ItemIdPredicate(long itemId)
        {
            throw new NotImplementedException();
        }

        public IPredicate OrderItemIdPredicate(long orderItemId)
        {
            throw new NotImplementedException();
        }

        public IEntity2 CreateItemEntity(long orderItemId, long itemId)
        {
            throw new NotImplementedException();
        }

        public OrderItem CreateOrderItem(long orderItemId, long itemId)
        {
            return new CancellationFeeItem(orderItemId) { ItemId = itemId }; 
        }

        public IEntityCollection2 CreateItemEntityCollection()
        {
            throw new NotImplementedException();
        }

        public long GetItemId(IEntity2 itemEntity)
        {
            throw new NotImplementedException();
        }

        public long GetOrderItemId(IEntity2 itemEntity)
        {
            throw new NotImplementedException();
        }
    }
}
