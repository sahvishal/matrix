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
    public class AsiTestResultFactory : TestResultFactory
    {
        public override TestResult CreateActualTestResult(CustomerEventScreeningTestsEntity customerEventScreeningTestsEntity)
        {
            var customerEventReadingEntities = customerEventScreeningTestsEntity.CustomerEventReading.ToList();

            var testResult = new ASITestResult(customerEventScreeningTestsEntity.CustomerEventScreeningTestId);

            var rawAsiReadingEntities = customerEventReadingEntities.
                Where(customerEventReading => customerEventReading.TestReading.ReadingId == (int)ReadingLabels.RawASI).ToList();

            if (rawAsiReadingEntities.Count > 0)
            {
                testResult.RawASI = new List<ResultReading<int>>();
                rawAsiReadingEntities.ForEach(asiReading =>
                    testResult.RawASI.Add(new ResultReading<int>(asiReading.CustomerEventReadingId)
                    {
                        Reading = !string.IsNullOrEmpty(asiReading.Value) ? Convert.ToInt32(asiReading.Value) : 0,
                        ReadingSource = (asiReading.IsManual == true ? ReadingSource.Manual : ReadingSource.Automatic),
                        Label = ReadingLabels.RawASI,
                        RecorderMetaData = new DataRecorderMetaData
                        {
                            DataRecorderCreator = new OrganizationRoleUser(asiReading.CreatedByOrgRoleUserId),
                            DateCreated = asiReading.CreatedOn,
                            DataRecorderModifier = asiReading.UpdatedByOrgRoleUserId.HasValue ? new OrganizationRoleUser(asiReading.UpdatedByOrgRoleUserId.Value) : null,
                            DateModified = asiReading.UpdatedOn
                        }
                    })
                );
            }

            testResult.PressureReadings = CreatePressureReadings(customerEventReadingEntities);
            testResult.RepeatStudy = CreateResultReading((int)ReadingLabels.RepeatStudy, customerEventReadingEntities);

            var asiReadingEntity = customerEventReadingEntities.
                Where(customerEventReading => customerEventReading.TestReading.ReadingId == (int)ReadingLabels.ASI).SingleOrDefault();

            if (asiReadingEntity != null)
            {
                testResult.ASI = new CompoundResultReading<int?>(asiReadingEntity.CustomerEventReadingId)
                {
                    Reading = !string.IsNullOrEmpty(asiReadingEntity.Value) ? (int?)Convert.ToInt32(asiReadingEntity.Value) : null,
                    ReadingSource = asiReadingEntity.IsManual ? ReadingSource.Manual : ReadingSource.Automatic,
                    Label = ReadingLabels.ASI,
                    RecorderMetaData = new DataRecorderMetaData
                    {
                        DataRecorderCreator = new OrganizationRoleUser(asiReadingEntity.CreatedByOrgRoleUserId),
                        DateCreated = asiReadingEntity.CreatedOn,
                        DataRecorderModifier = asiReadingEntity.UpdatedByOrgRoleUserId.HasValue ? new OrganizationRoleUser(asiReadingEntity.UpdatedByOrgRoleUserId.Value) : null,
                        DateModified = asiReadingEntity.UpdatedOn
                    }
                };

                // TODO : This code should be moved to a Coordinator/Service.
                int testReadingValue = 0;
                if (asiReadingEntity.StandardFindingTestReadingId != null)
                {
                    var standardFindingReadingEntity = customerEventScreeningTestsEntity.StandardFindingTestReadingCollectionViaCustomerEventReading.ToList().Find(stdFindingTestReading =>
                        stdFindingTestReading.TestId == (int)TestType.ASI && stdFindingTestReading.ReadingId == (int)ReadingLabels.ASI);

                    if (standardFindingReadingEntity != null)
                        testResult.ASI.Finding = new StandardFinding<int?>(standardFindingReadingEntity.StandardFindingId);
                }
                else if (asiReadingEntity.Value != null && int.TryParse(asiReadingEntity.Value, out testReadingValue))
                {
                    testResult.ASI.Finding = new StandardFinding<int?>((new TestResultService()).
                                                                         GetCalculatedStandardFinding(testReadingValue, (int)TestType.ASI, (int)ReadingLabels.ASI));
                }

                if (testResult.ASI.Finding != null)
                    testResult.ASI.Finding = new TestResultService().GetAllStandardFindings<int?>((int)TestType.ASI, (int)ReadingLabels.ASI).Find(standardFinding => standardFinding.Id == testResult.ASI.Finding.Id);
            }

            testResult.Pattern = CreateResultReadingforInputValues((int)ReadingLabels.Pattern, customerEventReadingEntities);
            return testResult;
        }

        public override CustomerEventScreeningTestsEntity CreateActualTestResultEntity(TestResult testResult, List<OrderedPair<int, int>> testReadingReadingPairs)
        {
            var asiTestResult = testResult as ASITestResult;
            var customerEventScreeningTestsEntity = new CustomerEventScreeningTestsEntity(testResult.Id) { TestId = (int)TestType.ASI };
            var customerEventReadingEntities = new List<CustomerEventReadingEntity>();

            if (asiTestResult.PressureReadings != null)
            {
                var pressureReadingEntities = CreatePressureReadingEntities(asiTestResult.PressureReadings, testReadingReadingPairs);
                if (pressureReadingEntities != null && pressureReadingEntities.Count > 0)
                {
                    customerEventReadingEntities.AddRange(pressureReadingEntities);
                }
            }

            var customerEventReading = CreateEventReadingEntity(asiTestResult.Pattern, (int)ReadingLabels.Pattern, testReadingReadingPairs);
            if (customerEventReading != null) customerEventReadingEntities.Add(customerEventReading);

            long findingId = 0;

            // TODO : This code should be moved to a Coordinator/Service.
            if (asiTestResult.ASI != null && asiTestResult.ASI.Finding != null)
            {
                customerEventReading = CreateEventReadingEntity(asiTestResult.ASI, (int)ReadingLabels.ASI, testReadingReadingPairs) ??
                                       CreateEventReadingEntitywithNullReading(asiTestResult.ASI, (int)ReadingLabels.ASI, testReadingReadingPairs);

                if (asiTestResult.ASI.Reading == null)
                {
                    findingId = asiTestResult.ASI.Finding.Id;
                    customerEventReading.StandardFindingTestReadingId
                            = (int?)new TestResultService().GetStandardFindingTestReadingIdForStandardFinding((int)TestType.ASI, (int)ReadingLabels.ASI, asiTestResult.ASI.Finding.Id);
                }
                else
                {
                    findingId = (new TestResultService()).GetCalculatedStandardFinding(asiTestResult.ASI.Reading, (int)TestType.ASI, (int)ReadingLabels.ASI);

                    if (asiTestResult.ASI.Finding.Id == findingId)
                        customerEventReading.StandardFindingTestReadingId = null;
                    else
                    {
                        findingId = asiTestResult.ASI.Finding.Id;
                        customerEventReading.StandardFindingTestReadingId
                            = (int?)new TestResultService().GetStandardFindingTestReadingIdForStandardFinding((int)TestType.ASI, (int)ReadingLabels.ASI, asiTestResult.ASI.Finding.Id);
                    }
                }

                customerEventReadingEntities.Add(customerEventReading);
            }

            if (findingId > 0)
            {
                var finding = GetSelectedStandardFinding((int) TestType.ASI, (int) ReadingLabels.ASI, findingId);
                if (testResult.ResultStatus.StateNumber == (int)TestResultStateNumber.Evaluated || testResult.ResultStatus.StateNumber == (int)NewTestResultStateNumber.Evaluated)
                {
                    testResult.ResultInterpretation = finding.ResultInterpretation;
                    testResult.PathwayRecommendation = finding.PathwayRecommendation;
                }
            }

            if (asiTestResult.RepeatStudy != null)
            {
                customerEventReading = CreateEventReadingEntity(asiTestResult.RepeatStudy, (int)ReadingLabels.RepeatStudy, testReadingReadingPairs);
                customerEventReadingEntities.Add(customerEventReading);
            }

            if (asiTestResult.RawASI != null && asiTestResult.RawASI.Count > 0)
            {
                asiTestResult.RawASI.ForEach(asi =>
                {
                    customerEventReading = CreateEventReadingEntity(asi, (int)ReadingLabels.RawASI, testReadingReadingPairs);

                    if (customerEventReading != null) customerEventReadingEntities.Add(customerEventReading);
                });
            }

            if (customerEventReadingEntities.Count > 0)
                customerEventScreeningTestsEntity.CustomerEventReading.AddRange(customerEventReadingEntities);

            return customerEventScreeningTestsEntity;
        }


        private CardiovisionPressureReadings CreatePressureReadings(List<CustomerEventReadingEntity> customerEventReadingEntities)
        {
            var pressureReadings = new CardiovisionPressureReadings
                                       {
                                           Pulse =
                                              CreateResultReadingforNullableInt((int)ReadingLabels.Pulse, customerEventReadingEntities),
                                           PulsePressure =
                                              CreateResultReadingforNullableInt((int)ReadingLabels.PulsePressure, customerEventReadingEntities)
                                       };


            return pressureReadings;
        }

        private List<CustomerEventReadingEntity> CreatePressureReadingEntities(CardiovisionPressureReadings pressureReadings, List<OrderedPair<int, int>> testReadingReadingPairs)
        {
            var customerEventReadingEntities = new List<CustomerEventReadingEntity>();

            //var customerEventReading = CreateEventReadingEntity(pressureReadings.SystolicRightArm, (int)ReadingLabels.SystolicRight, testReadingReadingPairs);

            //if (customerEventReading != null) customerEventReadingEntities.Add(customerEventReading);


            //customerEventReading = CreateEventReadingEntity(pressureReadings.SystolicLeftArm, (int)ReadingLabels.SystolicLeft, testReadingReadingPairs);

            //if (customerEventReading != null) customerEventReadingEntities.Add(customerEventReading);


            var customerEventReading = CreateEventReadingEntity(pressureReadings.Pulse, (int)ReadingLabels.Pulse, testReadingReadingPairs);

            if (customerEventReading != null) customerEventReadingEntities.Add(customerEventReading);


            //customerEventReading = CreateEventReadingEntity(pressureReadings.DiastolicRightArm, (int)ReadingLabels.DiastolicRight, testReadingReadingPairs);

            //if (customerEventReading != null) customerEventReadingEntities.Add(customerEventReading);


            //customerEventReading = CreateEventReadingEntity(pressureReadings.DiastolicLeftArm, (int)ReadingLabels.DiastolicLeft, testReadingReadingPairs);

            //if (customerEventReading != null) customerEventReadingEntities.Add(customerEventReading);


            customerEventReading = CreateEventReadingEntity(pressureReadings.PulsePressure, (int)ReadingLabels.PulsePressure, testReadingReadingPairs);

            if (customerEventReading != null) customerEventReadingEntities.Add(customerEventReading);

            return customerEventReadingEntities;
        }

    }
}
