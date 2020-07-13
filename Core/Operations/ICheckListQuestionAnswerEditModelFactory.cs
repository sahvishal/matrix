using System.Collections.Generic;
using Falcon.App.Core.Medical.Domain;
using Falcon.App.Core.Scheduling.ViewModels;

namespace Falcon.App.Core.Operations
{
    public interface ICheckListQuestionAnswerEditModelFactory
    {
        IEnumerable<CheckListQuestionAnswerEditModel> CheckListQuestionAnswerEditModel(IEnumerable<CheckListQuestion> questions, IEnumerable<CheckListAnswer> answers, IEnumerable<CheckListGroup> groups,
            IEnumerable<ChecklistGroupQuestion> groupQuestions);
    }
}