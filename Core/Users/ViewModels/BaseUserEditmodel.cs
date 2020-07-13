using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using Falcon.App.Core.Application.Attributes;
using Falcon.App.Core.Application.ViewModels;
using Falcon.App.Core.Geo.ViewModels;
using Falcon.App.Core.ValueTypes;

namespace Falcon.App.Core.Users.ViewModels
{
    public class BaseUserEditModel : ViewModelBase
    {
        [UIHint("Hidden")]
        public long Id { get; set; }

        [UIHint("Name")]
        public Name FullName { get; set; }

        [Description("5-100 characters")]
        [DisplayName("User Name")]
        [UIHint("ExtendedTextBox")]
        public string UserName { get; set; }


        [DisplayName("Email")]
        [UIHint("ExtendedTextBox")]
        public string Email { get; set; }


        [Description("between 8 and 64 characters")]
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

        [DisplayName("Is Account Locked")]
        [UIHint("CheckBox")]
        public bool IsLocked { get; set; }

        [DisplayName("Override OTP Setting")]
        [UIHint("CheckBox")]
        public bool OverRideTwoFactorAuthrequired { get; set; }

        [DisplayName("Is OTP required for Login")]
        [UIHint("CheckBox")]
        public bool IsTwoFactorAuthrequired { get; set; }

        public DateTime? LastLoggedInAt { get; set; }

        [IgnoreAudit]
        public string Ssn { get; set; }

        [Description("3-16 characters")]
        [DisplayName("Employee ID Number")]
        [UIHint("ExtendedTextBox")]
        public string EmployeeId { get; set; }
    }
}