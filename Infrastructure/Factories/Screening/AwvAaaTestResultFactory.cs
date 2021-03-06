﻿using System;
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
    public class AwvAaaTestResultFactory : TestResultFactory
    {
        public long EventId { get; set; }
        public long CustomerId { get; set; }

        public override TestResult CreateActualTestResult(CustomerEventScreeningTestsEntity customerEventScreeningTestsEntity)
        {
            var customerEventReadingEntities = customerEventScreeningTestsEntity.CustomerEventReading.ToList();
            var testResult = new AwvAaaTestResult(customerEventScreeningTestsEntity.CustomerEventScreeningTestId);

            var customerEventTestStandardFindingEntities = customerEventScreeningTestsEntity.CustomerEventTestStandardFinding.ToList();
            var standardFindingTestReadingEntities = customerEventScreeningTestsEntity.StandardFindingTestReadingCollectionViaCustomerEventReading.ToList();
            standardFindingTestReadingEntities.AddRange(customerEventScreeningTestsEntity.StandardFindingTestReadingCollectionViaCustomerEventTestStandardFinding.ToList());

            testResult.AortaSize = CreateResultReadingforNullableDecimal((int)ReadingLabels.AortaSize, customerEventReadingEntities);

            testResult.TransverseView = new OrderedPair<ResultReading<decimal?>, ResultReading<decimal?>>(null, null);
            testResult.TransverseView.FirstValue = CreateResultReadingforNullableDecimal((int)ReadingLabels.TransverseViewDataPointOne, customerEventReadingEntities);
            testResult.TransverseView.SecondValue = CreateResultReadingforNullableDecimal((int)ReadingLabels.TransverseViewDataPointTwo, customerEventReadingEntities);

            testResult.ResidualLumenStandardFindings = new OrderedPair<ResultReading<decimal?>, ResultReading<decimal?>>(null, null);
            testResult.ResidualLumenStandardFindings.FirstValue = CreateResultReadingforNullableDecimal((int)ReadingLabels.ResidualLumenTransverseViewDataPointOne, customerEventReadingEntities);
            testResult.ResidualLumenStandardFindings.SecondValue = CreateResultReadingforNullableDecimal((int)ReadingLabels.ResidualLumenTransverseViewDataPointTwo, customerEventReadingEntities);

            var aortaValue = GetMaxofthreeAortaValues(testResult);
            if (aortaValue != null)
            {
                testResult.Finding = new StandardFinding<decimal?>(Convert.ToInt64((new TestResultService()).GetCalculatedStandardFinding(EventId, CustomerId, aortaValue, (int)TestType.AwvAAA, (int)ReadingLabels.AortaSize)));
            }

            if (testResult.Finding != null)
                testResult.Finding = new TestResultService().GetAllStandardFindings<decimal?>((int)TestType.AwvAAA, (int)ReadingLabels.AortaSize).Find(standardFinding => standardFinding.Id == testResult.Finding.Id);

            testResult.PeakSystolicVelocity = CreateResultReadingforNullableDecimal((int)ReadingLabels.PeakSystolicVelocity, customerEventReadingEntities);

            testResult.AorticDissection = CreateResultReading((int)ReadingLabels.AorticDissection, customerEventReadingEntities);
            testResult.Plaque = CreateResultReading((int)ReadingLabels.Plaque, customerEventReadingEntities);
            testResult.Thrombus = CreateResultReading((int)ReadingLabels.Thrombus, customerEventReadingEntities);
            testResult.TechnicallyLimitedbutReadable = CreateResultReading((int)ReadingLabels.TechnicallyLimitedbutReadable, customerEventReadingEntities);
            testResult.RepeatStudy = CreateResultReading((int)ReadingLabels.RepeatStudy, customerEventReadingEntities);

            var testResultService = new TestResultService();
            var aortaRangeSaggitalViewFindings = testResultService.GetAllStandardFindings<int?>((int)TestType.AwvAAA, (int)ReadingLabels.AortaRangeSaggitalView);
            var peakSystolicSaggitalViewFindings = testResultService.GetAllStandardFindings<int?>((int)TestType.AwvAAA, (int)ReadingLabels.AortaRangeSaggitalView);
            var aortaRangeTransverseViewFindings = testResultService.GetAllStandardFindings<int?>((int)TestType.AwvAAA, (int)ReadingLabels.AortaRangeTransverseView);
            var aortaValueFindings = testResultService.GetAllStandardFindings<int?>((int)TestType.AwvAAA, (int)ReadingLabels.AortaSize);

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

                finding = CreateFindingObject(customerEventTestStandardFindingEntity, peakSystolicSaggitalViewFindings, standardFindingTestReadingEntity, (int?)ReadingLabels.PeakSystolicVelocitySaggitalView);
                if (finding != null)
                {
                    if (testResult.PeakSystolicVelocityStandardFindings == null) testResult.PeakSystolicVelocityStandardFindings = new List<StandardFinding<int>>();
                    testResult.PeakSystolicVelocityStandardFindings.Add(finding); return;
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
            var awvAaaTestResult = testResult as AwvAaaTestResult;
            var customerEventScreeningTestsEntity = new CustomerEventScreeningTestsEntity(testResult.Id) { TestId = (int)TestType.AwvAAA };
            var customerEventReadingEntities = new List<CustomerEventReadingEntity>();

            int? standardFindingTestReadingId = null;
            long findingId = 0;
            var aortaValue = GetMaxofthreeAortaValues(awvAaaTestResult);
            if (aortaValue != null)
            {
                findingId = (new TestResultService()).GetCalculatedStandardFinding(EventId, CustomerId, aortaValue, (int)TestType.AwvAAA, (int)ReadingLabels.AortaSize);

                if (awvAaaTestResult.Finding != null && awvAaaTestResult.Finding.Id != findingId)
                {
                    findingId = awvAaaTestResult.Finding.Id;
                    standardFindingTestReadingId = (int?)new TestResultService().GetStandardFindingTestReadingIdForStandardFinding((int)TestType.AwvAAA, (int)ReadingLabels.AortaSize, awvAaaTestResult.Finding.Id);
                }
            }
            else if (awvAaaTestResult.Finding != null)
            {
                findingId = awvAaaTestResult.Finding.Id;
                standardFindingTestReadingId = (int?)new TestResultService().GetStandardFindingTestReadingIdForStandardFinding((int)TestType.AwvAAA, (int)ReadingLabels.AortaSize, awvAaaTestResult.Finding.Id);
            }

            if (findingId > 0)
            {
                var finding = GetSelectedStandardFinding((int)TestType.AwvAAA, (int)ReadingLabels.AortaSize, findingId);
                if (testResult.ResultStatus.StateNumber == (int)TestResultStateNumber.Evaluated || testResult.ResultStatus.StateNumber == (int)NewTestResultStateNumber.Evaluated)
                {
                    testResult.ResultInterpretation = finding.ResultInterpretation;
                    testResult.PathwayRecommendation = finding.PathwayRecommendation;
                }
            }

            if (standardFindingTestReadingId != null)
            {
                customerEventScreeningTestsEntity.CustomerEventTestStandardFinding.Add(
                            new CustomerEventTestStandardFindingEntity(awvAaaTestResult.Finding.CustomerEventStandardFindingId)
                            {
                                StandardFindingTestReadingId = standardFindingTestReadingId.Value
                            });
            }

            if (awvAaaTestResult.AortaSize != null)
            {
                var customerEventReading = CreateEventReadingEntity(awvAaaTestResult.AortaSize, (int)ReadingLabels.AortaSize, testReadingReadingPairs);
                customerEventReadingEntities.Add(customerEventReading);
            }

            if (awvAaaTestResult.TransverseView != null)
            {
                if (awvAaaTestResult.TransverseView.FirstValue != null)
                {
                    var customerEventReading = CreateEventReadingEntity(awvAaaTestResult.TransverseView.FirstValue, (int)ReadingLabels.TransverseViewDataPointOne, testReadingReadingPairs);
                    customerEventReadingEntities.Add(customerEventReading);
                }

                if (awvAaaTestResult.TransverseView.SecondValue != null)
                {
                    var customerEventReading = CreateEventReadingEntity(awvAaaTestResult.TransverseView.SecondValue, (int)ReadingLabels.TransverseViewDataPointTwo, testReadingReadingPairs);
                    customerEventReadingEntities.Add(customerEventReading);
                }
            }

            if (awvAaaTestResult.ResidualLumenStandardFindings != null)
            {
                if (awvAaaTestResult.ResidualLumenStandardFindings.FirstValue != null)
                {
                    var customerEventReading = CreateEventReadingEntity(awvAaaTestResult.ResidualLumenStandardFindings.FirstValue, (int)ReadingLabels.ResidualLumenTransverseViewDataPointOne, testReadingReadingPairs);
                    customerEventReadingEntities.Add(customerEventReading);
                }

                if (awvAaaTestResult.ResidualLumenStandardFindings.SecondValue != null)
                {
                    var customerEventReading = CreateEventReadingEntity(awvAaaTestResult.ResidualLumenStandardFindings.SecondValue, (int)ReadingLabels.ResidualLumenTransverseViewDataPointTwo, testReadingReadingPairs);
                    customerEventReadingEntities.Add(customerEventReading);
                }
            }

            if (awvAaaTestResult.PeakSystolicVelocity != null)
            {
                var customerEventReading = CreateEventReadingEntity(awvAaaTestResult.PeakSystolicVelocity, (int)ReadingLabels.PeakSystolicVelocity, testReadingReadingPairs);

                customerEventReadingEntities.Add(customerEventReading);
            }


            if (awvAaaTestResult.AorticDissection != null)
            {
                var customerEventReading = CreateEventReadingEntity(awvAaaTestResult.AorticDissection, (int)ReadingLabels.AorticDissection, testReadingReadingPairs);

                customerEventReadingEntities.Add(customerEventReading);
            }

            if (awvAaaTestResult.Plaque != null)
            {
                var customerEventReading = CreateEventReadingEntity(awvAaaTestResult.Plaque, (int)ReadingLabels.Plaque, testReadingReadingPairs);

                customerEventReadingEntities.Add(customerEventReading);
            }

            if (awvAaaTestResult.TechnicallyLimitedbutReadable != null)
            {
                var customerEventReading = CreateEventReadingEntity(awvAaaTestResult.TechnicallyLimitedbutReadable, (int)ReadingLabels.TechnicallyLimitedbutReadable, testReadingReadingPairs);

                customerEventReadingEntities.Add(customerEventReading);
            }

            if (awvAaaTestResult.RepeatStudy != null)
            {
                var customerEventReading = CreateEventReadingEntity(awvAaaTestResult.RepeatStudy, (int)ReadingLabels.RepeatStudy, testReadingReadingPairs);

                customerEventReadingEntities.Add(customerEventReading);
            }

            if (awvAaaTestResult.Thrombus != null)
            {
                var customerEventReading = CreateEventReadingEntity(awvAaaTestResult.Thrombus, (int)ReadingLabels.Thrombus, testReadingReadingPairs);

                customerEventReadingEntities.Add(customerEventReading);
            }

            if (awvAaaTestResult.AortaRangeSaggitalView != null)
            {
                awvAaaTestResult.AortaRangeSaggitalView.ForEach(finding =>
                {
                    var customerEventTestStandardFindingEntity = new CustomerEventTestStandardFindingEntity()
                    {
                        StandardFindingTestReadingId =
                            (int?)new TestResultService().GetStandardFindingTestReadingIdForStandardFinding
                                ((int)TestType.AwvAAA, (int)ReadingLabels.AortaRangeSaggitalView, Convert.ToInt64(finding.Id)),
                        CustomerEventTestStandardFindingId = finding.CustomerEventStandardFindingId,
                        CustomerEventScreeningTestId = testResult.Id
                    };
                    customerEventScreeningTestsEntity.CustomerEventTestStandardFinding.Add(customerEventTestStandardFindingEntity);
                });
            }

            if (awvAaaTestResult.AortaRangeTransverseView != null)
            {
                awvAaaTestResult.AortaRangeTransverseView.ForEach(finding =>
                {
                    var customerEventTestStandardFindingEntity = new CustomerEventTestStandardFindingEntity()
                    {
                        StandardFindingTestReadingId =
                            (int?)new TestResultService().GetStandardFindingTestReadingIdForStandardFinding
                                ((int)TestType.AwvAAA, (int)ReadingLabels.AortaRangeTransverseView, Convert.ToInt64(finding.Id)),
                        CustomerEventTestStandardFindingId = finding.CustomerEventStandardFindingId,
                        CustomerEventScreeningTestId = testResult.Id
                    };
                    customerEventScreeningTestsEntity.CustomerEventTestStandardFinding.Add(customerEventTestStandardFindingEntity);
                });
            }

            if (awvAaaTestResult.PeakSystolicVelocityStandardFindings != null)
            {
                awvAaaTestResult.PeakSystolicVelocityStandardFindings.ForEach(finding =>
                {
                    var customerEventTestStandardFindingEntity = new CustomerEventTestStandardFindingEntity()
                    {
                        StandardFindingTestReadingId =
                            (int?)new TestResultService().GetStandardFindingTestReadingIdForStandardFinding
                                ((int)TestType.AwvAAA, (int)ReadingLabels.PeakSystolicVelocitySaggitalView, Convert.ToInt64(finding.Id)),
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

        private static decimal? GetMaxofthreeAortaValues(AwvAaaTestResult testResult)
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
