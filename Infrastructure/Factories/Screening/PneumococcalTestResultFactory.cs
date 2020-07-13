using System.Collections.Generic;
using System.Linq;
using Falcon.App.Core;
using Falcon.App.Core.Medical.Domain;
using Falcon.App.Core.Medical.Enum;
using Falcon.Data.EntityClasses;

namespace Falcon.App.Infrastructure.Factories.Screening
{
    public class PneumococcalTestResultFactory : TestResultFactory
    {
        public override TestResult CreateActualTestResult(CustomerEventScreeningTestsEntity customerEventScreeningTestEntity)
        {
            var customerEventReadingEntities = customerEventScreeningTestEntity.CustomerEventReading.ToList();

            var testResult = new PneumococcalTestResult(customerEventScreeningTestEntity.CustomerEventScreeningTestId)
            {
                Manufacturer = CreateResultReadingforInputValues((int)ReadingLabels.PneumococcalManufacturer, customerEventReadingEntities),
                LotNumber = CreateResultReadingforInputValues((int)ReadingLabels.PneumococcalLotNumber, customerEventReadingEntities),
                TechnicallyLimitedbutReadable = CreateResultReading((int)ReadingLabels.TechnicallyLimitedbutReadable, customerEventReadingEntities),
                RepeatStudy = CreateResultReading((int)ReadingLabels.RepeatStudy, customerEventReadingEntities)
            };

            return testResult;
        }

        public override CustomerEventScreeningTestsEntity CreateActualTestResultEntity(TestResult testResult, List<OrderedPair<int, int>> testReadingReadingPairs)
        {
            var pneumococcalTestResult = testResult as PneumococcalTestResult;
            var customerEventScreeningTestsEntity = new CustomerEventScreeningTestsEntity(testResult.Id) { TestId = (int)TestType.Pneumococcal };
            var customerEventReadingEntities = new List<CustomerEventReadingEntity>();

            var customerEventReading = CreateEventReadingEntity(pneumococcalTestResult.Manufacturer, (int)ReadingLabels.PneumococcalManufacturer, testReadingReadingPairs);
            if (customerEventReading != null) customerEventReadingEntities.Add(customerEventReading);

            customerEventReading = CreateEventReadingEntity(pneumococcalTestResult.LotNumber, (int)ReadingLabels.PneumococcalLotNumber, testReadingReadingPairs);
            if (customerEventReading != null) customerEventReadingEntities.Add(customerEventReading);

            testResult.ResultInterpretation = null;

            if (pneumococcalTestResult.TechnicallyLimitedbutReadable != null)
            {
                var customerEventReadingEntity = CreateEventReadingEntity(pneumococcalTestResult.TechnicallyLimitedbutReadable, (int)ReadingLabels.TechnicallyLimitedbutReadable, testReadingReadingPairs);
                if (customerEventReadingEntity != null) customerEventReadingEntities.Add(customerEventReadingEntity);
            }

            if (pneumococcalTestResult.RepeatStudy != null)
            {
                var customerEventReadingEntity = CreateEventReadingEntity(pneumococcalTestResult.RepeatStudy, (int)ReadingLabels.RepeatStudy, testReadingReadingPairs);
                if (customerEventReadingEntity != null) customerEventReadingEntities.Add(customerEventReadingEntity);
            }

            if (customerEventReadingEntities.Count > 0)
                customerEventScreeningTestsEntity.CustomerEventReading.AddRange(customerEventReadingEntities);

            return customerEventScreeningTestsEntity;
        }
    }
}