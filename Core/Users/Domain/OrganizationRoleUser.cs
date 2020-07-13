using Falcon.App.Core.Domain;

namespace Falcon.App.Core.Users.Domain
{
    public class OrganizationRoleUser : DomainObjectBase
    {
        public long UserId { get; set; }
        public long RoleId { get; set; }
        public long OrganizationId { get; set; }
        //public long ShellId { get; set; }
        
        public OrganizationRoleUser()
        {}

        public OrganizationRoleUser(long dataRecorderUserId)
            : base(dataRecorderUserId)
        {}

        public OrganizationRoleUser(long userId, long roleId, long organizationId)
        {
            UserId = userId;
            RoleId = roleId;
            OrganizationId = organizationId;
        }
    }
}