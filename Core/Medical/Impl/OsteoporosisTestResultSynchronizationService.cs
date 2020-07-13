using System.Collections.Generic;
using Falcon.App.Core.Medical.Domain;
using Falcon.App.Core.Medical.Enum;

namespace Falcon.App.Core.Medical.Impl
{
    public class OsteoporosisTestResultSynchronizationService : TestResultSynchronizationService
    {
        public OsteoporosisTestResultSynchronizationService(ReadingSource newTestReadingSource)
        {
            NewReadingSource = newTestReadingSource;
        }
        public override TestResult SynchronizeTestResult(TestResult currentTestResult, TestResult newTestResult, bool isNewResultFlow)
        {
            var newOsteoTestResult = (OsteoporosisTestResult)newTestResult;

            if (currentTestResult == null)
            {
                SynchronizeResultReadingsForRecorderMetaData(newTestResult);

                if (newOsteoTestResult.ResultImage != null)
                {
                    if (newOsteoTestResult.ResultImage.File == null) newOsteoTestResult.ResultImage = null;
                }

                if (newOsteoTestResult.EstimatedTScore != null && newOsteoTestResult.EstimatedTScore.Reading == null && newOsteoTestResult.EstimatedTScore.Finding == null) newOsteoTestResult.EstimatedTScore = null;
                if (newOsteoTestResult.LeftHeelTScore != null && newOsteoTestResult.LeftHeelTScore.Reading == null) newOsteoTestResult.LeftHeelTScore = null;
                if (newOsteoTestResult.RightHeelTScore != null && newOsteoTestResult.RightHeelTScore.Reading == null) newOsteoTestResult.RightHeelTScore = null;

                SyncronizeTestResult(currentTestResult, newTestResult);

                return newOsteoTestResult;
            }

            var currentOsteoTestResult = (OsteoporosisTestResult)currentTestResult;
            newOsteoTestResult.Id = currentOsteoTestResult.Id;
            newTestResult.ResultStatus.Id = currentTestResult.ResultStatus.Id;
            newOsteoTestResult.EstimatedTScore = SynchronizeResultReading(currentOsteoTestResult.EstimatedTScore, newOsteoTestResult.EstimatedTScore, newTestResult.DataRecorderMetaData);
            newOsteoTestResult.LeftHeelTScore = SynchronizeResultReading(currentOsteoTestResult.LeftHeelTScore, newOsteoTestResult.LeftHeelTScore, newTestResult.DataRecorderMetaData);
            newOsteoTestResult.RightHeelTScore = SynchronizeResultReading(currentOsteoTestResult.RightHeelTScore, newOsteoTestResult.RightHeelTScore, newTestResult.DataRecorderMetaData);

            if (currentOsteoTestResult.ResultImage != null && newOsteoTestResult.ResultImage != null)
            {
                if (newOsteoTestResult.ResultImage.File != null && currentOsteoTestResult.ResultImage.File != null && currentOsteoTestResult.ResultImage.File.Path == newOsteoTestResult.ResultImage.File.Path)
                    newOsteoTestResult.ResultImage = currentOsteoTestResult.ResultImage;

                if (currentOsteoTestResult.ResultImage.ReadingSource == ReadingSource.Manual && newOsteoTestResult.ResultImage.ReadingSource == ReadingSource.Automatic)
                    newOsteoTestResult.ResultImage = currentOsteoTestResult.ResultImage;
            }

            if (newOsteoTestResult.ResultImage != null)
            {
                if (newOsteoTestResult.ResultImage.File == null) newOsteoTestResult.ResultImage = null;
            }


            if (NewReadingSource == ReadingSource.Automatic)
            {
                newOsteoTestResult = (OsteoporosisTestResult)SyncronizeTestResultForAutomaticUploadwithManual(currentOsteoTestResult, newOsteoTestResult);
            }

            SyncronizeTestResult(currentTestResult, newTestResult);
            return newOsteoTestResult;
        }

        public override TestResult GetManualEntryUploadStatus(List<ResultReading<int>> compareToResultReadings, TestResult newTestResult, bool isNewResultFlow)
        {
            if (isNewResultFlow)
            {
                var newOsteoTestResult = NewResultStateManualEntry(compareToResultReadings, newTestResult);
                if (newOsteoTestResult.ResultStatus.Status == TestResultStatus.Complete && newOsteoTestResult.ResultStatus.StateNumber == (int)NewTestResultStateNumber.ResultEntryPartial)
                    newOsteoTestResult.ResultStatus.StateNumber = (int)NewTestResultStateNumber.ResultEntryCompleted;
                return newOsteoTestResult;
            }
            return OldResultStateManualEntry(compareToResultReadings, newTestResult);
        }

        public override TestResult IsTestIncomplete(List<ResultReading<int>> compareToResultReadings, TestResult newTestResult, bool isNewResultFlow)
        {
            var osteoTestResult = newTestResult as OsteoporosisTestResult;
            if (osteoTestResult == null) return null;

            if (osteoTestResult.TestPerformedExternally != null)
            {
                if (osteoTestResult.TestPerformedExternally.ResultEntryTypeId == (long)ResultEntryType.Chat && osteoTestResult.TestPerformedExternally.EntryCompleted)
                {
                    newTestResult.ResultStatus.Status = TestResultStatus.Complete;
                }
                else
                {
                    newTestResult.ResultStatus.Status = TestResultStatus.Incomplete;
                }
                return osteoTestResult;
            }

            foreach (var reading in compareToResultReadings)
            {
                switch (reading.Label)
                {
                    case ReadingLabels.EstimatedTScore:
                        if (IsIncompleteReading(osteoTestResult.EstimatedTScore))
                        {
                            newTestResult.ResultStatus.Status = TestResultStatus.Incomplete;
                            return newTestResult;
                        }
                        break;

                    case ReadingLabels.LeftHeelTScore:
                        if (osteoTestResult.LeftHeelTScore == null)
                        {
                            newTestResult.ResultStatus.Status = TestResultStatus.Incomplete;
                            return newTestResult;
                        }
                        break;

                    case ReadingLabels.RightHeelTScore:
                        if (osteoTestResult.RightHeelTScore == null)
                        {
                            newTestResult.ResultStatus.Status = TestResultStatus.Incomplete;
                            return newTestResult;
                        }
                        break;
                }
            }

            if (osteoTestResult.ResultImage == null || osteoTestResult.ResultImage.File == null)
            {
                osteoTestResult.ResultStatus.Status = TestResultStatus.Incomplete;

                return osteoTestResult;
            }

            newTestResult.ResultStatus.Status = TestResultStatus.Complete;
            return osteoTestResult;
        }

        private TestResult OldResultStateManualEntry(IEnumerable<ResultReading<int>> compareToResultReadings, TestResult newTestResult)
        {
            if (newTestResult.ResultStatus.StateNumber == (int)TestResultStateNumber.PreAudit) return newTestResult;
            var newOsteoTestResult = (OsteoporosisTestResult)newTestResult;

            foreach (var reading in compareToResultReadings)
            {
                bool returnStatus;
                switch (reading.Label)
                {
                    case ReadingLabels.EstimatedTScore:
                        returnStatus = SynchronizeForChangeReadingSource(reading.ReadingSource, newOsteoTestResult.EstimatedTScore);
                        if (returnStatus)
                        {
                            newOsteoTestResult.ResultStatus.StateNumber = (int)TestResultStateNumber.ManualEntry;
                            return newOsteoTestResult;
                        }
                        break;

                    case ReadingLabels.LeftHeelTScore:
                        returnStatus = SynchronizeForChangeReadingSource(reading.ReadingSource, newOsteoTestResult.LeftHeelTScore);
                        if (returnStatus)
                        {
                            newOsteoTestResult.ResultStatus.StateNumber = (int)TestResultStateNumber.ManualEntry;
                            return newOsteoTestResult;
                        }
                        break;

                    case ReadingLabels.RightHeelTScore:
                        returnStatus = SynchronizeForChangeReadingSource(reading.ReadingSource, newOsteoTestResult.RightHeelTScore);
                        if (returnStatus)
                        {
                            newOsteoTestResult.ResultStatus.StateNumber = (int)TestResultStateNumber.ManualEntry;
                            return newOsteoTestResult;
                        }
                        break;
                }
            }

            if (newOsteoTestResult.UnableScreenReason != null && newOsteoTestResult.UnableScreenReason.Count > 0)
            {
                newOsteoTestResult.ResultStatus.StateNumber = (int)TestResultStateNumber.ManualEntry;
                return newOsteoTestResult;
            }
            if (newOsteoTestResult.ResultImage != null && newOsteoTestResult.ResultImage.ReadingSource == ReadingSource.Manual)
            {
                newOsteoTestResult.ResultStatus.StateNumber = (int)TestResultStateNumber.ManualEntry;
                return newOsteoTestResult;
            }


            newOsteoTestResult.ResultStatus.StateNumber = (int)TestResultStateNumber.ResultsUploaded;
            return newOsteoTestResult;
        }

        private TestResult NewResultStateManualEntry(IEnumerable<ResultReading<int>> compareToResultReadings, TestResult newTestResult)
        {
            if (newTestResult.ResultStatus.StateNumber == (int)NewTestResultStateNumber.PreAudit) return newTestResult;
            var newOsteoTestResult = (OsteoporosisTestResult)newTestResult;

            foreach (var reading in compareToResultReadings)
            {
                bool returnStatus;
                switch (reading.Label)
                {
                    case ReadingLabels.EstimatedTScore:
                        returnStatus = SynchronizeForChangeReadingSource(reading.ReadingSource, newOsteoTestResult.EstimatedTScore);
                        if (returnStatus)
                        {
                            newOsteoTestResult.ResultStatus.StateNumber = (int)NewTestResultStateNumber.ResultEntryPartial;
                            return newOsteoTestResult;
                        }
                        break;

                    case ReadingLabels.LeftHeelTScore:
                        returnStatus = SynchronizeForChangeReadingSource(reading.ReadingSource, newOsteoTestResult.LeftHeelTScore);
                        if (returnStatus)
                        {
                            newOsteoTestResult.ResultStatus.StateNumber = (int)NewTestResultStateNumber.ResultEntryPartial;
                            return newOsteoTestResult;
                        }
                        break;

                    case ReadingLabels.RightHeelTScore:
                        returnStatus = SynchronizeForChangeReadingSource(reading.ReadingSource, newOsteoTestResult.RightHeelTScore);
                        if (returnStatus)
                        {
                            newOsteoTestResult.ResultStatus.StateNumber = (int)NewTestResultStateNumber.ResultEntryPartial;
                            return newOsteoTestResult;
                        }
                        break;
                }
            }

            if (newOsteoTestResult.UnableScreenReason != null && newOsteoTestResult.UnableScreenReason.Count > 0)
            {
                newOsteoTestResult.ResultStatus.StateNumber = (int)NewTestResultStateNumber.ResultEntryPartial;
                return newOsteoTestResult;
            }
            if (newOsteoTestResult.ResultImage != null && newOsteoTestResult.ResultImage.ReadingSource == ReadingSource.Manual)
            {
                newOsteoTestResult.ResultStatus.StateNumber = (int)NewTestResultStateNumber.ResultEntryPartial;
                return newOsteoTestResult;
            }


            newOsteoTestResult.ResultStatus.StateNumber = (int)NewTestResultStateNumber.ResultEntryPartial;
            return newOsteoTestResult;
        }
    }
}
