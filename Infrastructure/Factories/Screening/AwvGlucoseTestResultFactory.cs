using System;
using System.Collections.Generic;
using System.Linq;
using Falcon.App.Core;
using Falcon.App.Core.Domain;
using Falcon.App.Core.Extensions;
using Falcon.App.Core.Medical.Domain;
using Falcon.App.Core.Medical.Enum;
using Falcon.App.Core.Users.Domain;
using Falcon.App.Infrastructure.Service;
using Falcon.Data.EntityClasses;

namespace Falcon.App.Infrastructure.Factories.Screening
{
    public class AwvGlucoseTestResultFactory : TestResultFactory
    {
        private readonly string _toCheckFor = "";
        public AwvGlucoseTestResultFactory(bool isMale)
        {
            _toCheckFor = isMale ? "male - " : "female - ";
        }

        private CompoundResultReading<T> CreateTestReadingforaIntValue<T>(CustomerEventReadingEntity testReadingEntity, int readingId, List<StandardFindingTestReadingEntity> standardFindingTestReadingEntities, T value)
        {
            StandardFindingTestReadingEntity standardFindingTestReading = null;
            if (testReadingEntity.StandardFindingTestReadingId != null)
            {
                standardFindingTestReading =
                    standardFindingTestReadingEntities.Find(standardFindingTestReadingEntity =>
                                                                     (standardFindingTestReadingEntity.ReadingId ==
                                                                      readingId) &&
                                                                     (testReadingEntity.
                                                                          StandardFindingTestReadingId ==
                                                                      standardFindingTestReadingEntity.
                                                                          StandardFindingTestReadingId)
                        );

            }

            var testReading = new CompoundResultReading<T>(testReadingEntity.CustomerEventReadingId)
            {
                Label = (ReadingLabels)readingId,
                Reading = value,
                ReadingSource = testReadingEntity.IsManual
                                    ? ReadingSource.Manual
                                    : ReadingSource.Automatic,
                RecorderMetaData = new DataRecorderMetaData
                {
                    DataRecorderCreator = new OrganizationRoleUser(testReadingEntity.CreatedByOrgRoleUserId),
                    DateCreated = testReadingEntity.CreatedOn,
                    DataRecorderModifier = testReadingEntity.UpdatedByOrgRoleUserId.HasValue ? new OrganizationRoleUser(testReadingEntity.UpdatedByOrgRoleUserId.Value) : null,
                    DateModified = testReadingEntity.UpdatedOn
                }
            };

            int testReadingValue = 0;
            var allFindings = new TestResultService().GetAllStandardFindings<T>((int)TestType.AwvGlucose, readingId);

            if (testReadingEntity.Value != null && int.TryParse(testReadingEntity.Value, out testReadingValue))
            {
                var findings = (new TestResultService()).GetMultipleCalculatedStandardFinding(testReadingValue, (int)TestType.AwvGlucose, readingId);
                var finding = findings.FirstOrDefault();

                if (findings.Count() == 1)
                {
                    testReading.Finding = new StandardFinding<T>(Convert.ToInt64(testReadingEntity.StandardFindingTestReadingId == null ? finding : standardFindingTestReading.StandardFindingId));
                }
                else if (findings.Count() > 1)
                {
                    var avFindings = allFindings.FindAll(f => f.Label.ToLower().IndexOf(_toCheckFor) == 0);
                    finding = findings.Where(f => avFindings.Select(av => av.Id).Contains(f)).FirstOrDefault();
                    testReading.Finding = new StandardFinding<T>(Convert.ToInt64(testReadingEntity.StandardFindingTestReadingId == null ? finding : standardFindingTestReading.StandardFindingId));
                }
            }
            else if (testReadingEntity.StandardFindingTestReadingId != null)
            {
                testReading.Finding = new StandardFinding<T>(standardFindingTestReading.StandardFindingId);
            }

            if (testReading.Finding != null)
                testReading.Finding = allFindings.Find(standardFinding => standardFinding.Id == testReading.Finding.Id);

            return testReading;
        }
        
        public override TestResult CreateActualTestResult(CustomerEventScreeningTestsEntity customerEventScreeningTestsEntity)
        {
            var customerEventReadingEntities = customerEventScreeningTestsEntity.CustomerEventReading.ToList();

            var testResult = new AwvGlucoseTestResult(customerEventScreeningTestsEntity.CustomerEventScreeningTestId);

            var standardFindingTestReadingEntities = customerEventScreeningTestsEntity.StandardFindingTestReadingCollectionViaCustomerEventReading.ToList();
           

            var glucoseData = customerEventReadingEntities.SingleOrDefault(customerEventReading => customerEventReading.TestReading.ReadingId == (int)ReadingLabels.Glucose);

            if (glucoseData != null)
            {
                testResult.Glucose = CreateTestReadingforaIntValue(glucoseData, (int)ReadingLabels.Glucose, standardFindingTestReadingEntities,
                    (string.IsNullOrEmpty(glucoseData.Value) ? null : (int?)Convert.ToInt32(glucoseData.Value)));
            }

            return testResult;
        }

        public override CustomerEventScreeningTestsEntity CreateActualTestResultEntity(TestResult testResult, List<OrderedPair<int, int>> testReadingReadingPairs)
        {
            var awvGlucoseTestResult = testResult as AwvGlucoseTestResult;
            var customerEventScreeningTestsEntity = new CustomerEventScreeningTestsEntity(testResult.Id) { TestId = (int)TestType.AwvGlucose };
            var resultIntpretations = new List<long>();
            var pathwayRecomendations = new List<long>();

            var customerEventReadingEntities = new List<CustomerEventReadingEntity>();
            if (awvGlucoseTestResult != null)
            {
                CustomerEventReadingEntity customerEventTestReadingEntity = null;
                
                if (awvGlucoseTestResult.Glucose != null)
                {
                    customerEventTestReadingEntity = CreateEventReadingEntity(awvGlucoseTestResult.Glucose, (int)ReadingLabels.Glucose, testReadingReadingPairs);
                    long findingId = 0;

                    if (awvGlucoseTestResult.Glucose.Finding == null)
                    {
                        customerEventTestReadingEntity.StandardFindingTestReadingId = null;
                    }
                    else if (awvGlucoseTestResult.Glucose.Reading == null)
                    {
                        if (customerEventTestReadingEntity == null)
                            customerEventTestReadingEntity = CreateEventReadingEntitywithNullReading(awvGlucoseTestResult.Glucose, (int)ReadingLabels.Glucose, testReadingReadingPairs);

                        customerEventTestReadingEntity.StandardFindingTestReadingId
                                = (int?)new TestResultService().GetStandardFindingTestReadingIdForStandardFinding((int)TestType.AwvGlucose, (int)ReadingLabels.Glucose, awvGlucoseTestResult.Glucose.Finding.Id);

                        findingId = awvGlucoseTestResult.Glucose.Finding.Id;
                    }
                    else
                    {
                        findingId = (new TestResultService()).GetCalculatedStandardFinding(Convert.ToInt32(awvGlucoseTestResult.Glucose.Reading), (int)TestType.AwvGlucose, (int)ReadingLabels.Glucose);

                        if (awvGlucoseTestResult.Glucose.Finding.Id == findingId)
                            customerEventTestReadingEntity.StandardFindingTestReadingId = null;
                        else
                        {
                            customerEventTestReadingEntity.StandardFindingTestReadingId
                                = (int?)new TestResultService().GetStandardFindingTestReadingIdForStandardFinding((int)TestType.AwvGlucose, (int)ReadingLabels.Glucose, awvGlucoseTestResult.Glucose.Finding.Id);

                            findingId = awvGlucoseTestResult.Glucose.Finding.Id;
                        }
                    }

                    if (findingId > 0)
                    {
                        var finding = GetSelectedStandardFinding((int)TestType.AwvGlucose, (int)ReadingLabels.Glucose, findingId);
                        if (finding.ResultInterpretation != null) resultIntpretations.Add(finding.ResultInterpretation.Value);
                        if (finding.PathwayRecommendation != null) pathwayRecomendations.Add(finding.PathwayRecommendation.Value);
                    }

                    customerEventReadingEntities.Add(customerEventTestReadingEntity);
                }

                if (testResult.ResultStatus.StateNumber == (int)TestResultStateNumber.Evaluated || testResult.ResultStatus.StateNumber == (int)NewTestResultStateNumber.Evaluated)
                {
                    if (resultIntpretations.Count > 0)
                        testResult.ResultInterpretation = ResultInterpretation.Normal.GetMax(resultIntpretations);

                    if (pathwayRecomendations.Count > 0)
                        testResult.PathwayRecommendation = PathwayRecommendation.None.GetMax(pathwayRecomendations);
                }

            }

            customerEventScreeningTestsEntity.CustomerEventReading.AddRange(customerEventReadingEntities);
            return customerEventScreeningTestsEntity;
        }
    }
}
