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
    public class PpEchocardiogramTestResultFactory : TestResultFactory
    {
        public override TestResult CreateActualTestResult(CustomerEventScreeningTestsEntity customerEventScreeningTestEntity)
        {
            var customerEventReadingEntities = customerEventScreeningTestEntity.CustomerEventReading.ToList();
            var testResult = new PpEchocardiogramTestResult(customerEventScreeningTestEntity.CustomerEventScreeningTestId);

            var customerEventTestStandardFindingEntities = customerEventScreeningTestEntity.CustomerEventTestStandardFinding.ToList();
            var standardFindingTestReadingEntities = customerEventScreeningTestEntity.StandardFindingTestReadingCollectionViaCustomerEventTestStandardFinding.ToList();

            {
                var testResultService = new TestResultService();
                var standardFindings = testResultService.GetAllStandardFindings<int?>((int)TestType.PPEcho);
                var estimatedEjactionFindings = testResultService.GetAllStandardFindings<int?>((int)TestType.PPEcho, (int)ReadingLabels.EstimatedEjactionFraction);
                var aorticRegurgitationFindings = testResultService.GetAllStandardFindings<int?>((int)TestType.PPEcho, (int)ReadingLabels.Aortic);
                var mitralRegurgitationFindings = testResultService.GetAllStandardFindings<int?>((int)TestType.PPEcho, (int)ReadingLabels.Mitral);
                var pulmonicRegurgitationFindings = testResultService.GetAllStandardFindings<int?>((int)TestType.PPEcho, (int)ReadingLabels.Pulmonic);
                var tricuspidRegurgitationFindings = testResultService.GetAllStandardFindings<int?>((int)TestType.PPEcho, (int)ReadingLabels.Tricuspid);
                var aorticMorphologyFindings = testResultService.GetAllStandardFindings<int?>((int)TestType.PPEcho, (int)ReadingLabels.AorticMorphology);
                var mitralMorphologyFindings = testResultService.GetAllStandardFindings<int?>((int)TestType.PPEcho, (int)ReadingLabels.MitralMorphology);
                var pulmonicMorphologyFindings = testResultService.GetAllStandardFindings<int?>((int)TestType.PPEcho, (int)ReadingLabels.PulmonicMorphology);
                var tricuspidMorphologyFindings = testResultService.GetAllStandardFindings<int?>((int)TestType.PPEcho, (int)ReadingLabels.TricuspidMorphology);
                var distolicDysfunctionFindings = testResultService.GetAllStandardFindings<int?>((int)TestType.PPEcho, (int)ReadingLabels.DiastolicDysfunction);
                var pericardialEffusionFindings = testResultService.GetAllStandardFindings<int?>((int)TestType.PPEcho, (int)ReadingLabels.PericardialEffusion);

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

            testResult.DiagnosisCode = CreateResultReadingforInputValues((int)ReadingLabels.DiagnosisCode, customerEventReadingEntities);

            testResult.AorticRoot = CreateResultReading((int)ReadingLabels.AorticRoot, customerEventReadingEntities);
            testResult.Sclerotic = CreateResultReading((int)ReadingLabels.Sclerotic, customerEventReadingEntities);
            testResult.Calcified = CreateResultReading((int)ReadingLabels.Calcified, customerEventReadingEntities);
            testResult.EnlargedValue = CreateResultReadingforInputValues((int)ReadingLabels.EnlargedValue, customerEventReadingEntities);
            testResult.Enlarged = CreateResultReading((int)ReadingLabels.Enlarged, customerEventReadingEntities);

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

            testResult.SAM = CreateResultReading((int)ReadingLabels.SAM, customerEventReadingEntities);
            testResult.LVOTO = CreateResultReading((int)ReadingLabels.LVOTO, customerEventReadingEntities);
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
            testResult.MitralPT = CreateResultReadingforInputValues((int)ReadingLabels.MitralPT, customerEventReadingEntities);
            testResult.PulmonicVelocity = CreateResultReadingforInputValues((int)ReadingLabels.PulmonicVelocity, customerEventReadingEntities);
            testResult.TricuspidVelocity = CreateResultReadingforInputValues((int)ReadingLabels.TricuspidVelocity, customerEventReadingEntities);
            testResult.TricuspidPap = CreateResultReadingforInputValues((int)ReadingLabels.TricuspidPap, customerEventReadingEntities);

            testResult.MorphologyTricuspidHighOrGreater = CreateResultReading((int)ReadingLabels.High35MmHgOrGreater, customerEventReadingEntities);
            testResult.MorphologyTricuspidNormal = CreateResultReading((int)ReadingLabels.Normal, customerEventReadingEntities);

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

        public override CustomerEventScreeningTestsEntity CreateActualTestResultEntity(TestResult testResult, List<OrderedPair<int, int>> testReadingReadingPairs)
        {
            var echoTestResult = testResult as PpEchocardiogramTestResult;
            var customerEventScreeningTestsEntity = new CustomerEventScreeningTestsEntity(testResult.Id) { TestId = (int)TestType.PPEcho };
            var customerEventReadingEntities = new List<CustomerEventReadingEntity>();

            if (echoTestResult.Aortic != null)
                customerEventReadingEntities.Add(CreateEventReadingEntity(echoTestResult.Aortic, (int)ReadingLabels.Aortic, testReadingReadingPairs));

            if (echoTestResult.Mitral != null)
                customerEventReadingEntities.Add(CreateEventReadingEntity(echoTestResult.Mitral, (int)ReadingLabels.Mitral, testReadingReadingPairs));

            if (echoTestResult.Pulmonic != null)
                customerEventReadingEntities.Add(CreateEventReadingEntity(echoTestResult.Pulmonic, (int)ReadingLabels.Pulmonic, testReadingReadingPairs));

            if (echoTestResult.Tricuspid != null)
                customerEventReadingEntities.Add(CreateEventReadingEntity(echoTestResult.Tricuspid, (int)ReadingLabels.Tricuspid, testReadingReadingPairs));

            if (echoTestResult.DiagnosisCode != null)
            {
                var customerEventReading = CreateEventReadingEntity(echoTestResult.DiagnosisCode, (int)ReadingLabels.DiagnosisCode, testReadingReadingPairs);
                customerEventReadingEntities.Add(customerEventReading);
            }

            if (echoTestResult.VentricularEnlargement != null)
                customerEventReadingEntities.Add(CreateEventReadingEntity(echoTestResult.VentricularEnlargement, (int)ReadingLabels.VentricularEnlargement, testReadingReadingPairs));

            if (echoTestResult.LeftVentricularEnlargment != null)
                customerEventReadingEntities.Add(CreateEventReadingEntity(echoTestResult.LeftVentricularEnlargment, (int)ReadingLabels.LeftVentricularEnlargment, testReadingReadingPairs));

            if (echoTestResult.RightVentricularEnlargment != null)
                customerEventReadingEntities.Add(CreateEventReadingEntity(echoTestResult.RightVentricularEnlargment, (int)ReadingLabels.RightVentricularEnlargment, testReadingReadingPairs));

            if (echoTestResult.LeftVentricularEnlargmentValue != null)
                customerEventReadingEntities.Add(CreateEventReadingEntity(echoTestResult.LeftVentricularEnlargmentValue, (int)ReadingLabels.LeftVentricularEnlargmentValue, testReadingReadingPairs));

            if (echoTestResult.RightVentricularEnlargmentValue != null)
                customerEventReadingEntities.Add(CreateEventReadingEntity(echoTestResult.RightVentricularEnlargmentValue, (int)ReadingLabels.RightVentricularEnlargmentValue, testReadingReadingPairs));

            if (echoTestResult.DiastolicDysfunction != null)
                customerEventReadingEntities.Add(CreateEventReadingEntity(echoTestResult.DiastolicDysfunction, (int)ReadingLabels.DiastolicDysfunction, testReadingReadingPairs));

            if (echoTestResult.PericardialEffusion != null)
                customerEventReadingEntities.Add(CreateEventReadingEntity(echoTestResult.PericardialEffusion, (int)ReadingLabels.PericardialEffusion, testReadingReadingPairs));


            if (echoTestResult.AorticRoot != null)
                customerEventReadingEntities.Add(CreateEventReadingEntity(echoTestResult.AorticRoot, (int)ReadingLabels.AorticRoot, testReadingReadingPairs));

            if (echoTestResult.Sclerotic != null)
                customerEventReadingEntities.Add(CreateEventReadingEntity(echoTestResult.Sclerotic, (int)ReadingLabels.Sclerotic, testReadingReadingPairs));

            if (echoTestResult.Calcified != null)
                customerEventReadingEntities.Add(CreateEventReadingEntity(echoTestResult.Calcified, (int)ReadingLabels.Calcified, testReadingReadingPairs));

            if (echoTestResult.Enlarged != null)
                customerEventReadingEntities.Add(CreateEventReadingEntity(echoTestResult.Enlarged, (int)ReadingLabels.Enlarged, testReadingReadingPairs));

            if (echoTestResult.EnlargedValue != null)
                customerEventReadingEntities.Add(CreateEventReadingEntity(echoTestResult.EnlargedValue, (int)ReadingLabels.EnlargedValue, testReadingReadingPairs));

            if (echoTestResult.VentricularHypertrophy != null)
                customerEventReadingEntities.Add(CreateEventReadingEntity(echoTestResult.VentricularHypertrophy, (int)ReadingLabels.VentricularHypertrophy, testReadingReadingPairs));

            if (echoTestResult.LeftVHypertrophyValue != null)
                customerEventReadingEntities.Add(CreateEventReadingEntity(echoTestResult.LeftVHypertrophyValue, (int)ReadingLabels.LeftVHypertrophyValue, testReadingReadingPairs));

            if (echoTestResult.RightVHypertrophyValue != null)
                customerEventReadingEntities.Add(CreateEventReadingEntity(echoTestResult.RightVHypertrophyValue, (int)ReadingLabels.RightVHypertrophyValue, testReadingReadingPairs));

            if (echoTestResult.IvshHypertrophyValue != null)
                customerEventReadingEntities.Add(CreateEventReadingEntity(echoTestResult.IvshHypertrophyValue, (int)ReadingLabels.IVSHHypertrophyValue, testReadingReadingPairs));

            if (echoTestResult.LeftVHypertrophy != null)
                customerEventReadingEntities.Add(CreateEventReadingEntity(echoTestResult.LeftVHypertrophy, (int)ReadingLabels.LeftVHypertrophy, testReadingReadingPairs));

            if (echoTestResult.RightVHypertrophy != null)
                customerEventReadingEntities.Add(CreateEventReadingEntity(echoTestResult.RightVHypertrophy, (int)ReadingLabels.RightVHypertrophy, testReadingReadingPairs));

            if (echoTestResult.IvshHypertrophy != null)
                customerEventReadingEntities.Add(CreateEventReadingEntity(echoTestResult.IvshHypertrophy, (int)ReadingLabels.IVSHHypertrophy, testReadingReadingPairs));


            if (echoTestResult.TechnicallyLimitedbutReadable != null)
                customerEventReadingEntities.Add(CreateEventReadingEntity(echoTestResult.TechnicallyLimitedbutReadable, (int)ReadingLabels.TechnicallyLimitedbutReadable, testReadingReadingPairs));

            if (echoTestResult.RepeatStudyUnreadable != null)
                customerEventReadingEntities.Add(CreateEventReadingEntity(echoTestResult.RepeatStudyUnreadable, (int)ReadingLabels.RepeatStudy, testReadingReadingPairs));


            if (echoTestResult.AtrialEnlargement != null)
                customerEventReadingEntities.Add(CreateEventReadingEntity(echoTestResult.AtrialEnlargement, (int)ReadingLabels.AtrialEnlargement, testReadingReadingPairs));

            if (echoTestResult.LeftAtrialEnlargmentValue != null)
                customerEventReadingEntities.Add(CreateEventReadingEntity(echoTestResult.LeftAtrialEnlargmentValue, (int)ReadingLabels.LeftAtrialEnlargmentValue, testReadingReadingPairs));

            if (echoTestResult.RightAtrialEnlargmentValue != null)
                customerEventReadingEntities.Add(CreateEventReadingEntity(echoTestResult.RightAtrialEnlargmentValue, (int)ReadingLabels.RightAtrialEnlargmentValue, testReadingReadingPairs));

            if (echoTestResult.LeftAtrialEnlargment != null)
                customerEventReadingEntities.Add(CreateEventReadingEntity(echoTestResult.LeftAtrialEnlargment, (int)ReadingLabels.LeftAtrialEnlargment, testReadingReadingPairs));

            if (echoTestResult.RightAtrialEnlargment != null)
                customerEventReadingEntities.Add(CreateEventReadingEntity(echoTestResult.RightAtrialEnlargment, (int)ReadingLabels.RightAtrialEnlargment, testReadingReadingPairs));



            if (echoTestResult.ASD != null)
                customerEventReadingEntities.Add(CreateEventReadingEntity(echoTestResult.ASD, (int)ReadingLabels.ASD, testReadingReadingPairs));

            if (echoTestResult.PFO != null)
                customerEventReadingEntities.Add(CreateEventReadingEntity(echoTestResult.PFO, (int)ReadingLabels.PFO, testReadingReadingPairs));

            if (echoTestResult.VSD != null)
                customerEventReadingEntities.Add(CreateEventReadingEntity(echoTestResult.VSD, (int)ReadingLabels.VSD, testReadingReadingPairs));

            if (echoTestResult.FlailAS != null)
                customerEventReadingEntities.Add(CreateEventReadingEntity(echoTestResult.FlailAS, (int)ReadingLabels.FlailAS, testReadingReadingPairs));

            if (echoTestResult.Arrythmia != null)
                customerEventReadingEntities.Add(CreateEventReadingEntity(echoTestResult.Arrythmia, (int)ReadingLabels.Arrythmia, testReadingReadingPairs));

            if (echoTestResult.AFib != null)
                customerEventReadingEntities.Add(CreateEventReadingEntity(echoTestResult.AFib, (int)ReadingLabels.AFib, testReadingReadingPairs));

            if (echoTestResult.AFlutter != null)
                customerEventReadingEntities.Add(CreateEventReadingEntity(echoTestResult.AFlutter, (int)ReadingLabels.AFlutter, testReadingReadingPairs));

            if (echoTestResult.PAC != null)
                customerEventReadingEntities.Add(CreateEventReadingEntity(echoTestResult.PAC, (int)ReadingLabels.PAC, testReadingReadingPairs));

            if (echoTestResult.PVC != null)
                customerEventReadingEntities.Add(CreateEventReadingEntity(echoTestResult.PVC, (int)ReadingLabels.PVC, testReadingReadingPairs));


            if (echoTestResult.RestrictedLeafletMotion != null)
                customerEventReadingEntities.Add(CreateEventReadingEntity(echoTestResult.RestrictedLeafletMotion, (int)ReadingLabels.RestrictedLeafletMotion, testReadingReadingPairs));

            if (echoTestResult.RestrictedLeafletMotionAortic != null)
                customerEventReadingEntities.Add(CreateEventReadingEntity(echoTestResult.RestrictedLeafletMotionAortic, (int)ReadingLabels.RestrictedLeafletMotionAortic, testReadingReadingPairs));

            if (echoTestResult.RestrictedLeafletMotionMitral != null)
                customerEventReadingEntities.Add(CreateEventReadingEntity(echoTestResult.RestrictedLeafletMotionMitral, (int)ReadingLabels.RestrictedLeafletMotionMitral, testReadingReadingPairs));

            if (echoTestResult.RestrictedLeafletMotionPulmonic != null)
                customerEventReadingEntities.Add(CreateEventReadingEntity(echoTestResult.RestrictedLeafletMotionPulmonic, (int)ReadingLabels.RestrictedLeafletMotionPulmonic, testReadingReadingPairs));

            if (echoTestResult.RestrictedLeafletMotionTricuspid != null)
                customerEventReadingEntities.Add(CreateEventReadingEntity(echoTestResult.RestrictedLeafletMotionTricuspid, (int)ReadingLabels.RestrictedLeafletMotionTricuspid, testReadingReadingPairs));


            if (echoTestResult.SAM != null)
                customerEventReadingEntities.Add(CreateEventReadingEntity(echoTestResult.SAM, (int)ReadingLabels.SAM, testReadingReadingPairs));

            if (echoTestResult.LVOTO != null)
                customerEventReadingEntities.Add(CreateEventReadingEntity(echoTestResult.LVOTO, (int)ReadingLabels.LVOTO, testReadingReadingPairs));

            if (echoTestResult.MitralAnnularCa != null)
                customerEventReadingEntities.Add(CreateEventReadingEntity(echoTestResult.MitralAnnularCa, (int)ReadingLabels.MitralAnnularCa, testReadingReadingPairs));

            if (echoTestResult.Hypokinetic != null)
                customerEventReadingEntities.Add(CreateEventReadingEntity(echoTestResult.Hypokinetic, (int)ReadingLabels.Hypokinetic, testReadingReadingPairs));

            if (echoTestResult.Akinetic != null)
                customerEventReadingEntities.Add(CreateEventReadingEntity(echoTestResult.Akinetic, (int)ReadingLabels.Akinetic, testReadingReadingPairs));

            if (echoTestResult.Dyskinetic != null)
                customerEventReadingEntities.Add(CreateEventReadingEntity(echoTestResult.Dyskinetic, (int)ReadingLabels.Dyskinetic, testReadingReadingPairs));

            if (echoTestResult.Anterior != null)
                customerEventReadingEntities.Add(CreateEventReadingEntity(echoTestResult.Anterior, (int)ReadingLabels.Anterior, testReadingReadingPairs));

            if (echoTestResult.Posterior != null)
                customerEventReadingEntities.Add(CreateEventReadingEntity(echoTestResult.Posterior, (int)ReadingLabels.Posterior, testReadingReadingPairs));

            if (echoTestResult.Apical != null)
                customerEventReadingEntities.Add(CreateEventReadingEntity(echoTestResult.Apical, (int)ReadingLabels.Apical, testReadingReadingPairs));

            if (echoTestResult.Septal != null)
                customerEventReadingEntities.Add(CreateEventReadingEntity(echoTestResult.Septal, (int)ReadingLabels.Septal, testReadingReadingPairs));

            if (echoTestResult.Lateral != null)
                customerEventReadingEntities.Add(CreateEventReadingEntity(echoTestResult.Lateral, (int)ReadingLabels.Lateral, testReadingReadingPairs));

            if (echoTestResult.Inferior != null)
                customerEventReadingEntities.Add(CreateEventReadingEntity(echoTestResult.Inferior, (int)ReadingLabels.Inferior, testReadingReadingPairs));

            if (echoTestResult.AoticVelocity != null)
                customerEventReadingEntities.Add(CreateEventReadingEntity(echoTestResult.AoticVelocity, (int)ReadingLabels.AoticVelocity, testReadingReadingPairs));

            if (echoTestResult.MitralPT != null)
                customerEventReadingEntities.Add(CreateEventReadingEntity(echoTestResult.MitralPT, (int)ReadingLabels.MitralPT, testReadingReadingPairs));

            if (echoTestResult.PulmonicVelocity != null)
                customerEventReadingEntities.Add(CreateEventReadingEntity(echoTestResult.PulmonicVelocity, (int)ReadingLabels.PulmonicVelocity, testReadingReadingPairs));

            if (echoTestResult.TricuspidVelocity != null)
                customerEventReadingEntities.Add(CreateEventReadingEntity(echoTestResult.TricuspidVelocity, (int)ReadingLabels.TricuspidVelocity, testReadingReadingPairs));

            if (echoTestResult.TricuspidPap != null)
                customerEventReadingEntities.Add(CreateEventReadingEntity(echoTestResult.TricuspidPap, (int)ReadingLabels.TricuspidPap, testReadingReadingPairs));

            if (echoTestResult.MorphologyTricuspidHighOrGreater != null)
                customerEventReadingEntities.Add(CreateEventReadingEntity(echoTestResult.MorphologyTricuspidHighOrGreater, (int)ReadingLabels.High35MmHgOrGreater, testReadingReadingPairs));

            if (echoTestResult.MorphologyTricuspidNormal != null)
                customerEventReadingEntities.Add(CreateEventReadingEntity(echoTestResult.MorphologyTricuspidNormal, (int)ReadingLabels.Normal, testReadingReadingPairs));

            testResult.ResultInterpretation = null;
            if (echoTestResult.Finding != null)
            {
                var customerEventTestStandardFindingEntity = new CustomerEventTestStandardFindingEntity()
                {
                    StandardFindingTestReadingId =
                        (int?)new TestResultService().GetStandardFindingTestReadingIdForStandardFinding
                            ((int)TestType.PPEcho, null, Convert.ToInt64(echoTestResult.Finding.Id)),
                    CustomerEventTestStandardFindingId = echoTestResult.Finding.CustomerEventStandardFindingId,
                    CustomerEventScreeningTestId = testResult.Id
                };
                customerEventScreeningTestsEntity.CustomerEventTestStandardFinding.Add(customerEventTestStandardFindingEntity);

                var finding = GetSelectedStandardFinding((int)TestType.PPEcho, null, echoTestResult.Finding.Id);

                if (testResult.ResultStatus.StateNumber == (int)TestResultStateNumber.Evaluated || testResult.ResultStatus.StateNumber == (int)NewTestResultStateNumber.Evaluated)
                {
                    testResult.ResultInterpretation = finding.ResultInterpretation;
                    testResult.PathwayRecommendation = finding.PathwayRecommendation;
                }
            }

            if (echoTestResult.EstimatedEjactionFraction != null)
            {
                var customerEventTestStandardFindingEntity = new CustomerEventTestStandardFindingEntity()
                {
                    StandardFindingTestReadingId =
                        (int?)new TestResultService().GetStandardFindingTestReadingIdForStandardFinding
                            ((int)TestType.PPEcho, (int)ReadingLabels.EstimatedEjactionFraction, Convert.ToInt64(echoTestResult.EstimatedEjactionFraction.Id)),
                    CustomerEventTestStandardFindingId = echoTestResult.EstimatedEjactionFraction.CustomerEventStandardFindingId,
                    CustomerEventScreeningTestId = testResult.Id
                };
                customerEventScreeningTestsEntity.CustomerEventTestStandardFinding.Add(customerEventTestStandardFindingEntity);
            }
            if (echoTestResult.AorticRegurgitation != null)
            {
                var customerEventTestStandardFindingEntity = new CustomerEventTestStandardFindingEntity()
                {
                    StandardFindingTestReadingId =
                        (int?)new TestResultService().GetStandardFindingTestReadingIdForStandardFinding
                            ((int)TestType.PPEcho, (int)ReadingLabels.Aortic, Convert.ToInt64(echoTestResult.AorticRegurgitation.Id)),
                    CustomerEventTestStandardFindingId = echoTestResult.AorticRegurgitation.CustomerEventStandardFindingId,
                    CustomerEventScreeningTestId = testResult.Id
                };
                customerEventScreeningTestsEntity.CustomerEventTestStandardFinding.Add(customerEventTestStandardFindingEntity);
            }

            if (echoTestResult.AorticMorphology != null)
            {
                echoTestResult.AorticMorphology.ForEach(finding =>
                {
                    var customerEventTestStandardFindingEntity = new CustomerEventTestStandardFindingEntity()
                    {
                        StandardFindingTestReadingId =
                            (int?)new TestResultService().GetStandardFindingTestReadingIdForStandardFinding
                                ((int)TestType.PPEcho, (int)ReadingLabels.AorticMorphology, Convert.ToInt64(finding.Id)),
                        CustomerEventTestStandardFindingId = finding.CustomerEventStandardFindingId,
                        CustomerEventScreeningTestId = testResult.Id
                    };
                    customerEventScreeningTestsEntity.CustomerEventTestStandardFinding.Add(customerEventTestStandardFindingEntity);
                });
            }

            if (echoTestResult.MitralRegurgitation != null)
            {
                var customerEventTestStandardFindingEntity = new CustomerEventTestStandardFindingEntity()
                {
                    StandardFindingTestReadingId =
                        (int?)new TestResultService().GetStandardFindingTestReadingIdForStandardFinding
                            ((int)TestType.PPEcho, (int)ReadingLabels.Mitral, Convert.ToInt64(echoTestResult.MitralRegurgitation.Id)),
                    CustomerEventTestStandardFindingId = echoTestResult.MitralRegurgitation.CustomerEventStandardFindingId,
                    CustomerEventScreeningTestId = testResult.Id
                };
                customerEventScreeningTestsEntity.CustomerEventTestStandardFinding.Add(customerEventTestStandardFindingEntity);
            }

            if (echoTestResult.MitralMorphology != null)
            {
                echoTestResult.MitralMorphology.ForEach(finding =>
                {
                    var customerEventTestStandardFindingEntity = new CustomerEventTestStandardFindingEntity()
                    {
                        StandardFindingTestReadingId =
                            (int?)new TestResultService().GetStandardFindingTestReadingIdForStandardFinding
                                ((int)TestType.PPEcho, (int)ReadingLabels.MitralMorphology, Convert.ToInt64(finding.Id)),
                        CustomerEventTestStandardFindingId = finding.CustomerEventStandardFindingId,
                        CustomerEventScreeningTestId = testResult.Id
                    };
                    customerEventScreeningTestsEntity.CustomerEventTestStandardFinding.Add(customerEventTestStandardFindingEntity);
                });
            }

            if (echoTestResult.PulmonicRegurgitation != null)
            {
                var customerEventTestStandardFindingEntity = new CustomerEventTestStandardFindingEntity()
                {
                    StandardFindingTestReadingId =
                        (int?)new TestResultService().GetStandardFindingTestReadingIdForStandardFinding
                            ((int)TestType.PPEcho, (int)ReadingLabels.Pulmonic, Convert.ToInt64(echoTestResult.PulmonicRegurgitation.Id)),
                    CustomerEventTestStandardFindingId = echoTestResult.PulmonicRegurgitation.CustomerEventStandardFindingId,
                    CustomerEventScreeningTestId = testResult.Id
                };
                customerEventScreeningTestsEntity.CustomerEventTestStandardFinding.Add(customerEventTestStandardFindingEntity);
            }

            if (echoTestResult.PulmonicMorphology != null)
            {
                echoTestResult.PulmonicMorphology.ForEach(finding =>
                {
                    var customerEventTestStandardFindingEntity = new CustomerEventTestStandardFindingEntity()
                    {
                        StandardFindingTestReadingId =
                            (int?)new TestResultService().GetStandardFindingTestReadingIdForStandardFinding
                                ((int)TestType.PPEcho, (int)ReadingLabels.PulmonicMorphology, Convert.ToInt64(finding.Id)),
                        CustomerEventTestStandardFindingId = finding.CustomerEventStandardFindingId,
                        CustomerEventScreeningTestId = testResult.Id
                    };
                    customerEventScreeningTestsEntity.CustomerEventTestStandardFinding.Add(customerEventTestStandardFindingEntity);
                });
            }

            if (echoTestResult.TricuspidRegurgitation != null)
            {
                var customerEventTestStandardFindingEntity = new CustomerEventTestStandardFindingEntity()
                {
                    StandardFindingTestReadingId =
                        (int?)new TestResultService().GetStandardFindingTestReadingIdForStandardFinding
                            ((int)TestType.PPEcho, (int)ReadingLabels.Tricuspid, Convert.ToInt64(echoTestResult.TricuspidRegurgitation.Id)),
                    CustomerEventTestStandardFindingId = echoTestResult.TricuspidRegurgitation.CustomerEventStandardFindingId,
                    CustomerEventScreeningTestId = testResult.Id
                };
                customerEventScreeningTestsEntity.CustomerEventTestStandardFinding.Add(customerEventTestStandardFindingEntity);
            }

            if (echoTestResult.TricuspidMorphology != null)
            {
                echoTestResult.TricuspidMorphology.ForEach(finding =>
                {
                    var customerEventTestStandardFindingEntity = new CustomerEventTestStandardFindingEntity()
                    {
                        StandardFindingTestReadingId =
                            (int?)new TestResultService().GetStandardFindingTestReadingIdForStandardFinding
                                ((int)TestType.PPEcho, (int)ReadingLabels.TricuspidMorphology, Convert.ToInt64(finding.Id)),
                        CustomerEventTestStandardFindingId = finding.CustomerEventStandardFindingId,
                        CustomerEventScreeningTestId = testResult.Id
                    };
                    customerEventScreeningTestsEntity.CustomerEventTestStandardFinding.Add(customerEventTestStandardFindingEntity);
                });
            }
            
            if (echoTestResult.DistolicDysfunctionFinding != null)
            {
                var customerEventTestStandardFindingEntity = new CustomerEventTestStandardFindingEntity()
                {
                    StandardFindingTestReadingId =
                        (int?)new TestResultService().GetStandardFindingTestReadingIdForStandardFinding
                            ((int)TestType.PPEcho, (int)ReadingLabels.DiastolicDysfunction, Convert.ToInt64(echoTestResult.DistolicDysfunctionFinding.Id)),
                    CustomerEventTestStandardFindingId = echoTestResult.DistolicDysfunctionFinding.CustomerEventStandardFindingId,
                    CustomerEventScreeningTestId = testResult.Id
                };
                customerEventScreeningTestsEntity.CustomerEventTestStandardFinding.Add(customerEventTestStandardFindingEntity);
            }
            
            if (echoTestResult.PericardialEffusionFinding != null)
            {
                echoTestResult.PericardialEffusionFinding.ForEach(finding =>
                {
                    var customerEventTestStandardFindingEntity = new CustomerEventTestStandardFindingEntity()
                    {
                        StandardFindingTestReadingId =
                            (int?)new TestResultService().GetStandardFindingTestReadingIdForStandardFinding
                                ((int)TestType.PPEcho, (int)ReadingLabels.PericardialEffusion, Convert.ToInt64(finding.Id)),
                        CustomerEventTestStandardFindingId = finding.CustomerEventStandardFindingId,
                        CustomerEventScreeningTestId = testResult.Id
                    };
                    customerEventScreeningTestsEntity.CustomerEventTestStandardFinding.Add(customerEventTestStandardFindingEntity);
                });
            }

            customerEventScreeningTestsEntity.CustomerEventReading.AddRange(customerEventReadingEntities);
            return customerEventScreeningTestsEntity;
        }
    }
}
