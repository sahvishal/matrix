using System;
using System.Collections.Generic;
using System.Linq;
using AutoMapper;
using Falcon.App.Core.Application.Attributes;
using Falcon.App.Core.Application.Exceptions;
using Falcon.App.Core.Insurance;
using Falcon.App.Core.Insurance.Domain;
using Falcon.App.Infrastructure.Repositories;
using Falcon.Data.EntityClasses;
using Falcon.Data.HelperClasses;
using Falcon.Data.Linq;
using SD.LLBLGen.Pro.ORMSupportClasses;

namespace Falcon.App.Infrastructure.Insurance.Repositories
{
    [DefaultImplementation]
    public class EligibilityRepository : PersistenceRepository, IEligibilityRepository
    {
        public Eligibility GetById(long id)
        {
            using (var adapter = PersistenceLayer.GetDataAccessAdapter())
            {
                var linqMetaData = new LinqMetaData(adapter);
                try
                {
                    var entity = (from e in linqMetaData.Eligibility where e.EligibilityId == id select e).Single();
                    return Mapper.Map<EligibilityEntity, Eligibility>(entity);
                }
                catch (InvalidOperationException)
                {
                    throw new ObjectNotFoundInPersistenceException<Eligibility>(id);
                }
            }
        }

        public Eligibility GetByEventCustomerId(long eventCustomerId)
        {
            using (var adapter = PersistenceLayer.GetDataAccessAdapter())
            {
                var linqMetaData = new LinqMetaData(adapter);

                var entity = (from e in linqMetaData.Eligibility
                              join ee in linqMetaData.EventCustomerEligibility on e.EligibilityId equals ee.EligibilityId
                              where ee.EventCustomerId == eventCustomerId
                              select e).SingleOrDefault();
                if (entity == null)
                    return null;
                return Mapper.Map<EligibilityEntity, Eligibility>(entity);
            }
        }

        public IEnumerable<Eligibility> GetByEventCustomerIds(IEnumerable<long> eventCustomerIds)
        {
            using (var adapter = PersistenceLayer.GetDataAccessAdapter())
            {
                var linqMetaData = new LinqMetaData(adapter);

                var entities = (from e in linqMetaData.Eligibility
                                join ee in linqMetaData.EventCustomerEligibility on e.EligibilityId equals ee.EligibilityId
                                where eventCustomerIds.Contains(ee.EventCustomerId)
                                select e);

                return Mapper.Map<IEnumerable<EligibilityEntity>, IEnumerable<Eligibility>>(entities);
            }
        }

        public Eligibility Save(Eligibility domain)
        {
            using (var adapter = PersistenceLayer.GetDataAccessAdapter())
            {
                var entity = Mapper.Map<Eligibility, EligibilityEntity>(domain);
                adapter.SaveEntity(entity, true, false);
                return Mapper.Map<EligibilityEntity, Eligibility>(entity);
            }
        }

        public void SaveEventCustomerEligibility(long eventCustomerId, long eligibilityId, long chargeCardId)
        {
            DeleteEventCustomerEligibility(eventCustomerId);
            if (eligibilityId > 0)
            {
                using (var adapter = PersistenceLayer.GetDataAccessAdapter())
                {
                    adapter.SaveEntity(new EventCustomerEligibilityEntity(eventCustomerId, eligibilityId) { ChargeCardId = chargeCardId });
                }
            }
        }

        public void DeleteEventCustomerEligibility(long eventCustomerId)
        {
            using (var adapter = PersistenceLayer.GetDataAccessAdapter())
            {
                var relationPredicateBucket = new RelationPredicateBucket(EventCustomerEligibilityFields.EventCustomerId == eventCustomerId);

                adapter.DeleteEntitiesDirectly(typeof(EventCustomerEligibilityEntity), relationPredicateBucket);
            }
        }

        public EventCustomerEligibility GetEventCustomerEligibilityIdByEventCustomerId(long eventCustomerId)
        {
            using (var adapter = PersistenceLayer.GetDataAccessAdapter())
            {
                var linqMetaData = new LinqMetaData(adapter);

                var entity = (from ece in linqMetaData.EventCustomerEligibility
                    where ece.EventCustomerId == eventCustomerId
                    select ece).SingleOrDefault();
                if(entity == null)
                    return null;
                return Mapper.Map<EventCustomerEligibilityEntity, EventCustomerEligibility>(entity);
            }
        }

        public IEnumerable<EventCustomerEligibility> GetEventCustomerEligibilityIdByEventCustomerIds(IEnumerable<long> eventCustomerIds)
        {
            using (var adapter = PersistenceLayer.GetDataAccessAdapter())
            {
                var linqMetaData = new LinqMetaData(adapter);

                var entities = (from ece in linqMetaData.EventCustomerEligibility
                              where eventCustomerIds.Contains(ece.EventCustomerId)
                              select ece).ToArray();

                if (entities != null && entities.Any())
                    return Mapper.Map<IEnumerable<EventCustomerEligibilityEntity>, IEnumerable<EventCustomerEligibility>>(entities);
                return null;
                
            }
        }
    }
}
