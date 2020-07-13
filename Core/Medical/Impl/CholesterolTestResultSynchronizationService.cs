using System.Collections.Generic;
using Falcon.App.Core.Medical.Domain;
using Falcon.App.Core.Medical.Enum;

namespace Falcon.App.Core.Medical.Impl
{
    public class CholesterolTestResultSynchronizationService : TestResultSynchronizationService
    {
        public CholesterolTestResultSynchronizationService(ReadingSource newTestReadingSource)
        {
            NewReadingSource = newTestReadingSource;
        }

        public override TestResult SynchronizeTestResult(TestResult currentTestResult, TestResult newTestResult, bool isNewResultFlow)
        {
            var newCholesterolTestResult = (CholesterolTestResult)newTestResult;

            if (currentTestResult == null)
            {
                SynchronizeResultReadingsForRecorderMetaData(newTestResult);

                if (newCholesterolTestResult.TotalCholesterol != null && newCholesterolTestResult.TotalCholesterol.Reading == null && newCholesterolTestResult.TotalCholesterol.Finding == null) newCholesterolTestResult.TotalCholesterol = null;
                if (newCholesterolTestResult.HDL != null && newCholesterolTestResult.HDL.Reading == null && newCholesterolTestResult.HDL.Finding == null) newCholesterolTestResult.HDL = null;
                if (newCholesterolTestResult.LDL != null && newCholesterolTestResult.LDL.Reading == null && newCholesterolTestResult.LDL.Finding == null) newCholesterolTestResult.LDL = null;
                if (newCholesterolTestResult.TriGlycerides != null && newCholesterolTestResult.TriGlycerides.Reading == null && newCholesterolTestResult.TriGlycerides.Finding == null) newCholesterolTestResult.TriGlycerides = null;
                if (newCholesterolTestResult.TCHDLRatio != null && newCholesterolTestResult.TCHDLRatio.Reading == null && newCholesterolTestResult.TCHDLRatio.Finding == null) newCholesterolTestResult.TCHDLRatio = null;

                SyncronizeTestResult(currentTestResult, newTestResult);

                return newCholesterolTestResult;
            }

            var currentCholesterolTestResult = (CholesterolTestResult)currentTestResult;
            newCholesterolTestResult.Id = currentCholesterolTestResult.Id;
            newTestResult.ResultStatus.Id = currentTestResult.ResultStatus.Id;

            newCholesterolTestResult.TotalCholesterol = SynchronizeResultReading(currentCholesterolTestResult.TotalCholesterol, newCholesterolTestResult.TotalCholesterol, newTestResult.DataRecorderMetaData);
            newCholesterolTestResult.HDL = SynchronizeResultReading(currentCholesterolTestResult.HDL, newCholesterolTestResult.HDL, newTestResult.DataRecorderMetaData);
            newCholesterolTestResult.LDL = SynchronizeResultReading(currentCholesterolTestResult.LDL, newCholesterolTestResult.LDL, newTestResult.DataRecorderMetaData);
            newCholesterolTestResult.TriGlycerides = SynchronizeResultReading(currentCholesterolTestResult.TriGlycerides, newCholesterolTestResult.TriGlycerides, newTestResult.DataRecorderMetaData);
            newCholesterolTestResult.TCHDLRatio = SynchronizeResultReading(currentCholesterolTestResult.TCHDLRatio, newCholesterolTestResult.TCHDLRatio, newTestResult.DataRecorderMetaData);

            if (NewReadingSource == ReadingSource.Automatic)
            {
                newCholesterolTestResult = (CholesterolTestResult)SyncronizeTestResultForAutomaticUploadwithManual(currentCholesterolTestResult, newCholesterolTestResult);
            }

            SyncronizeTestResult(currentTestResult, newTestResult);
            return newCholesterolTestResult;
        }

        public override TestResult IsTestIncomplete(List<ResultReading<int>> compareToResultReadings, TestResult newTestResult, bool isNewResultFlow)
        {
            var cholesterolTestResult = newTestResult as CholesterolTestResult;
            if (cholesterolTestResult == null) return cholesterolTestResult;

            if (cholesterolTestResult.TestPerformedExternally != null)
            {
                if (cholesterolTestResult.TestPerformedExternally.ResultEntryTypeId == (long)ResultEntryType.Chat && cholesterolTestResult.TestPerformedExternally.EntryCompleted)
                {
                    newTestResult.ResultStatus.Status = TestResultStatus.Complete;
                }
                else
                {
                    newTestResult.ResultStatus.Status = TestResultStatus.Incomplete;
                }
                return cholesterolTestResult;
            }


            foreach (var reading in compareToResultReadings)
            {
                switch (reading.Label)
                {

                    case ReadingLabels.TCHDLRatio:
                        if (IsIncompleteReading(cholesterolTestResult.TCHDLRatio))
                        {
                            newTestResult.ResultStatus.Status = TestResultStatus.Incomplete;
                            return newTestResult;
                        }
                        break;

                    case ReadingLabels.TotalCholestrol:
                        if (IsIncompleteReading(cholesterolTestResult.TotalCholesterol))
                        {
                            newTestResult.ResultStatus.Status = TestResultStatus.Incomplete;
                            return newTestResult;
                        }
                        break;

                    case ReadingLabels.TriGlycerides:
                        if (IsIncompleteReading(cholesterolTestResult.TriGlycerides))
                        {
                            newTestResult.ResultStatus.Status = TestResultStatus.Incomplete;
                            return newTestResult;
                        }
                        break;

                    case ReadingLabels.HDL:
                        if (IsIncompleteReading(cholesterolTestResult.HDL))
                        {
                            newTestResult.ResultStatus.Status = TestResultStatus.Incomplete;
                            return newTestResult;
                        }
                        break;

                    case ReadingLabels.LDL:
                        if (IsIncompleteReading(cholesterolTestResult.LDL))
                        {
                            newTestResult.ResultStatus.Status = TestResultStatus.Incomplete;
                            return newTestResult;
                        }
                        break;
                }
            }

            newTestResult.ResultStatus.Status = TestResultStatus.Complete;
            return cholesterolTestResult;
        }


        public override TestResult GetManualEntryUploadStatus(List<ResultReading<int>> compareToResultReadings, TestResult newTestResult, bool isNewResultFlow)
        {
            if (isNewResultFlow)
            {
                var newCholesterolTestResult = NewResultStateManualEntry(compareToResultReadings, newTestResult);
                if (newCholesterolTestResult.ResultStatus.Status == TestResultStatus.Complete && newCholesterolTestResult.ResultStatus.StateNumber == (int)NewTestResultStateNumber.ResultEntryPartial)
                    newCholesterolTestResult.ResultStatus.StateNumber = (int)NewTestResultStateNumber.ResultEntryCompleted;
                return newCholesterolTestResult;
            }
            return OldResultStateManualEntry(compareToResultReadings, newTestResult);
        }

        private TestResult OldResultStateManualEntry(IEnumerable<ResultReading<int>> compareToResultReadings, TestResult newTestResult)
        {
            if (newTestResult.ResultStatus.StateNumber == (int)TestResultStateNumber.PreAudit) return newTestResult;
            var newCholesterolTestResult = (CholesterolTestResult)newTestResult;

            foreach (var reading in compareToResultReadings)
            {
                bool returnStatus;
                switch (reading.Label)
                {

                    case ReadingLabels.TCHDLRatio:
                        returnStatus = SynchronizeForChangeReadingSource(reading.ReadingSource, newCholesterolTestResult.TCHDLRatio);
                        if (returnStatus) { newCholesterolTestResult.ResultStatus.StateNumber = (int)TestResultStateNumber.ManualEntry; return newCholesterolTestResult; }
                        break;

                    case ReadingLabels.TotalCholestrol:
                        returnStatus = SynchronizeForChangeReadingSource(reading.ReadingSource, newCholesterolTestResult.TotalCholesterol);
                        if (returnStatus) { newCholesterolTestResult.ResultStatus.StateNumber = (int)TestResultStateNumber.ManualEntry; return newCholesterolTestResult; }
                        break;

                    case ReadingLabels.TriGlycerides:
                        returnStatus = SynchronizeForChangeReadingSource(reading.ReadingSource, newCholesterolTestResult.TriGlycerides);
                        if (returnStatus) { newCholesterolTestResult.ResultStatus.StateNumber = (int)TestResultStateNumber.ManualEntry; return newCholesterolTestResult; }
                        break;

                    case ReadingLabels.HDL:
                        returnStatus = SynchronizeForChangeReadingSource(reading.ReadingSource, newCholesterolTestResult.HDL);
                        if (returnStatus) { newCholesterolTestResult.ResultStatus.StateNumber = (int)TestResultStateNumber.ManualEntry; return newCholesterolTestResult; }
                        break;

                    case ReadingLabels.LDL:
                        returnStatus = SynchronizeForChangeReadingSource(reading.ReadingSource, newCholesterolTestResult.LDL);
                        if (returnStatus) { newCholesterolTestResult.ResultStatus.StateNumber = (int)TestResultStateNumber.ManualEntry; return newCholesterolTestResult; }
                        break;
                }
            }

            if (newCholesterolTestResult.UnableScreenReason != null && newCholesterolTestResult.UnableScreenReason.Count > 0)
            {
                newCholesterolTestResult.ResultStatus.StateNumber = (int)TestResultStateNumber.ManualEntry;
                return newCholesterolTestResult;
            }

            newCholesterolTestResult.ResultStatus.StateNumber = (int)TestResultStateNumber.ResultsUploaded;
            return newCholesterolTestResult;
        }

        private TestResult NewResultStateManualEntry(IEnumerable<ResultReading<int>> compareToResultReadings, TestResult newTestResult)
        {
            if (newTestResult.ResultStatus.StateNumber == (int)NewTestResultStateNumber.PreAudit) return newTestResult;
            var newCholesterolTestResult = (CholesterolTestResult)newTestResult;

            foreach (var reading in compareToResultReadings)
            {
                bool returnStatus;
                switch (reading.Label)
                {

                    case ReadingLabels.TCHDLRatio:
                        returnStatus = SynchronizeForChangeReadingSource(reading.ReadingSource, newCholesterolTestResult.TCHDLRatio);
                        if (returnStatus) { newCholesterolTestResult.ResultStatus.StateNumber = (int)NewTestResultStateNumber.ResultEntryPartial; return newCholesterolTestResult; }
                        break;

                    case ReadingLabels.TotalCholestrol:
                        returnStatus = SynchronizeForChangeReadingSource(reading.ReadingSource, newCholesterolTestResult.TotalCholesterol);
                        if (returnStatus) { newCholesterolTestResult.ResultStatus.StateNumber = (int)NewTestResultStateNumber.ResultEntryPartial; return newCholesterolTestResult; }
                        break;

                    case ReadingLabels.TriGlycerides:
                        returnStatus = SynchronizeForChangeReadingSource(reading.ReadingSource, newCholesterolTestResult.TriGlycerides);
                        if (returnStatus) { newCholesterolTestResult.ResultStatus.StateNumber = (int)NewTestResultStateNumber.ResultEntryPartial; return newCholesterolTestResult; }
                        break;

                    case ReadingLabels.HDL:
                        returnStatus = SynchronizeForChangeReadingSource(reading.ReadingSource, newCholesterolTestResult.HDL);
                        if (returnStatus) { newCholesterolTestResult.ResultStatus.StateNumber = (int)NewTestResultStateNumber.ResultEntryPartial; return newCholesterolTestResult; }
                        break;

                    case ReadingLabels.LDL:
                        returnStatus = SynchronizeForChangeReadingSource(reading.ReadingSource, newCholesterolTestResult.LDL);
                        if (returnStatus) { newCholesterolTestResult.ResultStatus.StateNumber = (int)NewTestResultStateNumber.ResultEntryPartial; return newCholesterolTestResult; }
                        break;
                }
            }

            if (newCholesterolTestResult.UnableScreenReason != null && newCholesterolTestResult.UnableScreenReason.Count > 0)
            {
                newCholesterolTestResult.ResultStatus.StateNumber = (int)NewTestResultStateNumber.ResultEntryPartial;
                return newCholesterolTestResult;
            }

            newCholesterolTestResult.ResultStatus.StateNumber = (int)NewTestResultStateNumber.ResultEntryPartial;
            return newCholesterolTestResult;
        }
    }
}
