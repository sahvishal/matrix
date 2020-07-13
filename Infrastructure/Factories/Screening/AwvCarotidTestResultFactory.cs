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
    public class AwvCarotidTestResultFactory : TestResultFactory
    {
        public override TestResult CreateActualTestResult(CustomerEventScreeningTestsEntity customerEventScreeningTestsEntity)
        {
            var customerEventReadingEntities = customerEventScreeningTestsEntity.CustomerEventReading.ToList();

            var testResult = new AwvCarotidTestResult(customerEventScreeningTestsEntity.CustomerEventScreeningTestId)
            {
                LeftResultReadings = new AwvCarotidTestReadings(),
                RightResultReadings = new AwvCarotidTestReadings()
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
                    testResult.LeftResultReadings.Finding = new TestResultService().GetAllStandardFindings<decimal>((int)TestType.AwvCarotid, (int)ReadingLabels.Left).
                        FirstOrDefault(standardFinding => standardFinding.Id == leftFindingEntity.StandardFindingId);

                    if (testResult.LeftResultReadings.Finding != null)
                    {
                        testResult.LeftResultReadings.Finding.CustomerEventStandardFindingId = customerEventStandardFindingEntities.Find(standardFindingEntity =>
                            standardFindingEntity.StandardFindingTestReadingId == leftFindingEntity.StandardFindingTestReadingId).CustomerEventTestStandardFindingId;
                    }
                }

                if (rightFindingEntity != null)
                {
                    testResult.RightResultReadings.Finding = new TestResultService().GetAllStandardFindings<decimal>((int)TestType.AwvCarotid, (int)ReadingLabels.Right).
                        FirstOrDefault(standardFinding => standardFinding.Id == rightFindingEntity.StandardFindingId);

                    if (testResult.RightResultReadings.Finding != null)
                    {
                        testResult.RightResultReadings.Finding.CustomerEventStandardFindingId = customerEventStandardFindingEntities.Find(standardFindingEntity =>
                            standardFindingEntity.StandardFindingTestReadingId == rightFindingEntity.StandardFindingTestReadingId).CustomerEventTestStandardFindingId;
                    }
                }

                if (velocityFindingLica != null)
                {
                    testResult.LowVelocityLica = new TestResultService().GetAllStandardFindings<int>((int)TestType.AwvCarotid, (int)ReadingLabels.LICAPSV).
                        Find(standardFinding => standardFinding.Id == velocityFindingLica.StandardFindingId);

                    testResult.LowVelocityLica.CustomerEventStandardFindingId = customerEventStandardFindingEntities.Find(standardFindingEntity =>
                        standardFindingEntity.StandardFindingTestReadingId == velocityFindingLica.StandardFindingTestReadingId).CustomerEventTestStandardFindingId;
                }
                if (velocityFindingRica != null)
                {
                    testResult.LowVelocityRica = new TestResultService().GetAllStandardFindings<int>((int)TestType.AwvCarotid, (int)ReadingLabels.RICAPSV).
                        Find(standardFinding => standardFinding.Id == velocityFindingRica.StandardFindingId);

                    testResult.LowVelocityRica.CustomerEventStandardFindingId = customerEventStandardFindingEntities.Find(standardFindingEntity =>
                        standardFindingEntity.StandardFindingTestReadingId == velocityFindingRica.StandardFindingTestReadingId).CustomerEventTestStandardFindingId;
                }
            }

            testResult.LeftResultReadings.CCAProximalPSV = CreateResultReadingforNullableDecimal((int)ReadingLabels.LCCAProximalPSV, customerEventReadingEntities);
            testResult.LeftResultReadings.CCAProximalEDV = CreateResultReadingforNullableDecimal((int)ReadingLabels.LCCAProximalEDV, customerEventReadingEntities);
            testResult.LeftResultReadings.CCADistalPSV = CreateResultReadingforNullableDecimal((int)ReadingLabels.LCCADistalPSV, customerEventReadingEntities);
            testResult.LeftResultReadings.CCADistalEDV = CreateResultReadingforNullableDecimal((int)ReadingLabels.LCCADistalEDV, customerEventReadingEntities);
            testResult.LeftResultReadings.BulbPSV = CreateResultReadingforNullableDecimal((int)ReadingLabels.LBulbPSV, customerEventReadingEntities);
            testResult.LeftResultReadings.BulbEDV = CreateResultReadingforNullableDecimal((int)ReadingLabels.LBulbEDV, customerEventReadingEntities);
            testResult.LeftResultReadings.ExtCarotidArtPSV = CreateResultReadingforNullableDecimal((int)ReadingLabels.LExtCarotidArtPSV, customerEventReadingEntities);
            testResult.LeftResultReadings.ICAProximalPSV = CreateResultReadingforNullableDecimal((int)ReadingLabels.LICAPSV, customerEventReadingEntities);
            testResult.LeftResultReadings.ICAProximalEDV = CreateResultReadingforNullableDecimal((int)ReadingLabels.LICAEDV, customerEventReadingEntities);
            testResult.LeftResultReadings.ICADistalPSV = CreateResultReadingforNullableDecimal((int)ReadingLabels.LICADistalPSV, customerEventReadingEntities);
            testResult.LeftResultReadings.ICADistalEDV = CreateResultReadingforNullableDecimal((int)ReadingLabels.LICADistalEDV, customerEventReadingEntities);
            testResult.LeftResultReadings.VertebralArtPSV = CreateResultReadingforNullableDecimal((int)ReadingLabels.LVertebralArtPSV, customerEventReadingEntities);
            testResult.LeftResultReadings.VertebralArtEDV = CreateResultReadingforNullableDecimal((int)ReadingLabels.LVertebralArtEDV, customerEventReadingEntities);


            testResult.RightResultReadings.CCAProximalPSV = CreateResultReadingforNullableDecimal((int)ReadingLabels.RCCAProximalPSV, customerEventReadingEntities);
            testResult.RightResultReadings.CCAProximalEDV = CreateResultReadingforNullableDecimal((int)ReadingLabels.RCCAProximalEDV, customerEventReadingEntities);
            testResult.RightResultReadings.CCADistalPSV = CreateResultReadingforNullableDecimal((int)ReadingLabels.RCCADistalPSV, customerEventReadingEntities);
            testResult.RightResultReadings.CCADistalEDV = CreateResultReadingforNullableDecimal((int)ReadingLabels.RCCADistalEDV, customerEventReadingEntities);
            testResult.RightResultReadings.BulbPSV = CreateResultReadingforNullableDecimal((int)ReadingLabels.RBulbPSV, customerEventReadingEntities);
            testResult.RightResultReadings.BulbEDV = CreateResultReadingforNullableDecimal((int)ReadingLabels.RBulbEDV, customerEventReadingEntities);
            testResult.RightResultReadings.ExtCarotidArtPSV = CreateResultReadingforNullableDecimal((int)ReadingLabels.RExtCarotidArtPSV, customerEventReadingEntities);
            testResult.RightResultReadings.ICAProximalPSV = CreateResultReadingforNullableDecimal((int)ReadingLabels.RICAPSV, customerEventReadingEntities);
            testResult.RightResultReadings.ICAProximalEDV = CreateResultReadingforNullableDecimal((int)ReadingLabels.RICAEDV, customerEventReadingEntities);
            testResult.RightResultReadings.ICADistalPSV = CreateResultReadingforNullableDecimal((int)ReadingLabels.RICADistalPSV, customerEventReadingEntities);
            testResult.RightResultReadings.ICADistalEDV = CreateResultReadingforNullableDecimal((int)ReadingLabels.RICADistalEDV, customerEventReadingEntities);
            testResult.RightResultReadings.VertebralArtPSV = CreateResultReadingforNullableDecimal((int)ReadingLabels.RVertebralArtPSV, customerEventReadingEntities);
            testResult.RightResultReadings.VertebralArtEDV = CreateResultReadingforNullableDecimal((int)ReadingLabels.RVertebralArtEDV, customerEventReadingEntities);

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
            var awvCarotidTestResult = testResult as AwvCarotidTestResult;
            var customerEventScreeningTestsEntity = new CustomerEventScreeningTestsEntity(testResult.Id) { TestId = (int)TestType.AwvCarotid };
            var customerEventReadingEntities = new List<CustomerEventReadingEntity>();

            var resultInterpretations = new List<long>();
            var pathwayRecommendations = new List<long>();

            if (awvCarotidTestResult.LeftResultReadings != null)
            {
                var customerEventReading = CreateEventReadingEntity(awvCarotidTestResult.LeftResultReadings.CCAProximalPSV, (int)ReadingLabels.LCCAProximalPSV, testReadingReadingPairs);
                if (customerEventReading != null) customerEventReadingEntities.Add(customerEventReading);
                customerEventReading = CreateEventReadingEntity(awvCarotidTestResult.LeftResultReadings.CCAProximalEDV, (int)ReadingLabels.LCCAProximalEDV, testReadingReadingPairs);
                if (customerEventReading != null) customerEventReadingEntities.Add(customerEventReading);

                customerEventReading = CreateEventReadingEntity(awvCarotidTestResult.LeftResultReadings.CCADistalPSV, (int)ReadingLabels.LCCADistalPSV, testReadingReadingPairs);
                if (customerEventReading != null) customerEventReadingEntities.Add(customerEventReading);
                customerEventReading = CreateEventReadingEntity(awvCarotidTestResult.LeftResultReadings.CCADistalEDV, (int)ReadingLabels.LCCADistalEDV, testReadingReadingPairs);
                if (customerEventReading != null) customerEventReadingEntities.Add(customerEventReading);

                customerEventReading = CreateEventReadingEntity(awvCarotidTestResult.LeftResultReadings.BulbPSV, (int)ReadingLabels.LBulbPSV, testReadingReadingPairs);
                if (customerEventReading != null) customerEventReadingEntities.Add(customerEventReading);
                customerEventReading = CreateEventReadingEntity(awvCarotidTestResult.LeftResultReadings.BulbEDV, (int)ReadingLabels.LBulbEDV, testReadingReadingPairs);
                if (customerEventReading != null) customerEventReadingEntities.Add(customerEventReading);

                customerEventReading = CreateEventReadingEntity(awvCarotidTestResult.LeftResultReadings.ExtCarotidArtPSV, (int)ReadingLabels.LExtCarotidArtPSV, testReadingReadingPairs);
                if (customerEventReading != null) customerEventReadingEntities.Add(customerEventReading);

                customerEventReading = CreateEventReadingEntity(awvCarotidTestResult.LeftResultReadings.ICAProximalPSV, (int)ReadingLabels.LICAPSV, testReadingReadingPairs);
                if (customerEventReading != null) customerEventReadingEntities.Add(customerEventReading);
                customerEventReading = CreateEventReadingEntity(awvCarotidTestResult.LeftResultReadings.ICAProximalEDV, (int)ReadingLabels.LICAEDV, testReadingReadingPairs);
                if (customerEventReading != null) customerEventReadingEntities.Add(customerEventReading);

                customerEventReading = CreateEventReadingEntity(awvCarotidTestResult.LeftResultReadings.ICADistalPSV, (int)ReadingLabels.LICADistalPSV, testReadingReadingPairs);
                if (customerEventReading != null) customerEventReadingEntities.Add(customerEventReading);
                customerEventReading = CreateEventReadingEntity(awvCarotidTestResult.LeftResultReadings.ICADistalEDV, (int)ReadingLabels.LICADistalEDV, testReadingReadingPairs);
                if (customerEventReading != null) customerEventReadingEntities.Add(customerEventReading);

                customerEventReading = CreateEventReadingEntity(awvCarotidTestResult.LeftResultReadings.VertebralArtPSV, (int)ReadingLabels.LVertebralArtPSV, testReadingReadingPairs);
                if (customerEventReading != null) customerEventReadingEntities.Add(customerEventReading);
                customerEventReading = CreateEventReadingEntity(awvCarotidTestResult.LeftResultReadings.VertebralArtEDV, (int)ReadingLabels.LVertebralArtEDV, testReadingReadingPairs);
                if (customerEventReading != null) customerEventReadingEntities.Add(customerEventReading);

                

                if (awvCarotidTestResult.LeftResultReadings.Finding != null)
                {
                    //TODO: Service methods being caled from the factory. need to Refactor and Revise it.
                    var customerEventTestStandardFindingEntity = new CustomerEventTestStandardFindingEntity
                    {
                        StandardFindingTestReadingId =
                            (int?)new TestResultService().GetStandardFindingTestReadingIdForStandardFinding((int)TestType.AwvCarotid, (int)ReadingLabels.Left, Convert.ToInt64(awvCarotidTestResult.LeftResultReadings.Finding.Id)),
                        CustomerEventTestStandardFindingId = awvCarotidTestResult.LeftResultReadings.Finding.CustomerEventStandardFindingId,
                        CustomerEventScreeningTestId = testResult.Id
                    };

                    var finding = GetSelectedStandardFinding((int)TestType.AwvCarotid, (int)ReadingLabels.Left, awvCarotidTestResult.LeftResultReadings.Finding.Id);

                    if (finding.ResultInterpretation != null) resultInterpretations.Add(finding.ResultInterpretation.Value);
                    if (finding.PathwayRecommendation != null) pathwayRecommendations.Add(finding.PathwayRecommendation.Value);

                    customerEventScreeningTestsEntity.CustomerEventTestStandardFinding.Add(customerEventTestStandardFindingEntity);
                }
            }

            if (awvCarotidTestResult.RightResultReadings != null)
            {
                var customerEventReading = CreateEventReadingEntity(awvCarotidTestResult.RightResultReadings.CCAProximalPSV, (int)ReadingLabels.RCCAProximalPSV, testReadingReadingPairs);
                if (customerEventReading != null) customerEventReadingEntities.Add(customerEventReading);
                customerEventReading = CreateEventReadingEntity(awvCarotidTestResult.RightResultReadings.CCAProximalEDV, (int)ReadingLabels.RCCAProximalEDV, testReadingReadingPairs);
                if (customerEventReading != null) customerEventReadingEntities.Add(customerEventReading);

                customerEventReading = CreateEventReadingEntity(awvCarotidTestResult.RightResultReadings.CCADistalPSV, (int)ReadingLabels.RCCADistalPSV, testReadingReadingPairs);
                if (customerEventReading != null) customerEventReadingEntities.Add(customerEventReading);
                customerEventReading = CreateEventReadingEntity(awvCarotidTestResult.RightResultReadings.CCADistalEDV, (int)ReadingLabels.RCCADistalEDV, testReadingReadingPairs);
                if (customerEventReading != null) customerEventReadingEntities.Add(customerEventReading);

                customerEventReading = CreateEventReadingEntity(awvCarotidTestResult.RightResultReadings.BulbPSV, (int)ReadingLabels.RBulbPSV, testReadingReadingPairs);
                if (customerEventReading != null) customerEventReadingEntities.Add(customerEventReading);
                customerEventReading = CreateEventReadingEntity(awvCarotidTestResult.RightResultReadings.BulbEDV, (int)ReadingLabels.RBulbEDV, testReadingReadingPairs);
                if (customerEventReading != null) customerEventReadingEntities.Add(customerEventReading);

                customerEventReading = CreateEventReadingEntity(awvCarotidTestResult.RightResultReadings.ExtCarotidArtPSV, (int)ReadingLabels.RExtCarotidArtPSV, testReadingReadingPairs);
                if (customerEventReading != null) customerEventReadingEntities.Add(customerEventReading);

                customerEventReading = CreateEventReadingEntity(awvCarotidTestResult.RightResultReadings.ICAProximalPSV, (int)ReadingLabels.RICAPSV, testReadingReadingPairs);
                if (customerEventReading != null) customerEventReadingEntities.Add(customerEventReading);
                customerEventReading = CreateEventReadingEntity(awvCarotidTestResult.RightResultReadings.ICAProximalEDV, (int)ReadingLabels.RICAEDV, testReadingReadingPairs);
                if (customerEventReading != null) customerEventReadingEntities.Add(customerEventReading);

                customerEventReading = CreateEventReadingEntity(awvCarotidTestResult.RightResultReadings.ICADistalPSV, (int)ReadingLabels.RICADistalPSV, testReadingReadingPairs);
                if (customerEventReading != null) customerEventReadingEntities.Add(customerEventReading);
                customerEventReading = CreateEventReadingEntity(awvCarotidTestResult.RightResultReadings.ICADistalEDV, (int)ReadingLabels.RICADistalEDV, testReadingReadingPairs);
                if (customerEventReading != null) customerEventReadingEntities.Add(customerEventReading);

                customerEventReading = CreateEventReadingEntity(awvCarotidTestResult.RightResultReadings.VertebralArtPSV, (int)ReadingLabels.RVertebralArtPSV, testReadingReadingPairs);
                if (customerEventReading != null) customerEventReadingEntities.Add(customerEventReading);
                customerEventReading = CreateEventReadingEntity(awvCarotidTestResult.RightResultReadings.VertebralArtEDV, (int)ReadingLabels.RVertebralArtEDV, testReadingReadingPairs);
                if (customerEventReading != null) customerEventReadingEntities.Add(customerEventReading);
                

                if (awvCarotidTestResult.RightResultReadings.Finding != null)
                {
                    //TODO: Service methods being caled from the factory. need to Refactor and Revise it.
                    var customerEventTestStandardFindingEntity = new CustomerEventTestStandardFindingEntity()
                    {
                        StandardFindingTestReadingId =
                            (int?)new TestResultService().GetStandardFindingTestReadingIdForStandardFinding
                                ((int)TestType.AwvCarotid, (int)ReadingLabels.Right, Convert.ToInt64(awvCarotidTestResult.RightResultReadings.Finding.Id)),
                        CustomerEventTestStandardFindingId = awvCarotidTestResult.RightResultReadings.Finding.CustomerEventStandardFindingId,
                        CustomerEventScreeningTestId = testResult.Id
                    };

                    var finding = GetSelectedStandardFinding((int)TestType.AwvCarotid, (int)ReadingLabels.Right, awvCarotidTestResult.RightResultReadings.Finding.Id);

                    if (finding.ResultInterpretation != null) resultInterpretations.Add(finding.ResultInterpretation.Value);
                    if (finding.PathwayRecommendation != null) pathwayRecommendations.Add(finding.PathwayRecommendation.Value);

                    customerEventScreeningTestsEntity.CustomerEventTestStandardFinding.Add(customerEventTestStandardFindingEntity);
                }
            }


            if (awvCarotidTestResult.LowVelocityLica != null)
            {
                //TODO: Service methods being caled from the factory. need to Refactor and Revise it.
                var customerEventTestStandardFindingEntity = new CustomerEventTestStandardFindingEntity()
                {
                    StandardFindingTestReadingId =
                        (int?)new TestResultService().GetStandardFindingTestReadingIdForStandardFinding
                            ((int)TestType.AwvCarotid, (int)ReadingLabels.LICAPSV, Convert.ToInt64(awvCarotidTestResult.LowVelocityLica.Id)),
                    CustomerEventTestStandardFindingId = awvCarotidTestResult.LowVelocityLica.CustomerEventStandardFindingId,
                    CustomerEventScreeningTestId = testResult.Id
                };

                customerEventScreeningTestsEntity.CustomerEventTestStandardFinding.Add(customerEventTestStandardFindingEntity);
            }

            if (awvCarotidTestResult.LowVelocityRica != null)
            {
                //TODO: Service methods being caled from the factory. need to Refactor and Revise it.
                var customerEventTestStandardFindingEntity = new CustomerEventTestStandardFindingEntity()
                {
                    StandardFindingTestReadingId =
                        (int?)new TestResultService().GetStandardFindingTestReadingIdForStandardFinding
                            ((int)TestType.AwvCarotid, (int)ReadingLabels.RICAPSV, Convert.ToInt64(awvCarotidTestResult.LowVelocityRica.Id)),
                    CustomerEventTestStandardFindingId = awvCarotidTestResult.LowVelocityRica.CustomerEventStandardFindingId,
                    CustomerEventScreeningTestId = testResult.Id
                };

                customerEventScreeningTestsEntity.CustomerEventTestStandardFinding.Add(customerEventTestStandardFindingEntity);
            }

            if (awvCarotidTestResult.TechnicallyLimitedbutReadable != null)
            {
                var customerEventReadingEntity = CreateEventReadingEntity(awvCarotidTestResult.TechnicallyLimitedbutReadable, (int)ReadingLabels.TechnicallyLimitedbutReadable, testReadingReadingPairs);
                if (customerEventReadingEntity != null) customerEventReadingEntities.Add(customerEventReadingEntity);
            }

            if (awvCarotidTestResult.RepeatStudy != null)
            {
                var customerEventReadingEntity = CreateEventReadingEntity(awvCarotidTestResult.RepeatStudy, (int)ReadingLabels.RepeatStudy, testReadingReadingPairs);
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
