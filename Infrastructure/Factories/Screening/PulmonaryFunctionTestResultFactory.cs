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
    public class PulmonaryFunctionTestResultFactory : TestResultFactory
    {
        public override TestResult CreateActualTestResult(CustomerEventScreeningTestsEntity customerEventScreeningTestEntity)
        {
            var testResult = new PulmonaryFunctionTestResult(customerEventScreeningTestEntity.CustomerEventScreeningTestId);

            var customerEventTestStandardFindingEntities = customerEventScreeningTestEntity.CustomerEventTestStandardFinding.ToList();
            var standardFindingTestReadingEntities = customerEventScreeningTestEntity.StandardFindingTestReadingCollectionViaCustomerEventTestStandardFinding.ToList();

            if (customerEventTestStandardFindingEntities.Count() > 0)
            {
                var testResultService = new TestResultService();
                var standardFindings = testResultService.GetAllStandardFindings<int?>((int)TestType.PulmonaryFunction);

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



            return testResult;
        }

        public override CustomerEventScreeningTestsEntity CreateActualTestResultEntity(TestResult testResult, List<Core.OrderedPair<int, int>> testReadingReadingPairs)
        {
            var pulmonaryFunctionTestResult = testResult as PulmonaryFunctionTestResult;
            var customerEventScreeningTestsEntity = new CustomerEventScreeningTestsEntity(testResult.Id) { TestId = (int)TestType.PulmonaryFunction };

            testResult.ResultInterpretation = null;
            if (pulmonaryFunctionTestResult.Finding != null)
            {
                var customerEventTestStandardFindingEntity = new CustomerEventTestStandardFindingEntity
                                                                 {
                                                                     StandardFindingTestReadingId =
                                                                         (int?)new TestResultService().GetStandardFindingTestReadingIdForStandardFinding
                                                                                   ((int)TestType.PulmonaryFunction, null, Convert.ToInt64(pulmonaryFunctionTestResult.Finding.Id)),

                                                                     CustomerEventTestStandardFindingId = pulmonaryFunctionTestResult.Finding.CustomerEventStandardFindingId,
                                                                     CustomerEventScreeningTestId = testResult.Id
                                                                 };
                
                var finding = GetSelectedStandardFinding((int)TestType.PulmonaryFunction, null, pulmonaryFunctionTestResult.Finding.Id);

                if (testResult.ResultStatus.StateNumber == (int)TestResultStateNumber.Evaluated || testResult.ResultStatus.StateNumber == (int)NewTestResultStateNumber.Evaluated)
                {
                    testResult.ResultInterpretation = finding.ResultInterpretation;
                    testResult.PathwayRecommendation = finding.PathwayRecommendation;
                }

                customerEventScreeningTestsEntity.CustomerEventTestStandardFinding.Add(customerEventTestStandardFindingEntity);
            }

            return customerEventScreeningTestsEntity;
        }
    }
}