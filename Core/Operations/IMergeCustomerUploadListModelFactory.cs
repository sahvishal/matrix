using System.Collections.Generic;
using Falcon.App.Core.Application.ViewModels;
using Falcon.App.Core.Operations.Domain;
using Falcon.App.Core.Operations.ViewModels;

namespace Falcon.App.Core.Operations
{
    public interface IMergeCustomerUploadListModelFactory
    {
        MergeCustomerUploadListModel Create(IEnumerable<FileModel> fileModels, IEnumerable<MergeCustomerUpload> callUpload,
            IEnumerable<OrderedPair<long, string>> uploadedbyAgentNameIdPair);
    }
}
