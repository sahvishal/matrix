using System.Collections.Generic;
using System.Linq;
using Falcon.App.Core.Medical.Domain;
using Falcon.App.Core.Medical.Enum;
using Falcon.Data.EntityClasses;

namespace Falcon.App.Infrastructure.Factories.Screening
{
    public class WomenBloodPanelTestResultFactory : TestResultFactory
    {
        public override TestResult CreateActualTestResult(CustomerEventScreeningTestsEntity customerEventScreeningTestEntity)
        {
            var testResult = new WomenBloodPanelTestResult(customerEventScreeningTestEntity.CustomerEventScreeningTestId);
            var customerEventReadingEntities = customerEventScreeningTestEntity.CustomerEventReading.ToList();

            testResult.LCRP = CreateResultReadingforInputValues((int)ReadingLabels.LCRP, customerEventReadingEntities);
            testResult.TSHSCR = CreateResultReadingforInputValues((int)ReadingLabels.TSHSCR, customerEventReadingEntities);
            testResult.VitD = CreateResultReadingforInputValues((int)ReadingLabels.VitD, customerEventReadingEntities);

            testResult.TechnicallyLimitedbutReadable = CreateResultReading((int)ReadingLabels.TechnicallyLimitedbutReadable, customerEventReadingEntities);
            testResult.RepeatStudy = CreateResultReading((int)ReadingLabels.RepeatStudy, customerEventReadingEntities);

            return testResult;
        }

        public override CustomerEventScreeningTestsEntity CreateActualTestResultEntity(TestResult testResult, List<Core.OrderedPair<int, int>> testReadingReadingPairs)
        {
            var womenBloodPanelTestResult = testResult as WomenBloodPanelTestResult;

            var customerEventScreeningTestsEntity = new CustomerEventScreeningTestsEntity(testResult.Id) { TestId = (int)TestType.WomenBloodPanel };
            var customerEventReadingEntities = new List<CustomerEventReadingEntity>();

            if (womenBloodPanelTestResult.LCRP != null)
                customerEventReadingEntities.Add(CreateEventReadingEntity(womenBloodPanelTestResult.LCRP, (int)ReadingLabels.LCRP, testReadingReadingPairs));

            if (womenBloodPanelTestResult.TSHSCR != null)
                customerEventReadingEntities.Add(CreateEventReadingEntity(womenBloodPanelTestResult.TSHSCR, (int)ReadingLabels.TSHSCR, testReadingReadingPairs));

            if (womenBloodPanelTestResult.VitD != null)
                customerEventReadingEntities.Add(CreateEventReadingEntity(womenBloodPanelTestResult.VitD, (int)ReadingLabels.VitD, testReadingReadingPairs));

            if (womenBloodPanelTestResult.TechnicallyLimitedbutReadable != null)
            {
                var customerEventReading = CreateEventReadingEntity(womenBloodPanelTestResult.TechnicallyLimitedbutReadable, (int)ReadingLabels.TechnicallyLimitedbutReadable, testReadingReadingPairs);

                customerEventReadingEntities.Add(customerEventReading);
            }

            if (womenBloodPanelTestResult.RepeatStudy != null)
            {
                var customerEventReading = CreateEventReadingEntity(womenBloodPanelTestResult.RepeatStudy, (int)ReadingLabels.RepeatStudy, testReadingReadingPairs);

                customerEventReadingEntities.Add(customerEventReading);
            }

            customerEventScreeningTestsEntity.CustomerEventReading.AddRange(customerEventReadingEntities);

            return customerEventScreeningTestsEntity;
        }
    }
}