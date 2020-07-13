using System;
using Falcon.App.Core.Domain;
using Falcon.App.Core.Operations.Domain;
using Falcon.App.Infrastructure.Mappers;
using Falcon.Data.EntityClasses;

namespace Falcon.App.Infrastructure.Operations.Mappers
{
    public class PodTeamAssignmentMapper : DomainEntityMapper<PodStaff, PodDefaultTeamEntity>
    {
        protected override void MapDomainFields(PodDefaultTeamEntity entity, PodStaff domainObjectToMapTo)
        {
            domainObjectToMapTo.Id = entity.PodTeamId;
            domainObjectToMapTo.PodId = entity.PodId;
            domainObjectToMapTo.OrganizationRoleUserId = entity.OrgnizationRoleUserId;
            domainObjectToMapTo.EventRoleId = entity.EventRoleId.HasValue?entity.EventRoleId.Value:0;
            domainObjectToMapTo.DataRecorderMetaData = new DataRecorderMetaData()
            {
                DateCreated = entity.DateCreated,
                DateModified = entity.DateModified,
                
            };
            domainObjectToMapTo.DataRecorderMetaData.DateCreated = entity.DateCreated;
            domainObjectToMapTo.DataRecorderMetaData.DateModified = entity.DateModified;
        }

        protected override void MapEntityFields(PodStaff domainObject, PodDefaultTeamEntity entityToMapTo)
        {
            entityToMapTo.PodTeamId = domainObject.Id;
            entityToMapTo.PodId = domainObject.PodId;
            entityToMapTo.OrgnizationRoleUserId = domainObject.OrganizationRoleUserId;
            entityToMapTo.EventRoleId = domainObject.EventRoleId;
            entityToMapTo.IsActive = true;
            if (domainObject.DataRecorderMetaData != null)
            {
                entityToMapTo.DateCreated = domainObject.DataRecorderMetaData.DateCreated;
                entityToMapTo.DateModified = domainObject.DataRecorderMetaData.DateModified.HasValue
                                                 ? domainObject.DataRecorderMetaData.DateModified.Value
                                                 : (DateTime?) null;
            }
        }
    }
}