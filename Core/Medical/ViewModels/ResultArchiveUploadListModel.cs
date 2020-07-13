using System.Collections.Generic;
using Falcon.App.Core.Application.Attributes;
using Falcon.App.Core.Application.ViewModels;

namespace Falcon.App.Core.Medical.ViewModels
{
    public class ResultArchiveUploadListModel
    {
        public IEnumerable<ResultArchiveUploadViewModel> ResultUploads { get; set; }
        [IgnoreAudit]
        public PagingModel PagingModel { get; set; }
        public ResultArchiveUploadListModelFilter Filter { get; set; }

    }
}