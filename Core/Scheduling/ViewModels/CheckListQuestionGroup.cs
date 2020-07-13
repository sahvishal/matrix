using System.Collections.Generic;
using Falcon.App.Core.Application.Attributes;
using Falcon.App.Core.Medical.Enum;

namespace Falcon.App.Core.Scheduling.ViewModels
{
    [NoValidationRequired]
    public class CheckListQuestionGroup
    {
        public long Id { get; set; }
        public string Name { get; set; }
        public CheckListGroupType Type { get; set; }
        public IEnumerable<CheckListQuestionAnswerEditModel> AnswerEditModels { get; set; }
    }
}