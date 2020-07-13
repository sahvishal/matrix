using Falcon.App.Core.Scheduling.ViewModels;

namespace Falcon.App.Core.Scheduling
{
    public interface ISchedulingExportableReportHelper
    {
        string AppointmentBookedReportExport(AppointmentsBookedListModelFilter filter, long userId);
        string CustomerReportExport(CustomerExportListModelFilter filter, long userId);

        string MemberStatusReportExport(MemberStatusListModelFilter filter, long userId);
        string TestBookedReportExport(TestsBookedListModelFilter filter, long userId);
        string CustomerScheduleExport(CustomerScheduleModelFilter filter, long userId);
        string PcpTrackingReportExport(PcpTrackingReportFilter pcpTrackingReportFilter, long userId);
    }
}
