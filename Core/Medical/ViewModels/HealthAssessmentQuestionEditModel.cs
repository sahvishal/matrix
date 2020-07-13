namespace Falcon.App.Core.Medical.ViewModels
{
    public class HealthAssessmentQuestionEditModel
    {
        public long QuestionId { get; set; }
        public int ControlType { get; set; }
        public string DefaultAnswer { get; set; }
        public int DisplaySequence { get; set; }
        public string Answer { get; set; }
        public string Question { get; set; }
        public long QuestionGroupId { get; set; }
    }
}
