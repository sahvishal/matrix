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
    public class DailyVolumeFactory : IDailyVolumeFactory
    {
        public DailyVolumeListModel Create(IEnumerable<Event> events, IEnumerable<Host> hosts, IEnumerable<Pod> pods, IEnumerable<EventAppointmentStatsModel> eventAppointmentStatsModels,
            IEnumerable<OrderedPair<long, string>> eventIdCorporateNamePairs, List<OrderedPair<long, int>> noShowCustomers, List<OrderedPair<long, int>> customersAttended,
            List<OrderedPair<long, int>> cancellationOnDayofEvent, List<OrderedPair<long, int>> movedOutEventCustomerCountPair, List<OrderedPair<long, int>> leftWithoutScreeningCustomers)
        {
            var model = new DailyVolumeListModel();
            var eventVolumeModels = new List<DailyVolumeModel>();

            events.ToList().ForEach(e =>
            {
                var host = hosts.FirstOrDefault(h => h.Id == e.HostId);
                var eventPods = (e.PodIds != null && e.PodIds.Count() > 0) ? pods.Where(p => e.PodIds.Contains(p.Id)).ToList() : null;

                var eventAppointmentStatsModel = eventAppointmentStatsModels.Single(easm => easm.EventId == e.Id);

                var bookedSlotCount = eventAppointmentStatsModel.BookedSlots;

                var totalSlotCount = eventAppointmentStatsModel.TotalSlots - eventAppointmentStatsModel.BlockedSlots;

                var availableSlotCount = eventAppointmentStatsModel.FreeSlots + eventAppointmentStatsModel.TemporaryBookedSlots;

                var corporateName = eventIdCorporateNamePairs.Where(ehp => ehp.FirstValue == e.Id).Select(ehp => ehp.SecondValue).SingleOrDefault();

                var cancellationOnDayofEventCount = cancellationOnDayofEvent.Single(x => x.FirstValue == e.Id).SecondValue;

                var noShowCustomerCount = noShowCustomers.Single(x => x.FirstValue == e.Id).SecondValue;

                var customersAttendedCount = customersAttended.Single(x => x.FirstValue == e.Id).SecondValue;

                var customerMovedOut = movedOutEventCustomerCountPair.First(x => x.FirstValue == e.Id).SecondValue;

                var leftWithoutScreeningCustomer = leftWithoutScreeningCustomers.Single(x => x.FirstValue == e.Id).SecondValue;

                eventVolumeModels.Add(CreateSingleDailyVolumeModel(e, host, eventPods, bookedSlotCount, totalSlotCount, availableSlotCount, corporateName, noShowCustomerCount, customersAttendedCount,
                     cancellationOnDayofEventCount, leftWithoutScreeningCustomer, customerMovedOut));
            });

            model.Collection = eventVolumeModels;

            return model;
        }

        private DailyVolumeModel CreateSingleDailyVolumeModel(Event evt, Host host, IEnumerable<Pod> pods, int bookedSlotCount, int totalSlotCount, int availableSlotCount,
            string corporateName, int noShowCustomerCount, int customersAttendedCount, int cancellationOnDayofEventCount, int leftWithoutScreeningCustomer, int customerMovedOut)
        {
            var address = host.Address;
            return new DailyVolumeModel
            {

                EventCode = evt.Id,
                EventDate = evt.EventDate,
                City = (address != null) ? address.City : string.Empty,
                State = (address != null) ? address.State : string.Empty,
                Zip = (address != null) ? address.ZipCode.Zip : string.Empty,
                Pod = pods != null ? string.Join(" | ", pods.Select(p => p.Name)) : string.Empty,
                CorporateAccount = corporateName,
                TotalSlots = evt.IsDynamicScheduling ? availableSlotCount + bookedSlotCount : totalSlotCount,
                AvailableSlots = availableSlotCount,
                SlotsBooked = bookedSlotCount + cancellationOnDayofEventCount + customerMovedOut,
                SameDayCancels = cancellationOnDayofEventCount,
                CustomersNoShow = noShowCustomerCount,
                CustomersAttended = customersAttendedCount,
                PatientsBooked = bookedSlotCount,
                PatientLeft = leftWithoutScreeningCustomer,
                SameDayReschedules = customerMovedOut,
                VacantSlots = ((evt.IsDynamicScheduling ? availableSlotCount + bookedSlotCount : totalSlotCount) - (bookedSlotCount + cancellationOnDayofEventCount + customerMovedOut))
            };
        }
    }
}