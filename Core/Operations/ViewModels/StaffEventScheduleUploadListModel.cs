using System.Collections.Generic;
using Falcon.App.Core.Application.Attributes;
using Falcon.App.Core.Application.ViewModels;

namespace Falcon.App.Core.Operations.ViewModels
{
    public class StaffEventScheduleUploadListModel
    {
        public IEnumerable<StaffEventScheduleUploadViewModel> Collection { get; set; }

        public StaffEventScheduleUploadModelFilter Filter { get; set; }

        [IgnoreAudit]
        public PagingModel PagingModel { get; set; }
    }
}
