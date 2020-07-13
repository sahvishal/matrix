using System;

namespace Falcon.App.Core.Users.ViewModels
{
    [Serializable]
    public class UserSessionModel
    {
        public OrganizationRoleUserModel CurrentOrganizationRole { get; set; }
        public OrganizationRoleUserModel[] AvailableOrganizationRoles { get; set; }

        public long UserId { get; set; }
        public string UserName { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string FullName { get { return FirstName + " " + LastName; } }

        public long UserLoginLogId { get; set; }


    }
}


