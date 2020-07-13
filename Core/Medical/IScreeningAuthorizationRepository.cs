using System.Collections.Generic;
using Falcon.App.Core.Medical.Domain;

namespace Falcon.App.Core.Medical
{
    public interface IScreeningAuthorizationRepository
    {
        bool SaveScreeningAuthorizations(List<ScreeningAuthorization> screeningAuthorizations);
        IEnumerable<long> GetEventCustomersAuthorizedforanEvent(long eventId);
        ScreeningAuthorization GetAuthorization(long eventCustomerId);
    }
}
