using AutoMapper;
using Falcon.App.Core.Application.Attributes;
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
    public class EventCustomerQuestionAnswerRepository : PersistenceRepository, IEventCustomerQuestionAnswerRepository
    {
        public IEnumerable<EventCustomerQuestionAnswer> GetAllByEventCustomerId(long customerId, long eventId, int version = 1)
        {
            using (var adapter = PersistenceLayer.GetDataAccessAdapter())
            {
                var linqMetaData = new LinqMetaData(adapter);
                var entities = linqMetaData.EventCustomerQuestionAnswer.Where(x => x.CustomerId == customerId && x.EventId == eventId && x.Version == version && x.IsActive).ToArray();

                return Mapper.Map<IEnumerable<EventCustomerQuestionAnswerEntity>, IEnumerable<EventCustomerQuestionAnswer>>(entities);
            }
        }

        public long GetLatestVersion(long customerId, long eventId)
        {
            using (var adapter = PersistenceLayer.GetDataAccessAdapter())
            {
                var linqMetaData = new LinqMetaData(adapter);
                var version = (from ecqa in linqMetaData.EventCustomerQuestionAnswer
                               where ecqa.CustomerId == customerId //&& ecqa.EventId == eventId
                               orderby ecqa.Version descending
                               select ecqa.Version).FirstOrDefault();

                return version;
            }
        }

        public void SaveAnswer(IEnumerable<EventCustomerQuestionAnswer> answers)
        {
            using (var adapter = PersistenceLayer.GetDataAccessAdapter())
            {
                var entities = Mapper.Map<IEnumerable<EventCustomerQuestionAnswer>, IEnumerable<EventCustomerQuestionAnswerEntity>>(answers);
                var collection = new EntityCollection<EventCustomerQuestionAnswerEntity>();
                collection.AddRange(entities);
                adapter.SaveEntityCollection(collection);
            }
        }

        public bool DeleteEventCustomerQuestionAnswers(long customerId, long eventId, long orgUserId)
        {
            var eventCustomerQuestionAnswerEntity = new EventCustomerQuestionAnswerEntity() { IsActive = false, UpdatedBy = orgUserId, UpdatedDate = DateTime.Now };
            using (var adapter = PersistenceLayer.GetDataAccessAdapter())
            {
                var bucket = new RelationPredicateBucket(EventCustomerQuestionAnswerFields.CustomerId == customerId);
                bucket.PredicateExpression.AddWithAnd(EventCustomerQuestionAnswerFields.EventId == eventId);
                return (adapter.UpdateEntitiesDirectly(eventCustomerQuestionAnswerEntity, bucket) > 0) ? true : false;
            }
        }

        public IEnumerable<EventCustomerQuestionAnswer> GetEventCustomerQuestionAnswer(long customerId)
        {
            using (var adapter = PersistenceLayer.GetDataAccessAdapter())
            {
                var linqMetaData = new LinqMetaData(adapter);

                var maxVersion = linqMetaData.EventCustomerQuestionAnswer.Where(x => x.CustomerId == customerId && x.IsActive == true).Max(x => x.Version);

                var entities = (from q in linqMetaData.EventCustomerQuestionAnswer
                                where q.CustomerId == customerId && q.Version == maxVersion
                                && q.IsActive
                                select q).ToArray();
                return Mapper.Map<IEnumerable<EventCustomerQuestionAnswerEntity>, IEnumerable<EventCustomerQuestionAnswer>>(entities);
            }
        }

        public IEnumerable<EventCustomerQuestionAnswer> GetAllByCustomerIdEventId(long customerId, long eventId)
        {
            using (var adapter = PersistenceLayer.GetDataAccessAdapter())
            {
                var linqMetaData = new LinqMetaData(adapter);
                var entities = (from q in linqMetaData.EventCustomerQuestionAnswer
                                where q.CustomerId == customerId && q.EventId == eventId
                                && q.IsActive
                                select q).ToArray();
                return Mapper.Map<IEnumerable<EventCustomerQuestionAnswerEntity>, IEnumerable<EventCustomerQuestionAnswer>>(entities);
            }
        }
        public bool DeleteEventCustomerQuestionAnswers(long customerId, long[] eventIds, long orgUserId)
        {
            var eventCustomerQuestionAnswerEntity = new EventCustomerQuestionAnswerEntity() { IsActive = false, UpdatedBy = orgUserId, UpdatedDate = DateTime.Now };
            using (var adapter = PersistenceLayer.GetDataAccessAdapter())
            {
                var bucket = new RelationPredicateBucket(EventCustomerQuestionAnswerFields.CustomerId == customerId);
                bucket.PredicateExpression.AddWithAnd(EventCustomerQuestionAnswerFields.EventId == eventIds);
                return (adapter.UpdateEntitiesDirectly(eventCustomerQuestionAnswerEntity, bucket) > 0) ? true : false;
            }
        }

        public IEnumerable<EventCustomerQuestionAnswer> GetEventCustomerQuestionAnswer(long customerId, long templateId)
        {
            using (var adapter = PersistenceLayer.GetDataAccessAdapter())
            {
                var linqMetaData = new LinqMetaData(adapter);

                var questionIds = linqMetaData.PreQualificationTemplateQuestion.Where(x => x.TemplateId == templateId).Select(x => x.QuestionId).ToArray();

                var maxVersion = linqMetaData.EventCustomerQuestionAnswer.Where(x => x.CustomerId == customerId && questionIds.Contains(x.QuestionId) && x.IsActive == true).Max(x => x.Version);

                var entities = (from q in linqMetaData.EventCustomerQuestionAnswer
                                where q.CustomerId == customerId && q.Version == maxVersion
                                && q.IsActive
                                select q).ToArray();
                return Mapper.Map<IEnumerable<EventCustomerQuestionAnswerEntity>, IEnumerable<EventCustomerQuestionAnswer>>(entities);
            }
        }

    }
}
