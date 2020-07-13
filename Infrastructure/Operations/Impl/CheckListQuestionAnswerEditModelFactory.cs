using System.Collections.Generic;
using System.Linq;
using Falcon.App.Core.Application.Attributes;
using Falcon.App.Core.Extensions;
using Falcon.App.Core.Medical.Domain;
using Falcon.App.Core.Operations;
using Falcon.App.Core.Scheduling.ViewModels;

namespace Falcon.App.Infrastructure.Operations.Impl
{
    [DefaultImplementation]
    public class CheckListQuestionAnswerEditModelFactory : ICheckListQuestionAnswerEditModelFactory
    {
        public IEnumerable<CheckListQuestionAnswerEditModel> CheckListQuestionAnswerEditModel(IEnumerable<CheckListQuestion> questions, IEnumerable<CheckListAnswer> answers, IEnumerable<CheckListGroup> groups,
            IEnumerable<ChecklistGroupQuestion> groupQuestions)
        {

            var questionCollection = new List<CheckListQuestionAnswerEditModel>();

            foreach (var groupQuestion in groupQuestions)
            {
                var checkListQuestion = questions.FirstOrDefault(x => x.Id == groupQuestion.QuestionId);
                if (checkListQuestion == null) continue;

                var group = groups.Single(x => x.Id == groupQuestion.GroupId);
                var answer = answers.IsNullOrEmpty() ? null : answers.SingleOrDefault(x => x.QuestionId == groupQuestion.QuestionId);
                var questionEditModel = CreateEditModel(checkListQuestion, answer, group, groupQuestion);
                questionCollection.Add(questionEditModel);
            }

            return questionCollection;
        }

        private CheckListQuestionAnswerEditModel CreateEditModel(CheckListQuestion question, CheckListAnswer answer, CheckListGroup group, ChecklistGroupQuestion checklistGroupQuestion)
        {
            return new CheckListQuestionAnswerEditModel
            {
                QuestionId = question.Id,
                Question = question.Question,
                ControlValue = GetControlValues(question.ControlValues, question.ControlValueDelimiter),
                Type = question.Type,
                Index = question.Index,
                GroupAlias = string.IsNullOrEmpty(group.Alias) ? string.Empty : group.Alias.ToLower().Trim(),
                GroupId = checklistGroupQuestion.GroupId,
                Answer = answer == null ? string.Empty : answer.Answer,
                ParentId = checklistGroupQuestion.ParentId,
            };
        }

        private IEnumerable<string> GetControlValues(string controlValue, string delimiter)
        {
            if (string.IsNullOrEmpty(controlValue)) return null;
            return controlValue.Split(delimiter.ToCharArray());
        }
    }
}