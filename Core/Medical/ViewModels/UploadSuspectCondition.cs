using Falcon.App.Core.Application.Attributes;
using System.Collections.Generic;

namespace Falcon.App.Core.Medical.ViewModels
{
    [NoValidationRequired]
    public class UploadSuspectCondition
    {
        public long SuspectConditionUploadId { get; set; }
        public string FileName { get; set; }
        public int PageSize { get; set; }
        public string FailedRecordsFile { get; set; }
        public int PageNumber { get; set; }
        public long LogFileId { get; set; }

        public UploadSuspectCondition()
        {
            PageNumber = 1;
        }
    }
}
