using Falcon.App.Core.Application.Attributes;
using Falcon.App.Core.Application.ViewModels;

namespace Falcon.App.Core.Scheduling.ViewModels
{
    [NoValidationRequired]
    public class CorporateEventCustomerModelFilter : ModelFilterBase
    {
        public long EventId { get; set; }
    }
}
