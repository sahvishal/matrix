using System.Collections.Generic;
using System.Linq;
using Falcon.App.Core.Medical.Domain;
using Falcon.App.Core.Medical.Enum;
using Falcon.Data.EntityClasses;

namespace Falcon.App.Infrastructure.Factories.Screening
{
    public class HemaglobinTestResultFactory : TestResultFactory
    {

        public override TestResult CreateActualTestResult(CustomerEventScreeningTestsEntity customerEventScreeningTestEntity)
        {
            var testResult = new HemaglobinA1CTestResult(customerEventScreeningTestEntity.CustomerEventScreeningTestId);
            var customerEventReadingEntities = customerEventScreeningTestEntity.CustomerEventReading.ToList();

            testResult.Hba1c = CreateResultReadingforInputValues((int)ReadingLabels.Hba1c, customerEventReadingEntities);
            return testResult;
        }

        public override CustomerEventScreeningTestsEntity CreateActualTestResultEntity(TestResult testResult, List<Core.OrderedPair<int, int>> testReadingReadingPairs)
        {
            var a1CtestResult = testResult as HemaglobinA1CTestResult;

            var customerEventScreeningTestsEntity = new CustomerEventScreeningTestsEntity(testResult.Id) { TestId = (int)TestType.A1C };
            var customerEventReadingEntities = new List<CustomerEventReadingEntity>();

            if (a1CtestResult.Hba1c != null)
                customerEventReadingEntities.Add(CreateEventReadingEntity(a1CtestResult.Hba1c, (int)ReadingLabels.Hba1c, testReadingReadingPairs));

            customerEventScreeningTestsEntity.CustomerEventReading.AddRange(customerEventReadingEntities);
            return customerEventScreeningTestsEntity;
        }
    }
}