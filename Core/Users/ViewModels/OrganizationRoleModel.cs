namespace Falcon.App.Core.Users.ViewModels
{
    public class OrganizationRoleModel
    {        
        public long OrganizationId { get; set; }
        public string OrganizationName { get; set; }
        public long RoleId { get; set; }
        public string RoleName { get; set; }
        public bool IsDefault { get; set; }        
    }
}