using Falcon.App.Core.Application.Attributes;

namespace Falcon.App.Core.Medical.ViewModels
{
    [NoValidationRequired]
    public class CheckListTemplateModelFilter
    {
        public string Name { get; set; }
        public bool Active { get; set; }
        public bool Inactive { get; set; }
        public long HealthPlanId { get; set; }
        public long CheckListTypeId { get; set; }
    }
}