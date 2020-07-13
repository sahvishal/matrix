using System.Collections.Generic;
using System.Linq;
using Falcon.App.Core.Application;
using Falcon.App.Core.Finance.Domain;
using Falcon.App.Core.Finance.Enum;
using Falcon.App.Core.Interfaces;
using Falcon.App.Core.Medical;
using Falcon.App.Core.Medical.Domain;
using Falcon.App.Core.Medical.Enum;
using Falcon.App.Core.Medical.Interfaces;
using Falcon.App.Core.Medical.ViewModels;
using Falcon.App.Core.Operations;
using Falcon.App.Core.Sales.Interfaces;
using Falcon.App.Core.Scheduling;
using Falcon.App.Core.Scheduling.Interfaces;
using Falcon.App.Core.Users;
using Falcon.App.Infrastructure.Medical.Interfaces;
using Falcon.App.Core.Finance.Interfaces;

namespace Falcon.App.Infrastructure.Repositories.Screening
{
    public class CustomerScreeningViewDataRepository : PersistenceRepository, ICustomerScreeningViewDataRepository
    {
        ICustomerScreeningViewDataFactory _factory;

        private readonly IEventCustomerRepository _eventCustomerRepository;
        private readonly ICustomerRepository _customerRepository;
        private readonly IPhysicianRepository _physicianRepository;
        private readonly IOrderRepository _orderRepository;
        private readonly IHostRepository _hostRepository;
        private readonly IAppointmentRepository _appointmentRepository;
        private readonly IEventRepository _eventRepository;
        private readonly IEventPackageRepository _packageRepository;
        private readonly IEventTestRepository _testRepository;
        private readonly IBasicBiometricRepository _basicBiometricRepository;
        private readonly IChargeCardRepository _chargeCardRepository;
        private readonly ICheckRepository _checkRepository;
        private readonly IPhysicianEvaluationRepository _physicianEvaluationRepsoitory;
        private readonly IPhysicianAssignmentService _physicianAssignmentService;
        private readonly IHospitalPartnerRepository _hospitalPartnerRepository;
        private readonly IEventPhysicianTestRepository _eventPhysicianTestRepository;
        private readonly ICorporateAccountRepository _corporateAccountRepository;
        private readonly ISettings _settings;

        public CustomerScreeningViewDataRepository(ICustomerRepository customerRepository, IPhysicianRepository physicianRepository, IOrderRepository orderRepository, ICustomerScreeningViewDataFactory customerScreeningViewDataFactory,
            IEventRepository eventRepository, IAppointmentRepository appointmentRepository, IEventPackageRepository packageRepository, IEventTestRepository testRepository, IHostRepository hostRepository, IBasicBiometricRepository basicBiometricRepository,
            IChargeCardRepository chargeCardRepository, IPhysicianEvaluationRepository physicianEvaluationRepository, IPhysicianAssignmentService physicianAssignmentService, IEventCustomerRepository eventCustomerRepository,
            ICheckRepository checkRepository, IHospitalPartnerRepository hospitalPartnerRepository, IEventPhysicianTestRepository eventPhysicianTestRepository, ISettings settings, ICorporateAccountRepository corporateAccountRepository)
        {
            _factory = customerScreeningViewDataFactory;
            _customerRepository = customerRepository;
            _physicianRepository = physicianRepository;
            _orderRepository = orderRepository;
            _hostRepository = hostRepository;
            _physicianEvaluationRepsoitory = physicianEvaluationRepository;
            _physicianAssignmentService = physicianAssignmentService;
            _appointmentRepository = appointmentRepository;
            _testRepository = testRepository;
            _packageRepository = packageRepository;
            _eventRepository = eventRepository;
            _basicBiometricRepository = basicBiometricRepository;
            _checkRepository = checkRepository;
            _chargeCardRepository = chargeCardRepository;
            _eventCustomerRepository = eventCustomerRepository;
            _hospitalPartnerRepository = hospitalPartnerRepository;
            _eventPhysicianTestRepository = eventPhysicianTestRepository;
            _corporateAccountRepository = corporateAccountRepository;
            _settings = settings;
        }

        public CustomerScreeningViewData GetCustomerScreeningViewData(long customerId, long eventId)
        {
            var eventCustomer = _eventCustomerRepository.Get(eventId, customerId);
            var customer = _customerRepository.GetCustomer(customerId);
            var theEvent = _eventRepository.GetById(eventId);
            var isNewResultFlow = theEvent.EventDate >= _settings.ResultFlowChangeDate;
            var testResults = GetTestResults(customerId, eventId, isNewResultFlow);
            var appointment = _appointmentRepository.GetEventCustomerAppointment(eventId, customerId);
            var order = _orderRepository.GetOrder(customerId, eventId);
            var package = _packageRepository.GetPackageForOrder(order.Id);

            var tests = _testRepository.GetTestsForOrder(order.Id);

            var evaluatingPhysicians = _physicianEvaluationRepsoitory.GetPhysicianEvaluation(eventCustomer.Id);
            var primaryEvalRecord = evaluatingPhysicians != null ? evaluatingPhysicians.Where(p => p.IsPrimaryEvaluator).OrderByDescending(p => p.EvaluationEndTime ?? p.EvaluationStartTime).FirstOrDefault() : null;

            var primaryPhysicianId = primaryEvalRecord != null ? primaryEvalRecord.PhysicianId : 0;
            var overreadPhysicianId = primaryEvalRecord != null ? evaluatingPhysicians.Where(p => !p.IsPrimaryEvaluator && p.EvaluationStartTime > primaryEvalRecord.EvaluationStartTime).OrderByDescending(
                p => p.EvaluationEndTime ?? p.EvaluationStartTime).Select(p => p.PhysicianId).FirstOrDefault() : 0;

            if (primaryPhysicianId < 1)
            {
                var assignment = _physicianAssignmentService.GetPhysicianIdsAssignedtoaCustomer(eventId, customerId);
                if (assignment != null)
                {
                    primaryPhysicianId = assignment.First();
                    overreadPhysicianId = assignment.ElementAtOrDefault(1);
                }
                else // Should be Skip Evaluation Case
                {
                    var physicians = testResults.Where(tr => tr.EvaluatedbyOrgRoleUserId > 0).Select(tr => tr.EvaluatedbyOrgRoleUserId).Distinct().ToArray();

                    if (physicians.Any())
                        primaryPhysicianId = physicians.First();

                    if (physicians.Count() > 1) overreadPhysicianId = physicians.Last();
                }
            }
            if (primaryPhysicianId < 1)
            {
                //todo:default for the state
                primaryPhysicianId = _physicianRepository.GetDefaultPhysicianforEvent(eventId);
            }

            var primaryPhysician = _physicianRepository.GetPhysician(primaryPhysicianId);
            var overreadPhysician = overreadPhysicianId > 0 ? _physicianRepository.GetPhysician(overreadPhysicianId) : null;

            var host = _hostRepository.GetHostForEvent(eventId);
            var basicBiometric = _basicBiometricRepository.Get(eventId, customerId);

            CustomerScreeningViewData viewData = _factory.Create(testResults, customer, appointment, theEvent, package != null ? package.Package : null, tests != null ? tests.Select(t => t.Test).ToArray() : null, host,
                                                                    primaryPhysician, overreadPhysician, order, basicBiometric);

            if (order.PaymentsApplied != null)
            {
                var chargeCardPayments =
                    order.PaymentsApplied.Where(pa => pa.PaymentType == PaymentType.CreditCard).Select(
                        pa => (ChargeCardPayment)pa).ToArray();

                if (chargeCardPayments.Count() > 0)
                    viewData.ChargeCards = _chargeCardRepository.GetByIds(chargeCardPayments.Select(cp => cp.ChargeCardId).ToArray());

                var checkPayments = order.PaymentsApplied.Where(pa => pa.PaymentType == PaymentType.Check).Select(
                    pa => (CheckPayment)pa).ToArray();

                if (checkPayments.Count() > 0)
                    viewData.Checks = _checkRepository.GetByIds(checkPayments.Select(c => c.CheckId).ToArray());
            }

            var eventHospitalPartner = _hospitalPartnerRepository.GetEventHospitalPartnersByEventId(eventId);
            if (eventHospitalPartner != null && eventHospitalPartner.RestrictEvaluation)
            {
                var eventPhysicianTests = _eventPhysicianTestRepository.GetByEventId(eventId);
                if (eventPhysicianTests != null && eventPhysicianTests.Any())
                {
                    viewData.EventPhysicianTests = eventPhysicianTests;
                }
            }

            return viewData;
        }

        // TODO: might need to put under a common place.
        private static List<TestResult> GetTestResults(long customerId, long eventId, bool isNewResultFlow)
        {
            var testResults = new List<TestResult>();

            ITestResultRepository testResultRepository = new ASITestRepository();
            var asiTestResult = testResultRepository.GetTestResults(customerId, eventId, isNewResultFlow);
            if (asiTestResult != null) testResults.Add(asiTestResult);

            testResultRepository = new PadTestRepository();
            var padTestResult = testResultRepository.GetTestResults(customerId, eventId, isNewResultFlow);
            if (padTestResult != null) testResults.Add(padTestResult);

            testResultRepository = new AwvAbiTestRepository();
            var awvAbiTestResult = testResultRepository.GetTestResults(customerId, eventId, isNewResultFlow);
            if (awvAbiTestResult != null) testResults.Add(awvAbiTestResult);

            testResultRepository = new OsteoporosisTestRepository();
            var osteoTestResult = testResultRepository.GetTestResults(customerId, eventId, isNewResultFlow);
            if (osteoTestResult != null) testResults.Add(osteoTestResult);

            testResultRepository = new AwvBoneMassTestRepository();
            var awvBoneMassTestResult = testResultRepository.GetTestResults(customerId, eventId, isNewResultFlow);
            if (awvBoneMassTestResult != null) testResults.Add(awvBoneMassTestResult);

            testResultRepository = new EKGTestRepository();
            var ekgTestResult = testResultRepository.GetTestResults(customerId, eventId, isNewResultFlow);
            if (ekgTestResult != null)
                testResults.Add(ekgTestResult);

            testResultRepository = new AwvEkgTestRepository();
            var awvEkgTestResult = testResultRepository.GetTestResults(customerId, eventId, isNewResultFlow);
            if (awvEkgTestResult != null)
                testResults.Add(awvEkgTestResult);

            testResultRepository = new AwvEkgIppeTestRepository();
            var awvEkgIppeTestResult = testResultRepository.GetTestResults(customerId, eventId, isNewResultFlow);
            if (awvEkgIppeTestResult != null)
                testResults.Add(awvEkgIppeTestResult);

            testResultRepository = new LipidTestRepository();
            var lipidTestResult = testResultRepository.GetTestResults(customerId, eventId, isNewResultFlow);
            if (lipidTestResult != null)
                testResults.Add(lipidTestResult);

            testResultRepository = new AwvLipidTestRepository();
            var awvLipidTestResult = testResultRepository.GetTestResults(customerId, eventId, isNewResultFlow);
            if (awvLipidTestResult != null)
                testResults.Add(awvLipidTestResult);

            testResultRepository = new AwvGlucoseTestRepository();
            var awvGlucoseTestResult = testResultRepository.GetTestResults(customerId, eventId, isNewResultFlow);
            if (awvGlucoseTestResult != null)
                testResults.Add(awvGlucoseTestResult);

            testResultRepository = new LiverTestRepository();
            var liverTestResult = testResultRepository.GetTestResults(customerId, eventId, isNewResultFlow);
            if (liverTestResult != null)
                testResults.Add(liverTestResult);

            testResultRepository = new AAATestRepository();
            var aaaTestResult = testResultRepository.GetTestResults(customerId, eventId, isNewResultFlow);
            if (aaaTestResult != null)
                testResults.Add(aaaTestResult);

            testResultRepository = new AwvAaaTestRepository();
            var awvAaaTestResult = testResultRepository.GetTestResults(customerId, eventId, isNewResultFlow);
            if (awvAaaTestResult != null)
                testResults.Add(awvAaaTestResult);

            testResultRepository = new PpAaaTestRepository();
            var ppAaaTestResult = testResultRepository.GetTestResults(customerId, eventId, isNewResultFlow);
            if (ppAaaTestResult != null)
                testResults.Add(ppAaaTestResult);

            testResultRepository = new StrokeTestRepository();
            var strokeTestResult = testResultRepository.GetTestResults(customerId, eventId, isNewResultFlow);
            if (strokeTestResult != null)
                testResults.Add(strokeTestResult);

            testResultRepository = new AwvCarotidTestRepository();
            var awvCarotidTestResult = testResultRepository.GetTestResults(customerId, eventId, isNewResultFlow);
            if (awvCarotidTestResult != null)
                testResults.Add(awvCarotidTestResult);

            testResultRepository = new LeadTestRepository();
            var leadTestResult = testResultRepository.GetTestResults(customerId, eventId, isNewResultFlow);
            if (leadTestResult != null)
                testResults.Add(leadTestResult);

            testResultRepository = new EchocardiogramTestRepository();
            var echocResult = testResultRepository.GetTestResults(customerId, eventId, isNewResultFlow);
            if (echocResult != null)
                testResults.Add(echocResult);

            testResultRepository = new PpEchocardiogramTestRepository();
            var ppEchocResult = testResultRepository.GetTestResults(customerId, eventId, isNewResultFlow);
            if (ppEchocResult != null)
                testResults.Add(ppEchocResult);

            testResultRepository = new ImtTestRepository();
            var imtTestResult = testResultRepository.GetTestResults(customerId, eventId, isNewResultFlow);
            if (imtTestResult != null)
                testResults.Add(imtTestResult);

            testResultRepository = new PulmonaryFunctionTestRepository();
            var pulmonaryTestResult = testResultRepository.GetTestResults(customerId, eventId, isNewResultFlow);
            if (pulmonaryTestResult != null)
                testResults.Add(pulmonaryTestResult);

            testResultRepository = new SpiroTestRepository();
            var spiroTestResult = testResultRepository.GetTestResults(customerId, eventId, isNewResultFlow);
            if (spiroTestResult != null)
                testResults.Add(spiroTestResult);

            testResultRepository = new AwvSpiroTestRepository();
            var awvSpiroTestResult = testResultRepository.GetTestResults(customerId, eventId, isNewResultFlow);
            if (awvSpiroTestResult != null)
                testResults.Add(awvSpiroTestResult);

            testResultRepository = new HemaglobinTestRepository();
            var a1CTestResult = testResultRepository.GetTestResults(customerId, eventId, isNewResultFlow);
            if (a1CTestResult != null)
                testResults.Add(a1CTestResult);

            testResultRepository = new AwvHemaglobinTestRepository();
            var awvA1CTestResult = testResultRepository.GetTestResults(customerId, eventId, isNewResultFlow);
            if (awvA1CTestResult != null)
                testResults.Add(awvA1CTestResult);

            testResultRepository = new HemoglobinTestRepository();
            var hemoglobinTestResult = testResultRepository.GetTestResults(customerId, eventId, isNewResultFlow);
            if (hemoglobinTestResult != null)
                testResults.Add(hemoglobinTestResult);

            testResultRepository = new ThyroidTestRepository();
            var thyroidTestResult = testResultRepository.GetTestResults(customerId, eventId, isNewResultFlow);
            if (thyroidTestResult != null) testResults.Add(thyroidTestResult);

            testResultRepository = new PsaTestRepository();
            var psaTestResult = testResultRepository.GetTestResults(customerId, eventId, isNewResultFlow);
            if (psaTestResult != null) testResults.Add(psaTestResult);

            testResultRepository = new CrpTestRepository();
            var crpTestResult = testResultRepository.GetTestResults(customerId, eventId, isNewResultFlow);
            if (crpTestResult != null) testResults.Add(crpTestResult);

            testResultRepository = new TestosteroneTestRepository();
            var testosteroneTestResult = testResultRepository.GetTestResults(customerId, eventId, isNewResultFlow);
            if (testosteroneTestResult != null) testResults.Add(testosteroneTestResult);

            testResultRepository = new HearingTestRepository();
            var hearingTestResult = testResultRepository.GetTestResults(customerId, eventId, isNewResultFlow);
            if (hearingTestResult != null) testResults.Add(hearingTestResult);

            testResultRepository = new VisionTestRepository();
            var visionTestResult = testResultRepository.GetTestResults(customerId, eventId, isNewResultFlow);
            if (visionTestResult != null) testResults.Add(visionTestResult);

            testResultRepository = new GlaucomaTestRepository();
            var glaucomaTestResult = testResultRepository.GetTestResults(customerId, eventId, isNewResultFlow);
            if (glaucomaTestResult != null) testResults.Add(glaucomaTestResult);

            testResultRepository = new HcpAaaTestRepository();
            var hcpAaaTestResult = testResultRepository.GetTestResults(customerId, eventId, isNewResultFlow);
            if (hcpAaaTestResult != null)
                testResults.Add(hcpAaaTestResult);

            testResultRepository = new HcpCarotidTestRepository();
            var hcpCarotidTestResult = testResultRepository.GetTestResults(customerId, eventId, isNewResultFlow);
            if (hcpCarotidTestResult != null)
                testResults.Add(hcpCarotidTestResult);

            testResultRepository = new HcpEchocardiogramTestRepository();
            var hcpEchocResult = testResultRepository.GetTestResults(customerId, eventId, isNewResultFlow);
            if (hcpEchocResult != null)
                testResults.Add(hcpEchocResult);

            testResultRepository = new AwvEchocardiogramTestRepository();
            var awvEchocResult = testResultRepository.GetTestResults(customerId, eventId, isNewResultFlow);
            if (awvEchocResult != null)
                testResults.Add(awvEchocResult);

            testResultRepository = new CholesterolTestRepository();
            var cholesterolTestResult = testResultRepository.GetTestResults(customerId, eventId, isNewResultFlow);
            if (cholesterolTestResult != null)
                testResults.Add(cholesterolTestResult);


            testResultRepository = new DiabetesTestRepository();
            var diabetesTestResult = testResultRepository.GetTestResults(customerId, eventId, isNewResultFlow);
            if (diabetesTestResult != null)
                testResults.Add(diabetesTestResult);

            testResultRepository = new HPyloriTestRepository();
            var hPyloriTestResult = testResultRepository.GetTestResults(customerId, eventId, isNewResultFlow);
            if (hPyloriTestResult != null)
                testResults.Add(hPyloriTestResult);

            testResultRepository = new MenBloodPanelTestRepository();
            var menBloodPanelTestResult = testResultRepository.GetTestResults(customerId, eventId, isNewResultFlow);
            if (menBloodPanelTestResult != null)
                testResults.Add(menBloodPanelTestResult);

            testResultRepository = new WomenBloodPanelTestRepository();
            var womenBloodPanelTestResult = testResultRepository.GetTestResults(customerId, eventId, isNewResultFlow);
            if (womenBloodPanelTestResult != null)
                testResults.Add(womenBloodPanelTestResult);

            testResultRepository = new VitaminDTestRepository();
            var vitaminDTestResult = testResultRepository.GetTestResults(customerId, eventId, isNewResultFlow);
            if (vitaminDTestResult != null)
                testResults.Add(vitaminDTestResult);

            testResultRepository = new HypertensionTestRepository();
            var hypertensionTestResult = testResultRepository.GetTestResults(customerId, eventId, isNewResultFlow);
            if (hypertensionTestResult != null)
                testResults.Add(hypertensionTestResult);

            testResultRepository = new DiabeticRetinopathyTestRepository();
            var diabeticRetinopathyTestResult = testResultRepository.GetTestResults(customerId, eventId, isNewResultFlow);
            if (diabeticRetinopathyTestResult != null)
                testResults.Add(diabeticRetinopathyTestResult);

            testResultRepository = new EAwvTestRepository();
            var eawvTestResult = testResultRepository.GetTestResults(customerId, eventId, isNewResultFlow);
            if (eawvTestResult != null)
                testResults.Add(eawvTestResult);

            testResultRepository = new DiabetesFootExamTestRepository();
            var diabetesFootExamTestResult = testResultRepository.GetTestResults(customerId, eventId, isNewResultFlow);
            if (diabetesFootExamTestResult != null)
                testResults.Add(diabetesFootExamTestResult);

            testResultRepository = new RinneWeberHearingTestRepository();
            var rinneWeberHearingTestResult = testResultRepository.GetTestResults(customerId, eventId, isNewResultFlow);
            if (rinneWeberHearingTestResult != null)
                testResults.Add(rinneWeberHearingTestResult);

            testResultRepository = new MonofilamentTestRepository();
            var monofilamentTestResult = testResultRepository.GetTestResults(customerId, eventId, isNewResultFlow);
            if (monofilamentTestResult != null)
                testResults.Add(monofilamentTestResult);

            testResultRepository = new DiabeticNeuropathyTestRepository();
            var diabeticNeuropathyTestResult = testResultRepository.GetTestResults(customerId, eventId, isNewResultFlow);
            if (diabeticNeuropathyTestResult != null)
                testResults.Add(diabeticNeuropathyTestResult);

            testResultRepository = new FloChecABITestRepository();
            var floChecABITestResult = testResultRepository.GetTestResults(customerId, eventId, isNewResultFlow);
            if (floChecABITestResult != null)
                testResults.Add(floChecABITestResult);

            testResultRepository = new IFOBTTestRepository();
            var iFOBTTestResult = testResultRepository.GetTestResults(customerId, eventId, isNewResultFlow);
            if (iFOBTTestResult != null)
                testResults.Add(iFOBTTestResult);

            testResultRepository = new QualityMeasuresTestRepository();
            var qualityMeasureTestResult = testResultRepository.GetTestResults(customerId, eventId, isNewResultFlow);
            if (qualityMeasureTestResult != null)
                testResults.Add(qualityMeasureTestResult);

            testResultRepository = new Phq9TestRepository();
            var phq9TestResult = testResultRepository.GetTestResults(customerId, eventId, isNewResultFlow);
            if (phq9TestResult != null)
                testResults.Add(phq9TestResult);

            testResultRepository = new FocAttestationTestRepository();
            var focAttestationTestResult = testResultRepository.GetTestResults(customerId, eventId, isNewResultFlow);
            if (focAttestationTestResult != null)
                testResults.Add(focAttestationTestResult);

            testResultRepository = new MammogramTestRepository();
            var mammogramTestResult = testResultRepository.GetTestResults(customerId, eventId, isNewResultFlow);
            if (mammogramTestResult != null)
                testResults.Add(mammogramTestResult);

            testResultRepository = new UrineMicroalbuminTestRepository();
            var urineMicroalbuminTestResult = testResultRepository.GetTestResults(customerId, eventId, isNewResultFlow);
            if (urineMicroalbuminTestResult != null)
                testResults.Add(urineMicroalbuminTestResult);

            testResultRepository = new FluShotTestRepository();
            var fluShotTestResult = testResultRepository.GetTestResults(customerId, eventId, isNewResultFlow);
            if (fluShotTestResult != null)
                testResults.Add(fluShotTestResult);

            testResultRepository = new AwvFluShotTestRepository();
            var awvFluShotTestResult = testResultRepository.GetTestResults(customerId, eventId, isNewResultFlow);
            if (awvFluShotTestResult != null)
                testResults.Add(awvFluShotTestResult);

            testResultRepository = new PneumococcalTestRepository();
            var pneumococcalTestResult = testResultRepository.GetTestResults(customerId, eventId, isNewResultFlow);
            if (pneumococcalTestResult != null)
                testResults.Add(pneumococcalTestResult);

            testResultRepository = new ChlamydiaTestRepository();
            var chlamydiaTestResult = testResultRepository.GetTestResults(customerId, eventId, isNewResultFlow);
            if (chlamydiaTestResult != null)
                testResults.Add(chlamydiaTestResult);

            testResultRepository = new QuantaFloABITestRepository();
            var quantaFloABITestResult = testResultRepository.GetTestResults(customerId, eventId, isNewResultFlow);
            if (quantaFloABITestResult != null)
                testResults.Add(quantaFloABITestResult);


            testResultRepository = new DpnTestRepository();
            var dpnTestResult = testResultRepository.GetTestResults(customerId, eventId, isNewResultFlow);
            if (dpnTestResult != null)
                testResults.Add(dpnTestResult);

            testResultRepository = new MyBioAssessmentTestRepository();
            var mybioCheckTestResult = testResultRepository.GetTestResults(customerId, eventId, isNewResultFlow);
            if (mybioCheckTestResult != null)
                testResults.Add(mybioCheckTestResult);

            testResultRepository = new TestResultRepository();

            var testResult = testResultRepository.GetTestResult(customerId, eventId, (int)TestType.Colorectal, isNewResultFlow);
            if (testResult != null) testResults.Add(testResult);

            testResult = testResultRepository.GetTestResult(customerId, eventId, (int)TestType.Kyn, isNewResultFlow);
            if (testResult != null) testResults.Add(testResult);

            testResult = testResultRepository.GetTestResult(customerId, eventId, (int)TestType.AWV, isNewResultFlow);
            if (testResult != null) testResults.Add(testResult);

            testResultRepository = new TestResultRepository();
            testResult = testResultRepository.GetTestResult(customerId, eventId, (int)TestType.Medicare, isNewResultFlow);
            if (testResult != null) testResults.Add(testResult);

            testResultRepository = new TestResultRepository();
            testResult = testResultRepository.GetTestResult(customerId, eventId, (int)TestType.AwvSubsequent, isNewResultFlow);
            if (testResult != null) testResults.Add(testResult);

            return testResults;
        }
    }
}
