using System.Collections.Generic;
using Falcon.App.Core.Application.ViewModels;
using Falcon.App.Core.CallQueues.Domain;
using Falcon.App.Core.CallQueues.ViewModels;

namespace Falcon.App.Core.CallQueues
{
    public interface IGmsExcludedCustomerService
    {
        IEnumerable<GmsExcludedCustomerViewModel> GetGmsExcludedCustomers(OutboundCallQueueFilter filter, CallQueue callQueue);
        ListModelBase<GmsExcludedCustomerViewModel, OutboundCallQueueFilter> GetExcludedCustomers(int pageNumber, int pageSize, ModelFilterBase filter, out int totalRecords);
        ExcludedCustomerListModel SetHeaderData(OutboundCallQueueFilter filter, ExcludedCustomerListModel model);
    }
}
