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
using System;
using System.Collections.Generic;
using System.Linq;

namespace Falcon.App.Infrastructure.Medical.Repositories
{
    [DefaultImplementation]
    public class ChaperoneAnswerRepository : PersistenceRepository, IChaperoneAnswerRepository
    {
        public int GetLatestVersion(long eventCustomerId)
        {
            using (var adapter = PersistenceLayer.GetDataAccessAdapter())
            {
                var linqMetaData = new LinqMetaData(adapter);
                var version = (from cla in linqMetaData.ChaperoneAnswer
                               where cla.EventCustomerId == eventCustomerId
                               select cla.Version).Max();

                return version;
            }
        }

        public void SaveAnswer(IEnumerable<ChaperoneAnswer> answers)
        {
            using (var adapter = PersistenceLayer.GetDataAccessAdapter())
            {
                if (!answers.IsNullOrEmpty())
                {
                    var eventCustomerId = answers.First().EventCustomerId;
                    var orgRoleUserId = answers.First().CreatedBy;
                    DeactivateAll(eventCustomerId, orgRoleUserId);
                }

                var entities = Mapper.Map<IEnumerable<ChaperoneAnswer>, IEnumerable<ChaperoneAnswerEntity>>(answers);
                var collection = new EntityCollection<ChaperoneAnswerEntity>();
                collection.AddRange(entities);
                adapter.SaveEntityCollection(collection);
            }
        }

        private void DeactivateAll(long eventCustomerId, long orgRoleUserId)
        {
            using (var adapter = PersistenceLayer.GetDataAccessAdapter())
            {
                var entity = new ChaperoneAnswerEntity
                {
                    IsActive = false,
                    ModifiedBy = orgRoleUserId,
                    DateModified = DateTime.Now
                };

                var bucket = new RelationPredicateBucket(ChaperoneAnswerFields.EventCustomerId == eventCustomerId);
                bucket.PredicateExpression.AddWithAnd(ChaperoneAnswerFields.IsActive == true);

                adapter.UpdateEntitiesDirectly(entity, bucket);
            }
        }

        public IEnumerable<ChaperoneAnswer> GetByEventCustomerId(long eventCustomerId)
        {
            using (var adapter = PersistenceLayer.GetDataAccessAdapter())
            {
                var linqMetaData = new LinqMetaData(adapter);
                var entities = linqMetaData.ChaperoneAnswer.Where(x => x.EventCustomerId == eventCustomerId && x.IsActive).ToArray();

                return Mapper.Map<IEnumerable<ChaperoneAnswerEntity>, IEnumerable<ChaperoneAnswer>>(entities);
            }
        }

        public IEnumerable<ChaperoneAnswer> GetAllAnswerByQuestionIds(IEnumerable<long> QuestionIds)
        {
            using (var adaper = PersistenceLayer.GetDataAccessAdapter())
            {
                var linqMetaData = new LinqMetaData(adaper);
                var entities = linqMetaData.ChaperoneAnswer.Where(x => QuestionIds.Contains(x.QuestionId) && x.IsActive == true).ToArray();
                return Mapper.Map<IEnumerable<ChaperoneAnswerEntity>, IEnumerable<ChaperoneAnswer>>(entities);
            }
        }

        public IEnumerable<ChaperoneAnswer> GetByEventCustomerIds(IEnumerable<long> eventCustomerIds)
        {
            using (var adapter = PersistenceLayer.GetDataAccessAdapter())
            {
                var linqMetaData = new LinqMetaData(adapter);
                var entities = linqMetaData.ChaperoneAnswer.Where(x => eventCustomerIds.Contains(x.EventCustomerId) && x.IsActive).ToArray();

                return Mapper.Map<IEnumerable<ChaperoneAnswerEntity>, IEnumerable<ChaperoneAnswer>>(entities);
            }
        }
    }
}
