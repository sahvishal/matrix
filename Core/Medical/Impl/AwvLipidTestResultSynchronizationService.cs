using System.Collections.Generic;
using Falcon.App.Core.Medical.Domain;
using Falcon.App.Core.Medical.Enum;

namespace Falcon.App.Core.Medical.Impl
{
    public class AwvLipidTestResultSynchronizationService : TestResultSynchronizationService
    {
        public AwvLipidTestResultSynchronizationService(ReadingSource newTestReadingSource)
        {
            NewReadingSource = newTestReadingSource;
        }

        public override TestResult SynchronizeTestResult(TestResult currentTestResult, TestResult newTestResult, bool isNewResultFlow)
        {
            var newAwvLipidTestResult = (AwvLipidTestResult)newTestResult;

            if (currentTestResult == null)
            {
                SynchronizeResultReadingsForRecorderMetaData(newTestResult);

                if (newAwvLipidTestResult.TotalCholestrol != null && newAwvLipidTestResult.TotalCholestrol.Reading == null && newAwvLipidTestResult.TotalCholestrol.Finding == null) newAwvLipidTestResult.TotalCholestrol = null;
                if (newAwvLipidTestResult.HDL != null && newAwvLipidTestResult.HDL.Reading == null && newAwvLipidTestResult.HDL.Finding == null) newAwvLipidTestResult.HDL = null;
                if (newAwvLipidTestResult.LDL != null && newAwvLipidTestResult.LDL.Reading == null && newAwvLipidTestResult.LDL.Finding == null) newAwvLipidTestResult.LDL = null;
                if (newAwvLipidTestResult.TriGlycerides != null && newAwvLipidTestResult.TriGlycerides.Reading == null && newAwvLipidTestResult.TriGlycerides.Finding == null) newAwvLipidTestResult.TriGlycerides = null;
                if (newAwvLipidTestResult.TCHDLRatio != null && newAwvLipidTestResult.TCHDLRatio.Reading == null && newAwvLipidTestResult.TCHDLRatio.Finding == null) newAwvLipidTestResult.TCHDLRatio = null;

                SyncronizeTestResult(currentTestResult, newTestResult);

                return newAwvLipidTestResult;
            }

            var currentAwvLipidTestResult = (AwvLipidTestResult)currentTestResult;
            newAwvLipidTestResult.Id = currentAwvLipidTestResult.Id;
            newTestResult.ResultStatus.Id = currentTestResult.ResultStatus.Id;

            newAwvLipidTestResult.TotalCholestrol = SynchronizeResultReading(currentAwvLipidTestResult.TotalCholestrol, newAwvLipidTestResult.TotalCholestrol, newTestResult.DataRecorderMetaData);
            newAwvLipidTestResult.HDL = SynchronizeResultReading(currentAwvLipidTestResult.HDL, newAwvLipidTestResult.HDL, newTestResult.DataRecorderMetaData);
            newAwvLipidTestResult.LDL = SynchronizeResultReading(currentAwvLipidTestResult.LDL, newAwvLipidTestResult.LDL, newTestResult.DataRecorderMetaData);
            newAwvLipidTestResult.TriGlycerides = SynchronizeResultReading(currentAwvLipidTestResult.TriGlycerides, newAwvLipidTestResult.TriGlycerides, newTestResult.DataRecorderMetaData);
            newAwvLipidTestResult.TCHDLRatio = SynchronizeResultReading(currentAwvLipidTestResult.TCHDLRatio, newAwvLipidTestResult.TCHDLRatio, newTestResult.DataRecorderMetaData);

            if (NewReadingSource == ReadingSource.Automatic)
            {
                newAwvLipidTestResult = (AwvLipidTestResult)SyncronizeTestResultForAutomaticUploadwithManual(currentAwvLipidTestResult, newAwvLipidTestResult);
            }

            SyncronizeTestResult(currentTestResult, newTestResult);
            return newAwvLipidTestResult;
        }

        public override TestResult IsTestIncomplete(List<ResultReading<int>> compareToResultReadings, TestResult newTestResult, bool isNewResultFlow)
        {
            var awvLipidTestResult = newTestResult as AwvLipidTestResult;
            if (awvLipidTestResult == null) return awvLipidTestResult;

            if (awvLipidTestResult.TestPerformedExternally != null)
            {
                if (awvLipidTestResult.TestPerformedExternally.ResultEntryTypeId == (long)ResultEntryType.Chat && awvLipidTestResult.TestPerformedExternally.EntryCompleted)
                {
                    newTestResult.ResultStatus.Status = TestResultStatus.Complete;
                }
                else
                {
                    newTestResult.ResultStatus.Status = TestResultStatus.Incomplete;
                }
                return awvLipidTestResult;
            }

            foreach (var reading in compareToResultReadings)
            {
                switch (reading.Label)
                {

                    case ReadingLabels.TCHDLRatio:
                        if (IsIncompleteReading(awvLipidTestResult.TCHDLRatio))
                        {
                            newTestResult.ResultStatus.Status = TestResultStatus.Incomplete;
                            return newTestResult;
                        }
                        break;

                    case ReadingLabels.TotalCholestrol:
                        if (IsIncompleteReading(awvLipidTestResult.TotalCholestrol))
                        {
                            newTestResult.ResultStatus.Status = TestResultStatus.Incomplete;
                            return newTestResult;
                        }
                        break;

                    case ReadingLabels.TriGlycerides:
                        if (IsIncompleteReading(awvLipidTestResult.TriGlycerides))
                        {
                            newTestResult.ResultStatus.Status = TestResultStatus.Incomplete;
                            return newTestResult;
                        }
                        break;

                    case ReadingLabels.HDL:
                        if (IsIncompleteReading(awvLipidTestResult.HDL))
                        {
                            newTestResult.ResultStatus.Status = TestResultStatus.Incomplete;
                            return newTestResult;
                        }
                        break;

                    case ReadingLabels.LDL:
                        if (IsIncompleteReading(awvLipidTestResult.LDL))
                        {
                            newTestResult.ResultStatus.Status = TestResultStatus.Incomplete;
                            return newTestResult;
                        }
                        break;
                }
            }

            newTestResult.ResultStatus.Status = TestResultStatus.Complete;
            return awvLipidTestResult;
        }


        public override TestResult GetManualEntryUploadStatus(List<ResultReading<int>> compareToResultReadings, TestResult newTestResult, bool isNewResultFlow)
        {
            if (isNewResultFlow)
            {
                var newAwvLipidTestResult = NewResultStateManualEntry(compareToResultReadings, newTestResult);
                if (newAwvLipidTestResult.ResultStatus.Status == TestResultStatus.Complete && newAwvLipidTestResult.ResultStatus.StateNumber == (int)NewTestResultStateNumber.ResultEntryPartial)
                    newAwvLipidTestResult.ResultStatus.StateNumber = (int)NewTestResultStateNumber.ResultEntryCompleted;
                return newAwvLipidTestResult;
            }
            return OldResultStateManualEntry(compareToResultReadings, newTestResult);
        }

        private TestResult OldResultStateManualEntry(IEnumerable<ResultReading<int>> compareToResultReadings, TestResult newTestResult)
        {
            if (newTestResult.ResultStatus.StateNumber == (int)TestResultStateNumber.PreAudit) return newTestResult;
            var newAwvLipidTestResult = (AwvLipidTestResult)newTestResult;

            foreach (var reading in compareToResultReadings)
            {
                bool returnStatus;
                switch (reading.Label)
                {

                    case ReadingLabels.TCHDLRatio:
                        returnStatus = SynchronizeForChangeReadingSource(reading.ReadingSource, newAwvLipidTestResult.TCHDLRatio);
                        if (returnStatus) { newAwvLipidTestResult.ResultStatus.StateNumber = (int)TestResultStateNumber.ManualEntry; return newAwvLipidTestResult; }
                        break;

                    case ReadingLabels.TotalCholestrol:
                        returnStatus = SynchronizeForChangeReadingSource(reading.ReadingSource, newAwvLipidTestResult.TotalCholestrol);
                        if (returnStatus) { newAwvLipidTestResult.ResultStatus.StateNumber = (int)TestResultStateNumber.ManualEntry; return newAwvLipidTestResult; }
                        break;

                    case ReadingLabels.TriGlycerides:
                        returnStatus = SynchronizeForChangeReadingSource(reading.ReadingSource, newAwvLipidTestResult.TriGlycerides);
                        if (returnStatus) { newAwvLipidTestResult.ResultStatus.StateNumber = (int)TestResultStateNumber.ManualEntry; return newAwvLipidTestResult; }
                        break;

                    case ReadingLabels.HDL:
                        returnStatus = SynchronizeForChangeReadingSource(reading.ReadingSource, newAwvLipidTestResult.HDL);
                        if (returnStatus) { newAwvLipidTestResult.ResultStatus.StateNumber = (int)TestResultStateNumber.ManualEntry; return newAwvLipidTestResult; }
                        break;

                    case ReadingLabels.LDL:
                        returnStatus = SynchronizeForChangeReadingSource(reading.ReadingSource, newAwvLipidTestResult.LDL);
                        if (returnStatus) { newAwvLipidTestResult.ResultStatus.StateNumber = (int)TestResultStateNumber.ManualEntry; return newAwvLipidTestResult; }
                        break;
                }
            }

            if (newAwvLipidTestResult.UnableScreenReason != null && newAwvLipidTestResult.UnableScreenReason.Count > 0)
            {
                newAwvLipidTestResult.ResultStatus.StateNumber = (int)TestResultStateNumber.ManualEntry;
                return newAwvLipidTestResult;
            }

            newAwvLipidTestResult.ResultStatus.StateNumber = (int)TestResultStateNumber.ResultsUploaded;
            return newAwvLipidTestResult;
        }

        private TestResult NewResultStateManualEntry(IEnumerable<ResultReading<int>> compareToResultReadings, TestResult newTestResult)
        {
            if (newTestResult.ResultStatus.StateNumber == (int)NewTestResultStateNumber.PreAudit) return newTestResult;
            var newAwvLipidTestResult = (AwvLipidTestResult)newTestResult;

            foreach (var reading in compareToResultReadings)
            {
                bool returnStatus;
                switch (reading.Label)
                {

                    case ReadingLabels.TCHDLRatio:
                        returnStatus = SynchronizeForChangeReadingSource(reading.ReadingSource, newAwvLipidTestResult.TCHDLRatio);
                        if (returnStatus) { newAwvLipidTestResult.ResultStatus.StateNumber = (int)NewTestResultStateNumber.ResultEntryPartial; return newAwvLipidTestResult; }
                        break;

                    case ReadingLabels.TotalCholestrol:
                        returnStatus = SynchronizeForChangeReadingSource(reading.ReadingSource, newAwvLipidTestResult.TotalCholestrol);
                        if (returnStatus) { newAwvLipidTestResult.ResultStatus.StateNumber = (int)NewTestResultStateNumber.ResultEntryPartial; return newAwvLipidTestResult; }
                        break;

                    case ReadingLabels.TriGlycerides:
                        returnStatus = SynchronizeForChangeReadingSource(reading.ReadingSource, newAwvLipidTestResult.TriGlycerides);
                        if (returnStatus) { newAwvLipidTestResult.ResultStatus.StateNumber = (int)NewTestResultStateNumber.ResultEntryPartial; return newAwvLipidTestResult; }
                        break;

                    case ReadingLabels.HDL:
                        returnStatus = SynchronizeForChangeReadingSource(reading.ReadingSource, newAwvLipidTestResult.HDL);
                        if (returnStatus) { newAwvLipidTestResult.ResultStatus.StateNumber = (int)NewTestResultStateNumber.ResultEntryPartial; return newAwvLipidTestResult; }
                        break;

                    case ReadingLabels.LDL:
                        returnStatus = SynchronizeForChangeReadingSource(reading.ReadingSource, newAwvLipidTestResult.LDL);
                        if (returnStatus) { newAwvLipidTestResult.ResultStatus.StateNumber = (int)NewTestResultStateNumber.ResultEntryPartial; return newAwvLipidTestResult; }
                        break;
                }
            }

            if (newAwvLipidTestResult.UnableScreenReason != null && newAwvLipidTestResult.UnableScreenReason.Count > 0)
            {
                newAwvLipidTestResult.ResultStatus.StateNumber = (int)NewTestResultStateNumber.ResultEntryPartial;
                return newAwvLipidTestResult;
            }

            newAwvLipidTestResult.ResultStatus.StateNumber = (int)NewTestResultStateNumber.ResultEntryPartial;
            return newAwvLipidTestResult;
        }
    }
}
