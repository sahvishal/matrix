using System.Collections.Generic;
using Falcon.App.Core.Medical.Domain;
using Falcon.App.Core.Medical.Enum;

namespace Falcon.App.Core.Medical.Impl
{
    public class MenBloodPanelTestResultSynchronizationService : TestResultSynchronizationService
    {

        public MenBloodPanelTestResultSynchronizationService(ReadingSource readingSource)
        {
            NewReadingSource = readingSource;
        }

        public override TestResult SynchronizeTestResult(TestResult currentTestResult, TestResult newTestResult, bool isNewResultFlow)
        {
            var newMenBloodPanelTestResult = newTestResult as MenBloodPanelTestResult;

            if (currentTestResult == null)
            {
                SynchronizeResultReadingsForRecorderMetaData(newTestResult);

                if (newMenBloodPanelTestResult.PSASCR != null && newMenBloodPanelTestResult.PSASCR.Reading == null) newMenBloodPanelTestResult.PSASCR = null;

                if (newMenBloodPanelTestResult.LCRP != null && newMenBloodPanelTestResult.LCRP.Reading == null) newMenBloodPanelTestResult.LCRP = null;

                if (newMenBloodPanelTestResult.TESTSCRE != null && newMenBloodPanelTestResult.TESTSCRE.Reading == null) newMenBloodPanelTestResult.TESTSCRE = null;

                SyncronizeTestResult(currentTestResult, newTestResult);

                return newMenBloodPanelTestResult;
            }

            var currentMenBloodPanelTestResult = (MenBloodPanelTestResult)currentTestResult;
            newMenBloodPanelTestResult.Id = currentMenBloodPanelTestResult.Id;
            newMenBloodPanelTestResult.ResultStatus.Id = currentTestResult.ResultStatus.Id;

            newMenBloodPanelTestResult.PSASCR = SynchronizeResultReading(currentMenBloodPanelTestResult.PSASCR, newMenBloodPanelTestResult.PSASCR, newTestResult.DataRecorderMetaData);
            newMenBloodPanelTestResult.LCRP = SynchronizeResultReading(currentMenBloodPanelTestResult.LCRP, newMenBloodPanelTestResult.LCRP, newTestResult.DataRecorderMetaData);
            newMenBloodPanelTestResult.TESTSCRE = SynchronizeResultReading(currentMenBloodPanelTestResult.TESTSCRE, newMenBloodPanelTestResult.TESTSCRE, newTestResult.DataRecorderMetaData);


            if (NewReadingSource == ReadingSource.Automatic) // Syncing those which didn't come through Uploaded file
            {
                newMenBloodPanelTestResult = (MenBloodPanelTestResult)SyncronizeTestResultForAutomaticUploadwithManual(currentMenBloodPanelTestResult, newMenBloodPanelTestResult);
            }

            SyncronizeTestResult(currentTestResult, newTestResult);
            return newMenBloodPanelTestResult;
        }

        public override TestResult GetManualEntryUploadStatus(List<ResultReading<int>> compareToResultReadings, TestResult newTestResult, bool isNewResultFlow)
        {
            if (isNewResultFlow)
            {
                var newMenBloodPanelTestResult = NewResultStateManualEntry(compareToResultReadings, newTestResult);
                if (newMenBloodPanelTestResult.ResultStatus.Status == TestResultStatus.Complete && newMenBloodPanelTestResult.ResultStatus.StateNumber == (int)NewTestResultStateNumber.ResultEntryPartial)
                    newMenBloodPanelTestResult.ResultStatus.StateNumber = (int)NewTestResultStateNumber.ResultEntryCompleted;
                return newMenBloodPanelTestResult;
            }
            return OldResultStateManualEntry(compareToResultReadings, newTestResult);
        }

        public override TestResult IsTestIncomplete(List<ResultReading<int>> compareToResultReadings, TestResult newTestResult, bool isNewResultFlow)
        {
            var menBloodPanelTestResult = newTestResult as MenBloodPanelTestResult;
            if (menBloodPanelTestResult == null) return null;

            if (menBloodPanelTestResult.TestPerformedExternally != null)
            {
                if (menBloodPanelTestResult.TestPerformedExternally.ResultEntryTypeId == (long)ResultEntryType.Chat && menBloodPanelTestResult.TestPerformedExternally.EntryCompleted)
                {
                    newTestResult.ResultStatus.Status = TestResultStatus.Complete;
                }
                else
                {
                    newTestResult.ResultStatus.Status = TestResultStatus.Incomplete;
                }
                return menBloodPanelTestResult;
            }


            foreach (var reading in compareToResultReadings)
            {
                switch (reading.Label)
                {
                    case ReadingLabels.LCRP:
                        if (menBloodPanelTestResult.LCRP == null)
                        {
                            menBloodPanelTestResult.ResultStatus.Status = TestResultStatus.Incomplete;
                            return menBloodPanelTestResult;
                        }
                        break;
                    case ReadingLabels.PSASCR:
                        if (menBloodPanelTestResult.PSASCR == null)
                        {
                            menBloodPanelTestResult.ResultStatus.Status = TestResultStatus.Incomplete;
                            return menBloodPanelTestResult;
                        }
                        break;

                    case ReadingLabels.TESTSCRE:
                        if (menBloodPanelTestResult.TESTSCRE == null)
                        {
                            menBloodPanelTestResult.ResultStatus.Status = TestResultStatus.Incomplete;
                            return menBloodPanelTestResult;
                        }
                        break;
                }
            }

            menBloodPanelTestResult.ResultStatus.Status = TestResultStatus.Complete;

            return menBloodPanelTestResult;
        }

        private TestResult OldResultStateManualEntry(List<ResultReading<int>> compareToResultReadings, TestResult newTestResult)
        {
            if (newTestResult.ResultStatus.StateNumber == (int)TestResultStateNumber.PreAudit) return newTestResult;
            var newMenBloodPanelTestResult = newTestResult as MenBloodPanelTestResult;

            foreach (var reading in compareToResultReadings)
            {
                bool returnStatus;

                switch (reading.Label)
                {
                    case ReadingLabels.LCRP:
                        returnStatus = SynchronizeForChangeReadingSource(compareToResultReadings.Find(resultReading => resultReading.Label == ReadingLabels.LCRP).ReadingSource, newMenBloodPanelTestResult.LCRP);
                        if (returnStatus) { newMenBloodPanelTestResult.ResultStatus.StateNumber = (int)TestResultStateNumber.ManualEntry; return newMenBloodPanelTestResult; }
                        break;

                    case ReadingLabels.PSASCR:
                        returnStatus = SynchronizeForChangeReadingSource(compareToResultReadings.Find(resultReading => resultReading.Label == ReadingLabels.PSASCR).ReadingSource, newMenBloodPanelTestResult.PSASCR);
                        if (returnStatus) { newMenBloodPanelTestResult.ResultStatus.StateNumber = (int)TestResultStateNumber.ManualEntry; return newMenBloodPanelTestResult; }
                        break;

                    case ReadingLabels.TESTSCRE:
                        returnStatus = SynchronizeForChangeReadingSource(compareToResultReadings.Find(resultReading => resultReading.Label == ReadingLabels.TESTSCRE).ReadingSource, newMenBloodPanelTestResult.TESTSCRE);
                        if (returnStatus) { newMenBloodPanelTestResult.ResultStatus.StateNumber = (int)TestResultStateNumber.ManualEntry; return newMenBloodPanelTestResult; }
                        break;
                }
            }


            if (newMenBloodPanelTestResult.UnableScreenReason != null && newMenBloodPanelTestResult.UnableScreenReason.Count > 0)
            {
                newMenBloodPanelTestResult.ResultStatus.StateNumber = (int)TestResultStateNumber.ManualEntry;
                return newMenBloodPanelTestResult;
            }

            newMenBloodPanelTestResult.ResultStatus.StateNumber = (int)TestResultStateNumber.ResultsUploaded;
            return newMenBloodPanelTestResult;
        }

        private TestResult NewResultStateManualEntry(List<ResultReading<int>> compareToResultReadings, TestResult newTestResult)
        {
            if (newTestResult.ResultStatus.StateNumber == (int)NewTestResultStateNumber.PreAudit) return newTestResult;
            var newMenBloodPanelTestResult = newTestResult as MenBloodPanelTestResult;

            foreach (var reading in compareToResultReadings)
            {
                bool returnStatus;

                switch (reading.Label)
                {
                    case ReadingLabels.LCRP:
                        returnStatus = SynchronizeForChangeReadingSource(compareToResultReadings.Find(resultReading => resultReading.Label == ReadingLabels.LCRP).ReadingSource, newMenBloodPanelTestResult.LCRP);
                        if (returnStatus) { newMenBloodPanelTestResult.ResultStatus.StateNumber = (int)NewTestResultStateNumber.ResultEntryPartial; return newMenBloodPanelTestResult; }
                        break;

                    case ReadingLabels.PSASCR:
                        returnStatus = SynchronizeForChangeReadingSource(compareToResultReadings.Find(resultReading => resultReading.Label == ReadingLabels.PSASCR).ReadingSource, newMenBloodPanelTestResult.PSASCR);
                        if (returnStatus) { newMenBloodPanelTestResult.ResultStatus.StateNumber = (int)NewTestResultStateNumber.ResultEntryPartial; return newMenBloodPanelTestResult; }
                        break;

                    case ReadingLabels.TESTSCRE:
                        returnStatus = SynchronizeForChangeReadingSource(compareToResultReadings.Find(resultReading => resultReading.Label == ReadingLabels.TESTSCRE).ReadingSource, newMenBloodPanelTestResult.TESTSCRE);
                        if (returnStatus) { newMenBloodPanelTestResult.ResultStatus.StateNumber = (int)NewTestResultStateNumber.ResultEntryPartial; return newMenBloodPanelTestResult; }
                        break;
                }
            }


            if (newMenBloodPanelTestResult.UnableScreenReason != null && newMenBloodPanelTestResult.UnableScreenReason.Count > 0)
            {
                newMenBloodPanelTestResult.ResultStatus.StateNumber = (int)NewTestResultStateNumber.ResultEntryPartial;
                return newMenBloodPanelTestResult;
            }

            newMenBloodPanelTestResult.ResultStatus.StateNumber = (int)NewTestResultStateNumber.ResultEntryPartial;
            return newMenBloodPanelTestResult;
        }
    }
}