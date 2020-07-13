using Falcon.App.Core.Finance.Domain;
using Falcon.App.Core.Scheduling.Domain;
using Falcon.App.Core.Scheduling.ViewModels;
using Falcon.App.Core.Users.Domain;
using System.Collections.Generic;

namespace Falcon.App.Core.Scheduling
{
    public interface IVoiceMailReminderModelFactory
    {
        VoiceMailReminderListModel Create(IEnumerable<EventCustomer> eventCustomers, EventVolumeListModel eventListModel, IEnumerable<Customer> customers, IEnumerable<OrderedPair<long, string>> packages,
            IEnumerable<Appointment> appointments, IEnumerable<Order> orders, IEnumerable<OrderedPair<long, string>> tests);
    }
}
