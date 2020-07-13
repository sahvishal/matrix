using System;
using Falcon.App.Core.Finance.Domain;
using Falcon.App.Infrastructure.Finance.Interfaces;
using Falcon.Data.EntityClasses;
using Falcon.Data.HelperClasses;
using SD.LLBLGen.Pro.ORMSupportClasses;

namespace Falcon.App.Infrastructure.Finance.Impl
{
    public class RefundOrderItemTraits : IOrderItemTraits
    {
        public IPredicate ItemIdPredicate(long refundItemId)
        {
            return RefundOrderItemFields.RefundId == refundItemId;
        }

        public IPredicate OrderItemIdPredicate(long orderItemId)
        {
            return RefundOrderItemFields.OrderItemId == orderItemId;
        }

        public IEntity2 CreateItemEntity(long orderItemId, long refundItemId)
        {
            return new RefundOrderItemEntity(orderItemId, refundItemId);
        }

        public OrderItem CreateOrderItem(long orderItemId, long itemId)
        {
            return new RefundItem(orderItemId) {ItemId = itemId};
        }

        public IEntityCollection2 CreateItemEntityCollection()
        {
            return new EntityCollection<RefundOrderItemEntity>();
        }

        public long GetItemId(IEntity2 itemEntity)
        {
            if (itemEntity == null)
            {
                throw new ArgumentNullException("itemEntity", "A non-null RefundOrderItemEntity is required.");
            }
            if (itemEntity.GetType() != typeof(RefundOrderItemEntity))
            {
                throw new ArgumentException(string.Format("Given entity must be a RefundOrderItemEntity ({0} given).", itemEntity.GetType()));
            }
            return ((RefundOrderItemEntity)itemEntity).RefundId;
        }

        public long GetOrderItemId(IEntity2 itemEntity)
        {
            if (itemEntity == null)
            {
                throw new ArgumentNullException("itemEntity", "A non-null RefundOrderItemEntity is required.");
            }
            if (itemEntity.GetType() != typeof(RefundOrderItemEntity))
            {
                throw new ArgumentException(string.Format("Given entity must be a RefundOrderItemEntity ({0} given).", itemEntity.GetType()));
            }
            return ((RefundOrderItemEntity)itemEntity).OrderItemId;
        }
    }
}