using System.Collections.Generic;
using Falcon.App.Core.Medical.ViewModels;
using Falcon.App.Core.Scheduling.ViewModels;

namespace Falcon.App.Core.Medical
{
    public interface IExitInterviewService
    {
        IEnumerable<ExitInterviewQuestionAnswerEditModel> GetQuestions(long eventCustomerId);

        bool Save(ExitInterviewAnswerModel model, long orgRoleUserId);
    }
}
