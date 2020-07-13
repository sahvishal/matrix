using Falcon.App.Core.Application.Attributes;
using System;

namespace Falcon.App.Core.Scheduling.ViewModels
{
    [NoValidationRequired]
    public class CustomerActivityTypeUploadListModelFilter
    {
        public DateTime? FromUploadDate { get; set; }
        public DateTime? ToUploadDate { get; set; }
        public long? UploadedBy { get; set; }
    }
}
