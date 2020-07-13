using System;
using Falcon.App.Core.Application.Attributes;
using Falcon.App.Core.Application.ViewModels;
using Falcon.App.Core.Scheduling.Enum;
using Falcon.App.Core.CallCenter.Enum;

namespace Falcon.App.Core.Scheduling.ViewModels
{
    [NoValidationRequired]
    public class MemberStatusListModelFilter : ModelFilterBase
    {
        public MemberStatusListModelFilter()
        {
            Year = DateTime.Now.Year;
        }

        public DateTime FromDate
        {
            get
            {
                return Year > 0 ? new DateTime(Year, 1, 1) : new DateTime(DateTime.Now.Year, 1, 1);
            }
        }

        public DateTime ToDate
        {
            get
            {
                return Year > 0 ? new DateTime(Year, 12, 31) : new DateTime(DateTime.Now.Year, 12, 31);
            }
        }

        public string FirstName { get; set; }
        public string LastName { get; set; }
        public long CustomerId { get; set; }

        public bool IsAttendedCustomers { get; set; }
        public bool IsNotAttendedCustomers { get; set; }

        public bool IsPublicEvent { get; set; }
        public bool IsPrivateEvent { get; set; }

        public string MemberId { get; set; }

        public string Tag { get; set; }

        public string[] CustomTags { get; set; }

        public bool IncludeDoNotContact { get; set; }
        public bool DoNotContactOnly { get; set; }

        public EligibleFilterStatus EligibleStatus { get; set; }

        public long HealthPlanId { get; set; }

        public int Year { get; set; }

        public TargetMemberFilterStatus TargetMemberStatus { get; set; }

        public CallAttemptFilterStatus CallAttemptFilter { get; set; }

        public bool ConsiderEligibiltyFromHistory { get; set; }

        public long ProductTypeId { get; set; }
    }
}