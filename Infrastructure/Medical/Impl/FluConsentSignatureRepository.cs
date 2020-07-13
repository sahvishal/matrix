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
    public class FluConsentSignatureRepository : PersistenceRepository, IFluConsentSignatureRepository
    {
        public void Save(FluConsentSignature domain)
        {
            using (var adapter = PersistenceLayer.GetDataAccessAdapter())
            {
                var entity = Mapper.Map<FluConsentSignature, FluConsentSignatureEntity>(domain);

                DeactivateAll(domain.EventCustomerId);

                if (!adapter.SaveEntity(entity))
                {
                    throw new PersistenceFailureException("Unable to save gift card answer and signature.");
                }
            }
        }

        public int GetLatestVersion(long eventCustomerId)
        {
            using (var adapter = PersistenceLayer.GetDataAccessAdapter())
            {
                var linqMetaData = new LinqMetaData(adapter);

                var version = (from fcs in linqMetaData.FluConsentSignature
                               where fcs.EventCustomerId == eventCustomerId
                               select fcs.Version).Max();

                return version + 1;
            }
        }

        private void DeactivateAll(long eventCustomerId)
        {
            using (var adapter = PersistenceLayer.GetDataAccessAdapter())
            {
                var entity = new FluConsentSignatureEntity
                {
                    IsActive = false
                };

                var bucket = new RelationPredicateBucket(FluConsentSignatureFields.EventCustomerId == eventCustomerId);
                bucket.PredicateExpression.AddWithAnd(FluConsentSignatureFields.IsActive == true);

                adapter.UpdateEntitiesDirectly(entity, bucket);
            }
        }

        public FluConsentSignature GetByEventCustomerId(long eventCustomerId)
        {
            using (var adapter = PersistenceLayer.GetDataAccessAdapter())
            {
                var linqMetaData = new LinqMetaData(adapter);

                var entity = (from fcs in linqMetaData.FluConsentSignature
                              where fcs.EventCustomerId == eventCustomerId && fcs.IsActive
                              select fcs).SingleOrDefault();

                return entity == null ? null : Mapper.Map<FluConsentSignatureEntity, FluConsentSignature>(entity);
            }
        }

        public bool IsSaved(long eventCustomerId)
        {
            using (var adapter = PersistenceLayer.GetDataAccessAdapter())
            {
                var linqMetaData = new LinqMetaData(adapter);

                var entity = (from fcs in linqMetaData.FluConsentSignature
                              where fcs.EventCustomerId == eventCustomerId && fcs.IsActive
                              select fcs).SingleOrDefault();

                return entity != null;
            }
        }

        public IEnumerable<FluConsentSignature> GetByEventCustomerIds(IEnumerable<long> eventCustomerIds)
        {
            using (var adapter = PersistenceLayer.GetDataAccessAdapter())
            {
                var linqMetaData = new LinqMetaData(adapter);

                var entities = (from fcs in linqMetaData.FluConsentSignature
                                where eventCustomerIds.Contains(fcs.EventCustomerId) && fcs.IsActive
                                select fcs).ToList();

                return entities == null ? null : Mapper.Map<IEnumerable<FluConsentSignatureEntity>, IEnumerable<FluConsentSignature>>(entities);
            }
        }
    }
}
