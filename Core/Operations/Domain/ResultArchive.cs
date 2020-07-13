using System;
using Falcon.App.Core.Domain;
using Falcon.App.Core.Medical.Enum;

namespace Falcon.App.Core.Operations.Domain
{
    public class ResultArchive : DomainObjectBase
    {
        public long? FileId { get; set; }
        public long EventId { get; set; }
        public DateTime UploadStartTime { get; set; }
        public DateTime? UploadEndTime { get; set; }

        public DateTime? ParseStartTime { get; set; }
        public DateTime? ParseEndTime { get; set; }

        public int? UploadPercentage { get; set; }
        public int? ParsePercentage { get; set; }

        public ResultArchiveUploadStatus Status { get; set; }
        public int CustomerRecordsFound { get; set; }
        public long UploadedByOrgRoleUserId { get; set; }
    }
}