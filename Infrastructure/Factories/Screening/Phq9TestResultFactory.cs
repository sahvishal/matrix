using System.Collections.Generic;
using System.Linq;
using Falcon.App.Core.Medical.Domain;
using Falcon.App.Core.Medical.Enum;
using Falcon.Data.EntityClasses;

namespace Falcon.App.Infrastructure.Factories.Screening
{
    public class Phq9TestResultFactory : TestResultFactory
    {
        public override TestResult CreateActualTestResult(CustomerEventScreeningTestsEntity customerEventScreeningTestEntity)
        {
            var testResult = new Phq9TestResult(customerEventScreeningTestEntity.CustomerEventScreeningTestId);
            var customerEventReadingEntities = customerEventScreeningTestEntity.CustomerEventReading.ToList();

            testResult.Phq9Score = CreateResultReadingforInputValues((int)ReadingLabels.Phq9Score, customerEventReadingEntities);

            testResult.TechnicallyLimitedbutReadable = CreateResultReading((int)ReadingLabels.TechnicallyLimitedbutReadable, customerEventReadingEntities);
            testResult.RepeatStudy = CreateResultReading((int)ReadingLabels.RepeatStudy, customerEventReadingEntities);

            return testResult;
        }

        public override CustomerEventScreeningTestsEntity CreateActualTestResultEntity(TestResult testResult, List<Core.OrderedPair<int, int>> testReadingReadingPairs)
        {
            var phq9TestResult = testResult as Phq9TestResult;

            var customerEventScreeningTestsEntity = new CustomerEventScreeningTestsEntity(testResult.Id) { TestId = (int)TestType.PHQ9 };
            var customerEventReadingEntities = new List<CustomerEventReadingEntity>();

            if (phq9TestResult.Phq9Score != null)
                customerEventReadingEntities.Add(CreateEventReadingEntity(phq9TestResult.Phq9Score, (int)ReadingLabels.Phq9Score, testReadingReadingPairs));

            if (phq9TestResult.TechnicallyLimitedbutReadable != null)
            {
                var customerEventReading = CreateEventReadingEntity(phq9TestResult.TechnicallyLimitedbutReadable, (int)ReadingLabels.TechnicallyLimitedbutReadable, testReadingReadingPairs);

                customerEventReadingEntities.Add(customerEventReading);
            }

            if (phq9TestResult.RepeatStudy != null)
            {
                var customerEventReading = CreateEventReadingEntity(phq9TestResult.RepeatStudy, (int)ReadingLabels.RepeatStudy, testReadingReadingPairs);

                customerEventReadingEntities.Add(customerEventReading);
            }

            customerEventScreeningTestsEntity.CustomerEventReading.AddRange(customerEventReadingEntities);

            return customerEventScreeningTestsEntity;
        }
    }
}