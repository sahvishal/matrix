using Falcon.App.Core.Sales.ViewModels;

namespace Falcon.App.Core.Sales.Interfaces
{
    public interface IPhoneNumberUploadService
    {
        CustomerPhoneNumberListModel GetPhoneNumberUploadDetails(CustomerPhoneNumberUpdateModelFilter filter, int pageNumber, int pageSize, out int totalRecords);
    }
}
