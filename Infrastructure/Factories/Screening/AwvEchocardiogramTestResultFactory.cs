using System;
using System.Collections.Generic;
using System.Linq;
using Falcon.App.Core;
using Falcon.App.Core.Application.Domain;
using Falcon.App.Core.Medical.Domain;
using Falcon.App.Core.Medical.Enum;
using Falcon.App.Infrastructure.Service;
using Falcon.Data.EntityClasses;

namespace Falcon.App.Infrastructure.Factories.Screening
{
    public class AwvEchocardiogramTestResultFactory : TestResultFactory
    {
        public override TestResult CreateActualTestResult(CustomerEventScreeningTestsEntity customerEventScreeningTestEntity)
        {
            var customerEventReadingEntities = customerEventScreeningTestEntity.CustomerEventReading.ToList();
            var testResult = new AwvEchocardiogramTestResult(customerEventScreeningTestEntity.CustomerEventScreeningTestId);

            var customerEventTestStandardFindingEntities = customerEventScreeningTestEntity.CustomerEventTestStandardFinding.ToList();
            var standardFindingTestReadingEntities = customerEventScreeningTestEntity.StandardFindingTestReadingCollectionViaCustomerEventTestStandardFinding.ToList();

            {
                var testResultService = new TestResultService();
                var standardFindings = testResultService.GetAllStandardFindings<int?>((int)TestType.AwvEcho);
                var estimatedEjactionFindings = testResultService.GetAllStandardFindings<int?>((int)TestType.AwvEcho, (int)ReadingLabels.EstimatedEjactionFraction);
                var aorticRegurgitationFindings = testResultService.GetAllStandardFindings<int?>((int)TestType.AwvEcho, (int)ReadingLabels.Aortic);
                var mitralRegurgitationFindings = testResultService.GetAllStandardFindings<int?>((int)TestType.AwvEcho, (int)ReadingLabels.Mitral);
                var pulmonicRegurgitationFindings = testResultService.GetAllStandardFindings<int?>((int)TestType.AwvEcho, (int)ReadingLabels.Pulmonic);
                var tricuspidRegurgitationFindings = testResultService.GetAllStandardFindings<int?>((int)TestType.AwvEcho, (int)ReadingLabels.Tricuspid);
                var aorticMorphologyFindings = testResultService.GetAllStandardFindings<int?>((int)TestType.AwvEcho, (int)ReadingLabels.AorticMorphology);
                var mitralMorphologyFindings = testResultService.GetAllStandardFindings<int?>((int)TestType.AwvEcho, (int)ReadingLabels.MitralMorphology);
                var pulmonicMorphologyFindings = testResultService.GetAllStandardFindings<int?>((int)TestType.AwvEcho, (int)ReadingLabels.PulmonicMorphology);
                var tricuspidMorphologyFindings = testResultService.GetAllStandardFindings<int?>((int)TestType.AwvEcho, (int)ReadingLabels.TricuspidMorphology);
                var distolicDysfunctionFindings = testResultService.GetAllStandardFindings<int?>((int)TestType.AwvEcho, (int)ReadingLabels.DiastolicDysfunction);
                var pericardialEffusionFindings = testResultService.GetAllStandardFindings<int?>((int)TestType.AwvEcho, (int)ReadingLabels.PericardialEffusion);

                customerEventTestStandardFindingEntities.ForEach(customerEventTestStandardFindingEntity =>
                {
                    var standardFindingTestReadingEntity = standardFindingTestReadingEntities.Find(entity => entity.StandardFindingTestReadingId == customerEventTestStandardFindingEntity.StandardFindingTestReadingId);
                    if (standardFindingTestReadingEntity == null) return;

                    var finding = CreateFindingObject(customerEventTestStandardFindingEntity, standardFindings, standardFindingTestReadingEntity, null);
                    if (finding != null)
                    {
                        testResult.Finding = finding; return;
                    }

                    finding = CreateFindingObject(customerEventTestStandardFindingEntity, estimatedEjactionFindings, standardFindingTestReadingEntity, (int?)ReadingLabels.EstimatedEjactionFraction);
                    if (finding != null)
                    {
                        testResult.EstimatedEjactionFraction = finding; return;
                    }

                    finding = CreateFindingObject(customerEventTestStandardFindingEntity, aorticRegurgitationFindings, standardFindingTestReadingEntity, (int?)ReadingLabels.Aortic);
                    if (finding != null)
                    {
                        testResult.AorticRegurgitation = finding; return;
                    }

                    finding = CreateFindingObject(customerEventTestStandardFindingEntity, mitralRegurgitationFindings, standardFindingTestReadingEntity, (int?)ReadingLabels.Mitral);
                    if (finding != null)
                    {
                        testResult.MitralRegurgitation = finding; return;
                    }

                    finding = CreateFindingObject(customerEventTestStandardFindingEntity, pulmonicRegurgitationFindings, standardFindingTestReadingEntity, (int?)ReadingLabels.Pulmonic);
                    if (finding != null)
                    {
                        testResult.PulmonicRegurgitation = finding; return;
                    }

                    finding = CreateFindingObject(customerEventTestStandardFindingEntity, tricuspidRegurgitationFindings, standardFindingTestReadingEntity, (int?)ReadingLabels.Tricuspid);
                    if (finding != null)
                    {
                        testResult.TricuspidRegurgitation = finding; return;
                    }


                    finding = CreateFindingObject(customerEventTestStandardFindingEntity, aorticMorphologyFindings, standardFindingTestReadingEntity, (int?)ReadingLabels.AorticMorphology);
                    if (finding != null)
                    {
                        if (testResult.AorticMorphology == null) testResult.AorticMorphology = new List<StandardFinding<int>>();
                        testResult.AorticMorphology.Add(finding); return;
                    }

                    finding = CreateFindingObject(customerEventTestStandardFindingEntity, mitralMorphologyFindings, standardFindingTestReadingEntity, (int?)ReadingLabels.MitralMorphology);
                    if (finding != null)
                    {
                        if (testResult.MitralMorphology == null) testResult.MitralMorphology = new List<StandardFinding<int>>();
                        testResult.MitralMorphology.Add(finding); return;
                    }

                    finding = CreateFindingObject(customerEventTestStandardFindingEntity, pulmonicMorphologyFindings, standardFindingTestReadingEntity, (int?)ReadingLabels.PulmonicMorphology);
                    if (finding != null)
                    {
                        if (testResult.PulmonicMorphology == null) testResult.PulmonicMorphology = new List<StandardFinding<int>>();
                        testResult.PulmonicMorphology.Add(finding); return;
                    }

                    finding = CreateFindingObject(customerEventTestStandardFindingEntity, tricuspidMorphologyFindings, standardFindingTestReadingEntity, (int?)ReadingLabels.TricuspidMorphology);
                    if (finding != null)
                    {
                        if (testResult.TricuspidMorphology == null) testResult.TricuspidMorphology = new List<StandardFinding<int>>();
                        testResult.TricuspidMorphology.Add(finding); return;
                    }

                    finding = CreateFindingObject(customerEventTestStandardFindingEntity, distolicDysfunctionFindings, standardFindingTestReadingEntity, (int?)ReadingLabels.DiastolicDysfunction);
                    if (finding != null)
                    {
                        testResult.DistolicDysfunctionFinding = finding; return;
                    }

                    finding = CreateFindingObject(customerEventTestStandardFindingEntity, pericardialEffusionFindings, standardFindingTestReadingEntity, (int?)ReadingLabels.PericardialEffusion);
                    if (finding != null)
                    {
                        if (testResult.PericardialEffusionFinding == null) testResult.PericardialEffusionFinding = new List<StandardFinding<int>>();
                        testResult.PericardialEffusionFinding.Add(finding); return;
                    }
                });
            }

            testResult.DiastolicDysfunction = CreateResultReading((int)ReadingLabels.DiastolicDysfunction, customerEventReadingEntities);
            testResult.PericardialEffusion = CreateResultReading((int)ReadingLabels.PericardialEffusion, customerEventReadingEntities);

            testResult.Aortic = CreateResultReading((int)ReadingLabels.Aortic, customerEventReadingEntities);
            testResult.Mitral = CreateResultReading((int)ReadingLabels.Mitral, customerEventReadingEntities);
            testResult.Pulmonic = CreateResultReading((int)ReadingLabels.Pulmonic, customerEventReadingEntities);
            testResult.Tricuspid = CreateResultReading((int)ReadingLabels.Tricuspid, customerEventReadingEntities);

            testResult.VentricularEnlargement = CreateResultReading((int)ReadingLabels.VentricularEnlargement, customerEventReadingEntities);
            testResult.LeftVentricularEnlargment = CreateResultReading((int)ReadingLabels.LeftVentricularEnlargment, customerEventReadingEntities);
            testResult.RightVentricularEnlargment = CreateResultReading((int)ReadingLabels.RightVentricularEnlargment, customerEventReadingEntities);
            testResult.LeftVentricularEnlargmentValue = CreateResultReadingforInputValues((int)ReadingLabels.LeftVentricularEnlargmentValue, customerEventReadingEntities);
            testResult.RightVentricularEnlargmentValue = CreateResultReadingforInputValues((int)ReadingLabels.RightVentricularEnlargmentValue, customerEventReadingEntities);

            testResult.AorticRoot = CreateResultReading((int)ReadingLabels.AorticRoot, customerEventReadingEntities);
            testResult.Sclerotic = CreateResultReading((int)ReadingLabels.Sclerotic, customerEventReadingEntities);
            testResult.Calcified = CreateResultReading((int)ReadingLabels.Calcified, customerEventReadingEntities);
            testResult.EnlargedValue = CreateResultReadingforInputValues((int)ReadingLabels.EnlargedValue, customerEventReadingEntities);
            testResult.Enlarged = CreateResultReading((int)ReadingLabels.Enlarged, customerEventReadingEntities);

            testResult.AscendingAortaArch = CreateResultReading((int)ReadingLabels.AscendingAortaArch, customerEventReadingEntities);
            testResult.Atherosclerosis = CreateResultReading((int)ReadingLabels.Atherosclerosis, customerEventReadingEntities);

            testResult.VentricularHypertrophy = CreateResultReading((int)ReadingLabels.VentricularHypertrophy, customerEventReadingEntities);

            testResult.LeftVHypertrophy = CreateResultReading((int)ReadingLabels.LeftVHypertrophy, customerEventReadingEntities);
            testResult.RightVHypertrophy = CreateResultReading((int)ReadingLabels.RightVHypertrophy, customerEventReadingEntities);
            testResult.IvshHypertrophy = CreateResultReading((int)ReadingLabels.IVSHHypertrophy, customerEventReadingEntities);
            testResult.LeftVHypertrophyValue = CreateResultReadingforInputValues((int)ReadingLabels.LeftVHypertrophyValue, customerEventReadingEntities);
            testResult.RightVHypertrophyValue = CreateResultReadingforInputValues((int)ReadingLabels.RightVHypertrophyValue, customerEventReadingEntities);
            testResult.IvshHypertrophyValue = CreateResultReadingforInputValues((int)ReadingLabels.IVSHHypertrophyValue, customerEventReadingEntities);

            testResult.AtrialEnlargement = CreateResultReading((int)ReadingLabels.AtrialEnlargement, customerEventReadingEntities);
            testResult.LeftAtrialEnlargmentValue = CreateResultReadingforInputValues((int)ReadingLabels.LeftAtrialEnlargmentValue, customerEventReadingEntities);
            testResult.RightAtrialEnlargmentValue = CreateResultReadingforInputValues((int)ReadingLabels.RightAtrialEnlargmentValue, customerEventReadingEntities);
            testResult.LeftAtrialEnlargment = CreateResultReading((int)ReadingLabels.LeftAtrialEnlargment, customerEventReadingEntities);
            testResult.RightAtrialEnlargment = CreateResultReading((int)ReadingLabels.RightAtrialEnlargment, customerEventReadingEntities);

            testResult.RestrictedLeafletMotion = CreateResultReading((int)ReadingLabels.RestrictedLeafletMotion, customerEventReadingEntities);
            testResult.RestrictedLeafletMotionAortic = CreateResultReading((int)ReadingLabels.RestrictedLeafletMotionAortic, customerEventReadingEntities);
            testResult.RestrictedLeafletMotionMitral = CreateResultReading((int)ReadingLabels.RestrictedLeafletMotionMitral, customerEventReadingEntities);
            testResult.RestrictedLeafletMotionPulmonic = CreateResultReading((int)ReadingLabels.RestrictedLeafletMotionPulmonic, customerEventReadingEntities);
            testResult.RestrictedLeafletMotionTricuspid = CreateResultReading((int)ReadingLabels.RestrictedLeafletMotionTricuspid, customerEventReadingEntities);

            testResult.ASD = CreateResultReading((int)ReadingLabels.ASD, customerEventReadingEntities);
            testResult.PFO = CreateResultReading((int)ReadingLabels.PFO, customerEventReadingEntities);
            testResult.VSD = CreateResultReading((int)ReadingLabels.VSD, customerEventReadingEntities);
            testResult.FlailAS = CreateResultReading((int)ReadingLabels.FlailAS, customerEventReadingEntities);
            testResult.Arrythmia = CreateResultReading((int)ReadingLabels.Arrythmia, customerEventReadingEntities);

            testResult.AFib = CreateResultReading((int)ReadingLabels.AFib, customerEventReadingEntities);
            testResult.AFlutter = CreateResultReading((int)ReadingLabels.AFlutter, customerEventReadingEntities);
            testResult.PAC = CreateResultReading((int)ReadingLabels.PAC, customerEventReadingEntities);
            testResult.PVC = CreateResultReading((int)ReadingLabels.PVC, customerEventReadingEntities);

            testResult.MitralAnnularCa = CreateResultReading((int)ReadingLabels.MitralAnnularCa, customerEventReadingEntities);
            testResult.TechnicallyLimitedbutReadable = CreateResultReading((int)ReadingLabels.TechnicallyLimitedbutReadable, customerEventReadingEntities);
            testResult.RepeatStudyUnreadable = CreateResultReading((int)ReadingLabels.RepeatStudy, customerEventReadingEntities);

            testResult.Hypokinetic = CreateResultReading((int)ReadingLabels.Hypokinetic, customerEventReadingEntities);
            testResult.Akinetic = CreateResultReading((int)ReadingLabels.Akinetic, customerEventReadingEntities);
            testResult.Dyskinetic = CreateResultReading((int)ReadingLabels.Dyskinetic, customerEventReadingEntities);
            testResult.Anterior = CreateResultReading((int)ReadingLabels.Anterior, customerEventReadingEntities);
            testResult.Posterior = CreateResultReading((int)ReadingLabels.Posterior, customerEventReadingEntities);
            testResult.Apical = CreateResultReading((int)ReadingLabels.Apical, customerEventReadingEntities);
            testResult.Septal = CreateResultReading((int)ReadingLabels.Septal, customerEventReadingEntities);
            testResult.Lateral = CreateResultReading((int)ReadingLabels.Lateral, customerEventReadingEntities);
            testResult.Inferior = CreateResultReading((int)ReadingLabels.Inferior, customerEventReadingEntities);
            testResult.AoticVelocity = CreateResultReadingforInputValues((int)ReadingLabels.AoticVelocity, customerEventReadingEntities);
            testResult.PeakGradient = CreateResultReadingforInputValues((int)ReadingLabels.PeakGradient, customerEventReadingEntities);
            testResult.MitralPT = CreateResultReadingforInputValues((int)ReadingLabels.MitralPT, customerEventReadingEntities);
            testResult.PulmonicVelocity = CreateResultReadingforInputValues((int)ReadingLabels.PulmonicVelocity, customerEventReadingEntities);
            testResult.TricuspidVelocity = CreateResultReadingforInputValues((int)ReadingLabels.TricuspidVelocity, customerEventReadingEntities);
            testResult.TricuspidPap = CreateResultReadingforInputValues((int)ReadingLabels.TricuspidPap, customerEventReadingEntities);

            testResult.AorticEstimatedValveArea = CreateResultReadingforInputValues((int)ReadingLabels.AorticEstimatedValveArea, customerEventReadingEntities);
            testResult.MitralEstimatedValveArea = CreateResultReadingforInputValues((int)ReadingLabels.MitralEstimatedValveArea, customerEventReadingEntities);
            testResult.PulmonicEstimatedValveArea = CreateResultReadingforInputValues((int)ReadingLabels.PulmonicEstimatedValveArea, customerEventReadingEntities);
            testResult.TricuspidEstimatedValveArea = CreateResultReadingforInputValues((int)ReadingLabels.TricuspidEstimatedValveArea, customerEventReadingEntities);

            testResult.AorticEstimatedRightValve = CreateResultReadingforInputValues((int)ReadingLabels.AorticEstimatedRightValve, customerEventReadingEntities);
            testResult.MitralEstimatedRightValve = CreateResultReadingforInputValues((int)ReadingLabels.MitralEstimatedRightValve, customerEventReadingEntities);
            testResult.DiastolicDysfunctionEeRatio = CreateResultReadingforInputValues((int)ReadingLabels.DiastolicDysfunctionEeRatio, customerEventReadingEntities);

            testResult.MorphologyTricuspidHighOrGreater = CreateResultReading((int)ReadingLabels.High35MmHgOrGreater, customerEventReadingEntities);
            testResult.MorphologyTricuspidNormal = CreateResultReading((int)ReadingLabels.Normal, customerEventReadingEntities);

            testResult.ConsistentLvDiastolicFailure = CreateResultReading((int)ReadingLabels.ConsistentLvDiastolicFailure, customerEventReadingEntities);
            testResult.ConsistentHypertensiveHeartDiseaseWithDiastolicHeartFailure = CreateResultReading((int)ReadingLabels.ConsistentHypertensiveHeartDiseaseWithDiastolicHeartFailure, customerEventReadingEntities);
            testResult.ConsistentHypertensiveHeartDiseaseWithoutDiastolicHeartFailure = CreateResultReading((int)ReadingLabels.ConsistentHypertensiveHeartDiseaseWithoutDiastolicHeartFailure, customerEventReadingEntities);

            GetLeftVentricleReadingData(testResult, customerEventReadingEntities);
            GetLeftAtriumReadingData(testResult, customerEventReadingEntities);
            GetRightVentricleReadingData(testResult, customerEventReadingEntities);
            GetRightAtriumReadingData(testResult, customerEventReadingEntities);
            GetAortaReadingData(testResult, customerEventReadingEntities);
            GetMitralReadingData(testResult, customerEventReadingEntities);
            GetPulmonaryReadingData(testResult, customerEventReadingEntities);
            GetTricuspidReadingData(testResult, customerEventReadingEntities);

            testResult.Conclusion = CreateResultReadingforInputValues((int)ReadingLabels.Conclusion, customerEventReadingEntities);

            var testMediaCollection = customerEventScreeningTestEntity.TestMedia.ToList();
            var fileEntityCollection = customerEventScreeningTestEntity.FileCollectionViaTestMedia.ToList();

            if (testMediaCollection.Count > 0)
            {
                var resultMedia = new List<ResultMedia>();
                testMediaCollection.ForEach(testMedia => resultMedia.Add(new ResultMedia(testMedia.MediaId)
                {
                    File = GetFileObjectfromEntity(testMedia.FileId, fileEntityCollection),
                    Thumbnail = testMedia.ThumbnailFileId != null ? new File(testMedia.ThumbnailFileId.Value) : null,
                    ReadingSource = testMedia.IsManual ? ReadingSource.Manual : ReadingSource.Automatic
                }));

                testResult.Media = resultMedia;
            }
            return testResult;
        }

        private void GetLeftVentricleReadingData(AwvEchocardiogramTestResult testResult, List<CustomerEventReadingEntity> customerEventReadingEntities)
        {
            testResult.LeftVentricleOverallFunctionNotEvaluated = CreateResultReading((int)ReadingLabels.LeftVentricleOverallFunctionNotEvaluated, customerEventReadingEntities);
            testResult.LeftVentricleOverallFunctionNormal = CreateResultReading((int)ReadingLabels.LeftVentricleOverallFunctionNormal, customerEventReadingEntities);
            testResult.LeftVentricleOverallFunctionReduced = CreateResultReading((int)ReadingLabels.LeftVentricleOverallFunctionReduced, customerEventReadingEntities);
            testResult.LeftVentricleOverallFunctionBorderline = CreateResultReading((int)ReadingLabels.LeftVentricleOverallFunctionBorderline, customerEventReadingEntities);
            testResult.LeftVentricleOverallFunctionHyperkinesis = CreateResultReading((int)ReadingLabels.LeftVentricleOverallFunctionHyperkinesis, customerEventReadingEntities);
            testResult.LeftVentricleOverallFunctionHypokinesis = CreateResultReading((int)ReadingLabels.LeftVentricleOverallFunctionHypokinesis, customerEventReadingEntities);
            testResult.LeftVentricleOverallFunctionConsistentLvSystolicFailure = CreateResultReading((int)ReadingLabels.LeftVentricleOverallFunctionConsistentLvSystolicFailure, customerEventReadingEntities);

            testResult.LeftVentricleDimensionsNotEvaluated = CreateResultReading((int)ReadingLabels.LeftVentricleDimensionsNotEvaluated, customerEventReadingEntities);
            testResult.LeftVentricleDimensionsNormal = CreateResultReading((int)ReadingLabels.LeftVentricleDimensionsNormal, customerEventReadingEntities);
            testResult.LeftVentricleDimensionsSmall = CreateResultReading((int)ReadingLabels.LeftVentricleDimensionsSmall, customerEventReadingEntities);
            testResult.LeftVentricleDimensionsDilated = CreateResultReading((int)ReadingLabels.LeftVentricleDimensionsDilated, customerEventReadingEntities);
            testResult.LeftVentricleDimensionsSlightlyEnlarged = CreateResultReading((int)ReadingLabels.LeftVentricleDimensionsSlightlyEnlarged, customerEventReadingEntities);
            testResult.LeftVentricleDimensionsSeverelyDilated = CreateResultReading((int)ReadingLabels.LeftVentricleDimensionsSeverelyDilated, customerEventReadingEntities);

            testResult.LeftVentricleThicknessesNotEvaluated = CreateResultReading((int)ReadingLabels.LeftVentricleThicknessesNotEvaluated, customerEventReadingEntities);
            testResult.LeftVentricleThicknessesNormal = CreateResultReading((int)ReadingLabels.LeftVentricleThicknessesNormal, customerEventReadingEntities);
            testResult.LeftVentricleThicknessesApicalHypertrophy = CreateResultReading((int)ReadingLabels.LeftVentricleThicknessesApicalHypertrophy, customerEventReadingEntities);
            testResult.LeftVentricleThicknessesAsymmetricalHypertrophy = CreateResultReading((int)ReadingLabels.LeftVentricleThicknessesAsymmetricalHypertrophy, customerEventReadingEntities);
            testResult.LeftVentricleThicknessesIVSeptumObstructiveHypertrophy = CreateResultReading((int)ReadingLabels.LeftVentricleThicknessesIVSeptumObstructiveHypertrophy, customerEventReadingEntities);
            testResult.LeftVentricleThicknessesMinorModerateIVSeptumHypertrophy = CreateResultReading((int)ReadingLabels.LeftVentricleThicknessesMinorModerateIVSeptumHypertrophy, customerEventReadingEntities);
            testResult.LeftVentricleThicknessesSevereIVSeptumHypertrophy = CreateResultReading((int)ReadingLabels.LeftVentricleThicknessesSevereIVSeptumHypertrophy, customerEventReadingEntities);
            testResult.LeftVentricleThicknessesMinorModerateSymmetricHypertrophy = CreateResultReading((int)ReadingLabels.LeftVentricleThicknessesMinorModerateSymmetricHypertrophy, customerEventReadingEntities);
            testResult.LeftVentricleThicknessesSevereSymmetricHypertrophy = CreateResultReading((int)ReadingLabels.LeftVentricleThicknessesSevereSymmetricHypertrophy, customerEventReadingEntities);
            testResult.LeftVentricleComment = CreateResultReadingforInputValues((int)ReadingLabels.LeftVentricleComment, customerEventReadingEntities);
        }

        private void GetLeftAtriumReadingData(AwvEchocardiogramTestResult testResult, List<CustomerEventReadingEntity> customerEventReadingEntities)
        {
            testResult.LeftAtriumIASLADimensionsNotEvaluated = CreateResultReading((int)ReadingLabels.LeftAtriumIASLADimensionsNotEvaluated, customerEventReadingEntities);
            testResult.LeftAtriumIASLADimensionsNormal = CreateResultReading((int)ReadingLabels.LeftAtriumIASLADimensionsNormal, customerEventReadingEntities);
            testResult.LeftAtriumIASLADimensionsMildlyDilated = CreateResultReading((int)ReadingLabels.LeftAtriumIASLADimensionsMildlyDilated, customerEventReadingEntities);
            testResult.LeftAtriumIASLADimensionsModeratelyDilated = CreateResultReading((int)ReadingLabels.LeftAtriumIASLADimensionsModeratelyDilated, customerEventReadingEntities);
            testResult.LeftAtriumIASLADimensionsSeverelyDilated = CreateResultReading((int)ReadingLabels.LeftAtriumIASLADimensionsSeverelyDilated, customerEventReadingEntities);
            testResult.LeftAtriumIASComment = CreateResultReadingforInputValues((int)ReadingLabels.LeftAtriumIASComment, customerEventReadingEntities);
        }

        private void GetRightVentricleReadingData(AwvEchocardiogramTestResult testResult, List<CustomerEventReadingEntity> customerEventReadingEntities)
        {
            testResult.RightVentricleOverallFunctionNotEvaluated = CreateResultReading((int)ReadingLabels.RightVentricleOverallFunctionNotEvaluated, customerEventReadingEntities);
            testResult.RightVentricleOverallFunctionNormal = CreateResultReading((int)ReadingLabels.RightVentricleOverallFunctionNormal, customerEventReadingEntities);
            testResult.RightVentricleOverallFunctionReduced = CreateResultReading((int)ReadingLabels.RightVentricleOverallFunctionReduced, customerEventReadingEntities);
            testResult.RightVentricleOverallFunctionBorderline = CreateResultReading((int)ReadingLabels.RightVentricleOverallFunctionBorderline, customerEventReadingEntities);
            testResult.RightVentricleOverallFunctionHyperkinesis = CreateResultReading((int)ReadingLabels.RightVentricleOverallFunctionHyperkinesis, customerEventReadingEntities);
            testResult.RightVentricleOverallFunctionHypokinesis = CreateResultReading((int)ReadingLabels.RightVentricleOverallFunctionHypokinesis, customerEventReadingEntities);

            testResult.RightVentricleDimensionsNotEvaluated = CreateResultReading((int)ReadingLabels.RightVentricleDimensionsNotEvaluated, customerEventReadingEntities);
            testResult.RightVentricleDimensionsNormal = CreateResultReading((int)ReadingLabels.RightVentricleDimensionsNormal, customerEventReadingEntities);
            testResult.RightVentricleDimensionsSmall = CreateResultReading((int)ReadingLabels.RightVentricleDimensionsSmall, customerEventReadingEntities);
            testResult.RightVentricleDimensionsDilated = CreateResultReading((int)ReadingLabels.RightVentricleDimensionsDilated, customerEventReadingEntities);
            testResult.RightVentricleDimensionsSlightlyEnlarged = CreateResultReading((int)ReadingLabels.RightVentricleDimensionsSlightlyEnlarged, customerEventReadingEntities);
            testResult.RightVentricleDimensionsSeverelyDilated = CreateResultReading((int)ReadingLabels.RightVentricleDimensionsSeverelyDilated, customerEventReadingEntities);

            testResult.RightVentricleThicknessesNotEvaluated = CreateResultReading((int)ReadingLabels.RightVentricleThicknessesNotEvaluated, customerEventReadingEntities);
            testResult.RightVentricleThicknessesNormal = CreateResultReading((int)ReadingLabels.RightVentricleThicknessesNormal, customerEventReadingEntities);
            testResult.RightVentricleThicknessesApicalHypertrophy = CreateResultReading((int)ReadingLabels.RightVentricleThicknessesApicalHypertrophy, customerEventReadingEntities);
            testResult.RightVentricleThicknessesAsymmetricalHypertrophy = CreateResultReading((int)ReadingLabels.RightVentricleThicknessesAsymmetricalHypertrophy, customerEventReadingEntities);
            testResult.RightVentricleThicknessesIVSeptumObstructiveHypertrophy = CreateResultReading((int)ReadingLabels.RightVentricleThicknessesIVSeptumObstructiveHypertrophy, customerEventReadingEntities);
            testResult.RightVentricleThicknessesMinorModerateIVSeptumHypertrophy = CreateResultReading((int)ReadingLabels.RightVentricleThicknessesMinorModerateIVSeptumHypertrophy, customerEventReadingEntities);
            testResult.RightVentricleThicknessesSevereIVSeptumHypertrophy = CreateResultReading((int)ReadingLabels.RightVentricleThicknessesSevereIVSeptumHypertrophy, customerEventReadingEntities);
            testResult.RightVentricleThicknessesMinorModerateSymmetricHypertrophy = CreateResultReading((int)ReadingLabels.RightVentricleThicknessesMinorModerateSymmetricHypertrophy, customerEventReadingEntities);
            testResult.RightVentricleThicknessesSevereSymmetricHypertrophy = CreateResultReading((int)ReadingLabels.RightVentricleThicknessesSevereSymmetricHypertrophy, customerEventReadingEntities);

            testResult.RightVentricleComment = CreateResultReadingforInputValues((int)ReadingLabels.RightVentricleComment, customerEventReadingEntities);
        }

        private void GetRightAtriumReadingData(AwvEchocardiogramTestResult testResult, List<CustomerEventReadingEntity> customerEventReadingEntities)
        {
            testResult.RightAtriumRADimensionsNotEvaluated = CreateResultReading((int)ReadingLabels.RightAtriumRADimensionsNotEvaluated, customerEventReadingEntities);
            testResult.RightAtriumRADimensionsNormal = CreateResultReading((int)ReadingLabels.RightAtriumRADimensionsNormal, customerEventReadingEntities);
            testResult.RightAtriumRADimensionsMildlyDilated = CreateResultReading((int)ReadingLabels.RightAtriumRADimensionsMildlyDilated, customerEventReadingEntities);
            testResult.RightAtriumRADimensionsModeratelyDilated = CreateResultReading((int)ReadingLabels.RightAtriumRADimensionsModeratelyDilated, customerEventReadingEntities);
            testResult.RightAtriumRADimensionsSeverelyDilated = CreateResultReading((int)ReadingLabels.RightAtriumRADimensionsSeverelyDilated, customerEventReadingEntities);
            testResult.RightAtriumComment = CreateResultReadingforInputValues((int)ReadingLabels.RightAtriumComment, customerEventReadingEntities);
        }

        private void GetAortaReadingData(AwvEchocardiogramTestResult testResult, List<CustomerEventReadingEntity> customerEventReadingEntities)
        {
            testResult.AortaInsufficiencyAbsent = CreateResultReading((int)ReadingLabels.AortaInsufficiencyAbsent, customerEventReadingEntities);
            testResult.AortaInsufficiencyMinor = CreateResultReading((int)ReadingLabels.AortaInsufficiencyMinor, customerEventReadingEntities);
            testResult.AortaInsufficiencyModerate = CreateResultReading((int)ReadingLabels.AortaInsufficiencyModerate, customerEventReadingEntities);
            testResult.AortaInsufficiencySevere = CreateResultReading((int)ReadingLabels.AortaInsufficiencySevere, customerEventReadingEntities);

            testResult.AortaLeafletsNotEvaluated = CreateResultReading((int)ReadingLabels.AortaLeafletsNotEvaluated, customerEventReadingEntities);
            testResult.AortaLeafletsNormal = CreateResultReading((int)ReadingLabels.AortaLeafletsNormal, customerEventReadingEntities);
            testResult.AortaLeafletsMildStenosis = CreateResultReading((int)ReadingLabels.AortaLeafletsMildStenosis, customerEventReadingEntities);
            testResult.AortaLeafletsModerateStenosis = CreateResultReading((int)ReadingLabels.AortaLeafletsModerateStenosis, customerEventReadingEntities);
            testResult.AortaLeafletsSevereStenosis = CreateResultReading((int)ReadingLabels.AortaLeafletsSevereStenosis, customerEventReadingEntities);

            testResult.AortaValveNotEvaluated = CreateResultReading((int)ReadingLabels.AortaValveNotEvaluated, customerEventReadingEntities);
            testResult.AortaValveBicuspid = CreateResultReading((int)ReadingLabels.AortaValveBicuspid, customerEventReadingEntities);
            testResult.AortaValveAtherosclerotic = CreateResultReading((int)ReadingLabels.AortaValveAtherosclerotic, customerEventReadingEntities);
            testResult.AortaValveNormalFunctioningBiologicalProsthesis = CreateResultReading((int)ReadingLabels.AortaValveNormalFunctioningBiologicalProsthesis, customerEventReadingEntities);
            testResult.AortaValveNormalFunctioningMechanicalProsthesis = CreateResultReading((int)ReadingLabels.AortaValveNormalFunctioningMechanicalProsthesis, customerEventReadingEntities);
            testResult.AortaValveMalfunctioningBiologicalProsthesis = CreateResultReading((int)ReadingLabels.AortaValveMalfunctioningBiologicalProsthesis, customerEventReadingEntities);
            testResult.AortaValveMalfunctioningMechanicalProsthesis = CreateResultReading((int)ReadingLabels.AortaValveMalfunctioningMechanicalProsthesis, customerEventReadingEntities);
            testResult.AortaValveDilatedAorticRoot = CreateResultReading((int)ReadingLabels.AortaValveDilatedAorticRoot, customerEventReadingEntities);
            testResult.AortaValveSinusValsalvaAneurysm = CreateResultReading((int)ReadingLabels.AortaValveSinusValsalvaAneurysm, customerEventReadingEntities);

            testResult.AortaComment = CreateResultReadingforInputValues((int)ReadingLabels.AortaComment, customerEventReadingEntities);
        }

        private void GetMitralReadingData(AwvEchocardiogramTestResult testResult, List<CustomerEventReadingEntity> customerEventReadingEntities)
        {
            testResult.MitralInsufficiencyAbsent = CreateResultReading((int)ReadingLabels.MitralInsufficiencyAbsent, customerEventReadingEntities);
            testResult.MitralInsufficiencyMinor = CreateResultReading((int)ReadingLabels.MitralInsufficiencyMinor, customerEventReadingEntities);
            testResult.MitralInsufficiencyModerate = CreateResultReading((int)ReadingLabels.MitralInsufficiencyModerate, customerEventReadingEntities);
            testResult.MitralInsufficiencySevere = CreateResultReading((int)ReadingLabels.MitralInsufficiencySevere, customerEventReadingEntities);

            testResult.MitralLeafletsNotEvaluated = CreateResultReading((int)ReadingLabels.MitralLeafletsNotEvaluated, customerEventReadingEntities);
            testResult.MitralLeafletsNormal = CreateResultReading((int)ReadingLabels.MitralLeafletsNormal, customerEventReadingEntities);
            testResult.MitralLeafletsRedundant = CreateResultReading((int)ReadingLabels.MitralLeafletsRedundant, customerEventReadingEntities);
            testResult.MitralLeafletsMildStenosis = CreateResultReading((int)ReadingLabels.MitralLeafletsMildStenosis, customerEventReadingEntities);
            testResult.MitralLeafletsModerateStenosis = CreateResultReading((int)ReadingLabels.MitralLeafletsModerateStenosis, customerEventReadingEntities);
            testResult.MitralLeafletsSevereStenosis = CreateResultReading((int)ReadingLabels.MitralLeafletsSevereStenosis, customerEventReadingEntities);

            testResult.MitralValveNotEvaluated = CreateResultReading((int)ReadingLabels.MitralValveNotEvaluated, customerEventReadingEntities);
            testResult.MitralValveBicuspid = CreateResultReading((int)ReadingLabels.MitralValveBicuspid, customerEventReadingEntities);
            testResult.MitralValveAtherosclerotic = CreateResultReading((int)ReadingLabels.MitralValveAtherosclerotic, customerEventReadingEntities);
            testResult.MitralValveNormalFunctioningBiologicalProsthesis = CreateResultReading((int)ReadingLabels.MitralValveNormalFunctioningBiologicalProsthesis, customerEventReadingEntities);
            testResult.MitralValveNormalFunctioningMechanicalProsthesis = CreateResultReading((int)ReadingLabels.MitralValveNormalFunctioningMechanicalProsthesis, customerEventReadingEntities);
            testResult.MitralValveMalfunctioningBiologicalProsthesis = CreateResultReading((int)ReadingLabels.MitralValveMalfunctioningBiologicalProsthesis, customerEventReadingEntities);
            testResult.MitralValveMalfunctioningMechanicalProsthesis = CreateResultReading((int)ReadingLabels.MitralValveMalfunctioningMechanicalProsthesis, customerEventReadingEntities);

            testResult.MitralValveComment = CreateResultReadingforInputValues((int)ReadingLabels.MitralValveComment, customerEventReadingEntities);
        }

        private void GetPulmonaryReadingData(AwvEchocardiogramTestResult testResult, List<CustomerEventReadingEntity> customerEventReadingEntities)
        {
            testResult.PulmonaryInsufficiencyAbsent = CreateResultReading((int)ReadingLabels.PulmonaryInsufficiencyAbsent, customerEventReadingEntities);
            testResult.PulmonaryInsufficiencyMinor = CreateResultReading((int)ReadingLabels.PulmonaryInsufficiencyMinor, customerEventReadingEntities);
            testResult.PulmonaryInsufficiencyModerate = CreateResultReading((int)ReadingLabels.PulmonaryInsufficiencyModerate, customerEventReadingEntities);
            testResult.PulmonaryInsufficiencySevere = CreateResultReading((int)ReadingLabels.PulmonaryInsufficiencySevere, customerEventReadingEntities);

            testResult.PulmonaryLeafletsNormal = CreateResultReading((int)ReadingLabels.PulmonaryLeafletsNormal, customerEventReadingEntities);
            testResult.PulmonaryLeafletsThickened = CreateResultReading((int)ReadingLabels.PulmonaryLeafletsThickened, customerEventReadingEntities);
            testResult.PulmonaryLeafletsStenotic = CreateResultReading((int)ReadingLabels.PulmonaryLeafletsStenotic, customerEventReadingEntities);
            testResult.PulmonaryLeafletsMildStenosis = CreateResultReading((int)ReadingLabels.PulmonaryLeafletsMildStenosis, customerEventReadingEntities);
            testResult.PulmonaryLeafletsModerateStenosis = CreateResultReading((int)ReadingLabels.PulmonaryLeafletsModerateStenosis, customerEventReadingEntities);
            testResult.PulmonaryLeafletsSevereStenosis = CreateResultReading((int)ReadingLabels.PulmonaryLeafletsSevereStenosis, customerEventReadingEntities);

            testResult.PulmonaryValveNotEvaluated = CreateResultReading((int)ReadingLabels.PulmonaryValveNotEvaluated, customerEventReadingEntities);
            testResult.PulmonaryValveBicuspid = CreateResultReading((int)ReadingLabels.PulmonaryValveBicuspid, customerEventReadingEntities);
            testResult.PulmonaryValveAtherosclerotic = CreateResultReading((int)ReadingLabels.PulmonaryValveAtherosclerotic, customerEventReadingEntities);
            testResult.PulmonaryValveNormalFunctioningBiologicalProsthesis = CreateResultReading((int)ReadingLabels.PulmonaryValveNormalFunctioningBiologicalProsthesis, customerEventReadingEntities);
            testResult.PulmonaryValveNormalFunctioningMechanicalProsthesis = CreateResultReading((int)ReadingLabels.PulmonaryValveNormalFunctioningMechanicalProsthesis, customerEventReadingEntities);
            testResult.PulmonaryValveMalfunctioningBiologicalProsthesis = CreateResultReading((int)ReadingLabels.PulmonaryValveMalfunctioningBiologicalProsthesis, customerEventReadingEntities);
            testResult.PulmonaryValveMalfunctioningMechanicalProsthesis = CreateResultReading((int)ReadingLabels.PulmonaryValveMalfunctioningMechanicalProsthesis, customerEventReadingEntities);

            testResult.PulmonaryComment = CreateResultReadingforInputValues((int)ReadingLabels.PulmonaryComment, customerEventReadingEntities);
        }

        private void GetTricuspidReadingData(AwvEchocardiogramTestResult testResult, List<CustomerEventReadingEntity> customerEventReadingEntities)
        {
            testResult.TricuspidInsufficiencyAbsent = CreateResultReading((int)ReadingLabels.TricuspidInsufficiencyAbsent, customerEventReadingEntities);
            testResult.TricuspidInsufficiencyMinor = CreateResultReading((int)ReadingLabels.TricuspidInsufficiencyMinor, customerEventReadingEntities);
            testResult.TricuspidInsufficiencyModerate = CreateResultReading((int)ReadingLabels.TricuspidInsufficiencyModerate, customerEventReadingEntities);
            testResult.TricuspidInsufficiencySevere = CreateResultReading((int)ReadingLabels.TricuspidInsufficiencySevere, customerEventReadingEntities);

            testResult.TricuspidLeafletsNormal = CreateResultReading((int)ReadingLabels.TricuspidLeafletsNormal, customerEventReadingEntities);
            testResult.TricuspidLeafletsThickened = CreateResultReading((int)ReadingLabels.TricuspidLeafletsThickened, customerEventReadingEntities);
            testResult.TricuspidLeafletsRedundant = CreateResultReading((int)ReadingLabels.TricuspidLeafletsRedundant, customerEventReadingEntities);
            testResult.TricuspidLeafletsMildStenosis = CreateResultReading((int)ReadingLabels.TricuspidLeafletsMildStenosis, customerEventReadingEntities);
            testResult.TricuspidLeafletsModerateStenosis = CreateResultReading((int)ReadingLabels.TricuspidLeafletsModerateStenosis, customerEventReadingEntities);
            testResult.TricuspidLeafletsSevereStenosis = CreateResultReading((int)ReadingLabels.TricuspidLeafletsSevereStenosis, customerEventReadingEntities);

            testResult.TricuspidValveNotEvaluated = CreateResultReading((int)ReadingLabels.TricuspidValveNotEvaluated, customerEventReadingEntities);
            testResult.TricuspidValveBicuspid = CreateResultReading((int)ReadingLabels.TricuspidValveBicuspid, customerEventReadingEntities);
            testResult.TricuspidValveAtherosclerotic = CreateResultReading((int)ReadingLabels.TricuspidValveAtherosclerotic, customerEventReadingEntities);
            testResult.TricuspidValveNormalFunctioningBiologicalProsthesis = CreateResultReading((int)ReadingLabels.TricuspidValveNormalFunctioningBiologicalProsthesis, customerEventReadingEntities);
            testResult.TricuspidValveNormalFunctioningMechanicalProsthesis = CreateResultReading((int)ReadingLabels.TricuspidValveNormalFunctioningMechanicalProsthesis, customerEventReadingEntities);
            testResult.TricuspidValveMalfunctioningBiologicalProsthesis = CreateResultReading((int)ReadingLabels.TricuspidValveMalfunctioningBiologicalProsthesis, customerEventReadingEntities);
            testResult.TricuspidValveMalfunctioningMechanicalProsthesis = CreateResultReading((int)ReadingLabels.TricuspidValveMalfunctioningMechanicalProsthesis, customerEventReadingEntities);

            testResult.TricuspidComment = CreateResultReadingforInputValues((int)ReadingLabels.TricuspidComment, customerEventReadingEntities);
        }

        public override CustomerEventScreeningTestsEntity CreateActualTestResultEntity(TestResult testResult, List<OrderedPair<int, int>> testReadingReadingPairs)
        {
            var awvEchoTestResult = testResult as AwvEchocardiogramTestResult;
            var customerEventScreeningTestsEntity = new CustomerEventScreeningTestsEntity(testResult.Id) { TestId = (int)TestType.AwvEcho };
            var customerEventReadingEntities = new List<CustomerEventReadingEntity>();

            if (awvEchoTestResult.Aortic != null)
                customerEventReadingEntities.Add(CreateEventReadingEntity(awvEchoTestResult.Aortic, (int)ReadingLabels.Aortic, testReadingReadingPairs));

            if (awvEchoTestResult.Mitral != null)
                customerEventReadingEntities.Add(CreateEventReadingEntity(awvEchoTestResult.Mitral, (int)ReadingLabels.Mitral, testReadingReadingPairs));

            if (awvEchoTestResult.Pulmonic != null)
                customerEventReadingEntities.Add(CreateEventReadingEntity(awvEchoTestResult.Pulmonic, (int)ReadingLabels.Pulmonic, testReadingReadingPairs));

            if (awvEchoTestResult.Tricuspid != null)
                customerEventReadingEntities.Add(CreateEventReadingEntity(awvEchoTestResult.Tricuspid, (int)ReadingLabels.Tricuspid, testReadingReadingPairs));

            if (awvEchoTestResult.Conclusion != null)
            {
                var customerEventReading = CreateEventReadingEntity(awvEchoTestResult.Conclusion, (int)ReadingLabels.Conclusion, testReadingReadingPairs);
                customerEventReadingEntities.Add(customerEventReading);
            }

            if (awvEchoTestResult.VentricularEnlargement != null)
                customerEventReadingEntities.Add(CreateEventReadingEntity(awvEchoTestResult.VentricularEnlargement, (int)ReadingLabels.VentricularEnlargement, testReadingReadingPairs));

            if (awvEchoTestResult.LeftVentricularEnlargment != null)
                customerEventReadingEntities.Add(CreateEventReadingEntity(awvEchoTestResult.LeftVentricularEnlargment, (int)ReadingLabels.LeftVentricularEnlargment, testReadingReadingPairs));

            if (awvEchoTestResult.RightVentricularEnlargment != null)
                customerEventReadingEntities.Add(CreateEventReadingEntity(awvEchoTestResult.RightVentricularEnlargment, (int)ReadingLabels.RightVentricularEnlargment, testReadingReadingPairs));

            if (awvEchoTestResult.LeftVentricularEnlargmentValue != null)
                customerEventReadingEntities.Add(CreateEventReadingEntity(awvEchoTestResult.LeftVentricularEnlargmentValue, (int)ReadingLabels.LeftVentricularEnlargmentValue, testReadingReadingPairs));

            if (awvEchoTestResult.RightVentricularEnlargmentValue != null)
                customerEventReadingEntities.Add(CreateEventReadingEntity(awvEchoTestResult.RightVentricularEnlargmentValue, (int)ReadingLabels.RightVentricularEnlargmentValue, testReadingReadingPairs));

            if (awvEchoTestResult.DiastolicDysfunction != null)
                customerEventReadingEntities.Add(CreateEventReadingEntity(awvEchoTestResult.DiastolicDysfunction, (int)ReadingLabels.DiastolicDysfunction, testReadingReadingPairs));

            if (awvEchoTestResult.PericardialEffusion != null)
                customerEventReadingEntities.Add(CreateEventReadingEntity(awvEchoTestResult.PericardialEffusion, (int)ReadingLabels.PericardialEffusion, testReadingReadingPairs));


            if (awvEchoTestResult.AorticRoot != null)
                customerEventReadingEntities.Add(CreateEventReadingEntity(awvEchoTestResult.AorticRoot, (int)ReadingLabels.AorticRoot, testReadingReadingPairs));

            if (awvEchoTestResult.Sclerotic != null)
                customerEventReadingEntities.Add(CreateEventReadingEntity(awvEchoTestResult.Sclerotic, (int)ReadingLabels.Sclerotic, testReadingReadingPairs));

            if (awvEchoTestResult.Calcified != null)
                customerEventReadingEntities.Add(CreateEventReadingEntity(awvEchoTestResult.Calcified, (int)ReadingLabels.Calcified, testReadingReadingPairs));

            if (awvEchoTestResult.Enlarged != null)
                customerEventReadingEntities.Add(CreateEventReadingEntity(awvEchoTestResult.Enlarged, (int)ReadingLabels.Enlarged, testReadingReadingPairs));

            if (awvEchoTestResult.EnlargedValue != null)
                customerEventReadingEntities.Add(CreateEventReadingEntity(awvEchoTestResult.EnlargedValue, (int)ReadingLabels.EnlargedValue, testReadingReadingPairs));

            if (awvEchoTestResult.AscendingAortaArch != null)
                customerEventReadingEntities.Add(CreateEventReadingEntity(awvEchoTestResult.AscendingAortaArch, (int)ReadingLabels.AscendingAortaArch, testReadingReadingPairs));

            if (awvEchoTestResult.Atherosclerosis != null)
                customerEventReadingEntities.Add(CreateEventReadingEntity(awvEchoTestResult.Atherosclerosis, (int)ReadingLabels.Atherosclerosis, testReadingReadingPairs));


            if (awvEchoTestResult.VentricularHypertrophy != null)
                customerEventReadingEntities.Add(CreateEventReadingEntity(awvEchoTestResult.VentricularHypertrophy, (int)ReadingLabels.VentricularHypertrophy, testReadingReadingPairs));

            if (awvEchoTestResult.LeftVHypertrophyValue != null)
                customerEventReadingEntities.Add(CreateEventReadingEntity(awvEchoTestResult.LeftVHypertrophyValue, (int)ReadingLabels.LeftVHypertrophyValue, testReadingReadingPairs));

            if (awvEchoTestResult.RightVHypertrophyValue != null)
                customerEventReadingEntities.Add(CreateEventReadingEntity(awvEchoTestResult.RightVHypertrophyValue, (int)ReadingLabels.RightVHypertrophyValue, testReadingReadingPairs));

            if (awvEchoTestResult.IvshHypertrophyValue != null)
                customerEventReadingEntities.Add(CreateEventReadingEntity(awvEchoTestResult.IvshHypertrophyValue, (int)ReadingLabels.IVSHHypertrophyValue, testReadingReadingPairs));

            if (awvEchoTestResult.LeftVHypertrophy != null)
                customerEventReadingEntities.Add(CreateEventReadingEntity(awvEchoTestResult.LeftVHypertrophy, (int)ReadingLabels.LeftVHypertrophy, testReadingReadingPairs));

            if (awvEchoTestResult.RightVHypertrophy != null)
                customerEventReadingEntities.Add(CreateEventReadingEntity(awvEchoTestResult.RightVHypertrophy, (int)ReadingLabels.RightVHypertrophy, testReadingReadingPairs));

            if (awvEchoTestResult.IvshHypertrophy != null)
                customerEventReadingEntities.Add(CreateEventReadingEntity(awvEchoTestResult.IvshHypertrophy, (int)ReadingLabels.IVSHHypertrophy, testReadingReadingPairs));


            if (awvEchoTestResult.TechnicallyLimitedbutReadable != null)
                customerEventReadingEntities.Add(CreateEventReadingEntity(awvEchoTestResult.TechnicallyLimitedbutReadable, (int)ReadingLabels.TechnicallyLimitedbutReadable, testReadingReadingPairs));

            if (awvEchoTestResult.RepeatStudyUnreadable != null)
                customerEventReadingEntities.Add(CreateEventReadingEntity(awvEchoTestResult.RepeatStudyUnreadable, (int)ReadingLabels.RepeatStudy, testReadingReadingPairs));


            if (awvEchoTestResult.AtrialEnlargement != null)
                customerEventReadingEntities.Add(CreateEventReadingEntity(awvEchoTestResult.AtrialEnlargement, (int)ReadingLabels.AtrialEnlargement, testReadingReadingPairs));

            if (awvEchoTestResult.LeftAtrialEnlargmentValue != null)
                customerEventReadingEntities.Add(CreateEventReadingEntity(awvEchoTestResult.LeftAtrialEnlargmentValue, (int)ReadingLabels.LeftAtrialEnlargmentValue, testReadingReadingPairs));

            if (awvEchoTestResult.RightAtrialEnlargmentValue != null)
                customerEventReadingEntities.Add(CreateEventReadingEntity(awvEchoTestResult.RightAtrialEnlargmentValue, (int)ReadingLabels.RightAtrialEnlargmentValue, testReadingReadingPairs));

            if (awvEchoTestResult.LeftAtrialEnlargment != null)
                customerEventReadingEntities.Add(CreateEventReadingEntity(awvEchoTestResult.LeftAtrialEnlargment, (int)ReadingLabels.LeftAtrialEnlargment, testReadingReadingPairs));

            if (awvEchoTestResult.RightAtrialEnlargment != null)
                customerEventReadingEntities.Add(CreateEventReadingEntity(awvEchoTestResult.RightAtrialEnlargment, (int)ReadingLabels.RightAtrialEnlargment, testReadingReadingPairs));



            if (awvEchoTestResult.ASD != null)
                customerEventReadingEntities.Add(CreateEventReadingEntity(awvEchoTestResult.ASD, (int)ReadingLabels.ASD, testReadingReadingPairs));

            if (awvEchoTestResult.PFO != null)
                customerEventReadingEntities.Add(CreateEventReadingEntity(awvEchoTestResult.PFO, (int)ReadingLabels.PFO, testReadingReadingPairs));

            if (awvEchoTestResult.VSD != null)
                customerEventReadingEntities.Add(CreateEventReadingEntity(awvEchoTestResult.VSD, (int)ReadingLabels.VSD, testReadingReadingPairs));

            if (awvEchoTestResult.FlailAS != null)
                customerEventReadingEntities.Add(CreateEventReadingEntity(awvEchoTestResult.FlailAS, (int)ReadingLabels.FlailAS, testReadingReadingPairs));

            if (awvEchoTestResult.Arrythmia != null)
                customerEventReadingEntities.Add(CreateEventReadingEntity(awvEchoTestResult.Arrythmia, (int)ReadingLabels.Arrythmia, testReadingReadingPairs));

            if (awvEchoTestResult.AFib != null)
                customerEventReadingEntities.Add(CreateEventReadingEntity(awvEchoTestResult.AFib, (int)ReadingLabels.AFib, testReadingReadingPairs));

            if (awvEchoTestResult.AFlutter != null)
                customerEventReadingEntities.Add(CreateEventReadingEntity(awvEchoTestResult.AFlutter, (int)ReadingLabels.AFlutter, testReadingReadingPairs));

            if (awvEchoTestResult.PAC != null)
                customerEventReadingEntities.Add(CreateEventReadingEntity(awvEchoTestResult.PAC, (int)ReadingLabels.PAC, testReadingReadingPairs));

            if (awvEchoTestResult.PVC != null)
                customerEventReadingEntities.Add(CreateEventReadingEntity(awvEchoTestResult.PVC, (int)ReadingLabels.PVC, testReadingReadingPairs));


            if (awvEchoTestResult.RestrictedLeafletMotion != null)
                customerEventReadingEntities.Add(CreateEventReadingEntity(awvEchoTestResult.RestrictedLeafletMotion, (int)ReadingLabels.RestrictedLeafletMotion, testReadingReadingPairs));

            if (awvEchoTestResult.RestrictedLeafletMotionAortic != null)
                customerEventReadingEntities.Add(CreateEventReadingEntity(awvEchoTestResult.RestrictedLeafletMotionAortic, (int)ReadingLabels.RestrictedLeafletMotionAortic, testReadingReadingPairs));

            if (awvEchoTestResult.RestrictedLeafletMotionMitral != null)
                customerEventReadingEntities.Add(CreateEventReadingEntity(awvEchoTestResult.RestrictedLeafletMotionMitral, (int)ReadingLabels.RestrictedLeafletMotionMitral, testReadingReadingPairs));

            if (awvEchoTestResult.RestrictedLeafletMotionPulmonic != null)
                customerEventReadingEntities.Add(CreateEventReadingEntity(awvEchoTestResult.RestrictedLeafletMotionPulmonic, (int)ReadingLabels.RestrictedLeafletMotionPulmonic, testReadingReadingPairs));

            if (awvEchoTestResult.RestrictedLeafletMotionTricuspid != null)
                customerEventReadingEntities.Add(CreateEventReadingEntity(awvEchoTestResult.RestrictedLeafletMotionTricuspid, (int)ReadingLabels.RestrictedLeafletMotionTricuspid, testReadingReadingPairs));

            if (awvEchoTestResult.MitralAnnularCa != null)
                customerEventReadingEntities.Add(CreateEventReadingEntity(awvEchoTestResult.MitralAnnularCa, (int)ReadingLabels.MitralAnnularCa, testReadingReadingPairs));

            if (awvEchoTestResult.Hypokinetic != null)
                customerEventReadingEntities.Add(CreateEventReadingEntity(awvEchoTestResult.Hypokinetic, (int)ReadingLabels.Hypokinetic, testReadingReadingPairs));

            if (awvEchoTestResult.Akinetic != null)
                customerEventReadingEntities.Add(CreateEventReadingEntity(awvEchoTestResult.Akinetic, (int)ReadingLabels.Akinetic, testReadingReadingPairs));

            if (awvEchoTestResult.Dyskinetic != null)
                customerEventReadingEntities.Add(CreateEventReadingEntity(awvEchoTestResult.Dyskinetic, (int)ReadingLabels.Dyskinetic, testReadingReadingPairs));

            if (awvEchoTestResult.Anterior != null)
                customerEventReadingEntities.Add(CreateEventReadingEntity(awvEchoTestResult.Anterior, (int)ReadingLabels.Anterior, testReadingReadingPairs));

            if (awvEchoTestResult.Posterior != null)
                customerEventReadingEntities.Add(CreateEventReadingEntity(awvEchoTestResult.Posterior, (int)ReadingLabels.Posterior, testReadingReadingPairs));

            if (awvEchoTestResult.Apical != null)
                customerEventReadingEntities.Add(CreateEventReadingEntity(awvEchoTestResult.Apical, (int)ReadingLabels.Apical, testReadingReadingPairs));

            if (awvEchoTestResult.Septal != null)
                customerEventReadingEntities.Add(CreateEventReadingEntity(awvEchoTestResult.Septal, (int)ReadingLabels.Septal, testReadingReadingPairs));

            if (awvEchoTestResult.Lateral != null)
                customerEventReadingEntities.Add(CreateEventReadingEntity(awvEchoTestResult.Lateral, (int)ReadingLabels.Lateral, testReadingReadingPairs));

            if (awvEchoTestResult.Inferior != null)
                customerEventReadingEntities.Add(CreateEventReadingEntity(awvEchoTestResult.Inferior, (int)ReadingLabels.Inferior, testReadingReadingPairs));

            if (awvEchoTestResult.AoticVelocity != null)
                customerEventReadingEntities.Add(CreateEventReadingEntity(awvEchoTestResult.AoticVelocity, (int)ReadingLabels.AoticVelocity, testReadingReadingPairs));

            if (awvEchoTestResult.PeakGradient != null)
                customerEventReadingEntities.Add(CreateEventReadingEntity(awvEchoTestResult.PeakGradient, (int)ReadingLabels.PeakGradient, testReadingReadingPairs));

            if (awvEchoTestResult.MitralPT != null)
                customerEventReadingEntities.Add(CreateEventReadingEntity(awvEchoTestResult.MitralPT, (int)ReadingLabels.MitralPT, testReadingReadingPairs));

            if (awvEchoTestResult.PulmonicVelocity != null)
                customerEventReadingEntities.Add(CreateEventReadingEntity(awvEchoTestResult.PulmonicVelocity, (int)ReadingLabels.PulmonicVelocity, testReadingReadingPairs));

            if (awvEchoTestResult.TricuspidVelocity != null)
                customerEventReadingEntities.Add(CreateEventReadingEntity(awvEchoTestResult.TricuspidVelocity, (int)ReadingLabels.TricuspidVelocity, testReadingReadingPairs));

            if (awvEchoTestResult.TricuspidPap != null)
                customerEventReadingEntities.Add(CreateEventReadingEntity(awvEchoTestResult.TricuspidPap, (int)ReadingLabels.TricuspidPap, testReadingReadingPairs));

            if (awvEchoTestResult.MorphologyTricuspidHighOrGreater != null)
                customerEventReadingEntities.Add(CreateEventReadingEntity(awvEchoTestResult.MorphologyTricuspidHighOrGreater, (int)ReadingLabels.High35MmHgOrGreater, testReadingReadingPairs));

            if (awvEchoTestResult.MorphologyTricuspidNormal != null)
                customerEventReadingEntities.Add(CreateEventReadingEntity(awvEchoTestResult.MorphologyTricuspidNormal, (int)ReadingLabels.Normal, testReadingReadingPairs));


            if (awvEchoTestResult.AorticEstimatedValveArea != null)
                customerEventReadingEntities.Add(CreateEventReadingEntity(awvEchoTestResult.AorticEstimatedValveArea, (int)ReadingLabels.AorticEstimatedValveArea, testReadingReadingPairs));

            if (awvEchoTestResult.MitralEstimatedValveArea != null)
                customerEventReadingEntities.Add(CreateEventReadingEntity(awvEchoTestResult.MitralEstimatedValveArea, (int)ReadingLabels.MitralEstimatedValveArea, testReadingReadingPairs));

            if (awvEchoTestResult.PulmonicEstimatedValveArea != null)
                customerEventReadingEntities.Add(CreateEventReadingEntity(awvEchoTestResult.PulmonicEstimatedValveArea, (int)ReadingLabels.PulmonicEstimatedValveArea, testReadingReadingPairs));

            if (awvEchoTestResult.TricuspidEstimatedValveArea != null)
                customerEventReadingEntities.Add(CreateEventReadingEntity(awvEchoTestResult.TricuspidEstimatedValveArea, (int)ReadingLabels.TricuspidEstimatedValveArea, testReadingReadingPairs));

            if (awvEchoTestResult.AorticEstimatedRightValve != null)
                customerEventReadingEntities.Add(CreateEventReadingEntity(awvEchoTestResult.AorticEstimatedRightValve, (int)ReadingLabels.AorticEstimatedRightValve, testReadingReadingPairs));

            if (awvEchoTestResult.MitralEstimatedRightValve != null)
                customerEventReadingEntities.Add(CreateEventReadingEntity(awvEchoTestResult.MitralEstimatedRightValve, (int)ReadingLabels.MitralEstimatedRightValve, testReadingReadingPairs));

            if (awvEchoTestResult.DiastolicDysfunctionEeRatio != null)
                customerEventReadingEntities.Add(CreateEventReadingEntity(awvEchoTestResult.DiastolicDysfunctionEeRatio, (int)ReadingLabels.DiastolicDysfunctionEeRatio, testReadingReadingPairs));


            if (awvEchoTestResult.ConsistentLvDiastolicFailure != null)
                customerEventReadingEntities.Add(CreateEventReadingEntity(awvEchoTestResult.ConsistentLvDiastolicFailure, (int)ReadingLabels.ConsistentLvDiastolicFailure, testReadingReadingPairs));
            if (awvEchoTestResult.ConsistentHypertensiveHeartDiseaseWithDiastolicHeartFailure != null)
                customerEventReadingEntities.Add(CreateEventReadingEntity(awvEchoTestResult.ConsistentHypertensiveHeartDiseaseWithDiastolicHeartFailure, (int)ReadingLabels.ConsistentHypertensiveHeartDiseaseWithDiastolicHeartFailure, testReadingReadingPairs));
            if (awvEchoTestResult.ConsistentHypertensiveHeartDiseaseWithoutDiastolicHeartFailure != null)
                customerEventReadingEntities.Add(CreateEventReadingEntity(awvEchoTestResult.ConsistentHypertensiveHeartDiseaseWithoutDiastolicHeartFailure, (int)ReadingLabels.ConsistentHypertensiveHeartDiseaseWithoutDiastolicHeartFailure, testReadingReadingPairs));

            SetLeftVentricleReadingData(testReadingReadingPairs, awvEchoTestResult, customerEventReadingEntities);
            SetLeftAtriumReadingData(testReadingReadingPairs, awvEchoTestResult, customerEventReadingEntities);
            SetRightVentricleReadingData(testReadingReadingPairs, awvEchoTestResult, customerEventReadingEntities);
            SetRightAtriumReadingData(testReadingReadingPairs, awvEchoTestResult, customerEventReadingEntities);
            SetAortaReadingData(testReadingReadingPairs, awvEchoTestResult, customerEventReadingEntities);
            SetMitralReadingData(testReadingReadingPairs, awvEchoTestResult, customerEventReadingEntities);
            SetPulmonaryReadingData(testReadingReadingPairs, awvEchoTestResult, customerEventReadingEntities);
            SetTricuspidReadingData(testReadingReadingPairs, awvEchoTestResult, customerEventReadingEntities);

            testResult.ResultInterpretation = null;
            if (awvEchoTestResult.Finding != null)
            {
                var customerEventTestStandardFindingEntity = new CustomerEventTestStandardFindingEntity()
                {
                    StandardFindingTestReadingId =
                        (int?)new TestResultService().GetStandardFindingTestReadingIdForStandardFinding
                            ((int)TestType.AwvEcho, null, Convert.ToInt64(awvEchoTestResult.Finding.Id)),
                    CustomerEventTestStandardFindingId = awvEchoTestResult.Finding.CustomerEventStandardFindingId,
                    CustomerEventScreeningTestId = testResult.Id
                };
                customerEventScreeningTestsEntity.CustomerEventTestStandardFinding.Add(customerEventTestStandardFindingEntity);

                var finding = GetSelectedStandardFinding((int)TestType.AwvEcho, null, awvEchoTestResult.Finding.Id);

                if (testResult.ResultStatus.StateNumber == (int)TestResultStateNumber.Evaluated || testResult.ResultStatus.StateNumber == (int)NewTestResultStateNumber.Evaluated)
                {
                    testResult.ResultInterpretation = finding.ResultInterpretation;
                    testResult.PathwayRecommendation = finding.PathwayRecommendation;
                }
            }

            if (awvEchoTestResult.EstimatedEjactionFraction != null)
            {
                var customerEventTestStandardFindingEntity = new CustomerEventTestStandardFindingEntity()
                {
                    StandardFindingTestReadingId =
                        (int?)new TestResultService().GetStandardFindingTestReadingIdForStandardFinding
                            ((int)TestType.AwvEcho, (int)ReadingLabels.EstimatedEjactionFraction, Convert.ToInt64(awvEchoTestResult.EstimatedEjactionFraction.Id)),
                    CustomerEventTestStandardFindingId = awvEchoTestResult.EstimatedEjactionFraction.CustomerEventStandardFindingId,
                    CustomerEventScreeningTestId = testResult.Id
                };
                customerEventScreeningTestsEntity.CustomerEventTestStandardFinding.Add(customerEventTestStandardFindingEntity);
            }
            if (awvEchoTestResult.AorticRegurgitation != null)
            {
                var customerEventTestStandardFindingEntity = new CustomerEventTestStandardFindingEntity()
                {
                    StandardFindingTestReadingId =
                        (int?)new TestResultService().GetStandardFindingTestReadingIdForStandardFinding
                            ((int)TestType.AwvEcho, (int)ReadingLabels.Aortic, Convert.ToInt64(awvEchoTestResult.AorticRegurgitation.Id)),
                    CustomerEventTestStandardFindingId = awvEchoTestResult.AorticRegurgitation.CustomerEventStandardFindingId,
                    CustomerEventScreeningTestId = testResult.Id
                };
                customerEventScreeningTestsEntity.CustomerEventTestStandardFinding.Add(customerEventTestStandardFindingEntity);
            }

            if (awvEchoTestResult.AorticMorphology != null)
            {
                awvEchoTestResult.AorticMorphology.ForEach(finding =>
                {
                    var customerEventTestStandardFindingEntity = new CustomerEventTestStandardFindingEntity()
                    {
                        StandardFindingTestReadingId =
                            (int?)new TestResultService().GetStandardFindingTestReadingIdForStandardFinding
                                ((int)TestType.AwvEcho, (int)ReadingLabels.AorticMorphology, Convert.ToInt64(finding.Id)),
                        CustomerEventTestStandardFindingId = finding.CustomerEventStandardFindingId,
                        CustomerEventScreeningTestId = testResult.Id
                    };
                    customerEventScreeningTestsEntity.CustomerEventTestStandardFinding.Add(customerEventTestStandardFindingEntity);
                });
            }

            if (awvEchoTestResult.MitralRegurgitation != null)
            {
                var customerEventTestStandardFindingEntity = new CustomerEventTestStandardFindingEntity()
                {
                    StandardFindingTestReadingId =
                        (int?)new TestResultService().GetStandardFindingTestReadingIdForStandardFinding
                            ((int)TestType.AwvEcho, (int)ReadingLabels.Mitral, Convert.ToInt64(awvEchoTestResult.MitralRegurgitation.Id)),
                    CustomerEventTestStandardFindingId = awvEchoTestResult.MitralRegurgitation.CustomerEventStandardFindingId,
                    CustomerEventScreeningTestId = testResult.Id
                };
                customerEventScreeningTestsEntity.CustomerEventTestStandardFinding.Add(customerEventTestStandardFindingEntity);
            }

            if (awvEchoTestResult.MitralMorphology != null)
            {
                awvEchoTestResult.MitralMorphology.ForEach(finding =>
                {
                    var customerEventTestStandardFindingEntity = new CustomerEventTestStandardFindingEntity()
                    {
                        StandardFindingTestReadingId =
                            (int?)new TestResultService().GetStandardFindingTestReadingIdForStandardFinding
                                ((int)TestType.AwvEcho, (int)ReadingLabels.MitralMorphology, Convert.ToInt64(finding.Id)),
                        CustomerEventTestStandardFindingId = finding.CustomerEventStandardFindingId,
                        CustomerEventScreeningTestId = testResult.Id
                    };
                    customerEventScreeningTestsEntity.CustomerEventTestStandardFinding.Add(customerEventTestStandardFindingEntity);
                });
            }

            if (awvEchoTestResult.PulmonicRegurgitation != null)
            {
                var customerEventTestStandardFindingEntity = new CustomerEventTestStandardFindingEntity()
                {
                    StandardFindingTestReadingId =
                        (int?)new TestResultService().GetStandardFindingTestReadingIdForStandardFinding
                            ((int)TestType.AwvEcho, (int)ReadingLabels.Pulmonic, Convert.ToInt64(awvEchoTestResult.PulmonicRegurgitation.Id)),
                    CustomerEventTestStandardFindingId = awvEchoTestResult.PulmonicRegurgitation.CustomerEventStandardFindingId,
                    CustomerEventScreeningTestId = testResult.Id
                };
                customerEventScreeningTestsEntity.CustomerEventTestStandardFinding.Add(customerEventTestStandardFindingEntity);
            }

            if (awvEchoTestResult.PulmonicMorphology != null)
            {
                awvEchoTestResult.PulmonicMorphology.ForEach(finding =>
                {
                    var customerEventTestStandardFindingEntity = new CustomerEventTestStandardFindingEntity()
                    {
                        StandardFindingTestReadingId =
                            (int?)new TestResultService().GetStandardFindingTestReadingIdForStandardFinding
                                ((int)TestType.AwvEcho, (int)ReadingLabels.PulmonicMorphology, Convert.ToInt64(finding.Id)),
                        CustomerEventTestStandardFindingId = finding.CustomerEventStandardFindingId,
                        CustomerEventScreeningTestId = testResult.Id
                    };
                    customerEventScreeningTestsEntity.CustomerEventTestStandardFinding.Add(customerEventTestStandardFindingEntity);
                });
            }

            if (awvEchoTestResult.TricuspidRegurgitation != null)
            {
                var customerEventTestStandardFindingEntity = new CustomerEventTestStandardFindingEntity()
                {
                    StandardFindingTestReadingId =
                        (int?)new TestResultService().GetStandardFindingTestReadingIdForStandardFinding
                            ((int)TestType.AwvEcho, (int)ReadingLabels.Tricuspid, Convert.ToInt64(awvEchoTestResult.TricuspidRegurgitation.Id)),
                    CustomerEventTestStandardFindingId = awvEchoTestResult.TricuspidRegurgitation.CustomerEventStandardFindingId,
                    CustomerEventScreeningTestId = testResult.Id
                };
                customerEventScreeningTestsEntity.CustomerEventTestStandardFinding.Add(customerEventTestStandardFindingEntity);
            }

            if (awvEchoTestResult.TricuspidMorphology != null)
            {
                awvEchoTestResult.TricuspidMorphology.ForEach(finding =>
                {
                    var customerEventTestStandardFindingEntity = new CustomerEventTestStandardFindingEntity()
                    {
                        StandardFindingTestReadingId =
                            (int?)new TestResultService().GetStandardFindingTestReadingIdForStandardFinding
                                ((int)TestType.AwvEcho, (int)ReadingLabels.TricuspidMorphology, Convert.ToInt64(finding.Id)),
                        CustomerEventTestStandardFindingId = finding.CustomerEventStandardFindingId,
                        CustomerEventScreeningTestId = testResult.Id
                    };
                    customerEventScreeningTestsEntity.CustomerEventTestStandardFinding.Add(customerEventTestStandardFindingEntity);
                });
            }

            if (awvEchoTestResult.DistolicDysfunctionFinding != null)
            {
                var customerEventTestStandardFindingEntity = new CustomerEventTestStandardFindingEntity()
                {
                    StandardFindingTestReadingId =
                        (int?)new TestResultService().GetStandardFindingTestReadingIdForStandardFinding
                            ((int)TestType.AwvEcho, (int)ReadingLabels.DiastolicDysfunction, Convert.ToInt64(awvEchoTestResult.DistolicDysfunctionFinding.Id)),
                    CustomerEventTestStandardFindingId = awvEchoTestResult.DistolicDysfunctionFinding.CustomerEventStandardFindingId,
                    CustomerEventScreeningTestId = testResult.Id
                };
                customerEventScreeningTestsEntity.CustomerEventTestStandardFinding.Add(customerEventTestStandardFindingEntity);
            }

            if (awvEchoTestResult.PericardialEffusionFinding != null)
            {
                awvEchoTestResult.PericardialEffusionFinding.ForEach(finding =>
                {
                    var customerEventTestStandardFindingEntity = new CustomerEventTestStandardFindingEntity()
                    {
                        StandardFindingTestReadingId =
                            (int?)new TestResultService().GetStandardFindingTestReadingIdForStandardFinding
                                ((int)TestType.AwvEcho, (int)ReadingLabels.PericardialEffusion, Convert.ToInt64(finding.Id)),
                        CustomerEventTestStandardFindingId = finding.CustomerEventStandardFindingId,
                        CustomerEventScreeningTestId = testResult.Id
                    };
                    customerEventScreeningTestsEntity.CustomerEventTestStandardFinding.Add(customerEventTestStandardFindingEntity);
                });
            }

            customerEventScreeningTestsEntity.CustomerEventReading.AddRange(customerEventReadingEntities);
            return customerEventScreeningTestsEntity;
        }

        private void SetLeftVentricleReadingData(List<OrderedPair<int, int>> testReadingReadingPairs, AwvEchocardiogramTestResult awvEchoTestResult, List<CustomerEventReadingEntity> customerEventReadingEntities)
        {
            if (awvEchoTestResult.LeftVentricleOverallFunctionNotEvaluated != null)
                customerEventReadingEntities.Add(CreateEventReadingEntity(awvEchoTestResult.LeftVentricleOverallFunctionNotEvaluated, (int)ReadingLabels.LeftVentricleOverallFunctionNotEvaluated, testReadingReadingPairs));
            if (awvEchoTestResult.LeftVentricleOverallFunctionNormal != null)
                customerEventReadingEntities.Add(CreateEventReadingEntity(awvEchoTestResult.LeftVentricleOverallFunctionNormal, (int)ReadingLabels.LeftVentricleOverallFunctionNormal, testReadingReadingPairs));
            if (awvEchoTestResult.LeftVentricleOverallFunctionReduced != null)
                customerEventReadingEntities.Add(CreateEventReadingEntity(awvEchoTestResult.LeftVentricleOverallFunctionReduced, (int)ReadingLabels.LeftVentricleOverallFunctionReduced, testReadingReadingPairs));
            if (awvEchoTestResult.LeftVentricleOverallFunctionBorderline != null)
                customerEventReadingEntities.Add(CreateEventReadingEntity(awvEchoTestResult.LeftVentricleOverallFunctionBorderline, (int)ReadingLabels.LeftVentricleOverallFunctionBorderline, testReadingReadingPairs));
            if (awvEchoTestResult.LeftVentricleOverallFunctionHyperkinesis != null)
                customerEventReadingEntities.Add(CreateEventReadingEntity(awvEchoTestResult.LeftVentricleOverallFunctionHyperkinesis, (int)ReadingLabels.LeftVentricleOverallFunctionHyperkinesis, testReadingReadingPairs));
            if (awvEchoTestResult.LeftVentricleOverallFunctionHypokinesis != null)
                customerEventReadingEntities.Add(CreateEventReadingEntity(awvEchoTestResult.LeftVentricleOverallFunctionHypokinesis, (int)ReadingLabels.LeftVentricleOverallFunctionHypokinesis, testReadingReadingPairs));
            if (awvEchoTestResult.LeftVentricleOverallFunctionConsistentLvSystolicFailure != null)
                customerEventReadingEntities.Add(CreateEventReadingEntity(awvEchoTestResult.LeftVentricleOverallFunctionConsistentLvSystolicFailure, (int)ReadingLabels.LeftVentricleOverallFunctionConsistentLvSystolicFailure, testReadingReadingPairs));

            if (awvEchoTestResult.LeftVentricleDimensionsNotEvaluated != null)
                customerEventReadingEntities.Add(CreateEventReadingEntity(awvEchoTestResult.LeftVentricleDimensionsNotEvaluated, (int)ReadingLabels.LeftVentricleDimensionsNotEvaluated, testReadingReadingPairs));
            if (awvEchoTestResult.LeftVentricleDimensionsNormal != null)
                customerEventReadingEntities.Add(CreateEventReadingEntity(awvEchoTestResult.LeftVentricleDimensionsNormal, (int)ReadingLabels.LeftVentricleDimensionsNormal, testReadingReadingPairs));
            if (awvEchoTestResult.LeftVentricleDimensionsSmall != null)
                customerEventReadingEntities.Add(CreateEventReadingEntity(awvEchoTestResult.LeftVentricleDimensionsSmall, (int)ReadingLabels.LeftVentricleDimensionsSmall, testReadingReadingPairs));
            if (awvEchoTestResult.LeftVentricleDimensionsDilated != null)
                customerEventReadingEntities.Add(CreateEventReadingEntity(awvEchoTestResult.LeftVentricleDimensionsDilated, (int)ReadingLabels.LeftVentricleDimensionsDilated, testReadingReadingPairs));
            if (awvEchoTestResult.LeftVentricleDimensionsSlightlyEnlarged != null)
                customerEventReadingEntities.Add(CreateEventReadingEntity(awvEchoTestResult.LeftVentricleDimensionsSlightlyEnlarged, (int)ReadingLabels.LeftVentricleDimensionsSlightlyEnlarged, testReadingReadingPairs));
            if (awvEchoTestResult.LeftVentricleDimensionsSeverelyDilated != null)
                customerEventReadingEntities.Add(CreateEventReadingEntity(awvEchoTestResult.LeftVentricleDimensionsSeverelyDilated, (int)ReadingLabels.LeftVentricleDimensionsSeverelyDilated, testReadingReadingPairs));

            if (awvEchoTestResult.LeftVentricleThicknessesNotEvaluated != null)
                customerEventReadingEntities.Add(CreateEventReadingEntity(awvEchoTestResult.LeftVentricleThicknessesNotEvaluated, (int)ReadingLabels.LeftVentricleThicknessesNotEvaluated, testReadingReadingPairs));
            if (awvEchoTestResult.LeftVentricleThicknessesNormal != null)
                customerEventReadingEntities.Add(CreateEventReadingEntity(awvEchoTestResult.LeftVentricleThicknessesNormal, (int)ReadingLabels.LeftVentricleThicknessesNormal, testReadingReadingPairs));
            if (awvEchoTestResult.LeftVentricleThicknessesApicalHypertrophy != null)
                customerEventReadingEntities.Add(CreateEventReadingEntity(awvEchoTestResult.LeftVentricleThicknessesApicalHypertrophy, (int)ReadingLabels.LeftVentricleThicknessesApicalHypertrophy, testReadingReadingPairs));
            if (awvEchoTestResult.LeftVentricleThicknessesAsymmetricalHypertrophy != null)
                customerEventReadingEntities.Add(CreateEventReadingEntity(awvEchoTestResult.LeftVentricleThicknessesAsymmetricalHypertrophy, (int)ReadingLabels.LeftVentricleThicknessesAsymmetricalHypertrophy, testReadingReadingPairs));
            if (awvEchoTestResult.LeftVentricleThicknessesIVSeptumObstructiveHypertrophy != null)
                customerEventReadingEntities.Add(CreateEventReadingEntity(awvEchoTestResult.LeftVentricleThicknessesIVSeptumObstructiveHypertrophy, (int)ReadingLabels.LeftVentricleThicknessesIVSeptumObstructiveHypertrophy, testReadingReadingPairs));
            if (awvEchoTestResult.LeftVentricleThicknessesMinorModerateIVSeptumHypertrophy != null)
                customerEventReadingEntities.Add(CreateEventReadingEntity(awvEchoTestResult.LeftVentricleThicknessesMinorModerateIVSeptumHypertrophy, (int)ReadingLabels.LeftVentricleThicknessesMinorModerateIVSeptumHypertrophy, testReadingReadingPairs));
            if (awvEchoTestResult.LeftVentricleThicknessesSevereIVSeptumHypertrophy != null)
                customerEventReadingEntities.Add(CreateEventReadingEntity(awvEchoTestResult.LeftVentricleThicknessesSevereIVSeptumHypertrophy, (int)ReadingLabels.LeftVentricleThicknessesSevereIVSeptumHypertrophy, testReadingReadingPairs));
            if (awvEchoTestResult.LeftVentricleThicknessesMinorModerateSymmetricHypertrophy != null)
                customerEventReadingEntities.Add(CreateEventReadingEntity(awvEchoTestResult.LeftVentricleThicknessesMinorModerateSymmetricHypertrophy, (int)ReadingLabels.LeftVentricleThicknessesMinorModerateSymmetricHypertrophy, testReadingReadingPairs));
            if (awvEchoTestResult.LeftVentricleThicknessesSevereSymmetricHypertrophy != null)
                customerEventReadingEntities.Add(CreateEventReadingEntity(awvEchoTestResult.LeftVentricleThicknessesSevereSymmetricHypertrophy, (int)ReadingLabels.LeftVentricleThicknessesSevereSymmetricHypertrophy, testReadingReadingPairs));

            if (awvEchoTestResult.LeftVentricleComment != null)
                customerEventReadingEntities.Add(CreateEventReadingEntity(awvEchoTestResult.LeftVentricleComment, (int)ReadingLabels.LeftVentricleComment, testReadingReadingPairs));
        }

        private void SetLeftAtriumReadingData(List<OrderedPair<int, int>> testReadingReadingPairs, AwvEchocardiogramTestResult awvEchoTestResult, List<CustomerEventReadingEntity> customerEventReadingEntities)
        {
            if (awvEchoTestResult.LeftAtriumIASLADimensionsNotEvaluated != null)
                customerEventReadingEntities.Add(CreateEventReadingEntity(awvEchoTestResult.LeftAtriumIASLADimensionsNotEvaluated, (int)ReadingLabels.LeftAtriumIASLADimensionsNotEvaluated, testReadingReadingPairs));

            if (awvEchoTestResult.LeftAtriumIASLADimensionsNormal != null)
                customerEventReadingEntities.Add(CreateEventReadingEntity(awvEchoTestResult.LeftAtriumIASLADimensionsNormal, (int)ReadingLabels.LeftAtriumIASLADimensionsNormal, testReadingReadingPairs));

            if (awvEchoTestResult.LeftAtriumIASLADimensionsMildlyDilated != null)
                customerEventReadingEntities.Add(CreateEventReadingEntity(awvEchoTestResult.LeftAtriumIASLADimensionsMildlyDilated, (int)ReadingLabels.LeftAtriumIASLADimensionsMildlyDilated, testReadingReadingPairs));

            if (awvEchoTestResult.LeftAtriumIASLADimensionsModeratelyDilated != null)
                customerEventReadingEntities.Add(CreateEventReadingEntity(awvEchoTestResult.LeftAtriumIASLADimensionsModeratelyDilated, (int)ReadingLabels.LeftAtriumIASLADimensionsModeratelyDilated, testReadingReadingPairs));

            if (awvEchoTestResult.LeftAtriumIASLADimensionsSeverelyDilated != null)
                customerEventReadingEntities.Add(CreateEventReadingEntity(awvEchoTestResult.LeftAtriumIASLADimensionsSeverelyDilated, (int)ReadingLabels.LeftAtriumIASLADimensionsSeverelyDilated, testReadingReadingPairs));

            if (awvEchoTestResult.LeftAtriumIASComment != null)
                customerEventReadingEntities.Add(CreateEventReadingEntity(awvEchoTestResult.LeftAtriumIASComment, (int)ReadingLabels.LeftAtriumIASComment, testReadingReadingPairs));
        }

        private void SetRightVentricleReadingData(List<OrderedPair<int, int>> testReadingReadingPairs, AwvEchocardiogramTestResult awvEchoTestResult, List<CustomerEventReadingEntity> customerEventReadingEntities)
        {
            if (awvEchoTestResult.RightVentricleOverallFunctionNotEvaluated != null)
                customerEventReadingEntities.Add(CreateEventReadingEntity(awvEchoTestResult.RightVentricleOverallFunctionNotEvaluated, (int)ReadingLabels.RightVentricleOverallFunctionNotEvaluated, testReadingReadingPairs));
            if (awvEchoTestResult.RightVentricleOverallFunctionNormal != null)
                customerEventReadingEntities.Add(CreateEventReadingEntity(awvEchoTestResult.RightVentricleOverallFunctionNormal, (int)ReadingLabels.RightVentricleOverallFunctionNormal, testReadingReadingPairs));
            if (awvEchoTestResult.RightVentricleOverallFunctionReduced != null)
                customerEventReadingEntities.Add(CreateEventReadingEntity(awvEchoTestResult.RightVentricleOverallFunctionReduced, (int)ReadingLabels.RightVentricleOverallFunctionReduced, testReadingReadingPairs));
            if (awvEchoTestResult.RightVentricleOverallFunctionBorderline != null)
                customerEventReadingEntities.Add(CreateEventReadingEntity(awvEchoTestResult.RightVentricleOverallFunctionBorderline, (int)ReadingLabels.RightVentricleOverallFunctionBorderline, testReadingReadingPairs));
            if (awvEchoTestResult.RightVentricleOverallFunctionHyperkinesis != null)
                customerEventReadingEntities.Add(CreateEventReadingEntity(awvEchoTestResult.RightVentricleOverallFunctionHyperkinesis, (int)ReadingLabels.RightVentricleOverallFunctionHyperkinesis, testReadingReadingPairs));
            if (awvEchoTestResult.RightVentricleOverallFunctionHypokinesis != null)
                customerEventReadingEntities.Add(CreateEventReadingEntity(awvEchoTestResult.RightVentricleOverallFunctionHypokinesis, (int)ReadingLabels.RightVentricleOverallFunctionHypokinesis, testReadingReadingPairs));

            if (awvEchoTestResult.RightVentricleDimensionsNotEvaluated != null)
                customerEventReadingEntities.Add(CreateEventReadingEntity(awvEchoTestResult.RightVentricleDimensionsNotEvaluated, (int)ReadingLabels.RightVentricleDimensionsNotEvaluated, testReadingReadingPairs));
            if (awvEchoTestResult.RightVentricleDimensionsNormal != null)
                customerEventReadingEntities.Add(CreateEventReadingEntity(awvEchoTestResult.RightVentricleDimensionsNormal, (int)ReadingLabels.RightVentricleDimensionsNormal, testReadingReadingPairs));
            if (awvEchoTestResult.RightVentricleDimensionsSmall != null)
                customerEventReadingEntities.Add(CreateEventReadingEntity(awvEchoTestResult.RightVentricleDimensionsSmall, (int)ReadingLabels.RightVentricleDimensionsSmall, testReadingReadingPairs));
            if (awvEchoTestResult.RightVentricleDimensionsDilated != null)
                customerEventReadingEntities.Add(CreateEventReadingEntity(awvEchoTestResult.RightVentricleDimensionsDilated, (int)ReadingLabels.RightVentricleDimensionsDilated, testReadingReadingPairs));
            if (awvEchoTestResult.RightVentricleDimensionsSlightlyEnlarged != null)
                customerEventReadingEntities.Add(CreateEventReadingEntity(awvEchoTestResult.RightVentricleDimensionsSlightlyEnlarged, (int)ReadingLabels.RightVentricleDimensionsSlightlyEnlarged, testReadingReadingPairs));
            if (awvEchoTestResult.RightVentricleDimensionsSeverelyDilated != null)
                customerEventReadingEntities.Add(CreateEventReadingEntity(awvEchoTestResult.RightVentricleDimensionsSeverelyDilated, (int)ReadingLabels.RightVentricleDimensionsSeverelyDilated, testReadingReadingPairs));

            if (awvEchoTestResult.RightVentricleThicknessesNotEvaluated != null)
                customerEventReadingEntities.Add(CreateEventReadingEntity(awvEchoTestResult.RightVentricleThicknessesNotEvaluated, (int)ReadingLabels.RightVentricleThicknessesNotEvaluated, testReadingReadingPairs));
            if (awvEchoTestResult.RightVentricleThicknessesNormal != null)
                customerEventReadingEntities.Add(CreateEventReadingEntity(awvEchoTestResult.RightVentricleThicknessesNormal, (int)ReadingLabels.RightVentricleThicknessesNormal, testReadingReadingPairs));
            if (awvEchoTestResult.RightVentricleThicknessesApicalHypertrophy != null)
                customerEventReadingEntities.Add(CreateEventReadingEntity(awvEchoTestResult.RightVentricleThicknessesApicalHypertrophy, (int)ReadingLabels.RightVentricleThicknessesApicalHypertrophy, testReadingReadingPairs));
            if (awvEchoTestResult.RightVentricleThicknessesAsymmetricalHypertrophy != null)
                customerEventReadingEntities.Add(CreateEventReadingEntity(awvEchoTestResult.RightVentricleThicknessesAsymmetricalHypertrophy, (int)ReadingLabels.RightVentricleThicknessesAsymmetricalHypertrophy, testReadingReadingPairs));
            if (awvEchoTestResult.RightVentricleThicknessesIVSeptumObstructiveHypertrophy != null)
                customerEventReadingEntities.Add(CreateEventReadingEntity(awvEchoTestResult.RightVentricleThicknessesIVSeptumObstructiveHypertrophy, (int)ReadingLabels.RightVentricleThicknessesIVSeptumObstructiveHypertrophy, testReadingReadingPairs));
            if (awvEchoTestResult.RightVentricleThicknessesMinorModerateIVSeptumHypertrophy != null)
                customerEventReadingEntities.Add(CreateEventReadingEntity(awvEchoTestResult.RightVentricleThicknessesMinorModerateIVSeptumHypertrophy, (int)ReadingLabels.RightVentricleThicknessesMinorModerateIVSeptumHypertrophy, testReadingReadingPairs));
            if (awvEchoTestResult.RightVentricleThicknessesSevereIVSeptumHypertrophy != null)
                customerEventReadingEntities.Add(CreateEventReadingEntity(awvEchoTestResult.RightVentricleThicknessesSevereIVSeptumHypertrophy, (int)ReadingLabels.RightVentricleThicknessesSevereIVSeptumHypertrophy, testReadingReadingPairs));
            if (awvEchoTestResult.RightVentricleThicknessesMinorModerateSymmetricHypertrophy != null)
                customerEventReadingEntities.Add(CreateEventReadingEntity(awvEchoTestResult.RightVentricleThicknessesMinorModerateSymmetricHypertrophy, (int)ReadingLabels.RightVentricleThicknessesMinorModerateSymmetricHypertrophy, testReadingReadingPairs));
            if (awvEchoTestResult.RightVentricleThicknessesSevereSymmetricHypertrophy != null)
                customerEventReadingEntities.Add(CreateEventReadingEntity(awvEchoTestResult.RightVentricleThicknessesSevereSymmetricHypertrophy, (int)ReadingLabels.RightVentricleThicknessesSevereSymmetricHypertrophy, testReadingReadingPairs));

            if (awvEchoTestResult.RightVentricleComment != null)
                customerEventReadingEntities.Add(CreateEventReadingEntity(awvEchoTestResult.RightVentricleComment, (int)ReadingLabels.RightVentricleComment, testReadingReadingPairs));
        }

        private void SetRightAtriumReadingData(List<OrderedPair<int, int>> testReadingReadingPairs, AwvEchocardiogramTestResult awvEchoTestResult, List<CustomerEventReadingEntity> customerEventReadingEntities)
        {
            if (awvEchoTestResult.RightAtriumRADimensionsNotEvaluated != null)
                customerEventReadingEntities.Add(CreateEventReadingEntity(awvEchoTestResult.RightAtriumRADimensionsNotEvaluated, (int)ReadingLabels.RightAtriumRADimensionsNotEvaluated, testReadingReadingPairs));
            if (awvEchoTestResult.RightAtriumRADimensionsNormal != null)
                customerEventReadingEntities.Add(CreateEventReadingEntity(awvEchoTestResult.RightAtriumRADimensionsNormal, (int)ReadingLabels.RightAtriumRADimensionsNormal, testReadingReadingPairs));
            if (awvEchoTestResult.RightAtriumRADimensionsMildlyDilated != null)
                customerEventReadingEntities.Add(CreateEventReadingEntity(awvEchoTestResult.RightAtriumRADimensionsMildlyDilated, (int)ReadingLabels.RightAtriumRADimensionsMildlyDilated, testReadingReadingPairs));
            if (awvEchoTestResult.RightAtriumRADimensionsModeratelyDilated != null)
                customerEventReadingEntities.Add(CreateEventReadingEntity(awvEchoTestResult.RightAtriumRADimensionsModeratelyDilated, (int)ReadingLabels.RightAtriumRADimensionsModeratelyDilated, testReadingReadingPairs));
            if (awvEchoTestResult.RightAtriumRADimensionsSeverelyDilated != null)
                customerEventReadingEntities.Add(CreateEventReadingEntity(awvEchoTestResult.RightAtriumRADimensionsSeverelyDilated, (int)ReadingLabels.RightAtriumRADimensionsSeverelyDilated, testReadingReadingPairs));

            if (awvEchoTestResult.RightAtriumComment != null)
                customerEventReadingEntities.Add(CreateEventReadingEntity(awvEchoTestResult.RightAtriumComment, (int)ReadingLabels.RightAtriumComment, testReadingReadingPairs));
        }

        private void SetAortaReadingData(List<OrderedPair<int, int>> testReadingReadingPairs, AwvEchocardiogramTestResult awvEchoTestResult, List<CustomerEventReadingEntity> customerEventReadingEntities)
        {
            if (awvEchoTestResult.AortaInsufficiencyAbsent != null)
                customerEventReadingEntities.Add(CreateEventReadingEntity(awvEchoTestResult.AortaInsufficiencyAbsent, (int)ReadingLabels.AortaInsufficiencyAbsent, testReadingReadingPairs));
            if (awvEchoTestResult.AortaInsufficiencyMinor != null)
                customerEventReadingEntities.Add(CreateEventReadingEntity(awvEchoTestResult.AortaInsufficiencyMinor, (int)ReadingLabels.AortaInsufficiencyMinor, testReadingReadingPairs));
            if (awvEchoTestResult.AortaInsufficiencyModerate != null)
                customerEventReadingEntities.Add(CreateEventReadingEntity(awvEchoTestResult.AortaInsufficiencyModerate, (int)ReadingLabels.AortaInsufficiencyModerate, testReadingReadingPairs));
            if (awvEchoTestResult.AortaInsufficiencySevere != null)
                customerEventReadingEntities.Add(CreateEventReadingEntity(awvEchoTestResult.AortaInsufficiencySevere, (int)ReadingLabels.AortaInsufficiencySevere, testReadingReadingPairs));

            if (awvEchoTestResult.AortaLeafletsNotEvaluated != null)
                customerEventReadingEntities.Add(CreateEventReadingEntity(awvEchoTestResult.AortaLeafletsNotEvaluated, (int)ReadingLabels.AortaLeafletsNotEvaluated, testReadingReadingPairs));
            if (awvEchoTestResult.AortaLeafletsNormal != null)
                customerEventReadingEntities.Add(CreateEventReadingEntity(awvEchoTestResult.AortaLeafletsNormal, (int)ReadingLabels.AortaLeafletsNormal, testReadingReadingPairs));
            if (awvEchoTestResult.AortaLeafletsMildStenosis != null)
                customerEventReadingEntities.Add(CreateEventReadingEntity(awvEchoTestResult.AortaLeafletsMildStenosis, (int)ReadingLabels.AortaLeafletsMildStenosis, testReadingReadingPairs));
            if (awvEchoTestResult.AortaLeafletsModerateStenosis != null)
                customerEventReadingEntities.Add(CreateEventReadingEntity(awvEchoTestResult.AortaLeafletsModerateStenosis, (int)ReadingLabels.AortaLeafletsModerateStenosis, testReadingReadingPairs));
            if (awvEchoTestResult.AortaLeafletsSevereStenosis != null)
                customerEventReadingEntities.Add(CreateEventReadingEntity(awvEchoTestResult.AortaLeafletsSevereStenosis, (int)ReadingLabels.AortaLeafletsSevereStenosis, testReadingReadingPairs));

            if (awvEchoTestResult.AortaValveNotEvaluated != null)
                customerEventReadingEntities.Add(CreateEventReadingEntity(awvEchoTestResult.AortaValveNotEvaluated, (int)ReadingLabels.AortaValveNotEvaluated, testReadingReadingPairs));
            if (awvEchoTestResult.AortaValveBicuspid != null)
                customerEventReadingEntities.Add(CreateEventReadingEntity(awvEchoTestResult.AortaValveBicuspid, (int)ReadingLabels.AortaValveBicuspid, testReadingReadingPairs));
            if (awvEchoTestResult.AortaValveAtherosclerotic != null)
                customerEventReadingEntities.Add(CreateEventReadingEntity(awvEchoTestResult.AortaValveAtherosclerotic, (int)ReadingLabels.AortaValveAtherosclerotic, testReadingReadingPairs));
            if (awvEchoTestResult.AortaValveNormalFunctioningBiologicalProsthesis != null)
                customerEventReadingEntities.Add(CreateEventReadingEntity(awvEchoTestResult.AortaValveNormalFunctioningBiologicalProsthesis, (int)ReadingLabels.AortaValveNormalFunctioningBiologicalProsthesis, testReadingReadingPairs));
            if (awvEchoTestResult.AortaValveNormalFunctioningMechanicalProsthesis != null)
                customerEventReadingEntities.Add(CreateEventReadingEntity(awvEchoTestResult.AortaValveNormalFunctioningMechanicalProsthesis, (int)ReadingLabels.AortaValveNormalFunctioningMechanicalProsthesis, testReadingReadingPairs));
            if (awvEchoTestResult.AortaValveMalfunctioningBiologicalProsthesis != null)
                customerEventReadingEntities.Add(CreateEventReadingEntity(awvEchoTestResult.AortaValveMalfunctioningBiologicalProsthesis, (int)ReadingLabels.AortaValveMalfunctioningBiologicalProsthesis, testReadingReadingPairs));
            if (awvEchoTestResult.AortaValveMalfunctioningMechanicalProsthesis != null)
                customerEventReadingEntities.Add(CreateEventReadingEntity(awvEchoTestResult.AortaValveMalfunctioningMechanicalProsthesis, (int)ReadingLabels.AortaValveMalfunctioningMechanicalProsthesis, testReadingReadingPairs));
            if (awvEchoTestResult.AortaValveDilatedAorticRoot != null)
                customerEventReadingEntities.Add(CreateEventReadingEntity(awvEchoTestResult.AortaValveDilatedAorticRoot, (int)ReadingLabels.AortaValveDilatedAorticRoot, testReadingReadingPairs));
            if (awvEchoTestResult.AortaValveSinusValsalvaAneurysm != null)
                customerEventReadingEntities.Add(CreateEventReadingEntity(awvEchoTestResult.AortaValveSinusValsalvaAneurysm, (int)ReadingLabels.AortaValveSinusValsalvaAneurysm, testReadingReadingPairs));
            if (awvEchoTestResult.AortaComment != null)
                customerEventReadingEntities.Add(CreateEventReadingEntity(awvEchoTestResult.AortaComment, (int)ReadingLabels.AortaComment, testReadingReadingPairs));
        }

        private void SetMitralReadingData(List<OrderedPair<int, int>> testReadingReadingPairs, AwvEchocardiogramTestResult awvEchoTestResult, List<CustomerEventReadingEntity> customerEventReadingEntities)
        {
            if (awvEchoTestResult.MitralInsufficiencyAbsent != null)
                customerEventReadingEntities.Add(CreateEventReadingEntity(awvEchoTestResult.MitralInsufficiencyAbsent, (int)ReadingLabels.MitralInsufficiencyAbsent, testReadingReadingPairs));
            if (awvEchoTestResult.MitralInsufficiencyMinor != null)
                customerEventReadingEntities.Add(CreateEventReadingEntity(awvEchoTestResult.MitralInsufficiencyMinor, (int)ReadingLabels.MitralInsufficiencyMinor, testReadingReadingPairs));
            if (awvEchoTestResult.MitralInsufficiencyModerate != null)
                customerEventReadingEntities.Add(CreateEventReadingEntity(awvEchoTestResult.MitralInsufficiencyModerate, (int)ReadingLabels.MitralInsufficiencyModerate, testReadingReadingPairs));
            if (awvEchoTestResult.MitralInsufficiencySevere != null)
                customerEventReadingEntities.Add(CreateEventReadingEntity(awvEchoTestResult.MitralInsufficiencySevere, (int)ReadingLabels.MitralInsufficiencySevere, testReadingReadingPairs));

            if (awvEchoTestResult.MitralLeafletsNotEvaluated != null)
                customerEventReadingEntities.Add(CreateEventReadingEntity(awvEchoTestResult.MitralLeafletsNotEvaluated, (int)ReadingLabels.MitralLeafletsNotEvaluated, testReadingReadingPairs));
            if (awvEchoTestResult.MitralLeafletsNormal != null)
                customerEventReadingEntities.Add(CreateEventReadingEntity(awvEchoTestResult.MitralLeafletsNormal, (int)ReadingLabels.MitralLeafletsNormal, testReadingReadingPairs));
            if (awvEchoTestResult.MitralLeafletsRedundant != null)
                customerEventReadingEntities.Add(CreateEventReadingEntity(awvEchoTestResult.MitralLeafletsRedundant, (int)ReadingLabels.MitralLeafletsRedundant, testReadingReadingPairs));
            if (awvEchoTestResult.MitralLeafletsMildStenosis != null)
                customerEventReadingEntities.Add(CreateEventReadingEntity(awvEchoTestResult.MitralLeafletsMildStenosis, (int)ReadingLabels.MitralLeafletsMildStenosis, testReadingReadingPairs));
            if (awvEchoTestResult.MitralLeafletsModerateStenosis != null)
                customerEventReadingEntities.Add(CreateEventReadingEntity(awvEchoTestResult.MitralLeafletsModerateStenosis, (int)ReadingLabels.MitralLeafletsModerateStenosis, testReadingReadingPairs));
            if (awvEchoTestResult.MitralLeafletsSevereStenosis != null)
                customerEventReadingEntities.Add(CreateEventReadingEntity(awvEchoTestResult.MitralLeafletsSevereStenosis, (int)ReadingLabels.MitralLeafletsSevereStenosis, testReadingReadingPairs));

            if (awvEchoTestResult.MitralValveNotEvaluated != null)
                customerEventReadingEntities.Add(CreateEventReadingEntity(awvEchoTestResult.MitralValveNotEvaluated, (int)ReadingLabels.MitralValveNotEvaluated, testReadingReadingPairs));
            if (awvEchoTestResult.MitralValveBicuspid != null)
                customerEventReadingEntities.Add(CreateEventReadingEntity(awvEchoTestResult.MitralValveBicuspid, (int)ReadingLabels.MitralValveBicuspid, testReadingReadingPairs));
            if (awvEchoTestResult.MitralValveAtherosclerotic != null)
                customerEventReadingEntities.Add(CreateEventReadingEntity(awvEchoTestResult.MitralValveAtherosclerotic, (int)ReadingLabels.MitralValveAtherosclerotic, testReadingReadingPairs));
            if (awvEchoTestResult.MitralValveNormalFunctioningBiologicalProsthesis != null)
                customerEventReadingEntities.Add(CreateEventReadingEntity(awvEchoTestResult.MitralValveNormalFunctioningBiologicalProsthesis, (int)ReadingLabels.MitralValveNormalFunctioningBiologicalProsthesis, testReadingReadingPairs));
            if (awvEchoTestResult.MitralValveNormalFunctioningMechanicalProsthesis != null)
                customerEventReadingEntities.Add(CreateEventReadingEntity(awvEchoTestResult.MitralValveNormalFunctioningMechanicalProsthesis, (int)ReadingLabels.MitralValveNormalFunctioningMechanicalProsthesis, testReadingReadingPairs));
            if (awvEchoTestResult.MitralValveMalfunctioningBiologicalProsthesis != null)
                customerEventReadingEntities.Add(CreateEventReadingEntity(awvEchoTestResult.MitralValveMalfunctioningBiologicalProsthesis, (int)ReadingLabels.MitralValveMalfunctioningBiologicalProsthesis, testReadingReadingPairs));
            if (awvEchoTestResult.MitralValveMalfunctioningMechanicalProsthesis != null)
                customerEventReadingEntities.Add(CreateEventReadingEntity(awvEchoTestResult.MitralValveMalfunctioningMechanicalProsthesis, (int)ReadingLabels.MitralValveMalfunctioningMechanicalProsthesis, testReadingReadingPairs));

            if (awvEchoTestResult.MitralValveComment != null)
                customerEventReadingEntities.Add(CreateEventReadingEntity(awvEchoTestResult.MitralValveComment, (int)ReadingLabels.MitralValveComment, testReadingReadingPairs));
        }

        private void SetPulmonaryReadingData(List<OrderedPair<int, int>> testReadingReadingPairs, AwvEchocardiogramTestResult awvEchoTestResult, List<CustomerEventReadingEntity> customerEventReadingEntities)
        {
            if (awvEchoTestResult.PulmonaryInsufficiencyAbsent != null)
                customerEventReadingEntities.Add(CreateEventReadingEntity(awvEchoTestResult.PulmonaryInsufficiencyAbsent, (int)ReadingLabels.PulmonaryInsufficiencyAbsent, testReadingReadingPairs));
            if (awvEchoTestResult.PulmonaryInsufficiencyMinor != null)
                customerEventReadingEntities.Add(CreateEventReadingEntity(awvEchoTestResult.PulmonaryInsufficiencyMinor, (int)ReadingLabels.PulmonaryInsufficiencyMinor, testReadingReadingPairs));
            if (awvEchoTestResult.PulmonaryInsufficiencyModerate != null)
                customerEventReadingEntities.Add(CreateEventReadingEntity(awvEchoTestResult.PulmonaryInsufficiencyModerate, (int)ReadingLabels.PulmonaryInsufficiencyModerate, testReadingReadingPairs));
            if (awvEchoTestResult.PulmonaryInsufficiencySevere != null)
                customerEventReadingEntities.Add(CreateEventReadingEntity(awvEchoTestResult.PulmonaryInsufficiencySevere, (int)ReadingLabels.PulmonaryInsufficiencySevere, testReadingReadingPairs));

            if (awvEchoTestResult.PulmonaryLeafletsNormal != null)
                customerEventReadingEntities.Add(CreateEventReadingEntity(awvEchoTestResult.PulmonaryLeafletsNormal, (int)ReadingLabels.PulmonaryLeafletsNormal, testReadingReadingPairs));
            if (awvEchoTestResult.PulmonaryLeafletsThickened != null)
                customerEventReadingEntities.Add(CreateEventReadingEntity(awvEchoTestResult.PulmonaryLeafletsThickened, (int)ReadingLabels.PulmonaryLeafletsThickened, testReadingReadingPairs));
            if (awvEchoTestResult.PulmonaryLeafletsStenotic != null)
                customerEventReadingEntities.Add(CreateEventReadingEntity(awvEchoTestResult.PulmonaryLeafletsStenotic, (int)ReadingLabels.PulmonaryLeafletsStenotic, testReadingReadingPairs));
            if (awvEchoTestResult.PulmonaryLeafletsMildStenosis != null)
                customerEventReadingEntities.Add(CreateEventReadingEntity(awvEchoTestResult.PulmonaryLeafletsMildStenosis, (int)ReadingLabels.PulmonaryLeafletsMildStenosis, testReadingReadingPairs));
            if (awvEchoTestResult.PulmonaryLeafletsModerateStenosis != null)
                customerEventReadingEntities.Add(CreateEventReadingEntity(awvEchoTestResult.PulmonaryLeafletsModerateStenosis, (int)ReadingLabels.PulmonaryLeafletsModerateStenosis, testReadingReadingPairs));
            if (awvEchoTestResult.PulmonaryLeafletsSevereStenosis != null)
                customerEventReadingEntities.Add(CreateEventReadingEntity(awvEchoTestResult.PulmonaryLeafletsSevereStenosis, (int)ReadingLabels.PulmonaryLeafletsSevereStenosis, testReadingReadingPairs));

            if (awvEchoTestResult.PulmonaryValveNotEvaluated != null)
                customerEventReadingEntities.Add(CreateEventReadingEntity(awvEchoTestResult.PulmonaryValveNotEvaluated, (int)ReadingLabels.PulmonaryValveNotEvaluated, testReadingReadingPairs));
            if (awvEchoTestResult.PulmonaryValveBicuspid != null)
                customerEventReadingEntities.Add(CreateEventReadingEntity(awvEchoTestResult.PulmonaryValveBicuspid, (int)ReadingLabels.PulmonaryValveBicuspid, testReadingReadingPairs));
            if (awvEchoTestResult.PulmonaryValveAtherosclerotic != null)
                customerEventReadingEntities.Add(CreateEventReadingEntity(awvEchoTestResult.PulmonaryValveAtherosclerotic, (int)ReadingLabels.PulmonaryValveAtherosclerotic, testReadingReadingPairs));
            if (awvEchoTestResult.PulmonaryValveNormalFunctioningBiologicalProsthesis != null)
                customerEventReadingEntities.Add(CreateEventReadingEntity(awvEchoTestResult.PulmonaryValveNormalFunctioningBiologicalProsthesis, (int)ReadingLabels.PulmonaryValveNormalFunctioningBiologicalProsthesis, testReadingReadingPairs));
            if (awvEchoTestResult.PulmonaryValveNormalFunctioningMechanicalProsthesis != null)
                customerEventReadingEntities.Add(CreateEventReadingEntity(awvEchoTestResult.PulmonaryValveNormalFunctioningMechanicalProsthesis, (int)ReadingLabels.PulmonaryValveNormalFunctioningMechanicalProsthesis, testReadingReadingPairs));
            if (awvEchoTestResult.PulmonaryValveMalfunctioningBiologicalProsthesis != null)
                customerEventReadingEntities.Add(CreateEventReadingEntity(awvEchoTestResult.PulmonaryValveMalfunctioningBiologicalProsthesis, (int)ReadingLabels.PulmonaryValveMalfunctioningBiologicalProsthesis, testReadingReadingPairs));
            if (awvEchoTestResult.PulmonaryValveMalfunctioningMechanicalProsthesis != null)
                customerEventReadingEntities.Add(CreateEventReadingEntity(awvEchoTestResult.PulmonaryValveMalfunctioningMechanicalProsthesis, (int)ReadingLabels.PulmonaryValveMalfunctioningMechanicalProsthesis, testReadingReadingPairs));



            if (awvEchoTestResult.PulmonaryComment != null)
                customerEventReadingEntities.Add(CreateEventReadingEntity(awvEchoTestResult.PulmonaryComment, (int)ReadingLabels.PulmonaryComment, testReadingReadingPairs));
        }

        private void SetTricuspidReadingData(List<OrderedPair<int, int>> testReadingReadingPairs, AwvEchocardiogramTestResult awvEchoTestResult, List<CustomerEventReadingEntity> customerEventReadingEntities)
        {
            if (awvEchoTestResult.TricuspidInsufficiencyAbsent != null)
                customerEventReadingEntities.Add(CreateEventReadingEntity(awvEchoTestResult.TricuspidInsufficiencyAbsent, (int)ReadingLabels.TricuspidInsufficiencyAbsent, testReadingReadingPairs));
            if (awvEchoTestResult.TricuspidInsufficiencyMinor != null)
                customerEventReadingEntities.Add(CreateEventReadingEntity(awvEchoTestResult.TricuspidInsufficiencyMinor, (int)ReadingLabels.TricuspidInsufficiencyMinor, testReadingReadingPairs));
            if (awvEchoTestResult.TricuspidInsufficiencyModerate != null)
                customerEventReadingEntities.Add(CreateEventReadingEntity(awvEchoTestResult.TricuspidInsufficiencyModerate, (int)ReadingLabels.TricuspidInsufficiencyModerate, testReadingReadingPairs));
            if (awvEchoTestResult.TricuspidInsufficiencySevere != null)
                customerEventReadingEntities.Add(CreateEventReadingEntity(awvEchoTestResult.TricuspidInsufficiencySevere, (int)ReadingLabels.TricuspidInsufficiencySevere, testReadingReadingPairs));

            if (awvEchoTestResult.TricuspidLeafletsNormal != null)
                customerEventReadingEntities.Add(CreateEventReadingEntity(awvEchoTestResult.TricuspidLeafletsNormal, (int)ReadingLabels.TricuspidLeafletsNormal, testReadingReadingPairs));
            if (awvEchoTestResult.TricuspidLeafletsThickened != null)
                customerEventReadingEntities.Add(CreateEventReadingEntity(awvEchoTestResult.TricuspidLeafletsThickened, (int)ReadingLabels.TricuspidLeafletsThickened, testReadingReadingPairs));
            if (awvEchoTestResult.TricuspidLeafletsRedundant != null)
                customerEventReadingEntities.Add(CreateEventReadingEntity(awvEchoTestResult.TricuspidLeafletsRedundant, (int)ReadingLabels.TricuspidLeafletsRedundant, testReadingReadingPairs));
            if (awvEchoTestResult.TricuspidLeafletsMildStenosis != null)
                customerEventReadingEntities.Add(CreateEventReadingEntity(awvEchoTestResult.TricuspidLeafletsMildStenosis, (int)ReadingLabels.TricuspidLeafletsMildStenosis, testReadingReadingPairs));
            if (awvEchoTestResult.TricuspidLeafletsModerateStenosis != null)
                customerEventReadingEntities.Add(CreateEventReadingEntity(awvEchoTestResult.TricuspidLeafletsModerateStenosis, (int)ReadingLabels.TricuspidLeafletsModerateStenosis, testReadingReadingPairs));
            if (awvEchoTestResult.TricuspidLeafletsSevereStenosis != null)
                customerEventReadingEntities.Add(CreateEventReadingEntity(awvEchoTestResult.TricuspidLeafletsSevereStenosis, (int)ReadingLabels.TricuspidLeafletsSevereStenosis, testReadingReadingPairs));

            if (awvEchoTestResult.TricuspidValveNotEvaluated != null)
                customerEventReadingEntities.Add(CreateEventReadingEntity(awvEchoTestResult.TricuspidValveNotEvaluated, (int)ReadingLabels.TricuspidValveNotEvaluated, testReadingReadingPairs));
            if (awvEchoTestResult.TricuspidValveBicuspid != null)
                customerEventReadingEntities.Add(CreateEventReadingEntity(awvEchoTestResult.TricuspidValveBicuspid, (int)ReadingLabels.TricuspidValveBicuspid, testReadingReadingPairs));
            if (awvEchoTestResult.TricuspidValveAtherosclerotic != null)
                customerEventReadingEntities.Add(CreateEventReadingEntity(awvEchoTestResult.TricuspidValveAtherosclerotic, (int)ReadingLabels.TricuspidValveAtherosclerotic, testReadingReadingPairs));
            if (awvEchoTestResult.TricuspidValveNormalFunctioningBiologicalProsthesis != null)
                customerEventReadingEntities.Add(CreateEventReadingEntity(awvEchoTestResult.TricuspidValveNormalFunctioningBiologicalProsthesis, (int)ReadingLabels.TricuspidValveNormalFunctioningBiologicalProsthesis, testReadingReadingPairs));
            if (awvEchoTestResult.TricuspidValveNormalFunctioningMechanicalProsthesis != null)
                customerEventReadingEntities.Add(CreateEventReadingEntity(awvEchoTestResult.TricuspidValveNormalFunctioningMechanicalProsthesis, (int)ReadingLabels.TricuspidValveNormalFunctioningMechanicalProsthesis, testReadingReadingPairs));
            if (awvEchoTestResult.TricuspidValveMalfunctioningBiologicalProsthesis != null)
                customerEventReadingEntities.Add(CreateEventReadingEntity(awvEchoTestResult.TricuspidValveMalfunctioningBiologicalProsthesis, (int)ReadingLabels.TricuspidValveMalfunctioningBiologicalProsthesis, testReadingReadingPairs));
            if (awvEchoTestResult.TricuspidValveMalfunctioningMechanicalProsthesis != null)
                customerEventReadingEntities.Add(CreateEventReadingEntity(awvEchoTestResult.TricuspidValveMalfunctioningMechanicalProsthesis, (int)ReadingLabels.TricuspidValveMalfunctioningMechanicalProsthesis, testReadingReadingPairs));

            if (awvEchoTestResult.TricuspidComment != null)
                customerEventReadingEntities.Add(CreateEventReadingEntity(awvEchoTestResult.TricuspidComment, (int)ReadingLabels.TricuspidComment, testReadingReadingPairs));
        }
    }
}
