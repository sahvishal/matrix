using System.Collections.Generic;
using System.Linq;
using Falcon.App.Core.Medical.Domain;
using Falcon.App.Core.Medical.Enum;
using Falcon.Data.EntityClasses;

namespace Falcon.App.Infrastructure.Factories.Screening
{
    public class HypertensionTestResultFactory : TestResultFactory
    {
        public override TestResult CreateActualTestResult(CustomerEventScreeningTestsEntity customerEventScreeningTestEntity)
        {
            var testResult = new HypertensionTestResult(customerEventScreeningTestEntity.CustomerEventScreeningTestId);
            var customerEventReadingEntities = customerEventScreeningTestEntity.CustomerEventReading.ToList();
            
            testResult.Systolic = CreateResultReadingforNullableInt((int)ReadingLabels.SystolicRight, customerEventReadingEntities);
            testResult.Diastolic = CreateResultReadingforNullableInt((int)ReadingLabels.DiastolicRight, customerEventReadingEntities);

            testResult.Pulse = CreateResultReadingforNullableInt((int)ReadingLabels.Pulse, customerEventReadingEntities);
            testResult.BloodPressureElevated = CreateResultReading((int)ReadingLabels.BloodPressureElevated, customerEventReadingEntities);
            testResult.RightArmBpMeasurement = CreateResultReading((int)ReadingLabels.RightArmBpMeasurement, customerEventReadingEntities);

            testResult.TechnicallyLimitedbutReadable = CreateResultReading((int)ReadingLabels.TechnicallyLimitedbutReadable, customerEventReadingEntities);
            testResult.RepeatStudy = CreateResultReading((int)ReadingLabels.RepeatStudy, customerEventReadingEntities);
            
            return testResult;
        }

        public override CustomerEventScreeningTestsEntity CreateActualTestResultEntity(TestResult testResult, List<Core.OrderedPair<int, int>> testReadingReadingPairs)
        {
            var hypertensionTestResult = testResult as HypertensionTestResult;

            var customerEventScreeningTestsEntity = new CustomerEventScreeningTestsEntity(testResult.Id) { TestId = (int)TestType.Hypertension };
            var customerEventReadingEntities = new List<CustomerEventReadingEntity>();

            
            if (hypertensionTestResult.Systolic != null)
                customerEventReadingEntities.Add(CreateEventReadingEntity(hypertensionTestResult.Systolic, (int)ReadingLabels.SystolicRight, testReadingReadingPairs));

            if (hypertensionTestResult.Diastolic!= null)
                customerEventReadingEntities.Add(CreateEventReadingEntity(hypertensionTestResult.Diastolic, (int)ReadingLabels.DiastolicRight, testReadingReadingPairs));

            if (hypertensionTestResult.Pulse != null)
                customerEventReadingEntities.Add(CreateEventReadingEntity(hypertensionTestResult.Pulse, (int)ReadingLabels.Pulse, testReadingReadingPairs));

            if (hypertensionTestResult.RightArmBpMeasurement != null)
                customerEventReadingEntities.Add(CreateEventReadingEntity(hypertensionTestResult.RightArmBpMeasurement, (int)ReadingLabels.RightArmBpMeasurement, testReadingReadingPairs));

            if (hypertensionTestResult.BloodPressureElevated != null)
                customerEventReadingEntities.Add(CreateEventReadingEntity(hypertensionTestResult.BloodPressureElevated, (int)ReadingLabels.BloodPressureElevated, testReadingReadingPairs));

            if (hypertensionTestResult.TechnicallyLimitedbutReadable != null)
            {
                var customerEventReading = CreateEventReadingEntity(hypertensionTestResult.TechnicallyLimitedbutReadable, (int)ReadingLabels.TechnicallyLimitedbutReadable, testReadingReadingPairs);

                customerEventReadingEntities.Add(customerEventReading);
            }

            if (hypertensionTestResult.RepeatStudy != null)
            {
                var customerEventReading = CreateEventReadingEntity(hypertensionTestResult.RepeatStudy, (int)ReadingLabels.RepeatStudy, testReadingReadingPairs);

                customerEventReadingEntities.Add(customerEventReading);
            }

            customerEventScreeningTestsEntity.CustomerEventReading.AddRange(customerEventReadingEntities);

            return customerEventScreeningTestsEntity;
        }
    }
}