using System.Collections.Generic;
using Falcon.App.Core.Operations.Domain;

namespace Falcon.App.Core.Operations
{
    public interface IStaffEventScheduleUploadLogRepository
    {
        void Save(IEnumerable<StaffEventScheduleUploadLog> collection);
    }
}
