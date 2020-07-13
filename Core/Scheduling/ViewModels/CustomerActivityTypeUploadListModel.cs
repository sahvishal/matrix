using Falcon.App.Core.Application.Attributes;
using Falcon.App.Core.Application.ViewModels;
using System.Collections.Generic;

namespace Falcon.App.Core.Scheduling.ViewModels
{
    public class CustomerActivityTypeUploadListModel
    {
        public IEnumerable<CustomerActivityTypeUploadViewModel> Collection { get; set; }
        public CustomerActivityTypeUploadListModelFilter Filter { get; set; }

        [IgnoreAudit]
        public PagingModel PagingModel { get; set; }
    }
}
