using System.Collections.Generic;
using Falcon.App.Core.Medical.Domain;

namespace Falcon.App.Core.Medical
{
    public interface ICheckListAnswerRepository
    {
        IEnumerable<CheckListAnswer> GetAllAnswerByEventCustomerId(long eventCustomerId, int version = 1);
        int GetLatestVersion(long eventCustomerId);
        void SaveAnswer(IEnumerable<CheckListAnswer> answer);
        bool DeleteEventCustomerCheckListAnswers(long eventCustomerId);

        IEnumerable<CheckListAnswer> GetExitInterviewAnswers(long eventCustomerId);
    }
}