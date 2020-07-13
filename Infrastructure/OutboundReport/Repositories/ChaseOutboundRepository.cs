using System;
using System.Collections.Generic;
using System.Linq;
using AutoMapper;
using Falcon.App.Core.Application.Attributes;
using Falcon.App.Core.Application.Exceptions;
using Falcon.App.Core.OutboundReport;
using Falcon.App.Core.OutboundReport.Domain;
using Falcon.App.Infrastructure.Repositories;
using Falcon.Data.EntityClasses;
using Falcon.Data.HelperClasses;
using Falcon.Data.Linq;
using SD.LLBLGen.Pro.ORMSupportClasses;

namespace Falcon.App.Infrastructure.OutboundReport.Repositories
{
    [DefaultImplementation]
    public class ChaseOutboundRepository : PersistenceRepository, IChaseOutboundRepository
    {
        public ChaseOutbound GetByCustomerId(long customerId)
        {
            using (var adapter = PersistenceLayer.GetDataAccessAdapter())
            {
                var linqMetaData = new LinqMetaData(adapter);
                var entity = (from co in linqMetaData.ChaseOutbound where co.CustomerId == customerId select co).SingleOrDefault();

                return entity == null ? null : Mapper.Map<ChaseOutboundEntity, ChaseOutbound>(entity);
            }
        }

        public IEnumerable<ChaseOutbound> GetByCustomerIds(IEnumerable<long> customerIds)
        {
            using (var adapter = PersistenceLayer.GetDataAccessAdapter())
            {
                var linqMetaData = new LinqMetaData(adapter);
                var entities = (from co in linqMetaData.ChaseOutbound where customerIds.Contains(co.CustomerId) && co.IsActive select co).ToArray();

                return Mapper.Map<IEnumerable<ChaseOutboundEntity>, IEnumerable<ChaseOutbound>>(entities);
            }
        }

        public void DeactivateChaseOutboundByCustomerId(long customerId)
        {
            using (var adapter = PersistenceLayer.GetDataAccessAdapter())
            {

                var entity = new ChaseOutboundEntity()
                {
                    IsActive = false,
                    EndDate = DateTime.Now
                };

                var bucket = new RelationPredicateBucket(ChaseOutboundFields.CustomerId == customerId);
                bucket.PredicateExpression.AddWithAnd(ChaseOutboundFields.IsActive == true);

                adapter.UpdateEntitiesDirectly(entity, bucket);
            }
        }

        public ChaseOutbound Save(ChaseOutbound domain)
        {
            DeactivateChaseOutboundByCustomerId(domain.CustomerId);

            using (var adapter = PersistenceLayer.GetDataAccessAdapter())
            {
                var entity = Mapper.Map<ChaseOutbound, ChaseOutboundEntity>(domain);

                if (!adapter.SaveEntity(entity, true))
                {
                    throw new PersistenceFailureException();
                }

                return Mapper.Map<ChaseOutboundEntity, ChaseOutbound>(entity);
            }
        }

        public ChaseOutbound GetByIndividualIdNumber(string individulaIdNumber, string consumerId)
        {
            using (var adapter = PersistenceLayer.GetDataAccessAdapter())
            {
                var linqMetaData = new LinqMetaData(adapter);
                var entity = (from co in linqMetaData.ChaseOutbound where co.IndividualId == individulaIdNumber && co.ConsumerId == consumerId select co).SingleOrDefault();

                return entity == null ? null : Mapper.Map<ChaseOutboundEntity, ChaseOutbound>(entity);
            }
        }

        public ChaseOutbound GetByClientIdAndContractNumber(string clientId, string contractNumber)
        {
            using (var adapter = PersistenceLayer.GetDataAccessAdapter())
            {
                var linqMetaData = new LinqMetaData(adapter);
                var entity = (from co in linqMetaData.ChaseOutbound where co.ClientId == clientId && co.ContractNumber == contractNumber select co).FirstOrDefault();

                return entity == null ? null : Mapper.Map<ChaseOutboundEntity, ChaseOutbound>(entity);
            }
        }

        public ChaseOutbound GetByClientId(string clientId)
        {
            using (var adapter = PersistenceLayer.GetDataAccessAdapter())
            {
                var linqMetaData = new LinqMetaData(adapter);
                var entity = (from co in linqMetaData.ChaseOutbound where co.ClientId == clientId && co.IsActive select co).FirstOrDefault();

                return entity == null ? null : Mapper.Map<ChaseOutboundEntity, ChaseOutbound>(entity);
            }
        }

        public IEnumerable<ChaseOutbound> GetAllByCustomerIds(IEnumerable<long> customerIds)
        {
            using (var adapter = PersistenceLayer.GetDataAccessAdapter())
            {
                var linqMetaData = new LinqMetaData(adapter);
                var entities = (from co in linqMetaData.ChaseOutbound where customerIds.Contains(co.CustomerId) select co).ToArray();

                return Mapper.Map<IEnumerable<ChaseOutboundEntity>, IEnumerable<ChaseOutbound>>(entities);
            }
        }
    }
}
