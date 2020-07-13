using System;
using System.Collections.Generic;
using System.ComponentModel;
using Falcon.App.Core.Application.Attributes;
using Falcon.App.Core.Application.ViewModels;
using Falcon.App.Core.Communication.Domain;
using Falcon.App.Core.Geo.Domain;

namespace Falcon.App.Core.Scheduling.ViewModels
{
    public class CancelledCustomerModel : ViewModelBase
    {
        [DisplayName("Customer Id")]
        public long CustomerId { get; set; }

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

        [DisplayName("Ad Source")]
        public string AdSource { get; set; }

        public string Pod { get; set; }

        [DisplayName("EventId")]
        public long EventId { get; set; }

        [DisplayName("Event Date")]
        public DateTime EventDate { get; set; }

        [DisplayName("Host")]
        public string Host { get; set; }

        [DisplayName("Host Address")]
        public Address HostAddress { get; set; }

        [DisplayName("Total Amount")]
        [Format("00.00")]
        public decimal TotalAmount { get; set; }

        [DisplayName("Signup Method")]
        public string SignUpMethod { get; set; }

        [DisplayName("Scheduled By")]
        public string ScheduledBy { get; set; }

        [DisplayName("Canceled By")]
        public string CancelledBy { get; set; }

        [DisplayName("Cancellation Reason")]
        public string CancellationReason { get; set; }

        public string SubReason { get; set; }

        [DisplayName("Notes")]
        public IEnumerable<CustomerCallNotes> Notes { get; set; }

        [DisplayName("Canceled Date")]
        [Format("MM/dd/yyyy")]
        public string CanceledDate { get; set; }

        [DisplayName("Sponsored By")]
        public string SponsoredBy { get; set; }

        [Hidden]
        public long OrderId { get; set; }
    }
}
