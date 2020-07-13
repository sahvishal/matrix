using System.Collections.Generic;
using Falcon.App.Core.Application.ViewModels;
using Falcon.App.Core.Operations.Domain;
using Falcon.App.Core.Operations.ViewModels;

namespace Falcon.App.Core.Operations
{
    public interface IStaffEventScheduleUploadListModelFactory
    {
        StaffEventScheduleUploadListModel Create(IEnumerable<FileModel> fileModels, IEnumerable<StaffEventScheduleUpload> staffEventScheduleUpload,
            IEnumerable<OrderedPair<long, string>> uploadedbyAgentNameIdPair);
    }
}
