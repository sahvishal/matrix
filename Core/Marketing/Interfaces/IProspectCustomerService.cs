using Falcon.App.Core.Application.ViewModels;
using Falcon.App.Core.Marketing.ViewModels;
using Falcon.App.Core.Scheduling.ViewModels;

namespace Falcon.App.Core.Marketing.Interfaces
{
    public interface IProspectCustomerService
    {
        ListModelBase<ProspectCustomerBasicInfoModel, ProspectCustomerListModelFilter> GetAbandonedCustomers(int pageNumber, int pageSize, ModelFilterBase filter, out int totalRecords);
        SchedulingCustomerEditModel GetforProspectCustomerId(long prospectCustomerId);
    }
}