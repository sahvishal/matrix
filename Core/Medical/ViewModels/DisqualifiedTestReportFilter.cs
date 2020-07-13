using Falcon.App.Core.Application.Attributes;
using Falcon.App.Core.Application.ViewModels;

namespace Falcon.App.Core.Medical.ViewModels
{
    [NoValidationRequired]
    public class DisqualifiedTestReportFilter : ModelFilterBase
    {
        public long? CustomerId { get; set; }
        public long TestId { get; set; }
        public long AccountId { get; set; }
        public long? EventId { get; set; }
    }
}
