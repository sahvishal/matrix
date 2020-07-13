using System;
using System.ComponentModel;
using Falcon.App.Core.Application.Attributes;
using Falcon.App.Core.Application.ViewModels;
using Falcon.App.Core.ValueTypes;

namespace Falcon.App.Core.Finance.ViewModels
{
    public class CustomerOpenOrderViewModel : ViewModelBase
    {
        [DisplayName("Customer Id")]
        public long CustomerId { get; set; }

        [DisplayName("Customer Name")]
        public Name CustomerName { get; set; }

        [DisplayName("Event Id")]
        public long EventId { get; set; }

        [DisplayName("Host")]
        public string Location { get; set; }

        [DisplayName("Event Date")]
        [Format("MM/dd/yyyy")]
        public DateTime EventDate { get; set; }

        public string Pod { get; set; }

        [DisplayName("Open Order Total")]
        public decimal OpenOrderTotal { get; set; }

        [DisplayName("Outstanding Revenue")]
        public decimal OutstandingRevenue { get; set; }

        public decimal UnPaid { get; set; }

        public string Status { get; set; }

        [Hidden]
        public long OrderId { get; set; }
        
    }
}
