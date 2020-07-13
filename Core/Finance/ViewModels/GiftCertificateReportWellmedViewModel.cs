using System;
using System.ComponentModel;
using Falcon.App.Core.Application.Attributes;
using Falcon.App.Core.Application.ViewModels;

namespace Falcon.App.Core.Finance.ViewModels
{
    public class GiftCertificateReportWellmedViewModel : ViewModelBase
    {
        [DisplayName("Customer Id")]
        public long CustomerId { get; set; }

        [DisplayName("First Name")]
        public string FirstName { get; set; }

        [DisplayName("Middle Name")]
        public string MiddleName { get; set; }

        [DisplayName("Last Name")]
        public string LastName { get; set; }

        [DisplayName("Member Id")]
        public string MemberId { get; set; }

        [Hidden]
        [DisplayName("Phone Number")]
        public string PhoneHome { get; set; }

        [Hidden]
        public string Gender { get; set; }

        [Hidden]
        [DisplayName("DOB")]
        [Format("MM/dd/yyyy")]
        public DateTime? DateofBirth { get; set; }

        [DisplayName("Address 1")]
        public string Address1 { get; set; }

        [DisplayName("Address 2")]
        public string Address2 { get; set; }

        public string City { get; set; }

        public string State { get; set; }

        public string Zip { get; set; }

        public string Tag { get; set; }

        [Hidden]
        public string Email { get; set; }

        public long EventId { get; set; }

        [DisplayName("Event Name")]
        public string EventName { get; set; }

        [DisplayName("Event Date")]
        [Format("MM/dd/yyyy")]
        public DateTime? EventDate { get; set; }

        [Hidden]
        [DisplayName("Event Address 1")]
        public string EventAddress1 { get; set; }

        [Hidden]
        [DisplayName("Event Address 2")]
        public string EventAddress2 { get; set; }

        [Hidden]
        [DisplayName("Event City")]
        public string EventCity { get; set; }

        [Hidden]
        [DisplayName("Event State")]
        public string EventState { get; set; }

        [Hidden]
        [DisplayName("Event Zip")]
        public string EventZip { get; set; }

        [DisplayName("Pod Name")]
        public string Pod { get; set; }

        public string Package { get; set; }

        [Hidden]
        [DisplayName("Gift Certificate Delivered")]
        public bool? IsGiftCertificateDelivered { get; set; }

        [DisplayName("Gift Code")]
        public string GiftCode { get; set; }

        [DisplayName("Mrn")]
        public string Mrn { get; set; }
    }
}
