using System.Collections.Generic;
using Falcon.App.Core.Application.Attributes;
using Falcon.App.Core.Application.ViewModels;

namespace Falcon.App.Core.Scheduling.ViewModels
{
    [NoValidationRequired]
    public class CorporateUploadEditModel : ViewModelBase
    {
        public long CorporateAccountId { get; set; }
        public string Name { get; set; }
        public string Tag { get; set; }
        public bool IsUploadSucceded { get; set; }
        public bool IsParseSucceded { get; set; }
        public long TotalCustomers { get; set; }
        public long UploadedCustomers { get; set; }
        public long FailedCustomers { get; set; }
        public string FailedCustomersListPath { get; set; }
        public string UploadCsvMediaUrl { get; set; }
        public string FileName { get; set; }
        public string FailedRecordsFile { get; set; }
        public string AdjustOrderRecordsFile { get; set; }
        public List<string> CustomTags { get; set; }
        public long? UploadCorporateId { get; set; }
    }
}
