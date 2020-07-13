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
    public interface IHospitalPartnerCustomerViewModelFactory
    {
        HospitalPartnerCustomerListModel Create(IEnumerable<EventCustomer> eventCustomers,
                                                IEnumerable<Order> orders,
                                                IEnumerable<Customer> customers,
                                                IEnumerable<OrderedPair<long, string>> packages,
                                                IEnumerable<OrderedPair<long, string>> tests,
                                                IEnumerable<HospitalPartnerCustomer> hospitalPartnerCustomers,
                                                IEnumerable<OrderedPair<long, string>> idNamePairs,
                                                IEnumerable<Event> events, IEnumerable<ShippingDetail> shippingDetails,
                                                IEnumerable<CustomerResultStatusViewModel> resultStatuses,
                                                ShippingOption cdShippingOption,
                                                IEnumerable<Pod> pods,
                                                IEnumerable<OrderedPair<long, string>> eventHospitalPartnerNamePairs,
                                                IEnumerable<OrderedPair<long, string>> eventIdCorporateAccounrNamePairs,
                                                IEnumerable<PrimaryCarePhysician> primaryCarePhysicians,
                                                IEnumerable<HealthAssessmentQuestion> healthAssessmentQuestions,
                                                IEnumerable<HealthAssessmentAnswer> healthAssessmentAnswers,
                                                IEnumerable<EventCustomerResult> eventCustomerResults,
                                                HospitalPartner hospitalPartner, IEnumerable<CustomerCallNotes> notes, IEnumerable<EventCustomerNotification> eventCustomerNotifications,
                                                IEnumerable<EventHospitalPartner> eventHospitalPartners, IEnumerable<OrderedPair<long, string>> eventCustomerIdHospitalFacilityNamePairs, 
                                                IEnumerable<HospitalFacility> hospitalFacilities,IEnumerable<long> showScannedDocumentHospitalPartnerIds,
                                                IEnumerable<Language> languages);

        IEnumerable<HospitalPartnerCustomerActivityViewModel> GetHospitalPartnerCustomerActivities(IEnumerable<HospitalPartnerCustomer> hospitalPartnerCustomers, IEnumerable<OrderedPair<long, string>> idNamePairs);
    }
}
