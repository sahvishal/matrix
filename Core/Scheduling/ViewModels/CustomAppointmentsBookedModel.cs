using System;
using System.Collections.Generic;
using System.ComponentModel;
using Falcon.App.Core.Application.Attributes;
using Falcon.App.Core.Application.ViewModels;
using Falcon.App.Core.Geo.Domain;

namespace Falcon.App.Core.Scheduling.ViewModels
{
    public class CustomAppointmentsBookedModel : ViewModelBase
    {
        [Hidden]
        public long CustomerId { get; set; }

        [DisplayName("Customer Id")]
        public string CustomerCode { get; set; }

        [DisplayName("Registrant ID")]
        public string RegistrantId { get; set; }

        [DisplayName("Cancelled/Rescheduled")]
        public string RegistrationStatus { get; set; } // Cancelled/ Rescheduled

        [DisplayName("Reschedule Info")]
        public IEnumerable<RescheduleApplointmentModel> RescheduleInfo { get; set; }

        [DisplayName("Event Date")]
        [Format("MM/dd/yyyy")]
        public DateTime EventDate { get; set; }

        [DisplayName("Appointment Time")]
        [Format("hh:mm tt")]
        public DateTime? AppointmentTime { get; set; }

        [DisplayName("Customer Name")]
        public string CustomerName { get; set; }

        [DisplayName("DOB")]
        [Format("MM/dd/yyyy")]
        public DateTime? DateofBirth { get; set; }

        public string Gender { get; set; }

        [DisplayName("Region Group")]
        public string Market { get; set; }

        [DisplayName("Region Name")]
        public string AdditionalField3 { get; set; }

        [DisplayName("Entity Type")]
        public string AdditionalField4 { get; set; }

        public string Language { get; set; }

        [DisplayName("Preferred Contact")]
        public string PreferredContactType { get; set; }

        [DisplayName("PCP Key")]
        public string PcpNpi { get; set; }


        [DisplayName("PCP Name")]
        public string PcpName { get; set; }

        [DisplayName("PCP Address 1")]
        public string PcpAddress1 { get; set; }

        [DisplayName("PCP Address 2")]
        public string PcpAddress2 { get; set; }

        [DisplayName("PCP City")]
        [Hidden]
        public string PcpCity { get; set; }

        [DisplayName("PCP State")]
        [Hidden]
        public string PcpState { get; set; }

        [DisplayName("PCP Zip")]
        [Hidden]
        public string PcpZip { get; set; }

        [DisplayName("PCP City_ST_Zip")]
        public string PcpCityStateZip
        {
            get
            {
                return string.IsNullOrEmpty(PcpCity) ? string.Empty : PcpCity + "_" + PcpState + "_" + PcpZip;
            }
        }


        [DisplayName("PCP Phone")]
        public string PcpPhone { get; set; }

        [DisplayName("Member Id")]
        public string InsuranceId { get; set; }

        [DisplayName("Customer Name")]
        public string CustomerName1 { get { return CustomerName; } }

        [Hidden]
        [DisplayName("Customer Address")]
        public Address Address { get; set; }

        public string Address1
        {
            get
            {
                if (Address != null) return Address.StreetAddressLine1;
                return string.Empty;
            }
        }

        public string Address2
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

        [DisplayName("Phone(H)")]
        public string PhoneHome { get; set; }

        [DisplayName("Phone(C)")]
        public string PhoneCell { get; set; }

        [DisplayName("Medicare Advantage Plan Name")]
        public string MedicareAdvantagePlanName { get; set; }

        public string Package { get; set; }

        [DisplayName("Host")]
        public string Host { get; set; }

        [DisplayName("Host Address")]
        public Address HostAddress { get; set; }


        [DisplayName("Status")]
        public string Status { get; set; }

        [DisplayName("Registration Date")]
        [Format("MM/dd/yyyy")]
        public DateTime RegistrationDate { get; set; }

        [DisplayName("Event Id")]
        public string EventId { get; set; }

        [DisplayName("Plan Type")]
        public string GroupName { get; set; }
    }
}