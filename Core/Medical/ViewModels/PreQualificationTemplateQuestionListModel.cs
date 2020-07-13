using System.Collections.Generic;
using Falcon.App.Core.Application.Attributes;

namespace Falcon.App.Core.Medical.ViewModels
{
    [NoValidationRequired]
    public class PreQualificationTemplateQuestionListModel
    {
        public long TestId { get; set; }
        public string TestName { get; set; }
        public long TemplateId { get; set; }
        public List<QuestionViewModel> Questions { get; set; }
        public List<PreQualificationQuestionRuleViewModel> DependencyRule { get; set; }
    }
}
