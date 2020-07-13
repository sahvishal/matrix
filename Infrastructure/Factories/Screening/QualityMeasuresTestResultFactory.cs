using System;
using System.Collections.Generic;
using System.Linq;
using Falcon.App.Core;
using Falcon.App.Core.Medical.Domain;
using Falcon.App.Core.Medical.Enum;
using Falcon.App.Infrastructure.Service;
using Falcon.Data.EntityClasses;

namespace Falcon.App.Infrastructure.Factories.Screening
{
    public class QualityMeasuresTestResultFactory : TestResultFactory
    {
        public override TestResult CreateActualTestResult(CustomerEventScreeningTestsEntity customerEventScreeningTestEntity)
        {
            var customerEventReadingEntities = customerEventScreeningTestEntity.CustomerEventReading.ToList();

            var testResult = new QualityMeasuresTestResult(customerEventScreeningTestEntity.CustomerEventScreeningTestId);

            var customerEventTestStandardFindingEntities = customerEventScreeningTestEntity.CustomerEventTestStandardFinding.ToList();
            var standardFindingTestReadingEntities = customerEventScreeningTestEntity.StandardFindingTestReadingCollectionViaCustomerEventTestStandardFinding.ToList();

            if (customerEventTestStandardFindingEntities.Any())
            {
                var testResultService = new TestResultService();
                var functionalAssessmentScore = testResultService.GetAllStandardFindings<int?>((int)TestType.QualityMeasures, (int)ReadingLabels.FunctionalAssessmentScore);
                var painAssessmentScore = testResultService.GetAllStandardFindings<int?>((int)TestType.QualityMeasures, (int)ReadingLabels.PainAssessmentScore);

                customerEventTestStandardFindingEntities.ForEach(customerEventTestStandardFindingEntity =>
                {
                    var standardFindingTestReadingEntity = standardFindingTestReadingEntities.Find(entity => entity.StandardFindingTestReadingId == customerEventTestStandardFindingEntity.StandardFindingTestReadingId);
                    if (standardFindingTestReadingEntity == null) return;

                    var finding = CreateFindingObject(customerEventTestStandardFindingEntity, functionalAssessmentScore, standardFindingTestReadingEntity, (int)ReadingLabels.FunctionalAssessmentScore);
                    if (finding != null)
                    {
                        testResult.FunctionalAssessmentScore = finding; return;
                    }

                    finding = CreateFindingObject(customerEventTestStandardFindingEntity, painAssessmentScore, standardFindingTestReadingEntity, (int)ReadingLabels.PainAssessmentScore);
                    if (finding != null)
                    {
                        testResult.PainAssessmentScore = finding; return;
                    }
                });
            }

            
            testResult.MemoryRecallScore = CreateResultReadingforNullableInt((int)ReadingLabels.MemoryRecallScore, customerEventReadingEntities);

            testResult.ClockPass = CreateResultReading((int)ReadingLabels.ClockPass, customerEventReadingEntities);
            testResult.ClockFail = CreateResultReading((int)ReadingLabels.ClockFail, customerEventReadingEntities);

            testResult.GaitPass = CreateResultReading((int)ReadingLabels.GaitPass, customerEventReadingEntities);
            testResult.GaitFail = CreateResultReading((int)ReadingLabels.GaitFail, customerEventReadingEntities);

            testResult.TechnicallyLimitedbutReadable = CreateResultReading((int)ReadingLabels.TechnicallyLimitedbutReadable, customerEventReadingEntities);
            testResult.RepeatStudy = CreateResultReading((int)ReadingLabels.RepeatStudy, customerEventReadingEntities);

            return testResult;
        }

        public override CustomerEventScreeningTestsEntity CreateActualTestResultEntity(TestResult testResult, List<OrderedPair<int, int>> testReadingReadingPairs)
        {
            var qualityMeasuresTestResult = testResult as QualityMeasuresTestResult;
            var customerEventScreeningTestsEntity = new CustomerEventScreeningTestsEntity(testResult.Id) { TestId = (int)TestType.QualityMeasures };
            var customerEventReadingEntities = new List<CustomerEventReadingEntity>();

            testResult.ResultInterpretation = null;

            if (qualityMeasuresTestResult.MemoryRecallScore != null)
                customerEventReadingEntities.Add(CreateEventReadingEntity(qualityMeasuresTestResult.MemoryRecallScore, (int)ReadingLabels.MemoryRecallScore, testReadingReadingPairs));

            if (qualityMeasuresTestResult.ClockPass != null)
                customerEventReadingEntities.Add(CreateEventReadingEntity(qualityMeasuresTestResult.ClockPass, (int)ReadingLabels.ClockPass, testReadingReadingPairs));

            if (qualityMeasuresTestResult.ClockFail != null)
                customerEventReadingEntities.Add(CreateEventReadingEntity(qualityMeasuresTestResult.ClockFail, (int)ReadingLabels.ClockFail, testReadingReadingPairs));

            if (qualityMeasuresTestResult.GaitPass != null)
                customerEventReadingEntities.Add(CreateEventReadingEntity(qualityMeasuresTestResult.GaitPass, (int)ReadingLabels.GaitPass, testReadingReadingPairs));

            if (qualityMeasuresTestResult.GaitFail != null)
                customerEventReadingEntities.Add(CreateEventReadingEntity(qualityMeasuresTestResult.GaitFail, (int)ReadingLabels.GaitFail, testReadingReadingPairs));

            if (qualityMeasuresTestResult.FunctionalAssessmentScore != null)
            {
                var customerEventTestStandardFindingEntity = new CustomerEventTestStandardFindingEntity
                {
                    StandardFindingTestReadingId = (int?)new TestResultService().GetStandardFindingTestReadingIdForStandardFinding((int)TestType.QualityMeasures, (int)ReadingLabels.FunctionalAssessmentScore, Convert.ToInt64(qualityMeasuresTestResult.FunctionalAssessmentScore.Id)),

                    CustomerEventTestStandardFindingId = qualityMeasuresTestResult.FunctionalAssessmentScore.CustomerEventStandardFindingId,
                    CustomerEventScreeningTestId = testResult.Id
                };

                customerEventScreeningTestsEntity.CustomerEventTestStandardFinding.Add(customerEventTestStandardFindingEntity);
            }

            if (qualityMeasuresTestResult.PainAssessmentScore != null)
            {
                var customerEventTestStandardFindingEntity = new CustomerEventTestStandardFindingEntity
                {
                    StandardFindingTestReadingId =
                            (int?)new TestResultService().GetStandardFindingTestReadingIdForStandardFinding((int)TestType.QualityMeasures,
                                            (int)ReadingLabels.PainAssessmentScore, Convert.ToInt64(qualityMeasuresTestResult.PainAssessmentScore.Id)),

                    CustomerEventTestStandardFindingId = qualityMeasuresTestResult.PainAssessmentScore.CustomerEventStandardFindingId,
                    CustomerEventScreeningTestId = testResult.Id
                };

                customerEventScreeningTestsEntity.CustomerEventTestStandardFinding.Add(customerEventTestStandardFindingEntity);
            }

            if (qualityMeasuresTestResult.TechnicallyLimitedbutReadable != null)
            {
                var customerEventReadingEntity = CreateEventReadingEntity(qualityMeasuresTestResult.TechnicallyLimitedbutReadable, (int)ReadingLabels.TechnicallyLimitedbutReadable, testReadingReadingPairs);
                if (customerEventReadingEntity != null) customerEventReadingEntities.Add(customerEventReadingEntity);
            }

            if (qualityMeasuresTestResult.RepeatStudy != null)
            {
                var customerEventReadingEntity = CreateEventReadingEntity(qualityMeasuresTestResult.RepeatStudy, (int)ReadingLabels.RepeatStudy, testReadingReadingPairs);
                if (customerEventReadingEntity != null) customerEventReadingEntities.Add(customerEventReadingEntity);
            }

            if (customerEventReadingEntities.Count > 0)
                customerEventScreeningTestsEntity.CustomerEventReading.AddRange(customerEventReadingEntities);

            return customerEventScreeningTestsEntity;
        }
    }
}