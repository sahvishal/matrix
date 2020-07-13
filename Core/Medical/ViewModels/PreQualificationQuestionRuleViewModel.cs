using System.Collections.Generic;

namespace Falcon.App.Core.Medical.ViewModels
{
    public class PreQualificationQuestionRuleViewModel
    {
        public long QuestionId { get; set; }
        public long DependentQuestionId { get; set; }
        public string DependencyValue { get; set; }

    }
}
