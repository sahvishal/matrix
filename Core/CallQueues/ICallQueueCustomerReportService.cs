using Falcon.App.Core.Application.ViewModels;
using Falcon.App.Core.CallQueues.Domain;
using Falcon.App.Core.CallQueues.ViewModels;

namespace Falcon.App.Core.CallQueues
{
    public interface ICallQueueCustomerReportService
    {
        ListModelBase<CallQueueCustomersReportModel, OutboundCallQueueFilter> GetCallQueueCustomers(int pageNumber, int pageSize, ModelFilterBase filter, out int totalRecords);

        ListModelBase<GmsCallQueueCustomerViewModel, OutboundCallQueueFilter> GetGmsCallQueueCustomersReport(int pageNumber, int pageSize, ModelFilterBase filter, out int totalRecords);

        ListModelBase<MailRoundCustomersReportViewModel, OutboundCallQueueFilter> GetCustomersForMatrixReport(int pageNumber, int pageSize, OutboundCallQueueFilter filter, CallQueue callQueue, out int totalRecords);
    }
}