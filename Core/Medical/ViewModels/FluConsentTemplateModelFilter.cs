using Falcon.App.Core.Application.Attributes;
using Falcon.App.Core.Application.ViewModels;

namespace Falcon.App.Core.Medical.ViewModels
{
    [NoValidationRequired]
    public class FluConsentTemplateModelFilter : ModelFilterBase
    {
        public string Name { get; set; }
        public bool Active { get; set; }
        public long HealthPlanId { get; set; }
    }
}