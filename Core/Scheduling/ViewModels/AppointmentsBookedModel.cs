using System;
using System.Collections.Generic;
using Falcon.App.Core.Geo.Domain;
using Falcon.App.Core.Application.ViewModels;
using Falcon.App.Core.Application.Attributes;
using System.ComponentModel;

namespace Falcon.App.Core.Scheduling.ViewModels
{
    public class AppointmentsBookedModel : ViewModelBase
    {
        [Hidden]
        public long CustomerId { get; set; }

        [DisplayName("Customer Id")]
        public string CustomerCode { get; set; }

        [DisplayName("Event Id")]
        public string EventId { get; set; }

        [DisplayName("Package Recommend")]
        public string RecommendPackage { get; set; }

        [DisplayName("Customer Name")]
        public string CustomerName { get; set; }

        [DisplayName("Requested Newsletter")]
        public string RequestedNewsLetter { get; set; }

        public string Gender { get; set; }

        public string Language { get; set; }

        [DisplayName("Preferred Contact")]
        public string PreferredContactType { get; set; }

        public string Market { get; set; }

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

        [DisplayName("Predicted Zip")]
        public string PredictedZip { get; set; }

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

        [DisplayName("Member Id")]
        public string InsuranceId { get; set; }

        [DisplayName("SSN Captured")]
        public string SsnCaptured { get; set; }

        [DisplayName("Medicare Id")]
        public string Hicn { get; set; }

        [DisplayName("Medicare Advantage Number")]
        public string MedicareAdvantageNumber { get; set; }

        [DisplayName("Medicare Advantage Plan Name")]
        public string MedicareAdvantagePlanName { get; set; }

        [DisplayName("Registration Date")]
        [Format("MM/dd/yyyy")]
        public DateTime RegistrationDate { get; set; }

        [DisplayName("Registration Time")]
        [Format("hh:mm tt")]
        public DateTime RegistrationTime
        {
            get
            {
                return RegistrationDate;
            }
        }

        [DisplayName("Cancelled/Rescheduled")]
        public string RegistrationStatus { get; set; } // Cancelled/ Rescheduled

        [Hidden]
        [DisplayName("Is Confirmed?")]
        public string IsConfirmed { get; set; }

        [Hidden]
        [DisplayName("Confirmed By")]
        public string ConfirmedBy { get; set; }

        [DisplayName("Appointment Time")]
        [Format("hh:mm tt")]
        public DateTime? AppointmentTime { get; set; }

        public string Package { get; set; }

        //[DisplayName("HAF Status")]
        //public string HafStatus { get; set; }

        [DisplayName("Shipping Option")]
        public IEnumerable<string> ShippingOptions { get; set; }

        [DisplayName("Shipping Cost")]
        [Format("00.00")]
        public decimal ShippingCost { get; set; }

        [DisplayName("Images Purchased")]
        public string ImagesPurchased { get; set; }

        [DisplayName("Images Cost")]
        [Format("00.00")]
        public decimal ImagesCost { get; set; }

        [DisplayName("Cost (Package + Test + Product + Shipping)")]
        [Format("00.00")]
        public decimal PackageCost { get; set; }

        [DisplayName("Total Amount")]
        [Format("00.00")]
        public decimal TotalAmount { get; set; }
        [Hidden]
        public decimal AmountPaid { get; set; }

        [DisplayName("Amount Due")]
        [Format("00.00")]
        public decimal AmountDue
        {
            get { return TotalAmount - AmountPaid; }
        }

        [DisplayName("Reimbursement Rate")]
        public decimal ReimbursementRate { get; set; }

        [DisplayName("Pre-Paid")]
        public string PrePaid
        {
            get
            {
                return AmountPaid > 0 ? "Yes" : "No";
            }
        }

        [DisplayName("Pod")]
        public string Pod { get; set; }
        [DisplayName("Source Code")]
        public string PriortyCode { get; set; }
        [DisplayName("Discount")]
        public decimal PriortyCodeDiscount { get; set; }
        [DisplayName("Ad Source")]
        public string AdSource { get; set; }

        [DisplayName("Event Date")]
        [Format("MM/dd/yyyy")]
        public DateTime EventDate { get; set; }

        [DisplayName("Event Type")]
        public string EventType { get; set; }

        [DisplayName("Host")]
        public string Host { get; set; }
        [DisplayName("Host Address")]
        public Address HostAddress { get; set; }

        [DisplayName("Sponsored By")]
        public string SponsoredBy { get; set; }

        [DisplayName("Incoming Phone Line")]
        public string IncomingPhoneLine { get; set; }

        [DisplayName("Callers Phone number")]
        public string CallersPhoneNumber { get; set; }

        [DisplayName("Last Screening Date")]
        public string LastScreeningDate { get; set; }

        [DisplayName("Registration Mode")]
        public string RegisterationByRole { get; set; } // Registering agent role

        [DisplayName("Call Type")]
        public string CallType { get; set; }

        [DisplayName("Booking Agent")]
        public string RegisteredBy { get; set; } // Registering agent

        [DisplayName("PCP Name")]
        public string PcpName { get; set; }

        [DisplayName("PCP Phone")]
        public string PcpPhone { get; set; }

        [DisplayName("PCP Fax")]
        public string PcpFax { get; set; }

        [DisplayName("PCP NPI")]
        public string PcpNpi { get; set; }

        [DisplayName("Reschedule Info")]
        public IEnumerable<RescheduleApplointmentModel> RescheduleInfo { get; set; }

        [DisplayName("Check In")]
        [Format("hh:mm tt")]
        public DateTime? CheckInTime { get; set; }

        [DisplayName("Check Out")]
        [Format("hh:mm tt")]
        public DateTime? CheckOutTime { get; set; }

        [DisplayName("Status")]
        public string Status { get; set; }

        public string Tag { get; set; }

        [DisplayName("Custom Tag(s)")]
        public string CustomTag { get; set; }

        [DisplayName("PCP Appointment Date")]
        [Format("MM/dd/yyyy")]
        public DateTime? PcpAppointmentDate { get; set; }

        [DisplayName("PCP Appointment Time")]
        [Format("hh:mm tt")]
        public DateTime? PcpAppointmentTime
        {
            get
            {
                return PcpAppointmentDate;
            }
        }

        [DisplayName("Is Eligible")]
        public string IsEligible { get; set; }

        [DisplayName("Group Name")]
        public string GroupName { get; set; }

        [DisplayName("Additional Fields")]
        public IEnumerable<OrderedPair<string, string>> AdditionalFields { get; set; }

        [DisplayName("Product")]
        public string Product { get; set; }
    }
}
