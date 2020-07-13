using System;
using System.Collections.Generic;
using System.Linq;
using AutoMapper;
using Falcon.App.Core.Application.Attributes;
using Falcon.App.Core.Extensions;
using Falcon.App.Core.Medical;
using Falcon.App.Core.Medical.Domain;
using Falcon.App.Infrastructure.Repositories;
using Falcon.Data.EntityClasses;
using Falcon.Data.HelperClasses;
using Falcon.Data.Linq;
using SD.LLBLGen.Pro.ORMSupportClasses;

namespace Falcon.App.Infrastructure.Medical.Repositories
{
    [DefaultImplementation]
    public class FluConsentAnswerRepository : PersistenceRepository, IFluConsentAnswerRepository
    {
        public IEnumerable<FluConsentAnswer> GetAllAnswerByEventCustomerId(long eventCustomerId, int version = 1)
        {
            using (var adapter = PersistenceLayer.GetDataAccessAdapter())
            {
                var linqMetaData = new LinqMetaData(adapter);
                var entities = linqMetaData.FluConsentAnswer.Where(x => x.EventCustomerId == eventCustomerId && x.Version == version).ToArray();

                return Mapper.Map<IEnumerable<FluConsentAnswerEntity>, IEnumerable<FluConsentAnswer>>(entities);
            }
        }

        public int GetLatestVersion(long eventCustomerId)
        {
            using (var adapter = PersistenceLayer.GetDataAccessAdapter())
            {
                var linqMetaData = new LinqMetaData(adapter);
                var version = (from cla in linqMetaData.FluConsentAnswer
                               where cla.EventCustomerId == eventCustomerId
                               select cla.Version).Max();

                return version;
            }
        }

        public void SaveAnswer(IEnumerable<FluConsentAnswer> answers)
        {
            using (var adapter = PersistenceLayer.GetDataAccessAdapter())
            {
                if (!answers.IsNullOrEmpty())
                {
                    var eventCustomerId = answers.First().EventCustomerId;
                    var orgRoleUserId = answers.First().CreatedBy;
                    DeactivateAll(eventCustomerId, orgRoleUserId);
                }

                var entities = Mapper.Map<IEnumerable<FluConsentAnswer>, IEnumerable<FluConsentAnswerEntity>>(answers);
                var collection = new EntityCollection<FluConsentAnswerEntity>();
                collection.AddRange(entities);
                adapter.SaveEntityCollection(collection);
            }
        }

        private void DeactivateAll(long eventCustomerId, long orgRoleUserId)
        {
            using (var adapter = PersistenceLayer.GetDataAccessAdapter())
            {
                var entity = new FluConsentAnswerEntity
                {
                    IsActive = false,
                    ModifiedBy = orgRoleUserId,
                    DateModified = DateTime.Now
                };

                var bucket = new RelationPredicateBucket(FluConsentAnswerFields.EventCustomerId == eventCustomerId);
                bucket.PredicateExpression.AddWithAnd(FluConsentAnswerFields.IsActive == true);

                adapter.UpdateEntitiesDirectly(entity, bucket);
            }
        }

        public IEnumerable<FluConsentAnswer> GetByEventCustomerId(long eventCustomerId)
        {
            using (var adapter = PersistenceLayer.GetDataAccessAdapter())
            {
                var linqMetaData = new LinqMetaData(adapter);
                var entities = linqMetaData.FluConsentAnswer.Where(x => x.EventCustomerId == eventCustomerId && x.IsActive).ToArray();

                return Mapper.Map<IEnumerable<FluConsentAnswerEntity>, IEnumerable<FluConsentAnswer>>(entities);
            }
        }

    }
}
