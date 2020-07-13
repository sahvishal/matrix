using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using Falcon.App.Core.Application.Attributes;
using Falcon.App.Core.Application.ViewModels;
using Falcon.App.Core.Geo.ViewModels;

namespace Falcon.App.Core.Scheduling.ViewModels
{
    public class HealthPlanEventViewModel : ViewModelBase
    {
        [DisplayName("EventID")]
        public long Id { get; set; }

        [DisplayName("Event Date")]
        [Format("MM/dd/yyyy")]
        public DateTime EventDate { get; set; }
        
        [Hidden]
        public long HostId { get; set; }
        
        [DisplayName("Host Name")]
        public string HostName { get; set; }
        
        [DisplayName("Address")]
        public AddressViewModel HostAddress { get; set; }

        public IEnumerable<OrderedPair<long, string>> Pods { get; set; }

        [DisplayName("Screened Customers")]
        public long ScreenedCustomers { get; set; }

        [DisplayName("Total Appointment Slots")]
        public int TotalAppointmentSlots { get; set; }

        [DisplayName("Filled Appointment Slots")]
        public int FilledAppintmentSlots { get; set; }

        public string PodNames()
        {
            return Pods != null ? string.Join(", ", Pods.Select(pod => pod.SecondValue)) : string.Empty;
        }
    }
}
