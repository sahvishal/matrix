using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using Falcon.App.Core.Application.Attributes;
using Falcon.App.Core.Application.ViewModels;
using Falcon.App.Core.Geo.Domain;
using Falcon.App.Core.Scheduling.Enum;

namespace Falcon.App.Core.Scheduling.ViewModels
{
    public class EventScheduleModel : ViewModelBase
    {
        [DisplayName("Event Id")]
        public long EventCode { get; set; }

        [DisplayName("Event Date")]
        [Format("MM/dd/yyyy")]
        public DateTime EventDate { get; set; }

        public string Location { get; set; }

        [Hidden]
        public Address Address { get; set; }

        [DisplayName("Street")]
        public string StreetAddressLine1
        {
            get
            {
                if (Address != null && string.IsNullOrEmpty(Address.StreetAddressLine2))
                {
                    return Address.StreetAddressLine1;
                }

                if (Address != null && !string.IsNullOrEmpty(Address.StreetAddressLine2))
                {
                    return Address.StreetAddressLine1 + ", " + Address.StreetAddressLine2;
                }
                return string.Empty;
            }
        }

        //[DisplayName("Street 2")]
        //public string StreetAddressLine2
        //{
        //    get
        //    {
        //        if (Address != null) return Address.StreetAddressLine2;
        //        return string.Empty;
        //    }
        //}

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

        [DisplayName("Slots Booked")]
        public int AppointmentsBooked { get; set; }

        [DisplayName("Screened Customers")]
        public int ScreenedCustomers { get; set; }

        public EventStatus Status { get; set; }

        public string Pod { get; set; }

        [DisplayName("No Show")]
        public int NoShow { get; set; }
    }
}