using System.Collections.Generic;
using System.Linq;
using Falcon.App.Core;
using Falcon.App.Core.Medical.Domain;
using Falcon.App.Core.Medical.Enum;
using Falcon.Data.EntityClasses;

namespace Falcon.App.Infrastructure.Factories.Screening
{
    public class AwvFluShotTestResultFactory : TestResultFactory
    {
        public override TestResult CreateActualTestResult(CustomerEventScreeningTestsEntity customerEventScreeningTestEntity)
        {
            var customerEventReadingEntities = customerEventScreeningTestEntity.CustomerEventReading.ToList();

            var testResult = new AwvFluShotTestResult(customerEventScreeningTestEntity.CustomerEventScreeningTestId)
            {
                Manufacturer = CreateResultReadingforInputValues((int)ReadingLabels.AwvFluShotManufacturer, customerEventReadingEntities),
                LotNumber = CreateResultReadingforInputValues((int)ReadingLabels.AwvFluShotLotNumber, customerEventReadingEntities),
                TechnicallyLimitedbutReadable = CreateResultReading((int)ReadingLabels.TechnicallyLimitedbutReadable, customerEventReadingEntities),
                RepeatStudy = CreateResultReading((int)ReadingLabels.RepeatStudy, customerEventReadingEntities)
            };

            return testResult;
        }

        public override CustomerEventScreeningTestsEntity CreateActualTestResultEntity(TestResult testResult, List<OrderedPair<int, int>> testReadingReadingPairs)
        {
            var awvFluShotTestResult = testResult as AwvFluShotTestResult;
            var customerEventScreeningTestsEntity = new CustomerEventScreeningTestsEntity(testResult.Id) { TestId = (int)TestType.AwvFluShot };
            var customerEventReadingEntities = new List<CustomerEventReadingEntity>();

            var customerEventReading = CreateEventReadingEntity(awvFluShotTestResult.Manufacturer, (int)ReadingLabels.AwvFluShotManufacturer, testReadingReadingPairs);
            if (customerEventReading != null) customerEventReadingEntities.Add(customerEventReading);

            customerEventReading = CreateEventReadingEntity(awvFluShotTestResult.LotNumber, (int)ReadingLabels.AwvFluShotLotNumber, testReadingReadingPairs);
            if (customerEventReading != null) customerEventReadingEntities.Add(customerEventReading);

            testResult.ResultInterpretation = null;

            if (awvFluShotTestResult.TechnicallyLimitedbutReadable != null)
            {
                var customerEventReadingEntity = CreateEventReadingEntity(awvFluShotTestResult.TechnicallyLimitedbutReadable, (int)ReadingLabels.TechnicallyLimitedbutReadable, testReadingReadingPairs);
                if (customerEventReadingEntity != null) customerEventReadingEntities.Add(customerEventReadingEntity);
            }

            if (awvFluShotTestResult.RepeatStudy != null)
            {
                var customerEventReadingEntity = CreateEventReadingEntity(awvFluShotTestResult.RepeatStudy, (int)ReadingLabels.RepeatStudy, testReadingReadingPairs);
                if (customerEventReadingEntity != null) customerEventReadingEntities.Add(customerEventReadingEntity);
            }

            if (customerEventReadingEntities.Count > 0)
                customerEventScreeningTestsEntity.CustomerEventReading.AddRange(customerEventReadingEntities);

            return customerEventScreeningTestsEntity;
        }
    }
}