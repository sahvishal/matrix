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
    public class HcpCarotidTestResultFactory : TestResultFactory
    {
        public override TestResult CreateActualTestResult(CustomerEventScreeningTestsEntity customerEventScreeningTestsEntity)
        {
            var customerEventReadingEntities = customerEventScreeningTestsEntity.CustomerEventReading.ToList();

            var testResult = new HcpCarotidTestResult(customerEventScreeningTestsEntity.CustomerEventScreeningTestId)
            {
                LeftResultReadings = new HcpCarotidTestReadings(),
                RightResultReadings = new HcpCarotidTestReadings()
            };

            var standardFindingEntities = customerEventScreeningTestsEntity.StandardFindingTestReadingCollectionViaCustomerEventTestStandardFinding.ToList();

            if (standardFindingEntities.Count > 0)
            {
                var customerEventStandardFindingEntities = customerEventScreeningTestsEntity.CustomerEventTestStandardFinding.ToList();

                var leftFindingEntity = standardFindingEntities.Find(entity => entity.ReadingId.Value == (int)ReadingLabels.Left);
                var rightFindingEntity = standardFindingEntities.Find(entity => entity.ReadingId.Value == (int)ReadingLabels.Right);
                var velocityFindingLica = standardFindingEntities.Find(entity => entity.ReadingId == (int)ReadingLabels.LICAPSV);
                var velocityFindingRica = standardFindingEntities.Find(entity => entity.ReadingId == (int)ReadingLabels.RICAPSV);

                if (leftFindingEntity != null)
                {
                    testResult.LeftResultReadings.Finding = new TestResultService().GetAllStandardFindings<decimal>((int)TestType.HCPCarotid, (int)ReadingLabels.Left).
                        FirstOrDefault(standardFinding => standardFinding.Id == leftFindingEntity.StandardFindingId);

                    if (testResult.LeftResultReadings.Finding != null)
                    {
                        testResult.LeftResultReadings.Finding.CustomerEventStandardFindingId = customerEventStandardFindingEntities.Find(standardFindingEntity =>
                            standardFindingEntity.StandardFindingTestReadingId == leftFindingEntity.StandardFindingTestReadingId).CustomerEventTestStandardFindingId;
                    }
                }

                if (rightFindingEntity != null)
                {
                    testResult.RightResultReadings.Finding = new TestResultService().GetAllStandardFindings<decimal>((int)TestType.HCPCarotid, (int)ReadingLabels.Right).
                        FirstOrDefault(standardFinding => standardFinding.Id == rightFindingEntity.StandardFindingId);

                    if (testResult.RightResultReadings.Finding != null)
                    {
                        testResult.RightResultReadings.Finding.CustomerEventStandardFindingId = customerEventStandardFindingEntities.Find(standardFindingEntity =>
                            standardFindingEntity.StandardFindingTestReadingId == rightFindingEntity.StandardFindingTestReadingId).CustomerEventTestStandardFindingId;
                    }
                }

                if (velocityFindingLica != null)
                {
                    testResult.LowVelocityLica = new TestResultService().GetAllStandardFindings<int>((int)TestType.HCPCarotid, (int)ReadingLabels.LICAPSV).
                        Find(standardFinding => standardFinding.Id == velocityFindingLica.StandardFindingId);

                    testResult.LowVelocityLica.CustomerEventStandardFindingId = customerEventStandardFindingEntities.Find(standardFindingEntity =>
                        standardFindingEntity.StandardFindingTestReadingId == velocityFindingLica.StandardFindingTestReadingId).CustomerEventTestStandardFindingId;
                }
                if (velocityFindingRica != null)
                {
                    testResult.LowVelocityRica = new TestResultService().GetAllStandardFindings<int>((int)TestType.HCPCarotid, (int)ReadingLabels.RICAPSV).
                        Find(standardFinding => standardFinding.Id == velocityFindingRica.StandardFindingId);

                    testResult.LowVelocityRica.CustomerEventStandardFindingId = customerEventStandardFindingEntities.Find(standardFindingEntity =>
                        standardFindingEntity.StandardFindingTestReadingId == velocityFindingRica.StandardFindingTestReadingId).CustomerEventTestStandardFindingId;
                }
            }

            testResult.LeftResultReadings.ICAPSV = CreateResultReadingforNullableDecimal((int)ReadingLabels.LICAPSV, customerEventReadingEntities);
            testResult.LeftResultReadings.ICAEDV = CreateResultReadingforNullableDecimal((int)ReadingLabels.LICAEDV, customerEventReadingEntities);
            testResult.LeftResultReadings.CCAPSV = CreateResultReadingforNullableDecimal((int)ReadingLabels.LCCAPSV, customerEventReadingEntities);

            testResult.RightResultReadings.ICAPSV = CreateResultReadingforNullableDecimal((int)ReadingLabels.RICAPSV, customerEventReadingEntities);
            testResult.RightResultReadings.ICAEDV = CreateResultReadingforNullableDecimal((int)ReadingLabels.RICAEDV, customerEventReadingEntities);
            testResult.RightResultReadings.CCAPSV = CreateResultReadingforNullableDecimal((int)ReadingLabels.RCCAPSV, customerEventReadingEntities);

            testResult.VelocityElevatedOnRight = CreateResultReading((int)ReadingLabels.VelocityElevatedOnRight, customerEventReadingEntities);
            testResult.VelocityElevatedOnLeft = CreateResultReading((int)ReadingLabels.VelocityElevatedOnLeft, customerEventReadingEntities);

            testResult.TechnicallyLimitedbutReadable = CreateResultReading((int)ReadingLabels.TechnicallyLimitedbutReadable, customerEventReadingEntities);
            testResult.RepeatStudy = CreateResultReading((int)ReadingLabels.RepeatStudy, customerEventReadingEntities);

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
            var hcpCarotidTestResult = testResult as HcpCarotidTestResult;
            var customerEventScreeningTestsEntity = new CustomerEventScreeningTestsEntity(testResult.Id) { TestId = (int)TestType.HCPCarotid };
            var customerEventReadingEntities = new List<CustomerEventReadingEntity>();

            var resultInterpretations = new List<long>();
            var pathwayRecommendations = new List<long>();

            if (hcpCarotidTestResult.LeftResultReadings != null)
            {
                var customerEventReading = CreateEventReadingEntity(hcpCarotidTestResult.LeftResultReadings.ICAPSV, (int)ReadingLabels.LICAPSV, testReadingReadingPairs);
                if (customerEventReading != null) customerEventReadingEntities.Add(customerEventReading);

                customerEventReading = CreateEventReadingEntity(hcpCarotidTestResult.LeftResultReadings.ICAEDV, (int)ReadingLabels.LICAEDV, testReadingReadingPairs);
                if (customerEventReading != null) customerEventReadingEntities.Add(customerEventReading);

                customerEventReading = CreateEventReadingEntity(hcpCarotidTestResult.LeftResultReadings.CCAPSV, (int)ReadingLabels.LCCAPSV, testReadingReadingPairs);
                if (customerEventReading != null) customerEventReadingEntities.Add(customerEventReading);

                if (hcpCarotidTestResult.LeftResultReadings.Finding != null)
                {
                    //TODO: Service methods being caled from the factory. need to Refactor and Revise it.
                    var customerEventTestStandardFindingEntity = new CustomerEventTestStandardFindingEntity
                    {
                        StandardFindingTestReadingId =
                            (int?)new TestResultService().GetStandardFindingTestReadingIdForStandardFinding((int)TestType.HCPCarotid, (int)ReadingLabels.Left, Convert.ToInt64(hcpCarotidTestResult.LeftResultReadings.Finding.Id)),
                        CustomerEventTestStandardFindingId = hcpCarotidTestResult.LeftResultReadings.Finding.CustomerEventStandardFindingId,
                        CustomerEventScreeningTestId = testResult.Id
                    };

                    var finding = GetSelectedStandardFinding((int)TestType.HCPCarotid, (int)ReadingLabels.Left, hcpCarotidTestResult.LeftResultReadings.Finding.Id);

                    if (finding.ResultInterpretation != null) resultInterpretations.Add(finding.ResultInterpretation.Value);
                    if (finding.PathwayRecommendation != null) pathwayRecommendations.Add(finding.PathwayRecommendation.Value);

                    customerEventScreeningTestsEntity.CustomerEventTestStandardFinding.Add(customerEventTestStandardFindingEntity);
                }
            }

            var reading = CreateEventReadingEntity(hcpCarotidTestResult.VelocityElevatedOnLeft, (int)ReadingLabels.VelocityElevatedOnLeft, testReadingReadingPairs);
            if (reading != null) customerEventReadingEntities.Add(reading);

            reading = CreateEventReadingEntity(hcpCarotidTestResult.VelocityElevatedOnRight, (int)ReadingLabels.VelocityElevatedOnRight, testReadingReadingPairs);
            if (reading != null) customerEventReadingEntities.Add(reading);

            if (hcpCarotidTestResult.RightResultReadings != null)
            {
                var customerEventReading = CreateEventReadingEntity(hcpCarotidTestResult.RightResultReadings.ICAPSV, (int)ReadingLabels.RICAPSV, testReadingReadingPairs);
                if (customerEventReading != null) customerEventReadingEntities.Add(customerEventReading);

                customerEventReading = CreateEventReadingEntity(hcpCarotidTestResult.RightResultReadings.ICAEDV, (int)ReadingLabels.RICAEDV, testReadingReadingPairs);
                if (customerEventReading != null) customerEventReadingEntities.Add(customerEventReading);

                customerEventReading = CreateEventReadingEntity(hcpCarotidTestResult.RightResultReadings.CCAPSV, (int)ReadingLabels.RCCAPSV, testReadingReadingPairs);
                if (customerEventReading != null) customerEventReadingEntities.Add(customerEventReading);

                if (hcpCarotidTestResult.RightResultReadings.Finding != null)
                {
                    //TODO: Service methods being caled from the factory. need to Refactor and Revise it.
                    var customerEventTestStandardFindingEntity = new CustomerEventTestStandardFindingEntity()
                    {
                        StandardFindingTestReadingId =
                            (int?)new TestResultService().GetStandardFindingTestReadingIdForStandardFinding
                                ((int)TestType.HCPCarotid, (int)ReadingLabels.Right, Convert.ToInt64(hcpCarotidTestResult.RightResultReadings.Finding.Id)),
                        CustomerEventTestStandardFindingId = hcpCarotidTestResult.RightResultReadings.Finding.CustomerEventStandardFindingId,
                        CustomerEventScreeningTestId = testResult.Id
                    };

                    var finding = GetSelectedStandardFinding((int)TestType.HCPCarotid, (int)ReadingLabels.Right, hcpCarotidTestResult.RightResultReadings.Finding.Id);

                    if (finding.ResultInterpretation != null) resultInterpretations.Add(finding.ResultInterpretation.Value);
                    if (finding.PathwayRecommendation != null) pathwayRecommendations.Add(finding.PathwayRecommendation.Value);

                    customerEventScreeningTestsEntity.CustomerEventTestStandardFinding.Add(customerEventTestStandardFindingEntity);
                }
            }


            if (hcpCarotidTestResult.LowVelocityLica != null)
            {
                //TODO: Service methods being caled from the factory. need to Refactor and Revise it.
                var customerEventTestStandardFindingEntity = new CustomerEventTestStandardFindingEntity()
                {
                    StandardFindingTestReadingId =
                        (int?)new TestResultService().GetStandardFindingTestReadingIdForStandardFinding
                            ((int)TestType.HCPCarotid, (int)ReadingLabels.LICAPSV, Convert.ToInt64(hcpCarotidTestResult.LowVelocityLica.Id)),
                    CustomerEventTestStandardFindingId = hcpCarotidTestResult.LowVelocityLica.CustomerEventStandardFindingId,
                    CustomerEventScreeningTestId = testResult.Id
                };

                customerEventScreeningTestsEntity.CustomerEventTestStandardFinding.Add(customerEventTestStandardFindingEntity);
            }

            if (hcpCarotidTestResult.LowVelocityRica != null)
            {
                //TODO: Service methods being caled from the factory. need to Refactor and Revise it.
                var customerEventTestStandardFindingEntity = new CustomerEventTestStandardFindingEntity()
                {
                    StandardFindingTestReadingId =
                        (int?)new TestResultService().GetStandardFindingTestReadingIdForStandardFinding
                            ((int)TestType.HCPCarotid, (int)ReadingLabels.RICAPSV, Convert.ToInt64(hcpCarotidTestResult.LowVelocityRica.Id)),
                    CustomerEventTestStandardFindingId = hcpCarotidTestResult.LowVelocityRica.CustomerEventStandardFindingId,
                    CustomerEventScreeningTestId = testResult.Id
                };

                customerEventScreeningTestsEntity.CustomerEventTestStandardFinding.Add(customerEventTestStandardFindingEntity);
            }

            if (hcpCarotidTestResult.TechnicallyLimitedbutReadable != null)
            {
                var customerEventReadingEntity = CreateEventReadingEntity(hcpCarotidTestResult.TechnicallyLimitedbutReadable, (int)ReadingLabels.TechnicallyLimitedbutReadable, testReadingReadingPairs);
                if (customerEventReadingEntity != null) customerEventReadingEntities.Add(customerEventReadingEntity);
            }

            if (hcpCarotidTestResult.RepeatStudy != null)
            {
                var customerEventReadingEntity = CreateEventReadingEntity(hcpCarotidTestResult.RepeatStudy, (int)ReadingLabels.RepeatStudy, testReadingReadingPairs);
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