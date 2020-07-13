using Falcon.App.Core.Sales.ViewModels;

namespace Falcon.App.Core.Sales.Interfaces
{
    public interface IEligibilityUploadService
    {
        EligibilityUploadListModel GetEligibilityUploadDetails(int pageNumber, int pageSize, EligibilityUploadListModelFilter filter, out int totalRecords);
    }
}
