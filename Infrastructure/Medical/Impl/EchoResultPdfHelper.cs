using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
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
    public class EchoResultPdfHelper : IEchoResultPdfHelper
    {
        private readonly IResultPdfHelper _resultPdfHelper;
        private readonly IStandardFindingRepository _standardFindingRepository;
        private readonly ISettings _settings;
        private readonly IEventCustomerResultRepository _eventCustomerResultRepository;
        private const string AwvEchocardiogramConclutionText = "The {0} {1} appears {2}.";
        public EchoResultPdfHelper(IResultPdfHelper resultPdfHelper, IStandardFindingRepository standardFindingRepository, ISettings settings, IEventCustomerResultRepository eventCustomerResultRepository)
        {
            _resultPdfHelper = resultPdfHelper;
            _standardFindingRepository = standardFindingRepository;
            _settings = settings;
            _eventCustomerResultRepository = eventCustomerResultRepository;
        }

        public void LoadEchoTestResults(HtmlDocument doc, EchocardiogramTestResult testResult, bool removeLongDescription, bool loadImages, List<OrderedPair<long, string>> technicianIdNamePairs, bool showRepeatStudyCheckbox,
            IEnumerable<CustomerScreeningEvaluatinPhysicianViewModel> physicians, IEnumerable<EventPhysicianTest> eventPhysicianTests, IEnumerable<PhysicianEvaluation> eventCustomerPhysicianEvaluations,
            CustomerSkipReview customerSkipReview)
        {
            if (testResult != null)
            {
                var selectedNode = doc.DocumentNode.SelectSingleNode("//div[@id='echo-rpp-section']");
                if (selectedNode != null && (testResult.UnableScreenReason == null || testResult.UnableScreenReason.Count == 0) && (testResult.TestNotPerformed == null || testResult.TestNotPerformed.TestNotPerformedReasonId <= 0)
                    && (testResult.RepeatStudyUnreadable == null || testResult.RepeatStudyUnreadable.Reading == false))
                    selectedNode.SetAttributeValue("style", "display:block;"); ;

                _resultPdfHelper.SetPhysicianSignature(doc, "echo-primaryEvalPhysicianSign", "echo-overreadEvalPhysicianSign", physicians, eventPhysicianTests, eventCustomerPhysicianEvaluations, customerSkipReview);

                LoadEchoFinding(doc, testResult);

                _resultPdfHelper.SetCheckBox(doc, "ValveAorticCheckbox", testResult.Aortic);
                _resultPdfHelper.SetCheckBox(doc, "ValveMitralCheckbox", testResult.Mitral);
                _resultPdfHelper.SetCheckBox(doc, "ValvePulmonicCheckbox", testResult.Pulmonic);
                _resultPdfHelper.SetCheckBox(doc, "ValveTricuspidCheckbox", testResult.Tricuspid);

                _resultPdfHelper.SetInputBox(doc, "AorticVelocityTextbox", testResult.AoticVelocity);
                _resultPdfHelper.SetInputBox(doc, "PTTextbox", testResult.MitralPT);
                _resultPdfHelper.SetInputBox(doc, "VelocityPulmonicTextbox", testResult.PulmonicVelocity);
                _resultPdfHelper.SetInputBox(doc, "PapTextbox", testResult.TricuspidPap);
                _resultPdfHelper.SetInputBox(doc, "VelocityTricuspidTextbox", testResult.TricuspidVelocity);

                _resultPdfHelper.SetCheckBox(doc, "DiastolicDysfunctionCheckbox", testResult.DiastolicDysfunction);
                _resultPdfHelper.SetCheckBox(doc, "PericardialEffusionCheckbox", testResult.PericardialEffusion);
                _resultPdfHelper.SetCheckBox(doc, "VentricularEnlargmentCheckbox", testResult.VentricularEnlargement);
                _resultPdfHelper.SetCheckBox(doc, "AorticRootCheckbox", testResult.AorticRoot);
                _resultPdfHelper.SetCheckBox(doc, "VentricularHypertrophyCheckbox", testResult.VentricularHypertrophy);
                _resultPdfHelper.SetCheckBox(doc, "AtrialEnlargmentCheckbox", testResult.AtrialEnlargement);
                _resultPdfHelper.SetCheckBox(doc, "ArrythmiaCheckbox", testResult.Arrythmia);

                _resultPdfHelper.SetCheckBox(doc, "LeftVEnlargementCheckbox", testResult.LeftVentricularEnlargment);
                _resultPdfHelper.SetCheckBox(doc, "RightVEnlargementCheckbox", testResult.RightVentricularEnlargment);
                _resultPdfHelper.SetCheckBox(doc, "ScleroticCheckbox", testResult.Sclerotic);
                _resultPdfHelper.SetCheckBox(doc, "CalcifiedCheckbox", testResult.Calcified);
                _resultPdfHelper.SetCheckBox(doc, "EnlargedCheckbox", testResult.Enlarged);
                _resultPdfHelper.SetCheckBox(doc, "LeftVHypertrophyCheckbox", testResult.LeftVHypertrophy);
                _resultPdfHelper.SetCheckBox(doc, "RightVHypertrophyCheckbox", testResult.RightVHypertrophy);
                _resultPdfHelper.SetCheckBox(doc, "IvshCheckbox", testResult.IvshHypertrophy);
                _resultPdfHelper.SetCheckBox(doc, "LeftAtrialEnlargementCheckbox", testResult.LeftAtrialEnlargment);
                _resultPdfHelper.SetCheckBox(doc, "RightAtrialEnlargementCheckbox", testResult.RightAtrialEnlargment);

                _resultPdfHelper.SetInputBox(doc, "LeftVEnlargementTextbox", testResult.LeftVentricularEnlargmentValue);
                _resultPdfHelper.SetInputBox(doc, "RightVEnlargementTextbox", testResult.RightVentricularEnlargmentValue);
                _resultPdfHelper.SetInputBox(doc, "EnlargedTextbox", testResult.EnlargedValue);
                _resultPdfHelper.SetInputBox(doc, "LeftVHypertrophyTextbox", testResult.LeftVHypertrophyValue);
                _resultPdfHelper.SetInputBox(doc, "RightVHypertrophyTextbox", testResult.RightVHypertrophyValue);
                _resultPdfHelper.SetInputBox(doc, "IvshTextbox", testResult.IvshHypertrophyValue);
                _resultPdfHelper.SetInputBox(doc, "LeftAtrialEnlargementTextbox", testResult.LeftAtrialEnlargmentValue);
                _resultPdfHelper.SetInputBox(doc, "RightAtrialEnlargementTextbox", testResult.RightAtrialEnlargmentValue);

                _resultPdfHelper.SetCheckBox(doc, "AsdCheckbox", testResult.ASD);
                _resultPdfHelper.SetCheckBox(doc, "PfoCheckbox", testResult.PFO);
                _resultPdfHelper.SetCheckBox(doc, "FlailCheckbox", testResult.FlailAS);
                _resultPdfHelper.SetCheckBox(doc, "VsdCheckbox", testResult.VSD);
                _resultPdfHelper.SetCheckBox(doc, "SamCheckbox", testResult.SAM);
                _resultPdfHelper.SetCheckBox(doc, "LvotoCheckbox", testResult.LVOTO);
                _resultPdfHelper.SetCheckBox(doc, "MitralAnnularCheckbox", testResult.MitralAnnularCa);

                _resultPdfHelper.SetCheckBox(doc, "RestrictedLeafletCheckbox", testResult.RestrictedLeafletMotion);
                _resultPdfHelper.SetCheckBox(doc, "RestrictedLeafletAorticCheckbox", testResult.RestrictedLeafletMotionAortic);
                _resultPdfHelper.SetCheckBox(doc, "RestrictedLeafletMitralCheckbox", testResult.RestrictedLeafletMotionMitral);
                _resultPdfHelper.SetCheckBox(doc, "RestrictedLeafletPulCheckbox", testResult.RestrictedLeafletMotionPulmonic);
                _resultPdfHelper.SetCheckBox(doc, "RestrictedLeafletTriCheckbox", testResult.RestrictedLeafletMotionTricuspid);

                _resultPdfHelper.SetCheckBox(doc, "HypokineticCheckbox", testResult.Hypokinetic);
                _resultPdfHelper.SetCheckBox(doc, "AkineticCheckbox", testResult.Akinetic);
                _resultPdfHelper.SetCheckBox(doc, "DyskineticCheckbox", testResult.Dyskinetic);

                _resultPdfHelper.SetCheckBox(doc, "AnteriorCheckbox", testResult.Anterior);
                _resultPdfHelper.SetCheckBox(doc, "PosteriorCheckbox", testResult.Posterior);
                _resultPdfHelper.SetCheckBox(doc, "ApicalCheckbox", testResult.Apical);

                _resultPdfHelper.SetCheckBox(doc, "SeptalCheckbox", testResult.Septal);
                _resultPdfHelper.SetCheckBox(doc, "LateralCheckbox", testResult.Lateral);
                _resultPdfHelper.SetCheckBox(doc, "InferiorCheckbox", testResult.Inferior);

                _resultPdfHelper.SetCheckBox(doc, "TechnicalLimitedbutReadableEchoCheckbox", testResult.TechnicallyLimitedbutReadable);
                _resultPdfHelper.SetCheckBox(doc, "RepeatStudyuneadableEchoCheckbox", testResult.RepeatStudyUnreadable);

                _resultPdfHelper.SetCheckBox(doc, "echoConsiderOtherModalities", testResult.ConsiderOtherModalities);
                _resultPdfHelper.SetCheckBox(doc, "echoAdditionalImagesNeeded", testResult.AdditionalImagesNeeded);

                _resultPdfHelper.LoadTestMedia(doc, testResult.Media, "testmedia-echo", loadImages);
                _resultPdfHelper.SetPhysicianRemarks(doc, testResult, "followUpEcho", "criticalEcho", "physicianRemarksEcho");
                _resultPdfHelper.SetTechnician(doc, testResult, "techecho", "technotesecho", technicianIdNamePairs);
                _resultPdfHelper.SetUnableToScreenReasons(doc, TestType.Echocardiogram, "echoUnableToScreen", testResult.UnableScreenReason);


                selectedNode = doc.DocumentNode.SelectSingleNode("//div[@id='echo-longdescription-div']");
                if (selectedNode != null)
                    selectedNode.SetAttributeValue("style", removeLongDescription ? "display:none" : "display:block");
            }
            else
            {
                _resultPdfHelper.SetUnableToScreenReasons(doc, TestType.Echocardiogram, "echoUnableToScreen", null);
                LoadEchoFinding(doc, null);
            }
            _resultPdfHelper.ShowHideRepeatStudy(doc, "echoPhysicianRepeatStudy", showRepeatStudyCheckbox);
            _resultPdfHelper.ShowHideOtherModalitiesAdditionalImages(doc, "echoOtherModalitiesAdditionalImagesDiv", !showRepeatStudyCheckbox);
        }

        private void LoadEchoFinding(HtmlDocument doc, EchocardiogramTestResult testResult)
        {
            var stdFindings = _standardFindingRepository.GetAllStandardFindings<int>((Int32)TestType.Echocardiogram);
            var estEjaFindings = _standardFindingRepository.GetAllStandardFindings<int>((Int32)TestType.Echocardiogram, (Int32)ReadingLabels.EstimatedEjactionFraction);
            var aorticFindings = _standardFindingRepository.GetAllStandardFindings<int>((Int32)TestType.Echocardiogram, (Int32)ReadingLabels.Aortic);
            var mitrlaFindings = _standardFindingRepository.GetAllStandardFindings<int>((Int32)TestType.Echocardiogram, (Int32)ReadingLabels.Mitral);
            var pulmonicFindings = _standardFindingRepository.GetAllStandardFindings<int>((Int32)TestType.Echocardiogram, (Int32)ReadingLabels.Pulmonic);
            var tricuspidFindings = _standardFindingRepository.GetAllStandardFindings<int>((Int32)TestType.Echocardiogram, (Int32)ReadingLabels.Tricuspid);
            var aorticMorphologyFindings = _standardFindingRepository.GetAllStandardFindings<int>((Int32)TestType.Echocardiogram, (Int32)ReadingLabels.AorticMorphology);
            var mitralMorphFindings = _standardFindingRepository.GetAllStandardFindings<int>((Int32)TestType.Echocardiogram, (Int32)ReadingLabels.MitralMorphology);
            var pulmonicMorphFindings = _standardFindingRepository.GetAllStandardFindings<int>((Int32)TestType.Echocardiogram, (Int32)ReadingLabels.PulmonicMorphology);
            var tricuspidMorphFindings = _standardFindingRepository.GetAllStandardFindings<int>((Int32)TestType.Echocardiogram, (Int32)ReadingLabels.TricuspidMorphology);
            var periEfuFindings = _standardFindingRepository.GetAllStandardFindings<int>((Int32)TestType.Echocardiogram, (Int32)ReadingLabels.PericardialEffusion);
            var diastolicFindings = _standardFindingRepository.GetAllStandardFindings<int>((Int32)TestType.Echocardiogram, (Int32)ReadingLabels.DiastolicDysfunction);

            UnableScreenReason unableScreenReason = null;
            //TODO: This is a hack for Echo Summary
            if (testResult != null && testResult.UnableScreenReason != null && testResult.UnableScreenReason.Count > 0 && testResult.UnableScreenReason.Count(us => us.Reason == UnableToScreenReason.TechnicallyLimitedButReadable) < 1)
                unableScreenReason = testResult.UnableScreenReason.First();

            var selectedNode = doc.DocumentNode.SelectSingleNode("//span[@id='echo-rpp-resultspan']");
            if (testResult != null && testResult.Finding != null && selectedNode != null)
            {
                var stdFinding = stdFindings.Single(f => f.Id == testResult.Finding.Id);
                selectedNode.InnerHtml = stdFinding.Label;
            }

            bool showAdditionalImagesNeeded = false;
            bool showConsiderOtherModalities = false;

            if (testResult != null)
            {
                if (testResult.AdditionalImagesNeeded != null)
                {
                    showAdditionalImagesNeeded = testResult.AdditionalImagesNeeded.Reading;
                }
                if (testResult.ConsiderOtherModalities != null)
                {
                    showConsiderOtherModalities = testResult.ConsiderOtherModalities.Reading;
                }
            }

            _resultPdfHelper.SetSummaryFindings(doc, (testResult != null ? testResult.Finding : null), stdFindings, "FindingsEchoDiv", "longdescription-echo", null, testResult != null, unableScreenReason, showAdditionalImagesNeeded, showConsiderOtherModalities);
            _resultPdfHelper.SetFindingsHorizontal(doc, testResult != null ? testResult.Finding : null, stdFindings, "echoFindings");
            _resultPdfHelper.SetFindingsVertical(doc, testResult != null ? testResult.EstimatedEjactionFraction : null, estEjaFindings, "estimatedEjacFinding");

            _resultPdfHelper.SetFindingsHorizontal(doc, testResult != null ? testResult.AorticRegurgitation : null, aorticFindings, "aorticRegurgitationFinding");
            _resultPdfHelper.SetFindingsHorizontal(doc, testResult != null ? testResult.MitralRegurgitation : null, mitrlaFindings, "mitralRegurgitationFinding");
            _resultPdfHelper.SetFindingsHorizontal(doc, testResult != null ? testResult.PulmonicRegurgitation : null, pulmonicFindings, "pulmonicRegurgitationFinding");
            _resultPdfHelper.SetFindingsHorizontal(doc, testResult != null ? testResult.TricuspidRegurgitation : null, tricuspidFindings, "tricuspidRegurgitationFinding");

            _resultPdfHelper.SetFindingsHorizontal(doc, testResult != null ? testResult.AorticMorphology : null, aorticMorphologyFindings, "aorticMorphologyFinding");
            _resultPdfHelper.SetFindingsHorizontal(doc, testResult != null ? testResult.MitralMorphology : null, mitralMorphFindings, "mitralMorphologyFinding");
            _resultPdfHelper.SetFindingsHorizontal(doc, testResult != null ? testResult.PulmonicMorphology : null, pulmonicMorphFindings, "pulmonicMorphologyFinding");
            _resultPdfHelper.SetFindingsHorizontal(doc, testResult != null ? testResult.TricuspidMorphology : null, tricuspidMorphFindings, "tricuspidMorphologyFinding");

            _resultPdfHelper.SetFindingsHorizontal(doc, testResult != null ? testResult.DistolicDysfunctionFinding : null, diastolicFindings, "distolicDysfunctionFinding");
            _resultPdfHelper.SetFindingsHorizontal(doc, testResult != null ? testResult.PericardialEffusionFinding : null, periEfuFindings, "pericardialEffFinding");
        }

        public void LoadPpEchoTestResults(HtmlDocument doc, PpEchocardiogramTestResult testResult, bool removeLongDescription, bool loadImages, List<OrderedPair<long, string>> technicianIdNamePairs,
            IEnumerable<CustomerScreeningEvaluatinPhysicianViewModel> physicians, IEnumerable<EventPhysicianTest> eventPhysicianTests, IEnumerable<PhysicianEvaluation> eventCustomerPhysicianEvaluations,
            CustomerSkipReview customerSkipReview)
        {
            if (testResult != null)
            {
                var selectedNode = doc.DocumentNode.SelectSingleNode("//div[@id='Ppecho-rpp-section']");
                if (selectedNode != null && (testResult.UnableScreenReason == null || testResult.UnableScreenReason.Count == 0) && (testResult.TestNotPerformed == null || testResult.TestNotPerformed.TestNotPerformedReasonId <= 0)
                    && (testResult.RepeatStudyUnreadable == null || testResult.RepeatStudyUnreadable.Reading == false))
                    selectedNode.SetAttributeValue("style", "display:block;");

                _resultPdfHelper.SetPhysicianSignature(doc, "Ppecho-primaryEvalPhysicianSign", "Ppecho-overreadEvalPhysicianSign", physicians, eventPhysicianTests, eventCustomerPhysicianEvaluations, customerSkipReview);

                LoadPpEchoFinding(doc, testResult);

                _resultPdfHelper.SetCheckBox(doc, "PpValveAorticCheckbox", testResult.Aortic);
                _resultPdfHelper.SetCheckBox(doc, "PpValveMitralCheckbox", testResult.Mitral);
                _resultPdfHelper.SetCheckBox(doc, "PpValvePulmonicCheckbox", testResult.Pulmonic);
                _resultPdfHelper.SetCheckBox(doc, "PpValveTricuspidCheckbox", testResult.Tricuspid);

                _resultPdfHelper.SetInputBox(doc, "PpAorticVelocityTextbox", testResult.AoticVelocity);
                _resultPdfHelper.SetInputBox(doc, "PpPTTextbox", testResult.MitralPT);
                _resultPdfHelper.SetInputBox(doc, "PpVelocityPulmonicTextbox", testResult.PulmonicVelocity);
                _resultPdfHelper.SetInputBox(doc, "PpPapTextbox", testResult.TricuspidPap);
                _resultPdfHelper.SetInputBox(doc, "PpVelocityTricuspidTextbox", testResult.TricuspidVelocity);

                _resultPdfHelper.SetCheckBox(doc, "PpDiastolicDysfunctionCheckbox", testResult.DiastolicDysfunction);
                _resultPdfHelper.SetCheckBox(doc, "PpPericardialEffusionCheckbox", testResult.PericardialEffusion);
                _resultPdfHelper.SetCheckBox(doc, "PpVentricularEnlargmentCheckbox", testResult.VentricularEnlargement);
                _resultPdfHelper.SetCheckBox(doc, "PpAorticRootCheckbox", testResult.AorticRoot);
                _resultPdfHelper.SetCheckBox(doc, "PpVentricularHypertrophyCheckbox", testResult.VentricularHypertrophy);
                _resultPdfHelper.SetCheckBox(doc, "PpAtrialEnlargmentCheckbox", testResult.AtrialEnlargement);
                _resultPdfHelper.SetCheckBox(doc, "PpArrythmiaCheckbox", testResult.Arrythmia);

                _resultPdfHelper.SetCheckBox(doc, "PpAFibCheckbox", testResult.AFib);
                _resultPdfHelper.SetCheckBox(doc, "PpAFlutterCheckbox", testResult.AFlutter);
                _resultPdfHelper.SetCheckBox(doc, "PpPACCheckbox", testResult.PAC);
                _resultPdfHelper.SetCheckBox(doc, "PpPVCCheckbox", testResult.PVC);

                _resultPdfHelper.SetCheckBox(doc, "PpLeftVEnlargementCheckbox", testResult.LeftVentricularEnlargment);
                _resultPdfHelper.SetCheckBox(doc, "PpRightVEnlargementCheckbox", testResult.RightVentricularEnlargment);
                _resultPdfHelper.SetCheckBox(doc, "PpScleroticCheckbox", testResult.Sclerotic);
                _resultPdfHelper.SetCheckBox(doc, "PpCalcifiedCheckbox", testResult.Calcified);
                _resultPdfHelper.SetCheckBox(doc, "PpEnlargedCheckbox", testResult.Enlarged);
                _resultPdfHelper.SetCheckBox(doc, "PpLeftVHypertrophyCheckbox", testResult.LeftVHypertrophy);
                _resultPdfHelper.SetCheckBox(doc, "PpRightVHypertrophyCheckbox", testResult.RightVHypertrophy);
                _resultPdfHelper.SetCheckBox(doc, "PpIvshCheckbox", testResult.IvshHypertrophy);
                _resultPdfHelper.SetCheckBox(doc, "PpLeftAtrialEnlargementCheckbox", testResult.LeftAtrialEnlargment);
                _resultPdfHelper.SetCheckBox(doc, "PpRightAtrialEnlargementCheckbox", testResult.RightAtrialEnlargment);

                _resultPdfHelper.SetInputBox(doc, "PpLeftVEnlargementTextbox", testResult.LeftVentricularEnlargmentValue);
                _resultPdfHelper.SetInputBox(doc, "PpRightVEnlargementTextbox", testResult.RightVentricularEnlargmentValue);
                _resultPdfHelper.SetInputBox(doc, "PpEnlargedTextbox", testResult.EnlargedValue);
                _resultPdfHelper.SetInputBox(doc, "PpLeftVHypertrophyTextbox", testResult.LeftVHypertrophyValue);
                _resultPdfHelper.SetInputBox(doc, "PpRightVHypertrophyTextbox", testResult.RightVHypertrophyValue);
                _resultPdfHelper.SetInputBox(doc, "PpIvshTextbox", testResult.IvshHypertrophyValue);
                _resultPdfHelper.SetInputBox(doc, "PpLeftAtrialEnlargementTextbox", testResult.LeftAtrialEnlargmentValue);
                _resultPdfHelper.SetInputBox(doc, "PpRightAtrialEnlargementTextbox", testResult.RightAtrialEnlargmentValue);

                _resultPdfHelper.SetCheckBox(doc, "PpAsdCheckbox", testResult.ASD);
                _resultPdfHelper.SetCheckBox(doc, "PpPfoCheckbox", testResult.PFO);
                _resultPdfHelper.SetCheckBox(doc, "PpFlailCheckbox", testResult.FlailAS);
                _resultPdfHelper.SetCheckBox(doc, "PpVsdCheckbox", testResult.VSD);
                _resultPdfHelper.SetCheckBox(doc, "PpSamCheckbox", testResult.SAM);
                _resultPdfHelper.SetCheckBox(doc, "PpLvotoCheckbox", testResult.LVOTO);
                _resultPdfHelper.SetCheckBox(doc, "PpMitralAnnularCheckbox", testResult.MitralAnnularCa);

                _resultPdfHelper.SetCheckBox(doc, "PpRestrictedLeafletCheckbox", testResult.RestrictedLeafletMotion);
                _resultPdfHelper.SetCheckBox(doc, "PpRestrictedLeafletAorticCheckbox", testResult.RestrictedLeafletMotionAortic);
                _resultPdfHelper.SetCheckBox(doc, "PpRestrictedLeafletMitralCheckbox", testResult.RestrictedLeafletMotionMitral);
                _resultPdfHelper.SetCheckBox(doc, "PpRestrictedLeafletPulCheckbox", testResult.RestrictedLeafletMotionPulmonic);
                _resultPdfHelper.SetCheckBox(doc, "PpRestrictedLeafletTriCheckbox", testResult.RestrictedLeafletMotionTricuspid);

                _resultPdfHelper.SetCheckBox(doc, "PpHypokineticCheckbox", testResult.Hypokinetic);
                _resultPdfHelper.SetCheckBox(doc, "PpAkineticCheckbox", testResult.Akinetic);
                _resultPdfHelper.SetCheckBox(doc, "PpDyskineticCheckbox", testResult.Dyskinetic);

                _resultPdfHelper.SetCheckBox(doc, "PpAnteriorCheckbox", testResult.Anterior);
                _resultPdfHelper.SetCheckBox(doc, "PpPosteriorCheckbox", testResult.Posterior);
                _resultPdfHelper.SetCheckBox(doc, "PpApicalCheckbox", testResult.Apical);

                _resultPdfHelper.SetCheckBox(doc, "PpSeptalCheckbox", testResult.Septal);
                _resultPdfHelper.SetCheckBox(doc, "PpLateralCheckbox", testResult.Lateral);
                _resultPdfHelper.SetCheckBox(doc, "PpInferiorCheckbox", testResult.Inferior);

                _resultPdfHelper.SetCheckBox(doc, "TechnicalLimitedbutReadablePpEchoCheckbox", testResult.TechnicallyLimitedbutReadable);
                _resultPdfHelper.SetCheckBox(doc, "RepeatStudyuneadablePpEchoCheckbox", testResult.RepeatStudyUnreadable);

                _resultPdfHelper.SetCheckBox(doc, "PpMorphologyTricuspidHigh35MmHgOrGreaterCheckbox", testResult.MorphologyTricuspidHighOrGreater);
                _resultPdfHelper.SetCheckBox(doc, "PpMorphologyTricuspidNormalCheckbox", testResult.MorphologyTricuspidNormal);

                _resultPdfHelper.LoadTestMedia(doc, testResult.Media, "testmedia-Ppecho", loadImages);
                _resultPdfHelper.SetPhysicianRemarks(doc, testResult, "followUpPpEcho", "criticalPpEcho", "physicianRemarksPpEcho");
                _resultPdfHelper.SetTechnician(doc, testResult, "techPpecho", "technotesPpecho", technicianIdNamePairs);
                _resultPdfHelper.SetUnableToScreenReasons(doc, TestType.PPEcho, "PpechoUnableToScreen", testResult.UnableScreenReason);

                selectedNode = doc.DocumentNode.SelectSingleNode("//span[@id='diagnosisCodePpecho']");
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

                selectedNode = doc.DocumentNode.SelectSingleNode("//div[@id='PpEcho-longdescription-div']");
                if (selectedNode != null)
                    selectedNode.SetAttributeValue("style", removeLongDescription ? "display:none" : "display:block");
            }
            else
            {
                _resultPdfHelper.SetUnableToScreenReasons(doc, TestType.PPEcho, "PpechoUnableToScreen", null);
                LoadPpEchoFinding(doc, null);
            }
        }

        private void LoadPpEchoFinding(HtmlDocument doc, PpEchocardiogramTestResult testResult)
        {
            var stdFindings = _standardFindingRepository.GetAllStandardFindings<int>((Int32)TestType.PPEcho);
            var estEjaFindings = _standardFindingRepository.GetAllStandardFindings<int>((Int32)TestType.PPEcho, (Int32)ReadingLabels.EstimatedEjactionFraction);
            var aorticFindings = _standardFindingRepository.GetAllStandardFindings<int>((Int32)TestType.PPEcho, (Int32)ReadingLabels.Aortic);
            var mitrlaFindings = _standardFindingRepository.GetAllStandardFindings<int>((Int32)TestType.PPEcho, (Int32)ReadingLabels.Mitral);
            var pulmonicFindings = _standardFindingRepository.GetAllStandardFindings<int>((Int32)TestType.PPEcho, (Int32)ReadingLabels.Pulmonic);
            var tricuspidFindings = _standardFindingRepository.GetAllStandardFindings<int>((Int32)TestType.PPEcho, (Int32)ReadingLabels.Tricuspid);
            var aorticMorphologyFindings = _standardFindingRepository.GetAllStandardFindings<int>((Int32)TestType.PPEcho, (Int32)ReadingLabels.AorticMorphology);
            var mitralMorphFindings = _standardFindingRepository.GetAllStandardFindings<int>((Int32)TestType.PPEcho, (Int32)ReadingLabels.MitralMorphology);
            var pulmonicMorphFindings = _standardFindingRepository.GetAllStandardFindings<int>((Int32)TestType.PPEcho, (Int32)ReadingLabels.PulmonicMorphology);
            var tricuspidMorphFindings = _standardFindingRepository.GetAllStandardFindings<int>((Int32)TestType.PPEcho, (Int32)ReadingLabels.TricuspidMorphology);
            var periEfuFindings = _standardFindingRepository.GetAllStandardFindings<int>((Int32)TestType.PPEcho, (Int32)ReadingLabels.PericardialEffusion);
            var diastolicFindings = _standardFindingRepository.GetAllStandardFindings<int>((Int32)TestType.PPEcho, (Int32)ReadingLabels.DiastolicDysfunction);

            UnableScreenReason unableScreenReason = null;
            //TODO: This is a hack for Echo Summary
            if (testResult != null && testResult.UnableScreenReason != null && testResult.UnableScreenReason.Count > 0 && testResult.UnableScreenReason.Where(us => us.Reason == UnableToScreenReason.TechnicallyLimitedButReadable).Count() < 1)
                unableScreenReason = testResult.UnableScreenReason.First();

            var selectedNode = doc.DocumentNode.SelectSingleNode("//span[@id='Ppecho-rpp-resultspan']");
            if (testResult != null && testResult.Finding != null && selectedNode != null)
            {
                var stdFinding = stdFindings.Where(f => f.Id == testResult.Finding.Id).Single();
                selectedNode.InnerHtml = stdFinding.Label;
            }

            _resultPdfHelper.SetSummaryFindings(doc, (testResult != null ? testResult.Finding : null), stdFindings, "FindingsPpEchoDiv", "longdescription-Ppecho", null, testResult != null, unableScreenReason);
            _resultPdfHelper.SetFindingsHorizontal(doc, testResult != null ? testResult.Finding : null, stdFindings, "PpechoFindings");
            _resultPdfHelper.SetFindingsVertical(doc, testResult != null ? testResult.EstimatedEjactionFraction : null, estEjaFindings, "PpestimatedEjacFinding");

            _resultPdfHelper.SetFindingsHorizontal(doc, testResult != null ? testResult.AorticRegurgitation : null, aorticFindings, "PpaorticRegurgitationFinding");
            _resultPdfHelper.SetFindingsHorizontal(doc, testResult != null ? testResult.MitralRegurgitation : null, mitrlaFindings, "PpmitralRegurgitationFinding");
            _resultPdfHelper.SetFindingsHorizontal(doc, testResult != null ? testResult.PulmonicRegurgitation : null, pulmonicFindings, "PppulmonicRegurgitationFinding");
            _resultPdfHelper.SetFindingsHorizontal(doc, testResult != null ? testResult.TricuspidRegurgitation : null, tricuspidFindings, "PptricuspidRegurgitationFinding");

            _resultPdfHelper.SetFindingsHorizontal(doc, testResult != null ? testResult.AorticMorphology : null, aorticMorphologyFindings, "PpaorticMorphologyFinding");
            _resultPdfHelper.SetFindingsHorizontal(doc, testResult != null ? testResult.MitralMorphology : null, mitralMorphFindings, "PpmitralMorphologyFinding");
            _resultPdfHelper.SetFindingsHorizontal(doc, testResult != null ? testResult.PulmonicMorphology : null, pulmonicMorphFindings, "PppulmonicMorphologyFinding");
            _resultPdfHelper.SetFindingsHorizontal(doc, testResult != null ? testResult.TricuspidMorphology : null, tricuspidMorphFindings, "PptricuspidMorphologyFinding");

            _resultPdfHelper.SetFindingsHorizontal(doc, testResult != null ? testResult.DistolicDysfunctionFinding : null, diastolicFindings, "PpdistolicDysfunctionFinding");
            _resultPdfHelper.SetFindingsHorizontal(doc, testResult != null ? testResult.PericardialEffusionFinding : null, periEfuFindings, "PppericardialEffFinding");
        }

        public void LoadAwvEchoTestResults(HtmlDocument doc, AwvEchocardiogramTestResult testResult, bool removeLongDescription, bool loadImages, List<OrderedPair<long, string>> technicianIdNamePairs,
            IEnumerable<CustomerScreeningEvaluatinPhysicianViewModel> physicians, IEnumerable<EventPhysicianTest> eventPhysicianTests, bool showUnreadableTest, IEnumerable<PhysicianEvaluation> eventCustomerPhysicianEvaluations,
            CustomerSkipReview customerSkipReview, long customerId, long eventId)
        {
            if (testResult != null)
            {
                var selectedNode = doc.DocumentNode.SelectSingleNode("//div[@id='AwvEcho-rpp-section']");
                if (selectedNode != null && (testResult.UnableScreenReason == null || testResult.UnableScreenReason.Count == 0) && (testResult.TestNotPerformed == null || testResult.TestNotPerformed.TestNotPerformedReasonId <= 0)
                    && (showUnreadableTest || testResult.RepeatStudyUnreadable == null || testResult.RepeatStudyUnreadable.Reading == false))
                    selectedNode.SetAttributeValue("style", "display:block;");

                _resultPdfHelper.SetPhysicianSignature(doc, "AwvEcho-primaryEvalPhysicianSign", "AwvEcho-overreadEvalPhysicianSign", physicians, eventPhysicianTests, eventCustomerPhysicianEvaluations, customerSkipReview);

                LoadAwvEchoFinding(doc, testResult, customerId, eventId, showUnreadableTest);

                _resultPdfHelper.SetCheckBox(doc, "AwvEchoValveAorticCheckbox", testResult.Aortic);
                _resultPdfHelper.SetInputBox(doc, "AwvEchoAorticVelocityTextbox", testResult.AoticVelocity);
                _resultPdfHelper.SetInputBox(doc, "PeakGradient", testResult.PeakGradient);
                _resultPdfHelper.SetInputBox(doc, "AorticEstimatedValveArea", testResult.AorticEstimatedValveArea);
                _resultPdfHelper.SetInputBox(doc, "AorticEstimatedRightValve", testResult.AorticEstimatedRightValve);

                _resultPdfHelper.SetCheckBox(doc, "AwvEchoValveMitralCheckbox", testResult.Mitral);
                _resultPdfHelper.SetInputBox(doc, "AwvEchoPTTextbox", testResult.MitralPT);
                _resultPdfHelper.SetInputBox(doc, "MitralEstimatedValveArea", testResult.MitralEstimatedValveArea);
                _resultPdfHelper.SetInputBox(doc, "MitralEstimatedRightValve", testResult.MitralEstimatedRightValve);

                _resultPdfHelper.SetCheckBox(doc, "AwvEchoValvePulmonicCheckbox", testResult.Pulmonic);
                _resultPdfHelper.SetInputBox(doc, "AwvEchoVelocityPulmonicTextbox", testResult.PulmonicVelocity);
                _resultPdfHelper.SetInputBox(doc, "PulmonicEstimatedValveArea", testResult.PulmonicEstimatedValveArea);

                _resultPdfHelper.SetCheckBox(doc, "AwvEchoValveTricuspidCheckbox", testResult.Tricuspid);
                _resultPdfHelper.SetInputBox(doc, "AwvEchoPapTextbox", testResult.TricuspidPap);
                _resultPdfHelper.SetInputBox(doc, "AwvEchoVelocityTricuspidTextbox", testResult.TricuspidVelocity);
                _resultPdfHelper.SetInputBox(doc, "TricuspidEstimatedValveArea", testResult.TricuspidEstimatedValveArea);
                _resultPdfHelper.SetCheckBox(doc, "AwvEchoMorphologyTricuspidHigh35MmHgOrGreaterCheckbox", testResult.MorphologyTricuspidHighOrGreater);
                _resultPdfHelper.SetCheckBox(doc, "AwvEchoMorphologyTricuspidNormalCheckbox", testResult.MorphologyTricuspidNormal);

                _resultPdfHelper.SetCheckBox(doc, "AwvEchoDiastolicDysfunctionCheckbox", testResult.DiastolicDysfunction);
                _resultPdfHelper.SetCheckBox(doc, "AwvEchoConsistentLvDiastolicFailureCheckbox", testResult.ConsistentLvDiastolicFailure);
                _resultPdfHelper.SetCheckBox(doc, "AwvEchoConsistentHypertensiveHeartDiseaseWithDiastolicHeartFailureCheckbox", testResult.ConsistentHypertensiveHeartDiseaseWithDiastolicHeartFailure);
                _resultPdfHelper.SetCheckBox(doc, "AwvEchoConsistentHypertensiveHeartDiseaseWithoutDiastolicHeartFailureCheckbox", testResult.ConsistentHypertensiveHeartDiseaseWithoutDiastolicHeartFailure);
                _resultPdfHelper.SetCheckBox(doc, "AwvEchoPericardialEffusionCheckbox", testResult.PericardialEffusion);
                _resultPdfHelper.SetCheckBox(doc, "AwvEchoAorticRootCheckbox", testResult.AorticRoot);
                _resultPdfHelper.SetCheckBox(doc, "AwvEchoAscendingAortaArchCheckbox", testResult.AscendingAortaArch);
                _resultPdfHelper.SetCheckBox(doc, "AwvEchoVentricularEnlargmentCheckbox", testResult.VentricularEnlargement);
                _resultPdfHelper.SetCheckBox(doc, "AwvEchoVentricularHypertrophyCheckbox", testResult.VentricularHypertrophy);
                _resultPdfHelper.SetCheckBox(doc, "AwvEchoAtrialEnlargmentCheckbox", testResult.AtrialEnlargement);
                _resultPdfHelper.SetCheckBox(doc, "AwvEchoArrythmiaCheckbox", testResult.Arrythmia);

                _resultPdfHelper.SetInputBox(doc, "DiastolicDysfunctionEeRatio", testResult.DiastolicDysfunctionEeRatio);

                _resultPdfHelper.SetCheckBox(doc, "AwvEchoAFibCheckbox", testResult.AFib);
                _resultPdfHelper.SetCheckBox(doc, "AwvEchoAFlutterCheckbox", testResult.AFlutter);
                _resultPdfHelper.SetCheckBox(doc, "AwvEchoPACCheckbox", testResult.PAC);
                _resultPdfHelper.SetCheckBox(doc, "AwvEchoPVCCheckbox", testResult.PVC);

                _resultPdfHelper.SetCheckBox(doc, "AwvEchoScleroticCheckbox", testResult.Sclerotic);
                _resultPdfHelper.SetCheckBox(doc, "AwvEchoCalcifiedCheckbox", testResult.Calcified);
                _resultPdfHelper.SetCheckBox(doc, "AwvEchoEnlargedCheckbox", testResult.Enlarged);
                _resultPdfHelper.SetInputBox(doc, "AwvEchoEnlargedTextbox", testResult.EnlargedValue);

                _resultPdfHelper.SetCheckBox(doc, "AwvEchoAtherosclerosis", testResult.Atherosclerosis);

                _resultPdfHelper.SetCheckBox(doc, "AwvEchoLeftVEnlargementCheckbox", testResult.LeftVentricularEnlargment);
                _resultPdfHelper.SetInputBox(doc, "AwvEchoLeftVEnlargementTextbox", testResult.LeftVentricularEnlargmentValue);
                _resultPdfHelper.SetCheckBox(doc, "AwvEchoRightVEnlargementCheckbox", testResult.RightVentricularEnlargment);
                _resultPdfHelper.SetInputBox(doc, "AwvEchoRightVEnlargementTextbox", testResult.RightVentricularEnlargmentValue);

                _resultPdfHelper.SetCheckBox(doc, "AwvEchoLeftVHypertrophyCheckbox", testResult.LeftVHypertrophy);
                _resultPdfHelper.SetInputBox(doc, "AwvEchoLeftVHypertrophyTextbox", testResult.LeftVHypertrophyValue);
                _resultPdfHelper.SetCheckBox(doc, "AwvEchoRightVHypertrophyCheckbox", testResult.RightVHypertrophy);
                _resultPdfHelper.SetInputBox(doc, "AwvEchoRightVHypertrophyTextbox", testResult.RightVHypertrophyValue);
                _resultPdfHelper.SetCheckBox(doc, "AwvEchoIvshCheckbox", testResult.IvshHypertrophy);
                _resultPdfHelper.SetInputBox(doc, "AwvEchoIvshTextbox", testResult.IvshHypertrophyValue);

                _resultPdfHelper.SetCheckBox(doc, "AwvEchoLeftAtrialEnlargementCheckbox", testResult.LeftAtrialEnlargment);
                _resultPdfHelper.SetInputBox(doc, "AwvEchoLeftAtrialEnlargementTextbox", testResult.LeftAtrialEnlargmentValue);
                _resultPdfHelper.SetCheckBox(doc, "AwvEchoRightAtrialEnlargementCheckbox", testResult.RightAtrialEnlargment);
                _resultPdfHelper.SetInputBox(doc, "AwvEchoRightAtrialEnlargementTextbox", testResult.RightAtrialEnlargmentValue);

                _resultPdfHelper.SetCheckBox(doc, "AwvEchoAsdCheckbox", testResult.ASD);
                _resultPdfHelper.SetCheckBox(doc, "AwvEchoPfoCheckbox", testResult.PFO);
                _resultPdfHelper.SetCheckBox(doc, "AwvEchoFlailCheckbox", testResult.FlailAS);
                _resultPdfHelper.SetCheckBox(doc, "AwvEchoVsdCheckbox", testResult.VSD);

                _resultPdfHelper.SetCheckBox(doc, "AwvEchoMitralAnnularCheckbox", testResult.MitralAnnularCa);

                _resultPdfHelper.SetCheckBox(doc, "AwvEchoRestrictedLeafletCheckbox", testResult.RestrictedLeafletMotion);
                _resultPdfHelper.SetCheckBox(doc, "AwvEchoRestrictedLeafletAorticCheckbox", testResult.RestrictedLeafletMotionAortic);
                _resultPdfHelper.SetCheckBox(doc, "AwvEchoRestrictedLeafletMitralCheckbox", testResult.RestrictedLeafletMotionMitral);
                _resultPdfHelper.SetCheckBox(doc, "AwvEchoRestrictedLeafletPulCheckbox", testResult.RestrictedLeafletMotionPulmonic);
                _resultPdfHelper.SetCheckBox(doc, "AwvEchoRestrictedLeafletTriCheckbox", testResult.RestrictedLeafletMotionTricuspid);

                _resultPdfHelper.SetCheckBox(doc, "AwvEchoHypokineticCheckbox", testResult.Hypokinetic);
                _resultPdfHelper.SetCheckBox(doc, "AwvEchoAkineticCheckbox", testResult.Akinetic);
                _resultPdfHelper.SetCheckBox(doc, "AwvEchoDyskineticCheckbox", testResult.Dyskinetic);

                _resultPdfHelper.SetCheckBox(doc, "AwvEchoAnteriorCheckbox", testResult.Anterior);
                _resultPdfHelper.SetCheckBox(doc, "AwvEchoPosteriorCheckbox", testResult.Posterior);
                _resultPdfHelper.SetCheckBox(doc, "AwvEchoApicalCheckbox", testResult.Apical);

                _resultPdfHelper.SetCheckBox(doc, "AwvEchoSeptalCheckbox", testResult.Septal);
                _resultPdfHelper.SetCheckBox(doc, "AwvEchoLateralCheckbox", testResult.Lateral);
                _resultPdfHelper.SetCheckBox(doc, "AwvEchoInferiorCheckbox", testResult.Inferior);

                _resultPdfHelper.SetCheckBox(doc, "TechnicalLimitedbutReadableAwvEchoCheckbox", testResult.TechnicallyLimitedbutReadable);
                _resultPdfHelper.SetCheckBox(doc, "RepeatStudyuneadableAwvEchoCheckbox", testResult.RepeatStudyUnreadable);

                _resultPdfHelper.LoadTestMedia(doc, testResult.Media, "testmedia-AwvEcho", loadImages);
                _resultPdfHelper.SetPhysicianRemarks(doc, testResult, "followUpAwvEcho", "criticalAwvEcho", "physicianRemarksAwvEcho");
                _resultPdfHelper.SetTechnician(doc, testResult, "techAwvEcho", "technotesAwvEcho", technicianIdNamePairs);

                _resultPdfHelper.SetUnableToScreenReasons(doc, TestType.AwvEcho, "AwvEchoUnableToScreen", testResult.UnableScreenReason);

                selectedNode = doc.DocumentNode.SelectSingleNode("//div[@id='AwvEcho-longdescription-div']");
                if (selectedNode != null)
                    selectedNode.SetAttributeValue("style", removeLongDescription ? "display:none" : "display:block");
            }
            else
            {
                _resultPdfHelper.SetUnableToScreenReasons(doc, TestType.Echocardiogram, "AwvEchoUnableToScreen", null);
                LoadAwvEchoFinding(doc, null, customerId, eventId, showUnreadableTest);
            }
        }

        private void LoadAwvEchoFinding(HtmlDocument doc, AwvEchocardiogramTestResult testResult, long customerId, long eventId, bool showUnreadableTest)
        {
            var stdFindings = _standardFindingRepository.GetAllStandardFindings<int>((Int32)TestType.AwvEcho);
            List<StandardFinding<int>> estEjaFindings;

            if (_settings.AwvEchoFindingChangeDate.HasValue)
            {
                var eventCustomerResult = _eventCustomerResultRepository.GetByCustomerIdAndEventId(customerId, eventId);
                if (eventCustomerResult != null && eventCustomerResult.DataRecorderMetaData.DateCreated < _settings.AwvEchoFindingChangeDate.Value)
                {
                    estEjaFindings = _standardFindingRepository.GetAllStandardFindings<int>((int)TestType.AwvEcho, (int)ReadingLabels.EstimatedEjactionFraction, _settings.AwvEchoFindingChangeDate.Value, true);
                }
                else
                {
                    estEjaFindings = _standardFindingRepository.GetAllStandardFindings<int>((int)TestType.AwvEcho, (int)ReadingLabels.EstimatedEjactionFraction, _settings.AwvEchoFindingChangeDate.Value, false);
                }
            }
            else
            {
                estEjaFindings = _standardFindingRepository.GetAllStandardFindings<int>((Int32)TestType.AwvEcho, (Int32)ReadingLabels.EstimatedEjactionFraction);
            }


            var aorticFindings = _standardFindingRepository.GetAllStandardFindings<int>((Int32)TestType.AwvEcho, (Int32)ReadingLabels.Aortic);
            var mitrlaFindings = _standardFindingRepository.GetAllStandardFindings<int>((Int32)TestType.AwvEcho, (Int32)ReadingLabels.Mitral);
            var pulmonicFindings = _standardFindingRepository.GetAllStandardFindings<int>((Int32)TestType.AwvEcho, (Int32)ReadingLabels.Pulmonic);
            var tricuspidFindings = _standardFindingRepository.GetAllStandardFindings<int>((Int32)TestType.AwvEcho, (Int32)ReadingLabels.Tricuspid);
            var aorticMorphologyFindings = _standardFindingRepository.GetAllStandardFindings<int>((Int32)TestType.AwvEcho, (Int32)ReadingLabels.AorticMorphology);
            var mitralMorphFindings = _standardFindingRepository.GetAllStandardFindings<int>((Int32)TestType.AwvEcho, (Int32)ReadingLabels.MitralMorphology);
            var pulmonicMorphFindings = _standardFindingRepository.GetAllStandardFindings<int>((Int32)TestType.AwvEcho, (Int32)ReadingLabels.PulmonicMorphology);
            var tricuspidMorphFindings = _standardFindingRepository.GetAllStandardFindings<int>((Int32)TestType.AwvEcho, (Int32)ReadingLabels.TricuspidMorphology);
            var periEfuFindings = _standardFindingRepository.GetAllStandardFindings<int>((Int32)TestType.AwvEcho, (Int32)ReadingLabels.PericardialEffusion);
            var diastolicFindings = _standardFindingRepository.GetAllStandardFindings<int>((Int32)TestType.AwvEcho, (Int32)ReadingLabels.DiastolicDysfunction);

            UnableScreenReason unableScreenReason = null;
            //TODO: This is a hack for Echo Summary
            if (testResult != null && testResult.UnableScreenReason != null && testResult.UnableScreenReason.Count > 0 && testResult.UnableScreenReason.Count(us => us.Reason == UnableToScreenReason.TechnicallyLimitedButReadable) < 1)
                unableScreenReason = testResult.UnableScreenReason.First();

            var selectedNode = doc.DocumentNode.SelectSingleNode("//span[@id='AwvEcho-rpp-resultspan']");
            if (testResult != null && testResult.Finding != null && selectedNode != null)
            {
                var stdFinding = stdFindings.Single(f => f.Id == testResult.Finding.Id);
                selectedNode.InnerHtml = stdFinding.Label;
            }

            _resultPdfHelper.SetSummaryFindings(doc, (testResult != null ? testResult.Finding : null), stdFindings, "FindingsAwvEchoDiv", "longdescription-AwvEcho", null, testResult != null, unableScreenReason);
            _resultPdfHelper.SetFindingsHorizontal(doc, testResult != null ? testResult.Finding : null, stdFindings, "AwvEchoFindings");

            _resultPdfHelper.SetFindingsHorizontal(doc, testResult != null ? testResult.EstimatedEjactionFraction : null, estEjaFindings, "AwvEchoEstimatedEjacFinding", 6);
            _resultPdfHelper.SetFindingsHorizontal(doc, testResult != null ? testResult.AorticRegurgitation : null, aorticFindings, "AwvEchoAorticRegurgitationFinding");
            _resultPdfHelper.SetFindingsHorizontal(doc, testResult != null ? testResult.MitralRegurgitation : null, mitrlaFindings, "AwvEchoMitralRegurgitationFinding");
            _resultPdfHelper.SetFindingsHorizontal(doc, testResult != null ? testResult.PulmonicRegurgitation : null, pulmonicFindings, "AwvEchoPulmonicRegurgitationFinding");
            _resultPdfHelper.SetFindingsHorizontal(doc, testResult != null ? testResult.TricuspidRegurgitation : null, tricuspidFindings, "AwvEchoTricuspidRegurgitationFinding");

            _resultPdfHelper.SetFindingsHorizontal(doc, testResult != null ? testResult.AorticMorphology : null, aorticMorphologyFindings, "AwvEchoAorticMorphologyFinding");
            _resultPdfHelper.SetFindingsHorizontal(doc, testResult != null ? testResult.MitralMorphology : null, mitralMorphFindings, "AwvEchoMitralMorphologyFinding");
            _resultPdfHelper.SetFindingsHorizontal(doc, testResult != null ? testResult.PulmonicMorphology : null, pulmonicMorphFindings, "AwvEchoPulmonicMorphologyFinding");
            _resultPdfHelper.SetFindingsHorizontal(doc, testResult != null ? testResult.TricuspidMorphology : null, tricuspidMorphFindings, "AwvEchoTricuspidMorphologyFinding");

            _resultPdfHelper.SetFindingsHorizontal(doc, testResult != null ? testResult.DistolicDysfunctionFinding : null, diastolicFindings, "AwvEchoDistolicDysfunctionFinding");
            _resultPdfHelper.SetFindingsHorizontal(doc, testResult != null ? testResult.PericardialEffusionFinding : null, periEfuFindings, "AwvEchoPericardialEffFinding");

            _resultPdfHelper.SetFindingsHorizontal(doc, testResult != null ? testResult.PericardialEffusionFinding : null, periEfuFindings, "AwvEchoPericardialEffFinding");

            AwvEchocardiogramConclusionFinding(doc, testResult, showUnreadableTest);
        }

        private List<ResultReading<int>> _readings;

        private void AwvEchocardiogramConclusionFinding(HtmlDocument doc, AwvEchocardiogramTestResult testResult, bool showUnreadableTest)
        {
            var awvEchocardiogramRepository = new AwvEchocardiogramTestRepository();
            _readings = awvEchocardiogramRepository.GetReadingsForTest();

            var showAdditionalReadingPage = false;

            if (SetAwvEchoEjectionFractionReadingData(doc, testResult))
                showAdditionalReadingPage = true;

            if (SetAwvEchoLeftVentricleReadingData(doc, testResult))
                showAdditionalReadingPage = true;

            if (SetAwvEchoLeftAtriumReadingData(doc, testResult))
                showAdditionalReadingPage = true;

            if (SetAwvEchoRightVentricleReadingData(doc, testResult))
                showAdditionalReadingPage = true;

            if (SetAwvEchoRightAtriumReadingData(doc, testResult))
                showAdditionalReadingPage = true;

            if (SetAwvEchoAortaReadingData(doc, testResult))
                showAdditionalReadingPage = true;

            if (SetAwvEchoMitralReadingData(doc, testResult))
                showAdditionalReadingPage = true;

            if (SetAwvEchoPulmonaryReadingData(doc, testResult))
                showAdditionalReadingPage = true;

            if (SetAwvEchoTricuspidReadingData(doc, testResult))
                showAdditionalReadingPage = true;

            var selectedNode = doc.DocumentNode.SelectSingleNode("//div[@id='AwvEcho-AdditionalReading-rpp-section']");

            if (selectedNode != null && testResult != null && (testResult.UnableScreenReason == null || testResult.UnableScreenReason.Count == 0) && (testResult.TestNotPerformed == null || testResult.TestNotPerformed.TestNotPerformedReasonId <= 0)
                    && (showUnreadableTest || testResult.RepeatStudyUnreadable == null || testResult.RepeatStudyUnreadable.Reading == false) && showAdditionalReadingPage)
            {
                selectedNode.SetAttributeValue("style", "display:block;");
            }

        }

        private bool SetAwvEchoTricuspidReadingData(HtmlDocument doc, AwvEchocardiogramTestResult testResult)
        {
            var selectedNode = doc.DocumentNode.SelectSingleNode("//div[@id='TricuspidFindingSection']");
            if (testResult != null && selectedNode != null)
            {
                var conclusionNode = doc.DocumentNode.SelectSingleNode("//div[@id='TricuspidFindingConclusion']");
                var conclusionTextBuilder = new StringBuilder();
                if (conclusionNode != null)
                {
                    var conclusionText = CreateConclusionText(testResult.TricuspidInsufficiencyAbsent);
                    if (!string.IsNullOrEmpty(conclusionText))
                        conclusionTextBuilder.Append(conclusionText + "<br/>");

                    conclusionText = CreateConclusionText(testResult.TricuspidInsufficiencyMinor);
                    if (!string.IsNullOrEmpty(conclusionText))
                        conclusionTextBuilder.Append(conclusionText + "<br/>");

                    conclusionText = CreateConclusionText(testResult.TricuspidInsufficiencyModerate);
                    if (!string.IsNullOrEmpty(conclusionText))
                        conclusionTextBuilder.Append(conclusionText + "<br/>");

                    conclusionText = CreateConclusionText(testResult.TricuspidInsufficiencySevere);
                    if (!string.IsNullOrEmpty(conclusionText))
                        conclusionTextBuilder.Append(conclusionText + "<br/>");


                    conclusionText = CreateConclusionText(testResult.TricuspidLeafletsNormal);
                    if (!string.IsNullOrEmpty(conclusionText))
                        conclusionTextBuilder.Append(conclusionText + "<br/>");

                    conclusionText = CreateConclusionText(testResult.TricuspidLeafletsThickened);
                    if (!string.IsNullOrEmpty(conclusionText))
                        conclusionTextBuilder.Append(conclusionText + "<br/>");

                    conclusionText = CreateConclusionText(testResult.TricuspidLeafletsRedundant);
                    if (!string.IsNullOrEmpty(conclusionText))
                        conclusionTextBuilder.Append(conclusionText + "<br/>");

                    conclusionText = CreateConclusionText(testResult.TricuspidLeafletsMildStenosis);
                    if (!string.IsNullOrEmpty(conclusionText))
                        conclusionTextBuilder.Append(conclusionText + "<br/>");

                    conclusionText = CreateConclusionText(testResult.TricuspidLeafletsModerateStenosis);
                    if (!string.IsNullOrEmpty(conclusionText))
                        conclusionTextBuilder.Append(conclusionText + "<br/>");

                    conclusionText = CreateConclusionText(testResult.TricuspidLeafletsSevereStenosis);
                    if (!string.IsNullOrEmpty(conclusionText))
                        conclusionTextBuilder.Append(conclusionText + "<br/>");


                    conclusionText = CreateConclusionText(testResult.TricuspidValveNotEvaluated);
                    if (!string.IsNullOrEmpty(conclusionText))
                        conclusionTextBuilder.Append(conclusionText + "<br/>");

                    conclusionText = CreateConclusionText(testResult.TricuspidValveBicuspid);
                    if (!string.IsNullOrEmpty(conclusionText))
                        conclusionTextBuilder.Append(conclusionText + "<br/>");

                    conclusionText = CreateConclusionText(testResult.TricuspidValveAtherosclerotic);
                    if (!string.IsNullOrEmpty(conclusionText))
                        conclusionTextBuilder.Append(conclusionText + "<br/>");

                    conclusionText = CreateConclusionText(testResult.TricuspidValveNormalFunctioningBiologicalProsthesis);
                    if (!string.IsNullOrEmpty(conclusionText))
                        conclusionTextBuilder.Append(conclusionText + "<br/>");

                    conclusionText = CreateConclusionText(testResult.TricuspidValveNormalFunctioningMechanicalProsthesis);
                    if (!string.IsNullOrEmpty(conclusionText))
                        conclusionTextBuilder.Append(conclusionText + "<br/>");

                    conclusionText = CreateConclusionText(testResult.TricuspidValveMalfunctioningBiologicalProsthesis);
                    if (!string.IsNullOrEmpty(conclusionText))
                        conclusionTextBuilder.Append(conclusionText + "<br/>");

                    conclusionText = CreateConclusionText(testResult.TricuspidValveMalfunctioningMechanicalProsthesis);
                    if (!string.IsNullOrEmpty(conclusionText))
                        conclusionTextBuilder.Append(conclusionText + "<br/>");


                    conclusionText = conclusionTextBuilder.ToString().Trim();

                    if (!string.IsNullOrEmpty(conclusionText))
                    {
                        selectedNode.SetAttributeValue("style", "display:block;");
                        conclusionNode.InnerHtml = conclusionText;
                        return true;
                    }
                }
            }
            return false;
        }

        private bool SetAwvEchoPulmonaryReadingData(HtmlDocument doc, AwvEchocardiogramTestResult testResult)
        {
            var selectedNode = doc.DocumentNode.SelectSingleNode("//div[@id='PulmonaryFindingSection']");
            if (testResult != null && selectedNode != null)
            {
                var conclusionNode = doc.DocumentNode.SelectSingleNode("//div[@id='PulmonaryFindingConclusion']");
                var conclusionTextBuilder = new StringBuilder();
                if (conclusionNode != null)
                {
                    var conclusionText = CreateConclusionText(testResult.PulmonaryInsufficiencyAbsent);
                    if (!string.IsNullOrEmpty(conclusionText))
                        conclusionTextBuilder.Append(conclusionText + "<br/>");

                    conclusionText = CreateConclusionText(testResult.PulmonaryInsufficiencyMinor);
                    if (!string.IsNullOrEmpty(conclusionText))
                        conclusionTextBuilder.Append(conclusionText + "<br/>");

                    conclusionText = CreateConclusionText(testResult.PulmonaryInsufficiencyModerate);
                    if (!string.IsNullOrEmpty(conclusionText))
                        conclusionTextBuilder.Append(conclusionText + "<br/>");

                    conclusionText = CreateConclusionText(testResult.PulmonaryInsufficiencySevere);
                    if (!string.IsNullOrEmpty(conclusionText))
                        conclusionTextBuilder.Append(conclusionText + "<br/>");


                    conclusionText = CreateConclusionText(testResult.PulmonaryLeafletsNormal);
                    if (!string.IsNullOrEmpty(conclusionText))
                        conclusionTextBuilder.Append(conclusionText + "<br/>");

                    conclusionText = CreateConclusionText(testResult.PulmonaryLeafletsThickened);
                    if (!string.IsNullOrEmpty(conclusionText))
                        conclusionTextBuilder.Append(conclusionText + "<br/>");

                    conclusionText = CreateConclusionText(testResult.PulmonaryLeafletsStenotic);
                    if (!string.IsNullOrEmpty(conclusionText))
                        conclusionTextBuilder.Append(conclusionText + "<br/>");

                    conclusionText = CreateConclusionText(testResult.PulmonaryLeafletsMildStenosis);
                    if (!string.IsNullOrEmpty(conclusionText))
                        conclusionTextBuilder.Append(conclusionText + "<br/>");

                    conclusionText = CreateConclusionText(testResult.PulmonaryLeafletsModerateStenosis);
                    if (!string.IsNullOrEmpty(conclusionText))
                        conclusionTextBuilder.Append(conclusionText + "<br/>");

                    conclusionText = CreateConclusionText(testResult.PulmonaryLeafletsSevereStenosis);
                    if (!string.IsNullOrEmpty(conclusionText))
                        conclusionTextBuilder.Append(conclusionText + "<br/>");


                    conclusionText = CreateConclusionText(testResult.PulmonaryValveNotEvaluated);
                    if (!string.IsNullOrEmpty(conclusionText))
                        conclusionTextBuilder.Append(conclusionText + "<br/>");

                    conclusionText = CreateConclusionText(testResult.PulmonaryValveBicuspid);
                    if (!string.IsNullOrEmpty(conclusionText))
                        conclusionTextBuilder.Append(conclusionText + "<br/>");

                    conclusionText = CreateConclusionText(testResult.PulmonaryValveAtherosclerotic);
                    if (!string.IsNullOrEmpty(conclusionText))
                        conclusionTextBuilder.Append(conclusionText + "<br/>");

                    conclusionText = CreateConclusionText(testResult.PulmonaryValveNormalFunctioningBiologicalProsthesis);
                    if (!string.IsNullOrEmpty(conclusionText))
                        conclusionTextBuilder.Append(conclusionText + "<br/>");

                    conclusionText = CreateConclusionText(testResult.PulmonaryValveNormalFunctioningMechanicalProsthesis);
                    if (!string.IsNullOrEmpty(conclusionText))
                        conclusionTextBuilder.Append(conclusionText + "<br/>");

                    conclusionText = CreateConclusionText(testResult.PulmonaryValveMalfunctioningBiologicalProsthesis);
                    if (!string.IsNullOrEmpty(conclusionText))
                        conclusionTextBuilder.Append(conclusionText + "<br/>");

                    conclusionText = CreateConclusionText(testResult.PulmonaryValveMalfunctioningMechanicalProsthesis);
                    if (!string.IsNullOrEmpty(conclusionText))
                        conclusionTextBuilder.Append(conclusionText + "<br/>");


                    conclusionText = conclusionTextBuilder.ToString().Trim();

                    if (!string.IsNullOrEmpty(conclusionText))
                    {
                        selectedNode.SetAttributeValue("style", "display:block;");
                        conclusionNode.InnerHtml = conclusionText;
                        return true;
                    }
                }
            }
            return false;
        }

        private bool SetAwvEchoMitralReadingData(HtmlDocument doc, AwvEchocardiogramTestResult testResult)
        {
            var selectedNode = doc.DocumentNode.SelectSingleNode("//div[@id='MitralFindingSection']");
            if (testResult != null && selectedNode != null)
            {
                var conclusionNode = doc.DocumentNode.SelectSingleNode("//div[@id='MitralFindingConclusion']");
                var conclusionTextBuilder = new StringBuilder();
                if (conclusionNode != null)
                {
                    var conclusionText = CreateConclusionText(testResult.MitralInsufficiencyAbsent);
                    if (!string.IsNullOrEmpty(conclusionText))
                        conclusionTextBuilder.Append(conclusionText + "<br/>");

                    conclusionText = CreateConclusionText(testResult.MitralInsufficiencyMinor);
                    if (!string.IsNullOrEmpty(conclusionText))
                        conclusionTextBuilder.Append(conclusionText + "<br/>");

                    conclusionText = CreateConclusionText(testResult.MitralInsufficiencyModerate);
                    if (!string.IsNullOrEmpty(conclusionText))
                        conclusionTextBuilder.Append(conclusionText + "<br/>");

                    conclusionText = CreateConclusionText(testResult.MitralInsufficiencySevere);
                    if (!string.IsNullOrEmpty(conclusionText))
                        conclusionTextBuilder.Append(conclusionText + "<br/>");


                    conclusionText = CreateConclusionText(testResult.MitralLeafletsNotEvaluated);
                    if (!string.IsNullOrEmpty(conclusionText))
                        conclusionTextBuilder.Append(conclusionText + "<br/>");

                    conclusionText = CreateConclusionText(testResult.MitralLeafletsNormal);
                    if (!string.IsNullOrEmpty(conclusionText))
                        conclusionTextBuilder.Append(conclusionText + "<br/>");

                    conclusionText = CreateConclusionText(testResult.MitralLeafletsRedundant);
                    if (!string.IsNullOrEmpty(conclusionText))
                        conclusionTextBuilder.Append(conclusionText + "<br/>");

                    conclusionText = CreateConclusionText(testResult.MitralLeafletsMildStenosis);
                    if (!string.IsNullOrEmpty(conclusionText))
                        conclusionTextBuilder.Append(conclusionText + "<br/>");

                    conclusionText = CreateConclusionText(testResult.MitralLeafletsModerateStenosis);
                    if (!string.IsNullOrEmpty(conclusionText))
                        conclusionTextBuilder.Append(conclusionText + "<br/>");

                    conclusionText = CreateConclusionText(testResult.MitralLeafletsSevereStenosis);
                    if (!string.IsNullOrEmpty(conclusionText))
                        conclusionTextBuilder.Append(conclusionText + "<br/>");


                    conclusionText = CreateConclusionText(testResult.MitralValveNotEvaluated);
                    if (!string.IsNullOrEmpty(conclusionText))
                        conclusionTextBuilder.Append(conclusionText + "<br/>");

                    conclusionText = CreateConclusionText(testResult.MitralValveBicuspid);
                    if (!string.IsNullOrEmpty(conclusionText))
                        conclusionTextBuilder.Append(conclusionText + "<br/>");

                    conclusionText = CreateConclusionText(testResult.MitralValveAtherosclerotic);
                    if (!string.IsNullOrEmpty(conclusionText))
                        conclusionTextBuilder.Append(conclusionText + "<br/>");

                    conclusionText = CreateConclusionText(testResult.MitralValveNormalFunctioningBiologicalProsthesis);
                    if (!string.IsNullOrEmpty(conclusionText))
                        conclusionTextBuilder.Append(conclusionText + "<br/>");

                    conclusionText = CreateConclusionText(testResult.MitralValveNormalFunctioningMechanicalProsthesis);
                    if (!string.IsNullOrEmpty(conclusionText))
                        conclusionTextBuilder.Append(conclusionText + "<br/>");

                    conclusionText = CreateConclusionText(testResult.MitralValveMalfunctioningBiologicalProsthesis);
                    if (!string.IsNullOrEmpty(conclusionText))
                        conclusionTextBuilder.Append(conclusionText + "<br/>");

                    conclusionText = CreateConclusionText(testResult.MitralValveMalfunctioningMechanicalProsthesis);
                    if (!string.IsNullOrEmpty(conclusionText))
                        conclusionTextBuilder.Append(conclusionText + "<br/>");


                    conclusionText = conclusionTextBuilder.ToString().Trim();

                    if (!string.IsNullOrEmpty(conclusionText))
                    {
                        selectedNode.SetAttributeValue("style", "display:block;");
                        conclusionNode.InnerHtml = conclusionText;
                        return true;
                    }
                }
            }
            return false;
        }

        private bool SetAwvEchoAortaReadingData(HtmlDocument doc, AwvEchocardiogramTestResult testResult)
        {
            var selectedNode = doc.DocumentNode.SelectSingleNode("//div[@id='AortaFindingSection']");
            if (testResult != null && selectedNode != null)
            {
                var conclusionNode = doc.DocumentNode.SelectSingleNode("//div[@id='AortaFindingConclusion']");
                var conclusionTextBuilder = new StringBuilder();
                if (conclusionNode != null)
                {
                    var conclusionText = CreateConclusionText(testResult.AortaInsufficiencyAbsent);
                    if (!string.IsNullOrEmpty(conclusionText))
                        conclusionTextBuilder.Append(conclusionText + "<br/>");

                    conclusionText = CreateConclusionText(testResult.AortaInsufficiencyMinor);
                    if (!string.IsNullOrEmpty(conclusionText))
                        conclusionTextBuilder.Append(conclusionText + "<br/>");

                    conclusionText = CreateConclusionText(testResult.AortaInsufficiencyModerate);
                    if (!string.IsNullOrEmpty(conclusionText))
                        conclusionTextBuilder.Append(conclusionText + "<br/>");

                    conclusionText = CreateConclusionText(testResult.AortaInsufficiencySevere);
                    if (!string.IsNullOrEmpty(conclusionText))
                        conclusionTextBuilder.Append(conclusionText + "<br/>");


                    conclusionText = CreateConclusionText(testResult.AortaLeafletsNotEvaluated);
                    if (!string.IsNullOrEmpty(conclusionText))
                        conclusionTextBuilder.Append(conclusionText + "<br/>");

                    conclusionText = CreateConclusionText(testResult.AortaLeafletsNormal);
                    if (!string.IsNullOrEmpty(conclusionText))
                        conclusionTextBuilder.Append(conclusionText + "<br/>");

                    conclusionText = CreateConclusionText(testResult.AortaLeafletsMildStenosis);
                    if (!string.IsNullOrEmpty(conclusionText))
                        conclusionTextBuilder.Append(conclusionText + "<br/>");

                    conclusionText = CreateConclusionText(testResult.AortaLeafletsModerateStenosis);
                    if (!string.IsNullOrEmpty(conclusionText))
                        conclusionTextBuilder.Append(conclusionText + "<br/>");

                    conclusionText = CreateConclusionText(testResult.AortaLeafletsSevereStenosis);
                    if (!string.IsNullOrEmpty(conclusionText))
                        conclusionTextBuilder.Append(conclusionText + "<br/>");


                    conclusionText = CreateConclusionText(testResult.AortaValveNotEvaluated);
                    if (!string.IsNullOrEmpty(conclusionText))
                        conclusionTextBuilder.Append(conclusionText + "<br/>");

                    conclusionText = CreateConclusionText(testResult.AortaValveBicuspid);
                    if (!string.IsNullOrEmpty(conclusionText))
                        conclusionTextBuilder.Append(conclusionText + "<br/>");


                    conclusionText = CreateConclusionText(testResult.AortaValveAtherosclerotic);
                    if (!string.IsNullOrEmpty(conclusionText))
                        conclusionTextBuilder.Append(conclusionText + "<br/>");

                    conclusionText = CreateConclusionText(testResult.AortaValveNormalFunctioningBiologicalProsthesis);
                    if (!string.IsNullOrEmpty(conclusionText))
                        conclusionTextBuilder.Append(conclusionText + "<br/>");

                    conclusionText = CreateConclusionText(testResult.AortaValveNormalFunctioningMechanicalProsthesis);
                    if (!string.IsNullOrEmpty(conclusionText))
                        conclusionTextBuilder.Append(conclusionText + "<br/>");


                    conclusionText = CreateConclusionText(testResult.AortaValveMalfunctioningBiologicalProsthesis);
                    if (!string.IsNullOrEmpty(conclusionText))
                        conclusionTextBuilder.Append(conclusionText + "<br/>");

                    conclusionText = CreateConclusionText(testResult.AortaValveMalfunctioningMechanicalProsthesis);
                    if (!string.IsNullOrEmpty(conclusionText))
                        conclusionTextBuilder.Append(conclusionText + "<br/>");

                    conclusionText = CreateConclusionText(testResult.AortaValveDilatedAorticRoot);
                    if (!string.IsNullOrEmpty(conclusionText))
                        conclusionTextBuilder.Append(conclusionText + "<br/>");

                    conclusionText = CreateConclusionText(testResult.AortaValveSinusValsalvaAneurysm);
                    if (!string.IsNullOrEmpty(conclusionText))
                        conclusionTextBuilder.Append(conclusionText + "<br/>");

                    conclusionText = conclusionTextBuilder.ToString().Trim();

                    if (!string.IsNullOrEmpty(conclusionText))
                    {
                        selectedNode.SetAttributeValue("style", "display:block;");
                        conclusionNode.InnerHtml = conclusionText;
                        return true;
                    }
                }
            }
            return false;
        }

        private bool SetAwvEchoRightAtriumReadingData(HtmlDocument doc, AwvEchocardiogramTestResult testResult)
        {
            var selectedNode = doc.DocumentNode.SelectSingleNode("//div[@id='RightAtriumFindingSection']");
            if (testResult != null && selectedNode != null)
            {
                var conclusionNode = doc.DocumentNode.SelectSingleNode("//div[@id='RightAtriumFindingConclusion']");
                var conclusionTextBuilder = new StringBuilder();
                if (conclusionNode != null)
                {
                    var conclusionText = CreateConclusionText(testResult.RightAtriumRADimensionsNotEvaluated);
                    if (!string.IsNullOrEmpty(conclusionText))
                        conclusionTextBuilder.Append(conclusionText + "<br/>");

                    conclusionText = CreateConclusionText(testResult.RightAtriumRADimensionsNormal);
                    if (!string.IsNullOrEmpty(conclusionText))
                        conclusionTextBuilder.Append(conclusionText + "<br/>");

                    conclusionText = CreateConclusionText(testResult.RightAtriumRADimensionsMildlyDilated);
                    if (!string.IsNullOrEmpty(conclusionText))
                        conclusionTextBuilder.Append(conclusionText + "<br/>");

                    conclusionText = CreateConclusionText(testResult.RightAtriumRADimensionsModeratelyDilated);
                    if (!string.IsNullOrEmpty(conclusionText))
                        conclusionTextBuilder.Append(conclusionText + "<br/>");

                    conclusionText = CreateConclusionText(testResult.RightAtriumRADimensionsSeverelyDilated);
                    if (!string.IsNullOrEmpty(conclusionText))
                        conclusionTextBuilder.Append(conclusionText + "<br/>");

                    conclusionText = conclusionTextBuilder.ToString().Trim();

                    if (!string.IsNullOrEmpty(conclusionText))
                    {
                        selectedNode.SetAttributeValue("style", "display:block;");
                        conclusionNode.InnerHtml = conclusionText;
                        return true;
                    }
                }
            }
            return false;
        }

        private bool SetAwvEchoRightVentricleReadingData(HtmlDocument doc, AwvEchocardiogramTestResult testResult)
        {

            var selectedNode = doc.DocumentNode.SelectSingleNode("//div[@id='RightVentricleFindingSection']");
            if (testResult != null && selectedNode != null)
            {
                var conclusionNode = doc.DocumentNode.SelectSingleNode("//div[@id='RightVentricleFindingConclusion']");
                var conclusionTextBuilder = new StringBuilder();
                if (conclusionNode != null)
                {
                    var conclusionText = CreateConclusionText(testResult.RightVentricleOverallFunctionNotEvaluated);
                    if (!string.IsNullOrEmpty(conclusionText))
                        conclusionTextBuilder.Append(conclusionText + "<br/>");

                    conclusionText = CreateConclusionText(testResult.RightVentricleOverallFunctionNormal);
                    if (!string.IsNullOrEmpty(conclusionText))
                        conclusionTextBuilder.Append(conclusionText + "<br/>");

                    conclusionText = CreateConclusionText(testResult.RightVentricleOverallFunctionReduced);
                    if (!string.IsNullOrEmpty(conclusionText))
                        conclusionTextBuilder.Append(conclusionText + "<br/>");

                    conclusionText = CreateConclusionText(testResult.RightVentricleOverallFunctionBorderline);
                    if (!string.IsNullOrEmpty(conclusionText))
                        conclusionTextBuilder.Append(conclusionText + "<br/>");

                    conclusionText = CreateConclusionText(testResult.RightVentricleOverallFunctionHyperkinesis);
                    if (!string.IsNullOrEmpty(conclusionText))
                        conclusionTextBuilder.Append(conclusionText + "<br/>");

                    conclusionText = CreateConclusionText(testResult.RightVentricleOverallFunctionHypokinesis);
                    if (!string.IsNullOrEmpty(conclusionText))
                        conclusionTextBuilder.Append(conclusionText + "<br/>");

                    conclusionText = CreateConclusionText(testResult.RightVentricleDimensionsNotEvaluated);
                    if (!string.IsNullOrEmpty(conclusionText))
                        conclusionTextBuilder.Append(conclusionText + "<br/>");

                    conclusionText = CreateConclusionText(testResult.RightVentricleDimensionsNormal);
                    if (!string.IsNullOrEmpty(conclusionText))
                        conclusionTextBuilder.Append(conclusionText + "<br/>");

                    conclusionText = CreateConclusionText(testResult.RightVentricleDimensionsSmall);
                    if (!string.IsNullOrEmpty(conclusionText))
                        conclusionTextBuilder.Append(conclusionText + "<br/>");

                    conclusionText = CreateConclusionText(testResult.RightVentricleDimensionsDilated);
                    if (!string.IsNullOrEmpty(conclusionText))
                        conclusionTextBuilder.Append(conclusionText + "<br/>");

                    conclusionText = CreateConclusionText(testResult.RightVentricleDimensionsSlightlyEnlarged);
                    if (!string.IsNullOrEmpty(conclusionText))
                        conclusionTextBuilder.Append(conclusionText + "<br/>");

                    conclusionText = CreateConclusionText(testResult.RightVentricleDimensionsSeverelyDilated);
                    if (!string.IsNullOrEmpty(conclusionText))
                        conclusionTextBuilder.Append(conclusionText + "<br/>");

                    conclusionText = CreateConclusionText(testResult.RightVentricleThicknessesNotEvaluated);
                    if (!string.IsNullOrEmpty(conclusionText))
                        conclusionTextBuilder.Append(conclusionText + "<br/>");

                    conclusionText = CreateConclusionText(testResult.RightVentricleThicknessesNormal);
                    if (!string.IsNullOrEmpty(conclusionText))
                        conclusionTextBuilder.Append(conclusionText + "<br/>");

                    conclusionText = CreateConclusionText(testResult.RightVentricleThicknessesApicalHypertrophy);
                    if (!string.IsNullOrEmpty(conclusionText))
                        conclusionTextBuilder.Append(conclusionText + "<br/>");

                    conclusionText = CreateConclusionText(testResult.RightVentricleThicknessesAsymmetricalHypertrophy);
                    if (!string.IsNullOrEmpty(conclusionText))
                        conclusionTextBuilder.Append(conclusionText + "<br/>");

                    conclusionText = CreateConclusionText(testResult.RightVentricleThicknessesIVSeptumObstructiveHypertrophy);
                    if (!string.IsNullOrEmpty(conclusionText))
                        conclusionTextBuilder.Append(conclusionText + "<br/>");

                    conclusionText = CreateConclusionText(testResult.RightVentricleThicknessesMinorModerateIVSeptumHypertrophy);
                    if (!string.IsNullOrEmpty(conclusionText))
                        conclusionTextBuilder.Append(conclusionText + "<br/>");

                    conclusionText = CreateConclusionText(testResult.RightVentricleThicknessesSevereIVSeptumHypertrophy);
                    if (!string.IsNullOrEmpty(conclusionText))
                        conclusionTextBuilder.Append(conclusionText + "<br/>");

                    conclusionText = CreateConclusionText(testResult.RightVentricleThicknessesMinorModerateSymmetricHypertrophy);
                    if (!string.IsNullOrEmpty(conclusionText))
                        conclusionTextBuilder.Append(conclusionText + "<br/>");

                    conclusionText = CreateConclusionText(testResult.RightVentricleThicknessesSevereSymmetricHypertrophy);
                    if (!string.IsNullOrEmpty(conclusionText))
                        conclusionTextBuilder.Append(conclusionText + "<br/>");

                    conclusionText = conclusionTextBuilder.ToString().Trim();

                    if (!string.IsNullOrEmpty(conclusionText))
                    {
                        selectedNode.SetAttributeValue("style", "display:block;");
                        conclusionNode.InnerHtml = conclusionText;
                        return true;
                    }
                }
            }
            return false;
        }

        private bool SetAwvEchoLeftAtriumReadingData(HtmlDocument doc, AwvEchocardiogramTestResult testResult)
        {

            var selectedNode = doc.DocumentNode.SelectSingleNode("//div[@id='LeftAtriumIASFindingSection']");
            if (testResult != null && selectedNode != null)
            {
                var conclusionNode = doc.DocumentNode.SelectSingleNode("//div[@id='LeftAtriumIASFindingConclusion']");
                var conclusionTextBuilder = new StringBuilder();
                if (conclusionNode != null)
                {
                    var conclusionText = CreateConclusionText(testResult.LeftAtriumIASLADimensionsNotEvaluated);
                    if (!string.IsNullOrEmpty(conclusionText))
                        conclusionTextBuilder.Append(conclusionText + "<br/>");

                    conclusionText = CreateConclusionText(testResult.LeftAtriumIASLADimensionsNormal);
                    if (!string.IsNullOrEmpty(conclusionText))
                        conclusionTextBuilder.Append(conclusionText + "<br/>");

                    conclusionText = CreateConclusionText(testResult.LeftAtriumIASLADimensionsMildlyDilated);
                    if (!string.IsNullOrEmpty(conclusionText))
                        conclusionTextBuilder.Append(conclusionText + "<br/>");

                    conclusionText = CreateConclusionText(testResult.LeftAtriumIASLADimensionsModeratelyDilated);
                    if (!string.IsNullOrEmpty(conclusionText))
                        conclusionTextBuilder.Append(conclusionText + "<br/>");

                    conclusionText = CreateConclusionText(testResult.LeftAtriumIASLADimensionsSeverelyDilated);
                    if (!string.IsNullOrEmpty(conclusionText))
                        conclusionTextBuilder.Append(conclusionText + "<br/>");

                    conclusionText = conclusionTextBuilder.ToString().Trim();

                    if (!string.IsNullOrEmpty(conclusionText))
                    {
                        selectedNode.SetAttributeValue("style", "display:block;");
                        conclusionNode.InnerHtml = conclusionText;
                        return true;
                    }
                }
            }
            return false;
        }

        private bool SetAwvEchoLeftVentricleReadingData(HtmlDocument doc, AwvEchocardiogramTestResult testResult)
        {
            var selectedNode = doc.DocumentNode.SelectSingleNode("//div[@id='LeftVentricleFindingSection']");
            if (testResult != null && selectedNode != null)
            {
                var conclusionNode = doc.DocumentNode.SelectSingleNode("//div[@id='LeftVentricleFindingConclusion']");
                var conclusionTextBuilder = new StringBuilder();
                if (conclusionNode != null)
                {
                    var conclusionText = CreateConclusionText(testResult.LeftVentricleOverallFunctionNotEvaluated);
                    if (!string.IsNullOrEmpty(conclusionText))
                        conclusionTextBuilder.Append(conclusionText + "<br/>");

                    conclusionText = CreateConclusionText(testResult.LeftVentricleOverallFunctionNormal);
                    if (!string.IsNullOrEmpty(conclusionText))
                        conclusionTextBuilder.Append(conclusionText + "<br/>");

                    conclusionText = CreateConclusionText(testResult.LeftVentricleOverallFunctionReduced);
                    if (!string.IsNullOrEmpty(conclusionText))
                        conclusionTextBuilder.Append(conclusionText + "<br/>");

                    conclusionText = CreateConclusionText(testResult.LeftVentricleOverallFunctionBorderline);
                    if (!string.IsNullOrEmpty(conclusionText))
                        conclusionTextBuilder.Append(conclusionText + "<br/>");

                    conclusionText = CreateConclusionText(testResult.LeftVentricleOverallFunctionHyperkinesis);
                    if (!string.IsNullOrEmpty(conclusionText))
                        conclusionTextBuilder.Append(conclusionText + "<br/>");

                    conclusionText = CreateConclusionText(testResult.LeftVentricleOverallFunctionHypokinesis);
                    if (!string.IsNullOrEmpty(conclusionText))
                        conclusionTextBuilder.Append(conclusionText + "<br/>");

                    conclusionText = CreateConclusionText(testResult.LeftVentricleOverallFunctionConsistentLvSystolicFailure);
                    if (!string.IsNullOrEmpty(conclusionText))
                        conclusionTextBuilder.Append(conclusionText + "<br/>");

                    conclusionText = CreateConclusionText(testResult.LeftVentricleDimensionsNotEvaluated);
                    if (!string.IsNullOrEmpty(conclusionText))
                        conclusionTextBuilder.Append(conclusionText + "<br/>");

                    conclusionText = CreateConclusionText(testResult.LeftVentricleDimensionsNormal);
                    if (!string.IsNullOrEmpty(conclusionText))
                        conclusionTextBuilder.Append(conclusionText + "<br/>");

                    conclusionText = CreateConclusionText(testResult.LeftVentricleDimensionsSmall);
                    if (!string.IsNullOrEmpty(conclusionText))
                        conclusionTextBuilder.Append(conclusionText + "<br/>");

                    conclusionText = CreateConclusionText(testResult.LeftVentricleDimensionsDilated);
                    if (!string.IsNullOrEmpty(conclusionText))
                        conclusionTextBuilder.Append(conclusionText + "<br/>");

                    conclusionText = CreateConclusionText(testResult.LeftVentricleDimensionsSlightlyEnlarged);
                    if (!string.IsNullOrEmpty(conclusionText))
                        conclusionTextBuilder.Append(conclusionText + "<br/>");

                    conclusionText = CreateConclusionText(testResult.LeftVentricleDimensionsSeverelyDilated);
                    if (!string.IsNullOrEmpty(conclusionText))
                        conclusionTextBuilder.Append(conclusionText + "<br/>");

                    conclusionText = CreateConclusionText(testResult.LeftVentricleThicknessesNotEvaluated);
                    if (!string.IsNullOrEmpty(conclusionText))
                        conclusionTextBuilder.Append(conclusionText + "<br/>");

                    conclusionText = CreateConclusionText(testResult.LeftVentricleThicknessesNormal);
                    if (!string.IsNullOrEmpty(conclusionText))
                        conclusionTextBuilder.Append(conclusionText + "<br/>");

                    conclusionText = CreateConclusionText(testResult.LeftVentricleThicknessesApicalHypertrophy);
                    if (!string.IsNullOrEmpty(conclusionText))
                        conclusionTextBuilder.Append(conclusionText + "<br/>");

                    conclusionText = CreateConclusionText(testResult.LeftVentricleThicknessesAsymmetricalHypertrophy);
                    if (!string.IsNullOrEmpty(conclusionText))
                        conclusionTextBuilder.Append(conclusionText + "<br/>");

                    conclusionText = CreateConclusionText(testResult.LeftVentricleThicknessesIVSeptumObstructiveHypertrophy);
                    if (!string.IsNullOrEmpty(conclusionText))
                        conclusionTextBuilder.Append(conclusionText + "<br/>");

                    conclusionText = CreateConclusionText(testResult.LeftVentricleThicknessesMinorModerateIVSeptumHypertrophy);
                    if (!string.IsNullOrEmpty(conclusionText))
                        conclusionTextBuilder.Append(conclusionText + "<br/>");

                    conclusionText = CreateConclusionText(testResult.LeftVentricleThicknessesSevereIVSeptumHypertrophy);
                    if (!string.IsNullOrEmpty(conclusionText))
                        conclusionTextBuilder.Append(conclusionText + "<br/>");

                    conclusionText = CreateConclusionText(testResult.LeftVentricleThicknessesMinorModerateSymmetricHypertrophy);
                    if (!string.IsNullOrEmpty(conclusionText))
                        conclusionTextBuilder.Append(conclusionText + "<br/>");

                    conclusionText = CreateConclusionText(testResult.LeftVentricleThicknessesSevereSymmetricHypertrophy);
                    if (!string.IsNullOrEmpty(conclusionText))
                        conclusionTextBuilder.Append(conclusionText + "<br/>");

                    conclusionText = conclusionTextBuilder.ToString().Trim();

                    if (!string.IsNullOrEmpty(conclusionText))
                    {
                        selectedNode.SetAttributeValue("style", "display:block;");
                        conclusionNode.InnerHtml = conclusionText;
                        return true;
                    }

                }
            }
            return false;
        }

        private bool SetAwvEchoEjectionFractionReadingData(HtmlDocument doc, AwvEchocardiogramTestResult testResult)
        {
            var selectedNode = doc.DocumentNode.SelectSingleNode("//div[@id='EjectionFractionFindingSection']");
            if (testResult != null && selectedNode != null)
            {
                var conclusionNode = doc.DocumentNode.SelectSingleNode("//div[@id='EjectionFractionFindingConclusion']");
                var conclusionTextBuilder = new StringBuilder();
                if (conclusionNode != null)
                {
                    var conclusionText = string.Empty;
                    if (testResult.EstimatedEjactionFraction != null)
                    {
                        conclusionText = "Estimated Ejection Fraction : " + testResult.EstimatedEjactionFraction.Label; 
                        if (!string.IsNullOrEmpty(conclusionText))
                            conclusionTextBuilder.Append(conclusionText + "<br/>");
                    }

                    if (testResult.ConsistentLvDiastolicFailure != null)
                    {
                        var reading = _readings.Single(x => x.Label == testResult.ConsistentLvDiastolicFailure.Label);
                        conclusionText = reading.LableText;
                        if (!string.IsNullOrEmpty(conclusionText))
                            conclusionTextBuilder.Append(conclusionText + "<br/>");
                    }

                    if (testResult.ConsistentHypertensiveHeartDiseaseWithDiastolicHeartFailure != null)
                    {
                        var reading = _readings.Single(x => x.Label == testResult.ConsistentHypertensiveHeartDiseaseWithDiastolicHeartFailure.Label);
                        conclusionText = reading.LableText;
                        if (!string.IsNullOrEmpty(conclusionText))
                            conclusionTextBuilder.Append(conclusionText + "<br/>");
                    }

                    if (testResult.ConsistentHypertensiveHeartDiseaseWithoutDiastolicHeartFailure != null)
                    {
                        var reading = _readings.Single(x => x.Label == testResult.ConsistentHypertensiveHeartDiseaseWithoutDiastolicHeartFailure.Label);
                        conclusionText = reading.LableText;
                        if (!string.IsNullOrEmpty(conclusionText))
                            conclusionTextBuilder.Append(conclusionText + "<br/>");
                    }

                    if (testResult.AorticRoot != null)
                    {
                        var reading = _readings.Single(x => x.Label == testResult.AorticRoot.Label);
                        conclusionText = reading.LableText;
                        if (!string.IsNullOrEmpty(conclusionText))
                            conclusionTextBuilder.Append(conclusionText + "<br/>");

                        if (testResult.Sclerotic != null)
                        {
                            reading = _readings.Single(x => x.Label == testResult.Sclerotic.Label);
                            conclusionText = "&emsp; - " + reading.LableText;
                            if (!string.IsNullOrEmpty(conclusionText))
                                conclusionTextBuilder.Append(conclusionText + "<br/>");
                        }

                        if (testResult.Atherosclerosis != null)
                        {
                            reading = _readings.Single(x => x.Label == testResult.Atherosclerosis.Label);
                            conclusionText = "&emsp; - " + reading.LableText;
                            if (!string.IsNullOrEmpty(conclusionText))
                                conclusionTextBuilder.Append(conclusionText + "<br/>");
                        }
                    }

                    conclusionText = conclusionTextBuilder.ToString().Trim();

                    if (!string.IsNullOrEmpty(conclusionText))
                    {
                        selectedNode.SetAttributeValue("style", "display:block;");
                        conclusionNode.InnerHtml = conclusionText;
                        return true;
                    }

                }
            }
            return false;
        }

        private string CreateConclusionText(ResultReading<bool> resultReading)
        {
            var conclutionText = string.Empty;
            if (resultReading != null)
            {
                var reading = _readings.Single(x => x.Label == resultReading.Label);

                var lableText = reading.LableText.Split('-');

                if (lableText.Length == 3)
                {
                    conclutionText = string.Format(AwvEchocardiogramConclutionText, lableText[0], lableText[1], lableText[2]);
                }
                else if (lableText.Length > 3)
                {
                    var tempConclusion = string.Join("-", lableText.Skip(2).ToArray());
                    conclutionText = string.Format(AwvEchocardiogramConclutionText, lableText[0], lableText[1], tempConclusion);
                }
            }

            return conclutionText;
        }

        private string CreateConclusionTextFromStandardFinding(StandardFinding<int> standardFinding)
        {
            var conclutionText = string.Empty;
            if (standardFinding != null)
            {
                var lableText = standardFinding.Label;
                
                conclutionText = lableText;
            }

            return conclutionText;
        }

        public void LoadHcpEchoTestResults(HtmlDocument doc, HcpEchocardiogramTestResult testResult, bool removeLongDescription, bool loadImages, List<OrderedPair<long, string>> technicianIdNamePairs,
            IEnumerable<CustomerScreeningEvaluatinPhysicianViewModel> physicians, IEnumerable<EventPhysicianTest> eventPhysicianTests, IEnumerable<PhysicianEvaluation> eventCustomerPhysicianEvaluations, CustomerSkipReview customerSkipReview)
        {
            if (testResult != null)
            {
                var selectedNode = doc.DocumentNode.SelectSingleNode("//div[@id='HcpEcho-rpp-section']");
                if (selectedNode != null && (testResult.UnableScreenReason == null || testResult.UnableScreenReason.Count == 0) && (testResult.TestNotPerformed == null || testResult.TestNotPerformed.TestNotPerformedReasonId <= 0)
                    && (testResult.RepeatStudyUnreadable == null || testResult.RepeatStudyUnreadable.Reading == false))
                    selectedNode.SetAttributeValue("style", "display:block;");

                _resultPdfHelper.SetPhysicianSignature(doc, "HcpEcho-primaryEvalPhysicianSign", "HcpEcho-overreadEvalPhysicianSign", physicians, eventPhysicianTests, eventCustomerPhysicianEvaluations, customerSkipReview);

                LoadHcpEchoFinding(doc, testResult);

                _resultPdfHelper.SetCheckBox(doc, "HcpEchoValveAorticCheckbox", testResult.Aortic);
                _resultPdfHelper.SetCheckBox(doc, "HcpEchoValveMitralCheckbox", testResult.Mitral);
                _resultPdfHelper.SetCheckBox(doc, "HcpEchoValvePulmonicCheckbox", testResult.Pulmonic);
                _resultPdfHelper.SetCheckBox(doc, "HcpEchoValveTricuspidCheckbox", testResult.Tricuspid);

                _resultPdfHelper.SetInputBox(doc, "HcpEchoAorticVelocityTextbox", testResult.AoticVelocity);
                _resultPdfHelper.SetInputBox(doc, "HcpEchoPTTextbox", testResult.MitralPT);
                _resultPdfHelper.SetInputBox(doc, "HcpEchoVelocityPulmonicTextbox", testResult.PulmonicVelocity);
                _resultPdfHelper.SetInputBox(doc, "HcpEchoPapTextbox", testResult.TricuspidPap);
                _resultPdfHelper.SetInputBox(doc, "HcpEchoVelocityTricuspidTextbox", testResult.TricuspidVelocity);

                _resultPdfHelper.SetCheckBox(doc, "HcpEchoDiastolicDysfunctionCheckbox", testResult.DiastolicDysfunction);
                _resultPdfHelper.SetCheckBox(doc, "HcpEchoPericardialEffusionCheckbox", testResult.PericardialEffusion);
                _resultPdfHelper.SetCheckBox(doc, "HcpEchoVentricularEnlargmentCheckbox", testResult.VentricularEnlargement);
                _resultPdfHelper.SetCheckBox(doc, "HcpEchoAorticRootCheckbox", testResult.AorticRoot);
                _resultPdfHelper.SetCheckBox(doc, "HcpEchoVentricularHypertrophyCheckbox", testResult.VentricularHypertrophy);
                _resultPdfHelper.SetCheckBox(doc, "HcpEchoAtrialEnlargmentCheckbox", testResult.AtrialEnlargement);
                _resultPdfHelper.SetCheckBox(doc, "HcpEchoArrythmiaCheckbox", testResult.Arrythmia);

                _resultPdfHelper.SetCheckBox(doc, "HcpEchoAFibCheckbox", testResult.AFib);
                _resultPdfHelper.SetCheckBox(doc, "HcpEchoAFlutterCheckbox", testResult.AFlutter);
                _resultPdfHelper.SetCheckBox(doc, "HcpEchoPACCheckbox", testResult.PAC);
                _resultPdfHelper.SetCheckBox(doc, "HcpEchoPVCCheckbox", testResult.PVC);

                _resultPdfHelper.SetCheckBox(doc, "HcpEchoLeftVEnlargementCheckbox", testResult.LeftVentricularEnlargment);
                _resultPdfHelper.SetCheckBox(doc, "HcpEchoRightVEnlargementCheckbox", testResult.RightVentricularEnlargment);
                _resultPdfHelper.SetCheckBox(doc, "HcpEchoScleroticCheckbox", testResult.Sclerotic);
                _resultPdfHelper.SetCheckBox(doc, "HcpEchoCalcifiedCheckbox", testResult.Calcified);
                _resultPdfHelper.SetCheckBox(doc, "HcpEchoEnlargedCheckbox", testResult.Enlarged);
                _resultPdfHelper.SetCheckBox(doc, "HcpEchoLeftVHypertrophyCheckbox", testResult.LeftVHypertrophy);
                _resultPdfHelper.SetCheckBox(doc, "HcpEchoRightVHypertrophyCheckbox", testResult.RightVHypertrophy);
                _resultPdfHelper.SetCheckBox(doc, "HcpEchoIvshCheckbox", testResult.IvshHypertrophy);
                _resultPdfHelper.SetCheckBox(doc, "HcpEchoLeftAtrialEnlargementCheckbox", testResult.LeftAtrialEnlargment);
                _resultPdfHelper.SetCheckBox(doc, "HcpEchoRightAtrialEnlargementCheckbox", testResult.RightAtrialEnlargment);

                _resultPdfHelper.SetInputBox(doc, "HcpEchoLeftVEnlargementTextbox", testResult.LeftVentricularEnlargmentValue);
                _resultPdfHelper.SetInputBox(doc, "HcpEchoRightVEnlargementTextbox", testResult.RightVentricularEnlargmentValue);
                _resultPdfHelper.SetInputBox(doc, "HcpEchoEnlargedTextbox", testResult.EnlargedValue);
                _resultPdfHelper.SetInputBox(doc, "HcpEchoLeftVHypertrophyTextbox", testResult.LeftVHypertrophyValue);
                _resultPdfHelper.SetInputBox(doc, "HcpEchoRightVHypertrophyTextbox", testResult.RightVHypertrophyValue);
                _resultPdfHelper.SetInputBox(doc, "HcpEchoIvshTextbox", testResult.IvshHypertrophyValue);
                _resultPdfHelper.SetInputBox(doc, "HcpEchoLeftAtrialEnlargementTextbox", testResult.LeftAtrialEnlargmentValue);
                _resultPdfHelper.SetInputBox(doc, "HcpEchoRightAtrialEnlargementTextbox", testResult.RightAtrialEnlargmentValue);

                _resultPdfHelper.SetCheckBox(doc, "HcpEchoAsdCheckbox", testResult.ASD);
                _resultPdfHelper.SetCheckBox(doc, "HcpEchoPfoCheckbox", testResult.PFO);
                _resultPdfHelper.SetCheckBox(doc, "HcpEchoFlailCheckbox", testResult.FlailAS);
                _resultPdfHelper.SetCheckBox(doc, "HcpEchoVsdCheckbox", testResult.VSD);
                _resultPdfHelper.SetCheckBox(doc, "HcpEchoSamCheckbox", testResult.SAM);
                _resultPdfHelper.SetCheckBox(doc, "HcpEchoLvotoCheckbox", testResult.LVOTO);
                _resultPdfHelper.SetCheckBox(doc, "HcpEchoMitralAnnularCheckbox", testResult.MitralAnnularCa);

                _resultPdfHelper.SetCheckBox(doc, "HcpEchoRestrictedLeafletCheckbox", testResult.RestrictedLeafletMotion);
                _resultPdfHelper.SetCheckBox(doc, "HcpEchoRestrictedLeafletAorticCheckbox", testResult.RestrictedLeafletMotionAortic);
                _resultPdfHelper.SetCheckBox(doc, "HcpEchoRestrictedLeafletMitralCheckbox", testResult.RestrictedLeafletMotionMitral);
                _resultPdfHelper.SetCheckBox(doc, "HcpEchoRestrictedLeafletPulCheckbox", testResult.RestrictedLeafletMotionPulmonic);
                _resultPdfHelper.SetCheckBox(doc, "HcpEchoRestrictedLeafletTriCheckbox", testResult.RestrictedLeafletMotionTricuspid);

                _resultPdfHelper.SetCheckBox(doc, "HcpEchoHypokineticCheckbox", testResult.Hypokinetic);
                _resultPdfHelper.SetCheckBox(doc, "HcpEchoAkineticCheckbox", testResult.Akinetic);
                _resultPdfHelper.SetCheckBox(doc, "HcpEchoDyskineticCheckbox", testResult.Dyskinetic);

                _resultPdfHelper.SetCheckBox(doc, "HcpEchoAnteriorCheckbox", testResult.Anterior);
                _resultPdfHelper.SetCheckBox(doc, "HcpEchoPosteriorCheckbox", testResult.Posterior);
                _resultPdfHelper.SetCheckBox(doc, "HcpEchoApicalCheckbox", testResult.Apical);

                _resultPdfHelper.SetCheckBox(doc, "HcpEchoSeptalCheckbox", testResult.Septal);
                _resultPdfHelper.SetCheckBox(doc, "HcpEchoLateralCheckbox", testResult.Lateral);
                _resultPdfHelper.SetCheckBox(doc, "HcpEchoInferiorCheckbox", testResult.Inferior);

                _resultPdfHelper.SetCheckBox(doc, "TechnicalLimitedbutReadableHcpEchoCheckbox", testResult.TechnicallyLimitedbutReadable);
                _resultPdfHelper.SetCheckBox(doc, "RepeatStudyuneadableHcpEchoCheckbox", testResult.RepeatStudyUnreadable);

                _resultPdfHelper.SetCheckBox(doc, "HcpEchoMorphologyTricuspidHigh35MmHgOrGreaterCheckbox", testResult.MorphologyTricuspidHighOrGreater);
                _resultPdfHelper.SetCheckBox(doc, "HcpEchoMorphologyTricuspidNormalCheckbox", testResult.MorphologyTricuspidNormal);

                _resultPdfHelper.LoadTestMedia(doc, testResult.Media, "testmedia-HcpEcho", loadImages);
                _resultPdfHelper.SetPhysicianRemarks(doc, testResult, "followUpHcpEcho", "criticalHcpEcho", "physicianRemarksHcpEcho");
                _resultPdfHelper.SetTechnician(doc, testResult, "techHcpEcho", "technotesHcpEcho", technicianIdNamePairs);
                _resultPdfHelper.SetUnableToScreenReasons(doc, TestType.HCPEcho, "HcpEchoUnableToScreen", testResult.UnableScreenReason);

                selectedNode = doc.DocumentNode.SelectSingleNode("//div[@id='HcpEcho-longdescription-div']");
                if (selectedNode != null)
                    selectedNode.SetAttributeValue("style", removeLongDescription ? "display:none" : "display:block");
            }
            else
            {
                _resultPdfHelper.SetUnableToScreenReasons(doc, TestType.HCPEcho, "HcpEchoUnableToScreen", null);
                LoadHcpEchoFinding(doc, null);
            }
        }

        private void LoadHcpEchoFinding(HtmlDocument doc, HcpEchocardiogramTestResult testResult)
        {
            var stdFindings = _standardFindingRepository.GetAllStandardFindings<int>((Int32)TestType.HCPEcho);
            var estEjaFindings = _standardFindingRepository.GetAllStandardFindings<int>((Int32)TestType.HCPEcho, (Int32)ReadingLabels.EstimatedEjactionFraction);
            var aorticFindings = _standardFindingRepository.GetAllStandardFindings<int>((Int32)TestType.HCPEcho, (Int32)ReadingLabels.Aortic);
            var mitrlaFindings = _standardFindingRepository.GetAllStandardFindings<int>((Int32)TestType.HCPEcho, (Int32)ReadingLabels.Mitral);
            var pulmonicFindings = _standardFindingRepository.GetAllStandardFindings<int>((Int32)TestType.HCPEcho, (Int32)ReadingLabels.Pulmonic);
            var tricuspidFindings = _standardFindingRepository.GetAllStandardFindings<int>((Int32)TestType.HCPEcho, (Int32)ReadingLabels.Tricuspid);
            var aorticMorphologyFindings = _standardFindingRepository.GetAllStandardFindings<int>((Int32)TestType.HCPEcho, (Int32)ReadingLabels.AorticMorphology);
            var mitralMorphFindings = _standardFindingRepository.GetAllStandardFindings<int>((Int32)TestType.HCPEcho, (Int32)ReadingLabels.MitralMorphology);
            var pulmonicMorphFindings = _standardFindingRepository.GetAllStandardFindings<int>((Int32)TestType.HCPEcho, (Int32)ReadingLabels.PulmonicMorphology);
            var tricuspidMorphFindings = _standardFindingRepository.GetAllStandardFindings<int>((Int32)TestType.HCPEcho, (Int32)ReadingLabels.TricuspidMorphology);
            var periEfuFindings = _standardFindingRepository.GetAllStandardFindings<int>((Int32)TestType.HCPEcho, (Int32)ReadingLabels.PericardialEffusion);
            var diastolicFindings = _standardFindingRepository.GetAllStandardFindings<int>((Int32)TestType.HCPEcho, (Int32)ReadingLabels.DiastolicDysfunction);

            UnableScreenReason unableScreenReason = null;
            //TODO: This is a hack for Echo Summary
            if (testResult != null && testResult.UnableScreenReason != null && testResult.UnableScreenReason.Count > 0 && testResult.UnableScreenReason.Count(us => us.Reason == UnableToScreenReason.TechnicallyLimitedButReadable) < 1)
                unableScreenReason = testResult.UnableScreenReason.First();

            var selectedNode = doc.DocumentNode.SelectSingleNode("//span[@id='HcpEcho-rpp-resultspan']");
            if (testResult != null && testResult.Finding != null && selectedNode != null)
            {
                var stdFinding = stdFindings.Single(f => f.Id == testResult.Finding.Id);
                selectedNode.InnerHtml = stdFinding.Label;
            }

            _resultPdfHelper.SetSummaryFindings(doc, (testResult != null ? testResult.Finding : null), stdFindings, "FindingsHcpEchoDiv", "longdescription-HcpEcho", null, testResult != null, unableScreenReason);
            _resultPdfHelper.SetFindingsHorizontal(doc, testResult != null ? testResult.Finding : null, stdFindings, "HcpEchoFindings");
            _resultPdfHelper.SetFindingsVertical(doc, testResult != null ? testResult.EstimatedEjactionFraction : null, estEjaFindings, "HcpEchoestimatedEjacFinding");

            _resultPdfHelper.SetFindingsHorizontal(doc, testResult != null ? testResult.AorticRegurgitation : null, aorticFindings, "HcpEchoaorticRegurgitationFinding");
            _resultPdfHelper.SetFindingsHorizontal(doc, testResult != null ? testResult.MitralRegurgitation : null, mitrlaFindings, "HcpEchomitralRegurgitationFinding");
            _resultPdfHelper.SetFindingsHorizontal(doc, testResult != null ? testResult.PulmonicRegurgitation : null, pulmonicFindings, "HcpEchopulmonicRegurgitationFinding");
            _resultPdfHelper.SetFindingsHorizontal(doc, testResult != null ? testResult.TricuspidRegurgitation : null, tricuspidFindings, "HcpEchotricuspidRegurgitationFinding");

            _resultPdfHelper.SetFindingsHorizontal(doc, testResult != null ? testResult.AorticMorphology : null, aorticMorphologyFindings, "HcpEchoaorticMorphologyFinding");
            _resultPdfHelper.SetFindingsHorizontal(doc, testResult != null ? testResult.MitralMorphology : null, mitralMorphFindings, "HcpEchomitralMorphologyFinding");
            _resultPdfHelper.SetFindingsHorizontal(doc, testResult != null ? testResult.PulmonicMorphology : null, pulmonicMorphFindings, "HcpEchopulmonicMorphologyFinding");
            _resultPdfHelper.SetFindingsHorizontal(doc, testResult != null ? testResult.TricuspidMorphology : null, tricuspidMorphFindings, "HcpEchotricuspidMorphologyFinding");

            _resultPdfHelper.SetFindingsHorizontal(doc, testResult != null ? testResult.DistolicDysfunctionFinding : null, diastolicFindings, "HcpEchodistolicDysfunctionFinding");
            _resultPdfHelper.SetFindingsHorizontal(doc, testResult != null ? testResult.PericardialEffusionFinding : null, periEfuFindings, "HcpEchopericardialEffFinding");
        }

    }
}
