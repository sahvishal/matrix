using System;
using System.Collections.Generic;
using System.ComponentModel;
using Falcon.App.Core.Application.Attributes;
using Falcon.App.Core.Application.ViewModels;
using Falcon.App.Core.Geo.ViewModels;
using Falcon.App.Core.ValueTypes;

namespace Falcon.App.Core.Sales.ViewModels
{
    public class CorporateAccountCustomerViewModel : ViewModelBase
    {
        [DisplayName("Customer Id")]
        public long CustomerId { get; set; }

        [Hidden]
        public Name CustomerName { get; set; }

        [DisplayName("First Name")]
        public string FirstName { get { return CustomerName.FirstName; } }

        [DisplayName("Middle Name")]
        public string MiddleName { get { return CustomerName.MiddleName; } }

        [DisplayName("Last Name")]
        public string LastName { get { return CustomerName.LastName; } }

        [Hidden]
        public AddressViewModel Address { get; set; }

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

        public string Country
        {
            get
            {
                if (Address != null) return Address.Country;
                return string.Empty;
            }
        }

        public string Zip
        {
            get
            {
                if (Address != null) return Address.ZipCode;
                return string.Empty;
            }
        }

        public string Email { get; set; }

        [DisplayName("Best Number to Call")]
        public string Phone { get; set; }

        [DisplayName("Phone(C)")]
        public string PhoneCell { get; set; }

        [DisplayName("Phone(O)")]
        public string PhoneOffice { get; set; }

        [DisplayName("Phone(O) Extn.")]
        public string PhoneOfficeExtn { get; set; }

        [DisplayName("DOB")]
        [Format("MM/dd/yyyy")]
        public DateTime? DateofBirth { get; set; }

        public string Gender { get; set; }

        [DisplayName("Height (inches)")]
        public string Height { get; set; }

        [DisplayName("Weight (lbs)")]
        public string Weight { get; set; }

        [DisplayName("Physician Name")]
        public string PrimaryCarePhysicianName { get; set; }

        [DisplayName("Preferred language")]
        public string PreferredLanguage { get; set; }

        [DisplayName("Best Time to Call")]
        public string BestTimeToCall { get; set; }

        [DisplayName("SSN")]
        public string Ssn { get; set; }


        [DisplayName("Member Id")]
        public string MemberId { get; set; }

        public string HicnNumber { get; set; }

        [DisplayName("Event Id")]
        public long EventId { get; set; }

        [DisplayName("Screening Date")]
        [Format("MM/dd/yyyy")]
        public DateTime EventDate { get; set; }

        [DisplayName("Corporate Sponsor")]
        public string CorporateSponsor { get; set; }

        public string Pod { get; set; }

        public string Package { get; set; }

        [DisplayName("Images")]
        public string CdPurchased { get; set; }

        [DisplayName("Result Summary")]
        public string Result { get; set; }

        [DisplayName("Pathway Recommendation")]
        public string Recommendation { get; set; }

        [DisplayName("Shipping Mode")]
        public string ShippingMode { get; set; }

        [DisplayName("Mailed Status")]
        public string MailedStatus { get; set; }

        [DisplayName("Mailed On")]
        [Format("MM/dd/yyyy")]
        public DateTime? MailedOn { get; set; }

        [DisplayName("Delivered On")]
        [Format("MM/dd/yyyy")]
        public DateTime? DeliveredOn { get; set; }

        [Hidden]
        public bool IsPdfGenerated { get; set; }

        [Hidden]
        public bool IsEvaluated { get; set; }

        public IEnumerable<OrderedPair<long, string>> TestSummary { get; set; }

        [Hidden]
        public string PrimaryCare { get; set; }

        [Hidden]
        public string MammogramProstateScreening { get; set; }

        [Hidden]
        public string Colonoscopy { get; set; }

        [Hidden]
        public string Cancer { get; set; }

        [Hidden]
        public string WeightBariatric { get; set; }

        [Hidden]
        public long EventCustomerId { get; set; }

        [Hidden]
        public bool IsCannedMessageSent { get; set; }

        [Hidden]
        public bool HasCannedMessage { get; set; }

        [Hidden]
        public bool ShowScannedDocumentUrl { get; set; }

        [Hidden]
        public string ScannedDocumentUrl { get; set; }
    }
}
