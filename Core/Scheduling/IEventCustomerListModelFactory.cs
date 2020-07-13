using System;
using System.Collections.Generic;
using Falcon.App.Core.Communication.Domain;
using Falcon.App.Core.Domain.MedicalVendors;
using Falcon.App.Core.Finance.Domain;
using Falcon.App.Core.Marketing.Domain;
using Falcon.App.Core.Medical.Domain;
using Falcon.App.Core.Operations.Domain;
using Falcon.App.Core.Operations.ViewModels;
using Falcon.App.Core.Sales.Domain;
using Falcon.App.Core.Scheduling.Domain;
using Falcon.App.Core.Scheduling.Impl;
using Falcon.App.Core.Scheduling.ViewModels;
using Falcon.App.Core.Users.Domain;

namespace Falcon.App.Core.Scheduling
{
    public interface IEventCustomerListModelFactory
    {
        EventCustomerListModel Create(EventCustomerListModel model, IEnumerable<EventCustomer> eventCustomers, IEnumerable<EventCustomerResult> eventCustomerResults, IEnumerable<CustomerCallNotes> customerCallNotes,
            IEnumerable<AssignedPhysicianViewModel> physicians, IEnumerable<EventAppointmentBasicInfoModel> eventAppointments, IEnumerable<Customer> customers, IEnumerable<Order> orders, IEnumerable<SourceCode> sourceCodes,
            IEnumerable<long> authorizedEventCustomerIds, IEnumerable<long> undeliveredShippingCustomerIds, IEnumerable<long> filledHealthAssesmentForms, IEnumerable<EventPackage> eventPackages, IEnumerable<EventTest> eventtests,
            IEnumerable<ElectronicProduct> products, EventCustomerListModelFilter filter, IEnumerable<OrganizationRoleUser> orgRoleUsers, IEnumerable<RefundRequest> refundRequests, IEnumerable<ShippingDetail> cdShippingDetails,
            IEnumerable<PrimaryCarePhysician> primaryCarePhysician, IEnumerable<OrderedPair<long, DateTime>> answeredMedicareQuestionsOrderdPair, CorporateAccount corporateAccount, IEnumerable<OrderedPair<long, string>> preapprovedTests,
            IEnumerable<CustomerCallNotes> patientLeftNotes, IEnumerable<OrderedPair<long, long>> eawvTestNotPerformed);

        EventCustomerBrifListModel CreateBrifListModel(EventCustomerBrifListModel model, IEnumerable<EventCustomer> eventCustomers, IEnumerable<EventAppointmentBasicInfoModel> eventAppointments,
            IEnumerable<Customer> customers, IEnumerable<Order> orders, IEnumerable<long> filledHealthAssesmentForms, IEnumerable<ElectronicProduct> products, EventCustomerListModelFilter filter, IEnumerable<EventPackage> eventPackages,
            IEnumerable<EventTest> eventtests, IEnumerable<OrganizationRoleUser> orgRoleUsers, IEnumerable<ShippingDetail> cdShippingDetails, IEnumerable<SourceCode> sourceCodes, CorporateAccount account, IEnumerable<PrimaryCarePhysician> primaryCarePhysicians);

        IEnumerable<ShortPatientInfoViewModel> CreateCustomerAppointmentList(IEnumerable<EventCustomer> eventCustomers, IEnumerable<EventAppointmentBasicInfoModel> eventAppointments, IEnumerable<Customer> customers,
            IEnumerable<Order> orders, EventCustomerListModelFilter filter, IEnumerable<OrganizationRoleUser> orgRoleUsers, Host host, IEnumerable<EventPackage> eventPackages, IEnumerable<EventTest> eventTests,
            IEnumerable<ParticipationConsentSignature> participationConsentSignatures, IEnumerable<FluConsentSignature> fluConsentSignatures, IEnumerable<PhysicianRecordRequestSignature> physicianRecordRequestSignatures, IEnumerable<PrimaryCarePhysician> primaryCarePhysicians,
            IEnumerable<ChaperoneSignature> chaperoneSignature);
    }
}