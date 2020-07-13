using Falcon.App.Core;
using Falcon.App.Core.Application;
using Falcon.App.Core.Application.Attributes;
using Falcon.App.Core.Interfaces;
using Falcon.App.Core.Medical;
using Falcon.App.Core.Medical.Domain;
using Falcon.App.Core.Medical.Enum;
using Falcon.App.Core.Medical.ViewModels;
using Falcon.App.Core.Operations.Domain;
using Falcon.App.Infrastructure.Repositories.Screening;
using HtmlAgilityPack;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Falcon.App.Infrastructure.Medical.Impl
{
    [DefaultImplementation]
    public class LeadResultPdfHelper : ILeadResultPdfHelper
    {
        private readonly ISettings _settings;
        private readonly IResultPdfHelper _resultPdfHelper;
        private readonly IStandardFindingRepository _standardFindingRepository;
        private IIncidentalFindingRepository _incidentalFindingRepository;

        // private const string LeadLongLongDescription = "The result of your LEAD shows plaque in your lower (peripheral is acceptable) arterial system.  It is recommended to take your results to your personal physician for discussion.";
        private const string LeadLongLongDescription = "";

        public LeadResultPdfHelper(ISettings settings, IResultPdfHelper resultPdfHelper, IStandardFindingRepository standardFindingRepository,
            IIncidentalFindingRepository incidentalFindingRepository)
        {
            _settings = settings;
            _resultPdfHelper = resultPdfHelper;
            _standardFindingRepository = standardFindingRepository;
            _incidentalFindingRepository = incidentalFindingRepository;
        }

        public void LoadLeadTestresults(HtmlDocument doc, LeadTestResult testResult, bool removeLongDescription, List<OrderedPair<long, string>> technicianIdNamePairs,
            bool loadImages, IEnumerable<CustomerScreeningEvaluatinPhysicianViewModel> physicians, IEnumerable<EventPhysicianTest> eventPhysicianTests,
            IEnumerable<PhysicianEvaluation> eventCustomerPhysicianEvaluation, CustomerSkipReview customerSkipReview, DateTime eventDate,
            bool isPhysicianPartnerCustomer)
        {
            var findingVelocityLeftList = _standardFindingRepository.GetAllStandardFindings<decimal?>((int)TestType.Lead, (int)ReadingLabels.LeftCFAPSV);
            var findingVelocityRightList = _standardFindingRepository.GetAllStandardFindings<decimal?>((int)TestType.Lead, (int)ReadingLabels.RightCFAPSV);
            var incidentalFindings = _incidentalFindingRepository.GetAllIncidentalFinding((int)TestType.Stroke);

            var selectedNode = doc.DocumentNode.SelectSingleNode("//span[@id='LowVelocityLeftLabel']");
            if (selectedNode != null)
            {
                selectedNode.InnerHtml = findingVelocityLeftList.FirstOrDefault().Label;
            }

            selectedNode = doc.DocumentNode.SelectSingleNode("//span[@id='LowVelocityRightLabel']");
            if (selectedNode != null)
            {
                selectedNode.InnerHtml = findingVelocityRightList.FirstOrDefault().Label;
            }

            var getAbsValue = new Func<ResultReading<decimal?>, ResultReading<decimal?>>(r =>
            {
                if (r != null && r.Reading != null && r.Reading.Value < 0)
                    r.Reading = r.Reading.Value * -1;

                return r;
            });


            if (testResult != null)
            {
                selectedNode = doc.DocumentNode.SelectSingleNode("//div[@id='lead-rpp-section']");
                if (selectedNode != null && (testResult.UnableScreenReason == null || testResult.UnableScreenReason.Count == 0) && (testResult.TestNotPerformed == null || testResult.TestNotPerformed.TestNotPerformedReasonId <= 0)
                    && (testResult.RepeatStudy == null || testResult.RepeatStudy.Reading == false))
                    selectedNode.SetAttributeValue("style", "display:block;");

                selectedNode = doc.DocumentNode.SelectSingleNode("//div[@id='rpp-eus-lead-div']");
                if (selectedNode != null)
                    selectedNode.SetAttributeValue("style", "display:block;");

                _resultPdfHelper.SetPhysicianSignature(doc, "lead-primaryEvalPhysicianSign", "lead-overreadEvalPhysicianSign", physicians, eventPhysicianTests, eventCustomerPhysicianEvaluation, customerSkipReview);

                var readings = new TestResultRepository().GetAllReadings((int)TestType.Lead);

                foreach (var resultReading in readings)
                {
                    switch (resultReading.Label)
                    {
                        case ReadingLabels.RightCFAPSV:
                            if (testResult.RightResultReadings != null)
                            {
                                testResult.RightResultReadings.CFAPSV = getAbsValue(testResult.RightResultReadings.CFAPSV);
                                _resultPdfHelper.SetInputBox(doc, "RightCFAPSVInputText", testResult.RightResultReadings.CFAPSV);
                            }
                            break;

                        case ReadingLabels.RightPSFAPSV:
                            if (testResult.RightResultReadings != null)
                            {
                                testResult.RightResultReadings.PSFAPSV = getAbsValue(testResult.RightResultReadings.PSFAPSV);
                                _resultPdfHelper.SetInputBox(doc, "RightPSFAPSVInputText", getAbsValue(testResult.RightResultReadings.PSFAPSV));
                            }
                            break;


                        case ReadingLabels.LeftCFAPSV:
                            if (testResult.LeftResultReadings != null)
                            {
                                testResult.LeftResultReadings.CFAPSV = getAbsValue(testResult.LeftResultReadings.CFAPSV);
                                _resultPdfHelper.SetInputBox(doc, "LeftCFAPSVInputText", getAbsValue(testResult.LeftResultReadings.CFAPSV));
                            }
                            break;

                        case ReadingLabels.LeftPSFAPSV:
                            if (testResult.LeftResultReadings != null)
                            {
                                testResult.LeftResultReadings.PSFAPSV = getAbsValue(testResult.LeftResultReadings.PSFAPSV);
                                _resultPdfHelper.SetInputBox(doc, "LeftPSFAPSVInputText", getAbsValue(testResult.LeftResultReadings.PSFAPSV));
                            }
                            break;

                        case ReadingLabels.TechnicallyLimitedbutReadable:
                            _resultPdfHelper.SetCheckBox(doc, "TechnicallyLimitedbutReadableLeadInputCheck", testResult.TechnicallyLimitedbutReadable);
                            break;

                        case ReadingLabels.RepeatStudy:
                            _resultPdfHelper.SetCheckBox(doc, "RepeatStudyLeadInputCheck", testResult.RepeatStudy);
                            break;
                    }
                }


                if (findingVelocityLeftList != null)
                {
                    selectedNode = doc.DocumentNode.SelectSingleNode("//input[@id='LowVelocityLeftCheckbox']");
                    if (selectedNode != null && testResult.LowVelocityLeft != null)
                    {
                        selectedNode.SetAttributeValue("checked", "checked");
                    }
                }

                if (findingVelocityLeftList != null)
                {
                    selectedNode = doc.DocumentNode.SelectSingleNode("//input[@id='LowVelocityRightCheckbox']");
                    if (selectedNode != null && testResult.LowVelocityRight != null)
                    {
                        selectedNode.SetAttributeValue("checked", "checked");
                    }
                }

                _resultPdfHelper.LoadTestMedia(doc, testResult.ResultImages, "testmedia-lead", loadImages);
                LoadLeadIncidentalFindings(doc, incidentalFindings, testResult.IncidentalFindings);
                _resultPdfHelper.SetUnableToScreenReasons(doc, TestType.Lead, "leadUnableToScreen", testResult.UnableScreenReason);
                _resultPdfHelper.SetTechnician(doc, testResult, "techlead", "technoteslead", technicianIdNamePairs);
                _resultPdfHelper.SetPhysicianRemarks(doc, testResult, "followUpLead", "criticalLead", "physicianRemarksLead");

                if (testResult.IncidentalFindings != null && testResult.IncidentalFindings.Any())
                {
                    selectedNode = doc.DocumentNode.SelectSingleNode("//p[@id='incidentalfinding-description-lead']");
                    if (selectedNode != null) selectedNode.SetAttributeValue("style", "display:block;");
                }

                selectedNode = doc.DocumentNode.SelectSingleNode("//span[@id='diagnosisCodeLead']");

                if (selectedNode != null && testResult.DiagnosisCode != null && !string.IsNullOrEmpty(testResult.DiagnosisCode.Reading))
                {
                    var readingList = testResult.DiagnosisCode.Reading.Split('|');
                    var stBuilder = string.Empty;

                    foreach (var reading in readingList)
                    {
                        stBuilder = stBuilder + "<br/>" + reading;
                    }

                    selectedNode.InnerHtml = stBuilder;
                }

                selectedNode = doc.DocumentNode.SelectSingleNode("//div[@id='lead-longdescription-div']");
                if (selectedNode != null)
                    selectedNode.SetAttributeValue("style", removeLongDescription ? "display:none" : "display:block");

                if (_settings.ChangeLeadReadingDate.HasValue && eventDate.Date >= _settings.ChangeLeadReadingDate.Value)
                {
                    selectedNode = doc.DocumentNode.SelectSingleNode("//div[@id='diagnosisCodeLeadContainer']");
                    if (selectedNode != null)
                        selectedNode.SetAttributeValue("style", "display:none");

                    selectedNode = doc.DocumentNode.SelectSingleNode("//table[@id='leadFinding']");
                    if (selectedNode != null)
                        selectedNode.SetAttributeValue("style", "display:none");

                    selectedNode = doc.DocumentNode.SelectSingleNode("//table[@id='leadFinding-CheckBox']");
                    if (selectedNode != null)
                        selectedNode.SetAttributeValue("style", "display:block");

                    selectedNode = doc.DocumentNode.SelectSingleNode("//div[@id='lead-longdescription-div']");
                    if (selectedNode != null)
                        selectedNode.SetAttributeValue("style", "display:none");

                    selectedNode = doc.DocumentNode.SelectSingleNode("//p[@id='long-description-lead']");
                    if (selectedNode != null)
                        selectedNode.InnerHtml = "<i>" + LeadLongLongDescription + "</i>";

                    if (testResult.RightResultReadings != null)
                    {
                        _resultPdfHelper.SetCheckBox(doc, "rightNoVisualPlaque", testResult.RightResultReadings.NoVisualPlaque);
                        _resultPdfHelper.SetCheckBox(doc, "rightVisuallyDemonstratedPlaque", testResult.RightResultReadings.VisuallyDemonstratedPlaque);
                        _resultPdfHelper.SetCheckBox(doc, "rightModerateStenosis", testResult.RightResultReadings.ModerateStenosis);
                        _resultPdfHelper.SetCheckBox(doc, "rightPossibleOcclusion", testResult.RightResultReadings.PossibleOcclusion);
                    }

                    if (testResult.LeftResultReadings != null)
                    {
                        _resultPdfHelper.SetCheckBox(doc, "leftNoVisualPlaque", testResult.LeftResultReadings.NoVisualPlaque);
                        _resultPdfHelper.SetCheckBox(doc, "leftVisuallyDemonstratedPlaque", testResult.LeftResultReadings.VisuallyDemonstratedPlaque);
                        _resultPdfHelper.SetCheckBox(doc, "leftModerateStenosis", testResult.LeftResultReadings.ModerateStenosis);
                        _resultPdfHelper.SetCheckBox(doc, "leftPossibleOcclusion", testResult.LeftResultReadings.PossibleOcclusion);
                    }

                    SetLeadResult(doc, testResult, readings);
                }
                else
                {
                    selectedNode = doc.DocumentNode.SelectSingleNode("//div[@id='diagnosisCodeLeadContainer']");
                    if (selectedNode != null)
                        selectedNode.SetAttributeValue("style", "display:block");

                    selectedNode = doc.DocumentNode.SelectSingleNode("//table[@id='leadFinding']");
                    if (selectedNode != null)
                        selectedNode.SetAttributeValue("style", "display:block");

                    selectedNode = doc.DocumentNode.SelectSingleNode("//table[@id='leadFinding-CheckBox']");
                    if (selectedNode != null)
                        selectedNode.SetAttributeValue("style", "display:none");

                    LoadLeadFindings(doc, testResult);
                }

                if (isPhysicianPartnerCustomer)
                {
                    selectedNode = doc.DocumentNode.SelectSingleNode("//div[@id='ppLead-patient-detail']");
                    if (selectedNode != null)
                        selectedNode.SetAttributeValue("style", "display:block");
                }
            }
            else
            {
                LoadLeadFindings(doc, null, false);
                _resultPdfHelper.SetIncidentalFindings(doc, incidentalFindings, null, "leadIncidenatlFindings");
                _resultPdfHelper.SetUnableToScreenReasons(doc, TestType.Lead, "leadUnableToScreen", null);
            }
        }

        private void LoadLeadFindings(HtmlDocument doc, LeadTestResult testResult, bool isTestPurchased = true)
        {
            var standardFindingList = _standardFindingRepository.GetAllStandardFindings<decimal>((int)TestType.Lead, (int)ReadingLabels.Left);

            StandardFinding<decimal> leftFinding = null;
            StandardFinding<decimal> rightFinding = null;

            if (testResult != null)
            {
                if (testResult.LeftResultReadings != null && testResult.LeftResultReadings.Finding != null)
                {
                    leftFinding = testResult.LeftResultReadings.Finding;
                }
                if (testResult.RightResultReadings != null && testResult.RightResultReadings.Finding != null)
                {
                    rightFinding = testResult.RightResultReadings.Finding;
                }
            }

            StandardFinding<decimal> finding = leftFinding != null && rightFinding != null
                                          ? (leftFinding.Id > rightFinding.Id ? leftFinding : rightFinding)
                                          : (leftFinding ?? rightFinding);

            UnableScreenReason unableScreenReason = null;
            //TODO: This is a hack for U Screen Text on Stroke Summary
            if (testResult != null && testResult.UnableScreenReason != null && testResult.UnableScreenReason.Count > 0 && testResult.UnableScreenReason.Where(us => us.Reason == UnableToScreenReason.TechnicallyLimitedImages).Count() < 1)
                unableScreenReason = testResult.UnableScreenReason.First();

            _resultPdfHelper.SetSummaryFindings(doc, finding, standardFindingList, "FindingsLeadDiv", "long-description-lead", null, isTestPurchased, unableScreenReason);

            HtmlNode selectedNode;
            if (finding != null)
            {
                var stdFinding = standardFindingList.Where(f => f.Id == finding.Id).Single();

                selectedNode = doc.DocumentNode.SelectSingleNode("//span[@id='lead-rpp-resultspan']");
                if (selectedNode != null)
                    selectedNode.InnerHtml = stdFinding.Label;

                selectedNode = doc.DocumentNode.SelectSingleNode("//div[@id='docletter-lead']");
                if (stdFinding.ResultInterpretation != null && stdFinding.ResultInterpretation.Value != (long)ResultInterpretation.Normal && selectedNode != null)
                    selectedNode.SetAttributeValue("style", "display:block;");
            }

            string htmlRows = "";
            string strokeDescription = "<fieldset><legend>STENOSIS RANGE</legend><Table>";
            foreach (var standardFinding in standardFindingList)
            {
                string rowString = "<tr>";
                strokeDescription += "<tr>";
                if (rightFinding != null && rightFinding.Id == standardFinding.Id)
                {
                    rowString += "<td> <input type='checkbox' checked='checked' /> </td>";
                }
                else
                {
                    rowString += "<td> <input type='checkbox' /> </td>";
                }

                if (leftFinding != null && leftFinding.Id == standardFinding.Id)
                {
                    rowString += "<td> <input type='checkbox' checked='checked' /> </td>";
                }
                else
                {
                    rowString += "<td> <input type='checkbox' /> </td>";
                }

                rowString += "<td> " + standardFinding.Label + " " + standardFinding.Description + "</td></tr>";

                htmlRows = htmlRows + rowString;
            }

            strokeDescription += "</Table></fieldset>";

            selectedNode = doc.DocumentNode.SelectSingleNode("//table[@id='leadFinding']");
            if (selectedNode != null)
            {
                selectedNode.InnerHtml += htmlRows;
            }

            selectedNode = doc.DocumentNode.SelectSingleNode("//div[@id='leadFindingDescriptionDiv']");
            if (selectedNode != null)
            {
                selectedNode.InnerHtml += strokeDescription;
            }

            if (leftFinding != null)
            {
                selectedNode = doc.DocumentNode.SelectSingleNode("//span[@id='lead-at-a-glance-finding-left']");
                if (selectedNode != null) selectedNode.InnerHtml = leftFinding.Label;
            }

            if (rightFinding != null)
            {
                selectedNode = doc.DocumentNode.SelectSingleNode("//span[@id='lead-at-a-glance-finding-right']");
                if (selectedNode != null) selectedNode.InnerHtml = rightFinding.Label;
            }

            if (finding != null)
            {
                selectedNode = doc.DocumentNode.SelectSingleNode("//span[@id='lead-at-a-glance-result']");
                if (selectedNode != null && testResult.ResultInterpretation.HasValue)
                    selectedNode.InnerHtml = ((ResultInterpretation)testResult.ResultInterpretation).ToString();

            }
        }

        private void LoadLeadIncidentalFindings(HtmlDocument doc, IEnumerable<IncidentalFinding> allFortheTest, IEnumerable<IncidentalFinding> recordedForthecurrentRecord)
        {
            const int ifIrregularPatternDoppler = 101;

            if (recordedForthecurrentRecord != null && recordedForthecurrentRecord.Any(ifd => ifd.Id == ifIrregularPatternDoppler))
            {
                var selectedNode = doc.DocumentNode.SelectSingleNode("//p[@id='ifdescription-irregulardoppler-lead']");
                if (selectedNode != null) selectedNode.SetAttributeValue("style", "display:block;");
            }

            _resultPdfHelper.SetIncidentalFindings(doc, allFortheTest, recordedForthecurrentRecord, "leadIncidenatlFindings");
        }

        private void SetLeadResult(HtmlDocument doc, LeadTestResult testResult, List<ResultReading<int>> readings)
        {
            if (testResult.LeftResultReadings != null && testResult.RightResultReadings != null)
            {
                var readingLabel = string.Empty;
                var leftResultReadings = testResult.LeftResultReadings;
                var rightResultReading = testResult.RightResultReadings;

                if ((leftResultReadings.NoVisualPlaque != null && leftResultReadings.NoVisualPlaque.Reading != null) || (rightResultReading.NoVisualPlaque != null && rightResultReading.NoVisualPlaque.Reading != null))
                {
                    var reading = readings.First(x => x.Label == ReadingLabels.LeftNoVisualPlaque);
                    readingLabel = reading.LableText;
                }

                if ((leftResultReadings.VisuallyDemonstratedPlaque != null && leftResultReadings.VisuallyDemonstratedPlaque.Reading != null) || (rightResultReading.VisuallyDemonstratedPlaque != null && rightResultReading.VisuallyDemonstratedPlaque.Reading != null))
                {
                    var reading = readings.First(x => x.Label == ReadingLabels.LeftVisuallyDemonstratedPlaque);
                    readingLabel = reading.LableText;
                }

                if ((leftResultReadings.ModerateStenosis != null && leftResultReadings.ModerateStenosis.Reading != null) || (rightResultReading.ModerateStenosis != null && rightResultReading.ModerateStenosis.Reading != null))
                {
                    var reading = readings.First(x => x.Label == ReadingLabels.LeftModerateStenosis);
                    readingLabel = reading.LableText;
                }

                if ((leftResultReadings.PossibleOcclusion != null && leftResultReadings.PossibleOcclusion.Reading != null) || (rightResultReading.PossibleOcclusion != null && rightResultReading.PossibleOcclusion.Reading != null))
                {
                    var reading = readings.First(x => x.Label == ReadingLabels.LeftPossibleOcclusion);
                    readingLabel = reading.LableText;
                }

                var selectedNode = doc.DocumentNode.SelectSingleNode("//span[@id='lead-rpp-resultspan']");
                if (selectedNode != null)
                    selectedNode.InnerHtml = readingLabel;
            }
        }
    }
}
