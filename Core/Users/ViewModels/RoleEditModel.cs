using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using Falcon.App.Core.Application.ViewModels;

namespace Falcon.App.Core.Users.ViewModels
{
    public class RoleEditModel : ViewModelBase
    {
        public long OrganizationTypeId { get; set; }
        public long Id { get; set; }
        public string Name { get; set; }
        public string ShortName { get; set; }
        public DateTime DateCreated { get; set; }
        public DateTime DateModified { get; set; }
        public string Description { get; set; }
        public string DefaultPage { get; set; }
        public string ShellType { get; set; }
        public long ParentId { get; set; }
        public bool IsSystemRole { get; set; }
        [DisplayName("Is OTP required for Login")]
        [UIHint("CheckBox")]
        public bool IsTwoFactorAuthrequired { get; set; }
        [DisplayName("Reset All Overrides")]
        [UIHint("CheckBox")]
        public bool ResetAllOverrides { get; set; }
        [DisplayName("Is pin required for downloads")]
        [UIHint("CheckBox")]
        public bool IsPinRequired { get; set; }
    }
}