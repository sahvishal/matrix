using System.Collections.Generic;
using Falcon.App.Core.Scheduling.Domain;
using Falcon.App.Core.Scheduling.ViewModels;
using Falcon.App.Core.Users.Domain;

namespace Falcon.App.Core.Scheduling
{
    public interface IRescheduleApplointmentModelFactory
    {
        RescheduleApplointmentListModel Create(IEnumerable<EventAppointmentChangeLog> rescheduledAppointments, IEnumerable<EventCustomer> eventCustomers, IEnumerable<Customer> customers, IEnumerable<Event> events,
                                                    IEnumerable<OrganizationRoleUser> agents, IEnumerable<Role> roles, IEnumerable<OrderedPair<long, string>> agentIdNamePairs, EventVolumeListModel eventsVolumeWithSponsoredBy);

        IEnumerable<EventRescheduleAppointmentViewModel> CreateEventRescheduleAppointment(IEnumerable<EventCustomer> eventCustomers, IEnumerable<Customer> customers);
    }
}
