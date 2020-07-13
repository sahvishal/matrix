using System.Collections.Generic;
using Falcon.App.Core.Medical.Domain;
using Falcon.App.Core.Medical.Enum;

namespace Falcon.App.Core.Medical.Impl
{
    public class WomenBloodPanelTestResultSynchronizationService : TestResultSynchronizationService
    {

        public WomenBloodPanelTestResultSynchronizationService(ReadingSource readingSource)
        {
            NewReadingSource = readingSource;
        }

        public override TestResult SynchronizeTestResult(TestResult currentTestResult, TestResult newTestResult, bool isNewResultFlow)
        {
            var newWomenBloodPanelTestResult = newTestResult as WomenBloodPanelTestResult;

            if (currentTestResult == null)
            {
                SynchronizeResultReadingsForRecorderMetaData(newTestResult);

                if (newWomenBloodPanelTestResult.LCRP != null && newWomenBloodPanelTestResult.LCRP.Reading == null) newWomenBloodPanelTestResult.LCRP = null;

                if (newWomenBloodPanelTestResult.TSHSCR != null && newWomenBloodPanelTestResult.TSHSCR.Reading == null) newWomenBloodPanelTestResult.TSHSCR = null;

                if (newWomenBloodPanelTestResult.VitD != null && newWomenBloodPanelTestResult.VitD.Reading == null) newWomenBloodPanelTestResult.VitD = null;

                SyncronizeTestResult(currentTestResult, newTestResult);

                return newWomenBloodPanelTestResult;
            }

            var currentWomenBloodPanelTestResult = (WomenBloodPanelTestResult)currentTestResult;
            newWomenBloodPanelTestResult.Id = currentWomenBloodPanelTestResult.Id;
            newWomenBloodPanelTestResult.ResultStatus.Id = currentTestResult.ResultStatus.Id;

            newWomenBloodPanelTestResult.LCRP = SynchronizeResultReading(currentWomenBloodPanelTestResult.LCRP, newWomenBloodPanelTestResult.LCRP, newTestResult.DataRecorderMetaData);
            newWomenBloodPanelTestResult.TSHSCR = SynchronizeResultReading(currentWomenBloodPanelTestResult.TSHSCR, newWomenBloodPanelTestResult.TSHSCR, newTestResult.DataRecorderMetaData);
            newWomenBloodPanelTestResult.VitD = SynchronizeResultReading(currentWomenBloodPanelTestResult.VitD, newWomenBloodPanelTestResult.VitD, newTestResult.DataRecorderMetaData);


            if (NewReadingSource == ReadingSource.Automatic) // Syncing those which didn't come through Uploaded file
            {
                newWomenBloodPanelTestResult = (WomenBloodPanelTestResult)SyncronizeTestResultForAutomaticUploadwithManual(currentWomenBloodPanelTestResult, newWomenBloodPanelTestResult);
            }

            SyncronizeTestResult(currentTestResult, newTestResult);
            return newWomenBloodPanelTestResult;
        }

        public override TestResult GetManualEntryUploadStatus(List<ResultReading<int>> compareToResultReadings, TestResult newTestResult, bool isNewResultFlow)
        {
            if (isNewResultFlow)
            {
                var newWomenBloodPanelTestResult = NewResultStateManualEntry(compareToResultReadings, newTestResult);
                if (newWomenBloodPanelTestResult.ResultStatus.Status == TestResultStatus.Complete && newWomenBloodPanelTestResult.ResultStatus.StateNumber == (int)NewTestResultStateNumber.ResultEntryPartial)
                    newWomenBloodPanelTestResult.ResultStatus.StateNumber = (int)NewTestResultStateNumber.ResultEntryCompleted;
                return newWomenBloodPanelTestResult;
            }
            return OldResultStateManualEntry(compareToResultReadings, newTestResult);
        }

        public override TestResult IsTestIncomplete(List<ResultReading<int>> compareToResultReadings, TestResult newTestResult, bool isNewResultFlow)
        {
            var womenBloodPanelTestResult = newTestResult as WomenBloodPanelTestResult;
            if (womenBloodPanelTestResult == null) return null;

            if (womenBloodPanelTestResult.TestPerformedExternally != null)
            {
                if (womenBloodPanelTestResult.TestPerformedExternally.ResultEntryTypeId == (long)ResultEntryType.Chat && womenBloodPanelTestResult.TestPerformedExternally.EntryCompleted)
                {
                    newTestResult.ResultStatus.Status = TestResultStatus.Complete;
                }
                else
                {
                    newTestResult.ResultStatus.Status = TestResultStatus.Incomplete;
                }
                return womenBloodPanelTestResult;
            }


            foreach (var reading in compareToResultReadings)
            {
                switch (reading.Label)
                {
                    case ReadingLabels.LCRP:
                        if (womenBloodPanelTestResult.LCRP == null)
                        {
                            womenBloodPanelTestResult.ResultStatus.Status = TestResultStatus.Incomplete;
                            return womenBloodPanelTestResult;
                        }
                        break;
                    case ReadingLabels.TSHSCR:
                        if (womenBloodPanelTestResult.TSHSCR == null)
                        {
                            womenBloodPanelTestResult.ResultStatus.Status = TestResultStatus.Incomplete;
                            return womenBloodPanelTestResult;
                        }
                        break;

                    case ReadingLabels.VitD:
                        if (womenBloodPanelTestResult.VitD == null)
                        {
                            womenBloodPanelTestResult.ResultStatus.Status = TestResultStatus.Incomplete;
                            return womenBloodPanelTestResult;
                        }
                        break;
                }
            }

            womenBloodPanelTestResult.ResultStatus.Status = TestResultStatus.Complete;

            return womenBloodPanelTestResult;
        }

        private TestResult OldResultStateManualEntry(List<ResultReading<int>> compareToResultReadings, TestResult newTestResult)
        {
            if (newTestResult.ResultStatus.StateNumber == (int)TestResultStateNumber.PreAudit) return newTestResult;
            var newWomenBloodPanelTestResult = newTestResult as WomenBloodPanelTestResult;

            foreach (var reading in compareToResultReadings)
            {
                bool returnStatus;

                switch (reading.Label)
                {
                    case ReadingLabels.LCRP:
                        returnStatus = SynchronizeForChangeReadingSource(compareToResultReadings.Find(resultReading => resultReading.Label == ReadingLabels.LCRP).ReadingSource, newWomenBloodPanelTestResult.LCRP);
                        if (returnStatus) { newWomenBloodPanelTestResult.ResultStatus.StateNumber = (int)TestResultStateNumber.ManualEntry; return newWomenBloodPanelTestResult; }
                        break;

                    case ReadingLabels.TSHSCR:
                        returnStatus = SynchronizeForChangeReadingSource(compareToResultReadings.Find(resultReading => resultReading.Label == ReadingLabels.TSHSCR).ReadingSource, newWomenBloodPanelTestResult.TSHSCR);
                        if (returnStatus) { newWomenBloodPanelTestResult.ResultStatus.StateNumber = (int)TestResultStateNumber.ManualEntry; return newWomenBloodPanelTestResult; }
                        break;

                    case ReadingLabels.VitD:
                        returnStatus = SynchronizeForChangeReadingSource(compareToResultReadings.Find(resultReading => resultReading.Label == ReadingLabels.VitD).ReadingSource, newWomenBloodPanelTestResult.VitD);
                        if (returnStatus) { newWomenBloodPanelTestResult.ResultStatus.StateNumber = (int)TestResultStateNumber.ManualEntry; return newWomenBloodPanelTestResult; }
                        break;
                }
            }


            if (newWomenBloodPanelTestResult.UnableScreenReason != null && newWomenBloodPanelTestResult.UnableScreenReason.Count > 0)
            {
                newWomenBloodPanelTestResult.ResultStatus.StateNumber = (int)TestResultStateNumber.ManualEntry;
                return newWomenBloodPanelTestResult;
            }

            newWomenBloodPanelTestResult.ResultStatus.StateNumber = (int)TestResultStateNumber.ResultsUploaded;
            return newWomenBloodPanelTestResult;
        }

        private TestResult NewResultStateManualEntry(List<ResultReading<int>> compareToResultReadings, TestResult newTestResult)
        {
            if (newTestResult.ResultStatus.StateNumber == (int)NewTestResultStateNumber.PreAudit) return newTestResult;
            var newWomenBloodPanelTestResult = newTestResult as WomenBloodPanelTestResult;

            foreach (var reading in compareToResultReadings)
            {
                bool returnStatus;

                switch (reading.Label)
                {
                    case ReadingLabels.LCRP:
                        returnStatus = SynchronizeForChangeReadingSource(compareToResultReadings.Find(resultReading => resultReading.Label == ReadingLabels.LCRP).ReadingSource, newWomenBloodPanelTestResult.LCRP);
                        if (returnStatus) { newWomenBloodPanelTestResult.ResultStatus.StateNumber = (int)NewTestResultStateNumber.ResultEntryPartial; return newWomenBloodPanelTestResult; }
                        break;

                    case ReadingLabels.TSHSCR:
                        returnStatus = SynchronizeForChangeReadingSource(compareToResultReadings.Find(resultReading => resultReading.Label == ReadingLabels.TSHSCR).ReadingSource, newWomenBloodPanelTestResult.TSHSCR);
                        if (returnStatus) { newWomenBloodPanelTestResult.ResultStatus.StateNumber = (int)NewTestResultStateNumber.ResultEntryPartial; return newWomenBloodPanelTestResult; }
                        break;

                    case ReadingLabels.VitD:
                        returnStatus = SynchronizeForChangeReadingSource(compareToResultReadings.Find(resultReading => resultReading.Label == ReadingLabels.VitD).ReadingSource, newWomenBloodPanelTestResult.VitD);
                        if (returnStatus) { newWomenBloodPanelTestResult.ResultStatus.StateNumber = (int)NewTestResultStateNumber.ResultEntryPartial; return newWomenBloodPanelTestResult; }
                        break;
                }
            }


            if (newWomenBloodPanelTestResult.UnableScreenReason != null && newWomenBloodPanelTestResult.UnableScreenReason.Count > 0)
            {
                newWomenBloodPanelTestResult.ResultStatus.StateNumber = (int)NewTestResultStateNumber.ResultEntryPartial;
                return newWomenBloodPanelTestResult;
            }

            newWomenBloodPanelTestResult.ResultStatus.StateNumber = (int)NewTestResultStateNumber.ResultEntryPartial;
            return newWomenBloodPanelTestResult;
        }
    }
}