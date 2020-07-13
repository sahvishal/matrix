using System.Collections.Generic;
using System.Linq;
using Falcon.App.Core.Medical.Domain;
using Falcon.App.Core.Medical.Enum;
using Falcon.Data.EntityClasses;

namespace Falcon.App.Infrastructure.Factories.Screening
{
    public class ThyroidTestResultFactory : TestResultFactory
    {

        public override TestResult CreateActualTestResult(CustomerEventScreeningTestsEntity customerEventScreeningTestEntity)
        {
            var testResult = new ThyroidTestResult(customerEventScreeningTestEntity.CustomerEventScreeningTestId);
            var customerEventReadingEntities = customerEventScreeningTestEntity.CustomerEventReading.ToList();

            testResult.TSHSCR = CreateResultReadingforInputValues((int)ReadingLabels.TSHSCR, customerEventReadingEntities);
            
            return testResult;
        }

        public override CustomerEventScreeningTestsEntity CreateActualTestResultEntity(TestResult testResult, List<Core.OrderedPair<int, int>> testReadingReadingPairs)
        {
            var thyroidTestResult = testResult as ThyroidTestResult;
            var customerEventScreeningTestsEntity = new CustomerEventScreeningTestsEntity(testResult.Id) { TestId = (int)TestType.Thyroid };
            var customerEventReadingEntities = new List<CustomerEventReadingEntity>();

            if (thyroidTestResult.TSHSCR != null)
                customerEventReadingEntities.Add(CreateEventReadingEntity(thyroidTestResult.TSHSCR, (int)ReadingLabels.TSHSCR, testReadingReadingPairs));

            customerEventScreeningTestsEntity.CustomerEventReading.AddRange(customerEventReadingEntities);
            return customerEventScreeningTestsEntity;
        }

    }
}