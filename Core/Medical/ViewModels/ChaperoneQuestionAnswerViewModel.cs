using Falcon.App.Core.Medical.Enum;
using System.Collections.Generic;

namespace Falcon.App.Core.Medical.ViewModels
{
    public class ChaperoneQuestionAnswerViewModel
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
