using Falcon.App.Core.Users.Domain;
using Falcon.Data.EntityClasses;

namespace Falcon.App.Infrastructure.Mappers
{
    public class OrganizationRoleUserMapper : DomainEntityMapper<OrganizationRoleUser,
        OrganizationRoleUserEntity>
    {
        protected override void MapDomainFields(OrganizationRoleUserEntity entity, 
            OrganizationRoleUser domainObjectToMapTo)
        {
            domainObjectToMapTo.Id = entity.OrganizationRoleUserId;
            domainObjectToMapTo.UserId = entity.UserId;
            domainObjectToMapTo.RoleId = entity.RoleId;
            domainObjectToMapTo.OrganizationId = entity.OrganizationId;
        }

        protected override void MapEntityFields(OrganizationRoleUser domainObject,
            OrganizationRoleUserEntity entityToMapTo)
        {
            entityToMapTo.UserId = domainObject.UserId;
            entityToMapTo.RoleId = domainObject.RoleId;            
            entityToMapTo.OrganizationRoleUserId = domainObject.Id;
            entityToMapTo.OrganizationId = (long) (domainObject.OrganizationId > 0 ? (long?)domainObject.OrganizationId : null);
        }
    }
}
