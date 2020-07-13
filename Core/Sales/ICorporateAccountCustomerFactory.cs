using System.Collections.Generic;
using Falcon.App.Core.Communication.Domain;
using Falcon.App.Core.Domain.MedicalVendors;
using Falcon.App.Core.Finance.Domain;
using Falcon.App.Core.Medical.Domain;
using Falcon.App.Core.Medical.ViewModels;
using Falcon.App.Core.Operations.Domain;
using Falcon.App.Core.Sales.Domain;
using Falcon.App.Core.Sales.ViewModels;
using Falcon.App.Core.Scheduling.Domain;
using Falcon.App.Core.Users.Domain;

namespace Falcon.App.Core.Sales
{
    public interface ICorporateAccountCustomerFactory
    {
        CorporateAccountCustomerListModel Create(IEnumerable<EventCustomer> eventCustomers, IEnumerable<Customer> customers, IEnumerable<Order> orders, IEnumerable<OrderedPair<long, string>> packages, IEnumerable<OrderedPair<long, string>> tests,
            IEnumerable<ShippingDetail> shippingDetails, ShippingOption cdShippingOption, IEnumerable<EventCustomerResult> eventCustomerResults, IEnumerable<Event> events, IEnumerable<Pod> pods, IEnumerable<OrderedPair<long, string>> eventIdCorporateAccountNamePairs,
            IEnumerable<CustomerResultStatusViewModel> resultStatuses, IEnumerable<PrimaryCarePhysician> primaryCarePhysicians, IEnumerable<HealthAssessmentAnswer> healthAssessmentAnswers, IEnumerable<HealthAssessmentQuestion> healthAssessmentQuestions,
            IEnumerable<Language> languages, IEnumerable<EventCustomerNotification> eventCustomerNotifications, IEnumerable<EventHospitalPartner> eventHospitalPartners);
    }
}
