using System;
using System.ComponentModel;
using Falcon.App.Core.Application.Attributes;
using Falcon.App.Core.Application.ViewModels;

namespace Falcon.App.Core.Medical.ViewModels
{
    public class PhysicianEventQueueViewModel:ViewModelBase
    {
        [DisplayName("Assigned Physician")]
        public string PhysicianName { get; set; }

        [DisplayName("Event Id")]
        public long EventId { get; set; }

        [DisplayName("Event Date")]
        [Format("MM/dd/yyyy")]
        public DateTime EventDate { get; set; }

        [DisplayName("Event Name")]
        public string EventName { get; set; }

        public string Vehicle { get; set; }

        [DisplayName("Customers In Queue")]
        public int CustomersInQueue { get; set; }

        [Hidden]
        public long PhysicianId { get; set; }
    }
}
