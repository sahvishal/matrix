using System.Collections.Generic;
using Falcon.App.Core.Finance.Domain;
using Falcon.App.Core.Finance.ViewModels;
using Falcon.App.Core.Scheduling.Domain;

namespace Falcon.App.Core.Finance
{
    public interface ICallCenterBonusReportingFactory
    {
        IEnumerable<CallCenterBonusViewModel> Create(IEnumerable<OrderedPair<long, string>> callCenterAgents, IEnumerable<OrderedPair<long, long>> callCounts,
            IEnumerable<OrderedPair<long, long>> appointmentBooked, IEnumerable<PayPeriodCriteria> criterias);

        IEnumerable<AppointmentsShowedViewModel> Create(IEnumerable<OrderedPair<long, string>> callCenterAgents, IEnumerable<EventCustomer> eventCustomers, IEnumerable<PayPeriod> payPeriods,
            IEnumerable<PayPeriodCriteria> criterias, IEnumerable<PayRangeCustomerBookedViewModel> payPeriodCustomerBookedByAgent);
    }
}