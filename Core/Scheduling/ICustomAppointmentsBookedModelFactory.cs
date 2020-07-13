using System.Collections.Generic;
using Falcon.App.Core.Domain.MedicalVendors;
using Falcon.App.Core.Finance.Domain;
using Falcon.App.Core.Marketing.Domain;
using Falcon.App.Core.Operations.Domain;
using Falcon.App.Core.Sales.Domain;
using Falcon.App.Core.Scheduling.Domain;
using Falcon.App.Core.Scheduling.ViewModels;
using Falcon.App.Core.Users.Domain;
using Call = Falcon.App.Core.CallCenter.Domain.Call;

namespace Falcon.App.Core.Scheduling
{
    public interface ICustomAppointmentsBookedModelFactory
    {
        CustomAppointmentsBookedListModel Create(IEnumerable<EventCustomer> eventCustomers, IEnumerable<Appointment> appointments, IEnumerable<Order> orders,
            EventVolumeListModel eventListModel, IEnumerable<Customer> customers, IEnumerable<OrganizationRoleUser> agents, IEnumerable<Role> roles,
            IEnumerable<OrderedPair<long, string>> agentIdNamePairs, IEnumerable<EventAppointmentChangeLog> eventAppointmentChangeLogs,
            IEnumerable<PrimaryCarePhysician> primaryCarePhysicians, IEnumerable<EventPackage> packages,
            IEnumerable<EventTest> tests, IEnumerable<Language> languages
            );

        HourlyAppointmentsBookedListModel CreateHourlyModel(IEnumerable<EventCustomer> eventCustomers, IEnumerable<Appointment> appointments, IEnumerable<Order> orders, EventVolumeListModel eventListModel, IEnumerable<Customer> customers,
                                                    IEnumerable<OrganizationRoleUser> agents, IEnumerable<Role> roles, IEnumerable<OrderedPair<long, string>> agentIdNamePairs, IEnumerable<SourceCode> sourceCodes, IEnumerable<Call> calls, IEnumerable<ShippingDetail> shippingDetails,
                                                    ShippingOption cdShippingOption, IEnumerable<ShippingOption> shippingOptions, IEnumerable<EventAppointmentChangeLog> eventAppointmentChangeLogs,
                                                    IEnumerable<PrimaryCarePhysician> primaryCarePhysicians, IEnumerable<EventPackage> eventPackages, IEnumerable<EventTest> eventTests, IEnumerable<Language> languages,
                                                    IEnumerable<CorporateCustomerCustomTag> customTags, IEnumerable<CorporateAccount> corporateAccounts, IEnumerable<AccountAdditionalFields> accountAdditionalFields,
                                                    IEnumerable<PcpAppointment> pcpAppointments, IEnumerable<CustomerEligibility> customerEligibilities);
    }
}