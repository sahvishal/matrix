using System;
using Falcon.App.Core.Finance.Domain;
using Falcon.App.Infrastructure.Finance.Interfaces;
using Falcon.Data.EntityClasses;
using Falcon.Data.HelperClasses;
using SD.LLBLGen.Pro.ORMSupportClasses;

namespace Falcon.App.Infrastructure.Finance.Impl
{
    public class GiftCertificateOrderItemTraits : IOrderItemTraits
    {
        public IPredicate ItemIdPredicate(long giftCertificateOrderItemId)
        {
            return GiftCertificateOrderItemFields.GiftCertificateId == giftCertificateOrderItemId;
        }

        public IPredicate OrderItemIdPredicate(long orderItemId)
        {
            return GiftCertificateOrderItemFields.OrderItemId == orderItemId;
        }

        public IEntity2 CreateItemEntity(long orderItemId, long giftCertificateItemId)
        {
            return new GiftCertificateOrderItemEntity(orderItemId, giftCertificateItemId);
        }

        public OrderItem CreateOrderItem(long orderItemId, long itemId)
        {
            return new GiftCertificateItem(orderItemId) { ItemId = itemId };
        }

        public IEntityCollection2 CreateItemEntityCollection()
        {
            return new EntityCollection<GiftCertificateOrderItemEntity>();
        }

        public long GetItemId(IEntity2 itemEntity)
        {
            if (itemEntity == null)
            {
                throw new ArgumentNullException("itemEntity", "A non-null GiftCertificateOrderItemEntity is required.");
            }
            if (itemEntity.GetType() != typeof(GiftCertificateOrderItemEntity))
            {
                throw new ArgumentException(string.Format("Given entity must be a GiftCertificateOrderItemEntity ({0} given).", itemEntity.GetType()));
            }
            return ((GiftCertificateOrderItemEntity)itemEntity).GiftCertificateId;
        }

        public long GetOrderItemId(IEntity2 itemEntity)
        {
            VerifyEntity(itemEntity);
            return ((GiftCertificateOrderItemEntity)itemEntity).OrderItemId;
        }

        private void VerifyEntity(IEntity2 itemEntity)
        {
            if (itemEntity == null)
            {
                throw new ArgumentNullException("itemEntity", "A non-null GiftCertificateOrderItemEntity is required.");
            }
            if (itemEntity.GetType() != typeof(GiftCertificateOrderItemEntity))
            {
                throw new ArgumentException(string.Format("Given entity must be a GiftCertificateOrderItemEntity ({0} given).", itemEntity.GetType()));
            }
        }
    }
}