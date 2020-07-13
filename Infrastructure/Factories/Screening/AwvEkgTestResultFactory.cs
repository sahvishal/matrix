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
    public class AwvEkgTestResultFactory : TestResultFactory
    {
        public override TestResult CreateActualTestResult(CustomerEventScreeningTestsEntity customerEventScreeningTestEntity)
        {

            var customerEventReadingEntities = customerEventScreeningTestEntity.CustomerEventReading.ToList();
            var testResult = new AwvEkgTestResult(customerEventScreeningTestEntity.CustomerEventScreeningTestId);

            if (customerEventScreeningTestEntity.TestMedia != null && customerEventScreeningTestEntity.TestMedia.Count > 0)
            {
                var fileEntityCollection = customerEventScreeningTestEntity.FileCollectionViaTestMedia.ToList();
                var testMediaEntity = customerEventScreeningTestEntity.TestMedia.FirstOrDefault();
                testResult.ResultImage = new ResultMedia(testMediaEntity.MediaId);

                testResult.ResultImage.File = GetFileObjectfromEntity(testMediaEntity.FileId, fileEntityCollection);
                testResult.ResultImage.Thumbnail = testMediaEntity.ThumbnailFileId != null ? new File(testMediaEntity.ThumbnailFileId.Value) : null;

                if (testMediaEntity.IsManual)
                    testResult.ResultImage.ReadingSource = ReadingSource.Manual;
                else
                    testResult.ResultImage.ReadingSource = ReadingSource.Automatic;
            }

            var customerEventTestStandardFindingEntities = customerEventScreeningTestEntity.CustomerEventTestStandardFinding.ToList();

            var testResultService = new TestResultService();
            var standardFindings = testResultService.GetAllStandardFindings<int?>((int)TestType.AwvEkg);
            var bundleBranchFindings = testResultService.GetAllStandardFindings<int?>((int)TestType.AwvEkg, (int)ReadingLabels.BundleBranchBlock);
            var infarctionFindings = testResultService.GetAllStandardFindings<int?>((int)TestType.AwvEkg, (int)ReadingLabels.InfarctionPattern);

            var standardFindingTestReadingEntities =
                customerEventScreeningTestEntity.
                    StandardFindingTestReadingCollectionViaCustomerEventTestStandardFinding.ToList();
            customerEventTestStandardFindingEntities.ForEach(customerEventTestStandardFindingEntity =>
            {
                var standardFindingTestReadingEntity = standardFindingTestReadingEntities.Find(entity => entity.StandardFindingTestReadingId == customerEventTestStandardFindingEntity.StandardFindingTestReadingId);
                if (standardFindingTestReadingEntity == null) return;

                var standardFindingEntity = standardFindings.ToList().FindAll(standardFinding => standardFinding.Id == standardFindingTestReadingEntity.StandardFindingId).FirstOrDefault();
                if (standardFindingEntity != null)
                {
                    testResult.Finding = new StandardFinding<int?>(standardFindingEntity.Id)
                    {
                        CustomerEventStandardFindingId =
                            customerEventTestStandardFindingEntity.
                            CustomerEventTestStandardFindingId,
                        Label =
                            standardFindingEntity.Label,
                        MaxValue = Convert.ToInt32(standardFindingEntity.MaxValue),
                        MinValue = Convert.ToInt32(standardFindingEntity.MinValue)
                    };
                    return;
                }

                standardFindingEntity = bundleBranchFindings.ToList().FindAll(standardFinding => standardFinding.Id == standardFindingTestReadingEntity.StandardFindingId).FirstOrDefault();
                if (standardFindingEntity != null)
                {
                    var finding = new StandardFinding<int>(standardFindingEntity.Id)
                    {
                        CustomerEventStandardFindingId =
                            customerEventTestStandardFindingEntity.
                            CustomerEventTestStandardFindingId,
                        Label =
                            standardFindingEntity.Label,
                        MaxValue = Convert.ToInt32(standardFindingEntity.MaxValue),
                        MinValue = Convert.ToInt32(standardFindingEntity.MinValue)
                    };
                    if (testResult.BundleBranchBlockFinding == null) testResult.BundleBranchBlockFinding = new List<StandardFinding<int>>();
                    testResult.BundleBranchBlockFinding.Add(finding);
                    return;
                }

                standardFindingEntity = infarctionFindings.ToList().FindAll(standardFinding => standardFinding.Id == standardFindingTestReadingEntity.StandardFindingId).FirstOrDefault();
                if (standardFindingEntity != null)
                {
                    var finding = new StandardFinding<int>(standardFindingEntity.Id)
                    {
                        CustomerEventStandardFindingId =
                            customerEventTestStandardFindingEntity.
                            CustomerEventTestStandardFindingId,
                        Label =
                            standardFindingEntity.Label,
                        MaxValue = Convert.ToInt32(standardFindingEntity.MaxValue),
                        MinValue = Convert.ToInt32(standardFindingEntity.MinValue)
                    };
                    if (testResult.InfarctionPatternFinding == null) testResult.InfarctionPatternFinding = new List<StandardFinding<int>>();
                    testResult.InfarctionPatternFinding.Add(finding);
                    return;
                }

            });


            testResult.PRInterval = CreateResultReadingforNullableDecimal((int)ReadingLabels.PRInterval, customerEventReadingEntities);
            testResult.QRSDuration = CreateResultReadingforNullableDecimal((int)ReadingLabels.QRSDuration, customerEventReadingEntities);
            testResult.QTcInterval = CreateResultReadingforNullableDecimal((int)ReadingLabels.QTcInterval, customerEventReadingEntities);

            testResult.PRTAxis = new PRTAxis();
            testResult.PRTAxis.PFront = CreateResultReadingforNullableInt((int)ReadingLabels.PRTAxisPFront, customerEventReadingEntities);
            testResult.PRTAxis.QRSFront = CreateResultReadingforNullableInt((int)ReadingLabels.PRTAxisQRSFront, customerEventReadingEntities);
            testResult.PRTAxis.TFront = CreateResultReadingforNullableInt((int)ReadingLabels.PRTAxisTFront, customerEventReadingEntities);

            testResult.QTDispersion = CreateResultReadingforNullableInt((int)ReadingLabels.QTDispersion, customerEventReadingEntities);
            testResult.QTInterval = CreateResultReadingforNullableDecimal((int)ReadingLabels.QTInterval, customerEventReadingEntities);
            testResult.RRInterval = CreateResultReadingforNullableInt((int)ReadingLabels.RRInterval, customerEventReadingEntities);
            testResult.VentRate = CreateResultReadingforNullableInt((int)ReadingLabels.VentRate, customerEventReadingEntities);

            testResult.SinusRythm = CreateResultReading((int)ReadingLabels.SinusRythm, customerEventReadingEntities);
            testResult.SinusArrythmia = CreateResultReading((int)ReadingLabels.SinusArrythmia, customerEventReadingEntities);
            testResult.SinusBradycardia = CreateResultReading((int)ReadingLabels.SinusBradycardia, customerEventReadingEntities);
            testResult.Mild = CreateResultReading((int)ReadingLabels.Mild, customerEventReadingEntities);
            testResult.Marked = CreateResultReading((int)ReadingLabels.Marked, customerEventReadingEntities);
            testResult.SinusTachycardia = CreateResultReading((int)ReadingLabels.SinusTachycardia, customerEventReadingEntities);
            testResult.AtrialFibrillation = CreateResultReading((int)ReadingLabels.AtrialFibrillation, customerEventReadingEntities);
            testResult.AtrialFlutter = CreateResultReading((int)ReadingLabels.AtrialFlutter, customerEventReadingEntities);
            testResult.SVT = CreateResultReading((int)ReadingLabels.SVT, customerEventReadingEntities);
            testResult.PACs = CreateResultReading((int)ReadingLabels.PACs, customerEventReadingEntities);
            testResult.PVCs = CreateResultReading((int)ReadingLabels.PVCs, customerEventReadingEntities);
            testResult.QRSWidening = CreateResultReading((int)ReadingLabels.QRSWidening, customerEventReadingEntities);
            testResult.LeftAxis = CreateResultReading((int)ReadingLabels.LeftAxis, customerEventReadingEntities);
            testResult.RightAxis = CreateResultReading((int)ReadingLabels.RightAxis, customerEventReadingEntities);
            testResult.AbnormalAxis = CreateResultReading((int)ReadingLabels.AbnormalAxis, customerEventReadingEntities);
            testResult.Left = CreateResultReading((int)ReadingLabels.Left, customerEventReadingEntities);
            testResult.Right = CreateResultReading((int)ReadingLabels.Right, customerEventReadingEntities);
            testResult.HeartBlock = CreateResultReading((int)ReadingLabels.HeartBlock, customerEventReadingEntities);
            testResult.TypeI = CreateResultReading((int)ReadingLabels.TypeI, customerEventReadingEntities);
            testResult.TypeII = CreateResultReading((int)ReadingLabels.TypeII, customerEventReadingEntities);
            testResult.FirstDegreeBlock = CreateResultReading((int)ReadingLabels.FirstDegreeBlock, customerEventReadingEntities);
            testResult.SecondDegreeBlock = CreateResultReading((int)ReadingLabels.SecondDegreeBlock, customerEventReadingEntities);
            testResult.ThirdDegreeCompleteHeartBlock = CreateResultReading((int)ReadingLabels.ThirdDegreeCompleteHeartBlock, customerEventReadingEntities);
            testResult.Artifact = CreateResultReading((int)ReadingLabels.Artifact, customerEventReadingEntities);

            testResult.ShortPrInterval = CreateResultReading((int)ReadingLabels.ShortPrInterval, customerEventReadingEntities);

            testResult.BundleBranchBlock = CreateResultReading((int)ReadingLabels.BundleBranchBlock, customerEventReadingEntities);
            testResult.LeftAnteriorFasicularBlock = CreateResultReading((int)ReadingLabels.LeftAnteriorFasicularBlock, customerEventReadingEntities);
            testResult.VentricularHypertrophy = CreateResultReading((int)ReadingLabels.VentricularHypertrophy, customerEventReadingEntities);
            testResult.LeftVentricularHypertrophy = CreateResultReading((int)ReadingLabels.LeftVHypertrophy, customerEventReadingEntities);
            testResult.RightVentricularHypertrophy = CreateResultReading((int)ReadingLabels.RightVHypertrophy, customerEventReadingEntities);
            testResult.ProlongedQTInterval = CreateResultReading((int)ReadingLabels.ProlongedQTInterval, customerEventReadingEntities);
            testResult.IschemicSTTChanges = CreateResultReading((int)ReadingLabels.IschemicSTTChanges, customerEventReadingEntities);
            testResult.NonSpecificSTTChanges = CreateResultReading((int)ReadingLabels.NonSpecificSTTChanges, customerEventReadingEntities);
            testResult.PoorRWaveProgression = CreateResultReading((int)ReadingLabels.PoorRWaveProgression, customerEventReadingEntities);
            testResult.InfarctionPattern = CreateResultReading((int)ReadingLabels.InfarctionPattern, customerEventReadingEntities);
            testResult.AtypicalQWaveLead = CreateResultReading((int)ReadingLabels.AtypicalQWaveLead, customerEventReadingEntities);
            testResult.AtrialEnlargement = CreateResultReading((int)ReadingLabels.AtrialEnlargement, customerEventReadingEntities);
            testResult.LeftAtrialEnlargement = CreateResultReading((int)ReadingLabels.LeftAtrialEnlargment, customerEventReadingEntities);
            testResult.RightAtrialEnlargement = CreateResultReading((int)ReadingLabels.RightAtrialEnlargment, customerEventReadingEntities);
            testResult.RepolarizationVariant = CreateResultReading((int)ReadingLabels.RepolarizationVariant, customerEventReadingEntities);
            testResult.PacerRythm = CreateResultReading((int)ReadingLabels.PacerRythm, customerEventReadingEntities);
            testResult.SupraventricularArrythmia = CreateResultReading((int)ReadingLabels.SupraventricularArrythmia, customerEventReadingEntities);

            testResult.ReversedLeads = CreateResultReading((int)ReadingLabels.ReversedLeads, customerEventReadingEntities);
            testResult.RepeatStudy = CreateResultReading((int)ReadingLabels.RepeatStudy, customerEventReadingEntities);
            testResult.ComparetoEkg = CreateResultReading((int)ReadingLabels.ComparetoEkg, customerEventReadingEntities);

            testResult.LowVoltage = CreateResultReading((int)ReadingLabels.LowVoltage, customerEventReadingEntities);
            testResult.LimbLeads = CreateResultReading((int)ReadingLabels.LimbLeads, customerEventReadingEntities);
            testResult.PrecordialLeads = CreateResultReading((int)ReadingLabels.PrecordialLeads, customerEventReadingEntities);

            return testResult;
        }

        public override CustomerEventScreeningTestsEntity CreateActualTestResultEntity(TestResult testResult, List<OrderedPair<int, int>> testReadingReadingPairs)
        {
            var awvEkgTestResult = testResult as AwvEkgTestResult;

            var customerEventScreeningTestEntity = new CustomerEventScreeningTestsEntity(testResult.Id) { TestId = (int)TestType.AwvEkg };
            var customerEventReadingEntities = new List<CustomerEventReadingEntity>();

            if (awvEkgTestResult != null)
            {
                CustomerEventReadingEntity customerEventTestReadingEntity;
                if (awvEkgTestResult.PRInterval != null)
                {
                    customerEventTestReadingEntity = CreateEventReadingEntity(awvEkgTestResult.PRInterval, (int)ReadingLabels.PRInterval, testReadingReadingPairs);
                    customerEventReadingEntities.Add(customerEventTestReadingEntity);
                }

                if (awvEkgTestResult.QRSDuration != null)
                {
                    customerEventTestReadingEntity = CreateEventReadingEntity(awvEkgTestResult.QRSDuration, (int)ReadingLabels.QRSDuration, testReadingReadingPairs);
                    customerEventReadingEntities.Add(customerEventTestReadingEntity);
                }

                if (awvEkgTestResult.PRTAxis != null)
                {
                    if (awvEkgTestResult.PRTAxis.PFront != null)
                    {
                        customerEventTestReadingEntity = CreateEventReadingEntity(awvEkgTestResult.PRTAxis.PFront, (int)ReadingLabels.PRTAxisPFront, testReadingReadingPairs);
                        customerEventReadingEntities.Add(customerEventTestReadingEntity);
                    }

                    if (awvEkgTestResult.PRTAxis.QRSFront != null)
                    {
                        customerEventTestReadingEntity = CreateEventReadingEntity(awvEkgTestResult.PRTAxis.QRSFront, (int)ReadingLabels.PRTAxisQRSFront, testReadingReadingPairs);
                        customerEventReadingEntities.Add(customerEventTestReadingEntity);
                    }

                    if (awvEkgTestResult.PRTAxis.TFront != null)
                    {
                        customerEventTestReadingEntity = CreateEventReadingEntity(awvEkgTestResult.PRTAxis.TFront, (int)ReadingLabels.PRTAxisTFront, testReadingReadingPairs);
                        customerEventReadingEntities.Add(customerEventTestReadingEntity);
                    }
                }

                if (awvEkgTestResult.QTcInterval != null)
                {
                    customerEventTestReadingEntity = CreateEventReadingEntity(awvEkgTestResult.QTcInterval, (int)ReadingLabels.QTcInterval, testReadingReadingPairs);
                    customerEventReadingEntities.Add(customerEventTestReadingEntity);
                }

                if (awvEkgTestResult.QTDispersion != null)
                {

                    customerEventTestReadingEntity = CreateEventReadingEntity(awvEkgTestResult.QTDispersion, (int)ReadingLabels.QTDispersion, testReadingReadingPairs);
                    customerEventReadingEntities.Add(customerEventTestReadingEntity);
                }

                if (awvEkgTestResult.QTInterval != null)
                {

                    customerEventTestReadingEntity = CreateEventReadingEntity(awvEkgTestResult.QTInterval, (int)ReadingLabels.QTInterval, testReadingReadingPairs);
                    customerEventReadingEntities.Add(customerEventTestReadingEntity);
                }

                if (awvEkgTestResult.RRInterval != null)
                {
                    customerEventTestReadingEntity = CreateEventReadingEntity(awvEkgTestResult.RRInterval, (int)ReadingLabels.RRInterval, testReadingReadingPairs);
                    customerEventReadingEntities.Add(customerEventTestReadingEntity);
                }

                if (awvEkgTestResult.VentRate != null)
                {
                    customerEventTestReadingEntity = CreateEventReadingEntity(awvEkgTestResult.VentRate, (int)ReadingLabels.VentRate, testReadingReadingPairs);
                    customerEventReadingEntities.Add(customerEventTestReadingEntity);
                }

                testResult.ResultInterpretation = null;
                if (awvEkgTestResult.Finding != null)
                {
                    var customerEventTestStandardFindingEntity = new CustomerEventTestStandardFindingEntity
                    {
                        StandardFindingTestReadingId =
                            (int?)new TestResultService().GetStandardFindingTestReadingIdForStandardFinding((int)TestType.AwvEkg, null, Convert.ToInt64(awvEkgTestResult.Finding.Id)),
                        CustomerEventTestStandardFindingId = awvEkgTestResult.Finding.CustomerEventStandardFindingId,
                        CustomerEventScreeningTestId = testResult.Id,
                    };

                    var finding = GetSelectedStandardFinding((int)TestType.AwvEkg, null, awvEkgTestResult.Finding.Id);

                    if (testResult.ResultStatus.StateNumber == (int)TestResultStateNumber.Evaluated || testResult.ResultStatus.StateNumber == (int)NewTestResultStateNumber.Evaluated)
                    {
                        testResult.ResultInterpretation = finding.ResultInterpretation;
                        testResult.PathwayRecommendation = finding.PathwayRecommendation;
                    }
                    customerEventScreeningTestEntity.CustomerEventTestStandardFinding.Add(customerEventTestStandardFindingEntity);
                }

                if (awvEkgTestResult.BundleBranchBlockFinding != null && awvEkgTestResult.BundleBranchBlockFinding.Count > 0)
                {
                    awvEkgTestResult.BundleBranchBlockFinding.ForEach(finding =>
                    {
                        var customerEventTestStandardFindingEntity = new CustomerEventTestStandardFindingEntity
                        {
                            StandardFindingTestReadingId = (int?)new TestResultService().GetStandardFindingTestReadingIdForStandardFinding((int)TestType.AwvEkg, (int)ReadingLabels.BundleBranchBlock, Convert.ToInt64(finding.Id)),
                            CustomerEventTestStandardFindingId = finding.CustomerEventStandardFindingId,
                            CustomerEventScreeningTestId = testResult.Id,
                        };

                        customerEventScreeningTestEntity.CustomerEventTestStandardFinding.Add(customerEventTestStandardFindingEntity);
                    });
                }

                if (awvEkgTestResult.InfarctionPatternFinding != null && awvEkgTestResult.InfarctionPatternFinding.Count > 0)
                {
                    awvEkgTestResult.InfarctionPatternFinding.ForEach(finding =>
                    {
                        var customerEventTestStandardFindingEntity = new CustomerEventTestStandardFindingEntity
                        {
                            StandardFindingTestReadingId =
                                (int?)
                                new TestResultService().
                                    GetStandardFindingTestReadingIdForStandardFinding
                                    ((int)TestType.AwvEkg, (int)ReadingLabels.InfarctionPattern,
                                     Convert.ToInt64(finding.Id)),
                            CustomerEventTestStandardFindingId = finding.CustomerEventStandardFindingId,
                            CustomerEventScreeningTestId = testResult.Id,
                        };

                        customerEventScreeningTestEntity.CustomerEventTestStandardFinding.Add(customerEventTestStandardFindingEntity);
                    });
                }

                if (awvEkgTestResult.SinusRythm != null)
                    customerEventReadingEntities.Add(CreateEventReadingEntity(awvEkgTestResult.SinusRythm, (int)ReadingLabels.SinusRythm, testReadingReadingPairs));

                if (awvEkgTestResult.SinusArrythmia != null)
                    customerEventReadingEntities.Add(CreateEventReadingEntity(awvEkgTestResult.SinusArrythmia, (int)ReadingLabels.SinusArrythmia, testReadingReadingPairs));

                if (awvEkgTestResult.SinusBradycardia != null)
                    customerEventReadingEntities.Add(CreateEventReadingEntity(awvEkgTestResult.SinusBradycardia, (int)ReadingLabels.SinusBradycardia, testReadingReadingPairs));

                if (awvEkgTestResult.Mild != null)
                    customerEventReadingEntities.Add(CreateEventReadingEntity(awvEkgTestResult.Mild, (int)ReadingLabels.Mild, testReadingReadingPairs));

                if (awvEkgTestResult.Marked != null)
                    customerEventReadingEntities.Add(CreateEventReadingEntity(awvEkgTestResult.Marked, (int)ReadingLabels.Marked, testReadingReadingPairs));

                if (awvEkgTestResult.SinusTachycardia != null)
                    customerEventReadingEntities.Add(CreateEventReadingEntity(awvEkgTestResult.SinusTachycardia, (int)ReadingLabels.SinusTachycardia, testReadingReadingPairs));

                if (awvEkgTestResult.AtrialFibrillation != null)
                    customerEventReadingEntities.Add(CreateEventReadingEntity(awvEkgTestResult.AtrialFibrillation, (int)ReadingLabels.AtrialFibrillation, testReadingReadingPairs));

                if (awvEkgTestResult.AtrialFlutter != null)
                    customerEventReadingEntities.Add(CreateEventReadingEntity(awvEkgTestResult.AtrialFlutter, (int)ReadingLabels.AtrialFlutter, testReadingReadingPairs));

                if (awvEkgTestResult.SVT != null)
                    customerEventReadingEntities.Add(CreateEventReadingEntity(awvEkgTestResult.SVT, (int)ReadingLabels.SVT, testReadingReadingPairs));

                if (awvEkgTestResult.PACs != null)
                    customerEventReadingEntities.Add(CreateEventReadingEntity(awvEkgTestResult.PACs, (int)ReadingLabels.PACs, testReadingReadingPairs));

                if (awvEkgTestResult.PVCs != null)
                    customerEventReadingEntities.Add(CreateEventReadingEntity(awvEkgTestResult.PVCs, (int)ReadingLabels.PVCs, testReadingReadingPairs));

                if (awvEkgTestResult.QRSWidening != null)
                    customerEventReadingEntities.Add(CreateEventReadingEntity(awvEkgTestResult.QRSWidening, (int)ReadingLabels.QRSWidening, testReadingReadingPairs));

                if (awvEkgTestResult.LeftAxis != null)
                    customerEventReadingEntities.Add(CreateEventReadingEntity(awvEkgTestResult.LeftAxis, (int)ReadingLabels.LeftAxis, testReadingReadingPairs));

                if (awvEkgTestResult.RightAxis != null)
                    customerEventReadingEntities.Add(CreateEventReadingEntity(awvEkgTestResult.RightAxis, (int)ReadingLabels.RightAxis, testReadingReadingPairs));

                if (awvEkgTestResult.AbnormalAxis != null)
                    customerEventReadingEntities.Add(CreateEventReadingEntity(awvEkgTestResult.AbnormalAxis, (int)ReadingLabels.AbnormalAxis, testReadingReadingPairs));

                if (awvEkgTestResult.Left != null)
                    customerEventReadingEntities.Add(CreateEventReadingEntity(awvEkgTestResult.Left, (int)ReadingLabels.Left, testReadingReadingPairs));

                if (awvEkgTestResult.Right != null)
                    customerEventReadingEntities.Add(CreateEventReadingEntity(awvEkgTestResult.Right, (int)ReadingLabels.Right, testReadingReadingPairs));

                if (awvEkgTestResult.HeartBlock != null)
                    customerEventReadingEntities.Add(CreateEventReadingEntity(awvEkgTestResult.HeartBlock, (int)ReadingLabels.HeartBlock, testReadingReadingPairs));

                if (awvEkgTestResult.TypeI != null)
                    customerEventReadingEntities.Add(CreateEventReadingEntity(awvEkgTestResult.TypeI, (int)ReadingLabels.TypeI, testReadingReadingPairs));

                if (awvEkgTestResult.TypeII != null)
                    customerEventReadingEntities.Add(CreateEventReadingEntity(awvEkgTestResult.TypeII, (int)ReadingLabels.TypeII, testReadingReadingPairs));

                if (awvEkgTestResult.FirstDegreeBlock != null)
                    customerEventReadingEntities.Add(CreateEventReadingEntity(awvEkgTestResult.FirstDegreeBlock, (int)ReadingLabels.FirstDegreeBlock, testReadingReadingPairs));

                if (awvEkgTestResult.SecondDegreeBlock != null)
                    customerEventReadingEntities.Add(CreateEventReadingEntity(awvEkgTestResult.SecondDegreeBlock, (int)ReadingLabels.SecondDegreeBlock, testReadingReadingPairs));

                if (awvEkgTestResult.ThirdDegreeCompleteHeartBlock != null)
                    customerEventReadingEntities.Add(CreateEventReadingEntity(awvEkgTestResult.ThirdDegreeCompleteHeartBlock, (int)ReadingLabels.ThirdDegreeCompleteHeartBlock, testReadingReadingPairs));

                if (awvEkgTestResult.Artifact != null)
                    customerEventReadingEntities.Add(CreateEventReadingEntity(awvEkgTestResult.Artifact, (int)ReadingLabels.Artifact, testReadingReadingPairs));

                if (awvEkgTestResult.SupraventricularArrythmia != null)
                    customerEventReadingEntities.Add(CreateEventReadingEntity(awvEkgTestResult.SupraventricularArrythmia, (int)ReadingLabels.SupraventricularArrythmia, testReadingReadingPairs));

                if (awvEkgTestResult.PacerRythm != null)
                    customerEventReadingEntities.Add(CreateEventReadingEntity(awvEkgTestResult.PacerRythm, (int)ReadingLabels.PacerRythm, testReadingReadingPairs));

                if (awvEkgTestResult.BundleBranchBlock != null)
                    customerEventReadingEntities.Add(CreateEventReadingEntity(awvEkgTestResult.BundleBranchBlock, (int)ReadingLabels.BundleBranchBlock, testReadingReadingPairs));

                if (awvEkgTestResult.LeftAnteriorFasicularBlock != null)
                    customerEventReadingEntities.Add(CreateEventReadingEntity(awvEkgTestResult.LeftAnteriorFasicularBlock, (int)ReadingLabels.LeftAnteriorFasicularBlock, testReadingReadingPairs));

                if (awvEkgTestResult.VentricularHypertrophy != null)
                    customerEventReadingEntities.Add(CreateEventReadingEntity(awvEkgTestResult.VentricularHypertrophy, (int)ReadingLabels.VentricularHypertrophy, testReadingReadingPairs));

                if (awvEkgTestResult.LeftVentricularHypertrophy != null)
                    customerEventReadingEntities.Add(CreateEventReadingEntity(awvEkgTestResult.LeftVentricularHypertrophy, (int)ReadingLabels.LeftVHypertrophy, testReadingReadingPairs));

                if (awvEkgTestResult.RightVentricularHypertrophy != null)
                    customerEventReadingEntities.Add(CreateEventReadingEntity(awvEkgTestResult.RightVentricularHypertrophy, (int)ReadingLabels.RightVHypertrophy, testReadingReadingPairs));


                if (awvEkgTestResult.IschemicSTTChanges != null)
                    customerEventReadingEntities.Add(CreateEventReadingEntity(awvEkgTestResult.IschemicSTTChanges, (int)ReadingLabels.IschemicSTTChanges, testReadingReadingPairs));

                if (awvEkgTestResult.NonSpecificSTTChanges != null)
                    customerEventReadingEntities.Add(CreateEventReadingEntity(awvEkgTestResult.NonSpecificSTTChanges, (int)ReadingLabels.NonSpecificSTTChanges, testReadingReadingPairs));

                if (awvEkgTestResult.PoorRWaveProgression != null)
                    customerEventReadingEntities.Add(CreateEventReadingEntity(awvEkgTestResult.PoorRWaveProgression, (int)ReadingLabels.PoorRWaveProgression, testReadingReadingPairs));

                if (awvEkgTestResult.ProlongedQTInterval != null)
                    customerEventReadingEntities.Add(CreateEventReadingEntity(awvEkgTestResult.ProlongedQTInterval, (int)ReadingLabels.ProlongedQTInterval, testReadingReadingPairs));

                if (awvEkgTestResult.InfarctionPattern != null)
                    customerEventReadingEntities.Add(CreateEventReadingEntity(awvEkgTestResult.InfarctionPattern, (int)ReadingLabels.InfarctionPattern, testReadingReadingPairs));

                if (awvEkgTestResult.AtypicalQWaveLead != null)
                    customerEventReadingEntities.Add(CreateEventReadingEntity(awvEkgTestResult.AtypicalQWaveLead, (int)ReadingLabels.AtypicalQWaveLead, testReadingReadingPairs));

                if (awvEkgTestResult.AtrialEnlargement != null)
                    customerEventReadingEntities.Add(CreateEventReadingEntity(awvEkgTestResult.AtrialEnlargement, (int)ReadingLabels.AtrialEnlargement, testReadingReadingPairs));


                if (awvEkgTestResult.LeftAtrialEnlargement != null)
                    customerEventReadingEntities.Add(CreateEventReadingEntity(awvEkgTestResult.LeftAtrialEnlargement, (int)ReadingLabels.LeftAtrialEnlargment, testReadingReadingPairs));

                if (awvEkgTestResult.RightAtrialEnlargement != null)
                    customerEventReadingEntities.Add(CreateEventReadingEntity(awvEkgTestResult.RightAtrialEnlargement, (int)ReadingLabels.RightAtrialEnlargment, testReadingReadingPairs));

                if (awvEkgTestResult.RepolarizationVariant != null)
                    customerEventReadingEntities.Add(CreateEventReadingEntity(awvEkgTestResult.RepolarizationVariant, (int)ReadingLabels.RepolarizationVariant, testReadingReadingPairs));

                if (awvEkgTestResult.ReversedLeads != null)
                    customerEventReadingEntities.Add(CreateEventReadingEntity(awvEkgTestResult.ReversedLeads, (int)ReadingLabels.ReversedLeads, testReadingReadingPairs));

                if (awvEkgTestResult.RepeatStudy != null)
                    customerEventReadingEntities.Add(CreateEventReadingEntity(awvEkgTestResult.RepeatStudy, (int)ReadingLabels.RepeatStudy, testReadingReadingPairs));

                if (awvEkgTestResult.ComparetoEkg != null)
                    customerEventReadingEntities.Add(CreateEventReadingEntity(awvEkgTestResult.ComparetoEkg, (int)ReadingLabels.ComparetoEkg, testReadingReadingPairs));

                if (awvEkgTestResult.LowVoltage != null)
                    customerEventReadingEntities.Add(CreateEventReadingEntity(awvEkgTestResult.LowVoltage, (int)ReadingLabels.LowVoltage, testReadingReadingPairs));

                if (awvEkgTestResult.LimbLeads != null)
                    customerEventReadingEntities.Add(CreateEventReadingEntity(awvEkgTestResult.LimbLeads, (int)ReadingLabels.LimbLeads, testReadingReadingPairs));

                if (awvEkgTestResult.PrecordialLeads != null)
                    customerEventReadingEntities.Add(CreateEventReadingEntity(awvEkgTestResult.PrecordialLeads, (int)ReadingLabels.PrecordialLeads, testReadingReadingPairs));

                if (awvEkgTestResult.ShortPrInterval != null)
                    customerEventReadingEntities.Add(CreateEventReadingEntity(awvEkgTestResult.ShortPrInterval, (int)ReadingLabels.ShortPrInterval, testReadingReadingPairs));
            }

            customerEventScreeningTestEntity.CustomerEventReading.AddRange(customerEventReadingEntities);
            return customerEventScreeningTestEntity;
        }
    }
}
