using System;
using System.Collections.Generic;
using System.Linq;
using Falcon.App.Core;
using Falcon.App.Core.Medical.Domain;
using Falcon.App.Core.Medical.Enum;
using Falcon.App.Infrastructure.Service;
using Falcon.Data.EntityClasses;
using Falcon.App.Core.Application.Domain;

namespace Falcon.App.Infrastructure.Factories.Screening
{
    public class DpnTestResultFactory : TestResultFactory
    {
        public override TestResult CreateActualTestResult(CustomerEventScreeningTestsEntity customerEventScreeningTestEntity)
        {
            var customerEventReadingEntities = customerEventScreeningTestEntity.CustomerEventReading.ToList();

            var testResult = new DpnTestResult(customerEventScreeningTestEntity.CustomerEventScreeningTestId);

            if (customerEventScreeningTestEntity.TestMedia != null && customerEventScreeningTestEntity.TestMedia.Count > 0)
            {
                var fileEntityCollection = customerEventScreeningTestEntity.FileCollectionViaTestMedia.ToList();
                var testMediaEntity = customerEventScreeningTestEntity.TestMedia.FirstOrDefault();

                testResult.ResultImage = new ResultMedia(testMediaEntity.MediaId)
                {
                    File = GetFileObjectfromEntity(testMediaEntity.FileId, fileEntityCollection),
                    Thumbnail = testMediaEntity.ThumbnailFileId != null ? new File(testMediaEntity.ThumbnailFileId.Value) : null,
                    ReadingSource = testMediaEntity.IsManual ? ReadingSource.Manual : ReadingSource.Automatic
                };
            }

            var customerEventTestStandardFindingEntities = customerEventScreeningTestEntity.CustomerEventTestStandardFinding.ToList();
            var standardFindingTestReadingEntities = customerEventScreeningTestEntity.StandardFindingTestReadingCollectionViaCustomerEventTestStandardFinding.ToList();

            if (customerEventTestStandardFindingEntities.Count() > 0)
            {
                var testResultService = new TestResultService();
                var standardFindings = testResultService.GetAllStandardFindings<int?>((int)TestType.DPN);

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

            testResult.Amplitude = CreateResultReadingforNullableDecimal((int)ReadingLabels.DpnAmplitude, customerEventReadingEntities);
            testResult.ConductionVelocity = CreateResultReadingforNullableDecimal((int)ReadingLabels.DpnConductionVelocity, customerEventReadingEntities);

            testResult.RightLeg = CreateResultReadingforNullableBool((int)ReadingLabels.DpnRightLeg, customerEventReadingEntities);
            testResult.LeftLeg = CreateResultReadingforNullableBool((int)ReadingLabels.DpnLeftLeg, customerEventReadingEntities);


            testResult.TechnicallyLimitedbutReadable = CreateResultReading((int)ReadingLabels.TechnicallyLimitedbutReadable, customerEventReadingEntities);
            testResult.RepeatStudy = CreateResultReading((int)ReadingLabels.RepeatStudy, customerEventReadingEntities);

            return testResult;
        }

        public override CustomerEventScreeningTestsEntity CreateActualTestResultEntity(TestResult testResult, List<OrderedPair<int, int>> testReadingReadingPairs)
        {
            var dpnTestResult = testResult as DpnTestResult;
            var customerEventScreeningTestsEntity = new CustomerEventScreeningTestsEntity(testResult.Id) { TestId = (int)TestType.DPN };
            var customerEventReadingEntities = new List<CustomerEventReadingEntity>();

            testResult.ResultInterpretation = null;
            if (dpnTestResult.Finding != null)
            {
                var customerEventTestStandardFindingEntity = new CustomerEventTestStandardFindingEntity
                {
                    StandardFindingTestReadingId = (int?)new TestResultService().GetStandardFindingTestReadingIdForStandardFinding((int)TestType.DPN, null, Convert.ToInt64(dpnTestResult.Finding.Id)),

                    CustomerEventTestStandardFindingId = dpnTestResult.Finding.CustomerEventStandardFindingId,
                    CustomerEventScreeningTestId = testResult.Id
                };

                var finding = GetSelectedStandardFinding((int)TestType.DPN, null, dpnTestResult.Finding.Id);

                if (testResult.ResultStatus.StateNumber == (int)TestResultStateNumber.Evaluated || testResult.ResultStatus.StateNumber == (int)NewTestResultStateNumber.Evaluated)
                {
                    testResult.ResultInterpretation = finding.ResultInterpretation;
                    testResult.PathwayRecommendation = finding.PathwayRecommendation;
                }

                customerEventScreeningTestsEntity.CustomerEventTestStandardFinding.Add(customerEventTestStandardFindingEntity);
            }

            if (dpnTestResult.Amplitude != null)
            {
                var customerEventReadingEntity = CreateEventReadingEntity(dpnTestResult.Amplitude, (int)ReadingLabels.DpnAmplitude, testReadingReadingPairs);
                if (customerEventReadingEntity != null) customerEventReadingEntities.Add(customerEventReadingEntity);
            }

            if (dpnTestResult.ConductionVelocity != null)
            {
                var customerEventReadingEntity = CreateEventReadingEntity(dpnTestResult.ConductionVelocity, (int)ReadingLabels.DpnConductionVelocity, testReadingReadingPairs);
                if (customerEventReadingEntity != null) customerEventReadingEntities.Add(customerEventReadingEntity);
            }

            if (dpnTestResult.RightLeg != null)
            {
                var customerEventReadingEntity = CreateEventReadingEntity(dpnTestResult.RightLeg, (int)ReadingLabels.DpnRightLeg, testReadingReadingPairs);
                if (customerEventReadingEntity != null) customerEventReadingEntities.Add(customerEventReadingEntity);
            }

            if (dpnTestResult.LeftLeg != null)
            {
                var customerEventReadingEntity = CreateEventReadingEntity(dpnTestResult.LeftLeg, (int)ReadingLabels.DpnLeftLeg, testReadingReadingPairs);
                if (customerEventReadingEntity != null) customerEventReadingEntities.Add(customerEventReadingEntity);
            }

            if (dpnTestResult.TechnicallyLimitedbutReadable != null)
            {
                var customerEventReadingEntity = CreateEventReadingEntity(dpnTestResult.TechnicallyLimitedbutReadable, (int)ReadingLabels.TechnicallyLimitedbutReadable, testReadingReadingPairs);
                if (customerEventReadingEntity != null) customerEventReadingEntities.Add(customerEventReadingEntity);
            }

            if (dpnTestResult.RepeatStudy != null)
            {
                var customerEventReadingEntity = CreateEventReadingEntity(dpnTestResult.RepeatStudy, (int)ReadingLabels.RepeatStudy, testReadingReadingPairs);
                if (customerEventReadingEntity != null) customerEventReadingEntities.Add(customerEventReadingEntity);
            }

            if (customerEventReadingEntities.Count > 0)
                customerEventScreeningTestsEntity.CustomerEventReading.AddRange(customerEventReadingEntities);

            return customerEventScreeningTestsEntity;
        }
    }
}