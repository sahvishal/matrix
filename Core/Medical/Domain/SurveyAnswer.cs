using Falcon.App.Core.Domain;

namespace Falcon.App.Core.Medical.Domain
{
    public class SurveyAnswer : DomainObjectBase
    {
        public long QuestionId { get; set; }
        public string Answer { get; set; }
        public int Version { get; set; }
        public bool IsActive { get; set; }
        public DataRecorderMetaData DataRecorderMetaData { get; set; }
    }
}