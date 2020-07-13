using System;
using Falcon.App.Core.Application.Attributes;
using Falcon.App.Core.Application.Domain;
using Falcon.App.Core.Application.ViewModels;

namespace Falcon.App.Core.Medical.ViewModels
{
    [NoValidationRequired]
    public class RapsFileUploadEditModel : ViewModelBase
    {
        public long Id { get; set; }
        public File File { get; set; }
        public DateTime UploadStartTime { get; set; }
        public DateTime UploadEndTime { get; set; }
        public string UploadCsvMediaUrl { get; set; }   
    }
}
