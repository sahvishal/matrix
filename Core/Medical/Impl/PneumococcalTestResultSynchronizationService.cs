using System.Collections.Generic;
using Falcon.App.Core.Medical.Domain;
using Falcon.App.Core.Medical.Enum;

namespace Falcon.App.Core.Medical.Impl
{
    public class PneumococcalTestResultSynchronizationService : TestResultSynchronizationService
    {
        public PneumococcalTestResultSynchronizationService(ReadingSource newTestReadingSource)
        {
            NewReadingSource = newTestReadingSource;
        }

        public override TestResult SynchronizeTestResult(TestResult currentTestResult, TestResult newTestResult, bool isNewResultFlow)
        {
            var newPneumococcalTestResult = (PneumococcalTestResult)newTestResult;

            if (currentTestResult == null)
            {
                SynchronizeResultReadingsForRecorderMetaData(newTestResult);

                if (newPneumococcalTestResult.Manufacturer != null && newPneumococcalTestResult.Manufacturer.Reading == null) newPneumococcalTestResult.Manufacturer = null;
                if (newPneumococcalTestResult.LotNumber != null && newPneumococcalTestResult.LotNumber.Reading == null) newPneumococcalTestResult.LotNumber = null;

                SyncronizeTestResult(currentTestResult, newTestResult);

                return newPneumococcalTestResult;
            }

            var currentPneumococcalTestResult = (PneumococcalTestResult)currentTestResult;
            newPneumococcalTestResult.Id = currentPneumococcalTestResult.Id;
            newTestResult.ResultStatus.Id = currentTestResult.ResultStatus.Id;

            newPneumococcalTestResult.Manufacturer = SynchronizeResultReading(currentPneumococcalTestResult.Manufacturer, newPneumococcalTestResult.Manufacturer, newTestResult.DataRecorderMetaData);
            newPneumococcalTestResult.LotNumber = SynchronizeResultReading(currentPneumococcalTestResult.LotNumber, newPneumococcalTestResult.LotNumber, newTestResult.DataRecorderMetaData);

            if (NewReadingSource == ReadingSource.Automatic)
            {
                newPneumococcalTestResult = (PneumococcalTestResult)SyncronizeTestResultForAutomaticUploadwithManual(currentPneumococcalTestResult, newPneumococcalTestResult);
            }

            SyncronizeTestResult(currentTestResult, newTestResult);

            return newPneumococcalTestResult;
        }

        public override TestResult GetManualEntryUploadStatus(List<ResultReading<int>> compareToResultReadings, TestResult newTestResult, bool isNewResultFlow)
        {
            if (isNewResultFlow)
            {
                var newPneumococcalTestResult = NewResultStateManualEntry(compareToResultReadings, newTestResult);
                if (newPneumococcalTestResult.ResultStatus.Status == TestResultStatus.Complete && newPneumococcalTestResult.ResultStatus.StateNumber == (int)NewTestResultStateNumber.ResultEntryPartial)
                    newPneumococcalTestResult.ResultStatus.StateNumber = (int)NewTestResultStateNumber.ResultEntryCompleted;
                return newPneumococcalTestResult;
            }
            return OldResultStateManualEntry(compareToResultReadings, newTestResult);
        }

        public override TestResult IsTestIncomplete(List<ResultReading<int>> compareToResultReadings, TestResult newTestResult, bool isNewResultFlow)
        {
            var pneumococcalTestResult = newTestResult as PneumococcalTestResult;
            if (pneumococcalTestResult == null) return null;

            if (pneumococcalTestResult.TestPerformedExternally != null)
            {
                if (pneumococcalTestResult.TestPerformedExternally.ResultEntryTypeId == (long)ResultEntryType.Chat && pneumococcalTestResult.TestPerformedExternally.EntryCompleted)
                {
                    newTestResult.ResultStatus.Status = TestResultStatus.Complete;
                }
                else
                {
                    newTestResult.ResultStatus.Status = TestResultStatus.Incomplete;
                }
                return pneumococcalTestResult;
            }

            if (pneumococcalTestResult.Manufacturer == null || pneumococcalTestResult.Manufacturer.Reading == null)
            {
                pneumococcalTestResult.ResultStatus.Status = TestResultStatus.Incomplete;
                return pneumococcalTestResult;
            }

            if (pneumococcalTestResult.LotNumber == null || pneumococcalTestResult.LotNumber.Reading == null)
            {
                pneumococcalTestResult.ResultStatus.Status = TestResultStatus.Incomplete;
                return pneumococcalTestResult;
            }

            pneumococcalTestResult.ResultStatus.Status = TestResultStatus.Complete;

            return pneumococcalTestResult;
        }

        private TestResult OldResultStateManualEntry(List<ResultReading<int>> compareToResultReadings, TestResult newTestResult)
        {
            if (newTestResult.ResultStatus.StateNumber == (int)TestResultStateNumber.PreAudit) return newTestResult;
            newTestResult.ResultStatus.StateNumber = (int)TestResultStateNumber.ManualEntry;
            var newPneumococcalTestResult = (PneumococcalTestResult)newTestResult;

            foreach (var reading in compareToResultReadings)
            {
                bool returnStatus;

                switch (reading.Label)
                {
                    case ReadingLabels.PneumococcalManufacturer:
                        returnStatus = SynchronizeForChangeReadingSource(compareToResultReadings.Find(resultReading => resultReading.Label == ReadingLabels.PneumococcalManufacturer).ReadingSource, newPneumococcalTestResult.Manufacturer);
                        if (returnStatus) { newPneumococcalTestResult.ResultStatus.StateNumber = (int)TestResultStateNumber.ManualEntry; return newPneumococcalTestResult; }
                        break;

                    case ReadingLabels.PneumococcalLotNumber:
                        returnStatus = SynchronizeForChangeReadingSource(compareToResultReadings.Find(resultReading => resultReading.Label == ReadingLabels.PneumococcalLotNumber).ReadingSource, newPneumococcalTestResult.LotNumber);
                        if (returnStatus) { newPneumococcalTestResult.ResultStatus.StateNumber = (int)TestResultStateNumber.ManualEntry; return newPneumococcalTestResult; }
                        break;
                }
            }

            if (newPneumococcalTestResult.UnableScreenReason != null && newPneumococcalTestResult.UnableScreenReason.Count > 0)
            {
                newPneumococcalTestResult.ResultStatus.StateNumber = (int)TestResultStateNumber.ManualEntry;
                return newPneumococcalTestResult;
            }

            newPneumococcalTestResult.ResultStatus.StateNumber = (int)TestResultStateNumber.ResultsUploaded;
            return newPneumococcalTestResult;
        }

        private TestResult NewResultStateManualEntry(List<ResultReading<int>> compareToResultReadings, TestResult newTestResult)
        {
            if (newTestResult.ResultStatus.StateNumber == (int)NewTestResultStateNumber.PreAudit) return newTestResult;
            newTestResult.ResultStatus.StateNumber = (int)NewTestResultStateNumber.ResultEntryPartial;
            var newPneumococcalTestResult = (PneumococcalTestResult)newTestResult;

            foreach (var reading in compareToResultReadings)
            {
                bool returnStatus;

                switch (reading.Label)
                {
                    case ReadingLabels.PneumococcalManufacturer:
                        returnStatus = SynchronizeForChangeReadingSource(compareToResultReadings.Find(resultReading => resultReading.Label == ReadingLabels.PneumococcalManufacturer).ReadingSource, newPneumococcalTestResult.Manufacturer);
                        if (returnStatus) { newPneumococcalTestResult.ResultStatus.StateNumber = (int)NewTestResultStateNumber.ResultEntryPartial; return newPneumococcalTestResult; }
                        break;

                    case ReadingLabels.PneumococcalLotNumber:
                        returnStatus = SynchronizeForChangeReadingSource(compareToResultReadings.Find(resultReading => resultReading.Label == ReadingLabels.PneumococcalLotNumber).ReadingSource, newPneumococcalTestResult.LotNumber);
                        if (returnStatus) { newPneumococcalTestResult.ResultStatus.StateNumber = (int)NewTestResultStateNumber.ResultEntryPartial; return newPneumococcalTestResult; }
                        break;
                }
            }

            if (newPneumococcalTestResult.UnableScreenReason != null && newPneumococcalTestResult.UnableScreenReason.Count > 0)
            {
                newPneumococcalTestResult.ResultStatus.StateNumber = (int)NewTestResultStateNumber.ResultEntryPartial;
                return newPneumococcalTestResult;
            }

            newPneumococcalTestResult.ResultStatus.StateNumber = (int)NewTestResultStateNumber.ResultEntryPartial;
            return newPneumococcalTestResult;
        }
    }
}