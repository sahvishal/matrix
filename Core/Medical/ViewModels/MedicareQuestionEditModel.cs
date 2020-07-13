using System.Collections.Generic;
using Falcon.App.Core.Enum;
using Falcon.App.Core.Medical.Domain;

namespace Falcon.App.Core.Medical.ViewModels
{
    public class MedicareQuestionEditModel
    {
        public long Id { get; set; }
        public string Question { get; set; }

        public DisplayControlType ControlType { get; set; }
        public IEnumerable<string> ControlValues { get; set; }
        public long? ParentQuestionId { get; set; }
        public bool IsDefault { get; set; }
        public string DefaultValue { get; set; }
        public IEnumerable<MedicareQuestionDependencyRule> DependencyRules { get; set; }
        public IEnumerable<MedicareQuestionsRemark> MedicareQuestionsRemarks { get; set; }
        public IEnumerable<MedicareGroupDependencyRule> MedicareGroupDependencyRules { get; set; }
        
        public string Answer { get; set; }
    }
}
