using System;
using Falcon.App.Core.Finance.Domain;
using Falcon.App.Infrastructure.Finance.Interfaces;
using Falcon.Data.EntityClasses;
using Falcon.Data.HelperClasses;
using SD.LLBLGen.Pro.ORMSupportClasses;

namespace Falcon.App.Infrastructure.Finance.Impl
{
    public class EventTestOrderItemTraits : IOrderItemTraits
    {
        public IPredicate ItemIdPredicate(long testItemId)
        {
            return EventTestOrderItemFields.EventTestId == testItemId;
        }

        public IPredicate OrderItemIdPredicate(long orderItemId)
        {
            return EventTestOrderItemFields.OrderItemId == orderItemId;
        }

        public IEntity2 CreateItemEntity(long orderItemId, long testItemId)
        {
            return new EventTestOrderItemEntity(orderItemId, testItemId);
        }

        public OrderItem CreateOrderItem(long orderItemId, long itemId)
        {
            return new EventTestItem(orderItemId) {ItemId = itemId};
        }

        public IEntityCollection2 CreateItemEntityCollection()
        {
            return new EntityCollection<EventTestOrderItemEntity>();
        }

        public long GetItemId(IEntity2 itemEntity)
        {
            if (itemEntity == null)
            {
                throw new ArgumentNullException("itemEntity", "A non-null EventTestOrderItemEntity is required.");
            }
            if (itemEntity.GetType() != typeof(EventTestOrderItemEntity))
            {
                throw new ArgumentException(string.Format("Given entity must be a EventTestOrderItemEntity ({0} given).", itemEntity.GetType()));
            }
            return ((EventTestOrderItemEntity)itemEntity).EventTestId;
        }

        public long GetOrderItemId(IEntity2 itemEntity)
        {
            if (itemEntity == null)
            {
                throw new ArgumentNullException("itemEntity", "A non-null EventTestOrderItemEntity is required.");
            }
            if (itemEntity.GetType() != typeof(EventTestOrderItemEntity))
            {
                throw new ArgumentException(string.Format("Given entity must be a EventTestOrderItemEntity ({0} given).", itemEntity.GetType()));
            }
            return ((EventTestOrderItemEntity)itemEntity).OrderItemId;
        }
    }
}