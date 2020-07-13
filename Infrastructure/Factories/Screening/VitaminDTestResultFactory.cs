using System.Collections.Generic;
using System.Linq;
using Falcon.App.Core.Medical.Domain;
using Falcon.App.Core.Medical.Enum;
using Falcon.Data.EntityClasses;

namespace Falcon.App.Infrastructure.Factories.Screening
{
    public class VitaminDTestResultFactory : TestResultFactory
    {
        public override TestResult CreateActualTestResult(CustomerEventScreeningTestsEntity customerEventScreeningTestEntity)
        {
            var testResult = new VitaminDTestResult(customerEventScreeningTestEntity.CustomerEventScreeningTestId);
            var customerEventReadingEntities = customerEventScreeningTestEntity.CustomerEventReading.ToList();
            
            testResult.VitD = CreateResultReadingforInputValues((int)ReadingLabels.VitD, customerEventReadingEntities);

            testResult.TechnicallyLimitedbutReadable = CreateResultReading((int)ReadingLabels.TechnicallyLimitedbutReadable, customerEventReadingEntities);
            testResult.RepeatStudy = CreateResultReading((int)ReadingLabels.RepeatStudy, customerEventReadingEntities);

            return testResult;
        }

        public override CustomerEventScreeningTestsEntity CreateActualTestResultEntity(TestResult testResult, List<Core.OrderedPair<int, int>> testReadingReadingPairs)
        {
            var vitaminDTestResult = testResult as VitaminDTestResult;

            var customerEventScreeningTestsEntity = new CustomerEventScreeningTestsEntity(testResult.Id) { TestId = (int)TestType.VitaminD };
            var customerEventReadingEntities = new List<CustomerEventReadingEntity>();
            
            if (vitaminDTestResult.VitD != null)
                customerEventReadingEntities.Add(CreateEventReadingEntity(vitaminDTestResult.VitD, (int)ReadingLabels.VitD, testReadingReadingPairs));

            if (vitaminDTestResult.TechnicallyLimitedbutReadable != null)
            {
                var customerEventReading = CreateEventReadingEntity(vitaminDTestResult.TechnicallyLimitedbutReadable, (int)ReadingLabels.TechnicallyLimitedbutReadable, testReadingReadingPairs);

                customerEventReadingEntities.Add(customerEventReading);
            }

            if (vitaminDTestResult.RepeatStudy != null)
            {
                var customerEventReading = CreateEventReadingEntity(vitaminDTestResult.RepeatStudy, (int)ReadingLabels.RepeatStudy, testReadingReadingPairs);

                customerEventReadingEntities.Add(customerEventReading);
            }

            customerEventScreeningTestsEntity.CustomerEventReading.AddRange(customerEventReadingEntities);

            return customerEventScreeningTestsEntity;
        }
    }
}