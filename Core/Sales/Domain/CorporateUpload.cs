using System;
using Falcon.App.Core.Domain;

namespace Falcon.App.Core.Sales.Domain
{
    public class CorporateUpload : DomainObjectBase
    {
        public long FileId { get; set; }
        public long SuccessfullUploadCount { get; set; }
        public long FailedUploadCount { get; set; }
        public DateTime UploadTime { get; set; }
        public long UploadedBy { get; set; }
        public long? LogFileId { get; set; }
        public long? AccountId { get; set; }
        public long? AdjustOrderLogFileId { get; set; }
        public long SourceId { get; set; }
        public int? ParseStatus { get; set; }

        public bool? IsTermByAbsence { get; set; }
    }
}
