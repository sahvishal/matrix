using Falcon.App.Core.Sales.Domain;
using Falcon.App.Infrastructure.Mappers;
using Falcon.Data.EntityClasses;

namespace Falcon.App.Infrastructure.Sales.Mappers
{
    public class TagMapper : DomainEntityMapper<Tag, TagEntity>
    {
        protected override void MapDomainFields(TagEntity entity, Tag domainObjectToMapTo)
        {
            domainObjectToMapTo.Id = entity.TagId;
            domainObjectToMapTo.Source = entity.Source;
            domainObjectToMapTo.Name = entity.Name;
            domainObjectToMapTo.Alias = entity.Alias;
            domainObjectToMapTo.IsActive = entity.IsActive;
            domainObjectToMapTo.IsSystemDefined = entity.IsSystemDefined;
            domainObjectToMapTo.ForAppointmentConfirmation = entity.ForAppointmentConfirmation;
            domainObjectToMapTo.CallStatus = entity.CallStatus;
            domainObjectToMapTo.ForWarmTransfer = entity.ForWarmTransfer;
            domainObjectToMapTo.ForPreAssessment = entity.ForPreAssessment;
        }

        protected override void MapEntityFields(Tag domainObject, TagEntity entityToMapTo)
        {
            entityToMapTo.TagId = domainObject.Id;
            entityToMapTo.Source = domainObject.Source;
            entityToMapTo.Name = domainObject.Name;
            entityToMapTo.Alias = domainObject.Alias;
            entityToMapTo.IsActive = domainObject.IsActive;
            entityToMapTo.IsSystemDefined = domainObject.IsSystemDefined;
            entityToMapTo.IsNew = domainObject.Id <= 0;
            entityToMapTo.ForAppointmentConfirmation = domainObject.ForAppointmentConfirmation;
            entityToMapTo.CallStatus = domainObject.CallStatus;
            entityToMapTo.ForWarmTransfer = domainObject.ForWarmTransfer;
            entityToMapTo.ForPreAssessment = domainObject.ForPreAssessment;
        }
    }
}
