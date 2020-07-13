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
    public class AwvEkgIppeTestResultFactory : TestResultFactory
    {
        public override TestResult CreateActualTestResult(CustomerEventScreeningTestsEntity customerEventScreeningTestEntity)
        {

            var customerEventReadingEntities = customerEventScreeningTestEntity.CustomerEventReading.ToList();
            var testResult = new AwvEkgIppeTestResult(customerEventScreeningTestEntity.CustomerEventScreeningTestId);

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
            var standardFindings = testResultService.GetAllStandardFindings<int?>((int)TestType.AwvEkgIPPE);
            var bundleBranchFindings = testResultService.GetAllStandardFindings<int?>((int)TestType.AwvEkgIPPE, (int)ReadingLabels.BundleBranchBlock);
            var infarctionFindings = testResultService.GetAllStandardFindings<int?>((int)TestType.AwvEkgIPPE, (int)ReadingLabels.InfarctionPattern);

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
            var awvEkgIppeTestResult = testResult as AwvEkgIppeTestResult;

            var customerEventScreeningTestEntity = new CustomerEventScreeningTestsEntity(testResult.Id) { TestId = (int)TestType.AwvEkgIPPE };
            var customerEventReadingEntities = new List<CustomerEventReadingEntity>();

            if (awvEkgIppeTestResult != null)
            {
                CustomerEventReadingEntity customerEventTestReadingEntity;
                if (awvEkgIppeTestResult.PRInterval != null)
                {
                    customerEventTestReadingEntity = CreateEventReadingEntity(awvEkgIppeTestResult.PRInterval, (int)ReadingLabels.PRInterval, testReadingReadingPairs);
                    customerEventReadingEntities.Add(customerEventTestReadingEntity);
                }

                if (awvEkgIppeTestResult.QRSDuration != null)
                {
                    customerEventTestReadingEntity = CreateEventReadingEntity(awvEkgIppeTestResult.QRSDuration, (int)ReadingLabels.QRSDuration, testReadingReadingPairs);
                    customerEventReadingEntities.Add(customerEventTestReadingEntity);
                }

                if (awvEkgIppeTestResult.PRTAxis != null)
                {
                    if (awvEkgIppeTestResult.PRTAxis.PFront != null)
                    {
                        customerEventTestReadingEntity = CreateEventReadingEntity(awvEkgIppeTestResult.PRTAxis.PFront, (int)ReadingLabels.PRTAxisPFront, testReadingReadingPairs);
                        customerEventReadingEntities.Add(customerEventTestReadingEntity);
                    }

                    if (awvEkgIppeTestResult.PRTAxis.QRSFront != null)
                    {
                        customerEventTestReadingEntity = CreateEventReadingEntity(awvEkgIppeTestResult.PRTAxis.QRSFront, (int)ReadingLabels.PRTAxisQRSFront, testReadingReadingPairs);
                        customerEventReadingEntities.Add(customerEventTestReadingEntity);
                    }

                    if (awvEkgIppeTestResult.PRTAxis.TFront != null)
                    {
                        customerEventTestReadingEntity = CreateEventReadingEntity(awvEkgIppeTestResult.PRTAxis.TFront, (int)ReadingLabels.PRTAxisTFront, testReadingReadingPairs);
                        customerEventReadingEntities.Add(customerEventTestReadingEntity);
                    }
                }

                if (awvEkgIppeTestResult.QTcInterval != null)
                {
                    customerEventTestReadingEntity = CreateEventReadingEntity(awvEkgIppeTestResult.QTcInterval, (int)ReadingLabels.QTcInterval, testReadingReadingPairs);
                    customerEventReadingEntities.Add(customerEventTestReadingEntity);
                }

                if (awvEkgIppeTestResult.QTDispersion != null)
                {

                    customerEventTestReadingEntity = CreateEventReadingEntity(awvEkgIppeTestResult.QTDispersion, (int)ReadingLabels.QTDispersion, testReadingReadingPairs);
                    customerEventReadingEntities.Add(customerEventTestReadingEntity);
                }

                if (awvEkgIppeTestResult.QTInterval != null)
                {

                    customerEventTestReadingEntity = CreateEventReadingEntity(awvEkgIppeTestResult.QTInterval, (int)ReadingLabels.QTInterval, testReadingReadingPairs);
                    customerEventReadingEntities.Add(customerEventTestReadingEntity);
                }

                if (awvEkgIppeTestResult.RRInterval != null)
                {
                    customerEventTestReadingEntity = CreateEventReadingEntity(awvEkgIppeTestResult.RRInterval, (int)ReadingLabels.RRInterval, testReadingReadingPairs);
                    customerEventReadingEntities.Add(customerEventTestReadingEntity);
                }

                if (awvEkgIppeTestResult.VentRate != null)
                {
                    customerEventTestReadingEntity = CreateEventReadingEntity(awvEkgIppeTestResult.VentRate, (int)ReadingLabels.VentRate, testReadingReadingPairs);
                    customerEventReadingEntities.Add(customerEventTestReadingEntity);
                }

                testResult.ResultInterpretation = null;
                if (awvEkgIppeTestResult.Finding != null)
                {
                    var customerEventTestStandardFindingEntity = new CustomerEventTestStandardFindingEntity
                    {
                        StandardFindingTestReadingId =
                            (int?)new TestResultService().GetStandardFindingTestReadingIdForStandardFinding((int)TestType.AwvEkgIPPE, null, Convert.ToInt64(awvEkgIppeTestResult.Finding.Id)),
                        CustomerEventTestStandardFindingId = awvEkgIppeTestResult.Finding.CustomerEventStandardFindingId,
                        CustomerEventScreeningTestId = testResult.Id,
                    };

                    var finding = GetSelectedStandardFinding((int)TestType.AwvEkgIPPE, null, awvEkgIppeTestResult.Finding.Id);

                    if (testResult.ResultStatus.StateNumber == (int)TestResultStateNumber.Evaluated || testResult.ResultStatus.StateNumber == (int)NewTestResultStateNumber.Evaluated)
                    {
                        testResult.ResultInterpretation = finding.ResultInterpretation;
                        testResult.PathwayRecommendation = finding.PathwayRecommendation;
                    }
                    customerEventScreeningTestEntity.CustomerEventTestStandardFinding.Add(customerEventTestStandardFindingEntity);
                }

                if (awvEkgIppeTestResult.BundleBranchBlockFinding != null && awvEkgIppeTestResult.BundleBranchBlockFinding.Count > 0)
                {
                    awvEkgIppeTestResult.BundleBranchBlockFinding.ForEach(finding =>
                    {
                        var customerEventTestStandardFindingEntity = new CustomerEventTestStandardFindingEntity
                        {
                            StandardFindingTestReadingId = (int?)new TestResultService().GetStandardFindingTestReadingIdForStandardFinding((int)TestType.AwvEkgIPPE, (int)ReadingLabels.BundleBranchBlock, Convert.ToInt64(finding.Id)),
                            CustomerEventTestStandardFindingId = finding.CustomerEventStandardFindingId,
                            CustomerEventScreeningTestId = testResult.Id,
                        };

                        customerEventScreeningTestEntity.CustomerEventTestStandardFinding.Add(customerEventTestStandardFindingEntity);
                    });
                }

                if (awvEkgIppeTestResult.InfarctionPatternFinding != null && awvEkgIppeTestResult.InfarctionPatternFinding.Count > 0)
                {
                    awvEkgIppeTestResult.InfarctionPatternFinding.ForEach(finding =>
                    {
                        var customerEventTestStandardFindingEntity = new CustomerEventTestStandardFindingEntity
                        {
                            StandardFindingTestReadingId =
                                (int?)
                                new TestResultService().
                                    GetStandardFindingTestReadingIdForStandardFinding
                                    ((int)TestType.AwvEkgIPPE, (int)ReadingLabels.InfarctionPattern,
                                     Convert.ToInt64(finding.Id)),
                            CustomerEventTestStandardFindingId = finding.CustomerEventStandardFindingId,
                            CustomerEventScreeningTestId = testResult.Id,
                        };

                        customerEventScreeningTestEntity.CustomerEventTestStandardFinding.Add(customerEventTestStandardFindingEntity);
                    });
                }

                if (awvEkgIppeTestResult.SinusRythm != null)
                    customerEventReadingEntities.Add(CreateEventReadingEntity(awvEkgIppeTestResult.SinusRythm, (int)ReadingLabels.SinusRythm, testReadingReadingPairs));

                if (awvEkgIppeTestResult.SinusArrythmia != null)
                    customerEventReadingEntities.Add(CreateEventReadingEntity(awvEkgIppeTestResult.SinusArrythmia, (int)ReadingLabels.SinusArrythmia, testReadingReadingPairs));

                if (awvEkgIppeTestResult.SinusBradycardia != null)
                    customerEventReadingEntities.Add(CreateEventReadingEntity(awvEkgIppeTestResult.SinusBradycardia, (int)ReadingLabels.SinusBradycardia, testReadingReadingPairs));

                if (awvEkgIppeTestResult.Mild != null)
                    customerEventReadingEntities.Add(CreateEventReadingEntity(awvEkgIppeTestResult.Mild, (int)ReadingLabels.Mild, testReadingReadingPairs));

                if (awvEkgIppeTestResult.Marked != null)
                    customerEventReadingEntities.Add(CreateEventReadingEntity(awvEkgIppeTestResult.Marked, (int)ReadingLabels.Marked, testReadingReadingPairs));

                if (awvEkgIppeTestResult.SinusTachycardia != null)
                    customerEventReadingEntities.Add(CreateEventReadingEntity(awvEkgIppeTestResult.SinusTachycardia, (int)ReadingLabels.SinusTachycardia, testReadingReadingPairs));

                if (awvEkgIppeTestResult.AtrialFibrillation != null)
                    customerEventReadingEntities.Add(CreateEventReadingEntity(awvEkgIppeTestResult.AtrialFibrillation, (int)ReadingLabels.AtrialFibrillation, testReadingReadingPairs));

                if (awvEkgIppeTestResult.AtrialFlutter != null)
                    customerEventReadingEntities.Add(CreateEventReadingEntity(awvEkgIppeTestResult.AtrialFlutter, (int)ReadingLabels.AtrialFlutter, testReadingReadingPairs));

                if (awvEkgIppeTestResult.SVT != null)
                    customerEventReadingEntities.Add(CreateEventReadingEntity(awvEkgIppeTestResult.SVT, (int)ReadingLabels.SVT, testReadingReadingPairs));

                if (awvEkgIppeTestResult.PACs != null)
                    customerEventReadingEntities.Add(CreateEventReadingEntity(awvEkgIppeTestResult.PACs, (int)ReadingLabels.PACs, testReadingReadingPairs));

                if (awvEkgIppeTestResult.PVCs != null)
                    customerEventReadingEntities.Add(CreateEventReadingEntity(awvEkgIppeTestResult.PVCs, (int)ReadingLabels.PVCs, testReadingReadingPairs));

                if (awvEkgIppeTestResult.QRSWidening != null)
                    customerEventReadingEntities.Add(CreateEventReadingEntity(awvEkgIppeTestResult.QRSWidening, (int)ReadingLabels.QRSWidening, testReadingReadingPairs));

                if (awvEkgIppeTestResult.LeftAxis != null)
                    customerEventReadingEntities.Add(CreateEventReadingEntity(awvEkgIppeTestResult.LeftAxis, (int)ReadingLabels.LeftAxis, testReadingReadingPairs));

                if (awvEkgIppeTestResult.RightAxis != null)
                    customerEventReadingEntities.Add(CreateEventReadingEntity(awvEkgIppeTestResult.RightAxis, (int)ReadingLabels.RightAxis, testReadingReadingPairs));

                if (awvEkgIppeTestResult.AbnormalAxis != null)
                    customerEventReadingEntities.Add(CreateEventReadingEntity(awvEkgIppeTestResult.AbnormalAxis, (int)ReadingLabels.AbnormalAxis, testReadingReadingPairs));

                if (awvEkgIppeTestResult.Left != null)
                    customerEventReadingEntities.Add(CreateEventReadingEntity(awvEkgIppeTestResult.Left, (int)ReadingLabels.Left, testReadingReadingPairs));

                if (awvEkgIppeTestResult.Right != null)
                    customerEventReadingEntities.Add(CreateEventReadingEntity(awvEkgIppeTestResult.Right, (int)ReadingLabels.Right, testReadingReadingPairs));

                if (awvEkgIppeTestResult.HeartBlock != null)
                    customerEventReadingEntities.Add(CreateEventReadingEntity(awvEkgIppeTestResult.HeartBlock, (int)ReadingLabels.HeartBlock, testReadingReadingPairs));

                if (awvEkgIppeTestResult.TypeI != null)
                    customerEventReadingEntities.Add(CreateEventReadingEntity(awvEkgIppeTestResult.TypeI, (int)ReadingLabels.TypeI, testReadingReadingPairs));

                if (awvEkgIppeTestResult.TypeII != null)
                    customerEventReadingEntities.Add(CreateEventReadingEntity(awvEkgIppeTestResult.TypeII, (int)ReadingLabels.TypeII, testReadingReadingPairs));

                if (awvEkgIppeTestResult.FirstDegreeBlock != null)
                    customerEventReadingEntities.Add(CreateEventReadingEntity(awvEkgIppeTestResult.FirstDegreeBlock, (int)ReadingLabels.FirstDegreeBlock, testReadingReadingPairs));

                if (awvEkgIppeTestResult.SecondDegreeBlock != null)
                    customerEventReadingEntities.Add(CreateEventReadingEntity(awvEkgIppeTestResult.SecondDegreeBlock, (int)ReadingLabels.SecondDegreeBlock, testReadingReadingPairs));

                if (awvEkgIppeTestResult.ThirdDegreeCompleteHeartBlock != null)
                    customerEventReadingEntities.Add(CreateEventReadingEntity(awvEkgIppeTestResult.ThirdDegreeCompleteHeartBlock, (int)ReadingLabels.ThirdDegreeCompleteHeartBlock, testReadingReadingPairs));

                if (awvEkgIppeTestResult.Artifact != null)
                    customerEventReadingEntities.Add(CreateEventReadingEntity(awvEkgIppeTestResult.Artifact, (int)ReadingLabels.Artifact, testReadingReadingPairs));

                if (awvEkgIppeTestResult.SupraventricularArrythmia != null)
                    customerEventReadingEntities.Add(CreateEventReadingEntity(awvEkgIppeTestResult.SupraventricularArrythmia, (int)ReadingLabels.SupraventricularArrythmia, testReadingReadingPairs));

                if (awvEkgIppeTestResult.PacerRythm != null)
                    customerEventReadingEntities.Add(CreateEventReadingEntity(awvEkgIppeTestResult.PacerRythm, (int)ReadingLabels.PacerRythm, testReadingReadingPairs));

                if (awvEkgIppeTestResult.BundleBranchBlock != null)
                    customerEventReadingEntities.Add(CreateEventReadingEntity(awvEkgIppeTestResult.BundleBranchBlock, (int)ReadingLabels.BundleBranchBlock, testReadingReadingPairs));

                if (awvEkgIppeTestResult.LeftAnteriorFasicularBlock != null)
                    customerEventReadingEntities.Add(CreateEventReadingEntity(awvEkgIppeTestResult.LeftAnteriorFasicularBlock, (int)ReadingLabels.LeftAnteriorFasicularBlock, testReadingReadingPairs));

                if (awvEkgIppeTestResult.VentricularHypertrophy != null)
                    customerEventReadingEntities.Add(CreateEventReadingEntity(awvEkgIppeTestResult.VentricularHypertrophy, (int)ReadingLabels.VentricularHypertrophy, testReadingReadingPairs));

                if (awvEkgIppeTestResult.LeftVentricularHypertrophy != null)
                    customerEventReadingEntities.Add(CreateEventReadingEntity(awvEkgIppeTestResult.LeftVentricularHypertrophy, (int)ReadingLabels.LeftVHypertrophy, testReadingReadingPairs));

                if (awvEkgIppeTestResult.RightVentricularHypertrophy != null)
                    customerEventReadingEntities.Add(CreateEventReadingEntity(awvEkgIppeTestResult.RightVentricularHypertrophy, (int)ReadingLabels.RightVHypertrophy, testReadingReadingPairs));


                if (awvEkgIppeTestResult.IschemicSTTChanges != null)
                    customerEventReadingEntities.Add(CreateEventReadingEntity(awvEkgIppeTestResult.IschemicSTTChanges, (int)ReadingLabels.IschemicSTTChanges, testReadingReadingPairs));

                if (awvEkgIppeTestResult.NonSpecificSTTChanges != null)
                    customerEventReadingEntities.Add(CreateEventReadingEntity(awvEkgIppeTestResult.NonSpecificSTTChanges, (int)ReadingLabels.NonSpecificSTTChanges, testReadingReadingPairs));

                if (awvEkgIppeTestResult.PoorRWaveProgression != null)
                    customerEventReadingEntities.Add(CreateEventReadingEntity(awvEkgIppeTestResult.PoorRWaveProgression, (int)ReadingLabels.PoorRWaveProgression, testReadingReadingPairs));

                if (awvEkgIppeTestResult.ProlongedQTInterval != null)
                    customerEventReadingEntities.Add(CreateEventReadingEntity(awvEkgIppeTestResult.ProlongedQTInterval, (int)ReadingLabels.ProlongedQTInterval, testReadingReadingPairs));

                if (awvEkgIppeTestResult.InfarctionPattern != null)
                    customerEventReadingEntities.Add(CreateEventReadingEntity(awvEkgIppeTestResult.InfarctionPattern, (int)ReadingLabels.InfarctionPattern, testReadingReadingPairs));

                if (awvEkgIppeTestResult.AtypicalQWaveLead != null)
                    customerEventReadingEntities.Add(CreateEventReadingEntity(awvEkgIppeTestResult.AtypicalQWaveLead, (int)ReadingLabels.AtypicalQWaveLead, testReadingReadingPairs));

                if (awvEkgIppeTestResult.AtrialEnlargement != null)
                    customerEventReadingEntities.Add(CreateEventReadingEntity(awvEkgIppeTestResult.AtrialEnlargement, (int)ReadingLabels.AtrialEnlargement, testReadingReadingPairs));


                if (awvEkgIppeTestResult.LeftAtrialEnlargement != null)
                    customerEventReadingEntities.Add(CreateEventReadingEntity(awvEkgIppeTestResult.LeftAtrialEnlargement, (int)ReadingLabels.LeftAtrialEnlargment, testReadingReadingPairs));

                if (awvEkgIppeTestResult.RightAtrialEnlargement != null)
                    customerEventReadingEntities.Add(CreateEventReadingEntity(awvEkgIppeTestResult.RightAtrialEnlargement, (int)ReadingLabels.RightAtrialEnlargment, testReadingReadingPairs));

                if (awvEkgIppeTestResult.RepolarizationVariant != null)
                    customerEventReadingEntities.Add(CreateEventReadingEntity(awvEkgIppeTestResult.RepolarizationVariant, (int)ReadingLabels.RepolarizationVariant, testReadingReadingPairs));

                if (awvEkgIppeTestResult.ReversedLeads != null)
                    customerEventReadingEntities.Add(CreateEventReadingEntity(awvEkgIppeTestResult.ReversedLeads, (int)ReadingLabels.ReversedLeads, testReadingReadingPairs));

                if (awvEkgIppeTestResult.RepeatStudy != null)
                    customerEventReadingEntities.Add(CreateEventReadingEntity(awvEkgIppeTestResult.RepeatStudy, (int)ReadingLabels.RepeatStudy, testReadingReadingPairs));

                if (awvEkgIppeTestResult.ComparetoEkg != null)
                    customerEventReadingEntities.Add(CreateEventReadingEntity(awvEkgIppeTestResult.ComparetoEkg, (int)ReadingLabels.ComparetoEkg, testReadingReadingPairs));

                if (awvEkgIppeTestResult.LowVoltage != null)
                    customerEventReadingEntities.Add(CreateEventReadingEntity(awvEkgIppeTestResult.LowVoltage, (int)ReadingLabels.LowVoltage, testReadingReadingPairs));

                if (awvEkgIppeTestResult.LimbLeads != null)
                    customerEventReadingEntities.Add(CreateEventReadingEntity(awvEkgIppeTestResult.LimbLeads, (int)ReadingLabels.LimbLeads, testReadingReadingPairs));

                if (awvEkgIppeTestResult.PrecordialLeads != null)
                    customerEventReadingEntities.Add(CreateEventReadingEntity(awvEkgIppeTestResult.PrecordialLeads, (int)ReadingLabels.PrecordialLeads, testReadingReadingPairs));

            }

            customerEventScreeningTestEntity.CustomerEventReading.AddRange(customerEventReadingEntities);
            return customerEventScreeningTestEntity;
        }
    }
}
