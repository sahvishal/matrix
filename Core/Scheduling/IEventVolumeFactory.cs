using System.Collections.Generic;
using Falcon.App.Core.Operations.Domain;
using Falcon.App.Core.Sales.Domain;
using Falcon.App.Core.Scheduling.Domain;
using Falcon.App.Core.Scheduling.ViewModels;

namespace Falcon.App.Core.Scheduling
{
    public interface IEventVolumeFactory
    {
        EventVolumeListModel Create(IEnumerable<Event> events, IEnumerable<Host> hosts, IEnumerable<Pod> pods,
                                    IEnumerable<EventAppointmentStatsModel> eventAppointmentStatsModels,
                                    IEnumerable<OrderedPair<long, string>> primaryPhysicians,
                                    IEnumerable<OrderedPair<long, string>> overReadPhysicians, IEnumerable<OrderedPair<long, string>> eventIdHospitalPartnerNamePairs, IEnumerable<OrderedPair<long, int>> customersAttended,
            IEnumerable<OrderedPair<long, string>> eventIdCorporateNamePairs, IEnumerable<EventStaffAssignment> staffAssignments, IEnumerable<OrderedPair<long, string>> idNamePairs);

        ClientEventVolumeListModel Create(IEnumerable<Event> events, IEnumerable<Host> hosts, IEnumerable<Pod> pods, IEnumerable<EventAppointmentStatsModel> eventAppointmentStatsModels, IEnumerable<OrderedPair<long, string>> eventIdHospitalPartnerNamePairs, IEnumerable<OrderedPair<long, int>> customersAttended,
             IEnumerable<OrderedPair<long, string>> eventIdCorporateNamePairs, IEnumerable<EventStaffAssignment> staffAssignments, IEnumerable<OrderedPair<long, string>> idNamePairs);
    }
}
