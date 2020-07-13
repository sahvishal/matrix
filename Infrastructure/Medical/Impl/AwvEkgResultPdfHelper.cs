using Falcon.App.Core;
using Falcon.App.Core.Application;
using Falcon.App.Core.Application.Attributes;
using Falcon.App.Core.Application.Helper;
using Falcon.App.Core.Interfaces;
using Falcon.App.Core.Medical;
using Falcon.App.Core.Medical.Domain;
using Falcon.App.Core.Medical.Enum;
using Falcon.App.Core.Medical.ViewModels;
using Falcon.App.Core.Operations.Domain;
using HtmlAgilityPack;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace Falcon.App.Infrastructure.Medical.Impl
{
    [DefaultImplementation]
    public class AwvEkgResultPdfHelper : IAwvEkgResultPdfHelper
    {
        private readonly ISettings _settings;
        private readonly IResultPdfHelper _resultPdfHelper;
        private readonly IStandardFindingRepository _standardFindingRepository;
        private readonly IPdftoImageConverter _pdftoImageConverter;
        private readonly IMediaRepository _mediaRepository;

        public AwvEkgResultPdfHelper(ISettings settings, IResultPdfHelper resultPdfHelper, IStandardFindingRepository standardFindingRepository, IPdftoImageConverter pdftoImageConverter,
            IMediaRepository mediaRepository)
        {
            _settings = settings;
            _resultPdfHelper = resultPdfHelper;
            _standardFindingRepository = standardFindingRepository;
            _pdftoImageConverter = pdftoImageConverter;
            _mediaRepository = mediaRepository;
        }

        public void LoadAwvEkgTestResults(HtmlDocument doc, AwvEkgTestResult testResult, bool removeLongDescription, List<OrderedPair<long, string>> technicianIdNamePairs,
            bool loadImages, IEnumerable<CustomerScreeningEvaluatinPhysicianViewModel> physicians, IEnumerable<EventPhysicianTest> eventPhysicianTests,
            bool showUnreadableTest, IEnumerable<PhysicianEvaluation> eventCustomerPhysicianEvaluation, CustomerSkipReview customerSkipReview, string stringforMediaDirectory)
        {
            var bbbFindings = _standardFindingRepository.GetAllStandardFindings<int>((Int32)TestType.AwvEkg, (Int32)ReadingLabels.BundleBranchBlock);
            var ipFindings = _standardFindingRepository.GetAllStandardFindings<int>((Int32)TestType.AwvEkg, (Int32)ReadingLabels.InfarctionPattern);

            if (testResult != null)
            {
                var selectedNode = doc.DocumentNode.SelectSingleNode("//div[@id='AwvEkg-rpp-section']");
                if (selectedNode != null && (testResult.UnableScreenReason == null || testResult.UnableScreenReason.Count == 0) && (testResult.TestNotPerformed == null || testResult.TestNotPerformed.TestNotPerformedReasonId <= 0)
                    && (showUnreadableTest || testResult.RepeatStudy == null || testResult.RepeatStudy.Reading == false))
                    selectedNode.SetAttributeValue("style", "display:block;");

                selectedNode = doc.DocumentNode.SelectSingleNode("//div[@id='rpp-eus-AwvEkg-div']");
                if (selectedNode != null)
                    selectedNode.SetAttributeValue("style", "display:block;");

                _resultPdfHelper.SetPhysicianSignature(doc, "AwvEkg-primaryEvalPhysicianSign", "AwvEkg-overreadEvalPhysicianSign", physicians, eventPhysicianTests, eventCustomerPhysicianEvaluation, customerSkipReview);

                LoadAwvEkgFindings(doc, testResult.Finding, true, (testResult.UnableScreenReason != null && testResult.UnableScreenReason.Count > 0 ? testResult.UnableScreenReason.First() : null));

                _resultPdfHelper.SetInputBox(doc, "AwvEkgprIntervalTextbox", testResult.PRInterval);
                _resultPdfHelper.SetInputBox(doc, "AwvEkgventRateTextbox", testResult.VentRate);
                _resultPdfHelper.SetInputBox(doc, "AwvEkgqrsDurationTextbox", testResult.QRSDuration);
                _resultPdfHelper.SetInputBox(doc, "AwvEkgqtIntervalTextbox", testResult.QTInterval);
                _resultPdfHelper.SetInputBox(doc, "AwvEkgqtcInterval", testResult.QTcInterval);

                _resultPdfHelper.SetCheckBox(doc, "AwvEkgReversedLeadInputCheck", testResult.ReversedLeads);
                _resultPdfHelper.SetCheckBox(doc, "AwvEkgRepeatStudyInputCheck", testResult.RepeatStudy);
                _resultPdfHelper.SetCheckBox(doc, "AwvEkgArtifactInputCheck", testResult.Artifact);
                _resultPdfHelper.SetCheckBox(doc, "ComparetoPrevAwvEkgInputCheck", testResult.ComparetoEkg);

                _resultPdfHelper.SetCheckBox(doc, "AwvEkgSinusRythmInputCheck", testResult.SinusRythm);
                _resultPdfHelper.SetCheckBox(doc, "AwvEkgSinusArrythmiaInputCheck", testResult.SinusArrythmia);
                _resultPdfHelper.SetCheckBox(doc, "AwvEkgSinusBradycardiaInputCheck", testResult.SinusBradycardia);
                _resultPdfHelper.SetCheckBox(doc, "AwvEkgMarkedInputCheck", testResult.Marked);

                _resultPdfHelper.SetCheckBox(doc, "AwvEkgSinusTachycardiaInputCheck", testResult.SinusTachycardia);
                _resultPdfHelper.SetCheckBox(doc, "AwvEkgAtrialFibrillationInputCheck", testResult.AtrialFibrillation);
                _resultPdfHelper.SetCheckBox(doc, "AwvEkgAtrialFlutterInputCheck", testResult.AtrialFlutter);
                _resultPdfHelper.SetCheckBox(doc, "AwvEkgSupraventriculaCheckbox", testResult.SupraventricularArrythmia);
                _resultPdfHelper.SetCheckBox(doc, "AwvEkgSvtInputCheck", testResult.SVT);
                _resultPdfHelper.SetCheckBox(doc, "AwvEkgPacInputCheck", testResult.PACs);
                _resultPdfHelper.SetCheckBox(doc, "AwvEkgPvcInputCheck", testResult.PVCs);
                _resultPdfHelper.SetCheckBox(doc, "AwvEkgPacerRythmCheckbox", testResult.PacerRythm);
                _resultPdfHelper.SetCheckBox(doc, "AwvEkgBundleBranchBlockCheckbox", testResult.BundleBranchBlock);

                _resultPdfHelper.SetFindingsHorizontal(doc, testResult.BundleBranchBlockFinding, bbbFindings, "AwvEkgBundleBranchBlockFinding", 3);

                _resultPdfHelper.SetCheckBox(doc, "AwvEkgQrsWideningInputCheck", testResult.QRSWidening);
                _resultPdfHelper.SetCheckBox(doc, "AwvEkgLeftAxisInputCheck", testResult.LeftAxis);
                _resultPdfHelper.SetCheckBox(doc, "AwvEkgRightAxisInputCheck", testResult.RightAxis);
                _resultPdfHelper.SetCheckBox(doc, "AwvEkgAbnormalAxisInputCheck", testResult.AbnormalAxis);
                _resultPdfHelper.SetCheckBox(doc, "AwvEkgLeftInputCheck", testResult.Left);
                _resultPdfHelper.SetCheckBox(doc, "AwvEkgRightInputCheck", testResult.Right);
                _resultPdfHelper.SetCheckBox(doc, "AwvEkgLeftAnteriorfasicularBlockCheckbox", testResult.LeftAnteriorFasicularBlock);
                _resultPdfHelper.SetCheckBox(doc, "AwvEkgHeartBlockInputCheck", testResult.HeartBlock);

                _resultPdfHelper.SetCheckBox(doc, "AwvEkgFirstDegreeBlockInputCheck", testResult.FirstDegreeBlock);
                _resultPdfHelper.SetCheckBox(doc, "AwvEkgSecondDegreeBlockCheckbox", testResult.SecondDegreeBlock);

                _resultPdfHelper.SetCheckBox(doc, "AwvEkgTypeIIInputCheck", testResult.TypeII);

                _resultPdfHelper.SetCheckBox(doc, "AwvEkgThirdDegreeBlockInputCheck", testResult.ThirdDegreeCompleteHeartBlock);
                _resultPdfHelper.SetCheckBox(doc, "AwvEkgVentricularCheckbox", testResult.VentricularHypertrophy);
                _resultPdfHelper.SetCheckBox(doc, "AwvEkgLeftVentricularCheckbox", testResult.LeftVentricularHypertrophy);
                _resultPdfHelper.SetCheckBox(doc, "AwvEkgRightVentricularCheckbox", testResult.RightVentricularHypertrophy);

                _resultPdfHelper.SetCheckBox(doc, "AwvEkgProlongedQTCheckbox", testResult.ProlongedQTInterval);
                _resultPdfHelper.SetCheckBox(doc, "AwvEkgISchemicSttCheckbox", testResult.IschemicSTTChanges);
                _resultPdfHelper.SetCheckBox(doc, "AwvEkgNonSpecificSttCheckbox", testResult.NonSpecificSTTChanges);
                _resultPdfHelper.SetCheckBox(doc, "AwvEkgPoorRWaveProgressionCheckbox", testResult.PoorRWaveProgression);
                _resultPdfHelper.SetCheckBox(doc, "AwvEkgInfarctionPatternCheckbox", testResult.InfarctionPattern);

                _resultPdfHelper.SetCheckBox(doc, "AwvEkgATypicalWaveCheckbox", testResult.AtypicalQWaveLead);
                _resultPdfHelper.SetCheckBox(doc, "AwvEkgAtrialEnlargementCheckbox", testResult.AtrialEnlargement);
                _resultPdfHelper.SetCheckBox(doc, "AwvEkgLeftAtrialCheckbox", testResult.LeftAtrialEnlargement);
                _resultPdfHelper.SetCheckBox(doc, "AwvEkgRightAtrialCheckbox", testResult.RightAtrialEnlargement);
                _resultPdfHelper.SetCheckBox(doc, "AwvEkgRepolarizationCheckbox", testResult.RepolarizationVariant);

                _resultPdfHelper.SetCheckBox(doc, "AwvEkgLowVoltageCheckbox", testResult.LowVoltage);
                _resultPdfHelper.SetCheckBox(doc, "AwvEkgLimbLeadsCheckbox", testResult.LimbLeads);
                _resultPdfHelper.SetCheckBox(doc, "AwvEkgPrecordialLeadsCheckbox", testResult.PrecordialLeads);

                _resultPdfHelper.SetCheckBox(doc, "AwvEkgShortPrIntervalCheckbox", testResult.ShortPrInterval);

                _resultPdfHelper.SetFindingsHorizontal(doc, testResult.InfarctionPatternFinding, ipFindings, "AwvEkgInfarctionPatternFinding", 2);

                if (testResult.ResultImage != null && (testResult.UnableScreenReason == null || testResult.UnableScreenReason.Count == 0) && (showUnreadableTest || testResult.RepeatStudy == null || testResult.RepeatStudy.Reading == false))
                {
                    _resultPdfHelper.LoadTestMedia(doc, new[] { testResult.ResultImage }, "testmedia-AwvEkg", loadImages);

                    selectedNode = doc.DocumentNode.SelectSingleNode("//div[@id='AwvEkgReport']");
                    if (selectedNode != null) selectedNode.SetAttributeValue("style", "display:block");
                    selectedNode = doc.DocumentNode.SelectSingleNode("//img[@id='AwvEkgGraph']");
                    if (selectedNode != null) selectedNode.SetAttributeValue("src", stringforMediaDirectory + "/" + testResult.ResultImage.File.Path);               
                }

                _resultPdfHelper.SetTechnician(doc, testResult, "techAwvEkg", "technotesAwvEkg", technicianIdNamePairs);
                _resultPdfHelper.SetUnableToScreenReasons(doc, TestType.AwvEkg, "AwvEkgUnableToScreen", testResult.UnableScreenReason);
                _resultPdfHelper.SetPhysicianRemarks(doc, testResult, "followUpAwvEkg", "criticalAwvEkg", "AwvEkgPhysicianNotesTextbox");

                selectedNode = doc.DocumentNode.SelectSingleNode("//div[@id='AwvEkg-longdescription-div']");
                if (selectedNode != null)
                    selectedNode.SetAttributeValue("style", removeLongDescription ? "display:none" : "display:block");

            }
            else
            {
                LoadAwvEkgFindings(doc, null, false);
                _resultPdfHelper.SetUnableToScreenReasons(doc, TestType.AwvEkg, "AwvEkgUnableToScreen", null);
                _resultPdfHelper.SetFindingsHorizontal(doc, new StandardFinding<int>(), bbbFindings, "AwvEkgBundleBranchBlockFinding", 3);
                _resultPdfHelper.SetFindingsHorizontal(doc, new StandardFinding<int>(), ipFindings, "AwvEkgInfarctionPatternFinding", 2);
            }
        }

        private void LoadAwvEkgFindings(HtmlDocument doc, StandardFinding<int?> finding, bool isTestPurchased = true, UnableScreenReason unableScreenReason = null)
        {
            var standardFindingList = _standardFindingRepository.GetAllStandardFindings<int?>(Convert.ToInt32(TestType.AwvEkg));

            if (finding != null)
            {
                var stdFinding = standardFindingList.Single(f => f.Id == finding.Id);

                var selectedNode = doc.DocumentNode.SelectSingleNode("//span[@id='AwvEkg-rpp-resultspan']");
                if (selectedNode != null)
                    selectedNode.InnerHtml = stdFinding.Label;

                selectedNode = doc.DocumentNode.SelectSingleNode("//div[@id='docletter-AwvEkg']");
                if (stdFinding.ResultInterpretation != null && stdFinding.ResultInterpretation.Value != (long)ResultInterpretation.Normal && selectedNode != null)
                    selectedNode.SetAttributeValue("style", "display:block;");
            }

            _resultPdfHelper.SetSummaryFindings(doc, finding, standardFindingList, "FindingsAwvEkgDiv", "longdescription-AwvEkg", null, isTestPurchased, unableScreenReason);
            _resultPdfHelper.SetFindingsHorizontal(doc, finding, standardFindingList, "AwvEkgFinding");
        }

    }
}
