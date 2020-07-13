using Falcon.Data.EntityClasses;
using Falcon.App.Core.Users.ViewModels;

namespace Falcon.App.Infrastructure.Users.Mappers
{
    public class OrganizationRoleUserModelMapper
    {
        
        public OrganizationRoleUserModel Map(OrganizationRoleUserEntity entity)
        {
            var domainObjectToMapTo = new OrganizationRoleUserModel();

            if(entity.Organization != null){
                domainObjectToMapTo.OrganizationName = entity.Organization.Name;
                domainObjectToMapTo.OrganizationId = entity.Organization.OrganizationId;
            }
                        
            if (entity.Role != null)
            {
                domainObjectToMapTo.RoleId = entity.RoleId;
                domainObjectToMapTo.RoleDisplayName = entity.Role.Name;
                domainObjectToMapTo.RoleAlias = entity.Role.Alias;
                domainObjectToMapTo.UserId = entity.UserId;               
            }

            domainObjectToMapTo.OrganizationRoleUserId = entity.OrganizationRoleUserId;
            return domainObjectToMapTo;
        }

    }
}
