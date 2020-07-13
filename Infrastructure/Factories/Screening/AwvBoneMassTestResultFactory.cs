﻿using System;
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
    public class AwvBoneMassTestResultFactory : TestResultFactory
    {
        public override TestResult CreateActualTestResult(CustomerEventScreeningTestsEntity customerEventScreeningTestsEntity)
        {
            var customerEventReadingEntities = customerEventScreeningTestsEntity.CustomerEventReading.ToList();

            var testResult = new AwvBoneMassTestResult(customerEventScreeningTestsEntity.CustomerEventScreeningTestId);

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
                        stdFindingTestReading.TestId == (int)TestType.AwvBoneMass && stdFindingTestReading.ReadingId == (int)ReadingLabels.EstimatedTScore);

                    if (standardFindingReadingEntity != null)
                        testResult.EstimatedTScore.Finding = new StandardFinding<decimal?>(standardFindingReadingEntity.StandardFindingId);
                }
                else if (tScoreReadingEntity.Value != null && float.TryParse(tScoreReadingEntity.Value, out testReadingValue))
                {
                    testResult.EstimatedTScore.Finding = new StandardFinding<decimal?>((new TestResultService()).
                                                                         GetCalculatedStandardFinding((decimal?)testReadingValue,
                                                                         (int)TestType.AwvBoneMass, (int)ReadingLabels.EstimatedTScore));
                }

                if (testResult.EstimatedTScore.Finding != null)
                    testResult.EstimatedTScore.Finding = new TestResultService().GetAllStandardFindings<decimal?>((int)TestType.AwvBoneMass, (int)ReadingLabels.EstimatedTScore).Find(standardFinding => standardFinding.Id == testResult.EstimatedTScore.Finding.Id);
            }

            return testResult;
        }

        public override CustomerEventScreeningTestsEntity CreateActualTestResultEntity(TestResult testResult, List<OrderedPair<int, int>> testReadingReadingPairs)
        {
            var awvBoneMassTestResult = testResult as AwvBoneMassTestResult;
            var customerEventScreeningTestsEntity = new CustomerEventScreeningTestsEntity(testResult.Id) { TestId = (int)TestType.AwvBoneMass };
            var customerEventReadingEntities = new List<CustomerEventReadingEntity>();

            CustomerEventReadingEntity customerEventReading = null;

            testResult.ResultInterpretation = null;
            // TODO : This code should be moved to a Coordinator/Service.
            if (awvBoneMassTestResult.EstimatedTScore != null && awvBoneMassTestResult.EstimatedTScore.Finding != null)
            {
                customerEventReading = CreateEventReadingEntity(awvBoneMassTestResult.EstimatedTScore, (int)ReadingLabels.EstimatedTScore, testReadingReadingPairs) ??
                                       new CustomerEventReadingEntity(awvBoneMassTestResult.EstimatedTScore.Id)
                                       {
                                           IsManual = true,
                                           CreatedByOrgRoleUserId =
                                               awvBoneMassTestResult.EstimatedTScore.RecorderMetaData.DataRecorderCreator.Id,
                                           CreatedOn = awvBoneMassTestResult.EstimatedTScore.RecorderMetaData.DateCreated,
                                           UpdatedByOrgRoleUserId = awvBoneMassTestResult.EstimatedTScore.RecorderMetaData.DataRecorderModifier != null ? (long?)awvBoneMassTestResult.EstimatedTScore.RecorderMetaData.DataRecorderModifier.Id : null,
                                           UpdatedOn = awvBoneMassTestResult.EstimatedTScore.RecorderMetaData.DateModified,
                                           TestReadingId = testReadingReadingPairs.Find(testReadingpair => testReadingpair.FirstValue == (int)ReadingLabels.EstimatedTScore).SecondValue
                                       };

                if (awvBoneMassTestResult.EstimatedTScore.Reading == null)
                {
                    customerEventReading.StandardFindingTestReadingId
                            = (int?)new TestResultService().GetStandardFindingTestReadingIdForStandardFinding((int)TestType.AwvBoneMass, (int)ReadingLabels.EstimatedTScore, awvBoneMassTestResult.EstimatedTScore.Finding.Id);
                }
                else
                {
                    int findingId = (new TestResultService()).GetCalculatedStandardFinding(awvBoneMassTestResult.EstimatedTScore.Reading, (int)TestType.AwvBoneMass, (int)ReadingLabels.EstimatedTScore);

                    if (awvBoneMassTestResult.EstimatedTScore.Finding.Id == findingId)
                        customerEventReading.StandardFindingTestReadingId = null;
                    else
                        customerEventReading.StandardFindingTestReadingId
                            = (int?)new TestResultService().GetStandardFindingTestReadingIdForStandardFinding((int)TestType.AwvBoneMass, (int)ReadingLabels.EstimatedTScore, awvBoneMassTestResult.EstimatedTScore.Finding.Id);
                }

                if (awvBoneMassTestResult.EstimatedTScore.Finding.Id > 0)
                {
                    var finding = GetSelectedStandardFinding((int)TestType.AwvBoneMass, (int)ReadingLabels.EstimatedTScore, awvBoneMassTestResult.EstimatedTScore.Finding.Id);

                    if (testResult.ResultStatus.StateNumber == (int)TestResultStateNumber.Evaluated || testResult.ResultStatus.StateNumber == (int)NewTestResultStateNumber.Evaluated)
                    {
                        testResult.ResultInterpretation = finding.ResultInterpretation;
                        testResult.PathwayRecommendation = finding.PathwayRecommendation;
                    }
                }
            }

            if (customerEventReading != null) customerEventReadingEntities.Add(customerEventReading);

            if (customerEventReadingEntities.Count > 0)
                customerEventScreeningTestsEntity.CustomerEventReading.AddRange(customerEventReadingEntities);

            return customerEventScreeningTestsEntity;
        }
    }
}
