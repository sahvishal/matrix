using System.Collections.Generic;
using System.Linq;
using Falcon.App.Core.Application.Attributes;
using Falcon.App.Core.Finance.Domain;
using Falcon.App.Core.Finance.Interfaces;
using Falcon.App.Infrastructure.Application.Impl;
using Falcon.App.Infrastructure.Mappers.Orders;
using Falcon.Data;
using Falcon.Data.EntityClasses;
using Falcon.Data.HelperClasses;
using SD.LLBLGen.Pro.ORMSupportClasses;

namespace Falcon.App.Infrastructure.Repositories.Order
{
    [DefaultImplementation]
    public class ShippingDetailOrderDetailRepository : Repository<ShippingDetailOrderDetail, ShippingDetailOrderDetailEntity>, IShippingDetailOrderDetailRepository
    {
        public ShippingDetailOrderDetailRepository()
            : base(new ShippingDetailOrderDetailMapper())
        { }

        public IEnumerable<ShippingDetailOrderDetail> GetForOrderDetailId(long orderDetailId)
        {
            IPredicateExpression predicateExpression = new PredicateExpression(ShippingDetailOrderDetailFields.IsActive == true);
            predicateExpression.AddWithAnd(ShippingDetailOrderDetailFields.OrderDetailId == orderDetailId);
            var prefetchPath = new PrefetchPath2(EntityType.ShippingDetailOrderDetailEntity) { ShippingDetailOrderDetailEntity.PrefetchPathShippingDetail };

            var entityCollection = new EntityCollection<ShippingDetailOrderDetailEntity>();
            IRelationPredicateBucket bucket = new RelationPredicateBucket(predicateExpression);
            using (var adapter = PersistenceLayer.GetDataAccessAdapter())
            {
                adapter.FetchEntityCollection(entityCollection, bucket, prefetchPath);
            }

            return Mapper.MapMultiple(entityCollection).ToList();
        }

        // Hack: This method id written because Save did not work for updation as we dont have field to identify the new or old entity.
        public bool UpdateStatus(long shippingDetailId, long orderDetailId, bool status)
        {
            var shippingDetailOrderDetail = new ShippingDetailOrderDetailEntity { IsActive = status };

            IRelationPredicateBucket bucket =
                new RelationPredicateBucket(ShippingDetailOrderDetailFields.OrderDetailId == orderDetailId);
            bucket.PredicateExpression.AddWithAnd(ShippingDetailOrderDetailFields.ShippingDetailId == shippingDetailId);
            
            using (var adapter = PersistenceLayer.GetDataAccessAdapter())
            {
                return adapter.UpdateEntitiesDirectly(shippingDetailOrderDetail, bucket) > 0;
            }
        }
    }
}
