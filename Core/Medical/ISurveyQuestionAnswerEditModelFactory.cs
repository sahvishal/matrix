using Falcon.App.Core.Medical.Domain;
using Falcon.App.Core.Medical.ViewModels;
using System.Collections.Generic;

namespace Falcon.App.Core.Medical
{
    public interface ISurveyQuestionAnswerEditModelFactory
    {
        IEnumerable<SurveyQuestionAnswerEditModel> SurveyQuestionAnswerEditModel(IEnumerable<SurveyQuestion> questions, IEnumerable<SurveyAnswer> answers);
    }
}
