using System.Collections.Generic;
using Falcon.App.Core.Domain;

namespace Falcon.App.Core.Medical.Domain
{
    public class HealthAssessmentQuestionGroup : DomainObjectBase
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public IEnumerable<HealthAssessmentQuestion> Questions { get; set; }
        public bool IsClinicalQuestions { get; set; }
        public long? TestId { get; set; }
    }
}
