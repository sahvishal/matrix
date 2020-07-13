using System.Collections.Generic;
using System.Linq;
using Falcon.App.Core.Application;
using Falcon.App.Core.Application.Attributes;
using Falcon.App.Core.Application.Extension;
using Falcon.App.Core.Enum;
using Falcon.App.Core.Extensions;
using Falcon.App.Core.InboundReport;
using Falcon.App.Core.InboundReport.ViewModels;
using Falcon.App.Core.Medical;
using Falcon.App.Core.Medical.Domain;
using Falcon.App.Core.Medical.Enum;
using Falcon.App.Core.OutboundReport.Domain;
using Falcon.App.Core.Scheduling.Domain;
using Falcon.App.Core.Users.Domain;
using Falcon.App.Infrastructure.Medical.Repositories;
using Falcon.App.Infrastructure.Repositories.Screening;
using Falcon.App.Infrastructure.Service;

namespace Falcon.App.Infrastructure.InboundReport.Impl
{
    [DefaultImplementation]
    public class LabsInboundReportFactory : ILabsInboundReportFactory
    {
        private readonly TestResultService _testResultService;
        private readonly BasicBiometricRepository _basicBiometricRepository;
        private readonly ISettings _settings;

        private const string ReplaceStringMale = "Male - ";
        private const string ReplaceStringFemale = "Female - ";

        private const string PositiveString = "Positive";
        private const string NegativeString = "Negative";
        private const string KitDistributedString = "Kit distributed";

        public LabsInboundReportFactory(ISettings settings)
        {
            _settings = settings;
            _testResultService = new TestResultService();
            _basicBiometricRepository = new BasicBiometricRepository();
        }

        public LabsInboundListModel Create(IEnumerable<CustomerEventTestState> eventTestStates, IEnumerable<CustomerEventScreeningTests> eventScreeningTests, IEnumerable<EventCustomer> eventCustomers, IEnumerable<Customer> customers,
            IEnumerable<ChaseOutbound> chaseOutbounds, IEnumerable<CustomerChaseCampaign> customerChaseCampaigns, IEnumerable<ChaseCampaign> chaseCampaigns, IEnumerable<Test> tests, IEnumerable<Event> events,
            IEnumerable<EventCustomerResult> eventCustomerResults)
        {
            var collection = new List<LabsInboundViewModel>();

            foreach (var eventTestState in eventTestStates)
            {
                var customerEventScreeningTest = eventScreeningTests.First(x => x.Id == eventTestState.CustomerEventScreeningTestId);

                if (customerEventScreeningTest.TestId == (long)TestType.DPN || customerEventScreeningTest.TestId == (long)TestType.eAWV || customerEventScreeningTest.TestId == (long)TestType.FocAttestation)
                    continue;

                var eventCustomer = eventCustomers.First(x => x.Id == customerEventScreeningTest.EventCustomerResultId);
                var eventCustomerResult = eventCustomerResults.First(x => x.Id == customerEventScreeningTest.EventCustomerResultId);

                var theEvent = events.First(x => x.Id == eventCustomer.EventId);
                var isNewResultFlow = theEvent.EventDate >= _settings.ResultFlowChangeDate;
                var customer = customers.First(x => x.CustomerId == eventCustomer.CustomerId);
                var chaseOutbound = chaseOutbounds.FirstOrDefault(x => x.CustomerId == customer.CustomerId);
                if (chaseOutbound == null) continue;
                var customerChaseCampaign = !customerChaseCampaigns.IsNullOrEmpty() ? customerChaseCampaigns.FirstOrDefault(x => x.CustomerId == customer.CustomerId) : null;
                var campaign = !chaseCampaigns.IsNullOrEmpty() && customerChaseCampaign != null ? chaseCampaigns.FirstOrDefault(x => x.Id == customerChaseCampaign.ChaseCampaignId) : null;

                var test = tests.First(x => x.Id == customerEventScreeningTest.TestId);

                var labInboundViewModel = new LabsInboundViewModel
                {
                    TenantId = chaseOutbound.TenantId,
                    ClientId = chaseOutbound.ClientId,
                    CampaignId = campaign != null ? campaign.CampaignId : "",
                    IndividualIDNumber = chaseOutbound.IndividualId,
                    ContractNumber = chaseOutbound.ContractNumber,
                    ContractPersonNumber = chaseOutbound.ContractPersonNumber,
                    ConsumerId = chaseOutbound.ConsumerId,
                    VendorPersonId = customer.CustomerId.ToString(),
                    LabType = TestAbbreviation(test.Id, test.Name),
                    LabDate = theEvent.EventDate,
                    LabResult = "",
                    LabAction = eventCustomerResult.RegenerationDate != null ? "Update" : "Insert"
                };

                if (customerEventScreeningTest.TestId == (long)TestType.Lead || customerEventScreeningTest.TestId == (long)TestType.Monofilament)
                {
                    var leftModel = ObjectCloneExtension.Clone(labInboundViewModel);
                    leftModel = SetLabResults(leftModel, eventCustomer.CustomerId, eventCustomer.EventId, test.Id, isNewResultFlow, true);

                    if (!string.IsNullOrWhiteSpace(leftModel.LabResult))
                        collection.Add(leftModel);
                }

                labInboundViewModel = SetLabResults(labInboundViewModel, eventCustomer.CustomerId, eventCustomer.EventId, test.Id, isNewResultFlow);

                if (!string.IsNullOrWhiteSpace(labInboundViewModel.LabResult))
                    collection.Add(labInboundViewModel);
            }

            return new LabsInboundListModel
            {
                Collection = collection
            };
        }

        private string TestAbbreviation(long id, string testName)
        {
            string testAbbreviation;
            switch (id)
            {
                case (long)LabInboundTestType.Echo:
                    testAbbreviation = EnumExtension.GetDescription(LabInboundTestType.Echo);
                    break;

                case (long)LabInboundTestType.A1C:
                    testAbbreviation = EnumExtension.GetDescription(LabInboundTestType.A1C);
                    break;

                case (long)LabInboundTestType.LipidPanel:
                    testAbbreviation = EnumExtension.GetDescription(LabInboundTestType.LipidPanel);
                    break;

                case (long)LabInboundTestType.Ekg:
                    testAbbreviation = EnumExtension.GetDescription(LabInboundTestType.Ekg);
                    break;

                case (long)LabInboundTestType.DiabeticRetinopathy:
                    testAbbreviation = EnumExtension.GetDescription(LabInboundTestType.DiabeticRetinopathy);
                    break;

                case (long)LabInboundTestType.Lead:
                    testAbbreviation = EnumExtension.GetDescription(LabInboundTestType.Lead);
                    break;

                case (long)LabInboundTestType.CarotidArteryUltrasound:
                    testAbbreviation = EnumExtension.GetDescription(LabInboundTestType.CarotidArteryUltrasound);
                    break;

                case (long)LabInboundTestType.UrineMicroalbumin:
                    testAbbreviation = EnumExtension.GetDescription(LabInboundTestType.UrineMicroalbumin);
                    break;

                case (long)LabInboundTestType.PneumococcalVaccine:
                    testAbbreviation = EnumExtension.GetDescription(LabInboundTestType.PneumococcalVaccine);
                    break;

                case (long)LabInboundTestType.FluShot:
                    testAbbreviation = EnumExtension.GetDescription(LabInboundTestType.FluShot);
                    break;

                case (long)LabInboundTestType.AwvFluShot:
                    testAbbreviation = EnumExtension.GetDescription(LabInboundTestType.AwvFluShot);
                    break;

                case (long)LabInboundTestType.BoneDensity:
                    testAbbreviation = EnumExtension.GetDescription(LabInboundTestType.BoneDensity);
                    break;

                case (long)LabInboundTestType.AwvAbi:
                    testAbbreviation = EnumExtension.GetDescription(LabInboundTestType.AwvAbi);
                    break;

                case (long)LabInboundTestType.MammographyTest:
                    testAbbreviation = EnumExtension.GetDescription(LabInboundTestType.MammographyTest);
                    break;

                case (long)LabInboundTestType.ScreeningMammographyDigital:
                    testAbbreviation = EnumExtension.GetDescription(LabInboundTestType.ScreeningMammographyDigital);
                    break;

                case (long)LabInboundTestType.Aaa:
                    testAbbreviation = EnumExtension.GetDescription(LabInboundTestType.Aaa);
                    break;

                case (long)LabInboundTestType.AwvSpirometry:
                    testAbbreviation = EnumExtension.GetDescription(LabInboundTestType.AwvSpirometry);
                    break;

                case (long)LabInboundTestType.BloodPressure:
                    testAbbreviation = EnumExtension.GetDescription(LabInboundTestType.BloodPressure);
                    break;

                case (long)LabInboundTestType.AwvAaa:
                    testAbbreviation = EnumExtension.GetDescription(LabInboundTestType.AwvAaa);
                    break;

                case (long)LabInboundTestType.Ifobt:
                    testAbbreviation = EnumExtension.GetDescription(LabInboundTestType.Ifobt);
                    break;

                case (long)LabInboundTestType.Monofilament:
                    testAbbreviation = EnumExtension.GetDescription(LabInboundTestType.Monofilament);
                    break;

                case (long)LabInboundTestType.QuantaFloAbi:
                    testAbbreviation = EnumExtension.GetDescription(LabInboundTestType.QuantaFloAbi);
                    break;

                default:
                    testAbbreviation = testName;
                    break;
            }

            return testAbbreviation;
        }

        private LabsInboundViewModel SetLabResults(LabsInboundViewModel model, long customerId, long eventId, long testId, bool isNewResultFlow, bool getLeftReadings = false)
        {
            var isTestPurchased = false;
            ITestResultRepository testResultRepository;

            if (testId == (long)LabInboundTestType.Echo)
            {
                isTestPurchased = _testResultService.IsTestPurchasedByCustomer(eventId, customerId, (long)TestType.AwvEcho);
                if (isTestPurchased)
                {
                    testResultRepository = new AwvEchocardiogramTestRepository();
                    var awvEchoTestResult = testResultRepository.GetTestResults(customerId, eventId, isNewResultFlow);
                    if (awvEchoTestResult != null && (awvEchoTestResult.TestNotPerformed == null || awvEchoTestResult.TestNotPerformed.TestNotPerformedReasonId <= 0))
                    {
                        var result = awvEchoTestResult as AwvEchocardiogramTestResult;
                        if (result != null && result.Finding != null)
                            model.LabResult = result.Finding.Label;
                    }
                }
            }

            else if (testId == (long)LabInboundTestType.A1C)
            {
                isTestPurchased = _testResultService.IsTestPurchasedByCustomer(eventId, customerId, (long)TestType.AwvHBA1C);
                if (isTestPurchased)
                {
                    testResultRepository = new AwvHemaglobinTestRepository();
                    var awvHemaglobinTestResult = testResultRepository.GetTestResults(customerId, eventId, isNewResultFlow);
                    if (awvHemaglobinTestResult != null && (awvHemaglobinTestResult.TestNotPerformed == null || awvHemaglobinTestResult.TestNotPerformed.TestNotPerformedReasonId <= 0))
                    {
                        var result = awvHemaglobinTestResult as AwvHemaglobinTestResult;
                        if (result != null && result.Hba1c != null)
                            model.LabResult = result.Hba1c.Reading;
                    }
                }
            }

            else if (testId == (long)LabInboundTestType.Ekg)
            {
                isTestPurchased = _testResultService.IsTestPurchasedByCustomer(eventId, customerId, (long)TestType.AwvEkg);
                if (isTestPurchased)
                {
                    testResultRepository = new AwvEkgTestRepository();
                    var awvEkgTestResult = testResultRepository.GetTestResults(customerId, eventId, isNewResultFlow);
                    if (awvEkgTestResult != null && (awvEkgTestResult.TestNotPerformed == null || awvEkgTestResult.TestNotPerformed.TestNotPerformedReasonId <= 0))
                    {
                        var result = awvEkgTestResult as AwvEkgTestResult;
                        if (result != null && result.Finding != null)
                            model.LabResult = result.Finding.Label;
                    }
                }
            }

            //FL Blue asked us to Leave the Test with blank result field
            /*else if (testId == (long)LabInboundTestType.DiabeticRetinopathy)
            {
                isTestPurchased = _testResultService.IsTestPurchasedByCustomer(eventId, customerId, (long)TestType.DiabeticRetinopathy);
                if (isTestPurchased)
                {
                    testResultRepository = new DiabeticRetinopathyTestRepository();
                    var diabeticRetinopathyTestResult = testResultRepository.GetTestResults(customerId, eventId, isNewResultFlow);
                    if (diabeticRetinopathyTestResult != null && (diabeticRetinopathyTestResult.TestNotPerformed == null || diabeticRetinopathyTestResult.TestNotPerformed.TestNotPerformedReasonId <= 0))
                    {
                        var result = diabeticRetinopathyTestResult as DiabeticRetinopathyTestResult;
                        if (result != null && result.Finding != null)
                            model.LabResult = result.Finding.Label;
                    }
                }
            }*/

            else if (testId == (long)LabInboundTestType.UrineMicroalbumin)
            {
                isTestPurchased = _testResultService.IsTestPurchasedByCustomer(eventId, customerId, (long)TestType.UrineMicroalbumin);
                if (isTestPurchased)
                {
                    testResultRepository = new UrineMicroalbuminTestRepository();
                    var urineMicroalbuminTestResult = testResultRepository.GetTestResults(customerId, eventId, isNewResultFlow);
                    if (urineMicroalbuminTestResult != null && (urineMicroalbuminTestResult.TestNotPerformed == null || urineMicroalbuminTestResult.TestNotPerformed.TestNotPerformedReasonId <= 0))
                    {
                        var result = urineMicroalbuminTestResult as UrineMicroalbuminTestResult;
                        if (result != null && result.MicroalbuminValue != null)
                            model.LabResult = result.MicroalbuminValue.Reading;
                        else
                            model.LabResult = KitDistributedString;

                    }
                }
            }

            else if (testId == (long)LabInboundTestType.AwvAbi)
            {
                isTestPurchased = _testResultService.IsTestPurchasedByCustomer(eventId, customerId, (long)TestType.AwvABI);
                if (isTestPurchased)
                {
                    testResultRepository = new AwvAbiTestRepository();
                    var awvAbiTestResult = testResultRepository.GetTestResults(customerId, eventId, isNewResultFlow);
                    if (awvAbiTestResult != null && (awvAbiTestResult.TestNotPerformed == null || awvAbiTestResult.TestNotPerformed.TestNotPerformedReasonId <= 0))
                    {
                        var result = awvAbiTestResult as AwvAbiTestResult;
                        if (result != null && result.Finding != null)
                            model.LabResult = result.Finding.Label;
                    }
                }
            }

            else if (testId == (long)LabInboundTestType.ScreeningMammographyDigital)
            {
                isTestPurchased = _testResultService.IsTestPurchasedByCustomer(eventId, customerId, (long)TestType.Mammogram);
                if (isTestPurchased)
                {
                    testResultRepository = new MammogramTestRepository();
                    var mammogramTestResult = testResultRepository.GetTestResults(customerId, eventId, isNewResultFlow);
                    if (mammogramTestResult != null && (mammogramTestResult.TestNotPerformed == null || mammogramTestResult.TestNotPerformed.TestNotPerformedReasonId <= 0))
                    {
                        var result = mammogramTestResult as MammogramTestResult;
                        if (result != null && result.Finding != null && !string.IsNullOrWhiteSpace(result.Finding.Label))
                            model.LabResult = "BIRAD-" + result.Finding.Label.Substring(0, 1);
                    }
                }
            }

            else if (testId == (long)LabInboundTestType.AwvSpirometry)
            {
                isTestPurchased = _testResultService.IsTestPurchasedByCustomer(eventId, customerId, (long)TestType.AwvSpiro);
                if (isTestPurchased)
                {
                    testResultRepository = new AwvSpiroTestRepository();
                    var awvSpiroTestResult = testResultRepository.GetTestResults(customerId, eventId, isNewResultFlow);
                    if (awvSpiroTestResult != null && (awvSpiroTestResult.TestNotPerformed == null || awvSpiroTestResult.TestNotPerformed.TestNotPerformedReasonId <= 0))
                    {
                        var result = awvSpiroTestResult as AwvSpiroTestResult;
                        if (result != null && result.Finding != null)
                            model.LabResult = result.Finding.Label;
                    }
                }
            }

            else if (testId == (long)LabInboundTestType.BloodPressure)
            {
                isTestPurchased = _testResultService.IsTestPurchasedByCustomer(eventId, customerId, (long)TestType.Hypertension);
                if (isTestPurchased)
                {
                    testResultRepository = new HypertensionTestRepository();
                    var hyperTenstionTestResult = testResultRepository.GetTestResults(customerId, eventId, isNewResultFlow);
                    if (hyperTenstionTestResult != null && (hyperTenstionTestResult.TestNotPerformed == null || hyperTenstionTestResult.TestNotPerformed.TestNotPerformedReasonId <= 0))
                    {
                        var basicBiometric = _basicBiometricRepository.Get(eventId, customerId);
                        if (basicBiometric != null)
                            model.LabResult = (basicBiometric.SystolicPressure.HasValue ? basicBiometric.SystolicPressure.Value.ToString() : "0") + "/" + (basicBiometric.DiastolicPressure.HasValue ? basicBiometric.DiastolicPressure.Value.ToString() : "0");
                    }
                }
            }

            else if (testId == (long)LabInboundTestType.AwvAaa)
            {
                isTestPurchased = _testResultService.IsTestPurchasedByCustomer(eventId, customerId, (long)TestType.AwvAAA);
                if (isTestPurchased)
                {
                    testResultRepository = new AwvAaaTestRepository();
                    var awvAaaTestResult = testResultRepository.GetTestResults(customerId, eventId, isNewResultFlow);
                    if (awvAaaTestResult != null && (awvAaaTestResult.TestNotPerformed == null || awvAaaTestResult.TestNotPerformed.TestNotPerformedReasonId <= 0))
                    {
                        var result = awvAaaTestResult as AwvAaaTestResult;
                        if (result != null && result.Finding != null)
                            model.LabResult = result.Finding.Label;
                    }
                }
            }

            else if (testId == (long)LabInboundTestType.Ifobt)
            {
                isTestPurchased = _testResultService.IsTestPurchasedByCustomer(eventId, customerId, (long)TestType.IFOBT);
                if (isTestPurchased)
                {
                    testResultRepository = new IFOBTTestRepository();
                    var ifobtTestResult = testResultRepository.GetTestResults(customerId, eventId, isNewResultFlow);
                    if (ifobtTestResult != null && (ifobtTestResult.TestNotPerformed == null || ifobtTestResult.TestNotPerformed.TestNotPerformedReasonId <= 0))
                    {
                        var result = ifobtTestResult as IFOBTTestResult;
                        if (result != null && result.Finding != null && !string.IsNullOrWhiteSpace(result.Finding.Label) && (result.Finding.Label.ToLower() == PositiveString.ToLower() ||
                             result.Finding.Label.ToLower() == NegativeString.ToLower()))
                        {
                            model.LabResult = result.Finding.Label;
                        }
                        else
                        {
                            model.LabResult = KitDistributedString;
                        }
                    }
                }
            }

            else if (testId == (long)LabInboundTestType.Lead)
            {
                isTestPurchased = _testResultService.IsTestPurchasedByCustomer(eventId, customerId, (long)TestType.Lead);
                if (isTestPurchased)
                {
                    testResultRepository = new LeadTestRepository();
                    var leadTestResult = testResultRepository.GetTestResults(customerId, eventId, isNewResultFlow);
                    if (leadTestResult != null && (leadTestResult.TestNotPerformed == null || leadTestResult.TestNotPerformed.TestNotPerformedReasonId <= 0))
                    {
                        var result = leadTestResult as LeadTestResult;
                        if (result != null)
                        {
                            var readings = testResultRepository.GetAllReadings((int)TestType.Lead);
                            var readingLabels = new List<string>();
                            if (getLeftReadings)
                            {
                                model.LabType = EnumExtension.GetDescription(LabInboundTestType.Lead) + " L";
                                if (result.LeftResultReadings != null)
                                {
                                    var leftResultReadings = result.LeftResultReadings;

                                    if (leftResultReadings.NoVisualPlaque != null && leftResultReadings.NoVisualPlaque.Reading != null)
                                    {
                                        var reading = readings.First(x => x.Label == ReadingLabels.LeftNoVisualPlaque);
                                        readingLabels.Add(reading.LableText);
                                    }

                                    if (leftResultReadings.VisuallyDemonstratedPlaque != null && leftResultReadings.VisuallyDemonstratedPlaque.Reading != null)
                                    {
                                        var reading = readings.First(x => x.Label == ReadingLabels.LeftVisuallyDemonstratedPlaque);
                                        readingLabels.Add(reading.LableText);
                                    }

                                    if (leftResultReadings.ModerateStenosis != null && leftResultReadings.ModerateStenosis.Reading != null)
                                    {
                                        var reading = readings.First(x => x.Label == ReadingLabels.LeftModerateStenosis);
                                        readingLabels.Add(reading.LableText);
                                    }

                                    if (leftResultReadings.PossibleOcclusion != null && leftResultReadings.PossibleOcclusion.Reading != null)
                                    {
                                        var reading = readings.First(x => x.Label == ReadingLabels.LeftPossibleOcclusion);
                                        readingLabels.Add(reading.LableText);
                                    }
                                }
                            }
                            else
                            {
                                model.LabType = EnumExtension.GetDescription(LabInboundTestType.Lead) + " R";
                                if (result.RightResultReadings != null)
                                {
                                    var rightResultReading = result.RightResultReadings;

                                    if (rightResultReading.NoVisualPlaque != null && rightResultReading.NoVisualPlaque.Reading != null)
                                    {
                                        var reading = readings.First(x => x.Label == ReadingLabels.RightNoVisualPlaque);
                                        readingLabels.Add(reading.LableText);
                                    }

                                    if (rightResultReading.VisuallyDemonstratedPlaque != null && rightResultReading.VisuallyDemonstratedPlaque.Reading != null)
                                    {
                                        var reading = readings.First(x => x.Label == ReadingLabels.RightVisuallyDemonstratedPlaque);
                                        readingLabels.Add(reading.LableText);
                                    }

                                    if (rightResultReading.ModerateStenosis != null && rightResultReading.ModerateStenosis.Reading != null)
                                    {
                                        var reading = readings.First(x => x.Label == ReadingLabels.RightModerateStenosis);
                                        readingLabels.Add(reading.LableText);
                                    }

                                    if (rightResultReading.PossibleOcclusion != null && rightResultReading.PossibleOcclusion.Reading != null)
                                    {
                                        var reading = readings.First(x => x.Label == ReadingLabels.RightPossibleOcclusion);
                                        readingLabels.Add(reading.LableText);
                                    }
                                }
                            }

                            model.LabResult = string.Join(", ", readingLabels);
                        }
                    }
                }
            }

            else if (testId == (long)LabInboundTestType.Monofilament)
            {
                isTestPurchased = _testResultService.IsTestPurchasedByCustomer(eventId, customerId, (long)TestType.Monofilament);
                if (isTestPurchased)
                {
                    testResultRepository = new MonofilamentTestRepository();
                    var monofilamentTestResult = testResultRepository.GetTestResults(customerId, eventId, isNewResultFlow);
                    if (monofilamentTestResult != null && (monofilamentTestResult.TestNotPerformed == null || monofilamentTestResult.TestNotPerformed.TestNotPerformedReasonId <= 0))
                    {
                        var result = monofilamentTestResult as MonofilamentTestResult;
                        if (result != null)
                        {
                            var readings = testResultRepository.GetAllReadings((int)TestType.Monofilament);
                            if (getLeftReadings)
                            {
                                model.LabType = EnumExtension.GetDescription(LabInboundTestType.Monofilament) + " L";
                                if (result.LeftPositive != null)
                                {
                                    var reading = readings.First(x => x.Label == ReadingLabels.MonofilamentLeftFootSensationIntact);
                                    model.LabResult = reading.LableText;
                                }
                                else if (result.LeftNegative != null)
                                {
                                    var reading = readings.First(x => x.Label == ReadingLabels.MonofilamentLeftFootSensationNotIntact);
                                    model.LabResult = reading.LableText;
                                }
                            }
                            else
                            {
                                model.LabType = EnumExtension.GetDescription(LabInboundTestType.Monofilament) + " R";
                                if (result.RightPositive != null)
                                {
                                    var reading = readings.First(x => x.Label == ReadingLabels.MonofilamentRightFootSensationIntact);
                                    model.LabResult = reading.LableText;
                                }
                                else if (result.RightNegative != null)
                                {
                                    var reading = readings.First(x => x.Label == ReadingLabels.MonofilamentRightFootSensationNotIntact);
                                    model.LabResult = reading.LableText;
                                }
                            }
                        }
                    }
                }
            }

            else if (testId == (long)LabInboundTestType.QuantaFloAbi)
            {
                isTestPurchased = _testResultService.IsTestPurchasedByCustomer(eventId, customerId, (long)TestType.QuantaFloABI);
                if (isTestPurchased)
                {
                    testResultRepository = new QuantaFloABITestRepository();
                    var quantaFloAbiTestResult = testResultRepository.GetTestResults(customerId, eventId, isNewResultFlow);
                    if (quantaFloAbiTestResult != null && (quantaFloAbiTestResult.TestNotPerformed == null || quantaFloAbiTestResult.TestNotPerformed.TestNotPerformedReasonId <= 0))
                    {
                        var result = quantaFloAbiTestResult as QuantaFloABITestResult;
                        if (result != null && result.Finding != null)
                        {
                            model.LabResult = result.Finding.Label;
                        }
                    }
                }
            }

            return model;
        }
    }
}
