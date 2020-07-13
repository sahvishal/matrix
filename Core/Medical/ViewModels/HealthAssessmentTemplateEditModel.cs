using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using Falcon.App.Core.Application.ViewModels;

namespace Falcon.App.Core.Medical.ViewModels
{
    public class HealthAssessmentTemplateEditModel : ViewModelBase
    {
        [UIHint("Hidden")]
        public long Id { get; set; }
        public string Name { get; set; }

        [DisplayName("Type")]
        public long? TemplateType { get; set; }
        public bool IsDefault { get; set; }
        public bool IsPublished { get; set; }
        public bool IsActive { get; set; }
        public IEnumerable<long> SelectedQuestionIds { get; set; }
        public string Notes { get; set; }

        public long Category { get; set; }
        public bool IsNewTemplate { get; set; }

    }
}
