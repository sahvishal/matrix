using System;
using System.Collections.Generic;
using System.ComponentModel;
using Falcon.App.Core.Application.Attributes;
using Falcon.App.Core.Application.ViewModels;
using Falcon.App.Core.Geo.ViewModels;
using Falcon.App.Core.Medical.Enum;

namespace Falcon.App.Core.Medical.ViewModels
{
    public class TechnicalLimitedScreeningCustomerViewModel : ViewModelBase
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
        public string Phone { get; set; }

        public long EventId { get; set; }
        public string EventName { get; set; }
        [Format("MM/dd/yyyy")]
        public DateTime EventDate { get; set; }
        public string Pod { get; set; }
        [DisplayName("Package Screened For")]
        public string CustomerOrder { get; set; }
        public IEnumerable<TestUnabletoScreenViewModel> Test { get; set; }
        public TestResultStateLabel CurrentState { get; set; }

    }
}