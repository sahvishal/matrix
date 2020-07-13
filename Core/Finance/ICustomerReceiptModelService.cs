using Falcon.App.Core.Finance.ViewModels;

namespace Falcon.App.Core.Finance
{
    public interface ICustomerReceiptModelService
    {
        CustomerItemizedReceiptModel GetItemizedRecieptModel(long customerId, long eventId);
    }
}