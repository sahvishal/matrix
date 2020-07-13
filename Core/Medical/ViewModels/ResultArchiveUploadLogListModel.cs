using System.Collections.Generic;

namespace Falcon.App.Core.Medical.ViewModels
{
    public class ResultArchiveUploadLogListModel
    {
        public ResultArchiveUploadViewModel ResultArchive { get; set; }
        public IEnumerable<ResultArchiveUploadLogViewModel> ResultArchiveLogRecords { get; set; }
    }
}