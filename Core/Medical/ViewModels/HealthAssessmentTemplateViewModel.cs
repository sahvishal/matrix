using System.Collections.Generic;

namespace Falcon.App.Core.Medical.ViewModels
{
    public class HealthAssessmentTemplateViewModel
    {
        public long Id { get; set; }
        public string Name { get; set; }
        public string TemplateType { get; set; }
        public bool IsPublished { get; set; }
        public bool IsActive { get; set; }
        public bool IsDefault { get; set; }
        public IEnumerable<ClinicalTestQualificationCriteriaViewModel> Criterias { get; set; }
    }
}
