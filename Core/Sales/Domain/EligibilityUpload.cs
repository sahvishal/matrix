using System;
using Falcon.App.Core.Domain;

namespace Falcon.App.Core.Sales.Domain
{
    public class EligibilityUpload : DomainObjectBase
    {
        public long FileId { get; set; }
        public long SuccessfullUploadCount { get; set; }
        public long FailedUploadCount { get; set; }
        public DateTime UploadTime { get; set; }
        public long UploadedBy { get; set; }
        public long? LogFileId { get; set; }
        public long AccountId { get; set; }
        public long StatusId { get; set; }
        public DateTime? ParseStartTime { get; set; }
        public DateTime? ParseEndTime { get; set; }
    }
}