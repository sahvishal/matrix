using Falcon.App.Core.Medical.Domain;
using System.Collections.Generic;

namespace Falcon.App.Core.Medical
{
    public interface ISurveyAnswerRepository
    {
        IEnumerable<SurveyAnswer> GetSurveyAnswerByEventCustomerId(long eventCustomerId);
        int GetLatestVersion(long eventCustomerId);
        void SaveAnswer(IEnumerable<SurveyAnswer> answer);
    }
}
