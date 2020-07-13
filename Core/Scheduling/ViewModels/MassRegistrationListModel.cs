using System;
using System.Collections.Generic;
using Falcon.App.Core.Application.ViewModels;
using Falcon.App.Core.Geo.Domain;
using Falcon.App.Core.Marketing.Domain;
using Falcon.App.Core.Scheduling.Domain;

namespace Falcon.App.Core.Scheduling.ViewModels
{
    public class MassRegistrationListModel:ViewModelBase
    {
        public long EventId { get; set; }
        public string EventName { get; set; }
        public DateTime EventDate { get; set; }
        public Address EventAddress { get; set; }
        public int RegisteredCustomersCount { get; set; } 
        public IEnumerable<MassRegistrationEditModel> Registrations { get; set; }

        public IEnumerable<Package> Packages { get; set; }
        public IEnumerable<EventSchedulingSlot> Appointments { get; set; }
        public IEnumerable<Country> Countries { get; set; }
        public IEnumerable<State> States { get; set; }
        public IEnumerable<OrderedPair<int, string>> Races { get; set; }
        public IEnumerable<OrderedPair<int, string>> Genders { get; set; }
    }
}
