using System;
using Falcon.App.Core.Application.Attributes;

namespace Falcon.App.Core.Sales.ViewModels
{
    [NoValidationRequired]
    public class CustomerPhoneNumberUpdateModelFilter
    {
        public DateTime? FromUploadDate { get; set; }
        public DateTime? ToUploadDate { get; set; }
        public long? UploadedBy { get; set; }
    }
}
