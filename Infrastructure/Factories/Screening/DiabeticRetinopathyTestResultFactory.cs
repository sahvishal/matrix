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
    public class DiabeticRetinopathyTestResultFactory : TestResultFactory
    {
        public override TestResult CreateActualTestResult(CustomerEventScreeningTestsEntity customerEventScreeningTestEntity)
        {
            var customerEventReadingEntities = customerEventScreeningTestEntity.CustomerEventReading.ToList();

            var testResult = new DiabeticRetinopathyTestResult(customerEventScreeningTestEntity.CustomerEventScreeningTestId);

            testResult.SuspectedVeinOcclusion = CreateResultReading((int) ReadingLabels.DiabeticRetinopathySuspectedVeinOcclusion,customerEventReadingEntities);
            testResult.SuspectedWetAmd = CreateResultReading((int)ReadingLabels.DiabeticRetinopathySuspectedWetAmd, customerEventReadingEntities);
            testResult.SuspectedHtnRetinopathy = CreateResultReading((int)ReadingLabels.DiabeticRetinopathySuspectedHtnRetinopathy, customerEventReadingEntities);
            testResult.SuspectedEpiretinalMembrane = CreateResultReading((int)ReadingLabels.DiabeticRetinopathySuspectedEpiretinalMembrane, customerEventReadingEntities);
            testResult.SuspectedMacularHole = CreateResultReading((int)ReadingLabels.DiabeticRetinopathySuspectedMacularHole, customerEventReadingEntities);
            testResult.SuspectedCataract = CreateResultReading((int)ReadingLabels.DiabeticRetinopathySuspectedCataract, customerEventReadingEntities);
            testResult.SuspectedOtherDisease = CreateResultReading((int)ReadingLabels.DiabeticRetinopathySuspectedOtherDisease, customerEventReadingEntities);
            testResult.SuspectedGlaucoma = CreateResultReading((int)ReadingLabels.DiabeticRetinopathySuspectedGlaucoma, customerEventReadingEntities);
            testResult.SuspectedDryAmd = CreateResultReading((int)ReadingLabels.DiabeticRetinopathySuspectedDryAmd, customerEventReadingEntities);

            testResult.DiabeticRetinopathyHighestLevelOfSpecificity = CreateResultReading((int)ReadingLabels.DiabeticRetinopathyHighestLevelOfSpecificity, customerEventReadingEntities);
            testResult.MacularEdemaHighestLevelOfSpecificity = CreateResultReading((int)ReadingLabels.MacularEdemaHighestLevelOfSpecificity, customerEventReadingEntities);

            var customerEventTestStandardFindingEntities = customerEventScreeningTestEntity.CustomerEventTestStandardFinding.ToList();
            var standardFindingTestReadingEntities = customerEventScreeningTestEntity.StandardFindingTestReadingCollectionViaCustomerEventTestStandardFinding.ToList();
            

            if (customerEventTestStandardFindingEntities.Count() > 0)
            {
                var testResultService = new TestResultService();
                var standardFindings = testResultService.GetAllStandardFindings<int?>((int)TestType.DiabeticRetinopathy);
                var diabeticRetinopathyLevelFindings = testResultService.GetAllStandardFindings<int?>((int)TestType.DiabeticRetinopathy, (int)ReadingLabels.DiabeticRetinopathyHighestLevelOfSpecificity);
                var macularEdemLevel = testResultService.GetAllStandardFindings<int?>((int)TestType.DiabeticRetinopathy, (int)ReadingLabels.MacularEdemaHighestLevelOfSpecificity);

                customerEventTestStandardFindingEntities.ForEach(customerEventTestStandardFindingEntity =>
                {
                    var standardFindingTestReadingEntity = standardFindingTestReadingEntities.Find(entity => entity.StandardFindingTestReadingId == customerEventTestStandardFindingEntity.StandardFindingTestReadingId);
                    if (standardFindingTestReadingEntity == null) return;

                    var finding = CreateFindingObject(customerEventTestStandardFindingEntity, standardFindings, standardFindingTestReadingEntity, null);
                    if (finding != null)
                    {
                        testResult.Finding = finding; return;
                    }

                    finding = CreateFindingObject(customerEventTestStandardFindingEntity, diabeticRetinopathyLevelFindings, standardFindingTestReadingEntity, (int?)ReadingLabels.DiabeticRetinopathyHighestLevelOfSpecificity);
                    if (finding != null)
                    {
                        testResult.DiabeticRetinopathyLevel = finding; return;
                    }

                    finding = CreateFindingObject(customerEventTestStandardFindingEntity, macularEdemLevel, standardFindingTestReadingEntity, (int?)ReadingLabels.MacularEdemaHighestLevelOfSpecificity);
                    if (finding != null)
                    {
                        testResult.MacularEdemaLevel = finding; return;
                    }
                });
            }

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


            testResult.TechnicallyLimitedbutReadable = CreateResultReading((int)ReadingLabels.TechnicallyLimitedbutReadable, customerEventReadingEntities);
            testResult.RepeatStudy = CreateResultReading((int)ReadingLabels.RepeatStudy, customerEventReadingEntities);

            return testResult;
        }

        public override CustomerEventScreeningTestsEntity CreateActualTestResultEntity(TestResult testResult, List<OrderedPair<int, int>> testReadingReadingPairs)
        {
            var diabeticRetinopathyTestResult = testResult as DiabeticRetinopathyTestResult;
            var customerEventScreeningTestsEntity = new CustomerEventScreeningTestsEntity(testResult.Id) { TestId = (int)TestType.DiabeticRetinopathy };
            var customerEventReadingEntities = new List<CustomerEventReadingEntity>();

            if (diabeticRetinopathyTestResult.SuspectedVeinOcclusion != null)
                customerEventReadingEntities.Add(CreateEventReadingEntity(diabeticRetinopathyTestResult.SuspectedVeinOcclusion, (int)ReadingLabels.DiabeticRetinopathySuspectedVeinOcclusion, testReadingReadingPairs));

            if (diabeticRetinopathyTestResult.SuspectedWetAmd != null)
                customerEventReadingEntities.Add(CreateEventReadingEntity(diabeticRetinopathyTestResult.SuspectedWetAmd, (int)ReadingLabels.DiabeticRetinopathySuspectedWetAmd, testReadingReadingPairs));

            if (diabeticRetinopathyTestResult.SuspectedHtnRetinopathy != null)
                customerEventReadingEntities.Add(CreateEventReadingEntity(diabeticRetinopathyTestResult.SuspectedHtnRetinopathy, (int)ReadingLabels.DiabeticRetinopathySuspectedHtnRetinopathy, testReadingReadingPairs));

            if (diabeticRetinopathyTestResult.SuspectedEpiretinalMembrane != null)
                customerEventReadingEntities.Add(CreateEventReadingEntity(diabeticRetinopathyTestResult.SuspectedEpiretinalMembrane, (int)ReadingLabels.DiabeticRetinopathySuspectedEpiretinalMembrane, testReadingReadingPairs));

            if (diabeticRetinopathyTestResult.SuspectedMacularHole != null)
                customerEventReadingEntities.Add(CreateEventReadingEntity(diabeticRetinopathyTestResult.SuspectedMacularHole, (int)ReadingLabels.DiabeticRetinopathySuspectedMacularHole, testReadingReadingPairs));

            if (diabeticRetinopathyTestResult.SuspectedCataract != null)
                customerEventReadingEntities.Add(CreateEventReadingEntity(diabeticRetinopathyTestResult.SuspectedCataract, (int)ReadingLabels.DiabeticRetinopathySuspectedCataract, testReadingReadingPairs));

            if (diabeticRetinopathyTestResult.SuspectedOtherDisease != null)
                customerEventReadingEntities.Add(CreateEventReadingEntity(diabeticRetinopathyTestResult.SuspectedOtherDisease, (int)ReadingLabels.DiabeticRetinopathySuspectedOtherDisease, testReadingReadingPairs));

            if (diabeticRetinopathyTestResult.SuspectedGlaucoma != null)
                customerEventReadingEntities.Add(CreateEventReadingEntity(diabeticRetinopathyTestResult.SuspectedGlaucoma, (int)ReadingLabels.DiabeticRetinopathySuspectedGlaucoma, testReadingReadingPairs));

            if (diabeticRetinopathyTestResult.SuspectedDryAmd != null)
                customerEventReadingEntities.Add(CreateEventReadingEntity(diabeticRetinopathyTestResult.SuspectedDryAmd, (int)ReadingLabels.DiabeticRetinopathySuspectedDryAmd, testReadingReadingPairs));
            
            if (diabeticRetinopathyTestResult.DiabeticRetinopathyHighestLevelOfSpecificity != null)
                customerEventReadingEntities.Add(CreateEventReadingEntity(diabeticRetinopathyTestResult.DiabeticRetinopathyHighestLevelOfSpecificity, (int)ReadingLabels.DiabeticRetinopathyHighestLevelOfSpecificity, testReadingReadingPairs));


            if (diabeticRetinopathyTestResult.MacularEdemaHighestLevelOfSpecificity != null)
                customerEventReadingEntities.Add(CreateEventReadingEntity(diabeticRetinopathyTestResult.MacularEdemaHighestLevelOfSpecificity, (int)ReadingLabels.MacularEdemaHighestLevelOfSpecificity, testReadingReadingPairs));

         
            testResult.ResultInterpretation = null;
            if (diabeticRetinopathyTestResult.Finding != null)
            {
                var customerEventTestStandardFindingEntity = new CustomerEventTestStandardFindingEntity
                {
                    StandardFindingTestReadingId = (int?)new TestResultService().GetStandardFindingTestReadingIdForStandardFinding((int)TestType.DiabeticRetinopathy, null, Convert.ToInt64(diabeticRetinopathyTestResult.Finding.Id)),

                    CustomerEventTestStandardFindingId = diabeticRetinopathyTestResult.Finding.CustomerEventStandardFindingId,
                    CustomerEventScreeningTestId = testResult.Id
                };

                var finding = GetSelectedStandardFinding((int)TestType.DiabeticRetinopathy, null, diabeticRetinopathyTestResult.Finding.Id);

                if (testResult.ResultStatus.StateNumber == (int)TestResultStateNumber.Evaluated || testResult.ResultStatus.StateNumber == (int)NewTestResultStateNumber.Evaluated)
                {
                    testResult.ResultInterpretation = finding.ResultInterpretation;
                    testResult.PathwayRecommendation = finding.PathwayRecommendation;
                }

                customerEventScreeningTestsEntity.CustomerEventTestStandardFinding.Add(customerEventTestStandardFindingEntity);
            }

            if (diabeticRetinopathyTestResult.DiabeticRetinopathyLevel != null)
            {
                var customerEventTestStandardFindingEntity = new CustomerEventTestStandardFindingEntity()
                {
                    StandardFindingTestReadingId =
                        (int?)new TestResultService().GetStandardFindingTestReadingIdForStandardFinding
                            ((int)TestType.DiabeticRetinopathy, (int)ReadingLabels.DiabeticRetinopathyHighestLevelOfSpecificity, Convert.ToInt64(diabeticRetinopathyTestResult.DiabeticRetinopathyLevel.Id)),
                    CustomerEventTestStandardFindingId = diabeticRetinopathyTestResult.DiabeticRetinopathyLevel.CustomerEventStandardFindingId,
                    CustomerEventScreeningTestId = testResult.Id
                };
                customerEventScreeningTestsEntity.CustomerEventTestStandardFinding.Add(customerEventTestStandardFindingEntity);
            }

            if (diabeticRetinopathyTestResult.MacularEdemaLevel != null)
            {
                var customerEventTestStandardFindingEntity = new CustomerEventTestStandardFindingEntity()
                {
                    StandardFindingTestReadingId =
                        (int?)new TestResultService().GetStandardFindingTestReadingIdForStandardFinding
                            ((int)TestType.DiabeticRetinopathy, (int)ReadingLabels.MacularEdemaHighestLevelOfSpecificity, Convert.ToInt64(diabeticRetinopathyTestResult.MacularEdemaLevel.Id)),
                    CustomerEventTestStandardFindingId = diabeticRetinopathyTestResult.MacularEdemaLevel.CustomerEventStandardFindingId,
                    CustomerEventScreeningTestId = testResult.Id
                };
                customerEventScreeningTestsEntity.CustomerEventTestStandardFinding.Add(customerEventTestStandardFindingEntity);
            }

            if (diabeticRetinopathyTestResult.TechnicallyLimitedbutReadable != null)
            {
                var customerEventReadingEntity = CreateEventReadingEntity(diabeticRetinopathyTestResult.TechnicallyLimitedbutReadable, (int)ReadingLabels.TechnicallyLimitedbutReadable, testReadingReadingPairs);
                if (customerEventReadingEntity != null) customerEventReadingEntities.Add(customerEventReadingEntity);
            }

            if (diabeticRetinopathyTestResult.RepeatStudy != null)
            {
                var customerEventReadingEntity = CreateEventReadingEntity(diabeticRetinopathyTestResult.RepeatStudy, (int)ReadingLabels.RepeatStudy, testReadingReadingPairs);
                if (customerEventReadingEntity != null) customerEventReadingEntities.Add(customerEventReadingEntity);
            }

            if (customerEventReadingEntities.Count > 0)
                customerEventScreeningTestsEntity.CustomerEventReading.AddRange(customerEventReadingEntities);

            return customerEventScreeningTestsEntity;
        }
    }
}