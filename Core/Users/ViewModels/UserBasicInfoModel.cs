using System.ComponentModel;
using Falcon.App.Core.Application.Attributes;
using Falcon.App.Core.Application.ViewModels;
using System.Collections.Generic;

namespace Falcon.App.Core.Users.ViewModels
{
    public class UserBasicInfoModel : ViewModelBase
    {
        [Hidden]
        public long Id { get; set; }

        [Hidden]
        public string OrganizationName { get; set; }

        [Hidden]
        public long OrganizationRoleUserId { get; set; }
        
        public string Name { get; set; }
        public string Address { get; set; }
        public string Phone { get; set; }
        public string Email { get; set; }

        [DisplayName("Default Role")]
        public string DefaultRoleDisplayName { get; set; }

        [Hidden]
        public bool IsActive { get; set; }

        public string Status
        {
            get { return IsActive ? "Active" : "In Active"; }
        }

        [DisplayName("Available Roles")]
        public IEnumerable<string> Roles { get; set; }
    }
}