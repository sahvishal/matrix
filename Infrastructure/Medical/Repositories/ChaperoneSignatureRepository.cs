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
using System.Linq;

namespace Falcon.App.Infrastructure.Medical.Repositories
{
    [DefaultImplementation]
    public class ChaperoneSignatureRepository : PersistenceRepository, IChaperoneSignatureRepository
    {
        public void Save(ChaperoneSignature domain)
        {
            using (var adapter = PersistenceLayer.GetDataAccessAdapter())
            {
                var entity = Mapper.Map<ChaperoneSignature, ChaperoneSignatureEntity>(domain);

                DeactivateAll(domain.EventCustomerId);

                if (!adapter.SaveEntity(entity))
                {
                    throw new PersistenceFailureException("Unable to save Chaperone Signature.");
                }
            }
        }

        public int GetLatestVersion(long eventCustomerId)
        {
            using (var adapter = PersistenceLayer.GetDataAccessAdapter())
            {
                var linqMetaData = new LinqMetaData(adapter);

                var version = (from fcs in linqMetaData.ChaperoneSignature
                               where fcs.EventCustomerId == eventCustomerId
                               select fcs.Version).Max();

                return version + 1;
            }
        }

        private void DeactivateAll(long eventCustomerId)
        {
            using (var adapter = PersistenceLayer.GetDataAccessAdapter())
            {
                var entity = new ChaperoneSignatureEntity
                {
                    IsActive = false
                };

                var bucket = new RelationPredicateBucket(ChaperoneSignatureFields.EventCustomerId == eventCustomerId);
                bucket.PredicateExpression.AddWithAnd(ChaperoneSignatureFields.IsActive == true);

                adapter.UpdateEntitiesDirectly(entity, bucket);
            }
        }

        public ChaperoneSignature GetByEventCustomerId(long eventCustomerId)
        {
            using (var adapter = PersistenceLayer.GetDataAccessAdapter())
            {
                var linqMetaData = new LinqMetaData(adapter);

                var entity = (from fcs in linqMetaData.ChaperoneSignature
                              where fcs.EventCustomerId == eventCustomerId && fcs.IsActive
                              select fcs).SingleOrDefault();

                return entity == null ? null : Mapper.Map<ChaperoneSignatureEntity, ChaperoneSignature>(entity);
            }
        }

        public IEnumerable<ChaperoneSignature> GetByEventCustomerIds(IEnumerable<long> eventCustomerId)
        {
            using (var adapter = PersistenceLayer.GetDataAccessAdapter())
            {
                var linqMetaData = new LinqMetaData(adapter);

                var entity = linqMetaData.ChaperoneSignature.Where(x => eventCustomerId.Contains(x.EventCustomerId) && x.IsActive).ToArray();

                return Mapper.Map<IEnumerable<ChaperoneSignatureEntity>, IEnumerable<ChaperoneSignature>>(entity);
                
            }
        }
    }
}
