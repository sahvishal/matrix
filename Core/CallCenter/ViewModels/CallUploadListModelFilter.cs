using System;
using Falcon.App.Core.Application.Attributes;


namespace Falcon.App.Core.CallCenter.ViewModels
{
    [NoValidationRequired]
    public class CallUploadListModelFilter
    {                  
        public DateTime? FromUploadDate { get; set; }
        public DateTime? ToUploadDate { get; set; }
        public long? UploadedBy { get; set; }
    }
}
