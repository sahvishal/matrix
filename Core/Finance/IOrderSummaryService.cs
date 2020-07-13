using Falcon.App.Core.Finance.ViewModels;

namespace Falcon.App.Core.Finance
{
    public interface IOrderSummaryService
    {
        CustomerOrderViewModel GetOrderSummary(long customerId, long eventId);
    }
}