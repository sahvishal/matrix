using System.Collections.Generic;
using System.Linq;
using AutoMapper;
using Falcon.App.Core.Application.Attributes;
using Falcon.App.Core.Application.Exceptions;
using Falcon.App.Core.Scheduling;
using Falcon.App.Core.Scheduling.Domain;
using Falcon.App.Infrastructure.Repositories;
using Falcon.Data.EntityClasses;
using Falcon.Data.HelperClasses;
using Falcon.Data.Linq;
using SD.LLBLGen.Pro.ORMSupportClasses;

namespace Falcon.App.Infrastructure.Scheduling.Repositories
{
    [DefaultImplementation]
    class EventCustomerIcdCodesRepository : PersistenceRepository, IEventCustomerIcdCodesRepository
    {
        public IEnumerable<EventCustomerIcdCodes> GetbyEventCustomerId(long eventCustomerId)
        {
            using (var adapter = PersistenceLayer.GetDataAccessAdapter())
            {
                var linqMetaData = new LinqMetaData(adapter);
                var entities = (from eci in linqMetaData.EventCustomerIcdCodes
                                where eci.EventCustomerId == eventCustomerId
                                select eci).ToArray();
                return Mapper.Map<IEnumerable<EventCustomerIcdCodesEntity>, IEnumerable<EventCustomerIcdCodes>>(entities);
            }
        }

        private void DeleteOldData(long eventCustomerId)
        {
            using (var adapter = PersistenceLayer.GetDataAccessAdapter())
            {
                var relationPredicateBucket = new RelationPredicateBucket(EventCustomerIcdCodesFields.EventCustomerId == eventCustomerId);
                adapter.DeleteEntitiesDirectly(typeof(EventCustomerIcdCodesEntity), relationPredicateBucket);
            }
        }

        public void SaveAll(long eventCustomerId, IEnumerable<long> icdCodeIds)
        {
            DeleteOldData(eventCustomerId);
            if (icdCodeIds.Any())
            {
                using (var adapter = PersistenceLayer.GetDataAccessAdapter())
                {
                    //Insert New Collection
                    var entityCollection = new EntityCollection<EventCustomerIcdCodesEntity>();
                    foreach (var icdCodeId in icdCodeIds)
                    {
                        entityCollection.Add(new EventCustomerIcdCodesEntity
                        {
                            EventCustomerId = eventCustomerId,
                            IcdCodeId = icdCodeId
                        });
                    }
                    if (adapter.SaveEntityCollection(entityCollection) == 0)
                        throw new PersistenceFailureException();
                }
            }
        }
    }
}