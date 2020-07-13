using Falcon.App.Core.Application.Attributes;

namespace Falcon.App.Core.Medicare.ViewModels
{
    [NoValidationRequired]
    public class MedicareCheckListQuestionViewModel
    {
        public long QuestionId { get; set; }
        public string Answer { get; set; }
    }
}
