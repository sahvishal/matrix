using System.Collections.Generic;
using System.Linq;
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
    public class PhysicianCustomerAssignmentRepository : PersistenceRepository, IPhysicianCustomerAssignmentRepository
    {
        private readonly IMapper<PhysicianCustomerAssignment, PhysicianCustomerAssignmentEntity> _mapper;

        public PhysicianCustomerAssignmentRepository()
            :this(new SqlPersistenceLayer(),new PhysicianCustomerAssignmentMapper())
        {}

        public PhysicianCustomerAssignmentRepository(IPersistenceLayer persistenceLayer,IMapper<PhysicianCustomerAssignment, PhysicianCustomerAssignmentEntity> mapper)
            :base(persistenceLayer)
        {
            _mapper = mapper;
        }

        public PhysicianCustomerAssignment Save(PhysicianCustomerAssignment physicianCustomerAssignment)
        {
            using(var adapter = PersistenceLayer.GetDataAccessAdapter())
            {
                var entity = new PhysicianCustomerAssignmentEntity {IsActive = false};
                IRelationPredicateBucket bucket =
                    new RelationPredicateBucket(PhysicianCustomerAssignmentFields.EventCustomerId ==
                                                physicianCustomerAssignment.EventCustomerId);
                adapter.UpdateEntitiesDirectly(entity, bucket);

                var entityToSave = _mapper.Map(physicianCustomerAssignment);
                entityToSave.IsNew = 
                    !adapter.FetchEntity(new PhysicianCustomerAssignmentEntity(physicianCustomerAssignment.PhysicianId,
                                                                              physicianCustomerAssignment.
                                                                                  EventCustomerId));
                if (!adapter.SaveEntity(entityToSave, true))
                    throw new PersistenceFailureException();

                return _mapper.Map(entityToSave);
            }
        }

        public PhysicianCustomerAssignment GetAssignedPhysicians(long eventCustomerId)
        {
            using(var adapter = PersistenceLayer.GetDataAccessAdapter())
            {
                var linqMetaData = new LinqMetaData(adapter);

                var assignedPhysicianEntity = (from pc in linqMetaData.PhysicianCustomerAssignment
                                               where pc.EventCustomerId == eventCustomerId && pc.IsActive
                                               select pc).FirstOrDefault();
                if (assignedPhysicianEntity != null)
                    return _mapper.Map(assignedPhysicianEntity);

                return null;
            }
        }

        public PhysicianCustomerAssignment GetAssignedPhysicians(long eventId, long customerId)
        {
            using (var adapter = PersistenceLayer.GetDataAccessAdapter())
            {
                var linqMetaData = new LinqMetaData(adapter);

                var assignedPhysicianEntity = (from pc in linqMetaData.PhysicianCustomerAssignment
                                               join ecr in linqMetaData.EventCustomers on pc.EventCustomerId equals ecr.EventCustomerId
                                               where ecr.EventId == eventId && ecr.CustomerId == customerId && pc.IsActive
                                               select pc).FirstOrDefault();

                return assignedPhysicianEntity != null ? _mapper.Map(assignedPhysicianEntity) : null;
            }
        }

        public IEnumerable<PhysicianCustomerAssignment> GetCustomerAssignmentbyEventCustomerIds(IEnumerable<long> eventCustomerIds)
        {
            using (var adapter = PersistenceLayer.GetDataAccessAdapter())
            {
                var linqMetaData = new LinqMetaData(adapter);
                var assignedPhysicianEntities = (from pc in linqMetaData.PhysicianCustomerAssignment where eventCustomerIds.Contains(pc.EventCustomerId) && pc.IsActive select pc).ToArray();
                return _mapper.MapMultiple(assignedPhysicianEntities);
            }
        }

    }
}
