using System.Collections.Generic;
using System.Linq;
using Falcon.App.Core.Medical.Domain;
using Falcon.App.Core.Medical.Enum;
using Falcon.Data.EntityClasses;

namespace Falcon.App.Infrastructure.Factories.Screening
{
    public class DiabetesFootExamTestResultFactory : TestResultFactory
    {
        public override TestResult CreateActualTestResult(CustomerEventScreeningTestsEntity customerEventScreeningTestEntity)
        {
            var testResult = new DiabetesFootExamTestResult(customerEventScreeningTestEntity.CustomerEventScreeningTestId);
            var customerEventReadingEntities = customerEventScreeningTestEntity.CustomerEventReading.ToList();

            testResult.RightFootYes = CreateResultReadingforNullableBool((int)ReadingLabels.RightFootYes, customerEventReadingEntities);
            testResult.RightFootNo = CreateResultReadingforNullableBool((int)ReadingLabels.RightFootNo, customerEventReadingEntities);

            testResult.LeftFootYes = CreateResultReadingforNullableBool((int)ReadingLabels.LeftFootYes, customerEventReadingEntities);
            testResult.LeftFootNo = CreateResultReadingforNullableBool((int)ReadingLabels.LeftFootNo, customerEventReadingEntities);

            return testResult;
        }

        public override CustomerEventScreeningTestsEntity CreateActualTestResultEntity(TestResult testResult, List<Core.OrderedPair<int, int>> testReadingReadingPairs)
        {
            var diabetesFootExamTestResult = testResult as DiabetesFootExamTestResult;

            var customerEventScreeningTestsEntity = new CustomerEventScreeningTestsEntity(testResult.Id) { TestId = (int)TestType.DiabetesFootExam };
            var customerEventReadingEntities = new List<CustomerEventReadingEntity>();
            

            if (diabetesFootExamTestResult.RightFootYes != null)
                customerEventReadingEntities.Add(CreateEventReadingEntity(diabetesFootExamTestResult.RightFootYes, (int)ReadingLabels.RightFootYes, testReadingReadingPairs));
            if (diabetesFootExamTestResult.RightFootNo != null)
                customerEventReadingEntities.Add(CreateEventReadingEntity(diabetesFootExamTestResult.RightFootNo, (int)ReadingLabels.RightFootNo, testReadingReadingPairs));

            if (diabetesFootExamTestResult.LeftFootYes != null)
                customerEventReadingEntities.Add(CreateEventReadingEntity(diabetesFootExamTestResult.LeftFootYes, (int)ReadingLabels.LeftFootYes, testReadingReadingPairs));
            if (diabetesFootExamTestResult.LeftFootNo != null)
                customerEventReadingEntities.Add(CreateEventReadingEntity(diabetesFootExamTestResult.LeftFootNo, (int)ReadingLabels.LeftFootNo, testReadingReadingPairs));
            

            customerEventScreeningTestsEntity.CustomerEventReading.AddRange(customerEventReadingEntities);
            return customerEventScreeningTestsEntity;
        }
    }
}