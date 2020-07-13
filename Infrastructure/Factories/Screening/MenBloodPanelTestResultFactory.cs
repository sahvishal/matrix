using System.Collections.Generic;
using System.Linq;
using Falcon.App.Core.Medical.Domain;
using Falcon.App.Core.Medical.Enum;
using Falcon.Data.EntityClasses;

namespace Falcon.App.Infrastructure.Factories.Screening
{
    public class MenBloodPanelTestResultFactory : TestResultFactory
    {
        public override TestResult CreateActualTestResult(CustomerEventScreeningTestsEntity customerEventScreeningTestEntity)
        {
            var testResult = new MenBloodPanelTestResult(customerEventScreeningTestEntity.CustomerEventScreeningTestId);
            var customerEventReadingEntities = customerEventScreeningTestEntity.CustomerEventReading.ToList();

            testResult.PSASCR = CreateResultReadingforInputValues((int)ReadingLabels.PSASCR, customerEventReadingEntities);
            testResult.LCRP = CreateResultReadingforInputValues((int)ReadingLabels.LCRP, customerEventReadingEntities);
            testResult.TESTSCRE = CreateResultReadingforInputValues((int)ReadingLabels.TESTSCRE, customerEventReadingEntities);

            testResult.TechnicallyLimitedbutReadable = CreateResultReading((int)ReadingLabels.TechnicallyLimitedbutReadable, customerEventReadingEntities);
            testResult.RepeatStudy = CreateResultReading((int)ReadingLabels.RepeatStudy, customerEventReadingEntities);

            return testResult;
        }

        public override CustomerEventScreeningTestsEntity CreateActualTestResultEntity(TestResult testResult, List<Core.OrderedPair<int, int>> testReadingReadingPairs)
        {
            var menBloodPanelTestResult = testResult as MenBloodPanelTestResult;

            var customerEventScreeningTestsEntity = new CustomerEventScreeningTestsEntity(testResult.Id) { TestId = (int)TestType.MenBloodPanel };
            var customerEventReadingEntities = new List<CustomerEventReadingEntity>();

            if (menBloodPanelTestResult.PSASCR != null)
                customerEventReadingEntities.Add(CreateEventReadingEntity(menBloodPanelTestResult.PSASCR, (int)ReadingLabels.PSASCR, testReadingReadingPairs));

            if (menBloodPanelTestResult.LCRP != null)
                customerEventReadingEntities.Add(CreateEventReadingEntity(menBloodPanelTestResult.LCRP, (int)ReadingLabels.LCRP, testReadingReadingPairs));

            if (menBloodPanelTestResult.TESTSCRE != null)
                customerEventReadingEntities.Add(CreateEventReadingEntity(menBloodPanelTestResult.TESTSCRE, (int)ReadingLabels.TESTSCRE, testReadingReadingPairs));

            if (menBloodPanelTestResult.TechnicallyLimitedbutReadable != null)
            {
                var customerEventReading = CreateEventReadingEntity(menBloodPanelTestResult.TechnicallyLimitedbutReadable, (int)ReadingLabels.TechnicallyLimitedbutReadable, testReadingReadingPairs);

                customerEventReadingEntities.Add(customerEventReading);
            }

            if (menBloodPanelTestResult.RepeatStudy != null)
            {
                var customerEventReading = CreateEventReadingEntity(menBloodPanelTestResult.RepeatStudy, (int)ReadingLabels.RepeatStudy, testReadingReadingPairs);

                customerEventReadingEntities.Add(customerEventReading);
            }

            customerEventScreeningTestsEntity.CustomerEventReading.AddRange(customerEventReadingEntities);

            return customerEventScreeningTestsEntity;
        }
    }
}