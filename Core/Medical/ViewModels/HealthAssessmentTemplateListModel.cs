using System.Collections.Generic;
using Falcon.App.Core.Application.Attributes;
using Falcon.App.Core.Application.ViewModels;

namespace Falcon.App.Core.Medical.ViewModels
{
    public class HealthAssessmentTemplateListModel
    {
        public IEnumerable<HealthAssessmentTemplateViewModel> HealthAssessmentTemplates { get; set; }
        [IgnoreAudit]
        public PagingModel PagingModel { get; set; }
        public HealthAssessmentTemplateListModelFilter Filter { get; set; }
    }
}
