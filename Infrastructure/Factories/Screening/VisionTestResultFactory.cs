using System.Collections.Generic;
using System.Linq;
using Falcon.App.Core.Medical.Domain;
using Falcon.App.Core.Medical.Enum;
using Falcon.Data.EntityClasses;

namespace Falcon.App.Infrastructure.Factories.Screening
{
    public class VisionTestResultFactory : TestResultFactory
    {
        public override TestResult CreateActualTestResult(CustomerEventScreeningTestsEntity customerEventScreeningTestEntity)
        {
            var testResult = new VisionTestResult(customerEventScreeningTestEntity.CustomerEventScreeningTestId);
            var customerEventReadingEntities = customerEventScreeningTestEntity.CustomerEventReading.ToList();

            testResult.BothEyesLeftUpperQuadrant = CreateResultReadingforNullableBool((int)ReadingLabels.BothEyesLeftUpperQuadrant, customerEventReadingEntities);
            testResult.BothEyesLeftLowerQuadrant = CreateResultReadingforNullableBool((int)ReadingLabels.BothEyesLeftLowerQuadrant, customerEventReadingEntities);
            testResult.BothEyesRightUpperQuadrant = CreateResultReadingforNullableBool((int)ReadingLabels.BothEyesRightUpperQuadrant, customerEventReadingEntities);
            testResult.BothEyesRightLowerQuadrant = CreateResultReadingforNullableBool((int)ReadingLabels.BothEyesRightLowerQuadrant, customerEventReadingEntities);

            testResult.RightEyeLeftUpperQuadrant = CreateResultReadingforNullableBool((int)ReadingLabels.RightEyeLeftUpperQuadrant, customerEventReadingEntities);
            testResult.RightEyeLeftLowerQuadrant = CreateResultReadingforNullableBool((int)ReadingLabels.RightEyeLeftLowerQuadrant, customerEventReadingEntities);
            testResult.RightEyeRightUpperQuadrant = CreateResultReadingforNullableBool((int)ReadingLabels.RightEyeRightUpperQuadrant, customerEventReadingEntities);
            testResult.RightEyeRightLowerQuadrant = CreateResultReadingforNullableBool((int)ReadingLabels.RightEyeRightLowerQuadrant, customerEventReadingEntities);

            testResult.LeftEyeLeftUpperQuadrant = CreateResultReadingforNullableBool((int)ReadingLabels.LeftEyeLeftUpperQuadrant, customerEventReadingEntities);
            testResult.LeftEyeLeftLowerQuadrant = CreateResultReadingforNullableBool((int)ReadingLabels.LeftEyeLeftLowerQuadrant, customerEventReadingEntities);
            testResult.LeftEyeRightUpperQuadrant = CreateResultReadingforNullableBool((int)ReadingLabels.LeftEyeRightUpperQuadrant, customerEventReadingEntities);
            testResult.LeftEyeRightLowerQuadrant = CreateResultReadingforNullableBool((int)ReadingLabels.LeftEyeRightLowerQuadrant, customerEventReadingEntities);

            testResult.RightEyeCylindrical = CreateResultReadingforNullableInt((int)ReadingLabels.RightEyeCylindrical, customerEventReadingEntities);
            testResult.RightEyeSpherical = CreateResultReadingforNullableInt((int)ReadingLabels.RightEyeSpherical, customerEventReadingEntities);

            testResult.LeftEyeCylindrical = CreateResultReadingforNullableInt((int)ReadingLabels.LeftEyeCylindrical, customerEventReadingEntities);
            testResult.LeftEyeSpherical = CreateResultReadingforNullableInt((int)ReadingLabels.LeftEyeSpherical, customerEventReadingEntities);

            return testResult;
        }

        public override CustomerEventScreeningTestsEntity CreateActualTestResultEntity(TestResult testResult, List<Core.OrderedPair<int, int>> testReadingReadingPairs)
        {
            var visionTestResult = testResult as VisionTestResult;

            var customerEventScreeningTestsEntity = new CustomerEventScreeningTestsEntity(testResult.Id) { TestId = (int)TestType.Vision };
            var customerEventReadingEntities = new List<CustomerEventReadingEntity>();

            if (visionTestResult.BothEyesLeftUpperQuadrant != null)
                customerEventReadingEntities.Add(CreateEventReadingEntity(visionTestResult.BothEyesLeftUpperQuadrant, (int)ReadingLabels.BothEyesLeftUpperQuadrant, testReadingReadingPairs));
            if (visionTestResult.BothEyesLeftLowerQuadrant != null)
                customerEventReadingEntities.Add(CreateEventReadingEntity(visionTestResult.BothEyesLeftLowerQuadrant, (int)ReadingLabels.BothEyesLeftLowerQuadrant, testReadingReadingPairs));
            if (visionTestResult.BothEyesRightUpperQuadrant != null)
                customerEventReadingEntities.Add(CreateEventReadingEntity(visionTestResult.BothEyesRightUpperQuadrant, (int)ReadingLabels.BothEyesRightUpperQuadrant, testReadingReadingPairs));
            if (visionTestResult.BothEyesRightLowerQuadrant != null)
                customerEventReadingEntities.Add(CreateEventReadingEntity(visionTestResult.BothEyesRightLowerQuadrant, (int)ReadingLabels.BothEyesRightLowerQuadrant, testReadingReadingPairs));

            if (visionTestResult.RightEyeLeftUpperQuadrant != null)
                customerEventReadingEntities.Add(CreateEventReadingEntity(visionTestResult.RightEyeLeftUpperQuadrant, (int)ReadingLabels.RightEyeLeftUpperQuadrant, testReadingReadingPairs));
            if (visionTestResult.RightEyeLeftLowerQuadrant != null)
                customerEventReadingEntities.Add(CreateEventReadingEntity(visionTestResult.RightEyeLeftLowerQuadrant, (int)ReadingLabels.RightEyeLeftLowerQuadrant, testReadingReadingPairs));
            if (visionTestResult.RightEyeRightUpperQuadrant != null)
                customerEventReadingEntities.Add(CreateEventReadingEntity(visionTestResult.RightEyeRightUpperQuadrant, (int)ReadingLabels.RightEyeRightUpperQuadrant, testReadingReadingPairs));
            if (visionTestResult.RightEyeRightLowerQuadrant != null)
                customerEventReadingEntities.Add(CreateEventReadingEntity(visionTestResult.RightEyeRightLowerQuadrant, (int)ReadingLabels.RightEyeRightLowerQuadrant, testReadingReadingPairs));

            if (visionTestResult.LeftEyeLeftUpperQuadrant != null)
                customerEventReadingEntities.Add(CreateEventReadingEntity(visionTestResult.LeftEyeLeftUpperQuadrant, (int)ReadingLabels.LeftEyeLeftUpperQuadrant, testReadingReadingPairs));
            if (visionTestResult.LeftEyeLeftLowerQuadrant != null)
                customerEventReadingEntities.Add(CreateEventReadingEntity(visionTestResult.LeftEyeLeftLowerQuadrant, (int)ReadingLabels.LeftEyeLeftLowerQuadrant, testReadingReadingPairs));
            if (visionTestResult.LeftEyeRightUpperQuadrant != null)
                customerEventReadingEntities.Add(CreateEventReadingEntity(visionTestResult.LeftEyeRightUpperQuadrant, (int)ReadingLabels.LeftEyeRightUpperQuadrant, testReadingReadingPairs));
            if (visionTestResult.LeftEyeRightLowerQuadrant != null)
                customerEventReadingEntities.Add(CreateEventReadingEntity(visionTestResult.LeftEyeRightLowerQuadrant, (int)ReadingLabels.LeftEyeRightLowerQuadrant, testReadingReadingPairs));

            if (visionTestResult.RightEyeCylindrical != null)
                customerEventReadingEntities.Add(CreateEventReadingEntity(visionTestResult.RightEyeCylindrical, (int)ReadingLabels.RightEyeCylindrical, testReadingReadingPairs));
            if (visionTestResult.RightEyeSpherical != null)
                customerEventReadingEntities.Add(CreateEventReadingEntity(visionTestResult.RightEyeSpherical, (int)ReadingLabels.RightEyeSpherical, testReadingReadingPairs));

            if (visionTestResult.LeftEyeCylindrical != null)
                customerEventReadingEntities.Add(CreateEventReadingEntity(visionTestResult.LeftEyeCylindrical, (int)ReadingLabels.LeftEyeCylindrical, testReadingReadingPairs));
            if (visionTestResult.LeftEyeSpherical != null)
                customerEventReadingEntities.Add(CreateEventReadingEntity(visionTestResult.LeftEyeSpherical, (int)ReadingLabels.LeftEyeSpherical, testReadingReadingPairs));

            customerEventScreeningTestsEntity.CustomerEventReading.AddRange(customerEventReadingEntities);
            return customerEventScreeningTestsEntity;
        }
    }
}