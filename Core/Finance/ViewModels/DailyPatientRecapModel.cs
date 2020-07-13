using System;
using System.ComponentModel;
using Falcon.App.Core.Application.Attributes;
using Falcon.App.Core.Application.ViewModels;
using Falcon.App.Core.Geo.Domain;
using Falcon.App.Core.ValueTypes;

namespace Falcon.App.Core.Finance.ViewModels
{
    public class DailyPatientRecapModel : ViewModelBase
    {
        [DisplayName("Event Id")]
        public long EventId { get; set; }

        [DisplayName("Event Date")]
        [Format("MM/dd/yyyy")]
        public DateTime EventDate { get; set; }

        [DisplayName("Customer Id")]
        public long CustomerId { get; set; }

        [DisplayName("Name")]
        public Name Name { get; set; }

        [DisplayName("DoB")]
        [Format("MM/dd/yyyy")]
        public DateTime? DateOfBirth { get; set; }

        [DisplayName("Address")]
        public Address Address { get; set; }

        [DisplayName("Phone")]
        public PhoneNumber Phone { get; set; }

        [DisplayName("Email")]
        public Email Email { get; set; }

        [DisplayName("Member Id")]
        public string MemeberId { get; set; }

        [DisplayName("Gender")]
        public string Gender { get; set; }

        [DisplayName("Pod")]
        public string Pod { get; set; }

        [DisplayName("Package")]
        public string Package { get; set; }

        [DisplayName("Test(s)")]
        public string Tests { get; set; }

        [DisplayName("Shipping Purchased")]
        public string IsShippingPurchased { get; set; }

        [DisplayName("Images Purchased")]
        public string IsCdPurchased { get; set; }

        [DisplayName("Discount")]
        public decimal Discount { get; set; }

        [DisplayName("Total Amount")]
        public decimal TotalAmount { get; set; }

        [DisplayName("Amount Collected")]
        public decimal AmountCollected { get; set; }

        [DisplayName("Hospital Partner")]
        public string HospitalPartner { get; set; }

        [DisplayName("Corporate Account")]
        public string CorporatePartner { get; set; }

        [DisplayName("Check In")]
        [Format("hh:mm tt")]
        public DateTime? CheckedIn { get; set; }

        [DisplayName("Check Out")]
        [Format("hh:mm tt")]
        public DateTime? CheckedOut { get; set; }

        [DisplayName("GC Delivered")]
        public string IsGiftCertificateDeleievred { get; set; }

        [DisplayName("Gift Code")]
        public string GiftCode { get; set; }

        [DisplayName("Reason")]
        public string GcNotGivenReason { get; set; }
    }
}
