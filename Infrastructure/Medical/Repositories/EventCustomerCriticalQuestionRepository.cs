using System.Collections.Generic;
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

namespace Falcon.App.Infrastructure.Medical.Repositories
{
    [DefaultImplementation]
    public class EventCustomerCriticalQuestionRepository : PersistenceRepository, IEventCustomerCriticalQuestionRepository
    {
        public IEnumerable<EventCustomerCriticalQuestion> GetByEventCustomerId(long eventCustomerId)
        {
            using (var adapter = PersistenceLayer.GetDataAccessAdapter())
            {
                var linqMetaData = new LinqMetaData(adapter);

                var entities = (from eccq in linqMetaData.EventCustomerCriticalQuestion
                                where eccq.EventCustomerId == eventCustomerId
                                select eccq);

                return Mapper.Map<IEnumerable<EventCustomerCriticalQuestionEntity>, IEnumerable<EventCustomerCriticalQuestion>>(entities);
            }
        }

        public void Save(EventCustomerCriticalQuestion domain)
        {
            using (var adapter = PersistenceLayer.GetDataAccessAdapter())
            {
                var entity = Mapper.Map<EventCustomerCriticalQuestion, EventCustomerCriticalQuestionEntity>(domain);

                if (!adapter.SaveEntity(entity))
                {
                    throw new PersistenceFailureException();
                }
            }
        }

        public void DeleteByEventCustomerId(long eventCustomerId)
        {
            using (var adapter = PersistenceLayer.GetDataAccessAdapter())
            {
                var bucket = new RelationPredicateBucket(EventCustomerCriticalQuestionFields.EventCustomerId == eventCustomerId);
                adapter.DeleteEntitiesDirectly(typeof(EventCustomerCriticalQuestionEntity), bucket);
            }
        }
    }
}
