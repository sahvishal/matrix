using System.Collections.Generic;
using Falcon.App.Core.Application.ViewModels;

namespace Falcon.App.Core.Medical.ViewModels
{
    public class TemplateCriteriaEditModel : ViewModelBase
    {
        public long TemplateId { get; set; }
        public bool IsPublished { get; set; }
        public IEnumerable<ClinicalTestQualificationCriteriaEditModel> Criteria { get; set; }
    }
}