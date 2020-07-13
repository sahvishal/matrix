namespace Falcon.App.Core.Medical.Domain
{
    public class HealthAssessmentQuestionDependencyRule
    {
        public long QuestionId { get; set; }
        public long DependantQuestionId { get; set; }
        public string DependencyRule { get; set; }
    }
}
