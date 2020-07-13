using System;

namespace Falcon.App.Core.Users.ViewModels
{
    [Serializable]
    public class OrganizationRoleUserModel
    {
        public long OrganizationRoleUserId { get; set; }
        public long UserId { get; set; }
        public long OrganizationId { get; set; }
        public string OrganizationName { get; set; }
        public long RoleId { get; set; }
        public long ParentRoleId { get; set; }
        public string RoleDisplayName { get; set; }
        public string RoleAlias { get; set; }
        public bool IsDefault { get; set; }
        public string LogoFilePathUrl { get; set; }

        public string DialerUrl { get; set; }

        public bool CheckRole(long roleId)
        {
            return RoleId == roleId || ParentRoleId == roleId;
        }

        public long GetSystemRoleId
        {
            get
            {
                return ParentRoleId == 0 ? RoleId : ParentRoleId;
            }
        }
    }
}