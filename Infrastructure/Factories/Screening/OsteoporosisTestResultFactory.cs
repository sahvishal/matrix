using System;
using System.Collections.Generic;
using System.Linq;
using Falcon.App.Core;
using Falcon.App.Core.Domain;
using Falcon.App.Core.Medical.Domain;
using Falcon.App.Core.Medical.Enum;
using Falcon.App.Core.Users.Domain;
using Falcon.App.Infrastructure.Service;
using Falcon.Data.EntityClasses;
using Falcon.App.Core.Application.Domain;


namespace Falcon.App.Infrastructure.Factories.Screening
{
    public class OsteoporosisTestResultFactory : TestResultFactory
    {
        public override TestResult CreateActualTestResult(CustomerEventScreeningTestsEntity customerEventScreeningTestsEntity)
        {
            var customerEventReadingEntities = customerEventScreeningTestsEntity.CustomerEventReading.ToList();

            var testResult = new OsteoporosisTestResult(customerEventScreeningTestsEntity.CustomerEventScreeningTestId);
            
            if (customerEventScreeningTestsEntity.TestMedia != null && customerEventScreeningTestsEntity.TestMedia.Count > 0)
            {
                var fileEntityCollection = customerEventScreeningTestsEntity.FileCollectionViaTestMedia.ToList();
                var testMediaEntity = customerEventScreeningTestsEntity.TestMedia.FirstOrDefault();

                testResult.ResultImage = new ResultMedia(testMediaEntity.MediaId)
                {
                    File = GetFileObjectfromEntity(testMediaEntity.FileId, fileEntityCollection),
                    Thumbnail = testMediaEntity.ThumbnailFileId != null ? new File(testMediaEntity.ThumbnailFileId.Value) : null,
                    ReadingSource = testMediaEntity.IsManual ? ReadingSource.Manual : ReadingSource.Automatic
                };
            }

            var tScoreReadingEntity = customerEventReadingEntities.
                Where(customerEventReading => customerEventReading.TestReading.ReadingId == (int)ReadingLabels.EstimatedTScore).FirstOrDefault();

            if (tScoreReadingEntity != null)
            {
                testResult.EstimatedTScore = new CompoundResultReading<decimal?>(tScoreReadingEntity.CustomerEventReadingId)
                {
                    Reading = (!string.IsNullOrEmpty(tScoreReadingEntity.Value) ? (decimal?)Convert.ToSingle(tScoreReadingEntity.Value) : null),
                    ReadingSource = tScoreReadingEntity.IsManual ? ReadingSource.Manual : ReadingSource.Automatic,
                    Label = ReadingLabels.EstimatedTScore,
                    RecorderMetaData = new DataRecorderMetaData
                    {
                        DataRecorderCreator = new OrganizationRoleUser(tScoreReadingEntity.CreatedByOrgRoleUserId),
                        DateCreated = tScoreReadingEntity.CreatedOn,
                        DataRecorderModifier = tScoreReadingEntity.UpdatedByOrgRoleUserId.HasValue ? new OrganizationRoleUser(tScoreReadingEntity.UpdatedByOrgRoleUserId.Value) : null,
                        DateModified = tScoreReadingEntity.UpdatedOn
                    }
                };


                // TODO : This code should be moved to a Coordinator/Service.
                float testReadingValue = 0;
                if (tScoreReadingEntity.StandardFindingTestReadingId != null)
                {
                    var standardFindingReadingEntity = customerEventScreeningTestsEntity.StandardFindingTestReadingCollectionViaCustomerEventReading.ToList().Find(stdFindingTestReading =>
                        stdFindingTestReading.TestId == (int)TestType.Osteoporosis && stdFindingTestReading.ReadingId == (int)ReadingLabels.EstimatedTScore);

                    if (standardFindingReadingEntity != null)
                        testResult.EstimatedTScore.Finding = new StandardFinding<decimal?>(standardFindingReadingEntity.StandardFindingId);
                }
                else if (tScoreReadingEntity.Value != null && float.TryParse(tScoreReadingEntity.Value, out testReadingValue))
                {
                    testResult.EstimatedTScore.Finding = new StandardFinding<decimal?>((new TestResultService()).
                                                                         GetCalculatedStandardFinding((decimal?)testReadingValue,
                                                                         (int)TestType.Osteoporosis, (int)ReadingLabels.EstimatedTScore));
                }

                if (testResult.EstimatedTScore.Finding != null)
                    testResult.EstimatedTScore.Finding = new TestResultService().GetAllStandardFindings<decimal?>((int)TestType.Osteoporosis, (int)ReadingLabels.EstimatedTScore).Find(standardFinding => standardFinding.Id == testResult.EstimatedTScore.Finding.Id);
            }

            testResult.LeftHeelTScore = CreateResultReadingforNullableDecimal((int)ReadingLabels.LeftHeelTScore, customerEventReadingEntities);
            testResult.RightHeelTScore = CreateResultReadingforNullableDecimal((int)ReadingLabels.RightHeelTScore, customerEventReadingEntities);

            return testResult;
        }

        public override CustomerEventScreeningTestsEntity CreateActualTestResultEntity(TestResult testResult, List<OrderedPair<int, int>> testReadingReadingPairs)
        {
            var osteoTestResult = testResult as OsteoporosisTestResult;
            var customerEventScreeningTestsEntity = new CustomerEventScreeningTestsEntity(testResult.Id) { TestId = (int)TestType.Osteoporosis };
            var customerEventReadingEntities = new List<CustomerEventReadingEntity>();

            CustomerEventReadingEntity customerEventReading = null;

            testResult.ResultInterpretation = null;
            // TODO : This code should be moved to a Coordinator/Service.
            if (osteoTestResult.EstimatedTScore != null && osteoTestResult.EstimatedTScore.Finding != null)
            {
                customerEventReading = CreateEventReadingEntity(osteoTestResult.EstimatedTScore, (int)ReadingLabels.EstimatedTScore, testReadingReadingPairs) ??
                                       new CustomerEventReadingEntity(osteoTestResult.EstimatedTScore.Id)
                                        {
                                            IsManual = true,
                                            CreatedByOrgRoleUserId =
                                                osteoTestResult.EstimatedTScore.RecorderMetaData.DataRecorderCreator.Id,
                                            CreatedOn = osteoTestResult.EstimatedTScore.RecorderMetaData.DateCreated,
                                            UpdatedByOrgRoleUserId = osteoTestResult.EstimatedTScore.RecorderMetaData.DataRecorderModifier != null ? (long?)osteoTestResult.EstimatedTScore.RecorderMetaData.DataRecorderModifier.Id : null,
                                            UpdatedOn = osteoTestResult.EstimatedTScore.RecorderMetaData.DateModified,
                                            TestReadingId = testReadingReadingPairs.Find(testReadingpair => testReadingpair.FirstValue == (int)ReadingLabels.EstimatedTScore).SecondValue
                                        };

                if (osteoTestResult.EstimatedTScore.Reading == null)
                {
                    customerEventReading.StandardFindingTestReadingId
                            = (int?)new TestResultService().GetStandardFindingTestReadingIdForStandardFinding((int)TestType.Osteoporosis, (int)ReadingLabels.EstimatedTScore, osteoTestResult.EstimatedTScore.Finding.Id);
                }
                else
                {
                    int findingId = (new TestResultService()).GetCalculatedStandardFinding(osteoTestResult.EstimatedTScore.Reading, (int)TestType.Osteoporosis, (int)ReadingLabels.EstimatedTScore);

                    if (osteoTestResult.EstimatedTScore.Finding.Id == findingId)
                        customerEventReading.StandardFindingTestReadingId = null;
                    else
                        customerEventReading.StandardFindingTestReadingId
                            = (int?)new TestResultService().GetStandardFindingTestReadingIdForStandardFinding((int)TestType.Osteoporosis, (int)ReadingLabels.EstimatedTScore, osteoTestResult.EstimatedTScore.Finding.Id);
                }

                if (osteoTestResult.EstimatedTScore.Finding.Id > 0)
                {
                    var finding = GetSelectedStandardFinding((int)TestType.Osteoporosis, (int)ReadingLabels.EstimatedTScore, osteoTestResult.EstimatedTScore.Finding.Id);

                    if (testResult.ResultStatus.StateNumber == (int)TestResultStateNumber.Evaluated || testResult.ResultStatus.StateNumber == (int)NewTestResultStateNumber.Evaluated)
                    {
                        testResult.ResultInterpretation = finding.ResultInterpretation;
                        testResult.PathwayRecommendation = finding.PathwayRecommendation;
                    }
                }
            }

            if (customerEventReading != null) customerEventReadingEntities.Add(customerEventReading);

            customerEventReading = CreateEventReadingEntity(osteoTestResult.LeftHeelTScore, (int)ReadingLabels.LeftHeelTScore, testReadingReadingPairs);
            if (customerEventReading != null) customerEventReadingEntities.Add(customerEventReading);

            customerEventReading = CreateEventReadingEntity(osteoTestResult.RightHeelTScore, (int)ReadingLabels.RightHeelTScore, testReadingReadingPairs);
            if (customerEventReading != null) customerEventReadingEntities.Add(customerEventReading);

            if (customerEventReadingEntities.Count > 0)
                customerEventScreeningTestsEntity.CustomerEventReading.AddRange(customerEventReadingEntities);

            return customerEventScreeningTestsEntity;
        }

    }
}
