using System;
using System.Collections.Generic;
using System.Linq;
using Falcon.App.Core;
using Falcon.App.Core.Application.Domain;
using Falcon.App.Core.Medical.Domain;
using Falcon.App.Core.Medical.Enum;
using Falcon.App.Infrastructure.Service;
using Falcon.Data.EntityClasses;

namespace Falcon.App.Infrastructure.Factories.Screening
{
    public class FloChecABITestResultFactory : TestResultFactory
    {

        public override TestResult CreateActualTestResult(CustomerEventScreeningTestsEntity customerEventScreeningTestsEntity)
        {
            var customerEventReadingEntities = customerEventScreeningTestsEntity.CustomerEventReading.ToList();

            var testResult = new FloChecABITestResult(customerEventScreeningTestsEntity.CustomerEventScreeningTestId)
            {
                LeftResultReadings = new FloChecABIReadings(),
                RightResultReadings = new FloChecABIReadings(),
                PencilDopplerUsed = this.CreateResultReading((int)ReadingLabels.PencilDopplerUsed, customerEventReadingEntities),

                RepeatStudy = this.CreateResultReading((int)ReadingLabels.RepeatStudy, customerEventReadingEntities)
            };


            testResult.RightResultReadings.ABI = CreateResultReadingforNullableDecimal((int)ReadingLabels.RightABI, customerEventReadingEntities);
            testResult.LeftResultReadings.ABI = CreateResultReadingforNullableDecimal((int)ReadingLabels.LeftABI, customerEventReadingEntities);

            testResult.RightResultReadings.BFI = CreateResultReadingforNullableDecimal((int)ReadingLabels.RightHandBFI, customerEventReadingEntities);
            testResult.LeftResultReadings.BFI = CreateResultReadingforNullableDecimal((int)ReadingLabels.LeftHandBFI, customerEventReadingEntities);

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

            var standardFindings = new TestResultService().GetAllStandardFindings<decimal>((int)TestType.FloChecABI);
            var standardFindingsLeftAbi = new TestResultService().GetAllStandardFindings<decimal>((int)TestType.FloChecABI, (int)ReadingLabels.LeftABI);
            var standardFindingsRightAbi = new TestResultService().GetAllStandardFindings<decimal>((int)TestType.FloChecABI, (int)ReadingLabels.RightABI);
            
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
                findingId = testResultService.GetCalculatedStandardFinding(testResult.LeftResultReadings.ABI.Reading, (int)TestType.FloChecABI, standardFindingsLeftAbi != null && standardFindingsLeftAbi.Count() > 0 ? (int?)ReadingLabels.LeftABI : null);
                leftResultFinding = standardFindings.Where(f => f.Id == findingId).SingleOrDefault();
            }

            if (testResult.RightResultReadings.ABI != null)
            {
                findingId = testResultService.GetCalculatedStandardFinding(testResult.RightResultReadings.ABI.Reading, (int)TestType.FloChecABI, standardFindingsRightAbi != null && standardFindingsRightAbi.Count() > 0 ? (int?)ReadingLabels.RightABI : null);
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
                        stdFindingTestReading.TestId == (int)TestType.FloChecABI && stdFindingTestReading.ReadingId == (int)ReadingLabels.LeftABI);

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
                        stdFindingTestReading.TestId == (int)TestType.FloChecABI && stdFindingTestReading.ReadingId == (int)ReadingLabels.RightABI);

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
            var floChecAbiTestResult = testResult as FloChecABITestResult;
            var customerEventScreeningTestsEntity = new CustomerEventScreeningTestsEntity(testResult.Id) { TestId = (int)TestType.FloChecABI };
            var customerEventReadingEntities = new List<CustomerEventReadingEntity>();

            StandardFinding<decimal> rightResultFinding;

            StandardFinding<decimal> leftResultFinding = rightResultFinding = null;


            var standardFindingsLeftAbi = new TestResultService().GetAllStandardFindings<decimal>((int)TestType.FloChecABI, (int)ReadingLabels.LeftABI);
            var standardFindingsRightAbi = new TestResultService().GetAllStandardFindings<decimal>((int)TestType.FloChecABI, (int)ReadingLabels.RightABI);



            if (floChecAbiTestResult != null && floChecAbiTestResult.LeftResultReadings != null)
            {
                
                var customerEventReading = CreateEventReadingEntity(floChecAbiTestResult.LeftResultReadings.BFI, (int)ReadingLabels.LeftHandBFI, testReadingReadingPairs);
                if (customerEventReading != null) customerEventReadingEntities.Add(customerEventReading);

                customerEventReading = CreateEventReadingEntity(floChecAbiTestResult.LeftResultReadings.ABI, (int)ReadingLabels.LeftABI, testReadingReadingPairs);
                if (customerEventReading != null)
                {
                    leftResultFinding = new StandardFinding<decimal>((new TestResultService()).GetCalculatedStandardFinding(floChecAbiTestResult.LeftResultReadings.ABI.Reading, (int)TestType.FloChecABI, standardFindingsLeftAbi != null && standardFindingsLeftAbi.Count() > 0 ? (int?)ReadingLabels.LeftABI : null));
                    if (floChecAbiTestResult.LeftResultReadings.Finding != null && floChecAbiTestResult.LeftResultReadings.Finding.Id > 0 && floChecAbiTestResult.LeftResultReadings.Finding.Id != leftResultFinding.Id)
                    {
                        customerEventReading.StandardFindingTestReadingId = (int?)new TestResultService().GetStandardFindingTestReadingIdForStandardFinding((int)TestType.FloChecABI, (int)ReadingLabels.LeftABI, floChecAbiTestResult.LeftResultReadings.Finding.Id);
                    }

                    customerEventReadingEntities.Add(customerEventReading);
                }
                else if (floChecAbiTestResult.LeftResultReadings.Finding != null && floChecAbiTestResult.LeftResultReadings.Finding.Id > 0)
                {
                    customerEventReading = CreateEventReadingEntity(floChecAbiTestResult.LeftResultReadings.ABI ?? new ResultReading<decimal?> { ReadingSource = ReadingSource.Manual, RecorderMetaData = testResult.DataRecorderMetaData },
                        (int)ReadingLabels.LeftABI, testReadingReadingPairs);

                    customerEventReading.StandardFindingTestReadingId = (int?)new TestResultService().GetStandardFindingTestReadingIdForStandardFinding((int)TestType.FloChecABI, (int)ReadingLabels.LeftABI, floChecAbiTestResult.LeftResultReadings.Finding.Id);

                    customerEventReadingEntities.Add(customerEventReading);
                }
            }

            if (floChecAbiTestResult != null && floChecAbiTestResult.RightResultReadings != null)
            {

                var customerEventReading = CreateEventReadingEntity(floChecAbiTestResult.RightResultReadings.BFI, (int)ReadingLabels.RightHandBFI, testReadingReadingPairs);
                if (customerEventReading != null) customerEventReadingEntities.Add(customerEventReading);

                 customerEventReading = CreateEventReadingEntity(floChecAbiTestResult.RightResultReadings.ABI, (int)ReadingLabels.RightABI, testReadingReadingPairs);

                if (customerEventReading != null)
                {
                    rightResultFinding = new StandardFinding<decimal>((new TestResultService()).GetCalculatedStandardFinding(floChecAbiTestResult.RightResultReadings.ABI.Reading, (int)TestType.FloChecABI, standardFindingsRightAbi != null && standardFindingsRightAbi.Count() > 0 ? (int?)ReadingLabels.RightABI : null));
                    if (floChecAbiTestResult.RightResultReadings.Finding != null && floChecAbiTestResult.RightResultReadings.Finding.Id > 0 && floChecAbiTestResult.RightResultReadings.Finding.Id != rightResultFinding.Id)
                    {
                        customerEventReading.StandardFindingTestReadingId = (int?)new TestResultService().GetStandardFindingTestReadingIdForStandardFinding((int)TestType.FloChecABI, (int)ReadingLabels.RightABI, floChecAbiTestResult.RightResultReadings.Finding.Id);
                    }

                    customerEventReadingEntities.Add(customerEventReading);
                }
                else if (floChecAbiTestResult.RightResultReadings.Finding != null && floChecAbiTestResult.RightResultReadings.Finding.Id > 0)
                {
                    customerEventReading = CreateEventReadingEntity(floChecAbiTestResult.RightResultReadings.ABI ?? new ResultReading<decimal?> { ReadingSource = ReadingSource.Manual, RecorderMetaData = testResult.DataRecorderMetaData },
                        (int)ReadingLabels.RightABI, testReadingReadingPairs);

                    customerEventReading.StandardFindingTestReadingId = (int?)new TestResultService().GetStandardFindingTestReadingIdForStandardFinding((int)TestType.FloChecABI, (int)ReadingLabels.RightABI, floChecAbiTestResult.RightResultReadings.Finding.Id);

                    customerEventReadingEntities.Add(customerEventReading);
                }
            }

            if (floChecAbiTestResult != null)
            {
                var customerEventReadingPencilDoppler = CreateEventReadingEntity(floChecAbiTestResult.PencilDopplerUsed, (int)ReadingLabels.PencilDopplerUsed, testReadingReadingPairs);
                if (customerEventReadingPencilDoppler != null) customerEventReadingEntities.Add(customerEventReadingPencilDoppler);

                if (floChecAbiTestResult.RepeatStudy != null)
                {
                    var customerEventReading = CreateEventReadingEntity(floChecAbiTestResult.RepeatStudy, (int)ReadingLabels.RepeatStudy, testReadingReadingPairs);
                    customerEventReadingEntities.Add(customerEventReading);
                }
            }

            testResult.ResultInterpretation = null;
            //TODO: Need to move this code into a Service

            var findingToConsider = GetFindingToConsider(leftResultFinding, rightResultFinding);

            if (floChecAbiTestResult.Finding != null && (standardFindingsRightAbi == null || standardFindingsRightAbi.Count() < 1))
            {
                if (findingToConsider == null || findingToConsider.Id != floChecAbiTestResult.Finding.Id)
                {
                    customerEventScreeningTestsEntity.CustomerEventTestStandardFinding.Add(
                        new CustomerEventTestStandardFindingEntity(floChecAbiTestResult.Finding.CustomerEventStandardFindingId)
                        {
                            StandardFindingTestReadingId = (int?)new TestResultService().GetStandardFindingTestReadingIdForStandardFinding((int)TestType.FloChecABI, null, floChecAbiTestResult.Finding.Id)
                        });

                    findingToConsider = floChecAbiTestResult.Finding;
                }
            }

            if (findingToConsider != null)
            {
                var finding = GetSelectedStandardFinding((int)TestType.FloChecABI, (standardFindingsRightAbi != null && standardFindingsRightAbi.Count() > 0 ? (int?)ReadingLabels.RightABI : null), findingToConsider.Id);

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