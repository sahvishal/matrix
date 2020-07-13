using System.Collections.Generic;
using System.Linq;
using Falcon.App.Core.Medical.Domain;
using Falcon.App.Core.Medical.Enum;
using Falcon.Data.EntityClasses;

namespace Falcon.App.Infrastructure.Factories.Screening
{
    public class CrpTestResultFactory : TestResultFactory
    {
        public override TestResult CreateActualTestResult(CustomerEventScreeningTestsEntity customerEventScreeningTestEntity)
        {
            var testResult = new CrpTestResult(customerEventScreeningTestEntity.CustomerEventScreeningTestId);
            var customerEventReadingEntities = customerEventScreeningTestEntity.CustomerEventReading.ToList();

            testResult.LCRP = CreateResultReadingforInputValues((int)ReadingLabels.LCRP, customerEventReadingEntities);
            return testResult;
        }

        public override CustomerEventScreeningTestsEntity CreateActualTestResultEntity(TestResult testResult, List<Core.OrderedPair<int, int>> testReadingReadingPairs)
        {
            var crpTestResult = testResult as CrpTestResult;

            var customerEventScreeningTestsEntity = new CustomerEventScreeningTestsEntity(testResult.Id) { TestId = (int)TestType.Crp };
            var customerEventReadingEntities = new List<CustomerEventReadingEntity>();

            if (crpTestResult.LCRP != null)
                customerEventReadingEntities.Add(CreateEventReadingEntity(crpTestResult.LCRP, (int)ReadingLabels.LCRP, testReadingReadingPairs));

            customerEventScreeningTestsEntity.CustomerEventReading.AddRange(customerEventReadingEntities);
            return customerEventScreeningTestsEntity;
        }
    }
}