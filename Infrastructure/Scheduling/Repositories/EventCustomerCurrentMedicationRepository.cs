using System.Collections.Generic;
using System.Linq;
using AutoMapper;
using Falcon.App.Core;
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
    public class EventCustomerCurrentMedicationRepository : PersistenceRepository, IEventCustomerCurrentMedicationRepository
    {
        public IEnumerable<EventCustomerCurrentMedication> GetByCustomerId(long customerId)
        {
            using (var adapter = PersistenceLayer.GetDataAccessAdapter())
            {
                var linqMetaData = new LinqMetaData(adapter);
                var entities = (from eccm in linqMetaData.EventCustomerCurrentMedication
                                where eccm.EventCustomerId == customerId
                                select eccm).ToArray();
                return Mapper.Map<IEnumerable<EventCustomerCurrentMedicationEntity>, IEnumerable<EventCustomerCurrentMedication>>(entities);
            }
        }

        private void DeleteOldData(long eventCustomerId)
        {
            using (var adapter = PersistenceLayer.GetDataAccessAdapter())
            {
                var relationPredicateBucket = new RelationPredicateBucket(EventCustomerCurrentMedicationFields.EventCustomerId == eventCustomerId);
                adapter.DeleteEntitiesDirectly(typeof(EventCustomerCurrentMedicationEntity), relationPredicateBucket);
            }
        }

        //public void SaveAll(long eventCustomerId, IEnumerable<OrderedPair<long, string>> ndcPairs)
        //{
        //    var domainCollection = new List<EventCustomerCurrentMedication>();
        //    foreach (var ndcPair in ndcPairs)
        //    {
        //        domainCollection.Add(new EventCustomerCurrentMedication
        //        {
        //            EventCustomerId = eventCustomerId,
        //            NdcId = ndcPair.FirstValue,
        //            IsPrescribed = ndcPair.SecondValue == "p",
        //            IsOtc = ndcPair.SecondValue == "o"
        //        });
        //    }

        //    Save(eventCustomerId, domainCollection);
        //}

        public void Save(long eventCustomerId, IEnumerable<EventCustomerCurrentMedication> domain)
        {
            DeleteOldData(eventCustomerId);

            using (var adapter = PersistenceLayer.GetDataAccessAdapter())
            {
                foreach (var ndcPair in domain)
                {
                    var entity = Mapper.Map<EventCustomerCurrentMedication, EventCustomerCurrentMedicationEntity>(ndcPair);
                    if (!adapter.SaveEntity(entity,false))
                        throw new PersistenceFailureException();
                }
            }
        }
    }
}
