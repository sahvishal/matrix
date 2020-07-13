
using System;
using Falcon.App.Core.Application.Attributes;
using Falcon.App.Core.Application.ViewModels;
namespace Falcon.App.Core.CallQueues.ViewModels
{
    [NoValidationRequired]
    public class CallQueueExcludedCustomerReportModelFilter : ModelFilterBase
    {
        public long HealthPlanId { get; set; }
        public long? CustomerId { get; set; }
        public string MemberId { get; set; }
        public string ZipCode { get; set; }
        public bool IsEligible { get; set; }
        public bool DoNotContact { get; set; }
        public bool BookedAppointment { get; set; }
        public bool InCorrectPhoneNumber { get; set; }
        public string[] CustomTags { get; set; }
        public long CampaignId { get; set; }
        public DateTime? DirectMailDate { get; set; }

    }
}
