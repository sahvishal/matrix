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
    public class AaaTestResultFactory : TestResultFactory
    {
        public override TestResult CreateActualTestResult(CustomerEventScreeningTestsEntity customerEventScreeningTestsEntity)
        {
            var customerEventReadingEntities = customerEventScreeningTestsEntity.CustomerEventReading.ToList();
            var testResult = new AAATestResult(customerEventScreeningTestsEntity.CustomerEventScreeningTestId);

            var customerEventTestStandardFindingEntities = customerEventScreeningTestsEntity.CustomerEventTestStandardFinding.ToList();
            var standardFindingTestReadingEntities = customerEventScreeningTestsEntity.StandardFindingTestReadingCollectionViaCustomerEventReading.ToList();
            standardFindingTestReadingEntities.AddRange(customerEventScreeningTestsEntity.StandardFindingTestReadingCollectionViaCustomerEventTestStandardFinding.ToList());

            testResult.AortaSize = CreateResultReadingforNullableDecimal((int)ReadingLabels.AortaSize, customerEventReadingEntities);

            testResult.TransverseView = new OrderedPair<ResultReading<decimal?>, ResultReading<decimal?>>(null, null);
            testResult.TransverseView.FirstValue = CreateResultReadingforNullableDecimal((int)ReadingLabels.TransverseViewDataPointOne, customerEventReadingEntities);
            testResult.TransverseView.SecondValue = CreateResultReadingforNullableDecimal((int)ReadingLabels.TransverseViewDataPointTwo, customerEventReadingEntities);

            testResult.ConsiderOtherModalities = CreateResultReading((int)ReadingLabels.ConsiderOtherModalities, customerEventReadingEntities);
            testResult.AdditionalImagesNeeded = CreateResultReading((int)ReadingLabels.AdditionalImagesNeeded, customerEventReadingEntities);
            if (!((testResult.ConsiderOtherModalities != null && testResult.ConsiderOtherModalities.Reading)
                  || (testResult.AdditionalImagesNeeded != null && testResult.AdditionalImagesNeeded.Reading)))
            {
                var aortaValue = GetMaxofthreeAortaValues(testResult);
                if (aortaValue != null)
                {
                    testResult.Finding = new StandardFinding<decimal?>(Convert.ToInt64((new TestResultService()).GetCalculatedStandardFinding(aortaValue, (int)TestType.AAA, (int)ReadingLabels.AortaSize)));
                }
            }

            if (testResult.Finding != null)
                testResult.Finding = new TestResultService().GetAllStandardFindings<decimal?>((int)TestType.AAA, (int)ReadingLabels.AortaSize).Find(standardFinding => standardFinding.Id == testResult.Finding.Id);

            testResult.Fusiform = CreateResultReadingforNullableBool((int)ReadingLabels.IsFusiform, customerEventReadingEntities);
            testResult.Saccular = CreateResultReadingforNullableBool((int)ReadingLabels.IsSaccular, customerEventReadingEntities);
            testResult.AorticDissection = CreateResultReading((int)ReadingLabels.AorticDissection, customerEventReadingEntities);
            testResult.Plaque = CreateResultReading((int)ReadingLabels.Plaque, customerEventReadingEntities);
            testResult.Thrombus = CreateResultReading((int)ReadingLabels.Thrombus, customerEventReadingEntities);
            testResult.TechnicallyLimitedbutReadable = CreateResultReading((int)ReadingLabels.TechnicallyLimitedbutReadable, customerEventReadingEntities);
            testResult.RepeatStudy = CreateResultReading((int)ReadingLabels.RepeatStudy, customerEventReadingEntities);
            
            var testResultService = new TestResultService();
            var aortaRangeSaggitalViewFindings = testResultService.GetAllStandardFindings<int?>((int)TestType.AAA, (int)ReadingLabels.AortaRangeSaggitalView);
            var aortaRangeTransverseViewFindings = testResultService.GetAllStandardFindings<int?>((int)TestType.AAA, (int)ReadingLabels.AortaRangeTransverseView);
            var aortaValueFindings = testResultService.GetAllStandardFindings<int?>((int)TestType.AAA, (int)ReadingLabels.AortaSize);

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
            var aaaTestResult = testResult as AAATestResult;
            var customerEventScreeningTestsEntity = new CustomerEventScreeningTestsEntity(testResult.Id) { TestId = (int)TestType.AAA };
            var customerEventReadingEntities = new List<CustomerEventReadingEntity>();

            int? standardFindingTestReadingId = null;
            long findingId = 0;

            if (!((aaaTestResult.ConsiderOtherModalities != null && aaaTestResult.ConsiderOtherModalities.Reading) 
                || (aaaTestResult.AdditionalImagesNeeded != null && aaaTestResult.AdditionalImagesNeeded.Reading)))
            {
                var aortaValue = GetMaxofthreeAortaValues(aaaTestResult);
                if (aortaValue != null)
                {
                    findingId = (new TestResultService()).GetCalculatedStandardFinding(aortaValue, (int)TestType.AAA, (int)ReadingLabels.AortaSize);

                    if (aaaTestResult.Finding != null && aaaTestResult.Finding.Id != findingId)
                    {
                        findingId = aaaTestResult.Finding.Id;
                        standardFindingTestReadingId = (int?)new TestResultService().GetStandardFindingTestReadingIdForStandardFinding((int)TestType.AAA, (int)ReadingLabels.AortaSize, aaaTestResult.Finding.Id);
                    }
                }
                else if (aaaTestResult.Finding != null)
                {
                    findingId = aaaTestResult.Finding.Id;
                    standardFindingTestReadingId = (int?)new TestResultService().GetStandardFindingTestReadingIdForStandardFinding((int)TestType.AAA, (int)ReadingLabels.AortaSize, aaaTestResult.Finding.Id);
                }    
            }
            

            if(findingId > 0)
            {
                var finding = GetSelectedStandardFinding((int) TestType.AAA, (int) ReadingLabels.AortaSize, findingId);
                if (testResult.ResultStatus.StateNumber == (int)TestResultStateNumber.Evaluated || testResult.ResultStatus.StateNumber == (int)NewTestResultStateNumber.Evaluated)
                {
                    testResult.ResultInterpretation = finding.ResultInterpretation;
                    testResult.PathwayRecommendation = finding.PathwayRecommendation;
                }
            }

            if (standardFindingTestReadingId != null)
            {
                customerEventScreeningTestsEntity.CustomerEventTestStandardFinding.Add(
                            new CustomerEventTestStandardFindingEntity(aaaTestResult.Finding.CustomerEventStandardFindingId)
                            {
                                StandardFindingTestReadingId = standardFindingTestReadingId.Value
                            });
            }

            if (aaaTestResult.AortaSize != null)
            {
                var customerEventReading = CreateEventReadingEntity(aaaTestResult.AortaSize, (int)ReadingLabels.AortaSize, testReadingReadingPairs);
                customerEventReadingEntities.Add(customerEventReading);
            }

            if (aaaTestResult.TransverseView != null)
            {
                if (aaaTestResult.TransverseView.FirstValue != null)
                {
                    var customerEventReading = CreateEventReadingEntity(aaaTestResult.TransverseView.FirstValue, (int)ReadingLabels.TransverseViewDataPointOne, testReadingReadingPairs);
                    customerEventReadingEntities.Add(customerEventReading);
                }

                if (aaaTestResult.TransverseView.SecondValue != null)
                {
                    var customerEventReading = CreateEventReadingEntity(aaaTestResult.TransverseView.SecondValue, (int)ReadingLabels.TransverseViewDataPointTwo, testReadingReadingPairs);
                    customerEventReadingEntities.Add(customerEventReading);
                }
            }

            if (aaaTestResult.Fusiform != null)
            {
                var customerEventReading = CreateEventReadingEntity(aaaTestResult.Fusiform, (int)ReadingLabels.IsFusiform, testReadingReadingPairs);

                customerEventReadingEntities.Add(customerEventReading);
            }

            if (aaaTestResult.Saccular != null)
            {
                var customerEventReading = CreateEventReadingEntity(aaaTestResult.Saccular, (int)ReadingLabels.IsSaccular, testReadingReadingPairs);

                customerEventReadingEntities.Add(customerEventReading);
            }

            if (aaaTestResult.AorticDissection != null)
            {
                var customerEventReading = CreateEventReadingEntity(aaaTestResult.AorticDissection, (int)ReadingLabels.AorticDissection, testReadingReadingPairs);

                customerEventReadingEntities.Add(customerEventReading);
            }

            if (aaaTestResult.Plaque != null)
            {
                var customerEventReading = CreateEventReadingEntity(aaaTestResult.Plaque, (int)ReadingLabels.Plaque, testReadingReadingPairs);

                customerEventReadingEntities.Add(customerEventReading);
            }

            if (aaaTestResult.TechnicallyLimitedbutReadable != null)
            {
                var customerEventReading = CreateEventReadingEntity(aaaTestResult.TechnicallyLimitedbutReadable, (int)ReadingLabels.TechnicallyLimitedbutReadable, testReadingReadingPairs);

                customerEventReadingEntities.Add(customerEventReading);
            }

            if (aaaTestResult.RepeatStudy != null)
            {
                var customerEventReading = CreateEventReadingEntity(aaaTestResult.RepeatStudy, (int)ReadingLabels.RepeatStudy, testReadingReadingPairs);

                customerEventReadingEntities.Add(customerEventReading);
            }

            if (aaaTestResult.ConsiderOtherModalities != null)
            {
                var customerEventReading = CreateEventReadingEntity(aaaTestResult.ConsiderOtherModalities, (int)ReadingLabels.ConsiderOtherModalities, testReadingReadingPairs);

                customerEventReadingEntities.Add(customerEventReading);
            }

            if (aaaTestResult.AdditionalImagesNeeded != null)
            {
                var customerEventReading = CreateEventReadingEntity(aaaTestResult.AdditionalImagesNeeded, (int)ReadingLabels.AdditionalImagesNeeded, testReadingReadingPairs);

                customerEventReadingEntities.Add(customerEventReading);
            }

            if (aaaTestResult.Thrombus != null)
            {
                var customerEventReading = CreateEventReadingEntity(aaaTestResult.Thrombus, (int)ReadingLabels.Thrombus, testReadingReadingPairs);

                customerEventReadingEntities.Add(customerEventReading);
            }

            if (aaaTestResult.AortaRangeSaggitalView != null)
            {
                aaaTestResult.AortaRangeSaggitalView.ForEach(finding =>
                {
                    var customerEventTestStandardFindingEntity = new CustomerEventTestStandardFindingEntity()
                    {
                        StandardFindingTestReadingId =
                            (int?)new TestResultService().GetStandardFindingTestReadingIdForStandardFinding
                                ((int)TestType.AAA, (int)ReadingLabels.AortaRangeSaggitalView, Convert.ToInt64(finding.Id)),
                        CustomerEventTestStandardFindingId = finding.CustomerEventStandardFindingId,
                        CustomerEventScreeningTestId = testResult.Id
                    };
                    customerEventScreeningTestsEntity.CustomerEventTestStandardFinding.Add(customerEventTestStandardFindingEntity);
                });
            }

            if (aaaTestResult.AortaRangeTransverseView != null)
            {
                aaaTestResult.AortaRangeTransverseView.ForEach(finding =>
                {
                    var customerEventTestStandardFindingEntity = new CustomerEventTestStandardFindingEntity()
                    {
                        StandardFindingTestReadingId =
                            (int?)new TestResultService().GetStandardFindingTestReadingIdForStandardFinding
                                ((int)TestType.AAA, (int)ReadingLabels.AortaRangeTransverseView, Convert.ToInt64(finding.Id)),
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

        private static decimal? GetMaxofthreeAortaValues(AAATestResult testResult)
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
