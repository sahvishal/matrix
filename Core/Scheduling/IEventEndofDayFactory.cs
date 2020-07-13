using System;
using System.Collections.Generic;
using Falcon.App.Core.Finance.Domain;
using Falcon.App.Core.Medical.Domain;
using Falcon.App.Core.Medical.ViewModels;
using Falcon.App.Core.Sales.Domain;
using Falcon.App.Core.Scheduling.Domain;
using Falcon.App.Core.Scheduling.ViewModels;
using Falcon.App.Core.Users.Domain;

namespace Falcon.App.Core.Scheduling
{
    public interface IEventEndofDayFactory
    {
        EventEndofDayListModel Create(Event theEvent, Host host, IEnumerable<Customer> customers, IEnumerable<EventCustomer> eventCustomers, IEnumerable<Appointment> appointments, IEnumerable<EventPackage> eventPackages,
                                        IEnumerable<EventTest> eventTests, IEnumerable<Order> orders, IEnumerable<BasicBiometric> basicBiometrics, IEnumerable<OrderedPair<long, bool>> lipidStates, IEnumerable<OrderedPair<long, bool>> hbA1CStates,
                                        IEnumerable<CustomerResultStatusViewModel> customerResultStatuses, bool isHospitalPartnerAttached, IEnumerable<OrderedPair<long, DateTime>> hafDateSavePairs, string signOff,
                                        IEnumerable<OrderedPair<long, bool>> kynStates, bool isHospitalFacilitiesAttached, bool isKynIntegrationEnabled, bool isMedicareEnabled, IEnumerable<OrderedPair<long, DateTime>> orderdPairsMedicareSaved,
                                        CorporateAccount account, IEnumerable<OrderedPair<long, bool>> hypertensionStates, DateTime basicBiometricCutOfDate, IEnumerable<OrderedPair<long, bool>> cholesterolStates,
                                        IEnumerable<OrderedPair<long, bool>> awvLipidStates, IEnumerable<OrderedPair<long, bool>> diabetesStates, IEnumerable<OrderedPair<long, bool>> awvGlucoseStates,
                                        IEnumerable<OrderedPair<long, bool>> hPyloriStates, IEnumerable<OrderedPair<long, bool>> hemoglobinStates, IEnumerable<OrderedPair<long, bool>> qualityMeasuresState,
                                        IEnumerable<OrderedPair<long, bool>> phq9States, IEnumerable<OrderedPair<long, bool>> facAttestationStates, IEnumerable<OrderedPair<long, bool>> ifobtStates, IEnumerable<OrderedPair<long, bool>> hkynStates, IEnumerable<OrderedPair<long, bool>> myBioCheckAssessmentStates, bool IsShowGiftCertificateOnEod);

        EventEndofDayListModel CreateForMyBioCheck(Event theEvent, IEnumerable<Customer> customers,
            IEnumerable<EventCustomer> eventCustomers, IEnumerable<EventPackage> eventPackages,
            IEnumerable<EventTest> eventTests, IEnumerable<Order> orders, IEnumerable<BasicBiometric> basicBiometrics,
            IEnumerable<CustomerResultStatusViewModel> customerResultStatuses,
            IEnumerable<OrderedPair<long, bool>> hypertensionStates,
            DateTime basicBiometricCutOfDate,
            IEnumerable<OrderedPair<long, bool>> myBioCheckAssessmentStates, CorporateAccount account);
    }
}