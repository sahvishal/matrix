using Falcon.App.Core.Application.Attributes;
using Falcon.App.Core.Application.ViewModels;
using Falcon.App.Core.Scheduling.Enum;

namespace Falcon.App.Core.CallQueues.ViewModels
{
    [NoValidationRequired]
    public class UncontactedCustomersReportModelFilter : ModelFilterBase
    {       
        public long? HelathPlanId { get; set; }       
        public string[] CustomTags { get; set; }
        public EligibleFilterStatus EligibleStatus { get; set; }
    }
}
