using System.Collections.Generic;
using Falcon.App.Core.Sales.Domain;
using Falcon.App.Core.Sales.ViewModels;

namespace Falcon.App.Core.Sales.Interfaces
{
    public interface ICustomerPhoneNumberUpdateUploadRepository
    {
        CustomerPhoneNumberUpdateUpload Save(CustomerPhoneNumberUpdateUpload domain);

        IEnumerable<CustomerPhoneNumberUpdateUpload> GetByFilter(int pageNumber, int pageSize, CustomerPhoneNumberUpdateModelFilter filter, out int totalRecords);
        
        IEnumerable<CustomerPhoneNumberUpdateUpload> GetUploadedFilesInfo();
    }
}
