using System.Collections.Generic;
using System.Linq;
using Falcon.App.Core;
using Falcon.App.Core.Application;
using Falcon.App.Core.Application.Exceptions;
using Falcon.App.Core.Operations;
using Falcon.App.Core.Operations.Domain;
using Falcon.App.Infrastructure.Application.Impl;
using Falcon.App.Infrastructure.Interfaces;
using Falcon.App.Infrastructure.Operations.Mappers;
using Falcon.App.Infrastructure.Repositories;
using Falcon.Data.EntityClasses;
using Falcon.Data.HelperClasses;
using Falcon.Data.Linq;
using SD.LLBLGen.Pro.ORMSupportClasses;

namespace Falcon.App.Infrastructure.Operations.Repositories
{
    public class PhysicianEventAssignmentRepository : PersistenceRepository, IPhysicianEventAssignmentRepository
    {
        private readonly IMapper<PhysicianEventAssignment, PhysicianEventAssignmentEntity> _mapper;
        public PhysicianEventAssignmentRepository()
            :this(new SqlPersistenceLayer(),new PhysicianEventAssignmentMapper())
        {}

        public PhysicianEventAssignmentRepository(IPersistenceLayer persistenceLayer,IMapper<PhysicianEventAssignment,PhysicianEventAssignmentEntity> mapper)
            : base(persistenceLayer)
        {
            _mapper = mapper;
        }

        public PhysicianEventAssignment Save(PhysicianEventAssignment physicianEventAssignment)
        {
            using (var adapter = PersistenceLayer.GetDataAccessAdapter())
            {
                var entity = new PhysicianEventAssignmentEntity { IsActive = false };
                IRelationPredicateBucket bucket = new RelationPredicateBucket(PhysicianEventAssignmentFields.EventId == physicianEventAssignment.EventId);
                adapter.UpdateEntitiesDirectly(entity, bucket);

                var entityTosave = _mapper.Map(physicianEventAssignment);

                entityTosave.IsNew = !adapter.FetchEntity(new PhysicianEventAssignmentEntity(physicianEventAssignment.PhysicianId,physicianEventAssignment.EventId));

                if (!adapter.SaveEntity(entityTosave,true)) 
                    throw new PersistenceFailureException();

                return _mapper.Map(entityTosave);
            }
        }

        public PhysicianEventAssignment GetAssignedPhysicians(long eventId)
        {
            using(var adapter = PersistenceLayer.GetDataAccessAdapter())
            {
                var linqMetaData = new LinqMetaData(adapter);
                var assginedPhysicianEntity = (from pe in linqMetaData.PhysicianEventAssignment
                                               where pe.EventId == eventId && pe.IsActive
                                               select pe).FirstOrDefault();
                if (assginedPhysicianEntity != null)
                   return _mapper.Map(assginedPhysicianEntity);

                return null;
            }
        }

        public IEnumerable<OrderedPair<long,string>> GetPrimaryPhysicianForEvents(IEnumerable<long> eventIds)
        {
            using (var adapter = PersistenceLayer.GetDataAccessAdapter())
            {
                var linqMetaData = new LinqMetaData(adapter);

                return (from pe in linqMetaData.PhysicianEventAssignment
                 join oru in linqMetaData.OrganizationRoleUser on pe.PhysicianId equals oru.OrganizationRoleUserId
                 join u in linqMetaData.User on oru.UserId equals u.UserId
                 where pe.IsActive && eventIds.Contains(pe.EventId)
                 select new OrderedPair<long, string>(pe.EventId, u.FirstName + " " + u.LastName)).ToArray();
                
            }
        }

        public IEnumerable<OrderedPair<long, string>> GetOverReadPhysicianForEvents(IEnumerable<long> eventIds)
        {
            using (var adapter = PersistenceLayer.GetDataAccessAdapter())
            {
                var linqMetaData = new LinqMetaData(adapter);

                return (from pe in linqMetaData.PhysicianEventAssignment
                        join oru in linqMetaData.OrganizationRoleUser on pe.OverReadPhysicianId equals oru.OrganizationRoleUserId
                        join u in linqMetaData.User on oru.UserId equals u.UserId
                        where pe.IsActive && eventIds.Contains(pe.EventId)
                        select new OrderedPair<long, string>(pe.EventId, u.FirstName + " " + u.LastName)).ToArray();

            }
        }

        public IEnumerable<PhysicianEventAssignment> GetAssignedPhysiciansByEventIds(IEnumerable<long> eventIds)
        {
            using (var adapter = PersistenceLayer.GetDataAccessAdapter())
            {
                var linqMetaData = new LinqMetaData(adapter);
                var assginedPhysicianEntities = (from pe in linqMetaData.PhysicianEventAssignment
                                                 where eventIds.Contains(pe.EventId) && pe.IsActive
                                                 select pe);

                return _mapper.MapMultiple(assginedPhysicianEntities);
            }
        }
    }
}
