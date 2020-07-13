using System.Collections.Generic;
using System.Linq;
using Falcon.App.Core.Finance.Domain;
using Falcon.App.Core.Finance.Interfaces;
using Falcon.App.Infrastructure.Application.Impl;
using Falcon.App.Infrastructure.Mappers.Orders;
using Falcon.Data.EntityClasses;
using Falcon.Data.HelperClasses;
using Falcon.Data.Linq;
using SD.LLBLGen.Pro.ORMSupportClasses;
using Falcon.App.Core.Application.Attributes;

namespace Falcon.App.Infrastructure.Repositories.Order
{
    [DefaultImplementation]
    public class SourceCodeOrderDetailRepository : Repository<SourceCodeOrderDetail, SourceCodeOrderDetailEntity>, ISourceCodeOrderDetailRepository
    {
        public SourceCodeOrderDetailRepository()
            : base(new SourceCodeOrderDetailMapper())
        { }

        public IEnumerable<SourceCodeOrderDetail> GetForOrderDetailId(long orderDetailId)
        {
            return GetByPredicate(new PredicateExpression(SourceCodeOrderDetailFields.OrderDetailId == orderDetailId));
        }

        public SourceCodeOrderDetail GetForSourceCodeIdAndOrderDetailId(long sourceCodeId, long orderDetailId)
        {
            IPredicateExpression predicateExpression =
                new PredicateExpression(SourceCodeOrderDetailFields.OrderDetailId == orderDetailId);
            predicateExpression.AddWithAnd(SourceCodeOrderDetailFields.SourceCodeId == sourceCodeId);
            return GetByPredicate(predicateExpression).SingleOrDefault();
        }

        // Hack: This method id written because Save did not work for updation as we dont have field to identify the new or old entity.
        public bool UpdateStatus(long sourceCodeId, long orderDetailId, bool status)
        {
            var sourceCodeOrderDetailEntity = new SourceCodeOrderDetailEntity { IsActive = status };

            IRelationPredicateBucket bucket =
                new RelationPredicateBucket(SourceCodeOrderDetailFields.OrderDetailId == orderDetailId);
            bucket.PredicateExpression.AddWithAnd(SourceCodeOrderDetailFields.SourceCodeId == sourceCodeId);
            using (var adapter = PersistenceLayer.GetDataAccessAdapter())
            {
                return adapter.UpdateEntitiesDirectly(sourceCodeOrderDetailEntity, bucket) > 0;
            }
        }

        public bool UpdateAmount(long sourceCodeId, long orderDetailId, decimal amount, long organizationRoleUserCreatorId)
        {
            var sourceCodeOrderDetailEntity = new SourceCodeOrderDetailEntity
                                                  {
                                                      Amount = amount,
                                                      OrganizationRoleUserCreatorId = organizationRoleUserCreatorId
                                                  };

            IRelationPredicateBucket bucket =
                new RelationPredicateBucket(SourceCodeOrderDetailFields.OrderDetailId == orderDetailId);
            bucket.PredicateExpression.AddWithAnd(SourceCodeOrderDetailFields.SourceCodeId == sourceCodeId);
            using (var adapter = PersistenceLayer.GetDataAccessAdapter())
            {
                return adapter.UpdateEntitiesDirectly(sourceCodeOrderDetailEntity, bucket) > 0;
            }
        }

        public int GetSourceCodeUsageCount(long sourceCodeId)
        {
            using (var adapter = PersistenceLayer.GetDataAccessAdapter())
            {
                var linqMetaData = new LinqMetaData(adapter);
                return
                    linqMetaData.SourceCodeOrderDetail.Where(scod => scod.IsActive && scod.SourceCodeId == sourceCodeId)
                        .Count();
            }
        }

        public bool IsSourceCodeAppliedforGivenEventCustomer(long sourceCodeId, long eventId, long customerId)
        {
            using (var adapter = PersistenceLayer.GetDataAccessAdapter())
            {
                var linqMetaData = new LinqMetaData(adapter);
                var eventCustomerId = (from ec in linqMetaData.EventCustomers
                                       join ecod in linqMetaData.EventCustomerOrderDetail on ec.EventCustomerId equals
                                           ecod.EventCustomerId
                                       join od in linqMetaData.SourceCodeOrderDetail on ecod.OrderDetailId equals od.OrderDetailId
                                       where
                                           ec.EventId == eventId && ec.CustomerId == customerId && ecod.IsActive &&
                                           od.IsActive && od.SourceCodeId == sourceCodeId
                                       select ec.EventCustomerId).SingleOrDefault();

                return eventCustomerId > 0;
            }
        }

        public IEnumerable<SourceCodeOrderDetail> GetForOrder(long orderId)
        {
            using (var adapter = PersistenceLayer.GetDataAccessAdapter())
            {
                var linqMetaData = new LinqMetaData(adapter);
                var entities = (from od in linqMetaData.OrderDetail
                                join sdod in linqMetaData.SourceCodeOrderDetail on od.OrderDetailId equals sdod.OrderDetailId
                                where od.OrderId == orderId
                                select sdod);
                return Mapper.MapMultiple(entities);
            }
        }

    }
}