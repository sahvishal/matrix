using System.Collections.Generic;
using Falcon.App.Core.Domain;
using Falcon.App.Core.Enum;

namespace Falcon.App.Core.Medical.Domain
{
    public class MedicareQuestion : DomainObjectBase
    {
        public long GroupId { get; set; }
        public string Question { get; set; }

        public DisplayControlType ControlType { get; set; }
        public IEnumerable<string> ControlValues { get; set; }

        public bool IsActive { get; set; }
        public bool IsRequired { get; set; }
        public int DisplaySequence { get; set; }
        public long? ParentQuestionId { get; set; }
        public bool IsDefault { get; set; }
        public string DefaultValue { get; set; }

        public IEnumerable<MedicareQuestionDependencyRule> DependencyRules { get; set; }
        public IEnumerable<MedicareQuestionsRemark> MedicareQuestionsRemarks { get; set; }
        public IEnumerable<MedicareGroupDependencyRule> MedicareGroupDependencyRules { get; set; }
    }
}
