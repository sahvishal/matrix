using System.Collections.Generic;
using System.Linq;
using Falcon.App.Core;
using Falcon.App.Core.Medical.Domain;
using Falcon.App.Core.Medical.Enum;
using Falcon.Data.EntityClasses;

namespace Falcon.App.Infrastructure.Factories.Screening
{
    public class FluShotTestResultFactory : TestResultFactory
    {
        public override TestResult CreateActualTestResult(CustomerEventScreeningTestsEntity customerEventScreeningTestEntity)
        {
            var customerEventReadingEntities = customerEventScreeningTestEntity.CustomerEventReading.ToList();

            var testResult = new FluShotTestResult(customerEventScreeningTestEntity.CustomerEventScreeningTestId)
            {
                Manufacturer = CreateResultReadingforInputValues((int)ReadingLabels.FluShotManufacturer, customerEventReadingEntities),
                LotNumber = CreateResultReadingforInputValues((int)ReadingLabels.FluShotLotNumber, customerEventReadingEntities),
                TechnicallyLimitedbutReadable = CreateResultReading((int)ReadingLabels.TechnicallyLimitedbutReadable, customerEventReadingEntities),
                RepeatStudy = CreateResultReading((int)ReadingLabels.RepeatStudy, customerEventReadingEntities)
            };

            return testResult;
        }

        public override CustomerEventScreeningTestsEntity CreateActualTestResultEntity(TestResult testResult, List<OrderedPair<int, int>> testReadingReadingPairs)
        {
            var fluShotTestResult = testResult as FluShotTestResult;
            var customerEventScreeningTestsEntity = new CustomerEventScreeningTestsEntity(testResult.Id) { TestId = (int)TestType.FluShot };
            var customerEventReadingEntities = new List<CustomerEventReadingEntity>();

            var customerEventReading = CreateEventReadingEntity(fluShotTestResult.Manufacturer, (int)ReadingLabels.FluShotManufacturer, testReadingReadingPairs);
            if (customerEventReading != null) customerEventReadingEntities.Add(customerEventReading);

            customerEventReading = CreateEventReadingEntity(fluShotTestResult.LotNumber, (int)ReadingLabels.FluShotLotNumber, testReadingReadingPairs);
            if (customerEventReading != null) customerEventReadingEntities.Add(customerEventReading);

            testResult.ResultInterpretation = null;

            if (fluShotTestResult.TechnicallyLimitedbutReadable != null)
            {
                var customerEventReadingEntity = CreateEventReadingEntity(fluShotTestResult.TechnicallyLimitedbutReadable, (int)ReadingLabels.TechnicallyLimitedbutReadable, testReadingReadingPairs);
                if (customerEventReadingEntity != null) customerEventReadingEntities.Add(customerEventReadingEntity);
            }

            if (fluShotTestResult.RepeatStudy != null)
            {
                var customerEventReadingEntity = CreateEventReadingEntity(fluShotTestResult.RepeatStudy, (int)ReadingLabels.RepeatStudy, testReadingReadingPairs);
                if (customerEventReadingEntity != null) customerEventReadingEntities.Add(customerEventReadingEntity);
            }

            if (customerEventReadingEntities.Count > 0)
                customerEventScreeningTestsEntity.CustomerEventReading.AddRange(customerEventReadingEntities);

            return customerEventScreeningTestsEntity;
        }
    }
}