using System.ComponentModel;
using Falcon.App.Core.Application.Attributes;
using Falcon.App.Core.Application.ViewModels;

namespace Falcon.App.Core.Scheduling.ViewModels
{
    public class EventListGmsModel : ViewModelBase
    {
        [DisplayName("Event Id")]
        public long EventId { get; set; }

        [DisplayName("Event Date")]
        public string EventDate { get; set; }

        [DisplayName("Event Address")]
        public string EventAddressStreet12 { get; set; }

        [DisplayName("Event State")]
        public string EventStateName { get; set; }

        [DisplayName("Event City")]
        public string EventCity { get; set; }

        [DisplayName("Event ZipCode")]
        public string EventZipCode { get; set; }

        [DisplayName("Total Slots")]
        public int TotalSlots { get; set; }

        [DisplayName("Available Slots")]
        public int AvailableSlots { get; set; }

        [DisplayName("Sponsor Name")]
        public string HealthPlanName { get; set; }

        [Hidden]
        public long HostId { get; set; }
    }
}