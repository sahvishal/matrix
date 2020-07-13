using Falcon.App.Core.Finance.Domain;
using Falcon.App.Core.Geo.Domain;
using Falcon.App.Core.Users.Domain;

namespace Falcon.App.Core.Finance
{
    public interface IECheckService
    {
        ProcessorResponse ChargefromECheck(Check check, Address address, Customer customer, string ipAddress, string uniqueReference);
    }
}