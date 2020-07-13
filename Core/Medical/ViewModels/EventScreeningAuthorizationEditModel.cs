using System.Collections.Generic;
using System.ComponentModel;
using Falcon.App.Core.Application.ViewModels;
using Falcon.App.Core.Geo.ViewModels;
using Falcon.App.Core.Medical.Domain;

namespace Falcon.App.Core.Medical.ViewModels
{
    public class EventScreeningAuthorizationEditModel:ViewModelBase
    {
        [DisplayName("Event Id")]
        public long EventId { get; set; }

        [DisplayName("Event Name")]
        public string EventName { get; set; }

        public AddressViewModel EventAddress { get; set; }

        public IEnumerable<Test> EventTests { get; set; }

        public IEnumerable<CustomerScreeningAuthorizationEditModel> Customers { get; set; }
    }
}
