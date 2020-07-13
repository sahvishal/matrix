using System;
using System.Collections.Generic;
using System.Linq;
using Falcon.App.Core;
using Falcon.App.Core.Medical.Domain;
using Falcon.App.Core.Medical.Enum;
using Falcon.App.Core.Users.Enum;
using Falcon.Data.EntityClasses;

namespace Falcon.App.Infrastructure.Factories.Screening
{
    public class FraminghamRiskTestResultFactory : TestResultFactory
    {

        public override TestResult CreateActualTestResult(CustomerEventScreeningTestsEntity customerEventScreeningTestsEntity)
        {
            var customerEventReadingEntities = customerEventScreeningTestsEntity.CustomerEventReading.ToList();

            var testResult = new FraminghamRiskTestResult(customerEventScreeningTestsEntity.CustomerEventScreeningTestId);

            var totalCholesterolData = customerEventReadingEntities.
                Where(customerEventReading => customerEventReading.TestReading.ReadingId == (int)ReadingLabels.TotalCholestrol).
                SingleOrDefault();

            int tCholestrol = 0;
            if (totalCholesterolData != null && int.TryParse(totalCholesterolData.Value, out tCholestrol) == true)
                testResult.TotalCholestrol = new ResultReading<int?>(totalCholesterolData.CustomerEventReadingId)
                                                 {
                                                     Label = ReadingLabels.TotalCholestrol,
                                                     Reading = tCholestrol
                                                 };

            var hdlData = customerEventReadingEntities.
               Where(customerEventReading => customerEventReading.TestReading.ReadingId == (int)ReadingLabels.HDL).
               SingleOrDefault();

            int hdl = 0;
            if (hdlData != null && int.TryParse(hdlData.Value, out hdl) == true)
                testResult.HDL = new ResultReading<int?>(hdlData.CustomerEventReadingId)
                                     {
                                         Label = ReadingLabels.HDL,
                                         Reading = hdl
                                     };

            var ldlData = customerEventReadingEntities.
                Where(customerEventReading => customerEventReading.TestReading.ReadingId == (int)ReadingLabels.LDL).
                SingleOrDefault();

            if (ldlData != null)
                testResult.LDL = new ResultReading<int?>(ldlData.CustomerEventReadingId)
                                     {
                                         Label = ReadingLabels.LDL,
                                         Reading = !string.IsNullOrEmpty(ldlData.Value)
                                                       ? Convert.ToInt32(ldlData.Value)
                                                       : default(int),
                                     };

            var smokerData = customerEventReadingEntities.
               Where(customerEventReading => customerEventReading.TestReading.ReadingId == (int)ReadingLabels.Smoker).
               SingleOrDefault();

            if (smokerData != null)
                testResult.Smoker = new ResultReading<bool?>(smokerData.CustomerEventReadingId)
                                        {
                                            Label = ReadingLabels.Smoker,
                                            Reading = !string.IsNullOrEmpty(smokerData.Value)
                                                          ? Convert.ToBoolean(smokerData.Value)
                                                          : default(bool),
                                        };

            var diabeticData = customerEventReadingEntities.
                Where(customerEventReading => customerEventReading.TestReading.ReadingId == (int)ReadingLabels.Diabetes)
                .
                SingleOrDefault();

            if (diabeticData != null)
                testResult.Diabetic = new ResultReading<bool?>(diabeticData.CustomerEventReadingId)
                                          {
                                              Label = ReadingLabels.Diabetes,
                                              Reading = !string.IsNullOrEmpty(diabeticData.Value)
                                                            ? Convert.ToBoolean(diabeticData.Value)
                                                            : default(bool),
                                          };

            var systolicData = customerEventReadingEntities.
                Where(customerEventReading => customerEventReading.TestReading.ReadingId == (int)ReadingLabels.SystolicRight)
                .
                SingleOrDefault();

            if (systolicData != null)
                testResult.Systolic = new ResultReading<int?>(systolicData.CustomerEventReadingId)
                                          {
                                              Label = ReadingLabels.SystolicRight,
                                              Reading = !string.IsNullOrEmpty(systolicData.Value)
                                                            ? Convert.ToInt32(systolicData.Value)
                                                            : default(int),
                                          };

            var diastolicData = customerEventReadingEntities.
               Where(customerEventReading => customerEventReading.TestReading.ReadingId == (int)ReadingLabels.DiastolicRight)
               .
               SingleOrDefault();

            if (diastolicData != null)
                testResult.Diastolic = new ResultReading<int?>(diastolicData.CustomerEventReadingId)
                                          {
                                              Label = ReadingLabels.DiastolicRight,
                                              Reading = !string.IsNullOrEmpty(diastolicData.Value)
                                                            ? Convert.ToInt32(diastolicData.Value)
                                                            : default(int),
                                          };

            var age = customerEventReadingEntities.
               Where(customerEventReading => customerEventReading.TestReading.ReadingId == (int)ReadingLabels.Age)
               .
               SingleOrDefault();

            if (age != null)
                testResult.Age = new ResultReading<int?>(age.CustomerEventReadingId)
                                     {
                                         Label = ReadingLabels.Age,
                                         Reading = !string.IsNullOrEmpty(age.Value)
                                                       ? Convert.ToInt32(age.Value)
                                                       : default(int),
                                     };

            var gender = customerEventReadingEntities.
                Where(customerEventReading => customerEventReading.TestReading.ReadingId == (int) ReadingLabels.Gender)
                .SingleOrDefault();

            if (gender != null)
                testResult.Gender = new ResultReading<Gender>(gender.CustomerEventReadingId)
                                        {
                                            Label = ReadingLabels.Gender,
                                            Reading =
                                                gender.Value.ToUpper() == ("Male").ToUpper()
                                                    ? Gender.Male
                                                    : Gender.Female,
                                        };

            var framinghamData = customerEventReadingEntities.
               Where(customerEventReading => customerEventReading.TestReading.ReadingId == (int)ReadingLabels.FraminghamRisk).
               SingleOrDefault();

            if (framinghamData != null)
                testResult.FraminghamRisk = new ResultReading<decimal?>(framinghamData.CustomerEventReadingId)
                {
                    Label = ReadingLabels.FraminghamRisk,
                    Reading = !string.IsNullOrEmpty(framinghamData.Value)
                        ? Convert.ToDecimal(framinghamData.Value)
                        : default(int),
                    ReadingSource = (framinghamData.IsManual ? ReadingSource.Manual : ReadingSource.Automatic)
                };

            return testResult;
        }

        public override CustomerEventScreeningTestsEntity CreateActualTestResultEntity(TestResult testResult, List<OrderedPair<int, int>> testReadingReadingPairs)
        {
            var framinghamRiskTestResult = testResult as FraminghamRiskTestResult;

            var customerEventScreeningTestsEntity = new CustomerEventScreeningTestsEntity(testResult.Id) { TestId = (int)TestType.FraminghamRisk };

            var customerEventReadingEntities = new List<CustomerEventReadingEntity>();

            if (framinghamRiskTestResult != null)
            {
                CustomerEventReadingEntity customerEventTestReadingEntity = null;

                if (framinghamRiskTestResult.Age != null)
                {
                    customerEventTestReadingEntity = new CustomerEventReadingEntity()
                                                         {
                                                             TestReadingId =
                                                                 testReadingReadingPairs.Find(testReadingReadingPair =>
                                                                                              (testReadingReadingPair.
                                                                                                   FirstValue ==
                                                                                               (int)
                                                                                               ReadingLabels.
                                                                                                   Age))
                                                                 .SecondValue,
                                                             CustomerEventReadingId =
                                                                 Convert.ToInt32(
                                                                 framinghamRiskTestResult.Age.Id),
                                                             Value =
                                                                 framinghamRiskTestResult.Age.Reading.
                                                                 ToString(),
                                                             IsManual = (framinghamRiskTestResult.Age.ReadingSource == ReadingSource.Manual ? true : false),
                                                             CreatedByOrgRoleUserId =
                                                                 testResult.DataRecorderMetaData.DataRecorderCreator.Id,
                                                             CreatedOn = testResult.DataRecorderMetaData.DateCreated
                                                         };
                    customerEventReadingEntities.Add(customerEventTestReadingEntity);
                }

                if (framinghamRiskTestResult.FraminghamRisk != null)
                {
                    customerEventTestReadingEntity = new CustomerEventReadingEntity()
                                                         {
                                                             TestReadingId =
                                                                 testReadingReadingPairs.Find(testReadingReadingPair =>
                                                                                              (testReadingReadingPair.
                                                                                                   FirstValue ==
                                                                                               (int)
                                                                                               ReadingLabels.
                                                                                                   FraminghamRisk))
                                                                 .SecondValue,
                                                             CustomerEventReadingId =
                                                                 Convert.ToInt32(
                                                                 framinghamRiskTestResult.FraminghamRisk.Id),
                                                             Value =
                                                                 framinghamRiskTestResult.FraminghamRisk.Reading.
                                                                 ToString(),
                                                             IsManual = (framinghamRiskTestResult.FraminghamRisk.ReadingSource == ReadingSource.Manual ? true : false),
                                                             CreatedByOrgRoleUserId =
                                                                 testResult.DataRecorderMetaData.DataRecorderCreator.Id,
                                                             CreatedOn = testResult.DataRecorderMetaData.DateCreated
                                                         };
                    customerEventReadingEntities.Add(customerEventTestReadingEntity);
                }

                if (framinghamRiskTestResult.Gender != null)
                {
                    customerEventTestReadingEntity = new CustomerEventReadingEntity()
                                                         {
                                                             TestReadingId =
                                                                 testReadingReadingPairs.Find(testReadingReadingPair =>
                                                                                              (testReadingReadingPair.
                                                                                                   FirstValue ==
                                                                                               (int)
                                                                                               ReadingLabels.
                                                                                                   Gender))
                                                                 .SecondValue,
                                                             CustomerEventReadingId =
                                                                 Convert.ToInt32(
                                                                 framinghamRiskTestResult.Gender.Id),
                                                             Value =
                                                                 framinghamRiskTestResult.Gender.Reading.
                                                                 ToString(),
                                                             CreatedByOrgRoleUserId =
                                                                 testResult.DataRecorderMetaData.DataRecorderCreator.Id,
                                                             CreatedOn = testResult.DataRecorderMetaData.DateCreated
                                                         };
                    customerEventReadingEntities.Add(customerEventTestReadingEntity);
                }

                if (framinghamRiskTestResult.Smoker != null)
                {
                    customerEventTestReadingEntity = new CustomerEventReadingEntity()
                    {
                        TestReadingId =
                            testReadingReadingPairs.Find(testReadingReadingPair =>
                                                         (testReadingReadingPair.
                                                              FirstValue ==
                                                          (int)
                                                          ReadingLabels.Smoker))
                            .SecondValue,
                        CustomerEventReadingId =
                            Convert.ToInt32(framinghamRiskTestResult.Smoker.Id),
                        Value = framinghamRiskTestResult.Smoker.Reading.ToString(),
                        CreatedByOrgRoleUserId =
                            testResult.DataRecorderMetaData.DataRecorderCreator.Id,
                        CreatedOn = testResult.DataRecorderMetaData.DateCreated
                    };
                    customerEventReadingEntities.Add(customerEventTestReadingEntity);
                }

                if (framinghamRiskTestResult.Diabetic != null)
                {
                    customerEventTestReadingEntity = new CustomerEventReadingEntity()
                    {
                        TestReadingId =
                            testReadingReadingPairs.Find(testReadingReadingPair =>
                                                         (testReadingReadingPair.
                                                              FirstValue ==
                                                          (int)
                                                          ReadingLabels.Diabetes))
                            .SecondValue,
                        CustomerEventReadingId =
                            Convert.ToInt32(framinghamRiskTestResult.Diabetic.Id),
                        Value = framinghamRiskTestResult.Diabetic.Reading.ToString(),
                        CreatedByOrgRoleUserId =
                            testResult.DataRecorderMetaData.DataRecorderCreator.Id,
                        CreatedOn = testResult.DataRecorderMetaData.DateCreated
                    };
                    customerEventReadingEntities.Add(customerEventTestReadingEntity);
                }

                if (framinghamRiskTestResult.Systolic != null)
                {
                    customerEventTestReadingEntity = new CustomerEventReadingEntity()
                    {
                        TestReadingId =
                            testReadingReadingPairs.Find(testReadingReadingPair =>
                                                         (testReadingReadingPair.
                                                              FirstValue ==
                                                          (int)
                                                          ReadingLabels.SystolicRight))
                            .SecondValue,
                        CustomerEventReadingId =
                            Convert.ToInt32(framinghamRiskTestResult.Systolic.Id),
                        Value = framinghamRiskTestResult.Systolic.Reading.ToString(),
                        CreatedByOrgRoleUserId =
                            testResult.DataRecorderMetaData.DataRecorderCreator.Id,
                        CreatedOn = testResult.DataRecorderMetaData.DateCreated
                    };
                    customerEventReadingEntities.Add(customerEventTestReadingEntity);
                }

                if (framinghamRiskTestResult.Diastolic != null)
                {
                    customerEventTestReadingEntity = new CustomerEventReadingEntity()
                    {
                        TestReadingId =
                            testReadingReadingPairs.Find(testReadingReadingPair =>
                                                         (testReadingReadingPair.
                                                              FirstValue ==
                                                          (int)
                                                          ReadingLabels.DiastolicRight))
                            .SecondValue,
                        CustomerEventReadingId =
                            Convert.ToInt32(framinghamRiskTestResult.Diastolic.Id),
                        Value = framinghamRiskTestResult.Diastolic.Reading.ToString(),
                        CreatedByOrgRoleUserId =
                            testResult.DataRecorderMetaData.DataRecorderCreator.Id,
                        CreatedOn = testResult.DataRecorderMetaData.DateCreated
                    };
                    customerEventReadingEntities.Add(customerEventTestReadingEntity);
                }
            }

            customerEventScreeningTestsEntity.CustomerEventReading.AddRange(customerEventReadingEntities);
            return customerEventScreeningTestsEntity;
        }

    }
}
