using Falcon.App.Core.Application.ViewModels;
using Falcon.App.Core.Operations.ViewModels;

namespace Falcon.App.Core.Operations
{
    public interface IStaffEventScheduleExportService
    {
        ListModelBase<StaffEventSchedulingModel, EventStaffAssignmentListModelFilter> GetStaffScheduleForCsvExport(int pageNumber, int pageSize, ModelFilterBase staffEventScheduleModelFilter, out int totalRecords);
    }
}
