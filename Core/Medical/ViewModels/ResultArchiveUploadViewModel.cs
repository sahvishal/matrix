using System;
using Falcon.App.Core.Application.Domain;
using Falcon.App.Core.Medical.Enum;

namespace Falcon.App.Core.Medical.ViewModels
{
    public class ResultArchiveUploadViewModel
    {
        public long Id { get; set; }
        public File File { get; set; }

        public long EventId { get; set; }
        public string EventName { get; set; }
        public DateTime EventDate { get; set; }
        public string PodName { get; set; }

        public DateTime UploadStartTime { get; set; }
        public DateTime? UploadEndTime { get; set; }
        public DateTime? ParseStartTime { get; set; }
        public DateTime? ParseEndTime { get; set; }

        public int CustomerRecordsFound { get; set; }
        public string UploadedBy { get; set; }

        public ResultArchiveUploadStatus Status { get; set; }

    }
}