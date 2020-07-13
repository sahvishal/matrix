using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using Falcon.App.Core.Application.Attributes;
using Falcon.App.Core.Application.ViewModels;
using Falcon.App.Core.Enum;
using Falcon.App.Core.Geo.ViewModels;
using Falcon.App.Core.ValueTypes;

namespace Falcon.App.Core.Users.ViewModels
{
    public class ProfileEditModel : ViewModelBase
    {

        [UIHint("Hidden")]
        public long Id { get; set; }

        [UIHint("Hidden")]
        public Roles DefaultRole { get; set; }

        [UIHint("Hidden")]
        public string UserName { get; set; }
        
        [UIHint("Name")]
        public Name FullName { get; set; }

        [DisplayName("Email")]
        [UIHint("ExtendedTextBox")]
        public string Email { get; set; }


        [Description("between 8 and 64 characters, or leave blank if you don't want to change it.")]
        [UIHint("Password")]
        [IgnoreAudit]
        public string Password { get; set; }

        [Description("same as password")]
        [DisplayName("Confirm Password")]
        [UIHint("Password")]
        [IgnoreAudit]
        public string ConfirmPassword { get; set; }


        [DisplayName("Office Phone Number")]
        public PhoneNumber OfficeNumber { get; set; }

        [DisplayName("Cell Phone Number")]
        public PhoneNumber CellNumber { get; set; }

        [DisplayName("Home Phone Number")]
        public PhoneNumber HomeNumber { get; set; }

        [DisplayName("Date of Birth")]
        public DateTime? DateOfBirth { get; set; }

        public AddressEditModel Address { get; set; }

        [UIHint("Hidden")]
        public DateTime DateCreated { get; set; }

        [UIHint("Hidden")]
        public long CreatedByOrgRoleUserId{ get; set; }

        [UIHint("Hidden")]
        public string HintQuestion { get; set; }

        [UIHint("Hidden")]
        public string HintAnswer { get; set; }

        [UIHint("Hidden")]
        public string Ssn { get; set; }

        [DisplayName("Sms")]
        [UIHint("CheckBox")] 
        public bool UseSms { get; set; }

        [DisplayName("Email")]
        [UIHint("CheckBox")] 
        public bool UseEmail { get; set; }

        [DisplayName("Google Authenticator")]
        [UIHint("CheckBox")] 
        public bool UseAuthenticator { get; set; }

        public bool ChangePassword { get; set; }
        public bool IsOtpBySmsEnabled { get; set; }
        public bool IsOtpByEmailEnabled { get; set; }
        public bool IsOtpByAppEnabled { get; set; }

        public bool IsPinRequiredForRole { get; set; }

        [DisplayName("Download File Pin")]
        public string DownloadFilePin { get; set; }

        [IgnoreAudit]
        public string EncodedSecret { get; set; }
        [IgnoreAudit]
        public string Secret { get; set; }

        [DisplayName("Profile Pin")]
        public string TechnicianPin { get; set; }
    }
}