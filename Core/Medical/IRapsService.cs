using System.Collections.Generic;
using Falcon.App.Core.Medical.ViewModels;

namespace Falcon.App.Core.Medical
{
    public interface IRapsService
    {
        IEnumerable<RapsUploadModel> GetUploadList(int pageNumber, int pageSize, RapsUploadListModelFilter filter,
            out int totalRecords);
    }
}
