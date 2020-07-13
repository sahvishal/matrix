using System.Collections.Generic;
using Falcon.App.Core.Extensions;
using Falcon.App.Core.Medical.Domain;
using Falcon.App.Core.Medical.Enum;

namespace Falcon.App.Core.Medical.Impl
{
    public class AwvAaaTestResultSynchronizationService : TestResultSynchronizationService
    {
        public AwvAaaTestResultSynchronizationService(ReadingSource newReadingSource)
        {
            NewReadingSource = newReadingSource;
        }

        public override TestResult SynchronizeTestResult(TestResult currentTestResult, TestResult newTestResult, bool isNewResultFlow)
        {
            var newAwvAaaTestResult = (AwvAaaTestResult)newTestResult;

            if (currentTestResult == null)
            {
                SynchronizeResultReadingsForRecorderMetaData(newTestResult);

                if (newAwvAaaTestResult.AortaSize != null && newAwvAaaTestResult.AortaSize.Reading == null) newAwvAaaTestResult.AortaSize = null;
                if (newAwvAaaTestResult.PeakSystolicVelocity != null && newAwvAaaTestResult.PeakSystolicVelocity.Reading == null) newAwvAaaTestResult.PeakSystolicVelocity = null;
                if (newAwvAaaTestResult.AorticDissection != null && newAwvAaaTestResult.AorticDissection.Reading == false) newAwvAaaTestResult.AorticDissection = null;
                if (newAwvAaaTestResult.Plaque != null && newAwvAaaTestResult.Plaque.Reading == false) newAwvAaaTestResult.Plaque = null;
                if (newAwvAaaTestResult.Thrombus != null && newAwvAaaTestResult.Thrombus.Reading == false) newAwvAaaTestResult.Thrombus = null;

                if (newAwvAaaTestResult.TransverseView != null)
                {
                    if (newAwvAaaTestResult.TransverseView.FirstValue != null && newAwvAaaTestResult.TransverseView.FirstValue.Reading == null) newAwvAaaTestResult.TransverseView.FirstValue = null;
                    if (newAwvAaaTestResult.TransverseView.SecondValue != null && newAwvAaaTestResult.TransverseView.SecondValue.Reading == null) newAwvAaaTestResult.TransverseView.SecondValue = null;

                    if (newAwvAaaTestResult.TransverseView.FirstValue == null && newAwvAaaTestResult.TransverseView.SecondValue == null)
                        newAwvAaaTestResult.TransverseView = null;
                }

                if (newAwvAaaTestResult.ResidualLumenStandardFindings != null)
                {
                    if (newAwvAaaTestResult.ResidualLumenStandardFindings.FirstValue != null && newAwvAaaTestResult.ResidualLumenStandardFindings.FirstValue.Reading == null) newAwvAaaTestResult.ResidualLumenStandardFindings.FirstValue = null;
                    if (newAwvAaaTestResult.ResidualLumenStandardFindings.SecondValue != null && newAwvAaaTestResult.ResidualLumenStandardFindings.SecondValue.Reading == null) newAwvAaaTestResult.ResidualLumenStandardFindings.SecondValue = null;

                    if (newAwvAaaTestResult.ResidualLumenStandardFindings.FirstValue == null && newAwvAaaTestResult.ResidualLumenStandardFindings.SecondValue == null)
                        newAwvAaaTestResult.ResidualLumenStandardFindings = null;
                }

                if (!newAwvAaaTestResult.ResultImages.IsNullOrEmpty())
                {
                    newAwvAaaTestResult.ResultImages = newAwvAaaTestResult.ResultImages.FindAll(resultImage => resultImage.File != null);

                    if (newAwvAaaTestResult.ResultImages.IsNullOrEmpty()) newAwvAaaTestResult.ResultImages = null;
                }

                SyncronizeTestResult(currentTestResult, newTestResult);

                return newAwvAaaTestResult;
            }

            var currentAwvAaaTestResult = (AwvAaaTestResult)currentTestResult;
            newAwvAaaTestResult.Id = currentAwvAaaTestResult.Id;
            newAwvAaaTestResult.ResultStatus.Id = currentAwvAaaTestResult.ResultStatus.Id;

            var isAllReadingforCalcFindingNull = newAwvAaaTestResult.AortaSize == null || newAwvAaaTestResult.AortaSize.Reading == null;

            isAllReadingforCalcFindingNull = isAllReadingforCalcFindingNull &&
                (newAwvAaaTestResult.TransverseView == null || ((newAwvAaaTestResult.TransverseView.FirstValue == null || newAwvAaaTestResult.TransverseView.FirstValue.Reading == null)
                && (newAwvAaaTestResult.TransverseView.SecondValue == null || newAwvAaaTestResult.TransverseView.SecondValue.Reading == null)));

            newAwvAaaTestResult.AortaSize = SynchronizeResultReading(currentAwvAaaTestResult.AortaSize, newAwvAaaTestResult.AortaSize, newTestResult.DataRecorderMetaData);
            newAwvAaaTestResult.PeakSystolicVelocity = SynchronizeResultReading(currentAwvAaaTestResult.PeakSystolicVelocity, newAwvAaaTestResult.PeakSystolicVelocity, newTestResult.DataRecorderMetaData);
            newAwvAaaTestResult.Plaque = SynchronizeResultReading(currentAwvAaaTestResult.Plaque, newAwvAaaTestResult.Plaque, newTestResult.DataRecorderMetaData);
            newAwvAaaTestResult.AorticDissection = SynchronizeResultReading(currentAwvAaaTestResult.AorticDissection, newAwvAaaTestResult.AorticDissection, newTestResult.DataRecorderMetaData);
            newAwvAaaTestResult.Thrombus = SynchronizeResultReading(currentAwvAaaTestResult.Thrombus, newAwvAaaTestResult.Thrombus, newTestResult.DataRecorderMetaData);

            if (newAwvAaaTestResult.TransverseView != null)
            {
                newAwvAaaTestResult.TransverseView.FirstValue = SynchronizeResultReading(currentAwvAaaTestResult.TransverseView.FirstValue, newAwvAaaTestResult.TransverseView.FirstValue, newTestResult.DataRecorderMetaData);
                newAwvAaaTestResult.TransverseView.SecondValue = SynchronizeResultReading(currentAwvAaaTestResult.TransverseView.SecondValue, newAwvAaaTestResult.TransverseView.SecondValue, newTestResult.DataRecorderMetaData);
            }

            if (newAwvAaaTestResult.ResidualLumenStandardFindings != null)
            {
                newAwvAaaTestResult.ResidualLumenStandardFindings.FirstValue = SynchronizeResultReading(currentAwvAaaTestResult.ResidualLumenStandardFindings.FirstValue, newAwvAaaTestResult.ResidualLumenStandardFindings.FirstValue, newTestResult.DataRecorderMetaData);
                newAwvAaaTestResult.ResidualLumenStandardFindings.SecondValue = SynchronizeResultReading(currentAwvAaaTestResult.ResidualLumenStandardFindings.SecondValue, newAwvAaaTestResult.ResidualLumenStandardFindings.SecondValue, newTestResult.DataRecorderMetaData);
            }

            if (NewReadingSource == ReadingSource.Automatic)
            {
                if (!currentAwvAaaTestResult.ResultImages.IsNullOrEmpty() && !newAwvAaaTestResult.ResultImages.IsNullOrEmpty())
                {
                    List<ResultMedia> resultImages = currentAwvAaaTestResult.ResultImages.FindAll(image => image.ReadingSource == ReadingSource.Manual);

                    if (resultImages.IsNullOrEmpty()) resultImages = newAwvAaaTestResult.ResultImages;
                    else resultImages.AddRange(newAwvAaaTestResult.ResultImages);

                    newAwvAaaTestResult.ResultImages = resultImages;
                }
                else if (!currentAwvAaaTestResult.ResultImages.IsNullOrEmpty())
                {
                    newAwvAaaTestResult.ResultImages = currentAwvAaaTestResult.ResultImages;
                }
            }
            else
            {
                if (!currentAwvAaaTestResult.ResultImages.IsNullOrEmpty() && !newAwvAaaTestResult.ResultImages.IsNullOrEmpty())
                {
                    newAwvAaaTestResult.ResultImages.ForEach(resultImage =>
                    {
                        var selectedImage = currentAwvAaaTestResult.ResultImages.Find(currentImage => currentImage.File.Path == resultImage.File.Path);
                        if (selectedImage != null)
                            resultImage.ReadingSource = selectedImage.ReadingSource;
                    });
                }
            }

            if (NewReadingSource == ReadingSource.Automatic) // Syncing those which didn't come through Uploaded file
            {
                if (newAwvAaaTestResult.Finding == null && currentAwvAaaTestResult.Finding != null && isAllReadingforCalcFindingNull
                    && ((newAwvAaaTestResult.AortaSize != null && newAwvAaaTestResult.AortaSize.Reading != null)
                        ||
                        (newAwvAaaTestResult.TransverseView != null && ((newAwvAaaTestResult.TransverseView.FirstValue != null && newAwvAaaTestResult.TransverseView.FirstValue.Reading != null)
                                                                || (newAwvAaaTestResult.TransverseView.SecondValue != null && newAwvAaaTestResult.TransverseView.SecondValue.Reading != null)))))
                    newAwvAaaTestResult.Finding = currentAwvAaaTestResult.Finding;

                newAwvAaaTestResult = (AwvAaaTestResult)SyncronizeTestResultForAutomaticUploadwithManual(currentAwvAaaTestResult, newAwvAaaTestResult);
            }

            SyncronizeTestResult(currentTestResult, newTestResult);
            return newAwvAaaTestResult;
        }

        public override TestResult GetManualEntryUploadStatus(List<ResultReading<int>> compareToResultReadings, TestResult newTestResult, bool isNewResultFlow)
        {
            if (isNewResultFlow)
            {
                var newAwvAaaTestResult = NewResultStateManualEntry(compareToResultReadings, newTestResult);
                if (newAwvAaaTestResult.ResultStatus.Status == TestResultStatus.Complete && newAwvAaaTestResult.ResultStatus.StateNumber == (int)NewTestResultStateNumber.ResultEntryPartial)
                    newAwvAaaTestResult.ResultStatus.StateNumber = (int)NewTestResultStateNumber.ResultEntryCompleted;
                return newAwvAaaTestResult;
            }
            return OldResultStateManualEntry(compareToResultReadings, newTestResult);
        }

        public override TestResult IsTestIncomplete(List<ResultReading<int>> compareToResultReadings, TestResult newTestResult, bool isNewResultFlow)
        {
            var awvAaaTestResult = newTestResult as AwvAaaTestResult;
            if (awvAaaTestResult == null) return null;

            if (awvAaaTestResult.TestPerformedExternally != null)
            {
                if (awvAaaTestResult.TestPerformedExternally.ResultEntryTypeId == (long)ResultEntryType.Chat && awvAaaTestResult.TestPerformedExternally.EntryCompleted)
                {
                    newTestResult.ResultStatus.Status = TestResultStatus.Complete;
                }
                else
                {
                    newTestResult.ResultStatus.Status = TestResultStatus.Incomplete;
                }
                return awvAaaTestResult;
            }

            bool isAortaSizeComplete, isRangeSagComplete, isRangeTransComplete, isDpOneTransComplete, isDpTwoTransComplete;

            isAortaSizeComplete =
                isRangeSagComplete = isRangeTransComplete = isDpOneTransComplete = isDpTwoTransComplete = true;

            var isDpOneResidualComplete = true;
            var isDpTwoResidualComplete = true;
            var isRangePeakSystolicVelocityComplete = true;
            var isPeakSystolicVelocityComplete = true;
            foreach (var resultReading in compareToResultReadings)
            {
                switch (resultReading.Label)
                {
                    case ReadingLabels.AortaSize:
                        if (awvAaaTestResult.AortaSize == null)
                            isAortaSizeComplete = false;
                        break;

                    case ReadingLabels.AortaRangeSaggitalView:
                        if (awvAaaTestResult.AortaRangeSaggitalView == null || awvAaaTestResult.AortaRangeSaggitalView.Count < 1)
                            isRangeSagComplete = false;
                        break;

                    case ReadingLabels.AortaRangeTransverseView:
                        if (awvAaaTestResult.AortaRangeTransverseView == null || awvAaaTestResult.AortaRangeTransverseView.Count < 1)
                            isRangeTransComplete = false;
                        break;

                    case ReadingLabels.TransverseViewDataPointOne:
                        if (awvAaaTestResult.TransverseView == null || awvAaaTestResult.TransverseView.FirstValue == null)
                            isDpOneTransComplete = false;
                        break;

                    case ReadingLabels.TransverseViewDataPointTwo:
                        if (awvAaaTestResult.TransverseView == null || awvAaaTestResult.TransverseView.SecondValue == null)
                            isDpTwoTransComplete = false;
                        break;

                    case ReadingLabels.PeakSystolicVelocity:
                        if (awvAaaTestResult.PeakSystolicVelocity == null)
                            isPeakSystolicVelocityComplete = false;
                        break;
                    case ReadingLabels.PeakSystolicVelocitySaggitalView:
                        if (awvAaaTestResult.PeakSystolicVelocityStandardFindings == null || awvAaaTestResult.PeakSystolicVelocityStandardFindings.Count < 1)
                            isRangePeakSystolicVelocityComplete = false;
                        break;

                    case ReadingLabels.ResidualLumenTransverseViewDataPointOne:
                        if (awvAaaTestResult.ResidualLumenStandardFindings == null || awvAaaTestResult.ResidualLumenStandardFindings.FirstValue == null)
                            isDpOneResidualComplete = false;
                        break;

                    case ReadingLabels.ResidualLumenTransverseViewDataPointTwo:
                        if (awvAaaTestResult.ResidualLumenStandardFindings == null || awvAaaTestResult.ResidualLumenStandardFindings.SecondValue == null)
                            isDpTwoResidualComplete = false;
                        break;
                }
            }

            if (!((isAortaSizeComplete && isRangeSagComplete) || (isDpTwoTransComplete && isDpOneTransComplete && isRangeTransComplete) || (isDpOneResidualComplete && isDpTwoResidualComplete) || (isPeakSystolicVelocityComplete && isRangePeakSystolicVelocityComplete)) || awvAaaTestResult.Finding == null || awvAaaTestResult.ResultImages == null || awvAaaTestResult.ResultImages.Count < 1)
            {
                newTestResult.ResultStatus.Status = TestResultStatus.Incomplete;
                return newTestResult;
            }

            newTestResult.ResultStatus.Status = TestResultStatus.Complete;
            return awvAaaTestResult;
        }

        private TestResult OldResultStateManualEntry(IEnumerable<ResultReading<int>> compareToResultReadings, TestResult newTestResult)
        {
            if (newTestResult.ResultStatus.StateNumber == (int)TestResultStateNumber.PreAudit) return newTestResult;

            var newAwvAaaTestResult = (AwvAaaTestResult)newTestResult;

            foreach (var reading in compareToResultReadings)
            {
                bool returnStatus;
                switch (reading.Label)
                {
                    case ReadingLabels.AortaSize:
                        returnStatus = SynchronizeForChangeReadingSource(reading.ReadingSource, newAwvAaaTestResult.AortaSize);
                        if (returnStatus)
                        {
                            newAwvAaaTestResult.ResultStatus.StateNumber = (int)TestResultStateNumber.ManualEntry;
                            return newAwvAaaTestResult;
                        }
                        break;

                    case ReadingLabels.PeakSystolicVelocity:
                        returnStatus = SynchronizeForChangeReadingSource(reading.ReadingSource, newAwvAaaTestResult.PeakSystolicVelocity);
                        if (returnStatus)
                        {
                            newAwvAaaTestResult.ResultStatus.StateNumber = (int)TestResultStateNumber.ManualEntry;
                            return newAwvAaaTestResult;
                        }
                        break;

                    case ReadingLabels.AortaRangeSaggitalView:
                        break;

                    case ReadingLabels.AortaRangeTransverseView:
                        break;

                    case ReadingLabels.PeakSystolicVelocitySaggitalView:
                        break;

                    case ReadingLabels.TransverseViewDataPointOne:
                        returnStatus = SynchronizeForChangeReadingSource(reading.ReadingSource, newAwvAaaTestResult.TransverseView != null ? newAwvAaaTestResult.TransverseView.FirstValue : null);
                        if (returnStatus)
                        {
                            newAwvAaaTestResult.ResultStatus.StateNumber = (int)TestResultStateNumber.ManualEntry;
                            return newAwvAaaTestResult;
                        }
                        break;

                    case ReadingLabels.TransverseViewDataPointTwo:
                        returnStatus = SynchronizeForChangeReadingSource(reading.ReadingSource, newAwvAaaTestResult.TransverseView != null ? newAwvAaaTestResult.TransverseView.SecondValue : null);
                        if (returnStatus)
                        {
                            newAwvAaaTestResult.ResultStatus.StateNumber = (int)TestResultStateNumber.ManualEntry;
                            return newAwvAaaTestResult;
                        }
                        break;
                    case ReadingLabels.ResidualLumenTransverseViewDataPointOne:
                        returnStatus = SynchronizeForChangeReadingSource(reading.ReadingSource, newAwvAaaTestResult.ResidualLumenStandardFindings != null ? newAwvAaaTestResult.ResidualLumenStandardFindings.FirstValue : null);
                        if (returnStatus)
                        {
                            newAwvAaaTestResult.ResultStatus.StateNumber = (int)TestResultStateNumber.ManualEntry;
                            return newAwvAaaTestResult;
                        }
                        break;

                    case ReadingLabels.ResidualLumenTransverseViewDataPointTwo:
                        returnStatus = SynchronizeForChangeReadingSource(reading.ReadingSource, newAwvAaaTestResult.ResidualLumenStandardFindings != null ? newAwvAaaTestResult.ResidualLumenStandardFindings.SecondValue : null);
                        if (returnStatus)
                        {
                            newAwvAaaTestResult.ResultStatus.StateNumber = (int)TestResultStateNumber.ManualEntry;
                            return newAwvAaaTestResult;
                        }
                        break;
                }
            }

            if (!newAwvAaaTestResult.ResultImages.IsNullOrEmpty())
            {
                var manuallyUploadedImage = newAwvAaaTestResult.ResultImages.Find(resultImage => resultImage.ReadingSource == ReadingSource.Manual);
                if (manuallyUploadedImage != null)
                {
                    newAwvAaaTestResult.ResultStatus.StateNumber = (int)TestResultStateNumber.ManualEntry;
                    return newAwvAaaTestResult;
                }
            }

            if ((newAwvAaaTestResult.UnableScreenReason != null && newAwvAaaTestResult.UnableScreenReason.Count > 0) || (newAwvAaaTestResult.IncidentalFindings != null && newAwvAaaTestResult.IncidentalFindings.Count > 0))
            {
                newAwvAaaTestResult.ResultStatus.StateNumber = (int)TestResultStateNumber.ManualEntry;
                return newAwvAaaTestResult;
            }

            newAwvAaaTestResult.ResultStatus.StateNumber = (int)TestResultStateNumber.ResultsUploaded;
            return newAwvAaaTestResult;
        }

        private TestResult NewResultStateManualEntry(IEnumerable<ResultReading<int>> compareToResultReadings, TestResult newTestResult)
        {
            if (newTestResult.ResultStatus.StateNumber == (int)NewTestResultStateNumber.PreAudit) return newTestResult;

            var newAwvAaaTestResult = (AwvAaaTestResult)newTestResult;

            foreach (var reading in compareToResultReadings)
            {
                bool returnStatus;
                switch (reading.Label)
                {
                    case ReadingLabels.AortaSize:
                        returnStatus = SynchronizeForChangeReadingSource(reading.ReadingSource, newAwvAaaTestResult.AortaSize);
                        if (returnStatus)
                        {
                            newAwvAaaTestResult.ResultStatus.StateNumber = (int)NewTestResultStateNumber.ResultEntryPartial;
                            return newAwvAaaTestResult;
                        }
                        break;

                    case ReadingLabels.PeakSystolicVelocity:
                        returnStatus = SynchronizeForChangeReadingSource(reading.ReadingSource, newAwvAaaTestResult.PeakSystolicVelocity);
                        if (returnStatus)
                        {
                            newAwvAaaTestResult.ResultStatus.StateNumber = (int)NewTestResultStateNumber.ResultEntryPartial;
                            return newAwvAaaTestResult;
                        }
                        break;

                    case ReadingLabels.AortaRangeSaggitalView:
                        break;

                    case ReadingLabels.AortaRangeTransverseView:
                        break;

                    case ReadingLabels.PeakSystolicVelocitySaggitalView:
                        break;

                    case ReadingLabels.TransverseViewDataPointOne:
                        returnStatus = SynchronizeForChangeReadingSource(reading.ReadingSource, newAwvAaaTestResult.TransverseView != null ? newAwvAaaTestResult.TransverseView.FirstValue : null);
                        if (returnStatus)
                        {
                            newAwvAaaTestResult.ResultStatus.StateNumber = (int)NewTestResultStateNumber.ResultEntryPartial;
                            return newAwvAaaTestResult;
                        }
                        break;

                    case ReadingLabels.TransverseViewDataPointTwo:
                        returnStatus = SynchronizeForChangeReadingSource(reading.ReadingSource, newAwvAaaTestResult.TransverseView != null ? newAwvAaaTestResult.TransverseView.SecondValue : null);
                        if (returnStatus)
                        {
                            newAwvAaaTestResult.ResultStatus.StateNumber = (int)NewTestResultStateNumber.ResultEntryPartial;
                            return newAwvAaaTestResult;
                        }
                        break;
                    case ReadingLabels.ResidualLumenTransverseViewDataPointOne:
                        returnStatus = SynchronizeForChangeReadingSource(reading.ReadingSource, newAwvAaaTestResult.ResidualLumenStandardFindings != null ? newAwvAaaTestResult.ResidualLumenStandardFindings.FirstValue : null);
                        if (returnStatus)
                        {
                            newAwvAaaTestResult.ResultStatus.StateNumber = (int)NewTestResultStateNumber.ResultEntryPartial;
                            return newAwvAaaTestResult;
                        }
                        break;

                    case ReadingLabels.ResidualLumenTransverseViewDataPointTwo:
                        returnStatus = SynchronizeForChangeReadingSource(reading.ReadingSource, newAwvAaaTestResult.ResidualLumenStandardFindings != null ? newAwvAaaTestResult.ResidualLumenStandardFindings.SecondValue : null);
                        if (returnStatus)
                        {
                            newAwvAaaTestResult.ResultStatus.StateNumber = (int)NewTestResultStateNumber.ResultEntryPartial;
                            return newAwvAaaTestResult;
                        }
                        break;
                }
            }

            if (!newAwvAaaTestResult.ResultImages.IsNullOrEmpty())
            {
                var manuallyUploadedImage = newAwvAaaTestResult.ResultImages.Find(resultImage => resultImage.ReadingSource == ReadingSource.Manual);
                if (manuallyUploadedImage != null)
                {
                    newAwvAaaTestResult.ResultStatus.StateNumber = (int)NewTestResultStateNumber.ResultEntryPartial;
                    return newAwvAaaTestResult;
                }
            }

            if ((newAwvAaaTestResult.UnableScreenReason != null && newAwvAaaTestResult.UnableScreenReason.Count > 0) || (newAwvAaaTestResult.IncidentalFindings != null && newAwvAaaTestResult.IncidentalFindings.Count > 0))
            {
                newAwvAaaTestResult.ResultStatus.StateNumber = (int)NewTestResultStateNumber.ResultEntryPartial;
                return newAwvAaaTestResult;
            }

            newAwvAaaTestResult.ResultStatus.StateNumber = (int)NewTestResultStateNumber.ResultEntryPartial;
            return newAwvAaaTestResult;
        }
    }
}
