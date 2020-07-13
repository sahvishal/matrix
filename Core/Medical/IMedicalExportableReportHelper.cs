using Falcon.App.Core.Medical.ViewModels;
using Falcon.App.Core.Scheduling.ViewModels;

namespace Falcon.App.Core.Medical
{
    public interface IMedicalExportableReportHelper
    {
        string TestPerformedReportExport(TestPerformedListModelFilter filter, long userId);
        string TestNotPerformedReportExport(TestNotPerformedListModelFilter filter, long userId);
        string GapsReportExport(GapsClosureModelFilter filter, long userId);
        string EventArchiveStatsExport(EventArchiveStatsFilter filter, long userId);
        string DisqualifiedTestReportExport(DisqualifiedTestReportFilter filter, long userId);
    }
}
