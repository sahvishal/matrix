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
    public class CholesterolTestResultFactory : TestResultFactory
    {
        private readonly string _toCheckFor = "";

        public CholesterolTestResultFactory(bool isMale)
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
            var allFindings = new TestResultService().GetAllStandardFindings<T>((int)TestType.Cholesterol, readingId);

            if (testReadingEntity.Value != null && int.TryParse(testReadingEntity.Value, out testReadingValue))
            {
                var findings = (new TestResultService()).GetMultipleCalculatedStandardFinding(testReadingValue, (int)TestType.Cholesterol, readingId);
                var finding = findings.FirstOrDefault();

                if (findings.Count() == 1)
                {
                    testReading.Finding = new StandardFinding<T>(Convert.ToInt64(testReadingEntity.StandardFindingTestReadingId == null ? finding : standardFindingTestReading.StandardFindingId));
                }
                else if (findings.Count() > 1)
                {
                    var avFindings = allFindings.FindAll(f => f.Label.ToLower().IndexOf(_toCheckFor) == 0);
                    finding = findings.FirstOrDefault(f => avFindings.Select(av => av.Id).Contains(f));
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

        private static CompoundResultReading<decimal?> CreateTestReadingforaDecimalValue(CustomerEventReadingEntity testReadingEntity, int readingId, List<StandardFindingTestReadingEntity> standardFindingTestReadingEntities, decimal? value)
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
                testReading.Finding = new StandardFinding<decimal?>(Convert.ToInt64(testReadingEntity.StandardFindingTestReadingId == null ? (new TestResultService()).GetCalculatedStandardFinding(decimal.Round(value.Value, 1), (int)TestType.Cholesterol, readingId) : standardFindingTestReading.StandardFindingId));
            }
            else if (testReadingEntity.StandardFindingTestReadingId != null)
            {
                testReading.Finding = new StandardFinding<decimal?>(standardFindingTestReading.StandardFindingId);
            }

            if (testReading.Finding != null)
                testReading.Finding = new TestResultService().GetAllStandardFindings<decimal?>((int)TestType.Cholesterol, readingId).Find(standardFinding => standardFinding.Id == testReading.Finding.Id);

            return testReading;
        }

        public override TestResult CreateActualTestResult(CustomerEventScreeningTestsEntity customerEventScreeningTestsEntity)
        {
            var customerEventReadingEntities = customerEventScreeningTestsEntity.CustomerEventReading.ToList();

            var testResult = new CholesterolTestResult(customerEventScreeningTestsEntity.CustomerEventScreeningTestId);

            var standardFindingTestReadingEntities =
                    customerEventScreeningTestsEntity.
                        StandardFindingTestReadingCollectionViaCustomerEventReading.ToList();

            var totalCholesterolData = customerEventReadingEntities.SingleOrDefault(customerEventReading => customerEventReading.TestReading.ReadingId == (int)ReadingLabels.TotalCholestrol);

            if (totalCholesterolData != null)
            {
                testResult.TotalCholesterol = CreateTestReadingforaIntValue(totalCholesterolData, (int)ReadingLabels.TotalCholestrol, standardFindingTestReadingEntities, totalCholesterolData.Value);
            }

            var hdlData = customerEventReadingEntities.SingleOrDefault(customerEventReading => customerEventReading.TestReading.ReadingId == (int)ReadingLabels.HDL);

            if (hdlData != null)
            {
                testResult.HDL = CreateTestReadingforaIntValue(hdlData, (int)ReadingLabels.HDL, standardFindingTestReadingEntities, hdlData.Value);
            }

            var ldlData = customerEventReadingEntities.SingleOrDefault(customerEventReading => customerEventReading.TestReading.ReadingId == (int)ReadingLabels.LDL);

            if (ldlData != null)
            {
                testResult.LDL = CreateTestReadingforaIntValue(ldlData, (int)ReadingLabels.LDL, standardFindingTestReadingEntities, (string.IsNullOrEmpty(ldlData.Value) ? null : (int?)Convert.ToInt32(ldlData.Value)));
            }


            var triglyceridesData = customerEventReadingEntities.SingleOrDefault(customerEventReading => customerEventReading.TestReading.ReadingId == (int)ReadingLabels.TriGlycerides);

            if (triglyceridesData != null)
            {
                testResult.TriGlycerides = CreateTestReadingforaIntValue(triglyceridesData, (int)ReadingLabels.TriGlycerides, standardFindingTestReadingEntities, triglyceridesData.Value);
            }

            var tchdlratioData = customerEventReadingEntities.SingleOrDefault(customerEventReading => customerEventReading.TestReading.ReadingId == (int)ReadingLabels.TCHDLRatio);

            if (tchdlratioData != null)
            {
                testResult.TCHDLRatio = CreateTestReadingforaDecimalValue(tchdlratioData, (int)ReadingLabels.TCHDLRatio, standardFindingTestReadingEntities,
                    (string.IsNullOrEmpty(tchdlratioData.Value) ? null : (decimal?)Convert.ToDecimal(tchdlratioData.Value)));
            }

            return testResult;
        }

        public override CustomerEventScreeningTestsEntity CreateActualTestResultEntity(TestResult testResult, List<OrderedPair<int, int>> testReadingReadingPairs)
        {
            var cholesterolTestResult = testResult as CholesterolTestResult;
            var customerEventScreeningTestsEntity = new CustomerEventScreeningTestsEntity(testResult.Id) { TestId = (int)TestType.Cholesterol };
            var resultIntpretations = new List<long>();
            var pathwayRecomendations = new List<long>();

            var customerEventReadingEntities = new List<CustomerEventReadingEntity>();
            if (cholesterolTestResult != null)
            {
                CustomerEventReadingEntity customerEventTestReadingEntity = null;
                if (cholesterolTestResult.TotalCholesterol != null)
                {
                    customerEventTestReadingEntity = CreateEventReadingEntity(cholesterolTestResult.TotalCholesterol, (int)ReadingLabels.TotalCholestrol, testReadingReadingPairs);

                    int tCholestrol = 0;
                    long findingId = 0;

                    if (cholesterolTestResult.TotalCholesterol.Finding == null)
                    {
                        customerEventTestReadingEntity.StandardFindingTestReadingId = null;
                    }
                    else if (int.TryParse(cholesterolTestResult.TotalCholesterol.Reading, out tCholestrol) == false)
                    {
                        findingId = cholesterolTestResult.TotalCholesterol.Finding.Id;
                        customerEventTestReadingEntity.StandardFindingTestReadingId
                                = (int?)new TestResultService().GetStandardFindingTestReadingIdForStandardFinding((int)TestType.Cholesterol, (int)ReadingLabels.TotalCholestrol, cholesterolTestResult.TotalCholesterol.Finding.Id);
                    }
                    else
                    {
                        findingId = (new TestResultService()).GetCalculatedStandardFinding(Convert.ToInt32(cholesterolTestResult.TotalCholesterol.Reading), (int)TestType.Cholesterol, (int)ReadingLabels.TotalCholestrol);

                        if (cholesterolTestResult.TotalCholesterol.Finding.Id == findingId)
                            customerEventTestReadingEntity.StandardFindingTestReadingId = null;
                        else
                        {
                            findingId = cholesterolTestResult.TotalCholesterol.Finding.Id;
                            customerEventTestReadingEntity.StandardFindingTestReadingId
                                = (int?)new TestResultService().GetStandardFindingTestReadingIdForStandardFinding((int)TestType.Cholesterol, (int)ReadingLabels.TotalCholestrol, cholesterolTestResult.TotalCholesterol.Finding.Id);
                        }
                    }

                    if (findingId > 0)
                    {
                        var finding = GetSelectedStandardFinding((int)TestType.Cholesterol, (int)ReadingLabels.TotalCholestrol, findingId);
                        if (finding.ResultInterpretation != null) resultIntpretations.Add(finding.ResultInterpretation.Value);
                        if (finding.PathwayRecommendation != null) pathwayRecomendations.Add(finding.PathwayRecommendation.Value);
                    }

                    customerEventReadingEntities.Add(customerEventTestReadingEntity);
                }

                if (cholesterolTestResult.HDL != null)
                {
                    customerEventTestReadingEntity = CreateEventReadingEntity(cholesterolTestResult.HDL, (int)ReadingLabels.HDL, testReadingReadingPairs);
                    int hdl = 0;

                    long findingId = 0;
                    if (cholesterolTestResult.HDL.Finding == null)
                    {
                        customerEventTestReadingEntity.StandardFindingTestReadingId = null;
                    }
                    else if (int.TryParse(cholesterolTestResult.HDL.Reading, out hdl) == false)
                    {
                        findingId = cholesterolTestResult.HDL.Finding.Id;
                        customerEventTestReadingEntity.StandardFindingTestReadingId
                                = (int?)new TestResultService().GetStandardFindingTestReadingIdForStandardFinding((int)TestType.Cholesterol, (int)ReadingLabels.HDL, cholesterolTestResult.HDL.Finding.Id);
                    }
                    else
                    {
                        var allFindings = new TestResultService().GetAllStandardFindings<int>((int)TestType.Cholesterol, (int)ReadingLabels.HDL);

                        var findings = (new TestResultService()).GetMultipleCalculatedStandardFinding(Convert.ToInt32(cholesterolTestResult.HDL.Reading), (int)TestType.Cholesterol, (int)ReadingLabels.HDL);
                        var avFindings = allFindings.FindAll(f => f.Label.ToLower().IndexOf(_toCheckFor) == 0);
                        findingId = findings.FirstOrDefault(f => avFindings.Select(av => av.Id).Contains(f));

                        if (cholesterolTestResult.HDL.Finding.Id == findingId)
                            customerEventTestReadingEntity.StandardFindingTestReadingId = null;
                        else
                        {
                            customerEventTestReadingEntity.StandardFindingTestReadingId
                                = (int?)new TestResultService().GetStandardFindingTestReadingIdForStandardFinding((int)TestType.Cholesterol, (int)ReadingLabels.HDL, cholesterolTestResult.HDL.Finding.Id);
                            findingId = cholesterolTestResult.HDL.Finding.Id;
                        }
                    }

                    if (findingId > 0)
                    {
                        var finding = GetSelectedStandardFinding((int)TestType.Cholesterol, (int)ReadingLabels.HDL, findingId);
                        if (finding.ResultInterpretation != null) resultIntpretations.Add(finding.ResultInterpretation.Value);
                        if (finding.PathwayRecommendation != null) pathwayRecomendations.Add(finding.PathwayRecommendation.Value);
                    }

                    customerEventReadingEntities.Add(customerEventTestReadingEntity);
                }

                if (cholesterolTestResult.LDL != null)
                {
                    customerEventTestReadingEntity = CreateEventReadingEntity(cholesterolTestResult.LDL, (int)ReadingLabels.LDL, testReadingReadingPairs);

                    long findingId = 0;
                    if (cholesterolTestResult.LDL.Finding == null)
                    {
                        customerEventTestReadingEntity.StandardFindingTestReadingId = null;
                    }
                    else if (cholesterolTestResult.LDL.Reading != null)
                    {
                        findingId = ((new TestResultService()).GetCalculatedStandardFinding(cholesterolTestResult.LDL.Reading, (int)TestType.Cholesterol, (int)ReadingLabels.LDL));
                        customerEventTestReadingEntity.StandardFindingTestReadingId = (cholesterolTestResult.LDL.Finding.Id == findingId
                                                                   ? null : (int?)new TestResultService().GetStandardFindingTestReadingIdForStandardFinding((int)TestType.Cholesterol, (int)ReadingLabels.LDL, cholesterolTestResult.LDL.Finding.Id));

                        findingId = cholesterolTestResult.LDL.Finding.Id != findingId ? cholesterolTestResult.LDL.Finding.Id : findingId;
                    }
                    else if (cholesterolTestResult.LDL.Finding != null)
                    {
                        findingId = cholesterolTestResult.LDL.Finding.Id;
                        if (customerEventTestReadingEntity == null)
                            customerEventTestReadingEntity = CreateEventReadingEntitywithNullReading(cholesterolTestResult.LDL, (int)ReadingLabels.LDL, testReadingReadingPairs);

                        customerEventTestReadingEntity.StandardFindingTestReadingId = (int?)new TestResultService().GetStandardFindingTestReadingIdForStandardFinding((int)TestType.Cholesterol, (int)ReadingLabels.LDL, cholesterolTestResult.LDL.Finding.Id);
                    }

                    if (findingId > 0)
                    {
                        var finding = GetSelectedStandardFinding((int)TestType.Cholesterol, (int)ReadingLabels.LDL, findingId);
                        if (finding.ResultInterpretation != null) resultIntpretations.Add(finding.ResultInterpretation.Value);
                        if (finding.PathwayRecommendation != null) pathwayRecomendations.Add(finding.PathwayRecommendation.Value);
                    }

                    customerEventReadingEntities.Add(customerEventTestReadingEntity);
                }

                if (cholesterolTestResult.TriGlycerides != null)
                {
                    customerEventTestReadingEntity = CreateEventReadingEntity(cholesterolTestResult.TriGlycerides, (int)ReadingLabels.TriGlycerides, testReadingReadingPairs);
                    int triglycerides = 0;
                    long findingId = 0;

                    if (cholesterolTestResult.TriGlycerides.Finding == null)
                    {
                        customerEventTestReadingEntity.StandardFindingTestReadingId = null;
                    }
                    else if (int.TryParse(cholesterolTestResult.TriGlycerides.Reading, out triglycerides) == false)
                    {
                        findingId = cholesterolTestResult.TriGlycerides.Finding.Id;
                        customerEventTestReadingEntity.StandardFindingTestReadingId
                                = (int?)new TestResultService().GetStandardFindingTestReadingIdForStandardFinding((int)TestType.Cholesterol, (int)ReadingLabels.TriGlycerides, cholesterolTestResult.TriGlycerides.Finding.Id);
                    }
                    else
                    {
                        findingId = (new TestResultService()).GetCalculatedStandardFinding(Convert.ToInt32(cholesterolTestResult.TriGlycerides.Reading), (int)TestType.Cholesterol, (int)ReadingLabels.TriGlycerides);

                        if (cholesterolTestResult.TriGlycerides.Finding.Id == findingId)
                            customerEventTestReadingEntity.StandardFindingTestReadingId = null;
                        else
                        {
                            customerEventTestReadingEntity.StandardFindingTestReadingId
                                = (int?)new TestResultService().GetStandardFindingTestReadingIdForStandardFinding((int)TestType.Cholesterol, (int)ReadingLabels.TriGlycerides, cholesterolTestResult.TriGlycerides.Finding.Id);

                            findingId = cholesterolTestResult.TriGlycerides.Finding.Id;
                        }
                    }

                    if (findingId > 0)
                    {
                        var finding = GetSelectedStandardFinding((int)TestType.Cholesterol, (int)ReadingLabels.TriGlycerides, findingId);
                        if (finding.ResultInterpretation != null) resultIntpretations.Add(finding.ResultInterpretation.Value);
                        if (finding.PathwayRecommendation != null) pathwayRecomendations.Add(finding.PathwayRecommendation.Value);
                    }

                    customerEventReadingEntities.Add(customerEventTestReadingEntity);
                }

                if (cholesterolTestResult.TCHDLRatio != null)
                {
                    customerEventTestReadingEntity = CreateEventReadingEntity(cholesterolTestResult.TCHDLRatio, (int)ReadingLabels.TCHDLRatio, testReadingReadingPairs);
                    long findingId = 0;

                    if (cholesterolTestResult.TCHDLRatio.Finding == null)
                    {
                        customerEventTestReadingEntity.StandardFindingTestReadingId = null;
                    }
                    else if (cholesterolTestResult.TCHDLRatio.Reading != null)
                    {
                        findingId = ((new TestResultService()).GetCalculatedStandardFinding(cholesterolTestResult.TCHDLRatio.Reading, (int)TestType.Cholesterol, (int)ReadingLabels.TCHDLRatio));
                        customerEventTestReadingEntity.StandardFindingTestReadingId = (cholesterolTestResult.TCHDLRatio.Finding.Id == findingId
                                                                      ? null : (int?)new TestResultService().GetStandardFindingTestReadingIdForStandardFinding((int)TestType.Cholesterol, (int)ReadingLabels.TCHDLRatio, cholesterolTestResult.TCHDLRatio.Finding.Id));

                        findingId = findingId != cholesterolTestResult.TCHDLRatio.Finding.Id ? cholesterolTestResult.TCHDLRatio.Finding.Id : findingId;
                    }
                    else if (cholesterolTestResult.TCHDLRatio.Finding != null)
                    {
                        if (customerEventTestReadingEntity == null)
                            customerEventTestReadingEntity = CreateEventReadingEntitywithNullReading(cholesterolTestResult.TCHDLRatio, (int)ReadingLabels.TCHDLRatio, testReadingReadingPairs);

                        findingId = cholesterolTestResult.TCHDLRatio.Finding.Id;
                        customerEventTestReadingEntity.StandardFindingTestReadingId = (int?)new TestResultService().GetStandardFindingTestReadingIdForStandardFinding((int)TestType.Cholesterol, (int)ReadingLabels.TCHDLRatio, cholesterolTestResult.TCHDLRatio.Finding.Id);
                    }

                    if (findingId > 0)
                    {
                        var finding = GetSelectedStandardFinding((int)TestType.Cholesterol, (int)ReadingLabels.TCHDLRatio, findingId);
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
