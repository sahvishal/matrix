using System;
using Falcon.App.Core.Domain;

namespace Falcon.App.Core.Sales.Domain
{
    public class CustomerPhoneNumberUpdateUpload : DomainObjectBase
    {
        public long FileId { get; set; }
        public long StatusId { get; set; }
        public long SuccessUploadCount { get; set; }
        public long FailedUploadCount { get; set; }
        public DateTime UploadTime { get; set; }
        public DateTime? ParseStartTime { get; set; }
        public DateTime? ParseEndTime { get; set; }
        public long UploadedByOrgRoleUserId { get; set; }
        public long? LogFileId { get; set; }
    }
}
