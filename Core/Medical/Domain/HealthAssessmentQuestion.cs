using System.Collections.Generic;
using Falcon.App.Core.Domain;
using Falcon.App.Core.Enum;

namespace Falcon.App.Core.Medical.Domain
{
    public class HealthAssessmentQuestion : DomainObjectBase
    {
        public DisplayControlType ControlType { get; set; }
        public IEnumerable<string> ControlValues { get; set; }
        public int DisplaySequence { get; set; }
        public string DefaultValue { get; set; }
        public string Label { get; set; }
        public string Question { get; set; }
        public long QuestionGroupId { get; set; }
        public long? ParentQuestionId { get; set; }
        public bool? IsForFemale { get; set; }
        public bool IsActive { get; set; }
    }
}