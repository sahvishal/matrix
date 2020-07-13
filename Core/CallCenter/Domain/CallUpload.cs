using System;
using Falcon.App.Core.Domain;

namespace Falcon.App.Core.CallCenter.Domain
{
    public class CallUpload : DomainObjectBase
    {
        public long FileId { get; set; }
        public long StatusId { get; set; }
        public long SuccessfullUploadCount { get; set; }
        public long FailedUploadCount { get; set; }
        public DateTime UploadTime { get; set; }
        public long UploadedBy { get; set; }
        public DateTime? ParseStartTime { get; set; }
        public DateTime? ParseEndTime { get; set; }

        public long? LogFileId { get; set; }
    }
}
