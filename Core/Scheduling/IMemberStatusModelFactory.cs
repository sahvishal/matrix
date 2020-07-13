using System.Collections.Generic;
using Falcon.App.Core.Application.Domain;
using Falcon.App.Core.CallCenter.Domain;
using Falcon.App.Core.Domain.MedicalVendors;
using Falcon.App.Core.Finance.Domain;
using Falcon.App.Core.Sales.Domain;
using Falcon.App.Core.Scheduling.Domain;
using Falcon.App.Core.Scheduling.ViewModels;
using Falcon.App.Core.Users.Domain;
using Falcon.App.Core.Operations.Domain;
using System;
using Falcon.App.Core.Marketing.Domain;


namespace Falcon.App.Core.Scheduling
{
    public interface IMemberStatusModelFactory
    {
        MemberStatusListModel Create(IEnumerable<Customer> customers, IEnumerable<EventCustomer> eventCustomers, EventVolumeListModel eventListModel, IEnumerable<Order> orders,
            IEnumerable<OrderedPair<long, string>> packages, IEnumerable<OrderedPair<long, string>> tests, IEnumerable<CallCenter.Domain.Call> calls,
            IEnumerable<CorporateCustomerCustomTag> customTags, IEnumerable<PrimaryCarePhysician> primaryCarePhysicians, IEnumerable<Notes> doNotContactReasonNotes,
            IEnumerable<OrderedPair<long, string>> customersPreApprovedTests, IEnumerable<OrderedPair<long, string>> customersPreApprovedPackages,
            IEnumerable<DirectMail> directMails, IEnumerable<Appointment> appointments, IEnumerable<ShippingDetail> shipingDetails,
            IEnumerable<OrderedPair<long, long>> shippingDetailIdEventCustomerIdPairs, IEnumerable<ShippingOption> shippingOptions, ShippingOption pcpShippingOptions,
            IEnumerable<CorporateAccount> corporateAccounts, IEnumerable<AccountAdditionalFields> accountAdditionalFields, DateTime fromDate, DateTime toDate,
            IEnumerable<ProspectCustomer> prospectCustomers, IEnumerable<CustomerPredictedZip> customerPredictedZips, IEnumerable<CustomerEligibility> customerEligibilityList,
            IEnumerable<CustomerTargeted> customerTargetedList, IEnumerable<Falcon.App.Core.Medical.Domain.ActivityType> activityTypes);
    }
}