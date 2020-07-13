using Falcon.App.Core.Application.Attributes;

namespace Falcon.App.Core.Medical.ViewModels
{
    [NoValidationRequired]
    public class FluConsentAnswerModel
    {
        public long QuestionId { get; set; }

        public string Answer { get; set; }
    }
}
