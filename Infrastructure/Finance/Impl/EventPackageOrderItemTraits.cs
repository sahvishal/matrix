using System;
using Falcon.App.Core.Finance.Domain;
using Falcon.App.Infrastructure.Finance.Interfaces;
using Falcon.Data.EntityClasses;
using Falcon.Data.HelperClasses;
using SD.LLBLGen.Pro.ORMSupportClasses;

namespace Falcon.App.Infrastructure.Finance.Impl
{
    public class EventPackageOrderItemTraits : IOrderItemTraits
    {
        public IPredicate ItemIdPredicate(long packageItemId)
        {
            return EventPackageOrderItemFields.EventPackageId == packageItemId;
        }

        public IPredicate OrderItemIdPredicate(long orderItemId)
        {
            return EventPackageOrderItemFields.OrderItemId == orderItemId;
        }

        public IEntity2 CreateItemEntity(long orderItemId, long eventPackageId)
        {
            return new EventPackageOrderItemEntity(orderItemId, eventPackageId);
        }

        public OrderItem CreateOrderItem(long orderItemId, long itemId)
        {
            return new EventPackageItem(orderItemId) {ItemId = itemId};
        }

        public IEntityCollection2 CreateItemEntityCollection()
        {
            return new EntityCollection<EventPackageOrderItemEntity>();
        }

        public long GetItemId(IEntity2 itemEntity)
        {
            VerifyEntity(itemEntity);
            return ((EventPackageOrderItemEntity)itemEntity).EventPackageId;
        }

        public long GetOrderItemId(IEntity2 itemEntity)
        {
            VerifyEntity(itemEntity);
            return ((EventPackageOrderItemEntity)itemEntity).OrderItemId;
        }

        private void VerifyEntity(IEntity2 itemEntity)
        {
            if (itemEntity == null)
            {
                throw new ArgumentNullException("itemEntity", "A non-null EventPackageOrderItemEntity is required.");
            }
            if (itemEntity.GetType() != typeof(EventPackageOrderItemEntity))
            {
                throw new ArgumentException(string.Format("Given entity must be a EventPackageOrderItemEntity ({0} given).", itemEntity.GetType()));
            }
        }
    }
}