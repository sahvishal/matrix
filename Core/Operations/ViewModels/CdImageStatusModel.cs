using System;
using System.ComponentModel;
using Falcon.App.Core.Application.Attributes;
using Falcon.App.Core.Application.ViewModels;
using Falcon.App.Core.Geo.ViewModels;

namespace Falcon.App.Core.Operations.ViewModels
{
    public class CdImageStatusModel : ViewModelBase
    {
        [Hidden]
        public long CustomerId { get; set; }

        [DisplayName("Customer Id")]
        public string CustomerCode { get; set; }

        public string Name { get; set; }
        
        public AddressViewModel Address { get; set; }
        
        [DisplayName("Event Id")]
        public long EventId { get; set; }
        
        [DisplayName("Event Date")]
        [Format("MM/dd/yyyy")]
        public DateTime EventDate { get; set; }
        
        [DisplayName("Status")]
        public string CdImageStatus { get; set; }
    }
}
