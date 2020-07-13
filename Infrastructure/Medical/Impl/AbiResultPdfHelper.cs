using System.Collections.Generic;
using System.Linq;
using Falcon.App.Core;
using Falcon.App.Core.Application.Attributes;
using Falcon.App.Core.Interfaces;
using Falcon.App.Core.Medical;
using Falcon.App.Core.Medical.Domain;
using Falcon.App.Core.Medical.Enum;
using Falcon.App.Core.Medical.ViewModels;
using Falcon.App.Core.Operations.Domain;
using Falcon.App.Infrastructure.Repositories.Screening;
using HtmlAgilityPack;

namespace Falcon.App.Infrastructure.Medical.Impl
{
    [DefaultImplementation]
    public class AbiResultPdfHelper : IAbiResultPdfHelper
    {
        private readonly IResultPdfHelper _resultPdfHelper;
        private readonly IStandardFindingRepository _standardFindingRepository;
        private readonly IIncidentalFindingRepository _incidentalFindingRepository;
        private readonly Service.TestResultService _testResultService;

        private const string PadNormal = "NORMAL";
        private const string PadMild = "MILD";
        private const string PadModerate = "MODERATE";
        private const string PadSevere = "Severe";
        private const string StringforContentDirectory = "content";

        public AbiResultPdfHelper(IResultPdfHelper resultPdfHelper, IStandardFindingRepository standardFindingRepository, IIncidentalFindingRepository incidentalFindingRepository)
        {
            _resultPdfHelper = resultPdfHelper;
            _standardFindingRepository = standardFindingRepository;
            _incidentalFindingRepository = incidentalFindingRepository;
            _testResultService = new Service.TestResultService();
        }

        public void LoadPadTestResults(HtmlDocument doc, PADTestResult testResult, bool removeLongDescription, IEnumerable<CustomerScreeningEvaluatinPhysicianViewModel> physicians, IEnumerable<EventPhysicianTest> eventPhysicianTests,
            List<OrderedPair<long, string>> technicianIdNamePairs, IEnumerable<PhysicianEvaluation> eventCustomerPhysicianEvaluations, CustomerSkipReview customerSkipReview)
        {
            var incidentalFindings = _incidentalFindingRepository.GetAllIncidentalFinding((int)TestType.PAD);

            if (testResult != null)
            {
                var selectedNode = doc.DocumentNode.SelectSingleNode("//div[@id='pad-rpp-section']");
                if (selectedNode != null && (testResult.UnableScreenReason == null || testResult.UnableScreenReason.Count == 0) && (testResult.TestNotPerformed == null || testResult.TestNotPerformed.TestNotPerformedReasonId <= 0)
                    && (testResult.RepeatStudy == null || testResult.RepeatStudy.Reading == false))
                    selectedNode.SetAttributeValue("style", "display:block;");

                selectedNode = doc.DocumentNode.SelectSingleNode("//div[@id='rpp-eus-pad-div']");
                if (selectedNode != null)
                    selectedNode.SetAttributeValue("style", "display:block;");

                _resultPdfHelper.SetPhysicianSignature(doc, "pad-primaryEvalPhysicianSign", "pad-overreadEvalPhysicianSign", physicians, eventPhysicianTests, eventCustomerPhysicianEvaluations, customerSkipReview);

                var readings = new TestResultRepository().GetAllReadings((int)TestType.PAD);
                decimal? leftAbi = null;
                decimal? rightAbi = null;

                foreach (var resultReading in readings)
                {
                    switch (resultReading.Label)
                    {
                        case ReadingLabels.LeftABI:
                            if (testResult.LeftResultReadings != null)
                            {
                                _resultPdfHelper.SetInputBox(doc, "txtLeftAbi", testResult.LeftResultReadings.ABI);

                                if (testResult.LeftResultReadings.ABI != null && testResult.LeftResultReadings.ABI.Reading.HasValue)
                                {
                                    leftAbi = testResult.LeftResultReadings.ABI.Reading;

                                    selectedNode = doc.DocumentNode.SelectSingleNode("//span[@id='pad-at-a-glance-finding-left']");
                                    if (selectedNode != null)
                                        selectedNode.InnerHtml = testResult.LeftResultReadings.ABI.Reading.Value.ToString("0.00");
                                }
                            }
                            break;

                        case ReadingLabels.SystolicLArm:
                            if (testResult.LeftResultReadings != null)
                                _resultPdfHelper.SetInputBox(doc, "txtSystolicLeftArm", testResult.LeftResultReadings.SystolicArm);
                            break;

                        case ReadingLabels.SystolicLAnkle:
                            if (testResult.LeftResultReadings != null)
                                _resultPdfHelper.SetInputBox(doc, "txtSystolicLeftAnkle", testResult.LeftResultReadings.SystolicAnkle);
                            break;

                        case ReadingLabels.RightABI:
                            if (testResult.RightResultReadings != null)
                            {
                                _resultPdfHelper.SetInputBox(doc, "txtRightAbi", testResult.RightResultReadings.ABI);
                                if (testResult.RightResultReadings.ABI != null && testResult.RightResultReadings.ABI.Reading.HasValue)
                                {
                                    rightAbi = testResult.RightResultReadings.ABI.Reading;

                                    selectedNode = doc.DocumentNode.SelectSingleNode("//span[@id='pad-at-a-glance-finding-right']");
                                    if (selectedNode != null)
                                        selectedNode.InnerHtml = testResult.RightResultReadings.ABI.Reading.Value.ToString("0.00");
                                }
                            }
                            break;

                        case ReadingLabels.SystolicRArm:
                            if (testResult.RightResultReadings != null)
                                _resultPdfHelper.SetInputBox(doc, "txtSystolicRightArm", testResult.RightResultReadings.SystolicArm);
                            break;

                        case ReadingLabels.SystolicRAnkle:
                            if (testResult.RightResultReadings != null)
                                _resultPdfHelper.SetInputBox(doc, "txtSystolicRightAnkle", testResult.RightResultReadings.SystolicAnkle);
                            break;

                        case ReadingLabels.SystolicHighestArm:
                            _resultPdfHelper.SetInputBox(doc, "systolicHighestArm", testResult.SystolicHighestArm);
                            break;

                        case ReadingLabels.RepeatStudy:
                            _resultPdfHelper.SetCheckBox(doc, "RepeatStudyPadInputCheck", testResult.RepeatStudy);
                            break;

                        case ReadingLabels.LeftUnabletoOcclude:
                            if (testResult.LeftResultReadings != null)
                                _resultPdfHelper.SetCheckBox(doc, "leftunabletoocclude-checkbox", testResult.LeftResultReadings.UnabletoOcclude);

                            break;

                        case ReadingLabels.RightUnabletoOcclude:
                            if (testResult.RightResultReadings != null)
                                _resultPdfHelper.SetCheckBox(doc, "rightunabletoocclude-checkbox", testResult.RightResultReadings.UnabletoOcclude);

                            break;

                    }
                }

                decimal? abi;
                long leftFindingId = 0;
                if (leftAbi != null)
                {
                    leftFindingId = _testResultService.GetCalculatedStandardFinding(leftAbi.Value, (int)TestType.PAD, null);
                }

                long rightFindingId = 0;
                if (rightAbi != null)
                {
                    rightFindingId = _testResultService.GetCalculatedStandardFinding(rightAbi.Value, (int)TestType.PAD, null);
                }

                var standardFindingList = _standardFindingRepository.GetAllStandardFindings<decimal>((int)TestType.PAD);

                long findingId = 0;

                if (leftFindingId == rightFindingId)
                {
                    findingId = leftFindingId;
                }
                else if (leftFindingId > 0 && rightFindingId > 0)
                {
                    var lf = standardFindingList.Where(f => f.Id == leftFindingId).Single();
                    var rf = standardFindingList.Where(f => f.Id == rightFindingId).Single();

                    findingId = lf.WorstCaseOrder > rf.WorstCaseOrder ? lf.Id : rf.Id;
                }
                else
                {
                    findingId = leftFindingId > rightFindingId ? leftFindingId : rightFindingId;
                }

                if (findingId > 0 && findingId == leftFindingId)
                {
                    abi = leftAbi;
                }
                else
                {
                    abi = rightAbi;
                }

                _resultPdfHelper.SetInputBox(doc, "abi-pad-summary", new ResultReading<decimal?> { Reading = abi });
                LoadPadFindings(doc, testResult.Finding, standardFindingList, findingId, true, (testResult.UnableScreenReason != null && testResult.UnableScreenReason.Count > 0 ? testResult.UnableScreenReason.First() : null));
                _resultPdfHelper.SetTechnician(doc, testResult, "techPad", "technotespad", technicianIdNamePairs);
                _resultPdfHelper.SetIncidentalFindings(doc, incidentalFindings, testResult.IncidentalFindings, "padIncidentalFinding");
                _resultPdfHelper.SetPhysicianRemarks(doc, testResult, "followUpPad", "criticalPad", "physicianRemarksPad");
                _resultPdfHelper.SetUnableToScreenReasons(doc, TestType.PAD, "padUnableToScreen", testResult.UnableScreenReason);

                if (testResult.IncidentalFindings != null && testResult.IncidentalFindings.Count() > 0)
                {
                    selectedNode = doc.DocumentNode.SelectSingleNode("//p[@id='incidentalfinding-description-pad']");
                    if (selectedNode != null) selectedNode.SetAttributeValue("style", "display:block;");
                }
                if (testResult.Finding != null)
                {
                    selectedNode = doc.DocumentNode.SelectSingleNode("//span[@id='pad-at-a-glance-result']");
                    if (selectedNode != null && testResult.ResultInterpretation.HasValue)
                        selectedNode.InnerHtml = ((ResultInterpretation)testResult.ResultInterpretation).ToString();


                    selectedNode = doc.DocumentNode.SelectSingleNode("//img[@id='pad-at-a-glance-findingImage']");
                    if (selectedNode != null)
                    {
                        if (testResult.Finding.Label.ToLower() == PadNormal.ToLower())
                            selectedNode.SetAttributeValue("src", StringforContentDirectory + "/NMMSV_N.png");
                        else if (testResult.Finding.Label.ToLower() == PadMild.ToLower())
                            selectedNode.SetAttributeValue("src", StringforContentDirectory + "/NMMSV_M.png");
                        else if (testResult.Finding.Label.ToLower() == PadModerate.ToLower())
                            selectedNode.SetAttributeValue("src", StringforContentDirectory + "/NMMSV_MD.png");
                        else if (testResult.Finding.Label.ToLower() == PadSevere.ToLower())
                            selectedNode.SetAttributeValue("src", StringforContentDirectory + "/NMMSV_S.png");
                        else
                            selectedNode.SetAttributeValue("src", StringforContentDirectory + "/NoIndication_NMMSV.png");
                    }
                }

                if (testResult.UnableScreenReason != null && testResult.UnableScreenReason.Count > 0)
                {
                    selectedNode = doc.DocumentNode.SelectSingleNode("//div[@id='pad-at-a-glance-finding']");
                    if (selectedNode != null)
                        selectedNode.SetAttributeValue("style", "display:none;");

                    selectedNode = doc.DocumentNode.SelectSingleNode("//div[@id='pad-at-a-glance-unabletoscreen']");
                    if (selectedNode != null)
                        selectedNode.SetAttributeValue("style", "display:block;");

                    selectedNode = doc.DocumentNode.SelectSingleNode("//span[@id='pad-at-a-glance-result']");
                    if (selectedNode != null)
                        selectedNode.InnerHtml = "N/A";

                    selectedNode = doc.DocumentNode.SelectSingleNode("//img[@id='pad-at-a-glance-findingImage']");
                    if (selectedNode != null)
                        selectedNode.SetAttributeValue("src", StringforContentDirectory + "/NoIndication_NMMSV.png");
                }

                selectedNode = doc.DocumentNode.SelectSingleNode("//div[@id='pad-longdescription-div']");
                if (selectedNode != null)
                    selectedNode.SetAttributeValue("style", removeLongDescription ? "display:none" : "display:block");
            }
            else
            {
                LoadPadFindings(doc, null, null, 0, false);
                _resultPdfHelper.SetUnableToScreenReasons(doc, TestType.PAD, "padUnableToScreen", null);
                _resultPdfHelper.SetIncidentalFindings(doc, incidentalFindings, null, "padIncidentalFinding");
            }
        }

        private void LoadPadFindings(HtmlDocument doc, StandardFinding<decimal> finding, IEnumerable<StandardFinding<decimal>> standardFindingList, long findingIdForLongDescription = 0, bool isTestPurchased = true, UnableScreenReason unableScreenReason = null)
        {
            if (standardFindingList == null)
                standardFindingList = _standardFindingRepository.GetAllStandardFindings<decimal>((int)TestType.PAD);

            //if (standardFindingList.Count() > 0 && standardFindingList.First().WorstCaseOrder > 0)
            //{
            //    standardFindingList = standardFindingList.OrderBy(f => f.WorstCaseOrder).ToList();
            //}
            standardFindingList = standardFindingList.OrderBy(f => f.Id).ToList();
            StandardFinding<decimal> findingForLongDescription = null;
            if (findingIdForLongDescription > 0)
            {
                findingForLongDescription =
                    standardFindingList.Where(sf => sf.Id == findingIdForLongDescription).SingleOrDefault();
            }

            if (finding != null)
            {
                var stdFinding = standardFindingList.Where(f => f.Id == finding.Id).Single();

                var selectedNode = doc.DocumentNode.SelectSingleNode("//span[@id='pad-rpp-resultspan']");
                if (selectedNode != null)
                    selectedNode.InnerHtml = stdFinding.Label;

                selectedNode = doc.DocumentNode.SelectSingleNode("//div[@id='docletter-abi']");
                if (stdFinding.ResultInterpretation != null && stdFinding.ResultInterpretation.Value != (long)ResultInterpretation.Normal && selectedNode != null)
                    selectedNode.SetAttributeValue("style", "display:block;");
            }

            _resultPdfHelper.SetSummaryFindings(doc, finding, standardFindingList, "FindingsPadDiv", "longdescription-pad", findingForLongDescription, isTestPurchased, unableScreenReason);
            _resultPdfHelper.SetFindingsVertical(doc, finding, standardFindingList, "padFinding");
        }

        public void PadOverlayResults(HtmlDocument doc, PADTestResult padTestResult)
        {
            var selectedNode = doc.DocumentNode.SelectSingleNode("//div[@id='AnkleBrachialIndexDiv']");
            if (selectedNode != null) selectedNode.SetAttributeValue("style", "display:block;");

            if (padTestResult != null)
            {
                var readings = new TestResultRepository().GetAllReadings((int)TestType.PAD);
                foreach (var resultReading in readings)
                {
                    switch (resultReading.Label)
                    {
                        case ReadingLabels.LeftABI:
                            if (padTestResult.LeftResultReadings != null)
                                _resultPdfHelper.SetInputBox(doc, "LeftAbi", padTestResult.LeftResultReadings.ABI);
                            break;

                        case ReadingLabels.SystolicLArm:
                            if (padTestResult.LeftResultReadings != null)
                                _resultPdfHelper.SetInputBox(doc, "leftArmSystolicPressure", padTestResult.LeftResultReadings.SystolicArm);
                            break;

                        case ReadingLabels.SystolicLAnkle:
                            if (padTestResult.LeftResultReadings != null)
                                _resultPdfHelper.SetInputBox(doc, "LeftAnkleSystolicPressure", padTestResult.LeftResultReadings.SystolicAnkle);
                            break;

                        case ReadingLabels.RightABI:
                            if (padTestResult.RightResultReadings != null)
                                _resultPdfHelper.SetInputBox(doc, "RightAbi", padTestResult.RightResultReadings.ABI);
                            break;

                        case ReadingLabels.SystolicRArm:
                            if (padTestResult.RightResultReadings != null)
                                _resultPdfHelper.SetInputBox(doc, "RightArmSystolicPressure", padTestResult.RightResultReadings.SystolicArm);
                            break;

                        case ReadingLabels.SystolicRAnkle:
                            if (padTestResult.RightResultReadings != null)
                                _resultPdfHelper.SetInputBox(doc, "RightAnkleSystolicPressure", padTestResult.RightResultReadings.SystolicAnkle);
                            break;
                    }
                }
            }
        }

        public void LoadAwvAbiTestResults(HtmlDocument doc, AwvAbiTestResult testResult, bool removeLongDescription, IEnumerable<CustomerScreeningEvaluatinPhysicianViewModel> physicians, IEnumerable<EventPhysicianTest> eventPhysicianTests,
            List<OrderedPair<long, string>> technicianIdNamePairs, bool showUnreadableTest, IEnumerable<PhysicianEvaluation> eventCustomerPhysicianEvaluations, CustomerSkipReview customerSkipReview)
        {
            var incidentalFindings = _incidentalFindingRepository.GetAllIncidentalFinding((int)TestType.PAD);

            if (testResult != null)
            {
                var selectedNode = doc.DocumentNode.SelectSingleNode("//div[@id='AwvAbi-rpp-section']");
                if (selectedNode != null && (testResult.UnableScreenReason == null || testResult.UnableScreenReason.Count == 0) && (testResult.TestNotPerformed == null || testResult.TestNotPerformed.TestNotPerformedReasonId <= 0)
                    && (showUnreadableTest || testResult.RepeatStudy == null || testResult.RepeatStudy.Reading == false))
                    selectedNode.SetAttributeValue("style", "display:block;");

                selectedNode = doc.DocumentNode.SelectSingleNode("//div[@id='rpp-eus-AwvAbi-div']");
                if (selectedNode != null)
                    selectedNode.SetAttributeValue("style", "display:block;");

                _resultPdfHelper.SetPhysicianSignature(doc, "AwvAbi-primaryEvalPhysicianSign", "AwvAbi-overreadEvalPhysicianSign", physicians, eventPhysicianTests, eventCustomerPhysicianEvaluations, customerSkipReview);

                var readings = new TestResultRepository().GetAllReadings((int)TestType.PAD);
                decimal? leftAbi = null;
                decimal? rightAbi = null;

                foreach (var resultReading in readings)
                {
                    switch (resultReading.Label)
                    {
                        case ReadingLabels.LeftABI:
                            if (testResult.LeftResultReadings != null)
                            {
                                _resultPdfHelper.SetInputBox(doc, "AwvAbitxtLeftAbi", testResult.LeftResultReadings.ABI);

                                if (testResult.LeftResultReadings.ABI != null && testResult.LeftResultReadings.ABI.Reading.HasValue)
                                {
                                    leftAbi = testResult.LeftResultReadings.ABI.Reading;
                                }
                            }
                            break;

                        case ReadingLabels.SystolicLArm:
                            if (testResult.LeftResultReadings != null)
                                _resultPdfHelper.SetInputBox(doc, "AwvAbitxtSystolicLeftArm", testResult.LeftResultReadings.SystolicArm);
                            break;

                        case ReadingLabels.SystolicLAnkle:
                            if (testResult.LeftResultReadings != null)
                                _resultPdfHelper.SetInputBox(doc, "AwvAbitxtSystolicLeftAnkle", testResult.LeftResultReadings.SystolicAnkle);
                            break;

                        case ReadingLabels.RightABI:
                            if (testResult.RightResultReadings != null)
                            {
                                _resultPdfHelper.SetInputBox(doc, "AwvAbitxtRightAbi", testResult.RightResultReadings.ABI);

                                if (testResult.RightResultReadings.ABI != null && testResult.RightResultReadings.ABI.Reading.HasValue)
                                {
                                    rightAbi = testResult.RightResultReadings.ABI.Reading;
                                }
                            }
                            break;

                        case ReadingLabels.SystolicRArm:
                            if (testResult.RightResultReadings != null)
                                _resultPdfHelper.SetInputBox(doc, "AwvAbitxtSystolicRightArm", testResult.RightResultReadings.SystolicArm);
                            break;

                        case ReadingLabels.SystolicRAnkle:
                            if (testResult.RightResultReadings != null)
                                _resultPdfHelper.SetInputBox(doc, "AwvAbitxtSystolicRightAnkle", testResult.RightResultReadings.SystolicAnkle);
                            break;

                        case ReadingLabels.RepeatStudy:
                            _resultPdfHelper.SetCheckBox(doc, "RepeatStudyAwvAbiInputCheck", testResult.RepeatStudy);
                            break;

                    }
                }

                long leftFindingId = 0;
                if (leftAbi != null)
                {
                    leftFindingId = _testResultService.GetCalculatedStandardFinding(leftAbi.Value, (int)TestType.AwvABI, null);
                }

                long rightFindingId = 0;
                if (rightAbi != null)
                {
                    rightFindingId = _testResultService.GetCalculatedStandardFinding(rightAbi.Value, (int)TestType.AwvABI, null);
                }

                var standardFindingList = _standardFindingRepository.GetAllStandardFindings<decimal>((int)TestType.AwvABI);

                long findingId = 0;

                if (leftFindingId == rightFindingId)
                {
                    findingId = leftFindingId;
                }
                else if (leftFindingId > 0 && rightFindingId > 0)
                {
                    var lf = standardFindingList.Single(f => f.Id == leftFindingId);
                    var rf = standardFindingList.Single(f => f.Id == rightFindingId);

                    findingId = lf.WorstCaseOrder > rf.WorstCaseOrder ? lf.Id : rf.Id;
                }
                else
                {
                    findingId = leftFindingId > rightFindingId ? leftFindingId : rightFindingId;
                }

                LoadAwvAbiFindings(doc, testResult.Finding, standardFindingList, findingId, true, (testResult.UnableScreenReason != null && testResult.UnableScreenReason.Count > 0 ? testResult.UnableScreenReason.First() : null));
                _resultPdfHelper.SetTechnician(doc, testResult, "techAwvAbi", "technotesAwvAbi", technicianIdNamePairs);
                _resultPdfHelper.SetIncidentalFindings(doc, incidentalFindings, testResult.IncidentalFindings, "AwvAbiIncidentalFinding");
                _resultPdfHelper.SetPhysicianRemarks(doc, testResult, "followUpAwvAbi", "criticalAwvAbi", "physicianRemarksAwvAbi");
                _resultPdfHelper.SetUnableToScreenReasons(doc, TestType.AwvABI, "AwvAbiUnableToScreen", testResult.UnableScreenReason);

                if (testResult.IncidentalFindings != null && testResult.IncidentalFindings.Any())
                {
                    selectedNode = doc.DocumentNode.SelectSingleNode("//p[@id='incidentalfinding-description-AwvAbi']");
                    if (selectedNode != null) selectedNode.SetAttributeValue("style", "display:block;");
                }
                selectedNode = doc.DocumentNode.SelectSingleNode("//div[@id='AwvAbi-longdescription-div']");
                if (selectedNode != null)
                    selectedNode.SetAttributeValue("style", removeLongDescription ? "display:none" : "display:block");
            }
            else
            {
                LoadAwvAbiFindings(doc, null, null, 0, false);
                _resultPdfHelper.SetUnableToScreenReasons(doc, TestType.AwvABI, "AwvAbiUnableToScreen", null);
                _resultPdfHelper.SetIncidentalFindings(doc, incidentalFindings, null, "AwvAbiIncidentalFinding");
            }
        }

        private void LoadAwvAbiFindings(HtmlDocument doc, StandardFinding<decimal> finding, IEnumerable<StandardFinding<decimal>> standardFindingList, long findingIdForLongDescription = 0, bool isTestPurchased = true, UnableScreenReason unableScreenReason = null)
        {
            if (standardFindingList == null)
                standardFindingList = _standardFindingRepository.GetAllStandardFindings<decimal>((int)TestType.AwvABI);

            standardFindingList = standardFindingList.OrderBy(f => f.Id).ToList();
            StandardFinding<decimal> findingForLongDescription = null;

            if (findingIdForLongDescription > 0)
            {
                findingForLongDescription = standardFindingList.SingleOrDefault(sf => sf.Id == findingIdForLongDescription);
            }

            if (finding != null)
            {
                var stdFinding = standardFindingList.Single(f => f.Id == finding.Id);

                var selectedNode = doc.DocumentNode.SelectSingleNode("//span[@id='AwvAbi-rpp-resultspan']");
                if (selectedNode != null)
                    selectedNode.InnerHtml = stdFinding.Label;

                //todo: docletter-abi
                selectedNode = doc.DocumentNode.SelectSingleNode("//div[@id='docletter-abi']");
                if (stdFinding.ResultInterpretation != null && stdFinding.ResultInterpretation.Value != (long)ResultInterpretation.Normal && selectedNode != null)
                    selectedNode.SetAttributeValue("style", "display:block;");
            }

            _resultPdfHelper.SetSummaryFindings(doc, finding, standardFindingList, "FindingsAwvAbiDiv", "longdescription-AwvAbi", findingForLongDescription, isTestPurchased, unableScreenReason);
            _resultPdfHelper.SetFindingsVertical(doc, finding, standardFindingList, "AwvAbiFinding");
        }

        public void LoadFloChecAbiTestResults(HtmlDocument doc, FloChecABITestResult testResult, bool removeLongDescription, IEnumerable<CustomerScreeningEvaluatinPhysicianViewModel> physicians, IEnumerable<EventPhysicianTest> eventPhysicianTests,
            List<OrderedPair<long, string>> technicianIdNamePairs, bool loadImages, bool showUnreadableTest, IEnumerable<PhysicianEvaluation> eventCustomerPhysicianEvaluations, CustomerSkipReview customerSkipReview)
        {
            var incidentalFindings = _incidentalFindingRepository.GetAllIncidentalFinding((int)TestType.FloChecABI);

            if (testResult != null)
            {
                var selectedNode = doc.DocumentNode.SelectSingleNode("//div[@id='FloChecAbi-rpp-section']");
                if (selectedNode != null && (testResult.UnableScreenReason == null || testResult.UnableScreenReason.Count == 0) && (testResult.TestNotPerformed == null || testResult.TestNotPerformed.TestNotPerformedReasonId <= 0)
                    && (showUnreadableTest || testResult.RepeatStudy == null || testResult.RepeatStudy.Reading == false))
                    selectedNode.SetAttributeValue("style", "display:block;");


                _resultPdfHelper.SetPhysicianSignature(doc, "FloChecAbi-primaryEvalPhysicianSign", "FloChecAbi-overreadEvalPhysicianSign", physicians, eventPhysicianTests, eventCustomerPhysicianEvaluations, customerSkipReview);

                var readings = new TestResultRepository().GetAllReadings((int)TestType.FloChecABI);
                decimal? leftAbi = null;
                decimal? rightAbi = null;

                foreach (var resultReading in readings)
                {
                    switch (resultReading.Label)
                    {
                        case ReadingLabels.LeftABI:
                            if (testResult.LeftResultReadings != null)
                            {
                                _resultPdfHelper.SetInputBox(doc, "FloChecAbitxtLeftFootdABI", testResult.LeftResultReadings.ABI);

                                if (testResult.LeftResultReadings.ABI != null && testResult.LeftResultReadings.ABI.Reading.HasValue)
                                {
                                    leftAbi = testResult.LeftResultReadings.ABI.Reading;
                                }
                            }
                            break;

                        case ReadingLabels.LeftHandBFI:
                            if (testResult.LeftResultReadings != null)
                                _resultPdfHelper.SetInputBox(doc, "FloChecAbitxtLeftHandBFI", testResult.LeftResultReadings.BFI);
                            break;

                        case ReadingLabels.RightABI:
                            if (testResult.RightResultReadings != null)
                            {
                                _resultPdfHelper.SetInputBox(doc, "FloChecAbitxtRightFootdABI", testResult.RightResultReadings.ABI);

                                if (testResult.RightResultReadings.ABI != null && testResult.RightResultReadings.ABI.Reading.HasValue)
                                {
                                    rightAbi = testResult.RightResultReadings.ABI.Reading;
                                }
                            }
                            break;

                        case ReadingLabels.RightHandBFI:
                            if (testResult.RightResultReadings != null)
                                _resultPdfHelper.SetInputBox(doc, "FloChecAbitxtRightHandBFI", testResult.RightResultReadings.BFI);
                            break;

                        case ReadingLabels.RepeatStudy:
                            _resultPdfHelper.SetCheckBox(doc, "RepeatStudyFloChecAbiInputCheck", testResult.RepeatStudy);
                            break;

                    }
                }

                long leftFindingId = 0;
                if (leftAbi != null)
                {
                    leftFindingId = _testResultService.GetCalculatedStandardFinding(leftAbi.Value, (int)TestType.FloChecABI, null);
                }

                long rightFindingId = 0;
                if (rightAbi != null)
                {
                    rightFindingId = _testResultService.GetCalculatedStandardFinding(rightAbi.Value, (int)TestType.FloChecABI, null);
                }

                var standardFindingList = _standardFindingRepository.GetAllStandardFindings<decimal>((int)TestType.FloChecABI);

                long findingId = 0;

                if (leftFindingId == rightFindingId)
                {
                    findingId = leftFindingId;
                }
                else if (leftFindingId > 0 && rightFindingId > 0)
                {
                    var lf = standardFindingList.Single(f => f.Id == leftFindingId);
                    var rf = standardFindingList.Single(f => f.Id == rightFindingId);

                    findingId = lf.WorstCaseOrder > rf.WorstCaseOrder ? lf.Id : rf.Id;
                }
                else
                {
                    findingId = leftFindingId > rightFindingId ? leftFindingId : rightFindingId;
                }

                LoadFloChecAbiFindings(doc, testResult.Finding, standardFindingList, findingId, true, (testResult.UnableScreenReason != null && testResult.UnableScreenReason.Count > 0 ? testResult.UnableScreenReason.First() : null));
                _resultPdfHelper.SetTechnician(doc, testResult, "techFloChecAbi", "technotesFloChecAbi", technicianIdNamePairs);
                _resultPdfHelper.SetIncidentalFindings(doc, incidentalFindings, testResult.IncidentalFindings, "FloChecAbiIncidentalFinding");
                _resultPdfHelper.SetPhysicianRemarks(doc, testResult, "followUpFloChecAbi", "criticalFloChecAbi", "physicianRemarksFloChecAbi");
                _resultPdfHelper.SetUnableToScreenReasons(doc, TestType.FloChecABI, "FloChecAbiUnableToScreen", testResult.UnableScreenReason);

                if (testResult.IncidentalFindings != null && testResult.IncidentalFindings.Any())
                {
                    selectedNode = doc.DocumentNode.SelectSingleNode("//p[@id='incidentalfinding-description-FloChecAbi']");
                    if (selectedNode != null) selectedNode.SetAttributeValue("style", "display:block;");
                }

                if (testResult.ResultImage != null && (testResult.UnableScreenReason == null || testResult.UnableScreenReason.Count == 0) && (showUnreadableTest || testResult.RepeatStudy == null || testResult.RepeatStudy.Reading == false))
                {
                    _resultPdfHelper.LoadTestMedia(doc, new[] { testResult.ResultImage }, "testmedia-FloChecAbi", loadImages);
                }

                selectedNode = doc.DocumentNode.SelectSingleNode("//div[@id='FloChecAbi-longdescription-div']");
                if (selectedNode != null)
                    selectedNode.SetAttributeValue("style", removeLongDescription ? "display:none" : "display:block");
            }
            else
            {
                LoadFloChecAbiFindings(doc, null, null, 0, false);
                _resultPdfHelper.SetUnableToScreenReasons(doc, TestType.FloChecABI, "FloChecAbiUnableToScreen", null);
                _resultPdfHelper.SetIncidentalFindings(doc, incidentalFindings, null, "FloChecAbiIncidentalFinding");
            }
        }

        private void LoadFloChecAbiFindings(HtmlDocument doc, StandardFinding<decimal> finding, IEnumerable<StandardFinding<decimal>> standardFindingList, long findingIdForLongDescription = 0, bool isTestPurchased = true,
            UnableScreenReason unableScreenReason = null)
        {
            if (standardFindingList == null)
                standardFindingList = _standardFindingRepository.GetAllStandardFindings<decimal>((int)TestType.FloChecABI);

            standardFindingList = standardFindingList.OrderBy(f => f.Id).ToList();
            StandardFinding<decimal> findingForLongDescription = null;

            if (findingIdForLongDescription > 0)
            {
                findingForLongDescription = standardFindingList.SingleOrDefault(sf => sf.Id == findingIdForLongDescription);
            }

            if (finding != null)
            {
                var stdFinding = standardFindingList.Single(f => f.Id == finding.Id);

                var selectedNode = doc.DocumentNode.SelectSingleNode("//span[@id='FloChecAbi-rpp-resultspan']");
                if (selectedNode != null)
                    selectedNode.InnerHtml = stdFinding.Label;

                //todo: docletter-abi
                selectedNode = doc.DocumentNode.SelectSingleNode("//div[@id='docletter-abi']");
                if (stdFinding.ResultInterpretation != null && stdFinding.ResultInterpretation.Value != (long)ResultInterpretation.Normal && selectedNode != null)
                    selectedNode.SetAttributeValue("style", "display:block;");
            }

            _resultPdfHelper.SetSummaryFindings(doc, finding, standardFindingList, "FindingsFloChecAbiDiv", "longdescription-FloChecAbi", findingForLongDescription, isTestPurchased, unableScreenReason);
            _resultPdfHelper.SetFindingsVertical(doc, finding, standardFindingList, "FloChecAbiFinding");
        }



    }
}
