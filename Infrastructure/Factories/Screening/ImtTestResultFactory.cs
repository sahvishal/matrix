using System;
using System.Collections.Generic;
using System.Linq;
using Falcon.App.Core.Application.Domain;
using Falcon.App.Core.Medical.Domain;
using Falcon.App.Core.Medical.Enum;
using Falcon.App.Infrastructure.Service;
using Falcon.Data.EntityClasses;

namespace Falcon.App.Infrastructure.Factories.Screening
{
    public class ImtTestResultFactory : TestResultFactory
    {
        public override TestResult CreateActualTestResult(CustomerEventScreeningTestsEntity customerEventScreeningTestEntity)
        {
            var customerEventReadingEntities = customerEventScreeningTestEntity.CustomerEventReading.ToList();
            var testResult = new ImtTestResult(customerEventScreeningTestEntity.CustomerEventScreeningTestId);

            var customerEventTestStandardFindingEntities = customerEventScreeningTestEntity.CustomerEventTestStandardFinding.ToList();
            var standardFindingTestReadingEntities = customerEventScreeningTestEntity.StandardFindingTestReadingCollectionViaCustomerEventTestStandardFinding.ToList();

            if (customerEventTestStandardFindingEntities.Count() > 0)
            {
                var testResultService = new TestResultService();
                var standardFindings = testResultService.GetAllStandardFindings<int?>((int)TestType.IMT);

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

            testResult.VascularAge = CreateResultReadingforInt((int)ReadingLabels.VascularAge, customerEventReadingEntities);
            testResult.QimtLeft = CreateResultReadingforInt((int)ReadingLabels.QimtLeft, customerEventReadingEntities);
            testResult.QimtRight = CreateResultReadingforInt((int)ReadingLabels.QimtRight, customerEventReadingEntities);
            testResult.ExpectedQimt = CreateResultReadingforInt((int)ReadingLabels.ExpectedQimt, customerEventReadingEntities);

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

                testResult.ResultMedia = resultMedia;
            }
            return testResult;

        }

        public override CustomerEventScreeningTestsEntity CreateActualTestResultEntity(TestResult testResult, List<Core.OrderedPair<int, int>> testReadingReadingPairs)
        {
            var imtTestResult = testResult as ImtTestResult;
            var customerEventScreeningTestsEntity = new CustomerEventScreeningTestsEntity(testResult.Id) { TestId = (int)TestType.IMT };
            var customerEventReadingEntities = new List<CustomerEventReadingEntity>();

            if (imtTestResult.VascularAge != null)
                customerEventReadingEntities.Add(CreateEventReadingEntity(imtTestResult.VascularAge, (int)ReadingLabels.VascularAge, testReadingReadingPairs));

            if (imtTestResult.QimtLeft != null)
                customerEventReadingEntities.Add(CreateEventReadingEntity(imtTestResult.QimtLeft, (int)ReadingLabels.QimtLeft, testReadingReadingPairs));

            if (imtTestResult.QimtRight != null)
                customerEventReadingEntities.Add(CreateEventReadingEntity(imtTestResult.QimtRight, (int)ReadingLabels.QimtRight, testReadingReadingPairs));

            if (imtTestResult.ExpectedQimt != null)
                customerEventReadingEntities.Add(CreateEventReadingEntity(imtTestResult.ExpectedQimt, (int)ReadingLabels.ExpectedQimt, testReadingReadingPairs));

            testResult.ResultInterpretation = null;
            if (imtTestResult.Finding != null)
            {
                var customerEventTestStandardFindingEntity = new CustomerEventTestStandardFindingEntity()
                {
                    StandardFindingTestReadingId =
                        (int?)new TestResultService().GetStandardFindingTestReadingIdForStandardFinding
                            ((int)TestType.IMT, null, Convert.ToInt64(imtTestResult.Finding.Id)),

                    CustomerEventTestStandardFindingId = imtTestResult.Finding.CustomerEventStandardFindingId,
                    CustomerEventScreeningTestId = testResult.Id
                };

                var finding = GetSelectedStandardFinding((int)TestType.IMT, null, imtTestResult.Finding.Id);

                if (testResult.ResultStatus.StateNumber == (int)TestResultStateNumber.Evaluated || testResult.ResultStatus.StateNumber == (int)NewTestResultStateNumber.Evaluated)
                {
                    testResult.ResultInterpretation = finding.ResultInterpretation;
                    testResult.PathwayRecommendation = finding.PathwayRecommendation;
                }

                customerEventScreeningTestsEntity.CustomerEventTestStandardFinding.Add(customerEventTestStandardFindingEntity);
            }

            customerEventScreeningTestsEntity.CustomerEventReading.AddRange(customerEventReadingEntities);
            return customerEventScreeningTestsEntity;
        }
    }
}