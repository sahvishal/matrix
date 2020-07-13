using Falcon.App.Core.Application.Attributes;

namespace Falcon.App.Core.Medical.ViewModels
{
    [NoValidationRequired]
    public class HealthAssessmentTemplateListModelFilter
    {
        public string Name { get; set; }
        public bool Active { get; set; }
        public bool Inactive { get; set; }
        public int TemplateType { get; set; }
        public long Category { get; set; }
    }
}
