using Falcon.App.Core.Application.Attributes;
using Falcon.App.Core.Application.ViewModels;
using Falcon.App.Core.Geo.Domain;
using System;
using System.ComponentModel;

namespace Falcon.App.Core.Scheduling.ViewModels
{
    public class VoiceMailReminderModel : ViewModelBase
    {   
        [DisplayName("Customer Id")]
        public long CustomerId { get; set; }
        
        [DisplayName("EventId")]
        public long EventId { get; set; }

        [DisplayName("Phone(H)")]
        public string PhoneHome { get; set; }

        
        [DisplayName("Sponsored By")]
        public string SponsoredBy { get; set; }

        [DisplayName("Event Date")]
        [Format("MM/dd/yyyy")]
        public DateTime EventDate { get; set; }

        [DisplayName("Location")]
        public Address Address { get; set; }

        [DisplayName("Package")]
        public string Package { get; set; }

        [DisplayName("Appointment Time")]
        [Format("hh:mm tt")]
        public DateTime? AppointmentTime { get; set; }

    }
}
