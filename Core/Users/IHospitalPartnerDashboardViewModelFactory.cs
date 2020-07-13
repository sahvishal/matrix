using System;
using System.Collections.Generic;
using Falcon.App.Core.Medical.Domain;
using Falcon.App.Core.Medical.ViewModels;
using Falcon.App.Core.Sales.Domain;
using Falcon.App.Core.Sales.ViewModels;
using Falcon.App.Core.Scheduling.Domain;
using Falcon.App.Core.Users.Domain;
using Falcon.App.Core.Users.ViewModels;

namespace Falcon.App.Core.Users
{
    public interface IHospitalPartnerDashboardViewModelFactory
    {
        HospitalPartnerDashboardViewModel Create(long scheduledEvents,
                                                 IEnumerable<OrderedPair<long, int>> totalCustomers,
                                                 IEnumerable<OrderedPair<long, int>> customersAttended,
                                                 IEnumerable<OrderedPair<long, int>> criticalCustomers,
                                                 IEnumerable<OrderedPair<long, int>> normalCustomers,
                                                 IEnumerable<OrderedPair<long, int>> abnormalCustomers,
                                                 IEnumerable<Event> events, IEnumerable<Host> hosts,
                                                 long reccentContactedEventId,
                                                 IEnumerable<OrderedPair<long, DateTime>> recentMailedEvents,
                                                 DateTime? mailedDate,
                                                 IEnumerable<EventCustomerResult> recentCriticalCustomers,
                                                 IEnumerable<Customer> customers, IEnumerable<CustomerResultStatusViewModel> customerResultStatusViewModels, IEnumerable<OrderedPair<long, int>> urgentCustomers);

        HospitalPartnerCallStatusViewModel CreateCallStatus(int abnormalCustomers, int criticalCustomers, int urgentCustomers, IEnumerable<HospitalPartnerCustomer> hospitalPartnerCustomers);

        HospitalPartnerScheduledOutcomeViewModel CreateScheduledOutcome(int abnormalCustomers, int criticalCustomers, int urgentCustomers, IEnumerable<HospitalPartnerCustomer> hospitalPartnerCustomers);

        HospitalPartnerNotScheduledOutcomeViewModel CreateNotScheduledOutcome(int abnormalCustomers, int criticalCustomers, int urgentCustomers, IEnumerable<HospitalPartnerCustomer> hospitalPartnerCustomers);
    }
}
