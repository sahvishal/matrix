using System.Collections.Generic;
using Falcon.App.Core.Application.Attributes;

namespace Falcon.App.Core.Scheduling.ViewModels
{
    [NoValidationRequired]
    public class UploadCorporateCustomers
    {
        public string FileName { get; set; }
        public int PageSize { get; set; }
        public string Tag { get; set; }
        public string FailedRecordsFile { get; set; }
        public int PageNumber { get; set; }
        public List<string> CustomTags { get; set; }
        public long? UploadCorporateId { get; set; }
        public string AdjustOrderRecordsFile { get; set; }
        public long LogFileId { get; set; }
        public long AdjustOrderLogFileId { get; set; }
        public UploadCorporateCustomers()
        {
            PageNumber = 1;
        }
    }
}