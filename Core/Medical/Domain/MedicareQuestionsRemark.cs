using Falcon.App.Core.Domain;

namespace Falcon.App.Core.Medical.Domain
{
    public class MedicareQuestionsRemark : DomainObjectBase
    {
        public long QuestionId { get; set; }
        public string QuestionValue { get; set; }

        public long? DependentQuestionId { get; set; }
        public string DependentQuestionValue { get; set; }

        public long? CombinedQuestionId { get; set; }
        public string CombinedQuestionValue { get; set; }

        public bool IsDefault { get; set; }
        public string Remarks { get; set; }
    }
}
