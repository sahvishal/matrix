using System.Collections.Generic;
using Falcon.App.Core.Medical.Domain;

namespace Falcon.App.Core.Medical
{
    public interface ICheckListQuestionRepository
    {
        IEnumerable<CheckListQuestion> GetAllQuestions();
        /*IEnumerable<CheckListQuestion> GetQuestionByGroupId(long groupId);
        IEnumerable<CheckListQuestion> GetQuestionByGroupIds(IEnumerable<long> groupIds);*/
        IEnumerable<CheckListQuestion> GetAllQuestionsForTemplateId(long templateId);
    }
}