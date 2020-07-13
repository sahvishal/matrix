using Falcon.App.Core.Application.ViewModels;
using Falcon.App.Core.Finance.ViewModels;

namespace Falcon.App.Core.Finance
{
    public interface IDailyPatientRecapReportingService
    {
        ListModelBase<DailyPatientRecapModel, DailyPatientRecapModelFilter> GetDailyPatientReapModel(int pageNumber, int pageSize, ModelFilterBase filter, out int totalRecords);

        ListModelBase<DailyPatientRecapCustomModel, DailyPatientRecapModelFilter> GetDailyPatientReapCustomModel(int pageNumber, int pageSize, ModelFilterBase filter, out int totalRecords);
    }
}
