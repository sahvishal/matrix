using System.Collections.Generic;
using System.Linq;
using Falcon.App.Core;
using Falcon.App.Core.Application.Attributes;
using Falcon.App.Core.Operations.Domain;
using Falcon.App.Core.Sales.Domain;
using Falcon.App.Core.Scheduling;
using Falcon.App.Core.Scheduling.Domain;
using Falcon.App.Core.Scheduling.ViewModels;

namespace Falcon.App.Infrastructure.Sales.Factories
{
    [DefaultImplementation]
    public class EventScheduleReportFactory : IEventScheduleReportFactory
    {
        public EventScheduleListModel Create(IEnumerable<Event> events, IEnumerable<Host> hosts, IEnumerable<Pod> pods, IEnumerable<EventAppointmentStatsModel> eventAppointmentStatsModels,
            IEnumerable<OrderedPair<long, int>> customersAttendeds, IEnumerable<OrderedPair<long, int>> noshowCustomerCounts, IEnumerable<long> mamoeventIds)
        {
            var model = new EventScheduleListModel();
            var eventScheduleModel = new List<EventScheduleModel>();
            events.ToList().ForEach(e =>
            {
                var host = hosts.FirstOrDefault(h => h.Id == e.HostId);
                var eventPods = (e.PodIds != null && e.PodIds.Count() > 0) ? pods.Where(p => e.PodIds.Contains(p.Id)).ToList() : null;

                var eventAppointmentStatsModel = eventAppointmentStatsModels.Single(easm => easm.EventId == e.Id);

                var screenedCustomer = customersAttendeds.FirstOrDefault(bs => bs.FirstValue == e.Id);
                var noShowCustomers = noshowCustomerCounts.FirstOrDefault(bs => bs.FirstValue == e.Id);

                var screenedCustomerCount = screenedCustomer != null ? screenedCustomer.SecondValue : 0;
                var noShowCustomerCount = noShowCustomers != null ? noShowCustomers.SecondValue : 0;

                var isMammoEvent = mamoeventIds.Any(x => x == e.Id);

                var podName = eventPods != null ? string.Join(" | ", eventPods.Select(p => p.Name)) : string.Empty;
                var podStatus = "Assessment Event";

                if (isMammoEvent)
                {
                    podStatus = podStatus + ", Mammo Capable";
                }
                podStatus = podName + "(" + podStatus + ")";

                eventScheduleModel.Add(new EventScheduleModel
                {
                    EventCode = e.Id,
                    EventDate = e.EventDate,
                    Address = host != null ? host.Address : null,
                    AppointmentsBooked = eventAppointmentStatsModel.BookedSlots,
                    ScreenedCustomers = screenedCustomerCount,
                    NoShow = noShowCustomerCount,
                    Location = host != null ? host.OrganizationName : string.Empty,
                    Pod = podStatus,
                    Status = e.Status
                });
            });
            model.Collection = eventScheduleModel;

            return model;
        }
    }
}