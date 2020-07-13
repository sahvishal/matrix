using System;
using Falcon.App.Core.Application.Attributes;
using Falcon.App.Core.Application.ViewModels;

namespace Falcon.App.Core.Scheduling.ViewModels
{
    [NoValidationRequired]
    public class RescheduleApplointmentListModelFilter : ModelFilterBase
    {
        public DateTime? RescheduleFrom { get; set; }
        public DateTime? RescheduleTo { get; set; }
        
        public DateTime? EventFrom { get; set; }
        public DateTime? EventTo { get; set; }

        public long CustomerId { get; set; }

        public string CustomerName { get; set; }

        public long CorporateAccountId { get; set; }

        public long HospitalPartnerId { get; set; }
    }
}
