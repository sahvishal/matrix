using System.Collections.Generic;
using Falcon.App.Core.Scheduling.Domain;
using Falcon.App.Core.Scheduling.ViewModels;
using Falcon.App.Core.Users.Domain;

namespace Falcon.App.Core.Scheduling
{
    public interface IAppointmentEncounterFactory
    {
        AppointmentEncounterListModel Create(IEnumerable<EventCustomer> evnetEventCustomers, IEnumerable<Customer> customers, IEnumerable<PcpAppointment> pcpAppointments,
            IEnumerable<Appointment> customerAppointments, IEnumerable<Event> eventsCollection);
    }
}
