using System;
using System.ComponentModel;
using Falcon.App.Core.Application.Attributes;
using Falcon.App.Core.Application.ViewModels;
using Falcon.App.Core.Geo.Domain;
using Falcon.App.Core.ValueTypes;

namespace Falcon.App.Core.Finance.ViewModels
{
    public class DailyPatientRecapCustomModel : ViewModelBase
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

        [DisplayName("Member Id")]
        public string MemeberId { get; set; }

        [DisplayName("Pod")]
        public string Pod { get; set; }

        [DisplayName("Package")]
        public string Package { get; set; }

        [DisplayName("Test(s)")]
        public string Tests { get; set; }

        [DisplayName("Corporate Account")]
        public string CorporatePartner { get; set; }
    }
}
