using Falcon.App.Core.Application.Attributes;
using Falcon.App.Core.Domain;

namespace Falcon.App.Core.Medical.Domain
{
    public class HealthAssessmentAnswer
    {
        public long QuestionId { get; set; }
        public long CustomerId { get; set; }
        public string Answer { get; set; }
        [IgnoreAudit]
        public DataRecorderMetaData DataRecorderMetaData { get; set; }
        public long EventCustomerId { get; set; }
    }
}