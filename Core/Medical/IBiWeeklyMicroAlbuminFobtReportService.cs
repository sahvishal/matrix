using System.Collections.Generic;
using Falcon.App.Core.Application.ViewModels;
using Falcon.App.Core.Medical.Domain;
using Falcon.App.Core.Medical.ViewModels;

namespace Falcon.App.Core.Medical
{
    public interface IBiWeeklyMicroAlbuminFobtReportService
    {
        ListModelBase<BiWeeklyMicroAlbuminFobtReportViewModel, BiWeeklyMicroAlbuminFobtReportModelFilter> GetEventCustomerResultForReport(int pageNumber, int pageSize, ModelFilterBase filter, out int totalRecords);
    }
}
