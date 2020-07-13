using System;
using System.Collections.Generic;
using System.Linq;
using Falcon.App.Core;
using Falcon.App.Core.Application.Domain;
using Falcon.App.Core.Domain;
using Falcon.App.Core.Extensions;
using Falcon.App.Core.Medical.Domain;
using Falcon.App.Core.Medical.Enum;
using Falcon.App.Core.Users.Domain;
using Falcon.App.Infrastructure.Service;
using Falcon.Data.EntityClasses;

namespace Falcon.App.Infrastructure.Factories.Screening
{
    public class MyBioAssessmentTestResultFactory : TestResultFactory
    {
        private readonly string _toCheckFor = "";

        public MyBioAssessmentTestResultFactory(bool isMale)
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
            var allFindings = new TestResultService().GetAllStandardFindings<T>((int)TestType.MyBioCheckAssessment, readingId);

            if (testReadingEntity.Value != null && int.TryParse(testReadingEntity.Value, out testReadingValue) == true)
            {
                var findings = (new TestResultService()).GetMultipleCalculatedStandardFinding(testReadingValue, (int)TestType.MyBioCheckAssessment, readingId);
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
                testReading.Finding = new StandardFinding<decimal?>(Convert.ToInt64(testReadingEntity.StandardFindingTestReadingId == null ? (new TestResultService()).GetCalculatedStandardFinding(decimal.Round(value.Value, 1), (int)TestType.MyBioCheckAssessment, readingId) : standardFindingTestReading.StandardFindingId));
            }
            else if (testReadingEntity.StandardFindingTestReadingId != null)
            {
                testReading.Finding = new StandardFinding<decimal?>(standardFindingTestReading.StandardFindingId);
            }

            if (testReading.Finding != null)
                testReading.Finding = new TestResultService().GetAllStandardFindings<decimal?>((int)TestType.MyBioCheckAssessment, readingId).Find(standardFinding => standardFinding.Id == testReading.Finding.Id);

            return testReading;
        }

        public override TestResult CreateActualTestResult(CustomerEventScreeningTestsEntity customerEventScreeningTestsEntity)
        {
            var customerEventReadingEntities = customerEventScreeningTestsEntity.CustomerEventReading.ToList();

            var testResult = new MyBioAssessmentTestResult(customerEventScreeningTestsEntity.CustomerEventScreeningTestId);

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
                testResult.Hdl = CreateTestReadingforaIntValue(hdlData, (int)ReadingLabels.HDL, standardFindingTestReadingEntities, hdlData.Value);
            }

            var ldlData = customerEventReadingEntities.
                Where(customerEventReading => customerEventReading.TestReading.ReadingId == (int)ReadingLabels.LDL).
                SingleOrDefault();

            if (ldlData != null)
            {
                testResult.Ldl = CreateTestReadingforaIntValue(ldlData, (int)ReadingLabels.LDL, standardFindingTestReadingEntities, (string.IsNullOrEmpty(ldlData.Value) ? null : (int?)Convert.ToInt32(ldlData.Value)));
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


            var tchdlratioData = customerEventReadingEntities.
                Where(customerEventReading => customerEventReading.TestReading.ReadingId == (int)ReadingLabels.TCHDLRatio).
                SingleOrDefault();

            if (tchdlratioData != null)
            {
                testResult.TcHdlRatio = CreateTestReadingforaDecimalValue(tchdlratioData, (int)ReadingLabels.TCHDLRatio, standardFindingTestReadingEntities,
                    (string.IsNullOrEmpty(tchdlratioData.Value) ? null : (decimal?)Convert.ToDecimal(tchdlratioData.Value)));
            }


            return testResult;
        }

        public override CustomerEventScreeningTestsEntity CreateActualTestResultEntity(TestResult testResult, List<OrderedPair<int, int>> testReadingReadingPairs)
        {
            var mybioAssessmentTestResult = testResult as MyBioAssessmentTestResult;
            var customerEventScreeningTestsEntity = new CustomerEventScreeningTestsEntity(testResult.Id) { TestId = (int)TestType.MyBioCheckAssessment };
            var resultIntpretations = new List<long>();
            var pathwayRecomendations = new List<long>();

            var customerEventReadingEntities = new List<CustomerEventReadingEntity>();
            if (mybioAssessmentTestResult != null)
            {
                CustomerEventReadingEntity customerEventTestReadingEntity = null;
                if (mybioAssessmentTestResult.TotalCholestrol != null)
                {
                    customerEventTestReadingEntity = CreateEventReadingEntity(mybioAssessmentTestResult.TotalCholestrol, (int)ReadingLabels.TotalCholestrol, testReadingReadingPairs);

                    int tCholestrol = 0;
                    long findingId = 0;

                    if (mybioAssessmentTestResult.TotalCholestrol.Finding == null)
                    {
                        customerEventTestReadingEntity.StandardFindingTestReadingId = null;
                    }
                    else if (int.TryParse(mybioAssessmentTestResult.TotalCholestrol.Reading, out tCholestrol) == false)
                    {
                        findingId = mybioAssessmentTestResult.TotalCholestrol.Finding.Id;
                        customerEventTestReadingEntity.StandardFindingTestReadingId
                            = (int?)new TestResultService().GetStandardFindingTestReadingIdForStandardFinding((int)TestType.MyBioCheckAssessment, (int)ReadingLabels.TotalCholestrol, mybioAssessmentTestResult.TotalCholestrol.Finding.Id);
                    }
                    else
                    {
                        findingId = (new TestResultService()).GetCalculatedStandardFinding(Convert.ToInt32(mybioAssessmentTestResult.TotalCholestrol.Reading), (int)TestType.MyBioCheckAssessment, (int)ReadingLabels.TotalCholestrol);

                        if (mybioAssessmentTestResult.TotalCholestrol.Finding.Id == findingId)
                            customerEventTestReadingEntity.StandardFindingTestReadingId = null;
                        else
                        {
                            findingId = mybioAssessmentTestResult.TotalCholestrol.Finding.Id;
                            customerEventTestReadingEntity.StandardFindingTestReadingId
                                = (int?)new TestResultService().GetStandardFindingTestReadingIdForStandardFinding((int)TestType.MyBioCheckAssessment, (int)ReadingLabels.TotalCholestrol, mybioAssessmentTestResult.TotalCholestrol.Finding.Id);
                        }
                    }

                    if (findingId > 0)
                    {
                        var finding = GetSelectedStandardFinding((int)TestType.MyBioCheckAssessment, (int)ReadingLabels.TotalCholestrol, findingId);
                        if (finding.ResultInterpretation != null) resultIntpretations.Add(finding.ResultInterpretation.Value);
                        if (finding.PathwayRecommendation != null) pathwayRecomendations.Add(finding.PathwayRecommendation.Value);
                    }

                    customerEventReadingEntities.Add(customerEventTestReadingEntity);
                }

                if (mybioAssessmentTestResult.Hdl != null)
                {
                    customerEventTestReadingEntity = CreateEventReadingEntity(mybioAssessmentTestResult.Hdl, (int)ReadingLabels.HDL, testReadingReadingPairs);
                    int hdl = 0;

                    long findingId = 0;
                    if (mybioAssessmentTestResult.Hdl.Finding == null)
                    {
                        customerEventTestReadingEntity.StandardFindingTestReadingId = null;
                    }
                    else if (int.TryParse(mybioAssessmentTestResult.Hdl.Reading, out hdl) == false)
                    {
                        findingId = mybioAssessmentTestResult.Hdl.Finding.Id;
                        customerEventTestReadingEntity.StandardFindingTestReadingId
                            = (int?)new TestResultService().GetStandardFindingTestReadingIdForStandardFinding((int)TestType.MyBioCheckAssessment, (int)ReadingLabels.HDL, mybioAssessmentTestResult.Hdl.Finding.Id);
                    }
                    else
                    {
                        var allFindings = new TestResultService().GetAllStandardFindings<int>((int)TestType.MyBioCheckAssessment, (int)ReadingLabels.HDL);

                        var findings = (new TestResultService()).GetMultipleCalculatedStandardFinding(Convert.ToInt32(mybioAssessmentTestResult.Hdl.Reading), (int)TestType.MyBioCheckAssessment, (int)ReadingLabels.HDL);
                        var avFindings = allFindings.FindAll(f => f.Label.ToLower().IndexOf(_toCheckFor) == 0);
                        findingId = findings.Where(f => avFindings.Select(av => av.Id).Contains(f)).FirstOrDefault();

                        if (mybioAssessmentTestResult.Hdl.Finding.Id == findingId)
                            customerEventTestReadingEntity.StandardFindingTestReadingId = null;
                        else
                        {
                            customerEventTestReadingEntity.StandardFindingTestReadingId
                                = (int?)new TestResultService().GetStandardFindingTestReadingIdForStandardFinding((int)TestType.MyBioCheckAssessment, (int)ReadingLabels.HDL, mybioAssessmentTestResult.Hdl.Finding.Id);
                            findingId = mybioAssessmentTestResult.Hdl.Finding.Id;
                        }
                    }

                    if (findingId > 0)
                    {
                        var finding = GetSelectedStandardFinding((int)TestType.MyBioCheckAssessment, (int)ReadingLabels.HDL, findingId);
                        if (finding.ResultInterpretation != null) resultIntpretations.Add(finding.ResultInterpretation.Value);
                        if (finding.PathwayRecommendation != null) pathwayRecomendations.Add(finding.PathwayRecommendation.Value);
                    }

                    customerEventReadingEntities.Add(customerEventTestReadingEntity);
                }

                if (mybioAssessmentTestResult.Ldl != null)
                {
                    customerEventTestReadingEntity = CreateEventReadingEntity(mybioAssessmentTestResult.Ldl, (int)ReadingLabels.LDL, testReadingReadingPairs);

                    long findingId = 0;

                    if (mybioAssessmentTestResult.Ldl.Finding == null)
                    {
                        customerEventTestReadingEntity.StandardFindingTestReadingId = null;
                    }
                    else if (mybioAssessmentTestResult.Ldl.Reading != null)
                    {
                        findingId = ((new TestResultService()).GetCalculatedStandardFinding(mybioAssessmentTestResult.Ldl.Reading, (int)TestType.MyBioCheckAssessment, (int)ReadingLabels.LDL));
                        customerEventTestReadingEntity.StandardFindingTestReadingId = (mybioAssessmentTestResult.Ldl.Finding.Id == findingId
                            ? null : (int?)new TestResultService().GetStandardFindingTestReadingIdForStandardFinding((int)TestType.MyBioCheckAssessment, (int)ReadingLabels.LDL, mybioAssessmentTestResult.Ldl.Finding.Id));

                        findingId = mybioAssessmentTestResult.Ldl.Finding.Id != findingId ? mybioAssessmentTestResult.Ldl.Finding.Id : findingId;
                    }
                    else if (mybioAssessmentTestResult.Ldl.Finding != null)
                    {
                        findingId = mybioAssessmentTestResult.Ldl.Finding.Id;
                        if (customerEventTestReadingEntity == null)
                            customerEventTestReadingEntity = CreateEventReadingEntitywithNullReading(mybioAssessmentTestResult.Ldl, (int)ReadingLabels.LDL, testReadingReadingPairs);

                        customerEventTestReadingEntity.StandardFindingTestReadingId = (int?)new TestResultService().GetStandardFindingTestReadingIdForStandardFinding((int)TestType.MyBioCheckAssessment, (int)ReadingLabels.LDL, mybioAssessmentTestResult.Ldl.Finding.Id);
                    }

                    if (findingId > 0)
                    {
                        var finding = GetSelectedStandardFinding((int)TestType.MyBioCheckAssessment, (int)ReadingLabels.LDL, findingId);
                        if (finding.ResultInterpretation != null) resultIntpretations.Add(finding.ResultInterpretation.Value);
                        if (finding.PathwayRecommendation != null) pathwayRecomendations.Add(finding.PathwayRecommendation.Value);
                    }

                    customerEventReadingEntities.Add(customerEventTestReadingEntity);
                }


                if (mybioAssessmentTestResult.Glucose != null)
                {
                    customerEventTestReadingEntity = CreateEventReadingEntity(mybioAssessmentTestResult.Glucose, (int)ReadingLabels.Glucose, testReadingReadingPairs);
                    long findingId = 0;

                    if (mybioAssessmentTestResult.Glucose.Finding == null)
                    {
                        customerEventTestReadingEntity.StandardFindingTestReadingId = null;
                    }
                    else if (mybioAssessmentTestResult.Glucose.Reading == null)
                    {
                        if (customerEventTestReadingEntity == null)
                            customerEventTestReadingEntity = CreateEventReadingEntitywithNullReading(mybioAssessmentTestResult.Glucose, (int)ReadingLabels.Glucose, testReadingReadingPairs);

                        customerEventTestReadingEntity.StandardFindingTestReadingId
                            = (int?)new TestResultService().GetStandardFindingTestReadingIdForStandardFinding((int)TestType.MyBioCheckAssessment, (int)ReadingLabels.Glucose, mybioAssessmentTestResult.Glucose.Finding.Id);

                        findingId = mybioAssessmentTestResult.Glucose.Finding.Id;
                    }
                    else
                    {
                        findingId = (new TestResultService()).GetCalculatedStandardFinding(Convert.ToInt32(mybioAssessmentTestResult.Glucose.Reading), (int)TestType.MyBioCheckAssessment, (int)ReadingLabels.Glucose);

                        if (mybioAssessmentTestResult.Glucose.Finding.Id == findingId)
                            customerEventTestReadingEntity.StandardFindingTestReadingId = null;
                        else
                        {
                            customerEventTestReadingEntity.StandardFindingTestReadingId
                                = (int?)new TestResultService().GetStandardFindingTestReadingIdForStandardFinding((int)TestType.MyBioCheckAssessment, (int)ReadingLabels.Glucose, mybioAssessmentTestResult.Glucose.Finding.Id);

                            findingId = mybioAssessmentTestResult.Glucose.Finding.Id;
                        }
                    }

                    if (findingId > 0)
                    {
                        var finding = GetSelectedStandardFinding((int)TestType.MyBioCheckAssessment, (int)ReadingLabels.Glucose, findingId);
                        if (finding.ResultInterpretation != null) resultIntpretations.Add(finding.ResultInterpretation.Value);
                        if (finding.PathwayRecommendation != null) pathwayRecomendations.Add(finding.PathwayRecommendation.Value);
                    }

                    customerEventReadingEntities.Add(customerEventTestReadingEntity);
                }

                if (mybioAssessmentTestResult.TriGlycerides != null)
                {
                    customerEventTestReadingEntity = CreateEventReadingEntity(mybioAssessmentTestResult.TriGlycerides, (int)ReadingLabels.TriGlycerides, testReadingReadingPairs);
                    int triglycerides = 0;
                    long findingId = 0;

                    if (mybioAssessmentTestResult.TriGlycerides.Finding == null)
                    {
                        customerEventTestReadingEntity.StandardFindingTestReadingId = null;
                    }
                    else if (int.TryParse(mybioAssessmentTestResult.TriGlycerides.Reading, out triglycerides) == false)
                    {
                        findingId = mybioAssessmentTestResult.TriGlycerides.Finding.Id;
                        customerEventTestReadingEntity.StandardFindingTestReadingId
                            = (int?)new TestResultService().GetStandardFindingTestReadingIdForStandardFinding((int)TestType.MyBioCheckAssessment, (int)ReadingLabels.TriGlycerides, mybioAssessmentTestResult.TriGlycerides.Finding.Id);
                    }
                    else
                    {
                        findingId = (new TestResultService()).GetCalculatedStandardFinding(Convert.ToInt32(mybioAssessmentTestResult.TriGlycerides.Reading), (int)TestType.MyBioCheckAssessment, (int)ReadingLabels.TriGlycerides);

                        if (mybioAssessmentTestResult.TriGlycerides.Finding.Id == findingId)
                            customerEventTestReadingEntity.StandardFindingTestReadingId = null;
                        else
                        {
                            customerEventTestReadingEntity.StandardFindingTestReadingId
                                = (int?)new TestResultService().GetStandardFindingTestReadingIdForStandardFinding((int)TestType.MyBioCheckAssessment, (int)ReadingLabels.TriGlycerides, mybioAssessmentTestResult.TriGlycerides.Finding.Id);

                            findingId = mybioAssessmentTestResult.TriGlycerides.Finding.Id;
                        }
                    }

                    if (findingId > 0)
                    {
                        var finding = GetSelectedStandardFinding((int)TestType.MyBioCheckAssessment, (int)ReadingLabels.TriGlycerides, findingId);
                        if (finding.ResultInterpretation != null) resultIntpretations.Add(finding.ResultInterpretation.Value);
                        if (finding.PathwayRecommendation != null) pathwayRecomendations.Add(finding.PathwayRecommendation.Value);
                    }

                    customerEventReadingEntities.Add(customerEventTestReadingEntity);
                }

                if (mybioAssessmentTestResult.TcHdlRatio != null)
                {
                    customerEventTestReadingEntity = CreateEventReadingEntity(mybioAssessmentTestResult.TcHdlRatio, (int)ReadingLabels.TCHDLRatio, testReadingReadingPairs);
                    long findingId = 0;

                    if (mybioAssessmentTestResult.TcHdlRatio.Finding == null)
                    {
                        customerEventTestReadingEntity.StandardFindingTestReadingId = null;
                    }
                    else if (mybioAssessmentTestResult.TcHdlRatio.Reading != null)
                    {
                        findingId = ((new TestResultService()).GetCalculatedStandardFinding(mybioAssessmentTestResult.TcHdlRatio.Reading, (int)TestType.MyBioCheckAssessment, (int)ReadingLabels.TCHDLRatio));
                        customerEventTestReadingEntity.StandardFindingTestReadingId = (mybioAssessmentTestResult.TcHdlRatio.Finding.Id == findingId
                            ? null : (int?)new TestResultService().GetStandardFindingTestReadingIdForStandardFinding((int)TestType.MyBioCheckAssessment, (int)ReadingLabels.TCHDLRatio, mybioAssessmentTestResult.TcHdlRatio.Finding.Id));

                        findingId = findingId != mybioAssessmentTestResult.TcHdlRatio.Finding.Id ? mybioAssessmentTestResult.TcHdlRatio.Finding.Id : findingId;
                    }
                    else if (mybioAssessmentTestResult.TcHdlRatio.Finding != null)
                    {
                        if (customerEventTestReadingEntity == null)
                            customerEventTestReadingEntity = CreateEventReadingEntitywithNullReading(mybioAssessmentTestResult.TcHdlRatio, (int)ReadingLabels.TCHDLRatio, testReadingReadingPairs);

                        findingId = mybioAssessmentTestResult.TcHdlRatio.Finding.Id;
                        customerEventTestReadingEntity.StandardFindingTestReadingId = (int?)new TestResultService().GetStandardFindingTestReadingIdForStandardFinding((int)TestType.MyBioCheckAssessment, (int)ReadingLabels.TCHDLRatio, mybioAssessmentTestResult.TcHdlRatio.Finding.Id);
                    }

                    if (findingId > 0)
                    {
                        var finding = GetSelectedStandardFinding((int)TestType.MyBioCheckAssessment, (int)ReadingLabels.TCHDLRatio, findingId);
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