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
    public class ParticipationConsentSignatureRepository : PersistenceRepository, IParticipationConsentSignatureRepository
    {
        public void Save(ParticipationConsentSignature domain)
        {
            using (var adapter = PersistenceLayer.GetDataAccessAdapter())
            {
                var entity = Mapper.Map<ParticipationConsentSignature, ParticipationConsentSignatureEntity>(domain);

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

                var version = (from pcs in linqMetaData.ParticipationConsentSignature
                               where pcs.EventCustomerId == eventCustomerId
                               select pcs.Version).Max();

                return version + 1;
            }
        }

        private void DeactivateAll(long eventCustomerId)
        {
            using (var adapter = PersistenceLayer.GetDataAccessAdapter())
            {
                var entity = new ParticipationConsentSignatureEntity
                {
                    IsActive = false
                };

                var bucket = new RelationPredicateBucket(ParticipationConsentSignatureFields.EventCustomerId == eventCustomerId);
                bucket.PredicateExpression.AddWithAnd(ParticipationConsentSignatureFields.IsActive == true);

                adapter.UpdateEntitiesDirectly(entity, bucket);
            }
        }

        public ParticipationConsentSignature GetByEventCustomerId(long eventCustomerId)
        {
            using (var adapter = PersistenceLayer.GetDataAccessAdapter())
            {
                var linqMetaData = new LinqMetaData(adapter);

                var entity = (from pcs in linqMetaData.ParticipationConsentSignature
                              where pcs.EventCustomerId == eventCustomerId && pcs.IsActive
                              select pcs).SingleOrDefault();

                return entity == null ? null : Mapper.Map<ParticipationConsentSignatureEntity, ParticipationConsentSignature>(entity);
            }
        }

        public bool IsSaved(long eventCustomerId)
        {
            using (var adapter = PersistenceLayer.GetDataAccessAdapter())
            {
                var linqMetaData = new LinqMetaData(adapter);

                var entity = (from pcs in linqMetaData.ParticipationConsentSignature
                              where pcs.EventCustomerId == eventCustomerId && pcs.IsActive
                              select pcs).SingleOrDefault();

                return entity != null;
            }
        }

        public IEnumerable<ParticipationConsentSignature> GetByEventCustomerIds(IEnumerable<long> eventCustomerIds)
        {
            using (var adapter = PersistenceLayer.GetDataAccessAdapter())
            {
                var linqMetaData = new LinqMetaData(adapter);

                var entities = (from pcs in linqMetaData.ParticipationConsentSignature
                                where eventCustomerIds.Contains(pcs.EventCustomerId) && pcs.IsActive
                                select pcs).ToList();

                return entities == null ? null : Mapper.Map<IEnumerable<ParticipationConsentSignatureEntity>, IEnumerable<ParticipationConsentSignature>>(entities);
            }
        }
    }
}
