using Falcon.App.Core.Scheduling.Domain;
using Falcon.App.Core.Scheduling.ViewModels;

namespace Falcon.App.Core.Scheduling
{
    public interface IGoogleAnalyticsReportingDataService
    {
        GoogleAnalyticsEnableReportingDataModel GetGoogleAnalyticsViewModel(TempCart tempCart);
    }
}
