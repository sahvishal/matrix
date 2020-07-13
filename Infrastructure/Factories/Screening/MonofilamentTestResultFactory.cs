using System.Collections.Generic;
using System.Linq;
using Falcon.App.Core.Medical.Domain;
using Falcon.App.Core.Medical.Enum;
using Falcon.Data.EntityClasses;

namespace Falcon.App.Infrastructure.Factories.Screening
{
    public class MonofilamentTestResultFactory : TestResultFactory
    {
        public override TestResult CreateActualTestResult(CustomerEventScreeningTestsEntity customerEventScreeningTestEntity)
        {
            var testResult = new MonofilamentTestResult(customerEventScreeningTestEntity.CustomerEventScreeningTestId);
            var customerEventReadingEntities = customerEventScreeningTestEntity.CustomerEventReading.ToList();

            testResult.RightPositive = CreateResultReadingforNullableBool((int)ReadingLabels.MonofilamentRightFootSensationIntact, customerEventReadingEntities);
            testResult.RightNegative = CreateResultReadingforNullableBool((int)ReadingLabels.MonofilamentRightFootSensationNotIntact, customerEventReadingEntities);

            testResult.LeftPositive = CreateResultReadingforNullableBool((int)ReadingLabels.MonofilamentLeftFootSensationIntact, customerEventReadingEntities);
            testResult.LeftNegative = CreateResultReadingforNullableBool((int)ReadingLabels.MonofilamentLeftFootSensationNotIntact, customerEventReadingEntities);

            return testResult;
        }

        public override CustomerEventScreeningTestsEntity CreateActualTestResultEntity(TestResult testResult, List<Core.OrderedPair<int, int>> testReadingReadingPairs)
        {
            var monofilamentTestResult = testResult as MonofilamentTestResult;

            var customerEventScreeningTestsEntity = new CustomerEventScreeningTestsEntity(testResult.Id) { TestId = (int)TestType.Monofilament };
            var customerEventReadingEntities = new List<CustomerEventReadingEntity>();


            if (monofilamentTestResult.RightPositive != null)
                customerEventReadingEntities.Add(CreateEventReadingEntity(monofilamentTestResult.RightPositive, (int)ReadingLabels.MonofilamentRightFootSensationIntact, testReadingReadingPairs));
            if (monofilamentTestResult.RightNegative != null)
                customerEventReadingEntities.Add(CreateEventReadingEntity(monofilamentTestResult.RightNegative, (int)ReadingLabels.MonofilamentRightFootSensationNotIntact, testReadingReadingPairs));

            if (monofilamentTestResult.LeftPositive != null)
                customerEventReadingEntities.Add(CreateEventReadingEntity(monofilamentTestResult.LeftPositive, (int)ReadingLabels.MonofilamentLeftFootSensationIntact, testReadingReadingPairs));
            if (monofilamentTestResult.LeftNegative != null)
                customerEventReadingEntities.Add(CreateEventReadingEntity(monofilamentTestResult.LeftNegative, (int)ReadingLabels.MonofilamentLeftFootSensationNotIntact, testReadingReadingPairs));
            
            customerEventScreeningTestsEntity.CustomerEventReading.AddRange(customerEventReadingEntities);
            return customerEventScreeningTestsEntity;
        }
    }
}