using System.Collections.Generic;
using Falcon.App.Core.Application.Domain;
using Falcon.App.Core.Domain.MedicalVendors;
using Falcon.App.Core.Finance.Domain;
using Falcon.App.Core.Marketing.Domain;
using Falcon.App.Core.OutboundReport.Domain;
using Falcon.App.Core.Sales.Domain;
using Falcon.App.Core.Scheduling.Domain;
using Falcon.App.Core.Scheduling.ViewModels;
using Falcon.App.Core.Users.Domain;
using Call = Falcon.App.Core.CallCenter.Domain.Call;
using Falcon.App.Core.Medical.Domain;

namespace Falcon.App.Core.Scheduling
{
    public interface ICustomerExportModelFactory
    {
        CustomerExportListModel Create(IEnumerable<Customer> customers, IEnumerable<EventCustomer> eventCustomers, EventVolumeListModel eventListModel, IEnumerable<Order> orders, IEnumerable<OrderedPair<long, string>> packages,
            IEnumerable<OrderedPair<long, string>> tests, IEnumerable<Role> roles, IEnumerable<SourceCode> sourceCodes, IEnumerable<Call> calls, IEnumerable<Language> languages, IEnumerable<Lab> labs,
            IEnumerable<CorporateCustomerCustomTag> customTags, IEnumerable<PrimaryCarePhysician> primaryCarePhysicians, IEnumerable<Notes> doNotContactReasonNotes, IEnumerable<OrderedPair<long, string>> customersPreApprovedTests,
            IEnumerable<OrderedPair<long, string>> customersPreApprovedPackages, IEnumerable<Appointment> appointments, IEnumerable<CorporateAccount> corporateAccounts, IEnumerable<AccountAdditionalFields> additionalFields,
            IEnumerable<CustomerPredictedZip> customerPredictedZips, IEnumerable<CustomerEligibility> customerEligibilities, IEnumerable<ChaseOutbound> chaseOutbounds, IEnumerable<Relationship> relationships, IEnumerable<ActivityType> activityTypes);
    }
}
