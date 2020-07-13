using System;
using System.ComponentModel;
using Falcon.App.Core.Application.Attributes;
using Falcon.App.Core.Application.ViewModels;

namespace Falcon.App.Core.Medical.ViewModels
{
    public class EventArchiveStatsViewModel : ViewModelBase
    {
        [Hidden]
        public long Id { get; set; }

        [DisplayName("Event Id")]
        public long EventId { get; set; }

        [DisplayName("Event Name")]
        public string EventName { get; set; }

        [DisplayName("Event Date")]
        [Format("MM/dd/yyyy")]
        public DateTime EventDate { get; set; }

        [DisplayName("Pod")]
        public string PodName { get; set; }

        [DisplayName("Archive Name")]
        public string ArchiveName { get; set; }

        [DisplayName("File Size")]
        public string FileSize { get; set; }

        [DisplayName("Upload Start")]
        [Format("MM/dd/yyyy HH:mm:ss")]
        public DateTime UploadStartTime { get; set; }

        [DisplayName("Upload End")]
        [Format("MM/dd/yyyy HH:mm:ss")]
        public DateTime? UploadEndTime { get; set; }

        [DisplayName("Time Taken")]
        public string TimeTaken { get; set; }

        [Hidden]
        public DateTime? ParseStartTime { get; set; }

        [Hidden]
        public DateTime? ParseEndTime { get; set; }

        [Hidden]
        public int CustomerRecordsFound { get; set; }

        [DisplayName("Uploaded By")]
        public string UploadedBy { get; set; }

        [DisplayName("Upload Status")]
        public string UploadStatus { get; set; }
    }
}
