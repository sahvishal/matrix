using System.Collections.Generic;
using Falcon.App.Core.Medical.Domain;
using Falcon.App.Core.Medical.Enum;

namespace Falcon.App.Core.Medical.Impl
{
    //EchocardigramTestSynchronizationService
    public class QualityMeasuresTestResultSynchronizationService : TestResultSynchronizationService
    {
        public QualityMeasuresTestResultSynchronizationService(ReadingSource newTestReadingSource)
        {
            NewReadingSource = newTestReadingSource;
        }

        public override TestResult SynchronizeTestResult(TestResult currentTestResult, TestResult newTestResult, bool isNewResultFlow)
        {
            var newQualityMeasuresTestResult = (QualityMeasuresTestResult)newTestResult;
            SyncronizeTestResult(currentTestResult, newTestResult);

            if (currentTestResult != null)
            {
                newQualityMeasuresTestResult.Id = currentTestResult.Id;
                newTestResult.ResultStatus.Id = currentTestResult.ResultStatus.Id;
            }

            if (NewReadingSource == ReadingSource.Automatic)
            {
                newQualityMeasuresTestResult = (QualityMeasuresTestResult)SyncronizeTestResultForAutomaticUploadwithManual(currentTestResult, newQualityMeasuresTestResult);
            }

            return newQualityMeasuresTestResult;
        }

        public override TestResult GetManualEntryUploadStatus(List<ResultReading<int>> compareToResultReadings, TestResult newTestResult, bool isNewResultFlow)
        {
            if (isNewResultFlow)
            {
                var newQualityMeasuresTestResult = NewResultStateManualEntry(compareToResultReadings, newTestResult);
                if (newQualityMeasuresTestResult.ResultStatus.Status == TestResultStatus.Complete && newQualityMeasuresTestResult.ResultStatus.StateNumber == (int)NewTestResultStateNumber.ResultEntryPartial)
                    newQualityMeasuresTestResult.ResultStatus.StateNumber = (int)NewTestResultStateNumber.ResultEntryCompleted;
                return newQualityMeasuresTestResult;
            }
            return OldResultStateManualEntry(compareToResultReadings, newTestResult);
        }

        public override TestResult IsTestIncomplete(List<ResultReading<int>> compareToResultReadings, TestResult newTestResult, bool isNewResultFlow)
        {
            var qualityMeasureTestResult = newTestResult as QualityMeasuresTestResult;
            if (qualityMeasureTestResult == null) return null;

            if (qualityMeasureTestResult.TestPerformedExternally != null)
            {
                if (qualityMeasureTestResult.TestPerformedExternally.ResultEntryTypeId == (long)ResultEntryType.Chat && qualityMeasureTestResult.TestPerformedExternally.EntryCompleted)
                {
                    newTestResult.ResultStatus.Status = TestResultStatus.Complete;
                }
                else
                {
                    newTestResult.ResultStatus.Status = TestResultStatus.Incomplete;
                }
                return qualityMeasureTestResult;
            }


            qualityMeasureTestResult.ResultStatus.Status =
                (qualityMeasureTestResult.FunctionalAssessmentScore == null || qualityMeasureTestResult.PainAssessmentScore == null ||
                    (qualityMeasureTestResult.ClockFail == null && qualityMeasureTestResult.ClockFail == null) ||
                    (qualityMeasureTestResult.GaitFail == null && qualityMeasureTestResult.GaitPass == null) ||
                    (qualityMeasureTestResult.MemoryRecallScore == null))

                ? TestResultStatus.Incomplete
                : TestResultStatus.Complete;

            return qualityMeasureTestResult;
        }

        private TestResult OldResultStateManualEntry(IEnumerable<ResultReading<int>> compareToResultReadings, TestResult newTestResult)
        {
            if (newTestResult.ResultStatus.StateNumber == (int)TestResultStateNumber.PreAudit) return newTestResult;

            var newQualityMeasuresTestResult = (QualityMeasuresTestResult)newTestResult;

            if (newQualityMeasuresTestResult.UnableScreenReason != null && newQualityMeasuresTestResult.UnableScreenReason.Count > 0)
            {
                newQualityMeasuresTestResult.ResultStatus.StateNumber = (int)TestResultStateNumber.ManualEntry;
            }

            return newQualityMeasuresTestResult;
        }

        private TestResult NewResultStateManualEntry(IEnumerable<ResultReading<int>> compareToResultReadings, TestResult newTestResult)
        {
            if (newTestResult.ResultStatus.StateNumber == (int)NewTestResultStateNumber.PreAudit) return newTestResult;

            var newQualityMeasuresTestResult = (QualityMeasuresTestResult)newTestResult;

            if (newQualityMeasuresTestResult.UnableScreenReason != null && newQualityMeasuresTestResult.UnableScreenReason.Count > 0)
            {
                newQualityMeasuresTestResult.ResultStatus.StateNumber = (int)NewTestResultStateNumber.ResultEntryPartial;
            }

            return newQualityMeasuresTestResult;
        }
    }
}