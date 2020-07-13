using System;
using System.IO;
using System.Linq;
using System.Web.Services;
using System.Web.Script.Services;
using Falcon.App.Core.Application;
using Falcon.App.Core.Application.Helper;
using Falcon.App.Core.Application.Impl;
using Falcon.App.Core.Audit.Enum;
using Falcon.App.Core.Communication;
using Falcon.App.Core.Communication.Enum;
using Falcon.App.Core.Communication.Interfaces;
using Falcon.App.Core.Deprecated;
using Falcon.App.Core.Enum;
using Falcon.App.Core.Extensions;
using Falcon.App.Core.Finance.Interfaces;
using Falcon.App.Core.Interfaces;
using Falcon.App.Core.Medical;
using Falcon.App.Core.Medical.Domain;
using Falcon.App.Core.Medical.Enum;
using Falcon.App.Core.Medical.Impl;
using Falcon.App.Core.Medical.Interfaces;
using Falcon.App.Core.Medical.ViewModels;
using Falcon.App.Core.Medicare;
using Falcon.App.Core.Medicare.Enum;
using Falcon.App.Core.Medicare.ViewModels;
using Falcon.App.Core.Scheduling;
using Falcon.App.Core.Scheduling.Domain;
using Falcon.App.Core.Scheduling.Interfaces;
using Falcon.App.Core.Users;
using Falcon.App.Core.Users.Domain;
using Falcon.App.Core.Users.ViewModels;
using Falcon.App.DependencyResolution;
using Falcon.App.Infrastructure.Medical.Repositories;
using Falcon.App.Infrastructure.Scheduling.Repositories;
using Falcon.App.Infrastructure.Users.Repositories;
using Falcon.App.UI;
using Falcon.App.UI.App.BasePageClass;
using Falcon.Entity.Other;
using System.Collections.Generic;
using Falcon.DataAccess.Other;
using Falcon.App.Infrastructure.Repositories.Screening;
using Falcon.App.Infrastructure.Repositories.Users;
using Falcon.App.Core.Impl;
using Falcon.App.Infrastructure.Service;
using Falcon.App.Core.Domain;
using Falcon.App.Core.Domain.ViewData;
using System.Web.Script.Serialization;
using System.Web.UI.MobileControls;
using Falcon.App.Core;
using Falcon.App.Core.Communication.ViewModels;
using Falcon.App.Infrastructure.Repositories;
using Falcon.App.Core.Users.Enum;


/// <summary>
/// Summary description for ManualEntryAndAuditController
/// </summary>
[WebService(Namespace = "http://ManualEntryAndAuditController.org/")]
[WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
[ScriptService]
public class ManualEntryAndAuditController : BaseWebService
{

    [WebMethod(EnableSession = true)]
    public bool GetIsEventSignOff(Int64 eventId)
    {
        //TODO:SignOff value should be changed when there is a new registration after signoff.
        //return masterDal.GetIsEventSignOff(eventId);
        return false;
    }

    [WebMethod(EnableSession = true)]
    public EZip ValidateCityAndZip(string stateId, string cityName, string zipCode, bool bolForPcp)
    {
        var otherDal = new OtherDAL();
        if (bolForPcp)
        {
            if (zipCode.Length > 0)
                return otherDal.CheckCityZip(cityName, zipCode, stateId);
            return otherDal.GetCityZip(cityName, stateId);
        }
        return otherDal.CheckCityZip(cityName, zipCode, stateId);
    }

    [WebMethod(EnableSession = true)]
    public bool ValidateUniqueEmailAddress(long customerId, string emailAddress)
    {
        ICustomerRepository customerRepository = new CustomerRepository();
        return customerRepository.UniqueEmail(customerId, emailAddress);
    }

    [WebMethod(EnableSession = true)]
    public List<TestResult> GetTestResultsPhysician(long customerId, long eventId, string urlPath)
    {
        var tests = IoC.Resolve<IEventTestRepository>().GetTestsForEvent(eventId);
        tests = tests.Where(t => t.Test.IsRecordable && t.Test.IsReviewable).ToList();

        var eventRepository = IoC.Resolve<IEventRepository>();
        var isNewResultFlow = eventRepository.IsEventHasNewResultFlow(eventId);

        var testResults = FetchTestResults(customerId, eventId, isNewResultFlow, tests.Select(t => t.Test).ToArray());
        var custDetail = new { CustomerId = customerId, EventId = eventId, TestResult = testResults.Count > 0 ? "Retreived" : "None of the  Results Saved" };
        LogFilterListPairAudit(ModelType.List, custDetail, testResults, urlPath, "GET");

        var customerEventTestStateRepository = IoC.Resolve<ICustomerEventTestStateRepository>();
        var isPatientCritical = customerEventTestStateRepository.IsPatientCriticalForHIPTest(eventId, customerId);

        testResults.ForEach(x => x.ResultStatus.SelfPresent = isPatientCritical);

        return testResults;
    }

    // public static long[] currentCriticaltestIds;

    [WebMethod(EnableSession = true)]
    public List<TestResult> GetTestResults(long customerId, long eventId, string urlPath)
    {
        var eventCustomerResultRepository = IoC.Resolve<IEventCustomerResultRepository>();
        var eventCustomerResult = eventCustomerResultRepository.GetByCustomerIdAndEventId(customerId, eventId);
        if (eventCustomerResult != null && eventCustomerResult.ResultState < (int)TestResultStateNumber.PreAudit)
        {
            try
            {
                var orderId = IoC.Resolve<IOrderRepository>().GetOrderIdByEventIdCustomerId(eventId, customerId);
                var eventPackage = IoC.Resolve<IEventPackageRepository>().GetPackageForOrder(orderId);
                var eventTests = IoC.Resolve<IEventTestRepository>().GetTestsForOrder(orderId);

                var tests = eventPackage != null ? eventPackage.Tests.Select(t => t.TestId).ToList() : new List<long>();
                if (eventTests != null && eventTests.Count() > 0)
                    tests.AddRange(eventTests.Select(et => et.TestId));

                var model = eventCustomerResultRepository.GetTestResultStatusforEventCustomer(eventId, customerId);
                if (model != null && model.TestResults != null)
                {
                    var testIdsNotinOrder =
                        model.TestResults.Where(tr => !tests.Contains(tr.TestId)).Select(tr => tr.TestId).ToArray();
                    var testResultRepository = new TestResultRepository();
                    foreach (var testId in testIdsNotinOrder)
                    {
                        testResultRepository.DeleteTestData(eventId, customerId, testId);
                    }
                }
            }
            catch (Exception ex)
            {
                IoC.Resolve<ILogManager>().GetLogger<Global>().Error("\nError while deleteing test data in Adjust Order for CustomerId[" + customerId + "] & EventId [" + eventId + "]. Message: " + ex.Message + "\n\t" + ex.StackTrace);
            }
        }
        var eventRepository = IoC.Resolve<IEventRepository>();
        var isNewResultFlow = eventRepository.IsEventHasNewResultFlow(eventId);

        var testResults = FetchTestResults(customerId, eventId, isNewResultFlow, null);

        long[] currentCriticaltestIds = null;
        if (!testResults.IsNullOrEmpty())
            currentCriticaltestIds = testResults.Where(t => t.ResultStatus.SelfPresent == true).Select(t => (long)((TestType)t.TestType)).ToArray();
        Session["CurrentCriticaltestIds"] = currentCriticaltestIds;

        var custDetail = new { CustomerId = customerId, EventId = eventId, TestResult = testResults.Count > 0 ? "Retreived" : "None of the  Results Saved" };
        LogFilterListPairAudit(ModelType.List, custDetail, testResults, urlPath, "GET");
        return testResults;
    }

    private static List<TestResult> FetchTestResults(long customerId, long eventId, bool isNewResultFlow, IEnumerable<Test> tests = null)
    {
        if (tests == null)
        {
            var eventTests = IoC.Resolve<IEventTestRepository>().GetTestsForEvent(eventId);
            if (eventTests != null)
                tests = eventTests.Where(t => t.Test.IsRecordable).Select(t => t.Test).ToList();
        }

        var testResults = new List<TestResult>();
        ITestResultRepository testResultRepository;
        foreach (var test in tests)
        {
            switch ((TestType)test.Id)
            {
                case TestType.ASI:
                    testResultRepository = new ASITestRepository();
                    var asiTestResult = testResultRepository.GetTestResults(customerId, eventId, isNewResultFlow);
                    if (asiTestResult != null) testResults.Add(asiTestResult);
                    break;

                case TestType.AAA:
                    testResultRepository = new AAATestRepository();
                    var aaaTestResult = testResultRepository.GetTestResults(customerId, eventId, isNewResultFlow);
                    if (aaaTestResult != null)
                        testResults.Add(aaaTestResult);
                    break;

                case TestType.AwvAAA:
                    testResultRepository = new AwvAaaTestRepository();
                    var awvAaaTestResult = testResultRepository.GetTestResults(customerId, eventId, isNewResultFlow);
                    if (awvAaaTestResult != null)
                        testResults.Add(awvAaaTestResult);
                    break;

                case TestType.Stroke:
                    testResultRepository = new StrokeTestRepository();
                    var strokeTestResult = testResultRepository.GetTestResults(customerId, eventId, isNewResultFlow);
                    if (strokeTestResult != null)
                        testResults.Add(strokeTestResult);
                    break;

                case TestType.AwvCarotid:
                    testResultRepository = new AwvCarotidTestRepository();
                    var awvCarotidTestResult = testResultRepository.GetTestResults(customerId, eventId, isNewResultFlow);
                    if (awvCarotidTestResult != null)
                        testResults.Add(awvCarotidTestResult);
                    break;

                case TestType.Lead:
                    testResultRepository = new LeadTestRepository();
                    var leadTestResult = testResultRepository.GetTestResults(customerId, eventId, isNewResultFlow);
                    if (leadTestResult != null)
                        testResults.Add(leadTestResult);
                    break;

                case TestType.PAD:
                    testResultRepository = new PadTestRepository();
                    var padTestResult = testResultRepository.GetTestResults(customerId, eventId, isNewResultFlow);
                    if (padTestResult != null) testResults.Add(padTestResult);
                    break;

                case TestType.AwvABI:
                    testResultRepository = new AwvAbiTestRepository();
                    var awvAbiTestResult = testResultRepository.GetTestResults(customerId, eventId, isNewResultFlow);
                    if (awvAbiTestResult != null) testResults.Add(awvAbiTestResult);
                    break;

                case TestType.IMT:
                    testResultRepository = new ImtTestRepository();
                    var imtTestResult = testResultRepository.GetTestResults(customerId, eventId, isNewResultFlow);
                    if (imtTestResult != null)
                        testResults.Add(imtTestResult);
                    break;

                case TestType.EKG:
                    testResultRepository = new EKGTestRepository();
                    var ekgTestResult = testResultRepository.GetTestResults(customerId, eventId, isNewResultFlow);
                    if (ekgTestResult != null)
                        testResults.Add(ekgTestResult);
                    break;

                case TestType.AwvEkg:
                    testResultRepository = new AwvEkgTestRepository();
                    var awvEkgTestResult = testResultRepository.GetTestResults(customerId, eventId, isNewResultFlow);
                    if (awvEkgTestResult != null)
                        testResults.Add(awvEkgTestResult);
                    break;

                case TestType.AwvEkgIPPE:
                    testResultRepository = new AwvEkgIppeTestRepository();
                    var awvEkgIppeTestResult = testResultRepository.GetTestResults(customerId, eventId, isNewResultFlow);
                    if (awvEkgIppeTestResult != null)
                        testResults.Add(awvEkgIppeTestResult);
                    break;

                case TestType.Echocardiogram:
                    testResultRepository = new EchocardiogramTestRepository();
                    var echoTestResult = testResultRepository.GetTestResults(customerId, eventId, isNewResultFlow);
                    if (echoTestResult != null)
                        testResults.Add(echoTestResult);
                    break;

                case TestType.PulmonaryFunction:
                    testResultRepository = new PulmonaryFunctionTestRepository();
                    var pulmonaryTestResult = testResultRepository.GetTestResults(customerId, eventId, isNewResultFlow);
                    if (pulmonaryTestResult != null)
                        testResults.Add(pulmonaryTestResult);
                    break;

                case TestType.Osteoporosis:
                    testResultRepository = new OsteoporosisTestRepository();
                    var osteoTestResult = testResultRepository.GetTestResults(customerId, eventId, isNewResultFlow);
                    if (osteoTestResult != null) testResults.Add(osteoTestResult);
                    break;

                case TestType.AwvBoneMass:
                    testResultRepository = new AwvBoneMassTestRepository();
                    var awvBoneMassTestResult = testResultRepository.GetTestResults(customerId, eventId, isNewResultFlow);
                    if (awvBoneMassTestResult != null) testResults.Add(awvBoneMassTestResult);
                    break;

                case TestType.Spiro:
                    testResultRepository = new SpiroTestRepository();
                    var spiroTestResult = testResultRepository.GetTestResults(customerId, eventId, isNewResultFlow);
                    if (spiroTestResult != null) testResults.Add(spiroTestResult);
                    break;

                case TestType.AwvSpiro:
                    testResultRepository = new AwvSpiroTestRepository();
                    var awvSpiroTestResult = testResultRepository.GetTestResults(customerId, eventId, isNewResultFlow);
                    if (awvSpiroTestResult != null) testResults.Add(awvSpiroTestResult);
                    break;

                case TestType.Liver:
                    testResultRepository = new LiverTestRepository();
                    var liverTestResult = testResultRepository.GetTestResults(customerId, eventId, isNewResultFlow);
                    if (liverTestResult != null)
                        testResults.Add(liverTestResult);
                    break;

                case TestType.Lipid:
                    testResultRepository = new LipidTestRepository();
                    var lipidTestResult = testResultRepository.GetTestResults(customerId, eventId, isNewResultFlow);
                    if (lipidTestResult != null)
                        testResults.Add(lipidTestResult);
                    break;

                case TestType.AwvLipid:
                    testResultRepository = new AwvLipidTestRepository();
                    var awvLipidTestResult = testResultRepository.GetTestResults(customerId, eventId, isNewResultFlow);
                    if (awvLipidTestResult != null)
                        testResults.Add(awvLipidTestResult);
                    break;

                case TestType.AwvGlucose:
                    testResultRepository = new AwvGlucoseTestRepository();
                    var awvGlucoseTestResult = testResultRepository.GetTestResults(customerId, eventId, isNewResultFlow);
                    if (awvGlucoseTestResult != null)
                        testResults.Add(awvGlucoseTestResult);
                    break;

                case TestType.FraminghamRisk:
                    testResultRepository = new FraminghamRiskTestResultRepository();
                    var framinghamRiskTestResult = testResultRepository.GetTestResults(customerId, eventId, isNewResultFlow);
                    if (framinghamRiskTestResult != null && framinghamRiskTestResult.ResultStatus.StateNumber != (int)TestResultStateNumber.NoResults)
                        testResults.Add(framinghamRiskTestResult);
                    break;

                case TestType.PPAAA:
                    testResultRepository = new PpAaaTestRepository();
                    var ppAaaTestResult = testResultRepository.GetTestResults(customerId, eventId, isNewResultFlow);
                    if (ppAaaTestResult != null)
                        testResults.Add(ppAaaTestResult);
                    break;

                case TestType.PPEcho:
                    testResultRepository = new PpEchocardiogramTestRepository();
                    var ppEchoTestResult = testResultRepository.GetTestResults(customerId, eventId, isNewResultFlow);
                    if (ppEchoTestResult != null)
                        testResults.Add(ppEchoTestResult);
                    break;

                case TestType.AWV:
                    testResultRepository = new AwvTestRepository();
                    var awvTestResult = testResultRepository.GetTestResults(customerId, eventId, isNewResultFlow);
                    if (awvTestResult != null) testResults.Add(awvTestResult);
                    break;

                case TestType.Medicare:
                    testResultRepository = new MedicareTestRepository();
                    var medicareTestResult = testResultRepository.GetTestResults(customerId, eventId, isNewResultFlow);
                    if (medicareTestResult != null) testResults.Add(medicareTestResult);
                    break;

                case TestType.AwvSubsequent:
                    testResultRepository = new AwvSubsequentTestRepository();
                    var awvSubsequentTestResult = testResultRepository.GetTestResults(customerId, eventId, isNewResultFlow);
                    if (awvSubsequentTestResult != null) testResults.Add(awvSubsequentTestResult);
                    break;

                case TestType.A1C:
                    testResultRepository = new HemaglobinTestRepository();
                    var a1CTestResult = testResultRepository.GetTestResults(customerId, eventId, isNewResultFlow);
                    if (a1CTestResult != null)
                        testResults.Add(a1CTestResult);
                    break;

                case TestType.AwvHBA1C:
                    testResultRepository = new AwvHemaglobinTestRepository();
                    var awvA1CTestResult = testResultRepository.GetTestResults(customerId, eventId, isNewResultFlow);
                    if (awvA1CTestResult != null)
                        testResults.Add(awvA1CTestResult);
                    break;

                case TestType.Thyroid:
                    testResultRepository = new ThyroidTestRepository();
                    var thyroidTestResult = testResultRepository.GetTestResults(customerId, eventId, isNewResultFlow);
                    if (thyroidTestResult != null)
                        testResults.Add(thyroidTestResult);
                    break;

                case TestType.Psa:
                    testResultRepository = new PsaTestRepository();
                    var psaTestResult = testResultRepository.GetTestResults(customerId, eventId, isNewResultFlow);
                    if (psaTestResult != null)
                        testResults.Add(psaTestResult);
                    break;

                case TestType.Crp:
                    testResultRepository = new CrpTestRepository();
                    var crpTestResult = testResultRepository.GetTestResults(customerId, eventId, isNewResultFlow);
                    if (crpTestResult != null)
                        testResults.Add(crpTestResult);
                    break;

                case TestType.Testosterone:
                    testResultRepository = new TestosteroneTestRepository();
                    var testosteroneTestResult = testResultRepository.GetTestResults(customerId, eventId, isNewResultFlow);
                    if (testosteroneTestResult != null)
                        testResults.Add(testosteroneTestResult);
                    break;

                case TestType.Hearing:
                    testResultRepository = new HearingTestRepository();
                    var hearingTestResult = testResultRepository.GetTestResults(customerId, eventId, isNewResultFlow);
                    if (hearingTestResult != null)
                        testResults.Add(hearingTestResult);
                    break;

                case TestType.Vision:
                    testResultRepository = new VisionTestRepository();
                    var visionTestResult = testResultRepository.GetTestResults(customerId, eventId, isNewResultFlow);
                    if (visionTestResult != null)
                        testResults.Add(visionTestResult);
                    break;

                case TestType.Glaucoma:
                    testResultRepository = new GlaucomaTestRepository();
                    var glaucomaTestResult = testResultRepository.GetTestResults(customerId, eventId, isNewResultFlow);
                    if (glaucomaTestResult != null)
                        testResults.Add(glaucomaTestResult);
                    break;

                case TestType.HCPAAA:
                    testResultRepository = new HcpAaaTestRepository();
                    var hcpAaaTestResult = testResultRepository.GetTestResults(customerId, eventId, isNewResultFlow);
                    if (hcpAaaTestResult != null)
                        testResults.Add(hcpAaaTestResult);
                    break;

                case TestType.HCPCarotid:
                    testResultRepository = new HcpCarotidTestRepository();
                    var hcpCarotidTestResult = testResultRepository.GetTestResults(customerId, eventId, isNewResultFlow);
                    if (hcpCarotidTestResult != null)
                        testResults.Add(hcpCarotidTestResult);
                    break;

                case TestType.HCPEcho:
                    testResultRepository = new HcpEchocardiogramTestRepository();
                    var hcpEchoTestResult = testResultRepository.GetTestResults(customerId, eventId, isNewResultFlow);
                    if (hcpEchoTestResult != null)
                        testResults.Add(hcpEchoTestResult);
                    break;

                case TestType.AwvEcho:
                    testResultRepository = new AwvEchocardiogramTestRepository();
                    var awvEchoTestResult = testResultRepository.GetTestResults(customerId, eventId, isNewResultFlow);
                    if (awvEchoTestResult != null)
                        testResults.Add(awvEchoTestResult);
                    break;

                case TestType.Colorectal:
                case TestType.Kyn:
                case TestType.HKYN:
                    testResultRepository = new TestResultRepository();
                    var testResult = testResultRepository.GetTestResult(customerId, eventId, (int)test.Id, isNewResultFlow);
                    if (testResult != null)
                        testResults.Add(testResult);
                    break;

                case TestType.Cholesterol:
                    testResultRepository = new CholesterolTestRepository();
                    var cholesterolTestResult = testResultRepository.GetTestResults(customerId, eventId, isNewResultFlow);
                    if (cholesterolTestResult != null)
                        testResults.Add(cholesterolTestResult);
                    break;

                case TestType.Diabetes:
                    testResultRepository = new DiabetesTestRepository();
                    var diabetesTestResult = testResultRepository.GetTestResults(customerId, eventId, isNewResultFlow);
                    if (diabetesTestResult != null)
                        testResults.Add(diabetesTestResult);
                    break;

                case TestType.HPylori:
                    testResultRepository = new HPyloriTestRepository();
                    var hPyloriTestResult = testResultRepository.GetTestResults(customerId, eventId, isNewResultFlow);
                    if (hPyloriTestResult != null) testResults.Add(hPyloriTestResult);
                    break;

                case TestType.MenBloodPanel:
                    testResultRepository = new MenBloodPanelTestRepository();
                    var menBloodPanelTestResult = testResultRepository.GetTestResults(customerId, eventId, isNewResultFlow);
                    if (menBloodPanelTestResult != null) testResults.Add(menBloodPanelTestResult);
                    break;

                case TestType.WomenBloodPanel:
                    testResultRepository = new WomenBloodPanelTestRepository();
                    var womenBloodPanelTestResult = testResultRepository.GetTestResults(customerId, eventId, isNewResultFlow);
                    if (womenBloodPanelTestResult != null) testResults.Add(womenBloodPanelTestResult);
                    break;

                case TestType.VitaminD:
                    testResultRepository = new VitaminDTestRepository();
                    var vitaminDTestResult = testResultRepository.GetTestResults(customerId, eventId, isNewResultFlow);
                    if (vitaminDTestResult != null) testResults.Add(vitaminDTestResult);
                    break;

                case TestType.Hypertension:
                    testResultRepository = new HypertensionTestRepository();
                    var hypertensionTestResult = testResultRepository.GetTestResults(customerId, eventId, isNewResultFlow);
                    if (hypertensionTestResult != null) testResults.Add(hypertensionTestResult);
                    break;

                case TestType.Hemoglobin:
                    testResultRepository = new HemoglobinTestRepository();
                    var hemoglobingTestResult = testResultRepository.GetTestResults(customerId, eventId, isNewResultFlow);
                    if (hemoglobingTestResult != null) testResults.Add(hemoglobingTestResult);
                    break;

                case TestType.DiabeticRetinopathy:
                    testResultRepository = new DiabeticRetinopathyTestRepository();
                    var diabeticRetinopathyTestResult = testResultRepository.GetTestResults(customerId, eventId, isNewResultFlow);
                    if (diabeticRetinopathyTestResult != null) testResults.Add(diabeticRetinopathyTestResult);
                    break;

                case TestType.eAWV:
                    testResultRepository = new EAwvTestRepository();
                    var eawvTestResult = testResultRepository.GetTestResults(customerId, eventId, isNewResultFlow);
                    if (eawvTestResult != null) testResults.Add(eawvTestResult);
                    break;

                case TestType.DiabetesFootExam:
                    testResultRepository = new DiabetesFootExamTestRepository();
                    var diabetesFootExamTestResult = testResultRepository.GetTestResults(customerId, eventId, isNewResultFlow);
                    if (diabetesFootExamTestResult != null) testResults.Add(diabetesFootExamTestResult);
                    break;

                case TestType.RinneWeberHearing:
                    testResultRepository = new RinneWeberHearingTestRepository();
                    var rinneWeberHearingTestResult = testResultRepository.GetTestResults(customerId, eventId, isNewResultFlow);
                    if (rinneWeberHearingTestResult != null) testResults.Add(rinneWeberHearingTestResult);
                    break;

                case TestType.Monofilament:
                    testResultRepository = new MonofilamentTestRepository();
                    var monofilamentTestResult = testResultRepository.GetTestResults(customerId, eventId, isNewResultFlow);
                    if (monofilamentTestResult != null) testResults.Add(monofilamentTestResult);
                    break;

                case TestType.DiabeticNeuropathy:
                    testResultRepository = new DiabeticNeuropathyTestRepository();
                    var diabeticNeuropathyTestResult = testResultRepository.GetTestResults(customerId, eventId, isNewResultFlow);
                    if (diabeticNeuropathyTestResult != null) testResults.Add(diabeticNeuropathyTestResult);
                    break;

                case TestType.FloChecABI:
                    testResultRepository = new FloChecABITestRepository();
                    var floChecAbiTestResult = testResultRepository.GetTestResults(customerId, eventId, isNewResultFlow);
                    if (floChecAbiTestResult != null) testResults.Add(floChecAbiTestResult);
                    break;

                case TestType.IFOBT:
                    testResultRepository = new IFOBTTestRepository();
                    var iFOBTTestResult = testResultRepository.GetTestResults(customerId, eventId, isNewResultFlow);
                    if (iFOBTTestResult != null) testResults.Add(iFOBTTestResult);
                    break;

                case TestType.QualityMeasures:
                    testResultRepository = new QualityMeasuresTestRepository();
                    var qualityMeasuresTestResult = testResultRepository.GetTestResults(customerId, eventId, isNewResultFlow);
                    if (qualityMeasuresTestResult != null) testResults.Add(qualityMeasuresTestResult);
                    break;

                case TestType.PHQ9:
                    testResultRepository = new Phq9TestRepository();
                    var phq9TestResult = testResultRepository.GetTestResults(customerId, eventId, isNewResultFlow);
                    if (phq9TestResult != null) testResults.Add(phq9TestResult);
                    break;

                case TestType.FocAttestation:
                    testResultRepository = new FocAttestationTestRepository();
                    var focAttestationTestResult = testResultRepository.GetTestResults(customerId, eventId, isNewResultFlow);
                    if (focAttestationTestResult != null) testResults.Add(focAttestationTestResult);
                    break;

                case TestType.Mammogram:
                    testResultRepository = new MammogramTestRepository();
                    var mammogramTestResult = testResultRepository.GetTestResults(customerId, eventId, isNewResultFlow);
                    if (mammogramTestResult != null) testResults.Add(mammogramTestResult);
                    break;

                case TestType.UrineMicroalbumin:
                    testResultRepository = new UrineMicroalbuminTestRepository();
                    var urineMicroalbuminTestResult = testResultRepository.GetTestResults(customerId, eventId, isNewResultFlow);
                    if (urineMicroalbuminTestResult != null) testResults.Add(urineMicroalbuminTestResult);
                    break;

                case TestType.FluShot:
                    testResultRepository = new FluShotTestRepository();
                    var fluShotTestResult = testResultRepository.GetTestResults(customerId, eventId, isNewResultFlow);
                    if (fluShotTestResult != null) testResults.Add(fluShotTestResult);
                    break;

                case TestType.AwvFluShot:
                    testResultRepository = new AwvFluShotTestRepository();
                    var awvFluShotTestResult = testResultRepository.GetTestResults(customerId, eventId, isNewResultFlow);
                    if (awvFluShotTestResult != null) testResults.Add(awvFluShotTestResult);
                    break;

                case TestType.Pneumococcal:
                    testResultRepository = new PneumococcalTestRepository();
                    var pneumococcalTestResult = testResultRepository.GetTestResults(customerId, eventId, isNewResultFlow);
                    if (pneumococcalTestResult != null) testResults.Add(pneumococcalTestResult);
                    break;

                case TestType.Chlamydia:
                    testResultRepository = new ChlamydiaTestRepository();
                    var chlamydiaTestResult = testResultRepository.GetTestResults(customerId, eventId, isNewResultFlow);
                    if (chlamydiaTestResult != null) testResults.Add(chlamydiaTestResult);
                    break;
                case TestType.QuantaFloABI:
                    testResultRepository = new QuantaFloABITestRepository();
                    var quantaFloABITestResult = testResultRepository.GetTestResults(customerId, eventId, isNewResultFlow);
                    if (quantaFloABITestResult != null) testResults.Add(quantaFloABITestResult);
                    break;

                case TestType.DPN:
                    testResultRepository = new DpnTestRepository();
                    var dpnTestResult = testResultRepository.GetTestResults(customerId, eventId, isNewResultFlow);
                    if (dpnTestResult != null) testResults.Add(dpnTestResult);
                    break;

                case TestType.MyBioCheckAssessment:
                    testResultRepository = new MyBioAssessmentTestRepository();
                    var myBioCheckTestResult = testResultRepository.GetTestResults(customerId, eventId, isNewResultFlow);
                    if (myBioCheckTestResult != null)
                        testResults.Add(myBioCheckTestResult);
                    break;
                case TestType.Foc:
                    testResultRepository = new FocTestRepository();
                    var focTestResult = testResultRepository.GetTestResults(customerId, eventId, isNewResultFlow);
                    if (focTestResult != null)
                        testResults.Add(focTestResult);
                    break;
                case TestType.Cs:
                    testResultRepository = new CsTestRepository();
                    var csTestResult = testResultRepository.GetTestResults(customerId, eventId, isNewResultFlow);
                    if (csTestResult != null)
                        testResults.Add(csTestResult);
                    break;
                case TestType.Qv:
                    testResultRepository = new QvTestRepository();
                    var qvTestResult = testResultRepository.GetTestResults(customerId, eventId, isNewResultFlow);
                    if (qvTestResult != null)
                        testResults.Add(qvTestResult);
                    break;
            }
        }

        return testResults;
    }

    [WebMethod(EnableSession = true)]
    public BasicBiometric GetBasicBiometric(long customerId, long eventId)
    {
        var repository = IoC.Resolve<IBasicBiometricRepository>();
        return repository.Get(eventId, customerId);
    }

    [WebMethod(EnableSession = true)]
    public object SetAllResultswithBasicBiometric(long customerId, long eventId, IEnumerable<string> testResultStrings, BasicBiometric basicBiometric, bool sendToOverreadPhysician, long organizationRoleUserId, int numberOfCriticalTestSaved, bool isPriorityInQueue, string priorityInQueueNote, bool? isFastingStatus, long[] criticalTestIds = null)
    {
        var criticalMailSent = false;
        try
        {
            var filter = new { CustomerId = customerId, EventId = eventId };
            var testResults = DeserializeTestResult(testResultStrings);
            LogFilterListPairAudit(ModelType.Edit, filter, testResults, "App/Franchisee/Technician/AuditResultEntry.aspx", "POST");
            var criticalDataRepository = IoC.Resolve<ICustomerCriticalDataRepository>();

            var sessionContext = IoC.Resolve<ISessionContext>();
            var currentSession = sessionContext.UserSession;
            var account = IoC.Resolve<ICorporateAccountRepository>().GetbyEventId(eventId);

            foreach (var testResult in testResults)
            {
                if (!testResult.ResultStatus.SelfPresent)
                    criticalDataRepository.Delete(customerId, eventId, (long)testResult.TestType);
            }

            var repository = IoC.Resolve<IRepository<BasicBiometric>>();

            var eventCustomer = IoC.Resolve<IEventCustomerRepository>().Get(eventId, customerId);

            if (basicBiometric != null)
            {
                basicBiometric.Id = eventCustomer.Id;
                repository.Save(basicBiometric);
            }
            else
            {
                repository.Delete(new BasicBiometric { Id = eventCustomer.Id });
            }

            var testsFromDbSupplyTests = IoC.Resolve<EventCustomerResultRepository>().GetTestNotPerformedTestsByReason(eventCustomer.Id, (long)TestNotPerformedReasonType.SupplyIssue);
            var testsFromDbEquipmentMalfunction = IoC.Resolve<EventCustomerResultRepository>().GetTestNotPerformedTestsByReason(eventCustomer.Id, (long)TestNotPerformedReasonType.EquipmentMalfunction);

            SetAllResults(customerId, eventId, testResults, organizationRoleUserId);
            var isNewResultFlow = testResults.Any(tr => tr.IsNewResultFlow);
            bool isPreAuditState = false;

            if (isNewResultFlow)
                isPreAuditState = testResults.Any(x => x.ResultStatus.StateNumber == (int)NewTestResultStateNumber.PreAudit);
            else
                isPreAuditState = testResults.Any(x => x.ResultStatus.StateNumber == (int)TestResultStateNumber.PreAudit);

            var eawvTestResult = testResults.FirstOrDefault(x => x.TestType == TestType.eAWV);

            var eventRepository = IoC.Resolve<IEventRepository>();
            var theEvent = eventRepository.GetById(eventId);

            QuestionnaireType questionnaireType = QuestionnaireType.None;
            if (account != null && theEvent != null)
            {
                var accountHraChatQuestionnaireHistoryServices = IoC.Resolve<IAccountHraChatQuestionnaireHistoryServices>();
                questionnaireType = accountHraChatQuestionnaireHistoryServices.QuestionnaireTypeByAccountIdandEventDate(account.Id, theEvent.EventDate);
            }

            if (isNewResultFlow && account != null && account.IsHealthPlan && (questionnaireType == QuestionnaireType.HraQuestionnaire) && eawvTestResult != null)
            {
                if (eawvTestResult.TestNotPerformed != null && eawvTestResult.TestNotPerformed.TestNotPerformedReasonId > 0)
                {
                    IoC.Resolve<IMedicareService>().UpdateMedicareVisitStatus(eventCustomer.Id, (int)MedicareVisitStatus.TestNotPerformed, Session.SessionID, sessionContext);
                }
                else
                {
                    IoC.Resolve<IMedicareService>().UpdateMedicareVisitStatus(eventCustomer.Id, (int)MedicareVisitStatus.Visited, Session.SessionID, sessionContext);
                }
            }

            if (sendToOverreadPhysician)
            {
                ITestResultRepository testResultRepository = new TestResultRepository();
                testResultRepository.SetResultstoState(eventId, customerId, (int)TestResultStateNumber.Evaluated, true, organizationRoleUserId);
                IoC.Resolve<IEventCustomerResultRepository>().SetEventCustomerResultState(eventId, customerId);
            }
            else if (isPreAuditState && isNewResultFlow)
            {
                if (account != null && account.IsHealthPlan && (questionnaireType == QuestionnaireType.HraQuestionnaire) && eawvTestResult != null && (eawvTestResult.TestNotPerformed == null || eawvTestResult.TestNotPerformed.TestNotPerformedReasonId <= 0))
                {
                    var canUnsignModel = new MedicareCanUnsignViewModel
                    {
                        EventId = eventId,
                        HfCustomerId = customerId,
                        CanUnsign = false,
                    };

                    IoC.Resolve<INewResultFlowStateService>().RunTaskSyncHraCanUnsignForVisit(canUnsignModel, organizationRoleUserId, "SetAllResultswithBasicBiometric");
                }
            }

            if (isPriorityInQueue == false && currentSession != null && !currentSession.CurrentOrganizationRole.CheckRole((long)Roles.Technician))
            {
                priorityInQueueNote = "";
            }

            var eventCustomerRetestRepository = IoC.Resolve<IEventCustomerRetestRepository>();

            if (currentSession != null)
            {
                var eventCustomerRetestIds = eventCustomerRetestRepository.GetByEventCustomerId(eventCustomer.Id).Select(x => x.TestId);
                var retestTestIds = testResults.Where(x => x.IsRetest).Select(x => (long)x.TestType);

                if (!eventCustomerRetestIds.IsNullOrEmpty())
                {
                    var markMailSentDateToNull = false;
                    var reTestIdsToDelete = eventCustomerRetestIds.Except(retestTestIds).ToArray();
                    if (reTestIdsToDelete.Any())
                    {
                        eventCustomerRetestRepository.DeleteByEventCustomerIdAndTestIds(eventCustomer.Id, reTestIdsToDelete);
                        markMailSentDateToNull = true;
                    }

                    var reTestIdsToSave = retestTestIds.Except(eventCustomerRetestIds);
                    if (reTestIdsToSave.Any())
                    {
                        eventCustomerRetestRepository.SaveEventCustomerRetest(eventCustomer.Id, reTestIdsToSave.ToArray(), currentSession.CurrentOrganizationRole.OrganizationRoleUserId);
                        markMailSentDateToNull = true;
                    }

                    if (markMailSentDateToNull)
                        eventCustomerRetestRepository.UpdateMailSentDate(eventCustomer.Id, null);
                }
                else if (retestTestIds.Any())
                {
                    eventCustomerRetestRepository.SaveEventCustomerRetest(eventCustomer.Id, retestTestIds.ToArray(), currentSession.CurrentOrganizationRole.OrganizationRoleUserId);
                }


                var eventCustomerRetest = eventCustomerRetestRepository.GetByEventCustomerId(eventCustomer.Id);

                if (eventCustomerRetest.Any(x => x.MailSentDate == null) && isPreAuditState)
                {
                    SendReTestEmailNotification(eventCustomer.CustomerId, eventCustomer.EventId, eventCustomerRetest.Select(x => x.TestId).ToArray());
                    eventCustomerRetestRepository.UpdateMailSentDate(eventCustomer.Id, DateTime.Now);
                }
            }

            var anyTestPriorityInQueue = testResults.Any(tr => tr.ResultStatus.IsPriorityInQueue);
            if (anyTestPriorityInQueue)
                isPriorityInQueue = true;
            var piqEditModel = new PriorityInQueueEditModel()
            {
                EventCustomerResultId = eventCustomer.Id,
                IsPriorityInQueue = isPriorityInQueue,
                Note = priorityInQueueNote
            };
            IoC.Resolve<IPriorityInQueueService>().UpdatePriorityinQueue(piqEditModel, organizationRoleUserId); //updates priority in queue

            var isCritical = (testResults.Select(tr => tr.ResultStatus)).Any(rs => rs.SelfPresent);
            bool isManualEntry = false;


            if (isNewResultFlow)
                isManualEntry = (testResults.Select(tr => tr.ResultStatus)).Any(rs => rs.StateNumber <= (int)NewTestResultStateNumber.ResultEntryCompleted);
            else
                isManualEntry = (testResults.Select(tr => tr.ResultStatus)).Any(rs => rs.StateNumber <= (int)TestResultStateNumber.ManualEntry);

            //if (isCritical && isManualEntry && numberOfCriticalTestSaved > 0)
            //{
            //    CriticalMail(customerId, eventId, organizationRoleUserId);
            //    criticalMailSent = true;
            //}
            UpdateFastingStatus(eventId, customerId, isFastingStatus, organizationRoleUserId);

            TestNotPerformedEmail(customerId, eventId, testResults, testsFromDbSupplyTests, testsFromDbEquipmentMalfunction);

            long[] sendCriticalTestIds = null;

            var criticalTest = Session["CurrentCriticaltestIds"] as long[];

            if (!criticalTest.IsNullOrEmpty())
                sendCriticalTestIds = criticalTestIds.Select(x => x).Except(criticalTest).ToArray();
            else
                sendCriticalTestIds = criticalTestIds.ToArray();

            if (!sendCriticalTestIds.IsNullOrEmpty())
            {
                var resultState = testResults.Select(x => x.ResultStatus.StateNumber).FirstOrDefault();
                SendCriticalTestMail(eventId, customerId, organizationRoleUserId, resultState, 0);
                criticalMailSent = true;
            }
        }
        catch (Exception ex)
        {
            var logger = IoC.Resolve<ILogManager>().GetLogger<Global>();
            logger.Error("Error while Saving Results! Message: " + ex.Message + "\n\t Trace: " + ex.StackTrace);
            throw;
        }
        return new { ResultSaved = true, CriticalMailSent = criticalMailSent };
    }

    private static void CriticalMail(long customerId, long eventId, long organizationRoleUserId, long testId = 0)
    {
        var emailNotificationModelsFactory = IoC.Resolve<IEmailNotificationModelsFactory>();
        var notifier = IoC.Resolve<INotifier>();
        var criticalCustomerNotificationModel = emailNotificationModelsFactory.GetCriticalCustomerNotificationModel(eventId, customerId, testId);

        string[] careCordinatorEmails = null;
        var hospitalPartnerRepository = IoC.Resolve<IHospitalPartnerRepository>();
        var hospitalPartnerId = hospitalPartnerRepository.GetHospitalPartnerIdForEvent(eventId);
        var organizationRoleUserRepository = IoC.Resolve<IOrganizationRoleUserRepository>();
        if (hospitalPartnerId > 0)
        {

            var orgRoleUsers = organizationRoleUserRepository.GetOrganizationRoleUsersByOrganizationId(hospitalPartnerId);
            if (!orgRoleUsers.IsNullOrEmpty())
            {
                var userRepository = IoC.Resolve<IUserRepository<User>>();
                var users = userRepository.GetUsers(orgRoleUsers.Select(oru => oru.UserId).ToList());
                careCordinatorEmails = users.Where(u => u.Email != null && !string.IsNullOrEmpty(u.Email.ToString())).Select(u => u.Email.ToString()).ToArray();
            }
        }

        string[] accountCordinatorEmails = null;
        var _corporateAccountRepository = IoC.Resolve<ICorporateAccountRepository>();
        var corporateAccount = _corporateAccountRepository.GetbyEventId(eventId);

        if (corporateAccount != null)
        {
            var organizationRoleUsers = organizationRoleUserRepository.GetOrganizationRoleUsersByOrganizationId(corporateAccount.Id);
            if (!organizationRoleUsers.IsNullOrEmpty())
            {
                var userIds = new List<long>();
                var _accountCoordinatorProfileRepository = IoC.Resolve<IAccountCoordinatorProfileRepository>();
                var organiztionRoleUserIds = _accountCoordinatorProfileRepository.GetCriticalCoordinator(organizationRoleUsers.Select(m => m.Id).ToArray());
                if (organiztionRoleUserIds != null && organiztionRoleUserIds.Any())
                {
                    userIds = (from orr in organizationRoleUsers
                               where organiztionRoleUserIds.Contains(orr.Id)
                               select orr.UserId).ToList();
                }

                if (userIds != null && userIds.Any())
                {
                    var userRepository = IoC.Resolve<IUserRepository<User>>();
                    var users = userRepository.GetUsers(userIds);
                    accountCordinatorEmails = users.Where(u => u.Email != null && !string.IsNullOrEmpty(u.Email.ToString())).Select(u => u.Email.ToString()).ToArray();

                    if (careCordinatorEmails != null && accountCordinatorEmails != null)
                    {
                        careCordinatorEmails = careCordinatorEmails.Concat(accountCordinatorEmails).ToArray();
                    }
                    else if (accountCordinatorEmails != null)
                    {
                        careCordinatorEmails = accountCordinatorEmails;
                    }
                }
            }
        }
        if (careCordinatorEmails != null && careCordinatorEmails.Any())
        {
            notifier.NotifySubscribersViaEmail(NotificationTypeAlias.CriticalCustomer, EmailTemplateAlias.CriticalCustomer, criticalCustomerNotificationModel, careCordinatorEmails, 0, organizationRoleUserId, "Critical Customer");
        }
        else
        {
            notifier.NotifySubscribersViaEmail(NotificationTypeAlias.CriticalCustomer, EmailTemplateAlias.CriticalCustomer, criticalCustomerNotificationModel, 0, organizationRoleUserId, "Critical Customer");
        }
    }

    private void SaveCriticalData(long eventId, long customerId, string criticalDataString, long organizationRoleUserId, long resultState, string pageUrl)
    {
        var jsSerializer = new JavaScriptSerializer();
        var criticalData = jsSerializer.Deserialize<CustomerEventCriticalTestDataEditModel>(criticalDataString);
        var testResultService = IoC.Resolve<ITestResultService>();
        testResultService.SaveModel(eventId, customerId, criticalData, organizationRoleUserId);
        LogAudit(ModelType.Edit, criticalData, pageUrl + "(Marked Critical)", "POST", customerId);
        if (resultState <= (long)TestResultStateNumber.PreAudit)
            CriticalMail(customerId, eventId, organizationRoleUserId, criticalData.TestId);
    }

    private static void SavePriorityInQueueTestData(long eventId, long customerId, string priorityInqueuetetsDataString, long organizationRoleUserId, long resultState)
    {
        var jsSerializer = new JavaScriptSerializer();
        var priorityInqueuetetsData = jsSerializer.Deserialize<PriorityInQueueTestEditModel>(priorityInqueuetetsDataString);
        var testResultService = IoC.Resolve<ITestResultService>();
        testResultService.SavePriorityInQueueTestEditModel(eventId, customerId, priorityInqueuetetsData.TestId, priorityInqueuetetsData, organizationRoleUserId);
    }

    private static void SetEventCustomerInterpretation(long eventId, long customerId, IEnumerable<TestResult> testResults)
    {
        var eventCustomerResultRepository = IoC.Resolve<IEventCustomerResultRepository>();

        var findingIds = new List<long>();
        foreach (var testResult in testResults)
        {
            switch (testResult.TestType)
            {
                case TestType.AAA:
                    var aaaTestResult = testResult as AAATestResult;
                    if (aaaTestResult != null && aaaTestResult.Finding != null)
                        findingIds.Add(aaaTestResult.Finding.Id);
                    break;

                case TestType.AwvAAA:
                    var awvAaaTestResult = testResult as AwvAaaTestResult;
                    if (awvAaaTestResult != null && awvAaaTestResult.Finding != null)
                        findingIds.Add(awvAaaTestResult.Finding.Id);
                    break;

                case TestType.ASI:
                    var asiTestResult = testResult as ASITestResult;
                    if (asiTestResult != null && asiTestResult.ASI != null && asiTestResult.ASI.Finding != null)
                        findingIds.Add(asiTestResult.ASI.Finding.Id);
                    break;

                case TestType.Stroke:
                    var strokeTestResult = testResult as StrokeTestResult;
                    if (strokeTestResult != null)
                    {
                        if (strokeTestResult.LeftResultReadings != null && strokeTestResult.LeftResultReadings.Finding != null)
                            findingIds.Add(strokeTestResult.LeftResultReadings.Finding.Id);

                        if (strokeTestResult.RightResultReadings != null && strokeTestResult.RightResultReadings.Finding != null)
                            findingIds.Add(strokeTestResult.RightResultReadings.Finding.Id);

                        if (strokeTestResult.LowVelocityLica != null && strokeTestResult.LowVelocityLica.Id > 0)
                            findingIds.Add(strokeTestResult.LowVelocityLica.Id);

                        if (strokeTestResult.LowVelocityRica != null && strokeTestResult.LowVelocityRica.Id > 0)
                            findingIds.Add(strokeTestResult.LowVelocityRica.Id);
                    }
                    break;

                case TestType.AwvCarotid:
                    var awvCarotidTestResult = testResult as AwvCarotidTestResult;
                    if (awvCarotidTestResult != null)
                    {
                        if (awvCarotidTestResult.LeftResultReadings != null && awvCarotidTestResult.LeftResultReadings.Finding != null)
                            findingIds.Add(awvCarotidTestResult.LeftResultReadings.Finding.Id);

                        if (awvCarotidTestResult.RightResultReadings != null && awvCarotidTestResult.RightResultReadings.Finding != null)
                            findingIds.Add(awvCarotidTestResult.RightResultReadings.Finding.Id);

                        if (awvCarotidTestResult.LowVelocityLica != null && awvCarotidTestResult.LowVelocityLica.Id > 0)
                            findingIds.Add(awvCarotidTestResult.LowVelocityLica.Id);

                        if (awvCarotidTestResult.LowVelocityRica != null && awvCarotidTestResult.LowVelocityRica.Id > 0)
                            findingIds.Add(awvCarotidTestResult.LowVelocityRica.Id);
                    }
                    break;

                case TestType.Lead:
                    var leadTestResult = testResult as LeadTestResult;
                    if (leadTestResult != null)
                    {
                        if (leadTestResult.LeftResultReadings != null && leadTestResult.LeftResultReadings.Finding != null)
                            findingIds.Add(leadTestResult.LeftResultReadings.Finding.Id);

                        if (leadTestResult.RightResultReadings != null && leadTestResult.RightResultReadings.Finding != null)
                            findingIds.Add(leadTestResult.RightResultReadings.Finding.Id);

                        if (leadTestResult.LowVelocityLeft != null && leadTestResult.LowVelocityLeft.Id > 0)
                            findingIds.Add(leadTestResult.LowVelocityLeft.Id);

                        if (leadTestResult.LowVelocityRight != null && leadTestResult.LowVelocityRight.Id > 0)
                            findingIds.Add(leadTestResult.LowVelocityRight.Id);
                    }
                    break;

                case TestType.PAD:
                    var padTestResult = testResult as PADTestResult;
                    if (padTestResult != null && padTestResult.Finding != null)
                        findingIds.Add(padTestResult.Finding.Id);
                    break;

                case TestType.AwvABI:
                    var awvAbiTestResult = testResult as AwvAbiTestResult;
                    if (awvAbiTestResult != null && awvAbiTestResult.Finding != null)
                        findingIds.Add(awvAbiTestResult.Finding.Id);
                    break;

                case TestType.EKG:
                    var ekgTestResult = testResult as EKGTestResult;
                    if (ekgTestResult != null && ekgTestResult.Finding != null)
                        findingIds.Add(ekgTestResult.Finding.Id);
                    break;

                case TestType.AwvEkg:
                    var awvEkgTestResult = testResult as AwvEkgTestResult;
                    if (awvEkgTestResult != null && awvEkgTestResult.Finding != null)
                        findingIds.Add(awvEkgTestResult.Finding.Id);
                    break;

                case TestType.AwvEkgIPPE:
                    var awvEkgIppeTestResult = testResult as AwvEkgIppeTestResult;
                    if (awvEkgIppeTestResult != null && awvEkgIppeTestResult.Finding != null)
                        findingIds.Add(awvEkgIppeTestResult.Finding.Id);
                    break;

                case TestType.Echocardiogram:
                    var echoTestResult = testResult as EchocardiogramTestResult;
                    if (echoTestResult != null && echoTestResult.Finding != null)
                        findingIds.Add(echoTestResult.Finding.Id);
                    break;

                case TestType.Lipid:
                    var lipidTestResult = testResult as LipidTestResult;
                    if (lipidTestResult != null)
                    {
                        if (lipidTestResult.TotalCholestrol != null && lipidTestResult.TotalCholestrol.Finding != null) findingIds.Add(lipidTestResult.TotalCholestrol.Finding.Id);
                        if (lipidTestResult.Glucose != null && lipidTestResult.Glucose.Finding != null) findingIds.Add(lipidTestResult.Glucose.Finding.Id);
                        if (lipidTestResult.TriGlycerides != null && lipidTestResult.TriGlycerides.Finding != null) findingIds.Add(lipidTestResult.TriGlycerides.Finding.Id);
                        if (lipidTestResult.TCHDLRatio != null && lipidTestResult.TCHDLRatio.Finding != null) findingIds.Add(lipidTestResult.TCHDLRatio.Finding.Id);
                        if (lipidTestResult.LDL != null && lipidTestResult.LDL.Finding != null) findingIds.Add(lipidTestResult.LDL.Finding.Id);
                        if (lipidTestResult.HDL != null && lipidTestResult.HDL.Finding != null) findingIds.Add(lipidTestResult.HDL.Finding.Id);
                    }
                    break;

                case TestType.AwvLipid:
                    var awvLipidTestResult = testResult as AwvLipidTestResult;
                    if (awvLipidTestResult != null)
                    {
                        if (awvLipidTestResult.TotalCholestrol != null && awvLipidTestResult.TotalCholestrol.Finding != null) findingIds.Add(awvLipidTestResult.TotalCholestrol.Finding.Id);
                        if (awvLipidTestResult.TriGlycerides != null && awvLipidTestResult.TriGlycerides.Finding != null) findingIds.Add(awvLipidTestResult.TriGlycerides.Finding.Id);
                        if (awvLipidTestResult.TCHDLRatio != null && awvLipidTestResult.TCHDLRatio.Finding != null) findingIds.Add(awvLipidTestResult.TCHDLRatio.Finding.Id);
                        if (awvLipidTestResult.LDL != null && awvLipidTestResult.LDL.Finding != null) findingIds.Add(awvLipidTestResult.LDL.Finding.Id);
                        if (awvLipidTestResult.HDL != null && awvLipidTestResult.HDL.Finding != null) findingIds.Add(awvLipidTestResult.HDL.Finding.Id);
                    }
                    break;

                case TestType.AwvGlucose:
                    var awvGlucoseTestResult = testResult as AwvGlucoseTestResult;
                    if (awvGlucoseTestResult != null)
                    {
                        if (awvGlucoseTestResult.Glucose != null && awvGlucoseTestResult.Glucose.Finding != null) findingIds.Add(awvGlucoseTestResult.Glucose.Finding.Id);
                    }
                    break;

                case TestType.IMT:
                    var imtTestResult = testResult as ImtTestResult;
                    if (imtTestResult != null && imtTestResult.Finding != null)
                        findingIds.Add(imtTestResult.Finding.Id);
                    break;

                case TestType.Osteoporosis:
                    var osteoTestResult = testResult as OsteoporosisTestResult;
                    if (osteoTestResult != null && osteoTestResult.EstimatedTScore != null && osteoTestResult.EstimatedTScore.Finding != null)
                        findingIds.Add(osteoTestResult.EstimatedTScore.Finding.Id);
                    break;

                case TestType.AwvBoneMass:
                    var awvBoneMassTestResult = testResult as AwvBoneMassTestResult;
                    if (awvBoneMassTestResult != null && awvBoneMassTestResult.EstimatedTScore != null && awvBoneMassTestResult.EstimatedTScore.Finding != null)
                        findingIds.Add(awvBoneMassTestResult.EstimatedTScore.Finding.Id);
                    break;

                case TestType.Spiro:
                    var spiroTestResult = testResult as SpiroTestResult;
                    if (spiroTestResult != null && spiroTestResult.Finding != null)
                        findingIds.Add(spiroTestResult.Finding.Id);
                    break;

                case TestType.AwvSpiro:
                    var awvSpiroTestResult = testResult as AwvSpiroTestResult;
                    if (awvSpiroTestResult != null && awvSpiroTestResult.Finding != null)
                        findingIds.Add(awvSpiroTestResult.Finding.Id);
                    break;

                case TestType.PPAAA:
                    var ppAaaTestResult = testResult as PpAaaTestResult;
                    if (ppAaaTestResult != null && ppAaaTestResult.Finding != null)
                        findingIds.Add(ppAaaTestResult.Finding.Id);
                    break;

                case TestType.PPEcho:
                    var ppEchoTestResult = testResult as PpEchocardiogramTestResult;
                    if (ppEchoTestResult != null && ppEchoTestResult.Finding != null)
                        findingIds.Add(ppEchoTestResult.Finding.Id);
                    break;

                case TestType.AWV:
                    var awvTestResult = testResult as AwvTestResult;
                    if (awvTestResult != null && awvTestResult.Finding != null)
                        findingIds.Add(awvTestResult.Finding.Id);
                    break;

                case TestType.Medicare:
                    var medicareTestResult = testResult as MedicareTestResult;
                    if (medicareTestResult != null && medicareTestResult.Finding != null)
                        findingIds.Add(medicareTestResult.Finding.Id);
                    break;

                case TestType.AwvSubsequent:
                    var awvSubsequentTestResult = testResult as MedicareTestResult;
                    if (awvSubsequentTestResult != null && awvSubsequentTestResult.Finding != null)
                        findingIds.Add(awvSubsequentTestResult.Finding.Id);
                    break;

                case TestType.HCPAAA:
                    var hcpAaaTestResult = testResult as HcpAaaTestResult;
                    if (hcpAaaTestResult != null && hcpAaaTestResult.Finding != null)
                        findingIds.Add(hcpAaaTestResult.Finding.Id);
                    break;

                case TestType.HCPCarotid:
                    var hcpCarotidTestResult = testResult as HcpCarotidTestResult;
                    if (hcpCarotidTestResult != null)
                    {
                        if (hcpCarotidTestResult.LeftResultReadings != null && hcpCarotidTestResult.LeftResultReadings.Finding != null)
                            findingIds.Add(hcpCarotidTestResult.LeftResultReadings.Finding.Id);

                        if (hcpCarotidTestResult.RightResultReadings != null && hcpCarotidTestResult.RightResultReadings.Finding != null)
                            findingIds.Add(hcpCarotidTestResult.RightResultReadings.Finding.Id);

                        if (hcpCarotidTestResult.LowVelocityLica != null && hcpCarotidTestResult.LowVelocityLica.Id > 0)
                            findingIds.Add(hcpCarotidTestResult.LowVelocityLica.Id);

                        if (hcpCarotidTestResult.LowVelocityRica != null && hcpCarotidTestResult.LowVelocityRica.Id > 0)
                            findingIds.Add(hcpCarotidTestResult.LowVelocityRica.Id);
                    }
                    break;

                case TestType.HCPEcho:
                    var hcpEchoTestResult = testResult as HcpEchocardiogramTestResult;
                    if (hcpEchoTestResult != null && hcpEchoTestResult.Finding != null)
                        findingIds.Add(hcpEchoTestResult.Finding.Id);
                    break;

                case TestType.AwvEcho:
                    var awvEchoTestResult = testResult as AwvEchocardiogramTestResult;
                    if (awvEchoTestResult != null && awvEchoTestResult.Finding != null)
                        findingIds.Add(awvEchoTestResult.Finding.Id);
                    break;

                case TestType.Cholesterol:
                    var cholesterolTestResult = testResult as CholesterolTestResult;
                    if (cholesterolTestResult != null)
                    {
                        if (cholesterolTestResult.TotalCholesterol != null && cholesterolTestResult.TotalCholesterol.Finding != null) findingIds.Add(cholesterolTestResult.TotalCholesterol.Finding.Id);
                        if (cholesterolTestResult.TriGlycerides != null && cholesterolTestResult.TriGlycerides.Finding != null) findingIds.Add(cholesterolTestResult.TriGlycerides.Finding.Id);
                        if (cholesterolTestResult.TCHDLRatio != null && cholesterolTestResult.TCHDLRatio.Finding != null) findingIds.Add(cholesterolTestResult.TCHDLRatio.Finding.Id);
                        if (cholesterolTestResult.LDL != null && cholesterolTestResult.LDL.Finding != null) findingIds.Add(cholesterolTestResult.LDL.Finding.Id);
                        if (cholesterolTestResult.HDL != null && cholesterolTestResult.HDL.Finding != null) findingIds.Add(cholesterolTestResult.HDL.Finding.Id);
                    }
                    break;

                case TestType.Diabetes:
                    var diabetesTestResult = testResult as DiabetesTestResult;
                    if (diabetesTestResult != null)
                    {
                        if (diabetesTestResult.Glucose != null && diabetesTestResult.Glucose.Finding != null) findingIds.Add(diabetesTestResult.Glucose.Finding.Id);
                    }
                    break;

                case TestType.HPylori:
                    var hPyloriTestResult = testResult as HPyloriTestResult;
                    if (hPyloriTestResult != null && hPyloriTestResult.Finding != null)
                        findingIds.Add(hPyloriTestResult.Finding.Id);
                    break;

                case TestType.Hemoglobin:
                    var hemoglobinTestResult = testResult as HemoglobinTestResult;
                    if (hemoglobinTestResult != null && hemoglobinTestResult.Hemoglobin != null)
                        findingIds.Add(hemoglobinTestResult.Hemoglobin.Finding.Id);
                    break;

                case TestType.DiabeticRetinopathy:
                    var diabeticRetinopathyTestResult = testResult as DiabeticRetinopathyTestResult;
                    if (diabeticRetinopathyTestResult != null && diabeticRetinopathyTestResult.Finding != null)
                        findingIds.Add(diabeticRetinopathyTestResult.Finding.Id);
                    break;

                case TestType.eAWV:
                    var eawvTestResult = testResult as EAwvTestResult;
                    if (eawvTestResult != null && eawvTestResult.Finding != null)
                        findingIds.Add(eawvTestResult.Finding.Id);
                    break;

                case TestType.DiabeticNeuropathy:
                    var diabeticNeuropathyTestResult = testResult as DiabeticNeuropathyTestResult;
                    if (diabeticNeuropathyTestResult != null && diabeticNeuropathyTestResult.Finding != null)
                        findingIds.Add(diabeticNeuropathyTestResult.Finding.Id);
                    break;

                case TestType.FloChecABI:
                    var floChecABITestResult = testResult as FloChecABITestResult;
                    if (floChecABITestResult != null && floChecABITestResult.Finding != null)
                        findingIds.Add(floChecABITestResult.Finding.Id);
                    break;

                case TestType.IFOBT:
                    var iFOBTTestResult = testResult as IFOBTTestResult;
                    if (iFOBTTestResult != null && iFOBTTestResult.Finding != null)
                        findingIds.Add(iFOBTTestResult.Finding.Id);
                    break;
                case TestType.QualityMeasures:
                    var qualityMeasuresTestResult = testResult as QualityMeasuresTestResult;
                    if (qualityMeasuresTestResult != null && qualityMeasuresTestResult.PainAssessmentScore != null) findingIds.Add(qualityMeasuresTestResult.PainAssessmentScore.Id);
                    if (qualityMeasuresTestResult != null && qualityMeasuresTestResult.FunctionalAssessmentScore != null) findingIds.Add(qualityMeasuresTestResult.FunctionalAssessmentScore.Id);
                    break;
                case TestType.UrineMicroalbumin:
                    var urineMicroalbuminTestResult = testResult as UrineMicroalbuminTestResult;
                    if (urineMicroalbuminTestResult != null && urineMicroalbuminTestResult.Finding != null)
                        findingIds.Add(urineMicroalbuminTestResult.Finding.Id);
                    break;

                case TestType.Mammogram:
                    var mammogramTestResult = testResult as MammogramTestResult;
                    if (mammogramTestResult != null && mammogramTestResult.Finding != null)
                        findingIds.Add(mammogramTestResult.Finding.Id);
                    break;

                case TestType.Chlamydia:
                    var chlamydiaTestResult = testResult as ChlamydiaTestResult;
                    if (chlamydiaTestResult != null && chlamydiaTestResult.Finding != null)
                        findingIds.Add(chlamydiaTestResult.Finding.Id);
                    break;
                case TestType.QuantaFloABI:
                    var quantaFloABITestResult = testResult as QuantaFloABITestResult;
                    if (quantaFloABITestResult != null && quantaFloABITestResult.Finding != null)
                        findingIds.Add(quantaFloABITestResult.Finding.Id);
                    break;

                case TestType.DPN:
                    var dpnTestResult = testResult as DpnTestResult;
                    if (dpnTestResult != null && dpnTestResult.Finding != null)
                        findingIds.Add(dpnTestResult.Finding.Id);
                    break;

                case TestType.MyBioCheckAssessment:
                    var myBioAssessmentTestResult = testResult as MyBioAssessmentTestResult;
                    if (myBioAssessmentTestResult != null)
                    {
                        if (myBioAssessmentTestResult.TotalCholestrol != null && myBioAssessmentTestResult.TotalCholestrol.Finding != null) findingIds.Add(myBioAssessmentTestResult.TotalCholestrol.Finding.Id);
                        if (myBioAssessmentTestResult.Glucose != null && myBioAssessmentTestResult.Glucose.Finding != null) findingIds.Add(myBioAssessmentTestResult.Glucose.Finding.Id);
                        if (myBioAssessmentTestResult.TriGlycerides != null && myBioAssessmentTestResult.TriGlycerides.Finding != null) findingIds.Add(myBioAssessmentTestResult.TriGlycerides.Finding.Id);
                        if (myBioAssessmentTestResult.TcHdlRatio != null && myBioAssessmentTestResult.TcHdlRatio.Finding != null) findingIds.Add(myBioAssessmentTestResult.TcHdlRatio.Finding.Id);
                        if (myBioAssessmentTestResult.Ldl != null && myBioAssessmentTestResult.Ldl.Finding != null) findingIds.Add(myBioAssessmentTestResult.Ldl.Finding.Id);
                        if (myBioAssessmentTestResult.Hdl != null && myBioAssessmentTestResult.Hdl.Finding != null) findingIds.Add(myBioAssessmentTestResult.Hdl.Finding.Id);
                    }
                    break;
                //case TestType.Foc:
                //    var focTestResult = testResult as FocTestResult;
                //    if (focTestResult != null && focTestResult.Finding != null)
                //        findingIds.Add(focTestResult.Finding.Id);
                //    break;
            }
        }

        if (findingIds.Count < 1) return;

        var standardFindingRepository = IoC.Resolve<IStandardFindingRepository>();
        var findings = standardFindingRepository.GetByIds<int>(findingIds);

        long? resultInterpretation;

        bool isCritical = testResults.Where(tr => tr.PhysicianInterpretation != null && tr.PhysicianInterpretation.IsCritical && tr.ResultStatus.SelfPresent).Count() > 0;
        if (isCritical)
        {
            resultInterpretation = (long)ResultInterpretation.Critical;
        }
        else
        {
            var resultInterpretationsfromFindings = findings.Where(f => f.ResultInterpretation != null).Select(f => f.ResultInterpretation.Value).ToArray();

            var resIntFromFindings = ResultInterpretation.Normal.GetMax(resultInterpretationsfromFindings);

            if (resIntFromFindings == (long)ResultInterpretation.Critical)
                resultInterpretation = resIntFromFindings;
            else if (testResults.Any(tr => tr.PhysicianInterpretation != null && tr.PhysicianInterpretation.IsCritical && !tr.ResultStatus.SelfPresent))
                resultInterpretation = (long)ResultInterpretation.Urgent;
            else
                resultInterpretation = resIntFromFindings;
        }

        var pathwayRecommendationsfromFindings = findings.Where(f => f.PathwayRecommendation != null).Select(f => f.PathwayRecommendation.Value).ToArray();
        var pathwayRecommendationfromFindings = PathwayRecommendation.None.GetMax(pathwayRecommendationsfromFindings);

        eventCustomerResultRepository.SetEventCustomerResultInterpPathwayRecomendation(eventId, customerId, resultInterpretation, pathwayRecommendationfromFindings);
    }

    private static void TestNotPerformedEmail(long customerId, long eventId, IEnumerable<TestResult> testResults, IEnumerable<OrderedPair<long, long>> testsFromDbSupplyTests, IEnumerable<OrderedPair<long, long>> testsFromDbEquipmentMalfunction)
    {
        try
        {
            var logger = IoC.Resolve<ILogManager>().GetLogger<Global>();
            var supplyIssueTests = testResults.Where(x => x.TestNotPerformed != null && x.TestNotPerformed.TestNotPerformedReasonId == (long)TestNotPerformedReasonType.SupplyIssue).Select(x => x);
            var equipmentMalfunction = testResults.Where(x => x.TestNotPerformed != null && x.TestNotPerformed.TestNotPerformedReasonId == (long)TestNotPerformedReasonType.EquipmentMalfunction).Select(x => x);

            var isSupplyIssue = supplyIssueTests.Any();
            var isEquipmentMalfunction = equipmentMalfunction.Any();
            var notifier = IoC.Resolve<INotifier>();

            if (isSupplyIssue || isEquipmentMalfunction)
            {
                var orgRoleuserRepository = IoC.Resolve<IOrganizationRoleUserRepository>();
                var allTests = IoC.Resolve<TestRepository>().GetAll();
                var nameIdPairOrgRoleUser = orgRoleuserRepository.GetNameIdPairofUsers(testResults.Select(x => x.ConductedByOrgRoleUserId).Distinct().ToArray());
                var sessionContext = IoC.Resolve<ISessionContext>();

                if (isSupplyIssue)
                {
                    try
                    {
                        logger.Info(Environment.NewLine + "Processing email for CustomerId: " + customerId + " EventId: " + eventId + " for Supply Issue");
                        var emailViewModel = SupplyIssueEmailNotificationViewModel(supplyIssueTests, testsFromDbSupplyTests, allTests, nameIdPairOrgRoleUser, customerId, eventId);
                        if (emailViewModel != null)
                            notifier.NotifySubscribersViaEmail(NotificationTypeAlias.TestNotPerformedSupplyIssue, EmailTemplateAlias.TestNotPerformedSupplyIssueEmail, emailViewModel, 0, sessionContext.UserSession.CurrentOrganizationRole.OrganizationRoleUserId, "Test not performed Supply Issue");
                    }
                    catch (Exception ex)
                    {
                        logger.Error("Cannot process Supply Issue email TestNotPerformed for CustomerId: " + customerId + " EventId: " + eventId + "\nException Message: " + ex.Message + "\n\tStackTrace: " + ex.StackTrace);
                    }
                }
                if (isEquipmentMalfunction)
                {
                    try
                    {
                        logger.Info(Environment.NewLine + "Processing email for CustomerId: " + customerId + " EventId: " + eventId + " for Equipment Malfunction");
                        var emailViewModel = EquipmentMalfunctionEmailNotificationViewModel(equipmentMalfunction, testsFromDbEquipmentMalfunction, allTests, nameIdPairOrgRoleUser, customerId, eventId);
                        if (emailViewModel != null)
                            notifier.NotifySubscribersViaEmail(NotificationTypeAlias.TestNotPerformedEquipmentMalfunction, EmailTemplateAlias.TestNotPerformedEquiMalfunctionEmail, emailViewModel, 0, sessionContext.UserSession.CurrentOrganizationRole.OrganizationRoleUserId, "Test not performed Equipment Malfunction");
                    }
                    catch (Exception ex)
                    {
                        logger.Error("Cannot process Equipment Malfunction email TestNotPerformed for CustomerId: " + customerId + " EventId: " + eventId + "\nException Message: " + ex.Message + "\n\tStackTrace: " + ex.StackTrace);
                    }
                }
            }
        }
        catch (Exception ex)
        {
            var logger = IoC.Resolve<ILogManager>().GetLogger<Global>();
            logger.Error("Error while processing email for TestNotPerformed\nCustomerId:  " + customerId + " EventId: " + eventId + "\nExceptionMessage: " + ex.Message + "\n\tStack Trace: " + ex.StackTrace);
        }
    }

    private static TestNotPerformedEmailNotificationViewModel SupplyIssueEmailNotificationViewModel(IEnumerable<TestResult> supplyIssueTests,
        IEnumerable<OrderedPair<long, long>> resultsBeforeSave, IEnumerable<Test> allTests, IEnumerable<OrderedPair<long, string>> nameIdPairOrgRoleUsers, long customerId, long eventId)
    {
        if (supplyIssueTests.Select(x => (long)x.TestType).Except(resultsBeforeSave.Select(x => x.SecondValue)).Any() ||
            resultsBeforeSave.Select(x => x.SecondValue).Except(supplyIssueTests.Select(x => (long)x.TestType)).Any())
        {
            var emailNotificationModelsFactory = IoC.Resolve<IEmailNotificationModelsFactory>();
            var testNameCreatedByPairs = (from test in supplyIssueTests
                                          let testObject = allTests.FirstOrDefault(x => x.Id == (long)test.TestType)
                                          let nameIdPairOrgRoleUser = nameIdPairOrgRoleUsers.FirstOrDefault(x => x.FirstValue == test.ConductedByOrgRoleUserId)
                                          select new TestNotPerformedNotificationTestViewModel
                                          {
                                              TestName = testObject == null ? "N/A" : testObject.Name,
                                              ConductedBy = nameIdPairOrgRoleUser == null ? "N/A" : nameIdPairOrgRoleUser.SecondValue,
                                              Notes = string.IsNullOrEmpty(test.TestNotPerformed.Notes) ? "N/A" : test.TestNotPerformed.Notes
                                          }).ToList();

            return emailNotificationModelsFactory.GetTestNotPerformedEmailNotificationViewModel(customerId, eventId, TestNotPerformedReasonType.SupplyIssue.GetDescription(), testNameCreatedByPairs);
        }
        return null;
    }

    private static TestNotPerformedEmailNotificationViewModel EquipmentMalfunctionEmailNotificationViewModel(IEnumerable<TestResult> equipmentMalfunction,
        IEnumerable<OrderedPair<long, long>> resultsBeforeSave, IEnumerable<Test> allTests, IEnumerable<OrderedPair<long, string>> nameIdPairOrgRoleUsers, long customerId, long eventId)
    {
        if (equipmentMalfunction.Select(x => (long)x.TestType).Except(resultsBeforeSave.Select(x => x.SecondValue)).Any() ||
            resultsBeforeSave.Select(x => x.SecondValue).Except(equipmentMalfunction.Select(x => (long)x.TestType)).Any())
        {
            var emailNotificationModelsFactory = IoC.Resolve<IEmailNotificationModelsFactory>();
            var testNameCreatedByPairs = (from test in equipmentMalfunction
                                          let testObject = allTests.FirstOrDefault(x => x.Id == (long)test.TestType)
                                          let nameIdPairOrgRoleUser = nameIdPairOrgRoleUsers.FirstOrDefault(x => x.FirstValue == test.ConductedByOrgRoleUserId)
                                          select new TestNotPerformedNotificationTestViewModel
                                          {
                                              TestName = testObject == null ? "N/A" : testObject.Name,
                                              ConductedBy = nameIdPairOrgRoleUser == null ? "N/A" : nameIdPairOrgRoleUser.SecondValue,
                                              Notes = string.IsNullOrEmpty(test.TestNotPerformed.Notes) ? "N/A" : test.TestNotPerformed.Notes
                                          }).ToList();

            return emailNotificationModelsFactory.GetTestNotPerformedEmailNotificationViewModel(customerId, eventId, TestNotPerformedReasonType.EquipmentMalfunction.GetDescription(), testNameCreatedByPairs);
        }
        return null;
    }

    [WebMethod(EnableSession = true)]
    public TestResult SetTestResult(long customerId, long eventId, string testResultString, string criticalDataString, long organizationRoleUserId, long resultState, string pageUrl)
    {
        var testResultStrings = new[] { testResultString };
        var testResults = DeserializeTestResult(testResultStrings);

        if (testResults == null || testResults.Count() < 1) return null;

        var testResult = testResults.First();

        if (testResult.IsNewResultFlow)
        {
            testResult.ResultStatus.StateNumber = (int)NewTestResultStateNumber.ResultEntryPartial;
        }
        else
        {
            testResult.ResultStatus.StateNumber = (int)TestResultStateNumber.ManualEntry;
        }

        SetAllResults(customerId, eventId, testResults, organizationRoleUserId);

        if (!string.IsNullOrEmpty(criticalDataString))
            SaveCriticalData(eventId, customerId, criticalDataString, organizationRoleUserId, resultState, pageUrl);

        var testType = testResult.TestType;
        TestResultRepository testResultRepository = null;
        switch (testType)
        {
            case TestType.ASI:
                testResultRepository = new ASITestRepository();
                break;

            case TestType.AAA:
                testResultRepository = new AAATestRepository();
                break;

            case TestType.AwvAAA:
                testResultRepository = new AwvAaaTestRepository();
                break;

            case TestType.Stroke:
                testResultRepository = new StrokeTestRepository();
                break;

            case TestType.AwvCarotid:
                testResultRepository = new AwvCarotidTestRepository();
                break;

            case TestType.Lead:
                testResultRepository = new LeadTestRepository();
                break;

            case TestType.PAD:
                testResultRepository = new PadTestRepository();
                break;

            case TestType.AwvABI:
                testResultRepository = new AwvAbiTestRepository();
                break;

            case TestType.IMT:
                testResultRepository = new ImtTestRepository();
                break;

            case TestType.EKG:
                testResultRepository = new EKGTestRepository();
                break;

            case TestType.AwvEkg:
                testResultRepository = new AwvEkgTestRepository();
                break;

            case TestType.AwvEkgIPPE:
                testResultRepository = new AwvEkgIppeTestRepository();
                break;

            case TestType.Echocardiogram:
                testResultRepository = new EchocardiogramTestRepository();
                break;

            case TestType.PulmonaryFunction:
                testResultRepository = new PulmonaryFunctionTestRepository();
                break;

            case TestType.Osteoporosis:
                testResultRepository = new OsteoporosisTestRepository();
                break;

            case TestType.AwvBoneMass:
                testResultRepository = new AwvBoneMassTestRepository();
                break;

            case TestType.Spiro:
                testResultRepository = new SpiroTestRepository();
                break;

            case TestType.AwvSpiro:
                testResultRepository = new AwvSpiroTestRepository();
                break;

            case TestType.Lipid:
                testResultRepository = new LipidTestRepository();
                break;

            case TestType.AwvLipid:
                testResultRepository = new AwvLipidTestRepository();
                break;

            case TestType.AwvGlucose:
                testResultRepository = new AwvGlucoseTestRepository();
                break;

            case TestType.PPAAA:
                testResultRepository = new PpAaaTestRepository();
                break;

            case TestType.PPEcho:
                testResultRepository = new PpEchocardiogramTestRepository();
                break;

            case TestType.AWV:
                testResultRepository = new AwvTestRepository();
                break;

            case TestType.Medicare:
                testResultRepository = new MedicareTestRepository();
                break;

            case TestType.AwvSubsequent:
                testResultRepository = new AwvSubsequentTestRepository();
                break;

            case TestType.A1C:
                testResultRepository = new HemaglobinTestRepository();
                break;

            case TestType.AwvHBA1C:
                testResultRepository = new AwvHemaglobinTestRepository();
                break;

            case TestType.Thyroid:
                testResultRepository = new ThyroidTestRepository();
                break;

            case TestType.Psa:
                testResultRepository = new PsaTestRepository();
                break;

            case TestType.Crp:
                testResultRepository = new CrpTestRepository();
                break;

            case TestType.Testosterone:
                testResultRepository = new TestosteroneTestRepository();
                break;

            case TestType.Hearing:
                testResultRepository = new HearingTestRepository();
                break;

            case TestType.Vision:
                testResultRepository = new VisionTestRepository();
                break;

            case TestType.Glaucoma:
                testResultRepository = new GlaucomaTestRepository();
                break;

            case TestType.HCPAAA:
                testResultRepository = new HcpAaaTestRepository();
                break;

            case TestType.HCPCarotid:
                testResultRepository = new HcpCarotidTestRepository();
                break;

            case TestType.HCPEcho:
                testResultRepository = new HcpEchocardiogramTestRepository();
                break;

            case TestType.AwvEcho:
                testResultRepository = new AwvEchocardiogramTestRepository();
                break;

            case TestType.Cholesterol:
                testResultRepository = new CholesterolTestRepository();
                break;

            case TestType.Diabetes:
                testResultRepository = new DiabetesTestRepository();
                break;

            case TestType.HPylori:
                testResultRepository = new HPyloriTestRepository();
                break;

            case TestType.MenBloodPanel:
                testResultRepository = new MenBloodPanelTestRepository();
                break;

            case TestType.WomenBloodPanel:
                testResultRepository = new WomenBloodPanelTestRepository();
                break;

            case TestType.VitaminD:
                testResultRepository = new VitaminDTestRepository();
                break;

            case TestType.Hypertension:
                testResultRepository = new HypertensionTestRepository();
                break;

            case TestType.Hemoglobin:
                testResultRepository = new HemoglobinTestRepository();
                break;

            case TestType.eAWV:
                testResultRepository = new EAwvTestRepository();
                break;

            case TestType.DiabeticRetinopathy:
                testResultRepository = new DiabeticRetinopathyTestRepository();
                break;

            case TestType.DiabetesFootExam:
                testResultRepository = new DiabetesFootExamTestRepository();
                break;

            case TestType.RinneWeberHearing:
                testResultRepository = new RinneWeberHearingTestRepository();
                break;

            case TestType.Monofilament:
                testResultRepository = new MonofilamentTestRepository();
                break;

            case TestType.DiabeticNeuropathy:
                testResultRepository = new DiabeticNeuropathyTestRepository();
                break;

            case TestType.FloChecABI:
                testResultRepository = new FloChecABITestRepository();
                break;

            case TestType.IFOBT:
                testResultRepository = new IFOBTTestRepository();
                break;

            case TestType.QualityMeasures:
                testResultRepository = new QualityMeasuresTestRepository();
                break;

            case TestType.PHQ9:
                testResultRepository = new Phq9TestRepository();
                break;

            case TestType.FocAttestation:
                testResultRepository = new FocAttestationTestRepository();
                break;

            case TestType.Mammogram:
                testResultRepository = new MammogramTestRepository();
                break;

            case TestType.UrineMicroalbumin:
                testResultRepository = new UrineMicroalbuminTestRepository();
                break;

            case TestType.FluShot:
                testResultRepository = new FluShotTestRepository();
                break;

            case TestType.AwvFluShot:
                testResultRepository = new AwvFluShotTestRepository();
                break;

            case TestType.Pneumococcal:
                testResultRepository = new PneumococcalTestRepository();
                break;

            case TestType.Chlamydia:
                testResultRepository = new ChlamydiaTestRepository();
                break;

            case TestType.QuantaFloABI:
                testResultRepository = new QuantaFloABITestRepository();
                break;

            case TestType.DPN:
                testResultRepository = new DpnTestRepository();
                break;
            case TestType.MyBioCheckAssessment:
                testResultRepository = new MyBioAssessmentTestRepository();
                break;
            case TestType.Foc:
                testResultRepository = new FocTestRepository();
                break;
            case TestType.Cs:
                testResultRepository = new CsTestRepository();
                break;
            case TestType.Qv:
                testResultRepository = new QvTestRepository();
                break;
            case TestType.Colorectal:
            case TestType.Kyn:
            case TestType.HKYN:
                testResultRepository = new TestResultRepository();
                return testResultRepository.GetTestResult(customerId, eventId, (int)testType, testResult.IsNewResultFlow);
        }

        return testResultRepository != null ? testResultRepository.GetTestResults(customerId, eventId, testResult.IsNewResultFlow) : null;

    }

    [WebMethod(EnableSession = true)]
    public TestResult SetTestResultForPiq(long customerId, long eventId, string testResultString, string priorityInQueueTestDataString, long organizationRoleUserId, long resultState)
    {
        var testResultStrings = new[] { testResultString };
        var testResults = DeserializeTestResult(testResultStrings);

        if (testResults == null || testResults.Count() < 1) return null;

        var testResult = testResults.First();

        if (testResult.IsNewResultFlow)
        {
            testResult.ResultStatus.StateNumber = (int)NewTestResultStateNumber.ResultEntryPartial;
        }
        else
        {
            testResult.ResultStatus.StateNumber = (int)TestResultStateNumber.ManualEntry;
        }

        SetAllResults(customerId, eventId, testResults, organizationRoleUserId);

        if (!string.IsNullOrEmpty(priorityInQueueTestDataString))
            SavePriorityInQueueTestData(eventId, customerId, priorityInQueueTestDataString, organizationRoleUserId, resultState);

        var testType = testResult.TestType;
        TestResultRepository testResultRepository = null;
        switch (testType)
        {
            case TestType.ASI:
                testResultRepository = new ASITestRepository();
                break;

            case TestType.AAA:
                testResultRepository = new AAATestRepository();
                break;

            case TestType.AwvAAA:
                testResultRepository = new AwvAaaTestRepository();
                break;

            case TestType.Stroke:
                testResultRepository = new StrokeTestRepository();
                break;

            case TestType.AwvCarotid:
                testResultRepository = new AwvCarotidTestRepository();
                break;

            case TestType.Lead:
                testResultRepository = new LeadTestRepository();
                break;

            case TestType.PAD:
                testResultRepository = new PadTestRepository();
                break;

            case TestType.AwvABI:
                testResultRepository = new AwvAbiTestRepository();
                break;

            case TestType.IMT:
                testResultRepository = new ImtTestRepository();
                break;

            case TestType.EKG:
                testResultRepository = new EKGTestRepository();
                break;

            case TestType.AwvEkg:
                testResultRepository = new AwvEkgTestRepository();
                break;

            case TestType.AwvEkgIPPE:
                testResultRepository = new AwvEkgIppeTestRepository();
                break;

            case TestType.Echocardiogram:
                testResultRepository = new EchocardiogramTestRepository();
                break;

            case TestType.PulmonaryFunction:
                testResultRepository = new PulmonaryFunctionTestRepository();
                break;

            case TestType.Osteoporosis:
                testResultRepository = new OsteoporosisTestRepository();
                break;

            case TestType.AwvBoneMass:
                testResultRepository = new AwvBoneMassTestRepository();
                break;

            case TestType.Spiro:
                testResultRepository = new SpiroTestRepository();
                break;

            case TestType.AwvSpiro:
                testResultRepository = new AwvSpiroTestRepository();
                break;

            case TestType.Lipid:
                testResultRepository = new LipidTestRepository();
                break;

            case TestType.AwvLipid:
                testResultRepository = new AwvLipidTestRepository();
                break;

            case TestType.AwvGlucose:
                testResultRepository = new AwvGlucoseTestRepository();
                break;

            case TestType.PPAAA:
                testResultRepository = new PpAaaTestRepository();
                break;

            case TestType.PPEcho:
                testResultRepository = new PpEchocardiogramTestRepository();
                break;

            case TestType.AWV:
                testResultRepository = new AwvTestRepository();
                break;

            case TestType.Medicare:
                testResultRepository = new MedicareTestRepository();
                break;

            case TestType.AwvSubsequent:
                testResultRepository = new AwvSubsequentTestRepository();
                break;

            case TestType.A1C:
                testResultRepository = new HemaglobinTestRepository();
                break;

            case TestType.AwvHBA1C:
                testResultRepository = new AwvHemaglobinTestRepository();
                break;

            case TestType.Thyroid:
                testResultRepository = new ThyroidTestRepository();
                break;

            case TestType.Psa:
                testResultRepository = new PsaTestRepository();
                break;

            case TestType.Crp:
                testResultRepository = new CrpTestRepository();
                break;

            case TestType.Testosterone:
                testResultRepository = new TestosteroneTestRepository();
                break;

            case TestType.Hearing:
                testResultRepository = new HearingTestRepository();
                break;

            case TestType.Vision:
                testResultRepository = new VisionTestRepository();
                break;

            case TestType.Glaucoma:
                testResultRepository = new GlaucomaTestRepository();
                break;

            case TestType.HCPAAA:
                testResultRepository = new HcpAaaTestRepository();
                break;

            case TestType.HCPCarotid:
                testResultRepository = new HcpCarotidTestRepository();
                break;

            case TestType.HCPEcho:
                testResultRepository = new HcpEchocardiogramTestRepository();
                break;

            case TestType.AwvEcho:
                testResultRepository = new AwvEchocardiogramTestRepository();
                break;

            case TestType.Cholesterol:
                testResultRepository = new CholesterolTestRepository();
                break;

            case TestType.Diabetes:
                testResultRepository = new DiabetesTestRepository();
                break;

            case TestType.HPylori:
                testResultRepository = new HPyloriTestRepository();
                break;

            case TestType.MenBloodPanel:
                testResultRepository = new MenBloodPanelTestRepository();
                break;

            case TestType.WomenBloodPanel:
                testResultRepository = new WomenBloodPanelTestRepository();
                break;

            case TestType.VitaminD:
                testResultRepository = new VitaminDTestRepository();
                break;

            case TestType.Hypertension:
                testResultRepository = new HypertensionTestRepository();
                break;

            case TestType.Hemoglobin:
                testResultRepository = new HemoglobinTestRepository();
                break;

            case TestType.DiabeticRetinopathy:
                testResultRepository = new DiabeticRetinopathyTestRepository();
                break;

            case TestType.eAWV:
                testResultRepository = new EAwvTestRepository();
                break;
            case TestType.DiabetesFootExam:
                testResultRepository = new DiabetesFootExamTestRepository();
                break;

            case TestType.RinneWeberHearing:
                testResultRepository = new RinneWeberHearingTestRepository();
                break;

            case TestType.Monofilament:
                testResultRepository = new MonofilamentTestRepository();
                break;

            case TestType.DiabeticNeuropathy:
                testResultRepository = new DiabeticNeuropathyTestRepository();
                break;

            case TestType.FloChecABI:
                testResultRepository = new FloChecABITestRepository();
                break;

            case TestType.IFOBT:
                testResultRepository = new IFOBTTestRepository();
                break;

            case TestType.QualityMeasures:
                testResultRepository = new QualityMeasuresTestRepository();
                break;

            case TestType.PHQ9:
                testResultRepository = new Phq9TestRepository();
                break;

            case TestType.FocAttestation:
                testResultRepository = new FocAttestationTestRepository();
                break;

            case TestType.Mammogram:
                testResultRepository = new MammogramTestRepository();
                break;

            case TestType.UrineMicroalbumin:
                testResultRepository = new UrineMicroalbuminTestRepository();
                break;

            case TestType.FluShot:
                testResultRepository = new FluShotTestRepository();
                break;

            case TestType.AwvFluShot:
                testResultRepository = new AwvFluShotTestRepository();
                break;

            case TestType.Pneumococcal:
                testResultRepository = new PneumococcalTestRepository();
                break;

            case TestType.Chlamydia:
                testResultRepository = new ChlamydiaTestRepository();
                break;

            case TestType.QuantaFloABI:
                testResultRepository = new QuantaFloABITestRepository();
                break;
            case TestType.DPN:
                testResultRepository = new DpnTestRepository();
                break;
            case TestType.MyBioCheckAssessment:
                testResultRepository = new MyBioAssessmentTestRepository();
                break;
            case TestType.Foc:
                testResultRepository = new FocTestRepository();
                break;
            case TestType.Cs:
                testResultRepository = new CsTestRepository();
                break;
            case TestType.Qv:
                testResultRepository = new QvTestRepository();
                break;
            case TestType.Colorectal:
            case TestType.Kyn:
            case TestType.HKYN:
                testResultRepository = new TestResultRepository();
                return testResultRepository.GetTestResult(customerId, eventId, (int)testType, testResult.IsNewResultFlow);
        }

        return testResultRepository != null ? testResultRepository.GetTestResults(customerId, eventId, testResult.IsNewResultFlow) : null;

    }

    [WebMethod(EnableSession = true)]

    //public bool SetAllResultsforPostEvaluationEdit(long customerId, long eventId, IEnumerable<string> testResultStrings, bool doPostAudit, bool doReque, long organizationRoleUserId,
    //    bool isNewResultflow, bool isPennedBack = false, bool isRevertToCoding = false, bool isRevertToNp = false, string message = "")
    public bool SetAllResultsforPostEvaluationEdit(PostEvaluationEditModel model)
    {
        model.OrganizationRoleUserId = IoC.Resolve<ISessionContext>().UserSession.CurrentOrganizationRole.OrganizationRoleUserId;
        var testResults = DeserializeTestResult(model.TestResultStrings);
        SetAllResults(model.CustomerId, model.EventId, testResults, model.OrganizationRoleUserId);
        var manualAuditAndEnteryService = IoC.Resolve<IManualAuditAndEnteryService>();
        manualAuditAndEnteryService.SetPostAuditEvaluation(model);

        return true;
    }


    [WebMethod(EnableSession = true)]
    public bool SetAllResultsforPhysician(long customerId, long eventId, IEnumerable<string> testResultStrings, long organizationRoleUserId, bool isPrimaryPhysicianUpdate, bool isSendForCorrection, bool isBpElevated)
    {
        var physicianEvaluationRepository = IoC.Resolve<IPhysicianEvaluationRepository>();
        var eventCustomerResultRepository = IoC.Resolve<IEventCustomerResultRepository>();
        var eventCustomerResult = eventCustomerResultRepository.GetByCustomerIdAndEventId(customerId, eventId);
        var physicianEvaluation = physicianEvaluationRepository.GetPhysicianEvaluationinTransaction(eventCustomerResult.Id, organizationRoleUserId);

        if (physicianEvaluation == null) return false;
        IEnumerable<long> oldUrgentTestIds = null;
        try
        {
            var logger = IoC.Resolve<ILogManager>().GetLogger<Global>();
            logger.Info(string.Format("saving Physician Evaluation for EventId : {0} AND CustomerId : {1} ", eventId, customerId));

            var customerResultStatusViewModel = eventCustomerResultRepository.GetTestResultStatus(new[] { eventCustomerResult.Id }).First();

            oldUrgentTestIds = customerResultStatusViewModel.TestResults.Where(tr => !tr.IsCritical && tr.CriticalMarkedByPhysician).Select(tr => tr.TestId).ToArray();
        }
        catch (Exception ex)
        {
            var logger = IoC.Resolve<ILogManager>().GetLogger<Global>();
            logger.Info(string.Format("Error for fetching previous urgent test while Physician Evaluation for EventId : {0} AND CustomerId : {1} . Message: {2}, \n\t Stack Trace: {3}", eventId, customerId, ex.Message, ex.StackTrace));
        }

        try
        {
            var logger = IoC.Resolve<ILogManager>().GetLogger<Global>();

            var repository = IoC.Resolve<IBasicBiometricRepository>();
            var basicBiometric = repository.Get(eventCustomerResult.Id);
            if (basicBiometric != null)
            {
                basicBiometric.IsBloodPressureElevated = isBpElevated;
                ((IRepository<BasicBiometric>)repository).Save(basicBiometric);
            }

            var filter = new { CustomerId = customerId, EventId = eventId };
            ITestResultRepository testResultRepository = new TestResultRepository();
            var testResults = DeserializeTestResult(testResultStrings);
            LogFilterListPairAudit(ModelType.Edit, filter, testResults, "App/Franchisee/Technician/AuditResultEntry.aspx", "POST");
            SetEventCustomerInterpretation(eventId, customerId, testResults);
            var isNewResultFlow = testResults.First().IsNewResultFlow;

            testResultRepository.UpdateStateforNotReviewableTests(eventId, customerId, isPrimaryPhysicianUpdate, isNewResultFlow);
            SetAllResults(customerId, eventId, testResults, organizationRoleUserId);

            if (!(isPrimaryPhysicianUpdate || !isNewResultFlow || isSendForCorrection))
            {
                var testResultService = IoC.Resolve<ITestResultService>();
                var isTestPurchased = testResultService.IsTestPurchasedByCustomer(eventCustomerResult.Id, (long)TestType.eAWV);
                var account = IoC.Resolve<CorporateAccountRepository>().GetbyEventId(eventId);
                var isEawvTestNotPerformed = IoC.Resolve<ITestNotPerformedRepository>().IsTestNotPerformed(eventCustomerResult.Id, (long)TestType.eAWV);

                var eventRepository = IoC.Resolve<IEventRepository>();
                var theEvent = eventRepository.GetById(eventId);

                QuestionnaireType questionnaireType = QuestionnaireType.None;
                if (account != null && theEvent != null)
                {
                    var accountHraChatQuestionnaireHistoryServices = IoC.Resolve<IAccountHraChatQuestionnaireHistoryServices>();
                    questionnaireType = accountHraChatQuestionnaireHistoryServices.QuestionnaireTypeByAccountIdandEventDate(account.Id, theEvent.EventDate);
                }

                if (account == null || account.IsHealthPlan == false || isEawvTestNotPerformed || questionnaireType == QuestionnaireType.ChatQuestionnaire)
                {
                    logger.Info(string.Format("Updating ResultState to ArtifactSynced for EventId : {0} AND CustomerId : {1} .", eventId, customerId));
                    testResultService.SetResultstoState(eventId, customerId, (int)NewTestResultStateNumber.ArtifactSynced, false, organizationRoleUserId);
                }
                else if ((questionnaireType == QuestionnaireType.None) || isTestPurchased == false)
                {
                    logger.Info(string.Format("Updating ResultState to NpSigned for EventId : {0} AND CustomerId : {1} .", eventId, customerId));
                    testResultService.SetResultstoState(eventId, customerId, (int)NewTestResultStateNumber.NpSigned, false, organizationRoleUserId);
                }
                else if ((questionnaireType == QuestionnaireType.HraQuestionnaire))
                {
                    logger.Info(string.Format("Updating ResultState to Evaluated for EventId : {0} AND CustomerId : {1} .", eventId, customerId));
                    testResultService.SetResultstoState(eventId, customerId, (int)NewTestResultStateNumber.Evaluated, false, organizationRoleUserId);
                }

            }

            if (isSendForCorrection)
            {
                var restultState = isNewResultFlow ? (int)NewTestResultStateNumber.PreAudit : (int)TestResultStateNumber.PreAudit;

                logger.Info(string.Format("SendForCorrection: Updating ResultState to PreAudit for EventId : {0} AND CustomerId : {1} .", eventId, customerId));
                testResultRepository.SetResultstoState(eventId, customerId, restultState, true, organizationRoleUserId);
                eventCustomerResultRepository.SetEventCustomerResultState(eventId, customerId);
            }
            SendUrgentMail(eventId, customerId, eventCustomerResult.Id, oldUrgentTestIds, organizationRoleUserId);
            return true;
        }
        catch (Exception ex)
        {
            var logger = IoC.Resolve<ILogManager>().GetLogger<Global>();
            logger.Info(string.Format("Error while Physician Evaluation for EventId : {0} AND CustomerId : {1} . Message: {2}, \n\t Stack Trace: {3}", eventId, customerId, ex.Message, ex.StackTrace));
            throw;
        }
    }

    private static IEnumerable<TestResult> DeserializeTestResult(IEnumerable<string> testResultStrings)
    {
        var testResults = new List<TestResult>();
        var serializer = new JavaScriptSerializer();
        foreach (var testResultString in testResultStrings)
        {

            var testResult = serializer.Deserialize<TestResult>(testResultString);
            switch (testResult.TestType)
            {
                case TestType.AAA:
                    var aaaTestResult = serializer.Deserialize<AAATestResult>(testResultString);
                    testResults.Add(aaaTestResult);
                    break;

                case TestType.AwvAAA:
                    var awvAaaTestResult = serializer.Deserialize<AwvAaaTestResult>(testResultString);
                    testResults.Add(awvAaaTestResult);
                    break;

                case TestType.ASI:
                    var asiTestResult = serializer.Deserialize<ASITestResult>(testResultString);
                    testResults.Add(asiTestResult);
                    break;

                case TestType.PAD:
                    var padTestResult = serializer.Deserialize<PADTestResult>(testResultString);
                    testResults.Add(padTestResult);
                    break;

                case TestType.AwvABI:
                    var awvAbiTestResult = serializer.Deserialize<AwvAbiTestResult>(testResultString);
                    testResults.Add(awvAbiTestResult);
                    break;

                case TestType.Stroke:
                    var strokeTestResult = serializer.Deserialize<StrokeTestResult>(testResultString);
                    testResults.Add(strokeTestResult);
                    break;

                case TestType.AwvCarotid:
                    var awvCarotidTestResult = serializer.Deserialize<AwvCarotidTestResult>(testResultString);
                    testResults.Add(awvCarotidTestResult);
                    break;

                case TestType.Lead:
                    var leadTestResult = serializer.Deserialize<LeadTestResult>(testResultString);
                    testResults.Add(leadTestResult);
                    break;

                case TestType.Osteoporosis:
                    var osteoTestResult = serializer.Deserialize<OsteoporosisTestResult>(testResultString);
                    testResults.Add(osteoTestResult);
                    break;

                case TestType.AwvBoneMass:
                    var awvBoneMassTestResult = serializer.Deserialize<AwvBoneMassTestResult>(testResultString);
                    testResults.Add(awvBoneMassTestResult);
                    break;

                case TestType.Spiro:
                    var spiroTestResult = serializer.Deserialize<SpiroTestResult>(testResultString);
                    testResults.Add(spiroTestResult);
                    break;

                case TestType.AwvSpiro:
                    var awvSpiroTestResult = serializer.Deserialize<AwvSpiroTestResult>(testResultString);
                    testResults.Add(awvSpiroTestResult);
                    break;

                case TestType.PulmonaryFunction:
                    var pulmonaryTestResult = serializer.Deserialize<PulmonaryFunctionTestResult>(testResultString);
                    testResults.Add(pulmonaryTestResult);
                    break;

                case TestType.IMT:
                    var imtTestResult = serializer.Deserialize<ImtTestResult>(testResultString);
                    testResults.Add(imtTestResult);
                    break;

                case TestType.EKG:
                    var ekgTestResult = serializer.Deserialize<EKGTestResult>(testResultString);
                    testResults.Add(ekgTestResult);
                    break;

                case TestType.AwvEkg:
                    var awvEkgTestResult = serializer.Deserialize<AwvEkgTestResult>(testResultString);
                    testResults.Add(awvEkgTestResult);
                    break;

                case TestType.AwvEkgIPPE:
                    var awvEkgIppeTestResult = serializer.Deserialize<AwvEkgIppeTestResult>(testResultString);
                    testResults.Add(awvEkgIppeTestResult);
                    break;

                case TestType.Echocardiogram:
                    var echoTestResult = serializer.Deserialize<EchocardiogramTestResult>(testResultString);
                    testResults.Add(echoTestResult);
                    break;

                case TestType.Lipid:
                    var lipidTestResult = serializer.Deserialize<LipidTestResult>(testResultString);
                    testResults.Add(lipidTestResult);
                    break;

                case TestType.AwvLipid:
                    var awvLipidTestResult = serializer.Deserialize<AwvLipidTestResult>(testResultString);
                    testResults.Add(awvLipidTestResult);
                    break;

                case TestType.AwvGlucose:
                    var awvGlucoseTestResult = serializer.Deserialize<AwvGlucoseTestResult>(testResultString);
                    testResults.Add(awvGlucoseTestResult);
                    break;

                case TestType.Liver:
                    var liverTestResult = serializer.Deserialize<LiverTestResult>(testResultString);
                    testResults.Add(liverTestResult);
                    break;

                case TestType.PPAAA:
                    var ppAaaTestResult = serializer.Deserialize<PpAaaTestResult>(testResultString);
                    testResults.Add(ppAaaTestResult);
                    break;

                case TestType.PPEcho:
                    var ppEchoTestResult = serializer.Deserialize<PpEchocardiogramTestResult>(testResultString);
                    testResults.Add(ppEchoTestResult);
                    break;

                case TestType.AWV:
                    var awvTestResult = serializer.Deserialize<AwvTestResult>(testResultString);
                    testResults.Add(awvTestResult);
                    break;

                case TestType.Medicare:
                    var medicareTestResult = serializer.Deserialize<MedicareTestResult>(testResultString);
                    testResults.Add(medicareTestResult);
                    break;

                case TestType.AwvSubsequent:
                    var awvSubsequentTestResult = serializer.Deserialize<AwvSubsequentTestResult>(testResultString);
                    testResults.Add(awvSubsequentTestResult);
                    break;

                case TestType.A1C:
                    var a1CTestResult = serializer.Deserialize<HemaglobinA1CTestResult>(testResultString);
                    testResults.Add(a1CTestResult);
                    break;

                case TestType.AwvHBA1C:
                    var awvA1CTestResult = serializer.Deserialize<AwvHemaglobinTestResult>(testResultString);
                    testResults.Add(awvA1CTestResult);
                    break;

                case TestType.Thyroid:
                    var thyroidTestResult = serializer.Deserialize<ThyroidTestResult>(testResultString);
                    testResults.Add(thyroidTestResult);
                    break;

                case TestType.Psa:
                    var psaTestResult = serializer.Deserialize<PsaTestResult>(testResultString);
                    testResults.Add(psaTestResult);
                    break;

                case TestType.Crp:
                    var crpTestResult = serializer.Deserialize<CrpTestResult>(testResultString);
                    testResults.Add(crpTestResult);
                    break;

                case TestType.Testosterone:
                    var testosteroneTestResult = serializer.Deserialize<TestosteroneTestResult>(testResultString);
                    testResults.Add(testosteroneTestResult);
                    break;

                case TestType.Hearing:
                    var hearingTestResult = serializer.Deserialize<HearingTestResult>(testResultString);
                    testResults.Add(hearingTestResult);
                    break;

                case TestType.Vision:
                    var visionTestResult = serializer.Deserialize<VisionTestResult>(testResultString);
                    testResults.Add(visionTestResult);
                    break;

                case TestType.Glaucoma:
                    var glaucomaTestResult = serializer.Deserialize<GlaucomaTestResult>(testResultString);
                    testResults.Add(glaucomaTestResult);
                    break;

                case TestType.HCPAAA:
                    var hcpAaaTestResult = serializer.Deserialize<HcpAaaTestResult>(testResultString);
                    testResults.Add(hcpAaaTestResult);
                    break;

                case TestType.HCPCarotid:
                    var hcpCarotidTestResult = serializer.Deserialize<HcpCarotidTestResult>(testResultString);
                    testResults.Add(hcpCarotidTestResult);
                    break;

                case TestType.HCPEcho:
                    var hcpEchoTestResult = serializer.Deserialize<HcpEchocardiogramTestResult>(testResultString);
                    testResults.Add(hcpEchoTestResult);
                    break;

                case TestType.AwvEcho:
                    var awvEchoTestResult = serializer.Deserialize<AwvEchocardiogramTestResult>(testResultString);
                    testResults.Add(awvEchoTestResult);
                    break;

                case TestType.Colorectal:
                case TestType.Kyn:
                case TestType.HKYN:
                    testResults.Add(testResult);
                    break;

                case TestType.Cholesterol:
                    var cholesterolTestResult = serializer.Deserialize<CholesterolTestResult>(testResultString);
                    testResults.Add(cholesterolTestResult);
                    break;

                case TestType.Diabetes:
                    var diabetesTestResult = serializer.Deserialize<DiabetesTestResult>(testResultString);
                    testResults.Add(diabetesTestResult);
                    break;

                case TestType.HPylori:
                    var hPyloriTestResult = serializer.Deserialize<HPyloriTestResult>(testResultString);
                    testResults.Add(hPyloriTestResult);
                    break;

                case TestType.MenBloodPanel:
                    var menBloodPanelTestResult = serializer.Deserialize<MenBloodPanelTestResult>(testResultString);
                    testResults.Add(menBloodPanelTestResult);
                    break;
                case TestType.WomenBloodPanel:
                    var womenBloodPanelTestResult = serializer.Deserialize<WomenBloodPanelTestResult>(testResultString);
                    testResults.Add(womenBloodPanelTestResult);
                    break;
                case TestType.VitaminD:
                    var vitaminDTestResult = serializer.Deserialize<VitaminDTestResult>(testResultString);
                    testResults.Add(vitaminDTestResult);
                    break;
                case TestType.Hypertension:
                    var hypertensionTestResult = serializer.Deserialize<HypertensionTestResult>(testResultString);
                    testResults.Add(hypertensionTestResult);
                    break;

                case TestType.Hemoglobin:
                    var hemoglobinTestResult = serializer.Deserialize<HemoglobinTestResult>(testResultString);
                    testResults.Add(hemoglobinTestResult);
                    break;

                case TestType.DiabeticRetinopathy:
                    var diabeticRetinopathyTestResult = serializer.Deserialize<DiabeticRetinopathyTestResult>(testResultString);
                    testResults.Add(diabeticRetinopathyTestResult);
                    break;

                case TestType.eAWV:
                    var eawvTestResult = serializer.Deserialize<EAwvTestResult>(testResultString);
                    testResults.Add(eawvTestResult);
                    break;

                case TestType.DiabetesFootExam:
                    var diabetesFootExamTestResult = serializer.Deserialize<DiabetesFootExamTestResult>(testResultString);
                    testResults.Add(diabetesFootExamTestResult);
                    break;

                case TestType.RinneWeberHearing:
                    var rinneWeberHearingTestResult = serializer.Deserialize<RinneWeberHearingTestResult>(testResultString);
                    testResults.Add(rinneWeberHearingTestResult);
                    break;

                case TestType.Monofilament:
                    var monofilamentTestResult = serializer.Deserialize<MonofilamentTestResult>(testResultString);
                    testResults.Add(monofilamentTestResult);
                    break;

                case TestType.DiabeticNeuropathy:
                    var diabeticNeuropathyTestResult = serializer.Deserialize<DiabeticNeuropathyTestResult>(testResultString);
                    testResults.Add(diabeticNeuropathyTestResult);
                    break;

                case TestType.FloChecABI:
                    var floChecABITestResult = serializer.Deserialize<FloChecABITestResult>(testResultString);
                    testResults.Add(floChecABITestResult);
                    break;

                case TestType.IFOBT:
                    var iFOBTTestResult = serializer.Deserialize<IFOBTTestResult>(testResultString);
                    testResults.Add(iFOBTTestResult);
                    break;

                case TestType.QualityMeasures:
                    var qualityMeasures = serializer.Deserialize<QualityMeasuresTestResult>(testResultString);
                    testResults.Add(qualityMeasures);
                    break;
                case TestType.PHQ9:
                    var phq9TestResult = serializer.Deserialize<Phq9TestResult>(testResultString);
                    testResults.Add(phq9TestResult);
                    break;
                case TestType.FocAttestation:
                    var focAttestationTestResult = serializer.Deserialize<FocAttestationTestResult>(testResultString);
                    testResults.Add(focAttestationTestResult);
                    break;

                case TestType.Mammogram:
                    var mammogramTestResult = serializer.Deserialize<MammogramTestResult>(testResultString);
                    testResults.Add(mammogramTestResult);
                    break;

                case TestType.UrineMicroalbumin:
                    var urineMicroalbuminTestResult = serializer.Deserialize<UrineMicroalbuminTestResult>(testResultString);
                    testResults.Add(urineMicroalbuminTestResult);
                    break;

                case TestType.FluShot:
                    var fluShotTestResult = serializer.Deserialize<FluShotTestResult>(testResultString);
                    testResults.Add(fluShotTestResult);
                    break;

                case TestType.AwvFluShot:
                    var awvFluShotTestResult = serializer.Deserialize<AwvFluShotTestResult>(testResultString);
                    testResults.Add(awvFluShotTestResult);
                    break;

                case TestType.Pneumococcal:
                    var pneumococcalTestResult = serializer.Deserialize<PneumococcalTestResult>(testResultString);
                    testResults.Add(pneumococcalTestResult);
                    break;

                case TestType.Chlamydia:
                    var chlamydiaTestResult = serializer.Deserialize<ChlamydiaTestResult>(testResultString);
                    testResults.Add(chlamydiaTestResult);
                    break;
                case TestType.QuantaFloABI:
                    var quantaFloABITestResult = serializer.Deserialize<QuantaFloABITestResult>(testResultString);
                    testResults.Add(quantaFloABITestResult);
                    break;

                case TestType.DPN:
                    var dpnTestResult = serializer.Deserialize<DpnTestResult>(testResultString);
                    testResults.Add(dpnTestResult);
                    break;

                case TestType.MyBioCheckAssessment:
                    var myBioCheckAssessmentTestResult = serializer.Deserialize<MyBioAssessmentTestResult>(testResultString);
                    testResults.Add(myBioCheckAssessmentTestResult);
                    break;
                case TestType.Foc:
                    var focTestResult = serializer.Deserialize<FocTestResult>(testResultString);
                    testResults.Add(focTestResult);
                    break;
                case TestType.Cs:
                    var csTestResult = serializer.Deserialize<CsTestResult>(testResultString);
                    testResults.Add(csTestResult);
                    break;
                case TestType.Qv:
                    var qvTestResult = serializer.Deserialize<QvTestResult>(testResultString);
                    testResults.Add(qvTestResult);
                    break;
            }
        }
        return testResults;
    }

    private static bool SetAllResults(long customerId, long eventId, IEnumerable<TestResult> testResults, long organizationRoleUserId)
    {
        if (testResults == null || testResults.Count() < 1) return false;

        SaveEventCustomerResult(eventId, customerId);
        bool exceptionCaused = false;

        var testResultService = new TestResultService();
        var logger = IoC.Resolve<ILogManager>().GetLogger<Global>();

        var organizationRoleUserRepository = new OrganizationRoleUserRepository();
        var organizationRoleUser = organizationRoleUserRepository.GetOrganizationRoleUser(organizationRoleUserId);

        foreach (var testResult in testResults)
        {
            try
            {
                testResult.DataRecorderMetaData = new DataRecorderMetaData
                {
                    DataRecorderCreator = organizationRoleUser,
                    DateCreated = DateTime.Now
                };

                testResultService.SaveTestResult(testResult, eventId, customerId, organizationRoleUserId, logger);
            }
            catch
            {
                exceptionCaused = true;
            }
        }

        IoC.Resolve<IEventCustomerResultRepository>().SetEventCustomerResultState(eventId, customerId);
        if (exceptionCaused) throw new Exception("Exception caused while saving the results!");

        return true;
    }

    private static void SaveEventCustomerResult(long eventId, long customerId)
    {
        var eventCustomerResultRepository = new EventCustomerResultRepository();
        var eventCustomerResult = eventCustomerResultRepository.GetByCustomerIdAndEventId(customerId, eventId);
        if (eventCustomerResult == null)
        {
            eventCustomerResult = new EventCustomerResult
            {
                CustomerId = customerId,
                EventId = eventId,
                DataRecorderMetaData =
                    new DataRecorderMetaData(IoC.Resolve<ISessionContext>().UserSession.CurrentOrganizationRole.OrganizationRoleUserId, DateTime.Now, null)
            };
            eventCustomerResultRepository.Save(eventCustomerResult);
        }

    }

    private static void UpdateFastingStatus(long eventId, long customerId, bool? isFasting, long organizationRoleUserId)
    {
        var eventData = IoC.Resolve<IEventRepository>().GetById(eventId);
        var fastingDate = IoC.Resolve<ISettings>().FastingStatusDate;
        var testResultService = new TestResultService();

        if (fastingDate.HasValue && eventData.EventDate.Date >= fastingDate.Value)
        {
            var eventCustomerResultRepository = IoC.Resolve<IEventCustomerResultRepository>();
            var eventCustomerResult = IoC.Resolve<IEventCustomerResultRepository>().GetByCustomerIdAndEventId(customerId, eventId);
            if (eventCustomerResult != null)
            {
                eventCustomerResultRepository.Update(eventCustomerResult.Id, isFasting);
                testResultService.SaveKynLabFastingStatus(eventId, customerId, organizationRoleUserId, isFasting, eventCustomerResult.Id);
            }
        }
    }

    [WebMethod(EnableSession = true)]
    public Customer GetCustomer(long customerId)
    {
        var customerRepository = IoC.Resolve<ICustomerRepository>();
        return customerRepository.GetCustomer(customerId);
    }

    [WebMethod(EnableSession = true)]
    public UserEditModel GetCustomerEditModel(long customerId)
    {
        var customerRepository = IoC.Resolve<ICustomerRepository>();
        var customer = customerRepository.GetCustomer(customerId);

        var editModel = AutoMapper.Mapper.Map<User, UserEditModel>(customer);
        var customerModel = AutoMapper.Mapper.Map<Customer, CustomerEditModel>(customer);

        editModel.CustomerProfile = customerModel;
        if (editModel.DateOfBirth.HasValue)
            editModel.DateOfBirth = DateTime.SpecifyKind(editModel.DateOfBirth.Value.ToUniversalTime(), DateTimeKind.Utc);

        return editModel;
    }

    [WebMethod(EnableSession = true)]
    public void SetCustomer(UserEditModel model)
    {
        try
        {


            var customerRepository = IoC.Resolve<ICustomerRepository>();
            var customer = customerRepository.GetCustomer(model.CustomerProfile.CustomerId);
            model.UsersRoles = new[] { new OrganizationRoleUserModel() { IsDefault = true, RoleId = (long)customer.DefaultRole } };

            var customerFromModel = AutoMapper.Mapper.Map<CustomerEditModel, Customer>(model.CustomerProfile);
            AutoMapper.Mapper.Map<UserEditModel, User>(model, customerFromModel);

            var currentUser = IoC.Resolve<ISessionContext>().UserSession.CurrentOrganizationRole.OrganizationRoleUserId;
            customerFromModel.DataRecorderMetaData = customer.DataRecorderMetaData;
            customerFromModel.DataRecorderMetaData.DataRecorderModifier = new OrganizationRoleUser(currentUser);
            customerFromModel.DataRecorderMetaData.DateModified = DateTime.Now;
            customerFromModel.DateModified = DateTime.Now;
            customerFromModel.UserLogin = customer.UserLogin;
            customerFromModel.DisplayCode = customer.DisplayCode;
            customerFromModel.BillingAddress = customer.BillingAddress;
            customerFromModel.DateCreated = customer.DateCreated;
            customerFromModel.PrimaryCarePhysician = customer.PrimaryCarePhysician;
            customerFromModel.DefaultRole = customer.DefaultRole;
            customerFromModel.DoNotContactTypeId = customer.DoNotContactTypeId;
            customerFromModel.DoNotContactReasonId = customer.DoNotContactReasonId;
            customerFromModel.DoNotContactReasonNotesId = customerFromModel.DoNotContactReasonNotesId;
            customerFromModel.RequestForNewsLetter = customerFromModel.RequestForNewsLetter;
            customerFromModel.EmployeeId = customer.EmployeeId;
            customerFromModel.InsuranceId = customer.InsuranceId;
            customerFromModel.PreferredLanguage = customer.PreferredLanguage;
            customerFromModel.BestTimeToCall = customer.BestTimeToCall;
            customerFromModel.Ssn = customer.Ssn;
            customerFromModel.Tag = customer.Tag;
            customerFromModel.Hicn = customer.Hicn;
            customerFromModel.EnableTexting = customer.EnableTexting;
            customerFromModel.MedicareAdvantageNumber = customer.MedicareAdvantageNumber;
            customerFromModel.MedicareAdvantagePlanName = customer.MedicareAdvantagePlanName;
            //customerFromModel.IsEligible = customer.IsEligible;                                   //Eligibility status is not updated from the page where this Function is USED. AuditResultEntry.aspx
            customerFromModel.LabId = customer.LabId;
            customerFromModel.LanguageId = customer.LanguageId;
            customerFromModel.Copay = customer.Copay;
            customerFromModel.Lpi = customer.Lpi;
            customerFromModel.Market = customer.Market;
            customerFromModel.Mrn = customer.Mrn;
            customerFromModel.GroupName = customer.GroupName;
            customerFromModel.IsIncorrectPhoneNumber = customer.IsIncorrectPhoneNumber;
            customerFromModel.IsLanguageBarrier = customer.IsLanguageBarrier;
            customerFromModel.EnableVoiceMail = customer.EnableVoiceMail;
            customerFromModel.AdditionalField1 = customer.AdditionalField1;
            customerFromModel.AdditionalField2 = customer.AdditionalField2;
            customerFromModel.AdditionalField3 = customer.AdditionalField3;
            customerFromModel.AdditionalField4 = customer.AdditionalField4;
            customerFromModel.ActivityId = customer.ActivityId;

            customerFromModel.DoNotContactUpdateDate = customer.DoNotContactUpdateDate;
            //customerFromModel.IsDuplicate = customer.IsDuplicate;
            customerFromModel.DoNotContactUpdateSource = customer.DoNotContactUpdateSource;

            customerFromModel.IsSubscribed = customer.IsSubscribed;
            customerFromModel.LanguageBarrierMarkedDate = customer.LanguageBarrierMarkedDate;
            customerFromModel.IncorrectPhoneNumberMarkedDate = customer.IncorrectPhoneNumberMarkedDate;
            customerFromModel.PreferredContactType = customer.PreferredContactType;

            customerFromModel.Mbi = customer.Mbi;

            customerFromModel.PhoneHomeConsentId = customer.PhoneHomeConsentId;
            customerFromModel.PhoneCellConsentId = customer.PhoneCellConsentId;
            customerFromModel.PhoneOfficeConsentId = customer.PhoneOfficeConsentId;
            customerFromModel.PhoneHomeConsentUpdateDate = customer.PhoneHomeConsentUpdateDate;
            customerFromModel.PhoneCellConsentUpdateDate = customer.PhoneCellConsentUpdateDate;
            customerFromModel.PhoneOfficeConsentUpdateDate = customer.PhoneOfficeConsentUpdateDate;
            customerFromModel.AcesId = customer.AcesId;
            customerFromModel.BillingMemberId = customer.BillingMemberId;
            customerFromModel.BillingMemberPlan = customer.BillingMemberPlan;
            customerFromModel.BillingMemberPlanYear = customer.BillingMemberPlanYear;
            customerFromModel.EnableEmail = customer.EnableEmail;
            customerFromModel.EnableEmailUpdateDate = customer.EnableEmailUpdateDate;
            customerFromModel.MemberUploadSourceId = customer.MemberUploadSourceId;
            customerFromModel.ActivityTypeIsManual = customer.ActivityTypeIsManual;
            customerFromModel.ProductTypeId = customer.ProductTypeId;
            customerFromModel.AcesClientId = customer.AcesClientId;

            var customerService = IoC.Resolve<ICustomerService>();
            customerService.SaveCustomer(customerFromModel, currentUser);
        }
        catch (Exception ex)
        {
            var logger = IoC.Resolve<ILogManager>().GetLogger<Global>();
            logger.Error(string.Format("Error While set customer Message {0} \n\t Stack Trace : {1}", ex.Message, ex.StackTrace));
            throw;
        }

    }

    [WebMethod(EnableSession = true)]
    public void SaveNewTestResultsforPostAudit(long eventId, long customerId, long orgRoleUserId)
    {
        try
        {
            IoC.Resolve<ITestResultService>().SetResultstoState(eventId, customerId, (int)TestResultStateNumber.PostAudit, true, orgRoleUserId);
        }
        catch (Exception ex)
        {
            var logger = IoC.Resolve<ILogManager>().GetLogger<Global>();
            logger.Info(string.Format("Error while Post Audit for EventId : {0} AND CustomerId : {1} . Message: {2}, \n\t Stack Trace: {3}", eventId, customerId, ex.Message, ex.StackTrace));
            throw;
        }

    }

    [WebMethod(EnableSession = true)]
    public List<EPrimaryCarePhysician> GetPcpListing(string searchText, int stateId)
    {
        OtherDAL otherDal = new OtherDAL();
        var listCarePhysicians = otherDal.GetPCPDetails(searchText, stateId);
        return listCarePhysicians;
    }

    [WebMethod(EnableSession = true)]
    public string IsLipidValuesValid(LipidTestResult lipidTestResult)
    {
        var validationRule = new LipidCalculatableDataMustBeValidRule<LipidTestResult, int?>();

        bool isValid = validationRule.IsValid(lipidTestResult);
        if (!isValid) return validationRule.GetErrorMessage(lipidTestResult);

        return string.Empty;
    }

    [WebMethod(EnableSession = true)]
    public object ValidateTestResults(long customerId, EKGTestResult ekgTestResult, LipidTestResult lipidTestResult,
            LiverTestResult liverTestResult, FraminghamRiskTestResult framinghamTestResult) // TODO: Will be refactored when old tests are moved to new structure
    {
        var aaaValidationMessages = new List<string>(0);
        var asiValidationMessages = new List<string>(0);
        var strokeValidationMessages = new List<string>(0);
        var padValidationMessages = new List<string>(0);
        var osteoporosisValidationMessages = new List<string>(0);
        var lipidValidationMessages = new List<string>(0);
        var liverValidationMessages = new List<string>(0);
        var ekgValidationMessages = new List<string>(0);
        var framinghamValidationMessages = new List<string>(0);


        bool isValid;

        if (lipidTestResult != null)
        {
            IValidator<LipidTestResult> validator = new Validator<LipidTestResult>(new LipidPanelValidationRuleFactory());
            isValid = validator.IsValid(lipidTestResult);
            if (!isValid) lipidValidationMessages = validator.GetBrokenRuleErrorMessages();
        }


        if (ekgTestResult != null)
        {
            IValidator<EKGTestResult> validator = new Validator<EKGTestResult>(new EKGValidationRuleFactory());
            isValid = validator.IsValid(ekgTestResult);
            if (!isValid) ekgValidationMessages = validator.GetBrokenRuleErrorMessages();
        }


        if (liverTestResult != null)
        {
            IValidator<LiverTestResult> validator = new Validator<LiverTestResult>(new LiverValidationRuleFactory());
            isValid = validator.IsValid(liverTestResult);
            if (!isValid) liverValidationMessages = validator.GetBrokenRuleErrorMessages();
        }

        if (framinghamTestResult != null)
        {
            //TODO: To Remove from here. Implement it in the validation factory.
            if (framinghamTestResult.UnableScreenReason == null || framinghamTestResult.UnableScreenReason.Count < 1)
            {
                isValid = new ReadingNotBlankRule<decimal?>().IsValid(framinghamTestResult.FraminghamRisk);
                if (!isValid) framinghamValidationMessages.Add("Framingham Risk is not calculated.");
            }
        }


        return new
                   {
                       AAAMessages = aaaValidationMessages,
                       StrokeMessages = strokeValidationMessages,
                       ASIMessages = asiValidationMessages,
                       PADMessages = padValidationMessages,
                       OsteoMessages = osteoporosisValidationMessages,
                       EKGMessages = ekgValidationMessages,
                       LipidMessages = lipidValidationMessages,
                       LiverMessages = liverValidationMessages,
                       FraminghamMessages = framinghamValidationMessages
                   };
    }

    [WebMethod(EnableSession = true)]
    public void SaveCommentsForPhysician(long customerId, long eventId, string comments, long organizationRoleUserId)
    {
        var orgRoleUser = new OrganizationRoleUserRepository().GetOrganizationRoleUser(organizationRoleUserId);
        new CommunicationRepository().SaveCommunicationDetails(comments, orgRoleUser, customerId, eventId);
    }

    [WebMethod(EnableSession = true)]
    public EventCustomerPackageTestDetailViewData GetEventCustomerPackageTestDetails(long customerId, long eventId)
    {
        var eventCustomerPackageTestDetailService = new EventCustomerPackageTestDetailService();

        var eventCustomerPackageTestDetailViewData =
        eventCustomerPackageTestDetailService.GetEventPackageDetails(eventId, customerId);
        return eventCustomerPackageTestDetailViewData;

    }

    [WebMethod(EnableSession = true)]
    public object RemoveKynDataFile(long eventId, long customerId, string fileType, long testId)
    {
        if (!(fileType.ToLower().Equals(KynFileTypes.LetterWriter) || fileType.ToLower().Equals(KynFileTypes.PhysicianSummaryReport)
              || fileType.ToLower().Equals(KynFileTypes.ParticipantSummaryReport) || fileType.ToLower().Equals(KynFileTypes.LongitudinalPrompt)))
            return new { IsSuccess = false, Message = "Wrong File Type provided." };


        var repository = IoC.Resolve<IMediaRepository>();
        var location = repository.GetKynIntegrationOutputDataLocation(eventId, customerId);

        var testType = (TestType)testId;

        var tempLocation = repository.GetTempMediaFileLocation();

        if (!Directory.Exists(location.PhysicalPath))
            return new { IsSuccess = false, Message = "No Files found for the sepcified customer." };

        var files = Directory.GetFiles(location.PhysicalPath, testType + "*.pdf");

        if (files.Length < 1)
            return new { IsSuccess = false, Message = "No Files found for the sepcified customer." };

        var filePath = files.Where(f => Path.GetFileName(f).ToLower().Contains(fileType)).SingleOrDefault();
        try
        {
            if (!string.IsNullOrEmpty(filePath))
            {
                DirectoryOperationsHelper.Move(filePath, tempLocation.PhysicalPath + "Delete_" + DateTime.Now.ToFileTimeUtc() + ".pdf");
                //File.Delete(filePath);
            }
        }
        catch (Exception ex)
        {
            var logger = IoC.Resolve<ILogManager>().GetLogger<Global>();
            logger.Info(string.Format("Error while deleteing {5} File for EventId : {0} AND CustomerId : {1} AND File Type {2} . Message: {3}, \n\t Stack Trace: {4}", eventId, customerId, fileType, ex.Message, ex.StackTrace, (TestType)testId));

            return new { IsSuccess = false, Message = "File couldn't be deleted. Someone might be accessing it." };
        }

        return new { IsSuccess = true, Message = "" };
    }

    [WebMethod(EnableSession = true)]
    public void SendCriticalMail(long eventId, long customerId, long organizationRoleUserId)
    {
        var emailNotificationModelsFactory = IoC.Resolve<IEmailNotificationModelsFactory>();
        var notifier = IoC.Resolve<INotifier>();
        var criticalCustomerNotificationModel = emailNotificationModelsFactory.GetCriticalCustomerNotificationModel(eventId, customerId);

        string[] careCordinatorEmails = null;
        var hospitalPartnerRepository = IoC.Resolve<IHospitalPartnerRepository>();
        var hospitalPartnerId = hospitalPartnerRepository.GetHospitalPartnerIdForEvent(eventId);
        if (hospitalPartnerId > 0)
        {
            var organizationRoleUserRepository = IoC.Resolve<IOrganizationRoleUserRepository>();
            var orgRoleUsers = organizationRoleUserRepository.GetOrganizationRoleUsersByOrganizationId(hospitalPartnerId);
            if (!orgRoleUsers.IsNullOrEmpty())
            {
                var userRepository = IoC.Resolve<IUserRepository<User>>();
                var users = userRepository.GetUsers(orgRoleUsers.Select(oru => oru.UserId).ToList());
                careCordinatorEmails = users.Where(u => u.Email != null && !string.IsNullOrEmpty(u.Email.ToString())).Select(u => u.Email.ToString()).ToArray();
            }
        }

        if (careCordinatorEmails != null && careCordinatorEmails.Any())
        {
            notifier.NotifySubscribersViaEmail(NotificationTypeAlias.CriticalCustomer, EmailTemplateAlias.CriticalCustomer, criticalCustomerNotificationModel, careCordinatorEmails, 0, organizationRoleUserId, "Critical Customer");
        }
        else
        {
            notifier.NotifySubscribersViaEmail(NotificationTypeAlias.CriticalCustomer, EmailTemplateAlias.CriticalCustomer, criticalCustomerNotificationModel, 0, organizationRoleUserId, "Critical Customer");
        }
    }

    [WebMethod(EnableSession = true)]
    public void DeleteCriticalData(long eventId, long customerId, long testId)
    {
        try
        {
            var criticalDataRepository = IoC.Resolve<ICustomerCriticalDataRepository>();
            criticalDataRepository.Delete(customerId, eventId, testId);

            ITestResultRepository testResultRepository = new TestResultRepository();
            testResultRepository.RemoveSelfPresent(eventId, customerId, testId);
        }
        catch (Exception ex)
        {
            var logger = IoC.Resolve<ILogManager>().GetLogger<Global>();
            logger.Info(string.Format("Error while deleteing Critical Data for EventId : {0} AND CustomerId : {1} AND TestId {2} . Message: {3}, \n\t Stack Trace: {4}", eventId, customerId, testId, ex.Message, ex.StackTrace));
            throw;
        }
    }

    [WebMethod(EnableSession = true)]
    public void DeletePriorityinQueueTestData(long eventId, long customerId, long testId, long modifiedByOrgRoleUserId)
    {
        try
        {
            var eventCustomerResultRepository = IoC.Resolve<IEventCustomerResultRepository>();
            var eventCustomerResult = eventCustomerResultRepository.GetByCustomerIdAndEventId(customerId, eventId);

            if (eventCustomerResult != null)
            {
                var priorityInQueueDataRepository = IoC.Resolve<ICustomerEventPriorityInQueueDataRepository>();
                priorityInQueueDataRepository.Delete(customerId, eventId, testId, modifiedByOrgRoleUserId);

                ITestResultRepository testResultRepository = new TestResultRepository();
                testResultRepository.RemovePriorityInQueue(eventId, customerId, testId);

                var priorityInQueueTests = priorityInQueueDataRepository.GetByEventCustomerResultId(eventCustomerResult.Id);
                if (priorityInQueueTests == null || !priorityInQueueTests.Any())
                {
                    var priorityInQueueService = IoC.Resolve<IPriorityInQueueService>();
                    priorityInQueueService.RemovePriorityInQueue(eventCustomerResult.Id, modifiedByOrgRoleUserId);
                }
            }

        }
        catch (Exception ex)
        {
            var logger = IoC.Resolve<ILogManager>().GetLogger<Global>();
            logger.Info(string.Format("Error while deleteing Pririty In Queue Data for EventId : {0} AND CustomerId : {1} AND TestId {2} . Message: {3}, \n\t Stack Trace: {4}", eventId, customerId, testId, ex.Message, ex.StackTrace));
            throw;
        }
    }

    private void SendUrgentMail(long eventId, long customerId, long eventcustomerResultId, IEnumerable<long> oldUrgentTestIds, long organizationRoleUserId)
    {
        try
        {
            var eventCustomerResultRepository = IoC.Resolve<IEventCustomerResultRepository>();
            var customerResultStatusViewModel = eventCustomerResultRepository.GetTestResultStatus(new[] { eventcustomerResultId }).First();

            var urgentTests = customerResultStatusViewModel.TestResults.Where(tr => !tr.IsCritical && tr.CriticalMarkedByPhysician).Select(tr => tr).ToArray();

            bool sendUrgentMail = false;
            if ((oldUrgentTestIds == null || !oldUrgentTestIds.Any()) && urgentTests.Count() > 0)
                sendUrgentMail = true;
            else
            {
                urgentTests = urgentTests.Where(ut => !oldUrgentTestIds.Contains(ut.TestId)).Select(ut => ut).ToArray();

                if (urgentTests.Any())
                    sendUrgentMail = true;
            }

            if (sendUrgentMail)
            {
                var emailNotificationModelsFactory = IoC.Resolve<IEmailNotificationModelsFactory>();
                var notifier = IoC.Resolve<INotifier>();
                var urgentCustomerNotificationModel = emailNotificationModelsFactory.GetUrgentCustomerNotificationModel(eventId, customerId, urgentTests);
                notifier.NotifySubscribersViaEmail(NotificationTypeAlias.UrgentCustomer, EmailTemplateAlias.UrgentCustomer, urgentCustomerNotificationModel, 0, organizationRoleUserId, "Urgent Customer");
            }
        }
        catch (Exception ex)
        {
            var logger = IoC.Resolve<ILogManager>().GetLogger<Global>();
            logger.Info(string.Format("Error while Sending Urgent mail for EventId : {0} AND CustomerId : {1} . Message: {2}, \n\t Stack Trace: {3}", eventId, customerId, ex.Message, ex.StackTrace));
        }
    }

    [WebMethod(EnableSession = true)]
    public PrimaryCarePhysicianEditModel GetPrimaryCarePhysicianEditModel(long customerId)
    {
        var primaryCarePhysicianHelper = IoC.Resolve<IPrimaryCarePhysicianHelper>();

        var pcpRepository = IoC.Resolve<PrimaryCarePhysicianRepository>();
        var pcp = pcpRepository.Get(customerId);
        PrimaryCarePhysicianEditModel pcpEditModel = null;

        if (pcp == null) return pcpEditModel;

        pcpEditModel = primaryCarePhysicianHelper.GetPrimaryCarePhysicianEditModel(customerId);
        return pcpEditModel;
    }

    [WebMethod(EnableSession = true)]
    public void SetPrimaryCarePhysician(PrimaryCarePhysicianEditModel model, long customerId)
    {
        try
        {
            var customerService = IoC.Resolve<ICustomerService>();
            var orgRoleUserId = IoC.Resolve<ISessionContext>().UserSession.CurrentOrganizationRole.OrganizationRoleUserId;

            customerService.SavePrimaryCarePhysician(model, customerId, orgRoleUserId);
        }
        catch (Exception ex)
        {
            var logger = IoC.Resolve<ILogManager>().GetLogger<Global>();
            logger.Info(string.Format("Error while updateing Primary Care Physician for  CustomerId : {0} . Message: {1}, \n\t Stack Trace: {2}", customerId, ex.Message, ex.StackTrace));
            throw;

        }


    }
    [WebMethod(EnableSession = true)]
    public EventCustomerResult GetFastingStatus(long customerId, long eventId)
    {
        var eventCustomerResultRepository = IoC.Resolve<IEventCustomerResultRepository>();
        return eventCustomerResultRepository.GetByCustomerIdAndEventId(customerId, eventId);
    }

    [WebMethod(EnableSession = true)]
    public EventCustomerStatusForResultEntryAndPreAudit CheckCustomerNoShowOrLeftWithoutScreening(long customerId, long eventId, bool isNewResultFlow)
    {
        var testResultService = IoC.Resolve<ITestResultService>();
        //var eventCustomerRepository = IoC.Resolve<IEventCustomerRepository>();
        //return eventCustomerRepository.IsCustomerNoShowOrLeftWithoutScreening(eventId, customerId);
        return testResultService.GetEventCustomerStatusForEntryAndAudit(customerId, eventId, isNewResultFlow);
    }

    [WebMethod(EnableSession = true)]
    public IEnumerable<long> GetRetestData(long customerId, long eventId)
    {
        var eventCustomerRetestRepository = IoC.Resolve<IEventCustomerRetestRepository>();
        var testIdsForRetest = eventCustomerRetestRepository.GetTestIdsByCustomerIdAndEventId(customerId, eventId);

        return testIdsForRetest;
    }

    private void SendReTestEmailNotification(long customerId, long eventId, long[] testIds)
    {
        var emailNotificationModelsFactory = IoC.Resolve<IEmailNotificationModelsFactory>();
        var notifier = IoC.Resolve<INotifier>();
        var reTestNotificationModel = emailNotificationModelsFactory.GetReTestNotificationViewModel(customerId, eventId, testIds);

        notifier.NotifySubscribersViaEmail(NotificationTypeAlias.ReTestNotification, EmailTemplateAlias.ReTestNotification, reTestNotificationModel, 0, 1, "Result PreAudit");
    }

    private void SendCriticalTestMail(long eventId, long customerId, long organizationRoleUserId, int resultState, long testId)
    {
        if (resultState <= (long)TestResultStateNumber.PreAudit)
            CriticalMail(customerId, eventId, organizationRoleUserId, testId);
    }

}


