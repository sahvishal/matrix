using System.Collections.Generic;
using Falcon.App.Core.Operations.Domain;
using Falcon.App.Core.Operations.ViewModels;

namespace Falcon.App.Core.Operations
{
    public interface IStaffEventScheduleUploadRepository
    {
        StaffEventScheduleUpload Save(StaffEventScheduleUpload domain);
        IEnumerable<StaffEventScheduleUpload> GetByFilter(int pageNumber, int pageSize, StaffEventScheduleUploadModelFilter filter, out int totalRecords);
        IEnumerable<StaffEventScheduleUpload> GetFilesToParse();
    }
}
