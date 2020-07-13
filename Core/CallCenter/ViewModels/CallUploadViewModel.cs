using Falcon.App.Core.Application.ViewModels;
using System;

namespace Falcon.App.Core.CallCenter.ViewModels
{
    public class CallUploadViewModel
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
