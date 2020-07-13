using System;
using System.Collections.Generic;
using System.Linq;
using AutoMapper;
using Falcon.App.Core.Application.Attributes;
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
    public class EventCustomerRetestRepository : PersistenceRepository, IEventCustomerRetestRepository
    {
        public IEnumerable<EventCustomerRetest> GetByEventCustomerId(long eventCustomerId)
        {
            using (var adapter = PersistenceLayer.GetDataAccessAdapter())
            {
                var linqMetaData = new LinqMetaData(adapter);
                var entities = (from ecr in linqMetaData.EventCustomerRetest
                                where ecr.EventCustomerId == eventCustomerId
                                select ecr).ToArray();

                return Mapper.Map<IEnumerable<EventCustomerRetestEntity>, IEnumerable<EventCustomerRetest>>(entities);
            }
        }

        public void SaveEventCustomerRetest(long eventCustomerId, long[] testIds, long createdBy)
        {
            using (var adapter = PersistenceLayer.GetDataAccessAdapter())
            {
                var linqMetaData = new LinqMetaData(adapter);
                var recordableTestIds = (from test in linqMetaData.Test
                                         where testIds.Contains(test.TestId) && test.IsRecordable
                                         select test.TestId);

                foreach (var testId in recordableTestIds)
                {
                    adapter.SaveEntity(new EventCustomerRetestEntity
                    {
                        EventCustomerId = eventCustomerId,
                        TestId = testId,
                        DateCreated = DateTime.Now,
                        CreatedBy = createdBy
                    });
                }
            }
        }

        public void DeleteByEventCustomerId(long eventCustomerId)
        {
            using (var adapter = PersistenceLayer.GetDataAccessAdapter())
            {
                adapter.DeleteEntitiesDirectly(typeof(EventCustomerRetestEntity), new RelationPredicateBucket(EventCustomerRetestFields.EventCustomerId == eventCustomerId));
            }
        }

        public void DeleteByEventCustomerIdAndTestIds(long eventCustomerId, long[] testIds)
        {
            using (var adapter = PersistenceLayer.GetDataAccessAdapter())
            {
                var bucket = new RelationPredicateBucket(EventCustomerRetestFields.EventCustomerId == eventCustomerId);
                bucket.PredicateExpression.AddWithAnd(EventCustomerRetestFields.TestId == testIds);

                adapter.DeleteEntitiesDirectly(typeof(EventCustomerRetestEntity), bucket);
            }
        }

        public IEnumerable<long> GetTestIdsByCustomerIdAndEventId(long customerId, long eventId)
        {
            using (var adapter = PersistenceLayer.GetDataAccessAdapter())
            {
                var linqMetaData = new LinqMetaData(adapter);

                return (from ecr in linqMetaData.EventCustomerRetest
                        join ec in linqMetaData.EventCustomers on ecr.EventCustomerId equals ec.EventCustomerId
                        where ec.CustomerId == customerId && ec.EventId == eventId
                        select ecr.TestId).ToArray();
            }
        }

        public IEnumerable<EventCustomerRetest> GetByEventCustomerIds(IEnumerable<long> eventCustomerIds)
        {
            using (var adapter = PersistenceLayer.GetDataAccessAdapter())
            {
                var linqMetaData = new LinqMetaData(adapter);
                var entities = (from ecr in linqMetaData.EventCustomerRetest
                                where eventCustomerIds.Contains(ecr.EventCustomerId)
                                select ecr).ToArray();

                return Mapper.Map<IEnumerable<EventCustomerRetestEntity>, IEnumerable<EventCustomerRetest>>(entities);
            }
        }

        public void UpdateMailSentDate(long eventCustomerId, DateTime? mailSendDate)
        {
            using (var adapter = PersistenceLayer.GetDataAccessAdapter())
            {
                var relationPredicateBucket = new RelationPredicateBucket(EventCustomerRetestFields.EventCustomerId == eventCustomerId);
                adapter.UpdateEntitiesDirectly(new EventCustomerRetestEntity { MailSentDate = mailSendDate }, relationPredicateBucket);
            }
        }
    }
}
