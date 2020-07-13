using System;
using System.Collections.Generic;
using Falcon.App.Core.Application.Domain;
using Falcon.App.Core.Application.ViewModels;
using Falcon.App.Core.Sales.Domain;
using Falcon.App.Core.Sales.ViewModels;
using Falcon.App.Core.Scheduling.Domain;

namespace Falcon.App.Core.Sales
{
    public interface IHospitalPartnerEventListFactory
    {
        IEnumerable<HospitalPartnerEventViewModel> Create(IEnumerable<Event> events, IEnumerable<Host> hosts,
                                                          IEnumerable<OrderedPair<long, int>> screenedCustomersCount,
                                                          IEnumerable<OrderedPair<long, int>> criticalCustomersCount,
                                                          IEnumerable<OrderedPair<long, int>> abnormalCustomersCount,
                                                          IEnumerable<OrderedPair<long, long>> eventIdNotesIdPairs,
                                                          IEnumerable<Notes> notes, IEnumerable<OrderedPair<long, int>> urgentCustomersCount, IEnumerable<OrderedPair<long, int>> normalCustomersCount, IEnumerable<OrderedPair<long, string>> idNamePairs);

        HospitalPartnerEventViewModel Create(Event theEvent, Host host, DateTime? mailedDate);

        IEnumerable<HospitalPartnerEventViewModel> Create(IEnumerable<Event> events, IEnumerable<Host> hosts,
                                                          IEnumerable<OrderedPair<long, DateTime>> recentEvents);

        IEnumerable<NotesViewModel> CreateNotesViewModel(IEnumerable<Notes> notes, IEnumerable<OrderedPair<long, string>> idNamePairs);
    }
}
