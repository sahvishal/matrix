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
    public class DiabeticNeuropathyTestResultFactory : TestResultFactory
    {
        public override TestResult CreateActualTestResult(CustomerEventScreeningTestsEntity customerEventScreeningTestEntity)
        {
            var customerEventReadingEntities = customerEventScreeningTestEntity.CustomerEventReading.ToList();

            var testResult = new DiabeticNeuropathyTestResult(customerEventScreeningTestEntity.CustomerEventScreeningTestId);

            var customerEventTestStandardFindingEntities = customerEventScreeningTestEntity.CustomerEventTestStandardFinding.ToList();
            var standardFindingTestReadingEntities = customerEventScreeningTestEntity.StandardFindingTestReadingCollectionViaCustomerEventTestStandardFinding.ToList();

            if (customerEventTestStandardFindingEntities.Count() > 0)
            {
                var testResultService = new TestResultService();
                var standardFindings = testResultService.GetAllStandardFindings<int?>((int)TestType.DiabeticNeuropathy);

                customerEventTestStandardFindingEntities.ForEach(customerEventTestStandardFindingEntity =>
                {
                    var standardFindingTestReadingEntity = standardFindingTestReadingEntities.Find(entity => entity.StandardFindingTestReadingId == customerEventTestStandardFindingEntity.StandardFindingTestReadingId);
                    if (standardFindingTestReadingEntity == null) return;

                    var finding = CreateFindingObject(customerEventTestStandardFindingEntity, standardFindings, standardFindingTestReadingEntity, null);
                    if (finding != null)
                    {
                        testResult.Finding = finding; return;
                    }
                });
            }

            testResult.Amplitude = CreateResultReadingforNullableDecimal((int)ReadingLabels.Amplitude, customerEventReadingEntities);
            testResult.ConductionVelocity = CreateResultReadingforNullableDecimal((int)ReadingLabels.ConductionVelocity, customerEventReadingEntities);

            testResult.RightLeg = CreateResultReadingforNullableBool((int)ReadingLabels.RightLeg, customerEventReadingEntities);
            testResult.LeftLeg = CreateResultReadingforNullableBool((int)ReadingLabels.LeftLeg, customerEventReadingEntities);


            testResult.TechnicallyLimitedbutReadable = CreateResultReading((int)ReadingLabels.TechnicallyLimitedbutReadable, customerEventReadingEntities);
            testResult.RepeatStudy = CreateResultReading((int)ReadingLabels.RepeatStudy, customerEventReadingEntities);

            return testResult;
        }

        public override CustomerEventScreeningTestsEntity CreateActualTestResultEntity(TestResult testResult, List<OrderedPair<int, int>> testReadingReadingPairs)
        {
            var diabeticNeuropathyTestResult = testResult as DiabeticNeuropathyTestResult;
            var customerEventScreeningTestsEntity = new CustomerEventScreeningTestsEntity(testResult.Id) { TestId = (int)TestType.DiabeticNeuropathy };
            var customerEventReadingEntities = new List<CustomerEventReadingEntity>();

            testResult.ResultInterpretation = null;
            if (diabeticNeuropathyTestResult.Finding != null)
            {
                var customerEventTestStandardFindingEntity = new CustomerEventTestStandardFindingEntity
                {
                    StandardFindingTestReadingId = (int?)new TestResultService().GetStandardFindingTestReadingIdForStandardFinding((int)TestType.DiabeticNeuropathy, null, Convert.ToInt64(diabeticNeuropathyTestResult.Finding.Id)),

                    CustomerEventTestStandardFindingId = diabeticNeuropathyTestResult.Finding.CustomerEventStandardFindingId,
                    CustomerEventScreeningTestId = testResult.Id
                };

                var finding = GetSelectedStandardFinding((int)TestType.DiabeticNeuropathy, null, diabeticNeuropathyTestResult.Finding.Id);

                if (testResult.ResultStatus.StateNumber == (int)TestResultStateNumber.Evaluated || testResult.ResultStatus.StateNumber == (int)NewTestResultStateNumber.Evaluated)
                {
                    testResult.ResultInterpretation = finding.ResultInterpretation;
                    testResult.PathwayRecommendation = finding.PathwayRecommendation;
                }

                customerEventScreeningTestsEntity.CustomerEventTestStandardFinding.Add(customerEventTestStandardFindingEntity);
            }

            if (diabeticNeuropathyTestResult.Amplitude != null)
            {
                var customerEventReadingEntity = CreateEventReadingEntity(diabeticNeuropathyTestResult.Amplitude, (int)ReadingLabels.Amplitude, testReadingReadingPairs);
                if (customerEventReadingEntity != null) customerEventReadingEntities.Add(customerEventReadingEntity);
            }

            if (diabeticNeuropathyTestResult.ConductionVelocity != null)
            {
                var customerEventReadingEntity = CreateEventReadingEntity(diabeticNeuropathyTestResult.ConductionVelocity, (int)ReadingLabels.ConductionVelocity, testReadingReadingPairs);
                if (customerEventReadingEntity != null) customerEventReadingEntities.Add(customerEventReadingEntity);
            }

            if (diabeticNeuropathyTestResult.RightLeg != null)
            {
                var customerEventReadingEntity = CreateEventReadingEntity(diabeticNeuropathyTestResult.RightLeg, (int)ReadingLabels.RightLeg, testReadingReadingPairs);
                if (customerEventReadingEntity != null) customerEventReadingEntities.Add(customerEventReadingEntity);
            }

            if (diabeticNeuropathyTestResult.LeftLeg != null)
            {
                var customerEventReadingEntity = CreateEventReadingEntity(diabeticNeuropathyTestResult.LeftLeg, (int)ReadingLabels.LeftLeg, testReadingReadingPairs);
                if (customerEventReadingEntity != null) customerEventReadingEntities.Add(customerEventReadingEntity);
            }

            if (diabeticNeuropathyTestResult.TechnicallyLimitedbutReadable != null)
            {
                var customerEventReadingEntity = CreateEventReadingEntity(diabeticNeuropathyTestResult.TechnicallyLimitedbutReadable, (int)ReadingLabels.TechnicallyLimitedbutReadable, testReadingReadingPairs);
                if (customerEventReadingEntity != null) customerEventReadingEntities.Add(customerEventReadingEntity);
            }

            if (diabeticNeuropathyTestResult.RepeatStudy != null)
            {
                var customerEventReadingEntity = CreateEventReadingEntity(diabeticNeuropathyTestResult.RepeatStudy, (int)ReadingLabels.RepeatStudy, testReadingReadingPairs);
                if (customerEventReadingEntity != null) customerEventReadingEntities.Add(customerEventReadingEntity);
            }

            if (customerEventReadingEntities.Count > 0)
                customerEventScreeningTestsEntity.CustomerEventReading.AddRange(customerEventReadingEntities);

            return customerEventScreeningTestsEntity;
        }
    }
}
