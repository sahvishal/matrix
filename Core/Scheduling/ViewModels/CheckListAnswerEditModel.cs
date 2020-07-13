using System.Collections.Generic;
using Falcon.App.Core.Application.Attributes;

namespace Falcon.App.Core.Scheduling.ViewModels
{
    [NoValidationRequired]
    public class CheckListAnswerEditModel
    {
        public long EventCustomerId { get; set; }
        public IEnumerable<CheckListQuestionAnswerEditModel> Answers { get; set; }
        public int Version { get; set; }
    }
}