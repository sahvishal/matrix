using Falcon.App.Core.CallCenter.ViewModels;
using Falcon.App.Core.CallQueues.ViewModels;
using Falcon.App.Core.Interfaces;

namespace Falcon.App.Core.CallCenter
{
    public interface ICallCenterExportableReportHelper
    {
        string OutreachCallReportExport(OutreachCallReportModelFilter filter, long userId);
        void OutreachCallReportExport(OutreachCallReportModelFilter filter, string filePath, ILogger logger);
        string CallQueueSchedulingReportExport(CallQueueSchedulingReportFilter filter, long userId);
        string CallQueueExcludedCustomerReportExport(CallQueueExcludedCustomerReportModelFilter filter, long userId);
        string CallQueueCustomersReportExport(OutboundCallQueueFilter filter, long userId);
        string CustomerWithNoEventsInAreaReportExport(CustomerWithNoEventsInAreaReportModelFilter filter, long userId);
        string CallCenterCallReportExport(CallCenterCallReportModelFilter filter, long userId);
        string ConfirmationReportExport(ConfirmationReportFilter filter, long userId);
        string CallSkippedReportExport(CallSkippedReportFilter filter, long userId);
        string ExcludedCusomerReportExport(OutboundCallQueueFilter filter, long userId);
        string PreAssessmentReportExport(PreAssessmentReportFilter filter, long userId);
    }
}
