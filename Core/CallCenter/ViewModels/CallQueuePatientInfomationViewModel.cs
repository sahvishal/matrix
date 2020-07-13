using System;
using Falcon.App.Core.Geo.ViewModels;
using Falcon.App.Core.Medical.ViewModels;
using Falcon.App.Core.Users.Enum;
using Falcon.App.Core.ValueTypes;

namespace Falcon.App.Core.CallCenter.ViewModels
{
    public class CallQueuePatientInfomationViewModel
    {
        public long CallQueueCustomerId { get; set; }

        public long? ProspectCustomerId { get; set; }
        public long UserId { get; set; }

        public long? CustomerId { get; set; }

        public string FirstName { get; set; }
        public string LastName { get; set; }
        public Gender Gender { get; set; }

        public DateTime? DateOfBirth { get; set; }
        public string ContactType { get; set; }
        public string ProspectTag { get; set; }
        public string Email { get; set; }
        public string AlternateEmail { get; set; }
        public string HicnNumber { get; set; }
        public string MbiNumber { get; set; }
        public string MemberId { get; set; }
        public string GroupName { get; set; }
        public bool? IsEligible { get; set; }
        public string CustomCorporateTags { get; set; }
        public AddressViewModel AddressViewModel { get; set; }

        public PhoneNumber CallBackPhoneNumber { get; set; }
        public PhoneNumber OfficePhoneNumber { get; set; }
        public PhoneNumber MobilePhoneNumber { get; set; }

        public PrimaryCarePhysicianViewModel PrimaryCarePhysician { get; set; }

        public long ActivityId { get; set; }
        public string Activity { get; set; }

        public PhoneNumber HealthPlanPhoneNumber { get; set; }

        public bool HasMammo { get; set; }
        public bool MammoTestAsPreApproved { get; set; }

        public string CallCenterScriptUrl { get; set; }

        public string HealthPlan { get; set; }

        public string CallBackPhoneNumberUrl { get; set; }
        public string OfficePhoneNumberUrl { get; set; }
        public string MobilePhoneNumberUrl { get; set; }

        public long PhoneHomeConsent { get; set; }
        public long PhoneOfficeConsent { get; set; }
        public long PhoneCellConsent { get; set; }

        public bool EnableEmail { get; set; }
        public string AcesId { get; set; }
        public string Product { get; set; }
    }
}