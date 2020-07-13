using Falcon.App.Core.Application.ViewModels;
using Falcon.App.Core.CallQueues.ViewModels;
using System.Collections.Generic;

namespace Falcon.App.Core.CallQueues
{
    public interface ICallQueueService
    {
        CallQueueEditModel SaveCallQueue(CallQueueEditModel callQueueEditModel, long orgRoleUserId);
        CallQueueEditModel GetCallQueue(long callQueueId);
        ListModelBase<CallQueueViewModel, CallQueueListModelFilter> GetCallQueueList(int pageNumber, int pageSize, ModelFilterBase filter, out int totalRecords);
        ListModelBase<CallQueueReportModel, CallQueueReportModelFilter> GetCallQueueReport(int pageNumber, int pageSize, ModelFilterBase filter, out int totalRecords);
        ListModelBase<OutreachCallReportModel, OutreachCallReportModelFilter> GetOutreachCallReport(int pageNumber, int pageSize, ModelFilterBase filter, out int totalRecords);
        ListModelBase<UncontactedCustomersReportModel, UncontactedCustomersReportModelFilter> GetUncontactedCustomersReport(int pageNumber, int pageSize, ModelFilterBase filter, out int totalRecords);
        ListModelBase<CallQueueExcludedCustomerReportModel, CallQueueExcludedCustomerReportModelFilter> GetCallQueueExcludedCustomerReport(int pageNumber, int pageSize, ModelFilterBase filter, out int totalRecords);
        IEnumerable<OutreachCallChartViewModel> GetOutreachCallChart();
        ListModelBase<CustomerWithNoEventsInAreaReportModel, CustomerWithNoEventsInAreaReportModelFilter> GetCustomerWithNoEventsInArea(int pageNumber, int pageSize, ModelFilterBase filter, out int totalRecords); 
        ListModelBase<CallCenterCallReportModel, CallCenterCallReportModelFilter> GetCallCenterCallReport(int pageNumber, int pageSize, ModelFilterBase filter, out int totalRecords);
        ListModelBase<HousecallOutreachReportModel, OutreachCallReportModelFilter> GetHousecallOutreachCallReport(int pageNumber, int pageSize, ModelFilterBase filter, out int totalRecords);
    }
}
