using System.Collections.Generic;
using Falcon.App.Core.Application.Attributes;
using Falcon.App.Core.Application.ViewModels;

namespace Falcon.App.Core.Operations.ViewModels
{
    public class MergeCustomerUploadListModel
    {
        public IEnumerable<MergeCustomerUploadViewModel> Collection { get; set; }
        public MergeCustomerUploadListModelFilter Filter { get; set; }

        [IgnoreAudit]
        public PagingModel PagingModel { get; set; }
    }
}
