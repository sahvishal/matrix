using Falcon.App.Core.Application;
using Falcon.App.Core.Medical.Domain;
using Falcon.App.Infrastructure.Mappers;
using Falcon.Data.EntityClasses;
using Falcon.App.Core.Application.Attributes;

namespace Falcon.App.Infrastructure.Medical.Mappers
{
    [DefaultImplementation(Interface = typeof(IMapper<PhysicianEvaluation, PhysicianEvaluationEntity>))]
    public class PhysicianEvaluationMapper : DomainEntityMapper<PhysicianEvaluation, PhysicianEvaluationEntity>
    {
        protected override void MapDomainFields(PhysicianEvaluationEntity entity, PhysicianEvaluation domainObjectToMapTo)
        {
            domainObjectToMapTo.Id = entity.PhysicianEvaluationId;
            domainObjectToMapTo.EventCustomerId = entity.EventCustomerId;
            domainObjectToMapTo.PhysicianId = entity.PhysicianId;
            domainObjectToMapTo.EvaluationStartTime = entity.EvaluationStartTime;
            domainObjectToMapTo.EvaluationEndTime = entity.EvaluationEndTime;
            domainObjectToMapTo.IpAddress = entity.Ipaddress;
            domainObjectToMapTo.IsPrimaryEvaluator = entity.IsPrimaryEvaluator;
        }

        protected override void MapEntityFields(PhysicianEvaluation domainObject, PhysicianEvaluationEntity entityToMapTo)
        {
            entityToMapTo.PhysicianEvaluationId = domainObject.Id;
            entityToMapTo.EventCustomerId = domainObject.EventCustomerId;
            entityToMapTo.PhysicianId = domainObject.PhysicianId;
            entityToMapTo.EvaluationStartTime = domainObject.EvaluationStartTime;
            entityToMapTo.EvaluationEndTime = domainObject.EvaluationEndTime;
            entityToMapTo.Ipaddress = domainObject.IpAddress;
            entityToMapTo.IsPrimaryEvaluator = domainObject.IsPrimaryEvaluator;
            entityToMapTo.IsNew = domainObject.Id > 0 ? false : true;
        }
    }
}
