using System.Collections.Generic;
using Falcon.App.Core.Operations.Domain;
using Falcon.App.Core.Operations.ViewModels;

namespace Falcon.App.Core.Operations
{
    public interface IMergeCustomerUploadRepository
    {
        MergeCustomerUpload Save(MergeCustomerUpload domainObject);
        IEnumerable<MergeCustomerUpload> GetByFilter(int pageNumber, int pageSize, MergeCustomerUploadListModelFilter filter, out int totalRecords);
        IEnumerable<MergeCustomerUpload> GetMergeCustomerUploadsForMerging();
    }
}
