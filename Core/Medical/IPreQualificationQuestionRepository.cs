using Falcon.App.Core.Medical.Domain;
using System.Collections.Generic;

namespace Falcon.App.Core.Medical
{
    public interface IPreQualificationQuestionRepository
    {
        IEnumerable<PreQualificationQuestion> GetByTestId(long testId);
        IEnumerable<PreQualificationQuestion> GetByQuestionIds(long[] questionIds);
        IEnumerable<PreQualificationQuestion> GetAllQuestions();
        IEnumerable<PreQualificationQuestion> GetQuestionsByTemplateIds(long[] ids);
    }
}
