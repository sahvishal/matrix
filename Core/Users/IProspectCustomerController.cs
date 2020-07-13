using Falcon.App.Core.Marketing.Domain;

namespace Falcon.App.Core.Users
{
    public interface IProspectCustomerController
    {
        ProspectCustomer GetById(long prospectCustomerId);
        ProspectCustomer SaveProspectCustomer(ProspectCustomer prospectCustomer);
        ProspectCustomer GetByCustomerId(long prospectCustomerId);
    }
}