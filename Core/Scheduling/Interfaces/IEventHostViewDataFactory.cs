using System.Collections.Generic;
using Falcon.App.Core.Geo.Domain;
using Falcon.App.Core.Operations.Domain;
using Falcon.App.Core.Scheduling.Domain;
using Falcon.App.Core.Scheduling.ViewModels;

namespace Falcon.App.Core.Scheduling.Interfaces
{
    public interface IEventHostViewDataFactory
    {
        //EventHostViewData Create(Event eventData, IEnumerable<Pod> pods, ZipCode zipCode, EventAppointmentStatsModel eventAppointmentStatsModel, IEnumerable<OrderedPair<long, string>> corporateAccountNames = null, IEnumerable<OrderedPair<long, string>> hospitalPartnerNames = null);
        List<EventHostViewData> Create(List<Event> events, IEnumerable<Pod> pods, ZipCode zipCode, IEnumerable<EventAppointmentStatsModel> eventAppointmentStatsModels, IEnumerable<OrderedPair<long, string>> corporateAccountNames = null, IEnumerable<OrderedPair<long, string>> hospitalPartnerNames = null, IEnumerable<ZipRadiusDistance> zipRadiusDistances = null);
    }
}