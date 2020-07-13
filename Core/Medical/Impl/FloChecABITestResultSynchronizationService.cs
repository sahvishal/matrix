using System.Collections.Generic;
using Falcon.App.Core.Medical.Domain;
using Falcon.App.Core.Medical.Enum;

namespace Falcon.App.Core.Medical.Impl
{
    public class FloChecABITestResultSynchronizationService : TestResultSynchronizationService
    {
        public FloChecABITestResultSynchronizationService(ReadingSource readingSource)
        {
            NewReadingSource = readingSource;
        }

        public override TestResult SynchronizeTestResult(TestResult currentTestResult, TestResult newTestResult, bool isNewResultFlow)
        {
            var newFloChecABITestResult = (FloChecABITestResult)newTestResult;

            if (currentTestResult == null)
            {
                SynchronizeResultReadingsForRecorderMetaData(newTestResult);

                if (newFloChecABITestResult.ResultImage != null)
                {
                    if (newFloChecABITestResult.ResultImage.File == null) newFloChecABITestResult.ResultImage = null;
                }

                if (newFloChecABITestResult.LeftResultReadings != null)
                {
                    if (newFloChecABITestResult.LeftResultReadings.ABI != null && newFloChecABITestResult.LeftResultReadings.ABI.Reading == null) newFloChecABITestResult.LeftResultReadings.ABI = null;
                    if (newFloChecABITestResult.LeftResultReadings.BFI != null && newFloChecABITestResult.LeftResultReadings.BFI.Reading == null) newFloChecABITestResult.LeftResultReadings.BFI = null;
                }

                if (newFloChecABITestResult.RightResultReadings != null)
                {
                    if (newFloChecABITestResult.RightResultReadings.ABI != null && newFloChecABITestResult.RightResultReadings.ABI.Reading == null) newFloChecABITestResult.RightResultReadings.ABI = null;
                    if (newFloChecABITestResult.RightResultReadings.BFI != null && newFloChecABITestResult.RightResultReadings.BFI.Reading == null) newFloChecABITestResult.RightResultReadings.BFI = null;
                }

                if (newFloChecABITestResult.PencilDopplerUsed != null && !newFloChecABITestResult.PencilDopplerUsed.Reading)
                    newFloChecABITestResult.PencilDopplerUsed = null;

                SyncronizeTestResult(currentTestResult, newTestResult);
                return newFloChecABITestResult;
            }

            var currentFloChecABITestResult = (FloChecABITestResult)currentTestResult;
            newFloChecABITestResult.Id = currentFloChecABITestResult.Id;
            newTestResult.ResultStatus.Id = currentTestResult.ResultStatus.Id;

            if (currentFloChecABITestResult.ResultImage != null && newFloChecABITestResult.ResultImage != null)
            {
                if (newFloChecABITestResult.ResultImage.File != null && currentFloChecABITestResult.ResultImage.File != null && currentFloChecABITestResult.ResultImage.File.Path == newFloChecABITestResult.ResultImage.File.Path)
                    newFloChecABITestResult.ResultImage = currentFloChecABITestResult.ResultImage;

                if (currentFloChecABITestResult.ResultImage.ReadingSource == ReadingSource.Manual && newFloChecABITestResult.ResultImage.ReadingSource == ReadingSource.Automatic)
                    newFloChecABITestResult.ResultImage = currentFloChecABITestResult.ResultImage;
            }

            if (newFloChecABITestResult.ResultImage != null)
            {
                if (newFloChecABITestResult.ResultImage.File == null) newFloChecABITestResult.ResultImage = null;
            }

            if (newFloChecABITestResult.LeftResultReadings == null && currentFloChecABITestResult.LeftResultReadings != null)
            {
                newFloChecABITestResult.LeftResultReadings = new FloChecABIReadings();
            }

            if (currentFloChecABITestResult.LeftResultReadings != null)
            {
                newFloChecABITestResult.LeftResultReadings.ABI = SynchronizeResultReading(currentFloChecABITestResult.LeftResultReadings.ABI, newFloChecABITestResult.LeftResultReadings.ABI, newTestResult.DataRecorderMetaData);
                newFloChecABITestResult.LeftResultReadings.BFI = SynchronizeResultReading(currentFloChecABITestResult.LeftResultReadings.BFI, newFloChecABITestResult.LeftResultReadings.BFI, newTestResult.DataRecorderMetaData);
            }


            if (newFloChecABITestResult.RightResultReadings == null && currentFloChecABITestResult.RightResultReadings != null)
            {
                newFloChecABITestResult.RightResultReadings = new FloChecABIReadings();
            }

            if (currentFloChecABITestResult.RightResultReadings != null)
            {
                newFloChecABITestResult.RightResultReadings.ABI = SynchronizeResultReading(currentFloChecABITestResult.RightResultReadings.ABI, newFloChecABITestResult.RightResultReadings.ABI, newTestResult.DataRecorderMetaData);
                newFloChecABITestResult.RightResultReadings.BFI = SynchronizeResultReading(currentFloChecABITestResult.RightResultReadings.BFI, newFloChecABITestResult.RightResultReadings.BFI, newTestResult.DataRecorderMetaData);

            }

            newFloChecABITestResult.PencilDopplerUsed = SynchronizeResultReading(currentFloChecABITestResult.PencilDopplerUsed, newFloChecABITestResult.PencilDopplerUsed, newTestResult.DataRecorderMetaData);

            if (newFloChecABITestResult.Finding == null && newFloChecABITestResult.LeftResultReadings != null && newFloChecABITestResult.RightResultReadings != null && currentFloChecABITestResult.Finding != null)
            {
                if (currentFloChecABITestResult.LeftResultReadings != null && ((newFloChecABITestResult.LeftResultReadings.ABI == null && currentFloChecABITestResult.LeftResultReadings.ABI == null)
                                                                        || (newFloChecABITestResult.LeftResultReadings.ABI != null && currentFloChecABITestResult.LeftResultReadings.ABI != null
                                                                                && currentFloChecABITestResult.LeftResultReadings.ABI.Reading == newFloChecABITestResult.LeftResultReadings.ABI.Reading))
                    &&
                    currentFloChecABITestResult.RightResultReadings != null && ((newFloChecABITestResult.RightResultReadings.ABI == null && currentFloChecABITestResult.RightResultReadings.ABI == null)
                                                                         || (newFloChecABITestResult.RightResultReadings.ABI != null && currentFloChecABITestResult.RightResultReadings.ABI != null
                                                                                && currentFloChecABITestResult.RightResultReadings.ABI.Reading == newFloChecABITestResult.RightResultReadings.ABI.Reading)))

                    newFloChecABITestResult.Finding = currentFloChecABITestResult.Finding;
            }

            if (NewReadingSource == ReadingSource.Automatic)
            {
                newFloChecABITestResult = (FloChecABITestResult)SyncronizeTestResultForAutomaticUploadwithManual(currentFloChecABITestResult, newFloChecABITestResult);
            }

            SyncronizeTestResult(currentTestResult, newTestResult);
            return newFloChecABITestResult;
        }

        public override TestResult GetManualEntryUploadStatus(List<ResultReading<int>> compareToResultReadings, TestResult newTestResult, bool isNewResultFlow)
        {
            if (isNewResultFlow)
            {
                var newFloChecABITestResult = NewResultStateManualEntry(compareToResultReadings, newTestResult);
                if (newFloChecABITestResult.ResultStatus.Status == TestResultStatus.Complete && newFloChecABITestResult.ResultStatus.StateNumber == (int)NewTestResultStateNumber.ResultEntryPartial)
                    newFloChecABITestResult.ResultStatus.StateNumber = (int)NewTestResultStateNumber.ResultEntryCompleted;
                return newFloChecABITestResult;
            }
            return OldResultStateManualEntry(compareToResultReadings, newTestResult);
        }

        public override TestResult IsTestIncomplete(List<ResultReading<int>> compareToResultReadings, TestResult newTestResult, bool isNewResultFlow)
        {
            var FloChecABITestResult = newTestResult as FloChecABITestResult;
            if (FloChecABITestResult == null) return null;

            if (FloChecABITestResult.TestPerformedExternally != null)
            {
                if (FloChecABITestResult.TestPerformedExternally.ResultEntryTypeId == (long)ResultEntryType.Chat && FloChecABITestResult.TestPerformedExternally.EntryCompleted)
                {
                    newTestResult.ResultStatus.Status = TestResultStatus.Complete;
                }
                else
                {
                    newTestResult.ResultStatus.Status = TestResultStatus.Incomplete;
                }
                return FloChecABITestResult;
            }

            foreach (var reading in compareToResultReadings)
            {
                switch (reading.Label)
                {
                    case ReadingLabels.LeftABI:
                        if (FloChecABITestResult.LeftResultReadings == null || FloChecABITestResult.LeftResultReadings.ABI == null)
                        {
                            newTestResult.ResultStatus.Status = TestResultStatus.Incomplete;
                            return newTestResult;
                        }
                        break;

                    case ReadingLabels.LeftHandBFI:
                        if (FloChecABITestResult.LeftResultReadings == null || FloChecABITestResult.LeftResultReadings.BFI == null)
                        {
                            newTestResult.ResultStatus.Status = TestResultStatus.Incomplete;
                            return newTestResult;
                        }
                        break;

                    case ReadingLabels.RightABI:
                        if (FloChecABITestResult.RightResultReadings == null || FloChecABITestResult.RightResultReadings.ABI == null)
                        {
                            newTestResult.ResultStatus.Status = TestResultStatus.Incomplete;
                            return newTestResult;
                        }
                        break;

                    case ReadingLabels.RightHandBFI:
                        if (FloChecABITestResult.RightResultReadings == null || FloChecABITestResult.RightResultReadings.BFI == null)
                        {
                            newTestResult.ResultStatus.Status = TestResultStatus.Incomplete;
                            return newTestResult;
                        }
                        break;
                }
            }

            if (FloChecABITestResult.ResultImage == null || FloChecABITestResult.ResultImage.File == null)
                FloChecABITestResult.ResultStatus.Status = TestResultStatus.Incomplete;
            else
                FloChecABITestResult.ResultStatus.Status = TestResultStatus.Complete;

            newTestResult.ResultStatus.Status = FloChecABITestResult.Finding == null ? TestResultStatus.Incomplete : TestResultStatus.Complete;

            return FloChecABITestResult;
        }

        private TestResult OldResultStateManualEntry(IEnumerable<ResultReading<int>> compareToResultReadings, TestResult newTestResult)
        {
            if (newTestResult.ResultStatus.StateNumber == (int)TestResultStateNumber.PreAudit) return newTestResult;
            var newFloChecABITestResult = (FloChecABITestResult)newTestResult;

            foreach (var reading in compareToResultReadings)
            {
                bool returnStatus;
                switch (reading.Label)
                {
                    case ReadingLabels.LeftABI:
                        returnStatus = SynchronizeForChangeReadingSource(reading.ReadingSource, newFloChecABITestResult.LeftResultReadings != null ? newFloChecABITestResult.LeftResultReadings.ABI : null);
                        if (returnStatus)
                        {
                            newFloChecABITestResult.ResultStatus.StateNumber = (int)TestResultStateNumber.ManualEntry;
                            return newFloChecABITestResult;
                        }
                        break;

                    case ReadingLabels.LeftHandBFI:
                        returnStatus = SynchronizeForChangeReadingSource(reading.ReadingSource, newFloChecABITestResult.LeftResultReadings != null ? newFloChecABITestResult.LeftResultReadings.BFI : null);
                        if (returnStatus)
                        {
                            newFloChecABITestResult.ResultStatus.StateNumber = (int)TestResultStateNumber.ManualEntry;
                            return newFloChecABITestResult;
                        }
                        break;

                    case ReadingLabels.RightABI:
                        returnStatus = SynchronizeForChangeReadingSource(reading.ReadingSource, newFloChecABITestResult.RightResultReadings != null ? newFloChecABITestResult.RightResultReadings.ABI : null);
                        if (returnStatus)
                        {
                            newFloChecABITestResult.ResultStatus.StateNumber = (int)TestResultStateNumber.ManualEntry;
                            return newFloChecABITestResult;
                        }
                        break;

                    case ReadingLabels.RightHandBFI:
                        returnStatus = SynchronizeForChangeReadingSource(reading.ReadingSource, newFloChecABITestResult.RightResultReadings != null ? newFloChecABITestResult.RightResultReadings.BFI : null);
                        if (returnStatus)
                        {
                            newFloChecABITestResult.ResultStatus.StateNumber = (int)TestResultStateNumber.ManualEntry;
                            return newFloChecABITestResult;
                        }
                        break;

                    case ReadingLabels.PencilDopplerUsed:
                        returnStatus = SynchronizeForChangeReadingSource(reading.ReadingSource, newFloChecABITestResult.PencilDopplerUsed);
                        if (returnStatus)
                        {
                            newFloChecABITestResult.ResultStatus.StateNumber = (int)TestResultStateNumber.ManualEntry;
                            return newFloChecABITestResult;
                        }
                        break;
                }
            }

            if ((newFloChecABITestResult.UnableScreenReason != null && newFloChecABITestResult.UnableScreenReason.Count > 0) || (newFloChecABITestResult.IncidentalFindings != null && newFloChecABITestResult.IncidentalFindings.Count > 0))
            {
                newFloChecABITestResult.ResultStatus.StateNumber = (int)TestResultStateNumber.ManualEntry;
                return newFloChecABITestResult;
            }

            newFloChecABITestResult.ResultStatus.StateNumber = (int)TestResultStateNumber.ResultsUploaded;
            return newFloChecABITestResult;
        }

        private TestResult NewResultStateManualEntry(IEnumerable<ResultReading<int>> compareToResultReadings, TestResult newTestResult)
        {
            if (newTestResult.ResultStatus.StateNumber == (int)NewTestResultStateNumber.PreAudit) return newTestResult;
            var newFloChecABITestResult = (FloChecABITestResult)newTestResult;

            foreach (var reading in compareToResultReadings)
            {
                bool returnStatus;
                switch (reading.Label)
                {
                    case ReadingLabels.LeftABI:
                        returnStatus = SynchronizeForChangeReadingSource(reading.ReadingSource, newFloChecABITestResult.LeftResultReadings != null ? newFloChecABITestResult.LeftResultReadings.ABI : null);
                        if (returnStatus)
                        {
                            newFloChecABITestResult.ResultStatus.StateNumber = (int)NewTestResultStateNumber.ResultEntryPartial;
                            return newFloChecABITestResult;
                        }
                        break;

                    case ReadingLabels.LeftHandBFI:
                        returnStatus = SynchronizeForChangeReadingSource(reading.ReadingSource, newFloChecABITestResult.LeftResultReadings != null ? newFloChecABITestResult.LeftResultReadings.BFI : null);
                        if (returnStatus)
                        {
                            newFloChecABITestResult.ResultStatus.StateNumber = (int)NewTestResultStateNumber.ResultEntryPartial;
                            return newFloChecABITestResult;
                        }
                        break;

                    case ReadingLabels.RightABI:
                        returnStatus = SynchronizeForChangeReadingSource(reading.ReadingSource, newFloChecABITestResult.RightResultReadings != null ? newFloChecABITestResult.RightResultReadings.ABI : null);
                        if (returnStatus)
                        {
                            newFloChecABITestResult.ResultStatus.StateNumber = (int)NewTestResultStateNumber.ResultEntryPartial;
                            return newFloChecABITestResult;
                        }
                        break;

                    case ReadingLabels.RightHandBFI:
                        returnStatus = SynchronizeForChangeReadingSource(reading.ReadingSource, newFloChecABITestResult.RightResultReadings != null ? newFloChecABITestResult.RightResultReadings.BFI : null);
                        if (returnStatus)
                        {
                            newFloChecABITestResult.ResultStatus.StateNumber = (int)NewTestResultStateNumber.ResultEntryPartial;
                            return newFloChecABITestResult;
                        }
                        break;

                    case ReadingLabels.PencilDopplerUsed:
                        returnStatus = SynchronizeForChangeReadingSource(reading.ReadingSource, newFloChecABITestResult.PencilDopplerUsed);
                        if (returnStatus)
                        {
                            newFloChecABITestResult.ResultStatus.StateNumber = (int)NewTestResultStateNumber.ResultEntryPartial;
                            return newFloChecABITestResult;
                        }
                        break;
                }
            }

            if ((newFloChecABITestResult.UnableScreenReason != null && newFloChecABITestResult.UnableScreenReason.Count > 0) || (newFloChecABITestResult.IncidentalFindings != null && newFloChecABITestResult.IncidentalFindings.Count > 0))
            {
                newFloChecABITestResult.ResultStatus.StateNumber = (int)NewTestResultStateNumber.ResultEntryPartial;
                return newFloChecABITestResult;
            }

            newFloChecABITestResult.ResultStatus.StateNumber = (int)NewTestResultStateNumber.ResultEntryPartial;
            return newFloChecABITestResult;
        }
    }
}