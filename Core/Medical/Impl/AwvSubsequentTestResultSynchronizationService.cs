using System.Collections.Generic;
using Falcon.App.Core.Extensions;
using Falcon.App.Core.Medical.Domain;
using Falcon.App.Core.Medical.Enum;

namespace Falcon.App.Core.Medical.Impl
{
    public class AwvSubsequentTestResultSynchronizationService : TestResultSynchronizationService
    {
        public AwvSubsequentTestResultSynchronizationService(ReadingSource newTestReadingSource)
        {
            NewReadingSource = newTestReadingSource;
        }

        public override TestResult SynchronizeTestResult(TestResult currentTestResult, TestResult newTestResult, bool isNewResultFlow)
        {
            var newAwvSubsequentTestResult = (AwvSubsequentTestResult)newTestResult;

            if (currentTestResult == null)
            {
                SynchronizeResultReadingsForRecorderMetaData(newTestResult);

                if (!newAwvSubsequentTestResult.ResultImages.IsNullOrEmpty())
                {
                    newAwvSubsequentTestResult.ResultImages = newAwvSubsequentTestResult.ResultImages.FindAll(resultImage => resultImage.File != null);

                    if (newAwvSubsequentTestResult.ResultImages.IsNullOrEmpty()) newAwvSubsequentTestResult.ResultImages = null;
                }

                SyncronizeTestResult(currentTestResult, newTestResult);

                return newAwvSubsequentTestResult;
            }

            var currentAwvSubsequentTestResult = (AwvSubsequentTestResult)currentTestResult;
            newAwvSubsequentTestResult.Id = currentAwvSubsequentTestResult.Id;
            newTestResult.ResultStatus.Id = currentTestResult.ResultStatus.Id;

            if (NewReadingSource == ReadingSource.Automatic)
            {
                if (!currentAwvSubsequentTestResult.ResultImages.IsNullOrEmpty() && !newAwvSubsequentTestResult.ResultImages.IsNullOrEmpty())
                {
                    List<ResultMedia> resultImages = currentAwvSubsequentTestResult.ResultImages.FindAll(image => image.ReadingSource == ReadingSource.Manual);

                    if (resultImages.IsNullOrEmpty()) resultImages = newAwvSubsequentTestResult.ResultImages;
                    else resultImages.AddRange(newAwvSubsequentTestResult.ResultImages);

                    newAwvSubsequentTestResult.ResultImages = resultImages;
                }
                else if (!currentAwvSubsequentTestResult.ResultImages.IsNullOrEmpty())
                {
                    newAwvSubsequentTestResult.ResultImages = currentAwvSubsequentTestResult.ResultImages;
                }
            }
            else
            {
                if (!currentAwvSubsequentTestResult.ResultImages.IsNullOrEmpty() && !currentAwvSubsequentTestResult.ResultImages.IsNullOrEmpty())
                {
                    newAwvSubsequentTestResult.ResultImages.ForEach(resultImage =>
                    {
                        var selectedImage = currentAwvSubsequentTestResult.ResultImages.Find(currentImage => currentImage.File.Path == resultImage.File.Path);
                        if (selectedImage != null)
                            resultImage.ReadingSource = selectedImage.ReadingSource;
                    });
                }
            }

            if (NewReadingSource == ReadingSource.Automatic)
            {
                newAwvSubsequentTestResult.Finding = currentAwvSubsequentTestResult.Finding;
                newAwvSubsequentTestResult = (AwvSubsequentTestResult)SyncronizeTestResultForAutomaticUploadwithManual(currentAwvSubsequentTestResult, newAwvSubsequentTestResult);
            }

            SyncronizeTestResult(currentTestResult, newTestResult);
            return newAwvSubsequentTestResult;
        }

        public override TestResult GetManualEntryUploadStatus(List<ResultReading<int>> compareToResultReadings, TestResult newTestResult, bool isNewResultFlow)
        {
            if (isNewResultFlow)
            {
                var newAwvSubsequentTestResult = NewResultStateManualEntry(compareToResultReadings, newTestResult);
                if (newAwvSubsequentTestResult.ResultStatus.Status == TestResultStatus.Complete && newAwvSubsequentTestResult.ResultStatus.StateNumber == (int)NewTestResultStateNumber.ResultEntryPartial)
                    newAwvSubsequentTestResult.ResultStatus.StateNumber = (int)NewTestResultStateNumber.ResultEntryCompleted;
                return newAwvSubsequentTestResult;
            }
            return OldResultStateManualEntry(compareToResultReadings, newTestResult);
        }

        public override TestResult IsTestIncomplete(List<ResultReading<int>> compareToResultReadings, TestResult newTestResult, bool isNewResultFlow)
        {
            var awvSubsequentTestResult = newTestResult as AwvSubsequentTestResult;
            if (awvSubsequentTestResult == null) return null;

            if (awvSubsequentTestResult.TestPerformedExternally != null)
            {
                if (awvSubsequentTestResult.TestPerformedExternally.ResultEntryTypeId == (long)ResultEntryType.Chat && awvSubsequentTestResult.TestPerformedExternally.EntryCompleted)
                {
                    newTestResult.ResultStatus.Status = TestResultStatus.Complete;
                }
                else
                {
                    newTestResult.ResultStatus.Status = TestResultStatus.Incomplete;
                }
                return awvSubsequentTestResult;
            }

            if (awvSubsequentTestResult.TestPerformedExternally != null && awvSubsequentTestResult.TestPerformedExternally.ResultEntryTypeId == (long)ResultEntryType.Chat)
            {

                if (awvSubsequentTestResult.TestPerformedExternally.EntryCompleted)
                    awvSubsequentTestResult.ResultStatus.Status = TestResultStatus.Complete;
                else
                    awvSubsequentTestResult.ResultStatus.Status = TestResultStatus.Incomplete;

                return awvSubsequentTestResult;

            }

            if (awvSubsequentTestResult.ResultImages != null && awvSubsequentTestResult.ResultImages.Count < 1)

                awvSubsequentTestResult.ResultStatus.Status = TestResultStatus.Incomplete;
            else
                awvSubsequentTestResult.ResultStatus.Status = TestResultStatus.Complete;
            return awvSubsequentTestResult;
        }

        private TestResult OldResultStateManualEntry(IEnumerable<ResultReading<int>> compareToResultReadings, TestResult newTestResult)
        {
            if (newTestResult.ResultStatus.StateNumber == (int)TestResultStateNumber.PreAudit) return newTestResult;
            newTestResult.ResultStatus.StateNumber = (int)TestResultStateNumber.ManualEntry;
            var newAwvSubsequentTestResult = (AwvSubsequentTestResult)newTestResult;

            if (newAwvSubsequentTestResult.UnableScreenReason != null && newAwvSubsequentTestResult.UnableScreenReason.Count > 0)
            {
                newAwvSubsequentTestResult.ResultStatus.StateNumber = (int)TestResultStateNumber.ManualEntry;
                return newAwvSubsequentTestResult;
            }

            newAwvSubsequentTestResult.ResultStatus.StateNumber = (int)TestResultStateNumber.ResultsUploaded;
            return newAwvSubsequentTestResult;
        }

        private TestResult NewResultStateManualEntry(IEnumerable<ResultReading<int>> compareToResultReadings, TestResult newTestResult)
        {
            if (newTestResult.ResultStatus.StateNumber == (int)NewTestResultStateNumber.PreAudit) return newTestResult;
            newTestResult.ResultStatus.StateNumber = (int)NewTestResultStateNumber.ResultEntryPartial;
            var newAwvSubsequentTestResult = (AwvSubsequentTestResult)newTestResult;

            if (newAwvSubsequentTestResult.UnableScreenReason != null && newAwvSubsequentTestResult.UnableScreenReason.Count > 0)
            {
                newAwvSubsequentTestResult.ResultStatus.StateNumber = (int)NewTestResultStateNumber.ResultEntryPartial;
                return newAwvSubsequentTestResult;
            }

            newAwvSubsequentTestResult.ResultStatus.StateNumber = (int)NewTestResultStateNumber.ResultEntryPartial;
            return newAwvSubsequentTestResult;
        }
    }
}
