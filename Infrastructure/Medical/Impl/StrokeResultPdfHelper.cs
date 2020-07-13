using System;
using System.Collections.Generic;
using System.Linq;
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

namespace Falcon.App.Infrastructure.Medical.Impl
{
    [DefaultImplementation]
    public class StrokeResultPdfHelper : IStrokeResultPdfHelper
    {
        private readonly IResultPdfHelper _resultPdfHelper;
        private readonly IStandardFindingRepository _standardFindingRepository;
        private readonly IIncidentalFindingRepository _incidentalFindingRepository;
        private readonly ISettings _settings;
        private readonly IEventCustomerResultRepository _eventCustomerResultRepository;

        private const string StrokeNone = "None";
        private const string StrokeMild = "Mild";
        private const string StrokeModerate = "Moderate";
        private const string StrokeSignificant = "Significant";
        private const string StrokeOccluded = "Occluded";
        private const string StringforContentDirectory = "content";

        public StrokeResultPdfHelper(IResultPdfHelper resultPdfHelper, IStandardFindingRepository standardFindingRepository, IIncidentalFindingRepository incidentalFindingRepository, ISettings settings,
            IEventCustomerResultRepository eventCustomerResultRepository)
        {
            _resultPdfHelper = resultPdfHelper;
            _standardFindingRepository = standardFindingRepository;
            _incidentalFindingRepository = incidentalFindingRepository;
            _settings = settings;
            _eventCustomerResultRepository = eventCustomerResultRepository;
        }

        public void LoadStrokeTestresults(HtmlDocument doc, StrokeTestResult testResult, bool removeLongDescription, bool loadImages, List<OrderedPair<long, string>> technicianIdNamePairs, long eventId, long customerId,
            bool showRepeatStudyCheckbox, IEnumerable<CustomerScreeningEvaluatinPhysicianViewModel> physicians, IEnumerable<EventPhysicianTest> eventPhysicianTests, IEnumerable<PhysicianEvaluation> eventCustomerPhysicianEvaluations,
            CustomerSkipReview customerSkipReview)
        {
            var findingVelocityLicaList = _standardFindingRepository.GetAllStandardFindings<decimal?>((int)TestType.Stroke, (int)ReadingLabels.LICAPSV);
            var findingVelocityRicaList = _standardFindingRepository.GetAllStandardFindings<decimal?>((int)TestType.Stroke, (int)ReadingLabels.RICAPSV);
            var incidentalFindings = _incidentalFindingRepository.GetAllIncidentalFinding((int)TestType.Stroke);

            var selectedNode = doc.DocumentNode.SelectSingleNode("//span[@id='LowVelocityLabel']");
            if (selectedNode != null)
            {
                selectedNode.InnerHtml = findingVelocityLicaList.FirstOrDefault().Label;
            }

            selectedNode = doc.DocumentNode.SelectSingleNode("//span[@id='LowVelocityLICALabel']");
            if (selectedNode != null)
            {
                selectedNode.InnerHtml = findingVelocityLicaList.FirstOrDefault().Label;
            }

            selectedNode = doc.DocumentNode.SelectSingleNode("//span[@id='LowVelocityRICALabel']");
            if (selectedNode != null)
            {
                selectedNode.InnerHtml = findingVelocityRicaList.FirstOrDefault().Label;
            }



            var getAbsValue = new Func<ResultReading<decimal?>, ResultReading<decimal?>>(r =>
            {
                if (r != null && r.Reading != null && r.Reading.Value < 0)
                    r.Reading = r.Reading.Value * -1;

                return r;
            });


            if (testResult != null)
            {
                selectedNode = doc.DocumentNode.SelectSingleNode("//div[@id='stroke-rpp-section']");
                if (selectedNode != null && (testResult.UnableScreenReason == null || testResult.UnableScreenReason.Count == 0) && (testResult.TestNotPerformed == null || testResult.TestNotPerformed.TestNotPerformedReasonId <= 0))
                    selectedNode.SetAttributeValue("style", "display:block;");

                selectedNode = doc.DocumentNode.SelectSingleNode("//div[@id='rpp-eus-stroke-div']");
                if (selectedNode != null)
                    selectedNode.SetAttributeValue("style", "display:block;");

                _resultPdfHelper.SetPhysicianSignature(doc, "stroke-primaryEvalPhysicianSign", "stroke-overreadEvalPhysicianSign", physicians, eventPhysicianTests, eventCustomerPhysicianEvaluations, customerSkipReview);

                var readings = new TestResultRepository().GetAllReadings((int)TestType.Stroke);

                foreach (var resultReading in readings)
                {
                    switch (resultReading.Label)
                    {
                        case ReadingLabels.RICAPSV:
                            if (testResult.RightResultReadings != null)
                            {
                                testResult.RightResultReadings.ICAPSV =
                                    getAbsValue(testResult.RightResultReadings.ICAPSV);
                                _resultPdfHelper.SetInputBox(doc, "RICAPSVInputText", testResult.RightResultReadings.ICAPSV);
                            }
                            break;

                        case ReadingLabels.RICAEDV:
                            if (testResult.RightResultReadings != null)
                            {
                                testResult.RightResultReadings.ICAEDV =
                                    getAbsValue(testResult.RightResultReadings.ICAEDV);
                                _resultPdfHelper.SetInputBox(doc, "RICAEDVInputText", getAbsValue(testResult.RightResultReadings.ICAEDV));
                            }
                            break;

                        case ReadingLabels.RCCAPSV:

                            break;

                        case ReadingLabels.LICAPSV:
                            if (testResult.LeftResultReadings != null)
                            {
                                testResult.LeftResultReadings.ICAPSV =
                                    getAbsValue(testResult.LeftResultReadings.ICAPSV);
                                _resultPdfHelper.SetInputBox(doc, "LICAPSVInputText", getAbsValue(testResult.LeftResultReadings.ICAPSV));
                            }
                            break;

                        case ReadingLabels.LICAEDV:
                            if (testResult.LeftResultReadings != null)
                            {
                                testResult.LeftResultReadings.ICAEDV =
                                    getAbsValue(testResult.LeftResultReadings.ICAEDV);
                                _resultPdfHelper.SetInputBox(doc, "LICAEDVInputText", getAbsValue(testResult.LeftResultReadings.ICAEDV));
                            }
                            break;

                        case ReadingLabels.LCCAPSV:
                            break;

                        case ReadingLabels.TechnicallyLimitedbutReadable:
                            _resultPdfHelper.SetCheckBox(doc, "TechnicallyLimitedbutReadableStrokeInputCheck", testResult.TechnicallyLimitedbutReadable);
                            break;

                        case ReadingLabels.RepeatStudy:
                            _resultPdfHelper.SetCheckBox(doc, "RepeatStudyStrokeInputCheck", testResult.RepeatStudy);
                            break;
                    }
                }

                _resultPdfHelper.SetCheckBox(doc, "velocityelevatedleft", testResult.VelocityElevatedOnLeft);
                _resultPdfHelper.SetCheckBox(doc, "velocityelevatedright", testResult.VelocityElevatedOnRight);

                _resultPdfHelper.SetCheckBox(doc, "strokeConsiderOtherModalities", testResult.ConsiderOtherModalities);
                _resultPdfHelper.SetCheckBox(doc, "strokeAdditionalImagesNeeded", testResult.AdditionalImagesNeeded);

                LoadStrokeFindings(doc, testResult, customerId, eventId);

                if (findingVelocityLicaList != null)
                {
                    selectedNode = doc.DocumentNode.SelectSingleNode("//input[@id='LowVelocityCheckbox']");
                    if (selectedNode != null && testResult.LowVelocityLica != null)
                    {
                        selectedNode.SetAttributeValue("checked", "checked");
                    }

                    selectedNode = doc.DocumentNode.SelectSingleNode("//input[@id='LowVelocityLICACheckbox']");
                    if (selectedNode != null && testResult.LowVelocityLica != null)
                    {
                        selectedNode.SetAttributeValue("checked", "checked");
                    }
                }

                if (findingVelocityLicaList != null)
                {
                    selectedNode = doc.DocumentNode.SelectSingleNode("//input[@id='LowVelocityRICACheckbox']");
                    if (selectedNode != null && testResult.LowVelocityRica != null)
                    {
                        selectedNode.SetAttributeValue("checked", "checked");
                    }
                }

                _resultPdfHelper.LoadTestMedia(doc, testResult.ResultImages, "testmedia-stroke", loadImages);
                LoadStrokeIncidentalFindings(doc, incidentalFindings, testResult.IncidentalFindings);
                _resultPdfHelper.SetUnableToScreenReasons(doc, TestType.Stroke, "strokeUnableToScreen", testResult.UnableScreenReason);
                _resultPdfHelper.SetTechnician(doc, testResult, "techstroke", "technotesstroke", technicianIdNamePairs);
                _resultPdfHelper.SetPhysicianRemarks(doc, testResult, "followUpStroke", "criticalStroke", "physicianRemarksStroke");

                if (testResult.IncidentalFindings != null && testResult.IncidentalFindings.Any())
                {
                    selectedNode = doc.DocumentNode.SelectSingleNode("//p[@id='incidentalfinding-description-stroke']");
                    if (selectedNode != null) selectedNode.SetAttributeValue("style", "display:block;");
                }

                selectedNode = doc.DocumentNode.SelectSingleNode("//div[@id='stroke-longdescription-div']");
                if (selectedNode != null)
                    selectedNode.SetAttributeValue("style", removeLongDescription ? "display:none" : "display:block");
            }
            else
            {
                LoadStrokeFindings(doc, null, customerId, eventId, false);
                _resultPdfHelper.SetIncidentalFindings(doc, incidentalFindings, null, "strokeIncidenatlFindings");
                _resultPdfHelper.SetUnableToScreenReasons(doc, TestType.Stroke, "strokeUnableToScreen", null);
            }

            _resultPdfHelper.ShowHideRepeatStudy(doc, "strokePhysicianRepeatStudy", showRepeatStudyCheckbox);
            _resultPdfHelper.ShowHideOtherModalitiesAdditionalImages(doc, "strokeOtherModalitiesAdditionalImagesDiv", !showRepeatStudyCheckbox);
        }

        private void LoadStrokeIncidentalFindings(HtmlDocument doc, IEnumerable<IncidentalFinding> allFortheTest, IEnumerable<IncidentalFinding> recordedForthecurrentRecord)
        {
            const int ifIrregularPatternDoppler = 101;

            if (recordedForthecurrentRecord != null && recordedForthecurrentRecord.Any(ifd => ifd.Id == ifIrregularPatternDoppler))
            {
                var selectedNode = doc.DocumentNode.SelectSingleNode("//p[@id='ifdescription-irregulardoppler-stroke']");
                if (selectedNode != null) selectedNode.SetAttributeValue("style", "display:block;");
            }

            _resultPdfHelper.SetIncidentalFindings(doc, allFortheTest, recordedForthecurrentRecord, "strokeIncidenatlFindings");
        }

        private void LoadStrokeFindings(HtmlDocument doc, StrokeTestResult testResult, long customerId, long eventId, bool isTestPurchased = true)
        {
            List<StandardFinding<decimal>> standardFindingList;
            if (_settings.StrokeFindingChangeDate.HasValue)
            {
                var eventCustomerResult = _eventCustomerResultRepository.GetByCustomerIdAndEventId(customerId, eventId);
                if (eventCustomerResult != null && eventCustomerResult.DataRecorderMetaData.DateCreated < _settings.StrokeFindingChangeDate.Value)
                {
                    standardFindingList = _standardFindingRepository.GetAllStandardFindings<decimal>((int)TestType.Stroke, (int)ReadingLabels.Left, _settings.StrokeFindingChangeDate.Value, true);
                }
                else
                {
                    standardFindingList = _standardFindingRepository.GetAllStandardFindings<decimal>((int)TestType.Stroke, (int)ReadingLabels.Left, _settings.StrokeFindingChangeDate.Value, false);
                }
            }
            else
            {
                standardFindingList = _standardFindingRepository.GetAllStandardFindings<decimal>((int)TestType.Stroke, (int)ReadingLabels.Left);
            }

            //var standardFindingList = _standardFindingRepository.GetAllStandardFindings<decimal>((int)TestType.Stroke, (int)ReadingLabels.Left);
            StandardFinding<decimal> leftFinding = null;
            StandardFinding<decimal> rightFinding = null;
            bool showAdditionalImagesNeeded = false;
            bool showConsiderOtherModalities = false;

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

                if (testResult.AdditionalImagesNeeded != null)
                {
                    showAdditionalImagesNeeded = testResult.AdditionalImagesNeeded.Reading;
                }
                if (testResult.ConsiderOtherModalities != null)
                {
                    showConsiderOtherModalities = testResult.ConsiderOtherModalities.Reading;
                }
            }

            StandardFinding<decimal> finding = leftFinding != null && rightFinding != null
                                          ? (leftFinding.Id > rightFinding.Id ? leftFinding : rightFinding)
                                          : (leftFinding ?? rightFinding);

            UnableScreenReason unableScreenReason = null;
            //TODO: This is a hack for U Screen Text on Stroke Summary
            if (testResult != null && testResult.UnableScreenReason != null && testResult.UnableScreenReason.Count > 0 && testResult.UnableScreenReason.Count(us => us.Reason == UnableToScreenReason.TechnicallyLimitedImages) < 1)
                unableScreenReason = testResult.UnableScreenReason.First();





            _resultPdfHelper.SetSummaryFindings(doc, finding, standardFindingList, "FindingsStrokeDiv", "long-description-stroke", null, isTestPurchased, unableScreenReason, showAdditionalImagesNeeded, showConsiderOtherModalities);

            HtmlNode selectedNode;
            if (finding != null)
            {
                var stdFinding = standardFindingList.Single(f => f.Id == finding.Id);

                selectedNode = doc.DocumentNode.SelectSingleNode("//span[@id='stroke-rpp-resultspan']");
                if (selectedNode != null)
                    selectedNode.InnerHtml = stdFinding.Label;

                selectedNode = doc.DocumentNode.SelectSingleNode("//div[@id='docletter-stroke']");
                if (stdFinding.ResultInterpretation != null && stdFinding.ResultInterpretation.Value != (long)ResultInterpretation.Normal && selectedNode != null)
                    selectedNode.SetAttributeValue("style", "display:block;");
            }


            if (_settings.IsStrokeInferenceForPHS)
            {
                SetStrokeSummaryDescriptionforReading(doc, testResult, standardFindingList);
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
                if (_settings.IsStrokeInferenceForPHS)
                {
                    rowString += "<td> " + standardFinding.Label + "</td></tr>";
                    strokeDescription += "<td> " + standardFinding.Description.Replace("<", "&lt;").Replace(">", "&gt;") + "</td></tr>";
                }
                else
                {
                    //rowString += "<td> " + standardFinding.Label + " " + standardFinding.Description + "</td></tr>";

                    rowString += "<td style='float:left; width:110px; padding-left:10px; text-align:left;'> " + standardFinding.Label + "</td>";//.Replace("<", "&lt;")
                    rowString += "<td> " + standardFinding.Description + "</td></tr>";
                }
                htmlRows = htmlRows + rowString;
            }

            strokeDescription += "</Table></fieldset>";

            selectedNode = doc.DocumentNode.SelectSingleNode("//table[@id='strokeFinding']");
            if (selectedNode != null)
            {
                selectedNode.InnerHtml += htmlRows;
            }

            selectedNode = doc.DocumentNode.SelectSingleNode("//div[@id='strokeFindingDescriptionDiv']");
            if (selectedNode != null)
            {
                selectedNode.InnerHtml += strokeDescription;
            }

            if (leftFinding != null)
            {
                selectedNode = doc.DocumentNode.SelectSingleNode("//span[@id='stroke-at-a-glance-finding-left']");
                if (selectedNode != null) selectedNode.InnerHtml = leftFinding.Label;
            }

            if (rightFinding != null)
            {
                selectedNode = doc.DocumentNode.SelectSingleNode("//span[@id='stroke-at-a-glance-finding-right']");
                if (selectedNode != null) selectedNode.InnerHtml = rightFinding.Label;
            }

            if (finding != null)
            {
                selectedNode = doc.DocumentNode.SelectSingleNode("//span[@id='stroke-at-a-glance-result']");
                if (selectedNode != null && testResult.ResultInterpretation.HasValue)
                    selectedNode.InnerHtml = ((ResultInterpretation)testResult.ResultInterpretation).ToString();

                selectedNode = doc.DocumentNode.SelectSingleNode("//img[@id='stroke-at-a-glance-findingImage']");
                if (selectedNode != null)
                {
                    if (finding.Label.ToLower() == StrokeNone.ToLower())
                        selectedNode.SetAttributeValue("src", StringforContentDirectory + "/NMMS_N.png");
                    else if (finding.Label.ToLower() == StrokeMild.ToLower())
                        selectedNode.SetAttributeValue("src", StringforContentDirectory + "/NMMS_M.png");
                    else if (finding.Label.ToLower() == StrokeModerate.ToLower())
                        selectedNode.SetAttributeValue("src", StringforContentDirectory + "/NMMS_MD.png");
                    else if (finding.Label.ToLower() == StrokeSignificant.ToLower())
                        selectedNode.SetAttributeValue("src", StringforContentDirectory + "/NMMS_S.png");
                    else if (finding.Label.ToLower() == StrokeOccluded.ToLower())
                        selectedNode.SetAttributeValue("src", StringforContentDirectory + "/NMMS_S.png");
                    else
                        selectedNode.SetAttributeValue("src", StringforContentDirectory + "/NoIndication_NMMSI.png");
                }
            }

            if (testResult != null && testResult.UnableScreenReason != null && testResult.UnableScreenReason.Count > 0)
            {
                selectedNode = doc.DocumentNode.SelectSingleNode("//div[@id='stroke-at-a-glance-finding']");
                if (selectedNode != null)
                    selectedNode.SetAttributeValue("style", "display:none;");

                selectedNode = doc.DocumentNode.SelectSingleNode("//div[@id='stroke-at-a-glance-unabletoscreen']");
                if (selectedNode != null)
                    selectedNode.SetAttributeValue("style", "display:block;");

                selectedNode = doc.DocumentNode.SelectSingleNode("//span[@id='stroke-at-a-glance-result']");
                if (selectedNode != null)
                    selectedNode.InnerHtml = "N/A";

                selectedNode = doc.DocumentNode.SelectSingleNode("//img[@id='stroke-at-a-glance-findingImage']");
                if (selectedNode != null)
                    selectedNode.SetAttributeValue("src", StringforContentDirectory + "/NoIndication_NMMSI.png");
            }
        }

        private void SetStrokeSummaryDescriptionforReading(HtmlDocument doc, StrokeTestResult testResult, IEnumerable<StandardFinding<decimal>> standardFindings)
        {
            if (testResult == null) return;
            var findingLeft = CalculateFinding(testResult.LeftResultReadings, standardFindings);
            var findingRight = CalculateFinding(testResult.RightResultReadings, standardFindings);


            if (findingLeft == null && findingRight == null) return;

            var description = "";
            if (findingLeft != null && findingRight != null)
            {
                description = findingLeft.Id > findingRight.Id ? findingLeft.LongDescription : findingRight.LongDescription;
            }
            else
            {
                description = (findingLeft ?? findingRight).LongDescription;
            }

            if (!string.IsNullOrEmpty("long-description-stroke") && !string.IsNullOrEmpty(description))
            {
                var selectedNode = doc.DocumentNode.SelectSingleNode("//p[@id='long-description-stroke']");
                if (selectedNode != null)
                {
                    selectedNode.InnerHtml = description;
                }
            }
        }

        private StandardFinding<decimal> CalculateFinding(StrokeTestReadings readings, IEnumerable<StandardFinding<decimal>> standardFindings)
        {
            if (readings == null || ((readings.ICAEDV == null || !readings.ICAEDV.Reading.HasValue) && (readings.ICAPSV == null || !readings.ICAPSV.Reading.HasValue))) return null;

            string label = "";
            if (readings.ICAEDV != null && readings.ICAEDV.Reading != null)
            {
                if (readings.ICAEDV.Reading.Value >= 110)
                    label = "occluded";
                else if (readings.ICAEDV.Reading.Value >= 60)
                    label = "significant";
            }

            if (readings.ICAEDV != null && readings.ICAEDV.Reading != null && readings.ICAPSV != null && readings.ICAPSV.Reading != null && label.Length < 1)
            {
                if (readings.ICAEDV.Reading.Value < 60 && readings.ICAPSV.Reading.Value >= 120)
                {
                    label = "moderate";
                }
            }

            if (readings.ICAPSV != null && readings.ICAPSV.Reading != null && label.Length < 1 && readings.ICAPSV.Reading.Value < 120)
            {
                label = "mild";
            }

            return standardFindings.FirstOrDefault(finding => finding.Label.ToLower().Equals(label));
        }

        public void LoadHcpCarotidTestresults(HtmlDocument doc, HcpCarotidTestResult testResult, bool removeLongDescription, bool loadImages, List<OrderedPair<long, string>> technicianIdNamePairs,
             IEnumerable<CustomerScreeningEvaluatinPhysicianViewModel> physicians, IEnumerable<EventPhysicianTest> eventPhysicianTests, IEnumerable<PhysicianEvaluation> eventCustomerPhysicianEvaluations, CustomerSkipReview customerSkipReview)
        {
            var findingVelocityLicaList = _standardFindingRepository.GetAllStandardFindings<decimal?>((int)TestType.HCPCarotid, (int)ReadingLabels.LICAPSV);
            var findingVelocityRicaList = _standardFindingRepository.GetAllStandardFindings<decimal?>((int)TestType.HCPCarotid, (int)ReadingLabels.RICAPSV);
            var incidentalFindings = _incidentalFindingRepository.GetAllIncidentalFinding((int)TestType.HCPCarotid);

            var selectedNode = doc.DocumentNode.SelectSingleNode("//span[@id='HcpCarotidLowVelocityLICALabel']");
            if (selectedNode != null)
            {
                selectedNode.InnerHtml = findingVelocityLicaList.FirstOrDefault().Label;
            }

            selectedNode = doc.DocumentNode.SelectSingleNode("//span[@id='HcpCarotidLowVelocityRICALabel']");
            if (selectedNode != null)
            {
                selectedNode.InnerHtml = findingVelocityRicaList.FirstOrDefault().Label;
            }

            var getAbsValue = new Func<ResultReading<decimal?>, ResultReading<decimal?>>(r =>
            {
                if (r != null && r.Reading != null && r.Reading.Value < 0)
                    r.Reading = r.Reading.Value * -1;

                return r;
            });


            if (testResult != null)
            {
                selectedNode = doc.DocumentNode.SelectSingleNode("//div[@id='HcpCarotid-rpp-section']");
                if (selectedNode != null && (testResult.UnableScreenReason == null || testResult.UnableScreenReason.Count == 0) && (testResult.TestNotPerformed == null || testResult.TestNotPerformed.TestNotPerformedReasonId <= 0)
                    && (testResult.RepeatStudy == null || testResult.RepeatStudy.Reading == false))
                    selectedNode.SetAttributeValue("style", "display:block;");

                selectedNode = doc.DocumentNode.SelectSingleNode("//div[@id='rpp-eus-HcpCarotid-div']");
                if (selectedNode != null)
                    selectedNode.SetAttributeValue("style", "display:block;");

                _resultPdfHelper.SetPhysicianSignature(doc, "HcpCarotid-primaryEvalPhysicianSign", "HcpCarotid-overreadEvalPhysicianSign", physicians, eventPhysicianTests, eventCustomerPhysicianEvaluations, customerSkipReview);

                var readings = new TestResultRepository().GetAllReadings((int)TestType.HCPCarotid);

                foreach (var resultReading in readings)
                {
                    switch (resultReading.Label)
                    {
                        case ReadingLabels.RICAPSV:
                            if (testResult.RightResultReadings != null)
                            {
                                testResult.RightResultReadings.ICAPSV =
                                    getAbsValue(testResult.RightResultReadings.ICAPSV);
                                _resultPdfHelper.SetInputBox(doc, "HcpCarotidRICAPSVInputText", testResult.RightResultReadings.ICAPSV);
                            }
                            break;

                        case ReadingLabels.RICAEDV:
                            if (testResult.RightResultReadings != null)
                            {
                                testResult.RightResultReadings.ICAEDV =
                                    getAbsValue(testResult.RightResultReadings.ICAEDV);
                                _resultPdfHelper.SetInputBox(doc, "HcpCarotidRICAEDVInputText", getAbsValue(testResult.RightResultReadings.ICAEDV));
                            }
                            break;


                        case ReadingLabels.LICAPSV:
                            if (testResult.LeftResultReadings != null)
                            {
                                testResult.LeftResultReadings.ICAPSV =
                                    getAbsValue(testResult.LeftResultReadings.ICAPSV);
                                _resultPdfHelper.SetInputBox(doc, "HcpCarotidLICAPSVInputText", getAbsValue(testResult.LeftResultReadings.ICAPSV));
                            }
                            break;

                        case ReadingLabels.LICAEDV:
                            if (testResult.LeftResultReadings != null)
                            {
                                testResult.LeftResultReadings.ICAEDV =
                                    getAbsValue(testResult.LeftResultReadings.ICAEDV);
                                _resultPdfHelper.SetInputBox(doc, "HcpCarotidLICAEDVInputText", getAbsValue(testResult.LeftResultReadings.ICAEDV));
                            }
                            break;

                        case ReadingLabels.TechnicallyLimitedbutReadable:
                            _resultPdfHelper.SetCheckBox(doc, "TechnicallyLimitedbutReadableHcpCarotidInputCheck", testResult.TechnicallyLimitedbutReadable);
                            break;

                        case ReadingLabels.RepeatStudy:
                            _resultPdfHelper.SetCheckBox(doc, "RepeatStudyHcpCarotidInputCheck", testResult.RepeatStudy);
                            break;
                    }
                }

                _resultPdfHelper.SetCheckBox(doc, "velocityelevatedleft", testResult.VelocityElevatedOnLeft);
                _resultPdfHelper.SetCheckBox(doc, "velocityelevatedright", testResult.VelocityElevatedOnRight);

                LoadHcpCarotidFindings(doc, testResult);

                if (findingVelocityLicaList != null)
                {
                    selectedNode = doc.DocumentNode.SelectSingleNode("//input[@id='HcpCarotidLowVelocityLICACheckbox']");
                    if (selectedNode != null && testResult.LowVelocityLica != null)
                    {
                        selectedNode.SetAttributeValue("checked", "checked");
                    }
                }

                if (findingVelocityLicaList != null)
                {
                    selectedNode = doc.DocumentNode.SelectSingleNode("//input[@id='HcpCarotidLowVelocityRICACheckbox']");
                    if (selectedNode != null && testResult.LowVelocityRica != null)
                    {
                        selectedNode.SetAttributeValue("checked", "checked");
                    }
                }

                _resultPdfHelper.LoadTestMedia(doc, testResult.ResultImages, "testmedia-HcpCarotid", loadImages);
                LoadHcpCarotidIncidentalFindings(doc, incidentalFindings, testResult.IncidentalFindings);
                _resultPdfHelper.SetUnableToScreenReasons(doc, TestType.HCPCarotid, "HcpCarotidUnableToScreen", testResult.UnableScreenReason);
                _resultPdfHelper.SetTechnician(doc, testResult, "techHcpCarotid", "technotesHcpCarotid", technicianIdNamePairs);
                _resultPdfHelper.SetPhysicianRemarks(doc, testResult, "followUpHcpCarotid", "criticalHcpCarotid", "physicianRemarksHcpCarotid");

                if (testResult.IncidentalFindings != null && testResult.IncidentalFindings.Any())
                {
                    selectedNode = doc.DocumentNode.SelectSingleNode("//p[@id='incidentalfinding-description-HcpCarotid']");
                    if (selectedNode != null) selectedNode.SetAttributeValue("style", "display:block;");
                }

                selectedNode = doc.DocumentNode.SelectSingleNode("//div[@id='HcpCarotid-longdescription-div']");
                if (selectedNode != null)
                    selectedNode.SetAttributeValue("style", removeLongDescription ? "display:none" : "display:block");
            }
            else
            {
                LoadHcpCarotidFindings(doc, null, false);
                _resultPdfHelper.SetIncidentalFindings(doc, incidentalFindings, null, "HcpCarotidIncidenatlFindings");
                _resultPdfHelper.SetUnableToScreenReasons(doc, TestType.HCPCarotid, "HcpCarotidUnableToScreen", null);
            }
        }

        private void LoadHcpCarotidFindings(HtmlDocument doc, HcpCarotidTestResult testResult, bool isTestPurchased = true)
        {
            var standardFindingList = _standardFindingRepository.GetAllStandardFindings<decimal>((int)TestType.HCPCarotid, (int)ReadingLabels.Left);
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
            if (testResult != null && testResult.UnableScreenReason != null && testResult.UnableScreenReason.Count > 0 && testResult.UnableScreenReason.All(us => us.Reason != UnableToScreenReason.TechnicallyLimitedImages))
                unableScreenReason = testResult.UnableScreenReason.First();

            _resultPdfHelper.SetSummaryFindings(doc, finding, standardFindingList, "FindingsHcpCarotidDiv", "long-description-HcpCarotid", null, isTestPurchased, unableScreenReason);

            HtmlNode selectedNode;
            if (finding != null)
            {
                var stdFinding = standardFindingList.Single(f => f.Id == finding.Id);

                selectedNode = doc.DocumentNode.SelectSingleNode("//span[@id='HcpCarotid-rpp-resultspan']");
                if (selectedNode != null)
                    selectedNode.InnerHtml = stdFinding.Label;

                selectedNode = doc.DocumentNode.SelectSingleNode("//div[@id='docletter-HcpCarotid']");
                if (stdFinding.ResultInterpretation != null && stdFinding.ResultInterpretation.Value != (long)ResultInterpretation.Normal && selectedNode != null)
                    selectedNode.SetAttributeValue("style", "display:block;");
            }



            string htmlRows = "";
            string hcpCarotidDescription = "<fieldset><legend>STENOSIS RANGE</legend><Table>";
            foreach (var standardFinding in standardFindingList)
            {
                string rowString = "<tr>";
                hcpCarotidDescription += "<tr>";
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

                rowString += "<td style='float:left; width:110px; padding-left:10px; text-align:left;'> " + standardFinding.Label + "</td>";//.Replace("<", "&lt;")
                rowString += "<td> " + standardFinding.Description + "</td></tr>";


                htmlRows = htmlRows + rowString;
            }

            hcpCarotidDescription += "</Table></fieldset>";

            selectedNode = doc.DocumentNode.SelectSingleNode("//table[@id='HcpCarotidFinding']");
            if (selectedNode != null)
            {
                selectedNode.InnerHtml += htmlRows;
            }

            selectedNode = doc.DocumentNode.SelectSingleNode("//div[@id='HcpCarotidFindingDescriptionDiv']");
            if (selectedNode != null)
            {
                selectedNode.InnerHtml += hcpCarotidDescription;
            }

        }

        private void LoadHcpCarotidIncidentalFindings(HtmlDocument doc, IEnumerable<IncidentalFinding> allFortheTest, IEnumerable<IncidentalFinding> recordedForthecurrentRecord)
        {
            const int ifIrregularPatternDoppler = 101;

            if (recordedForthecurrentRecord != null && recordedForthecurrentRecord.Any(ifd => ifd.Id == ifIrregularPatternDoppler))
            {
                var selectedNode = doc.DocumentNode.SelectSingleNode("//p[@id='ifdescription-irregulardoppler-HcpCarotid']");
                if (selectedNode != null) selectedNode.SetAttributeValue("style", "display:block;");
            }

            _resultPdfHelper.SetIncidentalFindings(doc, allFortheTest, recordedForthecurrentRecord, "HcpCarotidIncidenatlFindings");
        }

        public void LoadAwvCarotidTestresults(AwvCarotidTestResult testResult, bool removeLongDescription, HtmlDocument doc, bool loadImages, List<OrderedPair<long, string>> technicianIdNamePairs,
            IEnumerable<CustomerScreeningEvaluatinPhysicianViewModel> physicians, IEnumerable<EventPhysicianTest> eventPhysicianTests, bool showUnreadAbleTest, IEnumerable<PhysicianEvaluation> eventCustomerPhysicianEvaluations,
            CustomerSkipReview customerSkipReview)
        {
            var findingVelocityLicaList = _standardFindingRepository.GetAllStandardFindings<decimal?>((int)TestType.AwvCarotid, (int)ReadingLabels.LICAPSV);
            var findingVelocityRicaList = _standardFindingRepository.GetAllStandardFindings<decimal?>((int)TestType.AwvCarotid, (int)ReadingLabels.RICAPSV);

            var incidentalFindings = _incidentalFindingRepository.GetAllIncidentalFinding((int)TestType.AwvCarotid);

            var selectedNode = doc.DocumentNode.SelectSingleNode("//span[@id='AwvCarotidLowVelocityLabel']");
            var findingLowVelocity = findingVelocityLicaList.FirstOrDefault();
            if (selectedNode != null && findingLowVelocity != null)
            {
                selectedNode.InnerHtml = findingLowVelocity.Label;
            }

            selectedNode = doc.DocumentNode.SelectSingleNode("//span[@id='LowVelocityLICAProximalLabel']");
            var findingVelocityLica = findingVelocityLicaList.FirstOrDefault();
            if (selectedNode != null && findingVelocityLica != null)
            {
                selectedNode.InnerHtml = findingVelocityLica.Label;
            }

            selectedNode = doc.DocumentNode.SelectSingleNode("//span[@id='LowVelocityRICAProximalLabel']");
            var findingVelocityRica = findingVelocityRicaList.FirstOrDefault();
            if (selectedNode != null && findingVelocityRica != null)
            {
                selectedNode.InnerHtml = findingVelocityRica.Label;
            }

            var getAbsValue = new Func<ResultReading<decimal?>, ResultReading<decimal?>>(r =>
            {
                if (r != null && r.Reading != null && r.Reading.Value < 0)
                    r.Reading = r.Reading.Value * -1;

                return r;
            });


            if (testResult != null)
            {
                selectedNode = doc.DocumentNode.SelectSingleNode("//div[@id='AwvCarotid-rpp-section']");
                if (selectedNode != null && (testResult.UnableScreenReason == null || testResult.UnableScreenReason.Count == 0) && (testResult.TestNotPerformed == null || testResult.TestNotPerformed.TestNotPerformedReasonId <= 0)
                    && (showUnreadAbleTest || testResult.RepeatStudy == null || testResult.RepeatStudy.Reading == false))
                    selectedNode.SetAttributeValue("style", "display:block;");

                selectedNode = doc.DocumentNode.SelectSingleNode("//div[@id='rpp-eus-AwvCarotid-div']");
                if (selectedNode != null)
                    selectedNode.SetAttributeValue("style", "display:block;");

                _resultPdfHelper.SetPhysicianSignature(doc, "AwvCarotid-primaryEvalPhysicianSign", "AwvCarotid-overreadEvalPhysicianSign", physicians, eventPhysicianTests, eventCustomerPhysicianEvaluations, customerSkipReview);

                var readings = new TestResultRepository().GetAllReadings((int)TestType.AwvCarotid);

                foreach (var resultReading in readings)
                {
                    switch (resultReading.Label)
                    {
                        case ReadingLabels.RCCAProximalPSV:
                            if (testResult.RightResultReadings != null)
                            {
                                testResult.RightResultReadings.CCAProximalPSV = getAbsValue(testResult.RightResultReadings.CCAProximalPSV);
                                _resultPdfHelper.SetInputBox(doc, "RCCAProximalPSVInputText", testResult.RightResultReadings.CCAProximalPSV);
                            }
                            break;
                        case ReadingLabels.RCCAProximalEDV:
                            if (testResult.RightResultReadings != null)
                            {
                                testResult.RightResultReadings.CCAProximalPSV = getAbsValue(testResult.RightResultReadings.CCAProximalEDV);
                                _resultPdfHelper.SetInputBox(doc, "RCCAProximalEDVInputText", testResult.RightResultReadings.CCAProximalEDV);
                            }
                            break;
                        case ReadingLabels.LCCAProximalPSV:
                            if (testResult.RightResultReadings != null)
                            {
                                testResult.LeftResultReadings.CCAProximalPSV = getAbsValue(testResult.LeftResultReadings.CCAProximalPSV);
                                _resultPdfHelper.SetInputBox(doc, "LCCAProximalPSVInputText", testResult.LeftResultReadings.CCAProximalPSV);
                            }
                            break;
                        case ReadingLabels.LCCAProximalEDV:
                            if (testResult.RightResultReadings != null)
                            {
                                testResult.LeftResultReadings.CCAProximalEDV = getAbsValue(testResult.LeftResultReadings.CCAProximalEDV);
                                _resultPdfHelper.SetInputBox(doc, "LCCAProximalEDVInputText", testResult.LeftResultReadings.CCAProximalEDV);
                            }
                            break;

                        case ReadingLabels.RCCADistalPSV:
                            if (testResult.RightResultReadings != null)
                            {
                                testResult.RightResultReadings.CCADistalPSV = getAbsValue(testResult.RightResultReadings.CCADistalPSV);
                                _resultPdfHelper.SetInputBox(doc, "RCCADistalPSVInputText", testResult.RightResultReadings.CCADistalPSV);
                            }
                            break;
                        case ReadingLabels.RCCADistalEDV:
                            if (testResult.RightResultReadings != null)
                            {
                                testResult.RightResultReadings.CCADistalEDV = getAbsValue(testResult.RightResultReadings.CCADistalEDV);
                                _resultPdfHelper.SetInputBox(doc, "RCCADistalEDVInputText", testResult.RightResultReadings.CCADistalEDV);
                            }
                            break;
                        case ReadingLabels.LCCADistalPSV:
                            if (testResult.RightResultReadings != null)
                            {
                                testResult.LeftResultReadings.CCADistalPSV = getAbsValue(testResult.LeftResultReadings.CCADistalPSV);
                                _resultPdfHelper.SetInputBox(doc, "LCCADistalPSVInputText", testResult.LeftResultReadings.CCADistalPSV);
                            }
                            break;
                        case ReadingLabels.LCCADistalEDV:
                            if (testResult.RightResultReadings != null)
                            {
                                testResult.LeftResultReadings.CCADistalEDV = getAbsValue(testResult.LeftResultReadings.CCADistalEDV);
                                _resultPdfHelper.SetInputBox(doc, "LCCADistalEDVInputText", testResult.LeftResultReadings.CCADistalEDV);
                            }
                            break;
                        /**Bulb**/
                        case ReadingLabels.RBulbPSV:
                            if (testResult.RightResultReadings != null)
                            {
                                testResult.RightResultReadings.BulbPSV = getAbsValue(testResult.RightResultReadings.BulbPSV);
                                _resultPdfHelper.SetInputBox(doc, "RBulbPSVInputText", testResult.RightResultReadings.BulbPSV);
                            }
                            break;
                        case ReadingLabels.RBulbEDV:
                            if (testResult.RightResultReadings != null)
                            {
                                testResult.RightResultReadings.BulbEDV = getAbsValue(testResult.RightResultReadings.BulbEDV);
                                _resultPdfHelper.SetInputBox(doc, "RBulbEDVInputText", testResult.RightResultReadings.BulbEDV);
                            }
                            break;
                        case ReadingLabels.LBulbPSV:
                            if (testResult.RightResultReadings != null)
                            {
                                testResult.LeftResultReadings.BulbPSV = getAbsValue(testResult.LeftResultReadings.BulbPSV);
                                _resultPdfHelper.SetInputBox(doc, "LBulbPSVInputText", testResult.LeftResultReadings.BulbPSV);
                            }
                            break;
                        case ReadingLabels.LBulbEDV:
                            if (testResult.RightResultReadings != null)
                            {
                                testResult.LeftResultReadings.BulbEDV = getAbsValue(testResult.LeftResultReadings.BulbEDV);
                                _resultPdfHelper.SetInputBox(doc, "LBulbEDVInputText", testResult.LeftResultReadings.BulbEDV);
                            }
                            break;
                        /**EXT CAROTID ART**/
                        case ReadingLabels.RExtCarotidArtPSV:
                            if (testResult.RightResultReadings != null)
                            {
                                testResult.RightResultReadings.ExtCarotidArtPSV = getAbsValue(testResult.RightResultReadings.ExtCarotidArtPSV);
                                _resultPdfHelper.SetInputBox(doc, "RExtCarotidArtPSVInputText", testResult.RightResultReadings.ExtCarotidArtPSV);
                            }
                            break;
                        case ReadingLabels.LExtCarotidArtPSV:
                            if (testResult.RightResultReadings != null)
                            {
                                testResult.LeftResultReadings.ExtCarotidArtPSV = getAbsValue(testResult.LeftResultReadings.ExtCarotidArtPSV);
                                _resultPdfHelper.SetInputBox(doc, "LExtCarotidArtPSVInputText", testResult.LeftResultReadings.ExtCarotidArtPSV);
                            }
                            break;
                        /**ICA PROXIMAL**/
                        case ReadingLabels.RICAPSV:
                            if (testResult.RightResultReadings != null)
                            {
                                testResult.RightResultReadings.ICAProximalPSV = getAbsValue(testResult.RightResultReadings.ICAProximalPSV);
                                _resultPdfHelper.SetInputBox(doc, "RICAProximalPSVInputText", testResult.RightResultReadings.ICAProximalPSV);
                            }
                            break;
                        case ReadingLabels.RICAEDV:
                            if (testResult.RightResultReadings != null)
                            {
                                testResult.RightResultReadings.ICAProximalEDV = getAbsValue(testResult.RightResultReadings.ICAProximalEDV);
                                _resultPdfHelper.SetInputBox(doc, "RICAProximalEDVInputText", testResult.RightResultReadings.ICAProximalEDV);
                            }
                            break;
                        case ReadingLabels.LICAPSV:
                            if (testResult.RightResultReadings != null)
                            {
                                testResult.LeftResultReadings.ICAProximalPSV = getAbsValue(testResult.LeftResultReadings.ICAProximalPSV);
                                _resultPdfHelper.SetInputBox(doc, "LICAProximalPSVInputText", testResult.LeftResultReadings.ICAProximalPSV);
                            }
                            break;
                        case ReadingLabels.LICAEDV:
                            if (testResult.RightResultReadings != null)
                            {
                                testResult.LeftResultReadings.ICAProximalEDV = getAbsValue(testResult.LeftResultReadings.ICAProximalEDV);
                                _resultPdfHelper.SetInputBox(doc, "LICAProximalEDVInputText", testResult.LeftResultReadings.ICAProximalEDV);
                            }
                            break;

                        /**ICA Distal**/
                        case ReadingLabels.RICADistalPSV:
                            if (testResult.RightResultReadings != null)
                            {
                                testResult.RightResultReadings.ICADistalPSV = getAbsValue(testResult.RightResultReadings.ICADistalPSV);
                                _resultPdfHelper.SetInputBox(doc, "RICADistalPSVInputText", testResult.RightResultReadings.ICADistalPSV);
                            }
                            break;
                        case ReadingLabels.RICADistalEDV:
                            if (testResult.RightResultReadings != null)
                            {
                                testResult.RightResultReadings.ICADistalEDV = getAbsValue(testResult.RightResultReadings.ICADistalEDV);
                                _resultPdfHelper.SetInputBox(doc, "RICADistalEDVInputText", testResult.RightResultReadings.ICADistalEDV);
                            }
                            break;
                        case ReadingLabels.LICADistalPSV:
                            if (testResult.RightResultReadings != null)
                            {
                                testResult.LeftResultReadings.ICADistalPSV = getAbsValue(testResult.LeftResultReadings.ICADistalPSV);
                                _resultPdfHelper.SetInputBox(doc, "LICADistalPSVInputText", testResult.LeftResultReadings.ICADistalPSV);
                            }
                            break;
                        case ReadingLabels.LICADistalEDV:
                            if (testResult.RightResultReadings != null)
                            {
                                testResult.LeftResultReadings.ICADistalEDV = getAbsValue(testResult.LeftResultReadings.ICADistalEDV);
                                _resultPdfHelper.SetInputBox(doc, "LICADistalEDVInputText", testResult.LeftResultReadings.ICADistalEDV);
                            }
                            break;
                        /**VERTEBRAL ART**/
                        case ReadingLabels.RVertebralArtPSV:
                            if (testResult.RightResultReadings != null)
                            {
                                testResult.RightResultReadings.VertebralArtPSV = getAbsValue(testResult.RightResultReadings.VertebralArtPSV);
                                _resultPdfHelper.SetInputBox(doc, "RVertebralArtPSVInputText", testResult.RightResultReadings.VertebralArtPSV);
                            }
                            break;
                        case ReadingLabels.RVertebralArtEDV:
                            if (testResult.RightResultReadings != null)
                            {
                                testResult.RightResultReadings.VertebralArtEDV = getAbsValue(testResult.RightResultReadings.VertebralArtEDV);
                                _resultPdfHelper.SetInputBox(doc, "RVertebralArtEDVInputText", testResult.RightResultReadings.VertebralArtEDV);
                            }
                            break;
                        case ReadingLabels.LVertebralArtPSV:
                            if (testResult.RightResultReadings != null)
                            {
                                testResult.LeftResultReadings.ICADistalPSV = getAbsValue(testResult.LeftResultReadings.VertebralArtPSV);
                                _resultPdfHelper.SetInputBox(doc, "LVertebralArtPSVInputText", testResult.LeftResultReadings.VertebralArtPSV);
                            }
                            break;
                        case ReadingLabels.LVertebralArtEDV:
                            if (testResult.RightResultReadings != null)
                            {
                                testResult.LeftResultReadings.VertebralArtEDV = getAbsValue(testResult.LeftResultReadings.VertebralArtEDV);
                                _resultPdfHelper.SetInputBox(doc, "LVertebralArtEDVInputText", testResult.LeftResultReadings.VertebralArtEDV);
                            }
                            break;
                        case ReadingLabels.TechnicallyLimitedbutReadable:
                            _resultPdfHelper.SetCheckBox(doc, "TechnicallyLimitedbutReadableAwvCarotidInputCheck", testResult.TechnicallyLimitedbutReadable);
                            break;

                        case ReadingLabels.RepeatStudy:
                            _resultPdfHelper.SetCheckBox(doc, "RepeatStudyAwvCarotidInputCheck", testResult.RepeatStudy);
                            break;
                    }
                }

                LoadAwvCarotidFindings(doc, testResult);

                if (findingVelocityLicaList != null)
                {
                    selectedNode = doc.DocumentNode.SelectSingleNode("//input[@id='LowVelocityCheckbox']");
                    if (selectedNode != null && testResult.LowVelocityLica != null)
                    {
                        selectedNode.SetAttributeValue("checked", "checked");
                    }

                    selectedNode = doc.DocumentNode.SelectSingleNode("//input[@id='LowVelocityLICAProximalCheckbox']");
                    if (selectedNode != null && testResult.LowVelocityLica != null)
                    {
                        selectedNode.SetAttributeValue("checked", "checked");
                    }
                }

                if (findingVelocityLicaList != null)
                {
                    selectedNode = doc.DocumentNode.SelectSingleNode("//input[@id='LowVelocityRICAProximalCheckbox']");
                    if (selectedNode != null && testResult.LowVelocityRica != null)
                    {
                        selectedNode.SetAttributeValue("checked", "checked");
                    }
                }

                _resultPdfHelper.LoadTestMedia(doc, testResult.ResultImages, "testmedia-AwvCarotid", loadImages);
                LoadAwvCarotidIncidentalFindings(doc, incidentalFindings, testResult.IncidentalFindings);
                _resultPdfHelper.SetUnableToScreenReasons(doc, TestType.AwvCarotid, "AwvCarotidUnableToScreen", testResult.UnableScreenReason);
                _resultPdfHelper.SetTechnician(doc, testResult, "techAwvCarotid", "technotesAwvCarotid", technicianIdNamePairs);
                _resultPdfHelper.SetPhysicianRemarks(doc, testResult, "followUpAwvCarotid", "criticalAwvCarotid", "physicianRemarksAwvCarotid");

                if (testResult.IncidentalFindings != null && testResult.IncidentalFindings.Any())
                {
                    selectedNode = doc.DocumentNode.SelectSingleNode("//p[@id='incidentalfinding-description-AwvCarotid']");
                    if (selectedNode != null) selectedNode.SetAttributeValue("style", "display:block;");
                }

                selectedNode = doc.DocumentNode.SelectSingleNode("//div[@id='AwvCarotid-longdescription-div']");
                if (selectedNode != null)
                    selectedNode.SetAttributeValue("style", removeLongDescription ? "display:none" : "display:block");
            }
            else
            {
                LoadAwvCarotidFindings(doc, null, false);
                _resultPdfHelper.SetIncidentalFindings(doc, incidentalFindings, null, "AwvCarotidIncidenatlFindings");
                _resultPdfHelper.SetUnableToScreenReasons(doc, TestType.AwvCarotid, "AwvCarotidUnableToScreen", null);
            }
        }

        private void LoadAwvCarotidIncidentalFindings(HtmlDocument doc, IEnumerable<IncidentalFinding> allFortheTest, IEnumerable<IncidentalFinding> recordedForthecurrentRecord)
        {
            const int ifIrregularPatternDoppler = 101;

            if (recordedForthecurrentRecord != null && recordedForthecurrentRecord.Any(ifd => ifd.Id == ifIrregularPatternDoppler))
            {
                var selectedNode = doc.DocumentNode.SelectSingleNode("//p[@id='ifdescription-irregulardoppler-AwvCarotid']");
                if (selectedNode != null) selectedNode.SetAttributeValue("style", "display:block;");
            }

            _resultPdfHelper.SetIncidentalFindings(doc, allFortheTest, recordedForthecurrentRecord, "AwvCarotidIncidenatlFindings");
        }

        private void LoadAwvCarotidFindings(HtmlDocument doc, AwvCarotidTestResult testResult, bool isTestPurchased = true)
        {
            var standardFindingList = _standardFindingRepository.GetAllStandardFindings<decimal>((int)TestType.AwvCarotid, (int)ReadingLabels.Left);
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

            if (testResult != null && testResult.UnableScreenReason != null && testResult.UnableScreenReason.Count > 0 && testResult.UnableScreenReason.All(us => us.Reason != UnableToScreenReason.TechnicallyLimitedImages))
                unableScreenReason = testResult.UnableScreenReason.First();

            _resultPdfHelper.SetSummaryFindings(doc, finding, standardFindingList, "FindingsAwvCarotidDiv", "long-description-AwvCarotid", null, isTestPurchased, unableScreenReason);

            HtmlNode selectedNode;
            if (finding != null)
            {
                var stdFinding = standardFindingList.Single(f => f.Id == finding.Id);

                selectedNode = doc.DocumentNode.SelectSingleNode("//span[@id='AwvCarotid-rpp-resultspan']");
                if (selectedNode != null)
                    selectedNode.InnerHtml = stdFinding.Label;

                selectedNode = doc.DocumentNode.SelectSingleNode("//div[@id='docletter-AwvCarotid']");
                if (stdFinding.ResultInterpretation != null && stdFinding.ResultInterpretation.Value != (long)ResultInterpretation.Normal && selectedNode != null)
                    selectedNode.SetAttributeValue("style", "display:block;");
            }

            string htmlRows = "";
            string hcpCarotidDescription = "<fieldset><legend>STENOSIS RANGE</legend><Table>";
            foreach (var standardFinding in standardFindingList)
            {
                string rowString = "<tr>";
                hcpCarotidDescription += "<tr>";
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

                rowString += "<td style='float:left; width:110px; padding-left:10px; text-align:left;'> " + standardFinding.Label + "</td>";//.Replace("<", "&lt;")
                rowString += "<td> " + standardFinding.Description + "</td></tr>";


                htmlRows = htmlRows + rowString;
            }

            hcpCarotidDescription += "</Table></fieldset>";

            selectedNode = doc.DocumentNode.SelectSingleNode("//table[@id='AwvCarotidFinding']");
            if (selectedNode != null)
            {
                selectedNode.InnerHtml += htmlRows;
            }

            selectedNode = doc.DocumentNode.SelectSingleNode("//div[@id='AwvCarotidFindingDescriptionDiv']");
            if (selectedNode != null)
            {
                selectedNode.InnerHtml += hcpCarotidDescription;
            }
        }
    }
}
