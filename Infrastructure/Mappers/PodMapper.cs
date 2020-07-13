using Falcon.App.Core.Domain;
using Falcon.App.Core.Operations.Domain;
using Falcon.App.Core.Users.Domain;
using Falcon.Data.EntityClasses;

namespace Falcon.App.Infrastructure.Mappers
{
    public class PodMapper : DomainEntityMapper<Pod, PodDetailsEntity>
    {
        protected override void MapDomainFields(PodDetailsEntity entity, Pod domainObjectToMapTo)
        {
            domainObjectToMapTo.Id = entity.PodId;
            domainObjectToMapTo.Name = entity.Name;
            domainObjectToMapTo.Description = entity.Description;
            domainObjectToMapTo.VanId = entity.VanId;
            domainObjectToMapTo.ProcessingCapacity = entity.PodProcessingCapacity;
            domainObjectToMapTo.AssignedToFranchiseeid = entity.OrganizationId != null ? entity.OrganizationId.Value : 0;
            domainObjectToMapTo.EnableKynIntegration = entity.EnableKynIntegration;
            domainObjectToMapTo.IsBloodworkFormAttached = entity.IsBloodworkFormAttached;

            domainObjectToMapTo.DataRecorderMetaData = new DataRecorderMetaData()
            {
                DateCreated = entity.CreatedOn,
                DateModified = entity.UpdatedOn,
                DataRecorderCreator =entity.CreatedByOrgRoleUserId.HasValue ? new OrganizationRoleUser(entity.CreatedByOrgRoleUserId.Value): null,
                DataRecorderModifier = entity.UpdatedByOrgRoleUserId.HasValue ? new OrganizationRoleUser(entity.UpdatedByOrgRoleUserId.Value): null
            };

            if (domainObjectToMapTo.DataRecorderMetaData.DataRecorderCreator != null)
                domainObjectToMapTo.DataRecorderMetaData.DataRecorderCreator.Id = entity.CreatedByOrgRoleUserId.HasValue ? entity.CreatedByOrgRoleUserId.Value : 0;
        }

        protected override void MapEntityFields(Pod domainObject, PodDetailsEntity entityToMapTo)
        {
            entityToMapTo.Name = domainObject.Name;
            entityToMapTo.PodId = domainObject.Id;
            entityToMapTo.Description = string.IsNullOrEmpty(domainObject.Description) ? "" : domainObject.Description;
            entityToMapTo.VanId = domainObject.VanId;
            entityToMapTo.PodProcessingCapacity = domainObject.ProcessingCapacity;
            entityToMapTo.OrganizationId = domainObject.AssignedToFranchiseeid;
            entityToMapTo.IsActive = true;
            entityToMapTo.EnableKynIntegration = domainObject.EnableKynIntegration;
            entityToMapTo.IsBloodworkFormAttached = domainObject.IsBloodworkFormAttached;

            if (domainObject.DataRecorderMetaData != null)
            {
                entityToMapTo.CreatedOn = domainObject.DataRecorderMetaData.DateCreated;
                if (domainObject.DataRecorderMetaData.DateModified != null)
                    entityToMapTo.UpdatedOn = domainObject.DataRecorderMetaData.DateModified.Value;
                entityToMapTo.CreatedByOrgRoleUserId = domainObject.DataRecorderMetaData.DataRecorderCreator.Id;
            }
            
        }
    }
}