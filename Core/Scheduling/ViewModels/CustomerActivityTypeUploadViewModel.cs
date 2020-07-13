using Falcon.App.Core.Application.Attributes;
using Falcon.App.Core.Application.ViewModels;
using System;

namespace Falcon.App.Core.Scheduling.ViewModels
{
    [NoValidationRequired]
    public class CustomerActivityTypeUploadViewModel : ViewModelBase
    {
        public long Id { get; set; }

        public FileModel File { get; set; }

        public DateTime UploadTime { get; set; }

        public string UploadedBy { get; set; }

        public long SuccessfullCustomer { get; set; }

        public long FailedCustomer { get; set; }

        public string Status { get; set; }

        public FileModel FailedFile { get; set; }
    }
}
