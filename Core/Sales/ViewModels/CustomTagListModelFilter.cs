using Falcon.App.Core.Application.Attributes;

namespace Falcon.App.Core.Sales.ViewModels
{
    [NoValidationRequired]
    public class CustomTagListModelFilter
    {
        public string CustomTag { get; set; }

        public long CorporateId { get; set; }

        public bool DisabledTag { get; set; }

        public bool EnabledTag { get; set; }
       
    }
}
