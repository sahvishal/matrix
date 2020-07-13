using Falcon.App.Core.Application.Attributes;
using Falcon.App.Core.Application.Domain;
using Falcon.App.Core.Application.ViewModels;
using System;

namespace Falcon.App.Core.Medical.ViewModels
{
    [NoValidationRequired]
    public class SuspectConditionFileUploadEditModel : ViewModelBase
    {
        public long SuspectConditionUploadId { get; set; }
        public bool IsUploadSucceded { get; set; }
        public bool IsParseSucceded { get; set; }
        public long TotalRecords { get; set; }
        public long UploadedRecords { get; set; }
        public long FailedRecords { get; set; }
        public string FailedRecordsListPath { get; set; }
        public string SampleCsvMediaUrl { get; set; }
        public string FileName { get; set; }
        public string FailedRecordsFile { get; set; }

    }
}
