using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using Falcon.App.Core.Application.Attributes;
using Falcon.App.Core.Geo.ViewModels;
using Falcon.App.Core.ValueTypes;

namespace Falcon.App.Core.Scheduling.ViewModels
{
    public class SchedulingCustomerEditModel
    {
        [UIHint("Hidden")]
        public long Id { get; set; }

        [UIHint("Name")]
        public Name FullName { get; set; }

        [DisplayName("Email")]
        [UIHint("ExtendedTextBox")]
        public string Email { get; set; }

        [DisplayName("Best Number To Call")]
        public string HomeNumber { get; set; }

        public AddressEditModel ShippingAddress { get; set; }

        public string MarketingSource { get; set; }

        [DisplayName("Date of Birth")]
        public DateTime? DateofBirth { get; set; }

        public int? Gender { get; set; }

        [Description("between 6 and 64 characters")]
        [UIHint("Password")]
        [IgnoreAudit]
        public string Password { get; set; }

        [Description("same as password")]
        [DisplayName("Confirm Password")]
        [UIHint("Password")]
        public string ConfirmPassword { get; set; }

        public string InsuranceId { get; set; }

        public bool InsuranceIdRequired { get; set; }

        public string InsuranceIdLabel { get; set; }

        public string Ssn { get; set; }

        public bool CaptureSsn { get; set; }

        public bool EnableTexting { get; set; }

        public bool? ConfirmationToEnablTexting { get; set; }

        [DisplayName("Phone(Cell)")]
        public string PhoneCell { get; set; }

        public string UserName { get; set; }
        public bool IsRegisteringForCorporateEvent { get; set; }
        public OnlineRequestValidationModel RequestValidationModel { get; set; }

        public bool EnableVoiceMail { get; set; }

        public bool? ConfirmationToEnableVoiceMail { get; set; }
    }
}