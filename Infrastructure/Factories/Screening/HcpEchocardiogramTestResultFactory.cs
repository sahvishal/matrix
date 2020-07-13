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
    public class HcpEchocardiogramTestResultFactory : TestResultFactory
    {
        public override TestResult CreateActualTestResult(CustomerEventScreeningTestsEntity customerEventScreeningTestEntity)
        {
            var customerEventReadingEntities = customerEventScreeningTestEntity.CustomerEventReading.ToList();
            var testResult = new HcpEchocardiogramTestResult(customerEventScreeningTestEntity.CustomerEventScreeningTestId);

            var customerEventTestStandardFindingEntities = customerEventScreeningTestEntity.CustomerEventTestStandardFinding.ToList();
            var standardFindingTestReadingEntities = customerEventScreeningTestEntity.StandardFindingTestReadingCollectionViaCustomerEventTestStandardFinding.ToList();

            {
                var testResultService = new TestResultService();
                var standardFindings = testResultService.GetAllStandardFindings<int?>((int)TestType.HCPEcho);
                var estimatedEjactionFindings = testResultService.GetAllStandardFindings<int?>((int)TestType.HCPEcho, (int)ReadingLabels.EstimatedEjactionFraction);
                var aorticRegurgitationFindings = testResultService.GetAllStandardFindings<int?>((int)TestType.HCPEcho, (int)ReadingLabels.Aortic);
                var mitralRegurgitationFindings = testResultService.GetAllStandardFindings<int?>((int)TestType.HCPEcho, (int)ReadingLabels.Mitral);
                var pulmonicRegurgitationFindings = testResultService.GetAllStandardFindings<int?>((int)TestType.HCPEcho, (int)ReadingLabels.Pulmonic);
                var tricuspidRegurgitationFindings = testResultService.GetAllStandardFindings<int?>((int)TestType.HCPEcho, (int)ReadingLabels.Tricuspid);
                var aorticMorphologyFindings = testResultService.GetAllStandardFindings<int?>((int)TestType.HCPEcho, (int)ReadingLabels.AorticMorphology);
                var mitralMorphologyFindings = testResultService.GetAllStandardFindings<int?>((int)TestType.HCPEcho, (int)ReadingLabels.MitralMorphology);
                var pulmonicMorphologyFindings = testResultService.GetAllStandardFindings<int?>((int)TestType.HCPEcho, (int)ReadingLabels.PulmonicMorphology);
                var tricuspidMorphologyFindings = testResultService.GetAllStandardFindings<int?>((int)TestType.HCPEcho, (int)ReadingLabels.TricuspidMorphology);
                var distolicDysfunctionFindings = testResultService.GetAllStandardFindings<int?>((int)TestType.HCPEcho, (int)ReadingLabels.DiastolicDysfunction);
                var pericardialEffusionFindings = testResultService.GetAllStandardFindings<int?>((int)TestType.HCPEcho, (int)ReadingLabels.PericardialEffusion);

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
            var hcpTestResult = testResult as HcpEchocardiogramTestResult;
            var customerEventScreeningTestsEntity = new CustomerEventScreeningTestsEntity(testResult.Id) { TestId = (int)TestType.HCPEcho };
            var customerEventReadingEntities = new List<CustomerEventReadingEntity>();

            if (hcpTestResult.Aortic != null)
                customerEventReadingEntities.Add(CreateEventReadingEntity(hcpTestResult.Aortic, (int)ReadingLabels.Aortic, testReadingReadingPairs));

            if (hcpTestResult.Mitral != null)
                customerEventReadingEntities.Add(CreateEventReadingEntity(hcpTestResult.Mitral, (int)ReadingLabels.Mitral, testReadingReadingPairs));

            if (hcpTestResult.Pulmonic != null)
                customerEventReadingEntities.Add(CreateEventReadingEntity(hcpTestResult.Pulmonic, (int)ReadingLabels.Pulmonic, testReadingReadingPairs));

            if (hcpTestResult.Tricuspid != null)
                customerEventReadingEntities.Add(CreateEventReadingEntity(hcpTestResult.Tricuspid, (int)ReadingLabels.Tricuspid, testReadingReadingPairs));
            
            if (hcpTestResult.VentricularEnlargement != null)
                customerEventReadingEntities.Add(CreateEventReadingEntity(hcpTestResult.VentricularEnlargement, (int)ReadingLabels.VentricularEnlargement, testReadingReadingPairs));

            if (hcpTestResult.LeftVentricularEnlargment != null)
                customerEventReadingEntities.Add(CreateEventReadingEntity(hcpTestResult.LeftVentricularEnlargment, (int)ReadingLabels.LeftVentricularEnlargment, testReadingReadingPairs));

            if (hcpTestResult.RightVentricularEnlargment != null)
                customerEventReadingEntities.Add(CreateEventReadingEntity(hcpTestResult.RightVentricularEnlargment, (int)ReadingLabels.RightVentricularEnlargment, testReadingReadingPairs));

            if (hcpTestResult.LeftVentricularEnlargmentValue != null)
                customerEventReadingEntities.Add(CreateEventReadingEntity(hcpTestResult.LeftVentricularEnlargmentValue, (int)ReadingLabels.LeftVentricularEnlargmentValue, testReadingReadingPairs));

            if (hcpTestResult.RightVentricularEnlargmentValue != null)
                customerEventReadingEntities.Add(CreateEventReadingEntity(hcpTestResult.RightVentricularEnlargmentValue, (int)ReadingLabels.RightVentricularEnlargmentValue, testReadingReadingPairs));

            if (hcpTestResult.DiastolicDysfunction != null)
                customerEventReadingEntities.Add(CreateEventReadingEntity(hcpTestResult.DiastolicDysfunction, (int)ReadingLabels.DiastolicDysfunction, testReadingReadingPairs));

            if (hcpTestResult.PericardialEffusion != null)
                customerEventReadingEntities.Add(CreateEventReadingEntity(hcpTestResult.PericardialEffusion, (int)ReadingLabels.PericardialEffusion, testReadingReadingPairs));


            if (hcpTestResult.AorticRoot != null)
                customerEventReadingEntities.Add(CreateEventReadingEntity(hcpTestResult.AorticRoot, (int)ReadingLabels.AorticRoot, testReadingReadingPairs));

            if (hcpTestResult.Sclerotic != null)
                customerEventReadingEntities.Add(CreateEventReadingEntity(hcpTestResult.Sclerotic, (int)ReadingLabels.Sclerotic, testReadingReadingPairs));

            if (hcpTestResult.Calcified != null)
                customerEventReadingEntities.Add(CreateEventReadingEntity(hcpTestResult.Calcified, (int)ReadingLabels.Calcified, testReadingReadingPairs));

            if (hcpTestResult.Enlarged != null)
                customerEventReadingEntities.Add(CreateEventReadingEntity(hcpTestResult.Enlarged, (int)ReadingLabels.Enlarged, testReadingReadingPairs));

            if (hcpTestResult.EnlargedValue != null)
                customerEventReadingEntities.Add(CreateEventReadingEntity(hcpTestResult.EnlargedValue, (int)ReadingLabels.EnlargedValue, testReadingReadingPairs));

            if (hcpTestResult.VentricularHypertrophy != null)
                customerEventReadingEntities.Add(CreateEventReadingEntity(hcpTestResult.VentricularHypertrophy, (int)ReadingLabels.VentricularHypertrophy, testReadingReadingPairs));

            if (hcpTestResult.LeftVHypertrophyValue != null)
                customerEventReadingEntities.Add(CreateEventReadingEntity(hcpTestResult.LeftVHypertrophyValue, (int)ReadingLabels.LeftVHypertrophyValue, testReadingReadingPairs));

            if (hcpTestResult.RightVHypertrophyValue != null)
                customerEventReadingEntities.Add(CreateEventReadingEntity(hcpTestResult.RightVHypertrophyValue, (int)ReadingLabels.RightVHypertrophyValue, testReadingReadingPairs));

            if (hcpTestResult.IvshHypertrophyValue != null)
                customerEventReadingEntities.Add(CreateEventReadingEntity(hcpTestResult.IvshHypertrophyValue, (int)ReadingLabels.IVSHHypertrophyValue, testReadingReadingPairs));

            if (hcpTestResult.LeftVHypertrophy != null)
                customerEventReadingEntities.Add(CreateEventReadingEntity(hcpTestResult.LeftVHypertrophy, (int)ReadingLabels.LeftVHypertrophy, testReadingReadingPairs));

            if (hcpTestResult.RightVHypertrophy != null)
                customerEventReadingEntities.Add(CreateEventReadingEntity(hcpTestResult.RightVHypertrophy, (int)ReadingLabels.RightVHypertrophy, testReadingReadingPairs));

            if (hcpTestResult.IvshHypertrophy != null)
                customerEventReadingEntities.Add(CreateEventReadingEntity(hcpTestResult.IvshHypertrophy, (int)ReadingLabels.IVSHHypertrophy, testReadingReadingPairs));


            if (hcpTestResult.TechnicallyLimitedbutReadable != null)
                customerEventReadingEntities.Add(CreateEventReadingEntity(hcpTestResult.TechnicallyLimitedbutReadable, (int)ReadingLabels.TechnicallyLimitedbutReadable, testReadingReadingPairs));

            if (hcpTestResult.RepeatStudyUnreadable != null)
                customerEventReadingEntities.Add(CreateEventReadingEntity(hcpTestResult.RepeatStudyUnreadable, (int)ReadingLabels.RepeatStudy, testReadingReadingPairs));


            if (hcpTestResult.AtrialEnlargement != null)
                customerEventReadingEntities.Add(CreateEventReadingEntity(hcpTestResult.AtrialEnlargement, (int)ReadingLabels.AtrialEnlargement, testReadingReadingPairs));

            if (hcpTestResult.LeftAtrialEnlargmentValue != null)
                customerEventReadingEntities.Add(CreateEventReadingEntity(hcpTestResult.LeftAtrialEnlargmentValue, (int)ReadingLabels.LeftAtrialEnlargmentValue, testReadingReadingPairs));

            if (hcpTestResult.RightAtrialEnlargmentValue != null)
                customerEventReadingEntities.Add(CreateEventReadingEntity(hcpTestResult.RightAtrialEnlargmentValue, (int)ReadingLabels.RightAtrialEnlargmentValue, testReadingReadingPairs));

            if (hcpTestResult.LeftAtrialEnlargment != null)
                customerEventReadingEntities.Add(CreateEventReadingEntity(hcpTestResult.LeftAtrialEnlargment, (int)ReadingLabels.LeftAtrialEnlargment, testReadingReadingPairs));

            if (hcpTestResult.RightAtrialEnlargment != null)
                customerEventReadingEntities.Add(CreateEventReadingEntity(hcpTestResult.RightAtrialEnlargment, (int)ReadingLabels.RightAtrialEnlargment, testReadingReadingPairs));



            if (hcpTestResult.ASD != null)
                customerEventReadingEntities.Add(CreateEventReadingEntity(hcpTestResult.ASD, (int)ReadingLabels.ASD, testReadingReadingPairs));

            if (hcpTestResult.PFO != null)
                customerEventReadingEntities.Add(CreateEventReadingEntity(hcpTestResult.PFO, (int)ReadingLabels.PFO, testReadingReadingPairs));

            if (hcpTestResult.VSD != null)
                customerEventReadingEntities.Add(CreateEventReadingEntity(hcpTestResult.VSD, (int)ReadingLabels.VSD, testReadingReadingPairs));

            if (hcpTestResult.FlailAS != null)
                customerEventReadingEntities.Add(CreateEventReadingEntity(hcpTestResult.FlailAS, (int)ReadingLabels.FlailAS, testReadingReadingPairs));

            if (hcpTestResult.Arrythmia != null)
                customerEventReadingEntities.Add(CreateEventReadingEntity(hcpTestResult.Arrythmia, (int)ReadingLabels.Arrythmia, testReadingReadingPairs));

            if (hcpTestResult.AFib != null)
                customerEventReadingEntities.Add(CreateEventReadingEntity(hcpTestResult.AFib, (int)ReadingLabels.AFib, testReadingReadingPairs));

            if (hcpTestResult.AFlutter != null)
                customerEventReadingEntities.Add(CreateEventReadingEntity(hcpTestResult.AFlutter, (int)ReadingLabels.AFlutter, testReadingReadingPairs));

            if (hcpTestResult.PAC != null)
                customerEventReadingEntities.Add(CreateEventReadingEntity(hcpTestResult.PAC, (int)ReadingLabels.PAC, testReadingReadingPairs));

            if (hcpTestResult.PVC != null)
                customerEventReadingEntities.Add(CreateEventReadingEntity(hcpTestResult.PVC, (int)ReadingLabels.PVC, testReadingReadingPairs));


            if (hcpTestResult.RestrictedLeafletMotion != null)
                customerEventReadingEntities.Add(CreateEventReadingEntity(hcpTestResult.RestrictedLeafletMotion, (int)ReadingLabels.RestrictedLeafletMotion, testReadingReadingPairs));

            if (hcpTestResult.RestrictedLeafletMotionAortic != null)
                customerEventReadingEntities.Add(CreateEventReadingEntity(hcpTestResult.RestrictedLeafletMotionAortic, (int)ReadingLabels.RestrictedLeafletMotionAortic, testReadingReadingPairs));

            if (hcpTestResult.RestrictedLeafletMotionMitral != null)
                customerEventReadingEntities.Add(CreateEventReadingEntity(hcpTestResult.RestrictedLeafletMotionMitral, (int)ReadingLabels.RestrictedLeafletMotionMitral, testReadingReadingPairs));

            if (hcpTestResult.RestrictedLeafletMotionPulmonic != null)
                customerEventReadingEntities.Add(CreateEventReadingEntity(hcpTestResult.RestrictedLeafletMotionPulmonic, (int)ReadingLabels.RestrictedLeafletMotionPulmonic, testReadingReadingPairs));

            if (hcpTestResult.RestrictedLeafletMotionTricuspid != null)
                customerEventReadingEntities.Add(CreateEventReadingEntity(hcpTestResult.RestrictedLeafletMotionTricuspid, (int)ReadingLabels.RestrictedLeafletMotionTricuspid, testReadingReadingPairs));


            if (hcpTestResult.SAM != null)
                customerEventReadingEntities.Add(CreateEventReadingEntity(hcpTestResult.SAM, (int)ReadingLabels.SAM, testReadingReadingPairs));

            if (hcpTestResult.LVOTO != null)
                customerEventReadingEntities.Add(CreateEventReadingEntity(hcpTestResult.LVOTO, (int)ReadingLabels.LVOTO, testReadingReadingPairs));

            if (hcpTestResult.MitralAnnularCa != null)
                customerEventReadingEntities.Add(CreateEventReadingEntity(hcpTestResult.MitralAnnularCa, (int)ReadingLabels.MitralAnnularCa, testReadingReadingPairs));

            if (hcpTestResult.Hypokinetic != null)
                customerEventReadingEntities.Add(CreateEventReadingEntity(hcpTestResult.Hypokinetic, (int)ReadingLabels.Hypokinetic, testReadingReadingPairs));

            if (hcpTestResult.Akinetic != null)
                customerEventReadingEntities.Add(CreateEventReadingEntity(hcpTestResult.Akinetic, (int)ReadingLabels.Akinetic, testReadingReadingPairs));

            if (hcpTestResult.Dyskinetic != null)
                customerEventReadingEntities.Add(CreateEventReadingEntity(hcpTestResult.Dyskinetic, (int)ReadingLabels.Dyskinetic, testReadingReadingPairs));

            if (hcpTestResult.Anterior != null)
                customerEventReadingEntities.Add(CreateEventReadingEntity(hcpTestResult.Anterior, (int)ReadingLabels.Anterior, testReadingReadingPairs));

            if (hcpTestResult.Posterior != null)
                customerEventReadingEntities.Add(CreateEventReadingEntity(hcpTestResult.Posterior, (int)ReadingLabels.Posterior, testReadingReadingPairs));

            if (hcpTestResult.Apical != null)
                customerEventReadingEntities.Add(CreateEventReadingEntity(hcpTestResult.Apical, (int)ReadingLabels.Apical, testReadingReadingPairs));

            if (hcpTestResult.Septal != null)
                customerEventReadingEntities.Add(CreateEventReadingEntity(hcpTestResult.Septal, (int)ReadingLabels.Septal, testReadingReadingPairs));

            if (hcpTestResult.Lateral != null)
                customerEventReadingEntities.Add(CreateEventReadingEntity(hcpTestResult.Lateral, (int)ReadingLabels.Lateral, testReadingReadingPairs));

            if (hcpTestResult.Inferior != null)
                customerEventReadingEntities.Add(CreateEventReadingEntity(hcpTestResult.Inferior, (int)ReadingLabels.Inferior, testReadingReadingPairs));

            if (hcpTestResult.AoticVelocity != null)
                customerEventReadingEntities.Add(CreateEventReadingEntity(hcpTestResult.AoticVelocity, (int)ReadingLabels.AoticVelocity, testReadingReadingPairs));

            if (hcpTestResult.MitralPT != null)
                customerEventReadingEntities.Add(CreateEventReadingEntity(hcpTestResult.MitralPT, (int)ReadingLabels.MitralPT, testReadingReadingPairs));

            if (hcpTestResult.PulmonicVelocity != null)
                customerEventReadingEntities.Add(CreateEventReadingEntity(hcpTestResult.PulmonicVelocity, (int)ReadingLabels.PulmonicVelocity, testReadingReadingPairs));

            if (hcpTestResult.TricuspidVelocity != null)
                customerEventReadingEntities.Add(CreateEventReadingEntity(hcpTestResult.TricuspidVelocity, (int)ReadingLabels.TricuspidVelocity, testReadingReadingPairs));

            if (hcpTestResult.TricuspidPap != null)
                customerEventReadingEntities.Add(CreateEventReadingEntity(hcpTestResult.TricuspidPap, (int)ReadingLabels.TricuspidPap, testReadingReadingPairs));

            if (hcpTestResult.MorphologyTricuspidHighOrGreater != null)
                customerEventReadingEntities.Add(CreateEventReadingEntity(hcpTestResult.MorphologyTricuspidHighOrGreater, (int)ReadingLabels.High35MmHgOrGreater, testReadingReadingPairs));

            if (hcpTestResult.MorphologyTricuspidNormal != null)
                customerEventReadingEntities.Add(CreateEventReadingEntity(hcpTestResult.MorphologyTricuspidNormal, (int)ReadingLabels.Normal, testReadingReadingPairs));

            testResult.ResultInterpretation = null;
            if (hcpTestResult.Finding != null)
            {
                var customerEventTestStandardFindingEntity = new CustomerEventTestStandardFindingEntity()
                {
                    StandardFindingTestReadingId =
                        (int?)new TestResultService().GetStandardFindingTestReadingIdForStandardFinding
                            ((int)TestType.HCPEcho, null, Convert.ToInt64(hcpTestResult.Finding.Id)),
                    CustomerEventTestStandardFindingId = hcpTestResult.Finding.CustomerEventStandardFindingId,
                    CustomerEventScreeningTestId = testResult.Id
                };
                customerEventScreeningTestsEntity.CustomerEventTestStandardFinding.Add(customerEventTestStandardFindingEntity);

                var finding = GetSelectedStandardFinding((int)TestType.HCPEcho, null, hcpTestResult.Finding.Id);

                if (testResult.ResultStatus.StateNumber == (int)TestResultStateNumber.Evaluated || testResult.ResultStatus.StateNumber == (int)NewTestResultStateNumber.Evaluated)
                {
                    testResult.ResultInterpretation = finding.ResultInterpretation;
                    testResult.PathwayRecommendation = finding.PathwayRecommendation;
                }
            }

            if (hcpTestResult.EstimatedEjactionFraction != null)
            {
                var customerEventTestStandardFindingEntity = new CustomerEventTestStandardFindingEntity()
                {
                    StandardFindingTestReadingId =
                        (int?)new TestResultService().GetStandardFindingTestReadingIdForStandardFinding
                            ((int)TestType.HCPEcho, (int)ReadingLabels.EstimatedEjactionFraction, Convert.ToInt64(hcpTestResult.EstimatedEjactionFraction.Id)),
                    CustomerEventTestStandardFindingId = hcpTestResult.EstimatedEjactionFraction.CustomerEventStandardFindingId,
                    CustomerEventScreeningTestId = testResult.Id
                };
                customerEventScreeningTestsEntity.CustomerEventTestStandardFinding.Add(customerEventTestStandardFindingEntity);
            }
            if (hcpTestResult.AorticRegurgitation != null)
            {
                var customerEventTestStandardFindingEntity = new CustomerEventTestStandardFindingEntity()
                {
                    StandardFindingTestReadingId =
                        (int?)new TestResultService().GetStandardFindingTestReadingIdForStandardFinding
                            ((int)TestType.HCPEcho, (int)ReadingLabels.Aortic, Convert.ToInt64(hcpTestResult.AorticRegurgitation.Id)),
                    CustomerEventTestStandardFindingId = hcpTestResult.AorticRegurgitation.CustomerEventStandardFindingId,
                    CustomerEventScreeningTestId = testResult.Id
                };
                customerEventScreeningTestsEntity.CustomerEventTestStandardFinding.Add(customerEventTestStandardFindingEntity);
            }

            if (hcpTestResult.AorticMorphology != null)
            {
                hcpTestResult.AorticMorphology.ForEach(finding =>
                {
                    var customerEventTestStandardFindingEntity = new CustomerEventTestStandardFindingEntity()
                    {
                        StandardFindingTestReadingId =
                            (int?)new TestResultService().GetStandardFindingTestReadingIdForStandardFinding
                                ((int)TestType.HCPEcho, (int)ReadingLabels.AorticMorphology, Convert.ToInt64(finding.Id)),
                        CustomerEventTestStandardFindingId = finding.CustomerEventStandardFindingId,
                        CustomerEventScreeningTestId = testResult.Id
                    };
                    customerEventScreeningTestsEntity.CustomerEventTestStandardFinding.Add(customerEventTestStandardFindingEntity);
                });
            }

            if (hcpTestResult.MitralRegurgitation != null)
            {
                var customerEventTestStandardFindingEntity = new CustomerEventTestStandardFindingEntity()
                {
                    StandardFindingTestReadingId =
                        (int?)new TestResultService().GetStandardFindingTestReadingIdForStandardFinding
                            ((int)TestType.HCPEcho, (int)ReadingLabels.Mitral, Convert.ToInt64(hcpTestResult.MitralRegurgitation.Id)),
                    CustomerEventTestStandardFindingId = hcpTestResult.MitralRegurgitation.CustomerEventStandardFindingId,
                    CustomerEventScreeningTestId = testResult.Id
                };
                customerEventScreeningTestsEntity.CustomerEventTestStandardFinding.Add(customerEventTestStandardFindingEntity);
            }

            if (hcpTestResult.MitralMorphology != null)
            {
                hcpTestResult.MitralMorphology.ForEach(finding =>
                {
                    var customerEventTestStandardFindingEntity = new CustomerEventTestStandardFindingEntity()
                    {
                        StandardFindingTestReadingId =
                            (int?)new TestResultService().GetStandardFindingTestReadingIdForStandardFinding
                                ((int)TestType.HCPEcho, (int)ReadingLabels.MitralMorphology, Convert.ToInt64(finding.Id)),
                        CustomerEventTestStandardFindingId = finding.CustomerEventStandardFindingId,
                        CustomerEventScreeningTestId = testResult.Id
                    };
                    customerEventScreeningTestsEntity.CustomerEventTestStandardFinding.Add(customerEventTestStandardFindingEntity);
                });
            }

            if (hcpTestResult.PulmonicRegurgitation != null)
            {
                var customerEventTestStandardFindingEntity = new CustomerEventTestStandardFindingEntity()
                {
                    StandardFindingTestReadingId =
                        (int?)new TestResultService().GetStandardFindingTestReadingIdForStandardFinding
                            ((int)TestType.HCPEcho, (int)ReadingLabels.Pulmonic, Convert.ToInt64(hcpTestResult.PulmonicRegurgitation.Id)),
                    CustomerEventTestStandardFindingId = hcpTestResult.PulmonicRegurgitation.CustomerEventStandardFindingId,
                    CustomerEventScreeningTestId = testResult.Id
                };
                customerEventScreeningTestsEntity.CustomerEventTestStandardFinding.Add(customerEventTestStandardFindingEntity);
            }

            if (hcpTestResult.PulmonicMorphology != null)
            {
                hcpTestResult.PulmonicMorphology.ForEach(finding =>
                {
                    var customerEventTestStandardFindingEntity = new CustomerEventTestStandardFindingEntity()
                    {
                        StandardFindingTestReadingId =
                            (int?)new TestResultService().GetStandardFindingTestReadingIdForStandardFinding
                                ((int)TestType.HCPEcho, (int)ReadingLabels.PulmonicMorphology, Convert.ToInt64(finding.Id)),
                        CustomerEventTestStandardFindingId = finding.CustomerEventStandardFindingId,
                        CustomerEventScreeningTestId = testResult.Id
                    };
                    customerEventScreeningTestsEntity.CustomerEventTestStandardFinding.Add(customerEventTestStandardFindingEntity);
                });
            }

            if (hcpTestResult.TricuspidRegurgitation != null)
            {
                var customerEventTestStandardFindingEntity = new CustomerEventTestStandardFindingEntity()
                {
                    StandardFindingTestReadingId =
                        (int?)new TestResultService().GetStandardFindingTestReadingIdForStandardFinding
                            ((int)TestType.HCPEcho, (int)ReadingLabels.Tricuspid, Convert.ToInt64(hcpTestResult.TricuspidRegurgitation.Id)),
                    CustomerEventTestStandardFindingId = hcpTestResult.TricuspidRegurgitation.CustomerEventStandardFindingId,
                    CustomerEventScreeningTestId = testResult.Id
                };
                customerEventScreeningTestsEntity.CustomerEventTestStandardFinding.Add(customerEventTestStandardFindingEntity);
            }

            if (hcpTestResult.TricuspidMorphology != null)
            {
                hcpTestResult.TricuspidMorphology.ForEach(finding =>
                {
                    var customerEventTestStandardFindingEntity = new CustomerEventTestStandardFindingEntity()
                    {
                        StandardFindingTestReadingId =
                            (int?)new TestResultService().GetStandardFindingTestReadingIdForStandardFinding
                                ((int)TestType.HCPEcho, (int)ReadingLabels.TricuspidMorphology, Convert.ToInt64(finding.Id)),
                        CustomerEventTestStandardFindingId = finding.CustomerEventStandardFindingId,
                        CustomerEventScreeningTestId = testResult.Id
                    };
                    customerEventScreeningTestsEntity.CustomerEventTestStandardFinding.Add(customerEventTestStandardFindingEntity);
                });
            }

            if (hcpTestResult.DistolicDysfunctionFinding != null)
            {
                var customerEventTestStandardFindingEntity = new CustomerEventTestStandardFindingEntity()
                {
                    StandardFindingTestReadingId =
                        (int?)new TestResultService().GetStandardFindingTestReadingIdForStandardFinding
                            ((int)TestType.HCPEcho, (int)ReadingLabels.DiastolicDysfunction, Convert.ToInt64(hcpTestResult.DistolicDysfunctionFinding.Id)),
                    CustomerEventTestStandardFindingId = hcpTestResult.DistolicDysfunctionFinding.CustomerEventStandardFindingId,
                    CustomerEventScreeningTestId = testResult.Id
                };
                customerEventScreeningTestsEntity.CustomerEventTestStandardFinding.Add(customerEventTestStandardFindingEntity);
            }

            if (hcpTestResult.PericardialEffusionFinding != null)
            {
                hcpTestResult.PericardialEffusionFinding.ForEach(finding =>
                {
                    var customerEventTestStandardFindingEntity = new CustomerEventTestStandardFindingEntity()
                    {
                        StandardFindingTestReadingId =
                            (int?)new TestResultService().GetStandardFindingTestReadingIdForStandardFinding
                                ((int)TestType.HCPEcho, (int)ReadingLabels.PericardialEffusion, Convert.ToInt64(finding.Id)),
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