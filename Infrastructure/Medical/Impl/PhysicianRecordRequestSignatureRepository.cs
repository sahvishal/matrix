using System.Linq;
using AutoMapper;
using Falcon.App.Core.Application.Attributes;
using Falcon.App.Core.Application.Exceptions;
using Falcon.App.Core.Medical;
using Falcon.App.Core.Medical.Domain;
using Falcon.App.Infrastructure.Repositories;
using Falcon.Data.EntityClasses;
using Falcon.Data.HelperClasses;
using Falcon.Data.Linq;
using SD.LLBLGen.Pro.ORMSupportClasses;
using System.Collections.Generic;

namespace Falcon.App.Infrastructure.Medical.Impl
{
    [DefaultImplementation]
    public class PhysicianRecordRequestSignatureRepository : PersistenceRepository, IPhysicianRecordRequestSignatureRepository
    {
        public void Save(PhysicianRecordRequestSignature domain)
        {
            using (var adapter = PersistenceLayer.GetDataAccessAdapter())
            {
                var entity = Mapper.Map<PhysicianRecordRequestSignature, PhysicianRecordRequestSignatureEntity>(domain);

                DeactivateAll(domain.EventCustomerId);

                if (!adapter.SaveEntity(entity))
                {
                    throw new PersistenceFailureException("Unable to save physician record request signature.");
                }
            }
        }

        public int GetLatestVersion(long eventCustomerId)
        {
            using (var adapter = PersistenceLayer.GetDataAccessAdapter())
            {
                var linqMetaData = new LinqMetaData(adapter);

                var version = (from prrs in linqMetaData.PhysicianRecordRequestSignature
                               where prrs.EventCustomerId == eventCustomerId
                               select prrs.Version).Max();

                return version + 1;
            }
        }

        private void DeactivateAll(long eventCustomerId)
        {
            using (var adapter = PersistenceLayer.GetDataAccessAdapter())
            {
                var entity = new PhysicianRecordRequestSignatureEntity
                {
                    IsActive = false
                };

                var bucket = new RelationPredicateBucket(PhysicianRecordRequestSignatureFields.EventCustomerId == eventCustomerId);
                bucket.PredicateExpression.AddWithAnd(PhysicianRecordRequestSignatureFields.IsActive == true);

                adapter.UpdateEntitiesDirectly(entity, bucket);
            }
        }

        public PhysicianRecordRequestSignature GetByEventCustomerId(long eventCustomerId)
        {
            using (var adapter = PersistenceLayer.GetDataAccessAdapter())
            {
                var linqMetaData = new LinqMetaData(adapter);

                var entity = (from prrs in linqMetaData.PhysicianRecordRequestSignature
                              where prrs.EventCustomerId == eventCustomerId && prrs.IsActive
                              select prrs).SingleOrDefault();

                return entity == null ? null : Mapper.Map<PhysicianRecordRequestSignatureEntity, PhysicianRecordRequestSignature>(entity);
            }
        }

        public bool IsSaved(long eventCustomerId)
        {
            using (var adapter = PersistenceLayer.GetDataAccessAdapter())
            {
                var linqMetaData = new LinqMetaData(adapter);

                var entity = (from prrs in linqMetaData.PhysicianRecordRequestSignature
                              where prrs.EventCustomerId == eventCustomerId && prrs.IsActive
                              select prrs).SingleOrDefault();

                return entity != null;
            }
        }

        public IEnumerable<PhysicianRecordRequestSignature> GetByEventCustomerIds(IEnumerable<long> eventCustomerIds)
        {
            using (var adapter = PersistenceLayer.GetDataAccessAdapter())
            {
                var linqMetaData = new LinqMetaData(adapter);

                var entities = (from prrs in linqMetaData.PhysicianRecordRequestSignature
                                where eventCustomerIds.Contains(prrs.EventCustomerId) && prrs.IsActive
                                select prrs).ToList();

                return entities == null ? null : Mapper.Map<IEnumerable<PhysicianRecordRequestSignatureEntity>, IEnumerable<PhysicianRecordRequestSignature>>(entities);
            }
        }
    }
}
