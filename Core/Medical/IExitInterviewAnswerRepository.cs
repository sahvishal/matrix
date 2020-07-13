using System.Collections.Generic;
using Falcon.App.Core.Medical.Domain;

namespace Falcon.App.Core.Medical
{
    public interface IExitInterviewAnswerRepository
    {
        IEnumerable<ExitInterviewAnswer> GetAllAnswerByEventCustomerId(long eventCustomerId, int version = 1);

        int GetLatestVersion(long eventCustomerId);

        void SaveAnswer(IEnumerable<ExitInterviewAnswer> answers);

        IEnumerable<ExitInterviewAnswer> GetByEventCustomerId(long eventCustomerId);
    }
}
