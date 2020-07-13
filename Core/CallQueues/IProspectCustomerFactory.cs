
using Falcon.App.Core.Marketing.Domain;
using Falcon.App.Core.Users.Domain;

namespace Falcon.App.Core.CallQueues
{
    public interface IProspectCustomerFactory
    {
        ProspectCustomer CreateProspectCustomerFromCustomer(Customer customer, bool isConverted);
    }
}
