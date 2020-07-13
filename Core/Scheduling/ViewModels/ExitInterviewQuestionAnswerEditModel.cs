using Falcon.App.Core.Application.Attributes;

namespace Falcon.App.Core.Scheduling.ViewModels
{
    [NoValidationRequired]
    public class ExitInterviewQuestionAnswerEditModel
    {
        public long QuestionId { get; set; }
        public string Question { get; set; }
        public bool? Answer { get; set; }
        public int Index { get; set; }
    }
}