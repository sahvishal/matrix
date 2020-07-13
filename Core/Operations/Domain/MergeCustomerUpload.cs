using System;
using Falcon.App.Core.Domain;

namespace Falcon.App.Core.Operations.Domain
{
    public class MergeCustomerUpload : DomainObjectBase
    {
        public long FileId { get; set; }
        public long StatusId { get; set; }
        public long UploadedBy { get; set; }
        public DateTime UploadTime { get; set; }
        public long SuccessUploadCount { get; set; }
        public long FailedUploadCount { get; set; }
        public DateTime? ParseStartTime { get; set; }
        public DateTime? ParseEndTime { get; set; }
        public long? LogFileId { get; set; }
    }
}
