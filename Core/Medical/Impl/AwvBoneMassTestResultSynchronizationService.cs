using System.Collections.Generic;
using Falcon.App.Core.Medical.Domain;
using Falcon.App.Core.Medical.Enum;

namespace Falcon.App.Core.Medical.Impl
{
    public class AwvBoneMassTestResultSynchronizationService : TestResultSynchronizationService
    {
        public AwvBoneMassTestResultSynchronizationService(ReadingSource newTestReadingSource)
        {
            NewReadingSource = newTestReadingSource;
        }

        public override TestResult SynchronizeTestResult(TestResult currentTestResult, TestResult newTestResult, bool isNewResultFlow)
        {
            var newAwvBoneMassTestResult = (AwvBoneMassTestResult)newTestResult;

            if (currentTestResult == null)
            {
                SynchronizeResultReadingsForRecorderMetaData(newTestResult);

                if (newAwvBoneMassTestResult.ResultImage != null)
                {
                    if (newAwvBoneMassTestResult.ResultImage.File == null) newAwvBoneMassTestResult.ResultImage = null;
                }

                if (newAwvBoneMassTestResult.EstimatedTScore != null && newAwvBoneMassTestResult.EstimatedTScore.Reading == null && newAwvBoneMassTestResult.EstimatedTScore.Finding == null) newAwvBoneMassTestResult.EstimatedTScore = null;

                SyncronizeTestResult(currentTestResult, newTestResult);

                return newAwvBoneMassTestResult;
            }

            var currentAwvBoneMassTestResult = (AwvBoneMassTestResult)currentTestResult;
            newAwvBoneMassTestResult.Id = currentAwvBoneMassTestResult.Id;
            newTestResult.ResultStatus.Id = currentTestResult.ResultStatus.Id;

            if (currentAwvBoneMassTestResult.ResultImage != null && newAwvBoneMassTestResult.ResultImage != null)
            {
                if (newAwvBoneMassTestResult.ResultImage.File != null && currentAwvBoneMassTestResult.ResultImage.File != null && currentAwvBoneMassTestResult.ResultImage.File.Path == newAwvBoneMassTestResult.ResultImage.File.Path)
                    newAwvBoneMassTestResult.ResultImage = currentAwvBoneMassTestResult.ResultImage;

                if (currentAwvBoneMassTestResult.ResultImage.ReadingSource == ReadingSource.Manual && newAwvBoneMassTestResult.ResultImage.ReadingSource == ReadingSource.Automatic)
                    newAwvBoneMassTestResult.ResultImage = currentAwvBoneMassTestResult.ResultImage;
            }

            newAwvBoneMassTestResult.EstimatedTScore = SynchronizeResultReading(currentAwvBoneMassTestResult.EstimatedTScore, newAwvBoneMassTestResult.EstimatedTScore, newTestResult.DataRecorderMetaData);

            if (newAwvBoneMassTestResult.ResultImage != null)
            {
                if (newAwvBoneMassTestResult.ResultImage.File == null) newAwvBoneMassTestResult.ResultImage = null;
            }


            if (NewReadingSource == ReadingSource.Automatic)
            {
                newAwvBoneMassTestResult = (AwvBoneMassTestResult)SyncronizeTestResultForAutomaticUploadwithManual(currentAwvBoneMassTestResult, newAwvBoneMassTestResult);
            }

            SyncronizeTestResult(currentTestResult, newTestResult);
            return newAwvBoneMassTestResult;
        }

        public override TestResult GetManualEntryUploadStatus(List<ResultReading<int>> compareToResultReadings, TestResult newTestResult, bool isNewResultFlow)
        {
            if (isNewResultFlow)
            {
                var newAwvBoneMassTestResult = NewResultStateManualEntry(compareToResultReadings, newTestResult);
                if (newAwvBoneMassTestResult.ResultStatus.Status == TestResultStatus.Complete && newAwvBoneMassTestResult.ResultStatus.StateNumber == (int)NewTestResultStateNumber.ResultEntryPartial)
                    newAwvBoneMassTestResult.ResultStatus.StateNumber = (int)NewTestResultStateNumber.ResultEntryCompleted;
                return newAwvBoneMassTestResult;
            }
            return OldResultStateManualEntry(compareToResultReadings, newTestResult);
        }

        public override TestResult IsTestIncomplete(List<ResultReading<int>> compareToResultReadings, TestResult newTestResult, bool isNewResultFlow)
        {
            var awvBoneMassTestResult = newTestResult as AwvBoneMassTestResult;
            if (awvBoneMassTestResult == null) return null;

            if (awvBoneMassTestResult.TestPerformedExternally != null)
            {
                if (awvBoneMassTestResult.TestPerformedExternally.ResultEntryTypeId == (long)ResultEntryType.Chat && awvBoneMassTestResult.TestPerformedExternally.EntryCompleted)
                {
                    newTestResult.ResultStatus.Status = TestResultStatus.Complete;
                }
                else
                {
                    newTestResult.ResultStatus.Status = TestResultStatus.Incomplete;
                }
                return awvBoneMassTestResult;
            }

            foreach (var reading in compareToResultReadings)
            {
                switch (reading.Label)
                {
                    case ReadingLabels.EstimatedTScore:
                        if (IsIncompleteReading(awvBoneMassTestResult.EstimatedTScore))
                        {
                            newTestResult.ResultStatus.Status = TestResultStatus.Incomplete;
                            return newTestResult;
                        }
                        break;
                }
            }

            if (awvBoneMassTestResult.ResultImage == null || awvBoneMassTestResult.ResultImage.File == null)
            {
                awvBoneMassTestResult.ResultStatus.Status = TestResultStatus.Incomplete;

                return awvBoneMassTestResult;
            }


            newTestResult.ResultStatus.Status = TestResultStatus.Complete;
            return awvBoneMassTestResult;
        }

        private TestResult OldResultStateManualEntry(IEnumerable<ResultReading<int>> compareToResultReadings, TestResult newTestResult)
        {
            if (newTestResult.ResultStatus.StateNumber == (int)TestResultStateNumber.PreAudit) return newTestResult;
            var newAwvBoneMassTestResult = (AwvBoneMassTestResult)newTestResult;

            foreach (var reading in compareToResultReadings)
            {
                bool returnStatus;
                switch (reading.Label)
                {
                    case ReadingLabels.EstimatedTScore:
                        returnStatus = SynchronizeForChangeReadingSource(reading.ReadingSource, newAwvBoneMassTestResult.EstimatedTScore);
                        if (returnStatus)
                        {
                            newAwvBoneMassTestResult.ResultStatus.StateNumber = (int)TestResultStateNumber.ManualEntry;
                            return newAwvBoneMassTestResult;
                        }
                        break;
                }
            }

            if (newAwvBoneMassTestResult.UnableScreenReason != null && newAwvBoneMassTestResult.UnableScreenReason.Count > 0)
            {
                newAwvBoneMassTestResult.ResultStatus.StateNumber = (int)TestResultStateNumber.ManualEntry;
                return newAwvBoneMassTestResult;
            }

            if (newAwvBoneMassTestResult.ResultImage != null && newAwvBoneMassTestResult.ResultImage.ReadingSource == ReadingSource.Manual)
            {
                newAwvBoneMassTestResult.ResultStatus.StateNumber = (int)TestResultStateNumber.ManualEntry;
                return newAwvBoneMassTestResult;
            }


            newAwvBoneMassTestResult.ResultStatus.StateNumber = (int)TestResultStateNumber.ResultsUploaded;
            return newAwvBoneMassTestResult;
        }

        private TestResult NewResultStateManualEntry(IEnumerable<ResultReading<int>> compareToResultReadings, TestResult newTestResult)
        {
            if (newTestResult.ResultStatus.StateNumber == (int)NewTestResultStateNumber.PreAudit) return newTestResult;
            var newAwvBoneMassTestResult = (AwvBoneMassTestResult)newTestResult;

            foreach (var reading in compareToResultReadings)
            {
                bool returnStatus;
                switch (reading.Label)
                {
                    case ReadingLabels.EstimatedTScore:
                        returnStatus = SynchronizeForChangeReadingSource(reading.ReadingSource, newAwvBoneMassTestResult.EstimatedTScore);
                        if (returnStatus)
                        {
                            newAwvBoneMassTestResult.ResultStatus.StateNumber = (int)NewTestResultStateNumber.ResultEntryPartial;
                            return newAwvBoneMassTestResult;
                        }
                        break;
                }
            }

            if (newAwvBoneMassTestResult.UnableScreenReason != null && newAwvBoneMassTestResult.UnableScreenReason.Count > 0)
            {
                newAwvBoneMassTestResult.ResultStatus.StateNumber = (int)NewTestResultStateNumber.ResultEntryPartial;
                return newAwvBoneMassTestResult;
            }

            if (newAwvBoneMassTestResult.ResultImage != null && newAwvBoneMassTestResult.ResultImage.ReadingSource == ReadingSource.Manual)
            {
                newAwvBoneMassTestResult.ResultStatus.StateNumber = (int)NewTestResultStateNumber.ResultEntryPartial;
                return newAwvBoneMassTestResult;
            }


            newAwvBoneMassTestResult.ResultStatus.StateNumber = (int)NewTestResultStateNumber.ResultEntryPartial;
            return newAwvBoneMassTestResult;
        }
    }
}
