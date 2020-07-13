using System.Collections.Generic;
using Falcon.App.Core.Application.Attributes;
using Falcon.App.Core.Medical.Enum;

namespace Falcon.App.Core.Scheduling.ViewModels
{
    [NoValidationRequired]
    public class CheckListQuestionAnswerEditModel
    {
        public long QuestionId { get; set; }
        public string Question { get; set; }
        public string Answer { get; set; }
        public IEnumerable<string> ControlValue { get; set; }
        public CheckListQuestionType Type { get; set; }
        public int Index { get; set; }
        public string GroupAlias { get; set; }
        public long GroupId { get; set; }
        public long? ParentId { get; set; }
    }
}