using Falcon.App.Core.Scheduling.Domain;
using Falcon.Data.EntityClasses;

namespace Falcon.App.Infrastructure.Mappers.Orders
{
    public class EventPackageMapper : DomainEntityMapper<EventPackage, EventPackageDetailsEntity>
    {
        protected override void MapDomainFields(EventPackageDetailsEntity entity,
            EventPackage domainObjectToMapTo)
        {
            domainObjectToMapTo.Id = entity.EventPackageId;
            domainObjectToMapTo.DateCreated = entity.DateCreated;
            domainObjectToMapTo.DateModified = entity.DateModified;
            domainObjectToMapTo.EventId = entity.EventId;
            domainObjectToMapTo.PackageId = entity.PackageId;
            domainObjectToMapTo.Price = entity.PackagePrice;
            domainObjectToMapTo.AvailableThroughOnline = entity.AvailableThroughOnline;
            domainObjectToMapTo.AvailableThroughCallCenter = entity.AvailableThroughCallCenter;
            domainObjectToMapTo.AvailableThroughTechnician = entity.AvailableThroughTechnician;
            domainObjectToMapTo.AvailableThroughAdmin = entity.AvailableThroughAdmin;
            domainObjectToMapTo.HealthAssessmentTemplateId = entity.HafTemplateId;
            domainObjectToMapTo.Gender = entity.Gender;
            domainObjectToMapTo.IsRecommended = entity.IsRecommended;
            domainObjectToMapTo.MostPopular = entity.MostPopular;
            domainObjectToMapTo.BestValue = entity.BestValue;
            domainObjectToMapTo.PodRoomId = entity.PodRoomId;
        }

        protected override void MapEntityFields(EventPackage domainObject,
            EventPackageDetailsEntity entityToMapTo)
        {
            entityToMapTo.EventPackageId = domainObject.Id;
            entityToMapTo.DateCreated = domainObject.DateCreated;
            entityToMapTo.EventId = domainObject.EventId;
            entityToMapTo.PackageId = domainObject.PackageId;
            entityToMapTo.PackagePrice = domainObject.Price;
            if (domainObject.DateModified.HasValue)
            {
                entityToMapTo.DateModified = domainObject.DateModified.Value;
            }
            entityToMapTo.AvailableThroughOnline = domainObject.AvailableThroughOnline;
            entityToMapTo.AvailableThroughCallCenter = domainObject.AvailableThroughCallCenter;
            entityToMapTo.AvailableThroughTechnician = domainObject.AvailableThroughTechnician;
            entityToMapTo.AvailableThroughAdmin = domainObject.AvailableThroughAdmin;
            entityToMapTo.HafTemplateId = domainObject.HealthAssessmentTemplateId;
            entityToMapTo.Gender = domainObject.Gender;
            entityToMapTo.IsRecommended = domainObject.IsRecommended;
            entityToMapTo.BestValue = domainObject.BestValue;
            entityToMapTo.MostPopular = domainObject.MostPopular;
            entityToMapTo.PodRoomId = domainObject.PodRoomId;
        }
    }
}