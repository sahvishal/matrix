using System.Collections.Generic;
using Falcon.App.Core.Medical.Domain;

namespace Falcon.App.Core.Medical
{
    public interface ISurveyQuestionRepository
    {
        IEnumerable<SurveyQuestion> GetAllQuestions();
        IEnumerable<SurveyQuestion> GetAllQuestionsForTemplateId(long templateId);
    }
}
