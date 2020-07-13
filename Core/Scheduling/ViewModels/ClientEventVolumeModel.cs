using Falcon.App.Core.Application.Attributes;
using Falcon.App.Core.Application.ViewModels;
using Falcon.App.Core.Geo.Domain;
using Falcon.App.Core.Scheduling.Enum;
using System;
using System.ComponentModel;

namespace Falcon.App.Core.Scheduling.ViewModels
{
    public class ClientEventVolumeModel:ViewModelBase
    {
        [DisplayName("Event Id")]
        public long EventCode { get; set; }

        [DisplayName("Event Date")]
        [Format("MM/dd/yyyy")]
        public DateTime EventDate { get; set; }

        [Hidden]
        public string EventType { get; set; }

        public string Location { get; set; }
        [Hidden]
        public Address Address { get; set; }

        public string StreetAddressLine1
        {
            get
            {
                if (Address != null) return Address.StreetAddressLine1;
                return string.Empty;
            }
        }

        public string StreetAddressLine2
        {
            get
            {
                if (Address != null) return Address.StreetAddressLine2;
                return string.Empty;
            }
        }
        public string City
        {
            get
            {
                if (Address != null) return Address.City;
                return string.Empty;
            }
        }

        public string State
        {
            get
            {
                if (Address != null) return Address.State;
                return string.Empty;
            }
        }

        public string Zip
        {
            get
            {
                if (Address != null) return Address.ZipCode.Zip;
                return string.Empty;
            }
        }

        [DisplayName("Pod")]
        public string Pod { get; set; }

        [DisplayName("Slots Booked")]
        public int AppointmentsBooked { get; set; }

        [DisplayName("Total Slots")]
        public int TotalSlots { get; set; }

        [DisplayName("Available Slots")]
        public int AvailableSlots { get; set; }

        [DisplayName("Screened Customers")]
        public int ScreenedCustomers { get; set; }     

        [DisplayName("Hospital Partner")]
        public string HospitalPartner { get; set; }

        [DisplayName("Corporate Sponsor")]
        public string CorporateAccount { get; set; }

        public EventStatus Status { get; set; }  
    }
}
