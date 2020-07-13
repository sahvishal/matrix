using System;
using Falcon.App.Core.Application.Attributes;
using Falcon.App.Core.Application.ViewModels;
using Falcon.App.Core.Scheduling.Enum;

namespace Falcon.App.Core.Scheduling.ViewModels
{
    [NoValidationRequired]
    public class CustomerExportListModelFilter : ModelFilterBase
    {
        public DateTime? FromDate { get; set; }
        public DateTime? ToDate { get; set; }

        public string FirstName { get; set; }
        public string LastName { get; set; }
        public long CustomerId { get; set; }

        public bool IsAttendedCustomers { get; set; }
        public bool IsNotAttendedCustomers { get; set; }

        public bool IsRetailEvent { get; set; }
        public bool IsCorporateEvent { get; set; }
        public bool IsHealthPlanEvent { get; set; }

        public bool IsPublicEvent { get; set; }
        public bool IsPrivateEvent { get; set; }

        public string MemberId { get; set; }

        public string Tag { get; set; }

        public string[] CustomTags { get; set; }

        public bool IncludeDoNotContact { get; set; }
        public bool DoNotContactOnly { get; set; }

        public EligibleFilterStatus EligibleStatus { get; set; }

        public long HealthPlanId { get; set; }

        public DateTime? AppointmentFrom { get; set; }
        public DateTime? AppointmentTo { get; set; }

        public bool OnlyRetailCustomers { get; set; }

        public long ProductTypeId { get; set; }

    }
}
