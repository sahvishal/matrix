using System;
using System.Collections.Generic;
using System.Linq;
using Falcon.App.Core;
using Falcon.App.Core.Application;
using Falcon.App.Core.Application.Attributes;
using Falcon.App.Core.Extensions;
using Falcon.App.Core.Finance.Interfaces;
using Falcon.App.Core.Interfaces;
using Falcon.App.Core.Medical;
using Falcon.App.Core.Medical.Domain;
using Falcon.App.Core.Medical.Enum;
using Falcon.App.Core.Medical.Interfaces;
using Falcon.App.Core.Medical.ValueType;
using Falcon.App.Core.Operations;
using Falcon.App.Core.Sales.Interfaces;
using Falcon.App.Core.Scheduling;
using Falcon.App.Core.Scheduling.Domain;
using Falcon.App.Core.Scheduling.Interfaces;
using Falcon.App.Core.Scheduling.ViewModels;
using Falcon.App.Core.Users;
using Falcon.App.Core.Users.Domain;
using Falcon.App.Infrastructure.Repositories.Screening;

namespace Falcon.App.Infrastructure.Scheduling.Services
{
    [DefaultImplementation(Interface = typeof(IEventEndofDayService))]
    public class EventEndofDayService : IEventEndofDayService
    {
        private readonly IEventRepository _eventRepository;
        private readonly IEventCustomerRepository _eventCustomerRepository;
        private readonly IEventCustomerResultRepository _eventCustomerResultRepository;
        private readonly ICustomerRepository _customerRepository;
        private readonly IHostRepository _hostRepository;
        private readonly IAppointmentRepository _appointmentRepository;
        private readonly IBasicBiometricRepository _basicBiometricRepository;
        private readonly IOrderRepository _orderRepository;
        private readonly IEventPackageRepository _eventPackageRepository;
        private readonly IEventTestRepository _eventTestRepository;

        private readonly ITestResultRepository _lipidTestResultRepository;
        private readonly ITestResultRepository _cholesterolTestResultRepository;
        private readonly ITestResultRepository _awvLipidTestResultRepository;
        private readonly ITestResultRepository _diabetesTestResultRepository;
        private readonly ITestResultRepository _awvGlucoseTestResultRepository;
        private readonly ITestResultRepository _myBioAssessmentTestRepository;

        private readonly ITestResultRepository _hba1CRepository;
        private readonly IEventEndofDayFactory _eventEndofDayFactory;
        private readonly IOrganizationRoleUserRepository _organizationRoleUserRepository;
        private readonly IKynLabValuesRepository _kynLabValuesRepository;
        private readonly IHealthAssessmentService _healthAssessmentService;
        private readonly IHospitalFacilityRepository _hospitalFacilityRepository;
        private readonly ITestResultRepository _testResultRepository;
        private readonly IEventPodRepository _eventPodRepository;
        private readonly IKynHealthAssessmentHelper _kynHealthAssessmentHelper;
        private readonly ICustomerMedicareQuestionService _medicareQuestionService;
        private readonly ICorporateAccountRepository _corporateAccountRepository;
        private readonly ITestResultRepository _hypertenstionRepository;
        private readonly ITestResultRepository _hPyloriRepository;
        private readonly ITestResultRepository _hemogobinRepository;

        private readonly ITestResultRepository _phq9Repository;
        private readonly ITestResultRepository _qualityMeasuresRepository;
        private readonly ITestResultRepository _focAttestationRepository;
        private readonly ISettings _settings;
        private readonly IEventCustomerPackageTestDetailService _eventCustomerPackageTestDetailService;
        private readonly ITestResultRepository _ifobtRepository;

        public EventEndofDayService(ICustomerRepository customerRepository, IHostRepository hostRepository, IEventCustomerRepository eventCustomerRepository, IAppointmentRepository appointmentRepository, IEventCustomerResultRepository eventCustomerResultRepository,
            IBasicBiometricRepository basicBiometricRepository, IOrderRepository orderRepository, IEventTestRepository eventTestRepository, IEventPackageRepository eventPackageRepository, IEventRepository eventRepository,
            IEventEndofDayFactory eventEndofDayFactory, IOrganizationRoleUserRepository organizationRoleUserRepository, IKynLabValuesRepository kynLabValuesRepository, IHealthAssessmentService healthAssessmentService,
            IHospitalFacilityRepository hospitalFacilityRepository, IEventPodRepository eventPodRepository, IKynHealthAssessmentHelper kynHealthAssessmentHelper, ICustomerMedicareQuestionService medicareQuestionService,
            ICorporateAccountRepository corporateAccountRepository, ISettings settings, IEventCustomerPackageTestDetailService eventCustomerPackageTestDetailService)
        {
            _customerRepository = customerRepository;
            _hostRepository = hostRepository;
            _eventCustomerRepository = eventCustomerRepository;
            _appointmentRepository = appointmentRepository;
            _basicBiometricRepository = basicBiometricRepository;
            _orderRepository = orderRepository;
            _eventTestRepository = eventTestRepository;
            _eventPackageRepository = eventPackageRepository;
            _eventRepository = eventRepository;
            _eventCustomerResultRepository = eventCustomerResultRepository;
            _eventEndofDayFactory = eventEndofDayFactory;
            _organizationRoleUserRepository = organizationRoleUserRepository;

            _lipidTestResultRepository = new LipidTestRepository();
            _cholesterolTestResultRepository = new CholesterolTestRepository();
            _awvLipidTestResultRepository = new AwvLipidTestRepository();
            _diabetesTestResultRepository = new DiabetesTestRepository();
            _awvGlucoseTestResultRepository = new AwvGlucoseTestRepository();
            _myBioAssessmentTestRepository = new MyBioAssessmentTestRepository();


            _hba1CRepository = new HemaglobinTestRepository();
            _kynLabValuesRepository = kynLabValuesRepository;
            _healthAssessmentService = healthAssessmentService;
            _hospitalFacilityRepository = hospitalFacilityRepository;
            _testResultRepository = new TestResultRepository();
            _eventPodRepository = eventPodRepository;
            _hypertenstionRepository = new HypertensionTestRepository();
            _kynHealthAssessmentHelper = kynHealthAssessmentHelper;
            _medicareQuestionService = medicareQuestionService;
            _corporateAccountRepository = corporateAccountRepository;
            _hemogobinRepository = new HemoglobinTestRepository();

            _phq9Repository = new Phq9TestRepository();
            _qualityMeasuresRepository = new QualityMeasuresTestRepository();
            _focAttestationRepository = new FocAttestationTestRepository();
            _settings = settings;

            _hPyloriRepository = new HPyloriTestRepository();
            _eventCustomerPackageTestDetailService = eventCustomerPackageTestDetailService;
            _ifobtRepository = new IFOBTTestRepository();
        }

        public EventEndofDayListModel GetforEvent(long eventId)
        {
            var theEvent = _eventRepository.GetById(eventId);
            if (theEvent == null) return null;

            var isNewResultFlow = theEvent.EventDate >= _settings.ResultFlowChangeDate;

            var isHospitalPartnerAttached = _eventRepository.IsHospitalPartnerAttached(eventId);

            var host = _hostRepository.GetHostForEvent(eventId);
            var eventCustomers = _eventCustomerRepository.GetbyEventId(eventId);
            if (eventCustomers.IsNullOrEmpty())
                return null;
            eventCustomers = eventCustomers.Where(ec => ec.AppointmentId.HasValue && !ec.NoShow && !ec.LeftWithoutScreeningReasonId.HasValue).ToArray();

            if (eventCustomers.IsNullOrEmpty())
                return null;

            var account = _corporateAccountRepository.GetbyEventId(eventId);
            var isShowGiftCertificateOnEod = account != null && account.ShowGiftCertificateOnEod;
            var appointmentIds = eventCustomers.Select(ec => ec.AppointmentId.Value).ToArray();
            var appointments = _appointmentRepository.GetByIds(appointmentIds);

            var customerIds = eventCustomers.Select(ec => ec.CustomerId).ToArray();
            var customers = _customerRepository.GetCustomers(customerIds);

            var eventCustomerIds = eventCustomers.Select(ec => ec.Id).ToArray();

            var orders = _orderRepository.GetAllOrdersByEventCustomerIds(eventCustomerIds);

            var eventPackages = _eventPackageRepository.GetPackagesForEvent(eventId);
            var eventTests = _eventTestRepository.GetTestsForEvent(eventId);

            var isMedicareEnabled = (eventPackages != null && eventPackages.Any(eps => eps.Tests.Any(t => TestGroup.AwvTestIds.Contains(t.TestId))) ||
                                   (eventTests != null && eventTests.Any(t => TestGroup.AwvTestIds.Contains(t.TestId))));

            var readingsLipid = _lipidTestResultRepository.GetAllReadings((int)TestType.Lipid);
            var readingsCholesterol = _cholesterolTestResultRepository.GetAllReadings((int)TestType.Cholesterol);
            var readingsAwvLipid = _awvLipidTestResultRepository.GetAllReadings((int)TestType.AwvLipid);
            var readingsDiabetes = _diabetesTestResultRepository.GetAllReadings((int)TestType.Diabetes);
            var readingsAwvGlucose = _awvGlucoseTestResultRepository.GetAllReadings((int)TestType.AwvGlucose);

            var readingQualityMeasures = _qualityMeasuresRepository.GetAllReadings((int)TestType.QualityMeasures);
            var readingsIfobt = _ifobtRepository.GetAllReadings((int)TestType.IFOBT);

            var readingsMyBioCheck = _lipidTestResultRepository.GetAllReadings((int)TestType.MyBioCheckAssessment);


            var hospitalFacilities = _hospitalFacilityRepository.GetByEventId(eventId);
            var isHospitalFacilitiesAttached = false;

            isHospitalFacilitiesAttached = hospitalFacilities != null && hospitalFacilities.Any();
            var isKynIntegrationEnabled = _eventPodRepository.IsKynIntegrationEnabled(eventId);

            var basicBiometrics = _basicBiometricRepository.Get(eventCustomerIds);

            IEnumerable<OrderedPair<long, DateTime>> orderedPairsHealthAssesmentForm = null;
            if (account == null || account.CaptureHaf)
            {
                orderedPairsHealthAssesmentForm = _healthAssessmentService.GetHealthAssesmentSavedDatePair(eventCustomerIds);
            }

            var lipidStates = new List<OrderedPair<long, bool>>();
            var cholesterolStates = new List<OrderedPair<long, bool>>();
            var awvLipidStates = new List<OrderedPair<long, bool>>();
            var diabetesStates = new List<OrderedPair<long, bool>>();
            var awvGlucoseStates = new List<OrderedPair<long, bool>>();

            var hbA1CState = new List<OrderedPair<long, bool>>();
            var kynState = new List<OrderedPair<long, bool>>();
            var hkynState = new List<OrderedPair<long, bool>>();

            var hypertensionState = new List<OrderedPair<long, bool>>();

            var hPyloriStates = new List<OrderedPair<long, bool>>();
            var hemoglobinStates = new List<OrderedPair<long, bool>>();

            var phq9States = new List<OrderedPair<long, bool>>();

            var qualityMeasuresStates = new List<OrderedPair<long, bool>>();

            var facAttestationStates = new List<OrderedPair<long, bool>>();

            var ifobtStates = new List<OrderedPair<long, bool>>();
            var myBioCheckStates = new List<OrderedPair<long, bool>>();

            foreach (EventCustomer eventCustomer in eventCustomers)
            {
                lipidStates.Add(new OrderedPair<long, bool>(eventCustomer.Id, CheckIfLipidIsComplete(readingsLipid, eventId, eventCustomer.CustomerId, isNewResultFlow)));
                cholesterolStates.Add(new OrderedPair<long, bool>(eventCustomer.Id, CheckifCholesterolIsComplete(readingsCholesterol, eventId, eventCustomer.CustomerId, isNewResultFlow)));
                awvLipidStates.Add(new OrderedPair<long, bool>(eventCustomer.Id, CheckifAwvLipidIsComplete(readingsAwvLipid, eventId, eventCustomer.CustomerId, isNewResultFlow)));
                diabetesStates.Add(new OrderedPair<long, bool>(eventCustomer.Id, CheckIfDiabetesIsComplete(readingsDiabetes, eventId, eventCustomer.CustomerId, isNewResultFlow)));
                awvGlucoseStates.Add(new OrderedPair<long, bool>(eventCustomer.Id, CheckIfAwvGlucoseIsComplete(readingsAwvGlucose, eventId, eventCustomer.CustomerId, isNewResultFlow)));

                hbA1CState.Add(new OrderedPair<long, bool>(eventCustomer.Id, CheckifHemaglobinisComplete(eventId, eventCustomer.CustomerId, isNewResultFlow)));

                hPyloriStates.Add(new OrderedPair<long, bool>(eventCustomer.Id, CheckIfHelicobacterPyloriIsComplete(eventId, eventCustomer.CustomerId, isNewResultFlow)));
                hemoglobinStates.Add(new OrderedPair<long, bool>(eventCustomer.Id, CheckifHemoglobinisComplete(eventId, eventCustomer.CustomerId, isNewResultFlow)));

                phq9States.Add(new OrderedPair<long, bool>(eventCustomer.Id, CheckifPhq9isComplete(eventId, eventCustomer.CustomerId, isNewResultFlow)));
                qualityMeasuresStates.Add(new OrderedPair<long, bool>(eventCustomer.Id, CheckifQualityMeasuresIsComplete(readingQualityMeasures, eventId, eventCustomer.CustomerId, isNewResultFlow)));

                facAttestationStates.Add(new OrderedPair<long, bool>(eventCustomer.Id, CheckIfFocAttestationIsComplete(eventId, eventCustomer.CustomerId, isNewResultFlow)));

                ifobtStates.Add(new OrderedPair<long, bool>(eventCustomer.Id, CheckIfIfobtIsComplete(readingsIfobt, eventId, eventCustomer.CustomerId, isNewResultFlow)));

                var customer = customers.Single(c => c.CustomerId == eventCustomer.CustomerId);

                myBioCheckStates.Add(new OrderedPair<long, bool>(eventCustomer.Id, CheckIfMyBioCheckIsComplete(readingsMyBioCheck, eventId, customer, isNewResultFlow)));

                if (account == null || account.CaptureHaf)
                {
                    var basicBiometric = basicBiometrics.SingleOrDefault(bm => bm.Id == eventCustomer.Id);
                    kynState.Add(new OrderedPair<long, bool>(eventCustomer.Id, CheckifKynisComplete(eventCustomer.Id, basicBiometric, customer, eventId, isKynIntegrationEnabled, isNewResultFlow)));
                    hkynState.Add(new OrderedPair<long, bool>(eventCustomer.Id, CheckifHKynisComplete(eventCustomer.Id, basicBiometric, customer, eventId, isKynIntegrationEnabled, isNewResultFlow)));
                }

                if (theEvent.EventDate >= _settings.BasicBiometricCutOfDate)
                {
                    hypertensionState.Add(new OrderedPair<long, bool>(eventCustomer.Id, CheckIfHypertenstionTestComplete(eventId, eventCustomer.CustomerId, isNewResultFlow)));
                }
            }

            string signOffBy = "";
            if (theEvent.SignOffOrgRoleUserId.HasValue)
                signOffBy = _organizationRoleUserRepository.GetNameIdPairofUsers(new long[] { theEvent.SignOffOrgRoleUserId.Value }).Select(op => op.SecondValue).FirstOrDefault();

            var customerResultStatuses = _eventCustomerResultRepository.GetTestResultStatusforEvent(eventId);

            var orderdPairsMedicareSaved = _medicareQuestionService.GetEvenetCustomerMedicareSavedDatePair(eventId);

            return _eventEndofDayFactory.Create(theEvent, host, customers, eventCustomers, appointments, eventPackages, eventTests, orders, basicBiometrics, lipidStates, hbA1CState,
                                         customerResultStatuses, isHospitalPartnerAttached, orderedPairsHealthAssesmentForm, signOffBy, kynState, isHospitalFacilitiesAttached, isKynIntegrationEnabled, isMedicareEnabled,
                                         orderdPairsMedicareSaved, account, hypertensionState, _settings.BasicBiometricCutOfDate, cholesterolStates, awvLipidStates, diabetesStates, awvGlucoseStates, hPyloriStates, hemoglobinStates,
                                         qualityMeasuresStates, phq9States, facAttestationStates, ifobtStates, hkynState, myBioCheckStates, isShowGiftCertificateOnEod);
        }

        private bool CheckIfLipidIsComplete(IEnumerable<ResultReading<int>> resultReadings, long eventId, long customerId, bool isNewResultFlow)
        {
            var testResult = _lipidTestResultRepository.GetTestResults(customerId, eventId, isNewResultFlow);
            if (testResult == null || !(testResult is LipidTestResult)) return false;

            var lipidTestResult = testResult as LipidTestResult;
            if (lipidTestResult.UnableScreenReason != null && lipidTestResult.UnableScreenReason.Count > 0)
                return true;

            if (lipidTestResult.TestNotPerformed != null && lipidTestResult.TestNotPerformed.TestNotPerformedReasonId > 0)
                return true;

            if (lipidTestResult.TestPerformedExternally != null)
                return lipidTestResult.TestPerformedExternally.EntryCompleted;

            foreach (var resultReading in resultReadings)
            {
                switch (resultReading.Label)
                {
                    case ReadingLabels.Glucose:
                        if (lipidTestResult.Glucose == null || lipidTestResult.Glucose.Finding == null || lipidTestResult.Glucose.Finding.Id == 0)
                            return false;
                        break;

                    case ReadingLabels.TCHDLRatio:
                        if (lipidTestResult.TCHDLRatio == null || lipidTestResult.TCHDLRatio.Finding == null || lipidTestResult.TCHDLRatio.Finding.Id == 0)
                            return false;
                        break;

                    case ReadingLabels.TotalCholestrol:
                        if (lipidTestResult.TotalCholestrol == null || lipidTestResult.TotalCholestrol.Finding == null || lipidTestResult.TotalCholestrol.Finding.Id == 0)
                            return false;
                        break;

                    case ReadingLabels.TriGlycerides:
                        if (lipidTestResult.TriGlycerides == null || lipidTestResult.TriGlycerides.Finding == null || lipidTestResult.TriGlycerides.Finding.Id == 0)
                            return false;
                        break;

                    case ReadingLabels.HDL:
                        if (lipidTestResult.HDL == null || lipidTestResult.HDL.Finding == null || lipidTestResult.HDL.Finding.Id == 0)
                            return false;
                        break;

                    case ReadingLabels.LDL:
                        if (lipidTestResult.LDL == null || lipidTestResult.LDL.Finding == null || lipidTestResult.LDL.Finding.Id == 0)
                            return false;
                        break;
                }
            }

            return true;
        }

        private bool CheckifCholesterolIsComplete(IEnumerable<ResultReading<int>> resultReadings, long eventId, long customerId, bool isNewResultFlow)
        {
            var testResult = _cholesterolTestResultRepository.GetTestResults(customerId, eventId, isNewResultFlow);
            if (testResult == null || !(testResult is CholesterolTestResult)) return false;

            var cholesterolTestResult = testResult as CholesterolTestResult;
            if (cholesterolTestResult.UnableScreenReason != null && cholesterolTestResult.UnableScreenReason.Count > 0)
                return true;

            if (cholesterolTestResult.TestNotPerformed != null && cholesterolTestResult.TestNotPerformed.TestNotPerformedReasonId > 0)
                return true;

            if (cholesterolTestResult.TestPerformedExternally != null)
                return cholesterolTestResult.TestPerformedExternally.EntryCompleted;

            foreach (var resultReading in resultReadings)
            {
                switch (resultReading.Label)
                {

                    case ReadingLabels.TCHDLRatio:
                        if (cholesterolTestResult.TCHDLRatio == null || cholesterolTestResult.TCHDLRatio.Finding == null || cholesterolTestResult.TCHDLRatio.Finding.Id == 0)
                            return false;
                        break;

                    case ReadingLabels.TotalCholestrol:
                        if (cholesterolTestResult.TotalCholesterol == null || cholesterolTestResult.TotalCholesterol.Finding == null || cholesterolTestResult.TotalCholesterol.Finding.Id == 0)
                            return false;
                        break;

                    case ReadingLabels.TriGlycerides:
                        if (cholesterolTestResult.TriGlycerides == null || cholesterolTestResult.TriGlycerides.Finding == null || cholesterolTestResult.TriGlycerides.Finding.Id == 0)
                            return false;
                        break;

                    case ReadingLabels.HDL:
                        if (cholesterolTestResult.HDL == null || cholesterolTestResult.HDL.Finding == null || cholesterolTestResult.HDL.Finding.Id == 0)
                            return false;
                        break;

                    case ReadingLabels.LDL:
                        if (cholesterolTestResult.LDL == null || cholesterolTestResult.LDL.Finding == null || cholesterolTestResult.LDL.Finding.Id == 0)
                            return false;
                        break;
                }
            }

            return true;
        }

        private bool CheckifAwvLipidIsComplete(IEnumerable<ResultReading<int>> resultReadings, long eventId, long customerId, bool isNewResultFlow)
        {
            var testResult = _awvLipidTestResultRepository.GetTestResults(customerId, eventId, isNewResultFlow);
            if (testResult == null || !(testResult is AwvLipidTestResult)) return false;

            var awvLipidTestResult = testResult as AwvLipidTestResult;
            if (awvLipidTestResult.UnableScreenReason != null && awvLipidTestResult.UnableScreenReason.Count > 0)
                return true;

            if (awvLipidTestResult.TestNotPerformed != null && awvLipidTestResult.TestNotPerformed.TestNotPerformedReasonId > 0)
                return true;

            if (awvLipidTestResult.TestPerformedExternally != null)
                return awvLipidTestResult.TestPerformedExternally.EntryCompleted;

            foreach (var resultReading in resultReadings)
            {
                switch (resultReading.Label)
                {

                    case ReadingLabels.TCHDLRatio:
                        if (awvLipidTestResult.TCHDLRatio == null || awvLipidTestResult.TCHDLRatio.Finding == null || awvLipidTestResult.TCHDLRatio.Finding.Id == 0)
                            return false;
                        break;

                    case ReadingLabels.TotalCholestrol:
                        if (awvLipidTestResult.TotalCholestrol == null || awvLipidTestResult.TotalCholestrol.Finding == null || awvLipidTestResult.TotalCholestrol.Finding.Id == 0)
                            return false;
                        break;

                    case ReadingLabels.TriGlycerides:
                        if (awvLipidTestResult.TriGlycerides == null || awvLipidTestResult.TriGlycerides.Finding == null || awvLipidTestResult.TriGlycerides.Finding.Id == 0)
                            return false;
                        break;

                    case ReadingLabels.HDL:
                        if (awvLipidTestResult.HDL == null || awvLipidTestResult.HDL.Finding == null || awvLipidTestResult.HDL.Finding.Id == 0)
                            return false;
                        break;

                    case ReadingLabels.LDL:
                        if (awvLipidTestResult.LDL == null || awvLipidTestResult.LDL.Finding == null || awvLipidTestResult.LDL.Finding.Id == 0)
                            return false;
                        break;
                }
            }

            return true;
        }

        private bool CheckIfDiabetesIsComplete(IEnumerable<ResultReading<int>> resultReadings, long eventId, long customerId, bool isNewResultFlow)
        {
            var testResult = _diabetesTestResultRepository.GetTestResults(customerId, eventId, isNewResultFlow);
            if (testResult == null || !(testResult is DiabetesTestResult)) return false;

            var diabetesTestResult = testResult as DiabetesTestResult;
            if (diabetesTestResult.UnableScreenReason != null && diabetesTestResult.UnableScreenReason.Count > 0)
                return true;

            if (diabetesTestResult.TestNotPerformed != null && diabetesTestResult.TestNotPerformed.TestNotPerformedReasonId > 0)
                return true;

            if (diabetesTestResult.TestPerformedExternally != null)
                return diabetesTestResult.TestPerformedExternally.EntryCompleted;

            foreach (var resultReading in resultReadings)
            {
                switch (resultReading.Label)
                {
                    case ReadingLabels.Glucose:
                        if (diabetesTestResult.Glucose == null || diabetesTestResult.Glucose.Finding == null || diabetesTestResult.Glucose.Finding.Id == 0)
                            return false;
                        break;
                }
            }

            return true;
        }

        private bool CheckIfAwvGlucoseIsComplete(IEnumerable<ResultReading<int>> resultReadings, long eventId, long customerId, bool isNewResultFlow)
        {
            var testResult = _awvGlucoseTestResultRepository.GetTestResults(customerId, eventId, isNewResultFlow);
            if (testResult == null || !(testResult is AwvGlucoseTestResult)) return false;

            var awvGlucoseTestResult = testResult as AwvGlucoseTestResult;
            if (awvGlucoseTestResult.UnableScreenReason != null && awvGlucoseTestResult.UnableScreenReason.Count > 0)
                return true;

            if (awvGlucoseTestResult.TestNotPerformed != null && awvGlucoseTestResult.TestNotPerformed.TestNotPerformedReasonId > 0)
                return true;

            if (awvGlucoseTestResult.TestPerformedExternally != null)
                return awvGlucoseTestResult.TestPerformedExternally.EntryCompleted;


            foreach (var resultReading in resultReadings)
            {
                switch (resultReading.Label)
                {
                    case ReadingLabels.Glucose:
                        if (awvGlucoseTestResult.Glucose == null || awvGlucoseTestResult.Glucose.Finding == null || awvGlucoseTestResult.Glucose.Finding.Id == 0)
                            return false;
                        break;
                }
            }

            return true;
        }

        private bool CheckifHemaglobinisComplete(long eventId, long customerId, bool isNewResultFlow)
        {
            var testResult = _hba1CRepository.GetTestResults(customerId, eventId, isNewResultFlow);
            if (testResult == null || !(testResult is HemaglobinA1CTestResult)) return false;

            var hbA1C = testResult as HemaglobinA1CTestResult;
            if (hbA1C.UnableScreenReason != null && hbA1C.UnableScreenReason.Count > 0)
                return true;

            if (hbA1C.TestNotPerformed != null && hbA1C.TestNotPerformed.TestNotPerformedReasonId > 0)
                return true;

            if (hbA1C.TestPerformedExternally != null)
                return hbA1C.TestPerformedExternally.EntryCompleted;

            if (hbA1C.Hba1c == null)
                return false;

            return true;
        }

        private bool CheckIfHypertenstionTestComplete(long eventId, long customerId, bool isNewResultFlow)
        {
            var testResult = _hypertenstionRepository.GetTestResults(customerId, eventId, isNewResultFlow);
            if (testResult == null || !(testResult is HypertensionTestResult)) return false;

            var hypertenstion = testResult as HypertensionTestResult;
            if (hypertenstion.UnableScreenReason != null && hypertenstion.UnableScreenReason.Count > 0)
                return true;

            if (hypertenstion.TestNotPerformed != null && hypertenstion.TestNotPerformed.TestNotPerformedReasonId > 0)
                return true;

            if (hypertenstion.TestPerformedExternally != null)
                return hypertenstion.TestPerformedExternally.EntryCompleted;

            if (hypertenstion.Systolic == null || hypertenstion.Diastolic == null)
                return false;

            return true;
        }

        private bool CheckifKynisComplete(long eventCustomerId, BasicBiometric basicBiometric, Customer customer, long eventId, bool isKynIntegrationEnabled, bool isNewResultFlow)
        {
            if (!isKynIntegrationEnabled)
                return true;

            var eventTests = _eventCustomerPackageTestDetailService.GetTestsPurchasedByCustomer(eventId, customer.CustomerId);

            var isKynPurchased = _healthAssessmentService.IsTestPurchasedWithHealthAssessment((long)TestType.Kyn, eventTests);
            var isHkynPurchased = _healthAssessmentService.IsTestPurchasedWithHealthAssessment((long)TestType.HKYN, eventTests);
            if (!isKynPurchased && !isHkynPurchased)
                return true;

            var testResult = isKynPurchased ? _testResultRepository.GetTestResult(customer.CustomerId, eventId, (int)TestType.Kyn, isNewResultFlow) : _testResultRepository.GetTestResult(customer.CustomerId, eventId, (int)TestType.HKYN, isNewResultFlow);
            var test = isKynPurchased ? TestType.Kyn : TestType.HKYN;
            if (testResult != null && testResult.UnableScreenReason != null && testResult.UnableScreenReason.Count > 0)
                return true;

            if (testResult != null && testResult.TestPerformedExternally != null)
                return testResult.TestPerformedExternally.EntryCompleted;


            if (customer.Height == null || customer.Height.TotalInches <= 0)
                return false;

            if (customer.Weight == null || customer.Weight.Pounds <= 0)
                return false;

            if (customer.Waist == null || customer.Waist.Value <= 0)
                return false;

            if (basicBiometric == null || basicBiometric.PulseRate == null || basicBiometric.PulseRate.Value <= 0)
                return false;

            if (basicBiometric.SystolicPressure == null || basicBiometric.SystolicPressure.Value <= 0)
                return false;

            if (basicBiometric.DiastolicPressure == null || basicBiometric.DiastolicPressure.Value <= 0)
                return false;

            var kynLabValues = _kynLabValuesRepository.Get(eventCustomerId, (long)test);

            if (kynLabValues == null)
                return false;

            if (kynLabValues.FastingStatus == null || kynLabValues.Glucose == null || kynLabValues.Glucose.Value <= 0 || kynLabValues.TotalCholesterol == null || kynLabValues.TotalCholesterol.Value <= 0 ||
                kynLabValues.Triglycerides == null || kynLabValues.Triglycerides.Value <= 0 || kynLabValues.Hdl == null || kynLabValues.Hdl.Value <= 0)
                return false;

            var isKynHafFilled = _kynHealthAssessmentHelper.IsKynHafFilled(eventId, customer);
            if (!isKynHafFilled)
                return false;

            return true;
        }

        private bool CheckifHKynisComplete(long eventCustomerId, BasicBiometric basicBiometric, Customer customer, long eventId, bool isKynIntegrationEnabled, bool isNewResultFlow)
        {
            if (!isKynIntegrationEnabled)
                return true;

            var eventTests = _eventCustomerPackageTestDetailService.GetTestsPurchasedByCustomer(eventId, customer.CustomerId);


            var test = TestType.HKYN;

            var isHkynPurchased = _healthAssessmentService.IsTestPurchasedWithHealthAssessment((long)test, eventTests);
            if (!isHkynPurchased)
                return true;

            var testResult = _testResultRepository.GetTestResult(customer.CustomerId, eventId, (int)test, isNewResultFlow);

            if (testResult != null && testResult.UnableScreenReason != null && testResult.UnableScreenReason.Count > 0)
                return true;

            if (testResult != null && testResult.TestPerformedExternally != null)
                return testResult.TestPerformedExternally.EntryCompleted;

            if (customer.Height == null || customer.Height.TotalInches <= 0)
                return false;

            if (customer.Weight == null || customer.Weight.Pounds <= 0)
                return false;

            if (customer.Waist == null || customer.Waist.Value <= 0)
                return false;

            if (basicBiometric == null || basicBiometric.PulseRate == null || basicBiometric.PulseRate.Value <= 0)
                return false;

            if (basicBiometric.SystolicPressure == null || basicBiometric.SystolicPressure.Value <= 0)
                return false;

            if (basicBiometric.DiastolicPressure == null || basicBiometric.DiastolicPressure.Value <= 0)
                return false;

            var kynLabValues = _kynLabValuesRepository.Get(eventCustomerId, (long)test);

            if (kynLabValues == null)
                return false;

            if (kynLabValues.FastingStatus == null || kynLabValues.A1c == null || kynLabValues.A1c.Value <= 0 || kynLabValues.TotalCholesterol == null || kynLabValues.TotalCholesterol.Value <= 0 ||
                kynLabValues.Triglycerides == null || kynLabValues.Triglycerides.Value <= 0 || kynLabValues.Hdl == null || kynLabValues.Hdl.Value <= 0)
                return false;

            var isKynHafFilled = _kynHealthAssessmentHelper.IsKynHafFilled(eventId, customer);
            if (!isKynHafFilled)
                return false;

            return true;
        }

        private bool CheckIfHelicobacterPyloriIsComplete(long eventId, long customerId, bool isNewResultFlow)
        {
            var testResult = _hPyloriRepository.GetTestResults(customerId, eventId, isNewResultFlow);
            if (testResult == null || !(testResult is HPyloriTestResult)) return false;

            var hPyloriTestResult = testResult as HPyloriTestResult;
            if (hPyloriTestResult.UnableScreenReason != null && hPyloriTestResult.UnableScreenReason.Count > 0)
                return true;

            if (hPyloriTestResult.TestNotPerformed != null && hPyloriTestResult.TestNotPerformed.TestNotPerformedReasonId > 0)
                return true;

            if (hPyloriTestResult.TestPerformedExternally != null)
                return hPyloriTestResult.TestPerformedExternally.EntryCompleted;

            if (hPyloriTestResult.Finding == null || hPyloriTestResult.Finding.Id <= 0)
                return false;
            return true;
        }

        private bool CheckifHemoglobinisComplete(long eventId, long customerId, bool isNewResultFlow)
        {
            var testResult = _hemogobinRepository.GetTestResults(customerId, eventId, isNewResultFlow);
            if (testResult == null || !(testResult is HemoglobinTestResult)) return false;

            var hbA1C = testResult as HemoglobinTestResult;
            if (hbA1C.UnableScreenReason != null && hbA1C.UnableScreenReason.Count > 0)
                return true;

            if (hbA1C.TestNotPerformed != null && hbA1C.TestNotPerformed.TestNotPerformedReasonId > 0)
                return true;

            if (hbA1C != null && hbA1C.TestPerformedExternally != null)
                return hbA1C.TestPerformedExternally.EntryCompleted;

            if (hbA1C.Hemoglobin == null)
                return false;

            return true;
        }

        private bool CheckifPhq9isComplete(long eventId, long customerId, bool isNewResultFlow)
        {
            var testResult = _phq9Repository.GetTestResults(customerId, eventId, isNewResultFlow);
            if (testResult == null || !(testResult is Phq9TestResult)) return false;

            var phq9 = testResult as Phq9TestResult;
            if (phq9.UnableScreenReason != null && phq9.UnableScreenReason.Count > 0)
                return true;

            if (phq9.TestNotPerformed != null && phq9.TestNotPerformed.TestNotPerformedReasonId > 0)
                return true;

            if (phq9.TestPerformedExternally != null)
                return phq9.TestPerformedExternally.EntryCompleted;

            return phq9.Phq9Score != null;
        }

        private bool CheckifQualityMeasuresIsComplete(IEnumerable<ResultReading<int>> resultReadings, long eventId, long customerId, bool isNewResultFlow)
        {
            var testResult = _qualityMeasuresRepository.GetTestResults(customerId, eventId, isNewResultFlow);
            if (testResult == null || !(testResult is QualityMeasuresTestResult)) return false;

            var qualityMeasures = testResult as QualityMeasuresTestResult;
            if (qualityMeasures.UnableScreenReason != null && qualityMeasures.UnableScreenReason.Count > 0)
                return true;

            if (qualityMeasures.TestNotPerformed != null && qualityMeasures.TestNotPerformed.TestNotPerformedReasonId > 0)
                return true;

            if (qualityMeasures.TestPerformedExternally != null)
                return qualityMeasures.TestPerformedExternally.EntryCompleted;

            foreach (var resultReading in resultReadings)
            {
                switch (resultReading.Label)
                {
                    case ReadingLabels.FunctionalAssessmentScore:
                        if (qualityMeasures.FunctionalAssessmentScore == null || qualityMeasures.FunctionalAssessmentScore.Id == 0)
                            return false;
                        break;
                    case ReadingLabels.PainAssessmentScore:
                        if (qualityMeasures.PainAssessmentScore == null || qualityMeasures.PainAssessmentScore.Id == 0)
                            return false;
                        break;
                    case ReadingLabels.GaitFail:
                    case ReadingLabels.GaitPass:
                        if (qualityMeasures.GaitFail == null && qualityMeasures.GaitPass == null)
                            return false;
                        break;
                    case ReadingLabels.ClockFail:
                    case ReadingLabels.ClockPass:
                        if (qualityMeasures.ClockFail == null && qualityMeasures.ClockPass == null)
                            return false;
                        break;
                    case ReadingLabels.MemoryRecallScore:
                        if (qualityMeasures.MemoryRecallScore == null)
                            return false;
                        break;
                }

            }
            return true;
        }

        private bool CheckIfFocAttestationIsComplete(long eventId, long customerId, bool isNewResultFlow)
        {
            var testResult = _focAttestationRepository.GetTestResults(customerId, eventId, isNewResultFlow);
            if (testResult == null || !(testResult is FocAttestationTestResult)) return false;

            var focAttestation = testResult as FocAttestationTestResult;

            if (focAttestation.UnableScreenReason != null && focAttestation.UnableScreenReason.Count > 0)
                return true;

            if (focAttestation.TestNotPerformed != null && focAttestation.TestNotPerformed.TestNotPerformedReasonId > 0)
                return true;

            if (focAttestation.TestPerformedExternally != null)
                return focAttestation.TestPerformedExternally.EntryCompleted;

            return focAttestation.ResultImage != null;
        }

        private bool CheckIfIfobtIsComplete(IEnumerable<ResultReading<int>> resultReadings, long eventId, long customerId, bool isNewResultFlow)
        {
            var testResult = _ifobtRepository.GetTestResults(customerId, eventId, isNewResultFlow);
            if (testResult == null || !(testResult is IFOBTTestResult)) return false;

            var ifobt = testResult as IFOBTTestResult;
            if (ifobt.UnableScreenReason != null && ifobt.UnableScreenReason.Count > 0)
                return true;

            if (ifobt.TestNotPerformed != null && ifobt.TestNotPerformed.TestNotPerformedReasonId > 0)
                return true;

            if (ifobt.TestPerformedExternally != null)
                return ifobt.TestPerformedExternally.EntryCompleted;

            foreach (var resultReading in resultReadings)
            {
                switch (resultReading.Label)
                {
                    case ReadingLabels.IFOBTSerialKey:
                        if (ifobt.SerialKey == null || string.IsNullOrEmpty(ifobt.SerialKey.Reading))
                            return false;
                        break;
                }
            }

            return true;
        }

        private bool CheckIfMyBioCheckIsComplete(IEnumerable<ResultReading<int>> resultReadings, long eventId, Customer customer, bool isNewResultFlow)
        {
            var testResult = _myBioAssessmentTestRepository.GetTestResults(customer.CustomerId, eventId, isNewResultFlow);
            if (testResult == null || !(testResult is MyBioAssessmentTestResult)) return false;

            var myBioAssessmentTestResult = testResult as MyBioAssessmentTestResult;
            if (myBioAssessmentTestResult.UnableScreenReason != null && myBioAssessmentTestResult.UnableScreenReason.Count > 0)
                return true;

            if (myBioAssessmentTestResult.TestNotPerformed != null && myBioAssessmentTestResult.TestNotPerformed.TestNotPerformedReasonId > 0)
                return true;

            if (myBioAssessmentTestResult.TestPerformedExternally != null)
                return myBioAssessmentTestResult.TestPerformedExternally.EntryCompleted;

            foreach (var resultReading in resultReadings)
            {
                switch (resultReading.Label)
                {
                    case ReadingLabels.Glucose:
                        if (myBioAssessmentTestResult.Glucose == null || myBioAssessmentTestResult.Glucose.Finding == null || myBioAssessmentTestResult.Glucose.Finding.Id == 0)
                            return false;
                        break;

                    case ReadingLabels.TCHDLRatio:
                        if (myBioAssessmentTestResult.TcHdlRatio == null || myBioAssessmentTestResult.TcHdlRatio.Finding == null || myBioAssessmentTestResult.TcHdlRatio.Finding.Id == 0)
                            return false;
                        break;

                    case ReadingLabels.TotalCholestrol:
                        if (myBioAssessmentTestResult.TotalCholestrol == null || myBioAssessmentTestResult.TotalCholestrol.Finding == null || myBioAssessmentTestResult.TotalCholestrol.Finding.Id == 0)
                            return false;
                        break;

                    case ReadingLabels.TriGlycerides:
                        if (myBioAssessmentTestResult.TriGlycerides == null || myBioAssessmentTestResult.TriGlycerides.Finding == null || myBioAssessmentTestResult.TriGlycerides.Finding.Id == 0)
                            return false;
                        break;

                    case ReadingLabels.HDL:
                        if (myBioAssessmentTestResult.Hdl == null || myBioAssessmentTestResult.Hdl.Finding == null || myBioAssessmentTestResult.Hdl.Finding.Id == 0)
                            return false;
                        break;

                    case ReadingLabels.LDL:
                        if (myBioAssessmentTestResult.Ldl == null || myBioAssessmentTestResult.Ldl.Finding == null || myBioAssessmentTestResult.Ldl.Finding.Id == 0)
                            return false;
                        break;
                }
            }

            var isCustomerInfoCompleted = (customer.Height != null && customer.Height.TotalInches > 0 && customer.Weight != null && customer.Weight.Pounds > 0);

            return isCustomerInfoCompleted;
        }

        public EventEndofDayListModel GetforEventMyBioCheckAssessment(long eventId)
        {
            var theEvent = _eventRepository.GetById(eventId);
            if (theEvent == null) return null;

            var isNewResultFlow = theEvent.EventDate >= _settings.ResultFlowChangeDate;

            var eventCustomers = _eventCustomerRepository.GetbyEventId(eventId);
            if (eventCustomers.IsNullOrEmpty())
                return null;
            eventCustomers = eventCustomers.Where(ec => ec.AppointmentId.HasValue && !ec.NoShow && !ec.LeftWithoutScreeningReasonId.HasValue).ToArray();

            if (eventCustomers.IsNullOrEmpty())
                return null;

            var customerIds = eventCustomers.Select(ec => ec.CustomerId).ToArray();
            var customers = _customerRepository.GetCustomers(customerIds);

            var eventCustomerIds = eventCustomers.Select(ec => ec.Id).ToArray();

            var orders = _orderRepository.GetAllOrdersByEventCustomerIds(eventCustomerIds);

            var eventPackages = _eventPackageRepository.GetPackagesForEvent(eventId);
            var eventTests = _eventTestRepository.GetTestsForEvent(eventId);

            var readingsMyBioCheck = _lipidTestResultRepository.GetAllReadings((int)TestType.MyBioCheckAssessment);

            var basicBiometrics = _basicBiometricRepository.Get(eventCustomerIds);

            var hypertensionState = new List<OrderedPair<long, bool>>();

            var myBioCheckStates = new List<OrderedPair<long, bool>>();

            foreach (EventCustomer eventCustomer in eventCustomers)
            {
                var customer = customers.Single(c => c.CustomerId == eventCustomer.CustomerId);

                myBioCheckStates.Add(new OrderedPair<long, bool>(eventCustomer.Id, CheckIfMyBioCheckIsComplete(readingsMyBioCheck, eventId, customer, isNewResultFlow)));

                if (theEvent.EventDate >= _settings.BasicBiometricCutOfDate)
                {
                    hypertensionState.Add(new OrderedPair<long, bool>(eventCustomer.Id, CheckIfHypertenstionTestComplete(eventId, eventCustomer.CustomerId, isNewResultFlow)));
                }
            }

            var account = _corporateAccountRepository.GetbyEventId(eventId);

            var customerResultStatuses = _eventCustomerResultRepository.GetTestResultStatusforEvent(eventId);

            return _eventEndofDayFactory.CreateForMyBioCheck(theEvent, customers, eventCustomers, eventPackages, eventTests, orders, basicBiometrics,
                customerResultStatuses, hypertensionState, _settings.BasicBiometricCutOfDate, myBioCheckStates, account);
        }
    }
}