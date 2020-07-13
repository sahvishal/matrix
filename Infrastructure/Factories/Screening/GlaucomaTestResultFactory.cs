using System.Collections.Generic;
using System.Linq;
using Falcon.App.Core.Medical.Domain;
using Falcon.App.Core.Medical.Enum;
using Falcon.Data.EntityClasses;

namespace Falcon.App.Infrastructure.Factories.Screening
{
    public class GlaucomaTestResultFactory : TestResultFactory
    {
        public override TestResult CreateActualTestResult(CustomerEventScreeningTestsEntity customerEventScreeningTestEntity)
        {
            var testResult = new GlaucomaTestResult(customerEventScreeningTestEntity.CustomerEventScreeningTestId);
            var customerEventReadingEntities = customerEventScreeningTestEntity.CustomerEventReading.ToList();

            testResult.AmslerRightEye = CreateResultReadingforNullableBool((int)ReadingLabels.AmslerRightEye, customerEventReadingEntities);
            testResult.AmslerLeftEye = CreateResultReadingforNullableBool((int)ReadingLabels.AmslerLeftEye, customerEventReadingEntities);

            testResult.RightEyePressure = CreateResultReadingforNullableInt((int)ReadingLabels.RightEyePressure, customerEventReadingEntities);
            testResult.LeftEyePressure = CreateResultReadingforNullableInt((int)ReadingLabels.LeftEyePressure, customerEventReadingEntities);

            return testResult;
        }

        public override CustomerEventScreeningTestsEntity CreateActualTestResultEntity(TestResult testResult, List<Core.OrderedPair<int, int>> testReadingReadingPairs)
        {
            var glaucomaTestResult = testResult as GlaucomaTestResult;

            var customerEventScreeningTestsEntity = new CustomerEventScreeningTestsEntity(testResult.Id) { TestId = (int)TestType.Glaucoma };
            var customerEventReadingEntities = new List<CustomerEventReadingEntity>();

            if (glaucomaTestResult.AmslerRightEye != null)
                customerEventReadingEntities.Add(CreateEventReadingEntity(glaucomaTestResult.AmslerRightEye, (int)ReadingLabels.AmslerRightEye, testReadingReadingPairs));
            if (glaucomaTestResult.AmslerLeftEye != null)
                customerEventReadingEntities.Add(CreateEventReadingEntity(glaucomaTestResult.AmslerLeftEye, (int)ReadingLabels.AmslerLeftEye, testReadingReadingPairs));

            if (glaucomaTestResult.RightEyePressure != null)
                customerEventReadingEntities.Add(CreateEventReadingEntity(glaucomaTestResult.RightEyePressure, (int)ReadingLabels.RightEyePressure, testReadingReadingPairs));
            if (glaucomaTestResult.LeftEyePressure != null)
                customerEventReadingEntities.Add(CreateEventReadingEntity(glaucomaTestResult.LeftEyePressure, (int)ReadingLabels.LeftEyePressure, testReadingReadingPairs));

            customerEventScreeningTestsEntity.CustomerEventReading.AddRange(customerEventReadingEntities);
            return customerEventScreeningTestsEntity;
        }
    }
}
