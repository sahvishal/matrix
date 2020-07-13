using System;
using System.Collections.Generic;
using System.ComponentModel;
using Falcon.App.Core.Application.Attributes;
using Falcon.App.Core.Application.ViewModels;
using Falcon.App.Core.Enum;
using Falcon.App.Core.Geo.Domain;
using Falcon.App.Core.Marketing.Enum;
using Falcon.App.Core.Users.Enum;
using Falcon.App.Core.ValueTypes;

namespace Falcon.App.Core.Marketing.ViewModels
{
    public class ProspectCustomerBasicInfoModel : ViewModelBase
    {
        [Hidden]
        public long Id { get; set; }

        [DisplayName("Customer Id")]
        public long? CustomerId { get; set; }

        [DisplayName("First Name")]
        public string FirstName { get; set; }
        
        [DisplayName("Last Name")]
        public string LastName { get; set; }

        public Gender Gender { get; set; }

        [DisplayName("Phone")]
        public PhoneNumber CallBackPhoneNumber { get; set; }

        [DisplayName("Phone(Other)")]
        public PhoneNumber PhoneNumber { get; set; }

        [Hidden]
        public Address Address { get; set; }

        [DisplayName("Address")]
        public string StreetAddress
        {
            get
            {
                if (Address != null)
                    return Address.StreetAddressLine1 + " " + Address.StreetAddressLine2;
                return string.Empty;
            }
        }
        public string City
        {
            get { return (Address != null ? Address.City : ""); }
        }

        public string Zip
        {
            get { return (Address != null ? Address.ZipCode.Zip : ""); }
        }

        public string State
        {
            get { return (Address != null ? Address.State : ""); }
        }

        public string Email { get; set; }

        [Format("MM/dd/yyyy")]
        public DateTime? DateOfBirth { get; set; }

        public string Source { get; set; }
        public ProspectCustomerTag Tag { get; set; }

        [DisplayName("Corporate Tag")]
        public string CorporateTag { get; set; }

        [DisplayName("Custom Tag")]
        public string CustomTags { get; set; }

        [DisplayName("Corporate Sponsor")]
        public string CorporateSponsor { get; set; }

        [DisplayName("Member Id")]
        public string MemberId { get; set; }

        [DisplayName("Source Code")]
        public string SourceCode { get; set; }

        [DisplayName("marketing Source")]
        public string MarketingSource { get; set; }

        [Format("MM/dd/yyyy")]
        [DisplayName("Created On")]
        public DateTime CreatedOn { get; set; }

        [DisplayName("Is Contacted")]
        public bool IsContacted { get; set; }

        [DisplayName("Contacted Date")]
        [Format("MM/dd/yyyy")]
        public DateTime? ContactedDate { get; set; }

        [DisplayName("Contacted By")]
        public string ContactedBy { get; set; }
        
        public ProspectCustomerConversionStatus Status { get; set; }

        public IEnumerable<NotesViewModel> Notes { get; set; }

    }
}