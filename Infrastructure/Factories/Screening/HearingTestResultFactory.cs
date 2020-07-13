using System.Collections.Generic;
using System.Linq;
using Falcon.App.Core.Medical.Domain;
using Falcon.App.Core.Medical.Enum;
using Falcon.Data.EntityClasses;

namespace Falcon.App.Infrastructure.Factories.Screening
{
    public class HearingTestResultFactory : TestResultFactory
    {
        public override TestResult CreateActualTestResult(CustomerEventScreeningTestsEntity customerEventScreeningTestEntity)
        {
            var testResult = new HearingTestResult(customerEventScreeningTestEntity.CustomerEventScreeningTestId);
            var customerEventReadingEntities = customerEventScreeningTestEntity.CustomerEventReading.ToList();

            testResult.HearingSummary = CreateResultReadingforNullableBool((int)ReadingLabels.HearingSummary, customerEventReadingEntities);

            testResult.RightEar500Hz = CreateResultReadingforNullableInt((int)ReadingLabels.RightEar500Hz, customerEventReadingEntities);
            testResult.LeftEar500Hz = CreateResultReadingforNullableInt((int)ReadingLabels.LeftEar500Hz, customerEventReadingEntities);

            testResult.RightEar1000Hz = CreateResultReadingforNullableInt((int)ReadingLabels.RightEar1000Hz, customerEventReadingEntities);
            testResult.LeftEar1000Hz = CreateResultReadingforNullableInt((int)ReadingLabels.LeftEar1000Hz, customerEventReadingEntities);

            testResult.RightEar2000Hz = CreateResultReadingforNullableInt((int)ReadingLabels.RightEar2000Hz, customerEventReadingEntities);
            testResult.LeftEar2000Hz = CreateResultReadingforNullableInt((int)ReadingLabels.LeftEar2000Hz, customerEventReadingEntities);

            testResult.RightEar3000Hz = CreateResultReadingforNullableInt((int)ReadingLabels.RightEar3000Hz, customerEventReadingEntities);
            testResult.LeftEar3000Hz = CreateResultReadingforNullableInt((int)ReadingLabels.LeftEar3000Hz, customerEventReadingEntities);

            testResult.RightEar4000Hz = CreateResultReadingforNullableInt((int)ReadingLabels.RightEar4000Hz, customerEventReadingEntities);
            testResult.LeftEar4000Hz = CreateResultReadingforNullableInt((int)ReadingLabels.LeftEar4000Hz, customerEventReadingEntities);

            testResult.RightEar6000Hz = CreateResultReadingforNullableInt((int)ReadingLabels.RightEar6000Hz, customerEventReadingEntities);
            testResult.LeftEar6000Hz = CreateResultReadingforNullableInt((int)ReadingLabels.LeftEar6000Hz, customerEventReadingEntities);

            testResult.RightEar8000Hz = CreateResultReadingforNullableInt((int)ReadingLabels.RightEar8000Hz, customerEventReadingEntities);
            testResult.LeftEar8000Hz = CreateResultReadingforNullableInt((int)ReadingLabels.LeftEar8000Hz, customerEventReadingEntities);

            return testResult;
        }

        public override CustomerEventScreeningTestsEntity CreateActualTestResultEntity(TestResult testResult, List<Core.OrderedPair<int, int>> testReadingReadingPairs)
        {
            var hearingTestResult = testResult as HearingTestResult;

            var customerEventScreeningTestsEntity = new CustomerEventScreeningTestsEntity(testResult.Id) { TestId = (int)TestType.Hearing };
            var customerEventReadingEntities = new List<CustomerEventReadingEntity>();

            if (hearingTestResult.HearingSummary != null)
                customerEventReadingEntities.Add(CreateEventReadingEntity(hearingTestResult.HearingSummary, (int)ReadingLabels.HearingSummary, testReadingReadingPairs));

            if (hearingTestResult.RightEar500Hz != null)
                customerEventReadingEntities.Add(CreateEventReadingEntity(hearingTestResult.RightEar500Hz, (int)ReadingLabels.RightEar500Hz, testReadingReadingPairs));
            if (hearingTestResult.LeftEar500Hz != null)
                customerEventReadingEntities.Add(CreateEventReadingEntity(hearingTestResult.LeftEar500Hz, (int)ReadingLabels.LeftEar500Hz, testReadingReadingPairs));

            if (hearingTestResult.RightEar1000Hz != null)
                customerEventReadingEntities.Add(CreateEventReadingEntity(hearingTestResult.RightEar1000Hz, (int)ReadingLabels.RightEar1000Hz, testReadingReadingPairs));
            if (hearingTestResult.LeftEar1000Hz != null)
                customerEventReadingEntities.Add(CreateEventReadingEntity(hearingTestResult.LeftEar1000Hz, (int)ReadingLabels.LeftEar1000Hz, testReadingReadingPairs));

            if (hearingTestResult.RightEar2000Hz != null)
                customerEventReadingEntities.Add(CreateEventReadingEntity(hearingTestResult.RightEar2000Hz, (int)ReadingLabels.RightEar2000Hz, testReadingReadingPairs));
            if (hearingTestResult.LeftEar2000Hz != null)
                customerEventReadingEntities.Add(CreateEventReadingEntity(hearingTestResult.LeftEar2000Hz, (int)ReadingLabels.LeftEar2000Hz, testReadingReadingPairs));

            if (hearingTestResult.RightEar3000Hz != null)
                customerEventReadingEntities.Add(CreateEventReadingEntity(hearingTestResult.RightEar3000Hz, (int)ReadingLabels.RightEar3000Hz, testReadingReadingPairs));
            if (hearingTestResult.LeftEar3000Hz != null)
                customerEventReadingEntities.Add(CreateEventReadingEntity(hearingTestResult.LeftEar3000Hz, (int)ReadingLabels.LeftEar3000Hz, testReadingReadingPairs));

            if (hearingTestResult.RightEar4000Hz != null)
                customerEventReadingEntities.Add(CreateEventReadingEntity(hearingTestResult.RightEar4000Hz, (int)ReadingLabels.RightEar4000Hz, testReadingReadingPairs));
            if (hearingTestResult.LeftEar4000Hz != null)
                customerEventReadingEntities.Add(CreateEventReadingEntity(hearingTestResult.LeftEar4000Hz, (int)ReadingLabels.LeftEar4000Hz, testReadingReadingPairs));

            if (hearingTestResult.RightEar6000Hz != null)
                customerEventReadingEntities.Add(CreateEventReadingEntity(hearingTestResult.RightEar6000Hz, (int)ReadingLabels.RightEar6000Hz, testReadingReadingPairs));
            if (hearingTestResult.LeftEar6000Hz != null)
                customerEventReadingEntities.Add(CreateEventReadingEntity(hearingTestResult.LeftEar6000Hz, (int)ReadingLabels.LeftEar6000Hz, testReadingReadingPairs));

            if (hearingTestResult.RightEar8000Hz != null)
                customerEventReadingEntities.Add(CreateEventReadingEntity(hearingTestResult.RightEar8000Hz, (int)ReadingLabels.RightEar8000Hz, testReadingReadingPairs));
            if (hearingTestResult.LeftEar8000Hz != null)
                customerEventReadingEntities.Add(CreateEventReadingEntity(hearingTestResult.LeftEar8000Hz, (int)ReadingLabels.LeftEar8000Hz, testReadingReadingPairs));


            customerEventScreeningTestsEntity.CustomerEventReading.AddRange(customerEventReadingEntities);
            return customerEventScreeningTestsEntity;
        }
    }
}
