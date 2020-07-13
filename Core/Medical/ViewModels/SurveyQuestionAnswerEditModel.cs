using Falcon.App.Core.Application.Attributes;
using Falcon.App.Core.Enum;
using System.Collections.Generic;

namespace Falcon.App.Core.Medical.ViewModels
{
    [NoValidationRequired]
    public class SurveyQuestionAnswerEditModel
    {
        public long QuestionId { get; set; }
        public string Question { get; set; }
        public string Answer { get; set; }
        public IEnumerable<string> ControlValue { get; set; }
        public DisplayControlType Type { get; set; }
        public int Index { get; set; }
        public long? ParentId { get; set; }
    }
}
