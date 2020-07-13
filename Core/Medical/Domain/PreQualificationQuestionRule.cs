using Falcon.App.Core.Domain;

namespace Falcon.App.Core.Medical.Domain
{
    public class PreQualificationQuestionRule : DomainObjectBase
    {
        public long QuestionId { get; set; }
        public long DependentQuestionId { get; set; }
        public string DependencyValue { get; set; }
    }
}
