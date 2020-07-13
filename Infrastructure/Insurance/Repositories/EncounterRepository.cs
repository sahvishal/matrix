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
using Falcon.Data.Linq;

namespace Falcon.App.Infrastructure.Insurance.Repositories
{
    [DefaultImplementation]
    public class EncounterRepository : PersistenceRepository, IEncounterRepository
    {
        public Encounter GetById(long id)
        {
            using (var adapter = PersistenceLayer.GetDataAccessAdapter())
            {
                var linqMetaData = new LinqMetaData(adapter);
                try
                {
                    var entity = (from e in linqMetaData.Encounter where e.EncounterId == id select e).Single();
                    return Mapper.Map<EncounterEntity, Encounter>(entity);
                }
                catch (InvalidOperationException)
                {
                    throw new ObjectNotFoundInPersistenceException<Eligibility>(id);
                }
            }
        }

        public Encounter GetByEventCustomerId(long eventCustomerId)
        {
            using (var adapter = PersistenceLayer.GetDataAccessAdapter())
            {
                var linqMetaData = new LinqMetaData(adapter);

                var entity = (from e in linqMetaData.Encounter
                              join ee in linqMetaData.EventCustomerEncounter on e.EncounterId equals ee.EncounterId
                              where ee.EventCustomerId == eventCustomerId
                              select e).SingleOrDefault();
                if (entity == null)
                    return null;
                return Mapper.Map<EncounterEntity, Encounter>(entity);
            }
        }

        public IEnumerable<Encounter> GetByEventCustomerIds(IEnumerable<long> eventCustomerIds)
        {
            using (var adapter = PersistenceLayer.GetDataAccessAdapter())
            {
                var linqMetaData = new LinqMetaData(adapter);

                var entities = (from e in linqMetaData.Encounter
                                join ee in linqMetaData.EventCustomerEncounter on e.EncounterId equals ee.EncounterId
                                where eventCustomerIds.Contains(ee.EventCustomerId)
                                select e);

                return Mapper.Map<IEnumerable<EncounterEntity>, IEnumerable<Encounter>>(entities);
            }
        }

        public Encounter Save(Encounter domain)
        {
            using (var adapter = PersistenceLayer.GetDataAccessAdapter())
            {
                var entity = Mapper.Map<Encounter, EncounterEntity>(domain);
                adapter.SaveEntity(entity, true, false);
                return Mapper.Map<EncounterEntity, Encounter>(entity);
            }
        }

        public void SaveEventCustomerEncounter(long eventCustomerId, long encounterId)
        {
            if (encounterId > 0)
            {
                using (var adapter = PersistenceLayer.GetDataAccessAdapter())
                {
                    adapter.SaveEntity(new EventCustomerEncounterEntity(eventCustomerId, encounterId));
                }
            }
        }

        public IEnumerable<EventCustomerEncounter> GetEventCustomerEncounterByEventCustomerIds(IEnumerable<long> eventCustomerIds)
        {
            using (var adapter = PersistenceLayer.GetDataAccessAdapter())
            {
                var linqMetaData = new LinqMetaData(adapter);

                var entities = (from ece in linqMetaData.EventCustomerEncounter
                                where eventCustomerIds.Contains(ece.EventCustomerId)
                                select ece).ToArray();

                if (entities != null && entities.Any())
                    return Mapper.Map<IEnumerable<EventCustomerEncounterEntity>, IEnumerable<EventCustomerEncounter>>(entities);
                return null;
            }
        }
    }
}
