using Falcon.App.Core.Operations.Domain;
using Falcon.App.Core.Operations.ViewModels;

namespace Falcon.App.Core.Operations
{
    public interface IMergeCustomerUploadService
    {
        MergeCustomerUploadListModel GetMergeCustomerUploadDetails(int pageNumber, int pageSize, MergeCustomerUploadListModelFilter filter, out int totalRecords);
        MergeCustomerUploadLog ParseMergeCustomerLog(MergeCustomerUploadLog mergeCustomerUploadLog, long orgRoleId);
    }
}
