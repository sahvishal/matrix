using System;
using Falcon.App.Core.Enum;
using Falcon.App.Core.Geo.Domain;
using Falcon.App.Core.Users.Enum;
using Falcon.App.Core.ValueTypes;

namespace Falcon.App.Core.Users.Domain
{
    public class CustomerProfileHistory
    {
        public long CustomerId { get; set; }
        public Name Name { get; set; }
        public Address HomeAddress { get; set; }
        public PhoneNumber HomePhoneNumber { get; set; }
        public PhoneNumber OfficePhoneNumber { get; set; }
        public PhoneNumber MobilePhoneNumber { get; set; }

        public Email Email { get; set; }
        public Email AlternateEmail { get; set; }
        public string Picture { get; set; }
        public DateTime? DateOfBirth { get; set; }
        public Roles DefaultRole { get; set; }
        public string PhoneOfficeExtension { get; set; }

        public string Ssn { get; set; }

        public long DisplayCode { get; set; }
        public Address BillingAddress { get; set; }
        public Height Height { get; set; }
        public Weight Weight { get; set; }
        public Gender Gender { get; set; }
        public Race Race { get; set; }

        //TrackingMarketingID
        public string MarketingSource { get; set; }
        public long? AddedByRoleId { get; set; }
        public string Employer { get; set; }
        public string EmergencyContactName { get; set; }
        public string EmergencyContactRelationship { get; set; }
        public PhoneNumber EmergencyContactPhoneNumber { get; set; }


        public long? DoNotContactReasonId { get; set; }
        public long? DoNotContactReasonNotesId { get; set; }
        public bool RequestForNewsLetter { get; set; }
        public string EmployeeId { get; set; }
        public string InsuranceId { get; set; }

        public string PreferredLanguage { get; set; }
        public long? BestTimeToCall { get; set; }

        public decimal? Waist { get; set; }
        public string Hicn { get; set; }
        public bool EnableTexting { get; set; }
        public string MedicareAdvantageNumber { get; set; }
        public string Tag { get; set; }
        public string MedicareAdvantagePlanName { get; set; }

        public bool? IsEligible { get; set; }
        public long? LanguageId { get; set; }
        public long? LabId { get; set; }
        public string Copay { get; set; }
        public string Lpi { get; set; }
        public string Market { get; set; }
        public string Mrn { get; set; }
        public string GroupName { get; set; }
        public bool IsIncorrectPhoneNumber { get; set; }

        public bool IsLanguageBarrier { get; set; }
        public long? DoNotContactTypeId { get; set; }
        public bool EnableVoiceMail { get; set; }

        public string AdditionalField1 { get; set; }
        public string AdditionalField2 { get; set; }
        public string AdditionalField3 { get; set; }
        public string AdditionalField4 { get; set; }
        public long? ActivityId { get; set; }

        public DateTime? DoNotContactUpdateDate { get; set; }
        public DateTime DateCreated { get; set; }
        public long CreatedBy { get; set; }

        public long? DoNotContactUpdateSource { get; set; }

        public long? IsSubscribed { get; set; }

        public DateTime? LanguageBarrierMarkedDate { get; set; }
        public DateTime? IncorrectPhoneNumberMarkedDate { get; set; }
        public long? PreferredContactType { get; set; }

        public string Mbi { get; set; }
        public string AcesId { get; set; }

        public long PhoneHomeConsentId { get; set; }
        public long PhoneCellConsentId { get; set; }
        public long PhoneOfficeConsentId { get; set; }
        public DateTime? PhoneHomeConsentUpdateDate { get; set; }
        public DateTime? PhoneCellConsentUpdateDate { get; set; }
        public DateTime? PhoneOfficeConsentUpdateDate { get; set; }

        public string BillingMemberId { get; set; }
        public string BillingMemberPlan { get; set; }
        public int? BillingMemberPlanYear { get; set; }

        public bool EnableEmail { get; set; }
        public DateTime? EnableEmailUpdateDate { get; set; }

        public long MergedCustomerId { get; set; }
        public int? EligibilityForYear { get; set; }
        public bool? IsWarmTransfer { get; set; }
        public int? WarmTransferYear { get; set; }
        public long? MemberUploadSourceId { get; set; }
        public bool ActivityTypeIsManual { get; set; }
        public int? TargetedYear { get; set; }
        public bool? IsTargeted { get; set; }
        public long? ProductTypeId { get; set; }
    }
}
