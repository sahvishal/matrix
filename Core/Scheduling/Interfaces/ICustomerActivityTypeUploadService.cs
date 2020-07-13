using Falcon.App.Core.Scheduling.ViewModels;

namespace Falcon.App.Core.Scheduling.Interfaces
{
    public interface ICustomerActivityTypeUploadService
    {
        CustomerActivityTypeUploadListModel GetCustomerActivityTypeUploadDetails(int pageNumber, int pageSize, CustomerActivityTypeUploadListModelFilter filter, out int totalRecords);
    }
}
