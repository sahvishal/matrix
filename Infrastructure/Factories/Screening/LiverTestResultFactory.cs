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
    public class LiverTestResultFactory : TestResultFactory
    {

        public override TestResult CreateActualTestResult(CustomerEventScreeningTestsEntity customerEventScreeningTestsEntity)
        {
            //var testResult = new LiverTestResult();

            var customerEventReadingEntities = customerEventScreeningTestsEntity.CustomerEventReading.ToList();

            var standardFindingTestReadingEntities =
                    customerEventScreeningTestsEntity.
                        StandardFindingTestReadingCollectionViaCustomerEventReading;

            var testResult = new LiverTestResult(customerEventScreeningTestsEntity.CustomerEventScreeningTestId);

            var astData = customerEventReadingEntities.Where(
                customerEventReading => customerEventReading.TestReading.ReadingId == (int)ReadingLabels.AST).SingleOrDefault();

            if (astData != null)
            {
                StandardFindingTestReadingEntity standardFindingTestReading = null;
                if (astData.StandardFindingTestReadingId != null)
                {
                    standardFindingTestReading =
                        standardFindingTestReadingEntities.ToList().Find(standardFindingTestReadingEntity =>
                                                                         (standardFindingTestReadingEntity.ReadingId ==
                                                                          (int)ReadingLabels.AST) &&
                                                                         (astData.
                                                                              StandardFindingTestReadingId ==
                                                                          standardFindingTestReadingEntity.
                                                                              StandardFindingTestReadingId)
                            );

                }

                testResult.AST = new CompoundResultReading<int?>(astData.CustomerEventReadingId)
                                     {
                                         Label = ReadingLabels.AST,
                                         Reading = !string.IsNullOrEmpty(astData.Value)
                                                        ? (int?)Convert.ToInt32(astData.Value)
                                                        : null,
                                         ReadingSource = astData.IsManual
                                                             ? ReadingSource.Manual
                                                             : ReadingSource.Automatic
                                     };

                int astValue = 0;
                if (astData.Value != null && int.TryParse(astData.Value, out astValue) == true)
                {
                    testResult.AST.Finding = new StandardFinding<int?>(
                                                         Convert.ToInt64(
                                                             astData.StandardFindingTestReadingId == null
                                                                 ?
                                                                     (new TestResultService()).
                                                                         GetCalculatedStandardFinding(astValue,
                                                                         (int)TestType.Liver, (int)ReadingLabels.AST)
                                                                 : standardFindingTestReading.StandardFindingId));
                }
                else if (astData.StandardFindingTestReadingId != null)
                {
                    testResult.AST.Finding = new StandardFinding<int?>(standardFindingTestReading.StandardFindingId);
                }

                if (testResult.AST.Finding != null)
                    testResult.AST.Finding = new TestResultService().GetAllStandardFindings<int?>((int)TestType.Liver,
                                                                            (int)ReadingLabels.AST).Find(standardFinding => standardFinding.Id == testResult.AST.Finding.Id);
            }

            var altData = customerEventReadingEntities.Where(
                customerEventReading => customerEventReading.TestReading.ReadingId == (int)ReadingLabels.ALT).SingleOrDefault();

            if (altData != null)
            {
                StandardFindingTestReadingEntity standardFindingTestReading = null;
                if (altData.StandardFindingTestReadingId != null)
                {
                    standardFindingTestReading =
                        standardFindingTestReadingEntities.ToList().Find(standardFindingTestReadingEntity =>
                                                                         (standardFindingTestReadingEntity.ReadingId ==
                                                                          (int)ReadingLabels.ALT) &&
                                                                         (altData.
                                                                              StandardFindingTestReadingId ==
                                                                          standardFindingTestReadingEntity.
                                                                              StandardFindingTestReadingId)
                            );

                }

                testResult.ALT = new CompoundResultReading<int?>(altData.CustomerEventReadingId)
                                     {
                                         Label = ReadingLabels.ALT,
                                         Reading = !string.IsNullOrEmpty(altData.Value)
                                                        ? (int?)Convert.ToInt32(altData.Value)
                                                        : null,
                                         ReadingSource = altData.IsManual
                                                             ? ReadingSource.Manual
                                                             : ReadingSource.Automatic
                                     };

                int altValue = 0;
                if (altData.Value != null && int.TryParse(altData.Value, out altValue) == true)
                {
                    testResult.ALT.Finding = new StandardFinding<int?>(
                                                         Convert.ToInt64(
                                                             altData.StandardFindingTestReadingId == null
                                                                 ?
                                                                     (new TestResultService()).
                                                                         GetCalculatedStandardFinding(altValue,
                                                                         (int)TestType.Liver, (int)ReadingLabels.ALT)
                                                                 : standardFindingTestReading.StandardFindingId));
                }
                else if (altData.StandardFindingTestReadingId != null)
                {
                    testResult.ALT.Finding = new StandardFinding<int?>(standardFindingTestReading.StandardFindingId);
                }
                
                if (testResult.ALT.Finding != null)
                    testResult.ALT.Finding = new TestResultService().GetAllStandardFindings<int?>((int)TestType.Liver,
                                                                            (int)ReadingLabels.ALT).Find(standardFinding => standardFinding.Id == testResult.ALT.Finding.Id);
            }
            return testResult;

        }

        public override CustomerEventScreeningTestsEntity CreateActualTestResultEntity(TestResult testResult, List<OrderedPair<int, int>> testReadingReadingPairs)
        {
            var liverTestResult = testResult as LiverTestResult;
            var customerEventScreeningTestsEntity = new CustomerEventScreeningTestsEntity(testResult.Id) { TestId = (int)TestType.Liver };
            var customerEventReadingEntities = new List<CustomerEventReadingEntity>();

            if (liverTestResult != null)
            {
                CustomerEventReadingEntity customerEventTestReadingEntity = null;

                if (liverTestResult.ALT != null)
                {
                    customerEventTestReadingEntity = new CustomerEventReadingEntity()
                                                         {
                                                             TestReadingId =
                                                                 testReadingReadingPairs.Find(testReadingReadingPair =>
                                                                                              (testReadingReadingPair.
                                                                                                   FirstValue ==
                                                                                               (int)
                                                                                               ReadingLabels.ALT))
                                                                 .SecondValue,
                                                             CustomerEventReadingId =
                                                                 Convert.ToInt32(liverTestResult.ALT.Id),
                                                             Value = liverTestResult.ALT.Reading != null ? liverTestResult.ALT.Reading.ToString() : null,
                                                             IsManual = (liverTestResult.ALT.ReadingSource == ReadingSource.Manual ? true : false),
                                                             CreatedByOrgRoleUserId =
                                                                 testResult.DataRecorderMetaData.DataRecorderCreator.Id,
                                                             CreatedOn = testResult.DataRecorderMetaData.DateCreated
                                                         };

                    
                    if (liverTestResult.ALT.Finding == null)
                    {
                        customerEventTestReadingEntity.StandardFindingTestReadingId = null;
                    }
                    else if (liverTestResult.ALT.Reading == null)
                    {
                        customerEventTestReadingEntity.StandardFindingTestReadingId
                                = (int?)new TestResultService().GetStandardFindingTestReadingIdForStandardFinding
                                                                            ((int)TestType.Liver,
                                                                             (int)ReadingLabels.ALT,
                                                                             liverTestResult.ALT.Finding.Id);
                    }
                    else
                    {
                        int findingId = (new TestResultService()).GetCalculatedStandardFinding(Convert.ToInt32(liverTestResult.ALT.Reading),
                                                            (int)TestType.Liver, (int)ReadingLabels.ALT);

                        if (liverTestResult.ALT.Finding.Id == findingId)
                            customerEventTestReadingEntity.StandardFindingTestReadingId = null;
                        else
                            customerEventTestReadingEntity.StandardFindingTestReadingId
                                = (int?)new TestResultService().GetStandardFindingTestReadingIdForStandardFinding
                                                                            ((int)TestType.Liver,
                                                                             (int)ReadingLabels.ALT,
                                                                             liverTestResult.ALT.Finding.Id);
                    }

                    customerEventReadingEntities.Add(customerEventTestReadingEntity);
                }

                if (liverTestResult.AST != null)
                {
                    customerEventTestReadingEntity = new CustomerEventReadingEntity()
                                                         {
                                                             TestReadingId =
                                                                 testReadingReadingPairs.Find(testReadingReadingPair =>
                                                                                              (testReadingReadingPair.
                                                                                                   FirstValue ==
                                                                                               (int)
                                                                                               ReadingLabels.AST))
                                                                 .SecondValue,
                                                             CustomerEventReadingId =
                                                                 Convert.ToInt32(liverTestResult.AST.Id),
                                                             Value = liverTestResult.AST.Reading != null ? liverTestResult.AST.Reading.ToString() : null,
                                                             IsManual = (liverTestResult.AST.ReadingSource == ReadingSource.Manual ? true : false),
                                                             CreatedByOrgRoleUserId =
                                                                 testResult.DataRecorderMetaData.DataRecorderCreator.Id,
                                                             CreatedOn = testResult.DataRecorderMetaData.DateCreated

                                                         };


                    if (liverTestResult.AST.Finding == null)
                    {
                        customerEventTestReadingEntity.StandardFindingTestReadingId = null;
                    }
                    else if (liverTestResult.AST.Reading == null)
                    {
                        customerEventTestReadingEntity.StandardFindingTestReadingId
                                = (int?)new TestResultService().GetStandardFindingTestReadingIdForStandardFinding
                                                                            ((int)TestType.Liver,
                                                                             (int)ReadingLabels.AST,
                                                                             liverTestResult.AST.Finding.Id);
                    }
                    else
                    {
                        int findingId = (new TestResultService()).GetCalculatedStandardFinding(Convert.ToInt32(liverTestResult.AST.Reading),
                                                            (int)TestType.Liver, (int)ReadingLabels.AST);

                        if (liverTestResult.AST.Finding.Id == findingId)
                            customerEventTestReadingEntity.StandardFindingTestReadingId = null;
                        else
                            customerEventTestReadingEntity.StandardFindingTestReadingId
                                = (int?)new TestResultService().GetStandardFindingTestReadingIdForStandardFinding
                                                                            ((int)TestType.Liver,
                                                                             (int)ReadingLabels.AST,
                                                                             liverTestResult.AST.Finding.Id);
                    }


                    customerEventReadingEntities.Add(customerEventTestReadingEntity);
                }

            }
            customerEventScreeningTestsEntity.CustomerEventReading.AddRange(customerEventReadingEntities);
            return customerEventScreeningTestsEntity;
        }

    }
}
