using Falcon.App.Core.Finance.ViewModels;

namespace Falcon.App.Core.Finance
{
    public interface IPayPeriodService
    {
        PayPeriodListModel Get(PayPeriodFilter filter, int pageNumber, int pageSize, out int totalRecords);
        PayPeriodEditModel GetEditModel(long payPeriodId);
        void Save(PayPeriodEditModel model, long orgRoleId);
        bool Delete(long payPeriodId);
    }
}