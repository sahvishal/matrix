using System;
using Falcon.App.Core.Geo.Domain;
using Falcon.App.Core.Application.ViewModels;
using Falcon.App.Core.Application.Attributes;
using System.ComponentModel;

namespace Falcon.App.Core.Scheduling.ViewModels
{
    public class NoShowCustomerModel : ViewModelBase
    {
        [Hidden]
        public long CustomerId { get; set; }

        [DisplayName("Customer Id")]
        public string CustomerCode { get; set; }
        [DisplayName("Customer Name")]
        public string CustomerName { get; set; }
        
        public string Gender { get; set; }
        public Address Address { get; set; }
        public string Email { get; set; }

        [DisplayName("DOB")]
        [Format("MM/dd/yyyy")]
        public DateTime? DateofBirth { get; set; }

        [DisplayName("Phone(H)")]
        public string PhoneHome { get; set; }
        [DisplayName("Phone(C)")]
        public string PhoneCell { get; set; }
        [DisplayName("Phone(O)")]
        public string PhoneBusiness { get; set; }
        [DisplayName("Phone(O) Ext")]
        public string PhoneOfficeExtension { get; set; }

        [DisplayName("Time Slot")]
        [Format("hh:mm tt")]
        public DateTime? AppointmentTime { get; set; }
        public string Package { get; set; }
        
        [DisplayName("Total Amount")]
        public decimal TotalAmount { get; set; }

        [Hidden]
        public decimal AmountPaid { get; set; }
        
        [DisplayName("Amt. Due")]
        [Format("00.00")]
        public decimal AmountDue
        {
            get { return TotalAmount - AmountPaid; }
        }

        [DisplayName("Ad Source")]
        public string AdSource { get; set; }
        
        public string Pod { get; set; }

        [DisplayName("EventId")]
        public long EventId { get; set; }

        [DisplayName("Event Date")]
        [Format("MM/dd/yyyy")]
        public DateTime EventDate { get; set; }
        
        [DisplayName("Host")]
        public string Host { get; set; }

        [DisplayName("Host Address")]
        public Address HostAddress { get; set; }

        [DisplayName("Booking Agent")]
        public string BookingAgent { get; set; }

        [DisplayName("Registration Mode")]
        public string RegistrationMode { get; set; }

        [DisplayName("Registration Date")]
        [Format("MM/dd/yyyy")]
        public DateTime? RegistrationDate { get; set; }

        [DisplayName("PCP Appointment Date")]
        [Format("MM/dd/yyyy")]
        public DateTime? PCPAppointmentDate { get; set; }

        [DisplayName("PCP Appointment Time")]        
        public string PCPAppointmentTime { get; set; }
    }
}
