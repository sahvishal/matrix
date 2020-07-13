using Falcon.App.Core.Application.Attributes;
using Falcon.App.Core.Geo.Domain;
using Falcon.App.Core.ValueTypes;
using System;
using System.ComponentModel;

namespace Falcon.App.Core.CallCenter.ViewModels
{
    public class BcbsMiIncorrectPhoneViewModel
    {
        [Hidden]
        public long CustomerId { get; set; }

        [DisplayName("Customer Id")]
        public string CustomerCode { get; set; }

        [Hidden]
        public Name CustomerName { get; set; }

        [Hidden]
        public Address Address { get; set; }

        [DisplayName("First Name")]
        public string FirstName { get { return CustomerName.FirstName; } }

        [DisplayName("Middle Name")]
        public string MiddleName { get { return CustomerName.MiddleName; } }

        [DisplayName("Last Name")]
        public string LastName { get { return CustomerName.LastName; } }

        [Format("MM/dd/yyyy")]
        public DateTime? DOB { get; set; }

        [DisplayName("Best Number to Call")]
        public string Phone { get; set; }

        [DisplayName("Phone(C)")]
        public string PhoneCell { get; set; }

        [DisplayName("Phone(O)")]
        public string PhoneOffice { get; set; }
        public string Email { get; set; }

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

        [DisplayName("Custom Tag")]
        public string CustomTag { get; set; }

        [DisplayName("Member Id")]
        public string MemberId { get; set; }

        [DisplayName("HICN")]
        public string Hicn { get; set; }

        [DisplayName("PCP Name")]
        public string PcpName { get; set; }

        [DisplayName("PCP Phone Number")]
        public string PcpPhone { get; set; }

        [DisplayName("Market")]
        public string Market { get; set; }

        [DisplayName("Group Name")]
        public string GroupName { get; set; }

        [DisplayName("Date")]
        [Format("MM/dd/yyyy")]
        public DateTime? DateAddedtoReport { get; set; }
    }
}
