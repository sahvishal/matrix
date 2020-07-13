using System.Collections.Generic;
using Falcon.App.Core.Operations.Domain;
using Falcon.App.Core.Scheduling.Domain;
using Falcon.App.Core.Scheduling.ViewModels;
using Falcon.App.Core.Users.Domain;

namespace Falcon.App.Core.Scheduling
{
    public interface IEventAppointmentBasicInfoModelFactory
    {
        EventAppointmentListModel Create(IEnumerable<EventSchedulingSlot> appointmentSlots, Event eventData, IEnumerable<EventPodRoom> eventPodRooms);

        EventAppointmentListModel Create(IEnumerable<EventCustomer> eventCustomers, IEnumerable<EventSchedulingSlot> appointmentSlots, IEnumerable<Customer> customers, IEnumerable<OrderedPair<long, string>> packages,
            IEnumerable<OrderedPair<long, string>> tests, Event eventData, IEnumerable<Appointment> bookedAppointments, IEnumerable<EventPodRoom> eventPodRooms);

        IEnumerable<EventAppointmentBasicInfoModel> Create(IEnumerable<EventCustomer> eventCustomers, IEnumerable<Customer> customers, IEnumerable<OrderedPair<long, string>> packages, IEnumerable<OrderedPair<long, string>> tests,
            IEnumerable<Appointment> bookedAppointments, IEnumerable<EventSchedulingSlot> appointmentSlots);

        IEnumerable<EventAppointmentBasicInfoModel> Create(IEnumerable<EventSchedulingSlot> appointmentSlots);
    }
}
