using System;
using Falcon.App.Core.Application.ViewModels;

namespace Falcon.App.Core.Sales.ViewModels
{
    public class EligibilityUploadViewModel
    {
        public long Id { get; set; }

        public FileModel File { get; set; }

        public DateTime UploadTime { get; set; }

        public string UploadedBy { get; set; }

        public long SuccessfullCustomer { get; set; }

        public long FailedCustomer { get; set; }

        public string Status { get; set; }

        public FileModel FailedFile { get; set; }

        public string UploadedForAccount { get; set; }
    }
}
