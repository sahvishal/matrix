using System;
using Falcon.App.Core.Application.Attributes;

namespace Falcon.App.Core.Operations.ViewModels
{
    [NoValidationRequired]
    public class StaffEventScheduleUploadModelFilter
    {
        public DateTime? FromUploadDate { get; set; }
        public DateTime? ToUploadDate { get; set; }
        public long? UploadedBy { get; set; }
    }
}
