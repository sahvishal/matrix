using System;
using System.Collections.Generic;
using System.Linq;
using Falcon.App.Core;
using Falcon.App.Core.Medical.Domain;
using Falcon.App.Core.Medical.Enum;
using Falcon.App.Infrastructure.Service;
using Falcon.Data.EntityClasses;

namespace Falcon.App.Infrastructure.Factories.Screening
{
    public class AwvAbiTestResultFactory : TestResultFactory
    {
        public override TestResult CreateActualTestResult(CustomerEventScreeningTestsEntity customerEventScreeningTestsEntity)
        {
            var customerEventReadingEntities = customerEventScreeningTestsEntity.CustomerEventReading.ToList();

            var testResult = new AwvAbiTestResult(customerEventScreeningTestsEntity.CustomerEventScreeningTestId)
            {
                LeftResultReadings = new PadTestReadings(),
                RightResultReadings = new PadTestReadings(),
                RepeatStudy = this.CreateResultReading((int)ReadingLabels.RepeatStudy, customerEventReadingEntities)
            };

            testResult.RightResultReadings.SystolicArm = CreateResultReadingforNullableInt((int)ReadingLabels.SystolicRArm, customerEventReadingEntities);
            testResult.RightResultReadings.SystolicAnkle = CreateResultReadingforNullableInt((int)ReadingLabels.SystolicRAnkle, customerEventReadingEntities);
            testResult.RightResultReadings.ABI = CreateResultReadingforNullableDecimal((int)ReadingLabels.RightABI, customerEventReadingEntities);

            testResult.LeftResultReadings.SystolicArm = CreateResultReadingforNullableInt((int)ReadingLabels.SystolicLArm, customerEventReadingEntities);
            testResult.LeftResultReadings.SystolicAnkle = CreateResultReadingforNullableInt((int)ReadingLabels.SystolicLAnkle, customerEventReadingEntities);
            testResult.LeftResultReadings.ABI = CreateResultReadingforNullableDecimal((int)ReadingLabels.LeftABI, customerEventReadingEntities);


            var standardFindings = new TestResultService().GetAllStandardFindings<decimal>((int)TestType.AwvABI);
            var standardFindingsLeftAbi = new TestResultService().GetAllStandardFindings<decimal>((int)TestType.AwvABI, (int)ReadingLabels.LeftABI);
            var standardFindingsRightAbi = new TestResultService().GetAllStandardFindings<decimal>((int)TestType.AwvABI, (int)ReadingLabels.RightABI);

            var testResultService = new TestResultService();

            StandardFinding<decimal> leftResultFinding, rightResultFinding;
            leftResultFinding = rightResultFinding = null;

            if (standardFindings == null || standardFindings.Count < 1)
            {
                standardFindings = standardFindingsLeftAbi;
            }

            int findingId = 0;
            if (testResult.LeftResultReadings.ABI != null)
            {
                findingId = testResultService.GetCalculatedStandardFinding(testResult.LeftResultReadings.ABI.Reading, (int)TestType.AwvABI, standardFindingsLeftAbi != null && standardFindingsLeftAbi.Count() > 0 ? (int?)ReadingLabels.LeftABI : null);
                leftResultFinding = standardFindings.Where(f => f.Id == findingId).SingleOrDefault();
            }

            if (testResult.RightResultReadings.ABI != null)
            {
                findingId = testResultService.GetCalculatedStandardFinding(testResult.RightResultReadings.ABI.Reading, (int)TestType.AwvABI, standardFindingsRightAbi != null && standardFindingsRightAbi.Count() > 0 ? (int?)ReadingLabels.RightABI : null);
                rightResultFinding = standardFindings.Where(f => f.Id == findingId).SingleOrDefault();
            }
            if (standardFindingsLeftAbi == null || standardFindingsLeftAbi.Count() < 1)
            {
                var customerEventTestStandardFindingEntity = customerEventScreeningTestsEntity.CustomerEventTestStandardFinding.FirstOrDefault();

                if (customerEventTestStandardFindingEntity != null)
                {
                    var standardFindingTestReadingEntity = customerEventScreeningTestsEntity.StandardFindingTestReadingCollectionViaCustomerEventTestStandardFinding.LastOrDefault();

                    var standardFindingEntity = standardFindings.ToList().FindAll(standardFinding => standardFinding.Id == standardFindingTestReadingEntity.StandardFindingId).FirstOrDefault();

                    if (standardFindingEntity != null)
                    {
                        testResult.Finding = new StandardFinding<decimal>(standardFindingEntity.Id)
                        {
                            CustomerEventStandardFindingId = customerEventTestStandardFindingEntity.CustomerEventTestStandardFindingId,
                            Label = standardFindingEntity.Label,
                            MaxValue = Convert.ToInt32(standardFindingEntity.MaxValue),
                            MinValue = Convert.ToInt32(standardFindingEntity.MinValue)
                        };
                    }
                }
                else
                {
                    testResult.Finding = GetFindingToConsider(leftResultFinding, rightResultFinding);

                    if (testResult.Finding != null)
                    {
                        var standardFinding = standardFindings.Find(finding => finding.Id == testResult.Finding.Id);
                        if (standardFinding != null)
                            testResult.Finding = standardFinding;
                    }
                }
            }
            else
            {
                var testReadingLAbiReading = customerEventReadingEntities.Where(customerEventReading => customerEventReading.TestReading.ReadingId == (int)ReadingLabels.LeftABI).SingleOrDefault();
                var testReadingRAbiReading = customerEventReadingEntities.Where(customerEventReading => customerEventReading.TestReading.ReadingId == (int)ReadingLabels.RightABI).SingleOrDefault();

                if (testReadingLAbiReading != null && testReadingLAbiReading.StandardFindingTestReadingId != null)
                {
                    var standardFindingReadingEntity = customerEventScreeningTestsEntity.StandardFindingTestReadingCollectionViaCustomerEventReading.ToList().Find(stdFindingTestReading =>
                        stdFindingTestReading.TestId == (int)TestType.AwvABI && stdFindingTestReading.ReadingId == (int)ReadingLabels.LeftABI);

                    if (standardFindingReadingEntity != null)
                        testResult.LeftResultReadings.Finding = new StandardFinding<decimal>(standardFindingReadingEntity.StandardFindingId);
                }
                else if (leftResultFinding != null)
                {
                    testResult.LeftResultReadings.Finding = leftResultFinding;
                }

                if (testResult.LeftResultReadings.Finding != null)
                    testResult.LeftResultReadings.Finding = standardFindings.Where(sf => sf.Id == testResult.LeftResultReadings.Finding.Id).SingleOrDefault();

                //-----------------------------------------------------------------------------------
                if (testReadingRAbiReading != null && testReadingRAbiReading.StandardFindingTestReadingId != null)
                {
                    var standardFindingReadingEntity = customerEventScreeningTestsEntity.StandardFindingTestReadingCollectionViaCustomerEventReading.ToList().Find(stdFindingTestReading =>
                        stdFindingTestReading.TestId == (int)TestType.AwvABI && stdFindingTestReading.ReadingId == (int)ReadingLabels.RightABI);

                    if (standardFindingReadingEntity != null)
                        testResult.RightResultReadings.Finding = new StandardFinding<decimal>(standardFindingReadingEntity.StandardFindingId);
                }
                else if (rightResultFinding != null)
                {
                    testResult.RightResultReadings.Finding = rightResultFinding;
                }

                if (testResult.RightResultReadings.Finding != null)
                    testResult.RightResultReadings.Finding = standardFindings.Where(sf => sf.Id == testResult.RightResultReadings.Finding.Id).SingleOrDefault();
            }


            return testResult;
        }


        public override CustomerEventScreeningTestsEntity CreateActualTestResultEntity(TestResult testResult, List<OrderedPair<int, int>> testReadingReadingPairs)
        {
            var awvAbiTestResult = testResult as AwvAbiTestResult;
            var customerEventScreeningTestsEntity = new CustomerEventScreeningTestsEntity(testResult.Id) { TestId = (int)TestType.AwvABI };
            var customerEventReadingEntities = new List<CustomerEventReadingEntity>();

            StandardFinding<decimal> rightResultFinding;

            StandardFinding<decimal> leftResultFinding = rightResultFinding = null;


            var standardFindingsLeftAbi = new TestResultService().GetAllStandardFindings<decimal>((int)TestType.AwvABI, (int)ReadingLabels.LeftABI);
            var standardFindingsRightAbi = new TestResultService().GetAllStandardFindings<decimal>((int)TestType.AwvABI, (int)ReadingLabels.RightABI);

            if (awvAbiTestResult != null && awvAbiTestResult.LeftResultReadings != null)
            {
                var customerEventReading = CreateEventReadingEntity(awvAbiTestResult.LeftResultReadings.SystolicArm, (int)ReadingLabels.SystolicLArm, testReadingReadingPairs);
                if (customerEventReading != null) customerEventReadingEntities.Add(customerEventReading);


                customerEventReading = CreateEventReadingEntity(awvAbiTestResult.LeftResultReadings.SystolicAnkle, (int)ReadingLabels.SystolicLAnkle, testReadingReadingPairs);
                if (customerEventReading != null) customerEventReadingEntities.Add(customerEventReading);


                customerEventReading = CreateEventReadingEntity(awvAbiTestResult.LeftResultReadings.ABI, (int)ReadingLabels.LeftABI, testReadingReadingPairs);
                if (customerEventReading != null)
                {
                    leftResultFinding = new StandardFinding<decimal>((new TestResultService()).GetCalculatedStandardFinding(awvAbiTestResult.LeftResultReadings.ABI.Reading, (int)TestType.AwvABI, standardFindingsLeftAbi != null && standardFindingsLeftAbi.Count() > 0 ? (int?)ReadingLabels.LeftABI : null));
                    if (awvAbiTestResult.LeftResultReadings.Finding != null && awvAbiTestResult.LeftResultReadings.Finding.Id > 0 && awvAbiTestResult.LeftResultReadings.Finding.Id != leftResultFinding.Id)
                    {
                        customerEventReading.StandardFindingTestReadingId = (int?)new TestResultService().GetStandardFindingTestReadingIdForStandardFinding((int)TestType.AwvABI, (int)ReadingLabels.LeftABI, awvAbiTestResult.LeftResultReadings.Finding.Id);
                    }

                    customerEventReadingEntities.Add(customerEventReading);
                }
                else if (awvAbiTestResult.LeftResultReadings.Finding != null && awvAbiTestResult.LeftResultReadings.Finding.Id > 0)
                {
                    customerEventReading = CreateEventReadingEntity(awvAbiTestResult.LeftResultReadings.ABI ?? new ResultReading<decimal?> { ReadingSource = ReadingSource.Manual, RecorderMetaData = testResult.DataRecorderMetaData },
                                                                        (int)ReadingLabels.LeftABI, testReadingReadingPairs);

                    customerEventReading.StandardFindingTestReadingId = (int?)new TestResultService().GetStandardFindingTestReadingIdForStandardFinding((int)TestType.AwvABI, (int)ReadingLabels.LeftABI, awvAbiTestResult.LeftResultReadings.Finding.Id);

                    customerEventReadingEntities.Add(customerEventReading);
                }
            }

            if (awvAbiTestResult != null && awvAbiTestResult.RightResultReadings != null)
            {
                var customerEventReading = CreateEventReadingEntity(awvAbiTestResult.RightResultReadings.SystolicArm, (int)ReadingLabels.SystolicRArm, testReadingReadingPairs);
                if (customerEventReading != null) customerEventReadingEntities.Add(customerEventReading);

                customerEventReading = CreateEventReadingEntity(awvAbiTestResult.RightResultReadings.SystolicAnkle, (int)ReadingLabels.SystolicRAnkle, testReadingReadingPairs);
                if (customerEventReading != null) customerEventReadingEntities.Add(customerEventReading);

                customerEventReading = CreateEventReadingEntity(awvAbiTestResult.RightResultReadings.ABI, (int)ReadingLabels.RightABI, testReadingReadingPairs);

                if (customerEventReading != null)
                {
                    rightResultFinding = new StandardFinding<decimal>((new TestResultService()).GetCalculatedStandardFinding(awvAbiTestResult.RightResultReadings.ABI.Reading, (int)TestType.AwvABI, standardFindingsRightAbi != null && standardFindingsRightAbi.Count() > 0 ? (int?)ReadingLabels.RightABI : null));
                    if (awvAbiTestResult.RightResultReadings.Finding != null && awvAbiTestResult.RightResultReadings.Finding.Id > 0 && awvAbiTestResult.RightResultReadings.Finding.Id != rightResultFinding.Id)
                    {
                        customerEventReading.StandardFindingTestReadingId = (int?)new TestResultService().GetStandardFindingTestReadingIdForStandardFinding((int)TestType.AwvABI, (int)ReadingLabels.RightABI, awvAbiTestResult.RightResultReadings.Finding.Id);
                    }

                    customerEventReadingEntities.Add(customerEventReading);
                }
                else if (awvAbiTestResult.RightResultReadings.Finding != null && awvAbiTestResult.RightResultReadings.Finding.Id > 0)
                {
                    customerEventReading = CreateEventReadingEntity(awvAbiTestResult.RightResultReadings.ABI ?? new ResultReading<decimal?> { ReadingSource = ReadingSource.Manual, RecorderMetaData = testResult.DataRecorderMetaData },
                                                                        (int)ReadingLabels.RightABI, testReadingReadingPairs);

                    customerEventReading.StandardFindingTestReadingId = (int?)new TestResultService().GetStandardFindingTestReadingIdForStandardFinding((int)TestType.AwvABI, (int)ReadingLabels.RightABI, awvAbiTestResult.RightResultReadings.Finding.Id);

                    customerEventReadingEntities.Add(customerEventReading);
                }
            }

            if (awvAbiTestResult != null && awvAbiTestResult.RepeatStudy != null)
            {
                var customerEventReading = CreateEventReadingEntity(awvAbiTestResult.RepeatStudy, (int)ReadingLabels.RepeatStudy, testReadingReadingPairs);
                customerEventReadingEntities.Add(customerEventReading);
            }


            testResult.ResultInterpretation = null;

            var findingToConsider = GetFindingToConsider(leftResultFinding, rightResultFinding);

            if (awvAbiTestResult != null && awvAbiTestResult.Finding != null && (standardFindingsRightAbi == null || standardFindingsRightAbi.Count() < 1))
            {
                if (findingToConsider == null || findingToConsider.Id != awvAbiTestResult.Finding.Id)
                {
                    customerEventScreeningTestsEntity.CustomerEventTestStandardFinding.Add(
                        new CustomerEventTestStandardFindingEntity(awvAbiTestResult.Finding.CustomerEventStandardFindingId)
                        {
                            StandardFindingTestReadingId = (int?)new TestResultService().GetStandardFindingTestReadingIdForStandardFinding((int)TestType.AwvABI, null, awvAbiTestResult.Finding.Id)
                        });

                    findingToConsider = awvAbiTestResult.Finding;
                }
            }

            if (findingToConsider != null)
            {
                var finding = GetSelectedStandardFinding((int)TestType.AwvABI, (standardFindingsRightAbi != null && standardFindingsRightAbi.Count() > 0 ? (int?)ReadingLabels.RightABI : null), findingToConsider.Id);

                if (testResult.ResultStatus.StateNumber == (int)TestResultStateNumber.Evaluated || testResult.ResultStatus.StateNumber == (int)NewTestResultStateNumber.Evaluated)
                {
                    testResult.ResultInterpretation = finding.ResultInterpretation;
                    testResult.PathwayRecommendation = finding.PathwayRecommendation;
                }
            }

            if (customerEventReadingEntities.Count > 0)
                customerEventScreeningTestsEntity.CustomerEventReading.AddRange(customerEventReadingEntities);

            return customerEventScreeningTestsEntity;
        }

        private static StandardFinding<decimal> GetFindingToConsider(StandardFinding<decimal> leftResultFinding, StandardFinding<decimal> rightResultFinding)
        {
            if (rightResultFinding != null && leftResultFinding != null)
            {
                if (rightResultFinding.WorstCaseOrder >= leftResultFinding.WorstCaseOrder) return rightResultFinding;
                return leftResultFinding;
            }

            if (rightResultFinding != null) return rightResultFinding;

            return leftResultFinding;
        }
    }
}
