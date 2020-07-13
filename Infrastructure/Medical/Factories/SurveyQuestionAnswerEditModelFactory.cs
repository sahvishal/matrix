using Falcon.App.Core.Application.Attributes;
using Falcon.App.Core.Extensions;
using Falcon.App.Core.Medical;
using Falcon.App.Core.Medical.Domain;
using Falcon.App.Core.Medical.ViewModels;
using System.Collections.Generic;
using System.Linq;

namespace Falcon.App.Infrastructure.Medical.Factories
{
    [DefaultImplementation]
    public class SurveyQuestionAnswerEditModelFactory : ISurveyQuestionAnswerEditModelFactory
    {
        public IEnumerable<SurveyQuestionAnswerEditModel> SurveyQuestionAnswerEditModel(IEnumerable<SurveyQuestion> questions, IEnumerable<SurveyAnswer> answers)
        {
            var questionCollection = new List<SurveyQuestionAnswerEditModel>();

            if (questions.IsNullOrEmpty()) return questionCollection;

            foreach (var ques in questions)
            {
                var question = questions.First(x => x.Id == ques.Id);

                var answer = answers.IsNullOrEmpty() ? null : answers.SingleOrDefault(x => x.QuestionId == question.Id);
                var questionEditModel = new SurveyQuestionAnswerEditModel
                {
                    QuestionId = question.Id,
                    Question = question.Question,
                    ControlValue = GetControlValues(question.ControlValues, question.ControlValueDelimiter),
                    Type = question.Type,
                    Index = question.Index,
                    Answer = answer == null ? string.Empty : answer.Answer,
                    ParentId = question.ParentId,
                };
                questionCollection.Add(questionEditModel);
            }

            return questionCollection;
        }

        private IEnumerable<string> GetControlValues(string controlValue, string delimiter)
        {
            if (string.IsNullOrEmpty(controlValue)) return null;
            return controlValue.Split(delimiter.ToCharArray());
        }
    }
}
