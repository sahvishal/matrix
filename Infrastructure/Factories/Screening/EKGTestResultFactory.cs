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
    public class EkgTestResultFactory : TestResultFactory
    {
        public override TestResult CreateActualTestResult(CustomerEventScreeningTestsEntity customerEventScreeningTestEntity)
        {

            var customerEventReadingEntities = customerEventScreeningTestEntity.CustomerEventReading.ToList();
            var testResult = new EKGTestResult(customerEventScreeningTestEntity.CustomerEventScreeningTestId);

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
            var standardFindings = testResultService.GetAllStandardFindings<int?>((int)TestType.EKG);
            var bundleBranchFindings = testResultService.GetAllStandardFindings<int?>((int)TestType.EKG, (int)ReadingLabels.BundleBranchBlock);
            var infarctionFindings = testResultService.GetAllStandardFindings<int?>((int)TestType.EKG, (int)ReadingLabels.InfarctionPattern);

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
            var ekgTestResult = testResult as EKGTestResult;

            var customerEventScreeningTestEntity = new CustomerEventScreeningTestsEntity(testResult.Id) { TestId = (int)TestType.EKG };
            var customerEventReadingEntities = new List<CustomerEventReadingEntity>();

            if (ekgTestResult != null)
            {
                CustomerEventReadingEntity customerEventTestReadingEntity;
                if (ekgTestResult.PRInterval != null)
                {
                    customerEventTestReadingEntity = CreateEventReadingEntity(ekgTestResult.PRInterval, (int)ReadingLabels.PRInterval, testReadingReadingPairs);
                    customerEventReadingEntities.Add(customerEventTestReadingEntity);
                }

                if (ekgTestResult.QRSDuration != null)
                {
                    customerEventTestReadingEntity = CreateEventReadingEntity(ekgTestResult.QRSDuration, (int)ReadingLabels.QRSDuration, testReadingReadingPairs);
                    customerEventReadingEntities.Add(customerEventTestReadingEntity);
                }

                if (ekgTestResult.PRTAxis != null)
                {
                    if (ekgTestResult.PRTAxis.PFront != null)
                    {
                        customerEventTestReadingEntity = CreateEventReadingEntity(ekgTestResult.PRTAxis.PFront, (int)ReadingLabels.PRTAxisPFront, testReadingReadingPairs);
                        customerEventReadingEntities.Add(customerEventTestReadingEntity);
                    }

                    if (ekgTestResult.PRTAxis.QRSFront != null)
                    {
                        customerEventTestReadingEntity = CreateEventReadingEntity(ekgTestResult.PRTAxis.QRSFront, (int)ReadingLabels.PRTAxisQRSFront, testReadingReadingPairs);
                        customerEventReadingEntities.Add(customerEventTestReadingEntity);
                    }

                    if (ekgTestResult.PRTAxis.TFront != null)
                    {
                        customerEventTestReadingEntity = CreateEventReadingEntity(ekgTestResult.PRTAxis.TFront, (int)ReadingLabels.PRTAxisTFront, testReadingReadingPairs);
                        customerEventReadingEntities.Add(customerEventTestReadingEntity);
                    }
                }

                if (ekgTestResult.QTcInterval != null)
                {
                    customerEventTestReadingEntity = CreateEventReadingEntity(ekgTestResult.QTcInterval, (int)ReadingLabels.QTcInterval, testReadingReadingPairs);
                    customerEventReadingEntities.Add(customerEventTestReadingEntity);
                }

                if (ekgTestResult.QTDispersion != null)
                {

                    customerEventTestReadingEntity = CreateEventReadingEntity(ekgTestResult.QTDispersion, (int)ReadingLabels.QTDispersion, testReadingReadingPairs);
                    customerEventReadingEntities.Add(customerEventTestReadingEntity);
                }

                if (ekgTestResult.QTInterval != null)
                {

                    customerEventTestReadingEntity = CreateEventReadingEntity(ekgTestResult.QTInterval, (int)ReadingLabels.QTInterval, testReadingReadingPairs);
                    customerEventReadingEntities.Add(customerEventTestReadingEntity);
                }

                if (ekgTestResult.RRInterval != null)
                {
                    customerEventTestReadingEntity = CreateEventReadingEntity(ekgTestResult.RRInterval, (int)ReadingLabels.RRInterval, testReadingReadingPairs);
                    customerEventReadingEntities.Add(customerEventTestReadingEntity);
                }

                if (ekgTestResult.VentRate != null)
                {
                    customerEventTestReadingEntity = CreateEventReadingEntity(ekgTestResult.VentRate, (int)ReadingLabels.VentRate, testReadingReadingPairs);
                    customerEventReadingEntities.Add(customerEventTestReadingEntity);
                }

                testResult.ResultInterpretation = null;
                if (ekgTestResult.Finding != null)
                {
                    var customerEventTestStandardFindingEntity = new CustomerEventTestStandardFindingEntity
                                                                     {
                                                                         StandardFindingTestReadingId =
                                                                             (int?)new TestResultService().GetStandardFindingTestReadingIdForStandardFinding((int)TestType.EKG, null, Convert.ToInt64(ekgTestResult.Finding.Id)),
                                                                         CustomerEventTestStandardFindingId = ekgTestResult.Finding.CustomerEventStandardFindingId,
                                                                         CustomerEventScreeningTestId = testResult.Id,
                                                                     };

                    var finding = GetSelectedStandardFinding((int)TestType.EKG, null, ekgTestResult.Finding.Id);

                    if (testResult.ResultStatus.StateNumber == (int)TestResultStateNumber.Evaluated || testResult.ResultStatus.StateNumber == (int)NewTestResultStateNumber.Evaluated)
                    {
                        testResult.ResultInterpretation = finding.ResultInterpretation;
                        testResult.PathwayRecommendation = finding.PathwayRecommendation;
                    }
                    customerEventScreeningTestEntity.CustomerEventTestStandardFinding.Add(customerEventTestStandardFindingEntity);
                }

                if (ekgTestResult.BundleBranchBlockFinding != null && ekgTestResult.BundleBranchBlockFinding.Count > 0)
                {
                    ekgTestResult.BundleBranchBlockFinding.ForEach(finding =>
                    {
                        var customerEventTestStandardFindingEntity = new CustomerEventTestStandardFindingEntity
                        {
                            StandardFindingTestReadingId = (int?)new TestResultService().GetStandardFindingTestReadingIdForStandardFinding((int)TestType.EKG, (int)ReadingLabels.BundleBranchBlock, Convert.ToInt64(finding.Id)),
                            CustomerEventTestStandardFindingId = finding.CustomerEventStandardFindingId,
                            CustomerEventScreeningTestId = testResult.Id,
                        };

                        customerEventScreeningTestEntity.CustomerEventTestStandardFinding.Add(customerEventTestStandardFindingEntity);
                    });
                }

                if (ekgTestResult.InfarctionPatternFinding != null && ekgTestResult.InfarctionPatternFinding.Count > 0)
                {
                    ekgTestResult.InfarctionPatternFinding.ForEach(finding =>
                    {
                        var customerEventTestStandardFindingEntity = new CustomerEventTestStandardFindingEntity
                        {
                            StandardFindingTestReadingId =
                                (int?)
                                new TestResultService().
                                    GetStandardFindingTestReadingIdForStandardFinding
                                    ((int)TestType.EKG, (int)ReadingLabels.InfarctionPattern,
                                     Convert.ToInt64(finding.Id)),
                            CustomerEventTestStandardFindingId = finding.CustomerEventStandardFindingId,
                            CustomerEventScreeningTestId = testResult.Id,
                        };

                        customerEventScreeningTestEntity.CustomerEventTestStandardFinding.Add(customerEventTestStandardFindingEntity);
                    });
                }

                if (ekgTestResult.SinusRythm != null)
                    customerEventReadingEntities.Add(CreateEventReadingEntity(ekgTestResult.SinusRythm, (int)ReadingLabels.SinusRythm, testReadingReadingPairs));

                if (ekgTestResult.SinusArrythmia != null)
                    customerEventReadingEntities.Add(CreateEventReadingEntity(ekgTestResult.SinusArrythmia, (int)ReadingLabels.SinusArrythmia, testReadingReadingPairs));

                if (ekgTestResult.SinusBradycardia != null)
                    customerEventReadingEntities.Add(CreateEventReadingEntity(ekgTestResult.SinusBradycardia, (int)ReadingLabels.SinusBradycardia, testReadingReadingPairs));

                if (ekgTestResult.Mild != null)
                    customerEventReadingEntities.Add(CreateEventReadingEntity(ekgTestResult.Mild, (int)ReadingLabels.Mild, testReadingReadingPairs));

                if (ekgTestResult.Marked != null)
                    customerEventReadingEntities.Add(CreateEventReadingEntity(ekgTestResult.Marked, (int)ReadingLabels.Marked, testReadingReadingPairs));

                if (ekgTestResult.SinusTachycardia != null)
                    customerEventReadingEntities.Add(CreateEventReadingEntity(ekgTestResult.SinusTachycardia, (int)ReadingLabels.SinusTachycardia, testReadingReadingPairs));

                if (ekgTestResult.AtrialFibrillation != null)
                    customerEventReadingEntities.Add(CreateEventReadingEntity(ekgTestResult.AtrialFibrillation, (int)ReadingLabels.AtrialFibrillation, testReadingReadingPairs));

                if (ekgTestResult.AtrialFlutter != null)
                    customerEventReadingEntities.Add(CreateEventReadingEntity(ekgTestResult.AtrialFlutter, (int)ReadingLabels.AtrialFlutter, testReadingReadingPairs));

                if (ekgTestResult.SVT != null)
                    customerEventReadingEntities.Add(CreateEventReadingEntity(ekgTestResult.SVT, (int)ReadingLabels.SVT, testReadingReadingPairs));

                if (ekgTestResult.PACs != null)
                    customerEventReadingEntities.Add(CreateEventReadingEntity(ekgTestResult.PACs, (int)ReadingLabels.PACs, testReadingReadingPairs));

                if (ekgTestResult.PVCs != null)
                    customerEventReadingEntities.Add(CreateEventReadingEntity(ekgTestResult.PVCs, (int)ReadingLabels.PVCs, testReadingReadingPairs));

                if (ekgTestResult.QRSWidening != null)
                    customerEventReadingEntities.Add(CreateEventReadingEntity(ekgTestResult.QRSWidening, (int)ReadingLabels.QRSWidening, testReadingReadingPairs));

                if (ekgTestResult.LeftAxis != null)
                    customerEventReadingEntities.Add(CreateEventReadingEntity(ekgTestResult.LeftAxis, (int)ReadingLabels.LeftAxis, testReadingReadingPairs));

                if (ekgTestResult.RightAxis != null)
                    customerEventReadingEntities.Add(CreateEventReadingEntity(ekgTestResult.RightAxis, (int)ReadingLabels.RightAxis, testReadingReadingPairs));

                if (ekgTestResult.AbnormalAxis != null)
                    customerEventReadingEntities.Add(CreateEventReadingEntity(ekgTestResult.AbnormalAxis, (int)ReadingLabels.AbnormalAxis, testReadingReadingPairs));

                if (ekgTestResult.Left != null)
                    customerEventReadingEntities.Add(CreateEventReadingEntity(ekgTestResult.Left, (int)ReadingLabels.Left, testReadingReadingPairs));

                if (ekgTestResult.Right != null)
                    customerEventReadingEntities.Add(CreateEventReadingEntity(ekgTestResult.Right, (int)ReadingLabels.Right, testReadingReadingPairs));

                if (ekgTestResult.HeartBlock != null)
                    customerEventReadingEntities.Add(CreateEventReadingEntity(ekgTestResult.HeartBlock, (int)ReadingLabels.HeartBlock, testReadingReadingPairs));

                if (ekgTestResult.TypeI != null)
                    customerEventReadingEntities.Add(CreateEventReadingEntity(ekgTestResult.TypeI, (int)ReadingLabels.TypeI, testReadingReadingPairs));

                if (ekgTestResult.TypeII != null)
                    customerEventReadingEntities.Add(CreateEventReadingEntity(ekgTestResult.TypeII, (int)ReadingLabels.TypeII, testReadingReadingPairs));

                if (ekgTestResult.FirstDegreeBlock != null)
                    customerEventReadingEntities.Add(CreateEventReadingEntity(ekgTestResult.FirstDegreeBlock, (int)ReadingLabels.FirstDegreeBlock, testReadingReadingPairs));

                if (ekgTestResult.SecondDegreeBlock != null)
                    customerEventReadingEntities.Add(CreateEventReadingEntity(ekgTestResult.SecondDegreeBlock, (int)ReadingLabels.SecondDegreeBlock, testReadingReadingPairs));

                if (ekgTestResult.ThirdDegreeCompleteHeartBlock != null)
                    customerEventReadingEntities.Add(CreateEventReadingEntity(ekgTestResult.ThirdDegreeCompleteHeartBlock, (int)ReadingLabels.ThirdDegreeCompleteHeartBlock, testReadingReadingPairs));

                if (ekgTestResult.Artifact != null)
                    customerEventReadingEntities.Add(CreateEventReadingEntity(ekgTestResult.Artifact, (int)ReadingLabels.Artifact, testReadingReadingPairs));

                if (ekgTestResult.SupraventricularArrythmia != null)
                    customerEventReadingEntities.Add(CreateEventReadingEntity(ekgTestResult.SupraventricularArrythmia, (int)ReadingLabels.SupraventricularArrythmia, testReadingReadingPairs));

                if (ekgTestResult.PacerRythm != null)
                    customerEventReadingEntities.Add(CreateEventReadingEntity(ekgTestResult.PacerRythm, (int)ReadingLabels.PacerRythm, testReadingReadingPairs));

                if (ekgTestResult.BundleBranchBlock != null)
                    customerEventReadingEntities.Add(CreateEventReadingEntity(ekgTestResult.BundleBranchBlock, (int)ReadingLabels.BundleBranchBlock, testReadingReadingPairs));

                if (ekgTestResult.LeftAnteriorFasicularBlock != null)
                    customerEventReadingEntities.Add(CreateEventReadingEntity(ekgTestResult.LeftAnteriorFasicularBlock, (int)ReadingLabels.LeftAnteriorFasicularBlock, testReadingReadingPairs));

                if (ekgTestResult.VentricularHypertrophy != null)
                    customerEventReadingEntities.Add(CreateEventReadingEntity(ekgTestResult.VentricularHypertrophy, (int)ReadingLabels.VentricularHypertrophy, testReadingReadingPairs));

                if (ekgTestResult.LeftVentricularHypertrophy != null)
                    customerEventReadingEntities.Add(CreateEventReadingEntity(ekgTestResult.LeftVentricularHypertrophy, (int)ReadingLabels.LeftVHypertrophy, testReadingReadingPairs));

                if (ekgTestResult.RightVentricularHypertrophy != null)
                    customerEventReadingEntities.Add(CreateEventReadingEntity(ekgTestResult.RightVentricularHypertrophy, (int)ReadingLabels.RightVHypertrophy, testReadingReadingPairs));


                if (ekgTestResult.IschemicSTTChanges != null)
                    customerEventReadingEntities.Add(CreateEventReadingEntity(ekgTestResult.IschemicSTTChanges, (int)ReadingLabels.IschemicSTTChanges, testReadingReadingPairs));

                if (ekgTestResult.NonSpecificSTTChanges != null)
                    customerEventReadingEntities.Add(CreateEventReadingEntity(ekgTestResult.NonSpecificSTTChanges, (int)ReadingLabels.NonSpecificSTTChanges, testReadingReadingPairs));

                if (ekgTestResult.PoorRWaveProgression != null)
                    customerEventReadingEntities.Add(CreateEventReadingEntity(ekgTestResult.PoorRWaveProgression, (int)ReadingLabels.PoorRWaveProgression, testReadingReadingPairs));

                if (ekgTestResult.ProlongedQTInterval != null)
                    customerEventReadingEntities.Add(CreateEventReadingEntity(ekgTestResult.ProlongedQTInterval, (int)ReadingLabels.ProlongedQTInterval, testReadingReadingPairs));

                if (ekgTestResult.InfarctionPattern != null)
                    customerEventReadingEntities.Add(CreateEventReadingEntity(ekgTestResult.InfarctionPattern, (int)ReadingLabels.InfarctionPattern, testReadingReadingPairs));

                if (ekgTestResult.AtypicalQWaveLead != null)
                    customerEventReadingEntities.Add(CreateEventReadingEntity(ekgTestResult.AtypicalQWaveLead, (int)ReadingLabels.AtypicalQWaveLead, testReadingReadingPairs));

                if (ekgTestResult.AtrialEnlargement != null)
                    customerEventReadingEntities.Add(CreateEventReadingEntity(ekgTestResult.AtrialEnlargement, (int)ReadingLabels.AtrialEnlargement, testReadingReadingPairs));


                if (ekgTestResult.LeftAtrialEnlargement != null)
                    customerEventReadingEntities.Add(CreateEventReadingEntity(ekgTestResult.LeftAtrialEnlargement, (int)ReadingLabels.LeftAtrialEnlargment, testReadingReadingPairs));

                if (ekgTestResult.RightAtrialEnlargement != null)
                    customerEventReadingEntities.Add(CreateEventReadingEntity(ekgTestResult.RightAtrialEnlargement, (int)ReadingLabels.RightAtrialEnlargment, testReadingReadingPairs));

                if (ekgTestResult.RepolarizationVariant != null)
                    customerEventReadingEntities.Add(CreateEventReadingEntity(ekgTestResult.RepolarizationVariant, (int)ReadingLabels.RepolarizationVariant, testReadingReadingPairs));

                if (ekgTestResult.ReversedLeads != null)
                    customerEventReadingEntities.Add(CreateEventReadingEntity(ekgTestResult.ReversedLeads, (int)ReadingLabels.ReversedLeads, testReadingReadingPairs));

                if (ekgTestResult.RepeatStudy != null)
                    customerEventReadingEntities.Add(CreateEventReadingEntity(ekgTestResult.RepeatStudy, (int)ReadingLabels.RepeatStudy, testReadingReadingPairs));

                if (ekgTestResult.ComparetoEkg != null)
                    customerEventReadingEntities.Add(CreateEventReadingEntity(ekgTestResult.ComparetoEkg, (int)ReadingLabels.ComparetoEkg, testReadingReadingPairs));

                if (ekgTestResult.LowVoltage != null)
                    customerEventReadingEntities.Add(CreateEventReadingEntity(ekgTestResult.LowVoltage, (int)ReadingLabels.LowVoltage, testReadingReadingPairs));

                if (ekgTestResult.LimbLeads != null)
                    customerEventReadingEntities.Add(CreateEventReadingEntity(ekgTestResult.LimbLeads, (int)ReadingLabels.LimbLeads, testReadingReadingPairs));

                if (ekgTestResult.PrecordialLeads != null)
                    customerEventReadingEntities.Add(CreateEventReadingEntity(ekgTestResult.PrecordialLeads, (int)ReadingLabels.PrecordialLeads, testReadingReadingPairs));

            }

            customerEventScreeningTestEntity.CustomerEventReading.AddRange(customerEventReadingEntities);
            return customerEventScreeningTestEntity;
        }

    }
}
