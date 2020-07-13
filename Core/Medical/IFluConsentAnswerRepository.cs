using System.Collections.Generic;
using Falcon.App.Core.Medical.Domain;

namespace Falcon.App.Core.Medical
{
    public interface IFluConsentAnswerRepository
    {
        IEnumerable<FluConsentAnswer> GetAllAnswerByEventCustomerId(long eventCustomerId, int version = 1);

        int GetLatestVersion(long eventCustomerId);

        void SaveAnswer(IEnumerable<FluConsentAnswer> answers);

        IEnumerable<FluConsentAnswer> GetByEventCustomerId(long eventCustomerId);

    }
}
