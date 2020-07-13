using Falcon.App.Core.Domain.MedicalVendors;
using Falcon.App.Core.Sales.Domain;
using Falcon.App.Core.Scheduling.Domain;
using Falcon.App.Core.Scheduling.ViewModels;
using System.Collections.Generic;
using Falcon.App.Core.Users.Domain;

namespace Falcon.App.Core.Scheduling
{
    public interface IPcpAppointmentViewModelFactory
    {
        IEnumerable<PcpAppointmentViewModel> Create(IEnumerable<ViewPcpAppointmentDisposition> vwPcpDispositions, IEnumerable<EventCustomer> eventCustomers, IEnumerable<Customer> customers, IEnumerable<CorporateCustomerCustomTag> corporateCustomerCustomTags,
            IEnumerable<PrimaryCarePhysician> primaryCarePhysician, IEnumerable<OrderedPair<long, string>> agentOrderedPairs, EventVolumeListModel eventListModel,
            IEnumerable<PcpAppointment> pcpAppointments, IEnumerable<PcpDisposition> pcpDispositions, IEnumerable<CustomerEligibility> customerEligibilities);
    }
}
