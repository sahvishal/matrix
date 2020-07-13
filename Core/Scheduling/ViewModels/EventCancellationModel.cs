using System;
using System.ComponentModel;
using Falcon.App.Core.Application.Attributes;
using Falcon.App.Core.Application.ViewModels;
using Falcon.App.Core.Geo.ViewModels;

namespace Falcon.App.Core.Scheduling.ViewModels
{
    public class EventCancellationModel : ViewModelBase
    {
        [DisplayName("EventId")]
        public long EventId { get; set; }

        [DisplayName("Event Date")]
        [Format("MM/dd/yyyy")]
        public DateTime EventDate { get; set; }

        [DisplayName("Name")]
        public string HostName { get; set; }

        [DisplayName("Address")]
        public AddressViewModel HostAddress { get; set; }
        public string Reason { get; set; }
        public string Notes { get; set; }

        [DisplayName("Agent Name")]
        public string AgentName { get; set; }
    }
}
