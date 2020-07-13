using Falcon.App.Core.Users.Enum;
using Falcon.App.Core.ValueTypes;

namespace Falcon.App.Core.Users.ViewModels
{
    public class CustomerEditModel
    {
        public long CustomerId { get; set; }
        public Height Height { get; set; }
        public Weight Weight { get; set; }
        public Gender Gender { get; set; }
        public Race Race { get; set; }
        public string MarketingSource { get; set; }
        public long? AddedByRoleId { get; set; }

        public string Employer { get; set; }
        public string EmergencyContactName { get; set; }
        public string EmergencyContactRelationship { get; set; }
        public PhoneNumber EmergencyContactPhoneNumber { get; set; }
        public string LastScreeningDate { get; set; }
        public string EmployeeId { get; set; }
        public string InsuranceId { get; set; }

        public string PreferredLanguage { get; set; }
        public long? BestTimeToCall { get; set; }

        public decimal? Waist { get; set; }
        public bool EnableTexting { get; set; }
        public bool EnableVoiceMail { get; set; }
        public string Hicn { get; set; }
        public string AcesId { get; set; }
    }
}