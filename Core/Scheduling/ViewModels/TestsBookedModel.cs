using System;
using System.ComponentModel;
using Falcon.App.Core.Application.Attributes;
using Falcon.App.Core.Application.ViewModels;

namespace Falcon.App.Core.Scheduling.ViewModels
{
    public class TestsBookedModel : ViewModelBase
    {
        [DisplayName("Event Id")]
        public long EventId { get; set; }

        [DisplayName("EventDate")]
        [Format("MM/dd/yyyy")]
        public DateTime EventDate { get; set; }

        [DisplayName("Event Name")]
        public string EventName { get; set; }

        [DisplayName("Pod")]
        public string PodName { get; set; }

        [DisplayName("Customer Id")]
        public long CustomerId { get; set; }

        [DisplayName("Customer Name")]
        public string CustomerName { get; set; }

        [DisplayName("Test Booked")]
        public string TestName { get; set; }
    }
}
