using System;
using System.ComponentModel;
using Falcon.App.Core.Application.Domain;
using Falcon.App.Core.Application.ViewModels;

namespace Falcon.App.Core.Medical.ViewModels
{
    public class ResultArchiveUploadEditModel : ViewModelBase
    {
        public long Id { get; set; }
        public File File { get; set; }
        [DisplayName("Event Id")]
        public long EventId { get; set; }
        public DateTime UploadStartTime { get; set; }
        public DateTime UploadEndTime { get; set; }
        
    }
}