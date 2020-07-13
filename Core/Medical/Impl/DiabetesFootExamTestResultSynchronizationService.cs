using System.Collections.Generic;
using Falcon.App.Core.Medical.Domain;
using Falcon.App.Core.Medical.Enum;

namespace Falcon.App.Core.Medical.Impl
{
    public class DiabetesFootExamTestResultSynchronizationService : TestResultSynchronizationService
    {
        public DiabetesFootExamTestResultSynchronizationService(ReadingSource readingSource)
        {
            NewReadingSource = readingSource;
        }

        public override TestResult SynchronizeTestResult(TestResult currentTestResult, TestResult newTestResult, bool isNewResultFlow)
        {
            var diabetesFootExamTestResult = newTestResult as DiabetesFootExamTestResult;

            if (currentTestResult == null)
            {
                SynchronizeResultReadingsForRecorderMetaData(newTestResult);


                if (diabetesFootExamTestResult.RightFootYes != null && diabetesFootExamTestResult.RightFootYes.Reading == null) diabetesFootExamTestResult.RightFootYes = null;
                if (diabetesFootExamTestResult.RightFootNo != null && diabetesFootExamTestResult.RightFootNo.Reading == null) diabetesFootExamTestResult.RightFootNo = null;

                if (diabetesFootExamTestResult.LeftFootYes != null && diabetesFootExamTestResult.LeftFootYes.Reading == null) diabetesFootExamTestResult.LeftFootYes = null;
                if (diabetesFootExamTestResult.LeftFootNo != null && diabetesFootExamTestResult.LeftFootNo.Reading == null) diabetesFootExamTestResult.LeftFootNo = null;

                SyncronizeTestResult(currentTestResult, newTestResult);

                return diabetesFootExamTestResult;
            }

            var currentDiabetesFootExamTTestResult = (DiabetesFootExamTestResult)currentTestResult;

            diabetesFootExamTestResult.Id = currentDiabetesFootExamTTestResult.Id;
            newTestResult.ResultStatus.Id = currentTestResult.ResultStatus.Id;

            diabetesFootExamTestResult.RightFootYes = SynchronizeResultReading(currentDiabetesFootExamTTestResult.RightFootYes, diabetesFootExamTestResult.RightFootYes, newTestResult.DataRecorderMetaData);
            diabetesFootExamTestResult.RightFootNo = SynchronizeResultReading(currentDiabetesFootExamTTestResult.RightFootNo, diabetesFootExamTestResult.RightFootNo, newTestResult.DataRecorderMetaData);

            diabetesFootExamTestResult.LeftFootYes = SynchronizeResultReading(currentDiabetesFootExamTTestResult.LeftFootYes, diabetesFootExamTestResult.LeftFootYes, newTestResult.DataRecorderMetaData);
            diabetesFootExamTestResult.LeftFootNo = SynchronizeResultReading(currentDiabetesFootExamTTestResult.LeftFootNo, diabetesFootExamTestResult.LeftFootNo, newTestResult.DataRecorderMetaData);


            if (NewReadingSource == ReadingSource.Automatic) // Syncing those which didn't come through Uploaded file
            {
                diabetesFootExamTestResult = (DiabetesFootExamTestResult)SyncronizeTestResultForAutomaticUploadwithManual(currentDiabetesFootExamTTestResult, diabetesFootExamTestResult);
            }

            SyncronizeTestResult(currentTestResult, newTestResult);
            return diabetesFootExamTestResult;
        }

        public override TestResult GetManualEntryUploadStatus(List<ResultReading<int>> compareToResultReadings, TestResult newTestResult, bool isNewResultFlow)
        {
            if (isNewResultFlow)
            {
                var diabetesFootExamTestResult = NewResultStateManualEntry(compareToResultReadings, newTestResult);
                if (diabetesFootExamTestResult.ResultStatus.Status == TestResultStatus.Complete && diabetesFootExamTestResult.ResultStatus.StateNumber == (int)NewTestResultStateNumber.ResultEntryPartial)
                    diabetesFootExamTestResult.ResultStatus.StateNumber = (int)NewTestResultStateNumber.ResultEntryCompleted;
                return diabetesFootExamTestResult;
            }
            return OldResultStateManualEntry(compareToResultReadings, newTestResult);
        }

        public override TestResult IsTestIncomplete(List<ResultReading<int>> compareToResultReadings, TestResult newTestResult, bool isNewResultFlow)
        {
            var diabetesFootExamTestResult = newTestResult as DiabetesFootExamTestResult;
            if (diabetesFootExamTestResult == null) return null;

            if (diabetesFootExamTestResult.TestPerformedExternally != null)
            {
                if (diabetesFootExamTestResult.TestPerformedExternally.ResultEntryTypeId == (long)ResultEntryType.Chat && diabetesFootExamTestResult.TestPerformedExternally.EntryCompleted)
                {
                    newTestResult.ResultStatus.Status = TestResultStatus.Complete;
                }
                else
                {
                    newTestResult.ResultStatus.Status = TestResultStatus.Incomplete;
                }
                return diabetesFootExamTestResult;
            }

            if ((diabetesFootExamTestResult.RightFootYes == null && diabetesFootExamTestResult.RightFootNo == null) || (diabetesFootExamTestResult.LeftFootYes == null && diabetesFootExamTestResult.LeftFootNo == null))
            {
                diabetesFootExamTestResult.ResultStatus.Status = TestResultStatus.Incomplete;
            }

            diabetesFootExamTestResult.ResultStatus.Status = TestResultStatus.Complete;

            return diabetesFootExamTestResult;
        }

        private TestResult OldResultStateManualEntry(IEnumerable<ResultReading<int>> compareToResultReadings, TestResult newTestResult)
        {
            if (newTestResult.ResultStatus.StateNumber == (int)TestResultStateNumber.PreAudit) return newTestResult;
            var diabetesFootExamTestResult = (DiabetesFootExamTestResult)newTestResult;

            foreach (var reading in compareToResultReadings)
            {
                bool returnStatus;
                switch (reading.Label)
                {

                    case ReadingLabels.RightFootYes:
                        returnStatus = SynchronizeForChangeReadingSource(reading.ReadingSource, diabetesFootExamTestResult.RightFootYes);
                        if (returnStatus)
                        {
                            diabetesFootExamTestResult.ResultStatus.StateNumber = (int)TestResultStateNumber.ManualEntry;
                            return diabetesFootExamTestResult;
                        }
                        break;

                    case ReadingLabels.RightFootNo:
                        returnStatus = SynchronizeForChangeReadingSource(reading.ReadingSource, diabetesFootExamTestResult.RightFootNo);
                        if (returnStatus)
                        {
                            diabetesFootExamTestResult.ResultStatus.StateNumber = (int)TestResultStateNumber.ManualEntry;
                            return diabetesFootExamTestResult;
                        }
                        break;

                    case ReadingLabels.LeftFootYes:
                        returnStatus = SynchronizeForChangeReadingSource(reading.ReadingSource, diabetesFootExamTestResult.LeftFootYes);
                        if (returnStatus)
                        {
                            diabetesFootExamTestResult.ResultStatus.StateNumber = (int)TestResultStateNumber.ManualEntry;
                            return diabetesFootExamTestResult;
                        }
                        break;

                    case ReadingLabels.LeftFootNo:
                        returnStatus = SynchronizeForChangeReadingSource(reading.ReadingSource, diabetesFootExamTestResult.LeftFootNo);
                        if (returnStatus)
                        {
                            diabetesFootExamTestResult.ResultStatus.StateNumber = (int)TestResultStateNumber.ManualEntry;
                            return diabetesFootExamTestResult;
                        }
                        break;
                }
            }

            if (diabetesFootExamTestResult.UnableScreenReason != null && diabetesFootExamTestResult.UnableScreenReason.Count > 0)
            {
                diabetesFootExamTestResult.ResultStatus.StateNumber = (int)TestResultStateNumber.ManualEntry;
                return diabetesFootExamTestResult;
            }

            diabetesFootExamTestResult.ResultStatus.StateNumber = (int)TestResultStateNumber.ResultsUploaded;
            return diabetesFootExamTestResult;
        }

        private TestResult NewResultStateManualEntry(IEnumerable<ResultReading<int>> compareToResultReadings, TestResult newTestResult)
        {
            if (newTestResult.ResultStatus.StateNumber == (int)NewTestResultStateNumber.PreAudit) return newTestResult;
            var diabetesFootExamTestResult = (DiabetesFootExamTestResult)newTestResult;

            foreach (var reading in compareToResultReadings)
            {
                bool returnStatus;
                switch (reading.Label)
                {

                    case ReadingLabels.RightFootYes:
                        returnStatus = SynchronizeForChangeReadingSource(reading.ReadingSource, diabetesFootExamTestResult.RightFootYes);
                        if (returnStatus)
                        {
                            diabetesFootExamTestResult.ResultStatus.StateNumber = (int)NewTestResultStateNumber.ResultEntryPartial;
                            return diabetesFootExamTestResult;
                        }
                        break;

                    case ReadingLabels.RightFootNo:
                        returnStatus = SynchronizeForChangeReadingSource(reading.ReadingSource, diabetesFootExamTestResult.RightFootNo);
                        if (returnStatus)
                        {
                            diabetesFootExamTestResult.ResultStatus.StateNumber = (int)NewTestResultStateNumber.ResultEntryPartial;
                            return diabetesFootExamTestResult;
                        }
                        break;

                    case ReadingLabels.LeftFootYes:
                        returnStatus = SynchronizeForChangeReadingSource(reading.ReadingSource, diabetesFootExamTestResult.LeftFootYes);
                        if (returnStatus)
                        {
                            diabetesFootExamTestResult.ResultStatus.StateNumber = (int)NewTestResultStateNumber.ResultEntryPartial;
                            return diabetesFootExamTestResult;
                        }
                        break;

                    case ReadingLabels.LeftFootNo:
                        returnStatus = SynchronizeForChangeReadingSource(reading.ReadingSource, diabetesFootExamTestResult.LeftFootNo);
                        if (returnStatus)
                        {
                            diabetesFootExamTestResult.ResultStatus.StateNumber = (int)NewTestResultStateNumber.ResultEntryPartial;
                            return diabetesFootExamTestResult;
                        }
                        break;
                }
            }

            if (diabetesFootExamTestResult.UnableScreenReason != null && diabetesFootExamTestResult.UnableScreenReason.Count > 0)
            {
                diabetesFootExamTestResult.ResultStatus.StateNumber = (int)NewTestResultStateNumber.ResultEntryPartial;
                return diabetesFootExamTestResult;
            }

            diabetesFootExamTestResult.ResultStatus.StateNumber = (int)NewTestResultStateNumber.ResultEntryPartial;
            return diabetesFootExamTestResult;
        }
    }
}