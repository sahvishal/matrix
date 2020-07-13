using AutoMapper;
using Falcon.App.Core.Application.Attributes;
using Falcon.App.Core.Application.Exceptions;
using Falcon.App.Core.CallCenter.Domain;
using Falcon.App.Core.CallCenter.Interfaces;
using Falcon.App.Core.CallQueues.Domain;
using Falcon.App.Infrastructure.Repositories;
using Falcon.Data.EntityClasses;

namespace Falcon.App.Infrastructure.CallCenter.Repositories
{
    [DefaultImplementation]
    public class HealthPlanCriteriaAssignmentUploadRepository : PersistenceRepository, IHealthPlanCriteriaAssignmentUploadRepository
    {
        public HealthPlanCriteriaAssignmentUpload Save(HealthPlanCriteriaAssignmentUpload domain)
        {
            using (var adapter = PersistenceLayer.GetDataAccessAdapter())
            {
                HealthPlanCriteriaAssignmentUploadEntity entity = Mapper.Map<HealthPlanCriteriaAssignmentUpload, HealthPlanCriteriaAssignmentUploadEntity>(domain);
                if (!adapter.SaveEntity(entity, true))
                {
                    throw new PersistenceFailureException();
                }
                return Mapper.Map<HealthPlanCriteriaAssignmentUploadEntity, HealthPlanCriteriaAssignmentUpload>(entity);
            }
        }
    }
}
