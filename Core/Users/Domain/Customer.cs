using System;
using Falcon.App.Core.Application.Attributes;
using Falcon.App.Core.Domain.MedicalVendors;
using Falcon.App.Core.Geo.Domain;
using Falcon.App.Core.Users.Enum;
using Falcon.App.Core.ValueTypes;

namespace Falcon.App.Core.Users.Domain
{
    public class Customer : User
    {
        public long CustomerId { get; set; }
        [IgnoreAudit]
        public string DisplayCode { get; set; }
        public Height Height { get; set; }
        public Weight Weight { get; set; }
        public Gender Gender { get; set; }
        public Race Race { get; set; }
        public Address BillingAddress { get; set; }
        public string MarketingSource { get; set; }
        public PrimaryCarePhysician PrimaryCarePhysician { get; set; }
        public long? AddedByRoleId { get; set; }
        public DateTime DateCreated { get; set; }
        public DateTime DateModified { get; set; }

        public string Employer { get; set; }
        public string EmergencyContactName { get; set; }
        public string EmergencyContactRelationship { get; set; }
        public PhoneNumber EmergencyContactPhoneNumber { get; set; }

        public long? DoNotContactTypeId { get; set; }
        public long? DoNotContactReasonId { get; set; }
        public long? DoNotContactReasonNotesId { get; set; }
        public bool RequestForNewsLetter { get; set; }
        public string LastScreeningDate { get; set; }

        public string EmployeeId { get; set; }
        public string InsuranceId { get; set; }

        public string PreferredLanguage { get; set; }
        public long? BestTimeToCall { get; set; }

        public decimal? Waist { get; set; }

        public string Tag { get; set; }
        public string Hicn { get; set; }
        public bool EnableTexting { get; set; }
        public string MedicareAdvantageNumber { get; set; }
        public string MedicareAdvantagePlanName { get; set; }

        //public bool? IsEligible { get; set; }
        public long? LabId { get; set; }
        public long? LanguageId { get; set; }
        public string Copay { get; set; }
        public string Lpi { get; set; }
        public string Market { get; set; }
        public string Mrn { get; set; }
        public string GroupName { get; set; }
        public bool IsIncorrectPhoneNumber { get; set; }

        public bool IsLanguageBarrier { get; set; }

        public bool EnableVoiceMail { get; set; }

        public string AdditionalField1 { get; set; }
        public string AdditionalField2 { get; set; }
        public string AdditionalField3 { get; set; }
        public string AdditionalField4 { get; set; }

        public long? ActivityId { get; set; }

        public DateTime? DoNotContactUpdateDate { get; set; }
        //public bool IsDuplicate { get; set; }
        public long? DoNotContactUpdateSource { get; set; }

        public DateTime? LanguageBarrierMarkedDate { get; set; }
        public DateTime? IncorrectPhoneNumberMarkedDate { get; set; }
        public long? PreferredContactType { get; set; }

        public bool? IsSubscribed { get; set; }
        public string AcesId { get; set; }

        public string Mbi { get; set; }

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

        public long? MemberUploadSourceId { get; set; }
        public bool ActivityTypeIsManual { get; set; }
        public long? ProductTypeId { get; set; }

        public string AcesClientId { get; set; }


        public Customer()
        { }

        public Customer(long userId)
            : base(userId)
        { }

        public Customer(long userId, long customerId)
            : base(userId)
        {
            CustomerId = customerId;
        }
    }
}