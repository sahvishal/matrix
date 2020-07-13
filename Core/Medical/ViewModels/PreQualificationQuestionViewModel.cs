using Falcon.App.Core.Application.Attributes;
using Falcon.App.Core.Medical.Domain;
using System.Collections.Generic;

namespace Falcon.App.Core.Medical.ViewModels
{
    [NoValidationRequired]
    public class PreQualificationQuestionViewModel
    {
        public long TestId { get; set; }
        public string TestName { get; set; }
        public long TemplateId { get; set; }
        public List<PreQualificationQuestion> Questions { get; set; }
        public List<PreQualificationQuestionRule> QuestionRule { get; set; } 
    }
}
