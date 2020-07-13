using System;
using Falcon.App.Core.Finance.Domain;
using Falcon.App.Infrastructure.Finance.Interfaces;
using Falcon.Data.EntityClasses;
using Falcon.Data.HelperClasses;
using SD.LLBLGen.Pro.ORMSupportClasses;

namespace Falcon.App.Infrastructure.Finance.Impl
{
    public class ProductOrderItemTraits : IOrderItemTraits
    {
        public IPredicate ItemIdPredicate(long productItemId)
        {
            return ProductOrderItemFields.ProductId == productItemId;
        }

        public IPredicate OrderItemIdPredicate(long orderItemId)
        {
            return ProductOrderItemFields.OrderItemId == orderItemId;
        }

        public IEntity2 CreateItemEntity(long orderItemId, long productItemId)
        {
            return new ProductOrderItemEntity(orderItemId, productItemId);
        }

        public OrderItem CreateOrderItem(long orderItemId, long itemId)
        {
            return new ProductItem(orderItemId) {ItemId = itemId};
        }

        public IEntityCollection2 CreateItemEntityCollection()
        {
            return new EntityCollection<ProductOrderItemEntity>();
        }

        public long GetItemId(IEntity2 itemEntity)
        {
            if (itemEntity == null)
            {
                throw new ArgumentNullException("itemEntity", "A non-null EventPackageOrderItemEntity is required.");
            }
            if (itemEntity.GetType() != typeof(ProductOrderItemEntity))
            {
                throw new ArgumentException(string.Format("Given entity must be a EventPackageOrderItemEntity ({0} given).", itemEntity.GetType()));
            }
            return ((ProductOrderItemEntity)itemEntity).ProductId;
        }

        public long GetOrderItemId(IEntity2 itemEntity)
        {
            if (itemEntity == null)
            {
                throw new ArgumentNullException("itemEntity", "A non-null EventPackageOrderItemEntity is required.");
            }
            if (itemEntity.GetType() != typeof(ProductOrderItemEntity))
            {
                throw new ArgumentException(string.Format("Given entity must be a EventPackageOrderItemEntity ({0} given).", itemEntity.GetType()));
            }
            return ((ProductOrderItemEntity) itemEntity).OrderItemId;
        }
    }
}