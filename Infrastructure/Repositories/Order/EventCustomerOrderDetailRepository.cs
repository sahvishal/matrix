using System.Collections.Generic;
using Falcon.App.Core.Application.Attributes;
using Falcon.App.Core.Finance.Domain;
using Falcon.App.Core.Finance.Interfaces;
using Falcon.App.Infrastructure.Application.Impl;
using Falcon.App.Infrastructure.Mappers.Orders;
using Falcon.Data.EntityClasses;
using Falcon.Data.HelperClasses;
using SD.LLBLGen.Pro.ORMSupportClasses;

namespace Falcon.App.Infrastructure.Repositories.Order
{
    [DefaultImplementation]
    public class EventCustomerOrderDetailRepository : Repository<EventCustomerOrderDetail, EventCustomerOrderDetailEntity>, IEventCustomerOrderDetailRepository
    {
        public EventCustomerOrderDetailRepository()
            : base(new EventCustomerOrderDetailMapper())
        { }

        public IEnumerable<EventCustomerOrderDetail> GetForOrderDetailId(long orderDetailId)
        {
            return GetByPredicate(new PredicateExpression(EventCustomerOrderDetailFields.OrderDetailId == orderDetailId));
        }

        // Hack: This method id written because Save did not work for updation as we dont have field to identify the new or old entity.
        public bool UpdateStatus(long eventCustomerId, long orderDetailId, bool status)
        {
            var eventCustomerOrderDetail = new EventCustomerOrderDetailEntity {IsActive = status};

            IRelationPredicateBucket bucket =
                new RelationPredicateBucket(EventCustomerOrderDetailFields.EventCustomerId == eventCustomerId);
            bucket.PredicateExpression.AddWithAnd(EventCustomerOrderDetailFields.OrderDetailId == orderDetailId);

            using (var adapter = PersistenceLayer.GetDataAccessAdapter())
            {
                return adapter.UpdateEntitiesDirectly(eventCustomerOrderDetail, bucket) > 0;
            }
        }
    }
}
