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
    public class LipidTestResultFactory : TestResultFactory
    {
        private readonly string _toCheckFor = "";
        public LipidTestResultFactory(bool isMale)
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
            var allFindings = new TestResultService().GetAllStandardFindings<T>((int)TestType.Lipid, readingId);

            if (testReadingEntity.Value != null && int.TryParse(testReadingEntity.Value, out testReadingValue) == true)
            {
                var findings = (new TestResultService()).GetMultipleCalculatedStandardFinding(testReadingValue, (int)TestType.Lipid, readingId);
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
                testReading.Finding = new StandardFinding<decimal?>(Convert.ToInt64(testReadingEntity.StandardFindingTestReadingId == null ? (new TestResultService()).GetCalculatedStandardFinding(decimal.Round(value.Value, 1), (int)TestType.Lipid, readingId) : standardFindingTestReading.StandardFindingId));
            }
            else if (testReadingEntity.StandardFindingTestReadingId != null)
            {
                testReading.Finding = new StandardFinding<decimal?>(standardFindingTestReading.StandardFindingId);
            }

            if (testReading.Finding != null)
                testReading.Finding = new TestResultService().GetAllStandardFindings<decimal?>((int)TestType.Lipid, readingId).Find(standardFinding => standardFinding.Id == testReading.Finding.Id);

            return testReading;
        }

        public override TestResult CreateActualTestResult(CustomerEventScreeningTestsEntity customerEventScreeningTestsEntity)
        {
            var customerEventReadingEntities = customerEventScreeningTestsEntity.CustomerEventReading.ToList();

            var testResult = new LipidTestResult(customerEventScreeningTestsEntity.CustomerEventScreeningTestId);

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

            var glucoseData = customerEventReadingEntities.
                Where(customerEventReading => customerEventReading.TestReading.ReadingId == (int)ReadingLabels.Glucose).
                SingleOrDefault();

            if (glucoseData != null)
            {
                testResult.Glucose = CreateTestReadingforaIntValue(glucoseData, (int)ReadingLabels.Glucose, standardFindingTestReadingEntities,
                    (string.IsNullOrEmpty(glucoseData.Value) ? null : (int?)Convert.ToInt32(glucoseData.Value)));
            }

            var triglyceridesData = customerEventReadingEntities.
                    Where(customerEventReading => customerEventReading.TestReading.ReadingId == (int)ReadingLabels.TriGlycerides).
                    SingleOrDefault();

            if (triglyceridesData != null)
            {
                testResult.TriGlycerides = CreateTestReadingforaIntValue(triglyceridesData, (int)ReadingLabels.TriGlycerides, standardFindingTestReadingEntities, triglyceridesData.Value);
            }

            var altData = customerEventReadingEntities.
                    Where(customerEventReading => customerEventReading.TestReading.ReadingId == (int)ReadingLabels.ALT).
                    SingleOrDefault();

            if (altData != null)
            {
                testResult.ALT = CreateTestReadingforaIntValue(altData, (int)ReadingLabels.ALT, standardFindingTestReadingEntities, string.IsNullOrEmpty(altData.Value) ? null : (int?)Convert.ToInt32(altData.Value));
            }

            var astData = customerEventReadingEntities.Where(customerEventReading => customerEventReading.TestReading.ReadingId == (int)ReadingLabels.AST).SingleOrDefault();

            if (astData != null)
            {
                testResult.AST = CreateTestReadingforaIntValue(astData, (int)ReadingLabels.AST, standardFindingTestReadingEntities, string.IsNullOrEmpty(astData.Value) ? null : (int?)Convert.ToInt32(astData.Value));
            }

            var tchdlratioData = customerEventReadingEntities.
                Where(customerEventReading => customerEventReading.TestReading.ReadingId == (int)ReadingLabels.TCHDLRatio).
                SingleOrDefault();

            if (tchdlratioData != null)
            {
                testResult.TCHDLRatio = CreateTestReadingforaDecimalValue(tchdlratioData, (int)ReadingLabels.TCHDLRatio, standardFindingTestReadingEntities,
                    (string.IsNullOrEmpty(tchdlratioData.Value) ? null : (decimal?)Convert.ToDecimal(tchdlratioData.Value)));
            }

            var hba1c = customerEventReadingEntities.
                Where(customerEventReading => customerEventReading.TestReading.ReadingId == (int)ReadingLabels.Hba1c).
                SingleOrDefault();

            if (hba1c != null)
            {
                testResult.HbA1c = new ResultReading<decimal?>(hba1c.CustomerEventReadingId)
                {
                    Label = ReadingLabels.Hba1c,
                    Reading = !string.IsNullOrEmpty(hba1c.Value)
                            ? Convert.ToDecimal(hba1c.Value)
                            : default(decimal)
                };

            }

            return testResult;
        }

        public override CustomerEventScreeningTestsEntity CreateActualTestResultEntity(TestResult testResult, List<OrderedPair<int, int>> testReadingReadingPairs)
        {
            var lipidTestResult = testResult as LipidTestResult;
            var customerEventScreeningTestsEntity = new CustomerEventScreeningTestsEntity(testResult.Id) { TestId = (int)TestType.Lipid };
            var resultIntpretations = new List<long>();
            var pathwayRecomendations = new List<long>();

            var customerEventReadingEntities = new List<CustomerEventReadingEntity>();
            if (lipidTestResult != null)
            {
                CustomerEventReadingEntity customerEventTestReadingEntity = null;
                if (lipidTestResult.TotalCholestrol != null)
                {
                    customerEventTestReadingEntity = CreateEventReadingEntity(lipidTestResult.TotalCholestrol, (int)ReadingLabels.TotalCholestrol, testReadingReadingPairs);

                    int tCholestrol = 0;
                    long findingId = 0;

                    if (lipidTestResult.TotalCholestrol.Finding == null)
                    {
                        customerEventTestReadingEntity.StandardFindingTestReadingId = null;
                    }
                    else if (int.TryParse(lipidTestResult.TotalCholestrol.Reading, out tCholestrol) == false)
                    {
                        findingId = lipidTestResult.TotalCholestrol.Finding.Id;
                        customerEventTestReadingEntity.StandardFindingTestReadingId
                                = (int?)new TestResultService().GetStandardFindingTestReadingIdForStandardFinding((int)TestType.Lipid, (int)ReadingLabels.TotalCholestrol, lipidTestResult.TotalCholestrol.Finding.Id);
                    }
                    else
                    {
                        findingId = (new TestResultService()).GetCalculatedStandardFinding(Convert.ToInt32(lipidTestResult.TotalCholestrol.Reading), (int)TestType.Lipid, (int)ReadingLabels.TotalCholestrol);

                        if (lipidTestResult.TotalCholestrol.Finding.Id == findingId)
                            customerEventTestReadingEntity.StandardFindingTestReadingId = null;
                        else
                        {
                            findingId = lipidTestResult.TotalCholestrol.Finding.Id;
                            customerEventTestReadingEntity.StandardFindingTestReadingId
                                = (int?)new TestResultService().GetStandardFindingTestReadingIdForStandardFinding((int)TestType.Lipid, (int)ReadingLabels.TotalCholestrol, lipidTestResult.TotalCholestrol.Finding.Id);
                        }
                    }

                    if (findingId > 0)
                    {
                        var finding = GetSelectedStandardFinding((int)TestType.Lipid, (int)ReadingLabels.TotalCholestrol, findingId);
                        if (finding.ResultInterpretation != null) resultIntpretations.Add(finding.ResultInterpretation.Value);
                        if (finding.PathwayRecommendation != null) pathwayRecomendations.Add(finding.PathwayRecommendation.Value);
                    }

                    customerEventReadingEntities.Add(customerEventTestReadingEntity);
                }

                if (lipidTestResult.HDL != null)
                {
                    customerEventTestReadingEntity = CreateEventReadingEntity(lipidTestResult.HDL, (int)ReadingLabels.HDL, testReadingReadingPairs);
                    int hdl = 0;

                    long findingId = 0;
                    if (lipidTestResult.HDL.Finding == null)
                    {
                        customerEventTestReadingEntity.StandardFindingTestReadingId = null;
                    }
                    else if (int.TryParse(lipidTestResult.HDL.Reading, out hdl) == false)
                    {
                        findingId = lipidTestResult.HDL.Finding.Id;
                        customerEventTestReadingEntity.StandardFindingTestReadingId
                                = (int?)new TestResultService().GetStandardFindingTestReadingIdForStandardFinding((int)TestType.Lipid, (int)ReadingLabels.HDL, lipidTestResult.HDL.Finding.Id);
                    }
                    else
                    {
                        var allFindings = new TestResultService().GetAllStandardFindings<int>((int)TestType.Lipid, (int)ReadingLabels.HDL);

                        var findings = (new TestResultService()).GetMultipleCalculatedStandardFinding(Convert.ToInt32(lipidTestResult.HDL.Reading), (int)TestType.Lipid, (int)ReadingLabels.HDL);
                        var avFindings = allFindings.FindAll(f => f.Label.ToLower().IndexOf(_toCheckFor) == 0);
                        findingId = findings.Where(f => avFindings.Select(av => av.Id).Contains(f)).FirstOrDefault();

                        if (lipidTestResult.HDL.Finding.Id == findingId)
                            customerEventTestReadingEntity.StandardFindingTestReadingId = null;
                        else
                        {
                            customerEventTestReadingEntity.StandardFindingTestReadingId
                                = (int?)new TestResultService().GetStandardFindingTestReadingIdForStandardFinding((int)TestType.Lipid, (int)ReadingLabels.HDL, lipidTestResult.HDL.Finding.Id);
                            findingId = lipidTestResult.HDL.Finding.Id;
                        }
                    }

                    if (findingId > 0)
                    {
                        var finding = GetSelectedStandardFinding((int)TestType.Lipid, (int)ReadingLabels.HDL, findingId);
                        if (finding.ResultInterpretation != null) resultIntpretations.Add(finding.ResultInterpretation.Value);
                        if (finding.PathwayRecommendation != null) pathwayRecomendations.Add(finding.PathwayRecommendation.Value);
                    }

                    customerEventReadingEntities.Add(customerEventTestReadingEntity);
                }

                if (lipidTestResult.LDL != null)
                {
                    customerEventTestReadingEntity = CreateEventReadingEntity(lipidTestResult.LDL, (int)ReadingLabels.LDL, testReadingReadingPairs);

                    long findingId = 0;

                    if (lipidTestResult.LDL.Finding == null)
                    {
                        customerEventTestReadingEntity.StandardFindingTestReadingId = null;
                    }
                    else if (lipidTestResult.LDL.Reading != null)
                    {
                        findingId = ((new TestResultService()).GetCalculatedStandardFinding(lipidTestResult.LDL.Reading, (int)TestType.Lipid, (int)ReadingLabels.LDL));
                        customerEventTestReadingEntity.StandardFindingTestReadingId = (lipidTestResult.LDL.Finding.Id == findingId
                                                                   ? null : (int?)new TestResultService().GetStandardFindingTestReadingIdForStandardFinding((int)TestType.Lipid, (int)ReadingLabels.LDL, lipidTestResult.LDL.Finding.Id));

                        findingId = lipidTestResult.LDL.Finding.Id != findingId ? lipidTestResult.LDL.Finding.Id : findingId;
                    }
                    else if (lipidTestResult.LDL.Finding != null)
                    {
                        findingId = lipidTestResult.LDL.Finding.Id;
                        if (customerEventTestReadingEntity == null)
                            customerEventTestReadingEntity = CreateEventReadingEntitywithNullReading(lipidTestResult.LDL, (int)ReadingLabels.LDL, testReadingReadingPairs);

                        customerEventTestReadingEntity.StandardFindingTestReadingId = (int?)new TestResultService().GetStandardFindingTestReadingIdForStandardFinding((int)TestType.Lipid, (int)ReadingLabels.LDL, lipidTestResult.LDL.Finding.Id);
                    }

                    if (findingId > 0)
                    {
                        var finding = GetSelectedStandardFinding((int)TestType.Lipid, (int)ReadingLabels.LDL, findingId);
                        if (finding.ResultInterpretation != null) resultIntpretations.Add(finding.ResultInterpretation.Value);
                        if (finding.PathwayRecommendation != null) pathwayRecomendations.Add(finding.PathwayRecommendation.Value);
                    }

                    customerEventReadingEntities.Add(customerEventTestReadingEntity);
                }


                if (lipidTestResult.Glucose != null)
                {
                    customerEventTestReadingEntity = CreateEventReadingEntity(lipidTestResult.Glucose, (int)ReadingLabels.Glucose, testReadingReadingPairs);
                    long findingId = 0;

                    if (lipidTestResult.Glucose.Finding == null)
                    {
                        customerEventTestReadingEntity.StandardFindingTestReadingId = null;
                    }
                    else if (lipidTestResult.Glucose.Reading == null)
                    {
                        if (customerEventTestReadingEntity == null)
                            customerEventTestReadingEntity = CreateEventReadingEntitywithNullReading(lipidTestResult.Glucose, (int)ReadingLabels.Glucose, testReadingReadingPairs);

                        customerEventTestReadingEntity.StandardFindingTestReadingId
                                = (int?)new TestResultService().GetStandardFindingTestReadingIdForStandardFinding((int)TestType.Lipid, (int)ReadingLabels.Glucose, lipidTestResult.Glucose.Finding.Id);

                        findingId = lipidTestResult.Glucose.Finding.Id;
                    }
                    else
                    {
                        findingId = (new TestResultService()).GetCalculatedStandardFinding(Convert.ToInt32(lipidTestResult.Glucose.Reading), (int)TestType.Lipid, (int)ReadingLabels.Glucose);

                        if (lipidTestResult.Glucose.Finding.Id == findingId)
                            customerEventTestReadingEntity.StandardFindingTestReadingId = null;
                        else
                        {
                            customerEventTestReadingEntity.StandardFindingTestReadingId
                                = (int?)new TestResultService().GetStandardFindingTestReadingIdForStandardFinding((int)TestType.Lipid, (int)ReadingLabels.Glucose, lipidTestResult.Glucose.Finding.Id);

                            findingId = lipidTestResult.Glucose.Finding.Id;
                        }
                    }

                    if (findingId > 0)
                    {
                        var finding = GetSelectedStandardFinding((int)TestType.Lipid, (int)ReadingLabels.Glucose, findingId);
                        if (finding.ResultInterpretation != null) resultIntpretations.Add(finding.ResultInterpretation.Value);
                        if (finding.PathwayRecommendation != null) pathwayRecomendations.Add(finding.PathwayRecommendation.Value);
                    }

                    customerEventReadingEntities.Add(customerEventTestReadingEntity);
                }

                if (lipidTestResult.TriGlycerides != null)
                {
                    customerEventTestReadingEntity = CreateEventReadingEntity(lipidTestResult.TriGlycerides, (int)ReadingLabels.TriGlycerides, testReadingReadingPairs);
                    int triglycerides = 0;
                    long findingId = 0;

                    if (lipidTestResult.TriGlycerides.Finding == null)
                    {
                        customerEventTestReadingEntity.StandardFindingTestReadingId = null;
                    }
                    else if (int.TryParse(lipidTestResult.TriGlycerides.Reading, out triglycerides) == false)
                    {
                        findingId = lipidTestResult.TriGlycerides.Finding.Id;
                        customerEventTestReadingEntity.StandardFindingTestReadingId
                                = (int?)new TestResultService().GetStandardFindingTestReadingIdForStandardFinding((int)TestType.Lipid, (int)ReadingLabels.TriGlycerides, lipidTestResult.TriGlycerides.Finding.Id);
                    }
                    else
                    {
                        findingId = (new TestResultService()).GetCalculatedStandardFinding(Convert.ToInt32(lipidTestResult.TriGlycerides.Reading), (int)TestType.Lipid, (int)ReadingLabels.TriGlycerides);

                        if (lipidTestResult.TriGlycerides.Finding.Id == findingId)
                            customerEventTestReadingEntity.StandardFindingTestReadingId = null;
                        else
                        {
                            customerEventTestReadingEntity.StandardFindingTestReadingId
                                = (int?)new TestResultService().GetStandardFindingTestReadingIdForStandardFinding((int)TestType.Lipid, (int)ReadingLabels.TriGlycerides, lipidTestResult.TriGlycerides.Finding.Id);

                            findingId = lipidTestResult.TriGlycerides.Finding.Id;
                        }
                    }

                    if (findingId > 0)
                    {
                        var finding = GetSelectedStandardFinding((int)TestType.Lipid, (int)ReadingLabels.TriGlycerides, findingId);
                        if (finding.ResultInterpretation != null) resultIntpretations.Add(finding.ResultInterpretation.Value);
                        if (finding.PathwayRecommendation != null) pathwayRecomendations.Add(finding.PathwayRecommendation.Value);
                    }

                    customerEventReadingEntities.Add(customerEventTestReadingEntity);
                }

                if (lipidTestResult.TCHDLRatio != null)
                {
                    customerEventTestReadingEntity = CreateEventReadingEntity(lipidTestResult.TCHDLRatio, (int)ReadingLabels.TCHDLRatio, testReadingReadingPairs);
                    long findingId = 0;

                    if (lipidTestResult.TCHDLRatio.Finding == null)
                    {
                        customerEventTestReadingEntity.StandardFindingTestReadingId = null;
                    }
                    else if (lipidTestResult.TCHDLRatio.Reading != null)
                    {
                        findingId = ((new TestResultService()).GetCalculatedStandardFinding(lipidTestResult.TCHDLRatio.Reading, (int)TestType.Lipid, (int)ReadingLabels.TCHDLRatio));
                        customerEventTestReadingEntity.StandardFindingTestReadingId = (lipidTestResult.TCHDLRatio.Finding.Id == findingId
                                                                      ? null : (int?)new TestResultService().GetStandardFindingTestReadingIdForStandardFinding((int)TestType.Lipid, (int)ReadingLabels.TCHDLRatio, lipidTestResult.TCHDLRatio.Finding.Id));

                        findingId = findingId != lipidTestResult.TCHDLRatio.Finding.Id ? lipidTestResult.TCHDLRatio.Finding.Id : findingId;
                    }
                    else if (lipidTestResult.TCHDLRatio.Finding != null)
                    {
                        if (customerEventTestReadingEntity == null)
                            customerEventTestReadingEntity = CreateEventReadingEntitywithNullReading(lipidTestResult.TCHDLRatio, (int)ReadingLabels.TCHDLRatio, testReadingReadingPairs);

                        findingId = lipidTestResult.TCHDLRatio.Finding.Id;
                        customerEventTestReadingEntity.StandardFindingTestReadingId = (int?)new TestResultService().GetStandardFindingTestReadingIdForStandardFinding((int)TestType.Lipid, (int)ReadingLabels.TCHDLRatio, lipidTestResult.TCHDLRatio.Finding.Id);
                    }

                    if (findingId > 0)
                    {
                        var finding = GetSelectedStandardFinding((int)TestType.Lipid, (int)ReadingLabels.TCHDLRatio, findingId);
                        if (finding.ResultInterpretation != null) resultIntpretations.Add(finding.ResultInterpretation.Value);
                        if (finding.PathwayRecommendation != null) pathwayRecomendations.Add(finding.PathwayRecommendation.Value);
                    }

                    customerEventReadingEntities.Add(customerEventTestReadingEntity);
                }

                if (lipidTestResult.HbA1c != null)
                {
                    customerEventTestReadingEntity = CreateEventReadingEntity(lipidTestResult.HbA1c, (int)ReadingLabels.Hba1c, testReadingReadingPairs);
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
