using System.Linq;
using Falcon.App.Core.Domain;
using Falcon.App.Core.Extensions;
using Falcon.App.Core.Operations.Domain;
using Falcon.App.Core.Users.Domain;
using Falcon.App.Infrastructure.Mappers;
using Falcon.Data.EntityClasses;

namespace Falcon.App.Infrastructure.Operations.Mappers
{
    public class EventRoleMapper : DomainEntityMapper<StaffEventRole, StaffEventRoleEntity>
    {
        protected override void MapDomainFields(StaffEventRoleEntity entity, StaffEventRole domainObjectToMapTo)
        {
            domainObjectToMapTo.Name = entity.Name;
            domainObjectToMapTo.Id = entity.StaffEventRoleId;
            domainObjectToMapTo.Description = entity.Description;


            domainObjectToMapTo.DataRecorderMetaData = new DataRecorderMetaData()
                                                            {
                                                                DateCreated = entity.CreatedOn,
                                                                DateModified = entity.UpdatedOn,

                                                                DataRecorderCreator =
                                                                    new OrganizationRoleUser(
                                                                    entity.CreatedByOrgRoleUserId),
                                                                DataRecorderModifier =
                                                                    entity.UpdatedByOrgRoleUserId.HasValue
                                                                        ? new OrganizationRoleUser(
                                                                              entity.UpdatedByOrgRoleUserId.Value)
                                                                        : null
                                                            };

            domainObjectToMapTo.AllowedTestIds = entity.StaffEventRoleTest.Select(sert => sert.TestId).ToArray();
        }

        protected override void MapEntityFields(StaffEventRole domainObject, StaffEventRoleEntity entityToMapTo)
        {
            entityToMapTo.StaffEventRoleId = domainObject.Id;
            entityToMapTo.Name = domainObject.Name;
            entityToMapTo.Description = string.IsNullOrEmpty(domainObject.Description) ? "" : domainObject.Description;
            entityToMapTo.IsActive = true;
            if (domainObject.DataRecorderMetaData != null)
            {
                entityToMapTo.CreatedOn = domainObject.DataRecorderMetaData.DateCreated;
                entityToMapTo.UpdatedOn = domainObject.DataRecorderMetaData.DateModified;
                if (domainObject.DataRecorderMetaData.DataRecorderCreator != null)
                    entityToMapTo.CreatedByOrgRoleUserId = domainObject.DataRecorderMetaData.DataRecorderCreator.Id;
                if (domainObject.DataRecorderMetaData.DataRecorderModifier != null)
                entityToMapTo.UpdatedByOrgRoleUserId = domainObject.DataRecorderMetaData.DataRecorderModifier.Id;
            }
            if (!domainObject.AllowedTestIds.IsNullOrEmpty())
                entityToMapTo.StaffEventRoleTest.AddRange(
                    domainObject.AllowedTestIds.Select(t => new StaffEventRoleTestEntity { TestId = t }));

        }
    }
}