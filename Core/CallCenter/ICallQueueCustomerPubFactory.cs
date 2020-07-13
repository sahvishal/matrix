using Falcon.App.Core.CallCenter.ViewModels;
using Falcon.App.Core.Geo.Domain;
using Falcon.App.Core.Users.Domain;

namespace Falcon.App.Core.CallCenter
{
    public interface ICallQueueCustomerPubFactory
    {
        CallQueueCustomerPubViewModel GetCallQueueCustomerPubViewModel(Customer customer, Address address);
    }
}
