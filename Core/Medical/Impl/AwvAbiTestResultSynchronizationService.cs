using System.Collections.Generic;
using Falcon.App.Core.Medical.Domain;
using Falcon.App.Core.Medical.Enum;

namespace Falcon.App.Core.Medical.Impl
{
    public class AwvAbiTestResultSynchronizationService : TestResultSynchronizationService
    {
        public AwvAbiTestResultSynchronizationService(ReadingSource readingSource)
        {
            NewReadingSource = readingSource;
        }

        public override TestResult SynchronizeTestResult(TestResult currentTestResult, TestResult newTestResult, bool isNewResultFlow)
        {
            var newAwvAbiTestResult = (AwvAbiTestResult)newTestResult;

            if (currentTestResult == null)
            {
                SynchronizeResultReadingsForRecorderMetaData(newTestResult);

                if (newAwvAbiTestResult.LeftResultReadings != null)
                {
                    if (newAwvAbiTestResult.LeftResultReadings.ABI != null && newAwvAbiTestResult.LeftResultReadings.ABI.Reading == null) newAwvAbiTestResult.LeftResultReadings.ABI = null;
                    if (newAwvAbiTestResult.LeftResultReadings.SystolicAnkle != null && newAwvAbiTestResult.LeftResultReadings.SystolicAnkle.Reading == null) newAwvAbiTestResult.LeftResultReadings.SystolicAnkle = null;
                    if (newAwvAbiTestResult.LeftResultReadings.SystolicArm != null && newAwvAbiTestResult.LeftResultReadings.SystolicArm.Reading == null) newAwvAbiTestResult.LeftResultReadings.SystolicArm = null;
                }

                if (newAwvAbiTestResult.RightResultReadings != null)
                {
                    if (newAwvAbiTestResult.RightResultReadings.ABI != null && newAwvAbiTestResult.RightResultReadings.ABI.Reading == null) newAwvAbiTestResult.RightResultReadings.ABI = null;
                    if (newAwvAbiTestResult.RightResultReadings.SystolicAnkle != null && newAwvAbiTestResult.RightResultReadings.SystolicAnkle.Reading == null) newAwvAbiTestResult.RightResultReadings.SystolicAnkle = null;
                    if (newAwvAbiTestResult.RightResultReadings.SystolicArm != null && newAwvAbiTestResult.RightResultReadings.SystolicArm.Reading == null) newAwvAbiTestResult.RightResultReadings.SystolicArm = null;
                }

                SyncronizeTestResult(currentTestResult, newTestResult);
                return newAwvAbiTestResult;
            }

            var currentAwvAbiTestResult = (AwvAbiTestResult)currentTestResult;
            newAwvAbiTestResult.Id = currentAwvAbiTestResult.Id;
            newTestResult.ResultStatus.Id = currentTestResult.ResultStatus.Id;

            if (newAwvAbiTestResult.LeftResultReadings == null && currentAwvAbiTestResult.LeftResultReadings != null)
            {
                newAwvAbiTestResult.LeftResultReadings = new PadTestReadings();
            }

            if (currentAwvAbiTestResult.LeftResultReadings != null)
            {
                newAwvAbiTestResult.LeftResultReadings.ABI = SynchronizeResultReading(currentAwvAbiTestResult.LeftResultReadings.ABI, newAwvAbiTestResult.LeftResultReadings.ABI, newTestResult.DataRecorderMetaData);

                newAwvAbiTestResult.LeftResultReadings.SystolicArm = SynchronizeResultReading(currentAwvAbiTestResult.LeftResultReadings.SystolicArm, newAwvAbiTestResult.LeftResultReadings.SystolicArm, newTestResult.DataRecorderMetaData);

                newAwvAbiTestResult.LeftResultReadings.SystolicAnkle = SynchronizeResultReading(currentAwvAbiTestResult.LeftResultReadings.SystolicAnkle, newAwvAbiTestResult.LeftResultReadings.SystolicAnkle, newTestResult.DataRecorderMetaData);
            }


            if (newAwvAbiTestResult.RightResultReadings == null && currentAwvAbiTestResult.RightResultReadings != null)
            {
                newAwvAbiTestResult.RightResultReadings = new PadTestReadings();
            }

            if (currentAwvAbiTestResult.RightResultReadings != null)
            {
                newAwvAbiTestResult.RightResultReadings.ABI = SynchronizeResultReading(currentAwvAbiTestResult.RightResultReadings.ABI, newAwvAbiTestResult.RightResultReadings.ABI, newTestResult.DataRecorderMetaData);
                newAwvAbiTestResult.RightResultReadings.SystolicArm = SynchronizeResultReading(currentAwvAbiTestResult.RightResultReadings.SystolicArm, newAwvAbiTestResult.RightResultReadings.SystolicArm, newTestResult.DataRecorderMetaData);
                newAwvAbiTestResult.RightResultReadings.SystolicAnkle = SynchronizeResultReading(currentAwvAbiTestResult.RightResultReadings.SystolicAnkle, newAwvAbiTestResult.RightResultReadings.SystolicAnkle, newTestResult.DataRecorderMetaData);
            }

            if (newAwvAbiTestResult.Finding == null && newAwvAbiTestResult.LeftResultReadings != null && newAwvAbiTestResult.RightResultReadings != null && currentAwvAbiTestResult.Finding != null)
            {
                if (currentAwvAbiTestResult.LeftResultReadings != null && ((newAwvAbiTestResult.LeftResultReadings.ABI == null && currentAwvAbiTestResult.LeftResultReadings.ABI == null)
                    || (newAwvAbiTestResult.LeftResultReadings.ABI != null && currentAwvAbiTestResult.LeftResultReadings.ABI != null && currentAwvAbiTestResult.LeftResultReadings.ABI.Reading == newAwvAbiTestResult.LeftResultReadings.ABI.Reading))
                    &&
                    currentAwvAbiTestResult.RightResultReadings != null && ((newAwvAbiTestResult.RightResultReadings.ABI == null && currentAwvAbiTestResult.RightResultReadings.ABI == null)
                    || (newAwvAbiTestResult.RightResultReadings.ABI != null && currentAwvAbiTestResult.RightResultReadings.ABI != null && currentAwvAbiTestResult.RightResultReadings.ABI.Reading == newAwvAbiTestResult.RightResultReadings.ABI.Reading)))
                    newAwvAbiTestResult.Finding = currentAwvAbiTestResult.Finding;
            }

            if (NewReadingSource == ReadingSource.Automatic)
            {
                newAwvAbiTestResult = (AwvAbiTestResult)SyncronizeTestResultForAutomaticUploadwithManual(currentAwvAbiTestResult, newAwvAbiTestResult);
            }

            SyncronizeTestResult(currentTestResult, newTestResult);
            return newAwvAbiTestResult;
        }

        public override TestResult GetManualEntryUploadStatus(List<ResultReading<int>> compareToResultReadings, TestResult newTestResult, bool isNewResultFlow)
        {
            if (isNewResultFlow)
            {
                var newAwvAbiTestResult = NewManualEntryUploadStatus(compareToResultReadings, newTestResult);
                if (newAwvAbiTestResult.ResultStatus.Status == TestResultStatus.Complete && newAwvAbiTestResult.ResultStatus.StateNumber == (int)NewTestResultStateNumber.ResultEntryPartial)
                    newAwvAbiTestResult.ResultStatus.StateNumber = (int)NewTestResultStateNumber.ResultEntryCompleted;

                return newAwvAbiTestResult;
            }

            return OldManualEntryUploadStatus(compareToResultReadings, newTestResult);
        }

        public override TestResult IsTestIncomplete(List<ResultReading<int>> compareToResultReadings, TestResult newTestResult, bool isNewResultFlow)
        {
            var awvAbiTestResult = newTestResult as AwvAbiTestResult;
            if (awvAbiTestResult == null) return null;

            if (awvAbiTestResult.TestPerformedExternally != null)
            {
                if (awvAbiTestResult.TestPerformedExternally.ResultEntryTypeId == (long)ResultEntryType.Chat && awvAbiTestResult.TestPerformedExternally.EntryCompleted)
                {
                    newTestResult.ResultStatus.Status = TestResultStatus.Complete;
                }
                else
                {
                    newTestResult.ResultStatus.Status = TestResultStatus.Incomplete;
                }
                return awvAbiTestResult;
            }

            foreach (var reading in compareToResultReadings)
            {
                switch (reading.Label)
                {
                    case ReadingLabels.LeftABI:
                        if (awvAbiTestResult.LeftResultReadings == null || awvAbiTestResult.LeftResultReadings.ABI == null)
                        {
                            newTestResult.ResultStatus.Status = TestResultStatus.Incomplete;
                            return newTestResult;
                        }
                        break;

                    case ReadingLabels.SystolicLArm:
                        if (awvAbiTestResult.LeftResultReadings == null || awvAbiTestResult.LeftResultReadings.SystolicArm == null)
                        {
                            newTestResult.ResultStatus.Status = TestResultStatus.Incomplete;
                            return newTestResult;
                        }
                        break;

                    case ReadingLabels.SystolicLAnkle:
                        if (awvAbiTestResult.LeftResultReadings == null || awvAbiTestResult.LeftResultReadings.SystolicAnkle == null)
                        {
                            newTestResult.ResultStatus.Status = TestResultStatus.Incomplete;
                            return newTestResult;
                        }
                        break;

                    case ReadingLabels.RightABI:
                        if (awvAbiTestResult.RightResultReadings == null || awvAbiTestResult.RightResultReadings.ABI == null)
                        {
                            newTestResult.ResultStatus.Status = TestResultStatus.Incomplete;
                            return newTestResult;
                        }
                        break;

                    case ReadingLabels.SystolicRArm:
                        if (awvAbiTestResult.RightResultReadings == null || awvAbiTestResult.RightResultReadings.SystolicArm == null)
                        {
                            newTestResult.ResultStatus.Status = TestResultStatus.Incomplete;
                            return newTestResult;
                        }
                        break;

                    case ReadingLabels.SystolicRAnkle:
                        if (awvAbiTestResult.RightResultReadings == null || awvAbiTestResult.RightResultReadings.SystolicAnkle == null)
                        {
                            newTestResult.ResultStatus.Status = TestResultStatus.Incomplete;
                            return newTestResult;
                        }
                        break;


                }
            }

            newTestResult.ResultStatus.Status = awvAbiTestResult.Finding == null ? TestResultStatus.Incomplete : TestResultStatus.Complete;

            return awvAbiTestResult;
        }

        private TestResult OldManualEntryUploadStatus(List<ResultReading<int>> compareToResultReadings, TestResult newTestResult)
        {
            if (newTestResult.ResultStatus.StateNumber == (int)TestResultStateNumber.PreAudit) return newTestResult;
            var newAwvAbiTestResult = (AwvAbiTestResult)newTestResult;

            foreach (var reading in compareToResultReadings)
            {
                bool returnStatus;
                switch (reading.Label)
                {
                    case ReadingLabels.LeftABI:
                        returnStatus = SynchronizeForChangeReadingSource(reading.ReadingSource, newAwvAbiTestResult.LeftResultReadings != null ? newAwvAbiTestResult.LeftResultReadings.ABI : null);
                        if (returnStatus)
                        {
                            newAwvAbiTestResult.ResultStatus.StateNumber = (int)TestResultStateNumber.ManualEntry;
                            return newAwvAbiTestResult;
                        }
                        break;

                    case ReadingLabels.SystolicLArm:
                        returnStatus = SynchronizeForChangeReadingSource(reading.ReadingSource, newAwvAbiTestResult.LeftResultReadings != null ? newAwvAbiTestResult.LeftResultReadings.SystolicArm : null);
                        if (returnStatus)
                        {
                            newAwvAbiTestResult.ResultStatus.StateNumber = (int)TestResultStateNumber.ManualEntry;
                            return newAwvAbiTestResult;
                        }
                        break;

                    case ReadingLabels.SystolicLAnkle:
                        returnStatus = SynchronizeForChangeReadingSource(reading.ReadingSource, newAwvAbiTestResult.LeftResultReadings != null ? newAwvAbiTestResult.LeftResultReadings.SystolicAnkle : null);
                        if (returnStatus)
                        {
                            newAwvAbiTestResult.ResultStatus.StateNumber = (int)TestResultStateNumber.ManualEntry;
                            return newAwvAbiTestResult;
                        }
                        break;

                    case ReadingLabels.RightABI:
                        returnStatus = SynchronizeForChangeReadingSource(reading.ReadingSource, newAwvAbiTestResult.RightResultReadings != null ? newAwvAbiTestResult.RightResultReadings.ABI : null);
                        if (returnStatus)
                        {
                            newAwvAbiTestResult.ResultStatus.StateNumber = (int)TestResultStateNumber.ManualEntry;
                            return newAwvAbiTestResult;
                        }
                        break;

                    case ReadingLabels.SystolicRArm:
                        returnStatus = SynchronizeForChangeReadingSource(reading.ReadingSource, newAwvAbiTestResult.RightResultReadings != null ? newAwvAbiTestResult.RightResultReadings.SystolicArm : null);
                        if (returnStatus)
                        {
                            newAwvAbiTestResult.ResultStatus.StateNumber = (int)TestResultStateNumber.ManualEntry;
                            return newAwvAbiTestResult;
                        }
                        break;

                    case ReadingLabels.SystolicRAnkle:
                        returnStatus = SynchronizeForChangeReadingSource(reading.ReadingSource, newAwvAbiTestResult.RightResultReadings != null ? newAwvAbiTestResult.RightResultReadings.SystolicAnkle : null);
                        if (returnStatus)
                        {
                            newAwvAbiTestResult.ResultStatus.StateNumber = (int)TestResultStateNumber.ManualEntry;
                            return newAwvAbiTestResult;
                        }
                        break;
                }
            }

            if ((newAwvAbiTestResult.UnableScreenReason != null && newAwvAbiTestResult.UnableScreenReason.Count > 0) || (newAwvAbiTestResult.IncidentalFindings != null && newAwvAbiTestResult.IncidentalFindings.Count > 0))
            {
                newAwvAbiTestResult.ResultStatus.StateNumber = (int)TestResultStateNumber.ManualEntry;
                return newAwvAbiTestResult;
            }

            newAwvAbiTestResult.ResultStatus.StateNumber = (int)TestResultStateNumber.ResultsUploaded;
            return newAwvAbiTestResult;
        }

        private TestResult NewManualEntryUploadStatus(IEnumerable<ResultReading<int>> compareToResultReadings, TestResult newTestResult)
        {
            if (newTestResult.ResultStatus.StateNumber == (int)NewTestResultStateNumber.PreAudit) return newTestResult;
            var newAwvAbiTestResult = (AwvAbiTestResult)newTestResult;

            foreach (var reading in compareToResultReadings)
            {
                bool returnStatus;
                switch (reading.Label)
                {
                    case ReadingLabels.LeftABI:
                        returnStatus = SynchronizeForChangeReadingSource(reading.ReadingSource, newAwvAbiTestResult.LeftResultReadings != null ? newAwvAbiTestResult.LeftResultReadings.ABI : null);
                        if (returnStatus)
                        {
                            newAwvAbiTestResult.ResultStatus.StateNumber = (int)NewTestResultStateNumber.ResultEntryPartial;
                            return newAwvAbiTestResult;
                        }
                        break;

                    case ReadingLabels.SystolicLArm:
                        returnStatus = SynchronizeForChangeReadingSource(reading.ReadingSource, newAwvAbiTestResult.LeftResultReadings != null ? newAwvAbiTestResult.LeftResultReadings.SystolicArm : null);
                        if (returnStatus)
                        {
                            newAwvAbiTestResult.ResultStatus.StateNumber = (int)NewTestResultStateNumber.ResultEntryPartial;
                            return newAwvAbiTestResult;
                        }
                        break;

                    case ReadingLabels.SystolicLAnkle:
                        returnStatus = SynchronizeForChangeReadingSource(reading.ReadingSource, newAwvAbiTestResult.LeftResultReadings != null ? newAwvAbiTestResult.LeftResultReadings.SystolicAnkle : null);
                        if (returnStatus)
                        {
                            newAwvAbiTestResult.ResultStatus.StateNumber = (int)NewTestResultStateNumber.ResultEntryPartial;
                            return newAwvAbiTestResult;
                        }
                        break;

                    case ReadingLabels.RightABI:
                        returnStatus = SynchronizeForChangeReadingSource(reading.ReadingSource, newAwvAbiTestResult.RightResultReadings != null ? newAwvAbiTestResult.RightResultReadings.ABI : null);
                        if (returnStatus)
                        {
                            newAwvAbiTestResult.ResultStatus.StateNumber = (int)NewTestResultStateNumber.ResultEntryPartial;
                            return newAwvAbiTestResult;
                        }
                        break;

                    case ReadingLabels.SystolicRArm:
                        returnStatus = SynchronizeForChangeReadingSource(reading.ReadingSource, newAwvAbiTestResult.RightResultReadings != null ? newAwvAbiTestResult.RightResultReadings.SystolicArm : null);
                        if (returnStatus)
                        {
                            newAwvAbiTestResult.ResultStatus.StateNumber = (int)NewTestResultStateNumber.ResultEntryPartial;
                            return newAwvAbiTestResult;
                        }
                        break;

                    case ReadingLabels.SystolicRAnkle:
                        returnStatus = SynchronizeForChangeReadingSource(reading.ReadingSource, newAwvAbiTestResult.RightResultReadings != null ? newAwvAbiTestResult.RightResultReadings.SystolicAnkle : null);
                        if (returnStatus)
                        {
                            newAwvAbiTestResult.ResultStatus.StateNumber = (int)NewTestResultStateNumber.ResultEntryPartial;
                            return newAwvAbiTestResult;
                        }
                        break;
                }
            }

            if ((newAwvAbiTestResult.UnableScreenReason != null && newAwvAbiTestResult.UnableScreenReason.Count > 0) || (newAwvAbiTestResult.IncidentalFindings != null && newAwvAbiTestResult.IncidentalFindings.Count > 0))
            {
                newAwvAbiTestResult.ResultStatus.StateNumber = (int)NewTestResultStateNumber.ResultEntryPartial;
                return newAwvAbiTestResult;
            }

            newAwvAbiTestResult.ResultStatus.StateNumber = (int)NewTestResultStateNumber.ResultEntryPartial;
            return newAwvAbiTestResult;
        }
    }
}
