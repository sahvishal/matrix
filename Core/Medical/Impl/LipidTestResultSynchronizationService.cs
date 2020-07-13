using System.Collections.Generic;
using Falcon.App.Core.Medical.Domain;
using Falcon.App.Core.Medical.Enum;

namespace Falcon.App.Core.Medical.Impl
{
    public class LipidTestResultSynchronizationService : TestResultSynchronizationService
    {
        public LipidTestResultSynchronizationService(ReadingSource newTestReadingSource)
        {
            NewReadingSource = newTestReadingSource;
        }

        public override TestResult SynchronizeTestResult(TestResult currentTestResult, TestResult newTestResult, bool isNewResultFlow)
        {
            var newLipidTestResult = (LipidTestResult)newTestResult;

            if (currentTestResult == null)
            {
                SynchronizeResultReadingsForRecorderMetaData(newTestResult);

                if (newLipidTestResult.Glucose != null && newLipidTestResult.Glucose.Reading == null && newLipidTestResult.Glucose.Finding == null) newLipidTestResult.Glucose = null;
                if (newLipidTestResult.TotalCholestrol != null && newLipidTestResult.TotalCholestrol.Reading == null && newLipidTestResult.TotalCholestrol.Finding == null) newLipidTestResult.TotalCholestrol = null;
                if (newLipidTestResult.HDL != null && newLipidTestResult.HDL.Reading == null && newLipidTestResult.HDL.Finding == null) newLipidTestResult.HDL = null;
                if (newLipidTestResult.LDL != null && newLipidTestResult.LDL.Reading == null && newLipidTestResult.LDL.Finding == null) newLipidTestResult.LDL = null;
                if (newLipidTestResult.TriGlycerides != null && newLipidTestResult.TriGlycerides.Reading == null && newLipidTestResult.TriGlycerides.Finding == null) newLipidTestResult.TriGlycerides = null;
                if (newLipidTestResult.TCHDLRatio != null && newLipidTestResult.TCHDLRatio.Reading == null && newLipidTestResult.TCHDLRatio.Finding == null) newLipidTestResult.TCHDLRatio = null;
                if (newLipidTestResult.ALT != null && newLipidTestResult.ALT.Reading == null && newLipidTestResult.ALT.Finding == null) newLipidTestResult.ALT = null;
                if (newLipidTestResult.AST != null && newLipidTestResult.AST.Reading == null && newLipidTestResult.AST.Finding == null) newLipidTestResult.AST = null;

                SyncronizeTestResult(currentTestResult, newTestResult);

                return newLipidTestResult;
            }

            var currentLipidTestResult = (LipidTestResult)currentTestResult;
            newLipidTestResult.Id = currentLipidTestResult.Id;
            newTestResult.ResultStatus.Id = currentTestResult.ResultStatus.Id;

            newLipidTestResult.Glucose = SynchronizeResultReading(currentLipidTestResult.Glucose, newLipidTestResult.Glucose, newTestResult.DataRecorderMetaData);
            newLipidTestResult.TotalCholestrol = SynchronizeResultReading(currentLipidTestResult.TotalCholestrol, newLipidTestResult.TotalCholestrol, newTestResult.DataRecorderMetaData);
            newLipidTestResult.HDL = SynchronizeResultReading(currentLipidTestResult.HDL, newLipidTestResult.HDL, newTestResult.DataRecorderMetaData);
            newLipidTestResult.LDL = SynchronizeResultReading(currentLipidTestResult.LDL, newLipidTestResult.LDL, newTestResult.DataRecorderMetaData);
            newLipidTestResult.TriGlycerides = SynchronizeResultReading(currentLipidTestResult.TriGlycerides, newLipidTestResult.TriGlycerides, newTestResult.DataRecorderMetaData);
            newLipidTestResult.TCHDLRatio = SynchronizeResultReading(currentLipidTestResult.TCHDLRatio, newLipidTestResult.TCHDLRatio, newTestResult.DataRecorderMetaData);
            newLipidTestResult.ALT = SynchronizeResultReading(currentLipidTestResult.ALT, newLipidTestResult.ALT, newTestResult.DataRecorderMetaData);
            newLipidTestResult.AST = SynchronizeResultReading(currentLipidTestResult.AST, newLipidTestResult.AST, newTestResult.DataRecorderMetaData);

            if (NewReadingSource == ReadingSource.Automatic)
            {
                newLipidTestResult = (LipidTestResult)SyncronizeTestResultForAutomaticUploadwithManual(currentLipidTestResult, newLipidTestResult);
            }

            SyncronizeTestResult(currentTestResult, newTestResult);
            return newLipidTestResult;
        }

        public override TestResult IsTestIncomplete(List<ResultReading<int>> compareToResultReadings, TestResult newTestResult, bool isNewResultFlow)
        {
            var lipidTestResult = newTestResult as LipidTestResult;
            if (lipidTestResult == null) return lipidTestResult;

            if (lipidTestResult.TestPerformedExternally != null)
            {
                if (lipidTestResult.TestPerformedExternally.ResultEntryTypeId == (long)ResultEntryType.Chat && lipidTestResult.TestPerformedExternally.EntryCompleted)
                {
                    newTestResult.ResultStatus.Status = TestResultStatus.Complete;
                }
                else
                {
                    newTestResult.ResultStatus.Status = TestResultStatus.Incomplete;
                }
                return lipidTestResult;
            }


            foreach (var reading in compareToResultReadings)
            {
                switch (reading.Label)
                {
                    case ReadingLabels.Glucose:
                        if (IsIncompleteReading(lipidTestResult.Glucose))
                        {
                            newTestResult.ResultStatus.Status = TestResultStatus.Incomplete;
                            return newTestResult;
                        }
                        break;

                    case ReadingLabels.TCHDLRatio:
                        if (IsIncompleteReading(lipidTestResult.TCHDLRatio))
                        {
                            newTestResult.ResultStatus.Status = TestResultStatus.Incomplete;
                            return newTestResult;
                        }
                        break;

                    case ReadingLabels.TotalCholestrol:
                        if (IsIncompleteReading(lipidTestResult.TotalCholestrol))
                        {
                            newTestResult.ResultStatus.Status = TestResultStatus.Incomplete;
                            return newTestResult;
                        }
                        break;

                    case ReadingLabels.TriGlycerides:
                        if (IsIncompleteReading(lipidTestResult.TriGlycerides))
                        {
                            newTestResult.ResultStatus.Status = TestResultStatus.Incomplete;
                            return newTestResult;
                        }
                        break;

                    case ReadingLabels.HDL:
                        if (IsIncompleteReading(lipidTestResult.HDL))
                        {
                            newTestResult.ResultStatus.Status = TestResultStatus.Incomplete;
                            return newTestResult;
                        }
                        break;

                    case ReadingLabels.LDL:
                        if (IsIncompleteReading(lipidTestResult.LDL))
                        {
                            newTestResult.ResultStatus.Status = TestResultStatus.Incomplete;
                            return newTestResult;
                        }
                        break;

                    case ReadingLabels.ALT:
                        if (IsIncompleteReading(lipidTestResult.ALT))
                        {
                            newTestResult.ResultStatus.Status = TestResultStatus.Incomplete;
                            return newTestResult;
                        }
                        break;

                    case ReadingLabels.AST:
                        if (IsIncompleteReading(lipidTestResult.AST))
                        {
                            newTestResult.ResultStatus.Status = TestResultStatus.Incomplete;
                            return newTestResult;
                        }
                        break;
                }
            }

            newTestResult.ResultStatus.Status = TestResultStatus.Complete;
            return lipidTestResult;
        }

        public override TestResult GetManualEntryUploadStatus(List<ResultReading<int>> compareToResultReadings, TestResult newTestResult, bool isNewResultFlow)
        {
            if (isNewResultFlow)
            {
                var newLipidTestResult = NewResultStateManualEntry(compareToResultReadings, newTestResult);
                if (newLipidTestResult.ResultStatus.Status == TestResultStatus.Complete && newLipidTestResult.ResultStatus.StateNumber == (int)NewTestResultStateNumber.ResultEntryPartial)
                    newLipidTestResult.ResultStatus.StateNumber = (int)NewTestResultStateNumber.ResultEntryCompleted;
                return newLipidTestResult;
            }
            return OldResultStateManualEntry(compareToResultReadings, newTestResult);
        }

        private TestResult OldResultStateManualEntry(IEnumerable<ResultReading<int>> compareToResultReadings, TestResult newTestResult)
        {
            if (newTestResult.ResultStatus.StateNumber == (int)TestResultStateNumber.PreAudit) return newTestResult;
            var newLipidTestResult = (LipidTestResult)newTestResult;

            foreach (var reading in compareToResultReadings)
            {
                bool returnStatus;
                switch (reading.Label)
                {
                    case ReadingLabels.Glucose:
                        returnStatus = SynchronizeForChangeReadingSource(reading.ReadingSource, newLipidTestResult.Glucose);
                        if (returnStatus) { newLipidTestResult.ResultStatus.StateNumber = (int)TestResultStateNumber.ManualEntry; return newLipidTestResult; }
                        break;

                    case ReadingLabels.TCHDLRatio:
                        returnStatus = SynchronizeForChangeReadingSource(reading.ReadingSource, newLipidTestResult.TCHDLRatio);
                        if (returnStatus) { newLipidTestResult.ResultStatus.StateNumber = (int)TestResultStateNumber.ManualEntry; return newLipidTestResult; }
                        break;

                    case ReadingLabels.TotalCholestrol:
                        returnStatus = SynchronizeForChangeReadingSource(reading.ReadingSource, newLipidTestResult.TotalCholestrol);
                        if (returnStatus) { newLipidTestResult.ResultStatus.StateNumber = (int)TestResultStateNumber.ManualEntry; return newLipidTestResult; }
                        break;

                    case ReadingLabels.TriGlycerides:
                        returnStatus = SynchronizeForChangeReadingSource(reading.ReadingSource, newLipidTestResult.TriGlycerides);
                        if (returnStatus) { newLipidTestResult.ResultStatus.StateNumber = (int)TestResultStateNumber.ManualEntry; return newLipidTestResult; }
                        break;

                    case ReadingLabels.HDL:
                        returnStatus = SynchronizeForChangeReadingSource(reading.ReadingSource, newLipidTestResult.HDL);
                        if (returnStatus) { newLipidTestResult.ResultStatus.StateNumber = (int)TestResultStateNumber.ManualEntry; return newLipidTestResult; }
                        break;

                    case ReadingLabels.LDL:
                        returnStatus = SynchronizeForChangeReadingSource(reading.ReadingSource, newLipidTestResult.LDL);
                        if (returnStatus) { newLipidTestResult.ResultStatus.StateNumber = (int)TestResultStateNumber.ManualEntry; return newLipidTestResult; }
                        break;

                    case ReadingLabels.ALT:
                        returnStatus = SynchronizeForChangeReadingSource(reading.ReadingSource, newLipidTestResult.ALT);
                        if (returnStatus) { newLipidTestResult.ResultStatus.StateNumber = (int)TestResultStateNumber.ManualEntry; return newLipidTestResult; }
                        break;

                    case ReadingLabels.AST:
                        returnStatus = SynchronizeForChangeReadingSource(reading.ReadingSource, newLipidTestResult.AST);
                        if (returnStatus) { newLipidTestResult.ResultStatus.StateNumber = (int)TestResultStateNumber.ManualEntry; return newLipidTestResult; }
                        break;
                }
            }

            if (newLipidTestResult.UnableScreenReason != null && newLipidTestResult.UnableScreenReason.Count > 0)
            {
                newLipidTestResult.ResultStatus.StateNumber = (int)TestResultStateNumber.ManualEntry;
                return newLipidTestResult;
            }

            newLipidTestResult.ResultStatus.StateNumber = (int)TestResultStateNumber.ResultsUploaded;
            return newLipidTestResult;
        }

        private TestResult NewResultStateManualEntry(IEnumerable<ResultReading<int>> compareToResultReadings, TestResult newTestResult)
        {
            if (newTestResult.ResultStatus.StateNumber == (int)NewTestResultStateNumber.PreAudit) return newTestResult;
            var newLipidTestResult = (LipidTestResult)newTestResult;

            foreach (var reading in compareToResultReadings)
            {
                bool returnStatus;
                switch (reading.Label)
                {
                    case ReadingLabels.Glucose:
                        returnStatus = SynchronizeForChangeReadingSource(reading.ReadingSource, newLipidTestResult.Glucose);
                        if (returnStatus) { newLipidTestResult.ResultStatus.StateNumber = (int)NewTestResultStateNumber.ResultEntryPartial; return newLipidTestResult; }
                        break;

                    case ReadingLabels.TCHDLRatio:
                        returnStatus = SynchronizeForChangeReadingSource(reading.ReadingSource, newLipidTestResult.TCHDLRatio);
                        if (returnStatus) { newLipidTestResult.ResultStatus.StateNumber = (int)NewTestResultStateNumber.ResultEntryPartial; return newLipidTestResult; }
                        break;

                    case ReadingLabels.TotalCholestrol:
                        returnStatus = SynchronizeForChangeReadingSource(reading.ReadingSource, newLipidTestResult.TotalCholestrol);
                        if (returnStatus) { newLipidTestResult.ResultStatus.StateNumber = (int)NewTestResultStateNumber.ResultEntryPartial; return newLipidTestResult; }
                        break;

                    case ReadingLabels.TriGlycerides:
                        returnStatus = SynchronizeForChangeReadingSource(reading.ReadingSource, newLipidTestResult.TriGlycerides);
                        if (returnStatus) { newLipidTestResult.ResultStatus.StateNumber = (int)NewTestResultStateNumber.ResultEntryPartial; return newLipidTestResult; }
                        break;

                    case ReadingLabels.HDL:
                        returnStatus = SynchronizeForChangeReadingSource(reading.ReadingSource, newLipidTestResult.HDL);
                        if (returnStatus) { newLipidTestResult.ResultStatus.StateNumber = (int)NewTestResultStateNumber.ResultEntryPartial; return newLipidTestResult; }
                        break;

                    case ReadingLabels.LDL:
                        returnStatus = SynchronizeForChangeReadingSource(reading.ReadingSource, newLipidTestResult.LDL);
                        if (returnStatus) { newLipidTestResult.ResultStatus.StateNumber = (int)NewTestResultStateNumber.ResultEntryPartial; return newLipidTestResult; }
                        break;

                    case ReadingLabels.ALT:
                        returnStatus = SynchronizeForChangeReadingSource(reading.ReadingSource, newLipidTestResult.ALT);
                        if (returnStatus) { newLipidTestResult.ResultStatus.StateNumber = (int)NewTestResultStateNumber.ResultEntryPartial; return newLipidTestResult; }
                        break;

                    case ReadingLabels.AST:
                        returnStatus = SynchronizeForChangeReadingSource(reading.ReadingSource, newLipidTestResult.AST);
                        if (returnStatus) { newLipidTestResult.ResultStatus.StateNumber = (int)NewTestResultStateNumber.ResultEntryPartial; return newLipidTestResult; }
                        break;
                }
            }

            if (newLipidTestResult.UnableScreenReason != null && newLipidTestResult.UnableScreenReason.Count > 0)
            {
                newLipidTestResult.ResultStatus.StateNumber = (int)NewTestResultStateNumber.ResultEntryPartial;
                return newLipidTestResult;
            }

            newLipidTestResult.ResultStatus.StateNumber = (int)NewTestResultStateNumber.ResultEntryPartial;
            return newLipidTestResult;
        }
    }
}
