using System;
using System.Collections.Generic;
using System.Linq;
using Falcon.App.Core.Application.Attributes;
using Falcon.App.Core.Extensions;
using Falcon.App.Core.Operations;
using Falcon.App.Core.Operations.Domain;
using Falcon.App.Infrastructure.Repositories;
using Falcon.Data.EntityClasses;
using Falcon.Data.Linq;
using AutoMapper;

namespace Falcon.App.Infrastructure.Operations.Repositories
{
    [DefaultImplementation]
    public class EventPhysicianTestRepository : PersistenceRepository, IEventPhysicianTestRepository
    {

        public EventPhysicianTest Save(EventPhysicianTest domain)
        {
            using (var adapter = PersistenceLayer.GetDataAccessAdapter())
            {
                var linqMetaData = new LinqMetaData(adapter);
                var entity = (from epr in linqMetaData.EventPhysicianTest
                              where epr.EventId == domain.EventId && epr.PhysicianId == domain.PhysicianId && epr.TestId == domain.TestId
                              select epr).FirstOrDefault();

                bool isNew = true;
                if (entity != null)
                {
                    isNew = false;
                    domain.DateCreated = entity.DateCreated;
                    domain.AssignedByOrgRoleUserId = entity.AssignedByOrgRoleUserId;
                }

                entity = Mapper.Map<EventPhysicianTest, EventPhysicianTestEntity>(domain);
                entity.IsNew = isNew;
                adapter.SaveEntity(entity, true, false);
                return Mapper.Map<EventPhysicianTestEntity, EventPhysicianTest>(entity);
            }
        }

        public void DeactivateAll(long eventId, long modifiedby)
        {
            using (var adapter = PersistenceLayer.GetDataAccessAdapter())
            {
                var linqMetaData = new LinqMetaData(adapter);
                var entities = (from epr in linqMetaData.EventPhysicianTest
                                where epr.EventId == eventId
                                select epr);

                foreach (var entity in entities)
                {
                    entity.IsActive = false;
                    entity.DateModified = DateTime.Now;
                    entity.ModifiedByOrgRoleUserId = modifiedby;
                    adapter.SaveEntity(entity, true, false);
                }
            }
        }

        public void SaveEventPhysicianTests(IEnumerable<EventPhysicianTest> collection)
        {
            if (collection != null && collection.Any())
            {
                var domain = collection.First();
                DeactivateAll(domain.EventId, domain.ModifiedByOrgRoleUserId);

                foreach (var eventPhysicianTest in collection)
                {
                    Save(eventPhysicianTest);
                }
            }
        }

        public IEnumerable<EventPhysicianTest> GetByEventId(long eventId)
        {
            using (var adapter = PersistenceLayer.GetDataAccessAdapter())
            {
                var linqMetaData = new LinqMetaData(adapter);

                var entities = (from ept in linqMetaData.EventPhysicianTest where ept.EventId == eventId && ept.IsActive select ept).ToArray();

                if (entities.IsNullOrEmpty())
                    return null;

                return Mapper.Map<IEnumerable<EventPhysicianTestEntity>, IEnumerable<EventPhysicianTest>>(entities);
            }
        }

        public IEnumerable<EventPhysicianTest> GetByEventIdPhysicianId(long eventId, long physicianId)
        {
            using (var adapter = PersistenceLayer.GetDataAccessAdapter())
            {
                var linqMetaData = new LinqMetaData(adapter);

                var entities = (from ept in linqMetaData.EventPhysicianTest where ept.EventId == eventId && ept.PhysicianId == physicianId && ept.IsActive select ept).ToArray();
                if (entities.IsNullOrEmpty())
                    return null;
                return Mapper.Map<IEnumerable<EventPhysicianTestEntity>, IEnumerable<EventPhysicianTest>>(entities);
            }
        }

    }
}
