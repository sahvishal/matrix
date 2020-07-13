using System;
using System.ComponentModel;
using Falcon.App.Core.Application.Attributes;
using Falcon.App.Core.Application.ViewModels;

namespace Falcon.App.Core.Operations.ViewModels
{
    public class CustomerCdContentTrackingModel : ViewModelBase
    {
        [DisplayName("Event Id")]
        public long EventId { get; set; }

        [DisplayName("Customer Id")]
        public long CustomerId { get; set; }

        [DisplayName("Name")]
        public string Name { get; set; }

        [DisplayName("Order")]
        public long OrderId { get; set; }

        [DisplayName("Content Generated")]
        public bool CdContentGenerated { get; set; }

        [DisplayName("Content Downloaded")]
        public bool CdContentDownloaded { get; set; }

        [DisplayName("Downloaded By")]
        public string DownloadedBy { get; set; }

        [DisplayName("Downloaded Time")]
        [Format("mm/dd/yyyy")]
        public DateTime? DownloadedTime { get; set; }

        [Hidden]
        public long CdContentTrackingId { get; set; }
        
    }
}
