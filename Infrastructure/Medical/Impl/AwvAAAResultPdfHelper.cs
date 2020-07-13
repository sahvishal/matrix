using Falcon.App.Core;
using Falcon.App.Core.Application;
using Falcon.App.Core.Application.Attributes;
using Falcon.App.Core.Interfaces;
using Falcon.App.Core.Medical;
using Falcon.App.Core.Medical.Domain;
using Falcon.App.Core.Medical.Enum;
using Falcon.App.Core.Medical.Interfaces;
using Falcon.App.Core.Medical.ViewModels;
using Falcon.App.Core.Operations.Domain;
using Falcon.App.Infrastructure.Repositories.Screening;
using HtmlAgilityPack;
using System.Collections.Generic;
using System.Linq;

namespace Falcon.App.Infrastructure.Medical.Impl
{
    [DefaultImplementation]
    public class AwvAAAResultPdfHelper : IAwvAAAResultPdfHelper
    {
        private readonly ISettings _settings;
        private readonly IResultPdfHelper _resultPdfHelper;
        private readonly IStandardFindingRepository _standardFindingRepository;
        private readonly IEventCustomerResultRepository _eventCustomerResultRepository;
        private IIncidentalFindingRepository _incidentalFindingRepository;
        private Service.TestResultService _testResultService;

        public AwvAAAResultPdfHelper(ISettings settings, IResultPdfHelper resultPdfHelper, IStandardFindingRepository standardFindingRepository,
            IEventCustomerResultRepository eventCustomerResultRepository, IIncidentalFindingRepository incidentalFindingRepository)
        {
            _settings = settings;
            _resultPdfHelper = resultPdfHelper;
            _standardFindingRepository = standardFindingRepository;
            _eventCustomerResultRepository = eventCustomerResultRepository;
            _incidentalFindingRepository = incidentalFindingRepository;
            _testResultService = new Service.TestResultService();
        }

        public void LoadAwvAaaTestresults(HtmlDocument doc, long eventId, long customerId, AwvAaaTestResult testResult, bool removeLongDescription,
            List<OrderedPair<long, string>> technicianIdNamePairs, bool loadImages, IEnumerable<CustomerScreeningEvaluatinPhysicianViewModel> physicians,
            IEnumerable<EventPhysicianTest> eventPhysicianTests, bool showUnreadableTest, IEnumerable<PhysicianEvaluation> eventCustomerPhysicianEvaluation,
            CustomerSkipReview customerSkipReview)
        {
            var incidentalFindings = _incidentalFindingRepository.GetAllIncidentalFinding((int)TestType.AwvAAA);
            if (testResult != null)
            {
                var selectedNode = doc.DocumentNode.SelectSingleNode("//div[@id='AwvAaa-rpp-section']");
                if (selectedNode != null && (testResult.UnableScreenReason == null || testResult.UnableScreenReason.Count == 0) && (testResult.TestNotPerformed == null || testResult.TestNotPerformed.TestNotPerformedReasonId <= 0)
                    && (showUnreadableTest || testResult.RepeatStudy == null || testResult.RepeatStudy.Reading == false))
                    selectedNode.SetAttributeValue("style", "display:block;");

                selectedNode = doc.DocumentNode.SelectSingleNode("//div[@id='rpp-eus-AwvAaa-div']");
                if (selectedNode != null)
                    selectedNode.SetAttributeValue("style", "display:block;");

                _resultPdfHelper.SetPhysicianSignature(doc, "AwvAaa-primaryEvalPhysicianSign", "AwvAaa-overreadEvalPhysicianSign", physicians, eventPhysicianTests, eventCustomerPhysicianEvaluation, customerSkipReview);

                var readings = new TestResultRepository().GetAllReadings((int)TestType.AwvAAA);

                foreach (var resultReading in readings)
                {
                    switch (resultReading.Label)
                    {
                        case ReadingLabels.AortaSize:
                            _resultPdfHelper.SetInputBox(doc, "AwvAaaAortaSizeInputText", testResult.AortaSize);
                            _resultPdfHelper.SetInputBox(doc, "aortasize-AwvAaa-summary", testResult.AortaSize);
                            break;

                        case ReadingLabels.TransverseViewDataPointOne:
                            if (testResult.TransverseView != null)
                                _resultPdfHelper.SetInputBox(doc, "AwvAaaTVDatapointOneTextbox", testResult.TransverseView.FirstValue);
                            break;

                        case ReadingLabels.TransverseViewDataPointTwo:
                            if (testResult.TransverseView != null)
                                _resultPdfHelper.SetInputBox(doc, "AwvAaaTVDatapointTwoTextbox", testResult.TransverseView.SecondValue);
                            break;

                        case ReadingLabels.AorticDissection:
                            _resultPdfHelper.SetCheckBox(doc, "AwvAaaAorticDissectionCheckbox", testResult.AorticDissection);
                            break;

                        case ReadingLabels.Plaque:
                            _resultPdfHelper.SetCheckBox(doc, "AwvAaaPlaqueCheckbox", testResult.Plaque);
                            break;

                        case ReadingLabels.Thrombus:
                            _resultPdfHelper.SetCheckBox(doc, "AwvAaaThrombusCheckbox", testResult.Thrombus);
                            break;

                        case ReadingLabels.TechnicallyLimitedbutReadable:
                            _resultPdfHelper.SetCheckBox(doc, "TechnicallyLimitedbutReadableAwvAaaInputCheck", testResult.TechnicallyLimitedbutReadable);
                            break;

                        case ReadingLabels.RepeatStudy:
                            _resultPdfHelper.SetCheckBox(doc, "RepeatStudyAwvAaaInputCheck", testResult.RepeatStudy);
                            break;

                        case ReadingLabels.PeakSystolicVelocity:
                            if (testResult.PeakSystolicVelocity != null)
                                _resultPdfHelper.SetInputBox(doc, "AwvAaaPeakSystolicVelocityTextbox", testResult.PeakSystolicVelocity);
                            break;
                        case ReadingLabels.ResidualLumenTransverseViewDataPointOne:
                            if (testResult.ResidualLumenStandardFindings != null)
                                _resultPdfHelper.SetInputBox(doc, "AwvAaaResidualLumenTVDatapointOneTextbox", testResult.ResidualLumenStandardFindings.FirstValue);
                            break;
                        case ReadingLabels.ResidualLumenTransverseViewDataPointTwo:
                            if (testResult.ResidualLumenStandardFindings != null)
                                _resultPdfHelper.SetInputBox(doc, "AwvAaaResidualLumenTVDatapointTwoTextbox", testResult.ResidualLumenStandardFindings.SecondValue);
                            break;
                    }
                }

                var maxAortaSize = GetMaxofthreeAwvAaaAortaValues(testResult);
                //TODO: This is a hack for U Screen Text on AAA Summary
                LoadAwvAaaFindings(doc, eventId, customerId, testResult.Finding, testResult.AortaRangeSaggitalView, testResult.AortaRangeTransverseView, maxAortaSize, true, (testResult.UnableScreenReason != null && testResult.UnableScreenReason.Count > 0 && testResult.UnableScreenReason.Count(us => us.Reason == UnableToScreenReason.UnableToTechnicallyVisualize) < 1 ? testResult.UnableScreenReason.First() : null), testResult.PeakSystolicVelocityStandardFindings);
                _resultPdfHelper.SetUnableToScreenReasons(doc, TestType.AwvAAA, "AwvAaaUnableToScreen", testResult.UnableScreenReason);
                _resultPdfHelper.SetTechnician(doc, testResult, "techAwvAaa", "technotesAwvAaa", technicianIdNamePairs);
                _resultPdfHelper.SetPhysicianRemarks(doc, testResult, "followUpAwvAaa", "criticalAwvAaa", "physicianRemarksAwvAaa");
                _resultPdfHelper.LoadTestMedia(doc, testResult.ResultImages, "testmedia-AwvAaa", loadImages);
                _resultPdfHelper.SetIncidentalFindings(doc, incidentalFindings, testResult.IncidentalFindings, "AwvAaaIncidenatlFindings");

                if (testResult.IncidentalFindings != null && testResult.IncidentalFindings.Any())
                {
                    selectedNode = doc.DocumentNode.SelectSingleNode("//p[@id='incidentalfinding-description-AwvAaa']");
                    if (selectedNode != null) selectedNode.SetAttributeValue("style", "display:block;");
                }

                selectedNode = doc.DocumentNode.SelectSingleNode("//div[@id='AwvAaa-longdescription-div']");
                if (selectedNode != null)
                    selectedNode.SetAttributeValue("style", removeLongDescription ? "display:none" : "display:block");
            }
            else
            {
                _resultPdfHelper.SetIncidentalFindings(doc, incidentalFindings, null, "AwvAaaIncidenatlFindings");
                _resultPdfHelper.SetUnableToScreenReasons(doc, TestType.AwvAAA, "AwvAaaUnableToScreen", null);
                LoadAwvAaaFindings(doc, eventId, customerId, null, null, null, null, false);
            }
        }

        private void LoadAwvAaaFindings(HtmlDocument doc, long eventId, long customerId, StandardFinding<decimal?> finding = null, IEnumerable<StandardFinding<int>> aortaRangeSaggitalView = null, IEnumerable<StandardFinding<int>> aortaRangeTransverseView = null, decimal? maxAortaSize = null, bool isTestPurchased = true, UnableScreenReason unableScreenReason = null, IEnumerable<StandardFinding<int>> peakSystolicVelocityStandardFindings = null)
        {
            List<StandardFinding<decimal?>> standardFindingList;
            if (_settings.AwvAaaFindingChangeDate.HasValue)
            {
                var eventCustomerResult = _eventCustomerResultRepository.GetByCustomerIdAndEventId(customerId, eventId);
                if (eventCustomerResult != null && eventCustomerResult.DataRecorderMetaData.DateCreated < _settings.AwvAaaFindingChangeDate.Value)
                {
                    standardFindingList = _standardFindingRepository.GetAllStandardFindings<decimal?>((int)TestType.AwvAAA, (int)ReadingLabels.AortaSize, _settings.AwvAaaFindingChangeDate.Value, true);
                }
                else
                {
                    standardFindingList = _standardFindingRepository.GetAllStandardFindings<decimal?>((int)TestType.AwvAAA, (int)ReadingLabels.AortaSize, _settings.AwvAaaFindingChangeDate.Value, false);
                }
            }
            else
            {
                standardFindingList = _standardFindingRepository.GetAllStandardFindings<decimal?>((int)TestType.AwvAAA, (int)ReadingLabels.AortaSize);
            }


            StandardFinding<decimal?> findingForLongDescription = null;
            if (maxAortaSize.HasValue)
            {
                var findingId = _testResultService.GetCalculatedStandardFinding(eventId, customerId, maxAortaSize, (int)TestType.AwvAAA, (int)ReadingLabels.AortaSize);
                if (findingId > 0)
                    findingForLongDescription = standardFindingList.SingleOrDefault(sf => sf.Id == findingId);
            }

            _resultPdfHelper.SetSummaryFindings(doc, finding, standardFindingList, "FindingsAwvAaaDiv", "long-description-AwvAaa", findingForLongDescription, isTestPurchased, unableScreenReason);
            _resultPdfHelper.SetFindingsVertical(doc, finding, standardFindingList, "AwvAaaFinding");

            if (finding != null)
            {
                var stdFinding = standardFindingList.Single(f => f.Id == finding.Id);

                var selectedNode = doc.DocumentNode.SelectSingleNode("//span[@id='AwvAaa-rpp-resultspan']");
                if (selectedNode != null)
                    selectedNode.InnerHtml = stdFinding.Label;

                selectedNode = doc.DocumentNode.SelectSingleNode("//div[@id='docletter-AwvAaa']");
                if (stdFinding.ResultInterpretation != null && stdFinding.ResultInterpretation.Value != (long)ResultInterpretation.Normal && selectedNode != null)
                    selectedNode.SetAttributeValue("style", "display:block;");
            }

            var sViewStandardFindingList = _standardFindingRepository.GetAllStandardFindings<int>((int)TestType.AwvAAA, (int)ReadingLabels.AortaRangeSaggitalView);
            _resultPdfHelper.SetFindingsHorizontal(doc, aortaRangeSaggitalView, sViewStandardFindingList, "AwvAaaSagitalView");

            var tViewStandardFindingList = _standardFindingRepository.GetAllStandardFindings<int>((int)TestType.AwvAAA, (int)ReadingLabels.AortaRangeTransverseView);
            _resultPdfHelper.SetFindingsHorizontal(doc, aortaRangeTransverseView, tViewStandardFindingList, "AwvAaaTransverseView");

            var peakSystolicVelocityStandardFindingsList = _standardFindingRepository.GetAllStandardFindings<int>((int)TestType.AwvAAA, (int)ReadingLabels.PeakSystolicVelocitySaggitalView);
            _resultPdfHelper.SetFindingsHorizontal(doc, peakSystolicVelocityStandardFindings, peakSystolicVelocityStandardFindingsList, "AwvAaaPeakSystolicVelocityStandardFindings");
        }

        private decimal? GetMaxofthreeAwvAaaAortaValues(AwvAaaTestResult testResult)
        {
            if (testResult == null) return null;

            var aortaValues = new decimal[3];
            int index = 0;

            if (testResult.AortaSize != null && testResult.AortaSize.Reading != null)
                aortaValues[index++] = testResult.AortaSize.Reading.Value;

            if (testResult.TransverseView != null)
            {
                if (testResult.TransverseView.FirstValue != null && testResult.TransverseView.FirstValue.Reading != null)
                    aortaValues[index++] = testResult.TransverseView.FirstValue.Reading.Value;

                if (testResult.TransverseView.SecondValue != null && testResult.TransverseView.SecondValue.Reading != null)
                    aortaValues[index++] = testResult.TransverseView.SecondValue.Reading.Value;
            }

            var aortaValue = aortaValues.Max();
            if (aortaValue > 0) return aortaValue;

            return null;
        }
    }
}
