using System;
using Falcon.App.Core.Application.ViewModels;

namespace Falcon.App.Core.Operations.ViewModels
{
    public class ExportableReportsQueueViewModel : ViewModelBase
    {
        public string Name { get; set; }
        public string Status { get; set; }
        public DateTime RequestedDate { get; set; }
        public string DownloadUrl { get; set; }
    }
}
