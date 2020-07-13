using Falcon.App.Core.Medical.ViewModels;

namespace Falcon.App.Core.Medical
{
    public interface ICustomerScreeningViewDataRepository
    {
        CustomerScreeningViewData GetCustomerScreeningViewData(long customerId, long eventId);
    }
}
