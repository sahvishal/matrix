using AutoMapper;
using Falcon.App.Core.Application.Attributes;
using Falcon.App.Core.Application.Exceptions;
using Falcon.App.Core.CallQueues;
using Falcon.App.Core.CallQueues.Domain;
using Falcon.App.Infrastructure.Repositories;
using Falcon.Data.EntityClasses;
using Falcon.Data.HelperClasses;
using SD.LLBLGen.Pro.ORMSupportClasses;

namespace Falcon.App.Infrastructure.CallQueues.Repositories
{
    [DefaultImplementation]
    public class SystemGeneratedCallQueueAssignmentRepository : PersistenceRepository, ISystemGeneratedCallQueueAssignmentRepository
    {
        public bool DeleteByCriteriaId(long criteriaId)
        {
            using (var adapter = PersistenceLayer.GetDataAccessAdapter())
            {
                var bucket = new RelationPredicateBucket(SystemGeneratedCallQueueAssignmentFields.CriteriaId == criteriaId);
                if (adapter.DeleteEntitiesDirectly("SystemGeneratedCallQueueAssignmentEntity", bucket) > 0)
                    return true;
                return false;
            }
        }

        public SystemGeneratedCallQueueAssignment Save(SystemGeneratedCallQueueAssignment systemGeneratedCallQueueCriteria)
        {
            using (var adapter = PersistenceLayer.GetDataAccessAdapter())
            {
                var entity = Mapper.Map<SystemGeneratedCallQueueAssignment, SystemGeneratedCallQueueAssignmentEntity>(systemGeneratedCallQueueCriteria);
                if (!adapter.SaveEntity(entity, true))
                {
                    throw new PersistenceFailureException();
                }
                return Mapper.Map<SystemGeneratedCallQueueAssignmentEntity, SystemGeneratedCallQueueAssignment>(entity);
            }
        }
    }
}
