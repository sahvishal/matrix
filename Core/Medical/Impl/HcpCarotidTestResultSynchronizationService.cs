using System.Collections.Generic;
using Falcon.App.Core.Extensions;
using Falcon.App.Core.Medical.Domain;
using Falcon.App.Core.Medical.Enum;

namespace Falcon.App.Core.Medical.Impl
{
    public class HcpCarotidTestResultSynchronizationService : TestResultSynchronizationService
    {
        public HcpCarotidTestResultSynchronizationService(ReadingSource readingSource)
        {
            NewReadingSource = readingSource;
        }

        public override TestResult SynchronizeTestResult(TestResult currentTestResult, TestResult newTestResult, bool isNewResultFlow)
        {
            var newHcpCarotidTestResult = (HcpCarotidTestResult)newTestResult;

            if (currentTestResult == null)
            {
                SynchronizeResultReadingsForRecorderMetaData(newTestResult);

                if (newHcpCarotidTestResult.LeftResultReadings != null)
                {
                    if (newHcpCarotidTestResult.LeftResultReadings.CCAPSV != null && newHcpCarotidTestResult.LeftResultReadings.CCAPSV.Reading == null) newHcpCarotidTestResult.LeftResultReadings.CCAPSV = null;
                    if (newHcpCarotidTestResult.LeftResultReadings.ICAPSV != null && newHcpCarotidTestResult.LeftResultReadings.ICAPSV.Reading == null) newHcpCarotidTestResult.LeftResultReadings.ICAPSV = null;
                    if (newHcpCarotidTestResult.LeftResultReadings.ICAEDV != null && newHcpCarotidTestResult.LeftResultReadings.ICAEDV.Reading == null) newHcpCarotidTestResult.LeftResultReadings.ICAEDV = null;
                }

                if (newHcpCarotidTestResult.RightResultReadings != null)
                {
                    if (newHcpCarotidTestResult.RightResultReadings.CCAPSV != null && newHcpCarotidTestResult.RightResultReadings.CCAPSV.Reading == null) newHcpCarotidTestResult.RightResultReadings.CCAPSV = null;
                    if (newHcpCarotidTestResult.RightResultReadings.ICAPSV != null && newHcpCarotidTestResult.RightResultReadings.ICAPSV.Reading == null) newHcpCarotidTestResult.RightResultReadings.ICAPSV = null;
                    if (newHcpCarotidTestResult.RightResultReadings.ICAEDV != null && newHcpCarotidTestResult.RightResultReadings.ICAEDV.Reading == null) newHcpCarotidTestResult.RightResultReadings.ICAEDV = null;
                }

                if (!newHcpCarotidTestResult.ResultImages.IsNullOrEmpty())
                {
                    newHcpCarotidTestResult.ResultImages = newHcpCarotidTestResult.ResultImages.FindAll(resultImage =>
                        resultImage.File != null);

                    if (newHcpCarotidTestResult.ResultImages.IsNullOrEmpty()) newHcpCarotidTestResult.ResultImages = null;
                }

                SyncronizeTestResult(currentTestResult, newTestResult);

                return newHcpCarotidTestResult;
            }

            var currentHcpCarotidTestResult = (HcpCarotidTestResult)currentTestResult;
            newHcpCarotidTestResult.Id = currentHcpCarotidTestResult.Id;
            newTestResult.ResultStatus.Id = currentTestResult.ResultStatus.Id;

            if (newHcpCarotidTestResult.LeftResultReadings == null && currentHcpCarotidTestResult.LeftResultReadings != null) newHcpCarotidTestResult.LeftResultReadings = new HcpCarotidTestReadings();

            if (newHcpCarotidTestResult.LeftResultReadings != null)
            {
                newHcpCarotidTestResult.LeftResultReadings.CCAPSV = SynchronizeResultReading(currentHcpCarotidTestResult.LeftResultReadings.CCAPSV, newHcpCarotidTestResult.LeftResultReadings.CCAPSV, newTestResult.DataRecorderMetaData);
                newHcpCarotidTestResult.LeftResultReadings.ICAEDV = SynchronizeResultReading(currentHcpCarotidTestResult.LeftResultReadings.ICAEDV, newHcpCarotidTestResult.LeftResultReadings.ICAEDV, newTestResult.DataRecorderMetaData);
                newHcpCarotidTestResult.LeftResultReadings.ICAPSV = SynchronizeResultReading(currentHcpCarotidTestResult.LeftResultReadings.ICAPSV, newHcpCarotidTestResult.LeftResultReadings.ICAPSV, newTestResult.DataRecorderMetaData);
            }

            if (newHcpCarotidTestResult.RightResultReadings == null && currentHcpCarotidTestResult.RightResultReadings != null) newHcpCarotidTestResult.RightResultReadings = new HcpCarotidTestReadings();

            if (newHcpCarotidTestResult.RightResultReadings != null)
            {
                newHcpCarotidTestResult.RightResultReadings.CCAPSV = SynchronizeResultReading(currentHcpCarotidTestResult.RightResultReadings.CCAPSV, newHcpCarotidTestResult.RightResultReadings.CCAPSV, newTestResult.DataRecorderMetaData);
                newHcpCarotidTestResult.RightResultReadings.ICAEDV = SynchronizeResultReading(currentHcpCarotidTestResult.RightResultReadings.ICAEDV, newHcpCarotidTestResult.RightResultReadings.ICAEDV, newTestResult.DataRecorderMetaData);
                newHcpCarotidTestResult.RightResultReadings.ICAPSV = SynchronizeResultReading(currentHcpCarotidTestResult.RightResultReadings.ICAPSV, newHcpCarotidTestResult.RightResultReadings.ICAPSV, newTestResult.DataRecorderMetaData);
            }

            if (NewReadingSource == ReadingSource.Automatic)
            {
                if (!currentHcpCarotidTestResult.ResultImages.IsNullOrEmpty() && !newHcpCarotidTestResult.ResultImages.IsNullOrEmpty())
                {
                    List<ResultMedia> resultImages = currentHcpCarotidTestResult.ResultImages.FindAll(image => image.ReadingSource == ReadingSource.Manual);

                    if (resultImages.IsNullOrEmpty()) resultImages = newHcpCarotidTestResult.ResultImages;
                    else resultImages.AddRange(newHcpCarotidTestResult.ResultImages);

                    newHcpCarotidTestResult.ResultImages = resultImages;
                }
                else if (!currentHcpCarotidTestResult.ResultImages.IsNullOrEmpty())
                {
                    newHcpCarotidTestResult.ResultImages = currentHcpCarotidTestResult.ResultImages;
                }
            }
            else
            {
                if (!currentHcpCarotidTestResult.ResultImages.IsNullOrEmpty() && !newHcpCarotidTestResult.ResultImages.IsNullOrEmpty())
                {
                    newHcpCarotidTestResult.ResultImages.ForEach(resultImage =>
                    {
                        var selectedImage = currentHcpCarotidTestResult.ResultImages.Find(currentImage => currentImage.File.Path == resultImage.File.Path);
                        if (selectedImage != null)
                            resultImage.ReadingSource = selectedImage.ReadingSource;
                    });
                }
            }

            if (NewReadingSource == ReadingSource.Automatic) // Syncing those which didn't come through Uploaded file
            {
                if (newHcpCarotidTestResult.RightResultReadings != null)
                {
                    newHcpCarotidTestResult.RightResultReadings.Finding = currentHcpCarotidTestResult.RightResultReadings.Finding;
                }
                else if (currentHcpCarotidTestResult.RightResultReadings.Finding != null)
                {
                    newHcpCarotidTestResult.RightResultReadings = new HcpCarotidTestReadings { Finding = currentHcpCarotidTestResult.RightResultReadings.Finding };
                }

                if (newHcpCarotidTestResult.LeftResultReadings != null) newHcpCarotidTestResult.LeftResultReadings.Finding = currentHcpCarotidTestResult.LeftResultReadings.Finding;
                else if (currentHcpCarotidTestResult.LeftResultReadings.Finding != null)
                {
                    newHcpCarotidTestResult.LeftResultReadings = new HcpCarotidTestReadings { Finding = currentHcpCarotidTestResult.LeftResultReadings.Finding };
                }

                newHcpCarotidTestResult = (HcpCarotidTestResult)SyncronizeTestResultForAutomaticUploadwithManual(currentHcpCarotidTestResult, newHcpCarotidTestResult);
            }

            SyncronizeTestResult(currentTestResult, newTestResult);
            return newHcpCarotidTestResult;
        }

        public override TestResult GetManualEntryUploadStatus(List<ResultReading<int>> compareToResultReadings, TestResult newTestResult, bool isNewResultFlow)
        {
            if (isNewResultFlow)
            {
                var newHcpCarotidTestResult = NewResultStateManualEntry(compareToResultReadings, newTestResult);
                if (newHcpCarotidTestResult.ResultStatus.Status == TestResultStatus.Complete && newHcpCarotidTestResult.ResultStatus.StateNumber == (int)NewTestResultStateNumber.ResultEntryPartial)
                    newHcpCarotidTestResult.ResultStatus.StateNumber = (int)NewTestResultStateNumber.ResultEntryCompleted;
                return newHcpCarotidTestResult;
            }
            return OldResultStateManualEntry(compareToResultReadings, newTestResult);
        }

        public override TestResult IsTestIncomplete(List<ResultReading<int>> compareToResultReadings, TestResult newTestResult, bool isNewResultFlow)
        {
            var hcpCarotidTestResult = newTestResult as HcpCarotidTestResult;
            if (hcpCarotidTestResult == null) return null;

            if (hcpCarotidTestResult.TestPerformedExternally != null)
            {
                if (hcpCarotidTestResult.TestPerformedExternally.ResultEntryTypeId == (long)ResultEntryType.Chat && hcpCarotidTestResult.TestPerformedExternally.EntryCompleted)
                {
                    newTestResult.ResultStatus.Status = TestResultStatus.Complete;
                }
                else
                {
                    newTestResult.ResultStatus.Status = TestResultStatus.Incomplete;
                }
                return hcpCarotidTestResult;
            }

            if (NewReadingSource != ReadingSource.Automatic)
            {
                foreach (var reading in compareToResultReadings)
                {
                    switch (reading.Label)
                    {
                        case ReadingLabels.RICAPSV:
                            if (hcpCarotidTestResult.RightResultReadings == null ||
                                hcpCarotidTestResult.RightResultReadings.ICAPSV == null)
                            {
                                hcpCarotidTestResult.ResultStatus.Status = TestResultStatus.Incomplete;
                                return hcpCarotidTestResult;
                            }
                            break;

                        case ReadingLabels.RICAEDV:
                            if (hcpCarotidTestResult.RightResultReadings == null ||
                                hcpCarotidTestResult.RightResultReadings.ICAEDV == null)
                            {
                                hcpCarotidTestResult.ResultStatus.Status = TestResultStatus.Incomplete;
                                return hcpCarotidTestResult;
                            }
                            break;

                        case ReadingLabels.RCCAPSV:
                            if (hcpCarotidTestResult.RightResultReadings == null ||
                                hcpCarotidTestResult.RightResultReadings.CCAPSV == null)
                            {
                                hcpCarotidTestResult.ResultStatus.Status = TestResultStatus.Incomplete;
                                return hcpCarotidTestResult;
                            }
                            break;

                        case ReadingLabels.LICAPSV:
                            if (hcpCarotidTestResult.LeftResultReadings == null ||
                                hcpCarotidTestResult.LeftResultReadings.ICAPSV == null)
                            {
                                hcpCarotidTestResult.ResultStatus.Status = TestResultStatus.Incomplete;
                                return hcpCarotidTestResult;
                            }
                            break;

                        case ReadingLabels.LICAEDV:
                            if (hcpCarotidTestResult.LeftResultReadings == null ||
                                hcpCarotidTestResult.LeftResultReadings.ICAEDV == null)
                            {
                                hcpCarotidTestResult.ResultStatus.Status = TestResultStatus.Incomplete;
                                return hcpCarotidTestResult;
                            }
                            break;

                        case ReadingLabels.LCCAPSV:
                            if (hcpCarotidTestResult.LeftResultReadings == null ||
                                hcpCarotidTestResult.LeftResultReadings.CCAPSV == null)
                            {
                                hcpCarotidTestResult.ResultStatus.Status = TestResultStatus.Incomplete;
                                return hcpCarotidTestResult;
                            }
                            break;
                    }
                }
            }

            if (hcpCarotidTestResult.ResultImages == null || hcpCarotidTestResult.ResultImages.Count < 1)
                newTestResult.ResultStatus.Status = TestResultStatus.Incomplete;
            else
                newTestResult.ResultStatus.Status = TestResultStatus.Complete;
            return hcpCarotidTestResult;
        }

        private TestResult OldResultStateManualEntry(IEnumerable<ResultReading<int>> compareToResultReadings, TestResult newTestResult)
        {
            if (newTestResult.ResultStatus.StateNumber == (int)TestResultStateNumber.PreAudit) return newTestResult;
            var newHcpCarotidTestResult = (HcpCarotidTestResult)newTestResult;

            foreach (var reading in compareToResultReadings)
            {
                bool returnStatus;
                switch (reading.Label)
                {
                    case ReadingLabels.RICAPSV:
                        returnStatus = SynchronizeForChangeReadingSource(reading.ReadingSource, newHcpCarotidTestResult.RightResultReadings != null ? newHcpCarotidTestResult.RightResultReadings.ICAPSV : null);
                        if (returnStatus)
                        {
                            newHcpCarotidTestResult.ResultStatus.StateNumber = (int)TestResultStateNumber.ManualEntry;
                            return newHcpCarotidTestResult;
                        }
                        break;

                    case ReadingLabels.RICAEDV:
                        returnStatus = SynchronizeForChangeReadingSource(reading.ReadingSource, newHcpCarotidTestResult.RightResultReadings != null ? newHcpCarotidTestResult.RightResultReadings.ICAEDV : null);
                        if (returnStatus)
                        {
                            newHcpCarotidTestResult.ResultStatus.StateNumber = (int)TestResultStateNumber.ManualEntry;
                            return newHcpCarotidTestResult;
                        }
                        break;

                    case ReadingLabels.RCCAPSV:
                        returnStatus = SynchronizeForChangeReadingSource(reading.ReadingSource, newHcpCarotidTestResult.RightResultReadings != null ? newHcpCarotidTestResult.RightResultReadings.CCAPSV : null);
                        if (returnStatus)
                        {
                            newHcpCarotidTestResult.ResultStatus.StateNumber = (int)TestResultStateNumber.ManualEntry;
                            return newHcpCarotidTestResult;
                        }
                        break;

                    case ReadingLabels.LICAPSV:
                        returnStatus = SynchronizeForChangeReadingSource(reading.ReadingSource, newHcpCarotidTestResult.LeftResultReadings != null ? newHcpCarotidTestResult.LeftResultReadings.ICAPSV : null);
                        if (returnStatus)
                        {
                            newHcpCarotidTestResult.ResultStatus.StateNumber = (int)TestResultStateNumber.ManualEntry;
                            return newHcpCarotidTestResult;
                        }
                        break;

                    case ReadingLabels.LICAEDV:
                        returnStatus = SynchronizeForChangeReadingSource(reading.ReadingSource, newHcpCarotidTestResult.LeftResultReadings != null ? newHcpCarotidTestResult.LeftResultReadings.ICAEDV : null);
                        if (returnStatus)
                        {
                            newHcpCarotidTestResult.ResultStatus.StateNumber = (int)TestResultStateNumber.ManualEntry;
                            return newHcpCarotidTestResult;
                        }
                        break;

                    case ReadingLabels.LCCAPSV:
                        returnStatus = SynchronizeForChangeReadingSource(reading.ReadingSource, newHcpCarotidTestResult.LeftResultReadings != null ? newHcpCarotidTestResult.LeftResultReadings.CCAPSV : null);
                        if (returnStatus)
                        {
                            newHcpCarotidTestResult.ResultStatus.StateNumber = (int)TestResultStateNumber.ManualEntry;
                            return newHcpCarotidTestResult;
                        }
                        break;
                }
            }

            if (!newHcpCarotidTestResult.ResultImages.IsNullOrEmpty())
            {
                var manuallyUploadedImage = newHcpCarotidTestResult.ResultImages.Find(resultImage => resultImage.ReadingSource == ReadingSource.Manual);
                if (manuallyUploadedImage != null)
                {
                    newHcpCarotidTestResult.ResultStatus.StateNumber = (int)TestResultStateNumber.ManualEntry;
                    return newHcpCarotidTestResult;
                }
            }

            if ((newHcpCarotidTestResult.UnableScreenReason != null && newHcpCarotidTestResult.UnableScreenReason.Count > 0) || (newHcpCarotidTestResult.IncidentalFindings != null && newHcpCarotidTestResult.IncidentalFindings.Count > 0))
            {
                newHcpCarotidTestResult.ResultStatus.StateNumber = (int)TestResultStateNumber.ManualEntry;
                return newHcpCarotidTestResult;
            }

            newHcpCarotidTestResult.ResultStatus.StateNumber = (int)TestResultStateNumber.ResultsUploaded;
            return newHcpCarotidTestResult;
        }

        private TestResult NewResultStateManualEntry(IEnumerable<ResultReading<int>> compareToResultReadings, TestResult newTestResult)
        {
            if (newTestResult.ResultStatus.StateNumber == (int)NewTestResultStateNumber.PreAudit) return newTestResult;
            var newHcpCarotidTestResult = (HcpCarotidTestResult)newTestResult;

            foreach (var reading in compareToResultReadings)
            {
                bool returnStatus;
                switch (reading.Label)
                {
                    case ReadingLabels.RICAPSV:
                        returnStatus = SynchronizeForChangeReadingSource(reading.ReadingSource, newHcpCarotidTestResult.RightResultReadings != null ? newHcpCarotidTestResult.RightResultReadings.ICAPSV : null);
                        if (returnStatus)
                        {
                            newHcpCarotidTestResult.ResultStatus.StateNumber = (int)NewTestResultStateNumber.ResultEntryPartial;
                            return newHcpCarotidTestResult;
                        }
                        break;

                    case ReadingLabels.RICAEDV:
                        returnStatus = SynchronizeForChangeReadingSource(reading.ReadingSource, newHcpCarotidTestResult.RightResultReadings != null ? newHcpCarotidTestResult.RightResultReadings.ICAEDV : null);
                        if (returnStatus)
                        {
                            newHcpCarotidTestResult.ResultStatus.StateNumber = (int)NewTestResultStateNumber.ResultEntryPartial;
                            return newHcpCarotidTestResult;
                        }
                        break;

                    case ReadingLabels.RCCAPSV:
                        returnStatus = SynchronizeForChangeReadingSource(reading.ReadingSource, newHcpCarotidTestResult.RightResultReadings != null ? newHcpCarotidTestResult.RightResultReadings.CCAPSV : null);
                        if (returnStatus)
                        {
                            newHcpCarotidTestResult.ResultStatus.StateNumber = (int)NewTestResultStateNumber.ResultEntryPartial;
                            return newHcpCarotidTestResult;
                        }
                        break;

                    case ReadingLabels.LICAPSV:
                        returnStatus = SynchronizeForChangeReadingSource(reading.ReadingSource, newHcpCarotidTestResult.LeftResultReadings != null ? newHcpCarotidTestResult.LeftResultReadings.ICAPSV : null);
                        if (returnStatus)
                        {
                            newHcpCarotidTestResult.ResultStatus.StateNumber = (int)NewTestResultStateNumber.ResultEntryPartial;
                            return newHcpCarotidTestResult;
                        }
                        break;

                    case ReadingLabels.LICAEDV:
                        returnStatus = SynchronizeForChangeReadingSource(reading.ReadingSource, newHcpCarotidTestResult.LeftResultReadings != null ? newHcpCarotidTestResult.LeftResultReadings.ICAEDV : null);
                        if (returnStatus)
                        {
                            newHcpCarotidTestResult.ResultStatus.StateNumber = (int)NewTestResultStateNumber.ResultEntryPartial;
                            return newHcpCarotidTestResult;
                        }
                        break;

                    case ReadingLabels.LCCAPSV:
                        returnStatus = SynchronizeForChangeReadingSource(reading.ReadingSource, newHcpCarotidTestResult.LeftResultReadings != null ? newHcpCarotidTestResult.LeftResultReadings.CCAPSV : null);
                        if (returnStatus)
                        {
                            newHcpCarotidTestResult.ResultStatus.StateNumber = (int)NewTestResultStateNumber.ResultEntryPartial;
                            return newHcpCarotidTestResult;
                        }
                        break;
                }
            }

            if (!newHcpCarotidTestResult.ResultImages.IsNullOrEmpty())
            {
                var manuallyUploadedImage = newHcpCarotidTestResult.ResultImages.Find(resultImage => resultImage.ReadingSource == ReadingSource.Manual);
                if (manuallyUploadedImage != null)
                {
                    newHcpCarotidTestResult.ResultStatus.StateNumber = (int)NewTestResultStateNumber.ResultEntryPartial;
                    return newHcpCarotidTestResult;
                }
            }

            if ((newHcpCarotidTestResult.UnableScreenReason != null && newHcpCarotidTestResult.UnableScreenReason.Count > 0) || (newHcpCarotidTestResult.IncidentalFindings != null && newHcpCarotidTestResult.IncidentalFindings.Count > 0))
            {
                newHcpCarotidTestResult.ResultStatus.StateNumber = (int)NewTestResultStateNumber.ResultEntryPartial;
                return newHcpCarotidTestResult;
            }

            newHcpCarotidTestResult.ResultStatus.StateNumber = (int)NewTestResultStateNumber.ResultEntryPartial;
            return newHcpCarotidTestResult;
        }
    }
}