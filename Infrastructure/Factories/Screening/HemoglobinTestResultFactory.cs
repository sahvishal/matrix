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

namespace Falcon.App.Infrastructure.Factories.Screening
{
    public class HemoglobinTestResultFactory : TestResultFactory
    {
        private readonly string _toCheckFor = "";

        public HemoglobinTestResultFactory(bool isMale)
        {
            _toCheckFor = isMale ? "male - " : "female - ";
        }

        private CompoundResultReading<decimal?> CreateTestReadingforaDecimalValue(CustomerEventReadingEntity testReadingEntity, int readingId, List<StandardFindingTestReadingEntity> standardFindingTestReadingEntities, decimal? value)
        {
            StandardFindingTestReadingEntity standardFindingTestReading = null;
            if (testReadingEntity.StandardFindingTestReadingId != null)
            {
                standardFindingTestReading =
                    standardFindingTestReadingEntities.Find(standardFindingTestReadingEntity =>
                                                                     (standardFindingTestReadingEntity.ReadingId == readingId)
                                                                     && (testReadingEntity.StandardFindingTestReadingId == standardFindingTestReadingEntity.StandardFindingTestReadingId)
                        );

            }

            var testReading = new CompoundResultReading<decimal?>(testReadingEntity.CustomerEventReadingId)
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

            decimal testReadingValue = 0;
            var allFindings = new TestResultService().GetAllStandardFindings<decimal?>((int)TestType.Hemoglobin, readingId);

            if (testReadingEntity.Value != null && decimal.TryParse(testReadingEntity.Value, out testReadingValue))
            {
                var findings = (new TestResultService()).GetMultipleCalculatedStandardFinding(decimal.Round(testReadingValue, 1), (int)TestType.Hemoglobin, readingId);
                var finding = findings.FirstOrDefault();

                if (findings.Count() == 1)
                {
                    testReading.Finding = new StandardFinding<decimal?>(Convert.ToInt64(testReadingEntity.StandardFindingTestReadingId == null ? finding : standardFindingTestReading.StandardFindingId));
                }
                else if (findings.Count() > 1)
                {
                    var avFindings = allFindings.FindAll(f => f.Label.ToLower().IndexOf(_toCheckFor) == 0);
                    finding = findings.FirstOrDefault(f => avFindings.Select(av => av.Id).Contains(f));
                    testReading.Finding = new StandardFinding<decimal?>(Convert.ToInt64(testReadingEntity.StandardFindingTestReadingId == null ? finding : standardFindingTestReading.StandardFindingId));
                }
            }
            else if (testReadingEntity.StandardFindingTestReadingId != null)
            {
                testReading.Finding = new StandardFinding<decimal?>(standardFindingTestReading.StandardFindingId);
            }

            if (testReading.Finding != null)
                testReading.Finding = allFindings.Find(standardFinding => standardFinding.Id == testReading.Finding.Id);

            return testReading;
        }

        public override TestResult CreateActualTestResult(CustomerEventScreeningTestsEntity customerEventScreeningTestsEntity)
        {
            var customerEventReadingEntities = customerEventScreeningTestsEntity.CustomerEventReading.ToList();

            var testResult = new HemoglobinTestResult(customerEventScreeningTestsEntity.CustomerEventScreeningTestId);

            var standardFindingTestReadingEntities = customerEventScreeningTestsEntity.StandardFindingTestReadingCollectionViaCustomerEventReading.ToList();

            var hemoglobinData = customerEventReadingEntities.SingleOrDefault(customerEventReading => customerEventReading.TestReading.ReadingId == (int)ReadingLabels.Hemoglobin);

            if (hemoglobinData != null)
            {
                testResult.Hemoglobin = CreateTestReadingforaDecimalValue(hemoglobinData, (int)ReadingLabels.Hemoglobin, standardFindingTestReadingEntities,
                    (string.IsNullOrEmpty(hemoglobinData.Value) ? null : (decimal?)Convert.ToDecimal(hemoglobinData.Value)));
            }

            testResult.TechnicallyLimitedbutReadable = CreateResultReading((int)ReadingLabels.TechnicallyLimitedbutReadable, customerEventReadingEntities);
            testResult.RepeatStudy = CreateResultReading((int)ReadingLabels.RepeatStudy, customerEventReadingEntities);

            return testResult;
        }

        public override CustomerEventScreeningTestsEntity CreateActualTestResultEntity(TestResult testResult, List<OrderedPair<int, int>> testReadingReadingPairs)
        {
            var hemoglobinTestResult = testResult as HemoglobinTestResult;
            var customerEventScreeningTestsEntity = new CustomerEventScreeningTestsEntity(testResult.Id) { TestId = (int)TestType.Hemoglobin };

            var customerEventReadingEntities = new List<CustomerEventReadingEntity>();
            if (hemoglobinTestResult != null)
            {
                CustomerEventReadingEntity customerEventTestReadingEntity = null;

                if (hemoglobinTestResult.Hemoglobin != null)
                {
                    customerEventTestReadingEntity = CreateEventReadingEntity(hemoglobinTestResult.Hemoglobin, (int)ReadingLabels.Hemoglobin, testReadingReadingPairs);


                    long findingId = 0;
                    if (hemoglobinTestResult.Hemoglobin.Finding == null)
                    {
                        customerEventTestReadingEntity.StandardFindingTestReadingId = null;
                    }
                    else if (hemoglobinTestResult.Hemoglobin.Reading == null)
                    {
                        if (customerEventTestReadingEntity == null)
                            customerEventTestReadingEntity = CreateEventReadingEntitywithNullReading(hemoglobinTestResult.Hemoglobin, (int)ReadingLabels.Hemoglobin, testReadingReadingPairs);

                        findingId = hemoglobinTestResult.Hemoglobin.Finding.Id;
                        customerEventTestReadingEntity.StandardFindingTestReadingId
                                = (int?)new TestResultService().GetStandardFindingTestReadingIdForStandardFinding((int)TestType.Hemoglobin, (int)ReadingLabels.Hemoglobin, hemoglobinTestResult.Hemoglobin.Finding.Id);
                    }
                    else
                    {
                        var allFindings = new TestResultService().GetAllStandardFindings<int>((int)TestType.Hemoglobin, (int)ReadingLabels.Hemoglobin);

                        var reading = hemoglobinTestResult.Hemoglobin.Reading != null ? decimal.Round(hemoglobinTestResult.Hemoglobin.Reading.Value, 1) : (decimal?)null;
                        var findings = (new TestResultService()).GetMultipleCalculatedStandardFinding(reading, (int)TestType.Hemoglobin, (int)ReadingLabels.Hemoglobin);
                        var avFindings = allFindings.FindAll(f => f.Label.ToLower().IndexOf(_toCheckFor) == 0);
                        findingId = findings.FirstOrDefault(f => avFindings.Select(av => av.Id).Contains(f));

                        if (hemoglobinTestResult.Hemoglobin.Finding.Id == findingId)
                            customerEventTestReadingEntity.StandardFindingTestReadingId = null;
                        else
                        {
                            customerEventTestReadingEntity.StandardFindingTestReadingId
                                = (int?)new TestResultService().GetStandardFindingTestReadingIdForStandardFinding((int)TestType.Hemoglobin, (int)ReadingLabels.Hemoglobin, hemoglobinTestResult.Hemoglobin.Finding.Id);
                            findingId = hemoglobinTestResult.Hemoglobin.Finding.Id;
                        }
                    }

                    if (findingId > 0)
                    {
                        var finding = GetSelectedStandardFinding((int)TestType.Hemoglobin, (int)ReadingLabels.Hemoglobin, findingId);

                        if (testResult.ResultStatus.StateNumber == (int)TestResultStateNumber.Evaluated || testResult.ResultStatus.StateNumber == (int)NewTestResultStateNumber.Evaluated)
                        {
                            testResult.ResultInterpretation = finding.ResultInterpretation;
                            testResult.PathwayRecommendation = finding.PathwayRecommendation;
                        }
                    }

                    customerEventReadingEntities.Add(customerEventTestReadingEntity);
                }

                if (hemoglobinTestResult.TechnicallyLimitedbutReadable != null)
                {
                    var customerEventReadingEntity = CreateEventReadingEntity(hemoglobinTestResult.TechnicallyLimitedbutReadable, (int)ReadingLabels.TechnicallyLimitedbutReadable, testReadingReadingPairs);
                    if (customerEventReadingEntity != null) customerEventReadingEntities.Add(customerEventReadingEntity);
                }

                if (hemoglobinTestResult.RepeatStudy != null)
                {
                    var customerEventReadingEntity = CreateEventReadingEntity(hemoglobinTestResult.RepeatStudy, (int)ReadingLabels.RepeatStudy, testReadingReadingPairs);
                    if (customerEventReadingEntity != null) customerEventReadingEntities.Add(customerEventReadingEntity);
                }

                if (customerEventReadingEntities.Count > 0)
                    customerEventScreeningTestsEntity.CustomerEventReading.AddRange(customerEventReadingEntities);
            }

            return customerEventScreeningTestsEntity;
        }
    }
}
