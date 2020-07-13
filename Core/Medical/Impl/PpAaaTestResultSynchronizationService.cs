using System.Collections.Generic;
using Falcon.App.Core.Extensions;
using Falcon.App.Core.Medical.Domain;
using Falcon.App.Core.Medical.Enum;

namespace Falcon.App.Core.Medical.Impl
{
    public class PpAaaTestResultSynchronizationService : TestResultSynchronizationService
    {
        public PpAaaTestResultSynchronizationService(ReadingSource newReadingSource)
        {
            NewReadingSource = newReadingSource;
        }

        public override TestResult SynchronizeTestResult(TestResult currentTestResult, TestResult newTestResult, bool isNewResultFlow)
        {
            var newAaaTestResult = (PpAaaTestResult)newTestResult;

            if (currentTestResult == null)
            {
                SynchronizeResultReadingsForRecorderMetaData(newTestResult);

                if (newAaaTestResult.AortaSize != null && newAaaTestResult.AortaSize.Reading == null) newAaaTestResult.AortaSize = null;
                if (newAaaTestResult.DiagnosisCode != null && newAaaTestResult.DiagnosisCode.Reading == null) newAaaTestResult.DiagnosisCode = null;
                if (newAaaTestResult.Fusiform != null && newAaaTestResult.Fusiform.Reading == null) newAaaTestResult.Fusiform = null;
                if (newAaaTestResult.Saccular != null && newAaaTestResult.Saccular.Reading == null) newAaaTestResult.Saccular = null;
                if (newAaaTestResult.AorticDissection != null && newAaaTestResult.AorticDissection.Reading == false) newAaaTestResult.AorticDissection = null;
                if (newAaaTestResult.Plaque != null && newAaaTestResult.Plaque.Reading == false) newAaaTestResult.Plaque = null;
                if (newAaaTestResult.Thrombus != null && newAaaTestResult.Thrombus.Reading == false) newAaaTestResult.Thrombus = null;

                if (newAaaTestResult.TransverseView != null)
                {
                    if (newAaaTestResult.TransverseView.FirstValue != null && newAaaTestResult.TransverseView.FirstValue.Reading == null) newAaaTestResult.TransverseView.FirstValue = null;
                    if (newAaaTestResult.TransverseView.SecondValue != null && newAaaTestResult.TransverseView.SecondValue.Reading == null) newAaaTestResult.TransverseView.SecondValue = null;

                    if (newAaaTestResult.TransverseView.FirstValue == null && newAaaTestResult.TransverseView.SecondValue == null)
                        newAaaTestResult.TransverseView = null;
                }

                if (!newAaaTestResult.ResultImages.IsNullOrEmpty())
                {
                    newAaaTestResult.ResultImages = newAaaTestResult.ResultImages.FindAll(resultImage =>
                        resultImage.File != null);

                    if (newAaaTestResult.ResultImages.IsNullOrEmpty()) newAaaTestResult.ResultImages = null;
                }

                SyncronizeTestResult(currentTestResult, newTestResult);

                return newAaaTestResult;
            }

            var currentAaaTestResult = (PpAaaTestResult)currentTestResult;
            newAaaTestResult.Id = currentAaaTestResult.Id;
            newAaaTestResult.ResultStatus.Id = currentAaaTestResult.ResultStatus.Id;

            var isAllReadingforCalcFindingNull = newAaaTestResult.AortaSize == null || newAaaTestResult.AortaSize.Reading == null;

            isAllReadingforCalcFindingNull = isAllReadingforCalcFindingNull && (newAaaTestResult.TransverseView == null || ((newAaaTestResult.TransverseView.FirstValue == null || newAaaTestResult.TransverseView.FirstValue.Reading == null)
                && (newAaaTestResult.TransverseView.SecondValue == null || newAaaTestResult.TransverseView.SecondValue.Reading == null)));

            newAaaTestResult.AortaSize = SynchronizeResultReading(currentAaaTestResult.AortaSize, newAaaTestResult.AortaSize, newTestResult.DataRecorderMetaData);
            newAaaTestResult.DiagnosisCode = SynchronizeResultReading(currentAaaTestResult.DiagnosisCode, newAaaTestResult.DiagnosisCode, newTestResult.DataRecorderMetaData);
            newAaaTestResult.Fusiform = SynchronizeResultReading(currentAaaTestResult.Fusiform, newAaaTestResult.Fusiform, newTestResult.DataRecorderMetaData);
            newAaaTestResult.Saccular = SynchronizeResultReading(currentAaaTestResult.Saccular, newAaaTestResult.Saccular, newTestResult.DataRecorderMetaData);
            newAaaTestResult.Plaque = SynchronizeResultReading(currentAaaTestResult.Plaque, newAaaTestResult.Plaque, newTestResult.DataRecorderMetaData);
            newAaaTestResult.AorticDissection = SynchronizeResultReading(currentAaaTestResult.AorticDissection, newAaaTestResult.AorticDissection, newTestResult.DataRecorderMetaData);
            newAaaTestResult.Thrombus = SynchronizeResultReading(currentAaaTestResult.Thrombus, newAaaTestResult.Thrombus, newTestResult.DataRecorderMetaData);

            if (newAaaTestResult.TransverseView != null)
            {
                newAaaTestResult.TransverseView.FirstValue = SynchronizeResultReading(currentAaaTestResult.TransverseView.FirstValue, newAaaTestResult.TransverseView.FirstValue, newTestResult.DataRecorderMetaData);
                newAaaTestResult.TransverseView.SecondValue = SynchronizeResultReading(currentAaaTestResult.TransverseView.SecondValue, newAaaTestResult.TransverseView.SecondValue, newTestResult.DataRecorderMetaData);
            }

            if (NewReadingSource == ReadingSource.Automatic)
            {
                if (!currentAaaTestResult.ResultImages.IsNullOrEmpty() && !newAaaTestResult.ResultImages.IsNullOrEmpty())
                {
                    List<ResultMedia> resultImages = currentAaaTestResult.ResultImages.FindAll(image => image.ReadingSource == ReadingSource.Manual);

                    if (resultImages.IsNullOrEmpty()) resultImages = newAaaTestResult.ResultImages;
                    else resultImages.AddRange(newAaaTestResult.ResultImages);

                    newAaaTestResult.ResultImages = resultImages;
                }
                else if (!currentAaaTestResult.ResultImages.IsNullOrEmpty())
                {
                    newAaaTestResult.ResultImages = currentAaaTestResult.ResultImages;
                }
            }
            else
            {
                if (!currentAaaTestResult.ResultImages.IsNullOrEmpty() && !newAaaTestResult.ResultImages.IsNullOrEmpty())
                {
                    newAaaTestResult.ResultImages.ForEach(resultImage =>
                    {
                        var selectedImage = currentAaaTestResult.ResultImages.Find(currentImage => currentImage.File.Path == resultImage.File.Path);
                        if (selectedImage != null)
                            resultImage.ReadingSource = selectedImage.ReadingSource;
                    });
                }
            }

            if (NewReadingSource == ReadingSource.Automatic) // Syncing those which didn't come through Uploaded file
            {
                if (newAaaTestResult.Finding == null && currentAaaTestResult.Finding != null && isAllReadingforCalcFindingNull
                    && ((newAaaTestResult.AortaSize != null && newAaaTestResult.AortaSize.Reading != null)
                        ||
                        (newAaaTestResult.TransverseView != null && ((newAaaTestResult.TransverseView.FirstValue != null && newAaaTestResult.TransverseView.FirstValue.Reading != null)
                                                                || (newAaaTestResult.TransverseView.SecondValue != null && newAaaTestResult.TransverseView.SecondValue.Reading != null)))))
                    newAaaTestResult.Finding = currentAaaTestResult.Finding;

                newAaaTestResult = (PpAaaTestResult)SyncronizeTestResultForAutomaticUploadwithManual(currentAaaTestResult, newAaaTestResult);
            }

            SyncronizeTestResult(currentTestResult, newTestResult);
            return newAaaTestResult;
        }

        public override TestResult GetManualEntryUploadStatus(List<ResultReading<int>> compareToResultReadings, TestResult newTestResult, bool isNewResultFlow)
        {
            if (isNewResultFlow)
            {
                var newAaaTestResult = NewResultStateManualEntry(compareToResultReadings, newTestResult);
                if (newAaaTestResult.ResultStatus.Status == TestResultStatus.Complete && newAaaTestResult.ResultStatus.StateNumber == (int)NewTestResultStateNumber.ResultEntryPartial)
                    newAaaTestResult.ResultStatus.StateNumber = (int)NewTestResultStateNumber.ResultEntryCompleted;
                return newAaaTestResult;
            }
            return OldResultStateManualEntry(compareToResultReadings, newTestResult);
        }

        public override TestResult IsTestIncomplete(List<ResultReading<int>> compareToResultReadings, TestResult newTestResult, bool isNewResultFlow)
        {
            var aaaTestResult = newTestResult as PpAaaTestResult;
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

            var newAaaTestResult = (PpAaaTestResult)newTestResult;

            foreach (var reading in compareToResultReadings)
            {
                bool returnStatus;
                switch (reading.Label)
                {
                    case ReadingLabels.AortaSize:
                        returnStatus = SynchronizeForChangeReadingSource(reading.ReadingSource, newAaaTestResult.AortaSize);
                        if (returnStatus)
                        {
                            newAaaTestResult.ResultStatus.StateNumber = (int)TestResultStateNumber.ManualEntry;
                            return newAaaTestResult;
                        }
                        break;

                    case ReadingLabels.DiagnosisCode:
                        returnStatus = SynchronizeForChangeReadingSource(reading.ReadingSource, newAaaTestResult.DiagnosisCode);
                        if (returnStatus)
                        {
                            newAaaTestResult.ResultStatus.StateNumber = (int)TestResultStateNumber.ManualEntry;
                            return newAaaTestResult;
                        }
                        break;

                    case ReadingLabels.IsSaccular:
                        returnStatus = SynchronizeForChangeReadingSource(reading.ReadingSource, newAaaTestResult.Saccular);
                        if (returnStatus)
                        {
                            newAaaTestResult.ResultStatus.StateNumber = (int)TestResultStateNumber.ManualEntry;
                            return newAaaTestResult;
                        }
                        break;

                    case ReadingLabels.IsFusiform:
                        returnStatus = SynchronizeForChangeReadingSource(reading.ReadingSource, newAaaTestResult.Fusiform);
                        if (returnStatus)
                        {
                            newAaaTestResult.ResultStatus.StateNumber = (int)TestResultStateNumber.ManualEntry;
                            return newAaaTestResult;
                        }
                        break;

                    case ReadingLabels.AortaRangeSaggitalView:
                        break;

                    case ReadingLabels.AortaRangeTransverseView:
                        break;

                    case ReadingLabels.TransverseViewDataPointOne:
                        returnStatus = SynchronizeForChangeReadingSource(reading.ReadingSource, newAaaTestResult.TransverseView != null ? newAaaTestResult.TransverseView.FirstValue : null);
                        if (returnStatus)
                        {
                            newAaaTestResult.ResultStatus.StateNumber = (int)TestResultStateNumber.ManualEntry;
                            return newAaaTestResult;
                        }
                        break;

                    case ReadingLabels.TransverseViewDataPointTwo:
                        returnStatus = SynchronizeForChangeReadingSource(reading.ReadingSource, newAaaTestResult.TransverseView != null ? newAaaTestResult.TransverseView.SecondValue : null);
                        if (returnStatus)
                        {
                            newAaaTestResult.ResultStatus.StateNumber = (int)TestResultStateNumber.ManualEntry;
                            return newAaaTestResult;
                        }
                        break;
                }
            }

            if (!newAaaTestResult.ResultImages.IsNullOrEmpty())
            {
                var manuallyUploadedImage = newAaaTestResult.ResultImages.Find(resultImage => resultImage.ReadingSource == ReadingSource.Manual);
                if (manuallyUploadedImage != null)
                {
                    newAaaTestResult.ResultStatus.StateNumber = (int)TestResultStateNumber.ManualEntry;
                    return newAaaTestResult;
                }
            }

            if ((newAaaTestResult.UnableScreenReason != null && newAaaTestResult.UnableScreenReason.Count > 0) || (newAaaTestResult.IncidentalFindings != null && newAaaTestResult.IncidentalFindings.Count > 0))
            {
                newAaaTestResult.ResultStatus.StateNumber = (int)TestResultStateNumber.ManualEntry;
                return newAaaTestResult;
            }

            newAaaTestResult.ResultStatus.StateNumber = (int)TestResultStateNumber.ResultsUploaded;
            return newAaaTestResult;
        }

        private TestResult NewResultStateManualEntry(IEnumerable<ResultReading<int>> compareToResultReadings, TestResult newTestResult)
        {
            if (newTestResult.ResultStatus.StateNumber == (int)NewTestResultStateNumber.PreAudit) return newTestResult;

            var newAaaTestResult = (PpAaaTestResult)newTestResult;

            foreach (var reading in compareToResultReadings)
            {
                bool returnStatus;
                switch (reading.Label)
                {
                    case ReadingLabels.AortaSize:
                        returnStatus = SynchronizeForChangeReadingSource(reading.ReadingSource, newAaaTestResult.AortaSize);
                        if (returnStatus)
                        {
                            newAaaTestResult.ResultStatus.StateNumber = (int)NewTestResultStateNumber.ResultEntryPartial;
                            return newAaaTestResult;
                        }
                        break;

                    case ReadingLabels.DiagnosisCode:
                        returnStatus = SynchronizeForChangeReadingSource(reading.ReadingSource, newAaaTestResult.DiagnosisCode);
                        if (returnStatus)
                        {
                            newAaaTestResult.ResultStatus.StateNumber = (int)NewTestResultStateNumber.ResultEntryPartial;
                            return newAaaTestResult;
                        }
                        break;

                    case ReadingLabels.IsSaccular:
                        returnStatus = SynchronizeForChangeReadingSource(reading.ReadingSource, newAaaTestResult.Saccular);
                        if (returnStatus)
                        {
                            newAaaTestResult.ResultStatus.StateNumber = (int)NewTestResultStateNumber.ResultEntryPartial;
                            return newAaaTestResult;
                        }
                        break;

                    case ReadingLabels.IsFusiform:
                        returnStatus = SynchronizeForChangeReadingSource(reading.ReadingSource, newAaaTestResult.Fusiform);
                        if (returnStatus)
                        {
                            newAaaTestResult.ResultStatus.StateNumber = (int)NewTestResultStateNumber.ResultEntryPartial;
                            return newAaaTestResult;
                        }
                        break;

                    case ReadingLabels.AortaRangeSaggitalView:
                        break;

                    case ReadingLabels.AortaRangeTransverseView:
                        break;

                    case ReadingLabels.TransverseViewDataPointOne:
                        returnStatus = SynchronizeForChangeReadingSource(reading.ReadingSource, newAaaTestResult.TransverseView != null ? newAaaTestResult.TransverseView.FirstValue : null);
                        if (returnStatus)
                        {
                            newAaaTestResult.ResultStatus.StateNumber = (int)NewTestResultStateNumber.ResultEntryPartial;
                            return newAaaTestResult;
                        }
                        break;

                    case ReadingLabels.TransverseViewDataPointTwo:
                        returnStatus = SynchronizeForChangeReadingSource(reading.ReadingSource, newAaaTestResult.TransverseView != null ? newAaaTestResult.TransverseView.SecondValue : null);
                        if (returnStatus)
                        {
                            newAaaTestResult.ResultStatus.StateNumber = (int)NewTestResultStateNumber.ResultEntryPartial;
                            return newAaaTestResult;
                        }
                        break;
                }
            }

            if (!newAaaTestResult.ResultImages.IsNullOrEmpty())
            {
                var manuallyUploadedImage = newAaaTestResult.ResultImages.Find(resultImage => resultImage.ReadingSource == ReadingSource.Manual);
                if (manuallyUploadedImage != null)
                {
                    newAaaTestResult.ResultStatus.StateNumber = (int)NewTestResultStateNumber.ResultEntryPartial;
                    return newAaaTestResult;
                }
            }

            if ((newAaaTestResult.UnableScreenReason != null && newAaaTestResult.UnableScreenReason.Count > 0) || (newAaaTestResult.IncidentalFindings != null && newAaaTestResult.IncidentalFindings.Count > 0))
            {
                newAaaTestResult.ResultStatus.StateNumber = (int)NewTestResultStateNumber.ResultEntryPartial;
                return newAaaTestResult;
            }

            newAaaTestResult.ResultStatus.StateNumber = (int)NewTestResultStateNumber.ResultEntryPartial;
            return newAaaTestResult;
        }
    }
}
