using System.Collections.Generic;
using Falcon.App.Core.Medical.Domain;
using Falcon.App.Core.Medical.Enum;

namespace Falcon.App.Core.Medical.Impl
{
    public class MonofilamentTestResultSynchronizationService : TestResultSynchronizationService
    {
        public MonofilamentTestResultSynchronizationService(ReadingSource readingSource)
        {
            NewReadingSource = readingSource;
        }

        public override TestResult SynchronizeTestResult(TestResult currentTestResult, TestResult newTestResult, bool isNewResultFlow)
        {
            var monofilamentTestResult = newTestResult as MonofilamentTestResult;

            if (currentTestResult == null)
            {
                SynchronizeResultReadingsForRecorderMetaData(newTestResult);


                if (monofilamentTestResult.RightPositive != null && monofilamentTestResult.RightPositive.Reading == null) monofilamentTestResult.RightPositive = null;
                if (monofilamentTestResult.RightNegative != null && monofilamentTestResult.RightNegative.Reading == null) monofilamentTestResult.RightNegative = null;

                if (monofilamentTestResult.LeftPositive != null && monofilamentTestResult.LeftPositive.Reading == null) monofilamentTestResult.LeftPositive = null;
                if (monofilamentTestResult.LeftNegative != null && monofilamentTestResult.LeftNegative.Reading == null) monofilamentTestResult.LeftNegative = null;

                SyncronizeTestResult(currentTestResult, newTestResult);

                return monofilamentTestResult;
            }

            var currentMonofilamentTestResult = (MonofilamentTestResult)currentTestResult;

            monofilamentTestResult.Id = currentMonofilamentTestResult.Id;
            newTestResult.ResultStatus.Id = currentTestResult.ResultStatus.Id;

            monofilamentTestResult.RightPositive = SynchronizeResultReading(currentMonofilamentTestResult.RightPositive, monofilamentTestResult.RightPositive, newTestResult.DataRecorderMetaData);
            monofilamentTestResult.RightNegative = SynchronizeResultReading(currentMonofilamentTestResult.RightNegative, monofilamentTestResult.RightNegative, newTestResult.DataRecorderMetaData);

            monofilamentTestResult.LeftPositive = SynchronizeResultReading(currentMonofilamentTestResult.LeftPositive, monofilamentTestResult.LeftPositive, newTestResult.DataRecorderMetaData);
            monofilamentTestResult.LeftNegative = SynchronizeResultReading(currentMonofilamentTestResult.LeftNegative, monofilamentTestResult.LeftNegative, newTestResult.DataRecorderMetaData);


            if (NewReadingSource == ReadingSource.Automatic) // Syncing those which didn't come through Uploaded file
            {
                monofilamentTestResult = (MonofilamentTestResult)SyncronizeTestResultForAutomaticUploadwithManual(currentMonofilamentTestResult, monofilamentTestResult);
            }

            SyncronizeTestResult(currentTestResult, newTestResult);
            return monofilamentTestResult;
        }

        public override TestResult GetManualEntryUploadStatus(List<ResultReading<int>> compareToResultReadings, TestResult newTestResult, bool isNewResultFlow)
        {
            if (isNewResultFlow)
            {
                var monofilamentTestResult = NewResultStateManualEntry(compareToResultReadings, newTestResult);
                if (monofilamentTestResult.ResultStatus.Status == TestResultStatus.Complete && monofilamentTestResult.ResultStatus.StateNumber == (int)NewTestResultStateNumber.ResultEntryPartial)
                    monofilamentTestResult.ResultStatus.StateNumber = (int)NewTestResultStateNumber.ResultEntryCompleted;
                return monofilamentTestResult;
            }
            return OldResultStateManualEntry(compareToResultReadings, newTestResult);
        }

        public override TestResult IsTestIncomplete(List<ResultReading<int>> compareToResultReadings, TestResult newTestResult, bool isNewResultFlow)
        {
            var monofilamentTestResult = newTestResult as MonofilamentTestResult;
            if (monofilamentTestResult == null) return null;

            if (monofilamentTestResult.TestPerformedExternally != null)
            {
                if (monofilamentTestResult.TestPerformedExternally.ResultEntryTypeId == (long)ResultEntryType.Chat && monofilamentTestResult.TestPerformedExternally.EntryCompleted)
                {
                    newTestResult.ResultStatus.Status = TestResultStatus.Complete;
                }
                else
                {
                    newTestResult.ResultStatus.Status = TestResultStatus.Incomplete;
                }
                return monofilamentTestResult;
            }


            if ((monofilamentTestResult.RightPositive == null && monofilamentTestResult.RightNegative == null) || (monofilamentTestResult.LeftPositive == null && monofilamentTestResult.LeftNegative == null))
            {
                monofilamentTestResult.ResultStatus.Status = TestResultStatus.Incomplete;
            }

            monofilamentTestResult.ResultStatus.Status = TestResultStatus.Complete;

            return monofilamentTestResult;
        }

        private TestResult OldResultStateManualEntry(IEnumerable<ResultReading<int>> compareToResultReadings, TestResult newTestResult)
        {
            if (newTestResult.ResultStatus.StateNumber == (int)TestResultStateNumber.PreAudit) return newTestResult;
            var monofilamentTestResult = (MonofilamentTestResult)newTestResult;

            foreach (var reading in compareToResultReadings)
            {
                bool returnStatus;
                switch (reading.Label)
                {

                    case ReadingLabels.MonofilamentRightFootSensationIntact:
                        returnStatus = SynchronizeForChangeReadingSource(reading.ReadingSource, monofilamentTestResult.RightPositive);
                        if (returnStatus)
                        {
                            monofilamentTestResult.ResultStatus.StateNumber = (int)TestResultStateNumber.ManualEntry;
                            return monofilamentTestResult;
                        }
                        break;

                    case ReadingLabels.MonofilamentRightFootSensationNotIntact:
                        returnStatus = SynchronizeForChangeReadingSource(reading.ReadingSource, monofilamentTestResult.RightNegative);
                        if (returnStatus)
                        {
                            monofilamentTestResult.ResultStatus.StateNumber = (int)TestResultStateNumber.ManualEntry;
                            return monofilamentTestResult;
                        }
                        break;

                    case ReadingLabels.MonofilamentLeftFootSensationIntact:
                        returnStatus = SynchronizeForChangeReadingSource(reading.ReadingSource, monofilamentTestResult.LeftPositive);
                        if (returnStatus)
                        {
                            monofilamentTestResult.ResultStatus.StateNumber = (int)TestResultStateNumber.ManualEntry;
                            return monofilamentTestResult;
                        }
                        break;

                    case ReadingLabels.MonofilamentLeftFootSensationNotIntact:
                        returnStatus = SynchronizeForChangeReadingSource(reading.ReadingSource, monofilamentTestResult.LeftNegative);
                        if (returnStatus)
                        {
                            monofilamentTestResult.ResultStatus.StateNumber = (int)TestResultStateNumber.ManualEntry;
                            return monofilamentTestResult;
                        }
                        break;
                }
            }

            if (monofilamentTestResult.UnableScreenReason != null && monofilamentTestResult.UnableScreenReason.Count > 0)
            {
                monofilamentTestResult.ResultStatus.StateNumber = (int)TestResultStateNumber.ManualEntry;
                return monofilamentTestResult;
            }

            monofilamentTestResult.ResultStatus.StateNumber = (int)TestResultStateNumber.ResultsUploaded;
            return monofilamentTestResult;
        }

        private TestResult NewResultStateManualEntry(IEnumerable<ResultReading<int>> compareToResultReadings, TestResult newTestResult)
        {
            if (newTestResult.ResultStatus.StateNumber == (int)NewTestResultStateNumber.PreAudit) return newTestResult;
            var monofilamentTestResult = (MonofilamentTestResult)newTestResult;

            foreach (var reading in compareToResultReadings)
            {
                bool returnStatus;
                switch (reading.Label)
                {

                    case ReadingLabels.MonofilamentRightFootSensationIntact:
                        returnStatus = SynchronizeForChangeReadingSource(reading.ReadingSource, monofilamentTestResult.RightPositive);
                        if (returnStatus)
                        {
                            monofilamentTestResult.ResultStatus.StateNumber = (int)NewTestResultStateNumber.ResultEntryPartial;
                            return monofilamentTestResult;
                        }
                        break;

                    case ReadingLabels.MonofilamentRightFootSensationNotIntact:
                        returnStatus = SynchronizeForChangeReadingSource(reading.ReadingSource, monofilamentTestResult.RightNegative);
                        if (returnStatus)
                        {
                            monofilamentTestResult.ResultStatus.StateNumber = (int)NewTestResultStateNumber.ResultEntryPartial;
                            return monofilamentTestResult;
                        }
                        break;

                    case ReadingLabels.MonofilamentLeftFootSensationIntact:
                        returnStatus = SynchronizeForChangeReadingSource(reading.ReadingSource, monofilamentTestResult.LeftPositive);
                        if (returnStatus)
                        {
                            monofilamentTestResult.ResultStatus.StateNumber = (int)NewTestResultStateNumber.ResultEntryPartial;
                            return monofilamentTestResult;
                        }
                        break;

                    case ReadingLabels.MonofilamentLeftFootSensationNotIntact:
                        returnStatus = SynchronizeForChangeReadingSource(reading.ReadingSource, monofilamentTestResult.LeftNegative);
                        if (returnStatus)
                        {
                            monofilamentTestResult.ResultStatus.StateNumber = (int)NewTestResultStateNumber.ResultEntryPartial;
                            return monofilamentTestResult;
                        }
                        break;
                }
            }

            if (monofilamentTestResult.UnableScreenReason != null && monofilamentTestResult.UnableScreenReason.Count > 0)
            {
                monofilamentTestResult.ResultStatus.StateNumber = (int)NewTestResultStateNumber.ResultEntryPartial;
                return monofilamentTestResult;
            }

            monofilamentTestResult.ResultStatus.StateNumber = (int)NewTestResultStateNumber.ResultEntryPartial;
            return monofilamentTestResult;
        }
    }
}