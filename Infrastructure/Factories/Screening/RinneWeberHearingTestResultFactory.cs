using System.Collections.Generic;
using System.Linq;
using Falcon.App.Core.Medical.Domain;
using Falcon.App.Core.Medical.Enum;
using Falcon.Data.EntityClasses;

namespace Falcon.App.Infrastructure.Factories.Screening
{
    public class RinneWeberHearingTestResultFactory : TestResultFactory
    {
        public override TestResult CreateActualTestResult(CustomerEventScreeningTestsEntity customerEventScreeningTestEntity)
        {
            var testResult = new RinneWeberHearingTestResult(customerEventScreeningTestEntity.CustomerEventScreeningTestId);
            var customerEventReadingEntities = customerEventScreeningTestEntity.CustomerEventReading.ToList();

            testResult.WeberNormal = CreateResultReadingforNullableBool((int)ReadingLabels.WeberNormal, customerEventReadingEntities);
            testResult.WeberAbnormal = CreateResultReadingforNullableBool((int)ReadingLabels.WeberAbnormal, customerEventReadingEntities);
            
            testResult.RinneNormal = CreateResultReadingforNullableBool((int)ReadingLabels.RinneNormal, customerEventReadingEntities);
            testResult.RinneAbnormal = CreateResultReadingforNullableBool((int)ReadingLabels.RinneAbnormal, customerEventReadingEntities);

            return testResult;
        }

        public override CustomerEventScreeningTestsEntity CreateActualTestResultEntity(TestResult testResult, List<Core.OrderedPair<int, int>> testReadingReadingPairs)
        {
            var rinneWeberHearingTestResult = testResult as RinneWeberHearingTestResult;

            var customerEventScreeningTestsEntity = new CustomerEventScreeningTestsEntity(testResult.Id) { TestId = (int)TestType.RinneWeberHearing };
            var customerEventReadingEntities = new List<CustomerEventReadingEntity>();


            if (rinneWeberHearingTestResult.WeberNormal != null)
                customerEventReadingEntities.Add(CreateEventReadingEntity(rinneWeberHearingTestResult.WeberNormal, (int)ReadingLabels.WeberNormal, testReadingReadingPairs));
            if (rinneWeberHearingTestResult.WeberAbnormal != null)
                customerEventReadingEntities.Add(CreateEventReadingEntity(rinneWeberHearingTestResult.WeberAbnormal, (int)ReadingLabels.WeberAbnormal, testReadingReadingPairs));

            if (rinneWeberHearingTestResult.RinneNormal != null)
                customerEventReadingEntities.Add(CreateEventReadingEntity(rinneWeberHearingTestResult.RinneNormal, (int)ReadingLabels.RinneNormal, testReadingReadingPairs));
            if (rinneWeberHearingTestResult.RinneAbnormal != null)
                customerEventReadingEntities.Add(CreateEventReadingEntity(rinneWeberHearingTestResult.RinneAbnormal, (int)ReadingLabels.RinneAbnormal, testReadingReadingPairs));
            
            customerEventScreeningTestsEntity.CustomerEventReading.AddRange(customerEventReadingEntities);
            return customerEventScreeningTestsEntity;
        }
    }
}