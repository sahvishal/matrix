using Falcon.App.Core.Application.Attributes;
using Falcon.App.Core.Application.ViewModels;

namespace Falcon.App.Core.CallQueues.ViewModels
{
    [NoValidationRequired]
    public class CustomerWithNoEventsInAreaReportModelFilter : ModelFilterBase
    {
        public long AccountId { get; set; }
        public long? CustomerId { get; set; }
        public string MemberId { get; set; }
        public string ZipCode { get; set; }
        public string[] CustomTags { get; set; }
        public int ZipRangeInMiles { get; set; }
    }
}
