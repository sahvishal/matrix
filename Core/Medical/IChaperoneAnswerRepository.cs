using Falcon.App.Core.Medical.Domain;
using System.Collections.Generic;

namespace Falcon.App.Core.Medical
{
    public interface IChaperoneAnswerRepository
    {
        int GetLatestVersion(long eventCustomerId);

        void SaveAnswer(IEnumerable<ChaperoneAnswer> answers);

        IEnumerable<ChaperoneAnswer> GetByEventCustomerId(long eventCustomerId);
        IEnumerable<ChaperoneAnswer> GetByEventCustomerIds(IEnumerable<long> eventCustomerIds);

        IEnumerable<ChaperoneAnswer> GetAllAnswerByQuestionIds(IEnumerable<long> QuestionIds);
    }
}
