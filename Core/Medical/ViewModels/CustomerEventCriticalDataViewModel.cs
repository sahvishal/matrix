using System;
using System.Collections.Generic;
using System.ComponentModel;
using Falcon.App.Core.Application.Attributes;
using Falcon.App.Core.Application.Domain;
using Falcon.App.Core.Application.ViewModels;
using Falcon.App.Core.Geo.ViewModels;

namespace Falcon.App.Core.Medical.ViewModels
{
    public class CustomerEventCriticalDataViewModel:ViewModelBase
    {
        [Hidden]
        public long EventCustomerResultId { get; set; }

        [DisplayName("Customer Id")]
        public long CustomerId { get; set; }

        [DisplayName("Name")]
        public string CustomerName { get; set; }

        [DisplayName("Address")]
        public AddressViewModel Address { get; set; }

        public string Email { get; set; }

        [DisplayName("Contact Number")]
        public string Phone { get; set; }

        [DisplayName("Package Screened For")]
        public string CustomerOrder { get; set; }

        [DisplayName("Event Id")]
        public long EventId { get; set; }

        [DisplayName("Event Name")]
        public string EventName { get; set; }

        [Format("MM/dd/yyyy")]
        public DateTime EventDate { get; set; }

        public string Pod { get; set; }

        [DisplayName("Hospital Sponsor")]
        public string HospitalSponsor { get; set; }

        [DisplayName("Primary Care Physician")]
        public string PrimaryCarePhysician { get; set; }

        [DisplayName("Evaluating Physician")]
        public string PrimaryPhysician { get; set; }

        [DisplayName("Overread Physician")]
        public string OverReadPhysician { get; set; }

        [DisplayName("Critical/Urgent")]
        public string Result { get; set; }

        public IEnumerable<CustomerEventCriticalTestDataViewModel> Tests { get; set; }

        public IEnumerable<Notes> Notes { get; set; }
    }
}
