using Falcon.App.Core.Finance.Domain;
using Falcon.Data.EntityClasses;

namespace Falcon.App.Infrastructure.Mappers.Orders
{
    public class EventCustomerOrderDetailMapper : DomainEntityMapper<EventCustomerOrderDetail,
        EventCustomerOrderDetailEntity>
    {
        protected override void MapDomainFields(EventCustomerOrderDetailEntity entity, EventCustomerOrderDetail domainObjectToMapTo)
        {
            domainObjectToMapTo.EventCustomerId = entity.EventCustomerId;
            domainObjectToMapTo.OrderDetailId = entity.OrderDetailId;
            domainObjectToMapTo.IsActive = entity.IsActive;
        }

        protected override void MapEntityFields(EventCustomerOrderDetail domainObject, EventCustomerOrderDetailEntity entityToMapTo)
        {
            entityToMapTo.EventCustomerId = domainObject.EventCustomerId;
            entityToMapTo.OrderDetailId = domainObject.OrderDetailId;
            entityToMapTo.IsActive = domainObject.IsActive;
        }
    }
}
