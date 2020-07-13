using System.Collections.Generic;
using Falcon.App.Core.Extensions;
using Falcon.App.Core.Medical.Domain;
using Falcon.App.Core.Medical.Enum;

namespace Falcon.App.Core.Medical.Impl
{
    public class HcpAaaTestResultSynchronizationService : TestResultSynchronizationService
    {
        public HcpAaaTestResultSynchronizationService(ReadingSource newReadingSource)
        {
            NewReadingSource = newReadingSource;
        }

        public override TestResult SynchronizeTestResult(TestResult currentTestResult, TestResult newTestResult, bool isNewResultFlow)
        {
            var newHcpAaaTestResult = (HcpAaaTestResult)newTestResult;

            if (currentTestResult == null)
            {
                SynchronizeResultReadingsForRecorderMetaData(newTestResult);

                if (newHcpAaaTestResult.AortaSize != null && newHcpAaaTestResult.AortaSize.Reading == null) newHcpAaaTestResult.AortaSize = null;
                //if (newHcpAaaTestResult.Fusiform != null && newHcpAaaTestResult.Fusiform.Reading == null) newHcpAaaTestResult.Fusiform = null;
                //if (newHcpAaaTestResult.Saccular != null && newHcpAaaTestResult.Saccular.Reading == null) newHcpAaaTestResult.Saccular = null;
                if (newHcpAaaTestResult.AorticDissection != null && newHcpAaaTestResult.AorticDissection.Reading == false) newHcpAaaTestResult.AorticDissection = null;
                if (newHcpAaaTestResult.Plaque != null && newHcpAaaTestResult.Plaque.Reading == false) newHcpAaaTestResult.Plaque = null;
                if (newHcpAaaTestResult.Thrombus != null && newHcpAaaTestResult.Thrombus.Reading == false) newHcpAaaTestResult.Thrombus = null;

                if (newHcpAaaTestResult.TransverseView != null)
                {
                    if (newHcpAaaTestResult.TransverseView.FirstValue != null && newHcpAaaTestResult.TransverseView.FirstValue.Reading == null) newHcpAaaTestResult.TransverseView.FirstValue = null;
                    if (newHcpAaaTestResult.TransverseView.SecondValue != null && newHcpAaaTestResult.TransverseView.SecondValue.Reading == null) newHcpAaaTestResult.TransverseView.SecondValue = null;

                    if (newHcpAaaTestResult.TransverseView.FirstValue == null && newHcpAaaTestResult.TransverseView.SecondValue == null)
                        newHcpAaaTestResult.TransverseView = null;
                }

                if (!newHcpAaaTestResult.ResultImages.IsNullOrEmpty())
                {
                    newHcpAaaTestResult.ResultImages = newHcpAaaTestResult.ResultImages.FindAll(resultImage =>
                        resultImage.File != null);

                    if (newHcpAaaTestResult.ResultImages.IsNullOrEmpty()) newHcpAaaTestResult.ResultImages = null;
                }

                SyncronizeTestResult(currentTestResult, newTestResult);

                return newHcpAaaTestResult;
            }

            var currentHcpAaaTestResult = (HcpAaaTestResult)currentTestResult;
            newHcpAaaTestResult.Id = currentHcpAaaTestResult.Id;
            newHcpAaaTestResult.ResultStatus.Id = currentHcpAaaTestResult.ResultStatus.Id;

            var isAllReadingforCalcFindingNull = newHcpAaaTestResult.AortaSize == null || newHcpAaaTestResult.AortaSize.Reading == null;

            isAllReadingforCalcFindingNull = isAllReadingforCalcFindingNull && (newHcpAaaTestResult.TransverseView == null || ((newHcpAaaTestResult.TransverseView.FirstValue == null || newHcpAaaTestResult.TransverseView.FirstValue.Reading == null)
                && (newHcpAaaTestResult.TransverseView.SecondValue == null || newHcpAaaTestResult.TransverseView.SecondValue.Reading == null)));

            newHcpAaaTestResult.AortaSize = SynchronizeResultReading(currentHcpAaaTestResult.AortaSize, newHcpAaaTestResult.AortaSize, newTestResult.DataRecorderMetaData);
            //newHcpAaaTestResult.Fusiform = SynchronizeResultReading(currentHcpAaaTestResult.Fusiform, newHcpAaaTestResult.Fusiform, newTestResult.DataRecorderMetaData);
            //newHcpAaaTestResult.Saccular = SynchronizeResultReading(currentHcpAaaTestResult.Saccular, newHcpAaaTestResult.Saccular, newTestResult.DataRecorderMetaData);
            newHcpAaaTestResult.Plaque = SynchronizeResultReading(currentHcpAaaTestResult.Plaque, newHcpAaaTestResult.Plaque, newTestResult.DataRecorderMetaData);
            newHcpAaaTestResult.AorticDissection = SynchronizeResultReading(currentHcpAaaTestResult.AorticDissection, newHcpAaaTestResult.AorticDissection, newTestResult.DataRecorderMetaData);
            newHcpAaaTestResult.Thrombus = SynchronizeResultReading(currentHcpAaaTestResult.Thrombus, newHcpAaaTestResult.Thrombus, newTestResult.DataRecorderMetaData);

            if (newHcpAaaTestResult.TransverseView != null)
            {
                newHcpAaaTestResult.TransverseView.FirstValue = SynchronizeResultReading(currentHcpAaaTestResult.TransverseView.FirstValue, newHcpAaaTestResult.TransverseView.FirstValue, newTestResult.DataRecorderMetaData);
                newHcpAaaTestResult.TransverseView.SecondValue = SynchronizeResultReading(currentHcpAaaTestResult.TransverseView.SecondValue, newHcpAaaTestResult.TransverseView.SecondValue, newTestResult.DataRecorderMetaData);
            }

            if (NewReadingSource == ReadingSource.Automatic)
            {
                if (!currentHcpAaaTestResult.ResultImages.IsNullOrEmpty() && !newHcpAaaTestResult.ResultImages.IsNullOrEmpty())
                {
                    List<ResultMedia> resultImages = currentHcpAaaTestResult.ResultImages.FindAll(image => image.ReadingSource == ReadingSource.Manual);

                    if (resultImages.IsNullOrEmpty()) resultImages = newHcpAaaTestResult.ResultImages;
                    else resultImages.AddRange(newHcpAaaTestResult.ResultImages);

                    newHcpAaaTestResult.ResultImages = resultImages;
                }
                else if (!currentHcpAaaTestResult.ResultImages.IsNullOrEmpty())
                {
                    newHcpAaaTestResult.ResultImages = currentHcpAaaTestResult.ResultImages;
                }
            }
            else
            {
                if (!currentHcpAaaTestResult.ResultImages.IsNullOrEmpty() && !newHcpAaaTestResult.ResultImages.IsNullOrEmpty())
                {
                    newHcpAaaTestResult.ResultImages.ForEach(resultImage =>
                    {
                        var selectedImage = currentHcpAaaTestResult.ResultImages.Find(currentImage => currentImage.File.Path == resultImage.File.Path);
                        if (selectedImage != null)
                            resultImage.ReadingSource = selectedImage.ReadingSource;
                    });
                }
            }

            if (NewReadingSource == ReadingSource.Automatic) // Syncing those which didn't come through Uploaded file
            {
                if (newHcpAaaTestResult.Finding == null && currentHcpAaaTestResult.Finding != null && isAllReadingforCalcFindingNull
                    && ((newHcpAaaTestResult.AortaSize != null && newHcpAaaTestResult.AortaSize.Reading != null)
                        ||
                        (newHcpAaaTestResult.TransverseView != null && ((newHcpAaaTestResult.TransverseView.FirstValue != null && newHcpAaaTestResult.TransverseView.FirstValue.Reading != null)
                                                                || (newHcpAaaTestResult.TransverseView.SecondValue != null && newHcpAaaTestResult.TransverseView.SecondValue.Reading != null)))))
                    newHcpAaaTestResult.Finding = currentHcpAaaTestResult.Finding;

                newHcpAaaTestResult = (HcpAaaTestResult)SyncronizeTestResultForAutomaticUploadwithManual(currentHcpAaaTestResult, newHcpAaaTestResult);
            }

            SyncronizeTestResult(currentTestResult, newTestResult);
            return newHcpAaaTestResult;
        }

        public override TestResult GetManualEntryUploadStatus(List<ResultReading<int>> compareToResultReadings, TestResult newTestResult, bool isNewResultFlow)
        {
            if (isNewResultFlow)
            {
                var newHcpAaaTestResult = NewResultStateManualEntry(compareToResultReadings, newTestResult);
                if (newHcpAaaTestResult.ResultStatus.Status == TestResultStatus.Complete && newHcpAaaTestResult.ResultStatus.StateNumber == (int)NewTestResultStateNumber.ResultEntryPartial)
                    newHcpAaaTestResult.ResultStatus.StateNumber = (int)NewTestResultStateNumber.ResultEntryCompleted;
                return newHcpAaaTestResult;
            }
            return OldResultStateManualEntry(compareToResultReadings, newTestResult);
        }

        public override TestResult IsTestIncomplete(List<ResultReading<int>> compareToResultReadings, TestResult newTestResult, bool isNewResultFlow)
        {
            var aaaTestResult = newTestResult as HcpAaaTestResult;
            if (aaaTestResult == null) return null;

            if (aaaTestResult.TestPerformedExternally != null)
            {
                if (aaaTestResult.TestPerformedExternally.ResultEntryTypeId == (long)ResultEntryType.Chat && aaaTestResult.TestPerformedExternally.EntryCompleted)
                {
                    newTestResult.ResultStatus.Status = TestResultStatus.Complete;
                }
                else
                {
                    newTestResult.ResultStatus.Status = TestResultStatus.Incomplete;
                }
                return aaaTestResult;
            }

            bool isAortaSizeComplete, isRangeSagComplete, isRangeTransComplete, isDpOneTransComplete, isDpTwoTransComplete;

            isAortaSizeComplete =
                isRangeSagComplete = isRangeTransComplete = isDpOneTransComplete = isDpTwoTransComplete = true;

            foreach (var resultReading in compareToResultReadings)
            {
                switch (resultReading.Label)
                {
                    case ReadingLabels.AortaSize:
                        if (aaaTestResult.AortaSize == null)
                            isAortaSizeComplete = false;
                        break;

                    case ReadingLabels.AortaRangeSaggitalView:
                        if (aaaTestResult.AortaRangeSaggitalView == null || aaaTestResult.AortaRangeSaggitalView.Count < 1)
                            isRangeSagComplete = false;
                        break;

                    case ReadingLabels.AortaRangeTransverseView:
                        if (aaaTestResult.AortaRangeTransverseView == null || aaaTestResult.AortaRangeTransverseView.Count < 1)
                            isRangeTransComplete = false;
                        break;

                    case ReadingLabels.TransverseViewDataPointOne:
                        if (aaaTestResult.TransverseView == null || aaaTestResult.TransverseView.FirstValue == null)
                            isDpOneTransComplete = false;
                        break;

                    case ReadingLabels.TransverseViewDataPointTwo:
                        if (aaaTestResult.TransverseView == null || aaaTestResult.TransverseView.SecondValue == null)
                            isDpTwoTransComplete = false;
                        break;
                }
            }

            if (!((isAortaSizeComplete && isRangeSagComplete) || (isDpTwoTransComplete && isDpOneTransComplete && isRangeTransComplete)) || aaaTestResult.Finding == null || aaaTestResult.ResultImages == null || aaaTestResult.ResultImages.Count < 1)
            {
                newTestResult.ResultStatus.Status = TestResultStatus.Incomplete;
                return newTestResult;
            }

            newTestResult.ResultStatus.Status = TestResultStatus.Complete;
            return aaaTestResult;
        }

        private TestResult OldResultStateManualEntry(IEnumerable<ResultReading<int>> compareToResultReadings, TestResult newTestResult)
        {
            if (newTestResult.ResultStatus.StateNumber == (int)TestResultStateNumber.PreAudit) return newTestResult;

            var newHcpAaaTestResult = (HcpAaaTestResult)newTestResult;

            foreach (var reading in compareToResultReadings)
            {
                bool returnStatus;
                switch (reading.Label)
                {
                    case ReadingLabels.AortaSize:
                        returnStatus = SynchronizeForChangeReadingSource(reading.ReadingSource, newHcpAaaTestResult.AortaSize);
                        if (returnStatus)
                        {
                            newHcpAaaTestResult.ResultStatus.StateNumber = (int)TestResultStateNumber.ManualEntry;
                            return newHcpAaaTestResult;
                        }
                        break;

                    //case ReadingLabels.IsSaccular:
                    //    returnStatus = SynchronizeForChangeReadingSource(reading.ReadingSource, newHcpAaaTestResult.Saccular);
                    //    if (returnStatus)
                    //    {
                    //        newHcpAaaTestResult.ResultStatus.StateNumber = TestResultStateNumber.ManualEntry;
                    //        return newHcpAaaTestResult;
                    //    }
                    //    break;

                    //case ReadingLabels.IsFusiform:
                    //    returnStatus = SynchronizeForChangeReadingSource(reading.ReadingSource, newHcpAaaTestResult.Fusiform);
                    //    if (returnStatus)
                    //    {
                    //        newHcpAaaTestResult.ResultStatus.StateNumber = TestResultStateNumber.ManualEntry;
                    //        return newHcpAaaTestResult;
                    //    }
                    //    break;

                    case ReadingLabels.AortaRangeSaggitalView:
                        break;

                    case ReadingLabels.AortaRangeTransverseView:
                        break;

                    case ReadingLabels.TransverseViewDataPointOne:
                        returnStatus = SynchronizeForChangeReadingSource(reading.ReadingSource, newHcpAaaTestResult.TransverseView != null ? newHcpAaaTestResult.TransverseView.FirstValue : null);
                        if (returnStatus)
                        {
                            newHcpAaaTestResult.ResultStatus.StateNumber = (int)TestResultStateNumber.ManualEntry;
                            return newHcpAaaTestResult;
                        }
                        break;

                    case ReadingLabels.TransverseViewDataPointTwo:
                        returnStatus = SynchronizeForChangeReadingSource(reading.ReadingSource, newHcpAaaTestResult.TransverseView != null ? newHcpAaaTestResult.TransverseView.SecondValue : null);
                        if (returnStatus)
                        {
                            newHcpAaaTestResult.ResultStatus.StateNumber = (int)TestResultStateNumber.ManualEntry;
                            return newHcpAaaTestResult;
                        }
                        break;
                }
            }

            if (!newHcpAaaTestResult.ResultImages.IsNullOrEmpty())
            {
                var manuallyUploadedImage = newHcpAaaTestResult.ResultImages.Find(resultImage => resultImage.ReadingSource == ReadingSource.Manual);
                if (manuallyUploadedImage != null)
                {
                    newHcpAaaTestResult.ResultStatus.StateNumber = (int)TestResultStateNumber.ManualEntry;
                    return newHcpAaaTestResult;
                }
            }

            if ((newHcpAaaTestResult.UnableScreenReason != null && newHcpAaaTestResult.UnableScreenReason.Count > 0) || (newHcpAaaTestResult.IncidentalFindings != null && newHcpAaaTestResult.IncidentalFindings.Count > 0))
            {
                newHcpAaaTestResult.ResultStatus.StateNumber = (int)TestResultStateNumber.ManualEntry;
                return newHcpAaaTestResult;
            }

            newHcpAaaTestResult.ResultStatus.StateNumber = (int)TestResultStateNumber.ResultsUploaded;
            return newHcpAaaTestResult;
        }

        private TestResult NewResultStateManualEntry(IEnumerable<ResultReading<int>> compareToResultReadings, TestResult newTestResult)
        {
            if (newTestResult.ResultStatus.StateNumber == (int)NewTestResultStateNumber.PreAudit) return newTestResult;

            var newHcpAaaTestResult = (HcpAaaTestResult)newTestResult;

            foreach (var reading in compareToResultReadings)
            {
                bool returnStatus;
                switch (reading.Label)
                {
                    case ReadingLabels.AortaSize:
                        returnStatus = SynchronizeForChangeReadingSource(reading.ReadingSource, newHcpAaaTestResult.AortaSize);
                        if (returnStatus)
                        {
                            newHcpAaaTestResult.ResultStatus.StateNumber = (int)NewTestResultStateNumber.ResultEntryPartial;
                            return newHcpAaaTestResult;
                        }
                        break;

                    //case ReadingLabels.IsSaccular:
                    //    returnStatus = SynchronizeForChangeReadingSource(reading.ReadingSource, newHcpAaaTestResult.Saccular);
                    //    if (returnStatus)
                    //    {
                    //        newHcpAaaTestResult.ResultStatus.StateNumber = NewTestResultStateNumber.ResultEntryPartial;
                    //        return newHcpAaaTestResult;
                    //    }
                    //    break;

                    //case ReadingLabels.IsFusiform:
                    //    returnStatus = SynchronizeForChangeReadingSource(reading.ReadingSource, newHcpAaaTestResult.Fusiform);
                    //    if (returnStatus)
                    //    {
                    //        newHcpAaaTestResult.ResultStatus.StateNumber = NewTestResultStateNumber.ResultEntryPartial;
                    //        return newHcpAaaTestResult;
                    //    }
                    //    break;

                    case ReadingLabels.AortaRangeSaggitalView:
                        break;

                    case ReadingLabels.AortaRangeTransverseView:
                        break;

                    case ReadingLabels.TransverseViewDataPointOne:
                        returnStatus = SynchronizeForChangeReadingSource(reading.ReadingSource, newHcpAaaTestResult.TransverseView != null ? newHcpAaaTestResult.TransverseView.FirstValue : null);
                        if (returnStatus)
                        {
                            newHcpAaaTestResult.ResultStatus.StateNumber = (int)NewTestResultStateNumber.ResultEntryPartial;
                            return newHcpAaaTestResult;
                        }
                        break;

                    case ReadingLabels.TransverseViewDataPointTwo:
                        returnStatus = SynchronizeForChangeReadingSource(reading.ReadingSource, newHcpAaaTestResult.TransverseView != null ? newHcpAaaTestResult.TransverseView.SecondValue : null);
                        if (returnStatus)
                        {
                            newHcpAaaTestResult.ResultStatus.StateNumber = (int)NewTestResultStateNumber.ResultEntryPartial;
                            return newHcpAaaTestResult;
                        }
                        break;
                }
            }

            if (!newHcpAaaTestResult.ResultImages.IsNullOrEmpty())
            {
                var manuallyUploadedImage = newHcpAaaTestResult.ResultImages.Find(resultImage => resultImage.ReadingSource == ReadingSource.Manual);
                if (manuallyUploadedImage != null)
                {
                    newHcpAaaTestResult.ResultStatus.StateNumber = (int)NewTestResultStateNumber.ResultEntryPartial;
                    return newHcpAaaTestResult;
                }
            }

            if ((newHcpAaaTestResult.UnableScreenReason != null && newHcpAaaTestResult.UnableScreenReason.Count > 0) || (newHcpAaaTestResult.IncidentalFindings != null && newHcpAaaTestResult.IncidentalFindings.Count > 0))
            {
                newHcpAaaTestResult.ResultStatus.StateNumber = (int)NewTestResultStateNumber.ResultEntryPartial;
                return newHcpAaaTestResult;
            }

            newHcpAaaTestResult.ResultStatus.StateNumber = (int)NewTestResultStateNumber.ResultEntryPartial;
            return newHcpAaaTestResult;
        }
    }
}
