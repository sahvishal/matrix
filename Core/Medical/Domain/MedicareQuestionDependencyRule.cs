using Falcon.App.Core.Domain;

namespace Falcon.App.Core.Medical.Domain
{
    public class MedicareQuestionDependencyRule : DomainObjectBase
    {
        public long QuestionId { get; set; }
        public long DependentQuestionId { get; set; }
        public string DependencyValue { get; set; }
    }
}