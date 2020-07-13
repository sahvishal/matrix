using System.Collections.Generic;
using Falcon.App.Core.Extensions;
using Falcon.App.Core.Medical.Domain;
using Falcon.App.Core.Medical.Enum;

namespace Falcon.App.Core.Medical.Impl
{
    public class StrokeTestResultSynchronizationService : TestResultSynchronizationService
    {
        public StrokeTestResultSynchronizationService(ReadingSource readingSource)
        {
            NewReadingSource = readingSource;
        }

        public override TestResult SynchronizeTestResult(TestResult currentTestResult, TestResult newTestResult, bool isNewResultFlow)
        {
            var newStrokeTestResult = (StrokeTestResult)newTestResult;

            if (currentTestResult == null)
            {
                SynchronizeResultReadingsForRecorderMetaData(newTestResult);

                if (newStrokeTestResult.LeftResultReadings != null)
                {
                    if (newStrokeTestResult.LeftResultReadings.CCAPSV != null && newStrokeTestResult.LeftResultReadings.CCAPSV.Reading == null) newStrokeTestResult.LeftResultReadings.CCAPSV = null;
                    if (newStrokeTestResult.LeftResultReadings.ICAPSV != null && newStrokeTestResult.LeftResultReadings.ICAPSV.Reading == null) newStrokeTestResult.LeftResultReadings.ICAPSV = null;
                    if (newStrokeTestResult.LeftResultReadings.ICAEDV != null && newStrokeTestResult.LeftResultReadings.ICAEDV.Reading == null) newStrokeTestResult.LeftResultReadings.ICAEDV = null;
                }

                if (newStrokeTestResult.RightResultReadings != null)
                {
                    if (newStrokeTestResult.RightResultReadings.CCAPSV != null && newStrokeTestResult.RightResultReadings.CCAPSV.Reading == null) newStrokeTestResult.RightResultReadings.CCAPSV = null;
                    if (newStrokeTestResult.RightResultReadings.ICAPSV != null && newStrokeTestResult.RightResultReadings.ICAPSV.Reading == null) newStrokeTestResult.RightResultReadings.ICAPSV = null;
                    if (newStrokeTestResult.RightResultReadings.ICAEDV != null && newStrokeTestResult.RightResultReadings.ICAEDV.Reading == null) newStrokeTestResult.RightResultReadings.ICAEDV = null;
                }

                if (!newStrokeTestResult.ResultImages.IsNullOrEmpty())
                {
                    newStrokeTestResult.ResultImages = newStrokeTestResult.ResultImages.FindAll(resultImage =>
                        resultImage.File != null);

                    if (newStrokeTestResult.ResultImages.IsNullOrEmpty()) newStrokeTestResult.ResultImages = null;
                }

                SyncronizeTestResult(currentTestResult, newTestResult);

                return newStrokeTestResult;
            }

            var currentStrokeTestResult = (StrokeTestResult)currentTestResult;
            newStrokeTestResult.Id = currentStrokeTestResult.Id;
            newTestResult.ResultStatus.Id = currentTestResult.ResultStatus.Id;

            if (newStrokeTestResult.LeftResultReadings == null && currentStrokeTestResult.LeftResultReadings != null) newStrokeTestResult.LeftResultReadings = new StrokeTestReadings();

            if (newStrokeTestResult.LeftResultReadings != null)
            {
                newStrokeTestResult.LeftResultReadings.CCAPSV = SynchronizeResultReading(currentStrokeTestResult.LeftResultReadings.CCAPSV, newStrokeTestResult.LeftResultReadings.CCAPSV, newTestResult.DataRecorderMetaData);
                newStrokeTestResult.LeftResultReadings.ICAEDV = SynchronizeResultReading(currentStrokeTestResult.LeftResultReadings.ICAEDV, newStrokeTestResult.LeftResultReadings.ICAEDV, newTestResult.DataRecorderMetaData);
                newStrokeTestResult.LeftResultReadings.ICAPSV = SynchronizeResultReading(currentStrokeTestResult.LeftResultReadings.ICAPSV, newStrokeTestResult.LeftResultReadings.ICAPSV, newTestResult.DataRecorderMetaData);
            }

            if (newStrokeTestResult.RightResultReadings == null && currentStrokeTestResult.RightResultReadings != null) newStrokeTestResult.RightResultReadings = new StrokeTestReadings();

            if (newStrokeTestResult.RightResultReadings != null)
            {
                newStrokeTestResult.RightResultReadings.CCAPSV = SynchronizeResultReading(currentStrokeTestResult.RightResultReadings.CCAPSV, newStrokeTestResult.RightResultReadings.CCAPSV, newTestResult.DataRecorderMetaData);
                newStrokeTestResult.RightResultReadings.ICAEDV = SynchronizeResultReading(currentStrokeTestResult.RightResultReadings.ICAEDV, newStrokeTestResult.RightResultReadings.ICAEDV, newTestResult.DataRecorderMetaData);
                newStrokeTestResult.RightResultReadings.ICAPSV = SynchronizeResultReading(currentStrokeTestResult.RightResultReadings.ICAPSV, newStrokeTestResult.RightResultReadings.ICAPSV, newTestResult.DataRecorderMetaData);
            }

            if (NewReadingSource == ReadingSource.Automatic)
            {
                if (!currentStrokeTestResult.ResultImages.IsNullOrEmpty() && !newStrokeTestResult.ResultImages.IsNullOrEmpty())
                {
                    List<ResultMedia> resultImages = currentStrokeTestResult.ResultImages.FindAll(image => image.ReadingSource == ReadingSource.Manual);

                    if (resultImages.IsNullOrEmpty()) resultImages = newStrokeTestResult.ResultImages;
                    else resultImages.AddRange(newStrokeTestResult.ResultImages);

                    newStrokeTestResult.ResultImages = resultImages;
                }
                else if (!currentStrokeTestResult.ResultImages.IsNullOrEmpty())
                {
                    newStrokeTestResult.ResultImages = currentStrokeTestResult.ResultImages;
                }
            }
            else
            {
                if (!currentStrokeTestResult.ResultImages.IsNullOrEmpty() && !newStrokeTestResult.ResultImages.IsNullOrEmpty())
                {
                    newStrokeTestResult.ResultImages.ForEach(resultImage =>
                    {
                        var selectedImage = currentStrokeTestResult.ResultImages.Find(currentImage => currentImage.File.Path == resultImage.File.Path);
                        if (selectedImage != null)
                            resultImage.ReadingSource = selectedImage.ReadingSource;
                    });
                }
            }

            if (NewReadingSource == ReadingSource.Automatic) // Syncing those which didn't come through Uploaded file
            {
                if (newStrokeTestResult.RightResultReadings != null)
                {
                    newStrokeTestResult.RightResultReadings.Finding = currentStrokeTestResult.RightResultReadings.Finding;
                }
                else if (currentStrokeTestResult.RightResultReadings.Finding != null)
                {
                    newStrokeTestResult.RightResultReadings = new StrokeTestReadings { Finding = currentStrokeTestResult.RightResultReadings.Finding };
                }

                if (newStrokeTestResult.LeftResultReadings != null) newStrokeTestResult.LeftResultReadings.Finding = currentStrokeTestResult.LeftResultReadings.Finding;
                else if (currentStrokeTestResult.LeftResultReadings.Finding != null)
                {
                    newStrokeTestResult.LeftResultReadings = new StrokeTestReadings { Finding = currentStrokeTestResult.LeftResultReadings.Finding };
                }

                newStrokeTestResult = (StrokeTestResult)SyncronizeTestResultForAutomaticUploadwithManual(currentStrokeTestResult, newStrokeTestResult);
            }

            SyncronizeTestResult(currentTestResult, newTestResult);
            return newStrokeTestResult;
        }

        public override TestResult GetManualEntryUploadStatus(List<ResultReading<int>> compareToResultReadings, TestResult newTestResult, bool isNewResultFlow)
        {
            if (isNewResultFlow)
            {
                var newStrokeTestResult = NewResultStateManualEntry(compareToResultReadings, newTestResult);
                if (newStrokeTestResult.ResultStatus.Status == TestResultStatus.Complete && newStrokeTestResult.ResultStatus.StateNumber == (int)NewTestResultStateNumber.ResultEntryPartial)
                    newStrokeTestResult.ResultStatus.StateNumber = (int)NewTestResultStateNumber.ResultEntryCompleted;
                return newStrokeTestResult;
            }
            return OldResultStateManualEntry(compareToResultReadings, newTestResult);
        }

        public override TestResult IsTestIncomplete(List<ResultReading<int>> compareToResultReadings, TestResult newTestResult, bool isNewResultFlow)
        {
            var strokeTestResult = newTestResult as StrokeTestResult;
            if (strokeTestResult == null) return null;

            if (strokeTestResult.TestPerformedExternally != null)
            {
                if (strokeTestResult.TestPerformedExternally.ResultEntryTypeId == (long)ResultEntryType.Chat && strokeTestResult.TestPerformedExternally.EntryCompleted)
                {
                    newTestResult.ResultStatus.Status = TestResultStatus.Complete;
                }
                else
                {
                    newTestResult.ResultStatus.Status = TestResultStatus.Incomplete;
                }
                return strokeTestResult;
            }

            if (NewReadingSource != ReadingSource.Automatic)
            {
                foreach (var reading in compareToResultReadings)
                {
                    switch (reading.Label)
                    {
                        case ReadingLabels.RICAPSV:
                            if (strokeTestResult.RightResultReadings == null ||
                                strokeTestResult.RightResultReadings.ICAPSV == null)
                            {
                                strokeTestResult.ResultStatus.Status = TestResultStatus.Incomplete;
                                return strokeTestResult;
                            }
                            break;

                        case ReadingLabels.RICAEDV:
                            if (strokeTestResult.RightResultReadings == null ||
                                strokeTestResult.RightResultReadings.ICAEDV == null)
                            {
                                strokeTestResult.ResultStatus.Status = TestResultStatus.Incomplete;
                                return strokeTestResult;
                            }
                            break;

                        case ReadingLabels.RCCAPSV:
                            if (strokeTestResult.RightResultReadings == null ||
                                strokeTestResult.RightResultReadings.CCAPSV == null)
                            {
                                strokeTestResult.ResultStatus.Status = TestResultStatus.Incomplete;
                                return strokeTestResult;
                            }
                            break;

                        case ReadingLabels.LICAPSV:
                            if (strokeTestResult.LeftResultReadings == null ||
                                strokeTestResult.LeftResultReadings.ICAPSV == null)
                            {
                                strokeTestResult.ResultStatus.Status = TestResultStatus.Incomplete;
                                return strokeTestResult;
                            }
                            break;

                        case ReadingLabels.LICAEDV:
                            if (strokeTestResult.LeftResultReadings == null ||
                                strokeTestResult.LeftResultReadings.ICAEDV == null)
                            {
                                strokeTestResult.ResultStatus.Status = TestResultStatus.Incomplete;
                                return strokeTestResult;
                            }
                            break;

                        case ReadingLabels.LCCAPSV:
                            if (strokeTestResult.LeftResultReadings == null ||
                                strokeTestResult.LeftResultReadings.CCAPSV == null)
                            {
                                strokeTestResult.ResultStatus.Status = TestResultStatus.Incomplete;
                                return strokeTestResult;
                            }
                            break;
                    }
                }
            }

            if (/*strokeTestResult.LeftResultReadings.Finding == null || strokeTestResult.RightResultReadings.Finding == null ||*/ strokeTestResult.ResultImages == null || strokeTestResult.ResultImages.Count < 1)
                newTestResult.ResultStatus.Status = TestResultStatus.Incomplete;
            else
                newTestResult.ResultStatus.Status = TestResultStatus.Complete;
            return strokeTestResult;
        }

        private TestResult OldResultStateManualEntry(IEnumerable<ResultReading<int>> compareToResultReadings, TestResult newTestResult)
        {
            if (newTestResult.ResultStatus.StateNumber == (int)TestResultStateNumber.PreAudit) return newTestResult;
            var newStrokeTestResult = (StrokeTestResult)newTestResult;

            foreach (var reading in compareToResultReadings)
            {
                bool returnStatus;
                switch (reading.Label)
                {
                    case ReadingLabels.RICAPSV:
                        returnStatus = SynchronizeForChangeReadingSource(reading.ReadingSource, newStrokeTestResult.RightResultReadings != null ? newStrokeTestResult.RightResultReadings.ICAPSV : null);
                        if (returnStatus)
                        {
                            newStrokeTestResult.ResultStatus.StateNumber = (int)TestResultStateNumber.ManualEntry;
                            return newStrokeTestResult;
                        }
                        break;

                    case ReadingLabels.RICAEDV:
                        returnStatus = SynchronizeForChangeReadingSource(reading.ReadingSource, newStrokeTestResult.RightResultReadings != null ? newStrokeTestResult.RightResultReadings.ICAEDV : null);
                        if (returnStatus)
                        {
                            newStrokeTestResult.ResultStatus.StateNumber = (int)TestResultStateNumber.ManualEntry;
                            return newStrokeTestResult;
                        }
                        break;

                    case ReadingLabels.RCCAPSV:
                        returnStatus = SynchronizeForChangeReadingSource(reading.ReadingSource, newStrokeTestResult.RightResultReadings != null ? newStrokeTestResult.RightResultReadings.CCAPSV : null);
                        if (returnStatus)
                        {
                            newStrokeTestResult.ResultStatus.StateNumber = (int)TestResultStateNumber.ManualEntry;
                            return newStrokeTestResult;
                        }
                        break;

                    case ReadingLabels.LICAPSV:
                        returnStatus = SynchronizeForChangeReadingSource(reading.ReadingSource, newStrokeTestResult.LeftResultReadings != null ? newStrokeTestResult.LeftResultReadings.ICAPSV : null);
                        if (returnStatus)
                        {
                            newStrokeTestResult.ResultStatus.StateNumber = (int)TestResultStateNumber.ManualEntry;
                            return newStrokeTestResult;
                        }
                        break;

                    case ReadingLabels.LICAEDV:
                        returnStatus = SynchronizeForChangeReadingSource(reading.ReadingSource, newStrokeTestResult.LeftResultReadings != null ? newStrokeTestResult.LeftResultReadings.ICAEDV : null);
                        if (returnStatus)
                        {
                            newStrokeTestResult.ResultStatus.StateNumber = (int)TestResultStateNumber.ManualEntry;
                            return newStrokeTestResult;
                        }
                        break;

                    case ReadingLabels.LCCAPSV:
                        returnStatus = SynchronizeForChangeReadingSource(reading.ReadingSource, newStrokeTestResult.LeftResultReadings != null ? newStrokeTestResult.LeftResultReadings.CCAPSV : null);
                        if (returnStatus)
                        {
                            newStrokeTestResult.ResultStatus.StateNumber = (int)TestResultStateNumber.ManualEntry;
                            return newStrokeTestResult;
                        }
                        break;
                }
            }

            if (!newStrokeTestResult.ResultImages.IsNullOrEmpty())
            {
                var manuallyUploadedImage = newStrokeTestResult.ResultImages.Find(resultImage => resultImage.ReadingSource == ReadingSource.Manual);
                if (manuallyUploadedImage != null)
                {
                    newStrokeTestResult.ResultStatus.StateNumber = (int)TestResultStateNumber.ManualEntry;
                    return newStrokeTestResult;
                }
            }

            if ((newStrokeTestResult.UnableScreenReason != null && newStrokeTestResult.UnableScreenReason.Count > 0) || (newStrokeTestResult.IncidentalFindings != null && newStrokeTestResult.IncidentalFindings.Count > 0))
            {
                newStrokeTestResult.ResultStatus.StateNumber = (int)TestResultStateNumber.ManualEntry;
                return newStrokeTestResult;
            }

            newStrokeTestResult.ResultStatus.StateNumber = (int)TestResultStateNumber.ResultsUploaded;
            return newStrokeTestResult;
        }

        private TestResult NewResultStateManualEntry(IEnumerable<ResultReading<int>> compareToResultReadings, TestResult newTestResult)
        {
            if (newTestResult.ResultStatus.StateNumber == (int)NewTestResultStateNumber.PreAudit) return newTestResult;
            var newStrokeTestResult = (StrokeTestResult)newTestResult;

            foreach (var reading in compareToResultReadings)
            {
                bool returnStatus;
                switch (reading.Label)
                {
                    case ReadingLabels.RICAPSV:
                        returnStatus = SynchronizeForChangeReadingSource(reading.ReadingSource, newStrokeTestResult.RightResultReadings != null ? newStrokeTestResult.RightResultReadings.ICAPSV : null);
                        if (returnStatus)
                        {
                            newStrokeTestResult.ResultStatus.StateNumber = (int)NewTestResultStateNumber.ResultEntryPartial;
                            return newStrokeTestResult;
                        }
                        break;

                    case ReadingLabels.RICAEDV:
                        returnStatus = SynchronizeForChangeReadingSource(reading.ReadingSource, newStrokeTestResult.RightResultReadings != null ? newStrokeTestResult.RightResultReadings.ICAEDV : null);
                        if (returnStatus)
                        {
                            newStrokeTestResult.ResultStatus.StateNumber = (int)NewTestResultStateNumber.ResultEntryPartial;
                            return newStrokeTestResult;
                        }
                        break;

                    case ReadingLabels.RCCAPSV:
                        returnStatus = SynchronizeForChangeReadingSource(reading.ReadingSource, newStrokeTestResult.RightResultReadings != null ? newStrokeTestResult.RightResultReadings.CCAPSV : null);
                        if (returnStatus)
                        {
                            newStrokeTestResult.ResultStatus.StateNumber = (int)NewTestResultStateNumber.ResultEntryPartial;
                            return newStrokeTestResult;
                        }
                        break;

                    case ReadingLabels.LICAPSV:
                        returnStatus = SynchronizeForChangeReadingSource(reading.ReadingSource, newStrokeTestResult.LeftResultReadings != null ? newStrokeTestResult.LeftResultReadings.ICAPSV : null);
                        if (returnStatus)
                        {
                            newStrokeTestResult.ResultStatus.StateNumber = (int)NewTestResultStateNumber.ResultEntryPartial;
                            return newStrokeTestResult;
                        }
                        break;

                    case ReadingLabels.LICAEDV:
                        returnStatus = SynchronizeForChangeReadingSource(reading.ReadingSource, newStrokeTestResult.LeftResultReadings != null ? newStrokeTestResult.LeftResultReadings.ICAEDV : null);
                        if (returnStatus)
                        {
                            newStrokeTestResult.ResultStatus.StateNumber = (int)NewTestResultStateNumber.ResultEntryPartial;
                            return newStrokeTestResult;
                        }
                        break;

                    case ReadingLabels.LCCAPSV:
                        returnStatus = SynchronizeForChangeReadingSource(reading.ReadingSource, newStrokeTestResult.LeftResultReadings != null ? newStrokeTestResult.LeftResultReadings.CCAPSV : null);
                        if (returnStatus)
                        {
                            newStrokeTestResult.ResultStatus.StateNumber = (int)NewTestResultStateNumber.ResultEntryPartial;
                            return newStrokeTestResult;
                        }
                        break;
                }
            }

            if (!newStrokeTestResult.ResultImages.IsNullOrEmpty())
            {
                var manuallyUploadedImage = newStrokeTestResult.ResultImages.Find(resultImage => resultImage.ReadingSource == ReadingSource.Manual);
                if (manuallyUploadedImage != null)
                {
                    newStrokeTestResult.ResultStatus.StateNumber = (int)NewTestResultStateNumber.ResultEntryPartial;
                    return newStrokeTestResult;
                }
            }

            if ((newStrokeTestResult.UnableScreenReason != null && newStrokeTestResult.UnableScreenReason.Count > 0) || (newStrokeTestResult.IncidentalFindings != null && newStrokeTestResult.IncidentalFindings.Count > 0))
            {
                newStrokeTestResult.ResultStatus.StateNumber = (int)NewTestResultStateNumber.ResultEntryPartial;
                return newStrokeTestResult;
            }

            newStrokeTestResult.ResultStatus.StateNumber = (int)NewTestResultStateNumber.ResultEntryPartial;
            return newStrokeTestResult;
        }
    }
}
