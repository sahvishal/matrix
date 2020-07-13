using System;
using System.Collections.Generic;
using System.Linq;
using Falcon.App.Core;
using Falcon.App.Core.Application.Domain;
using Falcon.App.Core.Extensions;
using Falcon.App.Core.Medical.Domain;
using Falcon.App.Core.Medical.Enum;
using Falcon.App.Infrastructure.Service;
using Falcon.Data.EntityClasses;

namespace Falcon.App.Infrastructure.Factories.Screening
{
    public class LeadTestResultFactory : TestResultFactory
    {
        public override TestResult CreateActualTestResult(CustomerEventScreeningTestsEntity customerEventScreeningTestsEntity)
        {
            var customerEventReadingEntities = customerEventScreeningTestsEntity.CustomerEventReading.ToList();

            var testResult = new LeadTestResult(customerEventScreeningTestsEntity.CustomerEventScreeningTestId)
            {
                LeftResultReadings = new LeadTestReadings(),
                RightResultReadings = new LeadTestReadings()
            };

            var standardFindingEntities = customerEventScreeningTestsEntity.StandardFindingTestReadingCollectionViaCustomerEventTestStandardFinding.ToList();

            if (standardFindingEntities.Count > 0)
            {
                var customerEventStandardFindingEntities = customerEventScreeningTestsEntity.CustomerEventTestStandardFinding.ToList();

                var leftFindingEntity = standardFindingEntities.Find(entity => entity.ReadingId.Value == (int)ReadingLabels.Left);
                var rightFindingEntity = standardFindingEntities.Find(entity => entity.ReadingId.Value == (int)ReadingLabels.Right);
                var velocityFindingLeft = standardFindingEntities.Find(entity => entity.ReadingId == (int)ReadingLabels.LeftCFAPSV);
                var velocityFindingRight = standardFindingEntities.Find(entity => entity.ReadingId == (int)ReadingLabels.RightCFAPSV);

                if (leftFindingEntity != null)
                {
                    testResult.LeftResultReadings.Finding = new TestResultService().GetAllStandardFindings<decimal>((int)TestType.Lead, (int)ReadingLabels.Left).
                        FirstOrDefault(standardFinding => standardFinding.Id == leftFindingEntity.StandardFindingId);

                    if (testResult.LeftResultReadings.Finding != null)
                    {
                        testResult.LeftResultReadings.Finding.CustomerEventStandardFindingId = customerEventStandardFindingEntities.Find(standardFindingEntity =>
                            standardFindingEntity.StandardFindingTestReadingId == leftFindingEntity.StandardFindingTestReadingId).CustomerEventTestStandardFindingId;
                    }
                }

                if (rightFindingEntity != null)
                {
                    testResult.RightResultReadings.Finding = new TestResultService().GetAllStandardFindings<decimal>((int)TestType.Lead, (int)ReadingLabels.Right).
                        FirstOrDefault(standardFinding => standardFinding.Id == rightFindingEntity.StandardFindingId);

                    if (testResult.RightResultReadings.Finding != null)
                    {
                        testResult.RightResultReadings.Finding.CustomerEventStandardFindingId = customerEventStandardFindingEntities.Find(standardFindingEntity =>
                            standardFindingEntity.StandardFindingTestReadingId == rightFindingEntity.StandardFindingTestReadingId).CustomerEventTestStandardFindingId;
                    }
                }

                if (velocityFindingLeft != null)
                {
                    testResult.LowVelocityLeft = new TestResultService().GetAllStandardFindings<int>((int)TestType.Lead, (int)ReadingLabels.LeftCFAPSV).
                        Find(standardFinding => standardFinding.Id == velocityFindingLeft.StandardFindingId);

                    testResult.LowVelocityLeft.CustomerEventStandardFindingId = customerEventStandardFindingEntities.Find(standardFindingEntity =>
                        standardFindingEntity.StandardFindingTestReadingId == velocityFindingLeft.StandardFindingTestReadingId).CustomerEventTestStandardFindingId;
                }
                if (velocityFindingRight != null)
                {
                    testResult.LowVelocityRight = new TestResultService().GetAllStandardFindings<int>((int)TestType.Lead, (int)ReadingLabels.RightCFAPSV).
                        Find(standardFinding => standardFinding.Id == velocityFindingRight.StandardFindingId);

                    testResult.LowVelocityRight.CustomerEventStandardFindingId = customerEventStandardFindingEntities.Find(standardFindingEntity =>
                        standardFindingEntity.StandardFindingTestReadingId == velocityFindingRight.StandardFindingTestReadingId).CustomerEventTestStandardFindingId;
                }
            }

            testResult.LeftResultReadings.CFAPSV = CreateResultReadingforNullableDecimal((int)ReadingLabels.LeftCFAPSV, customerEventReadingEntities);
            testResult.LeftResultReadings.PSFAPSV = CreateResultReadingforNullableDecimal((int)ReadingLabels.LeftPSFAPSV, customerEventReadingEntities);

            testResult.LeftResultReadings.NoVisualPlaque = CreateResultReadingforNullableBool((int)ReadingLabels.LeftNoVisualPlaque, customerEventReadingEntities);
            testResult.LeftResultReadings.VisuallyDemonstratedPlaque = CreateResultReadingforNullableBool((int)ReadingLabels.LeftVisuallyDemonstratedPlaque, customerEventReadingEntities);
            testResult.LeftResultReadings.ModerateStenosis = CreateResultReadingforNullableBool((int)ReadingLabels.LeftModerateStenosis, customerEventReadingEntities);
            testResult.LeftResultReadings.PossibleOcclusion = CreateResultReadingforNullableBool((int)ReadingLabels.LeftPossibleOcclusion, customerEventReadingEntities);

            testResult.RightResultReadings.CFAPSV = CreateResultReadingforNullableDecimal((int)ReadingLabels.RightCFAPSV, customerEventReadingEntities);
            testResult.RightResultReadings.PSFAPSV = CreateResultReadingforNullableDecimal((int)ReadingLabels.RightPSFAPSV, customerEventReadingEntities);

            testResult.RightResultReadings.NoVisualPlaque = CreateResultReadingforNullableBool((int)ReadingLabels.RightNoVisualPlaque, customerEventReadingEntities);
            testResult.RightResultReadings.VisuallyDemonstratedPlaque = CreateResultReadingforNullableBool((int)ReadingLabels.RightVisuallyDemonstratedPlaque, customerEventReadingEntities);
            testResult.RightResultReadings.ModerateStenosis = CreateResultReadingforNullableBool((int)ReadingLabels.RightModerateStenosis, customerEventReadingEntities);
            testResult.RightResultReadings.PossibleOcclusion = CreateResultReadingforNullableBool((int)ReadingLabels.RightPossibleOcclusion, customerEventReadingEntities);

            testResult.TechnicallyLimitedbutReadable = CreateResultReading((int)ReadingLabels.TechnicallyLimitedbutReadable, customerEventReadingEntities);
            testResult.RepeatStudy = CreateResultReading((int)ReadingLabels.RepeatStudy, customerEventReadingEntities);

            testResult.DiagnosisCode = CreateResultReadingforInputValues((int)ReadingLabels.DiagnosisCode, customerEventReadingEntities);

            var testImages = customerEventScreeningTestsEntity.TestMedia.ToList();
            var fileEntityCollection = customerEventScreeningTestsEntity.FileCollectionViaTestMedia.ToList();

            if (testImages.Count > 0)
            {
                var resultImages = new List<ResultMedia>();
                testImages.ForEach(testMedia => resultImages.Add(new ResultMedia(testMedia.MediaId)
                {
                    File = GetFileObjectfromEntity(testMedia.FileId, fileEntityCollection),
                    Thumbnail = testMedia.ThumbnailFileId != null ? new File(testMedia.ThumbnailFileId.Value) : null,
                    ReadingSource = testMedia.IsManual ? ReadingSource.Manual : ReadingSource.Automatic
                }));

                testResult.ResultImages = resultImages;
            }
            return testResult;
        }

        public override CustomerEventScreeningTestsEntity CreateActualTestResultEntity(TestResult testResult, List<OrderedPair<int, int>> testReadingReadingPairs)
        {
            var leadTestResult = testResult as LeadTestResult;
            var customerEventScreeningTestsEntity = new CustomerEventScreeningTestsEntity(testResult.Id) { TestId = (int)TestType.Lead };
            var customerEventReadingEntities = new List<CustomerEventReadingEntity>();

            var resultInterpretations = new List<long>();
            var pathwayRecommendations = new List<long>();

            if (leadTestResult.LeftResultReadings != null)
            {
                var customerEventReading = CreateEventReadingEntity(leadTestResult.LeftResultReadings.CFAPSV, (int)ReadingLabels.LeftCFAPSV, testReadingReadingPairs);
                if (customerEventReading != null) customerEventReadingEntities.Add(customerEventReading);

                customerEventReading = CreateEventReadingEntity(leadTestResult.LeftResultReadings.PSFAPSV, (int)ReadingLabels.LeftPSFAPSV, testReadingReadingPairs);
                if (customerEventReading != null) customerEventReadingEntities.Add(customerEventReading);

                customerEventReading = CreateEventReadingEntity(leadTestResult.LeftResultReadings.NoVisualPlaque, (int)ReadingLabels.LeftNoVisualPlaque, testReadingReadingPairs);
                if (customerEventReading != null) customerEventReadingEntities.Add(customerEventReading);

                customerEventReading = CreateEventReadingEntity(leadTestResult.LeftResultReadings.VisuallyDemonstratedPlaque, (int)ReadingLabels.LeftVisuallyDemonstratedPlaque, testReadingReadingPairs);
                if (customerEventReading != null) customerEventReadingEntities.Add(customerEventReading);

                customerEventReading = CreateEventReadingEntity(leadTestResult.LeftResultReadings.ModerateStenosis, (int)ReadingLabels.LeftModerateStenosis, testReadingReadingPairs);
                if (customerEventReading != null) customerEventReadingEntities.Add(customerEventReading);

                customerEventReading = CreateEventReadingEntity(leadTestResult.LeftResultReadings.PossibleOcclusion, (int)ReadingLabels.LeftPossibleOcclusion, testReadingReadingPairs);
                if (customerEventReading != null) customerEventReadingEntities.Add(customerEventReading);

                

                if (leadTestResult.LeftResultReadings.Finding != null)
                {
                    //TODO: Service methods being caled from the factory. need to Refactor and Revise it.
                    var customerEventTestStandardFindingEntity = new CustomerEventTestStandardFindingEntity
                    {
                        StandardFindingTestReadingId =
                            (int?)new TestResultService().GetStandardFindingTestReadingIdForStandardFinding((int)TestType.Lead, (int)ReadingLabels.Left, Convert.ToInt64(leadTestResult.LeftResultReadings.Finding.Id)),
                        CustomerEventTestStandardFindingId = leadTestResult.LeftResultReadings.Finding.CustomerEventStandardFindingId,
                        CustomerEventScreeningTestId = testResult.Id
                    };

                    var finding = GetSelectedStandardFinding((int)TestType.Lead, (int)ReadingLabels.Left, leadTestResult.LeftResultReadings.Finding.Id);

                    if (finding.ResultInterpretation != null) resultInterpretations.Add(finding.ResultInterpretation.Value);
                    if (finding.PathwayRecommendation != null) pathwayRecommendations.Add(finding.PathwayRecommendation.Value);

                    customerEventScreeningTestsEntity.CustomerEventTestStandardFinding.Add(customerEventTestStandardFindingEntity);
                }
            }

            if (leadTestResult.RightResultReadings != null)
            {
                var customerEventReading = CreateEventReadingEntity(leadTestResult.RightResultReadings.CFAPSV, (int)ReadingLabels.RightCFAPSV, testReadingReadingPairs);
                if (customerEventReading != null) customerEventReadingEntities.Add(customerEventReading);

                customerEventReading = CreateEventReadingEntity(leadTestResult.RightResultReadings.PSFAPSV, (int)ReadingLabels.RightPSFAPSV, testReadingReadingPairs);
                if (customerEventReading != null) customerEventReadingEntities.Add(customerEventReading);

                customerEventReading = CreateEventReadingEntity(leadTestResult.RightResultReadings.NoVisualPlaque, (int)ReadingLabels.RightNoVisualPlaque, testReadingReadingPairs);
                if (customerEventReading != null) customerEventReadingEntities.Add(customerEventReading);

                customerEventReading = CreateEventReadingEntity(leadTestResult.RightResultReadings.VisuallyDemonstratedPlaque, (int)ReadingLabels.RightVisuallyDemonstratedPlaque, testReadingReadingPairs);
                if (customerEventReading != null) customerEventReadingEntities.Add(customerEventReading);

                customerEventReading = CreateEventReadingEntity(leadTestResult.RightResultReadings.ModerateStenosis, (int)ReadingLabels.RightModerateStenosis, testReadingReadingPairs);
                if (customerEventReading != null) customerEventReadingEntities.Add(customerEventReading);

                customerEventReading = CreateEventReadingEntity(leadTestResult.RightResultReadings.PossibleOcclusion, (int)ReadingLabels.RightPossibleOcclusion, testReadingReadingPairs);
                if (customerEventReading != null) customerEventReadingEntities.Add(customerEventReading);

                if (leadTestResult.RightResultReadings.Finding != null)
                {
                    //TODO: Service methods being caled from the factory. need to Refactor and Revise it.
                    var customerEventTestStandardFindingEntity = new CustomerEventTestStandardFindingEntity()
                    {
                        StandardFindingTestReadingId =
                            (int?)new TestResultService().GetStandardFindingTestReadingIdForStandardFinding
                                ((int)TestType.Lead, (int)ReadingLabels.Right, Convert.ToInt64(leadTestResult.RightResultReadings.Finding.Id)),
                        CustomerEventTestStandardFindingId = leadTestResult.RightResultReadings.Finding.CustomerEventStandardFindingId,
                        CustomerEventScreeningTestId = testResult.Id
                    };

                    var finding = GetSelectedStandardFinding((int)TestType.Lead, (int)ReadingLabels.Right, leadTestResult.RightResultReadings.Finding.Id);

                    if (finding.ResultInterpretation != null) resultInterpretations.Add(finding.ResultInterpretation.Value);
                    if (finding.PathwayRecommendation != null) pathwayRecommendations.Add(finding.PathwayRecommendation.Value);

                    customerEventScreeningTestsEntity.CustomerEventTestStandardFinding.Add(customerEventTestStandardFindingEntity);
                }
            }


            if (leadTestResult.LowVelocityLeft != null)
            {
                //TODO: Service methods being caled from the factory. need to Refactor and Revise it.
                var customerEventTestStandardFindingEntity = new CustomerEventTestStandardFindingEntity()
                {
                    StandardFindingTestReadingId =
                        (int?)new TestResultService().GetStandardFindingTestReadingIdForStandardFinding
                            ((int)TestType.Lead, (int)ReadingLabels.LeftCFAPSV, Convert.ToInt64(leadTestResult.LowVelocityLeft.Id)),
                    CustomerEventTestStandardFindingId = leadTestResult.LowVelocityLeft.CustomerEventStandardFindingId,
                    CustomerEventScreeningTestId = testResult.Id
                };

                customerEventScreeningTestsEntity.CustomerEventTestStandardFinding.Add(customerEventTestStandardFindingEntity);
            }

            if (leadTestResult.LowVelocityRight != null)
            {
                //TODO: Service methods being caled from the factory. need to Refactor and Revise it.
                var customerEventTestStandardFindingEntity = new CustomerEventTestStandardFindingEntity()
                {
                    StandardFindingTestReadingId =
                        (int?)new TestResultService().GetStandardFindingTestReadingIdForStandardFinding
                            ((int)TestType.Lead, (int)ReadingLabels.RightCFAPSV, Convert.ToInt64(leadTestResult.LowVelocityRight.Id)),
                    CustomerEventTestStandardFindingId = leadTestResult.LowVelocityRight.CustomerEventStandardFindingId,
                    CustomerEventScreeningTestId = testResult.Id
                };

                customerEventScreeningTestsEntity.CustomerEventTestStandardFinding.Add(customerEventTestStandardFindingEntity);
            }

            if (leadTestResult.TechnicallyLimitedbutReadable != null)
            {
                var customerEventReadingEntity = CreateEventReadingEntity(leadTestResult.TechnicallyLimitedbutReadable, (int)ReadingLabels.TechnicallyLimitedbutReadable, testReadingReadingPairs);
                if (customerEventReadingEntity != null) customerEventReadingEntities.Add(customerEventReadingEntity);
            }

            if (leadTestResult.RepeatStudy != null)
            {
                var customerEventReadingEntity = CreateEventReadingEntity(leadTestResult.RepeatStudy, (int)ReadingLabels.RepeatStudy, testReadingReadingPairs);
                if (customerEventReadingEntity != null) customerEventReadingEntities.Add(customerEventReadingEntity);
            }

            if (leadTestResult.DiagnosisCode != null)
            {
                var customerEventReadingEntity = CreateEventReadingEntity(leadTestResult.DiagnosisCode, (int)ReadingLabels.DiagnosisCode, testReadingReadingPairs);
                if (customerEventReadingEntity != null) customerEventReadingEntities.Add(customerEventReadingEntity);
            }

            if (testResult.ResultStatus.StateNumber == (int)TestResultStateNumber.Evaluated || testResult.ResultStatus.StateNumber == (int)NewTestResultStateNumber.Evaluated)
            {
                testResult.ResultInterpretation = null;
                testResult.PathwayRecommendation = null;

                if (resultInterpretations.Count > 0)
                    testResult.ResultInterpretation = ResultInterpretation.Normal.GetMax(resultInterpretations);

                if (pathwayRecommendations.Count > 0)
                    testResult.PathwayRecommendation = PathwayRecommendation.None.GetMax(pathwayRecommendations);
            }

            if (customerEventReadingEntities.Count > 0)
                customerEventScreeningTestsEntity.CustomerEventReading.AddRange(customerEventReadingEntities);

            return customerEventScreeningTestsEntity;
        }
    }
}
