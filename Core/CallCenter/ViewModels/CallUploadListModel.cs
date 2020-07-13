using System.Collections.Generic;
using Falcon.App.Core.Application.Attributes;
using Falcon.App.Core.Application.ViewModels;


namespace Falcon.App.Core.CallCenter.ViewModels
{
    public class CallUploadListModel
    {
        public IEnumerable<CallUploadViewModel> Collection { get; set; }
        public CallUploadListModelFilter Filter { get; set; }

        [IgnoreAudit]
        public PagingModel PagingModel { get; set; }
    }
}
