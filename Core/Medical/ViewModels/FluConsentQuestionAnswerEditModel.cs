using System.Collections.Generic;
using Falcon.App.Core.Medical.Enum;

namespace Falcon.App.Core.Medical.ViewModels
{
    public class FluConsentQuestionAnswerEditModel
    {
        public long QuestionId { get; set; }
        public string Question { get; set; }
        public string Answer { get; set; }
        public IEnumerable<string> ControlValue { get; set; }
        public CheckListQuestionType Type { get; set; }
        public long Index { get; set; }
        public long? ParentId { get; set; }
    }
}
