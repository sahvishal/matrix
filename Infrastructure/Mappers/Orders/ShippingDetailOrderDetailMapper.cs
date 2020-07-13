using Falcon.App.Core.Finance.Domain;
using Falcon.Data.EntityClasses;

namespace Falcon.App.Infrastructure.Mappers.Orders
{
    public class ShippingDetailOrderDetailMapper : DomainEntityMapper<ShippingDetailOrderDetail,
        ShippingDetailOrderDetailEntity>
    {
        protected override void MapDomainFields(ShippingDetailOrderDetailEntity entity, ShippingDetailOrderDetail domainObjectToMapTo)
        {
            domainObjectToMapTo.ShippingDetailId = entity.ShippingDetailId;
            domainObjectToMapTo.OrderDetailId = entity.OrderDetailId;
            domainObjectToMapTo.IsActive = entity.IsActive;
            domainObjectToMapTo.Amount = entity.ShippingDetail != null ? entity.ShippingDetail.ActualPrice : 0m;
        }

        protected override void MapEntityFields(ShippingDetailOrderDetail domainObject, ShippingDetailOrderDetailEntity entityToMapTo)
        {
            entityToMapTo.ShippingDetailId = domainObject.ShippingDetailId;
            entityToMapTo.OrderDetailId = domainObject.OrderDetailId;
            entityToMapTo.IsActive = domainObject.IsActive;
        }
    }
}
