using System;
using System.Collections.Generic;
using Falcon.App.Core.Geo.Domain;
using Falcon.App.Core.Application.ViewModels;
using System.ComponentModel;
using Falcon.App.Core.Application.Attributes;
using Falcon.App.Core.Scheduling.Enum;

namespace Falcon.App.Core.Scheduling.ViewModels
{
    public class EventVolumeModel : ViewModelBase
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

        //[DisplayName("Hub")]
        //public string Territory { get; set; }
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

        [DisplayName("Primary Physician")]
        public string PrimaryPhysician { get; set; }

        [DisplayName("OverRead Physician")]
        public string OverReadPhysician { get; set; }

        [DisplayName("Technician Assigned")]
        public IEnumerable<string> Technicians { get; set; }

        [DisplayName("Hospital Partner")]
        public string HospitalPartner { get; set; }

        [DisplayName("Corporate Sponsor")]
        public string CorporateAccount { get; set; }

        [DisplayName("Recommend Package")]
        public bool RecommendPackage { get; set; }

        [Hidden]
        public bool IsCorporateEvent { get; set; }

        public EventStatus Status { get; set; }
    }
}
