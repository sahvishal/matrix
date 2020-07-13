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
    public class HcpAaaTestResultFactory : TestResultFactory
    {
        public override TestResult CreateActualTestResult(CustomerEventScreeningTestsEntity customerEventScreeningTestsEntity)
        {
            var customerEventReadingEntities = customerEventScreeningTestsEntity.CustomerEventReading.ToList();
            var testResult = new HcpAaaTestResult(customerEventScreeningTestsEntity.CustomerEventScreeningTestId);

            var customerEventTestStandardFindingEntities = customerEventScreeningTestsEntity.CustomerEventTestStandardFinding.ToList();
            var standardFindingTestReadingEntities = customerEventScreeningTestsEntity.StandardFindingTestReadingCollectionViaCustomerEventReading.ToList();
            standardFindingTestReadingEntities.AddRange(customerEventScreeningTestsEntity.StandardFindingTestReadingCollectionViaCustomerEventTestStandardFinding.ToList());

            testResult.AortaSize = CreateResultReadingforNullableDecimal((int)ReadingLabels.AortaSize, customerEventReadingEntities);

            testResult.TransverseView = new OrderedPair<ResultReading<decimal?>, ResultReading<decimal?>>(null, null);
            testResult.TransverseView.FirstValue = CreateResultReadingforNullableDecimal((int)ReadingLabels.TransverseViewDataPointOne, customerEventReadingEntities);
            testResult.TransverseView.SecondValue = CreateResultReadingforNullableDecimal((int)ReadingLabels.TransverseViewDataPointTwo, customerEventReadingEntities);

            var aortaValue = GetMaxofthreeAortaValues(testResult);
            if (aortaValue != null)
            {
                testResult.Finding = new StandardFinding<decimal?>(Convert.ToInt64((new TestResultService()).GetCalculatedStandardFinding(aortaValue, (int)TestType.HCPAAA, (int)ReadingLabels.AortaSize)));
            }

            if (testResult.Finding != null)
                testResult.Finding = new TestResultService().GetAllStandardFindings<decimal?>((int)TestType.HCPAAA, (int)ReadingLabels.AortaSize).Find(standardFinding => standardFinding.Id == testResult.Finding.Id);

            //testResult.Fusiform = CreateResultReadingforNullableBool((int)ReadingLabels.IsFusiform, customerEventReadingEntities);
            //testResult.Saccular = CreateResultReadingforNullableBool((int)ReadingLabels.IsSaccular, customerEventReadingEntities);
            testResult.AorticDissection = CreateResultReading((int)ReadingLabels.AorticDissection, customerEventReadingEntities);
            testResult.Plaque = CreateResultReading((int)ReadingLabels.Plaque, customerEventReadingEntities);
            testResult.Thrombus = CreateResultReading((int)ReadingLabels.Thrombus, customerEventReadingEntities);
            testResult.TechnicallyLimitedbutReadable = CreateResultReading((int)ReadingLabels.TechnicallyLimitedbutReadable, customerEventReadingEntities);
            testResult.RepeatStudy = CreateResultReading((int)ReadingLabels.RepeatStudy, customerEventReadingEntities);

            var testResultService = new TestResultService();
            var aortaRangeSaggitalViewFindings = testResultService.GetAllStandardFindings<int?>((int)TestType.HCPAAA, (int)ReadingLabels.AortaRangeSaggitalView);
            var aortaRangeTransverseViewFindings = testResultService.GetAllStandardFindings<int?>((int)TestType.HCPAAA, (int)ReadingLabels.AortaRangeTransverseView);
            var aortaValueFindings = testResultService.GetAllStandardFindings<int?>((int)TestType.HCPAAA, (int)ReadingLabels.AortaSize);

            customerEventTestStandardFindingEntities.ForEach(customerEventTestStandardFindingEntity =>
            {
                var standardFindingTestReadingEntity = standardFindingTestReadingEntities.Find(entity => entity.StandardFindingTestReadingId == customerEventTestStandardFindingEntity.StandardFindingTestReadingId);
                if (standardFindingTestReadingEntity == null) return;

                var finding = CreateFindingObject(customerEventTestStandardFindingEntity, aortaRangeSaggitalViewFindings, standardFindingTestReadingEntity, (int?)ReadingLabels.AortaRangeSaggitalView);
                if (finding != null)
                {
                    if (testResult.AortaRangeSaggitalView == null) testResult.AortaRangeSaggitalView = new List<StandardFinding<int>>();
                    testResult.AortaRangeSaggitalView.Add(finding); return;
                }

                finding = CreateFindingObject(customerEventTestStandardFindingEntity, aortaRangeTransverseViewFindings, standardFindingTestReadingEntity, (int?)ReadingLabels.AortaRangeTransverseView);
                if (finding != null)
                {
                    if (testResult.AortaRangeTransverseView == null) testResult.AortaRangeTransverseView = new List<StandardFinding<int>>();
                    testResult.AortaRangeTransverseView.Add(finding); return;
                }

                finding = CreateFindingObject(customerEventTestStandardFindingEntity, aortaValueFindings, standardFindingTestReadingEntity, (int?)ReadingLabels.AortaSize);
                if (finding != null)
                {
                    testResult.Finding = new StandardFinding<decimal?>(finding.Id)
                    {
                        CustomerEventStandardFindingId = finding.CustomerEventStandardFindingId,
                        Label = finding.Label,
                        Description = finding.Description
                    };
                    return;
                }
            });

            var testMediaCollection = customerEventScreeningTestsEntity.TestMedia.ToList();
            var fileEntityCollection = customerEventScreeningTestsEntity.FileCollectionViaTestMedia.ToList();

            if (testMediaCollection.Count > 0)
            {
                var resultMedia = new List<ResultMedia>();
                testMediaCollection.ForEach(testMedia => resultMedia.Add(new ResultMedia(testMedia.MediaId)
                {
                    File = GetFileObjectfromEntity(testMedia.FileId, fileEntityCollection),
                    Thumbnail = testMedia.ThumbnailFileId != null ? new File(testMedia.ThumbnailFileId.Value) : null,
                    ReadingSource = testMedia.IsManual ? ReadingSource.Manual : ReadingSource.Automatic
                }));

                testResult.ResultImages = resultMedia;
            }
            return testResult;
        }

        public override CustomerEventScreeningTestsEntity CreateActualTestResultEntity(TestResult testResult, List<OrderedPair<int, int>> testReadingReadingPairs)
        {
            var hcpAaaTestResult = testResult as HcpAaaTestResult;
            var customerEventScreeningTestsEntity = new CustomerEventScreeningTestsEntity(testResult.Id) { TestId = (int)TestType.HCPAAA };
            var customerEventReadingEntities = new List<CustomerEventReadingEntity>();

            int? standardFindingTestReadingId = null;
            long findingId = 0;
            var aortaValue = GetMaxofthreeAortaValues(hcpAaaTestResult);
            if (aortaValue != null)
            {
                findingId = (new TestResultService()).GetCalculatedStandardFinding(aortaValue, (int)TestType.HCPAAA, (int)ReadingLabels.AortaSize);

                if (hcpAaaTestResult.Finding != null && hcpAaaTestResult.Finding.Id != findingId)
                {
                    findingId = hcpAaaTestResult.Finding.Id;
                    standardFindingTestReadingId = (int?)new TestResultService().GetStandardFindingTestReadingIdForStandardFinding((int)TestType.HCPAAA, (int)ReadingLabels.AortaSize, hcpAaaTestResult.Finding.Id);
                }
            }
            else if (hcpAaaTestResult.Finding != null)
            {
                findingId = hcpAaaTestResult.Finding.Id;
                standardFindingTestReadingId = (int?)new TestResultService().GetStandardFindingTestReadingIdForStandardFinding((int)TestType.HCPAAA, (int)ReadingLabels.AortaSize, hcpAaaTestResult.Finding.Id);
            }

            if (findingId > 0)
            {
                var finding = GetSelectedStandardFinding((int)TestType.HCPAAA, (int)ReadingLabels.AortaSize, findingId);
                if (testResult.ResultStatus.StateNumber == (int)TestResultStateNumber.Evaluated || testResult.ResultStatus.StateNumber == (int)NewTestResultStateNumber.Evaluated)
                {
                    testResult.ResultInterpretation = finding.ResultInterpretation;
                    testResult.PathwayRecommendation = finding.PathwayRecommendation;
                }
            }

            if (standardFindingTestReadingId != null)
            {
                customerEventScreeningTestsEntity.CustomerEventTestStandardFinding.Add(
                            new CustomerEventTestStandardFindingEntity(hcpAaaTestResult.Finding.CustomerEventStandardFindingId)
                            {
                                StandardFindingTestReadingId = standardFindingTestReadingId.Value
                            });
            }

            if (hcpAaaTestResult.AortaSize != null)
            {
                var customerEventReading = CreateEventReadingEntity(hcpAaaTestResult.AortaSize, (int)ReadingLabels.AortaSize, testReadingReadingPairs);
                customerEventReadingEntities.Add(customerEventReading);
            }
            

            if (hcpAaaTestResult.TransverseView != null)
            {
                if (hcpAaaTestResult.TransverseView.FirstValue != null)
                {
                    var customerEventReading = CreateEventReadingEntity(hcpAaaTestResult.TransverseView.FirstValue, (int)ReadingLabels.TransverseViewDataPointOne, testReadingReadingPairs);
                    customerEventReadingEntities.Add(customerEventReading);
                }

                if (hcpAaaTestResult.TransverseView.SecondValue != null)
                {
                    var customerEventReading = CreateEventReadingEntity(hcpAaaTestResult.TransverseView.SecondValue, (int)ReadingLabels.TransverseViewDataPointTwo, testReadingReadingPairs);
                    customerEventReadingEntities.Add(customerEventReading);
                }
            }

            //if (hcpAaaTestResult.Fusiform != null)
            //{
            //    var customerEventReading = CreateEventReadingEntity(hcpAaaTestResult.Fusiform, (int)ReadingLabels.IsFusiform, testReadingReadingPairs);

            //    customerEventReadingEntities.Add(customerEventReading);
            //}

            //if (hcpAaaTestResult.Saccular != null)
            //{
            //    var customerEventReading = CreateEventReadingEntity(hcpAaaTestResult.Saccular, (int)ReadingLabels.IsSaccular, testReadingReadingPairs);

            //    customerEventReadingEntities.Add(customerEventReading);
            //}

            if (hcpAaaTestResult.AorticDissection != null)
            {
                var customerEventReading = CreateEventReadingEntity(hcpAaaTestResult.AorticDissection, (int)ReadingLabels.AorticDissection, testReadingReadingPairs);

                customerEventReadingEntities.Add(customerEventReading);
            }

            if (hcpAaaTestResult.Plaque != null)
            {
                var customerEventReading = CreateEventReadingEntity(hcpAaaTestResult.Plaque, (int)ReadingLabels.Plaque, testReadingReadingPairs);

                customerEventReadingEntities.Add(customerEventReading);
            }

            if (hcpAaaTestResult.TechnicallyLimitedbutReadable != null)
            {
                var customerEventReading = CreateEventReadingEntity(hcpAaaTestResult.TechnicallyLimitedbutReadable, (int)ReadingLabels.TechnicallyLimitedbutReadable, testReadingReadingPairs);

                customerEventReadingEntities.Add(customerEventReading);
            }

            if (hcpAaaTestResult.RepeatStudy != null)
            {
                var customerEventReading = CreateEventReadingEntity(hcpAaaTestResult.RepeatStudy, (int)ReadingLabels.RepeatStudy, testReadingReadingPairs);

                customerEventReadingEntities.Add(customerEventReading);
            }

            if (hcpAaaTestResult.Thrombus != null)
            {
                var customerEventReading = CreateEventReadingEntity(hcpAaaTestResult.Thrombus, (int)ReadingLabels.Thrombus, testReadingReadingPairs);

                customerEventReadingEntities.Add(customerEventReading);
            }

            if (hcpAaaTestResult.AortaRangeSaggitalView != null)
            {
                hcpAaaTestResult.AortaRangeSaggitalView.ForEach(finding =>
                {
                    var customerEventTestStandardFindingEntity = new CustomerEventTestStandardFindingEntity()
                    {
                        StandardFindingTestReadingId =
                            (int?)new TestResultService().GetStandardFindingTestReadingIdForStandardFinding
                                ((int)TestType.HCPAAA, (int)ReadingLabels.AortaRangeSaggitalView, Convert.ToInt64(finding.Id)),
                        CustomerEventTestStandardFindingId = finding.CustomerEventStandardFindingId,
                        CustomerEventScreeningTestId = testResult.Id
                    };
                    customerEventScreeningTestsEntity.CustomerEventTestStandardFinding.Add(customerEventTestStandardFindingEntity);
                });
            }

            if (hcpAaaTestResult.AortaRangeTransverseView != null)
            {
                hcpAaaTestResult.AortaRangeTransverseView.ForEach(finding =>
                {
                    var customerEventTestStandardFindingEntity = new CustomerEventTestStandardFindingEntity()
                    {
                        StandardFindingTestReadingId =
                            (int?)new TestResultService().GetStandardFindingTestReadingIdForStandardFinding
                                ((int)TestType.HCPAAA, (int)ReadingLabels.AortaRangeTransverseView, Convert.ToInt64(finding.Id)),
                        CustomerEventTestStandardFindingId = finding.CustomerEventStandardFindingId,
                        CustomerEventScreeningTestId = testResult.Id
                    };
                    customerEventScreeningTestsEntity.CustomerEventTestStandardFinding.Add(customerEventTestStandardFindingEntity);
                });
            }

            if (customerEventReadingEntities.Count > 0)
                customerEventScreeningTestsEntity.CustomerEventReading.AddRange(customerEventReadingEntities);

            return customerEventScreeningTestsEntity;
        }

        private static decimal? GetMaxofthreeAortaValues(HcpAaaTestResult testResult)
        {
            var aortaValues = new decimal[3];
            int index = 0;

            if (testResult.AortaSize != null && testResult.AortaSize.Reading != null)
                aortaValues[index++] = testResult.AortaSize.Reading.Value;

            if (testResult.TransverseView != null)
            {
                if (testResult.TransverseView.FirstValue != null && testResult.TransverseView.FirstValue.Reading != null)
                    aortaValues[index++] = testResult.TransverseView.FirstValue.Reading.Value;

                if (testResult.TransverseView.SecondValue != null && testResult.TransverseView.SecondValue.Reading != null)
                    aortaValues[index++] = testResult.TransverseView.SecondValue.Reading.Value;
            }

            var aortaValue = aortaValues.Max();
            if (aortaValue > 0) return aortaValue;

            return null;
        }
    }
}
