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
    public class AwvLipidTestResultFactory : TestResultFactory
    {
        private readonly string _toCheckFor = "";
        public AwvLipidTestResultFactory(bool isMale)
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
            var allFindings = new TestResultService().GetAllStandardFindings<T>((int)TestType.AwvLipid, readingId);

            if (testReadingEntity.Value != null && int.TryParse(testReadingEntity.Value, out testReadingValue))
            {
                var findings = (new TestResultService()).GetMultipleCalculatedStandardFinding(testReadingValue, (int)TestType.AwvLipid, readingId);
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

        private static CompoundResultReading<decimal?> CreateTestReadingforaDecimalValue(CustomerEventReadingEntity testReadingEntity, int readingId,
            List<StandardFindingTestReadingEntity> standardFindingTestReadingEntities, decimal? value)
        {
            StandardFindingTestReadingEntity standardFindingTestReading = null;
            if (testReadingEntity.StandardFindingTestReadingId != null)
            {
                standardFindingTestReading = standardFindingTestReadingEntities.Find(standardFindingTestReadingEntity => (standardFindingTestReadingEntity.ReadingId == readingId)
                                                && (testReadingEntity.StandardFindingTestReadingId == standardFindingTestReadingEntity.StandardFindingTestReadingId));

            }

            var testReading = new CompoundResultReading<decimal?>(testReadingEntity.CustomerEventReadingId)
            {
                Label = (ReadingLabels)readingId,
                Reading = value,
                ReadingSource = testReadingEntity.IsManual ? ReadingSource.Manual : ReadingSource.Automatic,
                RecorderMetaData = new DataRecorderMetaData
                {
                    DataRecorderCreator = new OrganizationRoleUser(testReadingEntity.CreatedByOrgRoleUserId),
                    DateCreated = testReadingEntity.CreatedOn,
                    DataRecorderModifier = testReadingEntity.UpdatedByOrgRoleUserId.HasValue ? new OrganizationRoleUser(testReadingEntity.UpdatedByOrgRoleUserId.Value) : null,
                    DateModified = testReadingEntity.UpdatedOn
                }
            };


            if (value != null)
            {
                testReading.Finding = new StandardFinding<decimal?>(Convert.ToInt64(testReadingEntity.StandardFindingTestReadingId == null ? (new TestResultService()).GetCalculatedStandardFinding(decimal.Round(value.Value, 1), (int)TestType.AwvLipid, readingId) : standardFindingTestReading.StandardFindingId));
            }
            else if (testReadingEntity.StandardFindingTestReadingId != null)
            {
                testReading.Finding = new StandardFinding<decimal?>(standardFindingTestReading.StandardFindingId);
            }

            if (testReading.Finding != null)
                testReading.Finding = new TestResultService().GetAllStandardFindings<decimal?>((int)TestType.AwvLipid, readingId).Find(standardFinding => standardFinding.Id == testReading.Finding.Id);

            return testReading;
        }

        public override TestResult CreateActualTestResult(CustomerEventScreeningTestsEntity customerEventScreeningTestsEntity)
        {
            var customerEventReadingEntities = customerEventScreeningTestsEntity.CustomerEventReading.ToList();

            var testResult = new AwvLipidTestResult(customerEventScreeningTestsEntity.CustomerEventScreeningTestId);

            var standardFindingTestReadingEntities =
                    customerEventScreeningTestsEntity.
                        StandardFindingTestReadingCollectionViaCustomerEventReading.ToList();

            var totalCholesterolData = customerEventReadingEntities.
                Where(customerEventReading => customerEventReading.TestReading.ReadingId == (int)ReadingLabels.TotalCholestrol).
                SingleOrDefault();

            if (totalCholesterolData != null)
            {
                testResult.TotalCholestrol = CreateTestReadingforaIntValue(totalCholesterolData, (int)ReadingLabels.TotalCholestrol, standardFindingTestReadingEntities, totalCholesterolData.Value);
            }

            var hdlData = customerEventReadingEntities.
                Where(customerEventReading => customerEventReading.TestReading.ReadingId == (int)ReadingLabels.HDL).
                SingleOrDefault();

            if (hdlData != null)
            {
                testResult.HDL = CreateTestReadingforaIntValue(hdlData, (int)ReadingLabels.HDL, standardFindingTestReadingEntities, hdlData.Value);
            }

            var ldlData = customerEventReadingEntities.
                Where(customerEventReading => customerEventReading.TestReading.ReadingId == (int)ReadingLabels.LDL).
                SingleOrDefault();

            if (ldlData != null)
            {
                testResult.LDL = CreateTestReadingforaIntValue(ldlData, (int)ReadingLabels.LDL, standardFindingTestReadingEntities, (string.IsNullOrEmpty(ldlData.Value) ? null : (int?)Convert.ToInt32(ldlData.Value)));
            }


            var triglyceridesData = customerEventReadingEntities.
                    Where(customerEventReading => customerEventReading.TestReading.ReadingId == (int)ReadingLabels.TriGlycerides).
                    SingleOrDefault();

            if (triglyceridesData != null)
            {
                testResult.TriGlycerides = CreateTestReadingforaIntValue(triglyceridesData, (int)ReadingLabels.TriGlycerides, standardFindingTestReadingEntities, triglyceridesData.Value);
            }

            var tchdlratioData = customerEventReadingEntities.
                Where(customerEventReading => customerEventReading.TestReading.ReadingId == (int)ReadingLabels.TCHDLRatio).
                SingleOrDefault();

            if (tchdlratioData != null)
            {
                testResult.TCHDLRatio = CreateTestReadingforaDecimalValue(tchdlratioData, (int)ReadingLabels.TCHDLRatio, standardFindingTestReadingEntities,
                    (string.IsNullOrEmpty(tchdlratioData.Value) ? null : (decimal?)Convert.ToDecimal(tchdlratioData.Value)));
            }

            return testResult;
        }

        public override CustomerEventScreeningTestsEntity CreateActualTestResultEntity(TestResult testResult, List<OrderedPair<int, int>> testReadingReadingPairs)
        {
            var awvLipidTestResult = testResult as AwvLipidTestResult;
            var customerEventScreeningTestsEntity = new CustomerEventScreeningTestsEntity(testResult.Id) { TestId = (int)TestType.AwvLipid };
            var resultIntpretations = new List<long>();
            var pathwayRecomendations = new List<long>();

            var customerEventReadingEntities = new List<CustomerEventReadingEntity>();
            if (awvLipidTestResult != null)
            {
                CustomerEventReadingEntity customerEventTestReadingEntity = null;
                if (awvLipidTestResult.TotalCholestrol != null)
                {
                    customerEventTestReadingEntity = CreateEventReadingEntity(awvLipidTestResult.TotalCholestrol, (int)ReadingLabels.TotalCholestrol, testReadingReadingPairs);

                    int tCholestrol = 0;
                    long findingId = 0;

                    if (awvLipidTestResult.TotalCholestrol.Finding == null)
                    {
                        customerEventTestReadingEntity.StandardFindingTestReadingId = null;
                    }
                    else if (int.TryParse(awvLipidTestResult.TotalCholestrol.Reading, out tCholestrol) == false)
                    {
                        findingId = awvLipidTestResult.TotalCholestrol.Finding.Id;
                        customerEventTestReadingEntity.StandardFindingTestReadingId
                                = (int?)new TestResultService().GetStandardFindingTestReadingIdForStandardFinding((int)TestType.AwvLipid, (int)ReadingLabels.TotalCholestrol, awvLipidTestResult.TotalCholestrol.Finding.Id);
                    }
                    else
                    {
                        findingId = (new TestResultService()).GetCalculatedStandardFinding(Convert.ToInt32(awvLipidTestResult.TotalCholestrol.Reading), (int)TestType.AwvLipid, (int)ReadingLabels.TotalCholestrol);

                        if (awvLipidTestResult.TotalCholestrol.Finding.Id == findingId)
                            customerEventTestReadingEntity.StandardFindingTestReadingId = null;
                        else
                        {
                            findingId = awvLipidTestResult.TotalCholestrol.Finding.Id;
                            customerEventTestReadingEntity.StandardFindingTestReadingId
                                = (int?)new TestResultService().GetStandardFindingTestReadingIdForStandardFinding((int)TestType.AwvLipid, (int)ReadingLabels.TotalCholestrol, awvLipidTestResult.TotalCholestrol.Finding.Id);
                        }
                    }

                    if (findingId > 0)
                    {
                        var finding = GetSelectedStandardFinding((int)TestType.AwvLipid, (int)ReadingLabels.TotalCholestrol, findingId);
                        if (finding.ResultInterpretation != null) resultIntpretations.Add(finding.ResultInterpretation.Value);
                        if (finding.PathwayRecommendation != null) pathwayRecomendations.Add(finding.PathwayRecommendation.Value);
                    }

                    customerEventReadingEntities.Add(customerEventTestReadingEntity);
                }

                if (awvLipidTestResult.HDL != null)
                {
                    customerEventTestReadingEntity = CreateEventReadingEntity(awvLipidTestResult.HDL, (int)ReadingLabels.HDL, testReadingReadingPairs);
                    int hdl = 0;

                    long findingId = 0;
                    if (awvLipidTestResult.HDL.Finding == null)
                    {
                        customerEventTestReadingEntity.StandardFindingTestReadingId = null;
                    }
                    else if (int.TryParse(awvLipidTestResult.HDL.Reading, out hdl) == false)
                    {
                        findingId = awvLipidTestResult.HDL.Finding.Id;
                        customerEventTestReadingEntity.StandardFindingTestReadingId
                                = (int?)new TestResultService().GetStandardFindingTestReadingIdForStandardFinding((int)TestType.AwvLipid, (int)ReadingLabels.HDL, awvLipidTestResult.HDL.Finding.Id);
                    }
                    else
                    {
                        var allFindings = new TestResultService().GetAllStandardFindings<int>((int)TestType.AwvLipid, (int)ReadingLabels.HDL);

                        var findings = (new TestResultService()).GetMultipleCalculatedStandardFinding(Convert.ToInt32(awvLipidTestResult.HDL.Reading), (int)TestType.AwvLipid, (int)ReadingLabels.HDL);
                        var avFindings = allFindings.FindAll(f => f.Label.ToLower().IndexOf(_toCheckFor) == 0);
                        findingId = findings.Where(f => avFindings.Select(av => av.Id).Contains(f)).FirstOrDefault();

                        if (awvLipidTestResult.HDL.Finding.Id == findingId)
                            customerEventTestReadingEntity.StandardFindingTestReadingId = null;
                        else
                        {
                            customerEventTestReadingEntity.StandardFindingTestReadingId
                                = (int?)new TestResultService().GetStandardFindingTestReadingIdForStandardFinding((int)TestType.AwvLipid, (int)ReadingLabels.HDL, awvLipidTestResult.HDL.Finding.Id);
                            findingId = awvLipidTestResult.HDL.Finding.Id;
                        }
                    }

                    if (findingId > 0)
                    {
                        var finding = GetSelectedStandardFinding((int)TestType.AwvLipid, (int)ReadingLabels.HDL, findingId);
                        if (finding.ResultInterpretation != null) resultIntpretations.Add(finding.ResultInterpretation.Value);
                        if (finding.PathwayRecommendation != null) pathwayRecomendations.Add(finding.PathwayRecommendation.Value);
                    }

                    customerEventReadingEntities.Add(customerEventTestReadingEntity);
                }

                if (awvLipidTestResult.LDL != null)
                {
                    customerEventTestReadingEntity = CreateEventReadingEntity(awvLipidTestResult.LDL, (int)ReadingLabels.LDL, testReadingReadingPairs);

                    long findingId = 0;

                    if (awvLipidTestResult.LDL.Finding == null)
                    {
                        customerEventTestReadingEntity.StandardFindingTestReadingId = null;
                    }
                    else if (awvLipidTestResult.LDL.Reading != null)
                    {
                        findingId = ((new TestResultService()).GetCalculatedStandardFinding(awvLipidTestResult.LDL.Reading, (int)TestType.AwvLipid, (int)ReadingLabels.LDL));
                        customerEventTestReadingEntity.StandardFindingTestReadingId = (awvLipidTestResult.LDL.Finding.Id == findingId
                                                                   ? null : (int?)new TestResultService().GetStandardFindingTestReadingIdForStandardFinding((int)TestType.AwvLipid, (int)ReadingLabels.LDL, awvLipidTestResult.LDL.Finding.Id));

                        findingId = awvLipidTestResult.LDL.Finding.Id != findingId ? awvLipidTestResult.LDL.Finding.Id : findingId;
                    }
                    else if (awvLipidTestResult.LDL.Finding != null)
                    {
                        findingId = awvLipidTestResult.LDL.Finding.Id;
                        if (customerEventTestReadingEntity == null)
                            customerEventTestReadingEntity = CreateEventReadingEntitywithNullReading(awvLipidTestResult.LDL, (int)ReadingLabels.LDL, testReadingReadingPairs);

                        customerEventTestReadingEntity.StandardFindingTestReadingId = (int?)new TestResultService().GetStandardFindingTestReadingIdForStandardFinding((int)TestType.AwvLipid, (int)ReadingLabels.LDL, awvLipidTestResult.LDL.Finding.Id);
                    }

                    if (findingId > 0)
                    {
                        var finding = GetSelectedStandardFinding((int)TestType.AwvLipid, (int)ReadingLabels.LDL, findingId);
                        if (finding.ResultInterpretation != null) resultIntpretations.Add(finding.ResultInterpretation.Value);
                        if (finding.PathwayRecommendation != null) pathwayRecomendations.Add(finding.PathwayRecommendation.Value);
                    }

                    customerEventReadingEntities.Add(customerEventTestReadingEntity);
                }

                if (awvLipidTestResult.TriGlycerides != null)
                {
                    customerEventTestReadingEntity = CreateEventReadingEntity(awvLipidTestResult.TriGlycerides, (int)ReadingLabels.TriGlycerides, testReadingReadingPairs);
                    int triglycerides = 0;
                    long findingId = 0;

                    if (awvLipidTestResult.TriGlycerides.Finding == null)
                    {
                        customerEventTestReadingEntity.StandardFindingTestReadingId = null;
                    }
                    else if (int.TryParse(awvLipidTestResult.TriGlycerides.Reading, out triglycerides) == false)
                    {
                        findingId = awvLipidTestResult.TriGlycerides.Finding.Id;
                        customerEventTestReadingEntity.StandardFindingTestReadingId
                                = (int?)new TestResultService().GetStandardFindingTestReadingIdForStandardFinding((int)TestType.AwvLipid, (int)ReadingLabels.TriGlycerides, awvLipidTestResult.TriGlycerides.Finding.Id);
                    }
                    else
                    {
                        findingId = (new TestResultService()).GetCalculatedStandardFinding(Convert.ToInt32(awvLipidTestResult.TriGlycerides.Reading), (int)TestType.AwvLipid, (int)ReadingLabels.TriGlycerides);

                        if (awvLipidTestResult.TriGlycerides.Finding.Id == findingId)
                            customerEventTestReadingEntity.StandardFindingTestReadingId = null;
                        else
                        {
                            customerEventTestReadingEntity.StandardFindingTestReadingId
                                = (int?)new TestResultService().GetStandardFindingTestReadingIdForStandardFinding((int)TestType.AwvLipid, (int)ReadingLabels.TriGlycerides, awvLipidTestResult.TriGlycerides.Finding.Id);

                            findingId = awvLipidTestResult.TriGlycerides.Finding.Id;
                        }
                    }

                    if (findingId > 0)
                    {
                        var finding = GetSelectedStandardFinding((int)TestType.AwvLipid, (int)ReadingLabels.TriGlycerides, findingId);
                        if (finding.ResultInterpretation != null) resultIntpretations.Add(finding.ResultInterpretation.Value);
                        if (finding.PathwayRecommendation != null) pathwayRecomendations.Add(finding.PathwayRecommendation.Value);
                    }

                    customerEventReadingEntities.Add(customerEventTestReadingEntity);
                }

                if (awvLipidTestResult.TCHDLRatio != null)
                {
                    customerEventTestReadingEntity = CreateEventReadingEntity(awvLipidTestResult.TCHDLRatio, (int)ReadingLabels.TCHDLRatio, testReadingReadingPairs);
                    long findingId = 0;

                    if (awvLipidTestResult.TCHDLRatio.Finding == null)
                    {
                        customerEventTestReadingEntity.StandardFindingTestReadingId = null;
                    }
                    else if (awvLipidTestResult.TCHDLRatio.Reading != null)
                    {
                        findingId = ((new TestResultService()).GetCalculatedStandardFinding(awvLipidTestResult.TCHDLRatio.Reading, (int)TestType.AwvLipid, (int)ReadingLabels.TCHDLRatio));
                        customerEventTestReadingEntity.StandardFindingTestReadingId = (awvLipidTestResult.TCHDLRatio.Finding.Id == findingId
                                                                      ? null : (int?)new TestResultService().GetStandardFindingTestReadingIdForStandardFinding((int)TestType.AwvLipid, (int)ReadingLabels.TCHDLRatio, awvLipidTestResult.TCHDLRatio.Finding.Id));

                        findingId = findingId != awvLipidTestResult.TCHDLRatio.Finding.Id ? awvLipidTestResult.TCHDLRatio.Finding.Id : findingId;
                    }
                    else if (awvLipidTestResult.TCHDLRatio.Finding != null)
                    {
                        if (customerEventTestReadingEntity == null)
                            customerEventTestReadingEntity = CreateEventReadingEntitywithNullReading(awvLipidTestResult.TCHDLRatio, (int)ReadingLabels.TCHDLRatio, testReadingReadingPairs);

                        findingId = awvLipidTestResult.TCHDLRatio.Finding.Id;
                        customerEventTestReadingEntity.StandardFindingTestReadingId = (int?)new TestResultService().GetStandardFindingTestReadingIdForStandardFinding((int)TestType.AwvLipid, (int)ReadingLabels.TCHDLRatio, awvLipidTestResult.TCHDLRatio.Finding.Id);
                    }

                    if (findingId > 0)
                    {
                        var finding = GetSelectedStandardFinding((int)TestType.AwvLipid, (int)ReadingLabels.TCHDLRatio, findingId);
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
