using Falcon.App.Core.Scheduling.Domain;
using Falcon.App.Core.Scheduling.ViewModels;
using System.Collections.Generic;

namespace Falcon.App.Core.Scheduling.Interfaces
{
    public interface ICustomerActivityTypeUploadRepository
    {
        CustomerActivityTypeUpload GetById(long id);
        CustomerActivityTypeUpload Save(CustomerActivityTypeUpload domainObject);
        IEnumerable<CustomerActivityTypeUpload> GetFilesToParse();
        IEnumerable<CustomerActivityTypeUpload> GetByFilter(int pageNumber, int pageSize, CustomerActivityTypeUploadListModelFilter filter, out int totalRecords);
    }
}
