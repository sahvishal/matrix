using System;
using System.ComponentModel;
using Falcon.App.Core.Application.Attributes;
using Falcon.App.Core.Application.ViewModels;

namespace Falcon.App.Core.Medical.ViewModels
{
    public class KynCustomerModel : ViewModelBase
    {
        [DisplayName("Customer Id")]
        public long CustomerId { get; set; }

        [DisplayName("Customer Name")]
        public string CustomerName { get; set; }

        [DisplayName("EventId")]
        public long EventId { get; set; }

        [DisplayName("Event Date")]
        [Format("MM/dd/yyyy")]
        public DateTime EventDate { get; set; }
        
        [DisplayName("Pod")]
        public string Pod { get; set; }

        [DisplayName("KYN\\HAF Status")]
        public string KynStatus { get; set; }

        [DisplayName("Registration Mode")]
        public string RegisterationByRole { get; set; } 

        [DisplayName("Booking Agent")]
        public string RegisteredBy { get; set; }
        public string Tag { get; set; }
        public string CustomTag { get; set; }

        [DisplayName("Sponsored by")]
        public string SponseredBy { get; set; }

        [DisplayName("Modified By")]
        public string ModifiedBy { get; set; }

        [DisplayName("Modified On")]
        [Format("MM/dd/yyyy")]
        public DateTime? ModifiedOn { get; set; }

    }
}
