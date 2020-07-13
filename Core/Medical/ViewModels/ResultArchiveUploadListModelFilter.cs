using System;

namespace Falcon.App.Core.Medical.ViewModels
{
    public class ResultArchiveUploadListModelFilter
    {
        public long EventId { get; set; }
        public DateTime? FromEventDate { get; set; }
        public DateTime? ToEventDate { get; set; }
        public DateTime? FromUploadDate { get; set; }
        public DateTime? ToUploadDate { get; set; }
        public long UploadedBy { get; set; }
        public int ResultArchiveUploadStatus { get; set; }
        public bool? IsArchived { get; set; }
        public string Pod { get; set; }
    }
}