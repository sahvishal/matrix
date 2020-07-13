using Falcon.App.Core.Application.Attributes;

namespace Falcon.App.Core.Medical.ViewModels
{
    [NoValidationRequired]
    public class ExitInterviewAnswerSignatureModel
    {
        public long QuestionId { get; set; }

        public bool Answer { get; set; }
    }
}
