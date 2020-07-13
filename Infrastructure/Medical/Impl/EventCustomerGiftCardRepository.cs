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

namespace Falcon.App.Infrastructure.Medical.Impl
{
    [DefaultImplementation]
    public class EventCustomerGiftCardRepository : PersistenceRepository, IEventCustomerGiftCardRepository
    {
        public void Save(EventCustomerGiftCard domain)
        {
            using (var adapter = PersistenceLayer.GetDataAccessAdapter())
            {
                var entity = Mapper.Map<EventCustomerGiftCard, EventCustomerGiftCardEntity>(domain);

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

                var version = (from ecgc in linqMetaData.EventCustomerGiftCard
                               where ecgc.EventCustomerId == eventCustomerId
                               select ecgc.Version).Max();

                return version + 1;
            }
        }

        private void DeactivateAll(long eventCustomerId)
        {
            using (var adapter = PersistenceLayer.GetDataAccessAdapter())
            {
                var entity = new EventCustomerGiftCardEntity
                {
                    IsActive = false
                };

                var bucket = new RelationPredicateBucket(EventCustomerGiftCardFields.EventCustomerId == eventCustomerId);
                bucket.PredicateExpression.AddWithAnd(EventCustomerGiftCardFields.IsActive == true);

                adapter.UpdateEntitiesDirectly(entity, bucket);
            }
        }

        public EventCustomerGiftCard GetByEventCustomerId(long eventCustomerId)
        {
            using (var adapter = PersistenceLayer.GetDataAccessAdapter())
            {
                var linqMetaData = new LinqMetaData(adapter);

                var entity = (from ecgc in linqMetaData.EventCustomerGiftCard
                              where ecgc.EventCustomerId == eventCustomerId && ecgc.IsActive
                              select ecgc).SingleOrDefault();

                return entity == null ? null : Mapper.Map<EventCustomerGiftCardEntity, EventCustomerGiftCard>(entity);
            }
        }

        public bool IsSaved(long eventCustomerId)
        {
            using (var adapter = PersistenceLayer.GetDataAccessAdapter())
            {
                var linqMetaData = new LinqMetaData(adapter);

                var entity = (from ecgc in linqMetaData.EventCustomerGiftCard
                              where ecgc.EventCustomerId == eventCustomerId && ecgc.IsActive
                              select ecgc).SingleOrDefault();

                return entity != null;
            }
        }
    }
}
