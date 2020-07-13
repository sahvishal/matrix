using System;
using System.Collections.Generic;
using System.Linq;
using Falcon.App.Core;
using Falcon.App.Core.Application.Domain;
using Falcon.App.Core.Medical.Domain;
using Falcon.App.Core.Medical.Enum;
using Falcon.App.Infrastructure.Service;
using Falcon.Data.EntityClasses;

namespace Falcon.App.Infrastructure.Factories.Screening
{
    public class MedicareTestResultFactory : TestResultFactory
    {
        public override TestResult CreateActualTestResult(CustomerEventScreeningTestsEntity customerEventScreeningTestEntity)
        {
            var customerEventReadingEntities = customerEventScreeningTestEntity.CustomerEventReading.ToList();

            var testResult = new MedicareTestResult(customerEventScreeningTestEntity.CustomerEventScreeningTestId);

            var customerEventTestStandardFindingEntities = customerEventScreeningTestEntity.CustomerEventTestStandardFinding.ToList();
            var standardFindingTestReadingEntities = customerEventScreeningTestEntity.StandardFindingTestReadingCollectionViaCustomerEventTestStandardFinding.ToList();

            if (customerEventTestStandardFindingEntities.Count() > 0)
            {
                var testResultService = new TestResultService();
                var standardFindings = testResultService.GetAllStandardFindings<int?>((int)TestType.Medicare);

                customerEventTestStandardFindingEntities.ForEach(customerEventTestStandardFindingEntity =>
                {
                    var standardFindingTestReadingEntity = standardFindingTestReadingEntities.Find(entity => entity.StandardFindingTestReadingId == customerEventTestStandardFindingEntity.StandardFindingTestReadingId);
                    if (standardFindingTestReadingEntity == null) return;

                    var finding = CreateFindingObject(customerEventTestStandardFindingEntity, standardFindings, standardFindingTestReadingEntity, null);
                    if (finding != null)
                    {
                        testResult.Finding = finding; return;
                    }
                });
            }


            var testMediaCollection = customerEventScreeningTestEntity.TestMedia.ToList();
            var fileEntityCollection = customerEventScreeningTestEntity.FileCollectionViaTestMedia.ToList();

            if (testMediaCollection.Count > 0)
            {
                var resultMedia = new List<ResultMedia>();
                testMediaCollection.ForEach(testMedia => resultMedia.Add(new ResultMedia(testMedia.MediaId)
                {
                    File = GetFileObjectfromEntity(testMedia.FileId, fileEntityCollection),
                    Thumbnail = testMedia.ThumbnailFileId != null ? new File(testMedia.ThumbnailFileId.Value) : null,
                    ReadingSource = testMedia.IsManual ? ReadingSource.Manual : ReadingSource.Automatic
                }));

                testResult.ResultImages = resultMedia;
            }

            testResult.TechnicallyLimitedbutReadable = CreateResultReading((int)ReadingLabels.TechnicallyLimitedbutReadable, customerEventReadingEntities);
            testResult.RepeatStudy = CreateResultReading((int)ReadingLabels.RepeatStudy, customerEventReadingEntities);

            return testResult;
        }

        public override CustomerEventScreeningTestsEntity CreateActualTestResultEntity(TestResult testResult, List<OrderedPair<int, int>> testReadingReadingPairs)
        {
            var medicareTestResult = testResult as MedicareTestResult;
            var customerEventScreeningTestsEntity = new CustomerEventScreeningTestsEntity(testResult.Id) { TestId = (int)TestType.Medicare };
            var customerEventReadingEntities = new List<CustomerEventReadingEntity>();

            testResult.ResultInterpretation = null;
            if (medicareTestResult.Finding != null)
            {
                var customerEventTestStandardFindingEntity = new CustomerEventTestStandardFindingEntity
                {
                    StandardFindingTestReadingId =
                        (int?)new TestResultService().GetStandardFindingTestReadingIdForStandardFinding
                                  ((int)TestType.Medicare, null, Convert.ToInt64(medicareTestResult.Finding.Id)),

                    CustomerEventTestStandardFindingId = medicareTestResult.Finding.CustomerEventStandardFindingId,
                    CustomerEventScreeningTestId = testResult.Id
                };

                var finding = GetSelectedStandardFinding((int)TestType.Medicare, null, medicareTestResult.Finding.Id);

                if (testResult.ResultStatus.StateNumber == (int)TestResultStateNumber.Evaluated || testResult.ResultStatus.StateNumber == (int)NewTestResultStateNumber.Evaluated)
                {
                    testResult.ResultInterpretation = finding.ResultInterpretation;
                    testResult.PathwayRecommendation = finding.PathwayRecommendation;
                }

                customerEventScreeningTestsEntity.CustomerEventTestStandardFinding.Add(customerEventTestStandardFindingEntity);
            }

            if (medicareTestResult.TechnicallyLimitedbutReadable != null)
            {
                var customerEventReadingEntity = CreateEventReadingEntity(medicareTestResult.TechnicallyLimitedbutReadable, (int)ReadingLabels.TechnicallyLimitedbutReadable, testReadingReadingPairs);
                if (customerEventReadingEntity != null) customerEventReadingEntities.Add(customerEventReadingEntity);
            }

            if (medicareTestResult.RepeatStudy != null)
            {
                var customerEventReadingEntity = CreateEventReadingEntity(medicareTestResult.RepeatStudy, (int)ReadingLabels.RepeatStudy, testReadingReadingPairs);
                if (customerEventReadingEntity != null) customerEventReadingEntities.Add(customerEventReadingEntity);
            }

            if (customerEventReadingEntities.Count > 0)
                customerEventScreeningTestsEntity.CustomerEventReading.AddRange(customerEventReadingEntities);

            return customerEventScreeningTestsEntity;
        }
    }
}
